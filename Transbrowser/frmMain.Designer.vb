<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DockPanel = New WeifenLuo.WinFormsUI.DockPanel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.txtStatusUsername = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtStatusServername = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtStatusDatabasename = New System.Windows.Forms.ToolStripStatusLabel
        Me.pbProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.txtSessionID = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadedModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PreferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QueriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.FirstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SolutionExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StartPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpTopicsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CaseStudiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DockPanel
        '
        Me.DockPanel.ActiveAutoHideContent = Nothing
        Me.DockPanel.BackColor = System.Drawing.Color.Gray
        Me.DockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DockPanel.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel.Name = "DockPanel"
        Me.DockPanel.ShowDocumentIcon = True
        Me.DockPanel.Size = New System.Drawing.Size(887, 498)
        Me.DockPanel.TabIndex = 9
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.My.Resources.Resources.tolbarbg
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStatusUsername, Me.txtStatusServername, Me.txtStatusDatabasename, Me.pbProgress, Me.txtSessionID})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 476)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(887, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtStatusUsername
        '
        Me.txtStatusUsername.AutoSize = False
        Me.txtStatusUsername.BackColor = System.Drawing.Color.Transparent
        Me.txtStatusUsername.ForeColor = System.Drawing.Color.White
        Me.txtStatusUsername.Image = CType(resources.GetObject("txtStatusUsername.Image"), System.Drawing.Image)
        Me.txtStatusUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtStatusUsername.Margin = New System.Windows.Forms.Padding(0, 3, 20, 2)
        Me.txtStatusUsername.Name = "txtStatusUsername"
        Me.txtStatusUsername.Size = New System.Drawing.Size(150, 17)
        Me.txtStatusUsername.Text = "UserName"
        Me.txtStatusUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStatusServername
        '
        Me.txtStatusServername.AutoSize = False
        Me.txtStatusServername.BackColor = System.Drawing.Color.Transparent
        Me.txtStatusServername.ForeColor = System.Drawing.Color.White
        Me.txtStatusServername.Image = CType(resources.GetObject("txtStatusServername.Image"), System.Drawing.Image)
        Me.txtStatusServername.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtStatusServername.Margin = New System.Windows.Forms.Padding(0, 3, 20, 2)
        Me.txtStatusServername.Name = "txtStatusServername"
        Me.txtStatusServername.Size = New System.Drawing.Size(200, 17)
        Me.txtStatusServername.Text = "ServerName"
        Me.txtStatusServername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStatusDatabasename
        '
        Me.txtStatusDatabasename.AutoSize = False
        Me.txtStatusDatabasename.BackColor = System.Drawing.Color.Transparent
        Me.txtStatusDatabasename.ForeColor = System.Drawing.Color.White
        Me.txtStatusDatabasename.Image = CType(resources.GetObject("txtStatusDatabasename.Image"), System.Drawing.Image)
        Me.txtStatusDatabasename.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtStatusDatabasename.Name = "txtStatusDatabasename"
        Me.txtStatusDatabasename.Size = New System.Drawing.Size(522, 17)
        Me.txtStatusDatabasename.Spring = True
        Me.txtStatusDatabasename.Text = "DatabaseName"
        Me.txtStatusDatabasename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtStatusDatabasename.Visible = False
        '
        'pbProgress
        '
        Me.pbProgress.Margin = New System.Windows.Forms.Padding(1, 3, 20, 3)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(100, 16)
        Me.pbProgress.Visible = False
        '
        'txtSessionID
        '
        Me.txtSessionID.BackColor = System.Drawing.Color.Transparent
        Me.txtSessionID.ForeColor = System.Drawing.Color.White
        Me.txtSessionID.Image = CType(resources.GetObject("txtSessionID.Image"), System.Drawing.Image)
        Me.txtSessionID.Name = "txtSessionID"
        Me.txtSessionID.Size = New System.Drawing.Size(127, 17)
        Me.txtSessionID.Text = "ToolStripStatusLabel1"
        Me.txtSessionID.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImage = Global.My.Resources.Resources.tolbarbg
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SessionToolStripMenuItem, Me.DataToolStripMenuItem, Me.ViewToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(887, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SessionToolStripMenuItem
        '
        Me.SessionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.LoadedModuleToolStripMenuItem, Me.LoginToolStripMenuItem, Me.LogoutToolStripMenuItem, Me.ToolStripSeparator1, Me.PreferenceToolStripMenuItem, Me.ToolStripSeparator7, Me.PrintSetupToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ToolStripSeparator6, Me.ExitToolStripMenuItem})
        Me.SessionToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SessionToolStripMenuItem.Name = "SessionToolStripMenuItem"
        Me.SessionToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.SessionToolStripMenuItem.Text = "&Session"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Enabled = False
        Me.ChangePasswordToolStripMenuItem.Image = CType(resources.GetObject("ChangePasswordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "&Change Password"
        '
        'LoadedModuleToolStripMenuItem
        '
        Me.LoadedModuleToolStripMenuItem.Name = "LoadedModuleToolStripMenuItem"
        Me.LoadedModuleToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.LoadedModuleToolStripMenuItem.Text = "Loaded Module"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Image = CType(resources.GetObject("LoginToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Image = CType(resources.GetObject("LogoutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        Me.LogoutToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'PreferenceToolStripMenuItem
        '
        Me.PreferenceToolStripMenuItem.Image = CType(resources.GetObject("PreferenceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreferenceToolStripMenuItem.Name = "PreferenceToolStripMenuItem"
        Me.PreferenceToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PreferenceToolStripMenuItem.Text = "P&reference"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(168, 6)
        '
        'PrintSetupToolStripMenuItem
        '
        Me.PrintSetupToolStripMenuItem.Name = "PrintSetupToolStripMenuItem"
        Me.PrintSetupToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PrintSetupToolStripMenuItem.Text = "Print Setup"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Preview"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(168, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadDataToolStripMenuItem, Me.QueriToolStripMenuItem, Me.ResetToolStripMenuItem, Me.ToolStripSeparator3, Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DelToolStripMenuItem, Me.ToolStripSeparator4, Me.CancelToolStripMenuItem, Me.CancelAllToolStripMenuItem, Me.ToolStripSeparator5, Me.FirstToolStripMenuItem, Me.PreviousToolStripMenuItem, Me.NextToolStripMenuItem, Me.LastToolStripMenuItem})
        Me.DataToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.DataToolStripMenuItem.Text = "&Data"
        Me.DataToolStripMenuItem.Visible = False
        '
        'LoadDataToolStripMenuItem
        '
        Me.LoadDataToolStripMenuItem.Image = CType(resources.GetObject("LoadDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LoadDataToolStripMenuItem.Name = "LoadDataToolStripMenuItem"
        Me.LoadDataToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.LoadDataToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.LoadDataToolStripMenuItem.Text = "&Load Data"
        '
        'QueriToolStripMenuItem
        '
        Me.QueriToolStripMenuItem.Image = CType(resources.GetObject("QueriToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QueriToolStripMenuItem.Name = "QueriToolStripMenuItem"
        Me.QueriToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.QueriToolStripMenuItem.Text = "&Queri"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Enabled = False
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ResetToolStripMenuItem.Text = "&Reset"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(153, 6)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'DelToolStripMenuItem
        '
        Me.DelToolStripMenuItem.Image = CType(resources.GetObject("DelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DelToolStripMenuItem.Name = "DelToolStripMenuItem"
        Me.DelToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.DelToolStripMenuItem.Text = "&Delete"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(153, 6)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Enabled = False
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CancelToolStripMenuItem.Text = "&Cancel"
        '
        'CancelAllToolStripMenuItem
        '
        Me.CancelAllToolStripMenuItem.Enabled = False
        Me.CancelAllToolStripMenuItem.Name = "CancelAllToolStripMenuItem"
        Me.CancelAllToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CancelAllToolStripMenuItem.Text = "Cancel &All"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(153, 6)
        '
        'FirstToolStripMenuItem
        '
        Me.FirstToolStripMenuItem.Enabled = False
        Me.FirstToolStripMenuItem.Image = CType(resources.GetObject("FirstToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FirstToolStripMenuItem.Name = "FirstToolStripMenuItem"
        Me.FirstToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.FirstToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.FirstToolStripMenuItem.Text = "&First"
        '
        'PreviousToolStripMenuItem
        '
        Me.PreviousToolStripMenuItem.Enabled = False
        Me.PreviousToolStripMenuItem.Image = CType(resources.GetObject("PreviousToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreviousToolStripMenuItem.Name = "PreviousToolStripMenuItem"
        Me.PreviousToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.PreviousToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PreviousToolStripMenuItem.Text = "&Previous"
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Enabled = False
        Me.NextToolStripMenuItem.Image = CType(resources.GetObject("NextToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.NextToolStripMenuItem.Text = "N&ext"
        '
        'LastToolStripMenuItem
        '
        Me.LastToolStripMenuItem.Enabled = False
        Me.LastToolStripMenuItem.Image = CType(resources.GetObject("LastToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LastToolStripMenuItem.Name = "LastToolStripMenuItem"
        Me.LastToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.LastToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.LastToolStripMenuItem.Text = "Las&t"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolutionExplorerToolStripMenuItem, Me.StartPageToolStripMenuItem, Me.ToolStripMenuItem1, Me.StatusToolStripMenuItem})
        Me.ViewToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'SolutionExplorerToolStripMenuItem
        '
        Me.SolutionExplorerToolStripMenuItem.CheckOnClick = True
        Me.SolutionExplorerToolStripMenuItem.Name = "SolutionExplorerToolStripMenuItem"
        Me.SolutionExplorerToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SolutionExplorerToolStripMenuItem.Text = "Solution Explorer"
        '
        'StartPageToolStripMenuItem
        '
        Me.StartPageToolStripMenuItem.Image = CType(resources.GetObject("StartPageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StartPageToolStripMenuItem.Name = "StartPageToolStripMenuItem"
        Me.StartPageToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.StartPageToolStripMenuItem.Text = "Start Page"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 6)
        '
        'StatusToolStripMenuItem
        '
        Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
        Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.StatusToolStripMenuItem.Text = "Status"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.WindowToolStripMenuItem.Text = "&Window"
        Me.WindowToolStripMenuItem.Visible = False
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpTopicsToolStripMenuItem, Me.CaseStudiesToolStripMenuItem, Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'HelpTopicsToolStripMenuItem
        '
        Me.HelpTopicsToolStripMenuItem.Name = "HelpTopicsToolStripMenuItem"
        Me.HelpTopicsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.HelpTopicsToolStripMenuItem.Text = "Help Topics"
        '
        'CaseStudiesToolStripMenuItem
        '
        Me.CaseStudiesToolStripMenuItem.Name = "CaseStudiesToolStripMenuItem"
        Me.CaseStudiesToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CaseStudiesToolStripMenuItem.Text = "Case &Studies..."
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents..."
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.IndexToolStripMenuItem.Text = "&Index..."
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SearchToolStripMenuItem.Text = "&Search..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(156, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImage = Global.My.Resources.Resources.tbbg1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(887, 498)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DockPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Text = "Transbrowser 2009i"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents DockPanel As WeifenLuo.WinFormsUI.DockPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SessionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadedModuleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PreferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QueriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FirstToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LastToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolutionExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpTopicsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CaseStudiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtStatusUsername As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtStatusServername As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtStatusDatabasename As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pbProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents txtSessionID As System.Windows.Forms.ToolStripStatusLabel

End Class
