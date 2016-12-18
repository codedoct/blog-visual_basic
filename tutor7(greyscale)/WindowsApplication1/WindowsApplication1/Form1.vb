Imports System.Drawing.Imaging
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "image file (*.jpg) |*.jpg| all files (*.*) | *.*"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = gray(PictureBox1.Image)
    End Sub

    Public Function gray(ByVal image As Bitmap) As Bitmap
        Dim a As New Bitmap(image.Width, image.Height)
        Dim b As Graphics = Graphics.FromImage(a)
        Dim c As New ColorMatrix(New Single()() {New Single() {0.3F, 0.3F, 0.3F, 0, 0},
                                                 New Single() {0.59F, 0.59F, 0.59F, 0, 0},
                                                 New Single() {0.11F, 0.11F, 0.11F, 0, 0},
                                                 New Single() {0, 0, 0, 1, 0},
                                                 New Single() {0, 0, 0, 0, 1}})
        Dim d As New ImageAttributes()
        d.SetColorMatrix(c)
        b.DrawImage(image, New Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, d)
        d.Dispose()
        Return a
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            SaveFileDialog1.Filter = "JPEG |*.jpeg"
            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
