Public Class frmMain
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnUploadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadData.Click
        Me.Hide()
        frmUploadData.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnViewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRecord.Click
        If sourceDBfilepath <> String.Empty Then
            Me.Hide()
            Dim x As New frmViewRecord
            x.ShowDialog()
            Me.Show()
        Else
            MessageBox.Show("Please upload a valid excel file!", "Error", MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        If sourceDBfilepath <> String.Empty Then
            Me.Hide()
            Dim x As New frmViewReport
            x.ShowDialog()
            Me.Show()
        Else
            MessageBox.Show("Please upload a valid excel file!", "Error", MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
        If MessageBox.Show("Are you sure you want to exit the system?", "Logging off", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then

            e.Cancel = True
        End If
    End Sub

End Class