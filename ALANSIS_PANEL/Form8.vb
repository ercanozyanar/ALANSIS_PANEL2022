Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form8
    Private printFont As Font
    Private streamToPrint As TextReader
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If TextBox1.Text = "" Then '
            Dim cmd As New SqlCommand()
            Dim cnn As New SqlConnection()
            Dim da As New SqlDataAdapter()
            Dim ds As New DataSet

            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_DEPO ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        If TextBox1.Text <> "" Then '
            Dim cmd As New SqlCommand()
            Dim cnn As New SqlConnection()
            Dim da As New SqlDataAdapter()
            Dim ds As New DataSet

            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "' ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
    End Sub
    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim serikontrol, kalintix, etiket, etiketm, stok_kod, partino, tip, oda, miktar, dara, brut, serinum, durum, seri, kalinti, bolge, islem, nar_islem, viyol, idx
        Dim soru, indeks
        Dim conn1, conn2 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        '--------------------------------------------------------------------------------------------------------------------------------------------------------
        indeks = "0"
        indeks = DataGridView1.CurrentCell.ColumnIndex

        If indeks = "1" Then
            conn2.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            soru = MsgBox("KAYIT SILINECEKTIR EMIN MISINIZ ?", vbExclamation + vbYesNo, "ALANSIS")
            If soru = vbYes Then
                If TextBox1.Text = "" Then
                    serikontrol = DataGridView1.CurrentRow.Cells(4).Value.ToString
                    idx = DataGridView1.CurrentRow.Cells(2).Value.ToString
                    conn2.Open()
                    cmd2.Connection = conn2
                    cmd2.CommandText = "DELETE EO_ALANSIS_NAR_DEPO WHERE ID='" & idx & "'"
                    cmd2.ExecuteNonQuery()
                    conn2.Close()
                    Try
                        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                        cnn.Open()
                        cmd.Connection = cnn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_DEPO ORDER BY ID DESC"
                        da.SelectCommand = cmd
                        da.Fill(ds)
                        DataGridView1.DataSource = ds.Tables(0).DefaultView
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    cnn.Close()
                    MsgBox("KAYIT SILINMISTIR...")
                End If
                If TextBox1.Text <> "" Then
                    serikontrol = DataGridView1.CurrentRow.Cells(5).Value.ToString
                    idx = DataGridView1.CurrentRow.Cells(2).Value.ToString
                    conn2.Open()
                    cmd2.Connection = conn2
                    cmd2.CommandText = "DELETE EO_ALANSIS_NAR_MAMULDEPO WHERE ID='" & idx & "'"
                    cmd2.ExecuteNonQuery()
                    conn2.Close()
                    Try
                        cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                        cnn.Open()
                        cmd.Connection = cnn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "' ORDER BY ID DESC"
                        da.SelectCommand = cmd
                        da.Fill(ds)
                        DataGridView1.DataSource = ds.Tables(0).DefaultView
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    cnn.Close()
                    MsgBox("KAYIT SILINMISTIR...")
                End If
            End If
            If soru = vbNo Then
                Exit Sub
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If TextBox1.Text = "" Then
            TextBox2.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
            ComboBox4.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
            ComboBox3.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
            ComboBox7.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
            ComboBox2.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
            ComboBox6.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString
        End If
        If TextBox1.Text <> "" Then
            TextBox2.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
            ComboBox4.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
            ComboBox3.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
            ComboBox7.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
            ComboBox2.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
            ComboBox6.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(12).Value.ToString
        End If
    End Sub


    Private Sub BindingSource1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim serikontrol, kalintix, etiket, etiketm, stok_kod, partino, tip, oda, miktar, dara, brut, serinum, durum, seri, kalinti, bolge, islem, nar_islem, viyol, idx
        Dim sBuf As String
        Dim sTemp As String
        Dim iFileNum As Integer
        Dim sFileName As String
        Dim soru, indeks
        Dim conn1, conn2 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        '--------------------------------------------------------------------------------------------------------------------------------------------------------
        conn2.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        If TextBox1.Text = "" Then
            serikontrol = DataGridView1.CurrentRow.Cells(4).Value.ToString
            idx = DataGridView1.CurrentRow.Cells(2).Value.ToString
            '---------------------------------------------------------------------------------------------------
            conn2.Open()
            cmd2.Connection = conn2
            cmd2.CommandText = "UPDATE EO_ALANSIS_NAR_DEPO SET MIKTAR='" & TextBox2.Text & "',BOLGE='" & ComboBox4.Text & "',ISLEM='" & ComboBox3.Text & "',NAR_ISLEM='" & ComboBox7.Text & "',VIYOL='" & ComboBox2.Text & "',ODA='" & ComboBox6.Text & "',KALINTI='" & ComboBox1.Text & "' WHERE ID='" & idx & "'"
            cmd2.ExecuteNonQuery()
            conn2.Close()
            '---------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANSIS_NAR_DEPO WHERE SERI='" & serikontrol & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                miktar = reader1("MIKTAR").ToString()
                bolge = reader1("BOLGE").ToString()
                islem = reader1("ISLEM").ToString()
                nar_islem = reader1("NAR_ISLEM").ToString()
                viyol = reader1("VIYOL").ToString()
                oda = reader1("ODA").ToString()
                kalintix = reader1("KALINTI").ToString()
                brut = reader1("BRUT").ToString()
                tip = reader1("TIP").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            If kalintix = "VAR" Then
                kalinti = "1"
            End If
            If kalintix = "YOK" Then
                kalinti = "0"
            End If
            '------------------------------------------------------------------------------------------------------
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_DEPO ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            MsgBox("DUZELTME ISLEMI TAMAMLANDI...")
            '---------------------------------------------------------------------------------------------
            If tip = "HAMMADDE" Then
                etiket = "C:\ALANSIS_PANEL\alanar1.prn"
            End If
            If tip = "2.KALITE" Then
                etiket = "C:\ALANSIS_PANEL\alanar4.prn"
            End If
            If tip = "YARIMAMUL" Then
                etiket = "C:\ALANSIS_PANEL\alanar2.prn"
            End If
            If tip = "SULUK" Then
                etiket = "C:\ALANSIS_PANEL\alanar3.prn"
            End If
            '---------------------------------------------------------------------------------------------------------------
            Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
            Dim fullPath As String = etiket
            Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
            clientSocket.Connect(ipend)
            System.Reflection.Assembly.GetExecutingAssembly.GetName()
            Dim tr As TextReader = New StreamReader(fullPath)
            '---------------------------------------------------------------------------------------------------------------
            Dim dosya As String = (tr.ReadToEnd)
            dosya = dosya.Replace("@STOKKODU", "HMD01-05-0001")
            dosya = dosya.Replace("@MUSTERI", "HAMMADDE NAR") ' & "VIYOL:" & +ComboBox2.Text)
            dosya = dosya.Replace("@TARIH", DateTime.Now)
            dosya = dosya.Replace("@PARTINO", "")
            dosya = dosya.Replace("@NET", miktar)
            dosya = dosya.Replace("@DARA", dara)
            dosya = dosya.Replace("@BRUT", brut)
            dosya = dosya.Replace("@BARKOD", serikontrol)
            dosya = dosya.Replace("@durum", nar_islem)
            dosya = dosya.Replace("@SERI", serikontrol)
            dosya = dosya.Replace("@KALINTI", kalinti)
            Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
            clientSocket.Send(fileBytes)
            clientSocket.Close()
        End If
        If TextBox1.Text <> "" Then
            serikontrol = DataGridView1.CurrentRow.Cells(5).Value.ToString
            idx = DataGridView1.CurrentRow.Cells(2).Value.ToString
            '---------------------------------------------------------------------------------------------------
            conn2.Open()
            cmd2.Connection = conn2
            cmd2.CommandText = "UPDATE EO_ALANSIS_NAR_MAMULDEPO SET MIKTAR='" & TextBox2.Text & "',BOLGE='" & ComboBox4.Text & "',ISLEM='" & ComboBox3.Text & "',NAR_ISLEM='" & ComboBox7.Text & "',VIYOL='" & ComboBox2.Text & "',ODA='" & ComboBox6.Text & "',KALINTI='" & ComboBox1.Text & "' WHERE ID='" & idx & "'"
            cmd2.ExecuteNonQuery()
            conn2.Close()
            '---------------------------------------------------------------------------------------------------
            SqlConn.Open()
            Dim mySelectQuery1 As String = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE SERI='" & serikontrol & "';"
            Dim SqlComm1 As New System.Data.SqlClient.SqlCommand(mySelectQuery1, SqlConn)
            Dim reader1 As System.Data.SqlClient.SqlDataReader
            reader1 = SqlComm1.ExecuteReader()
            While reader1.Read()
                stok_kod = reader1("stok_kodu").ToString()
                miktar = reader1("MIKTAR").ToString()
                bolge = reader1("BOLGE").ToString()
                islem = reader1("ISLEM").ToString()
                nar_islem = reader1("NAR_ISLEM").ToString()
                viyol = reader1("VIYOL").ToString()
                oda = reader1("ODA").ToString()
                kalintix = reader1("KALINTI").ToString()
                brut = reader1("BRUT").ToString()
                tip = reader1("TIP").ToString()
                partino = reader1("PARTINO").ToString()
            End While
            reader1.Close()
            SqlConn.Close()
            If kalintix = "VAR" Then
                kalinti = "1"
            End If
            If kalintix = "YOK" Then
                kalinti = "0"
            End If
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_NAR_MAMULDEPO WHERE PARTINO='" & TextBox1.Text & "' ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            MsgBox("DUZELTME ISLEMI TAMAMLANDI...")
                '---------------------------------------------------------------------------------------------
                Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim logDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                If tip = "MAMUL" Then
                etiketm = "C:\ALANSIS_PANEL\alanar_mamul1.prn"
                End If
                If tip = "2.KALITE" Then
                etiketm = "C:\ALANSIS_PANEL\alanar_mamul4.prn"
                End If
                If tip = "YARIMAMUL" Then
                etiketm = "C:\ALANSIS_PANEL\alanar_mamul2.prn"
                End If
                If tip = "SULUK" Then
                etiketm = "C:\ALANSIS_PANEL\alanar_mamul3.prn"
                End If
                Dim fullPath As String
                fullPath = etiketm
                Dim ipend As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.70.10.251"), 9100)
                clientSocket.Connect(ipend)
                '---------------------------------------------------------------------------------------------------------------
                System.Reflection.Assembly.GetExecutingAssembly.GetName()
                Dim tr As TextReader = New StreamReader(fullPath)
                Dim dosya As String = (tr.ReadToEnd)
                dosya = dosya.Replace("@STOKKODU", stok_kod)
                dosya = dosya.Replace("@MUSTERI", partino) ' & "VIYOL:" & +ComboBox2.Text)
                dosya = dosya.Replace("@TARIH", DateTime.Now)
                dosya = dosya.Replace("@PARTINO", "")
                dosya = dosya.Replace("@NET", miktar)
                dosya = dosya.Replace("@DARA", dara)
                dosya = dosya.Replace("@BRUT", brut)
                dosya = dosya.Replace("@BARKOD", serikontrol)
                dosya = dosya.Replace("@durum", nar_islem)
                dosya = dosya.Replace("@SERI", serikontrol)
                dosya = dosya.Replace("@KALINTI", kalinti)
                Dim fileBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(dosya) 'File.ReadAllBytes("C:\10050.prn")
                clientSocket.Send(fileBytes)
                clientSocket.Close()

            End If

    End Sub
End Class