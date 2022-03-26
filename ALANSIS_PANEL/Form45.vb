Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form45
    Private printFont As Font
    Private streamToPrint As TextReader
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Dim SqlConnStr1 As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn1 As New System.Data.SqlClient.SqlConnection(SqlConnStr1)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' On Error Resume Next
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10, cmd11 As New SqlCommand
        Dim serinum, seri, serikont, barkodkod, renk
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        serikont = ""
        barkodkod = ""
        renk = Mid(ComboBox1.Text, 1, 2)
        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        conn1.Open()
        cmd1.Connection = conn1
        cmd1.CommandText = "INSERT INTO EO_SERI_TAKIP ([TARIH],[MIKTAR],[BARKOD]) values  ('" & DateTime.Now & "','" & TextBox1.Text & "','" & TextBox4.Text & "')"
        cmd1.ExecuteNonQuery()
        conn1.Close()
        '---------------------------------------------------------------------------------------------------
        SqlConn1.Open()
        Dim mySelectQuery1 As String
        mySelectQuery1 = ""
        mySelectQuery1  = "select TOP 1 SERINO FROM EO_SERI_TAKIP ORDER BY SERINO DESC;"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn1)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            serikont = reader1("SERINO").ToString()
        End While
        reader1.Close()
        SqlConn1.Close()

        barkodkod = String.Concat(29, TextBox4.Text, serikont, TextBox1.Text)

        conn1.Open()
        cmd2.Connection = conn1
        cmd2.CommandText = "UPDATE EO_SERI_TAKIP SET BARKOD='" & barkodkod & "' WHERE SERINO='" & serikont & "'"
        cmd2.ExecuteNonQuery()
        conn1.Close()



        conn1.Open()
        cmd3.Connection = conn1
        cmd3.CommandText = "INSERT INTO EO_ALANSIS_HAMHARSERI([TARIH],[SERI],[SERI2],[STOK_KODU],[STOK_ADI],[HARAKET_TIPI],[HARAKET_KODU],[MIKTAR],[BMIKTAR],[RENK],[YERLESIM],[DEPO_KODU]) values  ('" & TextBox7.Text & "','" & serikont & "','0','" & TextBox5.Text & "','" & TextBox6.Text & "','URETIMIADEHAMMADDE','C','" & TextBox1.Text & "','" & TextBox3.Text & "','" & renk & "','8.A50','30')"
        cmd3.ExecuteNonQuery()
        conn1.Close()
        conn1.Open()
        cmd4.Connection = conn1
        cmd4.CommandText = "INSERT INTO EO_ALANSIS_HAMHARSERI([TARIH],[SERI],[SERI2],[STOK_KODU],[STOK_ADI],[HARAKET_TIPI],[HARAKET_KODU],[MIKTAR],[BMIKTAR],[RENK],[YERLESIM],[DEPO_KODU]) values  ('" & TextBox7.Text & "','" & serikont & "','0','" & TextBox5.Text & "','" & TextBox6.Text & "','URETIMIADEHAMMADDE','G','" & TextBox1.Text & "','" & TextBox3.Text & "','" & renk & "','8.A50','10')"
        cmd4.ExecuteNonQuery()
        conn1.Close()
        '---------------------------------------------------------------------------------------------
        Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Dim fullPath As String = "C:\ALANSIS_PANEL\10050.prn"
        Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
        clientSocket.Connect(ipend)
        '---------------------------------------------------------------------------------------------------------------
        System.Reflection.Assembly.GetExecutingAssembly.GetName()
        Dim tr As TextReader = New StreamReader(fullPath)
        Dim dosya As String = (tr.ReadToEnd)
        dosya = dosya.Replace("@STOKKODU", TextBox5.Text)
        dosya = dosya.Replace("@STOKADI1", TextBox6.Text)
        dosya = dosya.Replace("@TARIH", DateTime.Now)
        dosya = dosya.Replace("@PARTINO", serikont)
        dosya = dosya.Replace("@MIKTAR", TextBox1.Text)
        dosya = dosya.Replace("@BRUT", TextBox3.Text)
        dosya = dosya.Replace("@BARKOD", barkodkod)
        dosya = dosya.Replace("@ACIKLAMA", " ")
        dosya = dosya.Replace("@KALINTI", renk)
        dosya = dosya.Replace("@BOLGE", "URETIM IADE")
        Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
        kopya = ComboBox2.Text
        For X = 1 To kopya
            clientSocket.Send(fileBytes)
        Next X
        clientSocket.Close()


    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='HMD01-02-0001';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            TextBox4.Text = reader1("BARKOD").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        TextBox5.Text = "HMD01-02-0001"
        TextBox6.Text = "HAMMADDE KIRAZ"

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='HMD01-03-0001';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            TextBox4.Text = reader1("BARKOD").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        TextBox5.Text = "HMD01-03-0001"
        TextBox6.Text = "HAMMADDE KAYISI"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next

        Dim net, dara, brut As Integer
        net = 0
        dara = 0
        brut = 0
        net = Convert.ToInt32(TextBox1.Text)
        dara = Convert.ToInt32(TextBox2.Text)
        brut = net + dara
        TextBox3.Text = brut
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        On Error Resume Next
        Dim net, dara, brut As Integer
        net = 0
        dara = 0
        brut = 0
        net = TextBox1.Text
        dara = TextBox2.Text
        brut = net + dara
        TextBox3.Text = brut
    End Sub

    Private Sub Form45_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox7.Text = (Now.Year & "-" & Now.Month & "-" & Now.Day)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='HMD01-02-0002';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            TextBox4.Text = reader1("BARKOD").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        TextBox5.Text = "HMD01-02-0002"
        TextBox6.Text = "HAMMADDE INCIR"
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='HMD01-08-0001';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            TextBox4.Text = reader1("BARKOD").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        TextBox5.Text = "HMD01-08-0001"
        TextBox6.Text = "HAMMADDE ERIK"
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='HMD01-05-0001';"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            TextBox4.Text = reader1("BARKOD").ToString()
        End While
        reader1.Close()
        SqlConn.Close()
        TextBox5.Text = "HMD01-05-0001"
        TextBox6.Text = "HAMMADDE NAR"
    End Sub
End Class