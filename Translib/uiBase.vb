Public Class uiBase

    Public Enum EFormSaveResult
        Nochanges = 0
        SaveError = 1
        SaveSuccess = 2
    End Enum

    Public Enum EBackgroundworkerStatus
        NotExecuted = 0
        Init = 1
        Progress = 2
        Done = 3
        Fail = 4
    End Enum

    Public Enum EDataWalk
        [First] = 1
        [Previous] = 2
        [Next] = 3
        [Last] = 4
    End Enum


    Private mProgram As Translib.SolutionProgram
    Private mDSNLocal As String
    Private mParameter As String
    Private mBrowser As Object = Nothing
    Private mStartupMessage As String
    Private mSessionID As String
    Private mMasterLoaderDelay As Integer = 100
    Private mAllowPrintOnList As Boolean = True
    Private mAllowPrintOnData As Boolean = True

    Private mWebserviceNS As String
    Private mWebserviceNSGlobal As String = "transbrowser"
    Private mWebserviceNSModule As String
    Private mWebServiceObject As String
    Private mWebServiceObjectGlobal As String = "uimaster"
    Private mWebServiceObjectModule As String
    Private mWebRespond As String
    Private mWebSaveRespond As String
    Private mWebSaveService As String
    Private mWebSaveRequest As String
    Private mDdBinding As DataDetilBinding = New DataDetilBinding
    Private mMasterDataLoaderQueue As MasterDataLoaderQueue = New MasterDataLoaderQueue
    Private mIsNew As Boolean
    Private mPrimaryKeyObjectName As String
    Private mBackgroundworkerStatus As EBackgroundworkerStatus
    Private mBackgroundworkerSaveStatus As EBackgroundworkerStatus
    Private mStatus As String
    Private mMessage As String
    Private mProgress As Integer
    Private mTitle As String
    Private mList_RowMax As Integer = 20
    Private mList_RowCount As Long
    Private mList_CurrentPageIndex As Integer = 0

    Friend mUsername As String = "root"
    Friend mWebserviceAddress As String = "http://localhost/transbrowser"
    Friend mDllServer As String = "http://localhost/transbrowser"


    Public Event FormDataOpening(ByRef id As Object)
    Public Event FormDataOpened(ByVal id As Object)
    Public Event FormMasterDataLoaded(ByVal status As EBackgroundworkerStatus, ByVal message As String)
    Public Event FormMasterLoaderError(ByVal service As String, ByVal msg As String, ByVal request As String, ByVal respond As String)
    Public Event FormSaving(ByRef id As Object, ByRef service As String, ByRef datasent As Object)
    Public Event FormSavingCheck(ByRef id As Object, ByRef service As String, ByRef datasent As Object, ByRef cancel As Boolean)
    Public Event FormSaved(ByRef id As Object, ByVal respond As String, ByVal result As EFormSaveResult, ByVal obj As Object, ByVal supressmessage As Boolean)
    Public Event FormListLoaded(ByVal webrespond As String, ByVal args As Object)

    Public Event FormBeforeNew(ByRef result As Object, ByRef cancel As Boolean, ByRef args As Object)
    Public Event FormAfterNew(ByVal result As Object, ByVal args As Object)

    Public Event FormDatawalkExecuting(ByRef check_changes As Boolean, ByRef id As String)
    Public Event FormDatawalkExecuted(ByRef move As Boolean, ByRef id As String)
    Public Event FormDeleting(ByRef id As Object, ByRef message As String, ByRef cancel As Boolean)
    Public Event FormDeleted(ByRef id As Object, ByRef refresh As Boolean)
    Public Event FormRowAdding(ByVal tabname As String, ByVal table As DataTable, ByRef dialogname As String, ByRef cancel As Boolean, ByRef args As Object)
    Public Event FormRowCheck(ByVal tabname As String, ByVal rowadded As DataRow, ByVal args As Object, ByRef cancel As Boolean)
    Public Event FormRowAdded(ByVal tabname As String, ByRef dgv As System.Windows.Forms.DataGridView, ByVal rowadded As DataRow, ByVal args As Object)
    Public Event FormRowEditing(ByVal tabname As String, ByVal table As DataTable, ByRef dialogname As String, ByRef cancel As Boolean, ByRef args As Object)
    Public Event FormRowEdited(ByVal tabname As String, ByVal dgvrowedited As System.Windows.Forms.DataGridViewRow, ByVal args As Object)
    Public Event FormRowDeleting(ByVal tabname As String, ByVal row As System.Windows.Forms.DataGridViewRow, ByRef confirm As Boolean, ByRef msg As String, ByRef cancel As String, ByRef args As Object)
    Public Event FormRowDeleted(ByVal tabname As String, ByVal args As Object)
    Public Event FormRowModified(ByVal tabname As String)
    Public Event FormPrintPreviewExecuting(ByRef cancel As Boolean, ByRef args As Object, ByRef ids As Object, ByRef reportparams As Microsoft.Reporting.WinForms.ReportParameter(), ByRef dllfile As String, ByRef rdlcobjectname As String, ByRef webpage As String, ByRef customprinting As Boolean, ByRef customprintingclass As String)
    Public Event FormTabdetilSelecting(ByVal tabname As String, ByRef obj As Translib.DataDetilBindingTable)
    Public Event FormTabdetilSelected(ByVal tabname As String)
    Public Event FormTabmainSelected(ByVal tabname As String)


    Public Event BackgroundworkerListLoaderCompleted(ByRef bn As System.Windows.Forms.BindingNavigator, ByVal webrespond As String)
    Public Event BackgroundworkerListLoaderCompletedAndDone(ByVal webrespond As String)
    Public Event BackgroundworkerListLoaderCompletedButFail(ByVal webrespond As String)
    Public Event BackgroundworkerDataLoaderCompleted(ByRef tabMain As FlatTabControl.FlatTabControl, ByRef tabDetil As FlatTabControl.FlatTabControl, ByVal webrespond As String)
    Public Event BackgroundworkerDataLoaderCompletedAndDone(ByVal webrespond As String)
    Public Event BackgroundworkerDataLoaderCompletedButFail(ByVal webrespond As String)
    Public Event BackgroundworkerSaveCompleted(ByVal status As EBackgroundworkerStatus, ByVal service As String, ByVal requestheader As String, ByVal webrespond As String)
    Public Event BackgroundworkerSaveCompletedAndDone(ByVal webrespond As String)
    Public Event BackgroundworkerSaveCompletedButFail(ByVal webrespond As String)

    Public WithEvents dsMaster As DataSet = New DataSet()
    Public WithEvents tblList As DataTable
    Public WithEvents tblList_Temp As DataTable
    Public WithEvents tblDetil As DataTable
    Public WithEvents tblProp As DataTable
    Public WithEvents tblLog As DataTable
    Public WithEvents bgwListLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwDataLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwSave As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwNew As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwMasterLoaderQueue As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwMasterLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwPrintLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwPrintWeb As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents bgwDelete As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public WithEvents fLoadingIndicator As frmLoading = New frmLoading()
    Public WithEvents wb As System.Windows.Forms.WebBrowser = New System.Windows.Forms.WebBrowser
    Public WithEvents web_Save As System.Windows.Forms.ToolStripItem
    Public WithEvents web_Preview As System.Windows.Forms.ToolStripItem
    Public WithEvents dgvListVirtual As System.Windows.Forms.DataGridView = New System.Windows.Forms.DataGridView


    Public savework As Boolean
    Public uiAssembly As System.Reflection.Assembly


    ' Document Printing
    Private mDllPrint As String = ""
    Private mDllPrintRDLC As String = ""
    Private mWebserviceDataprintLoader As String = ""
    Private mWebserviceDataprintPageViewer As String = ""

    Public oAsmPrintCol As Collection = New Collection()
    Public oAsmPrint As System.Reflection.Assembly = Nothing


    Private mMASTERLOADED As Boolean = False
    Private mDATAOPENED As Boolean = False
    Private mFORMBINDED As Boolean = False

    Delegate Sub BackgroundworkerInvokeFunction(ByVal arg As Object(), ByVal open As Boolean)
    Delegate Sub BackgroundworkerAddRowFromJsonObjectInvokeFunction(ByRef tbl As DataTable, ByVal obj As Newtonsoft.Json.JavaScriptObject, ByVal auto_generate_column As Boolean)



#Region " Constructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub


#End Region

#Region " Property "

    Public ReadOnly Property Program() As Translib.SolutionProgram
        Get
            Return mProgram
        End Get
    End Property

    Public ReadOnly Property DSNLocal() As String
        Get
            Return mDSNLocal
        End Get
    End Property

    Public ReadOnly Property Parameter() As String
        Get
            Return mParameter
        End Get
    End Property

    Public ReadOnly Property UserName() As String
        Get
            Return mUsername
        End Get
    End Property

    Public ReadOnly Property DLLServer() As String
        Get
            Return mDllServer
        End Get
    End Property

    Public ReadOnly Property WebserviceAddress() As String
        Get
            Return mWebserviceAddress
        End Get
    End Property

    Public ReadOnly Property Browser() As Object
        Get
            Return mBrowser
        End Get
    End Property

    Public ReadOnly Property SessionID() As String
        Get
            Return mSessionID
        End Get
    End Property

    Public ReadOnly Property ddBinding() As DataDetilBinding
        Get
            Return mDdBinding
        End Get
    End Property

    Public ReadOnly Property MasterDataLoaderQueue() As Translib.MasterDataLoaderQueue
        Get
            Return mMasterDataLoaderQueue
        End Get
    End Property

    Public ReadOnly Property VersionNumber() As String
        Get
            Return Me.ProductVersion
        End Get
    End Property

    Public ReadOnly Property UIBaseType() As String
        Get
            Return "uiBase"
        End Get
    End Property

    Public ReadOnly Property MASTERLOADED() As Boolean
        Get
            Return mMASTERLOADED
        End Get
    End Property

    Public ReadOnly Property DATAOPENED() As Boolean
        Get
            Return mDATAOPENED
        End Get
    End Property


    Public Property DllPrintRDLC() As String
        Get
            Return mDllPrintRDLC
        End Get
        Set(ByVal value As String)
            mDllPrintRDLC = value
        End Set
    End Property

    Public Property DllPrint() As String
        Get
            Return mDllPrint
        End Get
        Set(ByVal value As String)
            mDllPrint = value
        End Set
    End Property

    Public Property AllowPrintOnList() As Boolean
        Get
            Return mAllowPrintOnList
        End Get
        Set(ByVal value As Boolean)
            mAllowPrintOnList = value
        End Set
    End Property

    Public Property AllowPrintOnData() As Boolean
        Get
            Return mAllowPrintOnData
        End Get
        Set(ByVal value As Boolean)
            mAllowPrintOnData = value
        End Set
    End Property

    Public Property WebserviceDataprintLoader() As String
        Get
            Return mWebserviceDataprintLoader
        End Get
        Set(ByVal value As String)
            mWebserviceDataprintLoader = value
        End Set
    End Property

    Public Property WebserviceDataprintPageViewer() As String
        Get
            Return mWebserviceDataprintPageViewer
        End Get
        Set(ByVal value As String)
            mWebserviceDataprintPageViewer = value
        End Set
    End Property

    Public Property FORMBINDED() As Boolean
        Get
            Return mFORMBINDED
        End Get
        Set(ByVal value As Boolean)
            mFORMBINDED = value
        End Set
    End Property


    Public Property PrimaryKeyObjectName() As String
        Get
            Return mPrimaryKeyObjectName
        End Get
        Set(ByVal value As String)
            mPrimaryKeyObjectName = value
        End Set
    End Property

    Public Property MasterLoaderDelay() As Integer
        Get
            Return Me.mMasterLoaderDelay
        End Get
        Set(ByVal value As Integer)
            Me.mMasterLoaderDelay = value
        End Set
    End Property

    Public Property StartupMessage() As String
        Get
            Return mStartupMessage
        End Get
        Set(ByVal value As String)
            mStartupMessage = value
        End Set
    End Property

    Public Property BackgroundworkerStatus() As EBackgroundworkerStatus
        Get
            Return Me.mBackgroundworkerStatus
        End Get
        Set(ByVal value As EBackgroundworkerStatus)
            Me.mBackgroundworkerStatus = value
        End Set
    End Property

    Public Property BackgroundworkerSaveStatus() As EBackgroundworkerStatus
        Get
            Return Me.mBackgroundworkerSaveStatus
        End Get
        Set(ByVal value As EBackgroundworkerStatus)
            Me.mBackgroundworkerSaveStatus = value
        End Set
    End Property

    Public Property WebSaveService() As String
        Get
            Return Me.mWebSaveService
        End Get
        Set(ByVal value As String)
            Me.mWebSaveService = value
        End Set
    End Property

    Public Property WebSaveRequest() As String
        Get
            Return Me.mWebSaveRequest
        End Get
        Set(ByVal value As String)
            Me.mWebSaveRequest = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal value As String)
            mStatus = value
        End Set
    End Property

    Public Property Message() As String
        Get
            Return mMessage
        End Get
        Set(ByVal value As String)
            mMessage = value
        End Set
    End Property

    Public Property Progress() As Integer
        Get
            Return mProgress
        End Get
        Set(ByVal value As Integer)
            mProgress = value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return mTitle
        End Get
        Set(ByVal value As String)
            mTitle = value
        End Set
    End Property

    Public Property List_RowMax() As Integer
        Get
            Return mList_RowMax
        End Get
        Set(ByVal value As Integer)
            mList_RowMax = value
        End Set
    End Property

    Public Property List_RowCount() As Long
        Get
            Return mList_RowCount
        End Get
        Set(ByVal value As Long)
            mList_RowCount = value
        End Set
    End Property

    Public Property List_CurrentPageIndex() As Integer
        Get
            Return mList_CurrentPageIndex
        End Get
        Set(ByVal value As Integer)
            mList_CurrentPageIndex = value
        End Set
    End Property

    Public Property WebserviceNS() As String
        Get
            Return mWebserviceNS
        End Get
        Set(ByVal value As String)
            mWebserviceNS = value
        End Set
    End Property

    Public Property WebserviceNSGlobal() As String
        Get
            Return mWebserviceNSGlobal
        End Get
        Set(ByVal value As String)
            mWebserviceNSGlobal = value
        End Set
    End Property

    Public Property WebserviceNSModule() As String
        Get
            Return mWebserviceNSModule
        End Get
        Set(ByVal value As String)
            mWebserviceNSModule = value
        End Set
    End Property

    Public Property WebserviceObject() As String
        Get
            Return mWebServiceObject
        End Get
        Set(ByVal value As String)
            mWebServiceObject = value
        End Set
    End Property

    Public Property WebserviceObjectGlobal() As String
        Get
            Return mWebServiceObjectGlobal
        End Get
        Set(ByVal value As String)
            mWebServiceObjectGlobal = value
        End Set
    End Property

    Public Property WebserviceObjectModule() As String
        Get
            Return mWebServiceObjectModule
        End Get
        Set(ByVal value As String)
            mWebServiceObjectModule = value
        End Set
    End Property

    Public Property WebRespond() As String
        Get
            Return mWebRespond
        End Get
        Set(ByVal value As String)
            mWebRespond = value
        End Set
    End Property

    Public Property WebSaveRespond() As String
        Get
            Return mWebSaveRespond
        End Get
        Set(ByVal value As String)
            mWebSaveRespond = value
        End Set
    End Property

    Public Property IsNew() As Boolean
        Get
            Return mIsNew
        End Get
        Set(ByVal value As Boolean)
            mIsNew = value
        End Set
    End Property

#End Region

#Region " Overridable "

    Public Overridable Function GetActiveDocumentID() As System.Windows.Forms.TextBox
        Dim objTxt As System.Windows.Forms.TextBox = Nothing
        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_Data") Then
                If Me.Controls("ftabMain").Controls("ftabMain_Data").Controls.ContainsKey("PnlDataMaster") Then
                    Dim pnl As System.Windows.Forms.Panel = Me.Controls("ftabMain").Controls("ftabMain_Data").Controls("PnlDataMaster")
                    If pnl.Controls.ContainsKey(Me.PrimaryKeyObjectName) Then
                        objTxt = pnl.Controls(Me.PrimaryKeyObjectName)
                    End If
                End If
            End If
        End If
        Return objTxt
    End Function


    Public Overridable Function GetActiveDocumentIDValue() As Object
        Dim objTxt As System.Windows.Forms.TextBox
        Dim txt As String = ""
        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_Data") Then
                If Me.Controls("ftabMain").Controls("ftabMain_Data").Controls.ContainsKey("PnlDataMaster") Then
                    Dim pnl As System.Windows.Forms.Panel = Me.Controls("ftabMain").Controls("ftabMain_Data").Controls("PnlDataMaster")
                    If pnl.Controls.ContainsKey(Me.PrimaryKeyObjectName) Then
                        objTxt = pnl.Controls(Me.PrimaryKeyObjectName)
                        txt = objTxt.Text
                    End If
                End If
            End If
        End If
        Return txt
    End Function

    Public Overridable Function btnNew_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        '        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function


        Dim res As System.Windows.Forms.DialogResult
        Dim id As String = Me.GetActiveDocumentIDValue()
        Dim tab As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl

        tab = Me.GetTabMain

        If tab.SelectedTab.Name = "ftabMain_Data" Then
            ' Cek apakah current data sedang diedit dan belum disimpan ?
            If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
                res = System.Windows.Forms.MessageBox.Show("Data in document " & id & " has changed." & vbCrLf & vbCrLf & "Do you want to save the changes ?", Me.Title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning)
                Select Case res
                    Case System.Windows.Forms.DialogResult.Yes
                        Me.DataSave(True)
                    Case System.Windows.Forms.DialogResult.No
                    Case System.Windows.Forms.DialogResult.Cancel
                        Exit Function
                End Select
            End If
        End If


        Dim tabmain As FlatTabControl.FlatTabControl
        tabmain = Me.GetTabMain()
        If tabmain IsNot Nothing Then
            If tabmain.SelectedTab.Name <> "ftabMain_Data" Then
                Me.IsNew = True
            End If
        End If
        Me.bgwNew.RunWorkerAsync()

    End Function

    Public Overridable Function btnSave_Click() As Boolean
        Me.DataSave(False)
    End Function

    Public Overridable Function btnPrint_Click() As Boolean
        Me.btnPrintPreview_Click()
    End Function

    Public Overridable Function btnPrintPreview_Click(Optional ByVal PrinterMethod As Object = Nothing) As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        If Me.GetTabMain().SelectedTab.Name = "ftabMain_List" Then
            If Not Me.AllowPrintOnList Then Exit Function
        Else
            If Not Me.AllowPrintOnData Then Exit Function
        End If

        Dim reportparams As Microsoft.Reporting.WinForms.ReportParameter() = New Microsoft.Reporting.WinForms.ReportParameter() {}
        Dim dllfile As String = Me.DllPrint
        Dim rdlcobjectname As String = Me.DllPrintRDLC
        Dim loadassemblyfirst As Boolean = False
        Dim ids As String() = {}
        Dim service As String = Me.WebserviceDataprintLoader
        Dim args As Object() '= New Object() {dllfile, rdlcobjectname, loadassemblyfirst, ids, service, reportparams}
        Dim webpage As String = ""
        Dim customprinting As Boolean = False
        Dim customprintingdll As String = ""
        Dim customprintingclass As String = ""

        Dim cancel As Boolean




        If Me.GetTabMain().SelectedTab.Name = "ftabMain_List" Then
            Dim dgv As System.Windows.Forms.DataGridView
            Dim i As Integer
            Dim primarykey As String = Me.tblList.PrimaryKey(0).ColumnName
            dgv = Me.GetDgvList()
            Array.Resize(ids, dgv.SelectedRows.Count)
            For i = 0 To dgv.SelectedRows.Count - 1
                ids(i) = dgv.SelectedRows(i).Cells(primarykey).Value
            Next
        Else
            Array.Resize(ids, 1)
            ids(0) = Me.GetActiveDocumentIDValue
        End If

        args = Nothing


        'Munculkan POP UP printing method selection
        Dim result As Object
        Dim o As Translib.GeneralObject = New Translib.GeneralObject()
        Dim dlg As Translib.dlgBasePrintSelector = Me.CreateDialog(o.GetType().Assembly.GetType("Translib.dlgBasePrintSelector", True, True), Me.Title)
        webpage = Me.WebserviceDataprintPageViewer
        dlg.Initialize(dllfile, rdlcobjectname, webpage, dllfile)
        result = dlg.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID)

        If result Is Nothing Then
            cancel = True
        Else
            dllfile = result(0)
            rdlcobjectname = result(1)
            webpage = result(2)
            customprinting = result(3)
            customprintingclass = result(4)
        End If


        RaiseEvent FormPrintPreviewExecuting(cancel, args, ids, reportparams, dllfile, rdlcobjectname, webpage, customprinting, customprintingclass)
        If cancel Then Exit Function


        ' Apakah Menggunakan DLL internal, dll yang sama dengan ui yang sedang running
        If UCase(dllfile) = UCase(Me.GetType().Assembly.ManifestModule.Name) Then
            Me.oAsmPrint = Me.GetType().Assembly
        Else
            ' menggunakan dll lain, didonload dari serper, di cache di memory
            ' Cek apakah DLL untuk printing sudah di load di memory
            If oAsmPrintCol.Contains(dllfile) Then
                Me.oAsmPrint = oAsmPrintCol(dllfile)
            Else
                loadassemblyfirst = True
            End If
        End If



        If webpage <> "" Then
            args = New Object() {dllfile, rdlcobjectname, loadassemblyfirst, ids, webpage, reportparams, args}
            Me.bgwPrintWeb.RunWorkerAsync(args)
        Else
            args = New Object() {dllfile, rdlcobjectname, loadassemblyfirst, ids, service, reportparams, args, customprinting, customprintingclass, PrinterMethod}
            Me.bgwPrintLoader.RunWorkerAsync(args)
        End If

    End Function

    Public Overridable Function btnEdit_Click() As Boolean
    End Function

    Public Overridable Function btnDel_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        If (Me.IsNew) Then Exit Function

        'System.Windows.Forms.MessageBox.Show("hapus data")
        Dim __ID As Object = Me.GetActiveDocumentIDValue()
        Dim res As System.Windows.Forms.DialogResult
        Dim service As String = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "delete")
        Dim msg As String = "Are you sure want to delete " & __ID
        Dim cancel As Boolean = False

        RaiseEvent FormDeleting(__ID, msg, cancel)

        If cancel Then Exit Function

        res = System.Windows.Forms.MessageBox.Show(msg, "Confirm Data Delete - " & Me.Title, System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2)
        Select Case res
            Case System.Windows.Forms.DialogResult.OK
                Me.bgwDelete.RunWorkerAsync(New Object() {service, __ID})
            Case System.Windows.Forms.DialogResult.Cancel
                Exit Function
        End Select

    End Function

    Public Overridable Function btnLoad_Click() As Boolean
    End Function

    Public Overridable Function btnQuery_Click() As Boolean
    End Function

    Public Overridable Function btnRefresh_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Dim res As System.Windows.Forms.DialogResult
        Dim id As String = Me.GetActiveDocumentIDValue()
        Dim refresh As Boolean = False



        If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then
            res = System.Windows.Forms.MessageBox.Show("Data in document " & id & " has changed." & vbCrLf & vbCrLf & "Do you want to save the changes ?", Me.Title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning)
            Select Case res
                Case System.Windows.Forms.DialogResult.Yes
                    Me.btnSave_Click()
                    refresh = True
                Case System.Windows.Forms.DialogResult.No
                    refresh = True
                Case System.Windows.Forms.DialogResult.Cancel
                    refresh = False
            End Select
        End If

        If refresh Then
            Dim dgv As System.Windows.Forms.DataGridView
            dgv = Me.GetDgvList()
            If dgv IsNot Nothing Then
                Me.TabMain_OpenData(dgv, Me.tblList.PrimaryKey(0).ColumnName, CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "open"))
            End If
        End If




        Return refresh
    End Function

    Public Overridable Function btnReset_Click() As Boolean
    End Function

    Public Overridable Function btnRowAdd_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Dim tab As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim cancel As Boolean
        Dim dgv As System.Windows.Forms.DataGridView

        tab = Me.GetTabDetil()
        If tab.SelectedTab Is Nothing Then Exit Function

        Dim tabname = tab.SelectedTab.Name
        Dim obj As Translib.DataDetilBindingTable = Me.ddBinding.GetTableByTabName(tabname)


        If obj IsNot Nothing Then
            Dim newrow As DataRow
            Dim retrow As DataRow
            Dim dialogname As String = ""
            Dim dialog As dlgBase = Nothing
            Dim args As Object = New Object() {}
            Dim result As Object

            RaiseEvent FormRowAdding(tabname, Me.ddBinding.Tables(obj.Name).Table, dialogname, cancel, args)
            If dialogname <> "" Then
                Try
                    dialog = Me.CreateDialog(Me.GetType().Assembly.GetType(dialogname, True, True), Me.Title)
                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Add New Row - " & Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    cancel = True
                End Try
            End If

            Dim arrDialogArguments As Object() = New Object() {Me.ddBinding.Tables(obj.Name).Table, Nothing}
            If args.GetType() Is GetType(System.Object()) Then
                Array.Resize(arrDialogArguments, arrDialogArguments.Length + args.Length)
                Array.Copy(args, 0, arrDialogArguments, 2, args.Length)
            Else
                Array.Resize(arrDialogArguments, 3)
                arrDialogArguments(2) = args
            End If
            args = arrDialogArguments

            If Not cancel Then
                dgv = tab.SelectedTab.Controls(obj.DgvName)
                If dialog IsNot Nothing Then
                    result = dialog.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID, args)
                    If result Is Nothing Then Exit Function

                    Try
                        If result.GetType() IsNot GetType(System.Object()) Then Throw New Exception("System Error." & vbCrLf & "Dialog did not return row in first array of result")
                        If result(0).GetType() IsNot GetType(DataRow) Then Throw New Exception("System Error." & vbCrLf & "Dialog did not return row in first array of result")
                        retrow = result(0)
                        newrow = Me.ddBinding.Tables(obj.Name).Table.NewRow

                        Dim i As Integer
                        Dim columnname As String
                        For i = 0 To Me.ddBinding.Tables(obj.Name).Table.Columns.Count - 1
                            columnname = Me.ddBinding.Tables(obj.Name).Table.Columns(i).ColumnName
                            If columnname <> Me.ddBinding.Tables(obj.Name).Table.PrimaryKey(0).ColumnName _
                                And columnname <> Me.ddBinding.Tables(obj.Name).Table.PrimaryKey(1).ColumnName Then
                                newrow(columnname) = retrow(columnname)
                            End If
                        Next


                        Dim canceladd As Boolean = False
                        RaiseEvent FormRowCheck(tabname, newrow, args, canceladd)
                        If Not canceladd Then
                            Me.ddBinding.Tables(obj.Name).Table.Rows.Add(newrow)
                        Else
                            Exit Function
                        End If

                        dgv.Focus()
                        dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1
                        dgv.CurrentCell = dgv(0, dgv.RowCount - 1)

                        RaiseEvent FormRowAdded(tabname, dgv, newrow, args)
                        RaiseEvent FormRowModified(tabname)
                    Catch ex As Exception
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Add New Row - " & Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    End Try
                Else
                    newrow = Me.ddBinding.Tables(obj.Name).Table.NewRow
                    Me.ddBinding.Tables(obj.Name).Table.Rows.Add(newrow)

                    dgv.Focus()
                    dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1
                    dgv.CurrentCell = dgv(0, dgv.RowCount - 1)

                    RaiseEvent FormRowAdded(tabname, dgv, newrow, args)
                    RaiseEvent FormRowModified(tabname)
                End If
                

            End If
        End If

    End Function

    Public Overridable Function btnRowEdit_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Dim dgv As System.Windows.Forms.DataGridView
        Dim tab As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim cancel As Boolean = False
        Dim confirm As Boolean = False
        Dim msg As String = "Are you sure ?"
        Dim args As Object = New Object() {}
        Dim retrow As DataRow

        tab = Me.GetTabDetil()
        If tab.SelectedTab Is Nothing Then Exit Function

        Dim tabname = tab.SelectedTab.Name
        Dim obj As Translib.DataDetilBindingTable = Me.ddBinding.GetTableByTabName(tabname)
        If Not tab.SelectedTab.Controls.ContainsKey(obj.DgvName) Then Exit Function
        dgv = tab.SelectedTab.Controls(obj.DgvName)
        Try
            If dgv.SelectedCells.Item(0) Is Nothing Then
            End If
        Catch ex As Exception
            Exit Function
        End Try


        If dgv.CurrentRow Is Nothing Then Exit Function
        If dgv.CurrentRow.IsNewRow Then Exit Function


        Dim dialogname As String = ""
        Dim dialog As dlgBase = Nothing
        Dim result As Object
        RaiseEvent FormRowEditing(tabname, Me.ddBinding.Tables(obj.Name).Table, dialogname, cancel, args)
        If dialogname <> "" Then
            Try
                dialog = Me.CreateDialog(Me.GetType().Assembly.GetType(dialogname, True, True), Me.Title)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message, "Edit Row - " & Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                cancel = True
            End Try
        End If


        Dim arrDialogArguments As Object() = New Object() {Me.ddBinding.Tables(obj.Name).Table, dgv.CurrentRow}
        If args.GetType() Is GetType(System.Object()) Then
            Array.Resize(arrDialogArguments, arrDialogArguments.Length + args.Length)
            Array.Copy(args, 0, arrDialogArguments, 2, args.Length)
        Else
            Array.Resize(arrDialogArguments, 3)
            arrDialogArguments(2) = args
        End If
        args = arrDialogArguments


        If Not cancel Then
            If dialog IsNot Nothing Then
                result = dialog.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID, args)
                If result Is Nothing Then Exit Function

                Try
                    If result.GetType() IsNot GetType(System.Object()) Then Throw New Exception("System Error." & vbCrLf & "Dialog did not return row in first array of result")
                    If result(0).GetType() IsNot GetType(DataRow) Then Throw New Exception("System Error." & vbCrLf & "Dialog did not return row in first array of result")
                    retrow = result(0)

                    Dim canceledit As Boolean = False
                    RaiseEvent FormRowCheck(tabname, retrow, args, canceledit)
                    If canceledit Then
                        Exit Function
                    End If

                    Dim i As Integer
                    Dim columnname As String
                    For i = 0 To Me.ddBinding.Tables(obj.Name).Table.Columns.Count - 1
                        columnname = Me.ddBinding.Tables(obj.Name).Table.Columns(i).ColumnName
                        If columnname <> Me.ddBinding.Tables(obj.Name).Table.PrimaryKey(0).ColumnName _
                            And columnname <> Me.ddBinding.Tables(obj.Name).Table.PrimaryKey(1).ColumnName Then
                            If dgv.Columns.Contains(columnname) Then
                                If retrow(columnname) IsNot GetType(System.DBNull) Then
                                    If dgv.CurrentRow.Cells(columnname).Value.GetType() Is GetType(System.DBNull) Then dgv.CurrentRow.Cells(columnname).Value = ""
                                    If dgv.CurrentRow.Cells(columnname).Value <> retrow(columnname) Then
                                        dgv.CurrentRow.Cells(columnname).Value = retrow(columnname)
                                    End If
                                Else
                                    dgv.CurrentRow.Cells(columnname).Value = retrow.Table.Columns(columnname).DefaultValue
                                End If
                            End If

                        End If
                    Next

                    dgv.Focus()
                    RaiseEvent FormRowEdited(tabname, dgv.CurrentRow, args)
                    RaiseEvent FormRowModified(tabname)
                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Edit Row - " & Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                End Try
            End If
        End If


    End Function


    Public Overridable Function btnRowDel_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Dim dgv As System.Windows.Forms.DataGridView
        Dim tab As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim res As System.Windows.Forms.DialogResult
        Dim cancel As Boolean = False
        Dim confirm As Boolean = False
        Dim msg As String = "Are you sure ?"
        Dim args As Object = New Object() {}

        tab = Me.GetTabDetil()
        If tab.SelectedTab Is Nothing Then Exit Function

        Dim tabname = tab.SelectedTab.Name
        Dim obj As Translib.DataDetilBindingTable = Me.ddBinding.GetTableByTabName(tabname)
        If Not tab.SelectedTab.Controls.ContainsKey(obj.DgvName) Then Exit Function
        dgv = tab.SelectedTab.Controls(obj.DgvName)
        Try
            If dgv.SelectedCells.Item(0) Is Nothing Then
            End If
        Catch ex As Exception
            Exit Function
        End Try

        If dgv.CurrentRow Is Nothing Then Exit Function
        If dgv.CurrentRow.IsNewRow Then Exit Function

        RaiseEvent FormRowDeleting(tabname, dgv.CurrentRow, confirm, msg, cancel, args)
        If cancel Then Exit Function
        If confirm Then
            res = System.Windows.Forms.MessageBox.Show(msg, "Confirm Row Delete - " & Me.Title, System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2)
            Select Case res
                Case System.Windows.Forms.DialogResult.OK
                    dgv.Rows.Remove(dgv.CurrentRow)
                    RaiseEvent FormRowDeleted(tabname, args)
                    RaiseEvent FormRowModified(tabname)
                Case System.Windows.Forms.DialogResult.Cancel
                    cancel = True
            End Select
        Else
            dgv.Rows.Remove(dgv.CurrentRow)
            RaiseEvent FormRowDeleted(tabname, args)
            RaiseEvent FormRowModified(tabname)
        End If

    End Function

    Public Overridable Function btnFirst_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Return Me.Datawalk_Move(EDataWalk.First)
    End Function

    Public Overridable Function btnPrev_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Return Me.Datawalk_Move(EDataWalk.Previous)
    End Function

    Public Overridable Function btnNext_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Return Me.Datawalk_Move(EDataWalk.Next)
    End Function

    Public Overridable Function btnLast_Click() As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function

        Return Me.Datawalk_Move(EDataWalk.Last)
    End Function

    Public Overridable Function btnHelpTopic_Click() As Boolean
    End Function

    Public Overridable Function btnShowStatus_Click() As Boolean
    End Function

    Public Overridable Function btnShowConsole_Click() As Boolean
    End Function

    Public Overridable Function btnReserved1_Click() As Boolean
    End Function

    Public Overridable Function btnReserved2_Click() As Boolean
    End Function

    Public Overridable Function btnReserved3_Click() As Boolean
    End Function

    Public Overridable Function btnReserved4_Click() As Boolean
    End Function

    Public Overridable Function btnReserved5_Click() As Boolean
    End Function

    Public Overridable Function btnReserved6_Click() As Boolean
    End Function


    Public Overridable Function RefreshList(ByRef bn As System.Windows.Forms.BindingNavigator, ByVal obj As System.Windows.Forms.ToolStripItem) As Boolean
    End Function


    Public Overridable Sub bgwMasterLoaderQueue_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwMasterLoaderQueue.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Public Overridable Sub bgwMasterLoader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwMasterLoader.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Public Overridable Sub ConstructTableHeader()

    End Sub

    Public Overridable Sub ConstructTableDetil()

    End Sub


    Public Overridable Sub DgvListFormat(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

    End Sub


#End Region

#Region " ToolStripButton Event "

    Private Sub tbtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNew.Click
        Me.btnNew_Click()
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.Click
        Me.btnSave_Click()
    End Sub

    Private Sub tbtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrint.Click
        Me.btnPrint_Click()
    End Sub

    Private Sub tbtnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.Click
        Me.btnPrintPreview_Click()
    End Sub


    Private Sub tbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnEdit.Click
        Me.btnEdit_Click()
    End Sub

    Private Sub tbtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDel.Click
        Me.btnDel_Click()
    End Sub


    Private Sub tbtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLoad.Click
        Me.btnLoad_Click()
    End Sub

    Private Sub tbtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnQuery.Click
        Me.btnQuery_Click()
    End Sub

    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.Click
        Me.btnRefresh_Click()
    End Sub

    Private Sub tbtnRowAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRowAdd.Click
        Me.btnRowAdd_Click()
    End Sub

    Private Sub tbtnRowDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRowDel.Click
        Me.btnRowDel_Click()
    End Sub


    Private Sub tbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnFirst.Click
        Me.btnFirst_Click()
    End Sub

    Private Sub tbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrev.Click
        Me.btnPrev_Click()
    End Sub

    Private Sub tbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNext.Click
        Me.btnNext_Click()
    End Sub

    Private Sub tbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLast.Click
        Me.btnLast_Click()
    End Sub

#End Region

#Region " Syncronisasi "

    Private Sub tbtnNew_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnNew.EnabledChanged
        Me._SyncronizeControlEnableState("New", tbtnNew.Enabled)
    End Sub

    Private Sub tbtnSave_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnSave.EnabledChanged
        Me._SyncronizeControlEnableState("Save", tbtnSave.Enabled)
    End Sub

    Private Sub tbtnPrint_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrint.EnabledChanged
        Me._SyncronizeControlEnableState("Print", tbtnPrint.Enabled)
    End Sub

    Private Sub tbtnPrintPreview_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.EnabledChanged
        Me._SyncronizeControlEnableState("PrintPreview", tbtnPrintPreview.Enabled)
    End Sub

    Private Sub tbtnDel_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnDel.EnabledChanged
        Me._SyncronizeControlEnableState("Delete", tbtnDel.Enabled)
    End Sub

    Private Sub tbtnLoad_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnLoad.EnabledChanged
        Me._SyncronizeControlEnableState("LoadData", tbtnLoad.Enabled)
    End Sub

    Private Sub tbtnQuery_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnQuery.EnabledChanged
        Me._SyncronizeControlEnableState("Queri", tbtnQuery.Enabled)
    End Sub


    Public Sub tbtnFirst_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnFirst.EnabledChanged
        Me._SyncronizeControlEnableState("First", tbtnFirst.Enabled)
    End Sub

    Private Sub tbtnPrev_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrev.EnabledChanged
        Me._SyncronizeControlEnableState("Previous", tbtnPrev.Enabled)
    End Sub

    Private Sub tbtnNext_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnNext.EnabledChanged
        Me._SyncronizeControlEnableState("Next", tbtnNext.Enabled)
    End Sub

    Private Sub tbtnLast_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnLast.EnabledChanged
        Me._SyncronizeControlEnableState("Last", tbtnLast.Enabled)
    End Sub


    Public Sub SyncronizeControlEnableState()
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled("New", tbtnNew.Enabled)
                Me.Browser.MenuEnabled("Save", tbtnSave.Enabled)
                Me.Browser.MenuEnabled("Print", tbtnPrint.Enabled)
                Me.Browser.MenuEnabled("PrintPreview", tbtnPrintPreview.Enabled)
                Me.Browser.MenuEnabled("Delete", tbtnDel.Enabled)
                Me.Browser.MenuEnabled("LoadData", tbtnLoad.Enabled)
                Me.Browser.MenuEnabled("Queri", tbtnQuery.Enabled)
                Me.Browser.MenuEnabled("First", tbtnFirst.Enabled)
                Me.Browser.MenuEnabled("Previous", tbtnPrev.Enabled)
                Me.Browser.MenuEnabled("Next", tbtnNext.Enabled)
                Me.Browser.MenuEnabled("Last", tbtnLast.Enabled)
            End If
        End If
    End Sub

    Public Sub _SyncronizeControlEnableState(ByVal Name As String, ByVal state As Boolean)
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled(Name, state)
            End If
        End If
    End Sub

#End Region

#Region " DataGridView Column Handler "

    Public Shared Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewTextBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, ByVal width As Integer) As System.Windows.Forms.DataGridViewTextBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Shared Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewTextBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, ByVal width As Integer, ByVal align As System.Windows.Forms.DataGridViewContentAlignment, ByVal [readonly] As Boolean) As System.Windows.Forms.DataGridViewTextBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = [readonly]
        col.DefaultCellStyle.Alignment = align
        If [readonly] Then
            col.DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
        End If
        Return col
    End Function


    Public Shared Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewTextBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, ByVal width As Integer, ByVal align As System.Windows.Forms.DataGridViewContentAlignment, ByVal [readonly] As Boolean, ByVal color As System.Drawing.Color) As System.Windows.Forms.DataGridViewTextBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = [readonly]
        col.DefaultCellStyle.Alignment = align
        col.DefaultCellStyle.BackColor = color
        Return col
    End Function


    Public Shared Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewComboBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, ByVal width As Integer) As System.Windows.Forms.DataGridViewComboBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Shared Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewCheckBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, ByVal width As Integer) As System.Windows.Forms.DataGridViewCheckBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Shared Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewButtonColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, ByVal width As Integer) As System.Windows.Forms.DataGridViewButtonColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Shared Function CreateDataGridViewComboBinding(ByRef objDgv As System.Windows.Forms.DataGridView, ByVal columnname As String, ByVal datavalue As String, ByVal datamember As String, ByVal dt As Data.DataTable) As Boolean
        With CType(objDgv.Columns(columnname), System.Windows.Forms.DataGridViewComboBoxColumn)
            .ValueMember = datavalue
            .DisplayMember = datamember
            .DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
            .DisplayStyleForCurrentCellOnly = True
            .AutoComplete = True
            .DataSource = dt
        End With
        Return True
    End Function


#End Region

#Region " Parameter Processing "

    Public Function GetParameterCollection(ByVal ParameterString As String) As Collection
        Dim i As Integer
        Dim arrParameter() As String
        Dim tempParameterLine() As String
        Dim ParameterKey As String
        Dim ParameterValue As String
        Dim objParameters As Collection = New Collection

        'Parameter = "CHANNEL=TTV; CHANNEL_CANBE_CHANGED=0; CHANNEL_CANBE_BROWSED=0; POSTING_MODE=1; POSTING_AUTHORITY=0; UNPOSTING_AUTHORITY=1;"
        arrParameter = ParameterString.Split(";")
        If Trim(ParameterString) <> "" Then
            For i = 0 To arrParameter.Length - 1
                tempParameterLine = arrParameter(i).Split("=")
                If tempParameterLine.Length = 2 Then
                    ParameterKey = Trim(tempParameterLine(0))
                    ParameterValue = Trim(tempParameterLine(1))

                    If objParameters.Contains(ParameterKey) Then
                        objParameters.Remove(ParameterKey)
                    End If

                    objParameters.Add(ParameterValue, ParameterKey)

                End If
            Next
        End If

        Return objParameters

    End Function

    Public Function GetBolValueFromParameter(ByVal Col As Collection, ByVal key As String) As Boolean
        If Col.Contains(key) Then
            If Col(key) = "0" Or Col(key) = "1" Or Col(key) = "true" Or Col(key) = "false" Then
                If Col(key) = "0" Or Col(key) = "false" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetIntValueFromParameter(ByVal Col As Collection, ByVal key As String) As Integer
        If Col.Contains(key) Then
            Return CType(Col(key), Integer)
        Else
            Return 0
        End If
    End Function

    Public Function GetValueFromParameter(ByVal Col As Collection, ByVal key As String) As String
        If Col.Contains(key) Then
            Return Col(key)
        Else
            Return ""
        End If
    End Function


#End Region

#Region " Control Initialisation "

    Public Function InitializeControl(ByVal session_id As String, ByVal username As String, ByVal webserviceaddress As String, ByVal dllserver As String, ByRef browser As Object, ByVal uiAsm As System.Reflection.Assembly) As Boolean
        Me.mSessionID = session_id
        Me.mUsername = username
        Me.mWebserviceAddress = webserviceaddress
        Me.mDllServer = dllserver
        Me.mBrowser = browser
        Me.uiAssembly = uiAsm
        Return True
    End Function

    Public Function SetProgram(ByVal obj As Translib.SolutionProgram) As Boolean
        Me.mProgram = obj
    End Function

    Public Function SetDSNLocal(ByVal dsn) As Boolean
        mDSNLocal = dsn
    End Function

    Public Function SetBrowser(ByRef obj As Object) As Boolean
        mBrowser = obj
    End Function

#End Region

#Region " List Loader "

    Public Overridable Sub bgwListLoader_Load(ByVal args As Object())
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim respond As String = ""
        Dim i, n As Integer
        Dim service As String = args(0)
        Dim criteria As String = args(1)
        Dim strRowLimit As String = args(2)

        Dim rowLimit As Integer

        Try
            rowLimit = strRowLimit
        Catch ex As Exception
            rowLimit = Me.List_RowMax
        End Try

        Try

            Me.ReportProgress(Me.bgwListLoader, 10, "Connecting to " & Me.WebserviceAddress & "/" & service & " ...")


            wConn.addtext("criteria", criteria)
            wConn.addtext("limit", rowLimit)
            wConn.addtext("start", (Me.List_CurrentPageIndex - 1) * Me.List_RowMax)
            objWebResult = WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)

            n = objWebResult.data.Count
            Me.List_RowCount = objWebResult.totalCount
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    If Me.InvokeRequired Then
                        Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                        If Me.tblList.Columns.Count > 0 Then
                            Me.Invoke(d, New Object() {Me.tblList, obj, False})
                        Else
                            Me.Invoke(d, New Object() {Me.tblList, obj, True})
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & service)
        Finally
            Me.WebRespond = respond
        End Try
    End Sub

    Private Sub bgwListLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwListLoader.DoWork
        While Me.bgwMasterLoaderQueue.IsBusy
            System.Threading.Thread.Sleep(100)
        End While



        Me.BackgroundworkerStatus = EBackgroundworkerStatus.Progress

        Me.Status = "Loading List Data..."
        Me.WebRespond = "{}"

        Try
            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                Me.Invoke(d, New Object() {e.Argument, True})
            End If
            'System.Threading.Thread.Sleep(100)

            Me.bgwListLoader_Load(e.Argument)
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Done

        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            Me.Status = "Error"
            Me.Message = ex.Message
        End Try

        e.Result = e.Argument
    End Sub

    Private Sub bgwListLoader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwListLoader.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwListLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwListLoader.RunWorkerCompleted
        Dim bn As System.Windows.Forms.BindingNavigator = Me.GetPagingNavigator()
        Dim dgv As System.Windows.Forms.DataGridView = Me.GetDgvList()
        Dim pn As System.Windows.Forms.BindingNavigator

        Try
            pn = Me.GetPagingNavigator()
            If pn IsNot Nothing Then
                Me.GetPagingNavigator().Items("bnRowLimit").Text = e.Result(2)
            End If
            Me.List_RowMax = e.Result(2)
        Catch ex As Exception
        End Try

        Me.fLoadingIndicator.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DisableForm(False)

        RaiseEvent BackgroundworkerListLoaderCompleted(bn, Me.WebRespond)

        Try
            dgv.DataSource = Me.tblList
            Me.BindingNavigator_SetPagingState(bn)
            Select Case Me.BackgroundworkerStatus
                Case EBackgroundworkerStatus.Done
                    RaiseEvent BackgroundworkerListLoaderCompletedAndDone(Me.WebRespond)
                    Me.Datawalk_SetButtonState(dgv, 0)
                    RaiseEvent FormListLoaded(Me.WebRespond, e.Result)
                Case EBackgroundworkerStatus.Fail
                    RaiseEvent BackgroundworkerListLoaderCompletedButFail(Me.WebRespond)
                    System.Windows.Forms.MessageBox.Show(Me.Message, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            End Select
        Catch ex As Exception
            ' Throw ex
            System.Windows.Forms.MessageBox.Show(ex.Message, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region " Data Open Loader "

    Public Overridable Sub bgwDataLoader_PreLoad(ByVal args As Object(), ByVal open As Boolean)
        Dim dgv As System.Windows.Forms.DataGridView = Me.GetDgvList()
        Dim key As Object = Me.tblList.PrimaryKey(0).ColumnName
        Dim id As Object = New Object

        If dgv IsNot Nothing Then
            If dgv.CurrentRow IsNot Nothing Then
                Dim rowIndex As Integer = dgv.CurrentRow.Index
                id = dgv.Rows(rowIndex).Cells(key).Value
            End If
        End If

        Me.mDATAOPENED = False
        RaiseEvent FormDataOpening(id)

    End Sub

    Public Overridable Sub bgwDataLoader_Load(ByVal args As Object())
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim objH As Newtonsoft.Json.JavaScriptObject
        Dim objD As Newtonsoft.Json.JavaScriptObject
        Dim objDArr As Newtonsoft.Json.JavaScriptArray
        Dim respond As String = ""
        Dim tableIndex, tableCount As Integer
        Dim i As Integer
        Dim service As String = args(0)
        Dim id As String = args(1)
        Dim key As String = ""

        Try
            wConn.addtext("id", id)

            Me.ReportProgress(Me.bgwDataLoader, 10, "Connecting to " & Me.WebserviceAddress & "/" & service & " ...")
            'System.Threading.Thread.Sleep(1000)
            objWebResult = WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)

            Me.ReportProgress(Me.bgwDataLoader, 20, "Opening " & Trim(id) & " ...")
            obj = CType(objWebResult.data(0), Newtonsoft.Json.JavaScriptObject)
            key = "H"
            objH = obj("H")
            If Me.InvokeRequired Then
                Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                Me.Invoke(d, New Object() {Me.tblList_Temp, objH, False})
            End If
            'System.Threading.Thread.Sleep(100)

            ' Data Detil
            tableCount = Me.ddBinding.Tables.Count
            For tableIndex = 1 To tableCount
                Me.ReportProgress(Me.bgwDataLoader, 20, "Opening " & Me.ddBinding.Tables(tableIndex).Name & " ...")
                key = "D, " & Me.ddBinding.Tables(tableIndex).Name
                Me.ddBinding.Tables(tableIndex).Table.Rows.Clear()
                objDArr = CType(obj("D")(Me.ddBinding.Tables(tableIndex).Name), Newtonsoft.Json.JavaScriptArray)
                If objDArr.Count > 0 Then
                    For i = 0 To objDArr.Count - 1
                        objD = CType(objDArr(i), Newtonsoft.Json.JavaScriptObject)
                        If Me.InvokeRequired Then
                            Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                            Me.Invoke(d, New Object() {Me.ddBinding.Tables(tableIndex).Table, objD, False})
                        End If
                    Next
                End If
                'System.Threading.Thread.Sleep(100)
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & "Key: " & key)
        Finally
            Me.WebRespond = respond
        End Try
    End Sub

    Private Sub bgwDataLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDataLoader.DoWork
        While Me.bgwSave.IsBusy
            System.Threading.Thread.Sleep(100)
        End While

        If Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Fail Then
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.NotExecuted
            Me.Status = "Error"
            'Me.Message = Me.Message

        Else
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Progress
            Me.Status = "Loading Data..."
            Me.WebRespond = "{}"

            Try
                If Me.InvokeRequired Then
                    Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                    Me.Invoke(d, New Object() {e.Argument, True})
                End If


                If Me.InvokeRequired Then
                    Dim d As New BackgroundworkerInvokeFunction(AddressOf bgwDataLoader_PreLoad)
                    Me.Invoke(d, New Object() {e.Argument, True})
                End If

                Me.bgwDataLoader_Load(e.Argument)
                Me.BackgroundworkerStatus = EBackgroundworkerStatus.Done

            Catch ex As Exception
                Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
                Me.Status = "Error"
                Me.Message = ex.Message
            End Try
        End If





    End Sub

    Private Sub bgwDataLoader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwDataLoader.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwDataLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDataLoader.RunWorkerCompleted
        Dim tabMain As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim tabDetil As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl


        Me.fLoadingIndicator.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DisableForm(False)
        Me.IsNew = False

        If Me.BackgroundworkerStatus = EBackgroundworkerStatus.NotExecuted Then Exit Sub

        Try

            tabMain = Me.GetTabMain()
            tabDetil = Me.GetTabDetil()

            RaiseEvent BackgroundworkerDataLoaderCompleted(tabMain, tabDetil, Me.WebRespond)

            Me.TabDetil_SetSelected(tabDetil)

            Select Case Me.BackgroundworkerStatus
                Case EBackgroundworkerStatus.Done
                    RaiseEvent BackgroundworkerDataLoaderCompletedAndDone(Me.WebRespond)

                    Dim tableIndex, tableCount As Integer
                    Dim tabname, dgvname As String
                    Dim dgv As System.Windows.Forms.DataGridView

                    Me.tblList_Temp.AcceptChanges()
                    Me.BindingStart()
                    Dim id As Object = Me.GetActiveDocumentIDValue()


                    Me.tblList_Temp.AcceptChanges()
                    tableCount = Me.ddBinding.Tables.Count
                    For tableIndex = 1 To tableCount
                        dgvname = Me.ddBinding.Tables(tableIndex).DgvName
                        tabname = Me.ddBinding.Tables(tableIndex).TabName
                        dgv = Me.GetDgvDetil(tabname, dgvname)
                        Me.ddBinding.Tables(tableIndex).Table.AcceptChanges()
                        dgv.DataSource = Me.ddBinding.Tables(tableIndex).Table
                    Next

                    Me.mDATAOPENED = True

                    RaiseEvent FormDataOpened(id)
                Case EBackgroundworkerStatus.Fail
                    tabMain.SelectedTab = tabMain.TabPages("ftabMain_List")
                    RaiseEvent BackgroundworkerDataLoaderCompletedButFail(Me.WebRespond)
                    System.Windows.Forms.MessageBox.Show(Me.Message, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Data Save "

    Public Overridable Function DataSave(ByVal supressmessage As Boolean) As Boolean
        If Me.tblList_Temp Is Nothing Then Exit Function
        If Not Me.BindingContext.Contains(Me.tblList_Temp) Then Exit Function


        Dim __ID As Object = Me.GetActiveDocumentIDValue()
        Dim i As Integer
        Dim dt_changes As DataTable = Nothing
        Dim dt_deleted As DataTable = Nothing
        Dim changed As Boolean = False
        Dim service As String = ""
        Dim row As DataRow

        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim objSent As Newtonsoft.Json.JavaScriptObject = New Newtonsoft.Json.JavaScriptObject()
        Dim objArrDataSent As Newtonsoft.Json.JavaScriptArray = New Newtonsoft.Json.JavaScriptArray()

        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_Data") Then
                Me.Controls("ftabMain").Controls("ftabMain_Data").Focus()
            End If
        End If


        If Me.DataIsChanged(Me.tblList_Temp, Me.ddBinding) Then


            changed = True

            objSent = New Newtonsoft.Json.JavaScriptObject()
            objSent.Add("_datachanged", 1)

            Me.BindingContext(Me.tblList_Temp).EndCurrentEdit()
            dt_changes = Me.tblList_Temp.GetChanges()
            obj = New Newtonsoft.Json.JavaScriptObject()
            If dt_changes IsNot Nothing Then
                row = dt_changes.Rows(0)
                obj = Me.AddJsonObjectFromRow(dt_changes, row, row.RowState)
                objSent.Add("H", obj)
            End If



            Dim rowIndex As Integer
            Dim arrObj As Newtonsoft.Json.JavaScriptArray
            Dim objDet As Newtonsoft.Json.JavaScriptObject = New Newtonsoft.Json.JavaScriptObject()
            For i = 1 To Me.ddBinding.Tables.Count
                Me.BindingContext(Me.ddBinding.Tables(Me.ddBinding.Tables(i).Name)).EndCurrentEdit()
                dt_changes = Nothing
                dt_changes = Me.ddBinding.Tables(i).Table.GetChanges()
                If dt_changes IsNot Nothing Then

                    arrObj = New Newtonsoft.Json.JavaScriptArray()
                    For rowIndex = 0 To dt_changes.Rows.Count - 1
                        row = dt_changes.Rows(rowIndex)
                        If row.RowState <> DataRowState.Deleted Then
                            obj = Me.AddJsonObjectFromRow(dt_changes, row, row.RowState)
                        Else
                            row.RejectChanges()
                            row.SetModified()
                            obj = Me.AddJsonObjectFromRow(dt_changes, row, DataRowState.Deleted)
                        End If
                        arrObj.Add(obj)
                    Next
                    objDet.Add(Me.ddBinding.Tables(i).Name, arrObj)
                End If
            Next

            objSent.Add("D", objDet)
            objArrDataSent.Add(objSent)

            Dim cancelsave As Boolean = False
            service = CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "save")
            RaiseEvent FormSaving(__ID, service, objArrDataSent)
            RaiseEvent FormSavingCheck(__ID, service, objArrDataSent, cancelsave)

            If cancelsave Then
                Exit Function
            End If

            Dim strJson As String = Newtonsoft.Json.JavaScriptConvert.SerializeObject(objArrDataSent)
            Me.savework = True
            Me.bgwSave.RunWorkerAsync(New Object() {service, changed, strJson, __ID, supressmessage})

        End If
    End Function

    Public Overridable Function bgwSave_Execute(ByVal args As Object()) As Object()
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject = New Newtonsoft.Json.JavaScriptObject
        Dim message As String = ""
        Dim respond As String = ""
        Dim request As String = ""
        Dim service As String = args(0)
        Dim changed As Boolean = args(1)
        Dim strJson As String = args(2)
        Dim __ID As String = args(3)
        Dim result As Object() = New Object() {EBackgroundworkerStatus.Progress, message, service, request, respond, obj}


        Try
            Me.ReportProgress(Me.bgwSave, 10, "Connecting to " & Me.WebserviceAddress & "/" & service & " ...")
            wConn.addtext("__ID", __ID)
            wConn.addtext("JSONDATA", strJson)
            objWebResult = WebserviceExecute(wConn, service, respond)
            Me.WebSaveRequest = wConn.GetPostedRequest()
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count > 0 Then
                obj = objWebResult.data(0)
            End If
            message = "Data Saved"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            Me.WebSaveRespond = respond
        End Try

        result = New Object() {EBackgroundworkerStatus.Done, message, service, request, respond, obj}
        Return result
    End Function

    Private Sub bgwSave_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwSave.DoWork
        Dim service As String = e.Argument(0)
        Dim changed As Boolean = e.Argument(1)
        Dim strJson As String = e.Argument(2)
        Dim __ID As String = e.Argument(3)
        Dim supressmessage As Boolean = e.Argument(4)
        Dim obj As Newtonsoft.Json.JavaScriptObject = New Newtonsoft.Json.JavaScriptObject
        Dim status As EBackgroundworkerStatus = EBackgroundworkerStatus.NotExecuted
        Dim request As String = ""
        Dim respond As String = ""
        Dim message As String = ""
        Dim saveResult As Object() = New Object() {}
        Dim result As Object() = New Object() {status, message, service, request, respond, obj}

        Me.Status = "Saving..."
        Me.WebSaveRespond = "{}"
        Me.WebSaveService = service
        Me.WebSaveRequest = ""

        If Not changed Then
            Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.NotExecuted
            Me.Status = "No Changes"
            Me.Message = "No Changes"
            result = New Object() {status, "No Changes", service, "", "{}", obj, supressmessage}
        Else
            Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Progress
            Try
                If Me.InvokeRequired Then
                    Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
                    Me.Invoke(d, New Object() {e.Argument, True})
                End If
                saveResult = Me.bgwSave_Execute(e.Argument)
                result = New Object() {EBackgroundworkerStatus.Done, saveResult(1), saveResult(2), saveResult(3), saveResult(4), saveResult(5), supressmessage}
                Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Done
            Catch ex As Exception
                Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Fail
                Me.Status = "Error"
                Me.Message = ex.Message
                result = New Object() {EBackgroundworkerStatus.Fail, ex.Message, service, request, respond, obj, supressmessage}
            End Try
        End If

        e.Result = result
    End Sub

    Private Sub bgwSave_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwSave.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwSave_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwSave.RunWorkerCompleted
        Dim tab As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim tableIndex, tableCount As Integer
        Dim result As Object = e.Result
        Dim obj As Newtonsoft.Json.JavaScriptObject = result(5)
        Dim supressmessage = result(6)


        Me.fLoadingIndicator.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DisableForm(False)

        RaiseEvent BackgroundworkerSaveCompleted(Me.BackgroundworkerSaveStatus, Me.WebSaveService, Me.WebSaveRequest, Me.WebSaveRespond)

        Dim id As String = Me.GetActiveDocumentIDValue()
        Dim objID As System.Windows.Forms.TextBox = Me.GetActiveDocumentID()


        Select Case Me.BackgroundworkerSaveStatus
            Case EBackgroundworkerStatus.Done
                If obj.ContainsKey("H") Then
                    obj = obj("H")
                    Dim x As Integer
                    Dim arr_keys As String() = {}
                    Dim obj_columnname As String
                    Array.Resize(arr_keys, obj.Count)
                    obj.Keys.CopyTo(arr_keys, 0)
                    For x = 0 To arr_keys.Length - 1
                        obj_columnname = arr_keys(x)
                        If Me.tblList_Temp.Columns.Contains(obj_columnname) Then
                            Me.tblList_Temp.Rows(0).Item(obj_columnname) = obj(obj_columnname)
                        End If
                    Next
                End If

                RaiseEvent FormSaved(id, Me.WebSaveRespond, EFormSaveResult.SaveSuccess, obj, supressmessage)
                tableCount = Me.ddBinding.Tables.Count
                Me.tblList_Temp.AcceptChanges()
                For tableIndex = 1 To tableCount
                    Me.ddBinding.Tables(tableIndex).Table.AcceptChanges()
                Next
                RaiseEvent BackgroundworkerSaveCompletedAndDone(Me.WebRespond)



                Dim dgvlist As System.Windows.Forms.DataGridView = Me.GetDgvList
                Dim i As Integer
                Dim columnname As String
                Dim newrowindex As Integer
                If dgvlist.CurrentRow Is Nothing Then
                    newrowindex = dgvlist.Rows.Add()
                    dgvlist.CurrentCell = dgvlist(0, newrowindex)
                End If

                Try
                    For i = 0 To dgvlist.Columns.Count - 1
                        columnname = dgvlist.Columns(i).Name
                        If Me.tblList_Temp.Columns.Contains(columnname) Then
                            dgvlist.CurrentRow.Cells(columnname).Value = Me.tblList_Temp.Rows(0).Item(columnname)
                        End If
                    Next
                Catch ex As Exception
                End Try




                Me.IsNew = False
                'Refresh datagrid list

            Case EBackgroundworkerStatus.Fail
                RaiseEvent FormSaved(id, Me.WebSaveRespond, EFormSaveResult.SaveError, obj, supressmessage)
                RaiseEvent BackgroundworkerSaveCompletedButFail(Me.WebRespond)
                System.Windows.Forms.MessageBox.Show(Me.Message, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            Case EBackgroundworkerStatus.NotExecuted
                RaiseEvent FormSaved(id, Me.WebSaveRespond, EFormSaveResult.Nochanges, obj, supressmessage)
        End Select

    End Sub

#End Region

#Region " Data New "

    Private Sub bgwNew_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwNew.DoWork
        While Me.bgwSave.IsBusy
            System.Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub bgwNew_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwNew.RunWorkerCompleted
        Dim tabMain As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim result As Object = New Object()
        Dim args As Object = New Object()
        Dim cancel As Boolean

        Try
            tabMain = Me.GetTabMain()
            If tabMain.SelectedTab.Name = "ftabMain_List" Then
                tabMain.SelectedTab = tabMain.TabPages("ftabMain_Data")
            End If


            Me.tblList_Temp.Clear()
            Me.BindingStop()
            Me.ConstructTableHeader()
            Me.ConstructTableDetil()
            Me.tbtnSave.Enabled = True

            RaiseEvent FormBeforeNew(result, cancel, args)

            If Not cancel Then
                Try
                    Me.BindingContext(Me.tblList_Temp).AddNew()
                Catch ex As Exception
                    Throw New Exception(ex.Message & vbCrLf & vbCrLf & "uiBase.btnNew_Click(), Me.BindingContext(Me.tblList_Temp).AddNew()")
                End Try

                Try
                    Dim tableIndex, tableCount As Integer
                    Dim tabname, dgvname As String
                    Dim dgv As System.Windows.Forms.DataGridView
                    tableCount = Me.ddBinding.Tables.Count
                    Me.BindingStart()
                    For tableIndex = 1 To tableCount
                        dgvname = Me.ddBinding.Tables(tableIndex).DgvName
                        tabname = Me.ddBinding.Tables(tableIndex).TabName
                        dgv = Me.GetDgvDetil(tabname, dgvname)
                        dgv.DataSource = Me.ddBinding.Tables(tableIndex).Table

                        If Me.ddBinding.Tables(tableIndex).AllowAddOrDeleteRowsOrigin Then
                            Me.tbtnRowAdd.Enabled = True
                            Me.tbtnRowDel.Enabled = True
                        End If
                    Next
                Catch ex As Exception
                    Throw New Exception(ex.Message & vbCrLf & vbCrLf & "uiBase.btnNew_Click()")
                End Try
                RaiseEvent FormAfterNew(result, args)

                Me.IsNew = True

            Else

                Dim tableIndex, tableCount As Integer
                Dim tabname, dgvname As String
                Dim dgv As System.Windows.Forms.DataGridView
                Try
                    tableCount = Me.ddBinding.Tables.Count
                    Me.tblList_Temp.AcceptChanges()
                    Me.BindingStart()
                    For tableIndex = 1 To tableCount
                        dgvname = Me.ddBinding.Tables(tableIndex).DgvName
                        tabname = Me.ddBinding.Tables(tableIndex).TabName
                        dgv = Me.GetDgvDetil(tabname, dgvname)
                        Me.ddBinding.Tables(tableIndex).Table.AcceptChanges()
                        dgv.DataSource = Me.ddBinding.Tables(tableIndex).Table

                        If Me.ddBinding.Tables(tableIndex).AllowAddOrDeleteRowsOrigin Then
                            Me.tbtnRowAdd.Enabled = True
                            Me.tbtnRowDel.Enabled = True
                        End If

                    Next

                    tabMain = Me.GetTabMain()
                    tabMain.SelectedTab = tabMain.TabPages("ftabMain_List")

                Catch ex As Exception
                    Throw New Exception(ex.Message & vbCrLf & vbCrLf & "uiBase.btnNew_Click(), and cancel")
                End Try

            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub



#End Region

#Region " Print Loader "

    Private Function bgwPrintLoader_LoadData(ByVal service As String, ByVal id As String, ByRef request As String, ByRef respond As String) As DataTable
        Dim tbl As DataTable = New DataTable
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim i, n As Integer

        Try
            wConn.addtext("id", id)
            objWebResult = WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)

            n = objWebResult.data.Count
            Me.List_RowCount = objWebResult.totalCount
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    If Me.InvokeRequired Then
                        Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                        Me.Invoke(d, New Object() {tbl, obj, True})
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & service)
        Finally
            Me.WebRespond = respond
        End Try


        Return tbl
    End Function

    Private Sub bgwPrintLoader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwPrintLoader.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwPrintLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPrintLoader.DoWork
        Dim dllfile As String = e.Argument(0)
        Dim rdlcobjectname As String = e.Argument(1)
        Dim loadassemblyfirst As Boolean = e.Argument(2)
        Dim ids As String() = e.Argument(3)
        Dim service As String = e.Argument(4)
        Dim reportparams As Microsoft.Reporting.WinForms.ReportParameter() = e.Argument(5)
        Dim args As Object = e.Argument(6)
        Dim customprinting As Boolean = e.Argument(7)
        Dim customprintingclass As String = e.Argument(8)
        Dim PrinterMethod As Object = e.Argument(9)

        Dim origin_dllfile As String = dllfile
        Dim origin_rdlcobjectname As String = rdlcobjectname



        Dim responds As String = ""
        Dim request As String = ""
        Dim status As EBackgroundworkerStatus = EBackgroundworkerStatus.NotExecuted
        Dim executeloaddata As Boolean = False
        Dim assemblyloaded As Boolean = False
        Dim assembly As System.Reflection.Assembly = Nothing
        Dim errmsg As String = ""
        Dim tbl As DataTable = New DataTable
        Dim result As Object() = New Object() {dllfile, rdlcobjectname, loadassemblyfirst, assemblyloaded, assembly, errmsg, service, responds, request, status, tbl, ids, reportparams, args}

        Dim i As Integer

        If Me.InvokeRequired Then
            Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
            Me.Invoke(d, New Object() {e.Argument, True})
        End If

        If loadassemblyfirst Then
            Me.Status = "Loading... "
            Me.ReportProgress(Me.bgwPrintLoader, 10, "download " & dllfile & "..." & service & " ...")

            Try
                assembly = System.Reflection.Assembly.LoadFrom(Me.DLLServer & "/" & dllfile & "?t=" & Now.Ticks, AppDomain.CurrentDomain.Evidence)
                executeloaddata = True
            Catch ex As Exception
                Dim o As Translib.GeneralObject = New Translib.GeneralObject()
                executeloaddata = False
                assembly = o.GetType().Assembly
                dllfile = assembly.ManifestModule.Name
                errmsg = ex.Message
            End Try
        Else
            executeloaddata = True
        End If


        Dim id As String = ""
        Dim tbltemp As DataTable = Nothing
        tbl = Nothing
        If executeloaddata Then

            Try

                For i = ids.Length - 1 To 0 Step -1
                    id = ids(i)
                    Me.ReportProgress(Me.bgwPrintLoader, 10, "Loading " & id & vbCrLf & " from " & service & " ...")
                    tbltemp = bgwPrintLoader_LoadData(service, id, request, responds)

                    If tbl Is Nothing Then
                        tbl = tbltemp
                    Else
                        tbl.Merge(tbltemp)
                    End If
                Next

                status = EBackgroundworkerStatus.Done
            Catch ex As Exception
                status = EBackgroundworkerStatus.Fail
                errmsg = ex.Message
            End Try

        End If


        If assembly IsNot Nothing Then
            assemblyloaded = True
        Else
            assemblyloaded = False
        End If


        '                      0         1               2                  3               4         5       6        7         8        9       10   11   12            13   14              15                   16              17                     18  
        result = New Object() {dllfile, rdlcobjectname, loadassemblyfirst, assemblyloaded, assembly, errmsg, service, responds, request, status, tbl, ids, reportparams, args, customprinting, customprintingclass, origin_dllfile, origin_rdlcobjectname, PrinterMethod}
        e.Result = result

    End Sub

    Private Sub bgwPrintLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPrintLoader.RunWorkerCompleted
        Dim dllfile As String = e.Result(0)
        Dim rdlcobjectname As String = e.Result(1)
        Dim loadassemblyfirst As Boolean = e.Result(2)
        Dim assemblyloaded As Boolean = e.Result(3)
        Dim assembly As System.Reflection.Assembly = e.Result(4)
        Dim errmsg As String = e.Result(5)
        Dim service As String = e.Result(6)
        Dim responds As String = e.Result(7)
        Dim request As String = e.Result(8)
        Dim status As EBackgroundworkerStatus = e.Result(9)
        Dim tbl As DataTable = e.Result(10)
        Dim ids As String() = e.Result(11)
        Dim reportparams As Microsoft.Reporting.WinForms.ReportParameter() = e.Result(12)
        Dim args As Object = e.Result(13)
        Dim customprinting As Boolean = e.Result(14)
        Dim customprintingclass As String = e.Result(15)
        Dim origin_dllfile As String = e.Result(16)
        Dim origin_rdlcobjectname As String = e.Result(17)
        Dim PrinterMethod As Object = e.Result(18)

        Dim cancel As Boolean = False


        If status = EBackgroundworkerStatus.Fail Then
            System.Windows.Forms.MessageBox.Show(errmsg, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            System.Threading.Thread.Sleep(100)
            If assembly Is Nothing Then
                Exit Sub
            Else
                assemblyloaded = True
            End If
        End If

        Try
            If loadassemblyfirst Then
                If Not assemblyloaded Then Throw New Exception(errmsg)
                If assembly Is Nothing Then Throw New Exception("Cannot Load Assembly")
                Me.oAsmPrint = assembly
                If Not oAsmPrintCol.Contains(dllfile) Then
                    oAsmPrintCol.Add(Me.oAsmPrint, dllfile)
                End If


            End If


            ' Overrides print function
            Dim objPrintingHack As Object
            Dim objNS As String = NamespaceFromRDLCObject(dllfile)
            Try
                objPrintingHack = oAsmPrint.CreateInstance(objNS & ".Printing")
                objPrintingHack.Overrides(ids, tbl, args, cancel)
            Catch ex As Exception
            End Try

            If cancel Then
                Me.fLoadingIndicator.BringToFront()
                Me.fLoadingIndicator.Hide()
                Me.Cursor = System.Windows.Forms.Cursors.Arrow
                Me.DisableForm(False)
                Me.Focus()
            Else


                If PrinterMethod IsNot Nothing Then
                    PrinterMethod.Print(ids, tbl, args)
                ElseIf customprinting Then
                    Me.fLoadingIndicator.Hide()
                    Me.Cursor = System.Windows.Forms.Cursors.Arrow
                    Me.DisableForm(False)

                    Dim objPrintingCustom As Object
                    Dim objPrintingCustomNS As String = NamespaceFromDLLObject(dllfile)
                    Dim objprintinginstancename As String = objPrintingCustomNS & "." & customprintingclass
                    Dim instanceloaded As Boolean = False
                    Try
                        objPrintingCustom = Me.oAsmPrint.CreateInstance(objprintinginstancename)
                        instanceloaded = True
                        objPrintingCustom.Print(ids, tbl, args)

                    Catch ex As Exception
                        If Not instanceloaded Then
                            Throw New Exception(objprintinginstancename & " cannot be created." & vbCrLf & "DLL: " & dllfile)
                        Else
                            Throw New Exception("Method Not found, or different arguments!" & vbCrLf & ".Print(ByRef ids As Object, ByRef tbl As DataTable, ByRef args As Object)" & vbCrLf & "Instance: " & objprintinginstancename & vbCrLf & "DLL: " & dllfile)
                        End If

                    End Try

                Else

                    If UCase(Me.oAsmPrint.ManifestModule.Name) = "TRANSLIB.DLL" Then
                        rdlcobjectname = "Translib.rptBasic.rdlc"
                    End If

                    'Load Report
                    Dim rptObj As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
                    Dim rptDatasource As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                    Dim state As String = ""
                    rptObj.Dock = System.Windows.Forms.DockStyle.Fill
                    rptDatasource.Name = CLSCompliantName(rdlcobjectname)





                    rptDatasource.Value = tbl




                    Try
                        rptObj.LocalReport.LoadReportDefinition(oAsmPrint.GetManifestResourceStream(rdlcobjectname))
                        rptObj.LocalReport.DataSources.Clear()
                        rptObj.LocalReport.DataSources.Add(rptDatasource)
                        If rdlcobjectname = "Translib.rptBasic.rdlc" Then
                            reportparams = New Microsoft.Reporting.WinForms.ReportParameter() { _
                                New Microsoft.Reporting.WinForms.ReportParameter("ERRMSG", errmsg), _
                                New Microsoft.Reporting.WinForms.ReportParameter("DLLFILE", origin_dllfile), _
                                New Microsoft.Reporting.WinForms.ReportParameter("RDLC", origin_rdlcobjectname) _
                            }
                        End If
                        state = "PARAMETER"
                        rptObj.LocalReport.SetParameters(reportparams)
                        rptObj.LocalReport.EnableExternalImages = True
                        rptObj.LocalReport.EnableHyperlinks = True
                        rptObj.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
                        rptObj.RefreshReport()
                    Catch ex As Exception
                        If state = "PARAMETER" Then
                            Throw New Exception("Wrong parameter definition for " & rdlcobjectname & vbCrLf & "report cannot be loaded.")
                        Else
                            Throw New Exception(rdlcobjectname & " cannot be loaded.")
                        End If

                    End Try


                    Me.fLoadingIndicator.Hide()
                    Me.Cursor = System.Windows.Forms.Cursors.Arrow
                    Me.DisableForm(False)

                    Dim o As Translib.GeneralObject = New Translib.GeneralObject()
                    Dim dlgprint As Translib.dlgBasePrint = Me.CreateDialog(o.GetType().Assembly.GetType("Translib.dlgBasePrint", True, True), Me.Title)
                    dlgprint.pnlMain.SuspendLayout()
                    dlgprint.pnlMain.Controls.Clear()
                    dlgprint.pnlMain.Controls.Add(rptObj)
                    dlgprint.pnlMain.ResumeLayout()
                    dlgprint.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID)

                    If UCase(Me.oAsmPrint.ManifestModule.Name) = "TRANSLIB.DLL" Then
                        Me.oAsmPrint = Nothing
                    End If
                End If

            End If






        Catch ex As Exception
            Me.fLoadingIndicator.Hide()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.DisableForm(False)
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try



    End Sub


#End Region

#Region " Print Web Method "

    Private Sub bgwPrintWeb_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwPrintWeb.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub

    Private Sub bgwPrintWeb_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwPrintWeb.DoWork
        Dim dllprint As String = e.Argument(0)
        Dim rdlcobjectname As String = e.Argument(1)
        Dim loadassemblyfirst As Boolean = e.Argument(2)
        Dim ids As String() = e.Argument(3)
        Dim webpage As String = e.Argument(4)
        Dim reportparams As Microsoft.Reporting.WinForms.ReportParameter() = e.Argument(5)
        Dim args As Object = e.Argument(6)

        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim status As EBackgroundworkerStatus = EBackgroundworkerStatus.NotExecuted
        Dim errmsg As String = ""
        Dim responds As String = ""
        Dim result As Object() = New Object() {webpage, ids, responds, status, errmsg, args}

        Dim obj As Newtonsoft.Json.JavaScriptArray = New Newtonsoft.Json.JavaScriptArray()
        Dim json_ids As String
        Dim i As Integer

        For i = 0 To ids.Length - 1
            obj.Add(ids(i))
        Next
        json_ids = Newtonsoft.Json.JavaScriptConvert.SerializeObject(obj)

        If Me.InvokeRequired Then
            Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
            Me.Invoke(d, New Object() {e.Argument, True})
        End If

        Try
            Me.Status = "Loading... "
            Me.ReportProgress(Me.bgwPrintWeb, 10, "opening " & webpage & " ...")
            wConn.addtext("ids", json_ids)
            responds = wConn.post(webpage)
            status = EBackgroundworkerStatus.Done
        Catch ex As Exception
            status = EBackgroundworkerStatus.Fail
            errmsg = ex.Message
        End Try


        result = New Object() {webpage, ids, responds, status, errmsg, args}
        e.Result = result

    End Sub

    Private Sub bgwPrintWeb_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPrintWeb.RunWorkerCompleted
        Dim webpage As String = e.Result(0)
        Dim ids As Object = e.Result(1)
        Dim responds As String = e.Result(2)
        Dim status As EBackgroundworkerStatus = e.Result(3)
        Dim errmsg As String = e.Result(4)
        Dim args As Object = e.Result(5)


        If status = EBackgroundworkerStatus.Fail Then
            System.Windows.Forms.MessageBox.Show(errmsg, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            System.Threading.Thread.Sleep(100)
            Me.fLoadingIndicator.BringToFront()
            Me.fLoadingIndicator.Hide()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.DisableForm(False)
            Me.Focus()
        Else


            Me.fLoadingIndicator.BringToFront()
            Me.fLoadingIndicator.Hide()
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.DisableForm(False)


            Dim cm As System.Windows.Forms.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip
            web_Save = cm.Items.Add("Save")
            web_Preview = cm.Items.Add("Print Preview")

            'wb.Url = 
            wb.DocumentText = responds
            wb.Dock = Windows.Forms.DockStyle.Fill
            wb.AllowNavigation = False
            wb.WebBrowserShortcutsEnabled = False
            wb.ScriptErrorsSuppressed = True
            wb.ContextMenuStrip = cm
            wb.IsWebBrowserContextMenuEnabled = False
            wb.Name = "wb"

            Dim o As Translib.GeneralObject = New Translib.GeneralObject()
            Dim dlgprint As Translib.dlgBasePrint = Me.CreateDialog(o.GetType().Assembly.GetType("Translib.dlgBasePrint", True, True), Me.Title)
            dlgprint.pnlMain.SuspendLayout()
            dlgprint.pnlMain.Controls.Clear()
            dlgprint.pnlMain.Controls.Add(wb)
            dlgprint.pnlMain.ResumeLayout()
            dlgprint.OpenDialog(Me, Me.WebserviceAddress, Me.DLLServer, Me.UserName, Me.SessionID)


        End If

    End Sub

#End Region

#Region " Delete Data "


    Private Function bgwDelete_Execute(ByVal args As Object) As Object
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject

        Dim errmsg As String = ""
        Dim respond As String = ""
        Dim request As String = ""
        Dim service As String = args(0)
        Dim __ID As String = args(1)
        Dim status As EBackgroundworkerStatus = EBackgroundworkerStatus.NotExecuted
        Dim parsed As Boolean = False

        Try
            Me.ReportProgress(Me.bgwDelete, 10, "executing " & Me.WebserviceAddress & "/" & service & " ...")
            wConn.addtext("__ID", __ID)
            objWebResult = WebserviceExecute(wConn, service, respond)
            parsed = True
            Me.WebSaveRequest = wConn.GetPostedRequest()
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)
            status = EBackgroundworkerStatus.Done
        Catch ex As Exception
            If Not parsed Then
                errmsg = Mid(respond, 1, 1000)
            Else
                errmsg = ex.Message & vbCrLf & Mid(respond, 1, 1000)
            End If
            status = EBackgroundworkerStatus.Fail
        End Try

        Dim result As Object = New Object() {service, __ID, status, errmsg}
        Return result

    End Function

    Private Sub bgwDelete_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwDelete.ProgressChanged
        Me.fLoadingIndicator.SetMessage(Me.Message)
        Me.fLoadingIndicator.Refresh()
    End Sub


    Private Sub bgwDelete_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDelete.DoWork
        Me.Status = "Deleting Data... "
        Me.Message = ""

        If Me.InvokeRequired Then
            Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
            Me.Invoke(d, New Object() {e.Argument, True})
        End If

        Dim result As Object
        result = bgwDelete_Execute(e.Argument)
        e.Result = result

        System.Threading.Thread.Sleep(300)

    End Sub

    Private Sub bgwDelete_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDelete.RunWorkerCompleted
        Dim tabMain As FlatTabControl.FlatTabControl = New FlatTabControl.FlatTabControl
        Dim obj As System.Windows.Forms.ToolStripItem

        Me.fLoadingIndicator.BringToFront()
        Me.fLoadingIndicator.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DisableForm(False)

        Dim service As String = e.Result(0)
        Dim __ID As String = e.Result(1)
        Dim status As EBackgroundworkerStatus = e.Result(2)
        Dim message As String = e.Result(3)


        If status = EBackgroundworkerStatus.Fail Then
            System.Windows.Forms.MessageBox.Show(message, "Delete - " & Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Else
            'Data didelete, kembali ke list
            tabMain = Me.GetTabMain()
            tabMain.SelectedTab = tabMain.TabPages("ftabMain_List")

            'hapus row dari data list
            Dim dgvlist As System.Windows.Forms.DataGridView = Me.GetDgvList
            dgvlist.Rows.Remove(dgvlist.CurrentRow)

            System.Windows.Forms.MessageBox.Show(__ID & " has been deleted.", "Delete - " & Me.Title, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)

            Dim resfresh As Boolean = True
            RaiseEvent FormDeleted(__ID, resfresh)

            If resfresh Then
                obj = Me.GetPagingNavigator().Items("bnRefresh")
                Me.RefreshList(Me.GetPagingNavigator, obj)
            End If

        End If



    End Sub



#End Region

#Region " Data Master Loader "

    Public Function LoadDataMaster(ByVal WebService As String, ByVal criteria As String, ByVal DataTableName As String, ByVal message As String, Optional ByVal percent As Integer = 10) As Boolean
        Me.ReportProgress(Me.bgwMasterLoaderQueue, percent, message & vbCrLf & WebService)
        Me.bgwMasterLoader.RunWorkerAsync(New Object() {WebService, criteria, DataTableName})
    End Function

    Private Sub bgwMasterLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwMasterLoader.DoWork
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim respond As String = ""
        Dim request As String = ""
        Dim result As Object
        Dim i, n As Integer
        Dim service As String = e.Argument(0)
        Dim criteria As String = e.Argument(1)
        Dim tableName As String = e.Argument(2)
        Dim msg As String = ""

        Me.BackgroundworkerStatus = EBackgroundworkerStatus.Progress
        Me.WebRespond = "{}"
        result = New Object() {EBackgroundworkerStatus.NotExecuted, service, respond, msg}

        Try
            If Not Me.dsMaster.Tables.Contains(tableName) Then Throw New Exception("Table " & tableName & " not found in dataset dsMaster.")

            wConn.addtext("criteria", criteria)
            objWebResult = WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)

            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    If Me.InvokeRequired Then
                        Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                        Me.Invoke(d, New Object() {Me.dsMaster.Tables(tableName), obj, True})
                    End If
                Next
            End If

            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Done
            result = New Object() {EBackgroundworkerStatus.Done, service, wConn.GetPostedRequest(), respond, msg}
        Catch ex As Exception
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            result = New Object() {EBackgroundworkerStatus.Fail, service, wConn.GetPostedRequest(), respond, ex.Message}
        Finally
            Me.WebRespond = respond
        End Try

        e.Result = result

    End Sub

    Private Sub bgwMasterLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwMasterLoader.RunWorkerCompleted
        Dim result As Object = e.Result

        Dim status As EBackgroundworkerStatus = result(0)
        Dim service As String = result(1)
        Dim request As String = result(2)
        Dim respond As String = result(3)
        Dim msg As String = result(4)
        Select Case status
            Case EBackgroundworkerStatus.Done
                Me.BackgroundworkerStatus = EBackgroundworkerStatus.Done
                Me.Message = ""
            Case EBackgroundworkerStatus.Fail
                Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
                Me.Message = msg
                RaiseEvent FormMasterLoaderError(service, msg, request, respond)
        End Select

    End Sub

    Public Sub bgwMasterLoaderQueue_LoadData(ByVal name As String, ByVal DataTableName As String, ByVal WebService As String, ByVal criteria As String)
        Me.LoadDataMaster(WebService, criteria, DataTableName, "donwloading " & name & " ...")
        Me.WaitWhileBusy(Me.bgwMasterLoader)
        If Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail Then Throw New Exception("Error while downloading " & name & "" & vbCrLf & Me.Message & vbCrLf & WebService)
    End Sub

    Private Sub bgwMasterLoaderQueue_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwMasterLoaderQueue.DoWork
        Dim msg As String = ""
        Dim result As Object = New Object() {EBackgroundworkerStatus.NotExecuted, msg}

        Me.BackgroundworkerStatus = EBackgroundworkerStatus.Progress
        Me.Status = "Loading Data..."

        If Me.InvokeRequired Then
            Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
            Me.Invoke(d, New Object() {e.Argument, True})
        End If

        Try

            Dim i As Integer
            Dim obj As Translib.MasterDataLoader
            For i = 1 To Me.MasterDataLoaderQueue.Tables.Count
                obj = CType(MasterDataLoaderQueue.Tables.Item(i), Translib.MasterDataLoader)
                Me.bgwMasterLoaderQueue_LoadData(obj.Name, obj.DataTableName, obj.WebService, obj.Criteria)
            Next

            Me.WaitWhileBusy(Me.bgwMasterLoader)
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Done
            Me.ReportProgress(Me.bgwMasterLoaderQueue, 20, "Done. ")
            result = New Object() {EBackgroundworkerStatus.Done, ""}
        Catch ex As Exception
            result = New Object() {EBackgroundworkerStatus.Fail, ex.Message}
        End Try

        e.Result = result

    End Sub

    Private Sub bgwMasterLoaderQueue_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwMasterLoaderQueue.RunWorkerCompleted
        Dim result As Object = e.Result
        Dim status As EBackgroundworkerStatus = result(0)
        Dim msg As String = result(1)

        Me.fLoadingIndicator.Hide()
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DisableForm(False)

        Select Case status
            Case EBackgroundworkerStatus.Done
            Case EBackgroundworkerStatus.Fail
                'System.Windows.Forms.MessageBox.Show(msg, Me.Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Select

        Me.mMASTERLOADED = True
        RaiseEvent FormMasterDataLoaded(status, msg)

    End Sub

#End Region




    Public Shared Sub __AddRowFromJsonObject(ByRef tbl As DataTable, ByVal obj As Newtonsoft.Json.JavaScriptObject, Optional ByVal auto_generate_column As Boolean = False)
        Dim row As DataRow
        Dim i As Integer
        Dim columnname As String = ""
        Dim dt As DateTime = Now()

        If auto_generate_column Then
            Dim x As Integer
            Dim arr_keys As String() = {}
            Dim obj_columnname As String

            Array.Resize(arr_keys, obj.Count)
            obj.Keys.CopyTo(arr_keys, 0)
            For x = 0 To arr_keys.Length - 1
                obj_columnname = arr_keys(x)
                If Not tbl.Columns.Contains(obj_columnname) Then
                    tbl.Columns.Add(New DataColumn(obj_columnname, GetType(System.String)))
                End If
            Next

        End If


        Try
            row = tbl.NewRow()
            For i = 0 To tbl.Columns.Count - 1
                columnname = tbl.Columns(i).ColumnName
                If columnname = "inventorymovingdetil_qtypropose" Then
                    Dim r As Int16 = 0
                End If

                If obj(columnname) Is Nothing Then
                    row(columnname) = DBNull.Value
                Else
                    If row.Table.Columns(columnname).DataType Is GetType(DateTime) Then
                        If obj(columnname).ToString = "" Then
                            row(columnname) = DBNull.Value
                        Else
                            dt = CDate(obj(columnname))
                            row(columnname) = dt
                        End If
                    ElseIf row.Table.Columns(columnname).DataType Is GetType(Boolean) Then
                        If obj(columnname).ToString = "" Or obj(columnname).ToString = "0" Then
                            row(columnname) = False
                        Else
                            row(columnname) = True
                        End If
                    ElseIf row.Table.Columns(columnname).DataType Is GetType(Decimal) _
                            Or row.Table.Columns(columnname).DataType Is GetType(Integer) _
                            Or row.Table.Columns(columnname).DataType Is GetType(Long) _
                        Then
                        If obj(columnname).ToString = "" Then
                            row(columnname) = 0
                        Else
                            row(columnname) = CDec(obj(columnname))
                        End If
                    Else
                        row(columnname) = obj(columnname)
                    End If
                End If
            Next
            tbl.Rows.Add(row)
        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & "Key : """ & columnname & """" & vbCrLf & "Please check your webservice vs DataTable")
        End Try

    End Sub

    Public Function WaitWhileBusy(ByRef bgw As System.ComponentModel.BackgroundWorker) As Boolean
        While bgw.IsBusy
            System.Threading.Thread.Sleep(Me.MasterLoaderDelay)
        End While
    End Function

    Public Overridable Sub AddRowFromJsonObject(ByRef tbl As DataTable, ByVal obj As Newtonsoft.Json.JavaScriptObject, Optional ByVal auto_generate_column As Boolean = False)
        __AddRowFromJsonObject(tbl, obj, auto_generate_column)
    End Sub

    Public Overridable Function AddJsonObjectFromRow(ByRef tbl As DataTable, ByVal row As DataRow, ByVal rowstate As System.Data.DataRowState) As Newtonsoft.Json.JavaScriptObject
        Dim obj As Newtonsoft.Json.JavaScriptObject = New Newtonsoft.Json.JavaScriptObject()
        Dim i As Integer
        Dim columnname As String = ""
        Dim sqldatestring As String
        Dim dt As DateTime

        Select Case rowstate
            Case DataRowState.Added
                obj.Add("__ROWSTATE", "NEW")
            Case DataRowState.Modified
                obj.Add("__ROWSTATE", "UPDATE")
            Case DataRowState.Deleted
                obj.Add("__ROWSTATE", "DELETE")
        End Select

        For i = 0 To tbl.Columns.Count - 1
            ' Cek tipe data row yang dimasukkan
            columnname = tbl.Columns(i).ColumnName
            If TypeOf row(tbl.Columns(i).ColumnName) Is DateTime Then
                dt = row(tbl.Columns(i).ColumnName)
                sqldatestring = dt.Year & "-" & dt.Month & "-" & dt.Day & " " & dt.Hour & ":" & dt.Minute & ":" & dt.Second
                obj.Add(columnname, sqldatestring)
            Else
                obj.Add(columnname, row(tbl.Columns(i).ColumnName))
            End If
        Next

        Return obj
    End Function

    Public Overridable Function BindingStart() As Boolean

    End Function

    Public Overridable Function BindingStop() As Boolean

    End Function


    Public Function BindingNavigator_Click(ByRef bn As System.Windows.Forms.BindingNavigator, ByVal obj As System.Windows.Forms.ToolStripItem) As Boolean
        Dim totalPage As Long
        If Me.List_RowMax = 0 Then
            totalPage = 1
        Else
            totalPage = CLng(Me.List_RowCount \ Me.List_RowMax) + 1
        End If



        Select Case obj.Name
            Case "bnMoveFirstItem"
                Me.List_CurrentPageIndex = 1
                Return True
            Case "bnMovePreviousItem"
                Me.List_CurrentPageIndex -= 1
                Return True
            Case "bnMoveNextItem"
                Me.List_CurrentPageIndex += 1
                Return True
            Case "bnMoveLastItem"
                Me.List_CurrentPageIndex = totalPage
                Return True
            Case "bnRefresh"
                Return True
        End Select
    End Function

    Public Function BindingNavigator_SetPagingState(ByRef bn As System.Windows.Forms.BindingNavigator) As Boolean
        Dim totalPage As Long
        If bn Is Nothing Then
            Return False
        End If

        ' Set Paging
        bn.Items("bnRowCount").Visible = True
        bn.Items("bnRowCount").Text = Me.List_RowCount & " Rows"
        bn.Items("bnRowCount").AutoSize = True
        bn.Items("bnRefresh").Enabled = True

        If Me.List_RowMax = 0 Then
            bn.Items("bnMoveFirstItem").Enabled = False
            bn.Items("bnMovePreviousItem").Enabled = False
            bn.Items("bnPositionItem").Enabled = False
            bn.Items("bnPageCount").Enabled = False
            bn.Items("bnMoveNextItem").Enabled = False
            bn.Items("bnMoveLastItem").Enabled = False
            totalPage = 1
            Exit Function
        Else
            totalPage = CLng(Me.List_RowCount \ Me.List_RowMax) + 1
        End If


        bn.Items("bnPositionItem").Text = Me.List_CurrentPageIndex
        bn.Items("bnPageCount").Text = "of " & totalPage

        If Me.List_RowCount <= Me.List_RowMax Then
            bn.Items("bnMoveFirstItem").Enabled = False
            bn.Items("bnMovePreviousItem").Enabled = False
            bn.Items("bnPositionItem").Enabled = False
            bn.Items("bnPageCount").Enabled = False
            bn.Items("bnMoveNextItem").Enabled = False
            bn.Items("bnMoveLastItem").Enabled = False
        Else
            bn.Items("bnPositionItem").Enabled = True
            bn.Items("bnPageCount").Enabled = True

            If Me.List_CurrentPageIndex = 1 Then
                'Halaman Pertama
                bn.Items("bnMoveFirstItem").Enabled = False
                bn.Items("bnMovePreviousItem").Enabled = False
                bn.Items("bnMoveNextItem").Enabled = True
                bn.Items("bnMoveLastItem").Enabled = True
            ElseIf Me.List_CurrentPageIndex = totalPage Then
                'Halaman terakhir
                bn.Items("bnMoveFirstItem").Enabled = True
                bn.Items("bnMovePreviousItem").Enabled = True
                bn.Items("bnMoveNextItem").Enabled = False
                bn.Items("bnMoveLastItem").Enabled = False
            Else
                'Halaman tengah
                bn.Items("bnMoveFirstItem").Enabled = True
                bn.Items("bnMovePreviousItem").Enabled = True
                bn.Items("bnMoveNextItem").Enabled = True
                bn.Items("bnMoveLastItem").Enabled = True
            End If
        End If
    End Function

    Public Function ReportProgress(ByRef bgw As System.ComponentModel.BackgroundWorker, ByVal percent As Integer, Optional ByVal msg As String = "") As Boolean
        If bgw.CancellationPending Then
            Me.BackgroundworkerStatus = EBackgroundworkerStatus.Fail
            System.Threading.Thread.CurrentThread.Abort()
        Else
            If msg <> "" Then
                Me.Message = msg
            End If
            Me.Progress = percent
            bgw.ReportProgress(percent)
        End If
    End Function

    Public Function TabMain_SetSelected(ByVal tab As FlatTabControl.FlatTabControl) As String
        Select Case tab.SelectedTab.Name
            Case "ftabMain_List"
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.tbtnRowAdd.Enabled = False
                Me.tbtnRowDel.Enabled = False
                If Me.AllowPrintOnList Then
                    Me.tbtnPrint.Enabled = True
                Else
                    Me.tbtnPrint.Enabled = False
                End If
                tab.TabPages.Item("ftabMain_List").BackColor = System.Drawing.Color.WhiteSmoke
                tab.TabPages.Item("ftabMain_Data").BackColor = System.Drawing.Color.Gainsboro
            Case "ftabMain_Data"
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.tbtnRowAdd.Enabled = True
                Me.tbtnRowDel.Enabled = True
                If Me.AllowPrintOnData Then
                    Me.tbtnPrint.Enabled = True
                Else
                    Me.tbtnPrint.Enabled = False
                End If
                tab.TabPages.Item("ftabMain_List").BackColor = System.Drawing.Color.Gainsboro
                tab.TabPages.Item("ftabMain_Data").BackColor = System.Drawing.Color.WhiteSmoke
        End Select
        RaiseEvent FormTabmainSelected(tab.SelectedTab.Name)
        Return tab.SelectedTab.Name
    End Function

    Public Function TabMain_OpenData(ByVal dgv As System.Windows.Forms.DataGridView, ByVal key As String, ByVal open_data_service As String) As Boolean
        If dgv.CurrentRow IsNot Nothing Then
            Dim rowIndex As Integer = dgv.CurrentRow.Index
            Dim id = dgv.Rows(rowIndex).Cells(key).Value

            Try
                If Not Me.bgwDataLoader.IsBusy Then
                    Me.bgwDataLoader.RunWorkerAsync(New Object() {open_data_service, id})
                End If
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
        Else
            'Buat Data Baru
            Me.btnNew_Click()
        End If
    End Function

    Public Function TabDetil_SetSelected(ByVal tab As FlatTabControl.FlatTabControl) As String
        Dim tabname As String = tab.SelectedTab.Name
        Dim obj As Translib.DataDetilBindingTable = Me.ddBinding.GetTableByTabName(tabname)


        RaiseEvent FormTabdetilSelecting(tabname, obj)
        If obj IsNot Nothing Then
            If obj.Readonly Then
                Me.tbtnRowAdd.Enabled = False
                Me.tbtnRowDel.Enabled = False
            Else
                Me.tbtnRowAdd.Enabled = obj.AllowAddOrDeleteRows
                Me.tbtnRowDel.Enabled = obj.AllowAddOrDeleteRows
            End If
        Else
            Me.tbtnRowAdd.Enabled = False
            Me.tbtnRowDel.Enabled = False
        End If
        'Dim fnt As System.Drawing.Font = tab.SelectedTab.Font

        'Dim i As Integer
        'For i = 0 To tab.TabCount - 1
        '    If tab.TabPages(i).Name = tab.SelectedTab.Name Then
        '        tab.TabPages(i).Font = New System.Drawing.Font(fnt.FontFamily, fnt.Size, Drawing.FontStyle.Bold)
        '    Else
        '        tab.TabPages(i).Font = New System.Drawing.Font(fnt.FontFamily, fnt.Size, Drawing.FontStyle.Regular)
        '    End If
        'Next


        RaiseEvent FormTabdetilSelected(tabname)
        Return tabname
    End Function





    Public Function AnchorAll(ByRef obj As Object()) As Boolean
        Dim i As Integer

        For i = 0 To obj.Length - 1
            obj(i).Anchor = System.Windows.Forms.AnchorStyles.Bottom
            obj(i).Anchor += System.Windows.Forms.AnchorStyles.Top
            obj(i).Anchor += System.Windows.Forms.AnchorStyles.Right
            obj(i).Anchor += System.Windows.Forms.AnchorStyles.Left
        Next

    End Function

    Public Function SetLocalization() As Boolean
        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.DateTimeFormat.LongDatePattern = "dd/MM/yyyy hh:mm:ss"
        myCIclone.NumberFormat.CurrencySymbol = "Rp "
        myCIclone.NumberFormat.NumberDecimalDigits = 2
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone
    End Function

    Public Shared Function CreateWebService(ByVal ns As String, ByVal obj As String, ByVal act As String, Optional ByVal param As String = "") As String
        Dim str As String

        str = String.Format("{0}?t={1}&ns={2}&object={3}&act={4}", "service.php", Now.Ticks, ns, obj, act)
        If param <> "" Then
            str = str & "&" & param
        End If
        Return str
    End Function

    Public Shared Function CreateDSN(ByVal DbServer As String, ByVal Dbname As String, ByVal DbUsername As String, ByVal DbPassword As String, Optional ByVal DSNFormat As String = "") As String
        Dim dsn As String
        If DSNFormat = "" Then
            DSNFormat = "User ID={0}; Password={1}; Data Source=""{2}""; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"
        End If
        dsn = String.Format(DSNFormat, DbUsername, DbPassword, DbServer, Dbname)
        Return dsn
    End Function


    Public Function DisableForm(ByVal disabled As Boolean) As Boolean
        Me.Enabled = Not disabled
    End Function




    Public Function Datawalk(ByRef dgv As System.Windows.Forms.DataGridView, ByVal direction As EDataWalk, ByRef tblHTemp As DataTable, ByRef dd As DataDetilBinding) As Boolean
        Dim check_changes As Boolean
        Dim res As System.Windows.Forms.DialogResult
        Dim id As String = ""
        Dim move As Boolean = True

        Me.BackgroundworkerSaveStatus = EBackgroundworkerStatus.Init

        Try
            Dim tabMain As FlatTabControl.FlatTabControl = Me.GetTabMain()
            If tabMain.SelectedTab.Name = "ftabMain_Data" Then
                check_changes = True
                id = Me.GetActiveDocumentIDValue()
                tabMain.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try


        RaiseEvent FormDatawalkExecuting(check_changes, id)

        If check_changes Then
            If Me.DataIsChanged(tblHTemp, dd) Then
                res = System.Windows.Forms.MessageBox.Show("Data in document " & id & " has changed." & vbCrLf & vbCrLf & "Do you want to save the changes ?", Me.Title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning)
                Select Case res
                    Case System.Windows.Forms.DialogResult.Yes
                        Me.btnSave_Click()
                        move = True
                    Case System.Windows.Forms.DialogResult.No
                        move = True
                    Case System.Windows.Forms.DialogResult.Cancel
                        move = False
                End Select
            End If
        End If

        If dgv.CurrentRow Is Nothing Then
            move = False
        End If


        If move Then
            Dim currIndex As Integer = dgv.CurrentRow.Index
            Dim totalRow As Integer = dgv.Rows.Count

            Select Case direction
                Case EDataWalk.First
                    currIndex = 0
                Case EDataWalk.Previous
                    If currIndex > 0 Then
                        currIndex -= 1
                    End If
                Case EDataWalk.Next
                    If currIndex < totalRow - 1 Then
                        currIndex += 1
                    End If
                Case EDataWalk.Last
                    currIndex = totalRow - 1
            End Select

            dgv.CurrentCell = dgv(0, currIndex)

        End If

        Try
            Dim tabMain As FlatTabControl.FlatTabControl = Me.GetTabMain()
            If tabMain.SelectedTab.Name = "ftabMain_Data" Then
                If move Then
                    TabMain_OpenData(dgv, Me.tblList.PrimaryKey(0).ColumnName, CreateWebService(Me.WebserviceNSModule, Me.WebserviceObjectModule, "open"))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try


        RaiseEvent FormDatawalkExecuted(move, id)
    End Function

    Public Function Datawalk_Move(ByVal direction As EDataWalk) As Boolean
        Dim dgv As System.Windows.Forms.DataGridView = Me.GetDgvList()
        If dgv IsNot Nothing Then
            Return Me.Datawalk(dgv, direction, Me.tblList_Temp, Me.ddBinding)
        End If
    End Function

    Public Function Datawalk_SetButtonState(ByRef dgv As System.Windows.Forms.DataGridView, ByVal rowIndex As Integer) As Boolean
        'pertama
        If dgv.RowCount > 1 Then
            If rowIndex = 0 Then
                Me.tbtnFirst.Enabled = False
                Me.tbtnPrev.Enabled = False
                Me.tbtnNext.Enabled = True
                Me.tbtnLast.Enabled = True
            ElseIf rowIndex = dgv.RowCount - 1 Then
                Me.tbtnFirst.Enabled = True
                Me.tbtnPrev.Enabled = True
                Me.tbtnNext.Enabled = False
                Me.tbtnLast.Enabled = False
            Else
                Me.tbtnFirst.Enabled = True
                Me.tbtnPrev.Enabled = True
                Me.tbtnNext.Enabled = True
                Me.tbtnLast.Enabled = True
            End If
        End If
    End Function


    Public Function GetPagingNavigator() As System.Windows.Forms.BindingNavigator
        Dim bn As System.Windows.Forms.BindingNavigator
        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_List") Then
                If Me.Controls("ftabMain").Controls("ftabMain_List").Controls.ContainsKey("PnlDfFooter") Then
                    If Me.Controls("ftabMain").Controls("ftabMain_List").Controls("PnlDfFooter").Controls.ContainsKey("bnList") Then
                        bn = Me.Controls("ftabMain").Controls("ftabMain_List").Controls("PnlDfFooter").Controls("bnList")
                        Return bn
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function


    Public Function GetDgvList() As System.Windows.Forms.DataGridView
        Dim dgv As System.Windows.Forms.DataGridView
        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_List") Then
                If Me.Controls("ftabMain").Controls("ftabMain_List").Controls.ContainsKey("PnlDfMain") Then
                    If Me.Controls("ftabMain").Controls("ftabMain_List").Controls("PnlDfMain").Controls.ContainsKey("DgvList") Then
                        dgv = Me.Controls("ftabMain").Controls("ftabMain_List").Controls("PnlDfMain").Controls("DgvList")
                        Return dgv
                    End If
                End If
            End If
        Else
            Return Me.dgvListVirtual
        End If
        Return Nothing
    End Function

    Public Function GetDgvDetil(ByVal tabname As String, ByVal dgvname As String) As System.Windows.Forms.DataGridView
        Dim dgv As System.Windows.Forms.DataGridView
        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_Data") Then
                If Me.Controls("ftabMain").Controls("ftabMain_Data").Controls.ContainsKey("ftabDataDetil") Then
                    Dim tabDetil As FlatTabControl.FlatTabControl = Me.Controls("ftabMain").Controls("ftabMain_Data").Controls("ftabDataDetil")
                    If tabDetil.Controls.ContainsKey(tabname) Then
                        If tabDetil.Controls(tabname).Controls.ContainsKey(dgvname) Then
                            dgv = tabDetil.Controls(tabname).Controls(dgvname)
                            Return dgv
                        End If
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Function GetTabMain(Optional ByVal tabname As String = "") As FlatTabControl.FlatTabControl
        Dim tab As FlatTabControl.FlatTabControl
        If Me.Controls.ContainsKey("ftabMain") Then
            If tabname = "" Then
                tab = Me.Controls("ftabMain")
                Return tab
            Else
                If Me.Controls("ftabMain").Controls.ContainsKey(tabname) Then
                    tab = Me.Controls("ftabMain").Controls(tabname)
                    Return tab
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Function GetTabDetil(Optional ByVal tabname As String = "") As FlatTabControl.FlatTabControl
        Dim tabDetil As FlatTabControl.FlatTabControl
        If Me.Controls.ContainsKey("ftabMain") Then
            If Me.Controls("ftabMain").Controls.ContainsKey("ftabMain_Data") Then
                If Me.Controls("ftabMain").Controls("ftabMain_Data").Controls.ContainsKey("ftabDataDetil") Then
                    If tabname = "" Then
                        tabDetil = Me.Controls("ftabMain").Controls("ftabMain_Data").Controls("ftabDataDetil")
                        Return tabDetil
                    Else
                        If Me.Controls("ftabMain").Controls("ftabMain_Data").Controls("ftabDataDetil").Controls.ContainsKey(tabname) Then
                            tabDetil = Me.Controls("ftabMain").Controls("ftabMain_Data").Controls("ftabDataDetil").Controls(tabname)
                            Return tabDetil
                        End If
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function



    Public Function ClearData() As Boolean
        Dim tableCount As Integer = Me.ddBinding.Tables.Count
        Dim tableIndex As Integer
        Me.tblList_Temp.Clear()
        For tableIndex = 1 To tableCount
            Me.ddBinding.Tables(tableIndex).Table.Clear()
        Next
    End Function

    Public Function CancelAllData() As Boolean
        'Accept Changes
        Dim tableIndex, tableCount As Integer
        Dim tabname, dgvname As String
        Dim dgv As System.Windows.Forms.DataGridView
        tableCount = Me.ddBinding.Tables.Count
        Me.tblList_Temp.RejectChanges()
        For tableIndex = 1 To tableCount
            dgvname = Me.ddBinding.Tables(tableIndex).DgvName
            tabname = Me.ddBinding.Tables(tableIndex).TabName
            dgv = Me.GetDgvDetil(tabname, dgvname)
            Me.ddBinding.Tables(tableIndex).Table.RejectChanges()
            dgv.DataSource = Me.ddBinding.Tables(tableIndex).Table
        Next
    End Function

    Public Function DataIsChanged(ByRef tblHTemp As DataTable, ByRef dd As DataDetilBinding) As Boolean
        Dim dgvDetil As System.Windows.Forms.DataGridView
        Dim i, rowIndex As Integer
        Dim dt_changes As DataTable = Nothing
        Dim changed As Boolean = False


        If Not Me.tbtnSave.Enabled Then
            Return False
            Exit Function
        End If


        Me.BindingContext(Me.tblList_Temp).EndCurrentEdit()
        dt_changes = Me.tblList_Temp.GetChanges()
        If dt_changes IsNot Nothing Then changed = changed Or True

        For i = 1 To dd.Tables.Count
            dgvDetil = Me.GetDgvDetil(dd.Tables(i).TabName, dd.Tables(i).DgvName)
            If dgvDetil.CurrentCell IsNot Nothing Then
                rowIndex = dgvDetil.CurrentCell.RowIndex
                dgvDetil.SuspendLayout()
                dgvDetil.CurrentCell = dgvDetil(dgvDetil.CurrentCell.ColumnIndex, 0)
                dgvDetil.CurrentCell = dgvDetil(dgvDetil.CurrentCell.ColumnIndex, rowIndex)
                dgvDetil.ResumeLayout()
            End If
            Me.BindingContext(Me.ddBinding.Tables(dd.Tables(i).Name)).EndCurrentEdit()
            dt_changes = Nothing
            dt_changes = dd.Tables(i).Table.GetChanges()
            If dt_changes IsNot Nothing Then changed = changed Or True
        Next


        Return changed
    End Function



    Public Shared Function WebserviceExecute(ByVal wConn As Translib.WebConnection, ByVal script As String, ByRef responds As String) As Translib.WebResultObject
        Dim objWebResult As Translib.WebResultObject
        Dim resultParsed As Boolean = False

        responds = wConn.post(script)



        Try
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(responds, GetType(Translib.WebResultObject)), Translib.WebResultObject)

            resultParsed = True
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error" & vbCrLf & vbCrLf & script)
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error, invalid object format." & vbCrLf & vbCrLf & script)
            'If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage & vbCrLf & script)

            If Not objWebResult.success Then
                If objWebResult.errors IsNot Nothing Then
                    Throw New Exception(objWebResult.errors.ErrorMessage & vbCrLf & script)
                Else
                    Throw New Exception("Variable [objWebResult.errors] is not refrenced to an object." & vbCrLf & "Please check your web service, for value of $objResult->success" & vbCrLf & "If defined as false, you have to set $objResult->errors " & vbCrLf & vbCrLf & script)
                End If
            End If

            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0" & vbCrLf & script)
        Catch ex As System.Exception
            objWebResult = New Translib.WebResultObject()
            objWebResult.errors = New Translib.WebResultErrorObject()
            objWebResult.errors.ErrorId = "12"
            If resultParsed Then
                objWebResult.errors.ErrorMessage = ex.Message & vbCrLf & "WebResponse: [" & Mid(Trim(responds), 1, 1000) & "]"
            Else
                objWebResult.errors.ErrorMessage = "Result Cannot be Parsed." & vbCrLf & "Check whether response data contains apostrof(""), which cannot be parsed with json parser. " & vbCrLf & vbCrLf & "Web Respond:" & vbCrLf & Mid(Trim(responds), 1, 2000)
            End If
        End Try

        Return objWebResult
    End Function


    Public Sub OpenLoadingIndicator(ByVal args As Object(), ByVal open As Boolean)
        If open Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.fLoadingIndicator.SetStatus(Me.Status)
            Me.fLoadingIndicator.SetMessage("")
            If Not Me.fLoadingIndicator.Visible Then
                Me.fLoadingIndicator.Show(Me)
            End If
            Me.DisableForm(True)
        Else
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.fLoadingIndicator.SetStatus(Me.Status)
            Me.fLoadingIndicator.SetMessage("")
            If Me.fLoadingIndicator.Visible Then
                Me.fLoadingIndicator.Hide()
            End If
            Me.DisableForm(False)
        End If

    End Sub


    Public Shared Function CLSCompliantName(ByVal name As String) As String
        name = Replace(name, ".", "_")
        Return name
    End Function


    Public Shared Function NamespaceFromRDLCObject(ByVal name As String) As String
        Dim str As String() = name.Split(".")
        name = str(0)
        Return name
    End Function

    Public Shared Function NamespaceFromDLLObject(ByVal name As String) As String
        Dim str As String() = name.Split(".")
        name = str(0)
        Return name
    End Function


    Public Shared Function NamespaceFromAssemblyFullName(ByVal name As String) As String
        Dim str As String() = name.Split(",")
        name = str(0)
        Return name
    End Function


    Public Function CreateDialog(ByVal objType As Type, ByVal title As String) As Translib.dlgBase
        Dim dlg As Translib.dlgBase = CType(Activator.CreateInstance(objType), Translib.dlgBase)
        Dim objectname As String = NamespaceFromAssemblyFullName(Me.GetType().AssemblyQualifiedName)

        dlg.Text = title
        dlg.ObjectName = objectname
        dlg.WebserviceNS = Me.WebserviceNS
        dlg.WebserviceNSModule = Me.WebserviceNSModule
        dlg.WebserviceNSGlobal = Me.WebserviceNSGlobal
        dlg.WebserviceObject = Me.WebserviceObject
        dlg.WebserviceObjectModule = Me.WebserviceObjectModule
        dlg.WebserviceObjectGlobal = Me.WebserviceObjectGlobal
        dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        dlg.ShowInTaskbar = False

        Return dlg
    End Function


    Private Sub web_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles web_Save.Click
        wb.ShowSaveAsDialog()
    End Sub

    Private Sub web_Preview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles web_Preview.Click
        wb.ShowPrintPreviewDialog()
    End Sub

    Private Sub uiBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetLocalization()

        Me.bgwListLoader.WorkerReportsProgress = True
        Me.bgwListLoader.WorkerSupportsCancellation = True
        Me.bgwDataLoader.WorkerReportsProgress = True
        Me.bgwDataLoader.WorkerSupportsCancellation = True
        Me.bgwSave.WorkerReportsProgress = True
        Me.bgwSave.WorkerSupportsCancellation = True
        Me.bgwNew.WorkerReportsProgress = True
        Me.bgwNew.WorkerSupportsCancellation = True
        Me.bgwMasterLoaderQueue.WorkerReportsProgress = True
        Me.bgwMasterLoaderQueue.WorkerSupportsCancellation = True
        Me.bgwMasterLoader.WorkerReportsProgress = True
        Me.bgwMasterLoader.WorkerSupportsCancellation = True
        Me.bgwPrintLoader.WorkerReportsProgress = True
        Me.bgwPrintLoader.WorkerSupportsCancellation = True
        Me.bgwPrintWeb.WorkerReportsProgress = True
        Me.bgwPrintWeb.WorkerSupportsCancellation = True
        Me.bgwDelete.WorkerReportsProgress = True
        Me.bgwDelete.WorkerSupportsCancellation = True


        Me.fLoadingIndicator.Visible = False
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.fLoadingIndicator.ShowInTaskbar = False
        Me.fLoadingIndicator.TopLevel = True

        If Me.ProductName = GeneralObject.DevProductName Then Exit Sub

        Me.bgwMasterLoaderQueue.RunWorkerAsync()



        Me.tbtnPrintPreview.Visible = False
        Me.tbtnEdit.Visible = False
        Me.tbtnRefresh.Visible = False


        If Me.AllowPrintOnList Then
            Me.tbtnPrint.Enabled = True
        Else
            Me.tbtnPrint.Enabled = False
        End If

    End Sub



    Public Shared Function ComboLink(ByRef combobox As System.Windows.Forms.ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal withOption As Boolean, ByVal OnlyShowOptionWhenMoreThanOneRow As Boolean, Optional ByVal optiontext As String = " -- SELECT -- ") As Boolean
        Dim row As System.Data.DataRow

        If Not datatable.Columns.Contains(valuemember) Then
            datatable.Columns.Add(New DataColumn(valuemember, GetType(System.String)))
            datatable.Columns(valuemember).DefaultValue = ""
        End If

        If Not datatable.Columns.Contains(displaymember) Then
            datatable.Columns.Add(New DataColumn(displaymember, GetType(System.String)))
            datatable.Columns(displaymember).DefaultValue = ""
        End If


        If withOption Then
            If datatable.Select(String.Format("{0}='{1}'", valuemember, "0")).Length < 1 Then
                row = datatable.NewRow
                row.Item(valuemember) = "0"
                row.Item(displaymember) = optiontext
                datatable.Rows.InsertAt(row, 0)
            End If
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        If OnlyShowOptionWhenMoreThanOneRow And datatable.Rows.Count > 1 Then
            ' Dimunculkan nilai default
            If datatable.Rows.Count > 1 Then
                row = datatable.Rows(1)
                Dim selectedValue As String = row(valuemember)
                combobox.SelectedValue = selectedValue
            End If
        End If

        Return True
    End Function

    Public Overridable Function LoadDataIntoDatatable(ByVal service As String, ByVal criteria As String, ByRef respond As String) As DataTable
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim n, i As Integer
        Dim tbl As DataTable = New DataTable()

        Try
            wConn.addtext("criteria", criteria)
            objWebResult = WebserviceExecute(wConn, service, respond)
            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    Me.AddRowFromJsonObject(tbl, obj, True)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(Mid(respond, 1, 1000) & vbCrLf & vbCrLf & ex.Message)
        End Try

        Return tbl
    End Function

End Class

