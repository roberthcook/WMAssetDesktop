Public Class frmImportDisposed
    Private Sub Read_DisposedCSV()
        Dim MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(sFileName)
        MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        MyReader.Delimiters = New String() {","}
        MyReader.CommentTokens = New String() {""}
        MyReader.HasFieldsEnclosedInQuotes = True
        Dim currentRow As String()
        iRecCnt = 0
        While Not MyReader.EndOfData
            Try
                currentRow = MyReader.ReadFields()
                'skip header row
                If iRecCnt > 0 Then
                    sPTag = currentRow(0)
                    sAssetDescription = currentRow(1)
                    sSerialNumber = currentRow(2)
                    sPtagDate = currentRow(3)
                    sType = currentRow(4)
                    sOTag = currentRow(5)
                    sPrimarytag = currentRow(6)
                    sBarcode = currentRow(7)
                    sRespOrg = currentRow(8)
                    sAquired = currentRow(9)
                    sDisposeDate = currentRow(10)
                    sDisposeMethod = currentRow(11)
                    sFundAmt = currentRow(12)
                    sCapAmt = currentRow(13)
                    sDeprAmt = currentRow(14)
                    sDeprStart = currentRow(15)
                    If Insert_DisposedAsset() Then
                        iRecCnt = iRecCnt + 1
                        lblCnt.Text = iRecCnt.ToString
                        lblCnt.Refresh()
                    End If
                End If
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message & " is invalid.  Skipping")
            End Try
            If iRecCnt = 0 Then
                iRecCnt = iRecCnt + 1
            End If
        End While
        iRecCnt = iRecCnt - 1 'adjust for header
        lblCnt.Text = iRecCnt.ToString
        lblCnt.Refresh()
        MyReader.Dispose()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        btnImport.Enabled = False
        Clear_DisposedAsset()
        '  Clear_Departments()
        MsgBox("Clearing Disposed Assets Table")
        btnImport.Enabled = True
        Read_DisposedCSV()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmViewDisposeImport
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            sFileName = OpenFileDialog1.FileName
            lblName.Text = sFileName
            lblName.Refresh()
        Else
            MsgBox("You must select a file to import!", vbOKOnly)
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub
End Class