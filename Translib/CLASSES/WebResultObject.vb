Public Class WebResultObject

    Private mObjectName As String
    Private mTotalCount As Integer
    Private mSuccess As Boolean
    Private mErrors As WebResultErrorObject
    Private mData As ArrayList

    Public Property ObjectName() As String
        Get
            Return mObjectName
        End Get
        Set(ByVal value As String)
            mObjectName = value
        End Set
    End Property

    Public Property totalCount() As Integer
        Get
            Return mTotalCount
        End Get
        Set(ByVal value As Integer)
            mTotalCount = value
        End Set
    End Property

    Public Property success() As Boolean
        Get
            Return mSuccess
        End Get
        Set(ByVal value As Boolean)
            mSuccess = value
        End Set
    End Property

    Public Property errors() As WebResultErrorObject
        Get
            Return mErrors
        End Get
        Set(ByVal value As WebResultErrorObject)
            mErrors = value
        End Set
    End Property

    Public Property data() As ArrayList
        Get
            Return mData
        End Get
        Set(ByVal value As ArrayList)
            mData = value
        End Set
    End Property

End Class



Public Class WebResultErrorObject
    Private mErrorId As String
    Private mErrorMessage As String

    Public Property ErrorId() As String
        Get
            Return mErrorId
        End Get
        Set(ByVal value As String)
            mErrorId = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
        Set(ByVal value As String)
            mErrorMessage = value
        End Set
    End Property

End Class
