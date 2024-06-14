<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoading
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoading))
        Me.lblLoading = New System.Windows.Forms.Label
        Me.imgLoad = New System.Windows.Forms.PictureBox
        Me.lblMessage = New System.Windows.Forms.Label
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Location = New System.Drawing.Point(78, 38)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(54, 13)
        Me.lblLoading.TabIndex = 1
        Me.lblLoading.Text = "Loading..."
        '
        'imgLoad
        '
        Me.imgLoad.Image = CType(resources.GetObject("imgLoad.Image"), System.Drawing.Image)
        Me.imgLoad.Location = New System.Drawing.Point(33, 36)
        Me.imgLoad.Name = "imgLoad"
        Me.imgLoad.Size = New System.Drawing.Size(32, 32)
        Me.imgLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgLoad.TabIndex = 2
        Me.imgLoad.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(78, 56)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(347, 67)
        Me.lblMessage.TabIndex = 3
        Me.lblMessage.Text = "Loading..."
        '
        'frmLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 146)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.imgLoad)
        Me.Controls.Add(Me.lblLoading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLoading"
        Me.Text = "frmLoading"
        CType(Me.imgLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents imgLoad As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class
