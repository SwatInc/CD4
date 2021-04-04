Imports System.Timers
Imports Serilog.Core

Public Class IdleState
    Implements IAstmState

    Private ReadOnly _logger As Logger

    Public Sub New(logger As Logger, Optional interval As Integer = 0)
        Me._logger = logger
        If interval > 0 Then
            Me.Countdown = New Timers.Timer() With {.AutoReset = False, .Interval = interval, .Enabled = True}
            AddHandler Countdown.Elapsed, AddressOf AstmWaitTimeOut
        End If
    End Sub

    Private Sub AstmWaitTimeOut(sender As Object, e As ElapsedEventArgs)
        _logger.Error($"Invalid timeout detected. Action: Ignoring. Interval is {Countdown.Interval} milliseconds at {e.SignalTime}")
        RaiseEvent OnTimeOut(Me, New IdleState(_logger))
    End Sub

    Public Property Countdown As Timers.Timer Implements IAstmState.Countdown
    Public Event OnTimeOut As EventHandler(Of IAstmState) Implements IAstmState.OnTimeOut
    Public Event TransmitData As EventHandler(Of String) Implements IAstmState.TransmitData
    Public Event TransmitNextMessage As EventHandler Implements IAstmState.TransmitNextMessage
    Public Event MessageverifiedForProcessing As EventHandler(Of String) Implements IAstmState.MessageverifiedForProcessing

    Public Function SendENQ() As IAstmState Implements IAstmState.SendENQ
        _logger.Information("Sending ENQ.")
        RaiseEvent TransmitData(Me, ChrW(AstmConstants.ENQ))
        _logger.Information("Activated waiting state for 15 sec.")
        Return New WaitingState(_logger, 15000)
    End Function

    Public Function ReceiveENQ() As IAstmState Implements IAstmState.ReceiveENQ
        Return SendACK()
    End Function

    Public Function SendNAK() As IAstmState Implements IAstmState.SendNAK
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveNAK() As IAstmState Implements IAstmState.ReceiveNAK
        Throw New NotImplementedException()
    End Function

    Public Function SendACK() As IAstmState Implements IAstmState.SendACK
        RaiseEvent TransmitData(Me, ChrW(AstmConstants.ACK))
        _logger.Information("Transitioning to waiting state for 30 seconds.")
        Return New WaitingState(_logger, 30000)
    End Function

    Public Function ReceiveACK() As IAstmState Implements IAstmState.ReceiveACK
        _logger.Warning("Not expecting to receive a ACK at ASTM Idle State. Ignoring")
        Return Me
    End Function

    Public Function SendEOT() As IAstmState Implements IAstmState.SendEOT
        Throw New NotImplementedException
    End Function

    Public Function ReceiveEOT() As IAstmState Implements IAstmState.ReceiveEOT
        _logger.Warning("Not expecting to receive a EOT at ASTM Idle State. Ignoring")
        Return Me
    End Function

    Public Function SendMessage() As IAstmState Implements IAstmState.SendMessage
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveMessage(data As String) As IAstmState Implements IAstmState.ReceiveMessage
        _logger.Warning("Not expecting to receive a message at ASTM Idle State. Ignoring")
        Return New IdleState(_logger)
    End Function
End Class
