Public Class frmVaneMax
    Private m_ReLoad As Boolean = False
    ''' <summary>
    ''' 是否重新载入数据的标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ReLoad() As Boolean
        Get
            Return Me.m_ReLoad
        End Get
        Set(ByVal value As Boolean)
            Me.m_ReLoad = value
        End Set
    End Property
    Private Sub frmVaneMax_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.m_ReLoad = True Then
            RefreshVaneMax()
            '添加结果表述
            Me.cmbRusult.Items.Clear()
            Me.cmbRusult.Items.Add("瞬时浓度")
            If Project0.Dis0.Forecast.OutPut.IsRisk And Project0.Dis0.Forecast.OutPut.ChargeOrSlip = 1 Then
                Me.cmbRusult.Items.Add("滑移平均最大浓度")
            End If
            '添加气象条件
            Me.cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                Me.cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            Me.cmbMet.Items.Add("所有气象条件")

            '添加预测时刻
            Me.cmbTime.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                Me.cmbTime.Items.Add(Project0.Dis0.Forecast.OutPut.ForeStart + i * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
            Next
            Me.cmbTime.Items.Add("所有预测时间")
            cmbRusult.SelectedIndex = 0
            cmbMet.SelectedIndex = cmbMet.Items.Count - 1
            cmbTime.SelectedIndex = cmbTime.Items.Count - 1
            cmbNum.SelectedIndex = 1
            cmbMet_SelectedIndexChanged(sender, e)

            '将重新载入标志设置
            Me.m_ReLoad = False
        End If
    End Sub
    Private Sub frmMax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EFlexGeneral.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
    End Sub
    ''' <summary>
    ''' 下风向浓度分布的标题
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshVaneMax()
        '更新图表
        EFlexGeneral.Clear() '清空所有
        EFlexGeneral.Rows.Count = 1
        With EFlexGeneral
            .Cols.Count = 20 + Project0.Dis0.Forecast.HurtConcentration.Length  '设置列数
            .SetData(0, 0, "序号") '设置序号
            .SetData(0, 1, "风向") '设置风向
            .SetData(0, 2, "风速[m/s]")
            .SetData(0, 3, "稳定度")
            .SetData(0, 4, "泄漏口高度[m]") '设置序号
            .SetData(0, 5, "泄漏口处风速[m/s]") '设置序号
            .SetData(0, 6, "泄漏速率[kg/s]") '设置泄漏口速率
            .SetData(0, 7, "预测时刻[min]")

            Select Case Project0.Dis0.IntialSource.LeakType

                Case 0, 3, 10, 11, 12 '气体泄漏
                    .SetData(0, 8, "最大浓度[mg/m^3]") '最大浓度
                    .SetData(0, 9, "最大浓度出现的距离[m]") '最大浓度出现的距离
                    '根据伤害范围的个数设置标题

                    For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                        .SetData(0, 10 + n, Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围[m]")
                    Next
                    If Project0.Dis0.IsCalUpVane Then
                        For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                            .SetData(0, 13 + n, "上风向" & Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围[m]")
                        Next
                    End If
                Case 1, 2, 4 '液体泄漏或两相流泄漏
                    .SetData(0, 8, "泄漏口闪蒸挥发速率[kg/s]")
                    .SetData(0, 9, "液池有效高度[m]")
                    .SetData(0, 10, "液池蒸发平均速率[kg/s]")
                    .SetData(0, 11, "最大浓度[mg/m^3]") '最大浓度
                    .SetData(0, 12, "最大浓度出现的距离[m]") '最大浓度出现的距离
                    '下风向浓度限值
                    For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                        .SetData(0, 13 + n, Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围[m]")
                    Next
                    '上风向
                    If Project0.Dis0.IsCalUpVane Then
                        For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                            .SetData(0, 13 + n, "上风向" & Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围[m]")
                        Next
                    End If
            End Select
        End With
        EFlexGeneral.AutoSizeCols()
    End Sub
    ''' <summary>
    ''' 根据用户选择更新结果
    ''' </summary>
    ''' <param name="i">选择的气象条件</param>
    ''' <param name="j">选择的预测时刻</param>
    ''' <param name="num">选择的位数</param>
    ''' <remarks></remarks>
    Private Sub ChangeResult(ByVal strResult As String, ByVal i As Integer, ByVal j As Integer, ByVal num As Integer)
        If strResult = "瞬时浓度" Then
            EFlexGeneral.Rows.Count = 1
            With EFlexGeneral
                For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    For jTime As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                        If i = imet Or i = cmbMet.Items.Count - 1 Then
                            If j = jTime Or j = cmbTime.Items.Count - 1 Then
                                .Rows.Count += 1
                                .SetData(.Rows.Count - 1, 0, .Rows.Count - 1) '序号
                                .SetData(.Rows.Count - 1, 1, Project0.Dis0.Forecast.Met(imet).Vane) '设置风向
                                .SetData(.Rows.Count - 1, 2, FormatNumber(Project0.Dis0.Forecast.Met(imet).WindSpeed, 4, TriState.True, TriState.False, TriState.False))
                                .SetData(.Rows.Count - 1, 3, Project0.Dis0.Forecast.Met(imet).Stab)
                                .SetData(.Rows.Count - 1, 4, Project0.Dis0.Sources(0).PLeak.H)
                                .SetData(.Rows.Count - 1, 5, FormatNumber(Project0.Dis0.Forecast.Met(imet).u2, 4, TriState.True, TriState.False, TriState.False))
                                .SetData(.Rows.Count - 1, 6, FormatNumber(Project0.Dis0.Sources(0).PLeak.Q / 1000000, 5, TriState.True, TriState.False, TriState.False)) '设置泄漏口速率,所有的速率
                                .SetData(.Rows.Count - 1, 7, Project0.Dis0.Forecast.OutPut.ForeStart + Project0.Dis0.Forecast.OutPut.ForeInterval * jTime) '

                                Select Case Project0.Dis0.IntialSource.LeakType
                                    Case 0, 3, 10, 11, 12 '气体泄漏
                                        .SetData(.Rows.Count - 1, 8, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).MaxConAndDistance.MaxCon, num, TriState.True, TriState.False, TriState.False)) '设置泄漏口速率,所有的速率
                                        .SetData(.Rows.Count - 1, 9, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).MaxConAndDistance.MaxDistance, num, TriState.True, TriState.False, TriState.False)) '设置泄漏口速率,所有的速率

                                        For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                                            .SetData(.Rows.Count - 1, 10 + n, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).HurtLength(n), num, TriState.True, TriState.False, TriState.False))
                                        Next
                                        If Project0.Dis0.IsCalUpVane Then
                                            For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                                                .SetData(0, 13 + n, "上风向" & Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围[m]")
                                            Next
                                        End If
                                    Case 1, 2, 4 '液体泄漏或两相流泄漏
                                        .SetData(.Rows.Count - 1, 8, FormatNumber(Project0.Dis0.Sources(imet).PLeak.Q / 1000000, 5, TriState.True, TriState.False, TriState.False)) '泄漏口挥发的速率
                                        .SetData(.Rows.Count - 1, 9, FormatNumber(Project0.Dis0.Sources(imet).SLeak.He, 4, TriState.True, TriState.False, TriState.False)) '液池有效高度
                                        .SetData(.Rows.Count - 1, 10, FormatNumber(Project0.Dis0.Sources(imet).SLeak.Q / 1000000, 5, TriState.True, TriState.False, TriState.False)) '液池蒸发平均速率[kg/s]
                                        .SetData(.Rows.Count - 1, 11, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).MaxConAndDistance.MaxCon, num, TriState.True, TriState.False, TriState.False))
                                        .SetData(.Rows.Count - 1, 12, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).MaxConAndDistance.MaxDistance, num, TriState.True, TriState.False, TriState.False))

                                        For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                                            .SetData(.Rows.Count - 1, 13 + n, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).HurtLength(n), num, TriState.True, TriState.False, TriState.False))
                                        Next
                                        If Project0.Dis0.IsCalUpVane Then
                                            For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                                                .SetData(0, 13 + n, "上风向" & Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围[m]")
                                            Next
                                        End If
                                End Select
                            End If
                        End If
                    Next
                Next

            End With
        ElseIf strResult = "滑移平均最大浓度" Then
            EFlexGeneral.Rows.Count = 1
            With EFlexGeneral
                For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    If i = imet Or i = cmbMet.Items.Count - 1 Then
                        .Rows.Count += 1
                        .SetData(.Rows.Count - 1, 0, .Rows.Count - 1) '序号
                        .SetData(.Rows.Count - 1, 1, Project0.Dis0.Forecast.Met(imet).Vane) '设置风向
                        .SetData(.Rows.Count - 1, 2, FormatNumber(Project0.Dis0.Forecast.Met(imet).WindSpeed, 4, TriState.True, TriState.False, TriState.False))
                        .SetData(.Rows.Count - 1, 3, Project0.Dis0.Forecast.Met(imet).Stab)
                        .SetData(.Rows.Count - 1, 4, Project0.Dis0.Sources(0).PLeak.H)
                        .SetData(.Rows.Count - 1, 5, FormatNumber(Project0.Dis0.Forecast.Met(imet).u2, 4, TriState.True, TriState.False, TriState.False))
                        .SetData(.Rows.Count - 1, 6, FormatNumber(Project0.Dis0.Sources(0).PLeak.Q / 1000000, 5, TriState.True, TriState.False, TriState.False)) '设置泄漏口速率,所有的速率
                        .SetData(.Rows.Count - 1, 7, "---") '

                        Select Case Project0.Dis0.IntialSource.LeakType
                            Case 0, 3, 10, 11, 12 '气体泄漏
                                .SetData(.Rows.Count - 1, 8, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.MaxConAndDistanceSlip.MaxCon, num, TriState.True, TriState.False, TriState.False))
                                .SetData(.Rows.Count - 1, 9, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.MaxConAndDistanceSlip.MaxDistance, num, TriState.True, TriState.False, TriState.False))
                                For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                                    .SetData(.Rows.Count - 1, 10 + n, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.HurtLengthSlip(n), num, TriState.True, TriState.False, TriState.False))
                                Next
                            Case 1, 2, 4 '液体泄漏或两相流泄漏
                                .SetData(.Rows.Count - 1, 8, FormatNumber(Project0.Dis0.Sources(imet).PLeak.Q / 1000000, 5, TriState.True, TriState.False, TriState.False)) '泄漏口挥发的速率
                                .SetData(.Rows.Count - 1, 9, FormatNumber(Project0.Dis0.Sources(imet).SLeak.He, 4, TriState.True, TriState.False, TriState.False)) '液池有效高度
                                .SetData(.Rows.Count - 1, 10, FormatNumber(Project0.Dis0.Sources(imet).SLeak.Q / 1000000, 5, TriState.True, TriState.False, TriState.False)) '液池蒸发平均速率[kg/s]
                                .SetData(.Rows.Count - 1, 11, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.MaxConAndDistanceSlip.MaxCon, num, TriState.True, TriState.False, TriState.False))
                                .SetData(.Rows.Count - 1, 12, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.MaxConAndDistanceSlip.MaxDistance, num, TriState.True, TriState.False, TriState.False))
                                For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                                    .SetData(.Rows.Count - 1, 13 + n, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.HurtLengthSlip(n), num, TriState.True, TriState.False, TriState.False))
                                Next
                        End Select
                    End If
                Next
            End With
        End If

        EFlexGeneral.AutoSizeCols()
    End Sub

    Private Sub cmbMet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMet.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim j As Integer = cmbTime.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(cmbRusult.Text, i, j, num)
    End Sub

    Private Sub cmbTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTime.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim j As Integer = cmbTime.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(cmbRusult.Text, i, j, num)
    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNum.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim j As Integer = cmbTime.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(cmbRusult.Text, i, j, num)
    End Sub

    Private Sub cmbRusult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRusult.Click

    End Sub

    Private Sub cmbRusult_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRusult.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim j As Integer = cmbTime.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(cmbRusult.Text, i, j, num)
        If cmbRusult.SelectedIndex = 0 Then
            cmbTime.Enabled = True
        ElseIf cmbRusult.SelectedIndex = 1 Then
            cmbTime.Enabled = False
        End If
    End Sub

    Private Sub cmbMet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMet.Click

    End Sub
End Class
