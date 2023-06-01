Public Class Home_Page
    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        order.Show()
        Me.Hide()
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Backup.Show()
        Me.Hide()
    End Sub

    Private Sub btnReviews_Click(sender As Object, e As EventArgs) Handles btnReviews.Click
        review.Show()
        Me.Hide()
    End Sub