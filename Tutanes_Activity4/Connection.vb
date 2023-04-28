Imports MySql.Data.MySqlClient
Module Connection
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public reader As MySqlDataReader
    Sub Connect()
        conn = New MySqlConnection("
            server = localhost;
            userid = root;
            password = Tutanes0824;
            database = product_database
        ")
        conn.Open()
    End Sub
End Module