Public Class frmImportMaster
    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub Read_MasterCSV()
        Dim MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(sFileName)
        MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        MyReader.Delimiters = New String() {","}
        MyReader.CommentTokens = New String() {""}
        MyReader.HasFieldsEnclosedInQuotes = True
        Dim currentRow As String()
        Dim sLastRespOrg As String = ""

        iRecCnt = 0
        While Not MyReader.EndOfData
            Try
                currentRow = MyReader.ReadFields()
                'skip header row
                If iRecCnt > 0 Then
                    sRespChart = currentRow(0)
                    sRespOrg = currentRow(1)
                    'If currentRow(3).TrimEnd = "" Or "-" Then
                    '    currentRow(3) = "Other"
                    'End If
                    sLocation = currentRow(2).TrimEnd & " / " & currentRow(3).TrimEnd
                    sRoom = currentRow(4)
                    sBarcode = currentRow(5)
                    sAssetDescription = currentRow(6)
                    sManufacturer = currentRow(7)
                    sMake = currentRow(8)
                    sModel = currentRow(9)
                    sSerialNumber = currentRow(10)
                    sPTag = currentRow(11)
                    sOTag = currentRow(12)
                    sAquired = currentRow(13)
                    sInventoried = currentRow(14)
                    sCustodian = currentRow(15)
                    sCustodianId = currentRow(16)
                    sEquipmentManager = currentRow(17)
                    sEquipmentManagerId = currentRow(18)
                    If Insert_MasterAsset() Then
                        iRecCnt = iRecCnt + 1
                        lblCnt.Text = iRecCnt.ToString
                        lblCnt.Refresh()
                        If sRespOrg <> sLastRespOrg Then
                            sLastRespOrg = sRespOrg
                            Add_Department(sRespOrg)
                        End If
                    End If
                End If
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message & " is invalid.  Skipping")
            End Try
            If iRecCnt = 0 Then
                iRecCnt = iRecCnt + 1
            End If
        End While
        iRecCnt = iRecCnt - 2 'adjust for header & EOD
        lblCnt.Text = iRecCnt.ToString
        lblCnt.Refresh()
        MyReader.Dispose()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            sFileName = OpenFileDialog1.FileName
            lblName.Text = sFileName
            lblName.Refresh()
        Else
            MsgBox("You must select a file to import!", vbOKOnly)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmViewImport
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        btnImport.Enabled = False
        Clear_MasterAsset()
        MsgBox("Clearing Master Assets Table")
        Clear_Departments()
        MsgBox("Clearing Departments")
        Read_MasterCSV()

        btnImport.Enabled = True
    End Sub

    Private Sub frmImportMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblName.Text = sFileName
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class