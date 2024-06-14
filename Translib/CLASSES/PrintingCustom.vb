Public Class PrintingCustom

    Public Function [Print](ByRef ids As Object, ByRef tbl As DataTable, ByRef args As Object) As Boolean
        Dim nama As String = args(0)

        System.Windows.Forms.MessageBox.Show("custom printing belum dibuat")
        ' cancel = True
    End Function

End Class
