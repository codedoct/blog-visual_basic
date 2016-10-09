Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Project_CRUDDataSet.DataUser' table. You can move, or remove it, as needed.
        Me.DataUserTableAdapter.Fill(Me.Project_CRUDDataSet.DataUser)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataUserBindingSource.AddNew()
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        On Error GoTo SaveErr
        DataUserBindingSource.EndEdit()
        DataUserTableAdapter.Update(Project_CRUDDataSet.DataUser)
        MessageBox.Show("Data was saved")
SaveErr:
        Exit Sub
    End Sub
End Class
