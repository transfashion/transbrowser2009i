Imports WeifenLuo.WinFormsUI

Public Class frmSolution
    Inherits DockContent

    Private ObjTreeNode As System.Windows.Forms.TreeNode
    Private CurrentSolutionProgram As Translib.SolutionProgram
    Private mFormMain As frmMain
    Private HadBeenCalled As Boolean = False

    Private FormMainActiveChildId As String



#Region " ContextMenuStrip Window Position"

    Private Sub FloatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FloatingToolStripMenuItem.Click
        Me.DockState = WeifenLuo.WinFormsUI.DockState.Float
    End Sub

    Private Sub DockableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DockableToolStripMenuItem.Click
        Me.DockState = Me.ShowHint
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub AutoHideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoHideToolStripMenuItem.Click
        Select Case Me.DockState
            Case WeifenLuo.WinFormsUI.DockState.DockBottom
                DockState = WeifenLuo.WinFormsUI.DockState.DockBottomAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockTop
                DockState = WeifenLuo.WinFormsUI.DockState.DockTopAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockLeft
                DockState = WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockRight
                DockState = WeifenLuo.WinFormsUI.DockState.DockRightAutoHide
        End Select
    End Sub

    Private Sub TabbedDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabbedDocumentToolStripMenuItem.Click
        DockState = WeifenLuo.WinFormsUI.DockState.Document
    End Sub



    Private Sub frmSolution_DockStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockStateChanged
        For Each item As ToolStripMenuItem In ContextMenuDock.Items
            item.Checked = False
        Next
        Select Case Me.DockState

            Case WeifenLuo.WinFormsUI.DockState.Document
                TabbedDocumentToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.DockState.Float
                FloatingToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.DockState.DockBottomAutoHide, _
                 WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide, _
                 WeifenLuo.WinFormsUI.DockState.DockRightAutoHide, _
                 WeifenLuo.WinFormsUI.DockState.DockTopAutoHide

                AutoHideToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.DockState.DockBottom, _
                 WeifenLuo.WinFormsUI.DockState.DockLeft, _
                 WeifenLuo.WinFormsUI.DockState.DockRight, _
                 WeifenLuo.WinFormsUI.DockState.DockTop

                DockableToolStripMenuItem.Checked = True

        End Select


        Dim i As Integer
        Dim mdiChild As frmProgram

        If Me.TreeViewSolution.Nodes IsNot Nothing Then

            If Me.TreeViewSolution.Nodes.Count > 0 Then
                For i = 0 To Me.mFormMain.MdiChildren.Length - 1
                    If Me.mFormMain.MdiChildren(i).Name <> "frmStartPage" And Me.mFormMain.MdiChildren(i).Name <> "frmSolution" Then
                        mdiChild = CType(Me.mFormMain.MdiChildren(i), frmProgram)
                        If mdiChild.ProgramId = Me.FormMainActiveChildId Then
                            Me.mFormMain.MdiChildren(i).Activate()
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Else
        End If


    End Sub




#End Region

#Region " Public Function "

    Public Function SetGroupDatasource(ByVal arrdatagroup As ArrayList) As Boolean
        Dim objGroup As Translib.UserGroup = CType(arrdatagroup(0), Translib.UserGroup)

        Me.ComboBoxGroup.DataSource = arrdatagroup
        Me.ComboBoxGroup.DisplayMember = "Name"
        Me.ComboBoxGroup.ValueMember = "Id"
        Me.ComboBoxGroup.Enabled = True

        Me.btnRefresh.Enabled = True

    End Function

    Public Function SetProgramDatasource(ByVal arrdataprogram As ArrayList) As Boolean
        Dim i, n As Integer
        Dim objProgram As Translib.SolutionProgram
        Dim ObjTreeNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TransCorp.")

        Dim ObjProgramNode As System.Windows.Forms.TreeNode
        Dim ObjTreeNodeMaster As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Master")
        Dim ObjTreeNodeTransaksi As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Transaction")
        Dim ObjTreeNodeReport As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Report")


        Me.TreeViewSolution.Nodes.Clear()
        Me.mFormMain.ObjImageList.Images.Clear()
        Me.mFormMain.ObjImageList.Images.Add("_TransBrowser_", Me.mFormMain.LoadImage("Desktop.ico"))
        Me.mFormMain.ObjImageList.Images.Add("TbTransaksi.ico", Me.mFormMain.LoadImage("TbTransaksi.ico"))
        Me.mFormMain.ObjImageList.Images.Add("TbMaster.ico", Me.mFormMain.LoadImage("TbMaster.ico"))
        Me.mFormMain.ObjImageList.Images.Add("TbLaporan.ico", Me.mFormMain.LoadImage("TbLaporan.ico"))



        ObjTreeNodeMaster.ImageKey = "TbMaster.ico"
        ObjTreeNodeMaster.SelectedImageKey = "TbMaster.ico"
        ObjTreeNodeMaster.StateImageKey = "TbMaster.ico"

        ObjTreeNodeTransaksi.ImageKey = "TbTransaksi.ico"
        ObjTreeNodeTransaksi.SelectedImageKey = "TbTransaksi.ico"
        ObjTreeNodeTransaksi.StateImageKey = "TbTransaksi.ico"

        ObjTreeNodeReport.ImageKey = "TbLaporan.ico"
        ObjTreeNodeReport.SelectedImageKey = "TbLaporan.ico"
        ObjTreeNodeReport.StateImageKey = "TbLaporan.ico"


        Me.TreeViewSolution.ImageList = Me.mFormMain.ObjImageList
        Me.TreeViewSolution.Enabled = True
        n = arrdataprogram.Count
        For i = 0 To n - 1
            objProgram = CType(arrdataprogram(i), Translib.SolutionProgram)
            ObjProgramNode = New System.Windows.Forms.TreeNode(objProgram.Title)

            If Not Me.mFormMain.ObjImageList.Images.ContainsKey(objProgram.Icon) Then
                Me.mFormMain.ObjImageList.Images.Add(objProgram.Icon, Me.mFormMain.LoadImage(objProgram.Icon))
            End If

            ObjProgramNode.ImageKey = objProgram.Icon
            ObjProgramNode.SelectedImageKey = objProgram.Icon
            ObjProgramNode.StateImageKey = objProgram.Icon
            ObjProgramNode.Tag = objProgram


            Select Case objProgram.Type
                Case "1"
                    ObjTreeNodeMaster.Nodes.Add(ObjProgramNode)
                Case "2"
                    ObjTreeNodeTransaksi.Nodes.Add(ObjProgramNode)
                Case "3"
                    ObjTreeNodeReport.Nodes.Add(ObjProgramNode)
            End Select
        Next

        ObjTreeNode.Nodes.Add(ObjTreeNodeMaster)
        ObjTreeNode.Nodes.Add(ObjTreeNodeTransaksi)
        ObjTreeNode.Nodes.Add(ObjTreeNodeReport)
        Me.TreeViewSolution.Nodes.Add(ObjTreeNode)
        Me.TreeViewSolution.ExpandAll()

    End Function


    Public Function Logout() As Boolean
        Me.TreeViewSolution.Nodes.Clear()
        Me.ComboBoxGroup.DataSource = Nothing
        Me.ComboBoxGroup.Items.Clear()
        Me.TreeViewSolution.Enabled = False
        Me.ComboBoxGroup.Enabled = False
        Me.btnRefresh.Enabled = False
        Me.Cursor = Cursors.Arrow
    End Function

#End Region



    Public Sub New(ByRef FormMain As frmMain)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mFormMain = FormMain
        Me.MdiParent = mFormMain

    End Sub

    Private Sub TreeViewSolution_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewSolution.AfterSelect
        Dim objProgram As Translib.SolutionProgram

        objProgram = CType(e.Node.Tag, Translib.SolutionProgram)

        If objProgram IsNot Nothing Then
            Me.txtObject.Text = objProgram.Instance
            Me.txtNamespace.Text = objProgram.Ns
            Me.txtDLL.Text = objProgram.Dll
            Me.txtParameter.Text = ""
            Me.txtDescription.Text = objProgram.Description
        Else
            Me.txtObject.Text = ""
            Me.txtNamespace.Text = ""
            Me.txtDLL.Text = ""
            Me.txtParameter.Text = ""
            Me.txtDescription.Text = ""
        End If

        CurrentSolutionProgram = objProgram

    End Sub



    Private Sub TreeViewSolution_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeViewSolution.DoubleClick
        If CurrentSolutionProgram IsNot Nothing Then

            Me.SuspendLayout()
            Try
                Me.mFormMain.Cursor = Cursors.WaitCursor
                Me.mFormMain.OpenNewForm(CurrentSolutionProgram)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Transbrowser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.mFormMain.Cursor = Cursors.Arrow
            End Try
            Me.ResumeLayout()

        End If
    End Sub

    Private Sub ComboBoxGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxGroup.SelectedIndexChanged
        Dim ObjSelectedUserGroup As Translib.UserGroup
        Dim SelectedUserGroupId As String

        Try

            Me.Cursor = Cursors.WaitCursor

            If (Me.ComboBoxGroup.SelectedValue.GetType Is GetType(Translib.UserGroup)) Then
                ObjSelectedUserGroup = CType(Me.ComboBoxGroup.SelectedValue, Translib.UserGroup)
                SelectedUserGroupId = ObjSelectedUserGroup.Id
            Else
                SelectedUserGroupId = CType(Me.ComboBoxGroup.SelectedValue, String)
            End If

            Me.mFormMain.SetProgramlistByGroup(SelectedUserGroupId)

            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmSolution_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        If Me.mFormMain.ActiveMdiChild Is Nothing Then
            Exit Sub
        End If

        If Me.mFormMain.ActiveMdiChild.Name <> "frmStartPage" And Me.mFormMain.ActiveMdiChild.Name <> "frmSolution" Then
            Dim frmActive As frmProgram = CType(Me.mFormMain.ActiveMdiChild, frmProgram)
            FormMainActiveChildId = frmActive.ProgramId
        End If
    End Sub




    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.mFormMain.SetFirstGroup()
    End Sub

    Private Sub TreeViewSolution_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeViewSolution.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim objProgram As Translib.SolutionProgram
            TreeViewSolution.SelectedNode = TreeViewSolution.GetNodeAt(e.Location)
            objProgram = CType(TreeViewSolution.GetNodeAt(e.Location).Tag, Translib.SolutionProgram)
            If objProgram IsNot Nothing Then
                If objProgram.Dll <> "" Then
                    'MessageBox.Show(objProgram.Dll)
                    Dim loc As System.Drawing.Point = e.Location
                    loc.Offset(TreeViewSolution.Location)
                    CurrentSolutionProgram = objProgram
                    Me.ContextMenuProgram.Show(Me.TreeViewSolution, e.Location)
                End If
            End If
        End If

    End Sub


    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        If CurrentSolutionProgram IsNot Nothing Then

            Me.SuspendLayout()
            Try
                Me.mFormMain.Cursor = Cursors.WaitCursor
                Me.mFormMain.OpenNewForm(CurrentSolutionProgram, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Transbrowser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.mFormMain.Cursor = Cursors.Arrow
            End Try
            Me.ResumeLayout()

        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Me.TreeViewSolution_DoubleClick(sender, e)
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

    End Sub
End Class