Public Class MasterDataLoaderQueue
    Dim colTables As Collection = New Collection()


#Region " Property "

    Public ReadOnly Property Tables() As Collection
        Get
            Return colTables
        End Get
    End Property

    Public ReadOnly Property Tables(ByVal i As Integer) As DataDetilBindingTable
        Get
            Return CType(colTables(i), DataDetilBindingTable)
        End Get
    End Property

    Public ReadOnly Property Tables(ByVal key As String) As DataDetilBindingTable
        Get
            Return CType(colTables(key), DataDetilBindingTable)
        End Get
    End Property

#End Region


    Public Sub New()
        Me.colTables.Clear()
    End Sub


    Public Function Add(ByVal name As String, ByVal DataTableName As String, ByVal WebService As String, ByVal criteria As String) As Boolean
        Dim obj As MasterDataLoader = New MasterDataLoader(name, DataTableName, WebService, criteria)
        Me.colTables.Add(obj, name)
    End Function



End Class





Public Class MasterDataLoader
    Private mName As String
    Private mDataTableName As String
    Private mWebService As String
    Private mCriteria As String


#Region " Property "

    Public ReadOnly Property Name() As String
        Get
            Return mName
        End Get
    End Property

    Public Property DataTableName() As String
        Get
            Return mDataTableName
        End Get
        Set(ByVal value As String)
            mDataTableName = value
        End Set
    End Property

    Public Property WebService() As String
        Get
            Return mWebService
        End Get
        Set(ByVal value As String)
            mWebService = value
        End Set
    End Property

    Public Property Criteria() As String
        Get
            Return mCriteria
        End Get
        Set(ByVal value As String)
            mCriteria = value
        End Set
    End Property

#End Region



    Public Sub New(ByVal name As String, ByVal DataTableName As String, ByVal WebService As String, ByVal criteria As String)
        mName = name
        mDataTableName = DataTableName
        mWebService = WebService
        mCriteria = criteria
    End Sub

End Class