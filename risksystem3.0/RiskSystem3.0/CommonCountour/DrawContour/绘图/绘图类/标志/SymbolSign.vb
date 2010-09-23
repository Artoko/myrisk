Imports System.Drawing.Drawing2D
<Serializable()> Public Class SymbolSign
    Private mSymbolShape As New SymbolShape '标志的形状
    Private mSymbolSize As Double = 1.4 '标志的大小，用mm表示
    Private mSymbolColor As Color = Color.Red  '标志的颜色
    Public mSymbolsPoint As PointF '标志的位置，用数组表示位置。每0个数为点源的位置，如果是面源，则绘制多边形
    Public Property SymbolShape() As SymbolShape
        Get
            Return mSymbolShape
        End Get
        Set(ByVal value As SymbolShape)
            mSymbolShape = value
        End Set
    End Property
    Public Property SymbolSize() As Double
        Get
            Return mSymbolSize
        End Get
        Set(ByVal value As Double)
            mSymbolSize = value
        End Set
    End Property
    Public Property SymbolColor() As Color
        Get
            Return mSymbolColor
        End Get
        Set(ByVal value As Color)
            mSymbolColor = value
        End Set
    End Property
    Public Sub DrawSymbolSign(ByVal grap As Graphics) '绘制标志

        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
        graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
        myMatrix.Translate(mSymbolsPoint.X, mSymbolsPoint.Y) '平移到绘字点
        myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
        myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
        grap.Transform = myMatrix
        Dim rect As Rectangle
        rect.X = -mSymbolSize / 2 / PannelSetting.MMTOPIX '换算成mm的比例
        rect.Y = -mSymbolSize / 2 / PannelSetting.MMTOPIX
        rect.Width = mSymbolSize / PannelSetting.MMTOPIX
        rect.Height = mSymbolSize / PannelSetting.MMTOPIX
        mSymbolShape.SymbolShapeColor = mSymbolColor
        mSymbolShape.DrawSymbolShape(grap, rect)
        grap.EndContainer(graphicsContainer) '退出绘图容器

    End Sub
End Class
