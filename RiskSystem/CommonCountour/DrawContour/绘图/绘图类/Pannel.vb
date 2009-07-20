Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class Pannel
    Private AxesValue As New Axes '坐标轴
    Private BackImageValue As New BackImage '背景图
    Private m_PlanImage As New BackImage '平面图
    Private ContoursValue As New Contours  '等值线类，用于绘制等值线
    Private mSymbols As New Symbols '标志类的集合，用于绘制污染源标志、关心点标志等
    Private mLegend As New Legend '图例
    Private m_PannelSeting As New PannelSettingClass  '用于设置当前绘图的区域等公共对象

    ''' <summary>
    ''' 平面图
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Axes() As Axes
        Get
            Return AxesValue
        End Get
        Set(ByVal value As Axes)
            AxesValue = value
        End Set
    End Property
    ''' <summary>
    ''' 背景图
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BackImage() As BackImage
        Get
            Return BackImageValue
        End Get
        Set(ByVal value As BackImage)
            BackImageValue = value
        End Set
    End Property

    Public Property Contours() As Contours
        Get
            Return ContoursValue
        End Get
        Set(ByVal value As Contours)
            ContoursValue = value
        End Set
    End Property

    Public Property Symbols() As Symbols
        Get
            Return mSymbols
        End Get
        Set(ByVal value As Symbols)
            mSymbols = value
        End Set
    End Property

    Public Property Legend() As Legend
        Get
            Return mLegend
        End Get
        Set(ByVal value As Legend)
            mLegend = value
        End Set
    End Property
    ''' <summary>
    ''' 平面图
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PlanImage() As BackImage
        Get
            Return Me.m_PlanImage
        End Get
        Set(ByVal value As BackImage)
            Me.m_PlanImage = value
        End Set
    End Property
    ''' <summary>
    ''' 用于设置当前绘图的区域等公共对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PannelSeting() As PannelSettingClass
        Get
            Return Me.m_PannelSeting
        End Get
        Set(ByVal value As PannelSettingClass)
            m_PannelSeting = value
        End Set
    End Property

    Public Sub DrawPannel(ByVal grap As Graphics)
        ''坐标变换
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '将坐标系统平移
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '绘图容器
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '比例尺为
        grap.Transform = myMatrix
        BackImageValue.DrawImage(grap) '绘制背景图
        Me.m_PlanImage.DrawImage(grap) '绘制平面图
        ContoursValue.DrawContours(grap) '绘制等值线
        AxesValue.DrawAxes(grap) '绘制坐标
        mSymbols.DrawSymbols(grap) '绘制标志
        mLegend.DrawLegend(grap, ContoursValue, mSymbols) '绘制图例
        DrawTR(grap)
        grap.EndContainer(graphicsContainer)
        PannelSetting.PreScale = PannelSetting.gScale '把值给前一个值
    End Sub
    Private Sub DrawTR(ByVal grap As Graphics)
        Dim fontFamily As New FontFamily(New GenericFontFamilies)
        Dim newFont As New Font(fontFamily, 900 / PannelSetting.gScale, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim x, y As Integer
        x = (AxesValue.BottomAxis.MainAxisScale.Max + AxesValue.BottomAxis.MainAxisScale.Min) / 2
        y = (AxesValue.LeftAxis.MainAxisScale.Max + AxesValue.LeftAxis.MainAxisScale.Min) / 2
        Dim labelformat As New StringFormat()
        labelformat.Alignment = StringAlignment.Center
        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
        graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
        myMatrix.Translate(x, y) '平移到绘字点
        If PannelSetting.gScale > 2 Then
            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
        End If
        myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
        grap.Transform = myMatrix
        'grap.DrawString("试用版", newFont, New SolidBrush(Color.Gray), 0, 0, labelformat) '正式版注销掉即可。
        grap.EndContainer(graphicsContainer) '退出绘图容器
    End Sub
End Class
