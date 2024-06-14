<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgBase))
        Me.pnlButtonBottom = New System.Windows.Forms.Panel
        Me.pnlLoading = New System.Windows.Forms.Panel
        Me.lblLoading = New System.Windows.Forms.Label
        Me.imgWait = New System.Windows.Forms.PictureBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.pnlButtonBottom.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.imgWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButtonBottom
        '
        Me.pnlButtonBottom.Controls.Add(Me.pnlLoading)
        Me.pnlButtonBottom.Controls.Add(Me.btnOK)
        Me.pnlButtonBottom.Controls.Add(Me.btnCancel)
        Me.pnlButtonBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtonBottom.Location = New System.Drawing.Point(0, 174)
        Me.pnlButtonBottom.Name = "pnlButtonBottom"
        Me.pnlButtonBottom.Size = New System.Drawing.Size(305, 39)
        Me.pnlButtonBottom.TabIndex = 2
        '
        'pnlLoading
        '
        Me.pnlLoading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLoading.Controls.Add(Me.lblLoading)
        Me.pnlLoading.Controls.Add(Me.imgWait)
        Me.pnlLoading.Location = New System.Drawing.Point(8, 8)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(121, 28)
        Me.pnlLoading.TabIndex = 2
        Me.pnlLoading.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoading.Location = New System.Drawing.Point(22, 6)
        Me.lblLoading.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(88, 16)
        Me.lblLoading.TabIndex = 13
        Me.lblLoading.Text = "Loading . . . "
        '
        'imgWait
        '
        Me.imgWait.Image = CType(resources.GetObject("imgWait.Image"), System.Drawing.Image)
        Me.imgWait.Location = New System.Drawing.Point(3, 3)
        Me.imgWait.Name = "imgWait"
        Me.imgWait.Size = New System.Drawing.Size(16, 16)
        Me.imgWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgWait.TabIndex = 12
        Me.imgWait.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(135, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(218, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dlgBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 213)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlButtonBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgBase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dlgBase"
        Me.pnlButtonBottom.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.imgWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents pnlButtonBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents imgWait As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
