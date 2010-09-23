
''' <summary>
''' 坐标轴类
''' </summary>
<Serializable()> Public Class Axis

    Private AxisLineValue As New AxisLine '坐标轴线
    Private MainScaleValue As New AxisScale '主坐标轴刻度线
    Private AxisTitleValue As New AxisTitle '坐标标题
    Private AxisLabelValue As New AxisLabel '主坐标刻度标注
    Private AxisgriddingValue As New AxisGridding '网格
    Private AxesSideValue As AxesSide = AxesSide.LeftSide  '用于判断是哪一边坐标轴,默认值是左边
    Sub New(ByVal SiedeValue As AxesSide)
        AxesSideValue = SiedeValue
        MainScaleValue.AxesSide = SiedeValue '设置刻度线的边
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

    Public Sub AxisDraw(ByVal grap As Graphics) '根据当前的坐标是左、右、底、顶轴，分别进行相应的绘制
        AxisLineValue.AxisDraw(grap, AxesSideValue) '绘制坐标轴线
        MainScaleValue.MainScaleDraw(grap, AxesSideValue) '绘制主刻度
        AxisLabelValue.AxisLabelDraw(grap, AxesSideValue) '绘制主刻度的标注
        AxisTitleValue.DrawTitle(grap, AxesSideValue) '绘制坐标标题
        AxisgriddingValue.AxisGriddingDraw(grap, AxesSideValue) '绘制网格线
    End Sub
End Class
