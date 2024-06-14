Public Class dlgBaseMaster

    Private mCriteriaQ As Translib.QueryCriteria = New Translib.QueryCriteria
    Private mWebservice As String = ""

    Private mSelectedValue As String
    Private mDisplayedText As String
    Private mSelectedValueColumn As String
    Private mDisplayedTextColumn As String
    Private mCriteriaIsMandatory As Boolean = True

    Private objErrorProvider As System.Windows.Forms.ErrorProvider = New System.Windows.Forms.ErrorProvider()



#Region " Constructor "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ds.Tables.Add("master")


    End Sub

    Public Function SetSelected(ByVal colname_value, ByVal selected_value, ByVal colname_display, ByVal selected_display) As Boolean
        Me.mSelectedValue = selected_value
        Me.mDisplayedText = selected_display
        Me.mSelectedValueColumn = colname_value
        Me.mDisplayedTextColumn = colname_display

        Me.obj_txt_masterdata_id.Text = selected_value
        Me.obj_txt_masterdata_name.Text = selected_display
        Me.obj_search_txt_masterdata_name.Text = selected_display


    End Function

#End Region

#Region " Property "

    Public ReadOnly Property SelectedValue() As String
        Get
            Return mSelectedValue
        End Get
    End Property

    Public ReadOnly Property DisplayedText() As String
        Get
            Return mDisplayedText
        End Get
    End Property

    Public ReadOnly Property SelectedValueColumn() As String
        Get
            Return mSelectedValueColumn
        End Get
    End Property

    Public ReadOnly Property DisplayedTextColumn() As String
        Get
            Return mDisplayedTextColumn
        End Get
    End Property

    Public ReadOnly Property CriteriaQuery() As Translib.QueryCriteria
        Get
            Return Me.mCriteriaQ
        End Get
    End Property

    Public Property CriteriaIsMandatory() As Boolean
        Get
            Return Me.mCriteriaIsMandatory
        End Get
        Set(ByVal value As Boolean)
            Me.mCriteriaIsMandatory = value
        End Set
    End Property

#End Region



    Private Sub dlgBaseMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim args As Object() = Me.Argument
        Dim service As String = Me.Argument(0)
        Dim criteriaQ As Translib.QueryCriteria = Me.Argument(1)
        Dim dgvcols As System.Windows.Forms.DataGridViewColumn() = Me.Argument(2)
        Dim criteria As String = ""




        Me.DgvMaster.Columns.Clear()
        If dgvcols IsNot Nothing Then
            Me.DgvMaster.Columns.AddRange(dgvcols)
            Me.DgvMaster.AutoGenerateColumns = False
        Else
            Me.DgvMaster.AutoGenerateColumns = True
        End If
        Me.DgvMaster.AllowUserToAddRows = False
        Me.DgvMaster.AllowUserToDeleteRows = False
        Me.DgvMaster.AllowUserToResizeRows = False
        Me.DgvMaster.ReadOnly = True
        Me.DgvMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect


        Me.mWebservice = service
        Me.mCriteriaQ = criteriaQ.Clone()


        If Me.obj_txt_masterdata_id.Text <> "" Then
            criteriaQ.AddCriteria("obj_chk_masterdata_id", 1, Me.obj_txt_masterdata_id.Text)
        Else
            Me.obj_txt_masterdata_id.Text = "0"
            criteriaQ.AddCriteria("obj_chk_masterdata_id", 1, Me.obj_txt_masterdata_id.Text)
        End If

        criteria = criteriaQ.Serialize()
        Me.DataLoad(Me.mWebservice, criteria, "master", "DgvMaster")

        ' Binding Criteria
        Me.obj_search_txt_masterdata_name.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Me.obj_chk_masterdata_name, "Checked"))
        Me.obj_search_txt_masterdata_advance.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Me.obj_chk_masterdata_advance, "Checked"))

        Me.obj_search_txt_masterdata_name.Focus()


        If Me.obj_search_txt_masterdata_name.Text = "" Then
            If Not Me.CriteriaIsMandatory Then
                Me.obj_chk_masterdata_name.Checked = False
            End If
        End If

    End Sub


    Private Sub dlgBaseMaster_DataLoaded(ByVal service As String) Handles Me.DataLoaded
        Dim dgvcols As System.Windows.Forms.DataGridViewColumn() = Me.Argument(2)
        Dim trimname As String = ""
        If dgvcols Is Nothing Then
            If Me.DgvMaster.Columns.Count > 1 Then
                Me.DgvMaster.Columns(1).Width = 270
            End If
        End If

        If Me.DgvMaster.Rows.Count = 1 Then
            Me.obj_txt_masterdata_id.Text = Me.DgvMaster.Rows(0).Cells(Me.mSelectedValueColumn).Value
            Me.obj_txt_masterdata_name.Text = Me.DgvMaster.Rows(0).Cells(Me.mDisplayedTextColumn).Value.ToString
        End If

    End Sub

    Private Sub dlgBaseMaster_DialogOKClick(ByRef retObj As Object, ByRef cancel As Boolean) Handles Me.DialogOKClick
        Dim crow As System.Windows.Forms.DataGridViewRow = Me.DgvMaster.CurrentRow
        Dim DialogSelectedValue As String
        Dim DialogDisplayedText As String

        ' Kembalikan data dari current row yang dipilih
        If crow Is Nothing Then
            cancel = True
        Else
            If Me.obj_txt_masterdata_id.Text = "" Or Me.obj_txt_masterdata_id.Text = "0" Then
                If Me.DgvMaster.CurrentRow IsNot Nothing Then
                    System.Windows.Forms.MessageBox.Show("Please chose one from list above", Me.Text, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
                Else
                End If
                cancel = True
            Else
                DialogSelectedValue = Me.obj_txt_masterdata_id.Text ' crow.Cells(Me.SelectedValueColumn).Value
                DialogDisplayedText = Me.obj_txt_masterdata_name.Text ' crow.Cells(Me.DisplayedTextColumn).Value
                retObj = New Object() {DialogSelectedValue, DialogDisplayedText, crow}
            End If
        End If

    End Sub


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim load As Boolean = False
        Dim criteriaQ As Translib.QueryCriteria = Me.CriteriaQuery.Clone()
        Dim criteria As String = ""


        Me.objErrorProvider.Clear()

        If Me.CriteriaIsMandatory Then
            ' Salah satu dari name atau advance harus dipilih
            If Not Me.obj_chk_masterdata_name.Checked And Not Me.obj_chk_masterdata_advance.Checked Then
                System.Windows.Forms.MessageBox.Show("Please choose at least one criteria", Me.Text, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If


        If Me.obj_chk_masterdata_name.Checked Then
            If Trim(Me.obj_search_txt_masterdata_name.Text) = "" Then
                Me.objErrorProvider.SetError(Me.obj_search_txt_masterdata_name, "please fill this named field")
            Else
                Me.objErrorProvider.SetError(Me.obj_search_txt_masterdata_name, "")
            End If
        End If

        If Me.obj_chk_masterdata_advance.Checked Then
            If Trim(Me.obj_search_txt_masterdata_advance.Text) = "" Then
                Me.objErrorProvider.SetError(Me.obj_search_txt_masterdata_advance, "please fill this named field")
            Else
                Me.objErrorProvider.SetError(Me.obj_search_txt_masterdata_advance, "")
            End If
        End If


        If Me.objErrorProvider.GetError(Me.obj_search_txt_masterdata_name) = "" And Me.objErrorProvider.GetError(Me.obj_search_txt_masterdata_advance) = "" Then
            criteriaQ.AddCriteria(Me.obj_chk_masterdata_name.Name, Me.obj_chk_masterdata_name.Checked, Me.obj_search_txt_masterdata_name.Text)
            criteriaQ.AddCriteria(Me.obj_chk_masterdata_advance.Name, Me.obj_chk_masterdata_advance.Checked, Me.obj_search_txt_masterdata_advance.Text)
            criteria = criteriaQ.Serialize()
            Me.DataLoad(Me.mWebservice, criteria, "master", "DgvMaster")
            Me.DgvMaster.Focus()
        End If

    End Sub

    Private Sub DgvMaster_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvMaster.MouseClick
        Dim dgv As System.Windows.Forms.DataGridView = CType(sender, System.Windows.Forms.DataGridView)
        Dim hi As System.Windows.Forms.DataGridView.HitTestInfo

        hi = dgv.HitTest(e.X, e.Y)

        If hi.ColumnIndex < 0 Or hi.RowIndex < 0 Then
            Exit Sub
        End If

        Try
            Me.obj_txt_masterdata_id.Text = dgv.Rows(hi.RowIndex).Cells(Me.mSelectedValueColumn).Value
            Me.obj_txt_masterdata_name.Text = dgv.Rows(hi.RowIndex).Cells(Me.mDisplayedTextColumn).Value.ToString
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Critical Error" & vbCrLf & ex.Message & vbCrLf & "mungkin sebelum open dialog lupa belom dipanggil dlg.SetSelected(id, idVal, name, nameVal)", Me.Text, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvMaster_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMaster.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If

        Me.btnOK_Click(Me.btnOK, New System.EventArgs)
    End Sub


    Private Sub obj_chk_masterdata_name_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_chk_masterdata_name.CheckedChanged
        Dim obj As System.Windows.Forms.CheckBox = CType(sender, System.Windows.Forms.CheckBox)
        If obj.Checked Then
            Me.obj_chk_masterdata_name.Focus()
        End If
    End Sub

    Private Sub obj_search_txt_masterdata_name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles obj_search_txt_masterdata_name.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btnLoad_Click(Me.btnLoad, New System.EventArgs)
        End If
    End Sub



End Class
