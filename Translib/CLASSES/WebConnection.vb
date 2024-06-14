Public Class WebConnection

    Private mURL As String = "http://localhost"
    Private mBoundary As String = System.Guid.NewGuid().ToString()
    Private mProxyAddress As String
    Private mProxyPort As String
    Private sbPostData As New System.Text.StringBuilder
    Private mSessionID As String
    Private mUserName As String
    Private mpostedrequest As String



#Region " Properties "

    Public Property SessionID() As String
        Get
            Return mSessionID
        End Get
        Set(ByVal value As String)
            mSessionID = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return mUserName
        End Get
        Set(ByVal value As String)
            mUserName = value
        End Set
    End Property

#End Region


    Public Sub New(ByVal url As String)
        mURL = url
    End Sub

    Public Sub New(ByVal url As String, ByVal session_id As String, ByVal username As String)
        mURL = url
        mSessionID = session_id
        mUserName = username
    End Sub


    Public Function addtext(ByVal name As String, ByVal value As String) As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
        str.Append("--" + mBoundary + vbCrLf)
        str.Append("Content-Disposition: form-data; name=""" & name & """" + vbCrLf)
        str.Append(vbCrLf)
        str.Append(value + vbCrLf)
        sbPostData.Append(Trim(str.ToString))
        Return str.ToString
    End Function

    Public Function Reset() As Boolean
        sbPostData = New System.Text.StringBuilder
    End Function

    Public Function post(ByVal script As String) As String
        Dim result As String = ""
        Dim address As String = mURL & "/" & script


        'MessageBox.Show(address)
        If UCase(Mid(script, 1, 7)) = UCase("http://") Then
            address = script
        End If


        Dim objEncoding As New System.Text.UTF8Encoding
        Dim request As System.Net.HttpWebRequest = Me.__ConnectionRequest(script)
        Dim intUploadBit As Integer
        Dim intUploadSoFar As Integer
        Dim intToUpload As Integer
        Dim i As Integer
        Dim objStreamReader As System.IO.Stream


        Me.mpostedrequest = ""

        'MessageBox.Show(sbPostData.ToString)
        If Me.SessionID <> "" Then
            Me.addtext("__SESSID", Me.SessionID)
        End If

        If Me.UserName <> "" Then
            Me.addtext("__USERNAME", Me.UserName)
        End If

        Me.addtext("__MachineName", My.Computer.Name)
        Me.addtext("__MachineIP", System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList.GetValue(0).ToString)


        Me.addtext("__ver", "x.145")
        Me.addtext("__cx", "235434583450435")

        Dim bytPostContents As Byte() = objEncoding.GetBytes(Trim(sbPostData.ToString))
        Dim bytPostFooter As Byte() = objEncoding.GetBytes(vbCrLf + "--" + mBoundary + vbCrLf)
        Dim bytDataBuffer As Byte() = New Byte(bytPostContents.Length + bytPostFooter.Length) {}

        request.ContentLength = bytDataBuffer.Length

        System.Buffer.BlockCopy(bytPostContents, 0, bytDataBuffer, 0, bytPostContents.Length)
        System.Buffer.BlockCopy(bytPostFooter, 0, bytDataBuffer, bytPostContents.Length, bytPostFooter.Length)

        Try
            'Kirim data ke Server
            Dim objStream As System.IO.Stream = request.GetRequestStream()
            intUploadBit = Math.Max(bytDataBuffer.Length / 100, 50 * 1024)
            intUploadSoFar = 0

            While i < bytDataBuffer.Length
                intToUpload = Math.Min(intUploadBit, bytDataBuffer.Length - i)
                intUploadSoFar += intToUpload
                objStream.Write(bytDataBuffer, i, intToUpload)
                i = i + intUploadBit
            End While
            objStream.Close()

            'Response Dari Server
            Dim objHTTPResponse As System.Net.HttpWebResponse = CType(request.GetResponse(), System.Net.HttpWebResponse)
            objStreamReader = objHTTPResponse.GetResponseStream()
            Dim objStreamResult As New System.IO.StreamReader(objStreamReader)
            result = objStreamResult.ReadToEnd

            objStreamReader.Close()
            objStreamResult.Close()

            Me.mpostedrequest = sbPostData.ToString

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try


        Return result
    End Function


    Public Function Execute(ByVal script As String) As Translib.WebResultObject
        Dim objWebResult As Translib.WebResultObject
        Dim str_result As String = ""

        str_result = Me.post(script)
        objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(str_result, GetType(Translib.WebResultObject)), Translib.WebResultObject)

        Try
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error" & vbCrLf & script)
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error, invalid object format." & vbCrLf & script)
            If Not objWebResult.success Then
                If objWebResult.errors IsNot Nothing Then
                    Throw New Exception(objWebResult.errors.ErrorMessage & vbCrLf & script)
                Else
                    Throw New Exception("objWebResult.errors not refrenced to object." & vbCrLf & "Please check your web service, for value of $objResult->success" & vbCrLf & "if defined as false, you have to set $objResult->errors " & vbCrLf & script)
                End If
            End If

            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0" & vbCrLf & script)
        Catch ex As Exception
            Throw ex
        End Try

        Return objWebResult

    End Function


    Public Function GetPostedRequest() As String
        Return Me.mpostedrequest
    End Function

    Private Function __ConnectionRequest(ByVal script As String) As System.Net.HttpWebRequest
        Dim address As String = mURL & "/" & script
        Dim Uri As Uri = New Uri(address)
        Dim request As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create(Uri), System.Net.HttpWebRequest)

        request.KeepAlive = False
        request.ProtocolVersion = System.Net.HttpVersion.Version10
        request.Timeout = System.Threading.Timeout.Infinite
        request.Method = "POST"
        request.ContentType = "multipart/form-data; boundary=" & mBoundary

        request.UserAgent = "Dhewe WebConnection"
        'request.ReadWriteTimeout = 2000

        If mProxyAddress <> "" Then
            Dim proxyURI As New Uri(mProxyAddress & ":" & mProxyPort)
            request.Proxy = New System.Net.WebProxy(proxyURI)
        End If

        Return request
    End Function

End Class
