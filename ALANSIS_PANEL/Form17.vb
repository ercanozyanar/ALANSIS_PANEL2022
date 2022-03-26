Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form17
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)

    Private Sub Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"

            cnn.Open()

            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select SATIS_PARTNO,STOK_KODU,STOK_ADI,SIPMIKTAR,TESLIM_TARIHI,URETIM_MIKTAR,TANIM,IMPORTER,TIP,MUSTERI, SIPAMAS,SIPATRA,SIPNO,PALET From EO_ALANAR_SIP_ISLEM WHERE TANIM='0'"

            da.SelectCommand = cmd
            da.Fill(ds)

            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()

    End Sub
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Dim kontrolx
        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.EndEdit()
            Dim kontrol As Integer
            kontrol = DataGridView1.CurrentCell.RowIndex
            Dim Checked As Boolean = CType(DataGridView1.CurrentCell.Value, Boolean)
            If Checked Then
                DataGridView1.Rows(kontrol).DefaultCellStyle.BackColor = Color.Turquoise
                kontrolx = DataGridView1.CurrentRow.Index
                If kontrolx = "0" Then
                    TextBox4.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                End If
                If kontrolx = "1" Then
                    TextBox5.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                End If
                If kontrolx = "2" Then
                    TextBox6.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "3" Then
                    TextBox7.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "4" Then
                    TextBox8.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "5" Then
                    TextBox9.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "6" Then
                    TextBox10.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "7" Then
                    TextBox11.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "8" Then
                    TextBox12.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
                If kontrolx = "9" Then
                    TextBox13.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString
                End If
            Else
                DataGridView1.Rows(kontrol).DefaultCellStyle.BackColor = Color.White
                kontrolx = DataGridView1.CurrentRow.Index
                If kontrolx = "0" Then
                    TextBox4.Text = ""
                End If
                If kontrolx = "1" Then
                    TextBox5.Text = ""
                End If
                If kontrolx = "2" Then
                    TextBox6.Text = ""
                End If
                If kontrolx = "3" Then
                    TextBox7.Text = ""
                End If
                If kontrolx = "4" Then
                    TextBox8.Text = ""
                End If
                If kontrolx = "5" Then
                    TextBox9.Text = ""
                End If
                If kontrolx = "6" Then
                    TextBox10.Text = ""
                End If
                If kontrolx = "7" Then
                    TextBox11.Text = ""
                End If
                If kontrolx = "8" Then
                    TextBox12.Text = ""
                End If
                If kontrolx = "9" Then
                    TextBox13.Text = ""
                End If
            End If
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim barkod, MIKTAR, hammadde, seri, stokkodu, stokadi
        Dim serikont1, serikont2, serikont3, serikont4, serikont5, serikont6, serikont7, serikont8, serikont9, serikont10 As String
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        barkod = Mid(TextBox1.Text, 3, 7)
        seri = Mid(TextBox1.Text, 10, 10)
        MIKTAR = Mid(TextBox1.Text, 20, 7)
        serikont1 = ""
        serikont2 = ""
        serikont3 = ""
        serikont4 = ""
        serikont5 = ""
        serikont6 = ""
        serikont7 = ""
        serikont8 = ""
        serikont9 = ""
        serikont10 = ""
        stokkodu = ""
        stokadi = ""
        If TextBox4.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" And TextBox8.Text = "" And TextBox9.Text = "" And TextBox10.Text = "" And TextBox11.Text = "" And TextBox12.Text = "" And TextBox13.Text = "" Then
            '---------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery21 As String = "Select* From EO_STOKBAR Where BARKOD='" & barkod & "';"
            Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
            Dim reader21 As System.Data.SqlClient.SqlDataReader
            reader21 = SqlComm21.ExecuteReader()
            While reader21.Read()
                TextBox2.Text = reader21("STOK_KODU").ToString()
                TextBox3.Text = reader21("STOK_ADI").ToString()
            End While
            reader21.Close()
            SqlConn.Close()
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('HAMMADDE', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            '---------------------------------------------------------------------------------------------------
        Else

            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery1 As String = "Select* From EO_STOKBAR Where BARKOD='" & barkod & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                TextBox2.Text = reader1("STOK_KODU").ToString()
                TextBox3.Text = reader1("STOK_ADI").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery3 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox4.Text & "';"
            Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
            Dim reader3 As System.Data.SqlClient.SqlDataReader
            reader3 = SqlComm3.ExecuteReader()
            While reader3.Read()
                serikont1 = reader3("SERI").ToString()
            End While
            reader3.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery4 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox5.Text & "';"
            Dim SqlComm4 As New System.Data.SqlClient.SqlCommand(mySelectQuery4, SqlConn)
            Dim reader4 As System.Data.SqlClient.SqlDataReader
            reader4 = SqlComm4.ExecuteReader()
            While reader4.Read()
                serikont2 = reader4("SERI").ToString()
            End While
            reader4.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery5 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox6.Text & "';"
            Dim SqlComm5 As New System.Data.SqlClient.SqlCommand(mySelectQuery5, SqlConn)
            Dim reader5 As System.Data.SqlClient.SqlDataReader
            reader5 = SqlComm5.ExecuteReader()
            While reader5.Read()
                serikont3 = reader5("STOK_KODU").ToString()
            End While
            reader5.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery6 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox7.Text & "';"
            Dim SqlComm6 As New System.Data.SqlClient.SqlCommand(mySelectQuery6, SqlConn)
            Dim reader6 As System.Data.SqlClient.SqlDataReader
            reader6 = SqlComm6.ExecuteReader()
            While reader6.Read()
                serikont4 = reader6("seri").ToString()
            End While
            reader6.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery7 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox8.Text & "';"
            Dim SqlComm7 As New System.Data.SqlClient.SqlCommand(mySelectQuery7, SqlConn)
            Dim reader7 As System.Data.SqlClient.SqlDataReader
            reader7 = SqlComm7.ExecuteReader()
            While reader7.Read()
                serikont5 = reader7("seri").ToString()
            End While
            reader7.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery8 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox9.Text & "';"
            Dim SqlComm8 As New System.Data.SqlClient.SqlCommand(mySelectQuery8, SqlConn)
            Dim reader8 As System.Data.SqlClient.SqlDataReader
            reader8 = SqlComm8.ExecuteReader()
            While reader8.Read()
                serikont6 = reader8("seri").ToString()
            End While
            reader8.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery9 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox10.Text & "';"
            Dim SqlComm9 As New System.Data.SqlClient.SqlCommand(mySelectQuery9, SqlConn)
            Dim reader9 As System.Data.SqlClient.SqlDataReader
            reader9 = SqlComm9.ExecuteReader()
            While reader9.Read()
                serikont7 = reader9("seri").ToString()
            End While
            reader9.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery10 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox12.Text & "';"
            Dim SqlComm10 As New System.Data.SqlClient.SqlCommand(mySelectQuery10, SqlConn)
            Dim reader10 As System.Data.SqlClient.SqlDataReader
            reader10 = SqlComm10.ExecuteReader()
            While reader10.Read()
                serikont8 = reader10("seri").ToString()
            End While
            reader10.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery11 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox12.Text & "';"
            Dim SqlComm11 As New System.Data.SqlClient.SqlCommand(mySelectQuery11, SqlConn)
            Dim reader11 As System.Data.SqlClient.SqlDataReader
            reader11 = SqlComm11.ExecuteReader()
            While reader11.Read()
                serikont9 = reader11("seri").ToString()
            End While
            reader11.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery12 As String = "Select* From EO_SARF_TUKETIM_SERI Where SERI='" & seri & "' And SIPARIS='" & TextBox13.Text & "';"
            Dim SqlComm12 As New System.Data.SqlClient.SqlCommand(mySelectQuery12, SqlConn)
            Dim reader12 As System.Data.SqlClient.SqlDataReader
            reader12 = SqlComm12.ExecuteReader()
            While reader12.Read()
                serikont10 = reader12("seri").ToString()
            End While
            reader12.Close()
            SqlConn.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If TextBox4.Text <> "" And serikont1 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox4.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox5.Text <> "" And serikont2 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox5.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox6.Text <> "" And serikont3 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox6.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox7.Text <> "" And serikont4 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox7.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox8.Text <> "" And serikont5 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox8.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox9.Text <> "" And serikont6 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox9.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox10.Text <> "" And serikont7 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox10.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox11.Text <> "" And serikont8 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox11.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox12.Text <> "" And serikont9 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox12.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
            If TextBox13.Text <> "" And serikont10 = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS) VALUES ('" & TextBox13.Text & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
            End If
        End If
        MsgBox("YUKLEME ISLEMI TAMAMLANMISTIR...")
    End Sub
End Class