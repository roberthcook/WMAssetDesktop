Imports WmAssetWebServiceClientNet
Imports System.Net.Http
Imports System.IO


Public Class frmViewSchedules
    Private Sub Load_Datagrid()
        '  ds.DeleteSchedule(30)

        '  ds.DeleteSchedule(31)

        DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False
        Dim asst As IEnumerable = Nothing

        Try
            asst = ds.GetSchedules().Result
        Catch ex As AggregateException
            MsgBox(ex.Message)
        End Try
        DataGridView1.DataSource = asst
        DataGridView1.Columns(0).Visible = False
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersWidth = 90
        DataGridView1.Refresh()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub frmViewSchedules_Load(sender As Object, e As EventArgs) Handles Me.Load
        Load_Datagrid()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
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

End Class