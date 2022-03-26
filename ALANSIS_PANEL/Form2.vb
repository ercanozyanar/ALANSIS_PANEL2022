Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form2
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text = "NAR " Then
            Form62.Text = "ALANSIS NAR URETIM USER :" + Trim(Mid(Me.Text, 10, 20))
            Form62.TextBox16.Text = Trim(Mid(Me.Text, 10, 20))
            Form62.Show()
            Me.Close()
        End If
        If TextBox1.Text = "KIVI" Then
            Form34.Text = "ALANSIS KIVI URETIM USER :" + Trim(Mid(Me.Text, 10, 20))
            Form34.TextBox16.Text = Trim(Mid(Me.Text, 10, 20))
            Form34.Show()
            Me.Close()
        End If
        If TextBox1.Text = "KIRAZ" Then
            Form29.Text = "ALANSIS KIRAZ URETIM USER :" + Trim(Mid(Me.Text, 10, 20))
            Form29.TextBox16.Text = Trim(Mid(Me.Text, 10, 20))
            Form29.Show()
            Me.Close()
        End If
        If TextBox1.Text = "INCIR" Then
            Form47.Text = "ALANSIS INCIR URETIM USER :" + Trim(Mid(Me.Text, 10, 20))
            Form47.TextBox16.Text = Trim(Mid(Me.Text, 10, 20))
            Form47.Show()
            Me.Close()
        End If
        If TextBox1.Text = "ERIK" Then
            Form48.Text = "ALANSIS ERIK URETIM USER :" + Trim(Mid(Me.Text, 10, 20))
            Form48.TextBox16.Text = Trim(Mid(Me.Text, 10, 20))
            Form48.Show()
            Me.Close()
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da, da1 As New SqlDataAdapter()
        Dim ds, ds1 As New DataSet

        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        If TextBox1.Text = "KIVI" Then
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID,PARTI,('KIVI '+MUSTERI) AS STOK_ADI,PALET_ADET AS SIPMIKTAR,'KIVI' AS TIP,MUSTERI,ETA AS TESLIM_TARIHI,TESLIM_YERI AS IMPORTER FROM EO_ALANSIS_KIVI_SATIS"
                da1.SelectCommand = cmd
                da1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANAR_KIVISIP_ISLEM"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        '=================================================================================================================================================================================================================
        If TextBox1.Text = "KIRAZ" Then
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID,ISEMRI,PARTI,STOK_ADI,PALET_ADET AS SIPMIKTAR,RENK AS TIP,ETA AS TESLIM_TARIHI,TESLIM_YERI AS IMPORTER FROM EO_ALANSIS_SATIS WHERE SON_ONAY='OK' AND (ISEMRI='0' OR ISEMRI IS NULL) ORDER BY ID DESC"
                da1.SelectCommand = cmd
                da1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANAR_KIRAZSIP_ISLEM"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        '=================================================================================================================================================================================================================
        If TextBox1.Text = "INCIR" Then
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID,ISEMRI,PARTI,STOK_ADI,PALET_ADET AS SIPMIKTAR,RENK AS TIP,ETA AS TESLIM_TARIHI,TESLIM_YERI AS IMPORTER FROM EO_ALANSIS_SATIS WHERE SON_ONAY='OK' AND (ISEMRI='0' OR ISEMRI IS NULL) ORDER BY ID DESC"
                da1.SelectCommand = cmd
                da1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANAR_INCIRSIP_ISLEM"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        '=================================================================================================================================================================================================================
        If TextBox1.Text = "ERIK" Then
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID,ISEMRI,PARTI,STOK_ADI,PALET_ADET AS SIPMIKTAR,RENK AS TIP,ETA AS TESLIM_TARIHI,TESLIM_YERI AS IMPORTER FROM EO_ALANSIS_SATIS WHERE SON_ONAY='OK' AND (ISEMRI='0' OR ISEMRI IS NULL) ORDER BY ID DESC"
                da1.SelectCommand = cmd
                da1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANAR_ERIKSIP_ISLEM"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        '=================================================================================================================================================================================================================
        If Trim(TextBox1.Text) = "NAR" Then
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID,ISEMRI,PARTI,STOK_ADI,PALET_ADET AS SIPMIKTAR,RENK AS TIP,ETA AS TESLIM_TARIHI,TESLIM_YERI AS IMPORTER FROM EO_ALANSIS_SATIS WHERE SON_ONAY='OK' AND (ISEMRI='0' OR ISEMRI IS NULL) ORDER BY ID DESC"
                da1.SelectCommand = cmd
                da1.Fill(ds1)
                DataGridView1.DataSource = ds1.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            Try
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANAR_NARSIP_ISLEM"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim da, da1 As New SqlDataAdapter()
        Dim ds, ds1 As New DataSet
        Dim ID, PARTIKONTROL, PARTIKONTROLX
        ID = ""
        PARTIKONTROL = ""
        PARTIKONTROLX = ""
        ID = DataGridView1.CurrentRow.Cells(0).Value.ToString
        PARTIKONTROL = DataGridView1.CurrentRow.Cells(2).Value.ToString
        '--------------------------------------------------------------------------------------------------------------------------
        If TextBox1.Text = "KIRAZ" Then
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANAR_KIRAZSIP_ISLEM WHERE PARTI='" & PARTIKONTROL & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                PARTIKONTROLX = reader1("PARTI").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            SqlConn.Open()
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            If PARTIKONTROLX = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANAR_KIRAZSIP_ISLEM SELECT DURUM,SIPARIS_TURU,SINIF,NAKLIYE,PARTI,MUSTERI,ETD,ETA,KUTU,AMBALAJ,EBAT,MIN_MEYVE_AGIRLIK,MIN_KUTU_AGIRLIK,PALET_ADET,KUTU_ADET,TONAJ_KG,PLT_KUTU,PALET_TIPI,ACIKLAMA,ETIKET,MUSTERI_REFERANS,TESLIM_SEKLI,TESLIM_YERI,RENK,STOK_KODU,STOK_ADI,GGN,NOK_BIRIM,URUN,ISEMRI FROM EO_ALANSIS_SATIS WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "UPDATE EO_ALANAR_KIRAZSIP_ISLEM SET ISEMRI='0' WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd2.Connection = conn1
                cmd2.CommandType = CommandType.Text
                cmd2.CommandText = "SELECT* FROM EO_ALANAR_KIRAZSIP_ISLEM"
                da1.SelectCommand = cmd2
                da1.Fill(ds1)
                DataGridView2.DataSource = ds1.Tables(0).DefaultView
                conn1.Close()
            End If
            If PARTIKONTROLX <> "" Then
                MsgBox("Sipariş kayıtlıdır.Tekrar eklenemez...")
                Exit Sub
            End If
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If TextBox1.Text = "INCIR" Then
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANAR_INCIRSIP_ISLEM WHERE PARTI='" & PARTIKONTROL & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                PARTIKONTROLX = reader1("PARTI").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            SqlConn.Open()
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            If PARTIKONTROLX = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANAR_INCIRSIP_ISLEM SELECT DURUM,SIPARIS_TURU,SINIF,NAKLIYE,PARTI,MUSTERI,ETD,ETA,KUTU,AMBALAJ,EBAT,MIN_MEYVE_AGIRLIK,MIN_KUTU_AGIRLIK,PALET_ADET,KUTU_ADET,TONAJ_KG,PLT_KUTU,PALET_TIPI,ACIKLAMA,ETIKET,MUSTERI_REFERANS,TESLIM_SEKLI,TESLIM_YERI,RENK,STOK_KODU,STOK_ADI,GGN,NOK_BIRIM,URUN,ISEMRI FROM EO_ALANSIS_SATIS WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "UPDATE EO_ALANAR_INCIRSIP_ISLEM SET ISEMRI='0' WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd2.Connection = conn1
                cmd2.CommandType = CommandType.Text
                cmd2.CommandText = "SELECT* FROM EO_ALANAR_INCIRSIP_ISLEM"
                da1.SelectCommand = cmd2
                da1.Fill(ds1)
                DataGridView2.DataSource = ds1.Tables(0).DefaultView
                conn1.Close()
            End If
            If PARTIKONTROLX <> "" Then
                MsgBox("Sipariş kayıtlıdır.Tekrar eklenemez...")
                Exit Sub
            End If
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If TextBox1.Text = "ERIK" Then
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANAR_ERIKSIP_ISLEM WHERE PARTI='" & PARTIKONTROL & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                PARTIKONTROLX = reader1("PARTI").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            SqlConn.Open()
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            If PARTIKONTROLX = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANAR_ERIKSIP_ISLEM SELECT DURUM,SIPARIS_TURU,SINIF,NAKLIYE,PARTI,MUSTERI,ETD,ETA,KUTU,AMBALAJ,EBAT,MIN_MEYVE_AGIRLIK,MIN_KUTU_AGIRLIK,PALET_ADET,KUTU_ADET,TONAJ_KG,PLT_KUTU,PALET_TIPI,ACIKLAMA,ETIKET,MUSTERI_REFERANS,TESLIM_SEKLI,TESLIM_YERI,RENK,STOK_KODU,STOK_ADI,GGN,NOK_BIRIM,URUN,ISEMRI FROM EO_ALANSIS_SATIS WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "UPDATE EO_ALANAR_ERIKSIP_ISLEM SET ISEMRI='0' WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd2.Connection = conn1
                cmd2.CommandType = CommandType.Text
                cmd2.CommandText = "SELECT* FROM EO_ALANAR_ERIKSIP_ISLEM"
                da1.SelectCommand = cmd2
                da1.Fill(ds1)
                DataGridView2.DataSource = ds1.Tables(0).DefaultView
                conn1.Close()
            End If
            If PARTIKONTROLX <> "" Then
                MsgBox("Sipariş kayıtlıdır.Tekrar eklenemez...")
                Exit Sub
            End If
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If Trim(TextBox1.Text) = "NAR" Then
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANAR_NARSIP_ISLEM WHERE PARTI='" & PARTIKONTROL & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                PARTIKONTROLX = reader1("PARTI").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            SqlConn.Open()
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            If PARTIKONTROLX = "" Then
                '---------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANAR_NARSIP_ISLEM SELECT DURUM,SIPARIS_TURU,SINIF,NAKLIYE,PARTI,MUSTERI,ETD,ETA,KUTU,AMBALAJ,EBAT,MIN_MEYVE_AGIRLIK,MIN_KUTU_AGIRLIK,PALET_ADET,KUTU_ADET,TONAJ_KG,PLT_KUTU,PALET_TIPI,ACIKLAMA,ETIKET,MUSTERI_REFERANS,TESLIM_SEKLI,TESLIM_YERI,RENK,STOK_KODU,STOK_ADI,GGN,NOK_BIRIM,URUN,ISEMRI FROM EO_ALANSIS_SATIS WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "UPDATE EO_ALANAR_NARSIP_ISLEM SET ISEMRI='0' WHERE PARTI='" & PARTIKONTROL & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd2.Connection = conn1
                cmd2.CommandType = CommandType.Text
                cmd2.CommandText = "SELECT* FROM EO_ALANAR_NARSIP_ISLEM"
                da1.SelectCommand = cmd2
                da1.Fill(ds1)
                DataGridView2.DataSource = ds1.Tables(0).DefaultView
                conn1.Close()
            End If
            If PARTIKONTROLX <> "" Then
                MsgBox("Sipariş kayıtlıdır.Tekrar eklenemez...")
                Exit Sub
            End If
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Dim silid
        silid = ""
        silid = DataGridView2.CurrentRow.Cells(4).Value.ToString
        '---------------------------------------------------------------------------------------------------------------
        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If TextBox1.Text = "KIRAZ" Then
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "Delete From EO_ALANAR_KIRAZSIP_ISLEM Where PARTI='" & silid & "'"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            conn1.Open()
            cmd2.Connection = conn1
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT* FROM EO_ALANAR_KIRAZSIP_ISLEM"
            da.SelectCommand = cmd2
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
            conn1.Close()
            Exit Sub
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If TextBox1.Text = "INCIR" Then
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "Delete From EO_ALANAR_INCIRSIP_ISLEM Where PARTI='" & silid & "'"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            conn1.Open()
            cmd2.Connection = conn1
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT* FROM EO_ALANAR_INCIRSIP_ISLEM"
            da.SelectCommand = cmd2
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
            conn1.Close()
            Exit Sub
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If TextBox1.Text = "ERIK" Then
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "Delete From EO_ALANAR_ERIKSIP_ISLEM Where PARTI='" & silid & "'"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            conn1.Open()
            cmd2.Connection = conn1
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT* FROM EO_ALANAR_ERIKSIP_ISLEM"
            da.SelectCommand = cmd2
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
            conn1.Close()
            Exit Sub
        End If
        '===============================================================================================================================================================================================================================================================================================================================================================================================================================
        If Trim(TextBox1.Text) = "NAR" Then
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "Delete From EO_ALANAR_NARSIP_ISLEM Where PARTI='" & silid & "'"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            conn1.Open()
            cmd2.Connection = conn1
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT* FROM EO_ALANAR_NARSIP_ISLEM"
            da.SelectCommand = cmd2
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
            conn1.Close()
            Exit Sub
        End If
    End Sub

End Class