Public Class frmRisk
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

    Private Sub frmRisk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EFlexRisk.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
    End Sub

    ''' <summary>
    ''' 关心点的标题
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshRisk()
        '更新图表
        EFlexRisk.Clear() '清空所有
        EFlexRisk.Rows.Count = 1
        With EFlexRisk
            .Cols.Count = 9   '设置列数
            .SetData(0, 0, "序号") '
            .SetData(0, 1, "事故概率") '设置风向
            .SetData(0, 2, "出现时刻") '
            .SetData(0, 3, "风向")
            .SetData(0, 4, "风速")
            .SetData(0, 5, "稳定度")
            .SetData(0, 6, "气象概率")
            .SetData(0, 7, "死亡人数")
            .SetData(0, 8, "风险值[/a]")
        End With
        EFlexRisk.Rows.Count = Project0.Dis0.Forecast.Met.Length + 3
        For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
            With EFlexRisk
                .SetData(i + 1, 0, i + 1) '设置序号
                .SetData(i + 1, 1, Project0.Dis0.IntialSource.Probability) '时间
                .SetData(i + 1, 2, Project0.Dis0.Forecast.Met(i).m_DateTime.ToString)
                Dim WindSpeed As Double = Project0.Dis0.Forecast.Met(i).WindSpeed
                If WindSpeed >= 0.3 Then
                    .SetData(i + 1, 3, Project0.Dis0.Forecast.Met(i).WindDer) '设置风向
                    .SetData(i + 1, 4, Project0.Dis0.Forecast.Met(i).WindSpeed)
                Else
                    .SetData(i + 1, 3, "C") '设置风向
                    .SetData(i + 1, 4, 0)
                End If
                .SetData(i + 1, 5, Project0.Dis0.Forecast.Met(i).Stab)
                .SetData(i + 1, 6, Project0.Dis0.Forecast.Met(i).Frequency)
                .SetData(i + 1, 7, Project0.Dis0.Results.AllGridResult.DiePeople(i))
                .SetData(i + 1, 8, Project0.Dis0.Results.AllGridResult.ArrayRisk(i) * Project0.Dis0.IntialSource.Probability)
            End With
        Next
        With EFlexRisk
            .SetData(Project0.Dis0.Forecast.Met.Length + 2, 1, Project0.Dis0.IntialSource.Probability) '时间
            .SetData(Project0.Dis0.Forecast.Met.Length + 2, 2, "全部")
            .SetData(Project0.Dis0.Forecast.Met.Length + 2, 8, Project0.Dis0.Results.AllGridResult.AllRisk * Project0.Dis0.IntialSource.Probability)
        End With
        EFlexRisk.AutoSizeCols()

    End Sub
    Private Sub frmCareCon_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.m_ReLoad = True Then
            RefreshRisk()
            '将重新载入标志设置
            Me.m_ReLoad = False
        End If
    End Sub

End Class