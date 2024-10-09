Imports System.Globalization

Public Class Meetings
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TMP1 As String = ""
        Dim TMP2 As String = ""
        Dim TMP3 As String = ""
        Dim MC, PC, AC As String
        Dim Radif As Integer = 0
        TMP1 = "<table class='view-tbl'><tr class='view-header'><td class='view-td'>ردیف</td><td class='view-td'>عنوان</td><td class='view-td'>تاریخ و ساعت</td><td class='view-td'>مدعوین</td><td class='view-td'>حاضرین</td><td class='view-td'>غایبین</td><td class='view-td'>عملیات</td></tr>"
        Try
            DBConn = New DBConnection
            DBConn.SQL("SELECT * FROM Meetings")
            DBConn.SQLComm.Connection = DBConn.SQLConn
            Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
            Do While d.Read
                Try
                    DBConn = New DBConnection
                    DBConn.SQL("SELECT COUNT(*) FROM MeetingMembers WHERE MID=" & d("MID".ToString))
                    DBConn.SQLComm.Connection = DBConn.SQLConn
                    Dim d1 As Integer = DBConn.SQLComm.ExecuteScalar
                    MC = d1
                    DBConn.SQLConn.Close()
                Catch err As System.Exception
                End Try
                If d("MDo".ToString) = True Then
                    Try
                        DBConn = New DBConnection
                        DBConn.SQL("SELECT COUNT(*) FROM MeetingMembers WHERE MID=" & d("MID".ToString) & " AND MePresent=1")
                        DBConn.SQLComm.Connection = DBConn.SQLConn
                        Dim d2 As Integer = DBConn.SQLComm.ExecuteScalar
                        PC = d2
                        DBConn.SQLConn.Close()
                    Catch err As System.Exception
                    End Try
                    Try
                        DBConn = New DBConnection
                        DBConn.SQL("SELECT COUNT(*) FROM MeetingMembers WHERE MID=" & d("MID".ToString) & " AND MePresent=0")
                        DBConn.SQLComm.Connection = DBConn.SQLConn
                        Dim d3 As Integer = DBConn.SQLComm.ExecuteScalar
                        AC = d3
                        DBConn.SQLConn.Close()
                    Catch err As System.Exception
                    End Try
                Else
                    PC = "برگزار نشده"
                    AC = "برگزار نشده"
                End If
                Radif += 1
                TMP2 &= "<tr>" + _
                "<td class='view-td'>" & Radif & "</td>" + _
                "<td class='view-td'>" & d("MTitle".ToString) & "</td>" + _
                "<td class='view-td'>" & Shamsi(d("MDate".ToString)) & "</td>" + _
                "<td class='view-td'>" & MC & "</td>" + _
                "<td class='view-td'>" & PC & "</td>" + _
                "<td class='view-td'>" & AC & "</td>" + _
                "<td class='view-td'><a href='/Default.aspx?Page=Meetings&Event=View&ID=" & d("MID".ToString) & "'><img title='مشاهده جلسه' src='/images/view.png' /></a><a href='/Default.aspx?Page=Meetings&Event=Edit&ID=" & d("MID".ToString) & "'><img title='ویرایش جلسه' src='/images/edit.png' /></a><a href='/Default.aspx?Page=Meetings&Event=Delete&ID=" & d("MID".ToString) & "'><img title='حذف جلسه' src='/images/delete.png' /></a></td></tr>"
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

    Private Function Shamsi(ByVal GeoDate As DateTime) As String
        Dim PCT As New PersianCalendar
        Dim DTN As DateTime = GeoDate
        Return PCT.GetYear(DTN).ToString & "/" & Format(PCT.GetMonth(DTN), "00") & "/" & Format(PCT.GetDayOfMonth(DTN), "00") & " - " & Format(PCT.GetHour(DTN), "00") & ":" & Format(PCT.GetMinute(DTN), "00")
    End Function

End Class