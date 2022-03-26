Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Public Class Form42
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)

    Private Sub Form42_Load(sender As Object, e As EventArgs) Handles Me.Load
        '================================================================================================================================
        '*** PARTI BILGISINE GORE RECETE
        SqlConn.Open()
        Dim mySelectQuery20 As String = "SELECT RECETE_INDEKS FROM EO_ALANSIS_RECETE WHERE PARTINO='" & TextBox1.Text & "' GROUP BY RECETE_INDEKS  "
        Dim SqlComm20 As New System.Data.SqlClient.SqlCommand(mySelectQuery20, SqlConn)
        Dim reader20 As System.Data.SqlClient.SqlDataReader
        reader20 = SqlComm20.ExecuteReader()
        While reader20.Read()
            ComboBox18.Items.Add(reader20("RECETE_INDEKS"))
        End While
        reader20.Close()
        SqlConn.Close()
        '================================================================================================================================
    End Sub
    Private Sub ComboBox18_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox18.SelectedIndexChanged
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        '================================================================================================================================
        '*** PARTI BILGISINE GORE RECETE
        SqlConn.Open()
        Dim mySelectQuery20 As String = "SELECT RECETE_TANIM FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & ComboBox18.Text & "' GROUP BY RECETE_TANIM  "
        Dim SqlComm20 As New System.Data.SqlClient.SqlCommand(mySelectQuery20, SqlConn)
        Dim reader20 As System.Data.SqlClient.SqlDataReader
        reader20 = SqlComm20.ExecuteReader()
        While reader20.Read()
            TextBox2.Text = reader20("RECETE_TANIM")
        End While
        reader20.Close()
        SqlConn.Close()
        '================================================================================================================================
        conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        conn1.Open()
        cmd2.Connection = conn1
        cmd2.CommandType = CommandType.Text
        cmd2.CommandText = "SELECT STOK_ADI,MIKTAR FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & ComboBox18.Text & "'"
        da.SelectCommand = cmd2
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        conn1.Close()
        DataGridView1.Columns(0).Width = 250
        DataGridView1.Columns(1).Width = 100
        For i = 0 To DataGridView1.Rows.Count - 1 Step 2
            DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
        Next
        '================================================================================================================================
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox3.Text = "INCIR" Then
            Form47.TextBox12.Text = ComboBox18.Text
            Me.Close()
        End If
        If TextBox3.Text = "ERIK" Then
            Form48.TextBox12.Text = ComboBox18.Text
            Me.Close()
        End If
        If TextBox3.Text = "NAR" Then
            Form62.TextBox12.Text = ComboBox18.Text
            Me.Close()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        Dim conn1 As New SqlConnection
        Dim cmd1, cmd2 As New SqlCommand
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        If ComboBox18.Text = "" Then
            MsgBox("Lütfen Reçete Seçiniz...")
        Else
            '================================================================================================================================
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "DELETE FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & ComboBox18.Text & "'"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            '================================================================================================================================
            MsgBox("Reçete Silinmiştir.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        On Error Resume Next
        Dim i As Integer
        i = 0
        '==================================================================================
        Form61.TextBox12.Text = ""
        Form61.TextBox3.Text = ""
        Form61.TextBox13.Text = ""
        Form60.TextBox4.Text = ""
        Form61.TextBox14.Text = ""
        Form61.TextBox5.Text = ""
        Form61.TextBox15.Text = ""
        Form61.TextBox6.Text = ""
        Form61.TextBox16.Text = ""
        Form61.TextBox7.Text = ""
        Form61.TextBox17.Text = ""
        Form61.TextBox8.Text = ""
        Form61.TextBox18.Text = ""
        Form61.TextBox9.Text = ""
        Form61.TextBox19.Text = ""
        Form61.TextBox10.Text = ""
        Form61.TextBox20.Text = ""
        Form61.TextBox11.Text = ""
        '==================================================================================
        Dim myConnString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
        Dim conn As New SqlConnection
        Dim myCommand As New SqlCommand
        Dim myAdapter As New SqlDataAdapter()
        Dim myData As New DataTable
        Dim SQL As String
        SQL = "SELECT * FROM EO_ALANSIS_RECETE WHERE RECETE_INDEKS='" & ComboBox18.Text & "'"
        conn.ConnectionString = myConnString
        conn.Open()
        myCommand.Connection = conn
        myCommand.CommandText = SQL
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(myData)
        For Each drRow As DataRow In myData.Rows
            i = i + 1
            If i = 1 Then
                '================================================================================================================================
                Form61.TextBox12.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox3.Text = drRow.Item("MIKTAR").ToString()
                '================================================================================================================================
            End If
            If i = 2 Then
                '================================================================================================================================
                Form61.TextBox13.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox4.Text = drRow.Item("MIKTAR").ToString()
            End If
            If i = 3 Then

                Form61.TextBox14.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox5.Text = drRow.Item("MIKTAR").ToString()
            End If
            If i = 4 Then
                Form61.TextBox15.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox6.Text = drRow.Item("MIKTAR").ToString()
            End If
            If i = 5 Then
                '================================================================================================================================
                Form61.TextBox16.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox7.Text = drRow.Item("MIKTAR").ToString()
            End If
            If i = 6 Then
                Form61.TextBox17.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox8.Text = drRow.Item("MIKTAR").ToString()
            End If
            If i = 7 Then
                '================================================================================================================================
                Form61.TextBox18.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox9.Text = drRow.Item("MIKTAR").ToString()
                '================================================================================================================================
            End If
            If i = 8 Then
                '================================================================================================================================
                Form61.TextBox19.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox10.Text = drRow.Item("MIKTAR").ToString()
                '================================================================================================================================
            End If
            If i = 9 Then
                '================================================================================================================================
                Form61.TextBox20.Text = drRow.Item("STOK_ADI").ToString()
                Form61.TextBox11.Text = drRow.Item("MIKTAR").ToString()
                '================================================================================================================================
            End If

        Next
        'Form61.ComboBox2.Text = TextBox4.Text
        Form61.TextBox1.Text = TextBox1.Text
        Form61.TextBox2.Text = ComboBox18.Text
        Form61.Show()
    End Sub
End Class