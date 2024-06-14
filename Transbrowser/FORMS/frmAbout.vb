Public Class frmAbout

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TextBox1.Text = System.Reflection.Assembly.GetExecutingAssembly.ToString
        Me.Label1.Text = "TransBrowser, v" & Application.ProductVersion
    End Sub
End Class