Imports System.IO

Public Class Form1

    Dim log As String
    Dim fileNameL5K As String
    Dim FolderName As String
    Dim streamText As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button7.Enabled = False
        Choose_Folder()
        Button1.Enabled = True
        Button7.Enabled = True
    End Sub

    Private Sub file_path(ByVal filenames As String)
        Try

            Using sr As New StreamReader(filenames, encoding:=System.Text.Encoding.GetEncoding("iso-8859-2"))
                streamText = sr.ReadToEnd

                TextBox3.Text = streamText

                Dim iso_8859_2 As System.Text.Encoding = System.Text.Encoding.GetEncoding("iso-8859-2")
                Dim utf_8 As System.Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")

                Dim s_unicode As String = streamText

                Dim isoBytes() As Byte = iso_8859_2.GetBytes(s_unicode)

                Dim utf8Bytes() As Byte = System.Text.Encoding.Convert(iso_8859_2, utf_8, isoBytes)

                TextBox2.Text = System.Text.Encoding.UTF8.GetString(utf8Bytes)

            End Using

            Dim ALPHAVAL As String = filenames

            If System.IO.File.Exists(ALPHAVAL) = True Then
                Dim objWriter As New System.IO.StreamWriter(ALPHAVAL, False, System.Text.Encoding.GetEncoding("utf-8"))
                objWriter.WriteLine(TextBox2.Text)
                objWriter.Close()
            End If

        Catch es As Exception
            MsgBox(es.Message)
            LogTXT.Text += vbNewLine & es.Message

        End Try
    End Sub
    Private Sub encode_file(ByVal encoded_file As String)
        Dim ALPHAVAL As String = encoded_file

        If System.IO.File.Exists(ALPHAVAL) = True Then
            Dim objWriter As New System.IO.StreamWriter(ALPHAVAL, False, System.Text.Encoding.GetEncoding("utf-8"))
            objWriter.WriteLine(TextBox2.Text)
            objWriter.Close()
        End If

    End Sub
    Private Sub Search_Srt(ByVal pathh As String)

        Dim Files As String()

        Files = Directory.GetFileSystemEntries(pathh)
        Dim element As String

        For Each element In Files
            If Directory.Exists(element) Then
                Search_Srt(element)
            Else

                If InStr(element, ".srt", CompareMethod.Text) > 0 Then
                    log = "srt file  " & element & vbNewLine & log
                    file_path(element)
                    LogTXT.Text += vbNewLine & element
                    Application.DoEvents()

                End If

            End If

            Application.DoEvents()
        Next


    End Sub

    Private Sub Choose_Folder()
        Dim folderBrowserDialog As New FolderBrowserDialog With {
            .Description = "Get Folder",
            .RootFolder = Environment.SpecialFolder.Desktop,
            .ShowNewFolderButton = True
}


        If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try

                FolderName = folderBrowserDialog.SelectedPath

                Search_Srt(FolderName)

            Catch es As Exception
                Console.WriteLine("The file could not be read: ")
                Console.WriteLine(es.Message)

            End Try

        End If
        LogTXT.Text += vbNewLine & vbNewLine & "Finish"
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim openFileDialog2 As New OpenFileDialog()

        openFileDialog2.InitialDirectory = ""
        openFileDialog2.Filter = "srt File|*.srt"

        openFileDialog2.FilterIndex = 1
        openFileDialog2.RestoreDirectory = True

        If openFileDialog2.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Try
                fileNameL5K = openFileDialog2.FileName
                Try

                    Using sr As New StreamReader(fileNameL5K, encoding:=System.Text.Encoding.GetEncoding("iso-8859-2"))
                        streamText = sr.ReadToEnd

                        TextBox3.Text = streamText

                        Dim iso_8859_2 As System.Text.Encoding = System.Text.Encoding.GetEncoding("iso-8859-2")
                        Dim utf_8 As System.Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")

                        Dim s_unicode As String = streamText

                        Dim isoBytes() As Byte = iso_8859_2.GetBytes(s_unicode)

                        Dim utf8Bytes() As Byte = System.Text.Encoding.Convert(iso_8859_2, utf_8, isoBytes)


                        TextBox2.Text = System.Text.Encoding.UTF8.GetString(utf8Bytes)

                    End Using

                    Dim ALPHAVAL As String = fileNameL5K

                    If System.IO.File.Exists(ALPHAVAL) = True Then
                        Dim objWriter As New System.IO.StreamWriter(ALPHAVAL, False, System.Text.Encoding.GetEncoding("utf-8"))
                        objWriter.WriteLine(TextBox2.Text)
                        objWriter.Close()
                    End If

                Catch es As Exception
                    MsgBox(es.Message)
                End Try
            Catch es As Exception
                MsgBox(es.Message)
            End Try
        Else
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    Public Function GetPath(ByVal paths As String, ByVal FileFolder As Integer) As String
        Dim SubPathFolder As String = ""
        Dim SubPathFile As String = ""
        Try
            If paths <> "" Then
                SubPathFolder = paths.Substring(0, paths.LastIndexOf("\") + 1)
                SubPathFile = Mid(paths, paths.LastIndexOf("\") + 2, Len(paths) - paths.LastIndexOf("\") + 1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in getting Path")
        End Try

        If FileFolder = 1 Then
            Return SubPathFile
        ElseIf FileFolder = 2 Then
            Return SubPathFolder
        Else
            Return "Error"
        End If

    End Function




End Class
