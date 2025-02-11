<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportDisposed
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportDisposed))
        lblCnt = New Label()
        Label1 = New Label()
        Button3 = New Button()
        btnImport = New Button()
        PictureBox1 = New PictureBox()
        lblName = New Label()
        blbFileName = New Label()
        Button1 = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblCnt
        ' 
        lblCnt.AutoSize = True
        lblCnt.Font = New Font("Segoe UI", 12F)
        lblCnt.Location = New Point(285, 414)
        lblCnt.Margin = New Padding(4, 0, 4, 0)
        lblCnt.Name = "lblCnt"
        lblCnt.Size = New Size(19, 21)
        lblCnt.TabIndex = 14
        lblCnt.Text = "0"
        lblCnt.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(54, 414)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(137, 21)
        Label1.TabIndex = 13
        Label1.Text = "Records Imported:"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(197, 485)
        Button3.Margin = New Padding(4, 4, 4, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(171, 59)
        Button3.TabIndex = 12
        Button3.Text = "View Data"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' btnImport
        ' 
        btnImport.Location = New Point(198, 312)
        btnImport.Margin = New Padding(4, 4, 4, 4)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(171, 59)
        btnImport.TabIndex = 11
        btnImport.Text = "Import Disposed Assets"
        btnImport.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(203, 14)
        PictureBox1.Margin = New Padding(4, 4, 4, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(166, 98)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Segoe UI", 12F)
        lblName.Location = New Point(230, 230)
        lblName.Margin = New Padding(4, 0, 4, 0)
        lblName.Name = "lblName"
        lblName.Size = New Size(0, 21)
        lblName.TabIndex = 10
        ' 
        ' blbFileName
        ' 
        blbFileName.AutoSize = True
        blbFileName.Font = New Font("Segoe UI", 12F)
        blbFileName.Location = New Point(67, 230)
        blbFileName.Margin = New Padding(4, 0, 4, 0)
        blbFileName.Name = "blbFileName"
        blbFileName.Size = New Size(79, 21)
        blbFileName.TabIndex = 9
        blbFileName.Text = "FileName:"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(197, 150)
        Button1.Margin = New Padding(4, 4, 4, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(171, 59)
        Button1.TabIndex = 8
        Button1.Text = "Select File to Import"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.Filter = "CSV files|*.CSV"
        ' 
        ' frmImportDisposed
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(566, 630)
        Controls.Add(lblCnt)
        Controls.Add(Label1)
        Controls.Add(Button3)
        Controls.Add(btnImport)
        Controls.Add(PictureBox1)
        Controls.Add(lblName)
        Controls.Add(blbFileName)
        Controls.Add(Button1)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 4, 4, 4)
        Name = "frmImportDisposed"
        Text = "Import Disposed Assets"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblCnt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents blbFileName As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
