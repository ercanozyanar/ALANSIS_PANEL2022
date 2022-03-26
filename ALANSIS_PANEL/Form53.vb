Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form53
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Form53_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim conn1, cnn As New SqlConnection
        Dim cmd, cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_INCIRAKTARILAN WHERE PARTINO='" & TextBox1.Text & "' ORDER BY ID DESC"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim conn1, cnn As New SqlConnection
        Dim cmd, cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Dim KUTUSAYI, KUTUKG As Integer
        KUTUSAYI = 0
        KUTUKG = 0
        KUTUSAYI = TextBox3.Text
        KUTUKG = TextBox4.Text
        '---------------------------------------------------------------------------------------------------------------
        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        conn1.Open()
        cmd1.Connection = conn1
        cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIRAKTARILAN (TARIH, PARTINO, AKTARILAN_URETICI, AKTARILAN_KUTUSAYI,AKTARILAN_KG) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & KUTUSAYI & "', '" & KUTUKG & "')"
        cmd1.ExecuteNonQuery()
        conn1.Close()
        '---------------------------------------------------------------------------------------------------
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_INCIRAKTARILAN WHERE PARTINO='" & TextBox1.Text & "' ORDER BY ID DESC"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        Dim conn1, cnn As New SqlConnection
        Dim cmd, cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        If TextBox5.Text <> "" Then
            '---------------------------------------------------------------------------------------------------------------
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "DELETE FROM EO_ALANSIS_INCIRAKTARILAN WHERE ID= '" & TextBox5.Text & "'"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            '---------------------------------------------------------------------------------------------------
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_ALANSIS_INCIRAKTARILAN WHERE PARTINO='" & TextBox1.Text & "' ORDER BY ID DESC"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
            cnn.Close()
        Else
            MsgBox("Lütfen Silinecek Kayıtı Seçiniz...")
            Exit Sub
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        On Error Resume Next
        Dim silid
        TextBox5.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub
End Class