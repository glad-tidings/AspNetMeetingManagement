Public Class AddMember
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub AddMember_Click(sender As Object, e As EventArgs) Handles AddMember.Click
        lblError.InnerHtml = ""
        If MeName.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا نام و نام خانوادگی را وارد کنید.</li></ul>"
        If MeTel.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا تلفن تماس را وارد کنید.</li></ul>"
        If MeMobile.Value = "" Then lblError.InnerHtml &= "<ul><li>لطفا موبایل را وارد کنید.</li></ul>"
        If lblError.InnerHtml <> "" Then Exit Sub
        Try
            DBConn = New DBConnection
            DBConn.SQL("Insert Into Members (MeID,MeName,MTel,MMobile) Values (" & GSIndex("MeID") & ",N'" & MeName.Value & "','" & MeTel.Value & "','" & MeMobile.Value & "')")
            DBConn.SQLComm.Connection = DBConn.SQLConn
            DBConn.SQLComm.ExecuteNonQuery()
            DBConn.SQLConn.Close()
        Catch err As System.Exception
            lblError.InnerHtml &= "<ul><li>خطا در افزودن عضو.</li></ul>"
            Exit Sub
        End Try
        Response.Redirect("Default.aspx?Page=Members")
    End Sub
End Class