<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddComment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddComment))
        btnSave = New Button()
        txtComment = New TextBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(199, 119)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(129, 34)
        btnSave.TabIndex = 4
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txtComment
        ' 
        txtComment.Font = New Font("Segoe UI", 12F)
        txtComment.Location = New Point(12, 54)
        txtComment.Name = "txtComment"
        txtComment.Size = New Size(503, 29)
        txtComment.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(12, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(122, 21)
        Label1.TabIndex = 6
        Label1.Text = "Enter Comment:"
        ' 
        ' frmAddComment
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(527, 174)
        Controls.Add(Label1)
        Controls.Add(txtComment)
        Controls.Add(btnSave)
        ForeColor = Color.Black
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmAddComment"
        Text = "Add Comment"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents txtComment As TextBox
    Friend WithEvents Label1 As Label
End Class
