
Public Class Form1

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        '  Görev yöneticisinde açık dosyayı kapat
        Shell("taskkill /f /im " & "EXE.exe", AppWinStyle.Hide)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim yol As String = Application.StartupPath & "\EXE.exe"
        IO.File.WriteAllBytes(yol, My.Resources.EXE)
        If IO.File.Exists(yol) Then Process.Start(yol)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            Dim dosyaVarmi = My.Computer.FileSystem.FileExists(Application.StartupPath & "\EXE.exe")
            If dosyaVarmi = True Then
                'Dosya açıksa kapat
                Shell("taskkill /f /im " & "EXE.exe", AppWinStyle.Hide)
            End If
            Kill(Application.StartupPath & "\EXE.exe") 'mesaj vermeden Diskten siler

            'Çöp kutusuna taşıma mesajı veren silme kodu
            'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\EXE.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)

        Catch ex As Exception
            MsgBox("dosya bulunmadı")
        End Try

    End Sub

End Class