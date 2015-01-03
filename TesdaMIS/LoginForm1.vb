Imports System.Data
Imports System.Data.OleDb
Public Class LoginForm1
    Dim try_ctr As Integer = 0
    Dim conn As New OleDbConnection(constring)
    Dim cmd As OleDbCommand = conn.CreateCommand
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        conn.Close()
        conn.Open()
        If try_ctr <= 2 Then
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username='" & UsernameTextBox.Text & "'"
            If cmd.ExecuteScalar > 0 Then
                cmd.CommandText = "SELECT UserPassword FROM Users WHERE Username = '" & UsernameTextBox.Text & "'"
                If PasswordTextBox.Text.Equals(cmd.ExecuteScalar.ToString) Then
                    Me.Hide()
                    MessageBox.Show("Logged-in as " & UsernameTextBox.Text, "Success", MessageBoxButtons.OK)
                    UsernameTextBox.Clear()
                    PasswordTextBox.Clear()
                    frmMain.ShowDialog()
                    Me.Show()
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

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
