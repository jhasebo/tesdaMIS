Imports System.Data
Imports System.Data.OleDb
Public Class frmViewRecord
    Dim connection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sourceDBfilepath & ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'")
    Dim reccommand = connection.CreateCommand()
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub bntMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmViewRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM [MISdb$]", connection)
        Dim cb As New OleDbCommandBuilder(da)
        da.Fill(ds)
        While ds.Tables(0).Columns.Count > 45
            ds.Tables(0).Columns.RemoveAt(ds.Tables(0).Columns.Count - 1)
        End While
        DataGridView1.DataSource = ds.Tables(0)
        ds.Dispose()
        da.Dispose()
        cb.Dispose()
        Dim dsft As New DataSet
        Dim daft As New OleDbDataAdapter("SELECT DISTINCT ProviderName FROM [MISdb$]", connection)
        Dim cbft As New OleDbCommandBuilder(daft)
        daft.Fill(dsft)
        cbProviders.Items.Add("All")
        Dim i As Integer = 0
        While i < dsft.Tables(0).Rows.Count
            cbProviders.Items.Add(dsft.Tables(0).Rows(i).Item(0))
            i += 1
        End While
        cbProviders.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("SELECT * FROM [MISdb$] WHERE LastName LIKE '%" & tbSearchRecord.Text & "%' OR FirstName LIKE '%" & tbSearchRecord.Text & "%' OR ProviderName LIKE '%" & tbSearchRecord.Text & "%'", connection)
        Dim cb As New OleDbCommandBuilder(da)
            da.Fill(ds)
            While ds.Tables(0).Columns.Count > 45
                ds.Tables(0).Columns.RemoveAt(ds.Tables(0).Columns.Count - 1)
            End While
            DataGridView1.DataSource = ds.Tables(0)
            ds.Dispose()
            da.Dispose()
        cb.Dispose()
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        frmAddNewRecord.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        frmEditRecord.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cbProviders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProviders.SelectedIndexChanged
        If cbProviders.Text = "All" Then
            tbProvname.Text = "All"
            tbProvAddress.Text = "N/A"
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter("SELECT * FROM [MISdb$]", connection)
            Dim cb As New OleDbCommandBuilder(da)
            da.Fill(ds)
            While ds.Tables(0).Columns.Count > 45
                ds.Tables(0).Columns.RemoveAt(ds.Tables(0).Columns.Count - 1)
            End While
            DataGridView1.DataSource = ds.Tables(0)
            cbProgram.Items.Clear()
            cbProgram.Items.Add("All")
            cbProgram.Text = String.Empty
            ds.Dispose()
            da.Dispose()
            cb.Dispose()
            Dim dsprog As New DataSet
            Dim daprog As New OleDbDataAdapter("SELECT DISTINCT FullQualificationWTR FROM [MISdb$]", connection)
            Dim cbprog As New OleDbCommandBuilder(daprog)
            daprog.Fill(dsprog)
            Dim i As Integer = 0
            While i < dsprog.Tables(0).Rows.Count
                cbProgram.Items.Add(dsprog.Tables(0).Rows(i).Item(0))
                i += 1
            End While
            cbProgram.SelectedIndex = 0
            dgvSummary.Columns.Clear()
            Dim progcol As New DataGridViewTextBoxColumn
            Dim enrolledcol As New DataGridViewTextBoxColumn
            Dim terminalcol As New DataGridViewTextBoxColumn
            Dim employeecol As New DataGridViewTextBoxColumn
            progcol.HeaderText = "Training Program"
            enrolledcol.HeaderText = "No. of Enrolled"
            terminalcol.HeaderText = "No. of Terminal"
            employeecol.HeaderText = "No. of Employee"
            dgvSummary.Columns.Add(progcol)
            dgvSummary.Columns.Add(enrolledcol)
            dgvSummary.Columns.Add(terminalcol)
            dgvSummary.Columns.Add(employeecol)
            dgvSummary.Rows.Add(dsprog.Tables(0).Rows.Count)
            Dim j As Integer = 0
            While j < dsprog.Tables(0).Rows.Count
                dgvSummary.Rows(j).Cells(0).Value = dsprog.Tables(0).Rows(j).Item(0)
                connection.Close()
                connection.Open()
                reccommand.commandText = "SELECT COUNT(*) FROM [MISdb$] WHERE FullQualificationWTR='" & dsprog.Tables(0).Rows(j).Item(0) & "'"
                dgvSummary.Rows(j).Cells(1).Value = reccommand.executeScalar()
                reccommand.commandText = "SELECT COUNT(*) FROM [MISdb$] WHERE FullQualificationWTR='" & dsprog.Tables(0).Rows(j).Item(0) & "' AND DateFinished IS NOT NULL"
                dgvSummary.Rows(j).Cells(2).Value = reccommand.executeScalar()
                reccommand.commandText = "SELECT COUNT(*) FROM [MISdb$] WHERE FullQualificationWTR='" & dsprog.Tables(0).Rows(j).Item(0) & "' AND EmploymentDate IS NOT NULL"
                dgvSummary.Rows(j).Cells(3).Value = reccommand.executeScalar()
                connection.Close()
                j += 1
            End While
        Else
            tbProvname.Text = cbProviders.Text
            Dim dse As New DataSet
            Dim dae As New OleDbDataAdapter("SELECT * FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "'", connection)
            Dim cbe As New OleDbCommandBuilder(dae)
            dae.Fill(dse)
            While dse.Tables(0).Columns.Count > 45
                dse.Tables(0).Columns.RemoveAt(dse.Tables(0).Columns.Count - 1)
            End While
            DataGridView1.DataSource = dse.Tables(0)
            tbProvAddress.Text = DataGridView1.Rows(0).Cells(6).Value.ToString
            cbProgram.Items.Clear()
            cbProgram.Items.Add("All")
            cbProgram.Text = String.Empty
            Dim dsprog As New DataSet
            Dim daprog As New OleDbDataAdapter("SELECT DISTINCT FullQualificationWTR FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "'", connection)
            Dim cbprog As New OleDbCommandBuilder(daprog)
            daprog.Fill(dsprog)
            Dim i As Integer = 0
            While i < dsprog.Tables(0).Rows.Count
                cbProgram.Items.Add(dsprog.Tables(0).Rows(i).Item(0))
                i += 1
            End While
            cbProgram.SelectedIndex = 0
            dgvSummary.Columns.Clear()
            Dim progcol As New DataGridViewTextBoxColumn
            Dim enrolledcol As New DataGridViewTextBoxColumn
            Dim terminalcol As New DataGridViewTextBoxColumn
            Dim employeecol As New DataGridViewTextBoxColumn
            progcol.HeaderText = "Training Program"
            enrolledcol.HeaderText = "No. of Enrolled"
            terminalcol.HeaderText = "No. of Terminal"
            employeecol.HeaderText = "No. of Employee"
            dgvSummary.Columns.Add(progcol)
            dgvSummary.Columns.Add(enrolledcol)
            dgvSummary.Columns.Add(terminalcol)
            dgvSummary.Columns.Add(employeecol)
            dgvSummary.Rows.Add(dsprog.Tables(0).Rows.Count)
            Dim j As Integer = 0
            While j < dsprog.Tables(0).Rows.Count
                dgvSummary.Rows(j).Cells(0).Value = dsprog.Tables(0).Rows(j).Item(0)
                connection.Close()
                connection.Open()
                reccommand.commandText = "SELECT COUNT(*) FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "' AND FullQualificationWTR='" & dsprog.Tables(0).Rows(j).Item(0) & "'"
                dgvSummary.Rows(j).Cells(1).Value = reccommand.executeScalar()
                reccommand.commandText = "SELECT COUNT(*) FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "' AND FullQualificationWTR='" & dsprog.Tables(0).Rows(j).Item(0) & "' AND DateFinished IS NOT NULL"
                dgvSummary.Rows(j).Cells(2).Value = reccommand.executeScalar()
                reccommand.commandText = "SELECT COUNT(*) FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "' AND FullQualificationWTR='" & dsprog.Tables(0).Rows(j).Item(0) & "' AND EmploymentDate IS NOT NULL"
                dgvSummary.Rows(j).Cells(3).Value = reccommand.executeScalar()
                connection.Close()
                j += 1
            End While
        End If
    End Sub

    Private Sub cbProgram_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProgram.SelectedIndexChanged
        If cbProgram.Text <> String.Empty Then
            If cbProgram.Text = "All" Then
                If cbProviders.Text = "All" Then
                    Dim ds As New DataSet
                    Dim da As New OleDbDataAdapter("SELECT * FROM [MISdb$]", connection)
                    Dim cb As New OleDbCommandBuilder(da)
                    da.Fill(ds)
                    While ds.Tables(0).Columns.Count > 45
                        ds.Tables(0).Columns.RemoveAt(ds.Tables(0).Columns.Count - 1)
                    End While
                    DataGridView1.DataSource = ds.Tables(0)
                Else
                    Dim dse As New DataSet
                    Dim dae As New OleDbDataAdapter("SELECT * FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "'", connection)
                    Dim cbe As New OleDbCommandBuilder(dae)
                    dae.Fill(dse)
                    While dse.Tables(0).Columns.Count > 45
                        dse.Tables(0).Columns.RemoveAt(dse.Tables(0).Columns.Count - 1)
                    End While
                    DataGridView1.DataSource = dse.Tables(0)
                End If
            Else
                If cbProviders.Text = "All" Then
                    Dim dse As New DataSet
                    Dim dae As New OleDbDataAdapter("SELECT * FROM [MISdb$] WHERE FullQualificationWTR='" & cbProgram.Text & "'", connection)
                    Dim cbe As New OleDbCommandBuilder(dae)
                    dae.Fill(dse)
                    While dse.Tables(0).Columns.Count > 45
                        dse.Tables(0).Columns.RemoveAt(dse.Tables(0).Columns.Count - 1)
                    End While
                    DataGridView1.DataSource = dse.Tables(0)
                Else
                    Dim dse As New DataSet
                    Dim dae As New OleDbDataAdapter("SELECT * FROM [MISdb$] WHERE ProviderName='" & cbProviders.Text & "' AND FullQualificationWTR='" & cbProgram.Text & "'", connection)
                    Dim cbe As New OleDbCommandBuilder(dae)
                    dae.Fill(dse)
                    While dse.Tables(0).Columns.Count > 45
                        dse.Tables(0).Columns.RemoveAt(dse.Tables(0).Columns.Count - 1)
                    End While
                    DataGridView1.DataSource = dse.Tables(0)
                End If

            End If
        End If
    End Sub

End Class