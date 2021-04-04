Imports System.Timers
Imports Serilog.Core

Public Class DataToSendState
    Implements IAstmState

    Public Property Countdown As Timer Implements IAstmState.Countdown

    Public Event OnTimeOut As EventHandler(Of IAstmState) Implements IAstmState.OnTimeOut
    Public Event TransmitData As EventHandler(Of String) Implements IAstmState.TransmitData
    Public Event TransmitNextMessage As EventHandler Implements IAstmState.TransmitNextMessage
    Private _logger As Logger
    Private _interval As Integer
    Public Sub New(logger As Logger, Optional interval As Integer = 0)
        Me._logger = logger
        Me._interval = interval
    End Sub
    Public Function SendENQ() As IAstmState Implements IAstmState.SendENQ
        _logger.Information("Data to send. Sending ENQ")
        RaiseEvent TransmitData(Me, ChrW(AstmConstants.ENQ))
        Return New WaitingState(_logger, 15000)
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
        Throw New NotImplementedException()
    End Function

    Public Function SendMessage() As IAstmState Implements IAstmState.SendMessage
        Throw New NotImplementedException()
    End Function

    Public Function ReceiveMessage(data As String) As IAstmState Implements IAstmState.ReceiveMessage
        Throw New NotImplementedException()
    End Function
End Class
