Public Class EditMeeting
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QSTRI As String = Request.QueryString("ID")
        If IsNumeric(QSTRI) Then
            If Not IsPostBack Then
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT * FROM Meetings WHERE MID=" & QSTRI)
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                    Do While d.Read
                        MTitle.Value = d("MTitle".ToString)
                        MDateD.Value = Format(d("MDate".ToString), "dd")
                        MDateM.Value = Format(d("MDate".ToString), "MM")
                        MDateY.Value = Format(d("MDate".ToString), "yyyy")
                        MTimeM.Value = Format(d("MDate".ToString), "mm")
                        MTimeH.Value = Format(d("MDate".ToString), "hh")
                    Loop
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT * FROM Members")
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d1 As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                    Do While d1.Read
                        MembersList.Items.Add(d1("MeName".ToString))
                        MembersListID.Items.Add(d1("MeID".ToString))
                    Loop
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
            End If
        End If
    End Sub

    Private Sub AddMeeting_Click(sender As Object, e As EventArgs) Handles AddMeeting.Click
        Dim QSTRI As String = Request.QueryString("ID")
        Dim TMP As String
        lblError.InnerHtml = ""
        If MTitle.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا عنوان را وارد کنید.</li></ul>"
        If MDateD.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا تاریخ برگزاری را وارد کنید.</li></ul>"
        If MDateM.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا تاریخ برگزاری را وارد کنید.</li></ul>"
        If MDateY.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا تاریخ برگزاری را وارد کنید.</li></ul>"
        If MTimeM.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا ساعت برگزاری را وارد کنید.</li></ul>"
        If MTimeH.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا ساعت برگزاری را وارد کنید.</li></ul>"
        If lblError.InnerHtml <> "" Then Exit Sub
        TMP = New DateTime(MDateY.Value, MDateM.Value, MDateD.Value, MTimeH.Value, MTimeM.Value, 0)
        Try
            DBConn = New DBConnection
            DBConn.SQL("Update Meetings Set MTitle=N'" & MTitle.Value & "',MDate='" & Persian_2_Gregorian(TMP) & "',MDo='0' WHERE MID=" & QSTRI)
            DBConn.SQLComm.Connection = DBConn.SQLConn
            DBConn.SQLComm.ExecuteNonQuery()
            DBConn.SQLConn.Close()
        Catch err As System.Exception
            lblError.InnerHtml &= "<ul><li>خطا در ویرایش جلسه.</li></ul>"
            Exit Sub
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
        For I As Integer = 0 To MembersList.Items.Count - 1
            If MembersList.Items.Item(I).Selected = True Then
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("Insert Into MeetingMembers (MID,MeID,MePresent) Values (" & QSTRI & "," & MembersListID.Items.Item(I).Text & ",'0')")
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    DBConn.SQLComm.ExecuteNonQuery()
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                    lblError.InnerHtml &= "<ul><li>خطا در ویرایش جلسه.</li></ul>"
                    Exit Sub
                End Try
            End If
        Next
        Response.Redirect("Default.aspx?Page=Meetings")
    End Sub
End Class