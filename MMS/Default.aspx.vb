Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QSTR As String = Request.QueryString("Page")
        Dim QSTRE As String = Request.QueryString("Event")
        Select Case QSTR
            Case "AddMeeting"
                MainP.Controls.Add(LoadControl("/AddMeeting.ascx"))
            Case "Members"
                Select Case QSTRE
                    Case "Delete"
                        MainP.Controls.Add(LoadControl("/DeleteMember.ascx"))
                    Case Else
                        MainP.Controls.Add(LoadControl("/Members.ascx"))
                End Select
            Case "AddMember"
                MainP.Controls.Add(LoadControl("/AddMember.ascx"))
            Case "Rollcalls"
                MainP.Controls.Add(LoadControl("/Rollcalls.ascx"))
            Case Else
                Select Case QSTRE
                    Case "Edit"
                        MainP.Controls.Add(LoadControl("/EditMeeting.ascx"))
                    Case "Delete"
                        MainP.Controls.Add(LoadControl("/DeleteMeeting.ascx"))
                    Case "View"
                        MainP.Controls.Add(LoadControl("/ViewMeeting.ascx"))
                    Case Else
                        MainP.Controls.Add(LoadControl("/Meetings.ascx"))
                End Select
        End Select
    End Sub

End Class