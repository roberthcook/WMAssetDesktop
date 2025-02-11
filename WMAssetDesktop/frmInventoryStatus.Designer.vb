<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryStatus))
        cbDpt = New ComboBox()
        btnExport = New Button()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        lblUploadDate = New Label()
        Label7 = New Label()
        lblActualEnd = New Label()
        lblActualStart = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        lblDeptName = New Label()
        Label6 = New Label()
        Label8 = New Label()
        lblNotFound = New Label()
        lblItemsFound = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cbDpt
        ' 
        cbDpt.FormattingEnabled = True
        cbDpt.Location = New Point(180, 48)
        cbDpt.Name = "cbDpt"
        cbDpt.Size = New Size(229, 23)
        cbDpt.TabIndex = 31
        ' 
        ' btnExport
        ' 
        btnExport.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnExport.Location = New Point(478, 30)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(106, 41)
        btnExport.TabIndex = 30
        btnExport.Text = "Export to CSV File"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.wm_cypher_green
        PictureBox1.Location = New Point(5, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(147, 92)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 29
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(180, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 25)
        Label1.TabIndex = 28
        Label1.Text = "Select Department:"
        ' 
        ' lblUploadDate
        ' 
        lblUploadDate.AutoSize = True
        lblUploadDate.Font = New Font("Segoe UI", 14F)
        lblUploadDate.ForeColor = Color.White
        lblUploadDate.Location = New Point(225, 265)
        lblUploadDate.Name = "lblUploadDate"
        lblUploadDate.Size = New Size(130, 25)
        lblUploadDate.TabIndex = 40
        lblUploadDate.Text = "Not Uploaded"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 14F)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(86, 266)
        Label7.Name = "Label7"
        Label7.Size = New Size(126, 25)
        Label7.TabIndex = 39
        Label7.Text = "Upload  Date:"
        ' 
        ' lblActualEnd
        ' 
        lblActualEnd.AutoSize = True
        lblActualEnd.Font = New Font("Segoe UI", 14F)
        lblActualEnd.ForeColor = Color.White
        lblActualEnd.Location = New Point(225, 225)
        lblActualEnd.Name = "lblActualEnd"
        lblActualEnd.Size = New Size(140, 25)
        lblActualEnd.TabIndex = 37
        lblActualEnd.Text = "Not Completed"
        ' 
        ' lblActualStart
        ' 
        lblActualStart.AutoSize = True
        lblActualStart.Font = New Font("Segoe UI", 14F)
        lblActualStart.ForeColor = Color.White
        lblActualStart.Location = New Point(225, 185)
        lblActualStart.Name = "lblActualStart"
        lblActualStart.Size = New Size(107, 25)
        lblActualStart.TabIndex = 36
        lblActualStart.Text = "Not Started"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 14F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(55, 226)
        Label5.Name = "Label5"
        Label5.Size = New Size(157, 25)
        Label5.TabIndex = 34
        Label5.Text = " Completed Date:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 14F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(109, 186)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 25)
        Label4.TabIndex = 33
        Label4.Text = " Start Date:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(96, 148)
        Label2.Name = "Label2"
        Label2.Size = New Size(116, 25)
        Label2.TabIndex = 41
        Label2.Text = "Department:"
        ' 
        ' lblDeptName
        ' 
        lblDeptName.AutoSize = True
        lblDeptName.Font = New Font("Segoe UI", 14F)
        lblDeptName.ForeColor = Color.White
        lblDeptName.Location = New Point(225, 145)
        lblDeptName.Name = "lblDeptName"
        lblDeptName.Size = New Size(0, 25)
        lblDeptName.TabIndex = 42
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(74, 306)
        Label6.Name = "Label6"
        Label6.Size = New Size(138, 25)
        Label6.TabIndex = 44
        Label6.Text = "Items Counted:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 14F)
        Label8.ForeColor = Color.White
        Label8.Location = New Point(33, 345)
        Label8.Name = "Label8"
        Label8.Size = New Size(179, 25)
        Label8.TabIndex = 45
        Label8.Text = "Items Not  Counted:"
        ' 
        ' lblNotFound
        ' 
        lblNotFound.AutoSize = True
        lblNotFound.Font = New Font("Segoe UI", 14F)
        lblNotFound.ForeColor = Color.White
        lblNotFound.Location = New Point(225, 345)
        lblNotFound.Name = "lblNotFound"
        lblNotFound.Size = New Size(22, 25)
        lblNotFound.TabIndex = 46
        lblNotFound.Text = "0"
        ' 
        ' lblItemsFound
        ' 
        lblItemsFound.AutoSize = True
        lblItemsFound.Font = New Font("Segoe UI", 14F)
        lblItemsFound.ForeColor = Color.White
        lblItemsFound.Location = New Point(225, 305)
        lblItemsFound.Name = "lblItemsFound"
        lblItemsFound.Size = New Size(22, 25)
        lblItemsFound.TabIndex = 47
        lblItemsFound.Text = "0"
        ' 
        ' frmInventoryStatus
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(641, 450)
        Controls.Add(lblItemsFound)
        Controls.Add(lblNotFound)
        Controls.Add(Label8)
        Controls.Add(Label6)
        Controls.Add(lblDeptName)
        Controls.Add(Label2)
        Controls.Add(lblUploadDate)
        Controls.Add(Label7)
        Controls.Add(lblActualEnd)
        Controls.Add(lblActualStart)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(cbDpt)
        Controls.Add(btnExport)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmInventoryStatus"
        Text = "Inventory Status"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cbDpt As ComboBox
    Friend WithEvents btnExport As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUploadDate As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblActualEnd As Label
    Friend WithEvents lblActualStart As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDeptName As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblNotFound As Label
    Friend WithEvents lblItemsFound As Label
End Class
