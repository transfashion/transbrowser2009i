Public Class frmAbout

    Private mBrowserVersion As String


    Public Function SetBrowserVersion(ByVal str As String) As Boolean
        Me.mBrowserVersion = str
    End Function


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TextBox1.Text = System.Reflection.Assembly.GetExecutingAssembly.ToString
        Me.lblTransbrowser.Text = "TransBrowser, v" & mBrowserVersion
    End Sub
End Class