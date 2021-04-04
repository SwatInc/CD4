Public Interface IAstmState
    Property Countdown As System.Timers.Timer
    Event OnTimeOut As EventHandler(Of IAstmState)
    Event TransmitData As EventHandler(Of String)
    Event TransmitNextMessage As EventHandler
    Function SendENQ() As IAstmState
    Function ReceiveENQ() As IAstmState
    Function SendNAK() As IAstmState
    Function ReceiveNAK() As IAstmState
    Function SendACK() As IAstmState
    Function ReceiveACK() As IAstmState
    Function SendEOT() As IAstmState
    Function ReceiveEOT() As IAstmState
    Function SendMessage() As IAstmState
    Function ReceiveMessage(data As String) As IAstmState

End Interface