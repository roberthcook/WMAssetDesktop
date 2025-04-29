
Imports WmAssetWebServiceClientNet.Models
Public Class frmSchedule
    Public bUpdate As Boolean = False
    Public bLoading As Boolean = True

    Dim dStartDate As Date
    Dim dEndDate As Date
    Dim dCompleteDate As Date
    Dim dUpLoadDate As Date
    Dim bComplete As Boolean

    Private Sub frmSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bUpdate = False
        btnView.Enabled = False
        lblDownload.Visible = False
        lblCnt.Visible = False
        Fill_Departments()
        btnSave.Enabled = False
        ' btnDelete.Enabled = False

    End Sub
    Private Sub Fill_Departments()
        Dim bRslt As Boolean = False
        cbDpt.Items.Clear()
        Dim depts As IEnumerable(Of Department)
        depts = ds.GetDepartments().Result
        Dim lst As List(Of Department) = depts.ToList
        cbDpt.DataSource = lst
        cbDpt.DisplayMember = "DepartmentName"
        ' cbDepartments.Refresh()
        bLoading = False
    End Sub
    Private Sub GetDepartmentSchedule()
        lblDownload.Visible = False
        lblCnt.Visible = False

        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result
        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = sRespOrg).ToList()
        Select Case filteredSchedules.Count
            Case 0
                'new schedule
                lblStatus.Text = "New Schedule"
                lblDept.Text = sRespOrg
                lblActualStart.Text = "Not Started"
                lblActualEnd.Text = "Not Completed"
                StartDte.Value = Now()
                EndDate.Value = Now()
                '   btnDelete.Enabled = False
                btnSave.Enabled = True
            Case Else
                bUpdate = True
                lblStatus.Text = "Current Schedule"
                lblDept.Text = sRespOrg
                iId = filteredSchedules.Item(0).Id
                StartDte.Value = filteredSchedules.Item(0).StartDate
                EndDate.Value = filteredSchedules.Item(0).EndDate
                lblActualStart.Text = filteredSchedules.Item(0).ActualStartDate.ToString
                lblActualEnd.Text = filteredSchedules.Item(0).CompletedDate.ToString
                If filteredSchedules.Item(0).CompletedDate IsNot Nothing Then
                    dCompleteDate = filteredSchedules.Item(0).CompletedDate
                End If
                lblUploadDate.Text = filteredSchedules.Item(0).UploadDate.ToString
                If filteredSchedules.Item(0).UploadDate IsNot Nothing Then
                    dUpLoadDate = filteredSchedules.Item(0).UploadDate
                End If
                lblActualEnd.Text = filteredSchedules.Item(0).CompletedDate.ToString
                If filteredSchedules.Item(0).Completed = True Then
                    chkComplete.CheckState = CheckState.Checked
                Else
                    chkComplete.CheckState = CheckState.Unchecked
                End If

                '   chkComplete.CheckState = filteredSchedules.Item(0).Completed
                bComplete = filteredSchedules.Item(0).Completed
                '    btnDelete.Enabled = True
                btnSave.Enabled = True
        End Select
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        iRecCnt = 0
        If bUpdate = False Then

            If InsertSchedule(StartDte.Value, EndDate.Value) Then
                lblDownload.Visible = True
                lblCnt.Visible = True
                PopulateCurrentInvnetoryForDepartment(sRespOrg)
                btnView.Enabled = True
                btnSave.Enabled = False
                lblActualStart.Text = ""
                lblActualEnd.Text = ""
                lblStatus.Text = ""
                lblDept.Text = ""
            End If
        Else
            If UpdateSchedule(StartDte.Value, EndDate.Value, bComplete, dUpLoadDate, dCompleteDate) Then
                lblDownload.Visible = False
                lblCnt.Visible = False
                btnView.Enabled = True
                btnSave.Enabled = False
                lblStatus.Text = ""
                lblActualStart.Text = ""
                lblActualEnd.Text = ""
                lblDept.Text = ""
                'UpdateSchedule()
            End If
        End If

    End Sub
    Public Sub PopulateCurrentInvnetoryForDepartment(dept As String)
        'clear Current inventory

        Try

        Catch ex As Exception

        End Try

        Dim assets As IEnumerable(Of Asset) = ds.GetAssetsForDepartment(dept).Result

        For Each asset As Asset In assets
            Dim inventoryAsset As New InventoryAsset() With {
            .Found = False,
            .Discrepancy = False,
            .Location = asset.Location,
            .ResponsibleOrganization = dept,
            .Barcode = asset.Barcode,
            .Room = asset.Room,
            .AssetDescription = asset.AssetDescription,
            .Comment = "",
            .Archived = False}
            Try
                inventoryAsset = ds.CreateInventoryAsset(inventoryAsset).Result
            Catch ex As Exception

            End Try

            If Not (inventoryAsset.Id = Nothing) And (inventoryAsset.Id > 0) Then
                iRecCnt = iRecCnt + 1
                lblCnt.Text = iRecCnt.ToString
                lblCnt.Refresh()

                'created
            Else

            End If

        Next
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmViewSchedules
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub


    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim f As New frmDeptDownLoad
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub
    Private Sub cbDpt_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbDpt.SelectedIndexChanged
        If bLoading Then
        Else
            sRespOrg = cbDpt.Text
            GetDepartmentSchedule()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        'Dim confirmed = MessageBox.Show("Are you sure? Current Inventory will be removed.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If confirmed = DialogResult.Yes Then
        '    'Try
        '    '    ds.(sRespOrg)
        '    'Catch ex As Exception

        '    'End Try
        '    Try
        '        ds.DeleteSchedule(iId)
        '    Catch ex As Exception

        '    End Try

        'End If

    End Sub

    Private Sub chkComplete_CheckStateChanged(sender As Object, e As EventArgs) Handles chkComplete.CheckStateChanged
        If CheckState.Checked Then
            bComplete = True
        Else
            bComplete = False
        End If
    End Sub
End Class