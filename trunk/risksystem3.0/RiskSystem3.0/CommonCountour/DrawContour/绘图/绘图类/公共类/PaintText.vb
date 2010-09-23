Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
''' <summary>
''' 绘制文本类，提供绘制文本的方法
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PaintText
    Private mVisible As Boolean = True  '标志的文字可见
    Protected mPosition As PointF '绘制文本的位置
    Private mColor As Color = Color.Black '字的颜色
    Private mName As String '标志的名称
    Protected mAngle As Integer = 0 '标志名称的角度，0-360度
    <NonSerialized()> Protected mfontFamily As New FontFamily(New GenericFontFamilies) '字体的样式
    Public mFont As New Font(mfontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel) '字体

    ''' <summary>
    ''' 文本是否可见
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Visible() As Boolean
        Get
            Return mVisible
        End Get
        Set(ByVal value As Boolean)
            mVisible = value
        End Set
    End Property
    Public Property Color() As Color
        Get
            Return mColor
        End Get
        Set(ByVal value As Color)
            mColor = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property


    Public Sub DrawText(ByVal grap As Graphics)
        PannelSetting.gAxisTitleRect = PannelSetting.gAxisLabelRect '设置坐标标题的区域等于绘制刻度线标注的区域
        '根据不同的坐标轴边，设置不同的最大值和最小值
        Dim SymbolBrush As New SolidBrush(mColor) '
        If mVisible Then '如果标志的文字可见就绘制标志标志的文字
            Dim mFormat As New StringFormat(New StringAlignment().Near) '字符的对齐方式

            Dim myMatrix As New Matrix()
            Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
            graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
            myMatrix.Translate(mPosition.X, mPosition.Y) '平移到绘字点
            myMatrix.Rotate(mAngle)
            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
            grap.Transform = myMatrix
            grap.DrawString(mName, mFont, SymbolBrush, 0, 0, mFormat)
            grap.EndContainer(graphicsContainer) '退出绘图容器
        End If
    End Sub
End Class
