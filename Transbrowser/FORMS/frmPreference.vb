Public Class frmPreference

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

    Private LogOnType As String




    Private Sub frmPreference_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Baca INI File
        'Server
        Dim iniFile As String = Application.StartupPath & "\TransBrowser.ini"
        Dim DllServer As String = Me.INIRead(iniFile, "ApplicationServer", "dll_server")
        Dim WebserviceAddress As String = Me.INIRead(iniFile, "ApplicationServer", "WebserviceAddress")
        Dim ReloadModuleEveryProgram As String = Me.INIRead(iniFile, "ApplicationServer", "ReloadModuleEveryProgram")

        ' Local
        Dim LocalDllLocation As String = Me.INIRead(iniFile, "Local", "dll_location")
        Dim LocalDbConfigtype As String = Me.INIRead(iniFile, "Local", "db_configtype")
        Dim LocalDbServer As String = Me.INIRead(iniFile, "Local", "db_server")
        Dim LocalDbUsername As String = Me.INIRead(iniFile, "Local", "db_user")
        Dim LocalDbPassword As String = Me.INIRead(iniFile, "Local", "db_password")
        Dim LocalDbname As String = Me.INIRead(iniFile, "Local", "db_name")
        Dim LocalDSNFormat As String = Me.INIRead(iniFile, "Local", "DSNFormat")


        ' Server
        Me.txtAsDll.Text = DllServer
        Me.txtWebserviceAddress.Text = WebserviceAddress
        If ReloadModuleEveryProgram = "True" Then Me.chkReloadModuleEveryProgram.Checked = True

        ' Local
        Me.txtLocalDll.Text = LocalDllLocation
        Me.txtDsDatabaseName.Text = LocalDbname
        Me.txtDsDSNFormat.Text = LocalDSNFormat
        Me.txtDsPassword.Text = LocalDbPassword
        Me.txtDsServerName.Text = LocalDbServer
        Me.txtDsUsername.Text = LocalDbUsername


        If LocalDbConfigtype = "manual" Then
            Me.rdoAuto.Checked = False
            Me.rdoManual.Checked = True
        Else
            Me.rdoAuto.Checked = True
            Me.rdoManual.Checked = False
        End If


    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub rdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAuto.CheckedChanged, rdoManual.CheckedChanged
        If Me.rdoAuto.Checked Then

            Me.txtDsServerName.ReadOnly = True
            Me.txtDsDatabaseName.ReadOnly = True
            Me.txtDsUsername.ReadOnly = True
            Me.txtDsPassword.ReadOnly = True

            Me.txtDsServerName.BackColor = Color.Gainsboro
            Me.txtDsDatabaseName.BackColor = Color.Gainsboro
            Me.txtDsUsername.BackColor = Color.Gainsboro
            Me.txtDsPassword.BackColor = Color.Gainsboro

            Me.txtDsServerName.ForeColor = Color.DarkGray
            Me.txtDsDatabaseName.ForeColor = Color.DarkGray
            Me.txtDsUsername.ForeColor = Color.DarkGray
            Me.txtDsPassword.ForeColor = Color.DarkGray


        Else

            Me.txtDsServerName.ReadOnly = False
            Me.txtDsDatabaseName.ReadOnly = False
            Me.txtDsUsername.ReadOnly = False
            Me.txtDsPassword.ReadOnly = False

            Me.txtDsServerName.BackColor = Color.White
            Me.txtDsDatabaseName.BackColor = Color.White
            Me.txtDsUsername.BackColor = Color.White
            Me.txtDsPassword.BackColor = Color.White

            Me.txtDsServerName.ForeColor = Color.Black
            Me.txtDsDatabaseName.ForeColor = Color.Black
            Me.txtDsUsername.ForeColor = Color.Black
            Me.txtDsPassword.ForeColor = Color.Black

        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Simpan ke ini file
        Dim iniFile As String = Application.StartupPath & "\TransBrowser.ini"
        Dim db_configtype As String
        Dim ReloadModuleEveryProgram As String = ""


        If Me.chkReloadModuleEveryProgram.Checked Then ReloadModuleEveryProgram = "True"
        Me.INIWrite(iniFile, "ApplicationServer", "dll_server", Me.txtAsDll.Text)
        Me.INIWrite(iniFile, "ApplicationServer", "WebserviceAddress", Me.txtWebserviceAddress.Text)
        Me.INIWrite(iniFile, "ApplicationServer", "ReloadModuleEveryProgram", ReloadModuleEveryProgram)


        If Me.rdoAuto.Checked Then
            db_configtype = "auto"
        Else
            db_configtype = "manual"
        End If


        Me.INIWrite(iniFile, "Local", "dll_location", Me.txtLocalDll.Text)
        Me.INIWrite(iniFile, "Local", "db_configtype", db_configtype)
        Me.INIWrite(iniFile, "Local", "db_server", Me.txtDsServerName.Text)
        Me.INIWrite(iniFile, "Local", "db_name", Me.txtDsDatabaseName.Text)
        Me.INIWrite(iniFile, "Local", "db_user", Me.txtDsUsername.Text)
        Me.INIWrite(iniFile, "Local", "db_password", Me.txtDsPassword.Text)
        Me.INIWrite(iniFile, "Local", "DSNFormat", Me.txtDsDSNFormat.Text)



        MessageBox.Show("This changes will take effect after you restart the application", "TransBrowser", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

  
End Class