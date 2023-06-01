Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim mycmd As New MySqlCommand
        Dim myreader As MySqlDataReader


        Dim strSQL As String = "Select * from accounts where username = '" _
            & UsernameTextBox.Text & "' and password = md5('" _
            & PasswordTextBox.Text & "')"
        'MsgBox(strSQL)
        mycmd.CommandText = strSQL
        mycmd.Connection = conn

        myreader = mycmd.ExecuteReader
        If myreader.HasRows Then
            Me.Hide()
            HomePage.Show()
        Else
            MessageBox.Show("Invalid username or password")
        End If
    End Sub
End Class