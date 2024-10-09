Public Class DBConnection

#Region "Class Import"

    Public WithEvents OLEConn As New System.Data.OleDb.OleDbConnection
    Public WithEvents OLEComm As New System.Data.OleDb.OleDbCommand
    Public WithEvents SQLConn As New System.Data.SqlClient.SqlConnection
    Public WithEvents SQLComm As New System.Data.SqlClient.SqlCommand

#End Region

#Region "class Function"

    Public Function SQL(ByVal DBString As String) As Boolean
        Try
            SQLConn.ConnectionString = "Data Source=127.0.0.1;Network Library=DBMSSOCN;Initial Catalog=MMS;User ID=sa;Password=84652;"
            SQLConn.Open()
            SQLComm.CommandText = DBString
            Return True
        Catch err As System.Exception
            Return False
        End Try
    End Function

    Public Function SQL() As String
        Return ("Data Source=127.0.0.1;Network Library=DBMSSOCN;Initial Catalog=MMS;User ID=sa;Password=84652;")
    End Function

#End Region

End Class