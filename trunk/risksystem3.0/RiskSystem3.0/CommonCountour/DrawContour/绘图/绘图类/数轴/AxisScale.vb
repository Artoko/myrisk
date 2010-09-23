
<Serializable()> Public Class AxisScale  '主刻度线类

    Public PenProperty As New PenProperty '画笔的悔改类
    Public ScaleVisible As Boolean = True  '主刻度线是否可见
    Private MaxValue, MinValue As Double '轴的最大值与最小值
    Private IncreaseValue As Double  '坐标的最大值、最小值和增加值
    Private inMax, inMin As Double  '用来画刻度线的最大值和最小值，是整数
    Public ScaleSide As ScalePosition '位置
    Public AxesSide As AxesSide = AxesSide.LeftSide  '边

    Public Property Max() As Double
        Get
            Return MaxValue
        End Get
        Set(ByVal value As Double)
            MaxValue = value
            '根据坐标轴不同，调整相应的坐标轴绘图区域
            Select Case AxesSide
                Case AxesSide.LeftSide
                    PannelSetting.gAxisRect.Y = MinValue
                    PannelSetting.gAxisRect.Height = MaxValue - MinValue
                Case AxesSide.BottomSide
                    PannelSetting.gAxisRect.X = MinValue
                    PannelSetting.gAxisRect.Width = MaxValue - MinValue
                Case AxesSide.RightSide
                    PannelSetting.gAxisRect.Y = MinValue
                    PannelSetting.gAxisRect.Height = MaxValue - MinValue
                Case AxesSide.TopSide
                    PannelSetting.gAxisRect.X = MinValue
                    PannelSetting.gAxisRect.Width = MaxValue - MinValue
            End Select
        End Set
    End Property
    Public Property Min() As Double
        Get
            Return MinValue
        End Get
        Set(ByVal value As Double)
            MinValue = value
            '根据坐标轴不同，调整相应的坐标轴绘图区域
            Select Case AxesSide
                Case AxesSide.LeftSide
                    PannelSetting.gAxisRect.Y = MinValue
                    PannelSetting.gAxisRect.Height = MaxValue - MinValue
                Case AxesSide.BottomSide
                    PannelSetting.gAxisRect.X = MinValue
                    PannelSetting.gAxisRect.Width = MaxValue - MinValue
                Case AxesSide.RightSide
                    PannelSetting.gAxisRect.Y = MinValue
                    PannelSetting.gAxisRect.Height = MaxValue - MinValue
                Case AxesSide.TopSide
                    PannelSetting.gAxisRect.X = MinValue
                    PannelSetting.gAxisRect.Width = MaxValue - MinValue

            End Select
        End Set
    End Property
    Public Property Increase() As Double
        Get
            Return IncreaseValue
        End Get
        Set(ByVal value As Double)
            IncreaseValue = value
            '根据坐标轴不同，调整相应的坐标轴绘图区域
            Select Case AxesSide
                Case AxesSide.LeftSide
                    PannelSetting.gVMainIncrease = IncreaseValue '垂直轴的主刻度间隔
                Case AxesSide.BottomSide
                    PannelSetting.gHMainIncrease = IncreaseValue '水平轴的主刻度间隔  
                Case AxesSide.RightSide
                    PannelSetting.gVMainIncrease = IncreaseValue '垂直轴的主刻度间隔
                Case AxesSide.TopSide
                    PannelSetting.gHMainIncrease = IncreaseValue '水平轴的主刻度间隔  
            End Select
        End Set
    End Property

    Public Sub MainScaleDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)

        '绘制轴标注的左边区域
        PannelSetting.gAxisLabelRect.X = PannelSetting.gAxisRect.X
        '绘制轴标注的底边区域
        PannelSetting.gAxisLabelRect.Y = PannelSetting.gAxisRect.Y
        '绘制轴标注的右边区域
        PannelSetting.gAxisLabelRect.Width = PannelSetting.gAxisRect.Width + (PannelSetting.gAxisRect.X - PannelSetting.gAxisLabelRect.X)
        '绘制轴标注的顶边区域
        PannelSetting.gAxisLabelRect.Height = PannelSetting.gAxisRect.Height + (PannelSetting.gAxisRect.Y - PannelSetting.gAxisLabelRect.Y)


        Dim ScalePen As New Pen(Color.FromArgb(PenProperty.color))
        ScalePen.DashStyle = PenProperty.DashStyle
        ScalePen.Width = PenProperty.WidthReal * PannelSetting.gScale
        If IncreaseValue > 0 Then
            '根据不同的坐标轴边，设置不同的最大值和最小值
            Select Case AxesSideValue
                Case AxesSide.LeftSide
                    MinValue = PannelSetting.gAxisRect.Y
                    MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                    IncreaseValue = PannelSetting.gVMainIncrease '垂直轴的主刻度间隔
                Case AxesSide.BottomSide
                    MinValue = PannelSetting.gAxisRect.X
                    MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                    IncreaseValue = PannelSetting.gHMainIncrease '水平轴的主刻度间隔  
                Case AxesSide.RightSide
                    MinValue = PannelSetting.gAxisRect.Y
                    MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                    IncreaseValue = PannelSetting.gVMainIncrease '垂直轴的主刻度间隔  
                Case AxesSide.TopSide
                    MinValue = PannelSetting.gAxisRect.X
                    MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                    IncreaseValue = PannelSetting.gHMainIncrease '水平轴的主刻度间隔  
            End Select
            inMin = MinValue
            inMax = MaxValue
            Dim i As Integer
            If ScaleVisible Then '如果可见就绘制坐标轴的轴线
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, PannelSetting.gAxisRect.X, i, CSng(PannelSetting.gAxisRect.X - 5 * PannelSetting.gScale), i)
                        Next
                        '扩大绘制轴标注的左边区域
                        PannelSetting.gAxisLabelRect.X = PannelSetting.gAxisRect.X - 5 * PannelSetting.gScale
                    Case AxesSide.BottomSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, i, PannelSetting.gAxisRect.Y, i, CSng(PannelSetting.gAxisRect.Y - 5 * PannelSetting.gScale))
                        Next
                        '扩大绘制轴标注的底边区域
                        PannelSetting.gAxisLabelRect.Y = PannelSetting.gAxisRect.Y - 5 * PannelSetting.gScale
                    Case AxesSide.RightSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, i, PannelSetting.gAxisRect.X + CSng(PannelSetting.gAxisRect.Width + 5 * PannelSetting.gScale), i)
                        Next
                        '扩大绘制轴标注的右边区域
                        PannelSetting.gAxisLabelRect.Width = PannelSetting.gAxisRect.Width + 5 * PannelSetting.gScale + (PannelSetting.gAxisRect.X - PannelSetting.gAxisLabelRect.X)
                    Case AxesSide.TopSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, i, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height, i, PannelSetting.gAxisRect.Y + CSng(PannelSetting.gAxisRect.Height + 5 * PannelSetting.gScale))
                        Next
                        '扩大绘制轴标注的顶边区域
                        PannelSetting.gAxisLabelRect.Height = PannelSetting.gAxisRect.Height + 5 * PannelSetting.gScale + (PannelSetting.gAxisRect.Y - PannelSetting.gAxisLabelRect.Y)
                End Select
            Else
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        '缩小绘制轴标注的左边区域
                        PannelSetting.gAxisLabelRect.X = PannelSetting.gAxisRect.X
                    Case AxesSide.BottomSide
                        '缩小绘制轴标注的底边区域
                        PannelSetting.gAxisLabelRect.Y = PannelSetting.gAxisRect.Y
                    Case AxesSide.RightSide
                        '缩小绘制轴标注的右边区域
                        PannelSetting.gAxisLabelRect.Width = PannelSetting.gAxisRect.Width + (PannelSetting.gAxisRect.X - PannelSetting.gAxisLabelRect.X)
                    Case AxesSide.TopSide
                        '缩小绘制轴标注的顶边区域
                        PannelSetting.gAxisLabelRect.Height = PannelSetting.gAxisRect.Height + (PannelSetting.gAxisRect.Y - PannelSetting.gAxisLabelRect.Y)
                End Select
            End If
        End If

    End Sub

End Class
Public Enum ScalePosition '刻度线的位置
    InSide
    Center
    OutSide
End Enum