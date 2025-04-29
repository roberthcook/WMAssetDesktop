Imports System.IO
Imports WmAssetWebServiceClientNet.Models





Public Class frmInventoryStatus
    Dim bLoading As Boolean = True
    Dim sCounted As String
    Dim sNotCounted As String
    Private Sub frmInventoryStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Departments()
    End Sub
    Private Sub Fill_Departments()
        Dim bRslt As Boolean = False
        cbDpt.Items.Clear()
        Dim depts As IEnumerable(Of Department)
        Try
            depts = ds.GetDepartments().Result
        Catch ex As AggregateException
            MsgBox(ex)
        End Try

        Dim lst As List(Of Department) = depts.ToList
        cbDpt.DataSource = lst
        cbDpt.DisplayMember = "DepartmentName"
        ' cbDepartments.Refresh()
        bLoading = False
    End Sub

    Private Sub cbDpt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDpt.SelectedIndexChanged
        If Not bLoading Then
            sRespOrg = cbDpt.Text
            lblDeptName.Text = sRespOrg
            GetDepartmentSchedule()
        End If
    End Sub
    Private Sub GetDepartmentSchedule()
        Dim schedules As IEnumerable(Of Schedule)

        Try
            schedules = ds.GetSchedules().Result
        Catch ex As AggregateException
            MsgBox(ex.Message, vbOKOnly, "Error in getting schedule.")
        End Try

        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = sRespOrg).ToList()
        Select Case filteredSchedules.Count
            Case 0
                'new schedule
                lblActualStart.Text = "Not Started"
                lblActualEnd.Text = "Not Completed"
                lblUploadDate.Text = "Not Exported"
                lblItemsFound.Text = "0"
                lblNotFound.Text = "0"
            Case Else
                lblActualStart.Text = filteredSchedules.Item(0).ActualStartDate.ToString
                lblActualEnd.Text = filteredSchedules.Item(0).CompletedDate.ToString
                lblUploadDate.Text = filteredSchedules.Item(0).UploadDate.ToString
                GetinventoryCounts()
        End Select
        Me.Refresh()
    End Sub
    Private Async Sub GetinventoryCounts()


        Dim inventoryAssets = Await ds.GetInventoryAssetsForDepartment(sRespOrg)

        Dim CountedAssets = inventoryAssets.Where(Function(x) x.Inventoried.HasValue = True).ToList
        Dim notCountedAssets = inventoryAssets.Where(Function(x) x.Inventoried.HasValue = False).ToList

        lblItemsFound.Text = CountedAssets.Count().ToString()
        lblNotFound.Text = notCountedAssets.Count().ToString()
        lblItemsFound.Refresh()
        lblNotFound.Refresh()
    End Sub
    Private Sub ExportCSV()
        Dim sfd As New SaveFileDialog()
        sfd.FileName = sRespOrg & " inventory status"
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog() = DialogResult.OK Then
            Using sw As StreamWriter = File.CreateText(sfd.FileName)

                Dim ColumnHeaders As String = "Department, Actual Start Date, Actual End Date, Upload Date, Items Counted, Items Not Counted"
                sw.WriteLine(ColumnHeaders)

                Dim StatusData As String = sRespOrg & "," & lblActualStart.Text & "," & lblActualEnd.Text & "," & lblUploadDate.Text & "," & lblItemsFound.Text & "," & lblNotFound.Text
                sw.WriteLine(StatusData)
            End Using

        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportCSV()
    End Sub
End Class