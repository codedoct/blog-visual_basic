Public Class Form1
    Dim selection As Rectangle
    Dim down As Boolean
    Dim filedialog As New OpenFileDialog
    Dim imagebitmap As Bitmap
    Dim selectioncolour As Color = Color.Black
    Dim bordersize As Integer = 2

    Function changealpha(ByVal colour As Color, ByVal value As Integer) As Color
        Dim c As Color
        c = (Color.FromArgb((value), (colour)))
        Return (c)
    End Function
    Function cropimage(ByVal image As Bitmap) As Bitmap
        Dim cropped As Bitmap = image.Clone(selection, image.PixelFormat)
        Return cropped
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.O
                If Not filedialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then imagebitmap = New Bitmap(filedialog.FileName)
                Me.BackgroundImage = imagebitmap
                Me.BackgroundImageLayout = ImageLayout.None
                Me.Invalidate()
            Case Keys.C
                'cropimage(imagebitmap).Save("C:\Data\")
                Try
                    SaveFileDialog1.Filter = "JPEG |*.jpeg"
                    If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        cropimage(imagebitmap).Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    End If
                Catch ex As Exception
                End Try
            Case Keys.Space
                selection = New Rectangle(New Point(selection.X, selection.Y), New Size(InputBox("width", "", selection.Width), InputBox("height", "", selection.Height)))
                Me.Invalidate()
        End Select
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        selection = New Rectangle(New Point(0, 0), New Size(100, 100))
        Me.Invalidate()
    End Sub
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        down = True
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If down = True Then
            selection = New Rectangle(e.Location, selection.Size)
            Me.Invalidate()
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        down = False
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle((New SolidBrush((changealpha((selectioncolour), 100)))), selection)
        e.Graphics.DrawRectangle((New Pen((New SolidBrush((selectioncolour))), bordersize)), selection)
        e.Graphics.DrawString(selection.Width & "x" & selection.Height, New Font("arial", 10, FontStyle.Regular), Brushes.White, selection.X, selection.Y)
    End Sub
End Class
