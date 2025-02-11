Imports System.Data.SqlClient

Public Class frmOrderRpt
    Private sCompany As String
    Private Sub frmOrderRpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MobJackDataSet.Orders' table. You can move, or remove it, as needed.
        '    Me.OrdersTableAdapter.Fill(Me.MobJackDataSet.Orders)
        'TODO: This line of code loads data into the 'MobJackDataSet.Orders' table. You can move, or remove it, as needed.
        '  Me.OrdersTableAdapter.Fill(Me.MobJackDataSet.Orders)
        'TODO: This line of code loads data into the 'MobJackDataSet.Orders' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MobJackDataSet.Orders' table. You can move, or remove it, as needed.
        '  Me.ReportViewer1.RefreshReport()

        Fill_Companys()

        Me.ReportViewer1.RefreshReport
    End Sub
    'Private Sub Fill_Customers()
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim i As Integer
    '    Dim localConn As New SqlConnection
    '    localConn = New SqlConnection
    '    localConn.ConnectionString = sConnString
    '    dt.Clear()

    '    Try
    '        localConn.Open()
    '        da = New SqlDataAdapter("SELECT Customers FROM Customers ORDER BY Customers ASC", localConn)
    '        da.Fill(dt)
    '        cbCustomer.Items.Clear()
    '        For i = 0 To dt.Rows.Count - 1
    '            cbCustomer.Items.Add(dt.Rows(i).Item(0).ToString)
    '        Next

    '    Catch SqlEx As SqlException
    '        MsgBox("SQL Error in FillComboCustomer()" & vbCrLf & vbCrLf & SqlEx.Message, , "SQL Error")
    '    Catch ex As Exception
    '        MsgBox("Error in FillComboCustomer()" & vbCrLf & vbCrLf & ex.Message, , "Error")
    '    Finally
    '        Try
    '            localConn.Close()
    '        Catch
    '        End Try
    '        Try
    '            localConn.Dispose()
    '        Catch
    '        End Try
    '    End Try
    'End Sub
    Private Sub Fill_Companys()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim localConn As New SqlConnection
        localConn = New SqlConnection
        localConn.ConnectionString = sConnString
        dt.Clear()

        Try
            localConn.Open()
            da = New SqlDataAdapter("SELECT Company FROM Company ORDER BY Company ASC", localConn)
            da.Fill(dt)
            cbCompany.Items.Clear()
            For i = 0 To dt.Rows.Count - 1
                cbCompany.Items.Add(dt.Rows(i).Item(0).ToString)
            Next

        Catch SqlEx As SqlException
            MsgBox("SQL Error in FillComboCompany()" & vbCrLf & vbCrLf & SqlEx.Message, , "SQL Error")
        Catch ex As Exception
            MsgBox("Error in FillComboCompany()" & vbCrLf & vbCrLf & ex.Message, , "Error")
        Finally
            Try
                localConn.Close()
            Catch
            End Try
            Try
                localConn.Dispose()
            Catch
            End Try
        End Try
    End Sub



    Private Sub cbCompany_Click(sender As Object, e As EventArgs) Handles cbCompany.Click

    End Sub

    Private Sub cbCompany_TextUpdate(sender As Object, e As EventArgs) Handles cbCompany.TextUpdate

    End Sub

    Private Sub cbCompany_TextChanged(sender As Object, e As EventArgs) Handles cbCompany.TextChanged
        sCompany = cbCompany.Text.Trim


    End Sub

    Private Sub cbCompany_VisibleChanged(sender As Object, e As EventArgs) Handles cbCompany.VisibleChanged

    End Sub

    Private Sub cbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCompany.SelectedIndexChanged

    End Sub

    Private Sub OrdersBindingSource_CurrentChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.OrdersTableAdapter.FilterDateCo(Me.MobJackDataSet.Orders, sCompany, DateTimePicker1.Value, DateTimePicker2.Value)


        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
    'TODO: This line of code loads data into the 'MobJackDataSet.Orders' table. You can move, or remove it, as needed.

End Class