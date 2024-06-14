<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassword
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtPasswordOld = New System.Windows.Forms.TextBox
        Me.txtPasswordNew = New System.Windows.Forms.TextBox
        Me.txtPasswordRe = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(163, 170)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(244, 170)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Old Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&New Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "&Re-Enter Password"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(132, 34)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 1
        '
        'txtPasswordOld
        '
        Me.txtPasswordOld.Font = New System.Drawing.Font("Wingdings", 8.0!)
        Me.txtPasswordOld.Location = New System.Drawing.Point(132, 68)
        Me.txtPasswordOld.Name = "txtPasswordOld"
        Me.txtPasswordOld.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPasswordOld.Size = New System.Drawing.Size(187, 19)
        Me.txtPasswordOld.TabIndex = 3
        '
        'txtPasswordNew
        '
        Me.txtPasswordNew.Font = New System.Drawing.Font("Wingdings", 8.0!)
        Me.txtPasswordNew.Location = New System.Drawing.Point(132, 94)
        Me.txtPasswordNew.Name = "txtPasswordNew"
        Me.txtPasswordNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPasswordNew.Size = New System.Drawing.Size(187, 19)
        Me.txtPasswordNew.TabIndex = 5
        '
        'txtPasswordRe
        '
        Me.txtPasswordRe.Font = New System.Drawing.Font("Wingdings", 8.0!)
        Me.txtPasswordRe.Location = New System.Drawing.Point(132, 120)
        Me.txtPasswordRe.Name = "txtPasswordRe"
        Me.txtPasswordRe.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPasswordRe.Size = New System.Drawing.Size(187, 19)
        Me.txtPasswordRe.TabIndex = 7
        '
        'frmPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPasswordRe)
        Me.Controls.Add(Me.txtPasswordNew)
        Me.Controls.Add(Me.txtPasswordOld)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmPassword"
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswordOld As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswordNew As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswordRe As System.Windows.Forms.TextBox
End Class
