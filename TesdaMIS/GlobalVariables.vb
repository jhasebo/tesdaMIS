Imports System.Data
Imports System.Data.OleDb
Module GlobalVariables
    Public systemconstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath().ToString & "\SystemDB.xlsx" & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'"
    Public sourceDBfilepath As String = ""
    Public activeuser As String
    Public reportmonth As Integer
    Public reportyear As Integer
    Public conn As New OleDbConnection(systemconstring)
    Public cmd As OleDbCommand = conn.CreateCommand()
    Sub connect()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
    End Sub
    Sub disconnect()
        conn.Close()
    End Sub
    Sub insert()

    End Sub
    Sub update()

    End Sub
    Sub delete()

    End Sub
End Module
