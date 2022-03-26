Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.Net.Mail
Public Class Form55
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Dim SMTP As New SmtpClient("smtp.gmail.com")
    Dim Mail As New MailMessage
    Private Sub Form55_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT PARTI,RENK,STOK_ADI,MUSTERI,PALET_ADET FROM EO_ALANAR_INCIRSIP_ISLEM"
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
            Dim serikont, serihamkont, hamserionay, USK, ymkont, ymstokkod, ymstokad As String
            Dim MIKTAR, YUK_MIKTAR, FIRE, YMMIKTAR As Integer
            Dim conn1 As New SqlConnection
            Dim cmd1 As New SqlCommand
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            USK = ""
            barkod = ""
            hammadde = ""
            seri = ""
            kontrol = ""
            serikont = ""
            serihamkont = ""
            stokkodu = ""
            stokadi = ""
            ymkont = ""
            ymstokkod = ""
            ymstokad = ""
            MIKTAR = 0
            YUK_MIKTAR = 0
            FIRE = 0
            YMMIKTAR = 0
            TextBox20.Visible = False
            TextBox2.Visible = True
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
            'HAMMADDE BARKOD KONTROLU
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
            SqlConn.Open()
            Dim mySelectQuery212 As String = "SELECT* FROM EO_ALANSIS_MAMHARSERI WHERE SERI='" & TextBox1.Text & "' AND BELGENO LIKE '%YARIMAMUL%' ;"
            Dim SqlComm212 As New System.Data.SqlClient.SqlCommand(mySelectQuery212, SqlConn)
            Dim reader212 As System.Data.SqlClient.SqlDataReader
            reader212 = SqlComm212.ExecuteReader()
            While reader212.Read()
                ymstokkod = reader212("STOK_KODU").ToString()
                ymstokad = reader212("STOK_ADI").ToString()
                YMMIKTAR = reader212("MIKTAR")
            End While
            reader212.Close()
            SqlConn.Close()
            If ymstokkod <> "" Or ymstokad <> "" Then
                TextBox20.Visible = True
                TextBox2.Visible = False
            End If
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
                    If barkod = "2800018" Or barkod = "2800013" Then
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
                        Dim uretici, bolge As String
                        '============================================================================================================================================================================================================================================================================
                        SqlConn.Open()
                        Dim mySelectQuery31 As String = "SELECT URETICI_ADSOY, BOLGE FROM EO_ALANSIS_MADHAMKABUL WHERE KABUL_SERI='" & seri & "' GROUP BY URETICI_ADSOY,BOLGE"
                        Dim SqlComm31 As New System.Data.SqlClient.SqlCommand(mySelectQuery31, SqlConn)
                        Dim reader31 As System.Data.SqlClient.SqlDataReader
                        reader31 = SqlComm31.ExecuteReader()
                        While reader31.Read()
                            uretici = reader31("URETICI_ADSOY").ToString()
                            bolge = reader31("bolge").ToString()
                        End While
                        reader31.Close()
                        SqlConn.Close()
                        '============================================================================================================================================================================================================================================================================
                        If barkod = "2800018" Or barkod = "2800013" Then
                            conn1.Open()
                            cmd1.Connection = conn1
                            cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS,USR) VALUES ('" & kontrol & "', '" & DateTime.Today & "','" & TextBox2.Text & "', '" & TextBox3.Text & "','" & seri & "'  ,'" & MIKTAR & "','" & DateTime.Now & "' ,'0','0','" & TextBox14.Text & "')"
                            cmd1.ExecuteNonQuery()
                            conn1.Close()
                            '================================================================================================================================================================================================
                            conn1.Open()
                            cmd1.Connection = conn1
                            cmd1.CommandText = "ALTER VIEW EO_YUKLEME_MAIL AS SELECT URETICI_ADSOY AS ISLENEN_URETICI,BOLGE AS ISLENEN_BOLGE FROM EO_ALANSIS_MADHAMKABUL WHERE KABUL_SERI='" & seri & "' GROUP BY URETICI_ADSOY,BOLGE"
                            cmd1.ExecuteNonQuery()
                            conn1.Close()
                            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            conn1.Open()
                            cmd1.Connection = conn1
                            'cmd1.CommandText = "exec dbo.EOZYANAR_SP_ViewToEmail 'EO_YUKLEME_MAIL','Parti No :" + kontrol + " Islenen Hammadde Bilgisi','ercanozyanar@gmail.com',''"
                            cmd1.CommandText = "exec dbo.EOZYANAR_SP_ViewToEmail 'EO_YUKLEME_MAIL','Parti No :" + kontrol + " Islenen Hammadde Bilgisi','ridvan.akman@alanar.com.tr;canan.bulut@alanar.com.tr;kalite.saha@alanar.com.tr',''"
                            cmd1.ExecuteNonQuery()
                            conn1.Close()
                            '================================================================================================================================================================================================
                            MsgBox("SERI SISTEME YUKLENMISTIR. YUKLENEN PARTI NO :" + kontrol)
                            '============================================================================================================================================================================================================================================================================

                        End If
                        '================================================================================================================================================================================================
                        If ymstokkod <> "" Or ymstokad <> "" Then
                            conn1.Open()
                            cmd1.Connection = conn1
                            cmd1.CommandText = "INSERT INTO EO_SARF_TUKETIM_SERI (SIPARIS, TARIH, STOK_KODU, STOK_ADI, SERI, MIKTAR, ZAMAN, TUKETIM, INDEKS,USR) VALUES ('" & kontrol & "', '" & DateTime.Today & "','" & ymstokkod & "', '" & ymstokad & "','" & TextBox1.Text & "'  ,'" & YMMIKTAR & "','" & DateTime.Now & "' ,'0','0','" & TextBox14.Text & "')"
                            cmd1.ExecuteNonQuery()
                            conn1.Close()
                        End If
                    Else
                        MsgBox("ONAYSIZ SERI...SISTEME YUKLENMEMISTIR.             YUKLENMEYEN PARTI NO :" + kontrol)
                    End If
                    'Else
                    'MsgBox("SERI SISTEME YUKLENMEMISTIR. YUKLENMEYEN PARTI NO :" + kontrol)
                    'End If
                Next
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_FIRE (TARIH, BARKOD, SERI, STOK_KODU, STOK_ADI, BARKOD_MIKTAR, FIRE_MIKTAR,TIP) VALUES ('" & DateTime.Today & "','" & TextBox1.Text & "', '" & seri & "','" & TextBox2.Text & "'  ,'" & TextBox3.Text & "','" & FIRE & "' ,'" & TextBox16.Text & "','MAMUL')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                USK = kontrol & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_HAMHAR ([TARIH],[STOK_KODU],[STOK_ADI],[HARAKET_TIPI],[HARAKET_KODU],[BELGENO],[MIKTAR],[DEPO_KODU]) values  ('" & (Now.Year & "-" & Now.Month & "-" & Now.Day) & "','" & TextBox2.Text & "','" & TextBox3.Text & "','URETIM','C','" & USK & "','" & TextBox15.Text & "','30')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "INSERT INTO EO_ALANSIS_HAMHARSERI ([TARIH],[SERI],[STOK_KODU],[STOK_ADI],[HARAKET_TIPI],[HARAKET_KODU],[BELGENO],[MIKTAR],[DEPO_KODU])   values  ('" & (Now.Year & "-" & Now.Month & "-" & Now.Day) & "','" & seri & "','" & TextBox2.Text & "','" & TextBox3.Text & "','URETIM','C','" & USK & "','" & TextBox15.Text & "','30')"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox15.Text = ""
            TextBox16.Text = ""
        End If
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
    End Sub
    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text = "" Then
            Exit Sub
        Else
            ListBox1.Items.Remove(TextBox19.Text)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class