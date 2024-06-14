Public Class uiRptBase

    Public WithEvents bgwRptListLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker


#Region " Contructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.tbtnNew.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnQuery.Enabled = False
        Me.tbtnRowAdd.Enabled = False
        Me.tbtnRowDel.Enabled = False
        Me.ToolStrip1.Visible = True
        Me.ToolStrip1.Enabled = True


        Me.bgwRptListLoader.WorkerReportsProgress = True
        Me.bgwRptListLoader.WorkerSupportsCancellation = True

    End Sub

#End Region

#Region " Ovveridable "

    Public Overridable Function ui_ReportGenerate(ByVal tbl As DataTable, ByVal rdlcobjectname As String, ByVal reportparams As Microsoft.Reporting.WinForms.ReportParameter()) As Boolean
        Dim rptObj As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim rptDatasource As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim state As String = ""
        Dim assembly As System.Reflection.Assembly = Me.uiAssembly
        Dim o As GeneralObject = New GeneralObject()

        If rdlcobjectname = "" Then
            rdlcobjectname = "Translib.rptBasic.rdlc"
            assembly = o.GetType().Assembly
        End If



        rptObj.Dock = System.Windows.Forms.DockStyle.Fill
        rptDatasource.Name = CLSCompliantName(rdlcobjectname)
        rptDatasource.Value = tbl

        Try
            rptObj.LocalReport.LoadReportDefinition(assembly.GetManifestResourceStream(rdlcobjectname))
            rptObj.LocalReport.DataSources.Clear()
            rptObj.LocalReport.DataSources.Add(rptDatasource)
            If rdlcobjectname = "Translib.rptBasic.rdlc" Then
                reportparams = New Microsoft.Reporting.WinForms.ReportParameter() { _
                    New Microsoft.Reporting.WinForms.ReportParameter("ERRMSG", "error"), _
                    New Microsoft.Reporting.WinForms.ReportParameter("DLLFILE", "dllfile"), _
                    New Microsoft.Reporting.WinForms.ReportParameter("RDLC", "rdlc object") _
                }
            End If

            state = "PARAMETER"
            If reportparams IsNot Nothing Then
                rptObj.LocalReport.SetParameters(reportparams)
            End If
            rptObj.LocalReport.EnableExternalImages = True
            rptObj.LocalReport.EnableHyperlinks = True
            rptObj.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
            rptObj.RefreshReport()
            Me.ReportViewer1 = rptObj
        Catch ex As Exception
            If state = "PARAMETER" Then
                Throw New Exception("Wrong parameter definition for " & rdlcobjectname & vbCrLf & "report cannot be loaded.")
            Else
                Throw New Exception(rdlcobjectname & " cannot be loaded.")
            End If
        End Try

        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(rptObj)
        Me.SplitContainer1.Panel2.ResumeLayout()

        rptObj.Focus()

    End Function

    Public Overridable Function ProcessData(ByVal tbl As DataTable, ByVal args As Object) As Boolean
        Dim service As String = args(0) & "_detil"
        Dim criteria As String = args(1)
        Me.bgwRptListLoader = New System.ComponentModel.BackgroundWorker
        Me.bgwRptListLoader.WorkerReportsProgress = True
        Me.bgwRptListLoader.RunWorkerAsync(New Object() {service, tbl, criteria})
    End Function

    Public Overridable Function ReportNavigateTo(ByVal bookmark_id As String, ByRef cancel As Boolean) As Boolean
    End Function


#End Region

    Private Sub ui_FormListLoaded(ByVal webrespond As String, ByVal args As Object) Handles Me.FormListLoaded
        Dim tbl As DataTable = Me.dgvListVirtual.DataSource
        Me.ProcessData(tbl, args)
        Me.bgwListLoader.Dispose()
    End Sub

    Private Sub ReportViewer1_BookmarkNavigation(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.BookmarkNavigationEventArgs) Handles ReportViewer1.BookmarkNavigation
        Dim cancel As Boolean = False
        Me.ReportNavigateTo(e.BookmarkId, cancel)
        e.Cancel = cancel
    End Sub


End Class
