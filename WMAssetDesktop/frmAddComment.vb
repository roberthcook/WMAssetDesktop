Imports WmAssetWebServiceClientNet.Models
Public Class frmAddComment
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bRslt As Boolean = False

        Dim NewComment As New Comment With {
        .CommentText = txtComment.Text}
        Try
            NewComment = ds.CreateComment(NewComment).Result
        Catch ex As Exception
            MessageBox.Show("Failed to add comment. " + ex.Message)
        End Try
        txtComment.Text = ""
        txtComment.Focus()


    End Sub
End Class