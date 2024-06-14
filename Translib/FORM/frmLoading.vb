Public Class frmLoading

  
    Public Function SetStatus(ByVal str As String) As Boolean
        Me.lblStatus.Text = str
        Me.lblStatus.Refresh()
    End Function


    Public Function SetMessage(ByVal str As String) As Boolean
        Me.lblMessage.Text = str
        Me.lblMessage.Refresh()
    End Function

End Class