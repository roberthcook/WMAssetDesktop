<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchedule))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        StartDte = New DateTimePicker()
        EndDate = New DateTimePicker()
        PictureBox1 = New PictureBox()
        Label4 = New Label()
        Label5 = New Label()
        chkComplete = New CheckBox()
        btnSave = New Button()
        lblStatus = New Label()
        lblDname = New Label()
        Button1 = New Button()
        lblDept = New Label()
        lblActualStart = New Label()
        lblActualEnd = New Label()
        btnView = New Button()
        lblDownload = New Label()
        lblCnt = New Label()
        lblUploadDate = New Label()
        Label7 = New Label()
        cbDpt = New ComboBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.White
        Label1.Location = New Point(191, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(107, 15)
        Label1.TabIndex = 1
        Label1.Text = "Select Department:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.White
        Label2.Location = New Point(41, 212)
        Label2.Name = "Label2"
        Label2.Size = New Size(119, 15)
        Label2.TabIndex = 2
        Label2.Text = "Scheduled Start Date:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.White
        Label3.Location = New Point(45, 263)
        Label3.Name = "Label3"
        Label3.Size = New Size(115, 15)
        Label3.TabIndex = 3
        Label3.Text = "Scheduled End Date:"
        ' 
        ' StartDte
        ' 
        StartDte.Location = New Point(165, 206)
        StartDte.Name = "StartDte"
        StartDte.Size = New Size(200, 23)
        StartDte.TabIndex = 4
        ' 
        ' EndDate
        ' 
        EndDate.Location = New Point(165, 257)
        EndDate.Name = "EndDate"
        EndDate.Size = New Size(200, 23)
        EndDate.TabIndex = 5
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.wm_cypher_green
        PictureBox1.Location = New Point(4, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(147, 92)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = Color.White
        Label4.Location = New Point(63, 295)
        Label4.Name = "Label4"
        Label4.Size = New Size(98, 15)
        Label4.TabIndex = 7
        Label4.Text = "Actual Start Date:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = Color.White
        Label5.Location = New Point(67, 324)
        Label5.Name = "Label5"
        Label5.Size = New Size(94, 15)
        Label5.TabIndex = 9
        Label5.Text = "Actual End Date:"
        ' 
        ' chkComplete
        ' 
        chkComplete.AutoSize = True
        chkComplete.ForeColor = Color.White
        chkComplete.Location = New Point(66, 396)
        chkComplete.Name = "chkComplete"
        chkComplete.Size = New Size(85, 19)
        chkComplete.TabIndex = 11
        chkComplete.Text = "Completed"
        chkComplete.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(41, 443)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(110, 39)
        btnSave.TabIndex = 13
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.ForeColor = Color.White
        lblStatus.Location = New Point(209, 174)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(82, 15)
        lblStatus.TabIndex = 14
        lblStatus.Text = "New Schedule"
        ' 
        ' lblDname
        ' 
        lblDname.AutoSize = True
        lblDname.ForeColor = Color.White
        lblDname.Location = New Point(87, 146)
        lblDname.Name = "lblDname"
        lblDname.Size = New Size(73, 15)
        lblDname.TabIndex = 15
        lblDname.Text = "Department:"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(339, 443)
        Button1.Name = "Button1"
        Button1.Size = New Size(110, 39)
        Button1.TabIndex = 16
        Button1.Text = "View Schedules"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' lblDept
        ' 
        lblDept.AutoSize = True
        lblDept.ForeColor = Color.White
        lblDept.Location = New Point(170, 146)
        lblDept.Name = "lblDept"
        lblDept.Size = New Size(0, 15)
        lblDept.TabIndex = 17
        ' 
        ' lblActualStart
        ' 
        lblActualStart.AutoSize = True
        lblActualStart.ForeColor = Color.White
        lblActualStart.Location = New Point(166, 295)
        lblActualStart.Name = "lblActualStart"
        lblActualStart.Size = New Size(67, 15)
        lblActualStart.TabIndex = 18
        lblActualStart.Text = "Not Started"
        ' 
        ' lblActualEnd
        ' 
        lblActualEnd.AutoSize = True
        lblActualEnd.ForeColor = Color.White
        lblActualEnd.Location = New Point(166, 325)
        lblActualEnd.Name = "lblActualEnd"
        lblActualEnd.Size = New Size(89, 15)
        lblActualEnd.TabIndex = 19
        lblActualEnd.Text = "Not Completed"
        ' 
        ' btnView
        ' 
        btnView.Location = New Point(183, 443)
        btnView.Name = "btnView"
        btnView.Size = New Size(110, 39)
        btnView.TabIndex = 20
        btnView.Text = "View Dept Inventory"
        btnView.UseVisualStyleBackColor = True
        ' 
        ' lblDownload
        ' 
        lblDownload.AutoSize = True
        lblDownload.ForeColor = Color.White
        lblDownload.Location = New Point(24, 533)
        lblDownload.Name = "lblDownload"
        lblDownload.Size = New Size(180, 15)
        lblDownload.TabIndex = 21
        lblDownload.Text = "Download Asset Count for Dept.:"
        ' 
        ' lblCnt
        ' 
        lblCnt.AutoSize = True
        lblCnt.ForeColor = Color.White
        lblCnt.Location = New Point(220, 533)
        lblCnt.Name = "lblCnt"
        lblCnt.Size = New Size(13, 15)
        lblCnt.TabIndex = 22
        lblCnt.Text = "0"
        ' 
        ' lblUploadDate
        ' 
        lblUploadDate.AutoSize = True
        lblUploadDate.ForeColor = Color.White
        lblUploadDate.Location = New Point(166, 353)
        lblUploadDate.Name = "lblUploadDate"
        lblUploadDate.Size = New Size(81, 15)
        lblUploadDate.TabIndex = 25
        lblUploadDate.Text = "Not Uploaded"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.ForeColor = Color.White
        Label7.Location = New Point(46, 353)
        Label7.Name = "Label7"
        Label7.Size = New Size(111, 15)
        Label7.TabIndex = 24
        Label7.Text = "Actual Export  Date:"
        ' 
        ' cbDpt
        ' 
        cbDpt.FormattingEnabled = True
        cbDpt.Location = New Point(191, 47)
        cbDpt.Name = "cbDpt"
        cbDpt.Size = New Size(211, 23)
        cbDpt.TabIndex = 26
        ' 
        ' frmSchedule
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(494, 557)
        Controls.Add(cbDpt)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(lblUploadDate)
        Controls.Add(Label7)
        Controls.Add(lblCnt)
        Controls.Add(lblDownload)
        Controls.Add(btnView)
        Controls.Add(lblActualEnd)
        Controls.Add(lblActualStart)
        Controls.Add(lblDept)
        Controls.Add(Button1)
        Controls.Add(lblDname)
        Controls.Add(lblStatus)
        Controls.Add(btnSave)
        Controls.Add(chkComplete)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(EndDate)
        Controls.Add(StartDte)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmSchedule"
        Text = "Department Schedule"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents StartDte As DateTimePicker
    Friend WithEvents EndDate As DateTimePicker
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkComplete As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblDname As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblDept As Label
    Friend WithEvents lblActualStart As Label
    Friend WithEvents lblActualEnd As Label
    Friend WithEvents btnView As Button
    Friend WithEvents lblDownload As Label
    Friend WithEvents lblCnt As Label
    Friend WithEvents lblUploadDate As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbDpt As ComboBox
End Class
