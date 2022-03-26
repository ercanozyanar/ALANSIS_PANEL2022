Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form19
    Private Sub Form19_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select* FROM EO_SARF_TUKETIM_SERI WHERE SIPARIS='" & TextBox1.Text & "'"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        On Error Resume Next
        Dim karar, id, partino, seri As String
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        partino = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        id = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        seri = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        karar = MsgBox("SILINECEK KAYIT PARTI NO: " + partino + " SERI NO: " + seri & " EMINMISINIZ...?", vbYesNo)
        If karar = vbYes Then
            '---------------------------------------------------------------------------------------------------------------
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "DELETE EO_SARF_TUKETIM_SERI WHERE ID='" & id & "'"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            '------------------------------------------------------------------------------------------------------------
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select* FROM EO_SARF_TUKETIM_SERI WHERE SIPARIS='" & TextBox1.Text & "'"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.Refresh()
            DataGridView1.DataSource = ds.Tables(0).DefaultView

            '-----------------------------------------------------------------------------------------------------------
        End If
        If karar = vbNo Then
            Exit Sub
        End If

        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class