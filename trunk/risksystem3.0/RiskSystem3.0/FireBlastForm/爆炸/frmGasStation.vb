Imports DataLib
Public Class frmGasStation

    Private m_GasStation As New FireBlast.GasStation '用TNT当量法进行计算的对象
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
    Property GasStation() As FireBlast.GasStation
        Get
            Return Me.m_GasStation
        End Get
        Set(ByVal value As FireBlast.GasStation)
            Me.m_GasStation = value
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
        '在数据库中查找数据，并导入 
        Dim frmNew As New frmSearchData
        frmNew.txtHc.Visible = True

        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtHc.Text <> "" Then
                Me.m_GasStation.Qf = frmNew.txtHc.Text
                Me.txtQf.Text = frmNew.txtHc.Text
            Else
                MsgBox("请手动输入物质的燃烧热！")
            End If
        End If
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
        Dim L As Integer = Me.m_GasStation.DestroyRr.Length
        Me.EFlex1.Rows.Count = L + 1
        For i As Integer = 0 To L - 1
            Me.EFlex1.SetData(1 + i, 0, Me.m_GasStation.DestroyRr(i).MDrangName)
            Me.EFlex1.SetData(1 + i, 1, Me.m_GasStation.DestroyRr(i).MDrang)
            Me.EFlex1.SetData(1 + i, 2, Me.m_GasStation.DestroyRr(i).Selected)
        Next
    End Sub

    ''' <summary>
    ''' 删除表格中的一行数据
    ''' 
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


    Private Sub frmGasStation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化 测试值
        txtLeakSourceName.Text = Me.m_GasStation.SourceName
        Me.txtName.Text = Me.m_GasStation.Name
        Me.txtX.Value = Me.m_GasStation.SoucePoint.x
        Me.txtY.Value = Me.m_GasStation.SoucePoint.y

        txta.Value = Me.m_GasStation.a
        Me.txtQf.Value = Me.m_GasStation.Qf
        txtWf.Value = Me.m_GasStation.Wf

        CTextStep.Value = Me.m_GasStation.Tstep
        CTextCount.Value = Me.m_GasStation.Tcount
        '设置提示
        SetTip()
        '修改的代码－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        '初始化数据
        '设置范围
        txtMinX.Value = m_Grid.MinX
        txtMaxX.Value = m_Grid.MaxX
        txtMinY.Value = m_Grid.MinY
        txtMaxY.Value = m_Grid.MaxY
        '按公式法计算
        CheckFormula.Checked = Me.m_GasStation.FormulaChecked
        Me.UpdateDistance() '更新
        UpdateDestroyR() '更新超压数据
    End Sub

    Private Sub cmdDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frmNewMainForm As New MainForm
        'Dim i As Short
        'If NZ > 0 Then  '如果半径个数不为0
        '    frmNewMainForm.SourceName = txtLeakSourceName.Text
        '    frmNewMainForm.ChartType = 1 '图表类型为伤害半径
        '    frmNewMainForm.NZ = NZ
        '    ReDim frmNewMainForm.ArrayHurtName(NZ - 1)
        '    ReDim frmNewMainForm.ArrayHurtValue(NZ - 1)
        '    ReDim frmNewMainForm.ContourValue(NZ - 1)
        '    For i = 0 To NZ - 1
        '        frmNewMainForm.ArrayHurtName(i) = PaintCircleName(i)
        '        frmNewMainForm.ArrayHurtValue(i) = PaintCircle(i)
        '        frmNewMainForm.ContourValue(i) = PaintCircle(i)
        '    Next
        '    frmNewMainForm.Title = "蒸汽云爆炸(TNT当量法)模型伤害范围"
        '    frmNewMainForm.ShowDialog()
        'Else
        '    MsgBox("请先计算后再绘图!", MsgBoxStyle.Information)
        'End If
    End Sub
    '增加一行数据
    Private Sub cmdDamageAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageAdd.Click
        ReDim Preserve Me.m_GasStation.DestroyRr(Me.m_GasStation.DestroyRr.Length) '长度增加1
        Me.m_GasStation.DestroyRr(Me.m_GasStation.DestroyRr.Length - 1) = New FireBlast.Drang  '创建一个对象
        UpdateDestroyR()
    End Sub

    Private Sub cmdDamageDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDamageDelete.Click
        '删除预测列表
        Dim index As Integer = Me.EFlex1.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_GasStation.DestroyRr.Length - 2
                Me.m_GasStation.DestroyRr(i) = Me.m_GasStation.DestroyRr(i + 1)
            Next
            ReDim Preserve Me.m_GasStation.DestroyRr(0 To Me.m_GasStation.DestroyRr.Length - 2)

        End If
        UpdateDestroyR()
    End Sub

    Private Sub txtDamageName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        '根据用户输入修改列表内容
        'Dim i As Short
        'i = listResult.SelectedIndex
        'If i >= 4 Then
        '    Me.listResult.Items(i) = txtDamageName.Text
        'End If
        ''设置错误提示
        'If listResult.SelectedIndex >= 4 Then
        '    If txtDamageName.Text = "" Then
        '        ErrorProvider1.SetError(txtDamageName, "请输入损害后果的名称")
        '    Else
        '        ErrorProvider1.SetError(txtDamageName, "")
        '    End If
        'Else
        '    ErrorProvider1.SetError(txtDamageName, "")
        'End If
    End Sub

    Private Sub txtDamageQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ''根据用户输入修改列表数组中数据
        'Dim i As Short
        'i = listResult.SelectedIndex
        'If i >= 4 Then
        '    Me.ListDamageQ.Items(i) = txtDamageQ.Text
        'End If
        ''设置错误提示
        'If listResult.SelectedIndex >= 4 Then
        '    If Not IsNumeric(txtDamageQ.Text) Then
        '        ErrorProvider1.SetError(txtDamageQ, "您输入的不是数值")
        '    ElseIf txtDamageQ.Text <= 0 Then
        '        ErrorProvider1.SetError(txtDamageQ, "您输入数值必须>0")
        '    Else
        '        ErrorProvider1.SetError(txtDamageQ, "")
        '    End If
        'Else
        '    ErrorProvider1.SetError(txtDamageQ, "")
        'End If
    End Sub

    Private Sub listResult_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim now_Renamed As Short
        'now_Renamed = listResult.SelectedIndex
        'If now_Renamed >= 4 Then
        '    txtDamageName.Text = Me.listResult.Items(now_Renamed).ToString
        '    txtDamageQ.Text = Me.ListDamageQ.Items(now_Renamed).ToString
        'Else
        '    txtDamageName.Text = ""
        '    txtDamageQ.Text = ""
        'End If
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveGasStation() '保存
    End Sub
    Public Sub SaveGasStation() '保存
        'Dim SaveFileDialog1 As New SaveFileDialog
        'Dim sFile As String
        'Dim strNameLast As String
        'If CheckIsSaved.Checked = False Then
        '    With SaveFileDialog1
        '        .Filter = "安全评价模拟系统文件 (*.sms)|*.sms"
        '        .ShowDialog()
        '        If Len(.FileName) = 0 Then
        '            Exit Sub
        '        End If
        '        sFile = .FileName
        '    End With
        '    '保存文件名
        '    Me.FileName.Text = sFile
        '    strNameLast = GetFileName(sFile)
        '    Me.Text = "蒸汽云爆炸模型预测(TNT当量法)--" & strNameLast
        '    OutPutGasStation(sFile)
        'Else
        '    sFile = Me.FileName.Text
        '    OutPutGasStation(sFile)
        '    '保存文件
        'End If
    End Sub
    Private Sub OutPutGasStation(ByRef sFileName As String) '导出GasStation（TNT模型）预测数据
        'Dim i As Short
        'i = 0
        'FileOpen(1, sFileName, OpenMode.Output)
        'PrintLine(1, "GasStation")
        'CheckIsSaved.Checked = True
        'PrintLine(1, CheckIsSaved.Checked)
        'PrintLine(1, txtLeakSourceName.Text)
        'PrintLine(1, txtName.Text)
        'PrintLine(1, txtWf.Text)
        'PrintLine(1, txtQf.Text)
        'PrintLine(1, txta.Text)
        ''PrintLine(1, listForecastPoint.Items.Count)
        ''For i = 0 To listForecastPoint.Items.Count - 1 Step 1
        ''    PrintLine(1, listForecastPoint.Items(i))
        ''    PrintLine(1, listForecastL.Items(i))
        ''Next i
        'PrintLine(1, listResult.Items.Count)
        'For i = 0 To listResult.Items.Count - 1
        '    PrintLine(1, listResult.Items(i))
        '    PrintLine(1, listResult.GetItemChecked(i))
        '    PrintLine(1, ListDamageQ.Items(i))
        'Next i
        'PrintLine(1, chkReflect.Checked)
        'FileClose(1)
    End Sub
    Public Sub InPutGasStation(ByRef sFileName As String) '导入GasStation（TNT模型）预测数据
        'Dim i, count As Short
        'Dim strValue As String = ""
        'Dim boolValue As Boolean = False
        'i = 0
        'FileOpen(1, sFileName, OpenMode.Input)
        'Input(1, "GasStation")
        'Input(1, CheckIsSaved.Checked)
        'Input(1, txtLeakSourceName.Text)
        'Input(1, txtName.Text)
        'Input(1, txtWf.Text)
        'Input(1, txtQf.Text)
        'Input(1, txta.Text)
        'Input(1, count)
        'For i = 0 To count - 1 Step 1
        '    Input(1, strValue)
        '    'listForecastPoint.Items.Add(strValue)
        '    Input(1, strValue)
        '    'listForecastL.Items.Add(strValue)
        'Next i
        'Input(1, count)
        'listResult.Items.Clear()
        'ListDamageQ.Items.Clear()
        'For i = 0 To count - 1
        '    Input(1, strValue)
        '    listResult.Items.Add(strValue)
        '    Input(1, boolValue)
        '    listResult.SetItemChecked(i, boolValue)
        '    Input(1, strValue)
        '    ListDamageQ.Items.Add(strValue)
        'Next i
        'Input(1, chkReflect.Checked)
        'FileClose(1)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SetTip()
        ToolTip1.SetToolTip(txtWf, ">0的数值")
        ToolTip1.SetToolTip(txtQf, ">0的数值")
        ToolTip1.SetToolTip(txta, ">0且<100的数值")
        ' ToolTip1.SetToolTip(txtDamageQ, "相应的损害后果对应的热辐射通量，为>0的数值。")
    End Sub

    Private Sub txtWf_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWf.TextChanged

    End Sub

    Private Sub txtWf_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWf.Validated

    End Sub

    Private Sub txtWf_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtWf.Validating
        Me.m_GasStation.Wf = txtWf.Value
    End Sub

    Private Sub txtQf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQf.TextChanged

    End Sub

    Private Sub txtQf_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQf.Validating
        Me.m_GasStation.Qf = txtQf.Value
    End Sub

    Private Sub txta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txta.TextChanged

    End Sub

    Private Sub txta_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txta.Validating
        Me.m_GasStation.a = txta.Value
    End Sub

    Private Sub EFlexDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EFlexDistance.Click

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
        Me.m_GasStation.Tstep = Me.CTextStep.Value

    End Sub

    Private Sub CTextCount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CTextCount.Validating
        Me.m_GasStation.Tcount = Me.CTextCount.Value


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
        ReDim Me.m_GasStation.DestroyRr(0 To L - 1)
        For i As Integer = 0 To L - 1
            m_GasStation.DestroyRr(i) = New FireBlast.Drang

            Me.m_GasStation.DestroyRr(i).MDrangName = Me.EFlex1.GetData(i + 1, 0)
            m_GasStation.DestroyRr(i).MDrang = Me.EFlex1.GetData(i + 1, 1)
            Me.m_GasStation.DestroyRr(i).Selected = Me.EFlex1.GetData(i + 1, 2)
        Next
    End Sub

    Private Sub _Box_1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub CTextStep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CTextStep.Validating
        Me.m_GasStation.Tstep = Me.CTextStep.Value
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


    Private Sub txtLeakSourceName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        m_GasStation.SourceName = txtLeakSourceName.Text
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        m_GasStation.Name = txtName.Text
    End Sub


    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        Me.m_GasStation.SoucePoint.x = txtX.Value
    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        Me.m_GasStation.SoucePoint.y = txtY.Value
    End Sub

    Private Sub CTextCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTextCount.TextChanged

    End Sub

    Private Sub txtLeakSourceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeakSourceName.TextChanged

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

    Private Sub CheckFormula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFormula.CheckedChanged
        Me.m_GasStation.FormulaChecked = CheckFormula.Checked
    End Sub
End Class