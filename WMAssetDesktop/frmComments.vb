Imports WmAssetWebServiceClientNet.Models
Imports WmAssetWebServiceClientNet
Imports System.Net.Http
Public Class frmComments
    'Dim httpClient As HttpClient
    'Dim assetDataRepository As AssetDataRepository
    Dim Comments As IEnumerable(Of Comment)
    Private Sub frmComments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataGrid()
    End Sub
    Private Sub LoadDataGrid()
        DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False

        ' Comments = New AssetDataRepository(httpClient)
        Try
            Comments = ds.GetComments().Result
            Try
                DataGridView1.DataSource = Comments
                DataGridView1.Columns(0).Visible = False
                DataGridView1.AutoResizeColumns()


                ' DataGridView1.Refresh()
            Catch ex As Exception
                MessageBox.Show("Failed to load Comments. " + ex.Message)
            End Try
        Catch
        End Try


    End Sub
    Private Sub ReLoadDataGrid()
        'DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False


        ' Comments = New AssetDataRepository(httpClient)

        Comments = ds.GetComments().Result
        Try
            DataGridView1.DataSource = Comments
            DataGridView1.Columns(0).Visible = False
            DataGridView1.AutoResizeColumns()


            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed to load comments. " + ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 Then ' Check if the event is not for the header row
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim oComment As Comment = TryCast(row.DataBoundItem, Comment)

            If oComment IsNot Nothing Then
                Dim dummy As Object = ds.UpdateComment(oComment)
                System.Threading.Thread.Sleep(200) ' Wait for 1/5th second to allow the server to process the request
                ReLoadDataGrid()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim confirmed = MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmed = DialogResult.Yes Then
                Dim dummy As Object
                For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
                    If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
                        Dim oComment = TryCast(selectedRow.DataBoundItem, Comment)
                        Try
                            dummy = ds.DeleteComment(oComment.Id)
                        Catch ex As Exception
                            MessageBox.Show($"Failed to delete comment: {ex.Message}")
                        End Try
                    End If
                Next
            End If
        Else
            MessageBox.Show("Please select at least one row to delete.")
        End If
        ReLoadDataGrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New frmAddComment
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
        LoadDataGrid()
    End Sub
End Class