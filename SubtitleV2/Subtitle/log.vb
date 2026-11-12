Imports System.IO

Module log
    Public Sub Write_Log(ByVal tmpWrt As String, ByVal direction As Integer, ByVal logName As String) '1 pos 2 neg
        Dim fnum As Integer
        Dim tempswrt() As String
        fnum = FreeFile()
        Try
            If File.Exists(My.Application.Info.DirectoryPath & "\" & logName) Then
                File.Delete(My.Application.Info.DirectoryPath & "\" & logName)
            End If
            'If File.Exists(My.Application.Info.DirectoryPath & "\log.txt") Then
            '    File.Delete(My.Application.Info.DirectoryPath & "\log.txt")
            'End If

            FileOpen(fnum, My.Application.Info.DirectoryPath & "\" & logName, OpenMode.Append)


            If tmpWrt <> "" Then
                tempswrt = Split(tmpWrt, vbNewLine, -1, CompareMethod.Text)

                Dim frm As New Form1

                If direction = 1 Then
                    PrintLine(fnum, Form1.Text & " - Log File")
                    ' PrintLine(fnum, Date.Today)
                    'PrintLine(fnum, "")

                    For n = 0 To UBound(tempswrt) - 1
                        PrintLine(fnum, tempswrt(UBound(tempswrt) - n))
                        Application.DoEvents()
                    Next
                    'Print(fnum, tmpWrt)

                    PrintLine(fnum, "")
                    PrintLine(fnum, "End log")

                ElseIf direction = 2 Then
                    PrintLine(fnum, Form1.Text & " - Log File")
                    ' PrintLine(fnum, Date.Today)
                    'PrintLine(fnum, "")

                    For n = 0 To UBound(tempswrt) - 1
                        PrintLine(fnum, tempswrt(n))
                        Application.DoEvents()
                    Next
                    PrintLine(fnum, "")
                    PrintLine(fnum, "End log")
                End If
            Else
                PrintLine(fnum, "Unknown error ! - no log")
            End If
            FileClose(fnum)
        Catch ex As Exception
            MsgBox(ex.Message & " - Log file could not be created !")
        End Try


    End Sub
End Module
