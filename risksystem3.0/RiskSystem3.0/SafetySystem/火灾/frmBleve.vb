Public Class frmBleve
    Private m_Bleve As FireBlast.Bleve = New FireBlast.Bleve
    Private m_Grid As New FireBlast.Grid
    ''' <summary>
    ''' 火灾爆炸的关心点数组
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayDistance() As FireBlast.CarePoint
    ''' <summary>
    '''  火灾爆炸的关心点数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ArrayDistance() As FireBlast.CarePoint()
        Get
            Return Me.m_ArrayDistance
        End Get
        Set(ByVal value As FireBlast.CarePoint())
            Me.m_ArrayDistance = value
        End Set
    End Property
    ''' <summary>
    ''' Bleve模型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Bleve() As FireBlast.Bleve
        Get
            Return Me.m_Bleve
        End Get
        Set(ByVal value As FireBlast.Bleve)
            Me.m_Bleve = value
        End Set
    End Property
    ''' <summary>
    ''' 预测范围
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Grid() As FireBlast.Grid
        Get
            Return Me.m_Grid
        End Get
        Set(ByVal value As FireBlast.Grid)
            Me.m_Grid = value
        End Set
    End Property

    Private Sub frmPoolFire_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '初始化计算结算包含的内容
        txtLeakSourceName.Text = Me.m_Bleve.SourceName
        txtName.Text = Me.m_Bleve.Name
        txtX.Value = Me.m_Bleve.SourcePoint.x
        txtY.Value = Me.m_Bleve.SourcePoint.y
        '设置提示
        Me.ctxtWf.Value = Me.m_Bleve.Wf

        Me.cmbType.Text = Me.m_Bleve.MemoryType '储存方式

        Me.ctxtHc.Value = Me.m_Bleve.Hc

        cmbBleveRTModel.Text = Me.m_Bleve.Model '选择模型
        If Me.m_Bleve.AccountFashion = 0 Then
            OptionF1.Checked = True
        Else
            OptionF2.Checked = True
        End If
        Me.ctxtPa.Value = Me.m_Bleve.Pa
        Me.ctxtF.Value = Me.m_Bleve.F

        ctxtLong.Value = Me.m_Bleve.StepLong
        ctxtCount.Value = Me.m_Bleve.StepCount

        '设置范围
        txtMinX.Value = m_Grid.MinX
        txtMaxX.Value = m_Grid.MaxX
        txtMinY.Value = m_Grid.MinY
        txtMaxY.Value = m_Grid.MaxY

        UpdateDistance()
        UpdateHeatEradiate()
    End Sub
    '增加一行数据
    Private Sub cmdForcastAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForcastAdd.Click
        ReDim Preserve Me.m_ArrayDistance(Me.m_ArrayDistance.Length)
        Me.m_ArrayDistance(Me.m_ArrayDistance.Length - 1) = New FireBlast.CarePoint
        Me.UpdateDistance()
    End Sub
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdForecastDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForecastDelete.Click
        Dim index As Integer = Me.EFlexDistance.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_ArrayDistance.Length - 2
                Me.m_ArrayDistance(i) = Me.m_ArrayDistance(i + 1)
            Next
            ReDim Preserve Me.m_ArrayDistance(0 To Me.m_ArrayDistance.Length - 2)
            Me.UpdateDistance()
        End If
    End Sub

    '增加一行数据
    Private Sub cmdDamageAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageAdd.Click
        ReDim Preserve Me.m_Bleve.ArrHeatEradiate(Me.m_Bleve.ArrHeatEradiate.Length)
        Me.m_Bleve.ArrHeatEradiate(Me.m_Bleve.ArrHeatEradiate.Length - 1) = New FireBlast.HeatEradiate
        Me.UpdateHeatEradiate()
    End Sub

    Private Sub cmdDamageDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageDelete.Click
        Dim index As Integer = Me.EFlexHeatRadiate.RowSel - 1
        If index >= 3 Then
            For i As Integer = index To Me.m_Bleve.ArrHeatEradiate.Length - 2
                Me.m_Bleve.ArrHeatEradiate(i) = Me.m_Bleve.ArrHeatEradiate(i + 1)
            Next
            ReDim Preserve Me.m_Bleve.ArrHeatEradiate(0 To Me.m_Bleve.ArrHeatEradiate.Length - 2)
            Me.UpdateHeatEradiate()
        End If
    End Sub
    ''' <summary>
    ''' 在表格 EFlexDistance  中添加 数据后，更新一下表格
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateDistance()
        Dim L As Integer = Me.m_ArrayDistance.Length
        Me.EFlexDistance.Rows.Count = L + 1
        For i As Integer = 0 To L - 1
            Me.EFlexDistance.SetData(1 + i, 0, (Me.m_ArrayDistance(i).Dist))
            Me.EFlexDistance.SetData(1 + i, 1, (Me.m_ArrayDistance(i).Rpoint.x))
            Me.EFlexDistance.SetData(1 + i, 2, (Me.m_ArrayDistance(i).Rpoint.y))
        Next
    End Sub

    ''' <summary>
    ''' 在表格 EFlexHeatRadiate  中添加 数据后，更新一下表格
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateHeatEradiate()
        Dim L As Integer = Me.m_Bleve.ArrHeatEradiate.Length
        Me.EFlexHeatRadiate.Rows.Count = L + 1
        For i As Integer = 0 To L - 1
            Me.EFlexHeatRadiate.SetData(1 + i, 0, Me.m_Bleve.ArrHeatEradiate(i).HeatName)
            Me.EFlexHeatRadiate.SetData(1 + i, 1, Me.m_Bleve.ArrHeatEradiate(i).Heat)
            Me.EFlexHeatRadiate.SetData(1 + i, 2, Me.m_Bleve.ArrHeatEradiate(i).Checkd)
        Next
    End Sub

    ''' <summary>
    ''' 表格 EFlexDistance  的 Validating 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EFlexDistance_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexDistance.Validating

        Dim L As Integer = Me.EFlexDistance.Rows.Count - 1
        ReDim Me.m_ArrayDistance(0 To L - 1)
        For i As Integer = 0 To L - 1
            Me.m_ArrayDistance(i) = New FireBlast.CarePoint
            Me.m_ArrayDistance(i).Dist = Me.EFlexDistance.GetData(i + 1, 0)
            Me.m_ArrayDistance(i).Rpoint.x = Me.EFlexDistance.GetData(i + 1, 1)
            Me.m_ArrayDistance(i).Rpoint.y = Me.EFlexDistance.GetData(i + 1, 2)
        Next
    End Sub
    ''' <summary>
    ''' 表格 EFlexHeatRadiate  的 Validating 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EFlexHeatRadiate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexHeatRadiate.Validating
        Dim L As Integer = Me.EFlexHeatRadiate.Rows.Count - 1
        ReDim Me.m_Bleve.ArrHeatEradiate(0 To L - 1)
        For i As Integer = 0 To L - 1
            m_Bleve.ArrHeatEradiate(i) = New FireBlast.HeatEradiate
            m_Bleve.ArrHeatEradiate(i).HeatName = Me.EFlexHeatRadiate.GetData(i + 1, 0)
            m_Bleve.ArrHeatEradiate(i).Heat = Me.EFlexHeatRadiate.GetData(i + 1, 1)
            m_Bleve.ArrHeatEradiate(i).Checkd = Me.EFlexHeatRadiate.GetData(i + 1, 2)

        Next
    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        Me.m_Bleve.Name = txtName.Text
    End Sub

    Private Sub txtX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtX.TextChanged

    End Sub

    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        Me.m_Bleve.SourcePoint.x = txtX.Value

    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        Me.m_Bleve.SourcePoint.y = txtY.Value
    End Sub


    Private Sub cmdSeachData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeachData.Click
        '在数据库中查找数据，并导入 
        Dim frmNew As New frmSearchData
        frmNew.txtHc.Visible = True
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtHc.Text <> "" Then
                m_Bleve.Hc = frmNew.txtHc.Text
                Me.ctxtHc.Value = frmNew.txtHc.Text
            Else
                MsgBox("请手动输入液体燃烧热！")
            End If
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub OptionF2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionF2.CheckedChanged
        If sender.Checked Then
            If OptionF1.Checked = True Then
                Me.m_Bleve.AccountFashion = 1
                ctxtF.Enabled = True
                ctxtPa.Enabled = False
            ElseIf OptionF2.Checked = True Then
                Me.m_Bleve.AccountFashion = 0
                ctxtPa.Enabled = True
                ctxtF.Enabled = False
            End If
        End If
    End Sub

    Private Sub ctxtF_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtF.Validating
        Me.m_Bleve.F = Me.ctxtF.Value
    End Sub

    Private Sub ctxtPa_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtPa.Validating
        Me.m_Bleve.Pa = Me.ctxtPa.Value
    End Sub
    Private Sub ctxtW_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtWf.Validating
        Me.m_Bleve.Wf = ctxtWf.Value
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        Me.m_Bleve.MemoryType = cmbType.Text
    End Sub

    Private Sub OptionF1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionF1.CheckedChanged
        If OptionF1.Checked = True Then
            Me.m_Bleve.AccountFashion = 0
            ctxtPa.Enabled = True
            ctxtF.Enabled = False
        Else
            Me.m_Bleve.AccountFashion = 1
            ctxtF.Enabled = True
            ctxtPa.Enabled = False
        End If
    End Sub

    Private Sub ctxtF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtF.TextChanged

    End Sub

    Private Sub ctxtPa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtPa.TextChanged

    End Sub

    Private Sub cmbBleveRTModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBleveRTModel.SelectedIndexChanged
        Me.m_Bleve.Model = cmbBleveRTModel.Text
    End Sub

    Private Sub txtLeakSourceName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        Me.m_Bleve.SourceName = txtLeakSourceName.Text
    End Sub

    Private Sub ctxtLong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtLong.TextChanged

    End Sub

    Private Sub ctxtLong_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtLong.Validating
        Me.m_Bleve.StepLong = ctxtLong.Value
    End Sub

    Private Sub ctxtCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtCount.TextChanged

    End Sub

    Private Sub ctxtCount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtCount.Validating
        Me.m_Bleve.StepCount = ctxtCount.Value
    End Sub

    Private Sub txtMinX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinX.TextChanged

    End Sub

    Private Sub txtMinX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinX.Validating
        m_Grid.MinX = txtMinX.Value
    End Sub

    Private Sub txtMaxX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxX.TextChanged

    End Sub

    Private Sub txtMaxX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMaxX.Validating
        m_Grid.MaxX = txtMaxX.Value
    End Sub

    Private Sub txtMinY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinY.TextChanged

    End Sub

    Private Sub txtMinY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinY.Validating
        m_Grid.MinY = txtMinY.Value
    End Sub

    Private Sub txtMaxY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxY.TextChanged

    End Sub

    Private Sub txtMaxY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMaxY.Validating
        m_Grid.MaxY = txtMaxY.Value
    End Sub
End Class