Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Project_CRUDDataSet1.DataUser' table. You can move, or remove it, as needed.
        Me.DataUserTableAdapter.Fill(Me.Project_CRUDDataSet1.DataUser)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataUserBindingSource.AddNew()
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        On Error GoTo SaveErr
        DataUserBindingSource.EndEdit()
        DataUserTableAdapter.Update(Project_CRUDDataSet1.DataUser)
        MessageBox.Show("Data was saved")
SaveErr:
        Exit Sub
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataUserBindingSource.MovePrevious()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataUserBindingSource.MoveNext()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataUserBindingSource.RemoveCurrent()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class
