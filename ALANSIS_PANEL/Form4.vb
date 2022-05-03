Public Class Form4

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox5.Text = "KIRAZ" Then
            Form29.TextBox6.Text = TextBox4.Text
            Form29.Show()
            Me.Close()
        End If
        If TextBox5.Text = "NAR" Then
            Form62.TextBox6.Text = TextBox4.Text
            Form62.Show()
            Me.Close()
        End If
        If TextBox5.Text = "INCIR" Then
            Form47.TextBox6.Text = TextBox4.Text
            Form47.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class