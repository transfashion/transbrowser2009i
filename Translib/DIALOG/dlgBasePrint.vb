Public Class dlgBasePrint

    Private mArgs As Object
    Private mIDS As Object



    Public WithEvents bgwDataprintLoader As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker

#Region " Constructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.btnCancel.Text = "Close"
        Me.btnOK.Visible = False

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True

    End Sub



#End Region

#Region " Property "

    Public Property Arguments() As Object
        Get
            Return mArgs
        End Get
        Set(ByVal value As Object)
            mArgs = value
        End Set
    End Property

    Public Property IDS() As Object
        Get
            Return mIDS
        End Get
        Set(ByVal value As Object)
            mIDS = value
        End Set
    End Property

#End Region

    '#Region " Data Loader "

    '    Private Sub bgwDataprintLoader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDataprintLoader.DoWork
    '        System.Threading.Thread.Sleep(100)
    '    End Sub

    '    Private Sub bgwDataprintLoader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDataprintLoader.RunWorkerCompleted
    '        System.Windows.Forms.MessageBox.Show("report completed")
    '    End Sub

    '#End Region


    '    Public Overridable Function ProcessReport() As Boolean
    '        Dim ids As Object = Me.IDS
    '        Dim args As Object = Me.Arguments

    '        Me.bgwDataprintLoader.RunWorkerAsync()

    '    End Function





End Class
