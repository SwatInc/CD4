Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports Essy.LIS.Connection
Imports Essy.LIS.LIS02A2
Imports Newtonsoft.Json
Imports Serilog.Core
Imports SimpleTcp

Public Class MainViewModel
    Implements ILisConnection
    Private ReadOnly _logger As Logger
    Dim _parser As LISParser
    Private IsTerminateSeqTransmitted As Boolean = False

    Public Event OnReceiveString As LISConnectionReceivedDataEventHandler Implements ILisConnection.OnReceiveString
    Public Event OnLISConnectionClosed As EventHandler Implements ILisConnection.OnLISConnectionClosed
    Public Event OnReceiveTimeOut As EventHandler Implements ILisConnection.OnReceiveTimeOut

    Private Property AstmState As IAstmState
        Get
            Return _astmState
        End Get
        Set
            _astmState = Value
            AddHandler _astmState.OnTimeOut, AddressOf HandleOnAstmTimeOut
            AddHandler _astmState.TransmitData, AddressOf TransmitAstmData
            AddHandler _astmState.TransmitNextMessage, AddressOf TransmitNextMessage
            AddHandler _astmState.MessageverifiedForProcessing, AddressOf OnMessageverified
        End Set
    End Property

    ''' <summary>
    ''' Runs the ASTM string through parser
    ''' </summary>
    ''' <param name="e">ASTM string</param>
    Private Sub OnMessageverified(sender As Object, e As String)

    End Sub

    Private _listener As SimpleTcpServer
    Private _client As SimpleTcpClient
    Private _encodingInUse As Encoding
    Private _ordersToTransmit As Queue(Of String)
    Private _serialPort As SerialPort
    Private _partialMessageViaSerial As String

    Friend Sub LookForOrderFile(orderFilePath As String)
        _logger.Information($"Looking for order file: {orderFilePath}")

        Try
            Dim lines = File.ReadAllLines(orderFilePath)
            _logger.Information("Order file read successfully.")
            ProcessAndAddToQueue(lines)
        Catch ex As Exception
            _logger.Error(ex.Message)
            _logger.Error("Stack Trace" + vbCrLf + ex.StackTrace)
        End Try
    End Sub

    Private Async Sub ProcessAndAddToQueue(lines() As String)
        _logger.Information("Processing the order file.")

        ProcessFrames(lines)
        If _ordersToTransmit.Count = 0 Then
            Return
        End If
        While True
            If _astmState.GetType = (New IdleState(_logger)).GetType() Then
                AstmState = _astmState.SendENQ()
                Exit While
            ElseIf Not _astmState.GetType = (New IdleState(_logger)).GetType() Then
                _logger.Information("Orders exist. Waiting for idle state to transmit")
                Await Task.Delay(10000)
            End If

        End While
    End Sub

    Private Sub ProcessFrames(lines() As String)
        For Each frame In lines
            Dim currentFrame = $"{ChrW(AstmConstants.STX)}{frame}{ChrW(AstmConstants.ETX)}"
            Dim frameWithCheckSum = $"{currentFrame}{StaticFunctions.GetCheckSumValue(currentFrame)}{ChrW(AstmConstants.CR)}{ChrW(AstmConstants.LF)}"
            _ordersToTransmit.Enqueue(frameWithCheckSum)
        Next
    End Sub

    Private Sub TransmitNextMessage(sender As Object, e As EventArgs)
        Try
            If _ordersToTransmit.Peek().Contains("L|1|N") Then
                IsTerminateSeqTransmitted = True
            End If
            TransmitAstmData(Me, _ordersToTransmit.Peek())
            _ordersToTransmit.Dequeue()
        Catch ex As Exception
        End Try
    End Sub

    Private _serverPortIp As String

    Public Sub New(logger As Logger)
        'Initialize socket settings
        Me._logger = logger
        _ordersToTransmit = New Queue(Of String)
        InitializeSocketSettings()
        _partialMessageViaSerial = ""
        _serialPort = New SerialPort
        _parser = New LISParser(Me)

        _logger.Information("Initialize ASTM State to Idle")
        AstmState = New IdleState(_logger)
    End Sub

    Private Sub HandleOnAstmTimeOut(sender As Object, e As IAstmState)
        AstmState = e
    End Sub


    Private Sub TransmitAstmData(sender As Object, e As String)
        If EthernetOrSerial = "Ethernet" Then
            Select Case True
                Case IsServer
                    _listener.Send(_serverPortIp, _encodingInUse.GetBytes(e))
                    _logger.Information($"[TX] : {ReplaceControlCharacters(e)}")
                Case Not IsServer
                    _client.Send(_encodingInUse.GetBytes(e))
                    _logger.Information($"[TX] : {ReplaceControlCharacters(e)}")
                Case Else

            End Select
        ElseIf EthernetOrSerial = "Serial" Then
            _serialPort.Write(e)
            _logger.Information($"[TX] : {ReplaceControlCharacters(e)}")
        End If


    End Sub

    ''' <summary>
    ''' Load settings from config
    ''' </summary>
    Private Sub InitializeSocketSettings()
        _logger.Information("Reading Application settings")
        IpAddress = My.Settings.IpAddress
        Port = My.Settings.Port
        IsServer = My.Settings.IsServer
        MainViewTitle = My.Settings.MainViewTitle
        SocketStatus = My.Settings.SocketStatus
        DataEncoding = My.Settings.DataEncoding
        EthernetOrSerial = My.Settings.EthernetOrSerial
        ComPort = My.Settings.ComPort
        _logger.Information("Completed reading settungs")
        _logger.Information(JsonConvert.SerializeObject(Me, Formatting.Indented))
    End Sub

    Friend Sub ConnectStartCommand()
        If EthernetOrSerial = "Ethernet" Then
            Select Case IsServer
                Case True
                    Try
                        'start listener
                        _listener = InitializeSocketListener()
                        _listener.Start()
                        If _listener.IsListening Then
                            _logger.Information($"Listener started successfully")
                        End If

                        'subscribe for events
                        AddHandler _listener.Events.ClientConnected, AddressOf ListenerClientConnected
                        AddHandler _listener.Events.ClientDisconnected, AddressOf ListenerClientDisconnected
                        AddHandler _listener.Events.DataReceived, AddressOf DataReceivedOnSocket
                    Catch ex As Exception
                        _logger.Error($"Failure to start TCP listener. Error: {ex.Message}")
                        _logger.Error($"Stack Trace{vbCrLf}{ex.StackTrace}")
                    End Try

                Case False
                    _client = InitializeSocketClient()
                    Try
                        _client.Connect()
                        'subscribe for events
                        AddHandler _client.Events.Connected, AddressOf ConnectedToListener
                        AddHandler _client.Events.Disconnected, AddressOf DisconnectedFromListener
                        AddHandler _client.Events.DataReceived, AddressOf DataReceivedOnSocket

                    Catch ex As Exception
                        _logger.Error(ex.Message)
                    End Try


                Case Else

            End Select

        ElseIf EthernetOrSerial = "Serial" Then


            Try
                If Not _serialPort.IsOpen Then
                    _serialPort = New SerialPort With
                                    {
                                        .PortName = "COM2",
                                        .BaudRate = 9600,
                                        .DataBits = 8,
                                        .StopBits = 1,
                                        .Parity = Parity.None,
                                        .ReadBufferSize = 2147483640
                                    }

                    AddHandler _serialPort.DataReceived, AddressOf SerialPortDataReceived
                    _serialPort.Encoding = Encoding.GetEncoding(My.Settings.DataEncoding)

                    _logger.Information($"Trying to open COM port")
                    _serialPort.Open()
                    _logger.Information($"Serial Port opened: {_serialPort.IsOpen}")
                Else
                    _logger.Information($"{_serialPort.PortName} is already opened by Astm Interface")
                End If

            Catch ex As Exception
                _logger.Error($"{ex.Message}{vbCrLf}{ex.StackTrace}")
            End Try


        End If
    End Sub

    Private Sub SerialPortDataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Dim data = _serialPort.ReadExisting
        CommonDataReceivedAction(data)
    End Sub

#Region "Client Events"
    Private Sub DataReceivedOnSocket(sender As Object, e As DataReceivedEventArgs)
        'decode received data
        Dim data = _encodingInUse.GetString(e.Data)
        CommonDataReceivedAction(data)
    End Sub

    Private Sub DisconnectedFromListener(sender As Object, e As EventArgs)
        _logger.Information("Client disconnected from listener.")
    End Sub

    Private Sub ConnectedToListener(sender As Object, e As EventArgs)
        _logger.Information("Client connected to listener.")
    End Sub


#End Region


    Private Sub CommonDataReceivedAction(data As String)
        Select Case True
            Case data = ChrW(AstmConstants.ENQ)
                _logger.Information($"[RX] : {ReplaceControlCharacters(data)}")
                AstmState = AstmState.ReceiveENQ()
            Case data = ChrW(AstmConstants.ACK)
                _logger.Information($"[RX] : {ReplaceControlCharacters(data)}")
                If IsTerminateSeqTransmitted Then
                    AstmState = AstmState.SendEOT()
                    IsTerminateSeqTransmitted = False
                    Return
                End If

                AstmState = AstmState.ReceiveACK()
            Case data = ChrW(AstmConstants.NAK)
                _logger.Information($"[RX] : {ReplaceControlCharacters(data)}")
                AstmState = AstmState.ReceiveNAK()
            Case data = ChrW(AstmConstants.EOT)
                _logger.Information($"[RX] : {ReplaceControlCharacters(data)}")
                AstmState = AstmState.ReceiveEOT()
            Case Else

                If EthernetOrSerial = "Ethernet" Then
                    _logger.Information($"[RX] : {ReplaceControlCharacters(data)}")
                    AstmState = AstmState.ReceiveMessage(data)

                ElseIf EthernetOrSerial = "Serial" Then

                    If data.Contains($"{ChrW(13)}{ChrW(10)}") Then
                        _partialMessageViaSerial += data
                        '_logger.Information($"[RX] : {ReplaceControlCharacters(_partialMessageViaSerial)}")
                        AstmState = AstmState.ReceiveMessage(_partialMessageViaSerial)
                        _partialMessageViaSerial = ""
                    Else
                        _partialMessageViaSerial += data
                    End If

                Else
                    _logger.Information($"[RX] : {ReplaceControlCharacters(data)}")
                End If


        End Select

    End Sub

    Private Function ReplaceControlCharacters(astmFrame As String) As String
        Dim ReplcedAstmFrame As StringBuilder = New StringBuilder(astmFrame)

        ReplcedAstmFrame.Replace(ChrW(AstmConstants.STX), "[STX]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ETX), "[ETX]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.EOT), "[EOT]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ENQ), "[ENQ]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ACK), "[ACK]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.LF), "[LF]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.CR), "[CR]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.NAK), "[NAK]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ETB), "[ETB]")

        Return ReplcedAstmFrame.ToString
    End Function

#Region "Listener Events"
    Private Sub ListenerClientDisconnected(sender As Object, e As ClientDisconnectedEventArgs)
        _logger.Information($"Client diconnected from listener. Reason: {e.Reason}, Info: {e.IpPort}")
        AstmState = New IdleState(_logger)
        _logger.Information("Set ASTM State to Idle")
    End Sub

    Private Sub ListenerClientConnected(sender As Object, e As ClientConnectedEventArgs)
        _serverPortIp = e.IpPort
        _logger.Information($"Client connected. {e.IpPort}")
        AstmState = New IdleState(_logger)
        _logger.Information("Set ASTM State to Idle")
    End Sub

    Private Function InitializeSocketListener() As SimpleTcpServer
        _logger.Information($"Trying to start TCP listener on {IpAddress}:{Port}")
        Return New SimpleTcpServer(IpAddress, Port, False, Nothing, Nothing)
    End Function
    Private Function InitializeSocketClient() As SimpleTcpClient
        _logger.Information($"Initializing TCP client to connect to {IpAddress}:{Port}")
        Return New SimpleTcpClient($"{IpAddress}:{Port}", False, "", "")
    End Function

#Region "ESSY LIS"
    Public Sub SendMessage(aMessage As String) Implements ILisConnection.SendMessage
        Throw New NotImplementedException()
    End Sub

    Public Sub Connect() Implements ILisConnection.Connect
        Throw New NotImplementedException()
    End Sub

    Public Sub DisConnect() Implements ILisConnection.DisConnect
        Throw New NotImplementedException()
    End Sub

    Public Function EstablishSendMode() As Boolean Implements ILisConnection.EstablishSendMode
        Throw New NotImplementedException()
    End Function

    Public Sub StopSendMode() Implements ILisConnection.StopSendMode
        Throw New NotImplementedException()
    End Sub

    Public Sub StartReceiveTimeoutTimer() Implements ILisConnection.StartReceiveTimeoutTimer
        Throw New NotImplementedException()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub

    Public Property Status As LisConnectionStatus Implements ILisConnection.Status
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As LisConnectionStatus)
            Throw New NotImplementedException()
        End Set
    End Property

#End Region

#End Region

    Private _ipAddress As String
    Public Property IpAddress() As String
        Get
            Return _ipAddress
        End Get
        Set(ByVal value As String)
            _ipAddress = value
        End Set
    End Property

    Private _port As Integer
    Public Property Port() As Integer
        Get
            Return _port
        End Get
        Set(ByVal value As Integer)
            _port = value
        End Set
    End Property
    Private _isServer As Boolean
    Public Property IsServer() As Boolean
        Get
            Return _isServer
        End Get
        Set(ByVal value As Boolean)
            _isServer = value
            ConnectStartButtoncaption = If(value = True, "Start Server", "Connect")
        End Set
    End Property

    Private _dataEncoding As String
    Public Property DataEncoding() As String
        Get
            Return _dataEncoding
        End Get
        Set(ByVal value As String)
            _dataEncoding = value
            _encodingInUse = Encoding.GetEncoding(_dataEncoding)
        End Set
    End Property

    Private _connectStartButtonCaption As String
    Public Property ConnectStartButtoncaption() As String
        Get
            Return _connectStartButtonCaption
        End Get
        Set(ByVal value As String)
            _connectStartButtonCaption = value
        End Set
    End Property
    Private _mainViewTitle As String
    Public Property MainViewTitle() As String
        Get
            Return _mainViewTitle
        End Get
        Set(ByVal value As String)
            _mainViewTitle = value
        End Set
    End Property
    Private _socketStatus As String
    Private _astmState As IAstmState

    Public Property SocketStatus() As String
        Get
            Return _socketStatus
        End Get
        Set(ByVal value As String)
            _socketStatus = value
        End Set
    End Property
    Private _ethernetOrSerial As String
    Public Property EthernetOrSerial() As String
        Get
            Return _ethernetOrSerial
        End Get
        Set(ByVal value As String)
            _ethernetOrSerial = value
        End Set
    End Property

    Private _comPort As String

    Public Property ComPort() As String
        Get
            Return _comPort
        End Get
        Set(ByVal value As String)
            _comPort = value
        End Set
    End Property
End Class
