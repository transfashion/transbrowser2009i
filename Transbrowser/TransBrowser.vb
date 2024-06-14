Public Class TransBrowser

    Public Shared DllServer As String
    Public Shared SptServer As String
    Public Shared DSN As String
    Public Shared DBCONFIGTYPE As String
    Public Shared DBSERVER As String
    Public Shared DBNAME As String
    Public Shared DBUSER As String
    Public Shared DBPASSWORD As String
    Public Shared LOGONTYPE As String
    Public Shared InstanceDirect As String
    Public Shared CachedTables As Collection = New Collection()


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

#Region " Service "

  

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
        Return INIRead(inipath, sectionname, KeyName, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String) As String
        ' overload 2 returns all keys in a given section of the given file
        Return INIRead(inipath, sectionname, Nothing, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String) As String
        ' overload 3 returns all section names given just path
        Return INIRead(inipath, Nothing, Nothing, "")
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
        Dim iniFile As String = Application.CommonAppDataPath & "\TransBrowser.ini"
        Dim dsnTemp As String = "User ID={0}; Password={1}; Data Source=""{2}""; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"
        Dim MyFile As New System.IO.FileInfo(iniFile)

        Try

            If Not MyFile.Exists() Then
                Throw New System.IO.FileNotFoundException
            End If

            DBCONFIGTYPE = Me.INIRead(iniFile, "DatabaseServer", "db_configtype")
            DBSERVER = Me.INIRead(iniFile, "DatabaseServer", "db_server")
            DBNAME = Me.INIRead(iniFile, "DatabaseServer", "db_name")
            DBUSER = Me.INIRead(iniFile, "DatabaseServer", "db_user")
            DBPASSWORD = Me.INIRead(iniFile, "DatabaseServer", "db_password")
            DllServer = Me.INIRead(iniFile, "ApplicationServer", "dll_server")
            SptServer = Me.INIRead(iniFile, "ApplicationServer", "spt_server")
            LOGONTYPE = Me.INIRead(iniFile, "LogOn", "LogOnType")

            dsnTemp = Me.INIRead(iniFile, "DatabaseServer", "DSNFormat")

            'Auto configuration, baca dari server
            Dim XmlFile As String
            Dim XmlConfig As Xml.XmlDataDocument = New Xml.XmlDataDocument

            Try
                XmlFile = SptServer & "/Solutions/" & "config.php"
                XmlConfig.Load(XmlFile)

                If XmlConfig.Item("TransBrowser").Item("Configurations").Item("Debug") IsNot Nothing Then
                    With XmlConfig.Item("TransBrowser").Item("Configurations").Item("Debug")
                        If .Item("InstanceDirect") IsNot Nothing Then
                            InstanceDirect = .Item("InstanceDirect").InnerText
                        End If
                    End With

                End If

                If DBCONFIGTYPE = "manual" Then
                Else
                    DBSERVER = XmlConfig.Item("TransBrowser").Item("Configurations").Item("Datastore").Item("Server").InnerText
                    DBNAME = XmlConfig.Item("TransBrowser").Item("Configurations").Item("Datastore").Item("Catalog").InnerText
                    DBUSER = XmlConfig.Item("TransBrowser").Item("Configurations").Item("Datastore").Item("UID").InnerText
                    DBPASSWORD = XmlConfig.Item("TransBrowser").Item("Configurations").Item("Datastore").Item("PWD").InnerText
                End If

            Catch ex As Exception
                Throw New Exception(ex.Message & vbCrLf & "Could not use auto configuration..." & vbCrLf & "Please switch Database Server preference to Manual, or correct the Start Point Address!")
            End Try

        Catch ex As System.IO.FileNotFoundException
            Me.INIWrite(iniFile, "DatabaseServer", "DSNFormat", dsnTemp)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transbrowser", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        DSN = String.Format(dsnTemp, DBUSER, DBPASSWORD, DBSERVER, DBNAME)

    End Sub

#End Region


    Public Shared Function GetListOfCachedTables() As Collection
        Dim XmlFile As String
        Dim XmlCachedTables As Xml.XmlDataDocument = New Xml.XmlDataDocument
        Dim i, n As Integer
        Dim TableName, Procedure, Criteria As String
        Dim objCachedTable As CachedTable
        Dim col As Collection = New Collection

        'Get Cache Tables
        Try
            XmlFile = SptServer & "/Solutions/" & "cachedtables.php"
            XmlCachedTables.Load(XmlFile)
            n = XmlCachedTables.Item("TransBrowser").Item("CachedTables").ChildNodes.Count
            For i = 0 To n - 1
                With XmlCachedTables.Item("TransBrowser").Item("CachedTables").ChildNodes(i)
                    TableName = .Item("Name").InnerText
                    Procedure = .Item("Procedure").InnerText
                    Criteria = .Item("Criteria").InnerText

                    objCachedTable = New CachedTable(TableName, Procedure, Criteria)
                    col.Add(objCachedTable, TableName)
                End With
            Next

        Catch ex As Exception
        End Try

        Return col

    End Function

    Public Shared Function LoadDataTable(ByRef objCachedTable As CachedTable) As Boolean
        Dim dbConn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(DSN)
        Dim dbCmd As System.Data.OleDb.OleDbCommand
        Dim dbDA As System.Data.OleDb.OleDbDataAdapter

        dbCmd = New System.Data.OleDb.OleDbCommand(objCachedTable.Procedure, dbConn)
        dbCmd.Parameters.Add("@Criteria", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = objCachedTable.Criteria

        dbCmd.CommandType = System.Data.CommandType.StoredProcedure
        dbDA = New System.Data.OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            objCachedTable.DataTable.Clear()
            dbDA.Fill(objCachedTable.DataTable)

            'masukkan ke cache
            'cek apabila sudah ada di cache, data di cache dihapus dulu
            If CachedTables.Contains(objCachedTable.Procedure) Then
                CachedTables.Remove(objCachedTable.Procedure)
            End If

            CachedTables.Add(objCachedTable, objCachedTable.Procedure)

        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function


    Public Function InitializeProgram() As Boolean
        Return True
    End Function




End Class
