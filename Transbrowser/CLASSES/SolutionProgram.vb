
''' <summary>
''' Class Untuk Menampung daftar Program Solusi yang disimpan dalam file XML
''' </summary>
Public Class SolutionProgram

    Private m_Id As String
    Private m_Title As String
    Private m_Icon As String
    Private m_Ns As String
    Private m_Dll As String
    Private m_Instance As String
    Private m_Description As String
    Private m_Parameter As String
    Private m_Type As String
    Private m_SingleInstance As Boolean
    Private m_isLocalDll As Boolean
    Private m_isLocalDb As Boolean



#Region " Properties "

    Public ReadOnly Property Id() As String
        Get
            Return m_Id
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return m_Title
        End Get
    End Property

    Public ReadOnly Property Icon() As String
        Get
            Return m_Icon
        End Get
    End Property

    Public Property Ns() As String
        Get
            Return m_Ns
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public ReadOnly Property Dll() As String
        Get
            Return m_Dll
        End Get
    End Property

    Public ReadOnly Property Instance() As String
        Get
            Return m_Ns & "." & m_Instance
        End Get
    End Property

    Public ReadOnly Property FormName() As String
        Get
            Return m_Instance
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return m_Description
        End Get
    End Property

    Public ReadOnly Property Type() As String
        Get
            Return m_Type
        End Get
    End Property

    Public ReadOnly Property SingleInstance() As Boolean
        Get
            Return m_SingleInstance
        End Get
    End Property

    Public ReadOnly Property Parameter() As String
        Get
            Return m_Parameter
        End Get
    End Property

    Public ReadOnly Property isLocalDll() As Boolean
        Get
            Return m_isLocalDll
        End Get
    End Property

    Public ReadOnly Property isLocalDb() As Boolean
        Get
            Return m_isLocalDb
        End Get
    End Property


#End Region

#Region " Constructor "

    Sub New(ByVal Id As String, ByVal Title As String, ByVal Icon As String, ByVal Ns As String, ByVal Dll As String, ByVal Instance As String, ByVal Description As String, ByVal type As String, ByVal singleinstance As Boolean, ByVal parameter As String, ByVal isLocalDll As Boolean, ByVal isLocalDb As Boolean)
        m_Id = Id
        m_Title = Title
        m_Icon = Icon
        m_Ns = Ns
        m_Dll = Dll
        m_Instance = Instance
        m_Description = Description
        m_Type = type
        m_SingleInstance = singleinstance
        m_Parameter = parameter
        m_isLocalDll = isLocalDll
        m_isLocalDb = isLocalDb
    End Sub

#End Region


End Class
