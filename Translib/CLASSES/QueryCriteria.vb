Public Class QueryCriteria
    Implements System.ICloneable


#Region " Kelas Pembantu Public "
    Public Class Criteria
        Private mName As String
        Private mChecked As Boolean
        Private mValue As String

        Public ReadOnly Property Name() As String
            Get
                Return mName
            End Get
        End Property

        Public ReadOnly Property Checked() As Boolean
            Get
                Return mChecked
            End Get
        End Property

        Public ReadOnly Property Value() As String
            Get
                Return mValue
            End Get
        End Property

        Public Sub New(ByVal name As String, ByVal checked As Boolean, ByVal value As String)
            mName = name
            mChecked = checked
            mValue = value
        End Sub

    End Class
#End Region


    Private mColCriteria As Collection = New Collection()


    Public ReadOnly Property Items() As Collection
        Get
            Return mColCriteria
        End Get
    End Property

    Public ReadOnly Property Items(ByVal key As String) As Criteria
        Get
            Return CType(mColCriteria(key), Criteria)
        End Get
    End Property



    Public Function AddCriteria(ByVal name As String, ByVal checked As Boolean, ByVal value As String) As QueryCriteria.Criteria
        Dim obj As QueryCriteria.Criteria = New QueryCriteria.Criteria(name, checked, value)
        Return Me.Add(name, obj)
    End Function

    Public Function Add(ByVal name As String, ByVal obj As QueryCriteria.Criteria) As QueryCriteria.Criteria
        Try
            mColCriteria.Add(obj, name)
            Return obj
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Serialize() As String
        Dim str As String = ""
        Dim objArrDataSent As Newtonsoft.Json.JavaScriptArray = New Newtonsoft.Json.JavaScriptArray()
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim i As Integer
        Dim objCriteria As QueryCriteria.Criteria


        For i = 1 To mColCriteria.Count
            objCriteria = CType(mColCriteria(i), QueryCriteria.Criteria)
            obj = New Newtonsoft.Json.JavaScriptObject
            obj.Add("name", objCriteria.Name)
            obj.Add("checked", objCriteria.Checked)
            obj.Add("value", objCriteria.Value)
            objArrDataSent.Add(obj)
        Next

        str = Newtonsoft.Json.JavaScriptConvert.SerializeObject(objArrDataSent)
        Return str
    End Function



    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim obj As QueryCriteria = New QueryCriteria()
        Dim objCriteria As QueryCriteria.Criteria
        For Each objCriteria In Me.Items
            obj.Add(objCriteria.Name, objCriteria)
        Next
        Return obj
    End Function



End Class



