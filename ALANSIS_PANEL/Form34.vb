Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form34
    Private printFont As Font
    Private streamToPrint As TextReader
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form41.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form5.Text = "ALANSIS KIVI URETIM USER :" + TextBox16.Text
        Form5.TextBox14.Text = TextBox16.Text
        Form5.Show()
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        On Error Resume Next
        '---------------------------------------------------------------------------------------------------
        If TextBox1.Text = "" Then
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT TIP,CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET,SUM(BRUT) AS BRUT FROM EO_ALANSIS_KIVI_DEPO WHERE TIP='HAMMADDE' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP;"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                Form37.Label1.Text = reader1("NET").ToString()
                Form37.Label12.Text = reader1("BRUT").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            '---------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery2 As String = "SELECT TIP,CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET,SUM(BRUT) AS BRUT FROM EO_ALANSIS_KIVI_DEPO WHERE TIP='2KALITE_HAMMADDE' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP;"
            Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
            Dim reader2 As System.Data.SqlClient.SqlDataReader
            reader2 = SqlComm2.ExecuteReader()
            While reader2.Read()
                Form37.Label10.Text = reader2("NET").ToString()
            End While
            reader2.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery3 As String = "SELECT TIP,CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET,SUM(BRUT) AS BRUT FROM EO_ALANSIS_KIVI_DEPO WHERE TIP='SULUK_HAMMADDE' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP;"
            Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
            Dim reader3 As System.Data.SqlClient.SqlDataReader
            reader3 = SqlComm3.ExecuteReader()
            While reader3.Read()
                Form37.Label8.Text = reader3("NET").ToString()
            End While
            reader3.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery4 As String = "SELECT TIP,CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET,SUM(BRUT) AS BRUT FROM EO_ALANSIS_KIVI_DEPO WHERE TIP='YARIMAMUL_HAMMADDE' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP;"
            Dim SqlComm4 As New System.Data.SqlClient.SqlCommand(mySelectQuery4, SqlConn)
            Dim reader4 As System.Data.SqlClient.SqlDataReader
            reader4 = SqlComm4.ExecuteReader()
            While reader4.Read()
                Form37.Label6.Text = reader4("NET").ToString()
            End While
            reader4.Close()
            SqlConn.Close()

            '---------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery9 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS MIKTAR FROM EO_SARF_TUKETIM_SERI WHERE  CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104);"
            Dim SqlComm9 As New System.Data.SqlClient.SqlCommand(mySelectQuery9, SqlConn)
            Dim reader9 As System.Data.SqlClient.SqlDataReader
            reader9 = SqlComm9.ExecuteReader()
            While reader9.Read()
                Form37.Label4.Text = reader9("MIKTAR").ToString()
            End While
            reader4.Close()
            SqlConn.Close()
            Form37.Show()
        End If
        '---------------------------------------------------------------------------------------------------
        If TextBox1.Text <> "" Then
            SqlConn.Open()
            Dim mySelectQuery5 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET,CAST(SUM(BRUT) AS DECIMAL) AS BRUT,TIP FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE TIP='MAMUL' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP;"
            Dim SqlComm5 As New System.Data.SqlClient.SqlCommand(mySelectQuery5, SqlConn)
            Dim reader5 As System.Data.SqlClient.SqlDataReader
            reader5 = SqlComm5.ExecuteReader()
            While reader5.Read()
                Form37.Label1.Text = reader5("NET").ToString()
                Form37.Label12.Text = reader5("BRUT").ToString()
            End While
            reader5.Close()
            SqlConn.Close()
            '---------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery6 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE TIP='2KALITE_MAMUL' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP"
            Dim SqlComm6 As New System.Data.SqlClient.SqlCommand(mySelectQuery6, SqlConn)
            Dim reader6 As System.Data.SqlClient.SqlDataReader
            reader6 = SqlComm6.ExecuteReader()
            While reader6.Read()
                Form37.Label10.Text = reader6("NET").ToString()
            End While
            reader6.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery7 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE TIP='SULUK_MAMUL' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP"
            Dim SqlComm7 As New System.Data.SqlClient.SqlCommand(mySelectQuery7, SqlConn)
            Dim reader7 As System.Data.SqlClient.SqlDataReader
            reader7 = SqlComm7.ExecuteReader()
            While reader7.Read()
                Form37.Label8.Text = reader7("NET").ToString()
            End While
            reader7.Close()
            SqlConn.Close()
            SqlConn.Open()
            Dim mySelectQuery8 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE TIP='YARIMAMUL_MAMUL' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP"
            Dim SqlComm8 As New System.Data.SqlClient.SqlCommand(mySelectQuery8, SqlConn)
            Dim reader8 As System.Data.SqlClient.SqlDataReader
            reader8 = SqlComm8.ExecuteReader()
            While reader8.Read()
                Form37.Label6.Text = reader8("NET").ToString()
            End While
            reader8.Close()
            SqlConn.Close()
            SqlConn.Open()
            '----------------------------------------------------------------------------------------------------------------------------------------------
            Dim mySelectQuery10 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS MIKTAR FROM EO_SARF_TUKETIM_SERI WHERE  CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) AND SIPARIS='" & TextBox1.Text & "' GROUP BY CONVERT(DATE,TARIH,104)"
            Dim SqlComm10 As New System.Data.SqlClient.SqlCommand(mySelectQuery10, SqlConn)
            Dim reader10 As System.Data.SqlClient.SqlDataReader
            reader10 = SqlComm10.ExecuteReader()
            While reader10.Read()
                Form37.Label4.Text = reader10("MIKTAR").ToString()
            End While
            reader10.Close()
            SqlConn.Close()

            '----------------------------------------------------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery31 As String = "SELECT TUKETIM FROM dbo.EO_ALANSIS_TUKETIMGUNLUK1"
            Dim SqlComm31 As New System.Data.SqlClient.SqlCommand(mySelectQuery31, SqlConn)
            Dim reader31 As System.Data.SqlClient.SqlDataReader
            reader31 = SqlComm31.ExecuteReader()
            While reader31.Read()
                Form37.Label16.Text = reader31("TUKETIM").ToString()
            End While
            reader31.Close()
            SqlConn.Close()

            '---------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery12 As String = "SELECT CONVERT(DATE,TARIH,104),CAST(SUM(MIKTAR) AS DECIMAL) AS NET, SUM(BRUT) AS BRUT,TIP FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE TIP='COP_MAMUL' AND CONVERT(DATE,TARIH,104)=(SELECT CONVERT(DATE,GETDATE(),104)) GROUP BY CONVERT(DATE,TARIH,104),TIP"
            Dim SqlComm12 As New System.Data.SqlClient.SqlCommand(mySelectQuery12, SqlConn)
            Dim reader12 As System.Data.SqlClient.SqlDataReader
            reader12 = SqlComm7.ExecuteReader()
            While reader12.Read()
                Form37.Label14.Text = reader12("NET").ToString()
            End While
            reader12.Close()
            SqlConn.Close()
            Form37.Show()
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form36.TextBox1.Text = TextBox1.Text
        Form36.Show()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form34_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub Form34_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
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
        '-------------------------------------------------------------------------------------------------------------------------------
        'SqlConn.Open()
        'Dim mySelectQuery20 As String = "SELECT PARTI FROM EO_ALANSIS_KIVI_SATIS "
        'Dim SqlComm20 As New System.Data.SqlClient.SqlCommand(mySelectQuery20, SqlConn)
        'Dim reader20 As System.Data.SqlClient.SqlDataReader
        'reader20 = SqlComm20.ExecuteReader()
        'While reader20.Read()
        ' ComboBox18.Items.Add(reader20("PARTI"))
        ' End While
        ' reader20.Close()
        ' SqlConn.Close()
        '-------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANSIS_KIVIISLEM;"
        Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
        Dim reader1 As System.Data.SqlClient.SqlDataReader
        reader1 = SqlComm1.ExecuteReader()
        While reader1.Read()
            ComboBox3.Items.Add(reader1("ISLEM"))
        End While
        reader1.Close()
        SqlConn.Close()
        '-------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery2 As String = "SELECT* FROM EO_ALANSIS_KIVIBOLGE;"
        Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
        Dim reader2 As System.Data.SqlClient.SqlDataReader
        reader2 = SqlComm2.ExecuteReader()
        While reader2.Read()
            ComboBox4.Items.Add(reader2("BOLGE"))
        End While
        reader2.Close()
        SqlConn.Close()
        '-------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery3 As String = "SELECT* FROM EO_ALANSIS_KIVIEBAT;"
        Dim SqlComm3 As New System.Data.SqlClient.SqlCommand(mySelectQuery3, SqlConn)
        Dim reader3 As System.Data.SqlClient.SqlDataReader
        reader3 = SqlComm3.ExecuteReader()
        While reader3.Read()
            ComboBox5.Items.Add(reader3("EBAT"))
        End While
        reader3.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery4 As String = "SELECT* FROM EO_ALANSIS_KIVIKIVIISLEM;"
        Dim SqlComm4 As New System.Data.SqlClient.SqlCommand(mySelectQuery4, SqlConn)
        Dim reader4 As System.Data.SqlClient.SqlDataReader
        reader4 = SqlComm4.ExecuteReader()
        While reader4.Read()
            ComboBox7.Items.Add(reader4("KIVIISLEM"))
        End While
        reader4.Close()
        SqlConn.Close()
        SqlConn.Close()
        SqlConn.Open()
        Dim mySelectQuery5 As String = "SELECT* FROM EO_ALANSIS_KIVIODA;"
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
        Dim mySelectQuery6 As String = "SELECT* FROM EO_ALANSIS_KIVICESIT;"
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
        Dim mySelectQuery7 As String = "SELECT* FROM EO_ALANSIS_KIVIURETIMTIPI;"
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
        Dim mySelectQuery8 As String = "SELECT* FROM EO_ALANSIS_KIVIPALETTIPI;"
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
        Dim mySelectQuery9 As String = "SELECT* FROM EO_ALANSIS_KIVIKUTUTIPI;"
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
        Dim mySelectQuery10 As String = "SELECT* FROM EO_ALANSIS_KIVIETIKETTIPI;"
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
        Dim mySelectQuery11 As String = "SELECT* FROM EO_ALANSIS_KIVIEBATETIKET;"
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
        Dim mySelectQuery12 As String = "SELECT* FROM EO_ALANSIS_KIVIPOSET;"
        Dim SqlComm12 As New System.Data.SqlClient.SqlCommand(mySelectQuery12, SqlConn)
        Dim reader12 As System.Data.SqlClient.SqlDataReader
        reader12 = SqlComm12.ExecuteReader()
        While reader12.Read()
            ComboBox15.Items.Add(reader12("POSET"))
        End While
        reader12.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery13 As String = "SELECT* FROM EO_ALANSIS_KIVIKLIPSTIPI;"
        Dim SqlComm13 As New System.Data.SqlClient.SqlCommand(mySelectQuery13, SqlConn)
        Dim reader13 As System.Data.SqlClient.SqlDataReader
        reader13 = SqlComm13.ExecuteReader()
        While reader13.Read()
            ComboBox20.Items.Add(reader13("KLIPS_TIPI"))
        End While
        reader13.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery14 As String = "SELECT* FROM EO_ALANSIS_KIVINEMBEZI;"
        Dim SqlComm14 As New System.Data.SqlClient.SqlCommand(mySelectQuery14, SqlConn)
        Dim reader14 As System.Data.SqlClient.SqlDataReader
        reader14 = SqlComm14.ExecuteReader()
        While reader14.Read()
            ComboBox2.Items.Add(reader14("NEMBEZI"))
        End While
        reader14.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery15 As String = "SELECT* FROM EO_ALANSIS_KIVICARRYBAG;"
        Dim SqlComm15 As New System.Data.SqlClient.SqlCommand(mySelectQuery15, SqlConn)
        Dim reader15 As System.Data.SqlClient.SqlDataReader
        reader15 = SqlComm15.ExecuteReader()
        While reader15.Read()
            ComboBox19.Items.Add(reader15("CARRYBAG"))
        End While
        reader15.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery16 As String = "SELECT* FROM EO_ALANSIS_KIVIFILETIPI;"
        Dim SqlComm16 As New System.Data.SqlClient.SqlCommand(mySelectQuery16, SqlConn)
        Dim reader16 As System.Data.SqlClient.SqlDataReader
        reader16 = SqlComm16.ExecuteReader()
        While reader16.Read()
            ComboBox22.Items.Add(reader16("FILE_TIPI"))
        End While
        reader16.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery17 As String = "SELECT* FROM EO_ALANSIS_KIVISALE;"
        Dim SqlComm17 As New System.Data.SqlClient.SqlCommand(mySelectQuery17, SqlConn)
        Dim reader17 As System.Data.SqlClient.SqlDataReader
        reader17 = SqlComm17.ExecuteReader()
        While reader17.Read()
            ComboBox21.Items.Add(reader17("SALE_TIPI"))
        End While
        reader17.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery18 As String = "SELECT* FROM EO_ALANSIS_KIVIKOSEBENTTIPI;"
        Dim SqlComm18 As New System.Data.SqlClient.SqlCommand(mySelectQuery18, SqlConn)
        Dim reader18 As System.Data.SqlClient.SqlDataReader
        reader18 = SqlComm18.ExecuteReader()
        While reader18.Read()
            ComboBox17.Items.Add(reader18("KOSEBENT_TIPI"))
        End While
        reader18.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery19 As String = "SELECT* FROM EO_ALANSIS_KIVISAPKATIPI;"
        Dim SqlComm19 As New System.Data.SqlClient.SqlCommand(mySelectQuery19, SqlConn)
        Dim reader19 As System.Data.SqlClient.SqlDataReader
        reader19 = SqlComm19.ExecuteReader()
        While reader19.Read()
            ComboBox16.Items.Add(reader19("SAPKA_TIPI"))
        End While
        reader19.Close()
        SqlConn.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        SqlConn.Open()
        Dim mySelectQuery21 As String = "SELECT* FROM EO_ALANSIS_KIVISERIT;"
        Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
        Dim reader21 As System.Data.SqlClient.SqlDataReader
        reader21 = SqlComm21.ExecuteReader()
        While reader21.Read()
            ComboBox23.Items.Add(reader21("SERIT"))
        End While
        reader21.Close()
        SqlConn.Close()
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
        If TextBox4.Text = "0" Or TextBox4.Text = "" Then
            MsgBox("URETILEN MIKTAR 0 OLAMAZ, KONTROL EDINIZ...")
            Exit Sub
        Else

            If ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Or ComboBox1.Text = "" Or ComboBox10.Text = "" Or ComboBox11.Text = "" Or ComboBox12.Text = "" Then
                MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM veya ETIKET KOPYA SAYISI veya DIGER SAHALAR girmelisiniz...")
                Exit Sub
            Else
                serinum = ""
                seri = ""
                If TextBox1.Text = "" Then
                    serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                    seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                    net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                    '---------------------------------------------------------------------------------------------------------------
                    conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    conn1.Open()
                    cmd1.Connection = conn1
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','10','HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                    cmd1.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                    If ComboBox10.Text <> "" Then
                        conn1.Open()
                        cmd2.Connection = conn1
                        cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'U','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd2.ExecuteNonQuery()
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        conn1.Close()
                        '---------------------------------------------------------------------------------------------------
                    End If
                    If ComboBox9.Text <> "" Then
                        conn1.Open()
                        cmd3.Connection = conn1
                        cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'U','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd3.ExecuteNonQuery()
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        conn1.Close()
                        '---------------------------------------------------------------------------------------------------
                    End If
                    If ComboBox13.Text <> "" Then
                        conn1.Open()
                        cmd4.Connection = conn1
                        cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'U','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd4.ExecuteNonQuery()
                        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        conn1.Close()
                        '---------------------------------------------------------------------------------------------------
                    End If
                    '---------------------------------------------------------------------------------------------------
                    If ComboBox14.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'U','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox20.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox20.Text & "', 'U','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox19.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox19.Text & "', 'U','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox22.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox22.Text & "', 'U','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox15.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox15.Text & "', 'U','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox16.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox16.Text & "', 'U','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox17.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox17.Text & "', 'U','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox2.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox2.Text & "', 'U','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox21.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox21.Text & "', 'U','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox23.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox23.Text & "', 'U','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    SqlConn.Open()
                    Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_DEPO;"
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
                    dosya = dosya.Replace("@STOKKODU", "HMD01-10-0001")
                    dosya = dosya.Replace("@MUSTERI", "HAMMADDE KIVI") ' & "VIYOL:" & +ComboBox2.Text)
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
                    serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                    seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                    net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                    '---------------------------------------------------------------------------------------------------------------
                    conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    conn1.Open()
                    cmd1.Connection = conn1
                    cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','10','MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                    cmd1.ExecuteNonQuery()
                    conn1.Close()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox10.Text <> "" Then
                        conn1.Open()
                        cmd6.Connection = conn1
                        cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'U','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd6.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '---------------------------------------------------------------------------------------------------
                    If ComboBox9.Text <> "" Then
                        conn1.Open()
                        cmd7.Connection = conn1
                        cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'U','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd7.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '---------------------------------------------------------------------------------------------------
                    If ComboBox13.Text <> "" Then
                        conn1.Open()
                        cmd8.Connection = conn1
                        cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'U','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd8.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '---------------------------------------------------------------------------------------------------
                    If ComboBox14.Text <> "" Then
                        conn1.Open()
                        cmd9.Connection = conn1
                        cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'U','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd9.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox20.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "' ,'" & TextBox1.Text & "','" & ComboBox20.Text & "', 'U','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox19.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox19.Text & "', 'U','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox22.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox22.Text & "', 'U','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox15.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox15.Text & "', 'U','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox16.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox16.Text & "', 'U','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox17.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox17.Text & "', 'U','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox2.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox2.Text & "', 'U','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox21.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox21.Text & "', 'U','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If ComboBox23.Text <> "" Then
                        conn1.Open()
                        cmd5.Connection = conn1
                        cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox23.Text & "', 'U','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                        cmd5.ExecuteNonQuery()
                        conn1.Close()
                    End If
                    SqlConn.Open()
                    Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
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
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVI_PANEL1 ORDER BY TARIH DESC"
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
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "252800579" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','YARIMAMUL_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'UY','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd2.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'UY','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd3.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'UY','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd4.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'UY','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox20.Text & "', 'UY','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox19.Text & "', 'UY','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox22.Text & "', 'UY','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox15.Text & "', 'UY','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox16.Text & "', 'UY','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox17.Text & "', 'UY','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox2.Text & "', 'UY','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox21.Text & "', 'UY','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox23.Text & "', 'UY','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_DEPO;"
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
                dosya = dosya.Replace("@STOKKODU", "YMD01-10-0001")
                dosya = dosya.Replace("@MUSTERI", "YARIMAMUL KIVI") ' & "VIYOL:" & +ComboBox2.Text)
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
                serinum = "252800579" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','YARIMAMUL_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'UY','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd6.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'UY','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd7.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'UY','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd8.ExecuteNonQuery()
                    conn1.Close()
                End If
                '---------------------------------------------------------------------------------------------------
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'UY','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd9.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox20.Text & "', 'UY','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox19.Text & "', 'UY','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox22.Text & "', 'UY','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox15.Text & "', 'UY','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox16.Text & "', 'UY','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox17.Text & "', 'UY','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox2.Text & "', 'UY','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox21.Text & "', 'UY','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox23.Text & "', 'UY','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
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
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVI_PANEL1 ORDER BY TARIH DESC"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

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
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','SULUK_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'US','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'US','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'US','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'US','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox20.Text & "', 'US','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox19.Text & "', 'US','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox22.Text & "', 'US','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox15.Text & "', 'U2','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox16.Text & "', 'US','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox17.Text & "', 'US','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox2.Text & "', 'US','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox21.Text & "', 'US','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox23.Text & "', 'US','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_DEPO;"
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
                dosya = dosya.Replace("@STOKKODU", "HMD01-10-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE KIVI") ' & "VIYOL:" & +ComboBox2.Text)
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
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','SULUK_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'US','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'US','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'US','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd8.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'US','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd9.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox20.Text & "', 'US','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox19.Text & "', 'US','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox22.Text & "', 'US','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox15.Text & "', 'US','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox16.Text & "', 'US','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox17.Text & "', 'US','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox2.Text & "', 'US','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox21.Text & "', 'US,'" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox23.Text & "', 'US','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
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
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVI_PANEL1 ORDER BY TARIH DESC"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

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
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya VIYOL veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','2KALITE_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'U2','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'U2','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'U2','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'U2','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox20.Text & "', 'U2','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox19.Text & "', 'U2','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox22.Text & "', 'U2','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox15.Text & "', 'U2','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox16.Text & "', 'U2','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox17.Text & "', 'U2','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox2.Text & "', 'U2','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox21.Text & "', 'U2','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox23.Text & "', 'U2','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_DEPO;"
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
                dosya = dosya.Replace("@STOKKODU", "HMD01-10-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE KIVI") ' & "VIYOL:" & +ComboBox2.Text)
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
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','20','2KALITE_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'U2','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'U2','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'U2','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd8.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'U2','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd9.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox20.Text & "', 'U2','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox19.Text & "', 'U2','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox22.Text & "', 'U2','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox15.Text & "', 'U2','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox16.Text & "', 'U2','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox17.Text & "', 'U2','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox2.Text & "', 'U2','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox21.Text & "', 'U2','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox23.Text & "', 'U2','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
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
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVI_PANEL1 ORDER BY TARIH DESC"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

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
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','50','COP_HAMMADDE','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox10.Text & "', 'UC','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd2.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox9.Text & "', 'UC','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd3.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox13.Text & "', 'UC','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd4.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox14.Text & "', 'UC','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox20.Text & "', 'UC','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox19.Text & "', 'UC','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox22.Text & "', 'UC','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox15.Text & "', 'UC','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox16.Text & "', 'UC','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox17.Text & "', 'UC','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox2.Text & "', 'UC','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox21.Text & "', 'UC','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE','" & ComboBox23.Text & "', 'UC','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_DEPO;"
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
                dosya = dosya.Replace("@STOKKODU", "HMD01-10-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE KIVI") ' & "VIYOL:" & +ComboBox2.Text)
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
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','50','COP_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'UC','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd6.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'UC','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd7.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'UC','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd8.ExecuteNonQuery()
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'UC','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd9.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox20.Text & "', 'UC','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox19.Text & "', 'UC','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox22.Text & "', 'UC','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox15.Text & "', 'UC','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox16.Text & "', 'UC','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox17.Text & "', 'UC','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox2.Text & "', 'UC','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox21.Text & "', 'UC','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox23.Text & "', 'UC','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
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
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVI_PANEL1 ORDER BY TARIH DESC"
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
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','12','STOK','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery1 As String = "SELECT COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_DEPO;"
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
                dosya = dosya.Replace("@STOKKODU", "HMD01-10-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE KIVI") ' & "VIYOL:" & +ComboBox2.Text)
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
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVI_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','12','MAMUL','STOK','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                SqlConn.Open()
                Dim mySelectQuery2 As String = "SELECT PARTINO, COUNT(ID) AS SAYI FROM EO_ALANSIS_KIVI_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "'GROUP BY PARTINO;"
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
        Form11.Text = "ALANSIS KIVI URETIM USER :" + TextBox16.Text
        Form11.TextBox1.Text = TextBox1.Text
        Form11.TextBox3.Text = TextBox16.Text
        Form11.Show()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form12.Text = "ALANSIS KIVI URETIM USER :" + TextBox16.Text
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
        If ComboBox1.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or ComboBox7.Text = "" Then
            MsgBox("BOLGE veya ODA veya KALINTI veya ISLEM girmelisiniz...")
            Exit Sub
        Else
            serinum = ""
            seri = ""
            If TextBox1.Text = "" Then
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVIYARIM_DEPO (TARIH, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,URETIM_TIPI,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','YARIM_URETIM','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "', '" & ComboBox21.Text & "','" & TextBox20.Text & "',     '" & ComboBox22.Text & "','" & TextBox23.Text & "','" & ComboBox12.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd2.Connection = conn1
                    cmd2.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox10.Text & "', 'UYM','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd2.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd3.Connection = conn1
                    cmd3.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox9.Text & "', 'UYM','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd3.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd4.Connection = conn1
                    cmd4.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox13.Text & "', 'UYM','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd4.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox14.Text & "', 'UYM','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '---------------------------------------------------------------------------------------------
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox20.Text & "', 'UYM','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox19.Text & "', 'UYM','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox22.Text & "', 'UYM','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox15.Text & "', 'UYM','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox16.Text & "', 'UYM','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox17.Text & "', 'UYM','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox2.Text & "', 'UYM','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox21.Text & "', 'UYM','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', 'HAMMADDE_YARIM','" & ComboBox23.Text & "', 'UYM','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                Dim fullPath As String = "C:\ALANSIS_PANEL\ALANAR4.prn"
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", "HMD01-10-0001")
                dosya = dosya.Replace("@MUSTERI", "HAMMADDE KIVI YARIM") ' & "VIYOL:" & +ComboBox2.Text)
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
                serinum = "2800578" & Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                seri = Format(DateTime.Today, "ddmmyy") & TextBox5.Text & TextBox4.Text
                net = CInt(TextBox4.Text) - CInt(TextBox6.Text)
                '---------------------------------------------------------------------------------------------------------------
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_KIVIYARIM_MAMULDEPO (TARIH,STOK_KODU, SERI, MIKTAR, BOLGE,EBAT, ISLEM, KIVI_ISLEM, ODA, KALINTI,DARA,BRUT,DEPO,TIP,PARTINO,URETIM_TIPI,CESIT,PALET_TIPI,KUTU_TIPI,KUTU_ADET,ETIKET_TIPI,ETIKET_ADET,EBAT_ETIKET,EBAT_ADET,POSET_TIPI,POSET_ADET,SAPKA_TIPI,SAPKA_ADET,KOSEBENT_TIPI,KOSEBENT_ADET,KLIPS_TIPI,KLIPS_ADET,CARRY_BAG_TIPI,CARRY_BAG_ADET,NEM_BEZI_TIPI,NEM_BEZI_ADET,SALE_TIPI,SALE_ADET,FILE_TIPI,FILE_ADET,USR,ACIKLAMA) VALUES ('" & DateTime.Now & "','" & TextBox9.Text & "', '" & serinum & "','" & net & "', '" & ComboBox4.Text & "', '" & ComboBox5.Text & "','" & ComboBox3.Text & "'  ,'" & ComboBox7.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','40','YARIMURETIM_MAMUL','" & TextBox1.Text & "','" & ComboBox12.Text & "','" & ComboBox11.Text & "','" & ComboBox10.Text & "','" & ComboBox9.Text & "','" & TextBox12.Text & "','" & ComboBox13.Text & "','" & TextBox13.Text & "','" & ComboBox14.Text & "','" & TextBox14.Text & "','" & ComboBox15.Text & "','" & TextBox15.Text & "','" & ComboBox16.Text & "','" & TextBox17.Text & "','" & ComboBox17.Text & "','" & TextBox18.Text & "','" & ComboBox20.Text & "','" & TextBox22.Text & "','" & ComboBox19.Text & "','" & TextBox21.Text & "','" & ComboBox2.Text & "','" & TextBox19.Text & "','" & ComboBox21.Text & "','" & TextBox20.Text & "','" & ComboBox22.Text & "','" & TextBox23.Text & "','" & TextBox16.Text & "','" & RichTextBox1.Text & "')"
                cmd1.ExecuteNonQuery()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Close()
                '---------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------
                If ComboBox10.Text <> "" Then
                    conn1.Open()
                    cmd6.Connection = conn1
                    cmd6.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox10.Text & "', 'UYM','1','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd6.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox9.Text <> "" Then
                    conn1.Open()
                    cmd7.Connection = conn1
                    cmd7.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox9.Text & "', 'UYM','" & TextBox12.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd7.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox13.Text <> "" Then
                    conn1.Open()
                    cmd8.Connection = conn1
                    cmd8.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox13.Text & "', 'UYM','" & TextBox13.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd8.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                    '---------------------------------------------------------------------------------------------------
                End If
                If ComboBox14.Text <> "" Then
                    conn1.Open()
                    cmd9.Connection = conn1
                    cmd9.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox14.Text & "', 'UYM','" & TextBox14.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd9.ExecuteNonQuery()
                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox20.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox20.Text & "', 'UYM','" & TextBox22.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox19.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox19.Text & "', 'UYM','" & TextBox21.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox22.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox22.Text & "', 'UYM','" & TextBox23.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox15.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox15.Text & "', 'UYM','" & TextBox15.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox16.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox16.Text & "', 'UYM','" & TextBox17.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox17.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox17.Text & "', 'UYM','" & TextBox18.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox2.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "','" & TextBox1.Text & "','" & ComboBox2.Text & "', 'UYM','" & TextBox19.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If ComboBox21.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox21.Text & "', 'UYM','" & TextBox20.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
                If ComboBox23.Text <> "" Then
                    conn1.Open()
                    cmd5.Connection = conn1
                    cmd5.CommandText = "INSERT INTO EO_ALANSIS_DEPO_SHAR (TARIH,NO, SARF_ADI, TIP, MIKTAR, HAREKET_KODU, BOLGE,USR,SERI) VALUES ('" & DateTime.Now & "', '" & TextBox1.Text & "','" & ComboBox23.Text & "', 'UYM','" & TextBox24.Text & "','C','" & ComboBox4.Text & "','" & TextBox16.Text & "','" & serinum & "')"
                    cmd5.ExecuteNonQuery()
                    conn1.Close()
                End If
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
        '--------------------------------------------------------------------------------------------------
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVI_PANEL1 ORDER BY TARIH DESC"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        '------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form40.TextBox1.Text = TextBox1.Text
        Form40.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form39.TextBox1.Text = TextBox1.Text
        Form39.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox9.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox10.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
        'TextBox11.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form7.Text = "ALANSIS KIVI URETIM USER :" + TextBox16.Text
        Form7.TextBox1.Text = TextBox1.Text
        Form7.TextBox3.Text = TextBox16.Text
        Form7.Show()
    End Sub

    Private Sub ComboBox18_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox18.SelectedIndexChanged
        On Error Resume Next
        SqlConn.Open()
        Dim mySelectQuery21 As String = "SELECT PARTI AS PARTI_NO,MUSTERI,PALET_ADET AS PALET FROM EO_ALANSIS_KIVI_SATIS WHERE PARTI='" & ComboBox18.Text & "';"
        Dim SqlComm21 As New System.Data.SqlClient.SqlCommand(mySelectQuery21, SqlConn)
        Dim reader21 As System.Data.SqlClient.SqlDataReader
        reader21 = SqlComm21.ExecuteReader()
        While reader21.Read()
            TextBox1.Text = (reader21("PARTI_NO").ToString()) ' DataGridView1.CurrentRow.Cells(0).Value.ToString
            TextBox2.Text = "KIVI " & (reader21("MUSTERI").ToString()) ' DataGridView1.CurrentRow.Cells(3).Value.ToString
            TextBox3.Text = (reader21("MUSTERI").ToString()) 'DataGridView1.CurrentRow.Cells(2).Value.ToString
            TextBox9.Text = "KIVI" '(reader21("STOK_KODU").ToString()) 'DataGridView1.CurrentRow.Cells(11).Value.ToString
            TextBox10.Text = (reader21("PALET").ToString()) 'DataGridView1.CurrentRow.Cells(10).Value.ToString
            'TextBox11.Text = (reader21("SIPARIS_NO").ToString()) 'DataGridView1.CurrentRow.Cells(1).Value.ToString

        End While
        reader21.Close()
        SqlConn.Close()





    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Form38.Text = "ALANSIS KIVI HAMMADDE YUKLEME URETIM USER :" + TextBox16.Text
        Form38.TextBox14.Text = TextBox16.Text
        Form38.Show()
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox9.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox10.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
    End Sub
End Class