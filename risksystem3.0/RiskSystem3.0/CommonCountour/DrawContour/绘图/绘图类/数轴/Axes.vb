Imports System.Drawing.Drawing2D
''' <summary>
''' �����������������ꡢ�����ꡢ�����ꡢ������
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
        '���õ�ֵ��ͼ���ᡢ����ɼ�
        LeftAxis.AxisTitle.TitleVisible = True
        BottomAxis.AxisTitle.TitleVisible = True
        LeftAxis.AxisTitle.TitleName = "Y��"
        BottomAxis.AxisTitle.TitleName = "X��"

        LeftAxis.MainAxisScale.ScaleVisible = True
        BottomAxis.MainAxisScale.ScaleVisible = True
        RightAxis.MainAxisScale.ScaleVisible = False
        TopAxis.MainAxisScale.ScaleVisible = False

        '��������̶ȵı�ע�ɼ�
        LeftAxis.AxisLabel.LabelVisible = True
        '���õ���̶ȵı�ע�ɼ�
        BottomAxis.AxisLabel.LabelVisible = True
        '���������߿ɼ�
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
    ''' �����ĸ���
    ''' </summary>
    ''' <param name="grap">��������</param>
    ''' <param name="point">��ǰ����λ��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DrawFoursquare(ByVal grap As Graphics, ByVal point As PointF) As Boolean '������з���T
        point.X = point.X - PannelSetting.OriginX
        point.Y = point.Y - PannelSetting.OriginY
        point.Y = -point.Y
        point.X = point.X * PannelSetting.gScale
        point.Y = point.Y * PannelSetting.gScale

        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
        grap.Transform = myMatrix
        Dim FourSquareValue As New Foursquare
        Return FourSquareValue.DrawFoursquare(grap, point, PannelSetting.gAxisRect)
        grap.EndContainer(graphicsContainer)
    End Function
    ''' <summary>
    ''' �����ķ��ε�����
    ''' </summary>
    ''' <param name="grap">��������</param>
    ''' <param name="prePoint">����������ʱ��λ��</param>
    ''' <param name="Point">��ǰ����λ��</param>
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

        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
        grap.Transform = myMatrix
        Dim FourSquareValue As New Foursquare
        FourSquareValue.DrawRectangle(grap, prePoint, Point, PannelSetting.gAxisRect)
        grap.EndContainer(graphicsContainer)
    End Sub
    ''' <summary>
    ''' �ƶ�ͼ�β��ػ�ͼ��
    ''' </summary>
    ''' <param name="grap">��������</param>
    ''' <param name="prePoint">����������ʱ��λ��</param>
    ''' <param name="Point">��ǰ����λ��</param>
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

        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
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
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
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
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
        grap.Transform = myMatrix

        Dim FourSquareValue As New Foursquare
        Return FourSquareValue.LeftBottomAndRightTopCursor(grap, prePoint)
        grap.EndContainer(graphicsContainer)

    End Function
End Class
