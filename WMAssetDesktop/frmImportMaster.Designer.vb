<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportMaster))
        OpenFileDialog1 = New OpenFileDialog()
        blbFileName = New Label()
        lblName = New Label()
        PictureBox1 = New PictureBox()
        btnImport = New Button()
        Button3 = New Button()
        Button1 = New Button()
        Label1 = New Label()
        lblCnt = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.Filter = "All files|*.*"
        ' 
        ' blbFileName
        ' 
        blbFileName.AutoSize = True
        blbFileName.Font = New Font("Segoe UI", 12F)
        blbFileName.Location = New Point(12, 167)
        blbFileName.Name = "blbFileName"
        blbFileName.Size = New Size(79, 21)
        blbFileName.TabIndex = 1
        blbFileName.Text = "FileName:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblName.Location = New Point(91, 171)
        lblName.Name = "lblName"
        lblName.Size = New Size(0, 13)
        lblName.TabIndex = 2
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(161, 1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(129, 70)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' btnImport
        ' 
        btnImport.Font = New Font("Segoe UI", 12F)
        btnImport.Location = New Point(157, 199)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(133, 81)
        btnImport.TabIndex = 3
        btnImport.Text = "Import Master Assets"
        btnImport.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 12F)
        Button3.Location = New Point(157, 320)
        Button3.Name = "Button3"
        Button3.Size = New Size(133, 81)
        Button3.TabIndex = 4
        Button3.Text = "View Data"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(157, 78)
        Button1.Name = "Button1"
        Button1.Size = New Size(133, 81)
        Button1.TabIndex = 0
        Button1.Text = "Select File to Import"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(12, 288)
        Label1.Name = "Label1"
        Label1.Size = New Size(137, 21)
        Label1.TabIndex = 5
        Label1.Text = "Records Imported:"
        ' 
        ' lblCnt
        ' 
        lblCnt.AutoSize = True
        lblCnt.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCnt.Location = New Point(155, 288)
        lblCnt.Name = "lblCnt"
        lblCnt.Size = New Size(19, 21)
        lblCnt.TabIndex = 6
        lblCnt.Text = "0"
        lblCnt.TextAlign = ContentAlignment.TopRight
        ' 
        ' frmImportMaster
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(447, 420)
        Controls.Add(lblCnt)
        Controls.Add(Label1)
        Controls.Add(Button3)
        Controls.Add(btnImport)
        Controls.Add(PictureBox1)
        Controls.Add(lblName)
        Controls.Add(blbFileName)
        Controls.Add(Button1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmImportMaster"
        Text = "Import Master CSV File"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents blbFileName As Label
    Friend WithEvents lblName As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnImport As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCnt As Label
End Class
