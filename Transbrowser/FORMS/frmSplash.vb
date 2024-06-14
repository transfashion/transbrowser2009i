Public Class frmSplash

    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblPT.Text = "DEVELOPMENT PURPOSE ONLY"
        Me.lblVersion.Text = "TransBrowser, Version " & Application.ProductVersion
        Me.lblTransCorp.Text = "Copyright(C) 2006 - 2008, PT.TransCoorpora. All Right Reserved"
    End Sub

End Class