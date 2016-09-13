Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If File.Exists(OpenFileDialog2.FileName) = True Then
            If RichTextBox1.Text = "" And RichTextBox1.Visible = True Then
                MessageBox.Show("Cannot save, Text is empty")
            ElseIf RichTextBox1.Visible = False Then
                MessageBox.Show("Please click button Edit first")
            Else
                If Label1.Text = RichTextBox1.Text Then
                    MessageBox.Show("Nothing change")
                Else
                    Dim writeFile As New StreamWriter(OpenFileDialog2.FileName, False)
                    writeFile.Write(RichTextBox1.Text)
                    writeFile.Close()
                    MessageBox.Show("File Was Write")
                End If
            End If
        ElseIf File.Exists(OpenFileDialog2.FileName) = False Then
            MessageBox.Show("File txt not found, Open first")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim openFile As StreamReader
        OpenFileDialog2.CheckFileExists = True
        OpenFileDialog2.CheckPathExists = True
        OpenFileDialog2.DefaultExt = "txt"
        OpenFileDialog2.FileName = ""
        OpenFileDialog2.Filter = "test|*.txt"
        OpenFileDialog2.Multiselect = False
        If OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            openFile = New StreamReader(OpenFileDialog2.FileName, True)
            Label1.Text = openFile.ReadToEnd
            Label1.Visible = True
            RichTextBox1.Visible = False
            openFile.Close()
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFile As StreamReader
        If File.Exists(OpenFileDialog2.FileName) = False Then
            MessageBox.Show("Open file first")
        Else
            openFile = New StreamReader(OpenFileDialog2.FileName, True)
            RichTextBox1.Text = openFile.ReadToEnd
            Label1.Visible = False
            RichTextBox1.Visible = True
            openFile.Close()
        End If
    End Sub
End Class
