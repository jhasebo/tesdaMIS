Public Class frmUploadData

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim file As String = openFileDialog.FileName
            Dim filearray() As String
            filearray = file.Split(".")
            If filearray(1).Equals("xlsx") Then
                sourceDBfilepath = openFileDialog.FileName
                reportmonth = Val(dtpReportCutOff.Value.Date.ToString("MM"))
                reportyear = Val(dtpReportCutOff.Value.Date.ToString("yy"))
                MessageBox.Show("Upload Successful!")
                Me.Close()
            Else
                MessageBox.Show("Unable to upload file not of Type [xlsx]. Please try again.", "Upload Failed", MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                openFileDialog.FileName = String.Empty
            End If

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class