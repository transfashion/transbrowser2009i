Public Class frmPassword

    Private m_username As String
    Private m_session_id As String
    Private m_dsn As String
    Private mFormMain As frmMain


    Private objError As ErrorProvider = New ErrorProvider()


#Region " Properties "

    Public Property UserName() As String
        Get
            Return m_username
        End Get
        Set(ByVal value As String)
            m_username = value
        End Set
    End Property

    Public Property DSN() As String
        Get
            Return m_dsn
        End Get
        Set(ByVal value As String)
            m_dsn = value
        End Set
    End Property

    Public Property SessionID() As String
        Get
            Return m_session_id
        End Get
        Set(ByVal value As String)
            m_session_id = value
        End Set
    End Property


#End Region



    Private Sub frmPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.mFormMain = Me.Owner
        Me.txtUsername.Enabled = False
        Me.txtUsername.Text = Me.UserName
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim wconn As Translib.WebConnection = New Translib.WebConnection(Me.mFormMain.WebserviceAddress, Me.SessionID, Me.UserName)
        Dim objWebResult As Translib.WebResultObject
        Dim str_result As String = ""
        Dim obj As Newtonsoft.Json.JavaScriptObject
        Dim username As String = Me.txtUsername.Text
        Dim oldpassword As String = Me.txtPasswordOld.Text
        Dim newpassword As String = Me.txtPasswordNew.Text
        Dim repassword As String = Me.txtPasswordRe.Text


        Me.objError.Clear()


        If Trim(newpassword) <> Trim(repassword) Then
            Me.objError.SetError(Me.txtPasswordRe, "Invalid Password")
            Me.txtPasswordRe.SelectAll()
            MessageBox.Show("You've typed invalid password.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            objError.SetError(Me.txtPasswordRe, "")
        End If


        Try
            Me.Cursor = Cursors.WaitCursor
            wconn.SessionID = Me.mFormMain.txtSessionID.Text
            wconn.addtext("username", username)
            wconn.addtext("password", newpassword)
            str_result = wconn.post(String.Format("service.php?t={0}&ns=transbrowser&object=uipassword&act=change", Now.Ticks))
            objWebResult = CType(Newtonsoft.Json.JavaScriptConvert.DeserializeObject(str_result, GetType(Translib.WebResultObject)), Translib.WebResultObject)
            If objWebResult Is Nothing Then Throw New Exception("Data Result Error")
            If objWebResult.data Is Nothing Then Throw New Exception("Data Result Error")
            If Not objWebResult.success Then Throw New Exception(objWebResult.errors.ErrorMessage)
            If objWebResult.data.Count < 0 Then Throw New Exception("Internal Error. objWebResult.data.Count < 0")

            obj = CType(objWebResult.data(0), Newtonsoft.Json.JavaScriptObject)
            If obj("success") = 1 Then
                Dim message As String = obj("message")

                MessageBox.Show("Password has been changed." & vbCrLf & message, "Transbrowser - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Throw New Exception(obj("message"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transbrowser - Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try


    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class