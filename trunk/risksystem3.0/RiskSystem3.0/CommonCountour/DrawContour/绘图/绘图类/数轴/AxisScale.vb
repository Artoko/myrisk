
<Serializable()> Public Class AxisScale  '���̶�����

    Public PenProperty As New PenProperty '���ʵĻڸ���
    Public ScaleVisible As Boolean = True  '���̶����Ƿ�ɼ�
    Private MaxValue, MinValue As Double '������ֵ����Сֵ
    Private IncreaseValue As Double  '��������ֵ����Сֵ������ֵ
    Private inMax, inMin As Double  '�������̶��ߵ����ֵ����Сֵ��������
    Public ScaleSide As ScalePosition 'λ��
    Public AxesSide As AxesSide = AxesSide.LeftSide  '��

    Public Property Max() As Double
        Get
            Return MaxValue
        End Get
        Set(ByVal value As Double)
            MaxValue = value
            '���������᲻ͬ��������Ӧ���������ͼ����
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
            '���������᲻ͬ��������Ӧ���������ͼ����
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
            '���������᲻ͬ��������Ӧ���������ͼ����
            Select Case AxesSide
                Case AxesSide.LeftSide
                    PannelSetting.gVMainIncrease = IncreaseValue '��ֱ������̶ȼ��
                Case AxesSide.BottomSide
                    PannelSetting.gHMainIncrease = IncreaseValue 'ˮƽ������̶ȼ��  
                Case AxesSide.RightSide
                    PannelSetting.gVMainIncrease = IncreaseValue '��ֱ������̶ȼ��
                Case AxesSide.TopSide
                    PannelSetting.gHMainIncrease = IncreaseValue 'ˮƽ������̶ȼ��  
            End Select
        End Set
    End Property

    Public Sub MainScaleDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)

        '�������ע���������
        PannelSetting.gAxisLabelRect.X = PannelSetting.gAxisRect.X
        '�������ע�ĵױ�����
        PannelSetting.gAxisLabelRect.Y = PannelSetting.gAxisRect.Y
        '�������ע���ұ�����
        PannelSetting.gAxisLabelRect.Width = PannelSetting.gAxisRect.Width + (PannelSetting.gAxisRect.X - PannelSetting.gAxisLabelRect.X)
        '�������ע�Ķ�������
        PannelSetting.gAxisLabelRect.Height = PannelSetting.gAxisRect.Height + (PannelSetting.gAxisRect.Y - PannelSetting.gAxisLabelRect.Y)


        Dim ScalePen As New Pen(Color.FromArgb(PenProperty.color))
        ScalePen.DashStyle = PenProperty.DashStyle
        ScalePen.Width = PenProperty.WidthReal * PannelSetting.gScale
        If IncreaseValue > 0 Then
            '���ݲ�ͬ��������ߣ����ò�ͬ�����ֵ����Сֵ
            Select Case AxesSideValue
                Case AxesSide.LeftSide
                    MinValue = PannelSetting.gAxisRect.Y
                    MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                    IncreaseValue = PannelSetting.gVMainIncrease '��ֱ������̶ȼ��
                Case AxesSide.BottomSide
                    MinValue = PannelSetting.gAxisRect.X
                    MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                    IncreaseValue = PannelSetting.gHMainIncrease 'ˮƽ������̶ȼ��  
                Case AxesSide.RightSide
                    MinValue = PannelSetting.gAxisRect.Y
                    MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                    IncreaseValue = PannelSetting.gVMainIncrease '��ֱ������̶ȼ��  
                Case AxesSide.TopSide
                    MinValue = PannelSetting.gAxisRect.X
                    MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                    IncreaseValue = PannelSetting.gHMainIncrease 'ˮƽ������̶ȼ��  
            End Select
            inMin = MinValue
            inMax = MaxValue
            Dim i As Integer
            If ScaleVisible Then '����ɼ��ͻ��������������
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, PannelSetting.gAxisRect.X, i, CSng(PannelSetting.gAxisRect.X - 5 * PannelSetting.gScale), i)
                        Next
                        '����������ע���������
                        PannelSetting.gAxisLabelRect.X = PannelSetting.gAxisRect.X - 5 * PannelSetting.gScale
                    Case AxesSide.BottomSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, i, PannelSetting.gAxisRect.Y, i, CSng(PannelSetting.gAxisRect.Y - 5 * PannelSetting.gScale))
                        Next
                        '����������ע�ĵױ�����
                        PannelSetting.gAxisLabelRect.Y = PannelSetting.gAxisRect.Y - 5 * PannelSetting.gScale
                    Case AxesSide.RightSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, i, PannelSetting.gAxisRect.X + CSng(PannelSetting.gAxisRect.Width + 5 * PannelSetting.gScale), i)
                        Next
                        '����������ע���ұ�����
                        PannelSetting.gAxisLabelRect.Width = PannelSetting.gAxisRect.Width + 5 * PannelSetting.gScale + (PannelSetting.gAxisRect.X - PannelSetting.gAxisLabelRect.X)
                    Case AxesSide.TopSide
                        For i = inMin To inMax Step IncreaseValue
                            grap.DrawLine(ScalePen, i, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height, i, PannelSetting.gAxisRect.Y + CSng(PannelSetting.gAxisRect.Height + 5 * PannelSetting.gScale))
                        Next
                        '����������ע�Ķ�������
                        PannelSetting.gAxisLabelRect.Height = PannelSetting.gAxisRect.Height + 5 * PannelSetting.gScale + (PannelSetting.gAxisRect.Y - PannelSetting.gAxisLabelRect.Y)
                End Select
            Else
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        '��С�������ע���������
                        PannelSetting.gAxisLabelRect.X = PannelSetting.gAxisRect.X
                    Case AxesSide.BottomSide
                        '��С�������ע�ĵױ�����
                        PannelSetting.gAxisLabelRect.Y = PannelSetting.gAxisRect.Y
                    Case AxesSide.RightSide
                        '��С�������ע���ұ�����
                        PannelSetting.gAxisLabelRect.Width = PannelSetting.gAxisRect.Width + (PannelSetting.gAxisRect.X - PannelSetting.gAxisLabelRect.X)
                    Case AxesSide.TopSide
                        '��С�������ע�Ķ�������
                        PannelSetting.gAxisLabelRect.Height = PannelSetting.gAxisRect.Height + (PannelSetting.gAxisRect.Y - PannelSetting.gAxisLabelRect.Y)
                End Select
            End If
        End If

    End Sub

End Class
Public Enum ScalePosition '�̶��ߵ�λ��
    InSide
    Center
    OutSide
End Enum