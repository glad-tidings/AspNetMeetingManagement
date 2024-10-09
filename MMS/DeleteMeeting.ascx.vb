Public Class DeleteMeeting
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub YesM_Click(sender As Object, e As EventArgs) Handles YesM.Click
        Dim QSTRI As String = Request.QueryString("ID")
        If IsNumeric(QSTRI) Then
            Try
                DBConn = New DBConnection
                DBConn.SQL("Delete From Meetings WHERE MID = " & QSTRI & ";")
                Try
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    DBConn.SQLComm.ExecuteNonQuery()
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
            Try
                DBConn = New DBConnection
                DBConn.SQL("Delete From MeetingMembers WHERE MID = " & QSTRI & ";")
                Try
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    DBConn.SQLComm.ExecuteNonQuery()
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
            Catch err As System.Exception
            End Try
        End If
        Response.Redirect("Default.aspx?Page=Meetings")
    End Sub

    Private Sub NoM_Click(sender As Object, e As EventArgs) Handles NoM.Click
        Response.Redirect("Default.aspx?Page=Meetings")
    End Sub
End Class