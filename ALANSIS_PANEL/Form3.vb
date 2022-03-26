Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form3
    Private printFont As Font
    Private streamToPrint As TextReader
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form4.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form5.Text = "ALANSIS NAR URETIM USER :" + TextBox16.Text
        Form5.TextBox14.Text = TextBox16.Text
        Form5.Show()
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        On Error Resume Next
        '---------------------------------------------------------------------------------------------------
        If TextBox1.Text = "" Then
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT SUM(MIKTAR) AS NET, SUM(BRUT) AS BRUT FROM EO_ALANSIS_NAR_DEPO WHERE TIP='HAMMADDE';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                Form10.Label1.Text = reader1("NET").ToString()
                Form10.Label12.Text = reader1("BRUT").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            '---------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery2 As String = "SELECT  SUM(MIKTAR) AS NET FROM EO_ALANSIS_NAR_DEPO WHERE TIP='2.KALITE';"
            Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
            Dim reader2 As System.Data.SqlClient.SqlDataReader
            reader2 = SqlComm2.ExecuteReader()
            While reader2.Read()
                Form10.Label10.Text = reader2("NET").ToString()
            End While
            reader2.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery3 As String = "SELECT  SUM(MIKTAR) AS NET FROM EO_ALANSIS_NAR_DEPO WHERE TIP='SULUK';"
            Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
            Dim reader3 As System.Data.SqlClient.SqlDataReader
            reader3 = SqlComm3.ExecuteReader()
            While reader3.Read()
                Form10.Label8.Text = reader3("NET").ToString()
            End While
            reader3.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery4 As String = "SELECT  SUM(MIKTAR) AS NET FROM EO_ALANSIS_NAR_DEPO WHERE TIP='YARIMAMUL';"
            Dim SqlComm4 As New System.Data.SqlClient.SqlCommand(mySelectQuery4, SqlConn)
            Dim reader4 As System.Data.SqlClient.SqlDataReader
            reader4 = SqlComm4.ExecuteReader()
            While reader4.Read()
                Form10.Label6.Text = reader4("NET").ToString()
            End While
            reader4.Close()
            SqlConn.Close()

            '---------------------------------------------------------------------------------------------
            'SELECT SIPARIS,SUM(MIKTAR) AS MIKTAR FROM EO_SARF_TUKETIM_SERI WHERE SIPARIS='HAMMADDE' GROUP BY SIPARIS
            SqlConn.Open()
            Dim mySelectQuery9 As String = "SELECT SIPARIS,SUM(MIKTAR) AS MIKTAR FROM EO_SARF_TUKETIM_SERI WHERE SIPARIS='HAMMADDE' GROUP BY SIPARIS;"
            Dim SqlComm9 As New System.Data.SqlClient.SqlCommand(mySelectQuery9, SqlConn)
            Dim reader9 As System.Data.SqlClient.SqlDataReader
            reader9 = SqlComm9.ExecuteReader()
            While reader9.Read()
                Form10.Label4.Text = reader9("MIKTAR").ToString()
            End While
            reader4.Close()
            SqlConn.Close()
            Form10.Show()

        End If
        '---------------------------------------------------------------------------------------------------
        If TextBox1.Text <> "" Then
            SqlConn.Open()
            Dim mySelectQuery5 As String = "SELECT PARTINO,SUM(MIKTAR) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_NAR_MAMULDEPO WHERE TIP='MAMUL' AND PARTINO='" & TextBox1.Text & "' GROUP BY PARTINO,TIP;"
            Dim SqlComm5 As New System.Data.SqlClient.SqlCommand(mySelectQuery5, SqlConn)
            Dim reader5 As System.Data.SqlClient.SqlDataReader
            reader5 = SqlComm5.ExecuteReader()
            While reader5.Read()
                Form6.Label1.Text = reader5("NET").ToString()
                Form6.Label12.Text = reader5("BRUT").ToString()
            End While
            reader5.Close()
            SqlConn.Close()
            '---------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery6 As String = "SELECT PARTINO,SUM(MIKTAR) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_NAR_MAMULDEPO WHERE TIP='2.KALITE' AND PARTINO='" & TextBox1.Text & "' GROUP BY PARTINO,TIP;"
            Dim SqlComm6 As New System.Data.SqlClient.SqlCommand(mySelectQuery6, SqlConn)
            Dim reader6 As System.Data.SqlClient.SqlDataReader
            reader6 = SqlComm6.ExecuteReader()
            While reader6.Read()
                Form6.Label10.Text = reader6("NET").ToString()
            End While
            reader6.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery7 As String = "SELECT PARTINO,SUM(MIKTAR) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_NAR_MAMULDEPO WHERE TIP='SULUK' AND PARTINO='" & TextBox1.Text & "' GROUP BY PARTINO,TIP;"
            Dim SqlComm7 As New System.Data.SqlClient.SqlCommand(mySelectQuery7, SqlConn)
            Dim reader7 As System.Data.SqlClient.SqlDataReader
            reader7 = SqlComm7.ExecuteReader()
            While reader7.Read()
                Form6.Label8.Text = reader7("NET").ToString()
            End While
            reader7.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery8 As String = "SELECT PARTINO,SUM(MIKTAR) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_NAR_MAMULDEPO WHERE TIP='YARIMAMUL' AND PARTINO='" & TextBox1.Text & "' GROUP BY PARTINO,TIP;"
            Dim SqlComm8 As New System.Data.SqlClient.SqlCommand(mySelectQuery8, SqlConn)
            Dim reader8 As System.Data.SqlClient.SqlDataReader
            reader8 = SqlComm8.ExecuteReader()
            While reader8.Read()
                Form6.Label6.Text = reader8("NET").ToString()
            End While
            reader8.Close()
            SqlConn.Close()
            SqlConn.Open()
            '----------------------------------------------------------------------------------------------------------------------------------------------
            Dim mySelectQuery10 As String = "SELECT SIPARIS,SUM(MIKTAR) AS MIKTAR FROM EO_SARF_TUKETIM_SERI WHERE SIPARIS='" & TextBox1.Text & "' GROUP BY SIPARIS;"
            Dim SqlComm10 As New System.Data.SqlClient.SqlCommand(mySelectQuery10, SqlConn)
            Dim reader10 As System.Data.SqlClient.SqlDataReader
            reader10 = SqlComm10.ExecuteReader()
            While reader10.Read()
                Form6.Label4.Text = reader10("MIKTAR").ToString()
            End While
            reader10.Close()
            SqlConn.Close()
            Form6.Show()
            '---------------------------------------------------------------------------------------------
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form8.TextBox1.Text = TextBox1.Text
        Form8.Show()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form7.TextBox1.Text = TextBox1.Text
        Form7.Show()
    End Sub

    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT SATIS_PARTNO AS PARTI_NO,SIPNO AS SIPARIS_NO,MUSTERI,STOK_ADI AS URUN_ADI,SIPMIKTAR AS SIPARIS_MIKTARI,URETIM_MIKTAR AS URETILEN_MIKTAR,TESLIM_TARIHI,TIP AS RECETE_TIPI,SIPAMAS,SIPATRA,PALET,STOK_KODU FROM EO_ALANAR_SIP_ISLEM WHERE TANIM='0' AND STOK_ADI LIKE 'NAR %' OR STOK_ADI LIKE 'ERIK %' "
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        '-------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANSIS_NARISLEM;"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            ComboBox3.Items.Add(reader1("ISLEM"))
        End While
        reader1.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery2 As String = "SELECT* FROM EO_ALANSIS_NARBOLGE;"
        Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
        Dim reader2 As System.Data.SqlClient.SqlDataReader
        reader2 = SqlComm2.ExecuteReader()
        While reader2.Read()
            ComboBox4.Items.Add(reader2("BOLGE"))
        End While
        reader2.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery3 As String = "SELECT* FROM EO_ALANSIS_NARBOY;"
        Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
        Dim reader3 As System.Data.SqlClient.SqlDataReader
        reader3 = SqlComm3.ExecuteReader()
        While reader3.Read()
            ComboBox5.Items.Add(reader3("BOY"))
        End While
        reader3.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery4 As String = "SELECT* FROM EO_ALANSIS_NARNARISLEM;"
        Dim SqlComm4 As New System.Data.SqlClient.SqlCommand(mySelectQuery4, SqlConn)
        Dim reader4 As System.Data.SqlClient.SqlDataReader
        reader4 = SqlComm4.ExecuteReader()
        While reader4.Read()
            ComboBox7.Items.Add(reader4("NARISLEM"))
        End While
        reader4.Close()
        SqlConn.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery5 As String = "SELECT* FROM EO_ALANSIS_NARODA;"
        Dim SqlComm5 As New System.Data.SqlClient.SqlCommand(mySelectQuery5, SqlConn)
        Dim reader5 As System.Data.SqlClient.SqlDataReader
        reader5 = SqlComm5.ExecuteReader()
        While reader5.Read()
            ComboBox6.Items.Add(reader5("ODA"))
        End While
        reader5.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery6 As String = "SELECT* FROM EO_ALANSIS_NARCESIT;"
        Dim SqlComm6 As New System.Data.SqlClient.SqlCommand(mySelectQuery6, SqlConn)
        Dim reader6 As System.Data.SqlClient.SqlDataReader
        reader6 = SqlComm6.ExecuteReader()
        While reader6.Read()
            ComboBox11.Items.Add(reader6("CESIT"))
        End While
        reader6.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery7 As String = "SELECT* FROM EO_ALANSIS_NARURETIMTIPI;"
        Dim SqlComm7 As New System.Data.SqlClient.SqlCommand(mySelectQuery7, SqlConn)
        Dim reader7 As System.Data.SqlClient.SqlDataReader
        reader7 = SqlComm7.ExecuteReader()
        While reader7.Read()
            ComboBox12.Items.Add(reader7("URETIM_TIPI"))
        End While
        reader7.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery8 As String = "SELECT* FROM EO_ALANSIS_NARPALETTIPI;"
        Dim SqlComm8 As New System.Data.SqlClient.SqlCommand(mySelectQuery8, SqlConn)
        Dim reader8 As System.Data.SqlClient.SqlDataReader
        reader8 = SqlComm8.ExecuteReader()
        While reader8.Read()
            ComboBox10.Items.Add(reader8("PALET_TIPI"))
        End While
        reader8.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery9 As String = "SELECT* FROM EO_ALANSIS_NARKUTUTIPI;"
        Dim SqlComm9 As New System.Data.SqlClient.SqlCommand(mySelectQuery9, SqlConn)
        Dim reader9 As System.Data.SqlClient.SqlDataReader
        reader9 = SqlComm9.ExecuteReader()
        While reader9.Read()
            ComboBox9.Items.Add(reader9("KUTU_TIPI"))
        End While
        reader9.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery10 As String = "SELECT* FROM EO_ALANSIS_NARETIKETTIPI;"
        Dim SqlComm10 As New System.Data.SqlClient.SqlCommand(mySelectQuery10, SqlConn)
        Dim reader10 As System.Data.SqlClient.SqlDataReader
        reader10 = SqlComm10.ExecuteReader()
        While reader10.Read()
            ComboBox13.Items.Add(reader10("ETIKET_TIPI"))
        End While
        reader10.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery11 As String = "SELECT* FROM EO_ALANSIS_NAREBATETIKET;"
        Dim SqlComm11 As New System.Data.SqlClient.SqlCommand(mySelectQuery11, SqlConn)
        Dim reader11 As System.Data.SqlClient.SqlDataReader
        reader11 = SqlComm11.ExecuteReader()
        While reader11.Read()
            ComboBox14.Items.Add(reader11("EBAT_ETIKET_TIPI"))
        End While
        reader11.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery12 As String = "SELECT* FROM EO_ALANSIS_NARYARDMALTIPI;"
        Dim SqlComm12 As New System.Data.SqlClient.SqlCommand(mySelectQuery12, SqlConn)
        Dim reader12 As System.Data.SqlClient.SqlDataReader
        reader12 = SqlComm12.ExecuteReader()
        While reader12.Read()
            ComboBox15.Items.Add(reader12("YARD_MAL_TIPI"))
        End While
        reader12.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    End Sub
    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox9.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString
        TextBox10.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
        TextBox11.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form9.Show()
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod

        barkod = ""
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox9.Text = "" Or ComboBox10.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Or ComboBox13.Text = "" Or ComboBox14.Text = "" Or ComboBox15.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','10','HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'U','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'U','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'U','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'U','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd5.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR1.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")

                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X

                'clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','10','MAMUL','" & TextBox1.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'U','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'U','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'U','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'U','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul1.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", TextBox3.Text) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", TextBox1.Text)
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")

                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X

                'clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim kontrol, say
        kontrol = ""
        say = ""
        kontrol = DatePart("h", Now) & DatePart("n", Now)
        say = Len(kontrol)
        If say = 1 Then
            TextBox5.Text = "000" & kontrol
        End If
        If say = 2 Then
            TextBox5.Text = "00" & kontrol
        End If
        If say = 3 Then
            TextBox5.Text = "0" & kontrol
        End If
        If say = 4 Then
            TextBox5.Text = kontrol
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ComboBox1.Text = "VAR" Then
            TextBox8.Text = "1"
        End If
        If ComboBox1.Text = "YOK" Then
            TextBox8.Text = "0"
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As New SqlCommand
        Dim serinum, seri
        Dim net As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','YARIMAMUL','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'UY','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'UY','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'UY','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'UY','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd5.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar2.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','YARIMAMUL','" & TextBox1.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'UY','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'UY','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'UY','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'UY','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul2.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", TextBox3.Text) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", TextBox1.Text)
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As New SqlCommand
        Dim serinum, seri
        Dim net As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""

        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','30','SULUK','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'US','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'US','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'US','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'US','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd5.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR3.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','30','SULUK','" & TextBox1.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'US','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'US','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'US','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'US','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul3.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", TextBox3.Text) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", TextBox1.Text)
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As New SqlCommand
        Dim serinum, seri
        Dim net As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','2.KALITE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'U2','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'U2','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'U2','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'U2','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd5.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR4.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','2.KALITE','" & TextBox1.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'U2','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'U2','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'U2','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'U2','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul4.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", TextBox3.Text) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", TextBox1.Text)
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As New SqlCommand
        Dim serinum, seri
        Dim net As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','50','HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'UC','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'UC','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'UC','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'UC','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd5.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR5.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','50','COP','" & TextBox1.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'UC','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'UC','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'UC','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'UC','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                '------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul5.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", TextBox3.Text) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", TextBox1.Text)
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
        End If
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
    End Sub

    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim serinum, seri
        Dim net As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','12','STOK','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR1.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NAR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','12','MAMUL','STOK','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul1.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", "STOK") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "STOK")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form11.TextBox1.Text = TextBox1.Text
        Form11.TextBox3.Text = TextBox16.Text
        Form11.Show()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form12.TextBox1.Text = TextBox11.Text
        Form12.TextBox3.Text = TextBox16.Text
        Form12.Show()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form13.Show()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As New SqlCommand
        Dim serinum, seri
        Dim net As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800016" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NARYARIM_DEPO (TARIH, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','YARIM_URETIM','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox10.Text & "', 'UY','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox9.Text & "', 'U2','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox13.Text & "', 'U2','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox14.Text & "', 'U2','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd5.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'SqlConn.Open()
                'Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_NARYARIM_DEPO;"
                'Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                'Dim reader1 As System.Data.SqlClient.SqlDataReader
                'reader1 = SqlComm1.ExecuteReader()
                'While reader1.Read()
                ' Label10.Text = reader1("SAYI").ToString()
                ' End While
                ' reader1.Close()
                ' SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR4.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR YARIM") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
            If TextBox1.Text <> "" Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "Select* From TBLSTOKBAR Where STOK_KODU='" & TextBox9.Text & "';"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    barkod = reader1("BARKOD").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                serinum = barkod & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_NARYARIM_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE, ISLEM, NAR_ISLEM, VIYOL, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,YARD_MAL_TIPI,YARD_ADET,URETIM_TIPI,USR) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox2.Text & "' ,'" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','YARIM_URETIM','" & TextBox1.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'UY','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'UY','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'UY','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'UY','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'SqlConn.Open()
                'Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_NARYARIM_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "' AND GROUP BY PARTINO;"
                'Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                'Dim reader2 As System.Data.SqlClient.SqlDataReader
                'reader2 = SqlComm2.ExecuteReader()
                'While reader2.Read()
                'Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                'End While
                'Label12.Text = TextBox10.Text - CInt(Label10.Text)
                'reader2.Close()
                'SqlConn.Close()
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul4.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", TextBox9.Text)
                dosya = dosya.Replace("@MUSTERI", TextBox3.Text) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", TextBox1.Text)
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox7.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", TextBox8.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = ""
            End If
        End If
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form11.TextBox1.Text = TextBox3.Text
        Form11.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form28.TextBox1.Text = TextBox3.Text
        Form28.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class