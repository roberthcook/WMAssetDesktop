Imports WmAssetWebServiceClientNet.Models
Imports WmAssetWebServiceClientNet
Imports System.Net.Http
Imports System.IO
Public Class frmRevDiscrepancy
    Dim httpClient As HttpClient
    Dim discpAsset As IEnumerable(Of Discrepancy)
    Dim bLoading As Boolean = True

    Private Sub frmRevDiscrepancy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IntloadDatagrid()
    End Sub
    Private Sub IntloadDatagrid()
        DataGridView1.DataSource = Nothing
        Try
            discpAsset = ds.GetDiscrepancies().Result
            Try
                DataGridView1.DataSource = discpAsset
                DataGridView1.Columns(0).Visible = False
                '  DataGridView1.Columns(9).Visible = False
                DataGridView1.AutoResizeColumns()
                DataGridView1.Columns(1).ReadOnly = True
                DataGridView1.Columns(2).ReadOnly = True
                DataGridView1.Columns(3).ReadOnly = True
                DataGridView1.Columns(5).ReadOnly = True
                Dim i As Int16
                For i = 7 To 18
                    DataGridView1.Columns(i).ReadOnly = True
                Next

                'DataGridView1.RowHeadersWidth = 90
                ' DataGridView1.Refresh()
            Catch ex As Exception
                MessageBox.Show("Failed to load inventory. " + ex.Message)
            End Try

        Catch ex As Exception
            ' MessageBox.Show("Failed to load inventory. " + ex.Message)
        End Try

    End Sub
    'Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    '    If DataGridView1.SelectedRows.Count > 0 Then
    '        Dim confirmed = MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '        If confirmed = DialogResult.Yes Then
    '            Dim dummy As Object
    '            For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
    '                If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
    '                    Dim oAsset As InventoryAsset = TryCast(selectedRow.DataBoundItem, InventoryAsset)
    '                    Try
    '                        dummy = assetDataRepository.DeleteInventoryAsset(oAsset.Id)
    '                    Catch ex As Exception
    '                        MessageBox.Show($"Failed to delete asset: {ex.Message}")
    '                    End Try
    '                End If
    '            Next
    '        End If
    '    Else
    '        MessageBox.Show("Please select at least one row to delete.")
    '    End If
    '    ReloadDatagrid()
    'End Sub
    'Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    '    If DataGridView1.SelectedRows.Count > 0 Then
    '        Dim confirmed = MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '        If confirmed = DialogResult.Yes Then
    '            Dim dummy As Object
    '            For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
    '                If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
    '                    Dim oAsset As InventoryAsset = TryCast(selectedRow.DataBoundItem, InventoryAsset)
    '                    Try
    '                        dummy = assetDataRepository.DeleteInventoryAsset(oAsset.Id)
    '                    Catch ex As Exception
    '                        MessageBox.Show($"Failed to delete asset: {ex.Message}")
    '                    End Try
    '                End If
    '            Next
    '        End If
    '    Else
    '        MessageBox.Show("Please select at least one row to delete.")
    '    End If
    '    ReloadDatagrid()
    'End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 Then ' Check if the event is not for the header row
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim oAsset As Discrepancy = TryCast(row.DataBoundItem, Discrepancy)

            If oAsset IsNot Nothing Then
                Dim dummy As Object = ds.UpdateDiscrepancy(oAsset)
                System.Threading.Thread.Sleep(200) ' Wait for 1/5th second to allow the server to process the request
                IntloadDatagrid()
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim sfd As New SaveFileDialog()
        sfd.FileName = "InvDiscrepancy"
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog() = DialogResult.OK Then
            Using sw As StreamWriter = File.CreateText(sfd.FileName)
                Dim sHeader As String = vbCrLf & vbCrLf & "Review Discrepancies" & "     " & "Date: " & Now() & vbCrLf & vbCrLf
                sw.WriteLine(sHeader)

                Dim dgvColumnNames As List(Of String) = DataGridView1.Columns.
                    Cast(Of DataGridViewColumn).ToList().
                    Select(Function(c) c.Name).ToList()

                sHeader = String.Join(",", dgvColumnNames)
                sHeader = Mid(sHeader, 4)
                sw.WriteLine(sHeader)

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim rowData As New List(Of String)
                    For Each column As DataGridViewColumn In DataGridView1.Columns
                        If column.Name = "Id" Then
                        Else
                            rowData.Add(Convert.ToString(row.Cells(column.Name).Value))
                        End If
                    Next
                    sw.WriteLine(String.Join(",", rowData))
                Next
            End Using
        End If
    End Sub

    Private Sub btnAddtoFinal_Click(sender As Object, e As EventArgs) Handles btnAddtoFinal.Click

        If DataGridView1.SelectedRows.Count > 0 Then
            Dim confirmed = MessageBox.Show("Are you sure you want to move the selected row to the final inventory?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Dim dummy As Object
            If confirmed = DialogResult.Yes Then

                For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
                    If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
                        Dim oDiscrepancy As Discrepancy = TryCast(selectedRow.DataBoundItem, Discrepancy)
                        Dim oMasterAsset As Asset = ds.GetAssetByBarcode(oDiscrepancy.Barcode).Result
                        Dim sLoc As String
                        Dim sLocCode As String
                        Dim sRoom As String
                        If oDiscrepancy.ActualRoom.Length = 0 Then
                            sRoom = oDiscrepancy.Room
                        Else
                            sRoom = oDiscrepancy.ActualRoom
                        End If
                        If oDiscrepancy.ActualLocation.Length = 0 Then
                            Dim aLocCode() As String = oDiscrepancy.Location.Split("/")
                            sLocCode = aLocCode(0)
                            sLoc = aLocCode(1)
                        Else
                            Dim aLocCode() As String = oDiscrepancy.ActualLocation.Split("/")
                            sLocCode = aLocCode(0)
                            sLoc = aLocCode(1)
                        End If

                        Dim newinventoryAsset As New FinalInventoryAsset() With {
                            .RespChart = oMasterAsset.RespChart,
                            .ResponsibleOrganization = oDiscrepancy.ResponsibleOrganization,
                            .LocationCode = sLocCode,
                            .Location = sLoc,
                            .Room = sRoom,
                            .Barcode = oDiscrepancy.Barcode,
                            .AssetDescription = oDiscrepancy.AssetDescription,
                            .Manufacturer = oDiscrepancy.Manufacturer,
                            .Make = oDiscrepancy.Make,
                            .Model = oDiscrepancy.Model,
                            .SerialNumber = oMasterAsset.SerialNumber,
                            .Otag = oMasterAsset.Otag,
                            .Ptag = oMasterAsset.Ptag,
                            .Acquired = oDiscrepancy.Acquired,
                            .Inventoried = oDiscrepancy.Inventoried,
                            .Custodian = oMasterAsset.Custodian,
                            .CustodianId = oMasterAsset.CustodianId,
                            .EquipmentManager = oMasterAsset.EquipmentManager,
                            .EquipmentId = oMasterAsset.EquipmentId
                            }
                        Try
                            dummy = ds.CreateFinalInventoryAsset(newinventoryAsset).Result

                        Catch ex As Exception
                            MessageBox.Show($"Failed to create final asset inventory: {ex.Message}")
                        End Try
                        'delete discrepancy
                        Try
                            dummy = ds.DeleteDiscrepancy(oDiscrepancy.Id)
                        Catch ex As Exception
                            MessageBox.Show($"Failed to delete Discrepancy: {ex.Message}")
                        End Try
                        System.Threading.Thread.Sleep(200) ' Wait for 1/5th second to allow the server to process the request
                        IntloadDatagrid()
                    End If
                Next
            End If
        Else
            MessageBox.Show("Please select at least one row to delete.")
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim confirmed = MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmed = DialogResult.Yes Then
                Dim dummy As Object
                For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
                    If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
                        Dim oDiscrepancy = TryCast(selectedRow.DataBoundItem, Discrepancy)
                        Try
                            dummy = ds.DeleteDiscrepancy(oDiscrepancy.Id)
                        Catch ex As Exception
                            MessageBox.Show($"Failed to delete Discrepancy: {ex.Message}")
                        End Try
                        System.Threading.Thread.Sleep(200) ' Wait for 1/5th second to allow the server to process the request
                        IntloadDatagrid()
                    End If
                Next
            End If
        Else
            MessageBox.Show("Please select at least one row to delete.")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class