Public Class dlgBase
    Private myRetObj As Object
    Private frmOwner As System.Windows.Forms.IWin32Window


    Private mSessionID As String


    Friend mUsername As String = "root"
    Friend mWebserviceAddress As String = "http://localhost/transbrowser"
    Friend mDllServer As String = "http://localhost/transbrowser"
    Friend mObjectName As String = ""

    Private mWebserviceNS As String
    Private mWebserviceNSGlobal As String = "transbrowser"
    Private mWebserviceNSModule As String
    Private mWebServiceObject As String
    Private mWebServiceObjectGlobal As String = "uimaster"
    Private mWebServiceObjectModule As String

    Public Event DataLoaded(ByVal service As String)
    Public Event DialogOKClick(ByRef retObj As Object, ByRef cancel As Boolean)
    Public Event DialogCancelClick()

    Public ds As DataSet = New DataSet()
    Public mArgument As Object = New Object

    Public WithEvents fLoadingIndicator As Translib.frmLoading
    Public WithEvents bgwDataLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker

    Delegate Sub BackgroundworkerInvokeFunction(ByVal arg As Object())
    Delegate Sub BackgroundworkerAddRowFromJsonObjectInvokeFunction(ByRef tbl As DataTable, ByVal obj As Newtonsoft.Json.JavaScriptObject, ByVal auto_generate_column As Boolean)


#Region "API Calls"
    ' standard API declarations for INI access
    ' changing only "As Long" to "As Int32" (As Integer would work also)
    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
    Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpString As String, _
    ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, _
    ByVal lpReturnedString As String, ByVal nSize As Int32, _
    ByVal lpFileName As String) As Int32
#End Region

#Region " Ini File "

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String, _
    ByVal DefaultValue As String) As String
        ' primary version of call gets single value given all parameters
        Dim n As Int32
        Dim sData As String

        sData = Space$(1024) ' allocate some room 
        n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, _
        sData, sData.Length, INIPath)

        If n > 0 Then ' return whatever it gave us
            INIRead = sData.Substring(0, n)
        Else
            INIRead = ""
        End If
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String) As String
        ' overload 1 assumes zero-length default
        Return INIRead(INIPath, SectionName, KeyName, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String) As String
        ' overload 2 returns all keys in a given section of the given file
        Return INIRead(INIPath, SectionName, Nothing, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String) As String
        ' overload 3 returns all section names given just path
        Return INIRead(INIPath, Nothing, Nothing, "")
    End Function

    Public Sub INIWrite(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String, ByVal TheValue As String)
        Call WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath)
    End Sub

    Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String) ' delete single line from section
        Call WritePrivateProfileString(SectionName, KeyName, Nothing, INIPath)
    End Sub

    Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String)
        ' delete section from INI file
        Call WritePrivateProfileString(SectionName, Nothing, Nothing, INIPath)
    End Sub

#End Region



#Region " Constructor "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal webservice As String, ByVal dllserv As String, ByVal username As String, ByVal session_id As String) As Object
        Me.mWebserviceAddress = webservice
        Me.mDllServer = dllserv
        Me.fLoadingIndicator = New frmLoading()
        Me.frmOwner = owner
        Me.mSessionID = session_id
        Me.mUsername = username

        MyBase.ShowDialog(owner)
        Return myRetObj
    End Function

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, ByVal webservice As String, ByVal dllserv As String, ByVal username As String, ByVal session_id As String, ByVal args As Object) As Object
        Me.Argument = args
        Return Me.OpenDialog(owner, webservice, dllserv, username, session_id)
    End Function

#End Region

#Region " Property "

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

    Public ReadOnly Property UserName() As String
        Get
            Return mUsername
        End Get
    End Property

    Public ReadOnly Property SessionID() As String
        Get
            Return mSessionID
        End Get
    End Property

    Public Property ObjectName() As String
        Get
            Return mObjectName
        End Get
        Set(ByVal value As String)
            mObjectName = value
        End Set
    End Property

    Public Property Argument() As Object
        Get
            Return mArgument
        End Get
        Set(ByVal value As Object)
            mArgument = value
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


#End Region

#Region " Data Loader "

    Public Overridable Function bgwDataLoader_Load(ByVal args As Object()) As Object
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim respond As String = ""
        Dim request As String = ""
        Dim i, n As Integer
        Dim service As String = args(0)
        Dim criteria As String = args(1)
        Dim tblname As String = args(2)
        Dim dgvname As String = args(3)
        Dim errmsg As String = ""
        Dim bgstatus As Translib.uiBase.EBackgroundworkerStatus = uiBase.EBackgroundworkerStatus.NotExecuted
        Dim result As Object() = New Object() {service, criteria, tblname, dgvname, respond, request, bgstatus, errmsg}




        Try
            wConn.addtext("criteria", criteria)

            objWebResult = Translib.uiBase.WebserviceExecute(wConn, service, respond)
            If objWebResult.errors IsNot Nothing Then Throw New Exception(objWebResult.errors.ErrorMessage)

            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)
                    If Me.InvokeRequired Then
                        Dim d As New BackgroundworkerAddRowFromJsonObjectInvokeFunction(AddressOf AddRowFromJsonObject)
                        Me.Invoke(d, New Object() {Me.ds.Tables(tblname), obj, True})
                    End If
                Next
            End If

            bgstatus = uiBase.EBackgroundworkerStatus.Done
        Catch ex As Exception
            bgstatus = uiBase.EBackgroundworkerStatus.Fail
            errmsg = ex.Message
        Finally
        End Try

        result = New Object() {service, criteria, tblname, dgvname, respond, request, bgstatus, errmsg}
        Return result

    End Function

    Private Sub bgwDataLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDataLoader.DoWork
        If Me.InvokeRequired Then
            Dim d As New BackgroundworkerInvokeFunction(AddressOf OpenLoadingIndicator)
            Me.Invoke(d, New Object() {e.Argument})
        End If

        Dim result As Object()
        result = Me.bgwDataLoader_Load(e.Argument)

        e.Result = result

    End Sub

    Private Sub bgwDataLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDataLoader.RunWorkerCompleted
        Dim args As Object() = e.Result
        Dim service As String = args(0)
        Dim criteria As String = args(1)
        Dim tblname As String = args(2)
        Dim dgvname As String = args(3)
        Dim respond As String = args(4)
        Dim request As String = args(5)
        Dim status As Translib.uiBase.EBackgroundworkerStatus = args(6)
        Dim errmsg As String = args(7)

        'Me.fLoadingIndicator.Dispose()
        Me.pnlLoading.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DisableForm(False)
        'Me.BringToFront()

        If status = uiBase.EBackgroundworkerStatus.Fail Then
            System.Windows.Forms.MessageBox.Show(errmsg, Me.Text, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Else
            Dim dgv As System.Windows.Forms.DataGridView = Nothing
            dgv = Me.GetDatagrid(dgvname)
            If dgv IsNot Nothing Then
                dgv.DataSource = Me.ds.Tables(tblname)
            End If
            RaiseEvent DataLoaded(service)
        End If

    End Sub

#End Region


    Public Overridable Function LoadDataIntoDatatable(ByVal service As String, ByVal criteria As String, ByRef respond As String) As DataTable
        Dim wConn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim n, i As Integer
        Dim tbl As DataTable = New DataTable()

        Try
            wConn.addtext("criteria", criteria)
            objWebResult = Translib.uiBase.WebserviceExecute(wConn, service, respond)
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

    Public Function PrepareDatarow(ByVal table As DataTable) As DataRow
        Dim row As DataRow = table.Copy.NewRow()
        Dim columnname As String

        If Me.Argument(1) IsNot Nothing Then
            If Me.Argument(1).GetType Is GetType(System.Windows.Forms.DataGridViewRow) Then
                Dim dgvrow As System.Windows.Forms.DataGridViewRow = CType(Me.Argument(1), System.Windows.Forms.DataGridViewRow)
                Dim i As Integer
                For i = 0 To table.Columns.Count - 1
                    columnname = table.Columns(i).ColumnName
                    If columnname <> table.PrimaryKey(0).ColumnName _
                        And columnname <> table.PrimaryKey(1).ColumnName Then
                        If dgvrow.DataGridView.Columns.Contains(columnname) Then
                            row(columnname) = dgvrow.Cells(columnname).Value
                        End If
                    End If
                Next
            End If
        End If

        Return row
    End Function

    Public Function GetDatagrid(ByVal dgvname As String) As System.Windows.Forms.DataGridView
        Dim dgv As System.Windows.Forms.DataGridView = Nothing

        If Me.Controls.ContainsKey("pnlMain") Then
            If Me.Controls("pnlMain").Controls.ContainsKey(dgvname) Then
                dgv = Me.Controls("pnlMain").Controls(dgvname)
            End If
        End If

        Return dgv
    End Function

    Public Function DataLoad(ByVal service As String, ByVal criteria As String, ByVal tblname As String, ByVal dgvname As String) As Boolean
        Dim args() As Object = New Object() {service, criteria, tblname, dgvname}
        Dim dgv As System.Windows.Forms.DataGridView = Nothing

        dgv = Me.GetDatagrid(dgvname)
        If dgv IsNot Nothing Then
            dgv.DataSource = Nothing
        End If

        ds.Tables(tblname).Clear()

        Me.bgwDataLoader.RunWorkerAsync(args)

    End Function

    Public Overridable Sub AddRowFromJsonObject(ByRef tbl As DataTable, ByVal obj As Newtonsoft.Json.JavaScriptObject, Optional ByVal auto_generate_column As Boolean = False)
        Translib.uiBase.__AddRowFromJsonObject(tbl, obj, auto_generate_column)
    End Sub

#Region " Default Events "

    Public Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RaiseEvent DialogCancelClick()
        myRetObj = Nothing
        Me.Close()
    End Sub

    Public Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim cancel As Boolean = False

        myRetObj = New Object()
        RaiseEvent DialogOKClick(myRetObj, cancel)

        If Not cancel Then
            Me.Close()
        End If

    End Sub




    Public Sub OpenLoadingIndicator(ByVal args As Object())

        Me.TopLevel = True

        'Me.fLoadingIndicator = New Translib.frmLoading
        'Me.fLoadingIndicator.ShowInTaskbar = False
        'Me.fLoadingIndicator.TopMost = True
        'Me.fLoadingIndicator.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        'Me.fLoadingIndicator.SetMessage(Me.WebserviceAddress)
        'Me.fLoadingIndicator.Show(Me)
 
        Me.pnlLoading.Visible = True
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DisableForm(True)
    End Sub

    Public Function DisableForm(ByVal disabled As Boolean) As Boolean
        Dim obj As System.Windows.Forms.Control
        Me.SuspendLayout()
        If disabled Then
            Me.btnOK.Enabled = False
            Me.btnCancel.Enabled = False
            For Each obj In Me.Controls
                If obj.Name <> "pnlButtonBottom" Then
                    Me.Controls(obj.Name).Enabled = False
                End If
            Next
        Else
            Me.btnOK.Enabled = True
            Me.btnCancel.Enabled = True
            For Each obj In Me.Controls
                If obj.Name <> "pnlButtonBottom" Then
                    Me.Controls(obj.Name).Enabled = True
                End If
            Next
        End If
        Me.ResumeLayout()
        'Me.Enabled = Not disabled
    End Function


    Public Function CreateDialog(ByVal objType As Type, ByVal title As String) As Translib.dlgBase
        Dim dlg As Translib.dlgBase = CType(Activator.CreateInstance(objType), Translib.dlgBase)
        Dim objectname As String = Translib.uiBase.NamespaceFromAssemblyFullName(Me.GetType().AssemblyQualifiedName)

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

#End Region

End Class