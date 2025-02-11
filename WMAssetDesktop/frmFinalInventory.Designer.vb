<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinalInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFinalInventory))
        DataGridView1 = New DataGridView()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        btnExport = New Button()
        cbDpt = New ComboBox()
        btnCompleteInv = New Button()
        btnExport_All = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 118)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1447, 435)
        DataGridView1.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.wm_cypher_green
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(147, 92)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(193, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 21)
        Label1.TabIndex = 8
        Label1.Text = "Select Department:"
        ' 
        ' btnExport
        ' 
        btnExport.Font = New Font("Segoe UI", 12F)
        btnExport.ImageAlign = ContentAlignment.TopCenter
        btnExport.Location = New Point(1134, 19)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(119, 74)
        btnExport.TabIndex = 10
        btnExport.Text = "Export to CSV File for Upload"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' cbDpt
        ' 
        cbDpt.Font = New Font("Segoe UI", 12F)
        cbDpt.FormattingEnabled = True
        cbDpt.Location = New Point(193, 56)
        cbDpt.Name = "cbDpt"
        cbDpt.Size = New Size(252, 29)
        cbDpt.TabIndex = 27
        ' 
        ' btnCompleteInv
        ' 
        btnCompleteInv.Font = New Font("Segoe UI", 12F)
        btnCompleteInv.Location = New Point(1300, 19)
        btnCompleteInv.Name = "btnCompleteInv"
        btnCompleteInv.RightToLeft = RightToLeft.Yes
        btnCompleteInv.Size = New Size(119, 74)
        btnCompleteInv.TabIndex = 29
        btnCompleteInv.Text = "Complete Inventory"
        btnCompleteInv.UseVisualStyleBackColor = True
        ' 
        ' btnExport_All
        ' 
        btnExport_All.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnExport_All.Location = New Point(968, 19)
        btnExport_All.Name = "btnExport_All"
        btnExport_All.Size = New Size(119, 74)
        btnExport_All.TabIndex = 30
        btnExport_All.Text = "Export All Data to CSV File"
        btnExport_All.UseVisualStyleBackColor = True
        ' 
        ' frmFinalInventory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(1471, 579)
        Controls.Add(btnExport_All)
        Controls.Add(btnCompleteInv)
        Controls.Add(cbDpt)
        Controls.Add(btnExport)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmFinalInventory"
        Text = "Final Inventory"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents cbDpt As ComboBox
    Friend WithEvents btnCompleteInv As Button
    Friend WithEvents btnExport_All As Button
End Class
