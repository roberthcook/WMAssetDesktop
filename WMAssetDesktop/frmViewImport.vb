Imports System.Drawing.Printing
Public Class frmViewImport
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub frmViewImport_Load(sender As Object, e As EventArgs) Handles Me.Load
        'BackColor = Color.FromArgb(11, 57, 40) 'wm green
        ' BackColor = Color.FromArgb(240, 179, 35) ' spirit gold
        ' BackColor = Color.FromArgb(185, 151, 91) '  gold
        Load_Datagrid()
    End Sub

    Private Sub Load_Datagrid()
        DataGridView1.DataSource = Nothing

        Dim asst As IEnumerable
        Try
            asst = ds.GetAssets().Result
        Catch ex As AggregateException
            MsgBox(ex.Message)
        End Try






        DataGridView1.DataSource = asst
        DataGridView1.Columns(0).Visible = False
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersWidth = 90
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter

    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        'DataGridView1.AutoResizeColumns(0)

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells


    End Sub

    Private Sub DataGridView1_ColumnRemoved(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnRemoved

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.Show
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Dim imagebmap As Bitmap(Me.DataGridView1.width,Me.datagridview1.height)

    End Sub
End Class