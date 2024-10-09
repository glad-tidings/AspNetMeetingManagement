Public Class Rollcalls
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MTitle.Items.Add("لطفا جلسه را انتخاب کنید")
            MIndex.Items.Add("")
            Try
                DBConn = New DBConnection
                DBConn.SQL("SELECT * FROM Meetings")
                DBConn.SQLComm.Connection = DBConn.SQLConn
                Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                Do While d.Read
                    MTitle.Items.Add(d("MTitle".ToString))
                    MIndex.Items.Add(d("MID".ToString))
                Loop
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
            MTitle.SelectedIndex = 0
        End If
    End Sub

    Private Sub MTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MTitle.SelectedIndexChanged
        MembersList.Items.Clear()
        MembersListID.Items.Clear()
        Try
            DBConn = New DBConnection
            DBConn.SQL("SELECT * FROM MeetingMembers WHERE MID=" & MIndex.Items.Item(MTitle.SelectedIndex).Text)
            DBConn.SQLComm.Connection = DBConn.SQLConn
            Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
            Do While d.Read
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT * FROM Members WHERE MeID=" & d("MeID".ToString))
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d1 As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                    Do While d1.Read
                        MembersList.Items.Add(d1("MeName".ToString))
                    Loop
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
                MembersListID.Items.Add(d("MeID".ToString))
            Loop
            DBConn.SQLConn.Close()
        Catch err As System.Exception
        End Try
    End Sub

    Private Sub SetRollCalls_Click(sender As Object, e As EventArgs) Handles SetRollCalls.Click
        lblError.InnerHtml = ""
        If MTitle.SelectedIndex = 0 Then lblError.InnerHtml &= "<ul><li>لطفا جلسه را انتخاب کنید.</li></ul>"
        If lblError.InnerHtml <> "" Then Exit Sub
        For I As Integer = 0 To MembersListID.Items.Count - 1
            Try
                DBConn = New DBConnection
                DBConn.SQL("Update MeetingMembers SET MePresent='" & MembersList.Items.Item(I).Selected & "' WHERE MID = '" & MIndex.Items.Item(MTitle.SelectedIndex).Text & "' AND MeID = '" & MembersListID.Items.Item(I).Text & "';")
                DBConn.SQLComm.Connection = DBConn.SQLConn
                DBConn.SQLComm.ExecuteNonQuery()
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
        Next
        Try
            DBConn = New DBConnection
            DBConn.SQL("Update Meetings SET MDo='1' WHERE MID = '" & MIndex.Items.Item(MTitle.SelectedIndex).Text & "';")
            DBConn.SQLComm.Connection = DBConn.SQLConn
            DBConn.SQLComm.ExecuteNonQuery()
            DBConn.SQLConn.Close()
        Catch err As System.Exception
        End Try
        Response.Redirect("Default.aspx?Page=Meetings")
    End Sub
End Class