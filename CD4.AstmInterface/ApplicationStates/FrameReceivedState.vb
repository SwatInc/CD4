Imports System.Timers
Imports Serilog.Core

Public Class FrameReceivedState
    Implements IAstmState

    Private ReadOnly _logger As Logger
    Private ReadOnly interval As Integer
    Public Property Countdown As Timer Implements IAstmState.Countdown

    Public Event OnTimeOut As EventHandler(Of IAstmState) Implements IAstmState.OnTimeOut
    Public Event TransmitData As EventHandler(Of String) Implements IAstmState.TransmitData
    Public Event TransmitNextMessage As EventHandler Implements IAstmState.TransmitNextMessage

    Public Sub New(logger As Logger, Optional _interval As Integer = 0)
        Me._logger = logger
        Me.interval = _interval
    End Sub
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
        Throw New NotImplementedException()
    End Function

    Public Function SendEOT() As IAstmState Implements IAstmState.SendEOT
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveEOT() As IAstmState Implements IAstmState.ReceiveEOT
        _logger.Information("Transitioning from FrameReceived State to Idle")
        Return New IdleState(_logger)
    End Function

    Public Function SendMessage() As IAstmState Implements IAstmState.SendMessage
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveMessage(data As String) As IAstmState Implements IAstmState.ReceiveMessage
        Dim verification = StaticFunctions.IsCheckSumVerified(data)
        If Not verification.IsMatch Then
            RaiseEvent TransmitData(Me, ChrW(AstmConstants.NAK))
        ElseIf verification.IsMatch Then
            RaiseEvent TransmitData(Me, ChrW(AstmConstants.ACK))
        End If
        _logger.Information(verification.LogMessage)
        _logger.Information("Waiting for next frame")
        Return New FrameReceivedState(_logger)
    End Function

End Class
