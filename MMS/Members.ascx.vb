Imports System.Globalization

Public Class Members
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TMP1 As String = ""
        Dim TMP2 As String = ""
        Dim TMP3 As String = ""
        Dim MC, PC, AC As Integer
        Dim Radif As Integer = 0
        TMP1 = "<table class='view-tbl'><tr class='view-header'><td class='view-td'>ردیف</td><td class='view-td'>نام و نام خانوادگی</td><td class='view-td'>تلفن</td><td class='view-td'>موبایل</td><td class='view-td'>جلسات</td><td class='view-td'>حضور</td><td class='view-td'>غیاب</td><td class='view-td'>عملیات</td></tr>"
        Try
            DBConn = New DBConnection
            DBConn.SQL("SELECT * FROM Members")
            DBConn.SQLComm.Connection = DBConn.SQLConn
            Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
            Do While d.Read
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT COUNT(*) FROM MeetingMembers WHERE MeID=" & d("MeID".ToString))
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d1 As Integer = DBConn.SQLComm.ExecuteScalar
                    MC = d1
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT COUNT(*) FROM MeetingMembers WHERE MeID=" & d("MeID".ToString) & " AND MePresent=1")
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d2 As Integer = DBConn.SQLComm.ExecuteScalar
                    PC = d2
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT COUNT(*) FROM MeetingMembers WHERE MeID=" & d("MeID".ToString) & " AND MePresent=0")
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d3 As Integer = DBConn.SQLComm.ExecuteScalar
                    AC = d3
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
                Radif += 1
                TMP2 &= "<tr>" + _
                "<td class='view-td'>" & Radif & "</td>" + _
                "<td class='view-td'>" & d("MeName".ToString) & "</td>" + _
                "<td class='view-td'>" & d("MTel".ToString) & "</td>" + _
                "<td class='view-td'>" & d("MMobile".ToString) & "</td>" + _
                "<td class='view-td'>" & MC & "</td>" + _
                "<td class='view-td'>" & PC & "</td>" + _
                "<td class='view-td'>" & AC & "</td>" + _
                "<td class='view-td'><a href='/Default.aspx?Page=Members&Event=Delete&ID=" & d("MeID".ToString) & "'><img title='حذف جلسه' src='/images/delete.png' /></a></td></tr>"
            Loop
            DBConn.SQLConn.Close()
        Catch err As System.Exception
        End Try
        If TMP2 = "" Then
            TMP3 = "</table><p style='width: 100%;text-align: center; color: #000000;'>هیچ موردی یافت نشد.</p>"
        Else
            TMP3 = "</table>"
        End If
        MeMa.InnerHtml = TMP1 & TMP2 & TMP3
    End Sub

End Class