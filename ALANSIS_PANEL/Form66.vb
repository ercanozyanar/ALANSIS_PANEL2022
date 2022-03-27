Imports System.Data.SqlClient
Imports System.IO
Public Class Form66
    Private printFont As Font
    Private streamToPrint As TextReader
    Dim SqlConnStr As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn As New System.Data.SqlClient.SqlConnection(SqlConnStr)
    Dim SqlConnStr1 As String = "server=10.3.11.61;database=ALANSIS;uid=sa;pwd=term.0907;"
    Dim SqlConn1 As New System.Data.SqlClient.SqlConnection(SqlConnStr1)
    Private Sub Form66_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd, cmd1 As New SqlCommand()
        Dim cnn As New SqlConnection()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        '================================================================================================================================
        SqlConn.Open()
        Dim mySelectQuery2 As String = "SELECT* FROM EO_ALANSIS_KIRAZBOLGE;"
        Dim SqlComm2 As New System.Data.SqlClient.SqlCommand(mySelectQuery2, SqlConn)
        Dim reader2 As System.Data.SqlClient.SqlDataReader
        reader2 = SqlComm2.ExecuteReader()
        While reader2.Read()
            ComboBox1.Items.Add(reader2("BOLGE"))
        End While
        reader2.Close()
        SqlConn.Close()
    End Sub
End Class