
Public Class Form1


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
        ElseIf CheckBox1.Checked = False Then
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.Visible = True
        ElseIf CheckBox2.Enabled = False Then
            TextBox2.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (CheckBox1.Checked = True And CheckBox2.Checked = True) Then
            MessageBox.Show("Semua sudah di check")
        Else
            MessageBox.Show("Semua CheckBox Harus Dicheck")
        End If
    End Sub
End Class