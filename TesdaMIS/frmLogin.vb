Public Class LoginForm1
    Dim try_ctr As Integer = 0
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Call connect()
        If try_ctr <= 2 Then
            cmd.CommandText = "SELECT COUNT(*) FROM [Users$] WHERE Username='" & UsernameTextBox.Text & "'"
            If cmd.ExecuteScalar > 0 Then
                cmd.CommandText = "SELECT Password FROM [Users$] WHERE Username = '" & UsernameTextBox.Text & "'"
                If PasswordTextBox.Text.Equals(cmd.ExecuteScalar.ToString) Then
                    Me.Hide()
                    MessageBox.Show("Logged-in as " & UsernameTextBox.Text, "Success", MessageBoxButtons.OK)
                    activeuser = UsernameTextBox.Text
                    UsernameTextBox.Clear()
                    PasswordTextBox.Clear()
                    frmMain.ShowDialog()
                    Me.Show()
                    UsernameTextBox.Focus()
                Else
                    MessageBox.Show("Incorrect Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    try_ctr = try_ctr + 1
                    If try_ctr > 2 Then
                        MessageBox.Show("You have reached the maximum number of login tries!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If
                End If
            Else
                MessageBox.Show("Incorrect Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                try_ctr = try_ctr + 1
                If try_ctr > 2 Then
                    MessageBox.Show("You have reached the maximum number of login tries!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            End If
        End If
        Call disconnect()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.AcceptButton = OK
    End Sub
End Class
