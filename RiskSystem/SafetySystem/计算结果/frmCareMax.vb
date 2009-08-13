Public Class frmCareMax
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
            '添加气象条件
            Me.cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).m_DateTime.Year & "年" & Project0.Dis0.Forecast.Met(i).m_DateTime.Month & "月" & Project0.Dis0.Forecast.Met(i).m_DateTime.Day & "日" & Project0.Dis0.Forecast.Met(i).m_DateTime.Hour & "时")
            Next
         
            '添加预测时刻

            cmbMet.SelectedIndex = 0
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
            .Cols.Count = 7 + Project0.Dis0.Forecast.OutPut.ForeCount  '设置列数
            .SetData(0, 0, "序号") '设置序号
            .SetData(0, 1, "风向") '设置风向
            .SetData(0, 2, "风速[m/s]")
            .SetData(0, 3, "稳定度")
            .SetData(0, 4, "关心点(x,y,z)")
            .SetData(0, 5, "最大浓度及出现时刻")

            For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                .SetData(0, 6 + n, Project0.Dis0.Forecast.HurtConcentration(n).Name & "范围")
            Next
        End With
        EFlexGeneral.AutoSizeCols()
    End Sub
    ''' <summary>
    ''' 根据用户选择更新结果
    ''' </summary>
    ''' <param name="i">选择的气象条件</param>
    ''' <param name="num">选择的位数</param>
    ''' <remarks></remarks>
    Private Sub ChangeResult(ByVal i As Integer, ByVal num As Integer)

        EFlexGeneral.Rows.Count = 1
        With EFlexGeneral
            For imet As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                If i = imet Or i = cmbMet.Items.Count - 1 Then
                    For jCare As Integer = 0 To Project0.Dis0.Forecast.CareReceptor.Length - 1
                        .Rows.Count += 1
                        .SetData(.Rows.Count - 1, 0, .Rows.Count - 1) '序号
                        .SetData(.Rows.Count - 1, 1, Project0.Dis0.Forecast.Met(imet).Vane) '设置风向
                        .SetData(.Rows.Count - 1, 2, FormatNumber(Project0.Dis0.Forecast.Met(imet).WindSpeed, 4, TriState.True, TriState.False, TriState.False))
                        .SetData(.Rows.Count - 1, 3, Project0.Dis0.Forecast.Met(imet).Stab)
                        .SetData(.Rows.Count - 1, 4, Project0.Dis0.Forecast.CareReceptor(jCare).Name & "(" & Project0.Dis0.Forecast.CareReceptor(jCare).Point3D.x & "," & Project0.Dis0.Forecast.CareReceptor(jCare).Point3D.y & "," & Project0.Dis0.Forecast.CareReceptor(jCare).Point3D.z & ")")
                        Dim MaxC As Double = Project0.Dis0.Results.AllCareResult.CarePointMaxCT(imet, jCare).MaxC
                        Dim MaxTime As Double = Project0.Dis0.Results.AllCareResult.CarePointMaxCT(imet, jCare).maxT
                        .SetData(.Rows.Count - 1, 5, FormatNumber(MaxC, num, TriState.True, TriState.False, TriState.False) & "mg/m^3 , " & Math.Truncate(MaxTime / 60) & "分" & CInt(MaxTime - Math.Truncate(MaxTime / 60) * 60) & "秒")

                        For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                            Dim starttime As Double = Project0.Dis0.Results.AllCareResult.CarePointTime(imet, jCare, n).StartTime
                            Dim endtime As Double = Project0.Dis0.Results.AllCareResult.CarePointTime(imet, jCare, n).EndTime
                            .SetData(.Rows.Count - 1, 6 + n, Math.Truncate(starttime / 60) & "分" & CInt(starttime - Math.Truncate(starttime / 60) * 60) & "秒 - " & Math.Truncate(endtime / 60) & "分" & CInt(endtime - Math.Truncate(endtime / 60) * 60) & "秒")
                        Next
                    Next
                End If
            Next

        End With
        EFlexGeneral.AutoSizeCols()
    End Sub

    Private Sub cmbMet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMet.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, num)
    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNum.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, num)
    End Sub
End Class