<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreference
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.chkReloadModuleEveryProgram = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblWebserviceAddress = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtWebserviceAddress = New System.Windows.Forms.TextBox
        Me.txtAsDll = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtLocalDll = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdoManual = New System.Windows.Forms.RadioButton
        Me.rdoAuto = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDsDSNFormat = New System.Windows.Forms.TextBox
        Me.txtDsDatabaseName = New System.Windows.Forms.TextBox
        Me.txtDsPassword = New System.Windows.Forms.TextBox
        Me.txtDsUsername = New System.Windows.Forms.TextBox
        Me.txtDsServerName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(524, 412)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(443, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkReloadModuleEveryProgram)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(579, 355)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Application"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkReloadModuleEveryProgram
        '
        Me.chkReloadModuleEveryProgram.AutoSize = True
        Me.chkReloadModuleEveryProgram.Location = New System.Drawing.Point(17, 278)
        Me.chkReloadModuleEveryProgram.Name = "chkReloadModuleEveryProgram"
        Me.chkReloadModuleEveryProgram.Size = New System.Drawing.Size(134, 17)
        Me.chkReloadModuleEveryProgram.TabIndex = 1
        Me.chkReloadModuleEveryProgram.Text = "Always Reload Module"
        Me.chkReloadModuleEveryProgram.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblWebserviceAddress)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtWebserviceAddress)
        Me.GroupBox1.Controls.Add(Me.txtAsDll)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(543, 235)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Application Server"
        '
        'lblWebserviceAddress
        '
        Me.lblWebserviceAddress.AutoSize = True
        Me.lblWebserviceAddress.Location = New System.Drawing.Point(23, 61)
        Me.lblWebserviceAddress.Name = "lblWebserviceAddress"
        Me.lblWebserviceAddress.Size = New System.Drawing.Size(105, 13)
        Me.lblWebserviceAddress.TabIndex = 3
        Me.lblWebserviceAddress.Text = "Webservice Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DLL Address"
        '
        'txtWebserviceAddress
        '
        Me.txtWebserviceAddress.Location = New System.Drawing.Point(135, 58)
        Me.txtWebserviceAddress.Name = "txtWebserviceAddress"
        Me.txtWebserviceAddress.Size = New System.Drawing.Size(377, 20)
        Me.txtWebserviceAddress.TabIndex = 1
        '
        'txtAsDll
        '
        Me.txtAsDll.Location = New System.Drawing.Point(135, 32)
        Me.txtAsDll.Name = "txtAsDll"
        Me.txtAsDll.Size = New System.Drawing.Size(377, 20)
        Me.txtAsDll.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(587, 381)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(579, 355)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Local Connection"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtLocalDll)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(543, 103)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Local Module Location"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "DLL Address"
        '
        'txtLocalDll
        '
        Me.txtLocalDll.Location = New System.Drawing.Point(135, 32)
        Me.txtLocalDll.Name = "txtLocalDll"
        Me.txtLocalDll.Size = New System.Drawing.Size(377, 20)
        Me.txtLocalDll.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoManual)
        Me.GroupBox2.Controls.Add(Me.rdoAuto)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDsDSNFormat)
        Me.GroupBox2.Controls.Add(Me.txtDsDatabaseName)
        Me.GroupBox2.Controls.Add(Me.txtDsPassword)
        Me.GroupBox2.Controls.Add(Me.txtDsUsername)
        Me.GroupBox2.Controls.Add(Me.txtDsServerName)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(543, 211)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Local Database"
        '
        'rdoManual
        '
        Me.rdoManual.AutoSize = True
        Me.rdoManual.Location = New System.Drawing.Point(26, 45)
        Me.rdoManual.Name = "rdoManual"
        Me.rdoManual.Size = New System.Drawing.Size(60, 17)
        Me.rdoManual.TabIndex = 16
        Me.rdoManual.TabStop = True
        Me.rdoManual.Text = "Manual"
        Me.rdoManual.UseVisualStyleBackColor = True
        '
        'rdoAuto
        '
        Me.rdoAuto.AutoSize = True
        Me.rdoAuto.Checked = True
        Me.rdoAuto.Location = New System.Drawing.Point(26, 22)
        Me.rdoAuto.Name = "rdoAuto"
        Me.rdoAuto.Size = New System.Drawing.Size(72, 17)
        Me.rdoAuto.TabIndex = 15
        Me.rdoAuto.TabStop = True
        Me.rdoAuto.Text = "Automatic"
        Me.rdoAuto.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(287, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "(3)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(287, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "(1)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(287, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "(0)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(287, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "(2)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "DSN Format"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Database Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Username"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Server Name"
        '
        'txtDsDSNFormat
        '
        Me.txtDsDSNFormat.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDsDSNFormat.Location = New System.Drawing.Point(135, 181)
        Me.txtDsDSNFormat.Name = "txtDsDSNFormat"
        Me.txtDsDSNFormat.ReadOnly = True
        Me.txtDsDSNFormat.Size = New System.Drawing.Size(377, 20)
        Me.txtDsDSNFormat.TabIndex = 5
        '
        'txtDsDatabaseName
        '
        Me.txtDsDatabaseName.Location = New System.Drawing.Point(135, 155)
        Me.txtDsDatabaseName.Name = "txtDsDatabaseName"
        Me.txtDsDatabaseName.Size = New System.Drawing.Size(146, 20)
        Me.txtDsDatabaseName.TabIndex = 4
        '
        'txtDsPassword
        '
        Me.txtDsPassword.Location = New System.Drawing.Point(135, 129)
        Me.txtDsPassword.Name = "txtDsPassword"
        Me.txtDsPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtDsPassword.Size = New System.Drawing.Size(146, 20)
        Me.txtDsPassword.TabIndex = 3
        '
        'txtDsUsername
        '
        Me.txtDsUsername.Location = New System.Drawing.Point(135, 103)
        Me.txtDsUsername.Name = "txtDsUsername"
        Me.txtDsUsername.Size = New System.Drawing.Size(146, 20)
        Me.txtDsUsername.TabIndex = 2
        '
        'txtDsServerName
        '
        Me.txtDsServerName.Location = New System.Drawing.Point(135, 77)
        Me.txtDsServerName.Name = "txtDsServerName"
        Me.txtDsServerName.Size = New System.Drawing.Size(146, 20)
        Me.txtDsServerName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Remote Procedure"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(135, 144)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(377, 20)
        Me.TextBox1.TabIndex = 5
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(26, 120)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(171, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Enable Remote Procedure Call"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(135, 170)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(377, 20)
        Me.TextBox2.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Remote DLL"
        '
        'frmPreference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 447)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPreference"
        Me.Text = "frmPreference"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblWebserviceAddress As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWebserviceAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtAsDll As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoManual As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAuto As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDsDSNFormat As System.Windows.Forms.TextBox
    Friend WithEvents txtDsDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents txtDsPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDsUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtDsServerName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLocalDll As System.Windows.Forms.TextBox
    Friend WithEvents chkReloadModuleEveryProgram As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
