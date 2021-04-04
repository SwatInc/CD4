Imports System.Timers

Friend Class WaitingState
    Implements IAstmState

    Private _logger As Serilog.Core.Logger
    Private _interval As Integer

    Public Sub New(logger As Serilog.Core.Logger, interval As Integer)
        _logger = logger
        _interval = interval
        ActivateTimer()
    End Sub

    Private Sub ActivateTimer()
        If _interval > 0 Then
            Countdown = New Timers.Timer() With {.AutoReset = False, .Interval = _interval, .Enabled = True}
            _logger.Information($"Waiting state activated for {_interval} milliseconds")
            AddHandler Countdown.Elapsed, AddressOf AstmWaitTimeOut
            Countdown.Start()
        End If
    End Sub

    Private Sub AstmWaitTimeOut(sender As Object, e As ElapsedEventArgs)
        _logger.Information($"Waiting state for {_interval} milliseconds timed-out at {e.SignalTime}. Transitioning to Idle.")
        RaiseEvent TransmitData(Me, ChrW(AstmConstants.EOT))
        RaiseEvent OnTimeOut(Me, New IdleState(_logger))
    End Sub

    Public Property Countdown As System.Timers.Timer Implements IAstmState.Countdown
    Public Event OnTimeOut As EventHandler(Of IAstmState) Implements IAstmState.OnTimeOut
    Public Event TransmitData As EventHandler(Of String) Implements IAstmState.TransmitData
    Public Event TransmitNextMessage As EventHandler Implements IAstmState.TransmitNextMessage

    Public Function SendENQ() As IAstmState Implements IAstmState.SendENQ
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveENQ() As IAstmState Implements IAstmState.ReceiveENQ
        Throw New NotImplementedException()
    End Function

    Public Function SendNAK() As IAstmState Implements IAstmState.SendNAK
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveNAK() As IAstmState Implements IAstmState.ReceiveNAK
        Throw New NotImplementedException()
    End Function

    Public Function SendACK() As IAstmState Implements IAstmState.SendACK
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveACK() As IAstmState Implements IAstmState.ReceiveACK
        _logger.Information("Continuing with transmissions")
        RaiseEvent TransmitNextMessage(Me, EventArgs.Empty)
        If Not Countdown Is Nothing Then
            Countdown.Enabled = False
        End If
        Return New WaitingState(_logger, 1500)
    End Function

    Public Function SendEOT() As IAstmState Implements IAstmState.SendEOT
        If Not Countdown Is Nothing Then
            Countdown.Enabled = False
        End If
        _interval = 0
        RaiseEvent TransmitData(Me, ChrW(AstmConstants.EOT))
        _logger.Information($"Transitioning from Waiting State to Idle State.")
        Return New IdleState(_logger)
    End Function

    Public Function ReceiveEOT() As IAstmState Implements IAstmState.ReceiveEOT
        Countdown.Enabled = False
        _logger.Information($"Transitioning from Waiting State to Idle State.")
        Return New IdleState(_logger)
    End Function

    Public Function SendMessage() As IAstmState Implements IAstmState.SendMessage
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveMessage(data As String) As IAstmState Implements IAstmState.ReceiveMessage
        Countdown.Enabled = False
        Dim verification = StaticFunctions.IsCheckSumVerified(data)
        If Not verification.IsMatch Then
            RaiseEvent TransmitData(Me, ChrW(AstmConstants.NAK))
        ElseIf verification.IsMatch Then
            RaiseEvent TransmitData(Me, ChrW(AstmConstants.ACK))
        End If
        _logger.Information(verification.LogMessage)
        _logger.Information("Transitioning from Waiting state to FrameReceived State")
        Return New FrameReceivedState(_logger)
    End Function
End Class
