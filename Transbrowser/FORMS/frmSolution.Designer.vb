<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolution
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolution))
        Me.ContextMenuDock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FloatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DockableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabbedDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoHideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBoxGroup = New System.Windows.Forms.ComboBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TreeViewSolution = New System.Windows.Forms.TreeView
        Me.ContextMenuProgram = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageListIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtObject = New System.Windows.Forms.TextBox
        Me.txtDLL = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNamespace = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtParameter = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.ContextMenuDock.SuspendLayout()
        Me.ContextMenuProgram.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuDock
        '
        Me.ContextMenuDock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FloatingToolStripMenuItem, Me.DockableToolStripMenuItem, Me.TabbedDocumentToolStripMenuItem, Me.AutoHideToolStripMenuItem, Me.HideToolStripMenuItem})
        Me.ContextMenuDock.Name = "ContextMenuStrip1"
        Me.ContextMenuDock.Size = New System.Drawing.Size(174, 114)
        Me.ContextMenuDock.Text = "Window Position"
        '
        'FloatingToolStripMenuItem
        '
        Me.FloatingToolStripMenuItem.CheckOnClick = True
        Me.FloatingToolStripMenuItem.Name = "FloatingToolStripMenuItem"
        Me.FloatingToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FloatingToolStripMenuItem.Text = "Floating"
        '
        'DockableToolStripMenuItem
        '
        Me.DockableToolStripMenuItem.Checked = True
        Me.DockableToolStripMenuItem.CheckOnClick = True
        Me.DockableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DockableToolStripMenuItem.Name = "DockableToolStripMenuItem"
        Me.DockableToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DockableToolStripMenuItem.Text = "Dockable"
        '
        'TabbedDocumentToolStripMenuItem
        '
        Me.TabbedDocumentToolStripMenuItem.CheckOnClick = True
        Me.TabbedDocumentToolStripMenuItem.Name = "TabbedDocumentToolStripMenuItem"
        Me.TabbedDocumentToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.TabbedDocumentToolStripMenuItem.Text = "Tabbed Document"
        '
        'AutoHideToolStripMenuItem
        '
        Me.AutoHideToolStripMenuItem.CheckOnClick = True
        Me.AutoHideToolStripMenuItem.Name = "AutoHideToolStripMenuItem"
        Me.AutoHideToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AutoHideToolStripMenuItem.Text = "Auto Hide"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.CheckOnClick = True
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Groups"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Programs"
        '
        'ComboBoxGroup
        '
        Me.ComboBoxGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxGroup.BackColor = System.Drawing.Color.Gainsboro
        Me.ComboBoxGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxGroup.Enabled = False
        Me.ComboBoxGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxGroup.FormattingEnabled = True
        Me.ComboBoxGroup.Location = New System.Drawing.Point(6, 29)
        Me.ComboBoxGroup.Name = "ComboBoxGroup"
        Me.ComboBoxGroup.Size = New System.Drawing.Size(184, 21)
        Me.ComboBoxGroup.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(6, 248)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(215, 74)
        Me.txtDescription.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Description"
        '
        'TreeViewSolution
        '
        Me.TreeViewSolution.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewSolution.BackColor = System.Drawing.Color.Gainsboro
        Me.TreeViewSolution.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeViewSolution.Enabled = False
        Me.TreeViewSolution.Location = New System.Drawing.Point(6, 83)
        Me.TreeViewSolution.Name = "TreeViewSolution"
        Me.TreeViewSolution.Size = New System.Drawing.Size(215, 29)
        Me.TreeViewSolution.TabIndex = 6
        '
        'ContextMenuProgram
        '
        Me.ContextMenuProgram.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.PropertiesToolStripMenuItem})
        Me.ContextMenuProgram.Name = "ContextMenuProgram"
        Me.ContextMenuProgram.Size = New System.Drawing.Size(128, 70)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ReloadToolStripMenuItem.Text = "&Reload"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.PropertiesToolStripMenuItem.Text = "&Properties"
        '
        'ImageListIcon
        '
        Me.ImageListIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageListIcon.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListIcon.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Instance"
        '
        'txtObject
        '
        Me.txtObject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObject.BackColor = System.Drawing.Color.Gainsboro
        Me.txtObject.Enabled = False
        Me.txtObject.Location = New System.Drawing.Point(68, 120)
        Me.txtObject.Name = "txtObject"
        Me.txtObject.Size = New System.Drawing.Size(153, 21)
        Me.txtObject.TabIndex = 8
        '
        'txtDLL
        '
        Me.txtDLL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDLL.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDLL.Enabled = False
        Me.txtDLL.Location = New System.Drawing.Point(68, 201)
        Me.txtDLL.Name = "txtDLL"
        Me.txtDLL.Size = New System.Drawing.Size(87, 21)
        Me.txtDLL.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(38, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "DLL"
        '
        'txtNamespace
        '
        Me.txtNamespace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNamespace.BackColor = System.Drawing.Color.Gainsboro
        Me.txtNamespace.Enabled = False
        Me.txtNamespace.Location = New System.Drawing.Point(68, 174)
        Me.txtNamespace.Name = "txtNamespace"
        Me.txtNamespace.Size = New System.Drawing.Size(153, 21)
        Me.txtNamespace.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Namespace"
        '
        'txtParameter
        '
        Me.txtParameter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParameter.BackColor = System.Drawing.Color.Gainsboro
        Me.txtParameter.Enabled = False
        Me.txtParameter.Location = New System.Drawing.Point(68, 147)
        Me.txtParameter.Name = "txtParameter"
        Me.txtParameter.Size = New System.Drawing.Size(153, 21)
        Me.txtParameter.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Parameter"
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Enabled = False
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOpen.Location = New System.Drawing.Point(158, 201)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(63, 21)
        Me.btnOpen.TabIndex = 11
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Enabled = False
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(192, 29)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(29, 21)
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'frmSolution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.BackgroundImage = Global.My.Resources.Resources.tolbarbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(225, 330)
        Me.CloseButton = False
        Me.Controls.Add(Me.txtParameter)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNamespace)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDLL)
        Me.Controls.Add(Me.txtObject)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TreeViewSolution)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.ComboBoxGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSolution"
        Me.ShowHint = WeifenLuo.WinFormsUI.DockState.DockLeft
        Me.TabPageContextMenuStrip = Me.ContextMenuDock
        Me.TabText = "Solution Explorer"
        Me.Text = "Solution Explorer"
        Me.ContextMenuDock.ResumeLayout(False)
        Me.ContextMenuProgram.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuDock As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FloatingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabbedDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoHideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TreeViewSolution As System.Windows.Forms.TreeView
    Friend WithEvents ImageListIcon As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObject As System.Windows.Forms.TextBox
    Friend WithEvents txtDLL As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNamespace As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtParameter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents ContextMenuProgram As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
