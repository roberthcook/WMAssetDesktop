<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDownload))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        lblCount = New Label()
        Done = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.wm_cypher_green
        PictureBox1.Location = New Point(96, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(116, 78)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(98, 119)
        Label1.Name = "Label1"
        Label1.Size = New Size(69, 21)
        Label1.TabIndex = 1
        Label1.Text = "Records:"
        ' 
        ' lblCount
        ' 
        lblCount.AutoSize = True
        lblCount.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCount.ForeColor = Color.White
        lblCount.Location = New Point(183, 119)
        lblCount.Name = "lblCount"
        lblCount.Size = New Size(19, 21)
        lblCount.TabIndex = 2
        lblCount.Text = "0"
        ' 
        ' Done
        ' 
        Done.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Done.Location = New Point(117, 165)
        Done.Name = "Done"
        Done.Size = New Size(75, 31)
        Done.TabIndex = 3
        Done.Text = "Done"
        Done.UseVisualStyleBackColor = True
        ' 
        ' frmDownload
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(309, 222)
        Controls.Add(Done)
        Controls.Add(lblCount)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmDownload"
        Text = "Loading Data"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents Done As Button
End Class
