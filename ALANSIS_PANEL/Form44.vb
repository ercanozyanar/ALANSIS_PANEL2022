Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Public Class Form44
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Private Sub Form44_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANAR2021;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT STOK_ADI FROM EO_ALANSIS_YARDIMCIMALZEME"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox4.Text = "COP"
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETECOP ORDER BY ID DESC"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox4.Text = "YARIMAMUL"
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETEYARIMAMUL ORDER BY ID DESC"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox4.Text = "2KALITE"
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETE2KALITE ORDER BY ID DESC"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        TextBox4.Text = "SULUK"
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETESULUK ORDER BY ID DESC"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Dim miktar As Integer
        miktar = TextBox3.Text
        If TextBox4.Text = "COP" Then
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETECOP (TARIH,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & TextBox2.Text & "', '" & miktar & "')"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETECOP ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
        If TextBox4.Text = "SULUK" Then
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETESULUK (TARIH,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & TextBox2.Text & "', '" & miktar & "')"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETESULUK ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
        If TextBox4.Text = "2KALITE" Then
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETE2KALITE (TARIH,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & TextBox2.Text & "', '" & miktar & "')"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETE2KALITE ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
        If TextBox4.Text = "YARIMAMUL" Then
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETEYARIMAMUL (TARIH,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & TextBox2.Text & "', '" & miktar & "')"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETEYARIMAMUL ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
        If TextBox4.Text = "RECELLIK" Then
            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "INSERT INTO EO_ALANSIS_RECETERECELLIK (TARIH,STOK_ADI,MIKTAR) VALUES ('" & DateTime.Now & "','" & TextBox2.Text & "', '" & miktar & "')"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETERECELLIK ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        cnn.ConnectionString = "server=10.3.11.61;database=ALANAR2021;uid=sa;pwd=term.0907;"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT STOK_ADI FROM EO_ALANSIS_YARDIMCIMALZEME WHERE STOK_ADI LIKE '%" & TextBox1.Text & "%'"
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0).DefaultView
        cnn.Close()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
    End Sub

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        Dim conn1, conn2, conn3 As New SqlConnection
        Dim cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As New SqlCommand
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Dim sil, soru
        sil = DataGridView2.CurrentRow.Cells(0).Value.ToString
        soru = MsgBox("Kayıt Silinecektir, Eminimisiniz...", vbYesNo)
        If soru = vbYes Then
            If TextBox4.Text = "COP" Then
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "DELETE FROM EO_ALANSIS_RECETECOP WHERE ID='" & sil & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETECOP ORDER BY ID DESC"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView2.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cnn.Close()
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
            If TextBox4.Text = "SULUK" Then
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "DELETE FROM EO_ALANSIS_RECETESULUK WHERE ID='" & sil & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETESULUK ORDER BY ID DESC"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView2.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cnn.Close()
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
            If TextBox4.Text = "2KALITE" Then
                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "DELETE FROM EO_ALANSIS_RECETE2KALITE  WHERE ID='" & sil & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETE2KALITE ORDER BY ID DESC"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView2.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cnn.Close()
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
            If TextBox4.Text = "YARIMAMUL" Then

                conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                conn1.Open()
                cmd1.Connection = conn1
                cmd1.CommandText = "DELETE FROM EO_ALANSIS_RECETEYARIMAMUL WHERE ID='" & sil & "'"
                cmd1.ExecuteNonQuery()
                conn1.Close()
                Try
                    cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                    cnn.Open()
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETEYARIMAMUL ORDER BY ID DESC"
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    DataGridView2.DataSource = ds.Tables(0).DefaultView
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cnn.Close()
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
        End If
        If TextBox4.Text = "RECELLIK" Then

            conn1.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            conn1.Open()
            cmd1.Connection = conn1
            cmd1.CommandText = "DELETE FROM EO_ALANSIS_RECETERECELLIK WHERE ID='" & sil & "'"
            cmd1.ExecuteNonQuery()
            conn1.Close()
            Try
                cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
                cnn.Open()
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETERECELLIK ORDER BY ID DESC"
                da.SelectCommand = cmd
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0).DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cnn.Close()
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If

        If soru = vbNo Then
            Exit Sub
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        TextBox4.Text = "RECELLIK"
        Dim cmd As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        Try
            cnn.ConnectionString = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT* FROM EO_ALANSIS_RECETERECELLIK ORDER BY ID DESC"
            da.SelectCommand = cmd
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cnn.Close()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
End Class