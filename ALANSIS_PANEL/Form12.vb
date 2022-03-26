Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form12
    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_MAMUL_RECETE_OTO WHERE SIPARISNO='" & TextBox1.Text & "'"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim soru, indeks
        Dim conn1, conn2 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        indeks = "0"
        indeks = DataGridView1.CurrentCell.ColumnIndex
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        If indeks = "0" Then
            conn2.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            soru = MsgBox("KAYIT SILINECEKTIR EMIN MISINIZ ?", vbExclamation + vbYesNo, "ALANSIS")
            If soru = vbYes Then
                conn2.Open()
                cmd2.Connection = conn2
                cmd2.CommandText = "DELETE EO_MAMUL_RECETE_OTO WHERE ID='" & TextBox2.Text & "'"
                cmd2.ExecuteNonQuery()
                conn2.Close()
                '--------------------------------------------------------------------------------
                conn2.Open()
                cmd.Connection = conn2
                cmd.CommandText = "INSERT INTO EO_ALANSIS_LOG (TARIH,KIMLIK, MODUL, DETAY) VALUES ('" & DateTime.Now & "','" & TextBox3.Text & "', 'RECETE EO_MAMUL_RECETE_OTO ID SILINDI','" & TextBox2.Text & "')"
                cmd.ExecuteNonQuery()
                conn2.Close()
                '---------------------------------------------------------------------------------------------------

                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_MAMUL_RECETE_OTO WHERE SIPARISNO='" & TextBox1.Text & "'"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cnn.Close()
                '------------------------------------------------------------------------------------
                MsgBox("KAYIT SILINMIŞTIR...")
            End If
            If soru = vbNo Then
                Exit Sub
            End If
        End If

    End Sub
End Class