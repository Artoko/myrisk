''' <summary>
''' 绘制标志形状的类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class SymbolShape
    Private mSymbolShapeStyle As SymbolShapeStyle = SymbolShapeStyle.SolidCircle '实心圆形
    Private mColor As Color = Color.Black

    Public Property SymbolShapeStyle() As SymbolShapeStyle
        Get
            Return mSymbolShapeStyle
        End Get
        Set(ByVal value As SymbolShapeStyle)
            mSymbolShapeStyle = value
        End Set
    End Property
    Public Property SymbolShapeColor() As Color
        Get
            Return mColor
        End Get
        Set(ByVal value As Color)
            mColor = value
        End Set
    End Property
    ''' <summary>
    ''' 绘制标志的形状
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <param name="rect">绘制的矩形区域</param>
    ''' <remarks></remarks>
    Public Sub DrawSymbolShape(ByVal grap As Graphics, ByVal rect As Rectangle)
        Dim D As Double '直径
        If rect.Width >= rect.Height Then
            D = rect.Width
        Else
            D = rect.Height
        End If
        grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Select Case mSymbolShapeStyle
            Case DrawContour.SymbolShapeStyle.Circle
                grap.DrawEllipse(New Pen(mColor), New Rectangle(rect.X, rect.Y, D, D))
            Case DrawContour.SymbolShapeStyle.SolidCircle
                grap.FillEllipse(New SolidBrush(mColor), New Rectangle(rect.X, rect.Y, D, D))
            Case DrawContour.SymbolShapeStyle.Square
                grap.DrawRectangle(New Pen(mColor), New Rectangle(rect.X, rect.Y, D, D))
            Case DrawContour.SymbolShapeStyle.SolidSquare
                grap.FillRectangle(New SolidBrush(mColor), New Rectangle(rect.X, rect.Y, D, D))
            Case DrawContour.SymbolShapeStyle.Diamond
                Dim SymbolPoint() As PointF = {New PointF(rect.X + D / 2, rect.Y), New PointF(rect.X + D, rect.Y + D / 2), New PointF(rect.X + D / 2, rect.Y + D), New PointF(rect.X, rect.Y + D / 2)}
                grap.DrawPolygon(New Pen(mColor), SymbolPoint)
            Case DrawContour.SymbolShapeStyle.SolidDiamond
                Dim SymbolPoint() As PointF = {New PointF(rect.X + D / 2, rect.Y), New PointF(rect.X + D, rect.Y + D / 2), New PointF(rect.X + D / 2, rect.Y + D), New PointF(rect.X, rect.Y + D / 2)}
                grap.FillPolygon(New SolidBrush(mColor), SymbolPoint)
            Case DrawContour.SymbolShapeStyle.UpwardTriangle
                Dim SymbolPoint() As PointF = {New PointF(rect.X + D / 2, rect.Y), New PointF(rect.X + D, rect.Y + D), New PointF(rect.X, rect.Y + D)}
                grap.DrawPolygon(New Pen(mColor), SymbolPoint)
            Case DrawContour.SymbolShapeStyle.SolidUpwardTriangle
                Dim SymbolPoint() As PointF = {New PointF(rect.X + D / 2, rect.Y), New PointF(rect.X + D, rect.Y + D), New PointF(rect.X, rect.Y + D)}
                grap.FillPolygon(New SolidBrush(mColor), SymbolPoint)
            Case DrawContour.SymbolShapeStyle.DownwardTriangle
                Dim SymbolPoint() As PointF = {New PointF(rect.X, rect.Y), New PointF(rect.X + D, rect.Y), New PointF(rect.X + D / 2, rect.Y + D)}
                grap.DrawPolygon(New Pen(mColor), SymbolPoint)
            Case DrawContour.SymbolShapeStyle.SolidDownwardTriangle
                Dim SymbolPoint() As PointF = {New PointF(rect.X, rect.Y), New PointF(rect.X + D, rect.Y), New PointF(rect.X + D / 2, rect.Y + D)}
                grap.FillPolygon(New SolidBrush(mColor), SymbolPoint)
        End Select
    End Sub
End Class
Public Enum SymbolShapeStyle
    Circle
    SolidCircle
    Square
    SolidSquare
    Diamond
    SolidDiamond
    UpwardTriangle
    SolidUpwardTriangle
    DownwardTriangle
    SolidDownwardTriangle
End Enum
