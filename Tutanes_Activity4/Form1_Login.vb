Imports MySql.Data.MySqlClient

Public Class LoginForm1

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click


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

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class