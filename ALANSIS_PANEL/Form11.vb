Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form11
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        If TextBox1.Text <> "" Then
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE TIP='STOK' ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        If TextBox1.Text = "" Then
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_DEPO WHERE TIP='STOK' ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANAR_SIP_ISLEM;"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            ComboBox1.Items.Add(reader1("SATIS_PARTNO"))
        End While
        reader1.Close()
        SqlConn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim soru, indeks
        Dim conn1, conn2 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        indeks = "0"
        indeks = DataGridView1.CurrentCell.ColumnIndex
        If indeks = "0" Then
            conn2.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            soru = MsgBox("KAYIT SILINECEKTIR EMIN MISINIZ ?", vbExclamation + vbYesNo, "ALANSIS")
            If TextBox1.Text = "" Then
                If soru = vbYes Then
                    conn2.Open()
                    cmd2.Connection = conn2
                    cmd2.CommandText = "DELETE EO_ALANSIS_NAR_DEPO WHERE ID='" & TextBox2.Text & "'"
                    cmd2.ExecuteNonQuery()
                    conn2.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn2.Open()
                    cmd.Connection = conn2
                    cmd.CommandText = "INSERT INTO EO_ALANSIS_LOG (TARIH,KIMLIK, MODUL, DETAY) VALUES ('" & DateTime.Now & "','" & TextBox3.Text & "', 'STOKTAN_YUKLE EO_ALANSIS_NAR_DEPO KAYIT SILINDI','" & TextBox2.Text & "')"
                    cmd.ExecuteNonQuery()
                    conn2.Close()
                    '---------------------------------------------------------------------------------------------------
                    Try
                        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                        cnn.Open()
                        cmd.Connection = cnn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_DEPO WHERE PARTINO='STOK' ORDER BY ID DESC"
                        da.SelectCommand = cmd
                        da.Fill(ds)
                        DataGridView1.DataSource = ds.Tables(0).DefaultView
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    cnn.Close()
                    MsgBox("KAYIT SILINMISTIR...")
                End If
                If soru = vbNo Then
                    Exit Sub
                End If
            End If
            If TextBox1.Text <> "" Then
                If soru = vbYes Then
                    conn2.Open()
                    cmd2.Connection = conn2
                    cmd2.CommandText = "DELETE EO_ALANSIS_NAR_MAMULDEPO WHERE ID='" & TextBox2.Text & "'"
                    cmd2.ExecuteNonQuery()
                    conn2.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn2.Open()
                    cmd2.Connection = conn2
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_LOG (TARIH,KIMLIK, MODUL, DETAY) VALUES ('" & DateTime.Now & "','" & TextBox3.Text & "', 'STOKTAN_YUKLE EO_ALANSIS_NAR_MAMULDEPO KAYIT SILINDI','" & TextBox2.Text & "')"
                    cmd2.ExecuteNonQuery()
                    conn2.Close()
                    '---------------------------------------------------------------------------------------------------
                    Try
                        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                        cnn.Open()
                        cmd.Connection = cnn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='STOK' ORDER BY ID DESC"
                        da.SelectCommand = cmd
                        da.Fill(ds)
                        DataGridView1.DataSource = ds.Tables(0).DefaultView
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    cnn.Close()
                    MsgBox("KAYIT SILINMISTIR...")
                End If
                If soru = vbNo Then
                    Exit Sub
                End If
            End If
        End If
        If indeks = "1" Then
            If TextBox1.Text = "" Then
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "UPDATE EO_ALANSIS_NAR_DEPO SET TIP='HAMMADDE',DEPO='10' WHERE ID='" & TextBox2.Text & "' "
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd.Connection = conn1
                cmd.CommandText = "INSERT INTO EO_ALANSIS_LOG (TARIH,KIMLIK, MODUL, DETAY) VALUES ('" & DateTime.Now & "','" & TextBox3.Text & "', 'STOKTAN_YUKLE EO_ALANSIS_NAR_DEPO TIP:HAMMADDE DEPO:10 OLARAK GUNCELLENDI','" & TextBox2.Text & "')"
                cmd.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------

                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='STOK' ORDER BY ID DESC"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox1.Text <> "" Then
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "UPDATE EO_ALANSIS_NAR_MAMULDEPO SET DEPO='10',PARTINO='" & ComboBox1.Text & "' WHERE ID='" & TextBox2.Text & "' "
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn2.Open()
                cmd.Connection = conn2
                cmd.CommandText = "INSERT INTO EO_ALANSIS_LOG (TARIH,KIMLIK, MODUL, DETAY) VALUES ('" & DateTime.Now & "','" & TextBox3.Text & "', 'STOKTAN_YUKLE EO_ALANSIS_NAR_MAMULDEPO TIP:HAMMADDE DEPO:10 OLARAK GUNCELLENDI','" & TextBox2.Text & "')"
                cmd.ExecuteNonQuery()
                conn2.Close()
                '---------------------------------------------------------------------------------------------------

                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE TIP='STOK' ORDER BY ID DESC"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                '---------------------------------------------------------------------------------------------------
            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class