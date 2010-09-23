
''' <summary>
''' ��������
''' </summary>
<Serializable()> Public Class Axis

    Private AxisLineValue As New AxisLine '��������
    Private MainScaleValue As New AxisScale '��������̶���
    Private AxisTitleValue As New AxisTitle '�������
    Private AxisLabelValue As New AxisLabel '������̶ȱ�ע
    Private AxisgriddingValue As New AxisGridding '����
    Private AxesSideValue As AxesSide = AxesSide.LeftSide  '�����ж�����һ��������,Ĭ��ֵ�����
    Sub New(ByVal SiedeValue As AxesSide)
        AxesSideValue = SiedeValue
        MainScaleValue.AxesSide = SiedeValue '���ÿ̶��ߵı�
    End Sub

    Public Property AxisLine() As AxisLine
        Get
            Return AxisLineValue
        End Get
        Set(ByVal value As AxisLine)
            AxisLineValue = value
        End Set
    End Property

    Public Property AxesSide() As AxesSide
        Get
            Return AxesSideValue
        End Get
        Set(ByVal value As AxesSide)
            AxesSideValue = value
        End Set
    End Property

    Public Property AxisTitle() As AxisTitle
        Get
            Return AxisTitleValue
        End Get
        Set(ByVal value As AxisTitle)
            AxisTitleValue = value
        End Set
    End Property

    Public Property MainAxisScale() As AxisScale
        Get
            Return MainScaleValue
        End Get
        Set(ByVal value As AxisScale)
            MainScaleValue = value
        End Set
    End Property

    Public Property AxisLabel() As AxisLabel
        Get
            Return AxisLabelValue
        End Get
        Set(ByVal value As AxisLabel)
            AxisLabelValue = value
        End Set
    End Property

    Public Property AxisGridding() As AxisGridding
        Get
            Return AxisgriddingValue
        End Get
        Set(ByVal value As AxisGridding)
            AxisgriddingValue = value
        End Set
    End Property

    Public Sub AxisDraw(ByVal grap As Graphics) '���ݵ�ǰ�����������ҡ��ס����ᣬ�ֱ������Ӧ�Ļ���
        AxisLineValue.AxisDraw(grap, AxesSideValue) '������������
        MainScaleValue.MainScaleDraw(grap, AxesSideValue) '�������̶�
        AxisLabelValue.AxisLabelDraw(grap, AxesSideValue) '�������̶ȵı�ע
        AxisTitleValue.DrawTitle(grap, AxesSideValue) '�����������
        AxisgriddingValue.AxisGriddingDraw(grap, AxesSideValue) '����������
    End Sub
End Class
