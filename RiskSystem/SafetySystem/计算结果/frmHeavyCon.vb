Public Class frmHeavyCon
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
            '添加气象条件
            Me.cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                Me.cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            cmbMet.SelectedIndex = 0
            cmbTime.SelectedIndex = 4
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
    ''' 根据用户选择更新结果
    ''' </summary>
    ''' <param name="i">选择的气象条件</param>
    ''' <param name="jTimeInter">时间间隔</param>
    ''' <param name="num">选择的位数</param>
    ''' <remarks></remarks>
    Private Sub ChangeResult(ByVal i As Integer, ByVal jTimeInter As Integer, ByVal num As Integer)

        EFlexGeneral.Cols.Count = 9
        EFlexGeneral.Rows.Count = 1
        With EFlexGeneral
            If Project0.Dis0.IntialSource.LeakType = 11 Then '瞬时重气体
                EFlexGeneral.Rows.Count = 1
                .SetData(0, 0, "序号")
                .SetData(0, 1, "时刻[s]")
                .SetData(0, 2, "云团中心位置[m]")
                .SetData(0, 3, "云团半径[m]")
                .SetData(0, 4, "云团高度[m]")
                .SetData(0, 5, "云团体积[m^3]")
                .SetData(0, 6, "云团密度[kg/m^3]")
                .SetData(0, 7, "云团温度[℃]")
                .SetData(0, 8, "污染物浓度[mg/m^3]")
                Dim nMount As Integer = Math.Truncate(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length / (jTimeInter * 10)) + 1
                EFlexGeneral.Rows.Count = nMount + 1 '设置表格的行
                For n As Integer = 0 To nMount - 1
                    If n = nMount - 1 Then
                        .SetData(n + 1, 0, n)
                        .SetData(n + 1, 1, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 2, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t * Project0.Dis0.Forecast.Met(i).WindSpeed, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 3, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_R, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 4, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_H, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 5, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_V, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 6, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_Density, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 7, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_Temp - 273.15, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 8, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_C, num, TriState.True, TriState.False, TriState.False))
                    Else
                        .SetData(n + 1, 0, n)
                        .SetData(n + 1, 1, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_t, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 2, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_t * Project0.Dis0.Forecast.Met(i).WindSpeed, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 3, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_R, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 4, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_H, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 5, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_V, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 6, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_Density, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 7, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_Temp - 273.15, num, TriState.True, TriState.False, TriState.False))
                        .SetData(n + 1, 8, FormatNumber(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * jTimeInter * 10).m_C, num, TriState.True, TriState.False, TriState.False))
                    End If
                Next
            End If
        End With
        EFlexGeneral.AutoSizeCols()
        RefreshVane(i) '更新曲线图
    End Sub

    Private Sub cmbMet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMet.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim jTiemInter = 1
        If cmbTime.Text <> "" And cmbTime.Text IsNot Nothing Then
            jTiemInter = cmbTime.Text
        End If

        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, jTiemInter, num)
    End Sub

    Private Sub cmbTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTime.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim jTiemInter = 1
        If cmbTime.Text <> "" And cmbTime.Text IsNot Nothing Then
            jTiemInter = cmbTime.Text
        End If

        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, jTiemInter, num)
    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNum.SelectedIndexChanged
        Dim i As Integer = cmbMet.SelectedIndex
        Dim jTiemInter = 1
        If cmbTime.Text <> "" And cmbTime.Text IsNot Nothing Then
            jTiemInter = cmbTime.Text
        End If

        Dim num As Integer = cmbNum.SelectedIndex
        ChangeResult(i, jTiemInter, num)
    End Sub

    ''' <summary>
    ''' 下风向浓度分布
    ''' </summary>
    ''' <param name="i">气象条件</param>
    ''' <remarks></remarks>
    Public Sub RefreshVane(ByVal i As Integer)
        '更新图表
        TChart1.Series.Clear() '清除所有
        Dim nMount As Integer = Math.Truncate(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length / 10) + 1
        Dim s As New Steema.TeeChart.Styles.Line
        Dim a(0 To nMount - 1) As Double
        Dim b(0 To nMount - 1) As Double
        For n As Integer = 0 To nMount - 1
            If n = nMount - 1 Then
                a(n) = Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t
                b(n) = Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_C
            Else
                a(n) = Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * 10).m_t
                b(n) = Project0.Dis0.Heavy(i).BoxHeavy.boxMetAndMass.BoxAirMass(n * 10).m_C
            End If

            s.Add(a, b)
            s.Title = Project0.Dis0.Forecast.Met(i).Vane & "," _
                     & Project0.Dis0.Forecast.Met(i).WindSpeed _
                     & "," & Project0.Dis0.Forecast.Met(i).Stab
            TChart1.Series.Add(s)

        Next

    End Sub

    Private Sub 复制CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制CToolStripMenuItem.Click
        Me.TChart1.Export.Image.JPEG.CopyToClipboard()
    End Sub

    Private Sub 设置SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置SToolStripMenuItem.Click
        TChart1.ShowEditor()
    End Sub

End Class
