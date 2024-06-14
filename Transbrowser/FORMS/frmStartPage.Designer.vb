<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartPage
    Inherits WeifenLuo.WinFormsUI.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartPage))
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.pnlLogin = New System.Windows.Forms.Panel
        Me.chkRemember = New System.Windows.Forms.CheckBox
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.lblBuild = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblCrossroads = New System.Windows.Forms.Label
        Me.imgError = New System.Windows.Forms.PictureBox
        Me.imgWait = New System.Windows.Forms.PictureBox
        Me.imgStatus = New System.Windows.Forms.PictureBox
        Me.lblLoginMessage = New System.Windows.Forms.Label
        Me.btnLogin = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PnlWelcome = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlLogin.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.imgError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlWelcome.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(24, 90)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "&Username"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(24, 117)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "&Password"
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.Transparent
        Me.pnlLogin.Controls.Add(Me.chkRemember)
        Me.pnlLogin.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlLogin.Controls.Add(Me.imgError)
        Me.pnlLogin.Controls.Add(Me.imgWait)
        Me.pnlLogin.Controls.Add(Me.imgStatus)
        Me.pnlLogin.Controls.Add(Me.lblLoginMessage)
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Controls.Add(Me.txtUserName)
        Me.pnlLogin.Controls.Add(Me.Label1)
        Me.pnlLogin.Controls.Add(Me.lblPassword)
        Me.pnlLogin.Controls.Add(Me.lblUsername)
        Me.pnlLogin.Location = New System.Drawing.Point(94, 93)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(836, 310)
        Me.pnlLogin.TabIndex = 0
        '
        'chkRemember
        '
        Me.chkRemember.AutoSize = True
        Me.chkRemember.Location = New System.Drawing.Point(98, 140)
        Me.chkRemember.Name = "chkRemember"
        Me.chkRemember.Size = New System.Drawing.Size(95, 17)
        Me.chkRemember.TabIndex = 6
        Me.chkRemember.Text = "Remember Me"
        Me.chkRemember.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.lblBuild)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblVersion)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblCrossroads)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(17, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(544, 20)
        Me.FlowLayoutPanel1.TabIndex = 13
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.Location = New System.Drawing.Point(3, 0)
        Me.lblBuild.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(170, 13)
        Me.lblBuild.TabIndex = 0
        Me.lblBuild.Text = "Transbrowser 2009i,  Build Version"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(174, 0)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "lblVersion"
        '
        'lblCrossroads
        '
        Me.lblCrossroads.AutoSize = True
        Me.lblCrossroads.Location = New System.Drawing.Point(228, 0)
        Me.lblCrossroads.Margin = New System.Windows.Forms.Padding(1, 0, 3, 0)
        Me.lblCrossroads.Name = "lblCrossroads"
        Me.lblCrossroads.Size = New System.Drawing.Size(74, 13)
        Me.lblCrossroads.TabIndex = 2
        Me.lblCrossroads.Text = "Crossroads (g)"
        '
        'imgError
        '
        Me.imgError.Image = CType(resources.GetObject("imgError.Image"), System.Drawing.Image)
        Me.imgError.Location = New System.Drawing.Point(27, 206)
        Me.imgError.Name = "imgError"
        Me.imgError.Size = New System.Drawing.Size(16, 16)
        Me.imgError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgError.TabIndex = 12
        Me.imgError.TabStop = False
        Me.imgError.Visible = False
        '
        'imgWait
        '
        Me.imgWait.Image = CType(resources.GetObject("imgWait.Image"), System.Drawing.Image)
        Me.imgWait.Location = New System.Drawing.Point(27, 180)
        Me.imgWait.Name = "imgWait"
        Me.imgWait.Size = New System.Drawing.Size(16, 16)
        Me.imgWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgWait.TabIndex = 11
        Me.imgWait.TabStop = False
        Me.imgWait.Visible = False
        '
        'imgStatus
        '
        Me.imgStatus.InitialImage = CType(resources.GetObject("imgStatus.InitialImage"), System.Drawing.Image)
        Me.imgStatus.Location = New System.Drawing.Point(98, 222)
        Me.imgStatus.Name = "imgStatus"
        Me.imgStatus.Size = New System.Drawing.Size(16, 16)
        Me.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgStatus.TabIndex = 10
        Me.imgStatus.TabStop = False
        '
        'lblLoginMessage
        '
        Me.lblLoginMessage.Location = New System.Drawing.Point(116, 224)
        Me.lblLoginMessage.Name = "lblLoginMessage"
        Me.lblLoginMessage.Size = New System.Drawing.Size(597, 71)
        Me.lblLoginMessage.TabIndex = 7
        Me.lblLoginMessage.Text = "loginmessage"
        '
        'btnLogin
        '
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Location = New System.Drawing.Point(96, 181)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(81, 25)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(96, 114)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPassword.Size = New System.Drawing.Size(143, 20)
        Me.txtPassword.TabIndex = 4
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(96, 87)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(143, 20)
        Me.txtUserName.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.My.Resources.Resources.tbtxt
        Me.PictureBox1.Location = New System.Drawing.Point(448, 476)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(290, 201)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'PnlWelcome
        '
        Me.PnlWelcome.BackColor = System.Drawing.Color.Transparent
        Me.PnlWelcome.Controls.Add(Me.Label3)
        Me.PnlWelcome.Controls.Add(Me.Label2)
        Me.PnlWelcome.Location = New System.Drawing.Point(94, 409)
        Me.PnlWelcome.Name = "PnlWelcome"
        Me.PnlWelcome.Size = New System.Drawing.Size(537, 293)
        Me.PnlWelcome.TabIndex = 6
        Me.PnlWelcome.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "nama"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Welcome"
        '
        'frmStartPage
        '
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.My.Resources.Resources.tbbg1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(778, 714)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.PnlWelcome)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStartPage"
        Me.TabText = "Start Page"
        Me.Text = "Start Page"
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.imgError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlWelcome.ResumeLayout(False)
        Me.PnlWelcome.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents pnlLogin As System.Windows.Forms.Panel
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblBuild As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblLoginMessage As System.Windows.Forms.Label
    Friend WithEvents imgStatus As System.Windows.Forms.PictureBox
    Friend WithEvents imgWait As System.Windows.Forms.PictureBox
    Friend WithEvents imgError As System.Windows.Forms.PictureBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblCrossroads As System.Windows.Forms.Label
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PnlWelcome As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
