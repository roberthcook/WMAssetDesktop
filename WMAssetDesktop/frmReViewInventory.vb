Imports System.IO
Imports System.Net.Http
Imports WmAssetWebServiceClientNet
Imports WmAssetWebServiceClientNet.Models
Public Class frmReViewInventory
    Dim httpClient As HttpClient
    Dim invAsset As IEnumerable(Of InventoryAsset)
    Dim finvAsset As IEnumerable(Of FinalInventoryAsset)
    Dim bLoading As Boolean = True
    Dim assetDataRepository As AssetDataRepository
    Dim msg As String
    Dim sCounted As String
    Dim sNotCounted As String


    Private Sub cbDepartments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartments.SelectedIndexChanged
        If Not bLoading Then
            sRespOrg = cbDepartments.Text

            If Check_MobileComplete() Then
                IntloadDatagrid()
                btnDelete.Enabled = True
                btnExport.Enabled = True
                btnMovetoFinal.Enabled = True
            Else
                MsgBox(msg, vbOKOnly, "Review Inventory")
            End If
        End If
    End Sub
    Private Sub IntloadDatagrid()
        DataGridView1.DataSource = Nothing

        invAsset = ds.GetInventoryAssetsForDepartment(sRespOrg).Result
        Try
            DataGridView1.DataSource = invAsset
            DataGridView1.Columns(0).Visible = False
            '   DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(11).Visible = False
            DataGridView1.AutoResizeColumns()
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(6).ReadOnly = True
            DataGridView1.Columns(7).ReadOnly = True
            DataGridView1.Columns(8).ReadOnly = True

            'DataGridView1.RowHeadersWidth = 90
            ' DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed to load inventory. " + ex.Message)
        End Try
    End Sub
    Private Sub ReloadDatagrid()
        ' DataGridView1.DataSource = Nothing

        invAsset = Nothing
        invAsset = ds.GetInventoryAssetsForDepartment(sRespOrg).Result
        DataGridView1.DataSource = invAsset
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersWidth = 90
        DataGridView1.Columns(0).Visible = False

        DataGridView1.Columns(11).Visible = False
        DataGridView1.AutoResizeColumns()
        DataGridView1.Columns(1).ReadOnly = False
        DataGridView1.Columns(2).ReadOnly = False
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = False
        DataGridView1.Columns(5).ReadOnly = False
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(7).ReadOnly = True
        DataGridView1.Columns(8).ReadOnly = True
        ' DataGridView1.Sort(DataGridView1.Columns(5), 1)

        DataGridView1.Refresh()
    End Sub

    Private Sub frmReViewInventory_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDepartments()
        bLoading = False
        btnDelete.Enabled = False
        btnExport.Enabled = False
        btnMovetoFinal.Enabled = False
    End Sub
    Private Sub LoadDepartments()
        cbDepartments.Items.Clear()

        Dim depts As IEnumerable(Of Department)
        Try
            depts = ds.GetDepartments().Result

            Dim ls As List(Of Department) = depts.ToList
            cbDepartments.DataSource = ls
            cbDepartments.DisplayMember = "DepartmentName"
            cbDepartments.Refresh()
        Catch
        End Try

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        ''DataGridView1.AutoResizeColumns(0)

        'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim confirmed = MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmed = DialogResult.Yes Then
                Dim dummy As Object
                For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
                    If Not selectedRow.IsNewRow Then ' Ensure the row isn't the placeholder for new entries
                        Dim oAsset As InventoryAsset = TryCast(selectedRow.DataBoundItem, InventoryAsset)
                        Try
                            dummy = ds.DeleteInventoryAsset(oAsset.Id)
                        Catch ex As Exception
                            MessageBox.Show($"Failed to delete asset: {ex.Message}")
                        End Try
                    End If
                Next
            End If
        Else
            MessageBox.Show("Please select at least one row to delete.")
        End If
        ReloadDatagrid()
        DataGridView1.Refresh()
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 Then ' Check if the event is not for the header row
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim oAsset As InventoryAsset = TryCast(row.DataBoundItem, InventoryAsset)

            If oAsset IsNot Nothing Then
                Dim dummy As Object = ds.UpdateInventoryAsset(oAsset)
                System.Threading.Thread.Sleep(200) ' Wait for 1/5th second to allow the server to process the request
                ReloadDatagrid()
            End If
        End If
    End Sub
    Private Sub DataGridView1_EnabledChanged(sender As Object, e As EventArgs) Handles DataGridView1.EnabledChanged

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim sfd As New SaveFileDialog
        sfd.FileName = "Inv" & sRespOrg.Trim
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog = DialogResult.OK Then
            Using sw = File.CreateText(sfd.FileName)
                Dim sHeader As String = vbCrLf & vbCrLf & "Review Inventory" & "     " & "Date: " & Now() & vbCrLf
                sw.WriteLine(sHeader)
                sHeader = "Department: " & sRespOrg & vbCrLf & vbCrLf
                sw.WriteLine(sHeader)

                sHeader = ""
                Dim dgvColumnNames = DataGridView1.Columns.
                    Cast(Of DataGridViewColumn).ToList.
                    Select(Function(c) c.Name).ToList

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
        '  .'  Export_Excel()
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnMovetoFinal_Click(sender As Object, e As EventArgs) Handles btnMovetoFinal.Click
        MovetoFinal()
    End Sub
    Private Sub MovetoFinal()
        Dim bSuccess As Boolean = True
        If DataGridView1.Rows.Count > 0 Then
            If Check_ScheduleforFinal(sRespOrg) Then
                Dim confirmed = MessageBox.Show("Are you sure you want to move the inventory to the final inventory for review? Mobile units will no loger be allowed for this department inventory! ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If confirmed = DialogResult.Yes Then
                    Try
                        ds.CreateFinalInventoryAssetsByDepartment(sRespOrg)
                    Catch ex As Exception
                        MessageBox.Show($"Failed to move to final: {ex.Message}")
                        bSuccess = False
                    End Try
                    If bSuccess Then
                        If UpdatesheduleBeforeFinal(sRespOrg) = False Then
                            MsgBox("Failed to update schedule to complete = True", vbOKOnly, "Update Error")
                        End If
                    End If
                End If
                DataGridView1.DataSource = Nothing
                DataGridView1.Refresh()
                btnDelete.Enabled = False
                btnExport.Enabled = False
                btnMovetoFinal.Enabled = False
            Else
                MsgBox(msg, MsgBoxStyle.OkOnly, "Requirement")
            End If


        End If
    End Sub

    Private Async Sub GetinventoryCounts()
        Dim inventoryAssets = Await ds.GetInventoryAssetsForDepartment(sRespOrg)

        Dim CountedAssets = inventoryAssets.Where(Function(x) x.Inventoried.HasValue = True).ToList
        Dim notCountedAssets = inventoryAssets.Where(Function(x) x.Inventoried.HasValue = False).ToList
        sCounted = CountedAssets.Count().ToString()
        sNotCounted = notCountedAssets.Count().ToString()

    End Sub
    Private Function Check_MobileComplete() As Boolean
        Dim bRslt As Boolean = True
        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result
        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = sRespOrg).ToList()
        If filteredSchedules.Count > 0 Then
            If filteredSchedules.Item(0).Completed = True Then
                msg = "Inventory moved to final"
                bRslt = False
            Else
                bRslt = True
            End If
        Else
            msg = "Schedule for " & sRespOrg & "does not exist!"
            bRslt = False
        End If
        Return bRslt
    End Function



    Private Function Check_ScheduleforLoad(ByVal Dept As String) As Boolean
        Dim bRslt As Boolean = True

        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result
        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = sRespOrg).ToList()
        Select Case filteredSchedules.Count
            Case 0
                msg = "Schedule does not exist for department " & sRespOrg
                bRslt = False
            Case Else
                If filteredSchedules.Item(0).Started = False Then
                    msg = "Mobile unit has not started inventory!"
                    bRslt = False
                ElseIf filteredSchedules.Item(0).Completed = True Then
                    bRslt = False
                    msg = "Inventory already moved to final!"
                End If
        End Select
        Return bRslt
    End Function
    Private Function Check_ScheduleforFinal(ByVal Dept As String) As Boolean
        Dim bRslt As Boolean = True

        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result
        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = sRespOrg).ToList()
        Select Case filteredSchedules.Count
            Case 0
                msg = "Schedule does not exist for department " & sRespOrg
                bRslt = False
            Case Else
                If filteredSchedules.Item(0).CompletedDate Is Nothing Then
                    msg = "Mobile unit must complete inventory before move to final!"
                    bRslt = False
                ElseIf filteredSchedules.Item(0).Completed = True Then
                    msg = "Inventory already moved to final"
                    bRslt = False
                Else
                    bRslt = True
                End If
        End Select
        Return bRslt
    End Function

End Class