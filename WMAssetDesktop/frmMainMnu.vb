Imports System.ComponentModel
Imports System.Net.Http
Imports System.Threading
Imports MicWrapper
Imports WmAssetWebServiceClientNet

Public Class frmMainMnu
    Dim bSuccess As Boolean = False
    Dim t1 As System.Threading.Timer
    Dim ds As AssetDataRepository
    Dim httpClient As HttpClient
    Dim objAuth As Auth
    Dim user As CurrentUser
    Dim authTime As DateTime



    Private Async Sub BtnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Await LoginRefresh()
        If Not (user Is Nothing) Then
            authTime = DateTime.Now
            MsgBox(user.DisplayName)
        End If
        If bSuccess Then
            ' MsgBox(user.DisplayName)
            Enable_Buttons()
        Else
            btnLogin.Enabled = True
        End If
    End Sub

    Private Async Function LoginRefresh() As Task
        objAuth = New Auth(New AzureAdOptions() With {
            .Instance = "https://login.microsoftonline.com/",
            .TenantId = "20fdd699-f9d9-45d6-93ec-1453b137984d",
            .ClientId = "f6e51cba-8a52-4dd7-8110-b3fb45849af7",
            .RedirectUri = "http://localhost",
            .Scopes = "api://316a6911-ae25-43b2-95fc-3fd1d504f7b3/api.read",
            .GraphScopes = "user.read"})

        user = Await objAuth.Authenticate(Me.Handle)
        If Not (user Is Nothing) Then

            Dim tsInterval As TimeSpan = user.TokenExpiration - DateTime.Now
            Dim refreshInterval As Integer = 1 + tsInterval.TotalMilliseconds
            SetupTokenTimer(refreshInterval)
            bSuccess = True
        End If
    End Function

    Private Sub SetupTokenTimer(interval As Integer)
        ' Instantiate a new system.threading.timer and specify its callback function.
        t1 = New System.Threading.Timer(AddressOf TokenTimerCallback, Nothing, interval, Timeout.Infinite)
    End Sub

    Private Async Sub TokenTimerCallback(ByVal state As Object)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() TokenTimerCallback(state))
            Return
        End If

        If DateDiff(DateInterval.Minute, authTime, DateTime.Now) < 2 Then
            Await LoginRefresh()
        Else
            Call btnLogout_Click(Nothing, Nothing)
        End If
    End Sub



    Private Sub Disable_Buttons()
        btnComments.Enabled = False
        btnFinalInv.Enabled = False
        btnImport.Enabled = False
        btnImportDisposed.Enabled = False
        btnInvStatus.Enabled = False
        btnReviewDiscrepancy.Enabled = False
        btnSchedule.Enabled = False
        btnUsers.Enabled = False
        btnReviewInv.Enabled = False
    End Sub
    Private Sub Enable_Buttons()
        btnComments.Enabled = True
        btnFinalInv.Enabled = True
        btnImport.Enabled = True
        btnImportDisposed.Enabled = True
        btnInvStatus.Enabled = True
        btnReviewDiscrepancy.Enabled = True
        btnSchedule.Enabled = True
        btnUsers.Enabled = True
        btnReviewInv.Enabled = True
    End Sub
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim f As New frmImportMaster
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub btnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click
        Dim f As New frmSchedule
        Try
            f.ShowDialog()
        Catch ex As Exception
        End Try
        f.Dispose()
    End Sub

    Private Sub btnImportDisposed_Click(sender As Object, e As EventArgs) Handles btnImportDisposed.Click
        Dim f As New frmImportDisposed
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub



    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        Dim f As New frmUsers
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub btnComments_Click(sender As Object, e As EventArgs) Handles btnComments.Click
        Dim f As New frmComments
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub
    Private Sub btnReviewInv_Click(sender As Object, e As EventArgs) Handles btnReviewInv.Click
        Dim f As New frmReViewInventory
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub btnReviewDiscrepancy_Click(sender As Object, e As EventArgs) Handles btnReviewDiscrepancy.Click
        Dim f As New frmRevDiscrepancy
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnFinalInv_Click(sender As Object, e As EventArgs) Handles btnFinalInv.Click
        Dim f As New frmFinalInventory
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    Private Sub btnInvStatus_Click(sender As Object, e As EventArgs) Handles btnInvStatus.Click
        Dim f As New frmInventoryStatus
        Try
            f.ShowDialog()
        Catch ex As Exception

        End Try
        f.Dispose()
    End Sub

    'Private Async Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

    '    'objAuth = New Auth(New AzureAdOptions() With {
    '    '    .Instance = "https://login.microsoftonline.com/",
    '    '    .TenantId = "20fdd699-f9d9-45d6-93ec-1453b137984d",
    '    '    .ClientId = "f6e51cba-8a52-4dd7-8110-b3fb45849af7",
    '    '    .RedirectUri = "http://localhost",
    '    '    .Scopes = "api://316a6911-ae25-43b2-95fc-3fd1d504f7b3/api.read",
    '    '    .GraphScopes = "user.read"})

    '    'user = Await objAuth.Authenticate(Me.Handle)
    '    ''   Dim tsInterval As TimeSpan = user.TokenExpiration - DateTime.Now
    '    ''  Dim refreshInterval As Integer = 1 + tsInterval.TotalMilliseconds
    '    ''   MsgBox(user.DisplayName,, refreshInterval.ToString())

    '    ''  Dim timer1 As Threading.Thread.timer

    '    Enable_Buttons()
    '    ds.SetAccessToken(user.ApiToken)
    'End Sub

    Private Async Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Try
            Await (objAuth.Logout)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
        Disable_Buttons()
        btnLogin.Enabled = True

    End Sub

    Private Async Sub frmMainMnu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Await (objAuth.Logout)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMainMnu_Load(sender As Object, e As EventArgs) Handles Me.Load
        '' instantiate our httpclient


        httpClient = New HttpClient With {
            .BaseAddress = New Uri(sUrl)}

        '' create an instance of the AssetDataRepository
        ds = New AssetDataRepository(httpClient)
        Disable_Buttons()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Disposed(sender As Object, e As EventArgs)

    End Sub
End Class
