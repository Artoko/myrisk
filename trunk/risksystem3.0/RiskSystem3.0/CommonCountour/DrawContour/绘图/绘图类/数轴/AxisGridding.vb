<Serializable()> Public Class AxisGridding
    Public AxisGriddingVisible As Boolean '网格是否可见
    Public PenProperty As New PenProperty '画笔的属性
    Private MaxValue, MinValue As Double '轴的最大轴与最小值
    Private IncreaseValue As Double  '坐标的最大值、最小值和增加值
    Private inMax, inMin As Double  '用来画线的最大值和最小值，是整数
    Public AxesSide As AxesSide = AxesSide.LeftSide  '边
    Public Sub New()
        PenProperty.DashStyle = Drawing2D.DashStyle.Dash
    End Sub
    Public Sub AxisGriddingDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)
        Dim AxisGriddingPen As New Pen(Color.FromArgb(PenProperty.color))
        AxisGriddingPen.DashStyle = PenProperty.DashStyle
        AxisGriddingPen.Width = PenProperty.WidthReal * PannelSetting.gScale
        '根据不同的坐标轴边，设置不同的最大值和最小值
        Select Case AxesSideValue
            Case AxesSide.LeftSide, AxesSide.RightSide
                MinValue = PannelSetting.gAxisRect.Y
                MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                IncreaseValue = PannelSetting.gVMainIncrease '垂直轴的主刻度间隔
            Case AxesSide.BottomSide, AxesSide.TopSide
                MinValue = PannelSetting.gAxisRect.X
                MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                IncreaseValue = PannelSetting.gHMainIncrease '水平轴的主刻度间隔  
        End Select
        If IncreaseValue > 0 Then
            inMin = MinValue
            inMax = MaxValue
            Dim iStart, iEnd As Integer
            If inMin = MinValue Then
                iStart = inMin + IncreaseValue
            Else
                iStart = inMin
            End If
            If inMax = MaxValue Then
                iEnd = inMax - IncreaseValue
            Else
                iEnd = inMax
            End If
            Dim i As Integer
            If AxisGriddingVisible Then '如果可见就绘制坐标轴的轴线
                Select Case AxesSideValue
                    Case AxesSide.LeftSide, AxesSide.RightSide '左轴或右轴
                        For i = iStart To iEnd Step IncreaseValue
                            grap.DrawLine(AxisGriddingPen, PannelSetting.gAxisRect.X, i, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, i)
                        Next
                    Case AxesSide.BottomSide, AxesSide.TopSide '底轴或顶轴
                        For i = iStart To iEnd Step IncreaseValue
                            grap.DrawLine(AxisGriddingPen, i, PannelSetting.gAxisRect.Y, i, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height)
                        Next
                End Select
            End If
        End If
    End Sub
    
End Class
