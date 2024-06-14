<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgBaseMaster
    Inherits Translib.dlgBase

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
        Me.obj_search_txt_masterdata_name = New System.Windows.Forms.TextBox
        Me.obj_chk_masterdata_advance = New System.Windows.Forms.CheckBox
        Me.btnLoad = New System.Windows.Forms.Button
        Me.obj_txt_masterdata_id = New System.Windows.Forms.TextBox
        Me.DgvMaster = New System.Windows.Forms.DataGridView
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.obj_txt_masterdata_name = New System.Windows.Forms.TextBox
        Me.obj_chk_masterdata_name = New System.Windows.Forms.CheckBox
        Me.lbl_id = New System.Windows.Forms.Label
        Me.obj_search_txt_masterdata_advance = New System.Windows.Forms.TextBox
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'obj_search_txt_masterdata_name
        '
        Me.obj_search_txt_masterdata_name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_search_txt_masterdata_name.Location = New System.Drawing.Point(109, 36)
        Me.obj_search_txt_masterdata_name.Name = "obj_search_txt_masterdata_name"
        Me.obj_search_txt_masterdata_name.Size = New System.Drawing.Size(311, 20)
        Me.obj_search_txt_masterdata_name.TabIndex = 4
        '
        'obj_chk_masterdata_advance
        '
        Me.obj_chk_masterdata_advance.AutoSize = True
        Me.obj_chk_masterdata_advance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_chk_masterdata_advance.Location = New System.Drawing.Point(18, 62)
        Me.obj_chk_masterdata_advance.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.obj_chk_masterdata_advance.Name = "obj_chk_masterdata_advance"
        Me.obj_chk_masterdata_advance.Size = New System.Drawing.Size(85, 17)
        Me.obj_chk_masterdata_advance.TabIndex = 6
        Me.obj_chk_masterdata_advance.Text = "Adv. &Search"
        Me.obj_chk_masterdata_advance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_chk_masterdata_advance.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(345, 88)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 5
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'obj_txt_masterdata_id
        '
        Me.obj_txt_masterdata_id.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_txt_masterdata_id.Location = New System.Drawing.Point(109, 10)
        Me.obj_txt_masterdata_id.Name = "obj_txt_masterdata_id"
        Me.obj_txt_masterdata_id.ReadOnly = True
        Me.obj_txt_masterdata_id.Size = New System.Drawing.Size(115, 20)
        Me.obj_txt_masterdata_id.TabIndex = 1
        '
        'DgvMaster
        '
        Me.DgvMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMaster.Location = New System.Drawing.Point(3, 118)
        Me.DgvMaster.Name = "DgvMaster"
        Me.DgvMaster.Size = New System.Drawing.Size(430, 296)
        Me.DgvMaster.TabIndex = 8
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.obj_txt_masterdata_name)
        Me.pnlMain.Controls.Add(Me.DgvMaster)
        Me.pnlMain.Controls.Add(Me.obj_chk_masterdata_name)
        Me.pnlMain.Controls.Add(Me.lbl_id)
        Me.pnlMain.Controls.Add(Me.obj_txt_masterdata_id)
        Me.pnlMain.Controls.Add(Me.btnLoad)
        Me.pnlMain.Controls.Add(Me.obj_chk_masterdata_advance)
        Me.pnlMain.Controls.Add(Me.obj_search_txt_masterdata_name)
        Me.pnlMain.Controls.Add(Me.obj_search_txt_masterdata_advance)
        Me.pnlMain.Location = New System.Drawing.Point(1, 1)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(436, 419)
        Me.pnlMain.TabIndex = 0
        '
        'obj_txt_masterdata_name
        '
        Me.obj_txt_masterdata_name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_txt_masterdata_name.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_txt_masterdata_name.Location = New System.Drawing.Point(227, 10)
        Me.obj_txt_masterdata_name.Name = "obj_txt_masterdata_name"
        Me.obj_txt_masterdata_name.ReadOnly = True
        Me.obj_txt_masterdata_name.Size = New System.Drawing.Size(193, 20)
        Me.obj_txt_masterdata_name.TabIndex = 2
        '
        'obj_chk_masterdata_name
        '
        Me.obj_chk_masterdata_name.AutoSize = True
        Me.obj_chk_masterdata_name.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_chk_masterdata_name.Checked = True
        Me.obj_chk_masterdata_name.CheckState = System.Windows.Forms.CheckState.Checked
        Me.obj_chk_masterdata_name.Location = New System.Drawing.Point(49, 38)
        Me.obj_chk_masterdata_name.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.obj_chk_masterdata_name.Name = "obj_chk_masterdata_name"
        Me.obj_chk_masterdata_name.Size = New System.Drawing.Size(54, 17)
        Me.obj_chk_masterdata_name.TabIndex = 3
        Me.obj_chk_masterdata_name.Text = "&Name"
        Me.obj_chk_masterdata_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.obj_chk_masterdata_name.UseVisualStyleBackColor = True
        '
        'lbl_id
        '
        Me.lbl_id.Location = New System.Drawing.Point(8, 10)
        Me.lbl_id.Name = "lbl_id"
        Me.lbl_id.Size = New System.Drawing.Size(95, 18)
        Me.lbl_id.TabIndex = 0
        Me.lbl_id.Text = "ID"
        Me.lbl_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'obj_search_txt_masterdata_advance
        '
        Me.obj_search_txt_masterdata_advance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_search_txt_masterdata_advance.Enabled = False
        Me.obj_search_txt_masterdata_advance.Location = New System.Drawing.Point(109, 60)
        Me.obj_search_txt_masterdata_advance.Name = "obj_search_txt_masterdata_advance"
        Me.obj_search_txt_masterdata_advance.Size = New System.Drawing.Size(311, 20)
        Me.obj_search_txt_masterdata_advance.TabIndex = 7
        '
        'dlgBaseMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(438, 456)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "dlgBaseMaster"
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents obj_search_txt_masterdata_name As System.Windows.Forms.TextBox
    Friend WithEvents obj_chk_masterdata_advance As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents obj_txt_masterdata_id As System.Windows.Forms.TextBox
    Friend WithEvents DgvMaster As System.Windows.Forms.DataGridView
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents obj_chk_masterdata_name As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_id As System.Windows.Forms.Label
    Friend WithEvents obj_search_txt_masterdata_advance As System.Windows.Forms.TextBox
    Friend WithEvents obj_txt_masterdata_name As System.Windows.Forms.TextBox

End Class
