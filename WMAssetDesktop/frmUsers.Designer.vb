<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsers))
        Label1 = New Label()
        txtUserID = New TextBox()
        txtName = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        lstDept = New ListBox()
        Label5 = New Label()
        cbAssignDept = New ComboBox()
        btnSave = New Button()
        chkAllDept = New CheckBox()
        PictureBox1 = New PictureBox()
        lblType = New Label()
        Button2 = New Button()
        btnView = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(87, 67)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 21)
        Label1.TabIndex = 0
        Label1.Text = "Enter UseID:"
        ' 
        ' txtUserID
        ' 
        txtUserID.Font = New Font("Segoe UI", 12F)
        txtUserID.Location = New Point(212, 64)
        txtUserID.Margin = New Padding(4)
        txtUserID.Name = "txtUserID"
        txtUserID.Size = New Size(160, 29)
        txtUserID.TabIndex = 1
        ' 
        ' txtName
        ' 
        txtName.Font = New Font("Segoe UI", 12F)
        txtName.Location = New Point(195, 202)
        txtName.Margin = New Padding(4)
        txtName.Name = "txtName"
        txtName.Size = New Size(315, 29)
        txtName.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(126, 204)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 21)
        Label2.TabIndex = 2
        Label2.Text = "Name:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(35, 259)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(146, 21)
        Label3.TabIndex = 4
        Label3.Text = "Assign Department:"
        Label3.UseWaitCursor = True
        ' 
        ' lstDept
        ' 
        lstDept.Font = New Font("Segoe UI", 12F)
        lstDept.FormattingEnabled = True
        lstDept.ItemHeight = 21
        lstDept.Location = New Point(557, 196)
        lstDept.Margin = New Padding(4)
        lstDept.Name = "lstDept"
        lstDept.Size = New Size(337, 424)
        lstDept.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(557, 159)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(167, 21)
        Label5.TabIndex = 10
        Label5.Text = "Assigned Departments"
        ' 
        ' cbAssignDept
        ' 
        cbAssignDept.Font = New Font("Segoe UI", 12F)
        cbAssignDept.FormattingEnabled = True
        cbAssignDept.Location = New Point(195, 256)
        cbAssignDept.Margin = New Padding(4)
        cbAssignDept.Name = "cbAssignDept"
        cbAssignDept.Size = New Size(314, 29)
        cbAssignDept.TabIndex = 11
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Segoe UI", 12F)
        btnSave.Location = New Point(62, 630)
        btnSave.Margin = New Padding(4)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(182, 71)
        btnSave.TabIndex = 13
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' chkAllDept
        ' 
        chkAllDept.AutoSize = True
        chkAllDept.Font = New Font("Segoe UI", 12F)
        chkAllDept.ForeColor = Color.White
        chkAllDept.Location = New Point(198, 393)
        chkAllDept.Margin = New Padding(4)
        chkAllDept.Name = "chkAllDept"
        chkAllDept.Size = New Size(141, 25)
        chkAllDept.TabIndex = 14
        chkAllDept.Text = "All Departments"
        chkAllDept.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(410, 17)
        PictureBox1.Margin = New Padding(4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(166, 98)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 15
        PictureBox1.TabStop = False
        PictureBox1.UseWaitCursor = True
        ' 
        ' lblType
        ' 
        lblType.AutoSize = True
        lblType.ForeColor = Color.White
        lblType.Location = New Point(294, 147)
        lblType.Margin = New Padding(4, 0, 4, 0)
        lblType.Name = "lblType"
        lblType.Size = New Size(0, 21)
        lblType.TabIndex = 16
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.Location = New Point(705, 630)
        Button2.Margin = New Padding(4)
        Button2.Name = "Button2"
        Button2.Size = New Size(182, 71)
        Button2.TabIndex = 17
        Button2.Text = "Remove Selected Department"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' btnView
        ' 
        btnView.Font = New Font("Segoe UI", 12F)
        btnView.Location = New Point(363, 630)
        btnView.Margin = New Padding(4)
        btnView.Name = "btnView"
        btnView.Size = New Size(182, 71)
        btnView.TabIndex = 20
        btnView.Text = "View Users"
        btnView.UseVisualStyleBackColor = True
        ' 
        ' frmUsers
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(928, 708)
        Controls.Add(btnView)
        Controls.Add(PictureBox1)
        Controls.Add(txtUserID)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(lblType)
        Controls.Add(chkAllDept)
        Controls.Add(btnSave)
        Controls.Add(cbAssignDept)
        Controls.Add(Label5)
        Controls.Add(lstDept)
        Controls.Add(Label3)
        Controls.Add(txtName)
        Controls.Add(Label2)
        Font = New Font("Segoe UI", 12F)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "frmUsers"
        Text = "Users"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lstDept As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbAssignDept As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents chkAllDept As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblType As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnView As Button
End Class
