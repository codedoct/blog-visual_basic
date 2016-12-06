Public Class Form1
    Dim bild As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Text = "waiting"
        Button1.Enabled = False

        CheckForIllegalCrossThreadCalls = False

        Dim width As Integer = CInt(TextBox1.Text.Split(CChar("|"))(1).Split(CChar("*"))(0))
        Dim height As Integer = CInt(TextBox1.Text.Split(CChar("|"))(1).Split(CChar("*"))(1))
        bild = New Bitmap(width, height)

        TextBox1.Text = TextBox1.Text.Split(CChar("|"))(0)

        For Each line In TextBox1.Lines

            Dim farbe As String = line.Split(CChar("'"))(0)
            Dim R, G, B, A As Integer
            Dim geteilt() As String = farbe.Split(CChar("-"))

            R = CInt(geteilt(0))
            G = CInt(geteilt(1))
            B = CInt(geteilt(2))
            A = CInt(geteilt(3))

            Dim x As Integer = CInt(CDbl(line.Split(CChar("'"))(1).Split(CChar(","))(0)))
            Dim y As Integer = CInt(CDbl(line.Split(CChar("'"))(1).Split(CChar(","))(1)))

            Dim c As Color = Color.FromArgb(A, R, G, B)
            bild.SetPixel(CInt(x) - 1, CInt(y) - 1, c)
        Next
        PictureBox1.Image = bild
        Button1.Text = "Done"
        Button1.Enabled = True
    End Sub
End Class
