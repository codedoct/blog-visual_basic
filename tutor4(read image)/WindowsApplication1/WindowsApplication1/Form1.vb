Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "image file (*.jpg) |*.jpg| all files (*.*) | *.*"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Text = "Please Wait..."
        Button2.Enabled = False

        CheckForIllegalCrossThreadCalls = False
        Dim bild As Bitmap = CType(Me.PictureBox1.Image.Clone, Bitmap)
        Dim width As Integer = bild.Width - 1
        Dim height As Integer = bild.Height - 1
        Dim h, i, j As Integer

        For x = 1 To width
            For y = 1 To height

                Dim R, G, B, A As Integer
                R = bild.GetPixel(x, y).R
                G = bild.GetPixel(x, y).G
                B = bild.GetPixel(x, y).B
                A = bild.GetPixel(x, y).A
                h = h + R
                i = i + G
                j = j + B

                RichTextBox1.AppendText(R & "-" & G & "-" & B & "-" & A & "'" & x & "," & y & vbNewLine)
            Next
        Next
        RichTextBox1.Text = RichTextBox1.Text.Substring(0, RichTextBox1.Text.Length - 1)
        RichTextBox1.AppendText("|" & width & "*" & height)
        hasil1.Text = h / 1000
        hasil2.Text = i / 1000
        hasil3.Text = j / 1000

        Button2.Text = "Load Data"
        Button2.Enabled = True
    End Sub
End Class
