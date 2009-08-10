Public Class frmVane
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
            If Project0.Dis0.Forecast.OutPut.IsRisk = True And Project0.Dis0.Forecast.OutPut.ChargeOrSlip = 1 Then
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
        EFlexGeneral.Rows.Count = Project0.Dis0.Forecast.Vane.VaneCount + 2
        EFlexGeneral.Cols.Count = 1
        EFlexGeneral.SetData(0, 0, "下风向距离[m]") '设置序号
        For nn As Integer = 0 To Project0.Dis0.Forecast.Vane.VaneCount  '按距离给出浓度
            EFlexGeneral.SetData(nn + 1, 0, Project0.Dis0.Forecast.Vane.VaneStep * nn) '设置泄漏口速率,所有的速率
        Next
        EFlexGeneral.AutoSizeCols()
    End Sub
    ''' <summary>
    ''' 根据用户选择更新结果
    ''' </summary>
    ''' <param name="strResult">结果表述</param>
    ''' <param name="i">选择的气象条件</param>
    ''' <param name="j">选择的预测时刻</param>
    ''' <param name="num">选择的位数</param>
    ''' <remarks></remarks>
    Private Sub ChangeResult(ByVal strResult As String, ByVal i As Integer, ByVal j As Integer, ByVal num As Integer)
        If strResult = "瞬时浓度" Then
            EFlexGeneral.Cols.Count = 1
            With EFlexGeneral
                For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    For jTime As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                        If i = imet Or i = cmbMet.Items.Count - 1 Then
                            If j = jTime Or j = cmbTime.Items.Count - 1 Then
                                .Cols.Count += 1 '列增加1
                                .SetData(0, .Cols.Count - 1, Project0.Dis0.Forecast.Met(imet).Vane & "," _
                                         & Project0.Dis0.Forecast.Met(imet).WindSpeed _
                                         & "," & Project0.Dis0.Forecast.Met(imet).Stab _
                                         & "," & Project0.Dis0.Forecast.OutPut.ForeStart + jTime * Project0.Dis0.Forecast.OutPut.ForeInterval & "min") '序号
                                For nn As Integer = 0 To Project0.Dis0.Forecast.Vane.VaneCount '按距离给出浓度
                                    .SetData(nn + 1, .Cols.Count - 1, FormatNumber(Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).GridVane(nn), num, TriState.True, TriState.False, TriState.False)) '设置泄漏口速率,所有的速率
                                Next
                            End If
                        End If
                    Next
                Next

            End With
            EFlexGeneral.AutoSizeCols()
            RefreshVane(strResult, i, j) '更新曲线图
        ElseIf strResult = "滑移平均最大浓度" Then
            EFlexGeneral.Cols.Count = 1
            With EFlexGeneral
                For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    If i = imet Or i = cmbMet.Items.Count - 1 Then
                        .Cols.Count += 1 '列增加1
                        .SetData(0, .Cols.Count - 1, Project0.Dis0.Forecast.Met(imet).Vane & "," _
                                 & Project0.Dis0.Forecast.Met(imet).WindSpeed _
                                 & "," & Project0.Dis0.Forecast.Met(imet).Stab) '序号
                        For nn As Integer = 0 To Project0.Dis0.Forecast.Vane.VaneCount '按距离给出浓度
                            .SetData(nn + 1, .Cols.Count - 1, FormatNumber(Project0.Dis0.Results.MetResults(imet).Slip.GridVane(nn), num, TriState.True, TriState.False, TriState.False)) '设置泄漏口速率,所有的速率
                        Next
                    End If
                Next
            End With
            EFlexGeneral.AutoSizeCols()
            RefreshVane(strResult, i, j) '更新曲线图
        End If

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

    ''' <summary>
    ''' 下风向浓度分布
    ''' </summary>
    ''' <param name="i"></param>
    ''' <param name="j"></param>
    ''' <remarks></remarks>
    Public Sub RefreshVane(ByVal strResult As String, ByVal i As Integer, ByVal j As Integer)
        '更新图表
        If strResult = "瞬时浓度" Then
            TChart1.Series.Clear() '清除所有
            For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                For jTime As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                    If i = imet Or i = cmbMet.Items.Count - 1 Then
                        If j = jTime Or j = cmbTime.Items.Count - 1 Then
                            Dim s As New Steema.TeeChart.Styles.Line
                            '光滑结束
                            Dim a(0 To Project0.Dis0.Forecast.Vane.VaneCount) As Double
                            Dim b(0 To Project0.Dis0.Forecast.Vane.VaneCount) As Double
                            For k As Integer = 0 To a.Length - 1
                                a(k) = k * Project0.Dis0.Forecast.Vane.VaneStep
                                b(k) = Project0.Dis0.Results.MetResults(imet).ForeTimeResults(jTime).GridVane(k)
                            Next
                            s.Add(a, b)

                            '光滑
                            s.Title = Project0.Dis0.Forecast.Met(imet).Vane & "," _
                                & Project0.Dis0.Forecast.Met(imet).WindSpeed _
                                & "," & Project0.Dis0.Forecast.Met(imet).Stab _
                                & "," & Project0.Dis0.Forecast.OutPut.ForeStart + jTime * Project0.Dis0.Forecast.OutPut.ForeInterval & "min"
                            TChart1.Series.Add(s)
                            s.Function = smoothing1
                            smoothing1.Recalculate()

                            TChart1.Refresh()
                        End If
                    End If
                Next
            Next
        ElseIf strResult = "滑移平均最大浓度" Then
            TChart1.Series.Clear() '清除所有
            For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                If i = imet Or i = cmbMet.Items.Count - 1 Then
                    Dim s As New Steema.TeeChart.Styles.Line
                    Dim a(0 To Project0.Dis0.Forecast.Vane.VaneCount) As Double
                    Dim b(0 To Project0.Dis0.Forecast.Vane.VaneCount) As Double
                    For k As Integer = 0 To a.Length - 1
                        a(k) = k * Project0.Dis0.Forecast.Vane.VaneStep
                        b(k) = Project0.Dis0.Results.MetResults(imet).Slip.GridVane(k)
                    Next
                    s.Add(a, b)
                    s.Title = Project0.Dis0.Forecast.Met(imet).Vane & "," _
                             & Project0.Dis0.Forecast.Met(imet).WindSpeed _
                             & "," & Project0.Dis0.Forecast.Met(imet).Stab
                    TChart1.Series.Add(s)
                End If
            Next
        End If
    End Sub

    Private Sub 复制CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制CToolStripMenuItem.Click
        Me.TChart1.Export.Image.JPEG.CopyToClipboard()
    End Sub

    Private Sub 设置SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置SToolStripMenuItem.Click
        TChart1.ShowEditor()
    End Sub

    Private Sub cmbRusult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRusult.Click

    End Sub

    Private Sub cmbMet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMet.Click

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
End Class
