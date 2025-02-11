<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainMnu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMnu))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        btnImport = New Button()
        btnSchedule = New Button()
        btnReviewInv = New Button()
        btnFinalInv = New Button()
        btnReviewDiscrepancy = New Button()
        btnUsers = New Button()
        btnInvStatus = New Button()
        btnImportDisposed = New Button()
        btnComments = New Button()
        btnLogin = New Button()
        btnLogout = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.CadetBlue
        PictureBox1.Image = My.Resources.Resources.wm_vertical_single_line_full_color
        PictureBox1.Location = New Point(121, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(337, 129)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(209, 139)
        Label1.Name = "Label1"
        Label1.Size = New Size(185, 32)
        Label1.TabIndex = 2
        Label1.Text = "Asset Inventory "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(230, 170)
        Label2.Name = "Label2"
        Label2.Size = New Size(138, 32)
        Label2.TabIndex = 3
        Label2.Text = "Main Menu"
        ' 
        ' btnImport
        ' 
        btnImport.BackColor = SystemColors.Control
        btnImport.Font = New Font("Microsoft Sans Serif", 12F)
        btnImport.Location = New Point(83, 317)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(119, 56)
        btnImport.TabIndex = 4
        btnImport.Text = "Import Master Assets"
        btnImport.UseVisualStyleBackColor = False
        ' 
        ' btnSchedule
        ' 
        btnSchedule.BackColor = SystemColors.Control
        btnSchedule.Font = New Font("Microsoft Sans Serif", 12F)
        btnSchedule.Location = New Point(246, 400)
        btnSchedule.Name = "btnSchedule"
        btnSchedule.Size = New Size(119, 56)
        btnSchedule.TabIndex = 5
        btnSchedule.Text = "Schedule Inventory"
        btnSchedule.UseVisualStyleBackColor = False
        ' 
        ' btnReviewInv
        ' 
        btnReviewInv.BackColor = SystemColors.Control
        btnReviewInv.Font = New Font("Microsoft Sans Serif", 12F)
        btnReviewInv.Location = New Point(246, 483)
        btnReviewInv.Name = "btnReviewInv"
        btnReviewInv.Size = New Size(119, 56)
        btnReviewInv.TabIndex = 6
        btnReviewInv.Text = "Review Inventory"
        btnReviewInv.UseVisualStyleBackColor = False
        ' 
        ' btnFinalInv
        ' 
        btnFinalInv.BackColor = SystemColors.Control
        btnFinalInv.Font = New Font("Microsoft Sans Serif", 12F)
        btnFinalInv.Location = New Point(404, 483)
        btnFinalInv.Name = "btnFinalInv"
        btnFinalInv.Size = New Size(119, 56)
        btnFinalInv.TabIndex = 7
        btnFinalInv.Text = "Compete / Export "
        btnFinalInv.UseVisualStyleBackColor = False
        ' 
        ' btnReviewDiscrepancy
        ' 
        btnReviewDiscrepancy.BackColor = SystemColors.Control
        btnReviewDiscrepancy.Font = New Font("Microsoft Sans Serif", 12F)
        btnReviewDiscrepancy.Location = New Point(404, 317)
        btnReviewDiscrepancy.Name = "btnReviewDiscrepancy"
        btnReviewDiscrepancy.Size = New Size(119, 56)
        btnReviewDiscrepancy.TabIndex = 8
        btnReviewDiscrepancy.Text = "Review Discrepancies"
        btnReviewDiscrepancy.UseVisualStyleBackColor = False
        ' 
        ' btnUsers
        ' 
        btnUsers.BackColor = SystemColors.Control
        btnUsers.Font = New Font("Microsoft Sans Serif", 12F)
        btnUsers.ForeColor = Color.Black
        btnUsers.Location = New Point(83, 483)
        btnUsers.Name = "btnUsers"
        btnUsers.Size = New Size(119, 56)
        btnUsers.TabIndex = 11
        btnUsers.Text = "Add/Edit Users"
        btnUsers.UseVisualStyleBackColor = False
        ' 
        ' btnInvStatus
        ' 
        btnInvStatus.BackColor = SystemColors.Control
        btnInvStatus.Font = New Font("Microsoft Sans Serif", 12F)
        btnInvStatus.Location = New Point(404, 400)
        btnInvStatus.Name = "btnInvStatus"
        btnInvStatus.Size = New Size(119, 56)
        btnInvStatus.TabIndex = 12
        btnInvStatus.Text = "Inventory Status"
        btnInvStatus.UseVisualStyleBackColor = False
        ' 
        ' btnImportDisposed
        ' 
        btnImportDisposed.BackColor = SystemColors.Control
        btnImportDisposed.Font = New Font("Microsoft Sans Serif", 12F)
        btnImportDisposed.Location = New Point(83, 400)
        btnImportDisposed.Name = "btnImportDisposed"
        btnImportDisposed.Size = New Size(119, 56)
        btnImportDisposed.TabIndex = 13
        btnImportDisposed.Text = "Import Disposed "
        btnImportDisposed.UseVisualStyleBackColor = False
        ' 
        ' btnComments
        ' 
        btnComments.BackColor = SystemColors.Control
        btnComments.Font = New Font("Microsoft Sans Serif", 12F)
        btnComments.Location = New Point(246, 317)
        btnComments.Name = "btnComments"
        btnComments.Size = New Size(119, 56)
        btnComments.TabIndex = 16
        btnComments.Text = "Add/Edit Comments"
        btnComments.UseVisualStyleBackColor = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = SystemColors.Control
        btnLogin.Font = New Font("Microsoft Sans Serif", 12F)
        btnLogin.Location = New Point(151, 230)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(119, 56)
        btnLogin.TabIndex = 17
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = SystemColors.Control
        btnLogout.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(327, 230)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(119, 56)
        btnLogout.TabIndex = 18
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' frmMainMnu
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(597, 577)
        Controls.Add(btnLogout)
        Controls.Add(btnLogin)
        Controls.Add(btnComments)
        Controls.Add(btnImportDisposed)
        Controls.Add(btnInvStatus)
        Controls.Add(btnUsers)
        Controls.Add(btnReviewDiscrepancy)
        Controls.Add(btnFinalInv)
        Controls.Add(btnReviewInv)
        Controls.Add(btnSchedule)
        Controls.Add(btnImport)
        Controls.Add(PictureBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmMainMnu"
        Text = "Asset Inventory"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnImport As Button
    Friend WithEvents btnSchedule As Button
    Friend WithEvents btnReviewInv As Button
    Friend WithEvents btnFinalInv As Button
    Friend WithEvents btnReviewDiscrepancy As Button
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnInvStatus As Button
    Friend WithEvents btnImportDisposed As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnComments As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnLogout As Button

End Class
