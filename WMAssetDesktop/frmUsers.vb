Imports WmAssetWebServiceClientNet.Models

Public Class frmUsers
    Dim bLoading As Boolean = True
    Dim sUserID As String
    Dim sName As String
    Dim sDept As String
    Dim bUpdate As Boolean = False



    Private Sub Fill_Departments()
        Dim bRslt As Boolean = False

        Dim depts As IEnumerable(Of Department)
        depts = ds.GetDepartments().Result
        Dim ls As List(Of Department) = depts.ToList
        cbAssignDept.DataSource = ls
        cbAssignDept.DisplayMember = "DepartmentName"
        cbAssignDept.Refresh()
        'cbRemoveDept.DataSource = ls
        'cbRemoveDept.DisplayMember = "DepartmentName"
        'cbRemoveDept.Refresh()
        txtUserID.Focus()
        lstDept.Items.Clear()
        lstDept.Refresh()
        btnSave.Enabled = False
    End Sub
    Public Function UpdateUser() As Boolean
        Dim bRslt As Boolean = False

        Dim NewUser As New User With {
         .Id = iId,
        .UserId = txtUserID.Text,
        .UserName = txtName.Text,
        .Departments = sDept,
        .AllDepartments = chkAllDept.Checked}

        Try
            Dim user = ds.UpdateUser(NewUser)

        Catch ex As AggregateException
            'ignore was probably duplicate key
        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

        bRslt = True
        Return bRslt
    End Function
    Private Sub Getuser()

        Dim iCnt As Int16
        Dim Users As IEnumerable(Of User)
        Users = ds.GetUsers().Result
        Dim filteredUsers As List(Of User) = Users.Where(Function(s) s.UserId = sUserID).ToList()
        iCnt = filteredUsers.Count
        If iCnt = 0 Then
            lblType.Text = "New User"
            lblType.Refresh()
            lstDept.Items.Clear()
            lstDept.Refresh()
            btnSave.Enabled = True
        Else
            lstDept.Items.Clear()
            lblType.Text = "Current User"
            lblType.Refresh()
            bUpdate = True
            iId = filteredUsers.Item(0).Id
            txtUserID.Text = filteredUsers.Item(0).UserId
            txtName.Text = filteredUsers.Item(0).UserName
            sDept = filteredUsers.Item(0).Departments
            chkAllDept.Checked = filteredUsers.Item(0).AllDepartments

            Dim list As New ArrayList
            list.AddRange(sDept.Split(","c))
            For i = 0 To list.Count - 1
                lstDept.Items.Add(list.Item(i))
            Next
            btnSave.Enabled = True
            lstDept.Refresh()
        End If

    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Fill_Departments()
        bLoading = False
    End Sub
    Public Function InsertUser() As Boolean
        Dim bRslt As Boolean = False

        Dim Newuser As New User With {
        .UserId = sUserID,
        .UserName = sName,
        .Departments = sDept,
        .AllDepartments = chkAllDept.Checked}

        Try
            Dim user = ds.CreateUser(Newuser).Result

        Catch ex As AggregateException
            'ignore was probably duplicate key
        End Try

        ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

        bRslt = True
        Return bRslt
    End Function
    'Public Function DeleteUser() As Boolean
    '    Dim bRslt As Boolean = False

    '    Try
    '        Dim user = ds.DeleteUser(iId)

    '    Catch ex As AggregateException
    '        'ignore was probably duplicate key
    '    End Try

    '    ' MsgBox("Asset ID=" & asset.Id & " " & asset.Barcode)

    '    bRslt = True
    '    Return bRslt
    'End Function
    Private Sub cbAssignDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAssignDept.SelectedIndexChanged
        If Not bLoading Then
            Dim bAdd As Boolean = True
            sDept = cbAssignDept.Text
            Dim i As Int16
            For i = 0 To lstDept.Items.Count - 1
                If sDept = lstDept.Items(i) Then
                    bAdd = False
                    Exit For
                End If
            Next
            If bAdd Then
                lstDept.Items.Add(sDept)
                lstDept.Refresh()
            End If
        End If

    End Sub

    Private Sub txtUserID_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With lstDept
            .Items.Remove(lstDept.SelectedItem)
            lstDept.Refresh()
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        sDept = ""
        For i = 0 To lstDept.Items.Count - 1
            If lstDept.Items(i).trim <> "" Then
                If i = 0 Then
                    sDept = lstDept.Items(i)
                Else
                    sDept = sDept & "," & lstDept.Items(i)
                End If
            End If
        Next
        If bUpdate Then
            UpdateUser()
        Else
            InsertUser()
        End If
        lstDept.Items.Clear()
        lstDept.Refresh()
        txtName.Text = ""
        txtUserID.Text = ""
        txtUserID.Focus()
        btnSave.Enabled = False

    End Sub

    Private Sub txtUserID_TextChanged(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        sName = txtName.Text
    End Sub

    Private Sub chkAllDept_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllDept.CheckedChanged
        If chkAllDept.Checked Then
            lstDept.Items.Clear()
        End If
    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
    End Sub

    Private Sub txtUserID_GotFocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus

    End Sub

    Private Sub txtUserID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserID.KeyPress
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(9) Then
            e.Handled = True
            If txtUserID.Text.Length = 0 Then
                MsgBox("You must enter a User ID!", MsgBoxStyle.OkOnly, "Required Entry")
                txtUserID.Focus()
            Else
                sUserID = txtUserID.Text
                Getuser()
                txtName.Focus()
            End If
        End If


    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim f As New frmViewUsers
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub
End Class