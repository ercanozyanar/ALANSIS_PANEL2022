Public Class Form25

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Form14.ComboBox3.Items.Add(TextBox1.Text)
        Me.Close()
    End Sub
End Class