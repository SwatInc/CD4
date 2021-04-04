Public Class StaticFunctions
    ''' <summary>
    ''' Reads checksum of an ASTM frame, calculates characters after STX,
    ''' up to and including the ETX or ETB. Method assumes the frame contains an ETX or ETB.
    ''' </summary>
    ''' <param name="rawFrame">frame of ASTM data to evaluate</param>
    ''' <returns>string containing checksum</returns>
    Public Shared Function GetCheckSumValue(ByVal rawFrame As String) As String
        Dim checksum As String = "00"
        Dim byteVal As Integer = 0
        Dim sumOfChars As Integer = 0
        Dim complete As Boolean = False
        For idx As Integer = 0 To rawFrame.Length - 1
            byteVal = Convert.ToInt32(rawFrame(idx))
            Select Case byteVal
                Case AstmConstants.STX
                    sumOfChars = 0
                Case AstmConstants.ETX, AstmConstants.ETB
                    sumOfChars += byteVal
                    complete = True
                Case Else
                    sumOfChars += byteVal
            End Select

            If complete Then Exit For
        Next

        If sumOfChars > 0 Then
            checksum = Convert.ToString(sumOfChars Mod 256, 16).ToUpper()
        End If

        Return CStr((If(checksum.Length = 1, "0" & checksum, checksum)))
    End Function

    Public Shared Function IsCheckSumVerified(rawFrame As String) As CheckSumVerificationModel
        Dim frameCheckSum = Left(Right(rawFrame, 4), 2)
        Dim calculatedCheckSum = StaticFunctions.GetCheckSumValue(rawFrame)

        Return If(frameCheckSum = calculatedCheckSum,
            New CheckSumVerificationModel() With {
                .LogMessage = $"Checksum verified. Frame: {frameCheckSum}, Calculated: {calculatedCheckSum}",
                .IsMatch = True
            },
            New CheckSumVerificationModel() With {
                .LogMessage = $"Checksum mismatch! Frame: {frameCheckSum}, Calculated: {calculatedCheckSum}",
                .IsMatch = False
            })

    End Function
End Class
