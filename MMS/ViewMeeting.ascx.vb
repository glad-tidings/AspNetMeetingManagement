Imports System.Globalization

Public Class ViewMeeting
    Inherits System.Web.UI.UserControl

    Dim DBConn As DBConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QSTRI As String = Request.QueryString("ID")
        If IsNumeric(QSTRI) Then
            Try
                DBConn = New DBConnection
                DBConn.SQL("SELECT * FROM Meetings WHERE MID=" & QSTRI)
                DBConn.SQLComm.Connection = DBConn.SQLConn
                Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                Do While d.Read
                    MTitle.InnerText = d("MTitle".ToString)
                    MDate.InnerText = Shamsi(d("MDate".ToString))
                    MDo.InnerText = IIf(d("MDo".ToString), "برگزار شده", "برگزار نشده")
                Loop
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
            Memb.InnerHtml = "<span>مدعوین شرکت کننده در این جلسه :</span><ul>"
            Try
                DBConn = New DBConnection
                DBConn.SQL("SELECT * FROM MeetingMembers WHERE MID=" & QSTRI)
                DBConn.SQLComm.Connection = DBConn.SQLConn
                Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                Do While d.Read
                    Try
                        DBConn = New DBConnection
                        DBConn.SQL("SELECT * FROM Members WHERE MeID=" & d("MeID".ToString))
                        DBConn.SQLComm.Connection = DBConn.SQLConn
                        Dim d1 As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                        Do While d1.Read
                            Memb.InnerHtml &= "<li>" & d1("MeName".ToString) & "</li>"
                        Loop
                        DBConn.SQLConn.Close()
                    Catch err As System.Exception
                    End Try
                Loop
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
            Memb.InnerHtml &= "</ul>"
            PMemb.InnerHtml = "<span>حاضرین :</span><ul>"
            Try
                DBConn = New DBConnection
                DBConn.SQL("SELECT * FROM MeetingMembers WHERE MID=" & QSTRI & " AND MePresent=1")
                DBConn.SQLComm.Connection = DBConn.SQLConn
                Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                Do While d.Read
                    Try
                        DBConn = New DBConnection
                        DBConn.SQL("SELECT * FROM Members WHERE MeID=" & d("MeID".ToString))
                        DBConn.SQLComm.Connection = DBConn.SQLConn
                        Dim d1 As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                        Do While d1.Read
                            PMemb.InnerHtml &= "<li>" & d1("MeName".ToString) & "</li>"
                        Loop
                        DBConn.SQLConn.Close()
                    Catch err As System.Exception
                    End Try
                Loop
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
            PMemb.InnerHtml &= "</ul>"
            UMemb.InnerHtml = "<span>غایبین :</span><ul>"
            Try
                DBConn = New DBConnection
                DBConn.SQL("SELECT * FROM MeetingMembers WHERE MID=" & QSTRI & " AND MePresent=0")
                DBConn.SQLComm.Connection = DBConn.SQLConn
                Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                Do While d.Read
                    Try
                        DBConn = New DBConnection
                        DBConn.SQL("SELECT * FROM Members WHERE MeID=" & d("MeID".ToString))
                        DBConn.SQLComm.Connection = DBConn.SQLConn
                        Dim d1 As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
                        Do While d1.Read
                            UMemb.InnerHtml &= "<li>" & d1("MeName".ToString) & "</li>"
                        Loop
                        DBConn.SQLConn.Close()
                    Catch err As System.Exception
                    End Try
                Loop
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
            UMemb.InnerHtml &= "</ul>"
        End If
    End Sub

    Private Function Shamsi(ByVal GeoDate As DateTime) As String
        Dim PCT As New PersianCalendar
        Dim DTN As DateTime = GeoDate
        Return EnDay2FaDate(PCT.GetDayOfWeek(DTN)) & " " & PCT.GetDayOfMonth(DTN).ToString & " " & IntMonth2FaMonth(PCT.GetMonth(DTN)) & " سال " & PCT.GetYear(DTN).ToString
    End Function

End Class