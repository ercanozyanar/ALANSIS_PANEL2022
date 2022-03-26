Public Class Form21

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Form14.ComboBox4.Items.Add(TextBox1.Text)
        Me.Close()
    End Sub
End Class