Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form38
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Form38_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"

            cnn.Open()

            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT PARTI,'KIVI '+MUSTERI AS STOK_ADI,MUSTERI,'KIVI' AS TIP,PALET_ADET,SINIF,KUTU,AMBALAJ,EBAT,PALET_TIPI FROM EO_ALANAR_KIVISIP_ISLEM"

            da.SelectCommand = cmd
            da.Fill(ds)

            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
    End Sub
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        TextBox18.Text = ""
        TextBox19.Text = ""
        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.EndEdit()
            Dim kontrol As Integer
            kontrol = DataGridView1.CurrentCell.RowIndex
            Dim Checked As Boolean = CType(DataGridView1.CurrentCell.Value, Boolean)
            If Checked Then
                TextBox18.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                DataGridView1.Rows(kontrol).DefaultCellStyle.BackColor = Color.Turquoise


            Else
                TextBox19.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
                DataGridView1.Rows(kontrol).DefaultCellStyle.BackColor = Color.White
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        If TextBox16.Text = "" Then
            MsgBox("LUTFEN TARTILAN DEGERI GIRINIZ")
            TextBox16.Select()
        Else
            Dim barkod, hammadde, seri, stokkodu, stokadi, kontrol, firex
            Dim serikont, serihamkont As String
            Dim MIKTAR, YUK_MIKTAR, FIRE As Integer
            Dim conn1 As New SqlConnection
            Dim cmd1 As New SqlCommand
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            barkod = ""
            hammadde = ""
            seri = ""
            kontrol = ""
            serikont = ""
            serihamkont = ""
            stokkodu = ""
            stokadi = ""
            MIKTAR = 0
            YUK_MIKTAR = 0
            FIRE = 0
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            barkod = Mid(TextBox1.Text, 3, 7)
            seri = Mid(TextBox1.Text, 10, 10)
            MIKTAR = CInt(Mid(TextBox1.Text, 20, 7))
            TextBox15.Text = MIKTAR
            YUK_MIKTAR = CInt(TextBox16.Text)
            FIRE = MIKTAR - YUK_MIKTAR
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
            '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If ListBox1.Items.Count = 0 Then
                SqlConn.Open()
                Dim mySelectQuery32 As String = "Select* From EO_SARF_TUKETIM_SERI Where (SERI='" & seri & "' or SERI='" & TextBox1.Text & "') And SIPARIS='HAMMADDE';"
                Dim SqlComm32 As New System.Data.SqlClient.SqlCommand(mySelectQuery32, SqlConn)
                Dim reader32 As System.Data.SqlClient.SqlDataReader
                reader32 = SqlComm32.ExecuteReader()
                While reader32.Read()
                    serihamkont = reader32("SERI").ToString()
                End While
                reader32.Close()
                SqlConn.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If serihamkont = "" Then
                    If barkod = "2800578" Then
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS,USR) VALUES ('HAMMADDE', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0','" & TextBox14.Text & "')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_ALANSIS_FIRE (TARIH, BARKOD, SERI, STOK_KODU, STOK_ADI, BARKOD_MIKTAR, FIRE_MIKTAR,TIP) VALUES ('" & DateTime.Today & "','" & TextBox1.Text & "', '" & seri & "','" & TextBox2.Text & "'  ,'" & TextBox3.Text & "','" & FIRE & "' ,'" & TextBox16.Text & "','HAMMADDE')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    ElseIf barkod = "2800579" Then
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS,USR) VALUES ('HAMMADDE', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox1.Text & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0','" & TextBox14.Text & "')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_ALANSIS_FIRE (TARIH, BARKOD, SERI, STOK_KODU, STOK_ADI, BARKOD_MIKTAR, FIRE_MIKTAR,TIP) VALUES ('" & DateTime.Today & "','" & TextBox1.Text & "', '" & seri & "','" & TextBox2.Text & "'  ,'" & TextBox3.Text & "','" & FIRE & "' ,'" & TextBox16.Text & "','MAMUL')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPOYARI SELECT* FROM EO_ALANSIS_KIVI_DEPO  WHERE SERI='" & TextBox1.Text & "'"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "DELETE FROM EO_ALANSIS_KIVI_DEPO WHERE SERI='" & TextBox1.Text & "'"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    MsgBox("ISLEM TAMAMLANMISTIR...")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox15.Text = ""
                    TextBox16.Text = ""
                Else
                    MsgBox("SERI DAHA ONCE SISTEME YUKLENMISTIR...")
                    Exit Sub
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox15.Text = ""
                    TextBox16.Text = ""
                End If
            Else
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                For i As Integer = 0 To ListBox1.Items.Count - 1
                kontrol = ""
                kontrol = ListBox1.Items.Item(i).ToString
                serikont = ""
                SqlConn.Open()
                Dim mySelectQuery3 As String = "Select* From EO_SARF_TUKETIM_SERI Where (SERI='" & seri & "' OR SERI='" & TextBox1.Text & "') And SIPARIS='" & kontrol & "';"
                Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
                Dim reader3 As System.Data.SqlClient.SqlDataReader
                reader3 = SqlComm3.ExecuteReader()
                While reader3.Read()
                    serikont = reader3("SERI").ToString()
                End While
                reader3.Close()
                SqlConn.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If serikont = "" Then
                    If barkod = "2800578" Then
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS,USR) VALUES ('" & kontrol & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0','" & TextBox14.Text & "')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        '---------------------------------------------------------------------------------------------------
                    ElseIf barkod = "2800579" Then
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS,USR) VALUES ('" & kontrol & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox1.Text & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0','" & TextBox14.Text & "')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPOYARI SELECT* FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE SERI='" & TextBox1.Text & "'"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "DELETE FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE SERI='" & TextBox1.Text & "'"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                    End If
                        MsgBox("SERI SISTEME YUKLENMISTIR. YUKLENEN PARTI NO :" + kontrol)
                    Else
                    MsgBox("SERI SISTEME YUKLENMEMISTIR. YUKLENMEYEN PARTI NO :" + kontrol)
                End If
            Next
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_FIRE (TARIH, BARKOD, SERI, STOK_KODU, STOK_ADI, BARKOD_MIKTAR, FIRE_MIKTAR,TIP) VALUES ('" & DateTime.Today & "','" & TextBox1.Text & "', '" & seri & "','" & TextBox2.Text & "'  ,'" & TextBox3.Text & "','" & FIRE & "' ,'" & TextBox16.Text & "','MAMUL')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox15.Text = ""
            TextBox16.Text = ""
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged
        ListBox1.SelectedIndex = ListBox1.FindStringExact(TextBox18.Text)

        If ListBox1.SelectedIndex > 0 Then
            Exit Sub

        Else
            If TextBox18.Text <> "" Then
                ListBox1.Items.Add(TextBox18.Text)
            Else
                Exit Sub
            End If

        End If
        'Next
    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text = "" Then
            Exit Sub
        Else
            ListBox1.Items.Remove(TextBox19.Text)

        End If
    End Sub
End Class