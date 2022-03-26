
Public Class Form1

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Form2.Text = "ALANSIS :" + Trim(Mid(Label1.Text, 10, 20))
        Form2.TextBox1.Text = "NAR "
        Form2.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = DateTime.Now
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Hide()
        Form2.Text = "ALANSIS :" + Trim(Mid(Label1.Text, 10, 30))
        Form2.TextBox1.Text = "KIVI"
        Form2.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Text = "ALANSIS :" + Trim(Mid(Label1.Text, 10, 20))
        Form2.TextBox1.Text = "KIRAZ"
        Form2.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Form2.Text = "ALANSIS :" + Trim(Mid(Label1.Text, 10, 20))
        Form2.TextBox1.Text = "INCIR"
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Text = "ALANSIS :" + Trim(Mid(Label1.Text, 10, 20))
        Form2.TextBox1.Text = "ERIK"
        Form2.Show()
    End Sub
End Class
