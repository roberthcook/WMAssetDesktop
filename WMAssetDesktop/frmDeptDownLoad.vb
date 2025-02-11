Imports WmAssetWebServiceClientNet
Imports WmAssetWebServiceClientNet.Models
Imports System.Net.Http
Imports System.IO

Public Class frmDeptDownLoad
    Private Sub frmDeptDownLoad_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadDatagrid()
    End Sub
    Private Sub loadDatagrid()
        DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False
        Dim asst As IEnumerable
        Try
            asst = ds.GetInventoryAssetsForDepartment(sRespOrg).Result
        Catch ex As AggregateException

        End Try

        DataGridView1.DataSource = asst
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(9).Visible = False

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersWidth = 90
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        'DataGridView1.AutoResizeColumns(0)

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim sfd As New SaveFileDialog()
        sfd.FileName = "Inv" & sRespOrg.Trim
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