Imports System.IO
Imports WmAssetWebServiceClientNet.Models

Public Class frmViewUsers
    Private Sub btnExport_Click(sender As Object, e As EventArgs)
        Dim sfd As New SaveFileDialog()
        sfd.FileName = "Schedules"
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog() = DialogResult.OK Then
            Using sw As StreamWriter = File.CreateText(sfd.FileName)
                Dim dgvColumnNames As List(Of String) = DataGridView1.Columns.
                    Cast(Of DataGridViewColumn).ToList().
                    Select(Function(c) c.Name).ToList()

                sw.WriteLine(String.Join(",", dgvColumnNames))

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim rowData As New List(Of String)
                    For Each column As DataGridViewColumn In DataGridView1.Columns
                        rowData.Add(Convert.ToString(row.Cells(column.Name).Value))
                    Next
                    sw.WriteLine(String.Join(",", rowData))
                Next
            End Using
        End If
    End Sub
    Private Sub Load_Datagrid()
        '  ds.DeleteSchedule(30)

        '  ds.DeleteSchedule(31)

        DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False
        Dim users As IEnumerable

        Try
            users = ds.GetUsers().Result
        Catch ex As AggregateException
            MsgBox(ex.Message)
        End Try
        DataGridView1.DataSource = users
        DataGridView1.AutoResizeColumns()
        ' DataGridView1.RowHeadersWidth = 90
    End Sub

    Private Sub frmViewUsers_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub frmViewUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Load_Datagrid()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim confirmed = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmed = DialogResult.Yes Then
                Dim dummy As Object
                For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
                    If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
                        Dim oUser As User = TryCast(selectedRow.DataBoundItem, User)
                        Try
                            dummy = ds.DeleteUser(oUser.Id)
                        Catch ex As Exception
                            MessageBox.Show($"Failed to delete user: {ex.Message}")
                        End Try
                    End If
                Next
            End If
        Else
            MessageBox.Show("Please select at least one row to delete.")
        End If
        Load_Datagrid()
        DataGridView1.Refresh()
    End Sub
End Class