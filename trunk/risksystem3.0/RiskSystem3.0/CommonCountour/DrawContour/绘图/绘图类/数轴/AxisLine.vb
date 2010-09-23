
''' <summary>
''' 坐标轴的轴线类
''' </summary>
''' <remarks>用于绘制坐标轴的轴线。主要属性有轴线的起点，轴线的终点，轴线的画笔</remarks>
<Serializable()> Public Class AxisLine

    ''' <summary>
    ''' 坐标线的画笔
    ''' </summary>
    Public PenProperty As New PenProperty '画笔的悔改类
    Public AxisVisible As Boolean = True  '坐标线是否可见
    Public Sub AxisDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)
       Dim m_AxisPen As New Pen(Color.FromArgb(PenProperty.color))
        m_AxisPen.DashStyle = PenProperty.DashStyle
        m_AxisPen.Width = PenProperty.WidthReal * PannelSetting.gScale
        If AxisVisible Then '如果可见就绘制坐标轴的轴线
            Select Case AxesSideValue
                Case AxesSide.LeftSide
                    grap.DrawLine(m_AxisPen, PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height, PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y)
                Case AxesSide.BottomSide
                    grap.DrawLine(m_AxisPen, PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, PannelSetting.gAxisRect.Y)
                Case AxesSide.RightSide
                    grap.DrawLine(m_AxisPen, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, PannelSetting.gAxisRect.Y)
                Case AxesSide.TopSide
                    grap.DrawLine(m_AxisPen, PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height)
            End Select
        End If
    End Sub

End Class
