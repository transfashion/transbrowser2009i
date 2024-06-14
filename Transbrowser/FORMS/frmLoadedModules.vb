Public Class frmLoadedModules

    Public Function SetContent(ByVal txt As String) As Boolean
        Dim txtTemp As TextBox = New TextBox()
        Dim i As Integer
        Dim str As String = "Loaded Modules: " & vbCrLf & "================" & vbCrLf & vbCrLf
        Dim tt(10) As String



        txtTemp.Multiline = True
        txtTemp.Text = txt

        For i = 0 To txtTemp.Lines.Length - 2
            tt = txtTemp.Lines(i).Split(",")
            str &= "[ " & Trim(tt(4)) & " ]" & vbCrLf
            str &= "DLL File: " & vbTab & Trim(tt(0)) & vbCrLf
            str &= "CLIR Version: " & vbTab & Trim(tt(1)) & vbCrLf
            str &= "Location: " & vbTab & Trim(tt(2)) & vbCrLf
            str &= "Cache: " & vbTab & vbTab & Trim(tt(3)) & vbCrLf
            str &= "Assembly: " & vbTab & Trim(tt(5)) & vbCrLf
            str &= "-------------------------------------------------------" & vbCrLf & vbCrLf
        Next

        Me.txtModule.Text = str
        Me.txtModule.Select(0, 0)
        Me.txtModule.WordWrap = False
        Me.btnClose.Focus()
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmLoadedModules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class