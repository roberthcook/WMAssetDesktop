<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReViewInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReViewInventory))
        DataGridView1 = New DataGridView()
        cbDepartments = New ComboBox()
        Label1 = New Label()
        btnDelete = New Button()
        btnExport = New Button()
        btnMovetoFinal = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 86)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1290, 535)
        DataGridView1.TabIndex = 0
        ' 
        ' cbDepartments
        ' 
        cbDepartments.Font = New Font("Segoe UI", 12F)
        cbDepartments.FormattingEnabled = True
        cbDepartments.Location = New Point(12, 38)
        cbDepartments.Name = "cbDepartments"
        cbDepartments.Size = New Size(367, 29)
        cbDepartments.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 21)
        Label1.TabIndex = 3
        Label1.Text = "Select Department:"
        ' 
        ' btnDelete
        ' 
        btnDelete.Font = New Font("Segoe UI", 12F)
        btnDelete.Location = New Point(26, 627)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(156, 37)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete Selected Row"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnExport
        ' 
        btnExport.Font = New Font("Segoe UI", 12F)
        btnExport.Location = New Point(1170, 14)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(133, 56)
        btnExport.TabIndex = 5
        btnExport.Text = "Export to CSV File"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnMovetoFinal
        ' 
        btnMovetoFinal.Font = New Font("Segoe UI", 12F)
        btnMovetoFinal.Location = New Point(989, 14)
        btnMovetoFinal.Name = "btnMovetoFinal"
        btnMovetoFinal.Size = New Size(133, 56)
        btnMovetoFinal.TabIndex = 6
        btnMovetoFinal.Text = "Move to Final Inventory"
        btnMovetoFinal.UseVisualStyleBackColor = True
        ' 
        ' frmReViewInventory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(1339, 676)
        Controls.Add(btnMovetoFinal)
        Controls.Add(btnExport)
        Controls.Add(btnDelete)
        Controls.Add(Label1)
        Controls.Add(cbDepartments)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmReViewInventory"
        Text = "Review Inventory"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cbDepartments As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnMovetoFinal As Button
End Class
