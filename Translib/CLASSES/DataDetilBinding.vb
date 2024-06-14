Public Class DataDetilBinding
    Dim colTables As Collection = New Collection()
    Dim colTabIndex As Collection = New Collection()
    Dim colDgvIndex As Collection = New Collection()


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

    Public Function Add(ByVal name As String, ByRef table As DataTable, ByVal tabname As String, ByVal dgvname As String, ByVal [readonly] As Boolean, ByVal allowaddordeleterows As Boolean) As Boolean
        Dim obj As DataDetilBindingTable = New DataDetilBindingTable(name, table, tabname, dgvname, [readonly], allowaddordeleterows)
        Me.colTables.Add(obj, name)
        Me.colTabIndex.Add(name, tabname)
        Me.colDgvIndex.Add(name, dgvname)
    End Function


    Public Function GetTableByTabName(ByVal tabname As String) As DataDetilBindingTable
        Dim key As String
        If Me.colTabIndex.Contains(tabname) Then
            key = Me.colTabIndex(tabname)
            Return CType(colTables(key), DataDetilBindingTable)
        End If
        Return Nothing
    End Function

    Public Function GetTableByDgvName(ByVal dgvname As String) As DataDetilBindingTable
        Dim key As String
        If Me.colDgvIndex.Contains(dgvname) Then
            key = Me.colTabIndex(dgvname)
            Return CType(colTables(key), DataDetilBindingTable)
        End If
        Return Nothing
    End Function

End Class



Public Class DataDetilBindingTable
    Private mName As String
    Private mTable As DataTable
    Private mTabName As String
    Private mDgvName As String
    Private mReadonly As Boolean
    Private mAllowaddordeleterows As Boolean
    Private mAllowaddordeleterowsOrigin As Boolean

#Region " Property "

    Public ReadOnly Property Name() As String
        Get
            Return mName
        End Get
    End Property

    Public Property Table() As DataTable
        Get
            Return mTable
        End Get
        Set(ByVal value As DataTable)
            mTable = value
        End Set
    End Property

    Public Property TabName() As String
        Get
            Return mTabName
        End Get
        Set(ByVal value As String)
            mTabName = value
        End Set
    End Property

    Public Property DgvName() As String
        Get
            Return mDgvName
        End Get
        Set(ByVal value As String)
            mDgvName = value
        End Set
    End Property

    Public Property [Readonly]() As Boolean
        Get
            Return mReadonly
        End Get
        Set(ByVal value As Boolean)
            mReadonly = value
        End Set
    End Property

    Public Property AllowAddOrDeleteRows() As Boolean
        Get
            Return mAllowaddordeleterows
        End Get
        Set(ByVal value As Boolean)
            mAllowaddordeleterows = value
        End Set
    End Property

    Public Property AllowAddOrDeleteRowsOrigin() As Boolean
        Get
            Return mAllowaddordeleterowsOrigin
        End Get
        Set(ByVal value As Boolean)
            mAllowaddordeleterowsOrigin = value
        End Set
    End Property


#End Region



    Public Sub New(ByVal name As String, ByRef table As DataTable, ByVal tabname As String, ByVal dgvname As String, ByVal [readonly] As Boolean, ByVal allowaddordeleterows As Boolean)
        mName = name
        mTable = table
        mTabName = tabname
        mDgvName = dgvname
        mReadonly = [readonly]
        mAllowaddordeleterows = allowaddordeleterows
        mAllowaddordeleterowsOrigin = allowaddordeleterows
    End Sub

    Public Function SetReadonly(ByVal [readonly] As Boolean) As Boolean
        Me.mReadonly = [readonly]
    End Function

    Public Function SetAllowAddOrDeleteRows(ByVal [allow] As Boolean) As Boolean
        Me.mAllowaddordeleterows = [allow]
    End Function


End Class
