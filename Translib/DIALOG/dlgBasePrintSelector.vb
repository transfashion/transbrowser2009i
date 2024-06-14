Public Class dlgBasePrintSelector

    Private selectedprintmethod As String
    Private iniFile As String = System.Windows.Forms.Application.StartupPath & "\TransBrowser.ini"


    Private __default_webviewer As String
    Private __default_customizedprinting As String
    Private __default_customizedprintingclass As String



    Private Sub dlgBasePrintSelector_DialogOKClick(ByRef retObj As Object, ByRef cancel As Boolean) Handles Me.DialogOKClick
        Dim dllfile As String = ""
        Dim rdlcobjectname As String = ""
        Dim webpage As String = ""
        Dim customprinting As Boolean = False
        Dim customprintingclass As String = ""

        selectedprintmethod = Me.GetSelectedPrintMethod()
        Select Case selectedprintmethod
            Case "rdoDefault"
                dllfile = Me.obj_txtDefaultDLL.Text
                rdlcobjectname = Me.obj_txtDefaultInstance.Text
            Case "rdoUsingCustomizedRDLC"
                dllfile = ""
                rdlcobjectname = ""
            Case "rdoWebViewer"
                webpage = Me.obj_txtWebViewer.Text
                Me.INIWrite(iniFile, Me.ObjectName, "webviewer", webpage)
            Case "rdoCustomizedPrinting"
                dllfile = Me.obj_txtCustomizedPrinting.Text
                customprintingclass = Me.obj_txtCustomizedPrintingClass.Text
                customprinting = True

                Me.INIWrite(iniFile, Me.ObjectName, "customizedprinting", dllfile)
                Me.INIWrite(iniFile, Me.ObjectName, "customizedprintingclass", customprintingclass)
        End Select

        'Tulis ke ini file
        Me.INIWrite(iniFile, Me.ObjectName, "rdoSelected", selectedprintmethod)



        retObj = New Object() {dllfile, rdlcobjectname, webpage, customprinting, customprintingclass}
    End Sub


    Public Function Initialize(ByVal defaultdll As String, ByVal defaultinstance As String, ByVal webviewer As String, ByVal customizedprinting As String) As Boolean
        __default_webviewer = webviewer
        __default_customizedprinting = customizedprinting
        __default_customizedprintingclass = "PrintingCustom"


        'Baca dari konfigurasi INI File
        Dim rdoSelected = Me.INIRead(iniFile, Me.ObjectName, "rdoSelected")
        If rdoSelected = "" Then
            rdoSelected = "rdoDefault"
        End If

        If Me.pnlMain.Controls.ContainsKey(rdoSelected) Then
            CType(Me.pnlMain.Controls(rdoSelected), System.Windows.Forms.RadioButton).Checked = True
        Else
            Me.rdoDefault.Checked = True
        End If


        'Web Viewer
        Dim _web As String = Me.INIRead(iniFile, Me.ObjectName, "webviewer")
        If _web = "" Then
            _web = __default_webviewer
        End If

        'Custom Printing
        Dim _customizedprinting As String = Me.INIRead(iniFile, Me.ObjectName, "customizedprinting")
        Dim _customizedprintingclass As String = Me.INIRead(iniFile, Me.ObjectName, "customizedprintingclass")

        If _customizedprinting = "" Then
            _customizedprinting = __default_customizedprinting
        End If

        If _customizedprintingclass = "" Then
            _customizedprintingclass = __default_customizedprintingclass
        End If

        Me.obj_txtDefaultDLL.Text = defaultdll
        Me.obj_txtDefaultInstance.Text = defaultinstance
        Me.obj_txtWebViewer.Text = _web
        Me.obj_txtCustomizedPrinting.Text = _customizedprinting
        Me.obj_txtCustomizedPrintingClass.Text = _customizedprintingclass
        Me.obj_txtCustomizedPrintingInstance.Text = "Print()"


    End Function


    Public Function GetSelectedPrintMethod() As String
        If Me.rdoDefault.Checked Then
            Return Me.rdoDefault.Name
        ElseIf Me.rdoUsingCustomizedRDLC.Checked Then
            Return Me.rdoUsingCustomizedRDLC.Name
        ElseIf Me.rdoWebViewer.Checked Then
            Return Me.rdoWebViewer.Name
        Else
            Return Me.rdoCustomizedPrinting.Name
        End If
    End Function

    Private Sub rdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDefault.CheckedChanged, rdoUsingCustomizedRDLC.CheckedChanged, rdoWebViewer.CheckedChanged, rdoCustomizedPrinting.CheckedChanged
        Dim rdo As System.Windows.Forms.RadioButton = sender

        Me.obj_cboCustomizedRDLC.Enabled = False
        Me.obj_txtWebViewer.Enabled = False
        Me.obj_txtCustomizedPrinting.Enabled = False
        Me.obj_txtCustomizedPrintingClass.Enabled = False
        Me.obj_txtCustomizedPrintingInstance.Enabled = False
        Me.lnkResetWebViewer.Enabled = False
        Me.lnkResetCustomizedPrinting.Enabled = False


        If rdo.Checked Then
            selectedprintmethod = rdo.Name
            Select Case rdo.Name
                Case "rdoDefault"
                Case "rdoUsingCustomizedRDLC"
                    Me.obj_cboCustomizedRDLC.Enabled = True
                Case "rdoWebViewer"
                    Me.obj_txtWebViewer.Enabled = True
                    Me.lnkResetWebViewer.Enabled = True
                Case "rdoCustomizedPrinting"
                    Me.obj_txtCustomizedPrinting.Enabled = True
                    Me.obj_txtCustomizedPrintingClass.Enabled = True
                    Me.obj_txtCustomizedPrintingInstance.Enabled = True
                    Me.lnkResetCustomizedPrinting.Enabled = True
            End Select
        End If


    End Sub

    Private Sub dlgBasePrintSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectedprintmethod = "rdoDefault"
    End Sub

    Private Sub lnkResetWebViewer_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkResetWebViewer.LinkClicked
        Me.obj_txtWebViewer.Text = __default_webviewer
    End Sub

    Private Sub lnkResetCustomizedPrinting_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkResetCustomizedPrinting.LinkClicked
        Me.obj_txtCustomizedPrinting.Text = __default_customizedprinting
        Me.obj_txtCustomizedPrintingClass.Text = __default_customizedprintingclass
    End Sub

End Class
