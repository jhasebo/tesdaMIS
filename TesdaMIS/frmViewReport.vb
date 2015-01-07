Imports System.Data
Imports System.Data.OleDb
Imports System.Threading
Imports Microsoft.Office.Interop
Public Class frmViewReport
    Dim cn As OleDbConnection
    Private Sub frmViewReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sourceDBfilepath <> String.Empty Then
            If DataGridView1.Columns.Count > 0 Then
                While DataGridView1.Columns.Count > 0
                    DataGridView1.Columns.RemoveAt(DataGridView1.Columns.Count - 1)
                End While
            End If
            lbActiveRecords.Items.Clear()
            cn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter("SELECT * FROM [Template$]", conn)
            Dim cb As New OleDbCommandBuilder(da)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Columns(0).Frozen = True
            DataGridView1.Columns(1).Frozen = True
            DataGridView1.Columns(2).Frozen = True
            DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        Else
            MsgBox("Please upload a valid excel database file.", MsgBoxStyle.OkOnly, "Unable to Open Reports")
            Me.Close()
        End If
    End Sub

    Private Sub cbReportCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbReportCategory.SelectedIndexChanged
        If cbReportCategory.Text <> String.Empty Then
            GroupBox2.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
        If DataGridView1.Columns.Count > 0 Then
            While DataGridView1.Columns.Count > 0
                DataGridView1.Columns.RemoveAt(DataGridView1.Columns.Count - 1)
            End While
        End If
        If lbActiveRecords.Items.Count > 0 Then
            lbActiveRecords.Items.Clear()
        End If
        cn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
        Dim dsn As New DataSet
        Dim dan As New OleDbDataAdapter("SELECT * FROM [Template$]", conn)
        Dim cbn As New OleDbCommandBuilder(dan)
        dan.Fill(dsn)
        DataGridView1.DataSource = dsn.Tables(0)
        With DataGridView1
            .Columns("No").DisplayIndex = 0
            .Columns("QualificationTitle").DisplayIndex = 1
            .Columns("PTQFLevel").DisplayIndex = 2
        End With
        DataGridView1.Columns(0).Frozen = True
        DataGridView1.Columns(1).Frozen = True
        DataGridView1.Columns(2).Frozen = True
        DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        If cbReportCategory.Text = "per TVI" Then
            cbSelectRecord.Items.Clear()
            If sourceDBfilepath <> String.Empty Then
                Dim dsv As New DataSet
                Dim da As New OleDbDataAdapter("SELECT DISTINCT ProviderName FROM [MISdb$]", cn)
                Dim cb As New OleDbCommandBuilder(da)
                da.Fill(dsv)
                Dim i As Integer = 0
                While i < dsv.Tables(0).Rows.Count
                    cbSelectRecord.Items.Add(dsv.Tables(0).Rows(i).Item(0))
                    i += 1
                End While
            End If
        ElseIf cbReportCategory.Text = "per Educational Attainment" Then
            cbSelectRecord.Items.Clear()
            cbSelectRecord.Items.Add("No Grade Completed")
            cbSelectRecord.Items.Add("Elementary Level")
            cbSelectRecord.Items.Add("Elementary Graduate")
            cbSelectRecord.Items.Add("High School Level")
            cbSelectRecord.Items.Add("High School Graduate")
            cbSelectRecord.Items.Add("Post Secondary Level (TVET)")
            cbSelectRecord.Items.Add("Post Secondary Graduate (TVET)")
            cbSelectRecord.Items.Add("College Level")
            cbSelectRecord.Items.Add("College Graduate/Higher")
            cbSelectRecord.Items.Add("TVET Graduate")
        ElseIf cbReportCategory.Text = "per Age Group" Then
            cbSelectRecord.Items.Clear()
            cbSelectRecord.Items.Add("15-17")
            cbSelectRecord.Items.Add("18-24")
            cbSelectRecord.Items.Add("25-34")
            cbSelectRecord.Items.Add("35-44")
            cbSelectRecord.Items.Add("45-54")
            cbSelectRecord.Items.Add("55-64")
            cbSelectRecord.Items.Add("65 Years and Older")
        End If
    End Sub

    Private Sub btnSelectRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectRecord.Click
        If cbReportCategory.Text = "per TVI" Then
            Dim flag As Boolean = False
            For Each Item In lbActiveRecords.Items
                If Item = cbSelectRecord.Text Then
                    flag = True
                End If
            Next Item
            If flag = False Then
                If cbSelectRecord.Text <> String.Empty Then
                    lbActiveRecords.Items.Add(cbSelectRecord.Text)
                    Dim dc As New DataGridViewTextBoxColumn
                    Dim dc2 As New DataGridViewTextBoxColumn
                    Dim dc3 As New DataGridViewTextBoxColumn
                    Dim dc4 As New DataGridViewTextBoxColumn
                    dc.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    dc2.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    dc3.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    dc4.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    DataGridView1.Columns.Add(dc)
                    DataGridView1.Columns.Add(dc2)
                    DataGridView1.Columns.Add(dc3)
                    DataGridView1.Columns.Add(dc4)
                    Dim workingindex As New Integer
                    workingindex = (((lbActiveRecords.Items.Count * 4) - 3) + 3) - 1
                    DataGridView1.Rows(0).Cells(workingindex).Value = "ENROLLED"
                    DataGridView1.Rows(0).Cells(workingindex + 2).Value = "GRADUATES"
                    DataGridView1.Rows(1).Cells(workingindex).Value = "M"
                    DataGridView1.Rows(1).Cells(workingindex + 2).Value = "M"
                    DataGridView1.Rows(1).Cells(workingindex + 1).Value = "F"
                    DataGridView1.Rows(1).Cells(workingindex + 3).Value = "F"
                    Dim record As String = cbSelectRecord.Text
                    If sourceDBfilepath <> String.Empty Then
                        Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
                        Dim command As OleDbCommand = connection.CreateCommand()
                        connection.Open()
                        Dim row As Integer = 2
                        While row < DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(row).Cells(2) Is Nothing Then
                                Thread.Sleep(1000)
                            End If
                            command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (ProviderName='" & record & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                            'Dim i As Integer = command.ExecuteScalar
                            'If i > 0 Then
                            DataGridView1.Rows(row).Cells(workingindex).Value = command.ExecuteScalar.ToString
                            'End If

                            row += 1
                        End While
                    Else
                        MsgBox("sourceDB is empty!")
                    End If
                    'Dim thread1 As New System.Threading.Thread(Sub() Me.col1ptviProc(workingindex, record))
                    Dim thread2 As New System.Threading.Thread(Sub() Me.col2ptviProc(workingindex + 1, record))
                    Dim thread3 As New System.Threading.Thread(Sub() Me.col3ptviProc(workingindex + 2, record))
                    Dim thread4 As New System.Threading.Thread(Sub() Me.col4ptviProc(workingindex + 3, record))
                    'thread1.Start()
                    thread2.Start()
                    thread3.Start()
                    thread4.Start()
                End If
            Else
                MsgBox("Record already active!")
            End If
        ElseIf cbReportCategory.Text = "per Educational Attainment" Then
            Dim flag As Boolean = False
            For Each Item In lbActiveRecords.Items
                If Item = cbSelectRecord.Text Then
                    flag = True
                End If
            Next Item
            If flag = False Then
                If cbSelectRecord.Text <> String.Empty Then
                    lbActiveRecords.Items.Add(cbSelectRecord.Text)
                    Dim dc As New DataGridViewTextBoxColumn
                    Dim dc2 As New DataGridViewTextBoxColumn
                    Dim dc3 As New DataGridViewTextBoxColumn
                    Dim dc4 As New DataGridViewTextBoxColumn
                    dc.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    dc2.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    dc3.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    dc4.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                    DataGridView1.Columns.Add(dc)
                    DataGridView1.Columns.Add(dc2)
                    DataGridView1.Columns.Add(dc3)
                    DataGridView1.Columns.Add(dc4)
                    Dim workingindex As New Integer
                    workingindex = (((lbActiveRecords.Items.Count * 4) - 3) + 3) - 1
                    DataGridView1.Rows(0).Cells(workingindex).Value = "ENROLLED"
                    DataGridView1.Rows(0).Cells(workingindex + 2).Value = "GRADUATES"
                    DataGridView1.Rows(1).Cells(workingindex).Value = "M"
                    DataGridView1.Rows(1).Cells(workingindex + 2).Value = "M"
                    DataGridView1.Rows(1).Cells(workingindex + 1).Value = "F"
                    DataGridView1.Rows(1).Cells(workingindex + 3).Value = "F"
                    Dim record As String = cbSelectRecord.Text
                    If sourceDBfilepath <> String.Empty Then
                        Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
                        Dim command As OleDbCommand = connection.CreateCommand()
                        connection.Open()
                        Dim row As Integer = 2
                        While row < DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(row).Cells(2) Is Nothing Then
                                Thread.Sleep(1000)
                            End If
                            command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (HighestEducationalAttainment='" & record & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                            'Dim i As Integer = command.ExecuteScalar
                            'If i > 0 Then
                            DataGridView1.Rows(row).Cells(workingindex).Value = command.ExecuteScalar.ToString
                            'End If

                            row += 1
                        End While
                    Else
                        MsgBox("sourceDB is empty!")
                    End If
                    'Dim thread1 As New System.Threading.Thread(Sub() Me.col1ptviProc(workingindex, record))
                    Dim thread2 As New System.Threading.Thread(Sub() Me.col2pheaProc(workingindex + 1, record))
                    Dim thread3 As New System.Threading.Thread(Sub() Me.col3pheaProc(workingindex + 2, record))
                    Dim thread4 As New System.Threading.Thread(Sub() Me.col4pheaProc(workingindex + 3, record))
                    'thread1.Start()
                    thread2.Start()
                    thread3.Start()
                    thread4.Start()
                End If
            Else
                MsgBox("Record already active!")
            End If
        ElseIf cbReportCategory.Text = "per Age Group" Then
            If cbSelectRecord.Text = "65 Years and Over" Then
                Dim flag As Boolean = False
                For Each Item In lbActiveRecords.Items
                    If Item = cbSelectRecord.Text Then
                        flag = True
                    End If
                Next Item
                If flag = False Then
                    If cbSelectRecord.Text <> String.Empty Then
                        lbActiveRecords.Items.Add(cbSelectRecord.Text)
                        Dim dc As New DataGridViewTextBoxColumn
                        Dim dc2 As New DataGridViewTextBoxColumn
                        Dim dc3 As New DataGridViewTextBoxColumn
                        Dim dc4 As New DataGridViewTextBoxColumn
                        dc.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        dc2.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        dc3.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        dc4.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        DataGridView1.Columns.Add(dc)
                        DataGridView1.Columns.Add(dc2)
                        DataGridView1.Columns.Add(dc3)
                        DataGridView1.Columns.Add(dc4)
                        Dim workingindex As New Integer
                        workingindex = (((lbActiveRecords.Items.Count * 4) - 3) + 3) - 1
                        DataGridView1.Rows(0).Cells(workingindex).Value = "ENROLLED"
                        DataGridView1.Rows(0).Cells(workingindex + 2).Value = "GRADUATES"
                        DataGridView1.Rows(1).Cells(workingindex).Value = "M"
                        DataGridView1.Rows(1).Cells(workingindex + 2).Value = "M"
                        DataGridView1.Rows(1).Cells(workingindex + 1).Value = "F"
                        DataGridView1.Rows(1).Cells(workingindex + 3).Value = "F"
                        Dim record As String = "64"
                        If sourceDBfilepath <> String.Empty Then
                            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
                            Dim command As OleDbCommand = connection.CreateCommand()
                            connection.Open()
                            Dim row As Integer = 2
                            While row < DataGridView1.Rows.Count - 1
                                If DataGridView1.Rows(row).Cells(2) Is Nothing Then
                                    Thread.Sleep(1000)
                                End If
                                command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (Age > '" & record & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                                'Dim i As Integer = command.ExecuteScalar
                                'If i > 0 Then
                                DataGridView1.Rows(row).Cells(workingindex).Value = command.ExecuteScalar.ToString
                                'End If

                                row += 1
                            End While
                        Else
                            MsgBox("sourceDB is empty!")
                        End If
                        'Dim thread1 As New System.Threading.Thread(Sub() Me.col1ptviProc(workingindex, record))
                        Dim thread2 As New System.Threading.Thread(Sub() Me.col2pheaProc(workingindex + 1, record))
                        Dim thread3 As New System.Threading.Thread(Sub() Me.col3pheaProc(workingindex + 2, record))
                        Dim thread4 As New System.Threading.Thread(Sub() Me.col4pheaProc(workingindex + 3, record))
                        'thread1.Start()
                        thread2.Start()
                        thread3.Start()
                        thread4.Start()
                    End If
                Else
                    MsgBox("Record already active!")
                End If
            Else
                Dim flag As Boolean = False
                For Each Item In lbActiveRecords.Items
                    If Item = cbSelectRecord.Text Then
                        flag = True
                    End If
                Next Item
                If flag = False Then
                    If cbSelectRecord.Text <> String.Empty Then
                        lbActiveRecords.Items.Add(cbSelectRecord.Text)
                        Dim dc As New DataGridViewTextBoxColumn
                        Dim dc2 As New DataGridViewTextBoxColumn
                        Dim dc3 As New DataGridViewTextBoxColumn
                        Dim dc4 As New DataGridViewTextBoxColumn
                        dc.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        dc2.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        dc3.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        dc4.HeaderText = lbActiveRecords.Items(lbActiveRecords.Items.Count - 1)
                        DataGridView1.Columns.Add(dc)
                        DataGridView1.Columns.Add(dc2)
                        DataGridView1.Columns.Add(dc3)
                        DataGridView1.Columns.Add(dc4)
                        Dim workingindex As New Integer
                        workingindex = (((lbActiveRecords.Items.Count * 4) - 3) + 3) - 1
                        DataGridView1.Rows(0).Cells(workingindex).Value = "ENROLLED"
                        DataGridView1.Rows(0).Cells(workingindex + 2).Value = "GRADUATES"
                        DataGridView1.Rows(1).Cells(workingindex).Value = "M"
                        DataGridView1.Rows(1).Cells(workingindex + 2).Value = "M"
                        DataGridView1.Rows(1).Cells(workingindex + 1).Value = "F"
                        DataGridView1.Rows(1).Cells(workingindex + 3).Value = "F"
                        Dim record() As String = cbSelectRecord.Text.Split("-")
                        If sourceDBfilepath <> String.Empty Then
                            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
                            Dim command As OleDbCommand = connection.CreateCommand()
                            connection.Open()
                            Dim row As Integer = 2
                            While row < DataGridView1.Rows.Count - 1
                                If DataGridView1.Rows(row).Cells(2) Is Nothing Then
                                    Thread.Sleep(1000)
                                End If
                                command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE ((Cint(Age) BETWEEN " & record(0) & " AND " & record(1) & ") AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                                'Dim i As Integer = command.ExecuteScalar
                                'If i > 0 Then
                                DataGridView1.Rows(row).Cells(workingindex).Value = command.ExecuteScalar.ToString
                                'End If

                                row += 1
                            End While
                        Else
                            MsgBox("sourceDB is empty!")
                        End If
                        'Dim thread1 As New System.Threading.Thread(Sub() Me.col1ptviProc(workingindex, record))
                        Dim thread2 As New System.Threading.Thread(Sub() Me.col2pagregProc(workingindex + 1, record(0), record(1)))
                        Dim thread3 As New System.Threading.Thread(Sub() Me.col3pagregProc(workingindex + 2, record(0), record(1)))
                        Dim thread4 As New System.Threading.Thread(Sub() Me.col4pagregProc(workingindex + 3, record(0), record(1)))
                        'thread1.Start()
                        thread2.Start()
                        thread3.Start()
                        thread4.Start()
                    End If
                Else
                    MsgBox("Record already active!")
                End If
            End If
        Else
            MsgBox("Plese select a report category.")
        End If
       

    End Sub


    'For TVI View
    'Public Sub col1ptviProc(ByVal index As Integer, ByVal tvi As String)
    '    If sourceDBfilepath <> String.Empty Then
    '        Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
    '        Dim command As OleDbCommand = connection.CreateCommand()
    '        connection.Open()
    '        Dim row As Integer = 2
    '        While row < DataGridView1.Rows.Count - 1
    '            If DataGridView1.Rows(row).Cells(2) Is Nothing Then
    '                Thread.Sleep(1000)
    '            End If
    '            command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (ProviderName='" & tvi & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "')"

    '            DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
    '            'Catch ex As Exception
    '            'MsgBox(ex.ToString)
    '            'End Try
    '            row += 1
    '        End While
    '        connection.Close()
    '    Else
    '        MsgBox("sourceDB is empty!")
    '    End If
    'End Sub

    Public Sub col2ptviProc(ByVal index As Integer, ByVal tvi As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                'Try
                command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (ProviderName='" & tvi & "' AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                'Dim i As Integer = command.ExecuteScalar
                'If i > 0 Then
                DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                'End If

                'Catch ex As Exception
                'End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col3ptviProc(ByVal index As Integer, ByVal tvi As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (ProviderName='" & tvi & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col4ptviProc(ByVal index As Integer, ByVal tvi As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (ProviderName='" & tvi & "' AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col2pheaProc(ByVal index As Integer, ByVal hea As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                'Try
                command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (HighestEducationalAttainment='" & hea & "' AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                'Dim i As Integer = command.ExecuteScalar
                'If i > 0 Then
                DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                'End If

                'Catch ex As Exception
                'End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col3pheaProc(ByVal index As Integer, ByVal hea As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (HighestEducationalAttainment='" & hea & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col4pheaProc(ByVal index As Integer, ByVal hea As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (HighestEducationalAttainment='" & hea & "' AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col2pag65Proc(ByVal index As Integer, ByVal ll As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                'Try
                command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (Age > '" & ll & "' AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                'Dim i As Integer = command.ExecuteScalar
                'If i > 0 Then
                DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                'End If

                'Catch ex As Exception
                'End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col3pag65Proc(ByVal index As Integer, ByVal ll As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (Age > '" & ll & "' AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col4pag65Proc(ByVal index As Integer, ByVal ll As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE (Age > '" & ll & "' AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col2pagregProc(ByVal index As Integer, ByVal ll As String, ByVal ul As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                'Try
                command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE ((Cint(Age) BETWEEN " & ll & " AND " & ul & ") AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "') AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                'Dim i As Integer = command.ExecuteScalar
                'If i > 0 Then
                DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                'End If

                'Catch ex As Exception
                'End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col3pagregProc(ByVal index As Integer, ByVal ll As String, ByVal ul As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count - 1
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE ((Cint(Age) BETWEEN " & ll & " AND " & ul & ") AND Sex='Male') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    Public Sub col4pagregProc(ByVal index As Integer, ByVal ll As String, ByVal ul As String)
        If sourceDBfilepath <> String.Empty Then
            Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
            Dim command As OleDbCommand = connection.CreateCommand()
            connection.Open()
            Dim row As Integer = 2
            While row < DataGridView1.Rows.Count
                Try
                    command.CommandText = "SELECT Count(*) FROM [MISdb$] WHERE ((Cint(Age) BETWEEN " & ll & " AND " & ul & ") AND Sex='Female') AND (FullQualificationWTR='" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' And PTQFLevel='" & DataGridView1.Rows(row).Cells(2).Value.ToString & "' And DateFinished IS NOT NULL) AND CutOffMarker='" & reportmonth & "/" & reportyear & "'"
                    'Dim i As Integer = command.ExecuteScalar
                    'If i > 0 Then
                    DataGridView1.Rows(row).Cells(index).Value = command.ExecuteScalar.ToString
                    'End If

                Catch ex As Exception
                End Try
                row += 1
            End While
            connection.Close()
        Else
            MsgBox("sourceDB is empty!")
        End If
    End Sub

    'Exporting
    Public Sub MergeAndCenter(ByVal MergeRange As Microsoft.Office.Interop.Excel.Range)
        MergeRange.[Select]()
        MergeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        MergeRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        MergeRange.WrapText = False
        MergeRange.Orientation = 0
        MergeRange.AddIndent = False
        MergeRange.IndentLevel = 0
        MergeRange.ShrinkToFit = False
        MergeRange.ReadingOrder = CInt(Excel.Constants.xlContext)
        MergeRange.MergeCells = False

        MergeRange.Merge(System.Type.Missing)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If DataGridView1.Columns.Count > 3 Then
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.Name = cbReportCategory.Text

            'Layout Proper
            Dim i As Int16, j As Int16

            Dim hctr As Int16 = 0
            While hctr < DataGridView1.ColumnCount
                xlWorkSheet.Cells(1, hctr + 1) = DataGridView1.Columns(hctr).HeaderText.ToString
                hctr += 1
            End While
            For i = 0 To DataGridView1.RowCount - 2
                For j = 0 To DataGridView1.ColumnCount - 1
                    xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value
                Next
            Next

            MergeAndCenter(xlWorkSheet.Range(xlWorkSheet.Cells(1, 4), xlWorkSheet.Cells(1, 7)))


            Dim exportSaveFileDialog As New SaveFileDialog()
            exportSaveFileDialog.Title = "Select Excel File"
            exportSaveFileDialog.Filter = "Microsoft Office Excel Workbook(*.xlsx)|*.xlsx"
            Dim result As Nullable(Of Boolean) = exportSaveFileDialog.ShowDialog()
            If result = True Then
                Dim fullFileName As String = exportSaveFileDialog.FileName
                xlWorkBook.SaveAs(fullFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, misValue, False, False, Excel.XlSaveAsAccessMode.xlShared, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, True, misValue, misValue)
                xlWorkBook.Saved = True
                MessageBox.Show("Exported successfully", "Exported to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            xlWorkBook.Close()
            xlApp.Quit()
        Else
            MsgBox("Please set report objects")
        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Me.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class


