<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm1))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(45, 33)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(218, 201)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 8
        Me.LogoPictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(28, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 21)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "WELCOME TO TESDA PaMaMariSan"
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.UsernameLabel.Location = New System.Drawing.Point(43, 322)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(222, 23)
        Me.UsernameLabel.TabIndex = 9
        Me.UsernameLabel.Text = "&Username"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(90, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 21)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "DISTRICT OFFICE"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.PasswordLabel.Location = New System.Drawing.Point(43, 371)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(222, 23)
        Me.PasswordLabel.TabIndex = 11
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.ForeColor = System.Drawing.Color.White
        Me.Cancel.Location = New System.Drawing.Point(160, 435)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(77, 23)
        Me.Cancel.TabIndex = 14
        Me.Cancel.Text = "Quit"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Location = New System.Drawing.Point(45, 347)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(220, 20)
        Me.UsernameTextBox.TabIndex = 10
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.OK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.Location = New System.Drawing.Point(74, 435)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(77, 23)
        Me.OK.TabIndex = 13
        Me.OK.Text = "Login"
        Me.OK.UseVisualStyleBackColor = False
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Location = New System.Drawing.Point(45, 396)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(220, 20)
        Me.PasswordTextBox.TabIndex = 12
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'LoginForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(307, 491)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Security"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox

End Class
