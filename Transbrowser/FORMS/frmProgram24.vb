Imports WeifenLuo.WinFormsUI

Public Class frmProgram24
    Inherits DockContent

    Private FormMain As frmMain
    Private ObjSolutionProgram As SolutionProgram


#Region " Constructor "
    Public Sub New(ByVal SolutionProgram As SolutionProgram)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ObjSolutionProgram = SolutionProgram

    End Sub
#End Region

    Private Sub frmProgram_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim i As Integer
        Dim oCtl As Object
        Dim mdiParent As frmMain = Me.MdiParent


        If mdiParent IsNot Nothing Then
            mdiParent.DataToolStripMenuItem.Visible = True
            FormMain.SolutionProgramSelected(ObjSolutionProgram)
            For i = 0 To Me.Controls.Count - 1
                oCtl = Me.Controls(i)
                If oCtl.Name = "MainControl" Then
                    oCtl.SyncronizeControlEnableState()
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub frmProgram_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Dim mdiParent As frmMain = Me.MdiParent
        If mdiParent IsNot Nothing Then
            mdiParent.DataToolStripMenuItem.Visible = False

        End If
    End Sub

    Private Sub frmProgram_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim mdiParent As frmMain = Me.MdiParent
        If mdiParent IsNot Nothing Then
            mdiParent.DataToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub frmProgram_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim oCtl As Object = Me.Controls(0)
        Dim CancelClose As Boolean = False

        Try
            CancelClose = oCtl.ControlClosing()
        Catch ex As Exception
        End Try
        e.Cancel = CancelClose
    End Sub

    Private Sub frmProgram_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormMain = Me.MdiParent
    End Sub


    Public Function SendMessageToControl(ByVal Message As String) As Boolean
        Dim oCtl As Object = Me.Controls(0)

        Try

            Select Case Message
                Case "New"
                    oCtl.btnNew_Click()
                Case "Save"
                    oCtl.btnSave_Click()
                Case "Print"
                    oCtl.btnPrint_Click()
                Case "PrintPreview"
                    oCtl.btnPrintPreview_Click()
                Case "Edit"
                    oCtl.btnEdit_Click()
                Case "Del"
                    oCtl.btnDel_Click()
                Case "Load"
                    oCtl.btnLoad_Click()
                Case "Query"
                    oCtl.btnQuery_Click()
                Case "Refresh"
                    oCtl.btnRefresh_Click()
                Case "Reset"
                    oCtl.btnReset_Click()
                Case "First"
                    oCtl.btnFirst_Click()
                Case "Prev"
                    oCtl.btnPrev_Click()
                Case "Next"
                    oCtl.btnNext_Click()
                Case "Last"
                    oCtl.btnLast_Click()
                Case "HelpTopic"
                    oCtl.btnHelpTopic_Click()
                Case "ShowStatus"
                    oCtl.btnShowStatus_Click()
                Case "ShowConsole"
                    oCtl.btnShowConsole_Click()
                Case "Reserved1"
                    oCtl.btnReserved1_Click()
                Case "Reserved2"
                    oCtl.btnReserved2_Click()
                Case "Reserved3"
                    oCtl.btnReserved3_Click()
                Case "Reserved4"
                    oCtl.btnReserved4_Click()
                Case "Reserved5"
                    oCtl.btnReserved5_Click()
                Case "Reserved6"
                    oCtl.btnReserved6_Click()
            End Select

        Catch ex As Exception
            MessageBox.Show("Command not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

End Class