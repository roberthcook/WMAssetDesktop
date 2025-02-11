
Imports WmAssetWebServiceClientNet.Models
Imports WmAssetWebServiceClientNet
Imports System.Net.Http
Imports MicWrapper


Module modData

    Public iRecCnt As Int16 = 0
    Public sFileName As String
    Public sDFileName As String
    Public bAssFound As Boolean
    Public sPTag As String
    Public sOTag As String
    Public sBarcode As String
    Public sLocation As String
    Public sLocChange As String
    Public sRoom As String
    Public sRoomChange As String
    Public sAssetDescription As String
    Public sManufacturer As String
    Public sMake As String
    Public sModel As String
    Public sSerialNumber As String
    Public sInventoried As String
    Public sRespOrg As String
    Public sRespChart As String
    Public sAquired As String
    Public sCustodian As String
    Public sCustodianId As String
    Public sEquipmentManager As String
    Public sEquipmentManagerId As String
    Public sDateScanned As String
    Public sPtagDate As String
    Public sType As String
    Public sFundAmt As String
    Public sPrimarytag As String
    Public sDisposeAmt As String
    Public sDisposeDate As String
    Public sDisposeMethod As String
    Public iId As Int16

    Public sCapAmt As String
    Public sDeprAmt As String
    Public sDeprStart As String
    Public ds As AssetDataRepository
    Public httpClient As HttpClient
    Public objAuth As Auth
    Public user As CurrentUser






    Public Function InsertSchedule(StartDte As Date, EndDte As Date) As Boolean
        Dim bRslt As Boolean = False


        Dim NewSchedule As New Schedule With {
        .Department = sRespOrg,
        .StartDate = StartDte,
        .EndDate = EndDte,
        .Completed = False}

        Try
            Dim sched = ds.CreateSchedule(NewSchedule).Result

        Catch ex As AggregateException
            'ignore was probably duplicate key
        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

        bRslt = True
        Return bRslt
    End Function

    Public Function UpdateSchedule(StartDte As Date, EndDte As Date, bComplete As Boolean, upDate As Date, CompleteDate As Date) As Boolean
        Dim bRslt As Boolean = False


        Dim NewSchedule As New Schedule With {
         .Id = iId,
        .Department = sRespOrg,
        .StartDate = StartDte,
        .EndDate = EndDte,
        .UploadDate = upDate,
        .CompletedDate = CompleteDate,
        .Completed = bComplete}

        Try
            Dim sched = ds.UpdateSchedule(NewSchedule)
        Catch ex As AggregateException
            'ignore was probably duplicate key
        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

        bRslt = True
        Return bRslt
    End Function
    Public Function DeleteSchedule(ByVal ID As Int16) As Boolean
        Dim bRslt As Boolean = False
        Try
            Dim sched = ds.DeleteSchedule(ID)
        Catch ex As AggregateException

        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

        bRslt = True
        Return bRslt
    End Function

    Public Function Insert_MasterAsset() As Boolean
        Dim bRslt As Boolean = True
        Dim dAcquired As Date
        Dim dInventoried As Date
        Try
            dAcquired = sAquired
        Catch ex As Exception
            dAcquired = ""
        End Try
        Try
            dInventoried = sInventoried
        Catch ex As Exception
            dInventoried = ""
        End Try


        Dim NewAsset As New Asset With {
        .RespChart = sRespChart,
        .ResponsibleOrganization = sRespOrg,
        .Location = sLocation,
        .Room = sRoom,
        .Barcode = sBarcode,
        .AssetDescription = sAssetDescription,
        .Manufacturer = sManufacturer,
        .Make = sMake,
        .Model = sModel,
        .SerialNumber = sSerialNumber,
        .Ptag = sPTag,
        .Otag = sOTag,
        .Acquired = dAcquired,
        .Inventoried = dInventoried,
        .Custodian = sCustodian,
        .CustodianId = sCustodianId,
        .EquipmentManager = sEquipmentManager,
        .EquipmentId = sEquipmentManagerId}
        Try
            Dim asset = ds.CreateAsset(NewAsset).Result

        Catch ex As AggregateException
            MsgBox(ex.Message, vbOKOnly, "Error in create asset")

            bRslt = False
        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)


        Return bRslt
    End Function
    Public Function Insert_DisposedAsset() As Boolean
        Dim bRslt As Boolean = False
        Dim dScanDate As Date = Now()
        Dim dAcquired As Date
        Dim dDisposed As Date
        Dim dPtagDate As Date
        Dim dDeprStart As Date
        Try
            dAcquired = sAquired
        Catch ex As Exception
            dAcquired = Nothing
        End Try
        Try
            dDisposed = sDisposeDate
        Catch ex As Exception
            dDisposed = Nothing
        End Try

        Try
            dPtagDate = sPtagDate
        Catch ex As Exception
            dPtagDate = Nothing
        End Try
        Try
            dDeprStart = sDeprStart
        Catch ex As Exception
            dDeprStart = Nothing
        End Try

        Dim NewDisposed As New DisposedAsset With {
            .Found = False,
            .Location = "",
            .Room = "",
            .DateScanned = dScanDate,
            .Ptag = sPTag,
            .SerialNumber = sSerialNumber,
            .Description = sAssetDescription,
            .PtagDate = dPtagDate,
            .Type = sType,
            .Otag = sOTag,
            .PrimaryTag = sPrimarytag,
            .Barcode = sBarcode,
            .ResponsibleOrganization = sRespOrg,
            .Acquired = dAcquired,
            .Disposed = dDisposed,
            .DisposalMethod = sDisposeMethod,
            .FundAmt = sFundAmt,
            .CapAmt = sCapAmt,
            .DeprAmt = sDeprAmt,
            .DeprStart = dDeprStart
            }
        Try
            Dim DisAsset = ds.CreateDisposedAsset(NewDisposed).Result

        Catch ex As AggregateException
            MsgBox(ex.Message, vbOKOnly, "Error in create disposed asset")
        End Try
        bRslt = True
        Return bRslt
    End Function
    Public Function Archive_Inventory(ByRef Dept As String) As Boolean
        Dim bRslt As Boolean
        Try
            ds.ArchiveInventoryAssetsForDepartment(Dept)
            bRslt = True
        Catch ex As AggregateException
            MsgBox(ex.Message)
            bRslt = False
        End Try
        Return bRslt
    End Function
    Public Function Delete_Inventory(ByRef Dept As String) As Boolean
        Dim bRslt As Boolean
        Try
            ' ds.Delete(Dept)
            bRslt = True
        Catch ex As AggregateException
            MsgBox(ex.Message)
            bRslt = False
        End Try
        Return bRslt
    End Function
    Public Function Clear_MasterAsset() As Boolean
        Dim bRslt As Boolean = True
        Try
            ds.DeleteAllAssets()
        Catch ex As AggregateException
            MsgBox(ex.Message, vbOKOnly, "Error in Clear Master Assets")
            bRslt = False
        End Try
        'If Not AssetDataRepository.DeleteAllAssets.IsCompletedSuccessfully Then
        '    Dim unsused = AssetDataRepository.DeleteAllAssets.
        ' Else
        '    bRslt = True
        '    ' MessageBox("Result =" & unsused)
        'End If

        Return bRslt
    End Function
    Public Function Clear_Departments() As Boolean
        Dim bRslt As Boolean = True
        Try
            ds.DeleteAllDepartments()
        Catch ex As AggregateException
            MsgBox(ex.Message, vbOKOnly, "Error in Clear Departments")
            bRslt = False
        End Try
        'If Not AssetDataRepository.DeleteAllAssets.IsCompletedSuccessfully Then
        '    Dim unsused = AssetDataRepository.DeleteAllAssets.
        ' Else
        '    bRslt = True
        '    ' MessageBox("Result =" & unsused)
        'End If

        Return bRslt
    End Function

    Public Function Clear_DisposedAsset() As Boolean
        Dim bRslt As Boolean = True


        Try
            ds.DeleteAllDisposedAssets()
        Catch ex As AggregateException
            MsgBox(ex.Message, vbOKOnly, "Error in Clear Disposed Assets")
        End Try


        Return bRslt
    End Function
    Public Function Add_Department(ByVal Dept As String) As Boolean
        Dim bRslt As Boolean = False

        Dim NewDepartment As New Department With {
        .Id = 0,
        .DepartmentName = sRespOrg
        }

        Try
            Dim Department = ds.CreateDepartment(NewDepartment).Result

        Catch ex As AggregateException
            'ignore was probably duplicate key
        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

        bRslt = True
        Return bRslt
    End Function
    Public Function UpdatesheduleFinal(ByVal Dept As String) As Boolean
        Dim bRslt As Boolean = False
        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result

        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = Dept).ToList()



        Select Case filteredSchedules.Count
            Case 0
                'schedule does not exist
            Case Else

                bRslt = True
                iId = filteredSchedules.Item(0).Id
                Dim NewSchedule As New Schedule With {
                     .Id = iId,
                     .Department = filteredSchedules.Item(0).Department,
                    .StartDate = filteredSchedules.Item(0).StartDate,
                    .ActualStartDate = filteredSchedules.Item(0).ActualStartDate,
                    .EndDate = filteredSchedules.Item(0).EndDate,
                      .CompletedDate = Format(Now(), "MM/dd/yyyy"),
                     .UploadDate = Format(Now(), "MM/dd/yyyy"),
                     .Completed = True}


                Try
                    Dim sched = ds.UpdateSchedule(NewSchedule)
                Catch ex As AggregateException

                End Try

                ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

                bRslt = True
                Return bRslt
        End Select


        Return bRslt
    End Function
    Public Function UpdatesheduleBeforeFinal(ByVal Dept As String) As Boolean
        Dim bRslt As Boolean = False
        Dim schedules As IEnumerable(Of Schedule)
        schedules = ds.GetSchedules().Result

        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = Dept).ToList()



        Select Case filteredSchedules.Count
            Case 0
                'schedule does not exist
            Case Else

                bRslt = True
                iId = filteredSchedules.Item(0).Id
                Dim NewSchedule As New Schedule With {
                     .Id = iId,
                     .Department = filteredSchedules.Item(0).Department,
                    .StartDate = filteredSchedules.Item(0).StartDate,
                    .ActualStartDate = filteredSchedules.Item(0).ActualStartDate,
                    .EndDate = filteredSchedules.Item(0).EndDate,
                    .CompletedDate = filteredSchedules.Item(0).CompletedDate,
                    .UploadDate = filteredSchedules.Item(0).UploadDate,
                    .Completed = True}
                Try
                    Dim sched = ds.UpdateSchedule(NewSchedule)
                Catch ex As AggregateException

                End Try

                ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

                bRslt = True
                Return bRslt
        End Select


        Return bRslt
    End Function
    Public Function Delete_SchedulebyDept(ByVal Dept As String) As Boolean
        Dim bRslt As Boolean = False
        Dim schedules As IEnumerable(Of Schedule)
        Try
            schedules = ds.GetSchedules().Result
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "Error in get schedules")
        End Try

        Dim filteredSchedules As List(Of Schedule) = schedules.Where(Function(s) s.Department = Dept).ToList()
        Select Case filteredSchedules.Count
            Case 0
                'schedule does not exist
            Case Else

                bRslt = True
                iId = filteredSchedules.Item(0).Id
                Try
                    Dim sched = ds.DeleteSchedule(iId)
                Catch ex As AggregateException

                End Try



                bRslt = True
        End Select
        Return bRslt
    End Function
End Module
