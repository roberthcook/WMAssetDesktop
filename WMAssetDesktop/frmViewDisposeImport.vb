Imports System.Linq
Imports WmAssetWebServiceClientNet.Models
Imports WmAssetWebServiceClientNet
Imports System.Net.Http
Imports System.Drawing.Printing

Public Class frmViewDisposeImport
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Load_Datagrid()
        DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False

        Dim asst As IEnumerable
        asst = ds.GetDisposedAssets().Result
        DataGridView1.DataSource = asst
        DataGridView1.Columns(0).Visible = False
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersWidth = 90
    End Sub

    Private Sub frmViewDisposeImport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Load_Datagrid()
    End Sub
End Class