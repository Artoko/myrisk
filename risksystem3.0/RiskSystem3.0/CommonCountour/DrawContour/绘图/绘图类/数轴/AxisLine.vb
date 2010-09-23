
''' <summary>
''' �������������
''' </summary>
''' <remarks>���ڻ�������������ߡ���Ҫ���������ߵ���㣬���ߵ��յ㣬���ߵĻ���</remarks>
<Serializable()> Public Class AxisLine

    ''' <summary>
    ''' �����ߵĻ���
    ''' </summary>
    Public PenProperty As New PenProperty '���ʵĻڸ���
    Public AxisVisible As Boolean = True  '�������Ƿ�ɼ�
    Public Sub AxisDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)
       Dim m_AxisPen As New Pen(Color.FromArgb(PenProperty.color))
        m_AxisPen.DashStyle = PenProperty.DashStyle
        m_AxisPen.Width = PenProperty.WidthReal * PannelSetting.gScale
        If AxisVisible Then '����ɼ��ͻ��������������
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
