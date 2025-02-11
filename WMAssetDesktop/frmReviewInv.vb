Imports WmAssetWebServiceClientNet.Models
Imports WmAssetWebServiceClientNet
Imports System.Net.Http


Public Class frmViewInventory
    Private Sub frmViewInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDept.Text="Department:" &sRespOrg
        loadDatagrid()
    End Sub
    Private Sub loadDatagrid()
        DataGridView1.DataSource = Nothing
        Dim bRslt As Boolean = False
        Dim HttpClient = New HttpClient With {
            .BaseAddress = New Uri("https://wmpgsqlapilinux.azurewebsites.net/")
        }
        Dim AssetDataRepository = New AssetDataRepository(HttpClient)
        Dim invAsset As InventoryAsset
        invAsset = AssetDataRepository.GetInventoryAssetsForDepartment(sRespOrg).Result
        Try
            DataGridView1.DataSource = invAsset
            DataGridView1.Columns(0).Visible = False
            DataGridView1.AutoResizeColumns()
            DataGridView1.Columns(1).ReadOnly = True
            'DataGridView1.RowHeadersWidth = 90
            ' DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed to load inventory. " + ex.Message)
        End Try
    End Sub
End Class