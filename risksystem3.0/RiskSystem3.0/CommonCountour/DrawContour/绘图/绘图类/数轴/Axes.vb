Imports System.Drawing.Drawing2D
''' <summary>
''' 坐标数，包括左坐标、右坐标、顶坐标、底坐标
''' </summary>
<Serializable()> Public Class Axes

    Private TopAxesValue As New Axis(AxesSide.TopSide)
    Private LeftAxesValue As New Axis(AxesSide.LeftSide)
    Private BottomAxesValue As New Axis(AxesSide.BottomSide)
    Private RightAxesValue As New Axis(AxesSide.RightSide)

    Public Property LeftAxis() As Axis
        Get
            Return LeftAxesValue
        End Get
        Set(ByVal value As Axis)
            LeftAxesValue = value
        End Set
    End Property

    Public Property BottomAxis() As Axis
        Get
            Return BottomAxesValue
        End Get
        Set(ByVal value As Axis)
            BottomAxesValue = value
        End Set
    End Property

    Public Property RightAxis() As Axis
        Get
            Return RightAxesValue
        End Get
        Set(ByVal value As Axis)
            RightAxesValue = value
        End Set
    End Property

    Public Property TopAxis() As Axis
        Get
            Return TopAxesValue
        End Get
        Set(ByVal value As Axis)
            TopAxesValue = value
        End Set
    End Property
    Public Sub New()
        '设置等值线图左轴、标题可见
        LeftAxis.AxisTitle.TitleVisible = True
        BottomAxis.AxisTitle.TitleVisible = True
        LeftAxis.AxisTitle.TitleName = "Y轴"
        BottomAxis.AxisTitle.TitleName = "X轴"

        LeftAxis.MainAxisScale.ScaleVisible = True
        BottomAxis.MainAxisScale.ScaleVisible = True
        RightAxis.MainAxisScale.ScaleVisible = False
        TopAxis.MainAxisScale.ScaleVisible = False

        '设置左轴刻度的标注可见
        LeftAxis.AxisLabel.LabelVisible = True
        '设置底轴刻度的标注可见
        BottomAxis.AxisLabel.LabelVisible = True
        '设置网格线可见
        BottomAxis.AxisGridding.AxisGriddingVisible = True
        LeftAxis.AxisGridding.AxisGriddingVisible = True
    End Sub
    Public Sub DrawAxes(ByVal grap As Graphics)
        LeftAxesValue.AxisDraw(grap)
        BottomAxesValue.AxisDraw(grap)
        RightAxesValue.AxisDraw(grap)
        TopAxesValue.AxisDraw(grap)
    End Sub
    ''' <summary>
    ''' 绘制四个角
    ''' </summary>
    ''' <param name="grap">画布对象</param>
    ''' <param name="point">当前鼠标的位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DrawFoursquare(ByVal grap As Graphics, ByVal point As PointF) As Boolean '如果命中返回T
        point.X = point.X - PannelSetting.OriginX
        point.Y = point.Y - PannelSetting.OriginY
        point.Y = -point.Y
        point.X = point.X * PannelSetting.gScale
        point.Y = point.Y * PannelSetting.gScale

        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '将坐标系统平移
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '绘图容器
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '比例尺为
        grap.Transform = myMatrix
        Dim FourSquareValue As New Foursquare
        Return FourSquareValue.DrawFoursquare(grap, point, PannelSetting.gAxisRect)
        grap.EndContainer(graphicsContainer)
    End Function
    ''' <summary>
    ''' 绘制四方形的虚线
    ''' </summary>
    ''' <param name="grap">画布对象</param>
    ''' <param name="prePoint">鼠标左键按下时的位置</param>
    ''' <param name="Point">当前鼠标的位置</param>
    ''' <remarks></remarks>
    Public Sub DrawRectangle(ByVal grap As Graphics, ByVal prePoint As PointF, ByVal Point As PointF)
        prePoint.X = prePoint.X - PannelSetting.OriginX
        prePoint.Y = prePoint.Y - PannelSetting.OriginY
        prePoint.Y = -prePoint.Y
        prePoint.X = prePoint.X * PannelSetting.gScale
        prePoint.Y = prePoint.Y * PannelSetting.gScale

        Point.X = Point.X - PannelSetting.OriginX
        Point.Y = Point.Y - PannelSetting.OriginY
        Point.Y = -Point.Y
        Point.X = Point.X * PannelSetting.gScale
        Point.Y = Point.Y * PannelSetting.gScale

        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '将坐标系统平移
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '绘图容器
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '比例尺为
        grap.Transform = myMatrix
        Dim FourSquareValue As New Foursquare
        FourSquareValue.DrawRectangle(grap, prePoint, Point, PannelSetting.gAxisRect)
        grap.EndContainer(graphicsContainer)
    End Sub
    ''' <summary>
    ''' 移动图形并重绘图形
    ''' </summary>
    ''' <param name="grap">画布对象</param>
    ''' <param name="prePoint">鼠标左键按下时的位置</param>
    ''' <param name="Point">当前鼠标的位置</param>
    ''' <remarks></remarks>
    Public Sub Redraw(ByVal grap As Graphics, ByVal prePoint As PointF, ByVal Point As PointF)
        prePoint.X = prePoint.X - PannelSetting.OriginX
        prePoint.Y = prePoint.Y - PannelSetting.OriginY
        prePoint.Y = -prePoint.Y
        prePoint.X = prePoint.X * PannelSetting.gScale
        prePoint.Y = prePoint.Y * PannelSetting.gScale

        Point.X = Point.X - PannelSetting.OriginX
        Point.Y = Point.Y - PannelSetting.OriginY
        Point.Y = -Point.Y
        Point.X = Point.X * PannelSetting.gScale
        Point.Y = Point.Y * PannelSetting.gScale

        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '将坐标系统平移
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '绘图容器
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '比例尺为
        grap.Transform = myMatrix

        Dim FourSquareValue As New Foursquare
        FourSquareValue.Redraw(grap, prePoint, Point, PannelSetting.gAxisRect, PannelSetting.OriginX, PannelSetting.OriginY, PannelSetting.gScale)
        grap.EndContainer(graphicsContainer)
    End Sub
    Public Function LeftTopAndRightBottomCursor(ByVal grap As Graphics, ByVal prePoint As PointF) As Boolean
        prePoint.X = prePoint.X - PannelSetting.OriginX
        prePoint.Y = prePoint.Y - PannelSetting.OriginY
        prePoint.Y = -prePoint.Y
        prePoint.X = prePoint.X * PannelSetting.gScale
        prePoint.Y = prePoint.Y * PannelSetting.gScale
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '将坐标系统平移
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '绘图容器
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '比例尺为
        grap.Transform = myMatrix

        Dim FourSquareValue As New Foursquare
        Return FourSquareValue.LeftTopAndRightBottomCursor(grap, prePoint)
        grap.EndContainer(graphicsContainer)
    End Function
    Public Function LeftBottomAndRightTopCursor(ByVal grap As Graphics, ByVal prePoint As PointF) As Boolean
        prePoint.X = prePoint.X - PannelSetting.OriginX
        prePoint.Y = prePoint.Y - PannelSetting.OriginY
        prePoint.Y = -prePoint.Y
        prePoint.X = prePoint.X * PannelSetting.gScale
        prePoint.Y = prePoint.Y * PannelSetting.gScale
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '将坐标系统平移
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '绘图容器
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '比例尺为
        grap.Transform = myMatrix

        Dim FourSquareValue As New Foursquare
        Return FourSquareValue.LeftBottomAndRightTopCursor(grap, prePoint)
        grap.EndContainer(graphicsContainer)

    End Function
End Class
