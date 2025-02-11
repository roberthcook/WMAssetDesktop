<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRevDiscrepancy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DataGridView1 = New DataGridView()
        btnExport = New Button()
        Label1 = New Label()
        btnAddtoFinal = New Button()
        btnDelete = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(22, 77)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1048, 402)
        DataGridView1.TabIndex = 0
        ' 
        ' btnExport
        ' 
        btnExport.Font = New Font("Segoe UI", 12F)
        btnExport.Location = New Point(915, 14)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(129, 50)
        btnExport.TabIndex = 8
        btnExport.Text = "Export to CSV File"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(22, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 21)
        Label1.TabIndex = 7
        Label1.Text = "Discrepancies:"
        ' 
        ' btnAddtoFinal
        ' 
        btnAddtoFinal.Font = New Font("Segoe UI", 12F)
        btnAddtoFinal.Location = New Point(33, 495)
        btnAddtoFinal.Name = "btnAddtoFinal"
        btnAddtoFinal.Size = New Size(129, 50)
        btnAddtoFinal.TabIndex = 9
        btnAddtoFinal.Text = "Add Selected Row to Final Inventory"
        btnAddtoFinal.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Font = New Font("Segoe UI", 12F)
        btnDelete.Location = New Point(210, 495)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(129, 50)
        btnDelete.TabIndex = 10
        btnDelete.Text = "Delete Selected Row"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' frmRevDiscrepancy
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(1082, 564)
        Controls.Add(btnDelete)
        Controls.Add(btnAddtoFinal)
        Controls.Add(btnExport)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Name = "frmRevDiscrepancy"
        Text = "Review Discrepancy"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnExport As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddtoFinal As Button
    Friend WithEvents btnDelete As Button
End Class
