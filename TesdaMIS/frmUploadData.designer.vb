<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpReportCutOff = New System.Windows.Forms.DateTimePicker()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpReportCutOff
        '
        Me.dtpReportCutOff.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReportCutOff.Location = New System.Drawing.Point(12, 55)
        Me.dtpReportCutOff.Name = "dtpReportCutOff"
        Me.dtpReportCutOff.Size = New System.Drawing.Size(166, 20)
        Me.dtpReportCutOff.TabIndex = 0
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload.ForeColor = System.Drawing.Color.White
        Me.btnUpload.Location = New System.Drawing.Point(12, 81)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(80, 31)
        Me.btnUpload.TabIndex = 4
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'openFileDialog
        '
        Me.openFileDialog.DefaultExt = "xlsx"
        Me.openFileDialog.FileName = "PMMS SB"
        Me.openFileDialog.Filter = "Excel Workbooks (*.xlsx)|*.xlsx"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(98, 81)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 31)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Reporting Cut-off Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "UPLOAD DATA"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(196, 27)
        Me.Panel1.TabIndex = 7
        '
        'frmUploadData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(191, 125)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpReportCutOff)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmUploadData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtpReportCutOff As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
