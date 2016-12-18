Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Masukkan Gambar"
        OpenFileDialog1.Filter = "image file (*.jpg) |*.jpg| image file (*.psd) |*.psd| image file (*.png) |*.png| image file (*.gif) |*.gif| image file (*.bmp) |*.bmp| all files (*.*) | *.*"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedItem = "JPEG" Then
            Try
                SaveFileDialog1.Filter = "JPEG |*.jpeg"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
            End Try
        End If
        If ComboBox1.SelectedItem = "PSD" Then
            Try
                SaveFileDialog1.Filter = "PSD |*.psd"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
            End Try
        End If
        If ComboBox1.SelectedItem = "PNG" Then
            Try
                SaveFileDialog1.Filter = "PNG |*.png"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
            End Try
        End If
        If ComboBox1.SelectedItem = "GIF" Then
            Try
                SaveFileDialog1.Filter = "GIF |*.gif"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
            End Try
        End If
        If ComboBox1.SelectedItem = "BMP" Then
            Try
                SaveFileDialog1.Filter = "BMP |*.bmp"
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
            End Try
        End If
        MsgBox("Success")
    End Sub

    Private Sub Form1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "JPEG"
    End Sub
End Class
