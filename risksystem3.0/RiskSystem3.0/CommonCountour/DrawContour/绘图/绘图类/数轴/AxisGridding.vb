<Serializable()> Public Class AxisGridding
    Public AxisGriddingVisible As Boolean '�����Ƿ�ɼ�
    Public PenProperty As New PenProperty '���ʵ�����
    Private MaxValue, MinValue As Double '������������Сֵ
    Private IncreaseValue As Double  '��������ֵ����Сֵ������ֵ
    Private inMax, inMin As Double  '�������ߵ����ֵ����Сֵ��������
    Public AxesSide As AxesSide = AxesSide.LeftSide  '��
    Public Sub New()
        PenProperty.DashStyle = Drawing2D.DashStyle.Dash
    End Sub
    Public Sub AxisGriddingDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)
        Dim AxisGriddingPen As New Pen(Color.FromArgb(PenProperty.color))
        AxisGriddingPen.DashStyle = PenProperty.DashStyle
        AxisGriddingPen.Width = PenProperty.WidthReal * PannelSetting.gScale
        '���ݲ�ͬ��������ߣ����ò�ͬ�����ֵ����Сֵ
        Select Case AxesSideValue
            Case AxesSide.LeftSide, AxesSide.RightSide
                MinValue = PannelSetting.gAxisRect.Y
                MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                IncreaseValue = PannelSetting.gVMainIncrease '��ֱ������̶ȼ��
            Case AxesSide.BottomSide, AxesSide.TopSide
                MinValue = PannelSetting.gAxisRect.X
                MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                IncreaseValue = PannelSetting.gHMainIncrease 'ˮƽ������̶ȼ��  
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
            If AxisGriddingVisible Then '����ɼ��ͻ��������������
                Select Case AxesSideValue
                    Case AxesSide.LeftSide, AxesSide.RightSide '���������
                        For i = iStart To iEnd Step IncreaseValue
                            grap.DrawLine(AxisGriddingPen, PannelSetting.gAxisRect.X, i, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, i)
                        Next
                    Case AxesSide.BottomSide, AxesSide.TopSide '�������
                        For i = iStart To iEnd Step IncreaseValue
                            grap.DrawLine(AxisGriddingPen, i, PannelSetting.gAxisRect.Y, i, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height)
                        Next
                End Select
            End If
        End If
    End Sub
    
End Class
