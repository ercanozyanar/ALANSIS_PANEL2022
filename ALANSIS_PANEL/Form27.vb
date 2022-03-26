Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets

Public Class Form27
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Dim cmd As New SqlCommand()
    Dim cnn As New SqlConnection()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim kim_kontrol, modul, yetki
        kim_kontrol = ""
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        '-------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANSIS_USER WHERE USR='" & ComboBox1.Text & "' and PASSWORD='" & TextBox2.Text & "';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            kim_kontrol = reader1("KIMLIK").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        If kim_kontrol <> "" Then
            Me.Hide()

            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandText = "INSERT INTO EO_ALANSIS_LOG (TARIH,KIMLIK, MODUL, DETAY) VALUES ('" & DateTime.Now & "','" & ComboBox1.Text & "', 'URETIM_PANEL','GIRIS_YAPILDI')"
            cmd.ExecuteNonQuery()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            cnn.Close()
            '---------------------------------------------------------------------------------------------------
            Form1.Label1.Text = "ALANSIS :" + ComboBox1.Text
            Form1.Show()
        Else
            MsgBox("Geçersiz Parola, Tekrar deneyiniz!", , "Login")
            TextBox2.Select()

        End If

    End Sub

    Private Sub Form27_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT USR FROM EO_ALANSIS_USER;"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            ComboBox1.Items.Add(reader1("USR"))
        End While
        reader1.Close()
        SqlConn.Close()
    End Sub
End Class