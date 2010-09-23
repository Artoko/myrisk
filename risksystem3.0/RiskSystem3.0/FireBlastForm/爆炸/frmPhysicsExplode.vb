Public Class frmPhysicsExplode

    Private m_PhysicsExplode As New FireBlast.PhysicsExplode  '用TNT当量法进行计算的对象
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
    ''' 用TNT当量法进行计算蒸汽云的对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PhysicsExplode() As FireBlast.PhysicsExplode
        Get
            Return Me.m_PhysicsExplode
        End Get
        Set(ByVal value As FireBlast.PhysicsExplode)
            Me.m_PhysicsExplode = value
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
    Private Sub cmdSeachData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeachData.Click
        ''在数据库中查找数据，并导入 
        'Dim frmNew As New frmSearchData
        'frmNew.txtHc.Visible = True

        'frmNew.txtName.Text = Me.txtName.Text
        'frmNew.ShowDialog()
        'If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
        '    If frmNew.txtHc.Text <> "" Then
        '        Me.txtQf.Text = frmNew.txtHc.Text
        '    Else
        '        MsgBox("请手动输入物质的燃烧热！")
        '    End If
        'End If
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub
    Private Function WTNT(ByVal Wf As Double, ByVal a As Double, ByVal Qf As Double, ByVal Reflect As Short) As Double '计算蒸汽云的TNT当量
        WTNT = a / 100 * Wf * Qf / (4.52 * 1000000)
        If Reflect = 1 Then
            WTNT = 1.8 * WTNT
        End If
    End Function
    Private Function RTNT(ByVal WTNT As Double, ByVal dP As Double) As Double '爆炸中心与给定超压间的距离

        If System.Math.Log(dP / 6900) >= 0.7241 / (2 * 0.0398) Then
            RTNT = 0
        Else
            RTNT = 0.3967 * WTNT ^ (1 / 3) * System.Math.Exp(3.5031 - 0.7241 * System.Math.Log(dP / 6900) + 0.0398 * (System.Math.Log(dP / 6900)) ^ 2)
        End If
    End Function
    Private Function R05(ByVal WTNT As Double) As Double '计算s死亡半径
        R05 = 13.6 * (WTNT / 1000) ^ 0.37
    End Function
    Private Function RWealth(ByVal WTNT As Double) As Double '计算财产损失半径
        RWealth = 4.6 * WTNT ^ (1 / 3) / ((1 + (3175 / WTNT) ^ 2) ^ (1 / 6))
    End Function
    Private Function db(ByVal WTNT As Double, ByVal R As Double) As Double '通过距离计算超压
        Dim x As Double
        If 0.524321 - 0.1592 * (3.5031 - System.Math.Log(R / (0.3967 * WTNT ^ (1 / 3)))) <= 0 Then
            db = 0
        Else
            x = (0.7241 - (0.524321 - 0.1592 * (3.5031 - System.Math.Log(R / (0.3967 * WTNT ^ (1 / 3))))) ^ 0.5) / 0.0796
            db = 6900 * System.Math.Exp(x)
        End If
    End Function
    '增加一行数据
    Private Sub cmdForcastAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForcastAdd.Click
        ReDim Preserve Me.m_ArrayDistance(Me.m_ArrayDistance.Length) '长度增加
        Me.m_ArrayDistance(Me.m_ArrayDistance.Length - 1) = New FireBlast.CarePoint '创建一个对象
        UpdateDistance()

    End Sub
    ''' <summary>
    ''' 更新表格中的数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateDistance()
        Dim L As Integer = Me.m_ArrayDistance.Length
        Me.EFlexDistance.Rows.Count = L + 1
        For i As Integer = 0 To L - 1
            Me.EFlexDistance.SetData(1 + i, 0, Me.m_ArrayDistance(i).Dist)
            Me.EFlexDistance.SetData(1 + i, 1, Me.m_ArrayDistance(i).Rpoint.x)
            Me.EFlexDistance.SetData(1 + i, 2, Me.m_ArrayDistance(i).Rpoint.y)
        Next
    End Sub
    ''' <summary>
    '''  更新表格中的数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateDestroyR()
        Dim L As Integer = Me.m_PhysicsExplode.DestroyRr.Length
        Me.EFlex1.Rows.Count = L + 1
        For i As Integer = 0 To L - 1
            Me.EFlex1.SetData(1 + i, 0, Me.m_PhysicsExplode.DestroyRr(i).MDrangName)
            Me.EFlex1.SetData(1 + i, 1, Me.m_PhysicsExplode.DestroyRr(i).MDrang)
            Me.EFlex1.SetData(1 + i, 2, Me.m_PhysicsExplode.DestroyRr(i).Selected)
        Next
    End Sub

    ''' <summary>
    ''' 删除表格中的一行数据 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdForecastDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForecastDelete.Click
        '
        Dim index As Integer = Me.EFlexDistance.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_ArrayDistance.Length - 2
                Me.m_ArrayDistance(i) = Me.m_ArrayDistance(i + 1)
            Next
            ReDim Preserve Me.m_ArrayDistance(0 To Me.m_ArrayDistance.Length - 2)

        End If
        UpdateDistance()
    End Sub


    Private Sub frmPhysicsExplode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化 测试值
        txtLeakSourceName.Text = Me.m_PhysicsExplode.SourceName
        Me.txtName.Text = Me.m_PhysicsExplode.Name
        Me.txtX.Value = Me.m_PhysicsExplode.SoucePoint.x
        Me.txtY.Value = Me.m_PhysicsExplode.SoucePoint.y
        Me.cmbType.SelectedIndex = Me.m_PhysicsExplode.ExplodeType

        txtPg.Value = Me.m_PhysicsExplode.Pg
        txtVg.Value = Me.m_PhysicsExplode.Vg
        txtKg.Value = Me.m_PhysicsExplode.kg
        txtPs.Value = Me.m_PhysicsExplode.Ps
        txtVs.Value = Me.m_PhysicsExplode.Vs
        txtPl.Value = Me.m_PhysicsExplode.Pl
        txtVl.Value = Me.m_PhysicsExplode.Vl
        txtBt.Value = Me.m_PhysicsExplode.Bt
        txtH1.Value = Me.m_PhysicsExplode.H1
        txtH2.Value = Me.m_PhysicsExplode.H2
        txtS1.Value = Me.m_PhysicsExplode.S1
        txtS2.Value = Me.m_PhysicsExplode.S2
        txtW.Value = Me.m_PhysicsExplode.W
        txtVw.Value = Me.m_PhysicsExplode.Vw
        txtPw.Value = Me.m_PhysicsExplode.Pw

        CTextStep.Value = Me.m_PhysicsExplode.Tstep
        CTextCount.Value = Me.m_PhysicsExplode.Tcount
        '设置提示

        '设置范围
        txtMinX.Value = m_Grid.MinX
        txtMaxX.Value = m_Grid.MaxX
        txtMinY.Value = m_Grid.MinY
        txtMaxY.Value = m_Grid.MaxY

        Me.UpdateDistance() '更新
        UpdateDestroyR() '更新超压数据
    End Sub

    '增加一行数据
    Private Sub cmdDamageAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageAdd.Click
        ReDim Preserve Me.m_PhysicsExplode.DestroyRr(Me.m_PhysicsExplode.DestroyRr.Length) '长度增加1
        Me.m_PhysicsExplode.DestroyRr(Me.m_PhysicsExplode.DestroyRr.Length - 1) = New FireBlast.Drang  '创建一个对象
        UpdateDestroyR()
    End Sub

    Private Sub cmdDamageDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageDelete.Click
        '删除预测列表
        Dim index As Integer = Me.EFlex1.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_PhysicsExplode.DestroyRr.Length - 2
                Me.m_PhysicsExplode.DestroyRr(i) = Me.m_PhysicsExplode.DestroyRr(i + 1)
            Next
            ReDim Preserve Me.m_PhysicsExplode.DestroyRr(0 To Me.m_PhysicsExplode.DestroyRr.Length - 2)

        End If
        UpdateDestroyR()
    End Sub


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' 表格EFlexDistance  的 Validating 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EFlexDistance_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexDistance.Validating
        Dim L As Integer = Me.EFlexDistance.Rows.Count - 1
        ReDim Me.m_ArrayDistance(0 To L - 1)
        For i As Integer = 0 To L - 1
            Me.m_ArrayDistance(i) = New FireBlast.CarePoint
            Me.m_ArrayDistance(i).Dist = Me.EFlexDistance.GetData(i + 1, 0)
            Me.m_ArrayDistance(i).Rpoint.x = Me.EFlexDistance.GetData(i + 1, 1)
            Me.m_ArrayDistance(i).Rpoint.y = Me.EFlexDistance.GetData(i + 1, 2)
        Next
    End Sub

    Private Sub CTextStep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTextStep.TextChanged

    End Sub

    Private Sub CTextStep_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CTextStep.Validated
        Me.m_PhysicsExplode.Tstep = Me.CTextStep.Value

    End Sub

    Private Sub CTextCount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CTextCount.Validating
        Me.m_PhysicsExplode.Tcount = Me.CTextCount.Value


    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtDamageQ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EFlex1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EFlex1.Click

    End Sub
    '表格 EFlex1 的 Validating 事件
    Private Sub EFlex1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlex1.Validating
        Dim L As Integer = Me.EFlex1.Rows.Count - 1
        ReDim Me.m_PhysicsExplode.DestroyRr(0 To L - 1)
        For i As Integer = 0 To L - 1
            m_PhysicsExplode.DestroyRr(i) = New FireBlast.Drang

            Me.m_PhysicsExplode.DestroyRr(i).MDrangName = Me.EFlex1.GetData(i + 1, 0)
            m_PhysicsExplode.DestroyRr(i).MDrang = Me.EFlex1.GetData(i + 1, 1)
            Me.m_PhysicsExplode.DestroyRr(i).Selected = Me.EFlex1.GetData(i + 1, 2)
        Next
    End Sub

    Private Sub _Box_1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub CTextStep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CTextStep.Validating
        Me.m_PhysicsExplode.Tstep = Me.CTextStep.Value
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtLeakSourceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeakSourceName.TextChanged

    End Sub

    Private Sub txtLeakSourceName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        m_PhysicsExplode.SourceName = txtLeakSourceName.Text
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        m_PhysicsExplode.Name = txtName.Text
    End Sub


    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        Me.m_PhysicsExplode.SoucePoint.x = txtX.Value
    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        Me.m_PhysicsExplode.SoucePoint.y = txtY.Value
    End Sub



    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        Me.m_PhysicsExplode.ExplodeType = cmbType.SelectedIndex
        Me.Panel1.Visible = False
        Me.Panel2.Visible = False
        Me.Panel3.Visible = False
        Me.Panel4.Visible = False
        Me.Panel5.Visible = False
        Select Case cmbType.SelectedIndex
            Case 0
                Me.Panel1.Visible = True
            Case 1
                Me.Panel2.Left = Me.Panel1.Left
                Me.Panel2.Top = Me.Panel1.Top
                Me.Panel2.Visible = True
            Case 2
                Me.Panel3.Left = Me.Panel1.Left
                Me.Panel3.Top = Me.Panel1.Top
                Me.Panel3.Visible = True
            Case 3
                Me.Panel4.Left = Me.Panel1.Left
                Me.Panel4.Top = Me.Panel1.Top
                Me.Panel4.Visible = True
            Case 4
                Me.Panel5.Left = Me.Panel1.Left
                Me.Panel5.Top = Me.Panel1.Top
                Me.Panel5.Visible = True
        End Select

    End Sub

    Private Sub txtPg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPg.Validating
        Me.m_PhysicsExplode.Pg = txtPg.Value
    End Sub

    Private Sub txtVg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVg.TextChanged

    End Sub

    Private Sub txtVg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVg.Validating
        Me.m_PhysicsExplode.Vg = txtVg.Value
    End Sub

    Private Sub txtKg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtKg.Validating
        Me.m_PhysicsExplode.kg = txtKg.Value
    End Sub

    Private Sub txtCs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPs.TextChanged

    End Sub

    Private Sub txtVs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVs.TextChanged

    End Sub

    Private Sub txtVs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVs.Validating
        Me.m_PhysicsExplode.Vs = txtVs.Value
    End Sub

    Private Sub txtPl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPl.TextChanged

    End Sub

    Private Sub txtPl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPl.Validating
        Me.m_PhysicsExplode.Pl = txtPl.Value
    End Sub

    Private Sub txtVl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVl.TextChanged

    End Sub

    Private Sub txtVl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVl.Validating
        Me.m_PhysicsExplode.Vl = txtVl.Value
    End Sub

    Private Sub txtBt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBt.TextChanged

    End Sub
    Private Sub txtBt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBt.Validating
        Me.m_PhysicsExplode.Bt = txtBt.Value
    End Sub
    Private Sub txtH1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtH1.TextChanged

    End Sub

    Private Sub txtH1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtH1.Validating
        Me.m_PhysicsExplode.H1 = txtH1.Value
    End Sub


    Private Sub txtH2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtH2.TextChanged

    End Sub

    Private Sub txtH2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtH2.Validating
        Me.m_PhysicsExplode.H2 = txtH2.Value
    End Sub

    Private Sub txtS1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS1.TextChanged

    End Sub

    Private Sub txtS1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS1.Validating
        Me.m_PhysicsExplode.S1 = txtS1.Value
    End Sub

    Private Sub txtS2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS2.TextChanged

    End Sub

    Private Sub txtS2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS2.Validating
        Me.m_PhysicsExplode.S2 = txtS2.Value
    End Sub

    Private Sub txtW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtW.TextChanged

    End Sub

    Private Sub txtW_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtW.Validating
        Me.m_PhysicsExplode.W = txtW.Value
    End Sub


    Private Sub txtVw_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVw.TextChanged

    End Sub

    Private Sub txtVw_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVw.Validating
        Me.m_PhysicsExplode.Vw = txtVw.Value
    End Sub

    Private Sub txtCw_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPw.TextChanged

    End Sub

    Private Sub txtCw_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPw.Validating
        Me.m_PhysicsExplode.Pw = txtPw.Value
    End Sub

    Private Sub txtCs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPs.Validating
        Me.m_PhysicsExplode.Ps = txtPs.Value
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