Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form47
    Private printFont As Font
    Private streamToPrint As TextReader
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Dim SqlConnStr1 As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn1 As New System.Data.SqlClient.SqlConnection(SqlConnStr1)
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        '*** DARA TANIMLA
        Form4.Show()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        '*** PALET KONTROL
        Form50.TextBox1.Text = TextBox1.Text
        Form50.Show()
    End Sub
    Private Sub Form47_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub Form47_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        '================================================================================================================================
        '*** PARTI NO BILGISINE GORE TOPLAM URETIM TABLOSU
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select TIP,PARTINO,SUM(TOPLAM_NET) As TOPLAM_NETKG,SUM(TOPLAM_BRUT) As TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        '================================================================================================================================
        '*** PARTI BILGISI
        SqlConn.Open()
        Dim mySelectQuery20 As String = "SELECT PARTI FROM EO_ALANAR_INCIRSIP_ISLEM  WHERE ISEMRI='0' GROUP BY PARTI "
        Dim SqlComm20 As New System.Data.SqlClient.SqlCommand(mySelectQuery20, SqlConn)
        Dim reader20 As System.Data.SqlClient.SqlDataReader
        reader20 = SqlComm20.ExecuteReader()
        While reader20.Read()
            ComboBox18.Items.Add(reader20("PARTI"))
        End While
        reader20.Close()
        SqlConn.Close()
        '================================================================================================================================
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANSIS_INCIRISLEM;"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            ComboBox3.Items.Add(reader1("ISLEM"))
        End While
        reader1.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery2 As String = "SELECT* FROM EO_ALANSIS_INCIRBOLGE;"
        Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
        Dim reader2 As System.Data.SqlClient.SqlDataReader
        reader2 = SqlComm2.ExecuteReader()
        While reader2.Read()
            ComboBox4.Items.Add(reader2("BOLGE"))
        End While
        reader2.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery3 As String = "SELECT* FROM EO_ALANSIS_INCIREBAT;"
        Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
        Dim reader3 As System.Data.SqlClient.SqlDataReader
        reader3 = SqlComm3.ExecuteReader()
        While reader3.Read()
            ComboBox5.Items.Add(reader3("EBAT"))
        End While
        reader3.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery4 As String = "SELECT* FROM EO_ALANSIS_INCIRINCIRISLEM;"
        Dim SqlComm4 As New System.Data.SqlClient.SqlCommand(mySelectQuery4, SqlConn)
        Dim reader4 As System.Data.SqlClient.SqlDataReader
        reader4 = SqlComm4.ExecuteReader()
        While reader4.Read()
            ComboBox7.Items.Add(reader4("INCIRISLEM"))
        End While
        reader4.Close()
        SqlConn.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery5 As String = "SELECT* FROM EO_ALANSIS_INCIRODA;"
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
        Dim mySelectQuery6 As String = "SELECT* FROM EO_ALANSIS_INCIRCESIT;"
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
        Dim mySelectQuery7 As String = "SELECT* FROM EO_ALANSIS_INCIRURETIMTIPI;"
        Dim SqlComm7 As New System.Data.SqlClient.SqlCommand(mySelectQuery7, SqlConn)
        Dim reader7 As System.Data.SqlClient.SqlDataReader
        reader7 = SqlComm7.ExecuteReader()
        While reader7.Read()
            ComboBox12.Items.Add(reader7("URETIM_TIPI"))
        End While
        reader7.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        On Error Resume Next
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else
            If TextBox12.Text <> "" Then
                If TextBox4.Text > 0 Then
                    serinum = ""
                    seri = ""
                    '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
                    If TextBox1.Text = "" Then
                        serinum = "" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                        seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                        net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                        '---------------------------------------------------------------------------------------------------------------
                        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                        conn1.Open()
                        cmd1.Connection = conn1
                        cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','10','HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                        cmd1.ExecuteNonQuery()
                        conn1.Close()
                        '---------------------------------------------------------------------------------------------------
                        SqlConn.Open()
                        Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                        Dim reader1 As System.Data.SqlClient.SqlDataReader
                        reader1 = SqlComm1.ExecuteReader()
                        While reader1.Read()
                            Label10.Text = reader1("SAYI").ToString()
                        End While
                        reader1.Close()
                        SqlConn.Close()
                        '============================================================================================================================================================================================================================================================================================
                        conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                        SqlConn.Open()
                        Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                        Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                        Dim reader21 As System.Data.SqlClient.SqlDataReader
                        reader21 = SqlComm21.ExecuteReader()
                        While reader21.Read()
                            Dim stok_adi As String
                            Dim miktar As Decimal
                            stok_adi = ""
                            miktar = 0
                            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            stok_adi = reader21("STOK_ADI").ToString()
                            miktar = reader21("MIKTAR").ToString()
                            conn3.Open()
                            cmd1.Connection = conn3
                            cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                            cmd1.ExecuteNonQuery()
                            conn3.Close()
                        End While
                        SqlConn.Close()
                        '============================================================================================================================================================================================================================================================================================

                        Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                        Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                        Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR1.prn"
                        Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                        clientSocket.Connect(ipend)
                        '---------------------------------------------------------------------------------------------------------------
                        System.Reflection.Assembly.GetExecutingAssembly.GetName()
                        Dim tr As TextReader = New StreamReader(fullPath)
                        Dim dosya As String = (tr.ReadToEnd)
                        dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                        dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                        dosya = dosya.Replace("@TARIH", DateTime.Now)
                        dosya = dosya.Replace("@PARTINO", "")
                        dosya = dosya.Replace("@NET", net)
                        dosya = dosya.Replace("@DARA", TextBox6.Text)
                        dosya = dosya.Replace("@BRUT", TextBox4.Text)
                        dosya = dosya.Replace("@BARKOD", serinum)
                        dosya = dosya.Replace("@durum", ComboBox5.Text)
                        dosya = dosya.Replace("@SERI", ComboBox4.Text)
                        dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                        Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                        kopya = ComboBox8.Text
                        For X = 1 To kopya
                            clientSocket.Send(fileBytes)
                        Next X
                        clientSocket.Close()
                        '------------------------------------------------------------------------------------------------
                        TextBox4.Text = "0"
                    End If
                    '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
                    If TextBox1.Text <> "" Then
                        If TextBox12.Text = "" Then
                            MsgBox("REÇETE TIP Seçimi girmelisiniz...")
                        Else
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
                            cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','10','MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"
                            cmd1.ExecuteNonQuery()
                            conn1.Close()
                            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            conn1.Open()
                            cmd10.Connection = conn1
                            cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                            cmd10.ExecuteNonQuery()
                            conn1.Close()
                            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            SqlConn.Open()
                            Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                            Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                            Dim reader2 As System.Data.SqlClient.SqlDataReader
                            reader2 = SqlComm2.ExecuteReader()
                            While reader2.Read()
                                Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                            End While
                            Label12.Text = TextBox10.Text - CInt(Label10.Text)
                            reader2.Close()
                            SqlConn.Close()
                            '============================================================================================================================================================================================================================================================================================
                            conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                            SqlConn.Open()
                            Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                            Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                            Dim reader21 As System.Data.SqlClient.SqlDataReader
                            reader21 = SqlComm21.ExecuteReader()
                            While reader21.Read()
                                Dim stok_adi As String
                                Dim miktar As Decimal
                                stok_adi = ""
                                miktar = 0
                                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                stok_adi = reader21("STOK_ADI").ToString()
                                miktar = reader21("MIKTAR").ToString()
                                conn3.Open()
                                cmd1.Connection = conn3
                                cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR,SERI) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "','" & serinum & "')"
                                cmd1.ExecuteNonQuery()
                                conn3.Close()
                            End While
                            SqlConn.Close()
                            '============================================================================================================================================================================================================================================================================================
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
                            dosya = dosya.Replace("@durum", ComboBox5.Text)
                            dosya = dosya.Replace("@SERI", ComboBox4.Text)
                            dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                            Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                            kopya = ComboBox8.Text
                            For X = 1 To kopya
                                clientSocket.Send(fileBytes)
                            Next X
                            clientSocket.Close()
                            TextBox4.Text = "0"
                        End If


                    End If
                Else
                    MsgBox("Miktar 0 olamaz...")
                    Exit Sub
                End If
            Else
                MsgBox("Lütfen Reçete seçiniz...")
                Exit Sub


            End If

        End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------
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
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya, brut As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        brut = 0
        net = 0
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else

            serinum = ""
            seri = ""
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text = "" Then
                serinum = "2800018" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','YARIMAMUL_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================

                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR2.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text <> "" Then
                ' If TextBox12.Text = "" Then
                'MsgBox("REÇETE TIP Seçimi girmelisiniz...")
                'Else
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
                'brut = TextBox4.Text
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT)  VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','YARIMAMUL_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd10.Connection = conn1
                cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "'+'YARIMAMUL','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                cmd10.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETEYARIMAMUL"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', 'RECETE_YARIMAMUL','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
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
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                TextBox4.Text = "0"
            End If

        End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

    End Sub


    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        On Error Resume Next
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else

            serinum = ""
            seri = ""
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text = "" Then
                serinum = "2800018" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','2KALITE_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================

                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR4.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text <> "" Then
                'If TextBox12.Text = "" Then
                ' MsgBox("REÇETE TIP Seçimi girmelisiniz...")
                ' Else
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
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT)  VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','2KALITE_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd10.Connection = conn1
                cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "'+'2KALITE','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                cmd10.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE2KALITE"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', 'RECETE_2KALITE','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
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
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                TextBox4.Text = "0"
            End If

        End If
        'End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        On Error Resume Next
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod
        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else

            serinum = ""
            seri = ""
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text = "" Then
                serinum = "2800018" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','50','COP_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================

                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR5.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text <> "" Then
                'If TextBox12.Text = "" Then
                'MsgBox("REÇETE TIP Seçimi girmelisiniz...")
                'Else
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
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT)  VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','50','COP_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd10.Connection = conn1
                cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "'+'COPMAMUL','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                cmd10.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETECOP"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', 'RECETE_COP','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
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
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                TextBox4.Text = "0"
            End If

        End If
        ' End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

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
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod

        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text = "" Then
                serinum = "2800018" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','12','STOK_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                'conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                'SqlConn.Open()
                'Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                'Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                'Dim reader21 As System.Data.SqlClient.SqlDataReader
                'reader21 = SqlComm21.ExecuteReader()
                'While reader21.Read()
                '    Dim stok_adi As String
                '    Dim miktar As Decimal
                '    stok_adi = ""
                '    miktar = 0
                '    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '    stok_adi = reader21("STOK_ADI").ToString()
                '    miktar = reader21("MIKTAR").ToString()
                '    conn3.Open()
                '    cmd1.Connection = conn3
                '    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                '    cmd1.ExecuteNonQuery()
                '    conn3.Close()
                'End While
                'SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR1.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text <> "" Then
                If TextBox12.Text = "" Then
                    MsgBox("REÇETE TIP Seçimi girmelisiniz...")
                Else
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
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT)  VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','12','STOK_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"

                    cmd1.ExecuteNonQuery()
                    conn1.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Open()
                    cmd10.Connection = conn1
                    cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "'+'STOK','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                    cmd10.ExecuteNonQuery()
                    conn1.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


                    SqlConn.Open()
                    Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                    Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                    Dim reader2 As System.Data.SqlClient.SqlDataReader
                    reader2 = SqlComm2.ExecuteReader()
                    While reader2.Read()
                        Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                    End While
                    Label12.Text = TextBox10.Text - CInt(Label10.Text)
                    reader2.Close()
                    SqlConn.Close()
                    '============================================================================================================================================================================================================================================================================================
                    conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    SqlConn.Open()
                    Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                    Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                    Dim reader21 As System.Data.SqlClient.SqlDataReader
                    reader21 = SqlComm21.ExecuteReader()
                    While reader21.Read()
                        Dim stok_adi As String
                        Dim miktar As Decimal
                        stok_adi = ""
                        miktar = 0
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        stok_adi = reader21("STOK_ADI").ToString()
                        miktar = reader21("MIKTAR").ToString()
                        conn3.Open()
                        cmd1.Connection = conn3
                        cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                        cmd1.ExecuteNonQuery()
                        conn3.Close()
                    End While
                    SqlConn.Close()
                    '============================================================================================================================================================================================================================================================================================
                    '---------------------------------------------------------------------------------------------
                    Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul6.prn"
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
                    dosya = dosya.Replace("@durum", ComboBox5.Text)
                    dosya = dosya.Replace("@SERI", ComboBox4.Text)
                    dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                    Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                    kopya = ComboBox8.Text
                    For X = 1 To kopya
                        clientSocket.Send(fileBytes)
                    Next X
                    clientSocket.Close()
                    TextBox4.Text = "0"
                End If

            End If
        End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form11.Text = "ALANSIS INCIR URETIM USER :" + TextBox16.Text
        Form11.TextBox1.Text = TextBox1.Text
        Form11.TextBox3.Text = TextBox16.Text
        Form11.Show()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form12.Text = "ALANSIS INCIR URETIM USER :" + TextBox16.Text
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
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod

        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else

            serinum = ""
            seri = ""
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text = "" Then
                serinum = "2800018" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','60','YARIM_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================

                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR6.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text <> "" Then
                If TextBox12.Text = "" Then
                    MsgBox("REÇETE TIP Seçimi girmelisiniz...")
                Else
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
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','60','YARIM_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"

                    cmd1.ExecuteNonQuery()
                    conn1.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Open()
                    cmd10.Connection = conn1
                    cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "'+'YARIMURETIM','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                    cmd10.ExecuteNonQuery()
                    conn1.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    SqlConn.Open()
                    Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                    Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                    Dim reader2 As System.Data.SqlClient.SqlDataReader
                    reader2 = SqlComm2.ExecuteReader()
                    While reader2.Read()
                        Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                    End While
                    Label12.Text = TextBox10.Text - CInt(Label10.Text)
                    reader2.Close()
                    SqlConn.Close()
                    '============================================================================================================================================================================================================================================================================================
                    'conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    'SqlConn.Open()
                    'Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                    'Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                    'Dim reader21 As System.Data.SqlClient.SqlDataReader
                    'reader21 = SqlComm21.ExecuteReader()
                    'While reader21.Read()
                    '    Dim stok_adi As String
                    '    Dim miktar As Decimal
                    '    stok_adi = ""
                    '    miktar = 0
                    '    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    '    stok_adi = reader21("STOK_ADI").ToString()
                    '    miktar = reader21("MIKTAR").ToString()
                    '    conn3.Open()
                    '    cmd1.Connection = conn3
                    '    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    '    cmd1.ExecuteNonQuery()
                    '    conn3.Close()
                    'End While
                    'SqlConn.Close()
                    '============================================================================================================================================================================================================================================================================================
                    '---------------------------------------------------------------------------------------------
                    Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    Dim fullPath As String = "C:\ALANSIS_PANEL\alanar_mamul6.prn"
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
                    dosya = dosya.Replace("@durum", ComboBox5.Text)
                    dosya = dosya.Replace("@SERI", ComboBox4.Text)
                    dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                    Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                    kopya = ComboBox8.Text
                    For X = 1 To kopya
                        clientSocket.Send(fileBytes)
                    Next X
                    clientSocket.Close()
                    TextBox4.Text = "0"
                End If

            End If
        End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

    End Sub
    Private Sub ComboBox18_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox18.SelectedIndexChanged
        On Error Resume Next
        SqlConn.Open()
        Dim mySelectQuery21 As String = "SELECT* FROM EO_ALANAR_INCIRSIP_ISLEM WHERE ISEMRI='0' AND PARTI='" & ComboBox18.Text & "';"
        Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
        Dim reader21 As System.Data.SqlClient.SqlDataReader
        reader21 = SqlComm21.ExecuteReader()
        While reader21.Read()
            TextBox1.Text = (reader21("PARTI").ToString())
            TextBox2.Text = (reader21("STOK_ADI").ToString())
            TextBox3.Text = (reader21("MUSTERI").ToString())
            TextBox9.Text = (reader21("STOK_KODU").ToString())
            TextBox10.Text = (reader21("PALET_ADET").ToString())
            ' TextBox11.Text = (reader21("SIPARIS_NO").ToString())
        End While
        reader21.Close()
        SqlConn.Close()
    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        '***HAMMADDE YUKLE
        Form55.Text = "ALANSIS INCIR HAMMADDE YUKLEME URETIM USER :" + TextBox16.Text
        Form55.TextBox14.Text = TextBox16.Text
        Form55.Show()
    End Sub

    Private Sub Button17_Click_1(sender As Object, e As EventArgs) Handles Button17.Click
        Form42.TextBox1.Text = ComboBox18.Text
        Form42.TextBox3.Text = "INCIR"
        Form42.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        On Error Resume Next
        Dim cmd1, cmd2 As New SqlCommand()
        Dim conn3 As New SqlConnection()
        '============================================================================================================================================================================================================================================================================================
        conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        conn3.Open()
        cmd1.Connection = conn3
        cmd1.CommandText = "UPDATE EO_ALANSIS_SATIS SET ISEMRI='1',SEVK='1' WHERE PARTI='" & ComboBox18.Text & "'"
        cmd1.ExecuteNonQuery()
        conn3.Close()
        conn3.Open()
        cmd2.Connection = conn3
        cmd2.CommandText = "UPDATE EO_ALANAR_INCIRSIP_ISLEM SET ISEMRI='1' WHERE PARTI='" & ComboBox18.Text & "'"
        cmd2.ExecuteNonQuery()
        conn3.Close()
        MsgBox("ISEMRI KAPATILMISTIR")
        ComboBox18.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox1.Text = ""
        ComboBox5.Text = ""
        ComboBox11.Text = ""
        ComboBox12.Text = ""
        Label10.Text = ""
        Label12.Text = ""

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        On Error Resume Next
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim serinum, seri
        Dim net, kopya As Integer
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim barkod

        barkod = ""
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya DIGER SAHALAR girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
            If TextBox1.Text = "" Then
                serinum = "2800018" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,URETIM_TIPI,USR,ACIKLAMA,RENK) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','70','RECEL_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_DEPO;"
                Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
                Dim reader1 As System.Data.SqlClient.SqlDataReader
                reader1 = SqlComm1.ExecuteReader()
                While reader1.Read()
                    Label10.Text = reader1("SAYI").ToString()
                End While
                reader1.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & TextBox12.Text & "'"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', '" & TextBox12.Text & "','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================

                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR3.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-02-0002")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE INCIR") ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", net)
                dosya = dosya.Replace("@DARA", TextBox6.Text)
                dosya = dosya.Replace("@BRUT", TextBox4.Text)
                dosya = dosya.Replace("@BARKOD", serinum)
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                '------------------------------------------------------------------------------------------------
                TextBox4.Text = "0"
            End If
            '===============================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
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
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_INCIR_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, INCIR_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,USR,ACIKLAMA,RENK,PASTA_KAGIT)  VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','70','RECEL_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox9.Text & "')"

                cmd1.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd10.Connection = conn1
                cmd10.CommandText = "INSERT INTO EO_ALANSIS_MAMHARSERI (TARIH,SERI,STOK_KODU,HARAKET_TIPI,HARAKET_KODU,BELGENO,MIKTAR,BMIKTAR,GELDIGI_YER,RENK,ODA,DEPO_KODU) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & TextBox9.Text & "','URETIM','G','" & TextBox1.Text & "'+'RECEL','" & net & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox6.Text & "','30')"
                cmd10.ExecuteNonQuery()
                conn1.Close()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_INCIR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
                Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
                Dim reader2 As System.Data.SqlClient.SqlDataReader
                reader2 = SqlComm2.ExecuteReader()
                While reader2.Read()
                    Label10.Text = IIf(IsDBNull(reader2("SAYI").ToString()), "0", (reader2("SAYI").ToString()))
                End While
                Label12.Text = TextBox10.Text - CInt(Label10.Text)
                reader2.Close()
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
                conn3.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                SqlConn.Open()
                Dim mySelectQuery21 As String = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETESULUK"
                Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
                Dim reader21 As System.Data.SqlClient.SqlDataReader
                reader21 = SqlComm21.ExecuteReader()
                While reader21.Read()
                    Dim stok_adi As String
                    Dim miktar As Decimal
                    stok_adi = ""
                    miktar = 0
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    stok_adi = reader21("STOK_ADI").ToString()
                    miktar = reader21("MIKTAR").ToString()
                    conn3.Open()
                    cmd1.Connection = conn3
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETETUKETIM (TARIH,PARTI,RECETE,STOK_KODU,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & ComboBox18.Text & "', 'RECETE_RECEL','" & stok_adi & "', '" & stok_adi & "', '" & Replace(miktar, ",", ".") & "')"
                    cmd1.ExecuteNonQuery()
                    conn3.Close()
                End While
                SqlConn.Close()
                '============================================================================================================================================================================================================================================================================================
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
                dosya = dosya.Replace("@durum", ComboBox5.Text)
                dosya = dosya.Replace("@SERI", ComboBox4.Text)
                dosya = dosya.Replace("@KALINTI", ComboBox2.Text)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                kopya = ComboBox8.Text
                For X = 1 To kopya
                    clientSocket.Send(fileBytes)
                Next X
                clientSocket.Close()
                TextBox4.Text = "0"
            End If
        End If
        'End If
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TIP,PARTINO,SUM(TOPLAM_NET) AS TOPLAM_NETKG,SUM(TOPLAM_BRUT) AS TOPLAM_BRUTKG FROM EO_ALANSIS_INCIR_PANEL1 GROUP BY PARTINO,TIP"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub Button18_Click_1(sender As Object, e As EventArgs) Handles Button18.Click
        Form44.Show()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form45.Show()

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        On Error Resume Next
        Form53.TextBox1.Text = ComboBox18.Text
        Form53.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Form57.Show()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Form59.TextBox1.Text = ComboBox18.Text
        Form59.Show()
    End Sub
End Class