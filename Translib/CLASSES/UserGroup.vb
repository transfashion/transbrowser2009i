
Public Class UserGroup

    Private m_Name As String
    Private m_Id As String
    Private m_Description As String


#Region " Properties "

    Public ReadOnly Property Name() As String
        Get
            Return m_Name
        End Get
    End Property

    Public ReadOnly Property Id() As String
        Get
            Return m_Id
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return m_Description
        End Get
    End Property

#End Region

#Region " Constructor "
    Public Sub New(ByVal Id As String, ByVal Name As String, ByVal Description As String)
        m_Id = Id
        m_Name = Name
        m_Description = Description
    End Sub
#End Region

  

End Class
