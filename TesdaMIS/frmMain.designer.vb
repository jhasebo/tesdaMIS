<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnUploadData = New System.Windows.Forms.Button()
        Me.btnViewRecord = New System.Windows.Forms.Button()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUploadData
        '
        Me.btnUploadData.FlatAppearance.BorderSize = 0
        Me.btnUploadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadData.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnUploadData.Image = CType(resources.GetObject("btnUploadData.Image"), System.Drawing.Image)
        Me.btnUploadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUploadData.Location = New System.Drawing.Point(66, 64)
        Me.btnUploadData.Name = "btnUploadData"
        Me.btnUploadData.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnUploadData.Size = New System.Drawing.Size(122, 31)
        Me.btnUploadData.TabIndex = 0
        Me.btnUploadData.Text = "UPLOAD DATA"
        Me.btnUploadData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUploadData.UseVisualStyleBackColor = True
        '
        'btnViewRecord
        '
        Me.btnViewRecord.FlatAppearance.BorderSize = 0
        Me.btnViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewRecord.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewRecord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnViewRecord.Image = CType(resources.GetObject("btnViewRecord.Image"), System.Drawing.Image)
        Me.btnViewRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewRecord.Location = New System.Drawing.Point(66, 101)
        Me.btnViewRecord.Name = "btnViewRecord"
        Me.btnViewRecord.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnViewRecord.Size = New System.Drawing.Size(122, 31)
        Me.btnViewRecord.TabIndex = 1
        Me.btnViewRecord.Text = "VIEW RECORD"
        Me.btnViewRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnViewRecord.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.FlatAppearance.BorderSize = 0
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewReport.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(66, 138)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnViewReport.Size = New System.Drawing.Size(122, 31)
        Me.btnViewReport.TabIndex = 2
        Me.btnViewReport.Text = "VIEW REPORT"
        Me.btnViewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnExit.Location = New System.Drawing.Point(66, 175)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(122, 31)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "EXIT"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Dashboard"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 49)
        Me.Panel1.TabIndex = 5
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(200, 215)
        Me.Controls.Add(Me.btnUploadData)
        Me.Controls.Add(Me.btnViewRecord)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnViewReport)
        Me.ForeColor = System.Drawing.Color.LightGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUploadData As System.Windows.Forms.Button
    Friend WithEvents btnViewRecord As System.Windows.Forms.Button
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
