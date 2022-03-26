Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form15
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form14.Show()
        Me.Close()
    End Sub

    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da, da1 As New SqlDataAdapter()
        Dim ds, ds1 As New DataSet

        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        Try
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT SATIS_PARTINO,STOK_KODU,STOK_ADI,MIKTAR,IST_TES_TAR,URETIM_MIKTAR,TARIH,IMPORTER,RTIPI,SATIS_MUSTERI,SIPAMASID,SIPATRAID,SIPARIS_NO,OF_PALET FROM EO_ALANSIS_SIPARIS WHERE STOK_ADI LIKE '%KİVİ%'"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        Try
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT SATIS_PARTNO,STOK_ADI,SIPMIKTAR,TIP,MUSTERI,TESLIM_TARIHI,IMPORTER FROM EO_ALANAR_SIP_ISLEM WHERE STOK_ADI LIKE '%KİVİ%'"
            da1.SelectCommand = cmd
            da1.Fill(ds1)
            DataGridView2.DataSource = ds1.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Dim sipno1, STOK_KODU1, STOK_ADI1, SIPMIKTAR1, TESLIM_TARIHI1, URETIM_MIKTAR1, TANIM1, IMPORTER1, TIP1, MUSTERI1, SIPAMAS1, SIPATRA1, SATIS_PARTNO1, palet1, kontrol1
        kontrol1 = ""
        sipno1 = ""
        STOK_KODU1 = ""
        STOK_ADI1 = ""
        SIPMIKTAR1 = ""
        TESLIM_TARIHI1 = ""
        URETIM_MIKTAR1 = ""
        TANIM1 = ""
        IMPORTER1 = ""
        TIP1 = ""
        MUSTERI1 = ""
        SIPAMAS1 = ""
        SIPATRA1 = ""
        SATIS_PARTNO1 = ""
        palet1 = ""
        SATIS_PARTNO1 = DataGridView1.CurrentRow.Cells(0).Value.ToString
        STOK_KODU1 = DataGridView1.CurrentRow.Cells(1).Value.ToString
        STOK_ADI1 = DataGridView1.CurrentRow.Cells(2).Value.ToString
        SIPMIKTAR1 = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TESLIM_TARIHI1 = DataGridView1.CurrentRow.Cells(4).Value.ToString
        URETIM_MIKTAR1 = DataGridView1.CurrentRow.Cells(5).Value.ToString
        TANIM1 = "0"
        IMPORTER1 = DataGridView1.CurrentRow.Cells(7).Value.ToString
        TIP1 = DataGridView1.CurrentRow.Cells(8).Value.ToString
        MUSTERI1 = DataGridView1.CurrentRow.Cells(9).Value.ToString
        SIPAMAS1 = DataGridView1.CurrentRow.Cells(10).Value.ToString
        SIPATRA1 = DataGridView1.CurrentRow.Cells(11).Value.ToString
        sipno1 = DataGridView1.CurrentRow.Cells(12).Value.ToString
        palet1 = DataGridView1.CurrentRow.Cells(13).Value.ToString
        '--------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT SIPNO FROM EO_ALANAR_SIP_ISLEM WHERE SIPNO='" & sipno1 & "' AND SATIS_PARTNO='" & SATIS_PARTNO1 & "';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            kontrol1 = reader1("SIPNO").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        SqlConn.Open()
        If kontrol1 = "" Then
            '---------------------------------------------------------------------------------------------------------------
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_ALANAR_SIP_ISLEM (SIPNO, STOK_KODU, STOK_ADI, SIPMIKTAR, TESLIM_TARIHI, URETIM_MIKTAR, TANIM, IMPORTER, TIP, MUSTERI, SIPAMAS, SIPATRA, SATIS_PARTNO, palet) VALUES ('" & sipno1 & "', '" & STOK_KODU1 & "','" & STOK_ADI1 & "', '" & SIPMIKTAR1 & "','" & TESLIM_TARIHI1 & "'  ,'" & URETIM_MIKTAR1 & "','" & TANIM1 & "' ,'" & IMPORTER1 & "','" & TIP1 & "','" & MUSTERI1 & "' ,'" & SIPAMAS1 & "' ,'" & SIPATRA1 & "' ,'" & SATIS_PARTNO1 & "' , '" & palet1 & "')"
            cmd1.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            conn1.Close()
            '---------------------------------------------------------------------------------------------------
            conn1.Open()
            cmd2.Connection = conn1
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "SELECT* FROM EO_ALANAR_SIP_ISLEM"
            da.SelectCommand = cmd2
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
            conn1.Close()
        End If
        If kontrol1 <> "" Then
            MsgBox("Sipariş kayıtlıdır.Tekrar eklenemez...")
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Dim silid
        silid = ""
        silid = DataGridView2.CurrentRow.Cells(0).Value.ToString
        '---------------------------------------------------------------------------------------------------------------
        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        conn1.Open()
        cmd1.Connection = conn1
        cmd1.CommandText = "Delete From EO_ALANAR_SIP_ISLEM Where ID='" & silid & "'"
        cmd1.ExecuteNonQuery()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        conn1.Close()
        '---------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------
        conn1.Open()
        cmd2.Connection = conn1
        cmd2.CommandType = CommandType.Text
        cmd2.CommandText = "SELECT* FROM EO_ALANAR_SIP_ISLEM"
        da.SelectCommand = cmd2
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0).DefaultView
        conn1.Close()
        '______________________________________________________________________________________________________________________________
        Exit Sub


    End Sub
End Class