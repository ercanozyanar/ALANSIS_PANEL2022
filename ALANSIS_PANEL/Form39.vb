Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form39
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim soru
        Dim conn1, conn2 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        conn2.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        TextBox4.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString    'STOK_KODU
        ' TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString    'STOK_KODU
        TextBox5.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString    'SERI
        'TextBox6.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString    'BOLGE
        'TextBox7.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString    'ISLEM
        'TextBox8.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString    'NAR ISLEM
        'TextBox9.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString    'VIYOL
        'TextBox10.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString  'ODA
        'TextBox11.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString  'KALINTI
        'TextBox12.Text = DataGridView1.CurrentRow.Cells(16).Value.ToString  'PARTI NO
        'TextBox13.Text = DataGridView1.CurrentRow.Cells(17).Value.ToString  'URETIM TIPI
        'TextBox14.Text = DataGridView1.CurrentRow.Cells(18).Value.ToString  'CESIT
        'TextBox15.Text = DataGridView1.CurrentRow.Cells(19).Value.ToString  'PALET TIPI
        'TextBox16.Text = DataGridView1.CurrentRow.Cells(20).Value.ToString  'KUTU TIPI
        'TextBox17.Text = DataGridView1.CurrentRow.Cells(21).Value.ToString  'KUTU ADET
        'TextBox18.Text = DataGridView1.CurrentRow.Cells(22).Value.ToString  'ETIKET TIPI
        'TextBox19.Text = DataGridView1.CurrentRow.Cells(23).Value.ToString  'ETIKET ADET
        'TextBox20.Text = DataGridView1.CurrentRow.Cells(24).Value.ToString  'EBAT ETIKET
        'TextBox21.Text = DataGridView1.CurrentRow.Cells(25).Value.ToString  'EBAT ADET
        'TextBox22.Text = DataGridView1.CurrentRow.Cells(26).Value.ToString  'YARD_MAL_TIPI
        'TextBox23.Text = DataGridView1.CurrentRow.Cells(27).Value.ToString  'YARD_MAL_ADET
        'TextBox24.Text = DataGridView1.CurrentRow.Cells(28).Value.ToString  'SAPKA TIPI 
        'TextBox25.Text = DataGridView1.CurrentRow.Cells(219).Value.ToString 'SAPKA ADET
        'TextBox26.Text = DataGridView1.CurrentRow.Cells(30).Value.ToString  'KOSEBENT TIPI
        'TextBox27.Text = DataGridView1.CurrentRow.Cells(31).Value.ToString  'KOSEBENT ADET
        If TextBox1.Text <> "" Then
            soru = MsgBox("YARIM PALET AKTARILACAKTIR EMIN MISINIZ ?", vbExclamation + vbYesNo, "ALANSIS")
            If soru = vbYes Then

                Form3.TextBox9.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString    'STOK_KODU
                'Form3.TextBox5.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString    'SERI
                Form3.ComboBox4.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString    'BOLGE
                Form3.ComboBox3.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString    'ISLEM
                Form3.ComboBox7.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString    'NAR ISLEM
                Form3.ComboBox2.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString    'VIYOL
                Form3.ComboBox6.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString  'ODA
                Form3.ComboBox1.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString  'KALINTI
                Form3.TextBox1.Text = DataGridView1.CurrentRow.Cells(16).Value.ToString  'PARTI NO
                Form3.ComboBox12.Text = DataGridView1.CurrentRow.Cells(17).Value.ToString  'URETIM TIPI
                Form3.ComboBox11.Text = DataGridView1.CurrentRow.Cells(18).Value.ToString  'CESIT
                Form3.ComboBox10.Text = DataGridView1.CurrentRow.Cells(19).Value.ToString  'PALET TIPI
                Form3.ComboBox9.Text = DataGridView1.CurrentRow.Cells(20).Value.ToString  'KUTU TIPI
                Form3.TextBox12.Text = DataGridView1.CurrentRow.Cells(21).Value.ToString  'KUTU ADET
                Form3.ComboBox13.Text = DataGridView1.CurrentRow.Cells(22).Value.ToString  'ETIKET TIPI
                Form3.TextBox13.Text = DataGridView1.CurrentRow.Cells(23).Value.ToString  'ETIKET ADET
                Form3.ComboBox14.Text = DataGridView1.CurrentRow.Cells(24).Value.ToString  'EBAT ETIKET
                Form3.TextBox14.Text = DataGridView1.CurrentRow.Cells(25).Value.ToString  'EBAT ADET
                Form3.ComboBox15.Text = DataGridView1.CurrentRow.Cells(26).Value.ToString  'YARD_MAL_TIPI
                Form3.TextBox15.Text = DataGridView1.CurrentRow.Cells(27).Value.ToString  'YARD_MAL_ADET
                Form3.ComboBox16.Text = DataGridView1.CurrentRow.Cells(28).Value.ToString  'SAPKA TIPI 
                Form3.TextBox17.Text = DataGridView1.CurrentRow.Cells(29).Value.ToString 'SAPKA ADET
                Form3.ComboBox17.Text = DataGridView1.CurrentRow.Cells(30).Value.ToString  'KOSEBENT TIPI
                Form3.TextBox18.Text = DataGridView1.CurrentRow.Cells(31).Value.ToString  'KOSEBENT ADET
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                conn2.Open()
                cmd.Connection = conn2
                cmd.CommandText = "DELETE FROM EO_ALANSIS_KIVIYARIM_MAMULDEPO WHERE ID='" & TextBox4.Text & "'"
                cmd.ExecuteNonQuery()
                conn2.Close()
                conn2.Open()
                cmd.Connection = conn2
                cmd.CommandText = "DELETE FROM EO_ALANSIS_DEPO_SHAR WHERE TARIH='" & TextBox5.Text & "'"
                cmd.ExecuteNonQuery()
                conn2.Close()
                '---------------------------------------------------------------------------------------------------
                Form3.Show()
                Me.Hide()
                If soru = vbNo Then
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub Form39_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        If TextBox1.Text <> "" Then
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVIYARIM_MAMULDEPO ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
        If TextBox1.Text = "" Then
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_KIVIYARIM_DEPO ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
        End If
    End Sub
End Class