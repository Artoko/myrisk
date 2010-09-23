Imports DataLib
Public Class frmJet

    Private m_Jet As FireBlast.Jet = New FireBlast.Jet    '逻辑类的对象
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
    ''' 固体火灾
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property jet() As FireBlast.Jet
        Get
            Return Me.m_Jet
        End Get
        Set(ByVal value As FireBlast.Jet)
            Me.m_Jet = value
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
    Private Sub frmjet_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '初始化计算结算包含的内容
        txtLeakSourceName.Text = Me.m_Jet.JetFire.SourceName
        txtName.Text = Me.m_Jet.JetFire.Name
        txtX.Value = Me.m_Jet.JetFire.SourcePoint.x
        txtY.Value = Me.m_Jet.JetFire.SourcePoint.y


        Me.ctxtTime.Value = Me.m_Jet.JetFire.T
        Me.ctxtHc.Value = Me.m_Jet.JetFire.Hc
        Me.txtM.Value = Me.m_Jet.JetFire.M
        Me.ctxtF.Value = Me.m_Jet.JetFire.f
        Me.txtAngle.Value = Me.m_Jet.JetFire.SourceAngle
        Me.ctxtLong.Value = Me.m_Jet.JetFire.StepLong
        Me.ctxtCount.Value = Me.m_Jet.JetFire.StepCount

        '设置范围
        txtMinX.Value = m_Grid.MinX
        txtMaxX.Value = m_Grid.MaxX
        txtMinY.Value = m_Grid.MinY
        txtMaxY.Value = m_Grid.MaxY
        '更新一下表格
        Me.UpdateDistance()
        Me.UpdateHeatEradiate()
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
        ReDim Preserve Me.m_Jet.JetFire.ArrHeatEradiate(Me.m_Jet.JetFire.ArrHeatEradiate.Length)
        Me.m_Jet.JetFire.ArrHeatEradiate(Me.m_Jet.JetFire.ArrHeatEradiate.Length - 1) = New FireBlast.HeatEradiate
        Me.UpdateHeatEradiate()
    End Sub

    Private Sub cmdDamageDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageDelete.Click
        Dim index As Integer = Me.EFlexHeatRadiate.RowSel - 1
        If index >= 3 Then
            For i As Integer = index To Me.m_Jet.JetFire.ArrHeatEradiate.Length - 2
                Me.m_Jet.JetFire.ArrHeatEradiate(i) = Me.m_Jet.JetFire.ArrHeatEradiate(i + 1)
            Next
            ReDim Preserve Me.m_Jet.JetFire.ArrHeatEradiate(0 To Me.m_Jet.JetFire.ArrHeatEradiate.Length - 2)
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
        Dim L As Integer = Me.m_Jet.JetFire.ArrHeatEradiate.Length
        Me.EFlexHeatRadiate.Rows.Count = L + 1
        For i As Integer = 0 To L - 1
            Me.EFlexHeatRadiate.SetData(1 + i, 0, Me.m_Jet.JetFire.ArrHeatEradiate(i).HeatName)
            Me.EFlexHeatRadiate.SetData(1 + i, 1, Me.m_Jet.JetFire.ArrHeatEradiate(i).Heat)
            Me.EFlexHeatRadiate.SetData(1 + i, 2, Me.m_Jet.JetFire.ArrHeatEradiate(i).Checkd)
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
        ReDim Me.m_Jet.JetFire.ArrHeatEradiate(0 To L - 1)
        For i As Integer = 0 To L - 1
            m_Jet.JetFire.ArrHeatEradiate(i) = New FireBlast.HeatEradiate
            m_Jet.JetFire.ArrHeatEradiate(i).HeatName = Me.EFlexHeatRadiate.GetData(i + 1, 0)
            m_Jet.JetFire.ArrHeatEradiate(i).Heat = Me.EFlexHeatRadiate.GetData(i + 1, 1)
            m_Jet.JetFire.ArrHeatEradiate(i).Checkd = Me.EFlexHeatRadiate.GetData(i + 1, 2)

        Next
    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub ctxtTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtTime.Validating
        Me.m_Jet.JetFire.T = Me.ctxtTime.Value
    End Sub

    Private Sub ctxtHc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtHc.Validating
        Me.m_Jet.JetFire.Hc = Me.ctxtHc.Value
    End Sub


    Private Sub ctxtLong_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtLong.Validating
        Me.m_Jet.JetFire.StepLong = Me.ctxtLong.Value

    End Sub

    Private Sub ctxtCount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtCount.Validating
        Me.m_Jet.JetFire.StepCount = Me.ctxtCount.Value

    End Sub



    Private Sub txtLeakSourceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeakSourceName.TextChanged

    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        Me.m_Jet.JetFire.Name = txtName.Text
    End Sub

    Private Sub txtX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtX.TextChanged

    End Sub

    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        Me.m_Jet.JetFire.SourcePoint.x = txtX.Value

    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        Me.m_Jet.JetFire.SourcePoint.y = txtY.Value
    End Sub


    Private Sub EFlexDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EFlexDistance.Click

    End Sub

    Private Sub txtMc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtM.TextChanged

    End Sub

    Private Sub txtMc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM.Validating
        Me.m_Jet.JetFire.M = txtM.Value
    End Sub

    Private Sub ctxtW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ctxtTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtTime.TextChanged

    End Sub

    Private Sub txtY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtY.TextChanged

    End Sub

    Private Sub ctxtHc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtHc.TextChanged

    End Sub

    Private Sub ctxtF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtF.TextChanged

    End Sub

    Private Sub ctxtF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxtF.Validating
        Me.m_Jet.JetFire.f = ctxtF.Value
    End Sub

    Private Sub txtLeakSourceName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        Me.m_Jet.JetFire.SourceName = txtLeakSourceName.Text
    End Sub

    Private Sub ctxtLong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtLong.TextChanged

    End Sub

    Private Sub ctxtCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtCount.TextChanged

    End Sub

    Private Sub txtAngle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngle.TextChanged

    End Sub

    Private Sub txtAngle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAngle.Validating
        Me.m_Jet.JetFire.SourceAngle = txtAngle.Value
    End Sub

    Private Sub cmdSeachData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeachData.Click
        '在数据库中查找数据，并导入 
        Dim frmNew As New frmSearchData
        frmNew.txtHc.Visible = True
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtHc.Text <> "" Then
                m_Jet.JetFire.Hc = frmNew.txtHc.Text
                Me.ctxtHc.Value = frmNew.txtHc.Text
            Else
                MsgBox("请手动输入液体燃烧热！")
            End If
        End If
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