Imports System.Globalization

Module Tools

    Dim DBConn As DBConnection

    Public Function Persian_2_Gregorian(ByVal PersianDate As String) As DateTime
        Dim PDate As DateTime = Convert.ToDateTime(PersianDate)
        Dim GCalendar As GregorianCalendar = New GregorianCalendar
        Dim PCalendar As PersianCalendar = New PersianCalendar
        Dim EDate As DateTime = PCalendar.ToDateTime(GCalendar.GetYear(PDate), GCalendar.GetMonth(PDate), GCalendar.GetDayOfMonth(PDate), GCalendar.GetHour(PDate), GCalendar.GetMinute(PDate), GCalendar.GetSecond(PDate), 0)
        Return EDate
    End Function

    Public Function Gregorian_2_Persian(ByVal GregorianDate As String) As DateTime
        Dim GDate As DateTime = Convert.ToDateTime(GregorianDate)
        Dim PCalendar As PersianCalendar = New PersianCalendar
        Dim EDate As DateTime = New DateTime(PCalendar.GetYear(GDate), PCalendar.GetMonth(GDate), PCalendar.GetDayOfMonth(GDate), PCalendar.GetHour(GDate), PCalendar.GetMinute(GDate), PCalendar.GetSecond(GDate), 0)
        Return EDate
    End Function

    Public Function EnDay2FaDate(ByVal EnDay As String) As String
        Dim Temp As String = ""
        Select Case EnDay
            Case "Saturday"
                Temp = "شنبه"
            Case "Sunday"
                Temp = "یک شنبه"
            Case "Monday"
                Temp = "دو شنبه"
            Case "Tuesday"
                Temp = "سه شنبه"
            Case "Wednesday"
                Temp = "چهار شنبه"
            Case "Thursday"
                Temp = "پنج شنبه"
            Case "Friday"
                Temp = "جمعه"
        End Select
        Return Temp
    End Function

    Public Function IntMonth2FaMonth(ByVal EnDay As Integer) As String
        Dim Temp As String = ""
        Select Case EnDay
            Case 1
                Temp = "فروردین"
            Case 2
                Temp = "اردیبهشت"
            Case 3
                Temp = "خرداد"
            Case 4
                Temp = "تیر"
            Case 5
                Temp = "مرداد"
            Case 6
                Temp = "شهریور"
            Case 7
                Temp = "مهر"
            Case 8
                Temp = "آبان"
            Case 9
                Temp = "آذر"
            Case 10
                Temp = "دی"
            Case 11
                Temp = "بهمن"
            Case 12
                Temp = "اسفند"
        End Select
        Return Temp
    End Function

    Public Function GSIndex(ByVal FieldName As String) As Integer
        Dim TMP As Integer = 0
        Try
            DBConn = New DBConnection
            DBConn.SQL("SELECT * FROM IndexList WHERE IndexID=1")
            DBConn.SQLComm.Connection = DBConn.SQLConn
            Dim d As SqlClient.SqlDataReader = DBConn.SQLComm.ExecuteReader()
            Do While d.Read
                TMP = d(FieldName.ToString)
            Loop
            DBConn.SQLConn.Close()
        Catch err As System.Exception
        End Try
        If TMP <> 0 Then
            Try
                DBConn = New DBConnection
                DBConn.SQL("Update IndexList SET " & FieldName & "=" & (TMP + 1) & " WHERE IndexID=1")
                DBConn.SQLComm.Connection = DBConn.SQLConn
                DBConn.SQLComm.ExecuteNonQuery()
                DBConn.SQLConn.Close()
            Catch err As System.Exception
            End Try
        End If
        Return TMP
    End Function

End Module
