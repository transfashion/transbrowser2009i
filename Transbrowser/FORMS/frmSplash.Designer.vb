<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPT = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblTransCorp = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(12, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loading..."
        '
        'lblPT
        '
        Me.lblPT.BackColor = System.Drawing.Color.Transparent
        Me.lblPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPT.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblPT.Location = New System.Drawing.Point(212, 229)
        Me.lblPT.Name = "lblPT"
        Me.lblPT.Size = New System.Drawing.Size(240, 13)
        Me.lblPT.TabIndex = 1
        Me.lblPT.Text = "[ name of company ]"
        Me.lblPT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblVersion.Location = New System.Drawing.Point(186, 249)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(266, 13)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Loading Transbrowser..."
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTransCorp
        '
        Me.lblTransCorp.BackColor = System.Drawing.Color.Transparent
        Me.lblTransCorp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransCorp.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblTransCorp.Location = New System.Drawing.Point(98, 262)
        Me.lblTransCorp.Name = "lblTransCorp"
        Me.lblTransCorp.Size = New System.Drawing.Size(354, 13)
        Me.lblTransCorp.TabIndex = 3
        Me.lblTransCorp.Text = "Loading Transbrowser..."
        Me.lblTransCorp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(462, 283)
        Me.Controls.Add(Me.lblTransCorp)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblPT)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplash"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPT As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTransCorp As System.Windows.Forms.Label
End Class
