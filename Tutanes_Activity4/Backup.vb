Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Backup
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim backup As New SaveFileDialog
        backup.InitialDirectory = "C:\Users\CARL TUTANES\Documents\2nd sem 3rd year\EDP"
        backup.Title = "Database Backup"
        backup.CheckFileExists = False
        backup.CheckPathExists = False
        backup.DefaultExt = "sql"
        backup.FileName = "backup"
        backup.Filter = "SQL files (*.sql)| *.sql"
        backup.RestoreDirectory = True

        If backup.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim cmd As MySqlCommand = New MySqlCommand
            cmd.Connection = conn
            Dim mb As MySqlBackup = New MySqlBackup(cmd)
            mb.ExportToFile(backup.FileName)
            MessageBox.Show("Database backup sucessfully at " & backup.FileName)
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "CSV Files|*.csv"
        openFileDialog1.Title = "Select a CSV File"

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim file As String = openFileDialog1.FileName
            Dim table As New DataTable()

            Try
                Using sr As New StreamReader(file)
                    Dim headers() As String = sr.ReadLine().Split(","c)
                    For Each header As String In headers
                        table.Columns.Add(header)
                    Next

                    While Not sr.EndOfStream
                        Dim content() As String = sr.ReadLine().Split(","c)
                        Dim row As DataRow = table.NewRow()
                        row.ItemArray = content
                        table.Rows.Add(row)
                    End While
                End Using

                dgview.DataSource = table
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class