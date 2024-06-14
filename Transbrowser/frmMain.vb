Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI
Imports VS2005Extender

Public Class frmMain

    Public Enum EAssemblyLoadStatus
        Init = 1
        Progress = 2
        Done = 3
        Fail = 4
    End Enum


    Public DllServer As String = ""
    Public WebserviceAddress As String = ""
    Public DllServerDefault As String = ""
    Public WebserviceAddressDefault As String = ""
    Public DllServerRemote As String = ""
    Public WebserviceAddressRemote As String = ""
    Public EnableRemoteProcedureCall As Boolean = False
    Public LocalDllLocation As String = ""
    Public LocalDbConfigtype As String = ""
    Public LocalDbServer As String = ""
    Public LocalDbUsername As String = ""
    Public LocalDbPassword As String = ""
    Public LocalDbname As String = ""
    Public LocalDSNFormat As String = ""

    Public ObjImageList As System.Windows.Forms.ImageList = New System.Windows.Forms.ImageList

    Private oDefaultRenderer As New ToolStripProfessionalRenderer(New PropertyGridEx.CustomColorScheme)
    Private UserName As String
    Private SessionID As String
    Private UserParameter As String
    Private StartupErrorMessage As String
    Private mAssemblyLoadStatus As EAssemblyLoadStatus
    Private mAssemblyLoadMessage As String
    Private HtAssembly As Hashtable = New Hashtable()
    Private LoadedModules As Collection = New Collection()
    Private ReloadModuleEveryProgram As Boolean = False


    Friend WithEvents FormStartPage As frmStartPage
    Friend WithEvents SolutionExplorer As frmSolution
    Friend WithEvents fLoading As Translib.frmLoading = New Translib.frmLoading()
    Friend WithEvents bgwAssemblyLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker


    Delegate Sub OpenNewFormFunction(ByVal objProgram As Translib.SolutionProgram)



#Region " Properties "

    Public Property AssemblyLoadStatus() As EAssemblyLoadStatus
        Get
            Return mAssemblyLoadStatus
        End Get
        Set(ByVal value As EAssemblyLoadStatus)
            mAssemblyLoadStatus = value
        End Set
    End Property

    Public Property AssemblyLoadMessage() As String
        Get
            Return mAssemblyLoadMessage
        End Get
        Set(ByVal value As String)
            mAssemblyLoadMessage = value
        End Set
    End Property

#End Region




#Region " API Calls"

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


    Private Declare Function DeleteUrlCacheEntry Lib "wininet" _
       Alias "DeleteUrlCacheEntryA" _
      (ByVal lpszUrlName As String) As Long


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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim iniFile As String = Application.StartupPath & "\TransBrowser.ini"
        Dim MyFile As New System.IO.FileInfo(iniFile)
        Dim _ReloadModuleEveryProgram As String

        Dim dsnTemp As String = "User ID={0}; Password={1}; Data Source=""{2}""; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"


        Try
            If Not MyFile.Exists() Then
                Throw New System.IO.FileNotFoundException
            End If

            _ReloadModuleEveryProgram = Me.INIRead(iniFile, "ApplicationServer", "ReloadModuleEveryProgram")
            If _ReloadModuleEveryProgram = "True" Then Me.ReloadModuleEveryProgram = True

            Me.DllServer = Me.INIRead(iniFile, "ApplicationServer", "dll_server")
            Me.WebserviceAddress = Me.INIRead(iniFile, "ApplicationServer", "WebserviceAddress")
            Me.DllServerDefault = Me.DllServer
            Me.WebserviceAddressDefault = Me.WebserviceAddress
            Me.DllServerRemote = Me.INIRead(iniFile, "ApplicationServer", "dll_server_remote", "")
            Me.WebserviceAddressRemote = Me.INIRead(iniFile, "ApplicationServer", "dll_server_remote", "")
            Me.EnableRemoteProcedureCall = CBool(Me.INIRead(iniFile, "ApplicationServer", "dll_server_remote", "False"))
            Me.LocalDllLocation = Me.INIRead(iniFile, "Local", "dll_location")
            Me.LocalDbConfigtype = Me.INIRead(iniFile, "Local", "db_configtype")
            Me.LocalDbServer = Me.INIRead(iniFile, "Local", "db_server")
            Me.LocalDbUsername = Me.INIRead(iniFile, "Local", "db_user")
            Me.LocalDbPassword = Me.INIRead(iniFile, "Local", "db_password")
            Me.LocalDbname = Me.INIRead(iniFile, "Local", "db_name")
            Me.LocalDSNFormat = Me.INIRead(iniFile, "Local", "DSNFormat", dsnTemp)

        Catch ex As System.IO.FileNotFoundException

            Me.INIWrite(iniFile, "ApplicationServer", "dll_server", "http://localhost")
            Me.INIWrite(iniFile, "ApplicationServer", "WebserviceAddress", "http://localhost")
            Me.INIWrite(iniFile, "Local", "dll_location", "http://localhost")
            Me.INIWrite(iniFile, "Local", "db_configtype", "manual")
            Me.INIWrite(iniFile, "Local", "db_server", "")
            Me.INIWrite(iniFile, "Local", "db_name", "")
            Me.INIWrite(iniFile, "Local", "db_user", "")
            Me.INIWrite(iniFile, "Local", "db_password", "")
            Me.INIWrite(iniFile, "Local", "DSNFormat", dsnTemp)

        Catch ex As Exception
            StartupErrorMessage = ex.Message
        End Try



        Me.txtStatusUsername.Visible = False
        Me.txtStatusServername.Text = Me.WebserviceAddress
        Me.txtStatusServername.AutoSize = True
        Me.txtStatusDatabasename.Text = ""
        Me.txtStatusDatabasename.AutoSize = True


    End Sub

#End Region

#Region " Public Function "

    Public Function SetUser(ByVal username As String, ByVal UserFullName As String, ByVal parameter As String) As Boolean
        Dim displayedName As String

        If UserFullName <> "" Then
            displayedName = UserFullName
        Else
            displayedName = username
        End If


        Me.UserName = username
        Me.UserParameter = parameter
        Me.txtStatusUsername.Text = displayedName
        Me.txtStatusUsername.AutoSize = True
        Me.txtStatusUsername.Visible = True


    End Function

    Public Function SetSession(ByVal session_id As String, ByVal database As String) As Boolean
        Me.SessionID = session_id
        Me.txtSessionID.Text = session_id
        Me.txtSessionID.AutoSize = True
        Me.txtSessionID.Visible = True

        Me.txtStatusDatabasename.Text = database
        Me.txtStatusDatabasename.AutoSize = True
        Me.txtStatusDatabasename.Visible = True

    End Function

    Public Function SetFirstGroup() As Boolean
        Dim wconn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim objWebResultParsed As Boolean = False
        Dim str_result As String = ""
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim i, n As Integer
        Dim group_id, group_name, group_descr As String

        Try
            str_result = wconn.post(String.Format("service.php?t={0}&ns=transbrowser&object=uistartpage&act=getgrouplist", Now.Ticks))
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(str_result, GetType(Translib.WebResultObject)), Translib.WebResultObject)

            objWebResultParsed = True
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error")
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error")
            If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0")


            Dim arrdatagroup As ArrayList = New ArrayList()
            Dim objGroup As Translib.UserGroup

            n = objWebResult.data.Count
            If n > 0 Then
                For i = 0 To n - 1
                    obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)

                    group_id = obj("group_id")
                    group_name = obj("group_name")
                    group_descr = obj("group_descr")

                    objGroup = New Translib.UserGroup(group_id, group_name, group_descr)
                    arrdatagroup.Add(objGroup)
                Next

                Me.SolutionExplorer.SetGroupDatasource(arrdatagroup)
            Else
                MessageBox.Show("There's no group associated with your account.", "Transbrowser - SetFirstGroup", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            If objWebResultParsed = True Then
                MessageBox.Show("Cannot browse user groups!" & vbCrLf & ex.Message, "Transbrowser - SetFirstGroup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(Mid(str_result, 1, 1000), "Transbrowser - SetFirstGroup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try

    End Function

    Public Function SetProgramlistByGroup(ByVal group_id As String) As Boolean
        Dim wconn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim str_result As String = ""
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim i, n As Integer
        Dim program_id, program_title, program_descr, program_icon, program_ns, program_instance, program_dll, program_type, program_parameter As String
        Dim program_issingleinstance, program_islocaldll, program_islocaldb As Boolean

        Try
            wconn.addtext("group_id", group_id)
            str_result = wconn.post(String.Format("service.php?t={0}&ns=transbrowser&object=uistartpage&act=getprogramlist", Now.Ticks))
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(str_result, GetType(Translib.WebResultObject)), Translib.WebResultObject)
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error")
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error")
            If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0")

            Dim arrprogram As ArrayList = New ArrayList()
            Dim objProgram As Translib.SolutionProgram

            n = objWebResult.data.Count
            For i = 0 To n - 1
                obj = CType(objWebResult.data(i), Newtonsoft.Json.JavaScriptObject)

                program_id = obj("program_id")
                program_title = obj("program_title")
                program_descr = obj("program_descr")
                program_icon = obj("program_icon")
                program_ns = obj("program_ns")
                program_dll = obj("program_dll")
                program_instance = obj("program_instance")
                program_type = obj("program_type")
                program_issingleinstance = obj("program_issingleinstance")
                program_parameter = obj("program_parameter")
                program_islocaldll = obj("program_islocaldll")
                program_islocaldb = obj("program_islocaldb")

                objProgram = New Translib.SolutionProgram(program_id, program_title, program_icon, program_ns, program_dll, program_instance, program_descr, program_type, program_issingleinstance, program_parameter, program_islocaldll, program_islocaldb)
                arrprogram.Add(objProgram)

            Next

            Me.SolutionExplorer.SetProgramDatasource(arrprogram)

        Catch ex As Exception
            MessageBox.Show("Cannot browse group programs!" & vbCrLf & ex.Message, "Transbrowser - SetProgramlistByGroup", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function LoadImage(ByVal IconFileName As String) As System.Drawing.Image
        Dim IconImage As System.Drawing.Image

        IconFileName = Me.WebserviceAddress & "/images/icons/" & IconFileName

        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim data As System.IO.Stream = client.OpenRead(IconFileName)
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(data)
            IconImage = New System.Drawing.Bitmap(reader.BaseStream)
        Catch ex As Exception
            IconImage = Nothing
        End Try

        Return IconImage

    End Function


    Public Function OpenNewForm(ByVal objProgram As Translib.SolutionProgram, Optional ByVal reload As Boolean = False) As Boolean
        If Not Me.bgwAssemblyLoader.IsBusy Then
            objProgram.Reload = reload
            Me.bgwAssemblyLoader.RunWorkerAsync(objProgram)
        End If
    End Function

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

    Public Function SolutionProgramSelected() As Boolean
        Me.Text = "TransBrowser"
    End Function

    Public Function SolutionProgramSelected(ByVal ObjSolutionProgram As Translib.SolutionProgram) As Boolean
        If ObjSolutionProgram Is Nothing Then
            Me.Text = "TransBrowser"
        Else
            Me.Text = ObjSolutionProgram.Title & " - TransBrowser"
        End If
    End Function


    Public Function DSNToDbConnectionStatus(ByVal DSN As String) As String
        Dim str As String = ""
        Dim dbConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(DSN)
        str = dbConn.Database & "@" & dbConn.DataSource
        Return str
    End Function


    Public Function GetBrowserClientConfig() As String
        Dim str As String = ""
        MessageBox.Show("test")
        Return str
    End Function



#End Region


#Region " Message to Child Form "

    Private Function SendMessageToStartupForm(ByVal Message As String) As Boolean
        Dim f As Object
        f = CType(Me.ActiveMdiChild, Object)
        If f IsNot Nothing Then
            If f.Name = "frmStartPage" Then
                f.SetStatusLoginMessage(Message)
            End If
        End If
        Return True
    End Function

    Private Function SendMessageToChildForm(ByVal Message As String) As Boolean
        Dim f As Form
        Dim fchild As frmProgram
        Try
            If Me.ActiveMdiChild IsNot Nothing Then
                f = Me.ActiveMdiChild
                If f.Name = "frmProgram" Then
                    fchild = CType(f, frmProgram)
                    If fchild IsNot Nothing Then
                        fchild.SendMessageToControl(Message)
                    End If
                ElseIf f.Name = "frmStartPage" Then
                    Select Case Message
                        Case "CaseStudies"
                            Me.ShowTransbrowserCaseStudiesForm()
                        Case "Contents"
                            Me.ShowTransbrowserContentsForm()
                        Case "Index"
                            Me.ShowTransbrowserIndexForm()
                        Case "Search"
                            Me.ShowTransbrowserSearchForm()
                        Case "About"
                            Me.ShowTransbrowserAboutForm()
                    End Select
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function




    Private Sub PrintSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSetupToolStripMenuItem.Click
        Me.SendMessageToChildForm("PrintSetup")
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Me.SendMessageToChildForm("PrintPreview")
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Me.SendMessageToChildForm("Print")
    End Sub

    Private Sub LoadDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadDataToolStripMenuItem.Click
        Me.SendMessageToChildForm("Load")
    End Sub

    Private Sub QueriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueriToolStripMenuItem.Click
        Me.SendMessageToChildForm("Query")
    End Sub

    Private Sub ResetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetToolStripMenuItem.Click
        Me.SendMessageToChildForm("Reset")
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Me.SendMessageToChildForm("New")
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Me.SendMessageToChildForm("Save")
    End Sub

    Private Sub DelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelToolStripMenuItem.Click
        Me.SendMessageToChildForm("Del")
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        Me.SendMessageToChildForm("Cancel")
    End Sub

    Private Sub CancelAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelAllToolStripMenuItem.Click
        Me.SendMessageToChildForm("CancelAll")
    End Sub

    Private Sub FirstToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstToolStripMenuItem.Click
        Me.SendMessageToChildForm("First")
    End Sub

    Private Sub PreviousToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousToolStripMenuItem.Click
        Me.SendMessageToChildForm("Prev")
    End Sub

    Private Sub NextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextToolStripMenuItem.Click
        Me.SendMessageToChildForm("Next")
    End Sub

    Private Sub LastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastToolStripMenuItem.Click
        Me.SendMessageToChildForm("Last")
    End Sub

    Private Sub StatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusToolStripMenuItem.Click
        Me.SendMessageToChildForm("ShowStatus")
    End Sub

    Private Sub HelpTopicsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpTopicsToolStripMenuItem.Click
        Me.SendMessageToChildForm("HelpTopic")
    End Sub

    Private Sub CaseStudiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaseStudiesToolStripMenuItem.Click
        Me.SendMessageToChildForm("CaseStudies")
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Me.SendMessageToChildForm("Contents")
    End Sub

    Private Sub IndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndexToolStripMenuItem.Click
        Me.SendMessageToChildForm("Index")
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Me.SendMessageToChildForm("Search")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Me.SendMessageToChildForm("About")
    End Sub

    Public Function MenuEnabled(ByVal Name As String, ByVal state As Boolean)
        Select Case Name
            Case "LoadData"
                Me.LoadDataToolStripMenuItem.Enabled = state
            Case "Queri"
                Me.QueriToolStripMenuItem.Enabled = state
            Case "Reset"
                Me.ResetToolStripMenuItem.Enabled = state
            Case "New"
                Me.NewToolStripMenuItem.Enabled = state
            Case "Save"
                Me.SaveToolStripMenuItem.Enabled = state
            Case "Delete"
                Me.DelToolStripMenuItem.Enabled = state
            Case "Cancel"
                Me.CancelAllToolStripMenuItem.Enabled = state
            Case "CancelAll"
                Me.CancelAllToolStripMenuItem.Enabled = state
            Case "First"
                Me.FirstToolStripMenuItem.Enabled = state
            Case "Previous"
                Me.PreviousToolStripMenuItem.Enabled = state
            Case "Next"
                Me.NextToolStripMenuItem.Enabled = state
            Case "Last"
                Me.LastToolStripMenuItem.Enabled = state
        End Select

        Return True
    End Function

#End Region

#Region " User Defined "

    Private Sub CreateBasicLayout()
        SolutionExplorer.MdiParent = Me
        SolutionExplorer.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        'PropertiesWindow.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
    End Sub

    Private Function ReloadContent(ByVal persistString As String) As IDockContent

        Select Case persistString

            Case "frmDocument"
                Return Nothing

            Case "frmSolution"
                Me.SolutionExplorer = New frmSolution(Me)
                Return SolutionExplorer
        End Select

        Return Nothing

    End Function

#End Region

#Region " Windowing "

    Private Sub OpenFormStartPage()
        ' Create a Start Page
        Me.FormStartPage = New frmStartPage()
        Me.FormStartPage.MdiParent = Me
        Me.FormStartPage.TabText = "Start Page"
        Me.FormStartPage.Text = FormStartPage.TabText
        Me.FormStartPage.Show(DockPanel)
    End Sub

    Private Function ShowTransbrowserCaseStudiesForm() As Boolean
    End Function

    Private Function ShowTransbrowserContentsForm() As Boolean
    End Function

    Private Function ShowTransbrowserIndexForm() As Boolean
    End Function

    Private Function ShowTransbrowserSearchForm() As Boolean
    End Function

    Private Function ShowTransbrowserAboutForm() As Boolean
        Dim fAbout As Translib.frmAbout = New Translib.frmAbout()
        fAbout.SetBrowserVersion(Application.ProductVersion)
        fAbout.ShowInTaskbar = False
        fAbout.StartPosition = FormStartPosition.CenterParent
        fAbout.ShowDialog(Me)
    End Function

#End Region

#Region " Assembly Loader "

    Private Sub SetLocalConnectionFromAutoConfig()
        Dim wconn As Translib.WebConnection = New Translib.WebConnection(Me.WebserviceAddress)
        Dim objWebResult As Translib.WebResultObject
        Dim str_result As String = ""
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim parsed As Boolean = False
        Dim service = "autoconfig.php"


        Try

            Me.fLoading.SetMessage("Loading Auto Configuration..." & vbCrLf & Me.WebserviceAddress & "/" & service)


            str_result = wconn.post("autoconfig.php")
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(str_result, GetType(Translib.WebResultObject)), Translib.WebResultObject)

            parsed = True
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error")
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error")
            If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0")
            obj = CType(objWebResult.data(0), Newtonsoft.Json.JavaScriptObject)

            Me.LocalDSNFormat = obj("LocalDSNFormat")
            Me.LocalDbUsername = obj("LocalDbUsername")
            Me.LocalDbPassword = obj("LocalDbPassword")
            Me.LocalDbServer = obj("LocalDbServer")
            Me.LocalDbname = obj("LocalDbname")

        Catch ex As Exception
            If Not parsed Then
                Throw New Exception("Error while loading autoconfiguration" & vbCrLf & Me.WebserviceAddress & "/" & service & vbCrLf & Mid(ex.Message & vbCrLf & vbCrLf & str_result, 1, 1000))
            Else
                Throw New Exception("Error while loading autoconfiguration" & vbCrLf & Me.WebserviceAddress & "/" & service & vbCrLf & Trim(ex.Message))
            End If
        End Try

    End Sub

    Private Sub OpenNewForm_OpenLoadingIndicator(ByVal objProgram As Translib.SolutionProgram)

        Me.Cursor = Cursors.WaitCursor

        If objProgram.SingleInstance Then
            Dim i As Integer
            Dim mdiChild As frmProgram

            For i = 0 To Me.MdiChildren.Length - 1
                If Me.MdiChildren(i).Name <> "frmStartPage" And Me.MdiChildren(i).Name <> "frmSolution" Then
                    mdiChild = CType(Me.MdiChildren(i), frmProgram)
                    If mdiChild.ProgramId = objProgram.Id Then
                        Me.MdiChildren(i).Activate()
                        Exit Sub
                    End If
                End If
            Next
        End If


        Me.fLoading.StartPosition = FormStartPosition.CenterScreen
        Me.fLoading.ShowInTaskbar = False
        Me.fLoading.TopLevel = True
        Me.fLoading.SetStatus("Loading...")
        Me.fLoading.SetMessage("starting " & objProgram.Title & " ...")
        Me.fLoading.Show(Me)
    End Sub

    Private Sub OpenNewForm_LoadAssembly(ByVal objProgram As Translib.SolutionProgram)
        Dim OAsm As System.Reflection.Assembly = Nothing
        Dim dllFile As String = Me.DllServer & "/" & objProgram.Dll & "?t=" & Now.Ticks
        Dim downloadmessage As String = ""

        If objProgram.isLocalDll Then
            Dim IsHTTPStyle As Boolean
            If UCase(Mid(Me.LocalDllLocation, 1, 7)) = "HTTP://" Then
                IsHTTPStyle = True
                dllFile = Me.LocalDllLocation & "/" & objProgram.Dll & "?t=" & Now.Ticks
            Else
                dllFile = Me.LocalDllLocation & "\" & objProgram.Dll
            End If
            downloadmessage = "Downloading local module "
        Else
            downloadmessage = "Downloading enterprise module "
        End If

        Dim site As System.Security.Policy.Site = System.Security.Policy.Site.CreateFromUrl(dllFile)
        AppDomain.CurrentDomain.Evidence.AddHost(site)

        If Me.HtAssembly(objProgram.Ns) Is Nothing Then
            ' Load Assembly
            Try
                Me.fLoading.SetMessage(downloadmessage & objProgram.Dll & "..." & vbCrLf & dllFile)



                OAsm = System.Reflection.Assembly.LoadFrom(dllFile, AppDomain.CurrentDomain.Evidence)


                Me.HtAssembly.Add(objProgram.Ns, OAsm)
                Me.LoadedModules.Add(objProgram.Dll & ", " & OAsm.ImageRuntimeVersion & ", " & OAsm.CodeBase & ", " & OAsm.Location & ", " & OAsm.ToString, objProgram.Dll)
            Catch ex As Exception

                Throw New Exception("Cannot Load " & objProgram.Dll & vbCrLf & ex.Message & vbCrLf & "frmMain.OpenNewForm_LoadAssembly()")
            End Try
        Else
            If Me.ReloadModuleEveryProgram Or objProgram.Reload Then
                Dim cachefile As String = Me.HtAssembly(objProgram.Ns).Location
                Me.HtAssembly.Remove(objProgram.Ns)
                Me.LoadedModules.Remove(objProgram.Dll)
                Me.fLoading.SetMessage("re-downloading " & objProgram.Dll & "...")
                DeleteUrlCacheEntry(cachefile)
                OAsm = System.Reflection.Assembly.LoadFrom(dllFile, AppDomain.CurrentDomain.Evidence)
                Me.HtAssembly.Add(objProgram.Ns, OAsm)
                Me.LoadedModules.Add(objProgram.Dll & ", " & OAsm.ImageRuntimeVersion & ", " & OAsm.CodeBase & ", " & OAsm.Location & ", " & OAsm.ToString, objProgram.Dll)
            End If
        End If
    End Sub

    Private Sub OpenNewForm_Show(ByVal objProgram As Translib.SolutionProgram)
        Dim ChildForm As frmProgram
        Dim IconImage As System.Drawing.Bitmap
        Dim OAsm As System.Reflection.Assembly = Nothing
        Dim OCtl As Object = Nothing
        'Dim objParameters As Collection = New Collection
        Dim WindowParameter As String = objProgram.Parameter & "; " & Me.UserParameter
        Dim dsnstatus As String = ""

        ChildForm = New frmProgram(objProgram)
        ChildForm.MdiParent = Me
        ChildForm.TabText = objProgram.Title
        ChildForm.Text = objProgram.Title
        IconImage = ObjImageList.Images(objProgram.Icon)
        ChildForm.Icon = System.Drawing.Icon.FromHandle(IconImage.GetHicon)


        If objProgram.SingleInstance Then
            Dim i As Integer
            Dim mdiChild As frmProgram

            For i = 0 To Me.MdiChildren.Length - 1
                If Me.MdiChildren(i).Name <> "frmStartPage" And Me.MdiChildren(i).Name <> "frmSolution" Then
                    mdiChild = CType(Me.MdiChildren(i), frmProgram)
                    If mdiChild.ProgramId = objProgram.Id Then
                        Exit Sub
                    End If
                End If
            Next
        End If

        Try
            Dim objNS As Object = HtAssembly(objProgram.Ns)

            OAsm = CType(objNS, System.Reflection.Assembly)
            OCtl = OAsm.CreateInstance(objProgram.Instance)
            OCtl.Name = "MainControl"
            OCtl.Dock = DockStyle.Fill
            OCtl.BorderStyle = Windows.Forms.BorderStyle.None

            ' Cek Versi OCtl, kalau versi lama, pakai DSN
            Try
                Dim version As String = OCtl.VersionNumber
            Catch ex As Exception
                ChildForm.Dispose()
                ChildForm = Nothing
                Me.OpenNewForm24_Show(objProgram, OCtl, IconImage, WindowParameter)
                Exit Sub
            End Try

            OCtl.SetProgram(objProgram)
            OCtl.Title = objProgram.Title
            If Not OCtl.InitializeControl(Me.SessionID, Me.UserName, Me.WebserviceAddress, Me.DllServer, Me, OAsm) Then
                Throw New Exception(OCtl.StartupMessage)
            End If

            If objProgram.SingleInstance Then
                ChildForm.ProgramId = objProgram.Id
            Else
                ChildForm.ProgramId = objProgram.Id & "-" & CStr(Now.Ticks)
            End If


            If objProgram.isLocalDb Then
                Dim DSN As String = ""

                If Me.LocalDbConfigtype = "auto" Then
                    Me.SetLocalConnectionFromAutoConfig()
                End If
                DSN = String.Format(Me.LocalDSNFormat, Me.LocalDbUsername, Me.LocalDbPassword, Me.LocalDbServer, Me.LocalDbname)
                OCtl.SetDSNLocal(DSN)
                dsnstatus = " :: " & Me.DSNToDbConnectionStatus(DSN) & " :: "
                ChildForm.Text = ChildForm.Text
            Else
                OCtl.SetDSNLocal("DSN is blank because of objProgram.isLocalDb is disabled")
            End If

            ChildForm.Controls.Clear()
            ChildForm.Show(DockPanel)
            ChildForm.Tag = "Transbrowser"
            ChildForm.SuspendLayout()
            ChildForm.Controls.Add(OCtl)
            ChildForm.ResumeLayout()
            ChildForm.SetBrowser(Me)
            ChildForm.SyncronizeControlEnableState()

            Me.Text = ChildForm.Text & " - Transbrowser" & dsnstatus

        Catch ex As Exception
            Try
                ChildForm.Dispose()
                ChildForm = Nothing
                Throw New Exception("Cannot Open " & objProgram.Dll & vbCrLf & ex.Message & vbCrLf & "frmMain.OpenNewForm_Show()")
            Catch exs As Exception
                Throw New Exception("Cannot Open " & objProgram.Dll & vbCrLf & ex.Message & vbCrLf & "frmMain.OpenNewForm_Show()")
            End Try
        End Try
    End Sub

    Private Sub OpenNewForm24_Show(ByVal objProgram As Translib.SolutionProgram, ByVal OCtl As Object, ByVal IconImage As System.Drawing.Bitmap, ByVal WindowParameter As String)
        Dim ChildForm As frmProgram = New frmProgram(objProgram)
        Dim DSN As String = ""
        'Dim DSNString As String = "User ID=sa; Password=rahasia; Data Source=""localhost\SQLEXPRESS""; Initial Catalog=E_FRM2_MGP_WHJKT; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"
        Dim dsntempformat = "User ID={0}; Password={1}; Data Source=""{2}""; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"

        If Me.LocalDbConfigtype = "auto" Then
            Me.SetLocalConnectionFromAutoConfig()
        End If

        If Me.LocalDSNFormat = "" Then
            Me.LocalDSNFormat = dsntempformat
        End If
        DSN = String.Format(Me.LocalDSNFormat, Me.LocalDbUsername, Me.LocalDbPassword, Me.LocalDbServer, Me.LocalDbname)


        'Cek Database Connection
        Me.fLoading.SetMessage("Checking connection to Local Database Server..." & vbCrLf & Me.LocalDbUsername & ":" & Me.LocalDbname & "@" & Me.LocalDbServer & vbCrLf & vbCrLf)
        Try
            Dim dbConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(DSN)
            dbConn.Open()
            dbConn.Close()
            dbConn.Dispose()
        Catch ex As Exception
            Throw New Exception("Cannot establish local database connection" & vbCrLf & Me.LocalDbUsername & ":" & Me.LocalDbname & "@" & Me.LocalDbServer & vbCrLf & "LocalDbConfigtype: " & Me.LocalDbConfigtype & vbCrLf & ex.Message & vbCrLf & DSN)
            Exit Sub
        End Try

        ChildForm.MdiParent = Me
        ChildForm.TabText = objProgram.Title
        ChildForm.Text = objProgram.Title
        ChildForm.Icon = System.Drawing.Icon.FromHandle(IconImage.GetHicon)

        Try
            OCtl.InitializeControl(DSN, Me.UserName, WindowParameter, Me.LocalDllLocation, Me.WebserviceAddress, Me)
            OCtl.Dock = DockStyle.Fill
            OCtl.BorderStyle = Windows.Forms.BorderStyle.None
            ChildForm.Controls.Clear()
            ChildForm.Controls.Add(OCtl)
            ChildForm.Show(DockPanel)
        Catch ex As Exception
            ChildForm.Dispose()
            ChildForm = Nothing
            Throw New Exception("Cannot Open " & objProgram.Dll & vbCrLf & ex.Message & vbCrLf & "frmMain.OpenNewForm24_Show()")
        End Try

    End Sub


    Private Sub bgwAssemblyLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwAssemblyLoader.DoWork
        Me.AssemblyLoadStatus = EAssemblyLoadStatus.Progress
        Try
            If Me.InvokeRequired Then
                ' It's on a different thread, so use Invoke.
                Dim d As New OpenNewFormFunction(AddressOf OpenNewForm_OpenLoadingIndicator)
                Me.Invoke(d, New Object() {e.Argument})
            End If

            System.Threading.Thread.Sleep(100)

            If Me.InvokeRequired Then
                ' It's on a different thread, so use Invoke.
                Dim d As New OpenNewFormFunction(AddressOf OpenNewForm_LoadAssembly)
                Me.Invoke(d, New Object() {e.Argument})
            End If

            System.Threading.Thread.Sleep(100)

            If Me.InvokeRequired Then
                ' It's on a different thread, so use Invoke.
                Dim d As New OpenNewFormFunction(AddressOf OpenNewForm_Show)
                Me.Invoke(d, New Object() {e.Argument})
            End If

            System.Threading.Thread.Sleep(100)


            Me.AssemblyLoadStatus = EAssemblyLoadStatus.Done

        Catch ex As Exception
            Me.AssemblyLoadStatus = EAssemblyLoadStatus.Fail
            Me.AssemblyLoadMessage = ex.Message
        End Try



    End Sub

    Private Sub bgwAssemblyLoader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwAssemblyLoader.ProgressChanged

    End Sub

    Private Sub bgwAssemblyLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwAssemblyLoader.RunWorkerCompleted
        Me.fLoading.Hide()
        Me.Cursor = Cursors.Arrow

        Select Case Me.AssemblyLoadStatus
            Case EAssemblyLoadStatus.Done
            Case EAssemblyLoadStatus.Fail
                MessageBox.Show(Me.AssemblyLoadMessage, "Transbrowser", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub



#End Region

#Region " TransBrowser24 Compatibility "

    Public Function IsDataTableCached(ByVal procedure As String, ByVal criteria As String) As Boolean
        Return False
    End Function

    Public Function RefreshCachedDataTable(ByVal procedure As String, ByVal criteria As String) As Boolean
        Return True
    End Function

#End Region

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.ExitThread()
        Application.Exit()
    End Sub



    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim rptViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Dim configFile As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Transbrowser.config")
        Dim secur As System.Security.Permissions.SecurityPermission = New System.Security.Permissions.SecurityPermission(Security.Permissions.PermissionState.Unrestricted)


        Me.SolutionExplorer = New frmSolution(Me)


        ' Apply a gray professional renderer as a default renderer
        ToolStripManager.Renderer = oDefaultRenderer
        oDefaultRenderer.RoundedEdges = False

        ' Set DockPanel properties
        DockPanel.ActiveAutoHideContent = Nothing
        DockPanel.Parent = Me
        DockPanel.AllowRedocking = False

        VS2005Style.Extender.SetSchema(DockPanel, VS2005Style.Extender.Schema.FromBase)

        DockPanel.SuspendLayout(True)
        If System.IO.File.Exists(configFile) Then
            DockPanel.LoadFromXml(configFile, AddressOf ReloadContent)
        Else
            ' Load a basic layout
            CreateBasicLayout()
        End If
        DockPanel.ResumeLayout(True, True)


        Me.OpenFormStartPage()
        If Me.SolutionExplorer.DockState = DockState.Hidden Then
            SolutionExplorerToolStripMenuItem.Checked = False
        Else
            SolutionExplorerToolStripMenuItem.Checked = True
        End If



        Me.WindowState = FormWindowState.Maximized
        Me.bgwAssemblyLoader.WorkerReportsProgress = True


        rptViewer.RefreshReport()

        Me.BringToFront()
        Me.Activate()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim configFile As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Transbrowser.config")
        DockPanel.SaveAsXml(configFile)

        Do While DockPanel.Contents.Count > 0
            Dim dc As DockContent = DockPanel.Contents(0)
            dc.Close()
        Loop

        Application.ExitThread()

    End Sub


    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

    End Sub

    Private Sub SolutionExplorerToolStripMenuItem_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SolutionExplorerToolStripMenuItem.Click
        If SolutionExplorerToolStripMenuItem.Checked Then
            Me.SolutionExplorer.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        Else
            Me.SolutionExplorer.Hide()
        End If
    End Sub

    Private Sub StartPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartPageToolStripMenuItem.Click
        Dim i As Integer
        Dim start_page_is_already_open As Boolean

        For i = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Name = "frmStartPage" Then
                start_page_is_already_open = True
                Me.MdiChildren(i).Activate()
                Exit For
            End If
        Next

        If Not start_page_is_already_open Then
            Me.OpenFormStartPage()
            If Me.UserName <> "" Then
                Me.FormStartPage.pnlLogin.Visible = False
                'Me.FormStartPage.PanelWelcome.Top = Me.FormStartPage.pnlLogin.Top
                'Me.FormStartPage.PanelWelcome.Left = Me.FormStartPage.pnlLogin.Left
                'Me.FormStartPage.PanelWelcome.Visible = True
                'Me.FormStartPage.PanelWelcome.Dock = DockStyle.Fill
                'Me.FormStartPage.wbStartup.Url = New System.Uri(String.Format("{0}/welcomepage.php?transbrowser=1&SESSID={1}", Me.WebserviceAddress, Me.txtSessionID.Text))
            End If
        End If

    End Sub

    Private Sub PreferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferenceToolStripMenuItem.Click
        Dim f As frmPreference = New frmPreference
        f.Text = "Preference"
        f.ShowInTaskbar = False
        f.StartPosition = FormStartPosition.CenterParent
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        f.ShowDialog(Me)
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        Dim i As Integer
        Dim start_page_is_already_open As Boolean

        For i = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).Name = "frmStartPage" Then
                start_page_is_already_open = True
                Me.MdiChildren(i).Activate()
                Exit For
            End If
        Next

        If Not start_page_is_already_open Then
            Me.OpenFormStartPage()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim i As Integer
        Dim wndName As String
        Dim wndCol As Collection = New Collection
        Dim fPrg As frmProgram
        Dim fSPage As frmStartPage
        Dim n As Int16
        Dim SolutionPageOpen As Boolean = False
        Dim Logout As Boolean

        n = MdiChildren.Length

        For i = 0 To n - 1
            wndName = "Form_" & i
            wndCol.Add(Me.MdiChildren(i), wndName)
        Next

        'Tutup semua
        For i = 0 To wndCol.Count - 1
            wndName = "Form_" & i
            If wndCol(wndName).GetType() Is GetType(frmProgram) Then
                fPrg = wndCol(wndName)
                fPrg.Close()
                fPrg = Nothing
            ElseIf wndCol(wndName).GetType() Is GetType(frmStartPage) Then
                fSPage = wndCol(wndName)
                fSPage.Close()
                fSPage = Nothing
            Else
                SolutionPageOpen = True
            End If
        Next

        wndCol = Nothing

        If SolutionPageOpen Then
            'disisain satu
            If Me.MdiChildren.Length > 1 Then
                Logout = False
            Else
                Logout = True
            End If

        Else
            'dihabisin
            If Me.MdiChildren.Length > 0 Then
                Logout = False
            Else
                Logout = True
            End If
        End If

        If Logout Then
            Me.UserName = ""
            Me.SolutionExplorer.Logout()
            Me.LogoutToolStripMenuItem.Visible = False
            Me.LoginToolStripMenuItem.Visible = True
            Me.ChangePasswordToolStripMenuItem.Enabled = False


            Me.txtStatusUsername.Visible = False
            Me.txtStatusUsername.Text = ""
            Me.txtStatusDatabasename.Visible = False
            Me.txtStatusDatabasename.Text = ""
            Me.txtSessionID.Visible = False
            Me.txtSessionID.Text = ""


            Me.StartPageToolStripMenuItem_Click(sender, e)

        End If

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim fPassword As frmPassword = New frmPassword
        fPassword.UserName = Me.UserName
        fPassword.SessionID = Me.SessionID
        fPassword.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        fPassword.ShowInTaskbar = False
        fPassword.StartPosition = FormStartPosition.CenterParent
        fPassword.ShowDialog(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LoadedModuleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadedModuleToolStripMenuItem.Click
        Dim frm As frmLoadedModules = New frmLoadedModules()
        Dim txt As String = ""
        Dim i As Integer

        For i = 1 To Me.LoadedModules.Count
            txt &= Me.LoadedModules(i) & vbCrLf
        Next

        frm.SetContent(txt)
        frm.ShowInTaskbar = False
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog(Me)

    End Sub

    Private Sub DockPanel_ContentRemoved(ByVal sender As Object, ByVal e As WeifenLuo.WinFormsUI.DockContentEventArgs) Handles DockPanel.ContentRemoved
        Dim dp As DockContent = e.Content
        dp.Dispose()
    End Sub

    Private Sub DockPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DockPanel.Paint

    End Sub
End Class
