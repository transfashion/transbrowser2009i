Public Class frmStartPage

    Public Enum LoginStatus
        Init = 1
        Progress = 2
        Success = 3
        Fail = 4
    End Enum


    Private mFormMain As frmMain
    Private mStatus As LoginStatus
    Private mMessage As String
    Private mProgress As Integer

    Private iniFile As String = System.Windows.Forms.Application.StartupPath & "\TransBrowser.ini"

    Friend WithEvents bgwLogin As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker



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



#Region " Properties "

    Public Property Status() As LoginStatus
        Get
            Return mStatus
        End Get
        Set(ByVal value As LoginStatus)
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

#End Region


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Baca user yang login terakhir
        Dim rememberme As String = Me.INIRead(iniFile, "LogOn", "rememberme")
        Dim username As String = Me.INIRead(iniFile, "LogOn", "username")
        Dim userpassword As String = Me.INIRead(iniFile, "LogOn", "userpassword")

        If UCase(rememberme) = "TRUE" Then
            Me.chkRemember.Checked = True
        End If

        Me.txtUserName.Text = username
        Me.txtPassword.Text = userpassword

        If Me.txtUserName.Text <> "" And Me.txtPassword.Text <> "" Then
            Me.btnLogin.Focus()
        End If

    End Sub


    Private Sub frmStartPage_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.mFormMain.BringToFront()
    End Sub



    Private Sub frmStartPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.mFormMain = Me.MdiParent
        Me.lblVersion.Text = Application.ProductVersion.ToString
        Me.lblLoginMessage.Text = ""

        Me.bgwLogin.WorkerReportsProgress = True
        Me.bgwLogin.WorkerSupportsCancellation = True
    End Sub

    Private Sub frmStartPage_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.mFormMain.SolutionProgramSelected()
    End Sub





    Private Sub bgwLogin_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwLogin.DoWork
        Dim wconn As Translib.WebConnection = New Translib.WebConnection(Me.mFormMain.WebserviceAddress)
        Dim objWebResult As Translib.WebResultObject
        Dim str_result As String = ""
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim username, user_fullname, parameter, database, session_id As String
        Dim parsed As Boolean = False

        Me.Status = LoginStatus.Progress
        Me.ReportProgress(1, "Wait...")
        System.Threading.Thread.Sleep(500)

        Me.ReportProgress(2, "Login to system")
        System.Threading.Thread.Sleep(500)

        Me.ReportProgress(2, "Connecting to " & Me.mFormMain.WebserviceAddress)
        System.Threading.Thread.Sleep(500)

        wconn.addtext("username", Me.txtUserName.Text)
        wconn.addtext("password", Me.txtPassword.Text)

        Try
            str_result = wconn.post("login.php")
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(str_result, GetType(Translib.WebResultObject)), Translib.WebResultObject)

            parsed = True
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error")
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error")
            If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0")
            obj = CType(objWebResult.data(0), Newtonsoft.Json.JavaScriptObject)

            username = obj("username")
            user_fullname = obj("user_fullname")
            parameter = obj("parameter")
            database = obj("database")
            session_id = obj("session_id")
            wconn.SessionID = database

            Me.mFormMain.SetUser(username, user_fullname, parameter)
            Me.mFormMain.SetSession(session_id, database)

            Me.Status = LoginStatus.Success
            Me.ReportProgress(100, "")


            'Tulis ke INI File Configurasi
            If Me.chkRemember.Checked Then
                Me.INIWrite(iniFile, "LogOn", "rememberme", "TRUE")
                Me.INIWrite(iniFile, "LogOn", "username", Me.txtUserName.Text)
                Me.INIWrite(iniFile, "LogOn", "userpassword", Me.txtPassword.Text)

            End If


        Catch ex As Exception
            System.Threading.Thread.Sleep(100)
            Me.Status = LoginStatus.Fail
            If Not parsed Then
                Me.ReportProgress(2, Mid(str_result, 1, 1000))
            Else
                Me.ReportProgress(2, ex.Message)
            End If

        End Try
    End Sub

    Private Sub bgwLogin_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwLogin.ProgressChanged

        Me.imgStatus.Visible = False
        Select Case Me.Status
            Case LoginStatus.Progress
                Me.imgStatus.Visible = True
                Me.imgStatus.Image = Me.imgWait.Image
            Case LoginStatus.Fail
                Me.imgStatus.Visible = True
                Me.imgStatus.Image = Me.imgError.Image
        End Select

        Me.lblLoginMessage.Text = Me.Message



    End Sub

    Private Sub bgwLogin_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwLogin.RunWorkerCompleted

        Me.btnLogin.Enabled = True
        Me.txtUserName.Enabled = True
        Me.txtPassword.Enabled = True

        Me.mFormMain.Cursor = Cursors.Arrow

        If Me.Status = LoginStatus.Fail Then
            MessageBox.Show(Me.Message, "Transbrowser - Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Me.imgStatus.Visible = False


            Me.SuspendLayout()
            Me.PnlWelcome.Top = Me.pnlLogin.Top
            Me.PnlWelcome.Left = Me.pnlLogin.Left
            Me.PnlWelcome.Height = Me.pnlLogin.Height
            Me.PnlWelcome.Width = Me.pnlLogin.Width
            Me.pnlLogin.Visible = False
            Me.PnlWelcome.Visible = True
            Me.Label3.Text = Me.mFormMain.txtStatusUsername.Text
            Me.Label3.AutoSize = True



            Me.lblLoginMessage.Text = ""
            Me.mFormMain.LogoutToolStripMenuItem.Visible = True
            Me.mFormMain.LoginToolStripMenuItem.Visible = False
            Me.mFormMain.ChangePasswordToolStripMenuItem.Enabled = True

            ' Set First Group
            Me.lblLoginMessage.Text = "Set First Group"
            Me.mFormMain.SetFirstGroup()

            Me.ResumeLayout()
        End If

  

    End Sub


    Public Function ReportProgress(ByVal percent As Integer, Optional ByVal msg As String = "") As Boolean
        If Me.bgwLogin.CancellationPending Then
            Me.Status = LoginStatus.Fail
            System.Threading.Thread.CurrentThread.Abort()
        Else
            If msg <> "" Then
                Me.Message = msg
            End If
            Me.Progress = percent
            Me.bgwLogin.ReportProgress(percent)
        End If
    End Function





    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        ' Login ke System
        Me.mFormMain.Cursor = Cursors.WaitCursor
        Me.btnLogin.Enabled = False
        Me.txtUserName.Enabled = False
        Me.txtPassword.Enabled = False
        Me.imgStatus.Visible = True
        Me.Status = LoginStatus.Init

        If Not Me.chkRemember.Checked Then
            Me.INIWrite(iniFile, "LogOn", "rememberme", "FALSE")
            Me.INIWrite(iniFile, "LogOn", "username", "")
            Me.INIWrite(iniFile, "LogOn", "userpassword", "")
        End If

        Me.bgwLogin.RunWorkerAsync()
    End Sub







    Private Sub UserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar()) = 13 Then
            Me.txtPassword.Focus()
        End If
    End Sub


    Private Sub Password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar()) = 13 Then
            Me.btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub Password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        Me.txtPassword.SelectAll()
    End Sub






End Class
