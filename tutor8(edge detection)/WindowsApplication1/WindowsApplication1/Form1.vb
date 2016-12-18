Public Class Form1
    Dim PicAda As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Images|*.GIF; *.TIF;*.JPG;*BMP"
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        PicAda = True
        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If PicAda = False Then
            MsgBox("Pilih dulu gambar yang akan diproses", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Proses gagal")
            Exit Sub
        End If
        Dim source As New Bitmap(PictureBox1.Image)
        Dim sobelResult As New Bitmap(PictureBox1.Image)

        Dim sobelX, sobelY, magnitude As Integer

        Dim neighbourList As ArrayList = New ArrayList
        Call Greyscale()
        For y As Integer = 0 To source.Height - 1
            For x As Integer = 0 To source.Width - 1
                neighbourList.Clear()

                neighbourList = getThreeNeighbourList(x, y, source)

                sobelX = getSobelValue(neighbourList, "X")
                sobelY = getSobelValue(neighbourList, "Y")

                magnitude = Math.Sqrt(Math.Pow(sobelX, 2) + Math.Pow(sobelY, 2))

                If magnitude > 150 Then
                    magnitude = 255
                Else
                    magnitude = 0
                End If

                sobelResult.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude))
            Next x
        Next y

        PictureBox2.Image = sobelResult
        MessageBox.Show("Proses Sobel Telah Selesai")
    End Sub

    Public Function getSobelValue(ByVal neighbourList As ArrayList, ByVal maskType As String) As Integer
        Dim result As Integer = 0

        Dim sobelX As Integer(,) = {{-1, 0, 1}, {-2, 0, 2}, {-1, 0, 1}}
        Dim sobelY As Integer(,) = {{1, 2, 1}, {0, 0, 0}, {-1, -2, -1}}

        Dim count As Integer = 0

        If (maskType.Equals("X")) Then
            For y As Integer = 0 To 2
                For x As Integer = 0 To 2
                    result = result + (sobelX(x, y) * Convert.ToInt16(neighbourList(count)))

                    count = count + 1
                Next x
            Next y
        ElseIf (maskType.Equals("Y")) Then
            For y As Integer = 0 To 2
                For x As Integer = 0 To 2
                    result = result + (sobelY(x, y) * Convert.ToInt16(neighbourList(count)))

                    count = count + 1
                Next x
            Next y
        End If

        Return result
    End Function

    Public Function getThreeNeighbourList(ByVal xPos As Integer, ByVal yPos As Integer, ByVal source As Bitmap) As ArrayList
        Dim neighbourList As ArrayList = New ArrayList

        Dim xStart, xFinish, yStart, yFinish As Integer

        Dim pixel As Integer

        xStart = xPos - 1
        xFinish = xPos + 1

        yStart = yPos - 1
        yFinish = yPos + 1

        For y As Integer = yStart To yFinish
            For x As Integer = xStart To xFinish
                If (x < 0) Or (y < 0) Or (x > source.Width - 1) Or (y > source.Height - 1) Then
                    neighbourList.Add(0)
                Else
                    pixel = source.GetPixel(x, y).R

                    neighbourList.Add(pixel)
                End If
            Next x
        Next y

        Return neighbourList
    End Function
    Private Sub Greyscale()
        Dim source As New Bitmap(PictureBox1.Image)

        Dim red, green, blue, grayscale As Integer

        For y As Integer = 0 To source.Height - 1
            For x As Integer = 0 To source.Width - 1
                red = source.GetPixel(x, y).R
                green = source.GetPixel(x, y).G
                blue = source.GetPixel(x, y).B

                grayscale = red * 0.299 + green * 0.587 + blue * 0.114

                source.SetPixel(x, y, Color.FromArgb(grayscale, grayscale, grayscale))
            Next x
        Next y

        PictureBox1.Image = source
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            SaveFileDialog1.Filter = "JPEG |*.jpg"
            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox2.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
