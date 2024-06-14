Public Class CachedTable

    Private mTableName As String
    Private mProcedure As String
    Private mCriteria As String
    Private mDataTable As System.Data.DataTable = New System.Data.DataTable()

    Public Property TableName() As String
        Get
            Return mTableName
        End Get
        Set(ByVal value As String)
            mTableName = value
        End Set
    End Property

    Public Property Procedure()
        Get
            Return mProcedure
        End Get
        Set(ByVal value)
            mProcedure = value
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

    Public Property [DataTable]() As System.Data.DataTable
        Get
            Return mDataTable
        End Get
        Set(ByVal value As System.Data.DataTable)
            mDataTable = value
        End Set
    End Property

    Public Sub New(ByVal tablename As String, ByVal procedure As String, ByVal criteria As String)
        mTableName = tablename
        mProcedure = procedure
        mCriteria = criteria
    End Sub

End Class
