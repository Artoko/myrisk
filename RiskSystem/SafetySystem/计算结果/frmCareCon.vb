Public Class frmCareCon
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
    Private Sub frmCareCon_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.m_ReLoad = True Then
            RefreshCareCon()
            '添加关心点
            Me.cmbCare.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.CareReceptor.Length - 1
                Me.cmbCare.Items.Add(Project0.Dis0.Forecast.CareReceptor(i).Name)
            Next
            Me.cmbCare.Items.Add("所有关心点")
            '添加气象条件
            Me.cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                Me.cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            Me.cmbMet.Items.Add("所有气象条件")

            '添加预测时刻
            cmbCare.SelectedIndex = cmbCare.Items.Count - 1
            cmbMet.SelectedIndex = cmbMet.Items.Count - 1
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
    ''' 关心点的标题
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshCareCon()
        '更新图表
        EFlexGeneral.Clear() '清空所有
        EFlexGeneral.Rows.Count = 1
        With EFlexGeneral
            .Cols.Count = 9 + Project0.Dis0.Forecast.OutPut.ForeCount  '设置列数
            .SetData(0, 0, "序号") '设置序号
            .SetData(0, 1, "关心点(x,y,z)")
            .SetData(0, 2, "风向") '设置风向
            .SetData(0, 3, "风速[m/s]")
            .SetData(0, 4, "稳定度")

            For n As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                .SetData(0, 5 + n, Project0.Dis0.Forecast.OutPut.ForeStart + n * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
            Next
            .SetData(0, 5 + Project0.Dis0.Forecast.OutPut.ForeCount, "死亡概率")
            .SetData(0, 6 + Project0.Dis0.Forecast.OutPut.ForeCount, "死亡率%")
            .SetData(0, 7 + Project0.Dis0.Forecast.OutPut.ForeCount, "滑移平均最大浓度")
            .SetData(0, 8 + Project0.Dis0.Forecast.OutPut.ForeCount, "出现的时间段")
        End With
        EFlexGeneral.AutoSizeCols()

    End Sub
    ''' <summary>
    ''' 根据用户选择更新结果
    ''' </summary>
    ''' <param name="i">选择的关心点</param>
    ''' <param name="j">选择的气象条件</param>
    ''' <param name="num">选择的位数</param>
    ''' <remarks></remarks>
    Private Sub ChangeResult(ByVal i As Integer, ByVal j As Integer, ByVal num As Integer)

        EFlexGeneral.Rows.Count = 1
        With EFlexGeneral
            For iCare As Integer = 0 To Project0.Dis0.Forecast.CareReceptor.Length - 1
                If i = iCare Or i = cmbCare.Items.Count - 1 Then
                    For jMet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1

                        If j = jMet Or j = cmbMet.Items.Count - 1 Then
                            .Rows.Count += 1
                            .SetData(.Rows.Count - 1, 0, .Rows.Count - 1) '序号
                            .SetData(.Rows.Count - 1, 1, Project0.Dis0.Forecast.CareReceptor(iCare).Name & "(" & Project0.Dis0.Forecast.CareReceptor(iCare).Point3D.x & "," & Project0.Dis0.Forecast.CareReceptor(iCare).Point3D.y & "," & Project0.Dis0.Forecast.CareReceptor(iCare).Point3D.z & ")")
                            .SetData(.Rows.Count - 1, 2, Project0.Dis0.Forecast.Met(jMet).Vane) '设置风向
                            .SetData(.Rows.Count - 1, 3, FormatNumber(Project0.Dis0.Forecast.Met(jMet).WindSpeed, 4, TriState.True, TriState.False, TriState.False))
                            .SetData(.Rows.Count - 1, 4, Project0.Dis0.Forecast.Met(jMet).Stab)
                            For n As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                                .SetData(.Rows.Count - 1, 5 + n, FormatNumber(Project0.Dis0.Results.AllCareResult.InstantaneousCareC(jMet, n, iCare), num, TriState.True, TriState.False, TriState.False))
                            Next
                            .SetData(.Rows.Count - 1, 5 + Project0.Dis0.Forecast.OutPut.ForeCount, FormatNumber(Project0.Dis0.Results.AllCareResult.Pr(jMet, iCare), num, TriState.True, TriState.False, TriState.False))
                            .SetData(.Rows.Count - 1, 6 + Project0.Dis0.Forecast.OutPut.ForeCount, FormatNumber(Project0.Dis0.Results.AllCareResult.D(jMet, iCare), num, TriState.True, TriState.False, TriState.False))
                            .SetData(.Rows.Count - 1, 7 + Project0.Dis0.Forecast.OutPut.ForeCount, FormatNumber(Project0.Dis0.Results.AllCareResult.SlipCare(jMet, iCare).MaxCon, num, TriState.True, TriState.False, TriState.False))

                            .SetData(.Rows.Count - 1, 8 + Project0.Dis0.Forecast.OutPut.ForeCount, Project0.Dis0.Results.AllCareResult.SlipCare(jMet, iCare).StartAndEndTimeTime.GetStartAndEndTimeTostring)

                        End If

                    Next
                End If

            Next

        End With
        EFlexGeneral.AutoSizeCols()
        RefreshCare(i, j)
    End Sub

    Private Sub cmbMet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMet.SelectedIndexChanged
        Dim i As Integer = cmbCare.SelectedIndex
        Dim j As Integer = cmbMet.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, j, num)
    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNum.SelectedIndexChanged
        Dim i As Integer = cmbCare.SelectedIndex
        Dim j As Integer = cmbMet.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, j, num)
    End Sub
    ''' <summary>
    ''' 关心点
    ''' </summary>
    ''' <param name="i"></param>
    ''' <param name="j"></param>
    ''' <remarks></remarks>
    Private Sub RefreshCare(ByVal i As Integer, ByVal j As Integer)
        TChart1.Series.Clear() '清除所有

        For iCare As Integer = 0 To Project0.Dis0.Forecast.CareReceptor.Length - 1
            If i = iCare Or i = cmbCare.Items.Count - 1 Then
                For jMet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1

                    If j = jMet Or j = cmbMet.Items.Count - 1 Then
                        Dim s As New Steema.TeeChart.Styles.Line
                        Dim a(0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1) As Double '数组长度=预测时间的个数
                        Dim b(0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1) As Double '数组长度=预测时间的个数
                        For k As Integer = 0 To a.Length - 1
                            a(k) = Project0.Dis0.Forecast.OutPut.ForeStart + k * Project0.Dis0.Forecast.OutPut.ForeInterval
                            b(k) = Project0.Dis0.Results.AllCareResult.InstantaneousCareC(jMet, k, iCare)
                        Next
                        s.Add(a, b)
                        s.Title = Project0.Dis0.Forecast.CareReceptor(iCare).Name & "," _
                                             & Project0.Dis0.Forecast.Met(jMet).Vane & "," _
                                             & Project0.Dis0.Forecast.Met(jMet).WindSpeed _
                                             & "," & Project0.Dis0.Forecast.Met(jMet).Stab

                        TChart1.Series.Add(s)
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub cmbCare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCare.SelectedIndexChanged
        Dim i As Integer = cmbCare.SelectedIndex
        Dim j As Integer = cmbMet.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, j, num)
    End Sub
    Private Sub 复制CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制CToolStripMenuItem.Click
        Me.TChart1.Export.Image.JPEG.CopyToClipboard()
    End Sub

    Private Sub 设置SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置SToolStripMenuItem.Click
        TChart1.ShowEditor()
    End Sub
End Class