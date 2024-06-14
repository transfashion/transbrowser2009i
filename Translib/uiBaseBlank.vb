Public Class uiBaseBlank

    Public Enum EBackgroundworkerStatus
        NotExecuted = 0
        Init = 1
        Progress = 2
        Done = 3
        Fail = 4
    End Enum



    Private mProgram As Translib.SolutionProgram
    Private mDSNLocal As String
    Private mParameter As String
    Private mBrowser As Object = Nothing
    Private mStartupMessage As String
    Private mSessionID As String
    Private mTitle As String = ""

    Private mBackgroundworkerStatus As EBackgroundworkerStatus
    Private mStatus As String
    Private mMessage As String
    Private mProgress As Integer

    Private mWebserviceNS As String
    Private mWebserviceNSGlobal As String = "transbrowser"
    Private mWebserviceNSModule As String
    Private mWebServiceObject As String
    Private mWebServiceObjectGlobal As String = "uimaster"
    Private mWebServiceObjectModule As String

    Friend mUsername As String = "root"
    Friend mWebserviceAddress As String = "http://localhost/transbrowser"
    Friend mDllServer As String = "http://localhost/transbrowser"

    Public uiAssembly As System.Reflection.Assembly
    Public WithEvents fLoadingIndicator As frmLoading = New frmLoading()



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


    Public ReadOnly Property VersionNumber() As String
        Get
            Return Me.ProductVersion
        End Get
    End Property


    Public ReadOnly Property UIBaseType() As String
        Get
            Return "uiBaseBlank"
        End Get
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

    Public Property BackgroundworkerStatus() As EBackgroundworkerStatus
        Get
            Return Me.mBackgroundworkerStatus
        End Get
        Set(ByVal value As EBackgroundworkerStatus)
            Me.mBackgroundworkerStatus = value
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

#Region " Overridable "

    Public Overridable Function btnNew_Click() As Boolean
    End Function

    Public Overridable Function btnSave_Click() As Boolean
    End Function

    Public Overridable Function btnPrint_Click() As Boolean
    End Function

    Public Overridable Function btnPrintPreview_Click() As Boolean
    End Function

    Public Overridable Function btnEdit_Click() As Boolean
    End Function

    Public Overridable Function btnDel_Click() As Boolean
   

    End Function

    Public Overridable Function btnLoad_Click() As Boolean
    End Function

    Public Overridable Function btnQuery_Click() As Boolean
    End Function

    Public Overridable Function btnRefresh_Click() As Boolean
   
    End Function

    Public Overridable Function btnReset_Click() As Boolean
    End Function

    Public Overridable Function btnRowAdd_Click() As Boolean
  

    End Function

    Public Overridable Function btnRowEdit_Click() As Boolean
 

    End Function

    Public Overridable Function btnRowDel_Click() As Boolean

    End Function

    Public Overridable Function btnFirst_Click() As Boolean
    End Function

    Public Overridable Function btnPrev_Click() As Boolean
    End Function

    Public Overridable Function btnNext_Click() As Boolean
    End Function

    Public Overridable Function btnLast_Click() As Boolean
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


    Private Sub uiBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetLocalization()

        Me.fLoadingIndicator.Visible = False
        Me.fLoadingIndicator.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.fLoadingIndicator.ShowInTaskbar = False
        Me.fLoadingIndicator.TopLevel = True

        If Me.ProductName = GeneralObject.DevProductName Then Exit Sub

        Me.tbtnPrintPreview.Visible = False
        Me.tbtnEdit.Visible = False
        Me.tbtnRefresh.Visible = False

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

