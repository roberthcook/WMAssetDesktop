Imports WmAssetWebServiceClientNet
Imports WmAssetWebServiceClientNet.Models
Imports System.Net.Http
Imports System.Text
Imports System.IO
Public Class frmFinalInventory
    Dim bLoading As Boolean = True
    Dim strtDate As String = ""
    Dim endDate As String = ""
    Dim sActualStrt As String = ""
    Dim sActualEnd As String = ""
    Dim sCounted As String = ""
    Dim sNotCounted As String = ""

    Private Sub frmFinalInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbDpt.Items.Clear()


        Fill_Departments()
        '    Load_Datagrid()
    End Sub
    Private Sub Fill_Departments()
        Dim depts As IEnumerable(Of Department)

        Try
            depts = ds.GetDepartments().Result
        Catch ex As AggregateException
            MsgBox(ex.Message)
        End Try



        Dim lst As List(Of Department) = depts.ToList
        cbDpt.DataSource = lst
        cbDpt.DisplayMember = "DepartmentName"
        ' cbDepartments.Refresh()
        bLoading = False
    End Sub
    Private Sub Load_Datagrid()
        DataGridView1.DataSource = Nothing
        Dim fasst As IEnumerable
        Try
            fasst = ds.GetFinalInventoryAssetsForDepartment(sRespOrg).Result
        Catch ex As AggregateException
            MsgBox(ex.Message)
        End Try


        DataGridView1.DataSource = fasst
        DataGridView1.Columns(0).Visible = False
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersWidth = 90
        For i = 0 To 15
            DataGridView1.Columns(i).ReadOnly = True
        Next i
        DataGridView1.Columns(3).ReadOnly = False
        DataGridView1.Columns(4).ReadOnly = False
        DataGridView1.Columns(5).ReadOnly = False
        DataGridView1.Refresh()

    End Sub


    Private Sub cbDepartments_DataContextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim sfd As New SaveFileDialog
        sfd.FileName = sRespOrg & " FinalDept.csv"
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog = DialogResult.OK Then
            Using sw = File.CreateText(sfd.FileName)
                ' Dim dvg = DataGridView1.Columns.Cast(Of DataGridViewColumn).ToList.Select(Function(c) c.Name).ToList
                'write header
                Dim sHeader As String = vbCrLf & vbCrLf & "Department: " & sRespOrg & vbCrLf & "Date: " & Now() & vbCrLf
                sw.WriteLine(sHeader)

                Dim dgvColumnNames As String
                dgvColumnNames = "Location Code,Location,Room,PTag,Inventoried,Custodian,  ID,Equipment Manager,  ID"

                sw.WriteLine(dgvColumnNames)

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim rowData As New List(Of String)
                    For Each column As DataGridViewColumn In DataGridView1.Columns
                        If column.Index = 0 Or column.Index = 1 Or column.Index = 2 Or column.Index = 6 Or column.Index = 7 Or column.Index = 8 Or column.Index = 9 Or column.Index = 10 Or column.Index = 11 Or column.Index = 13 Or column.Index = 14 Then
                            'skip it
                        Else
                            If column.Index = 15 Then
                                rowData.Add(Format(Now, "Short Date"))
                            Else
                                rowData.Add(Convert.ToString(row.Cells(column.Name).Value))
                            End If
                        End If
                    Next
                    sw.WriteLine(String.Join(",", rowData))
                Next
            End Using
        End If
    End Sub
    Private Sub Export_CSVFinal()
        Dim sfd As New SaveFileDialog
        GetinventoryCounts()
        sfd.FileName = sRespOrg & " FinalDeptComplete.csv"
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog = DialogResult.OK Then
            Using sw = File.CreateText(sfd.FileName)
                'write schedule summary
                GetScheduleData()
                sw.WriteLine(vbCrLf & vbCrLf & "Schedule Results" & vbCrLf)
                sw.WriteLine("Scheduled Start Date: " & strtDate & "  " & "Scheduled End Date:" & endDate & vbCrLf)
                sw.WriteLine("Actual Start Date: " & sActualStrt & "  " & "Actual End Date:" & sActualEnd & vbCrLf)
                sw.WriteLine("Export Date: " & Format(Now, "Short Date") & vbCrLf)
                sw.WriteLine("Items Counted: " & sCounted & " Items Not Counted: " & sNotCounted & vbCrLf)
                '    MsgBox(sCounted & "," & sNotCounted, MsgBoxStyle.OkOnly)
                Dim sHeader As String = vbCrLf & vbCrLf & "Department: " & sRespOrg & "   " & "Date: " & Now() & vbCrLf & vbCrLf
                sw.WriteLine(sHeader)

                Dim dgvColumnNames As String
                dgvColumnNames = "Location Code,Location,Room,PTag,Inventoried,Custodian,  ID,Equipment Manager,  ID"

                sw.WriteLine(dgvColumnNames)

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim rowData As New List(Of String)
                    For Each column As DataGridViewColumn In DataGridView1.Columns
                        If column.Index = 0 Or column.Index = 1 Or column.Index = 2 Or column.Index = 6 Or column.Index = 7 Or column.Index = 8 Or column.Index = 9 Or column.Index = 10 Or column.Index = 11 Or column.Index = 13 Or column.Index = 14 Then
                            'skip it
                        Else
                            If column.Index = 15 Then
                                rowData.Add(Format(Now, "Short Date"))
                            Else
                                rowData.Add(Convert.ToString(row.Cells(column.Name).Value))
                            End If
                        End If
                    Next
                    sw.WriteLine(String.Join(",", rowData))
                Next
            End Using
        End If
    End Sub
    Private Async Sub GetinventoryCounts()
        sCounted = "0"
        sNotCounted = "0"
        Dim inventoryAssets = Await ds.GetInventoryAssetsForDepartment(sRespOrg)
        '  System.Threading.Thread.Sleep(2000) ' Wait for 1th second to allow the server to process the request
        Dim CountedAssets = inventoryAssets.Where(Function(x) x.Inventoried.HasValue = True).ToList
        Dim notCountedAssets = inventoryAssets.Where(Function(x) x.Inventoried.HasValue = False).ToList

        sCounted = CountedAssets.Count().ToString()
        sNotCounted = notCountedAssets.Count().ToString()
    End Sub
    'Private Sub GetCountsandWaitOnResult()
    '    Dim T As Task = GetinventoryCounts()
    'End Sub

    Private Sub GetScheduleData()

        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result
        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = sRespOrg).ToList()
        Select Case filteredSchedules.Count
            Case 0
                MsgBox("Schedule not found for " & sRespOrg, vbOKOnly, "Data Missing")
            Case Else

                strtDate = filteredSchedules.Item(0).StartDate
                endDate = filteredSchedules.Item(0).EndDate
                sActualStrt = filteredSchedules.Item(0).ActualStartDate.ToString
                sActualEnd = filteredSchedules.Item(0).CompletedDate.ToString

        End Select
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub



    Private Sub cbDpt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDpt.SelectedIndexChanged
        If bLoading = False Then
            sRespOrg = cbDpt.Text
            Load_Datagrid()
        End If
    End Sub



    Private Sub btnCompleteInv_Click(sender As Object, e As EventArgs) Handles btnCompleteInv.Click
        Dim confirmed = MessageBox.Show("Are you sure you want to complete the inventory? This is the final step in the inventory process and the inventory will be completed.", "Confirm Complete Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmed = DialogResult.Yes Then
            If CheckforDiscrepancy(sRespOrg) Then
                UpdatesheduleFinal(sRespOrg)
                Export_CSVFinal()
                confirmed = MessageBox.Show("Did final export complete OK?", "Confirm Final Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmed = DialogResult.Yes Then
                    Delete_SchedulebyDept(sRespOrg)

                    'delete work inventory by department

                    ds.DeleteInventoryAssetsForDepartment(sRespOrg)

                    'delete discrepancies by dept

                    ds.DeleteDiscrepanciesForDepartment(sRespOrg)

                    ds.DeleteFinalInventoryAssetsForDepartment(sRespOrg)

                    DataGridView1.DataSource = Nothing
                    DataGridView1.Refresh()
                End If
            Else
                MsgBox("You must resolve discrepancy for " & sRespOrg & "before move to final!", vbOKOnly, "Discrepancy")
            End If
        End If



    End Sub
    Private Function CheckForDiscrepancy(ByVal Dept As String)
        Dim bRslt As Boolean = False
        Dim iDescrep As IEnumerable(Of Discrepancy)
        iDescrep = ds.GetDiscrepancies().Result
        Dim filteredDiscrepancy As List(Of Discrepancy) = iDescrep.Where(Function(s) s.ActualOrganization = sRespOrg).ToList()
        Select Case filteredDiscrepancy.Count
            Case 0
                bRslt = True
            Case Else
        End Select
        Return bRslt
    End Function
    Private Sub btnExport_All_Click(sender As Object, e As EventArgs) Handles btnExport_All.Click
        Dim sfd As New SaveFileDialog
        sfd.FileName = sRespOrg & " Final Review All"
        sfd.Filter = "CSV File | *.csv"
        If sfd.ShowDialog = DialogResult.OK Then
            Using sw = File.CreateText(sfd.FileName)
                Dim dgvColumnNames = DataGridView1.Columns.
                    Cast(Of DataGridViewColumn).ToList.
                    Select(Function(c) c.Name).ToList

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