<Serializable()> Public Class ContourPaintSetting
    Public NoPaint As Boolean = False '表示没有图形
    '污染源
    Private m_Title As String '标题
    Private m_ChartType As Integer '图的类型，0为等值线图表1为火灾爆炸

    Public SourceName As String '污染源名称
    ' 等值线属性-------------------------------------
    Public ContourNames(-1) As String '等值线的名称
    Public ContourValue(-1) As Double '等值线的值
    Public ArrayWeather(-1) As String '气象条件数组
    Public ArrayTime(-1) As String '时间数组
    Public CarePoint(-1) As Point3D '关心点数组,从(0)开始
    Public CarePointName(-1) As String '关心点数组的名称，从(0)开始
    '火灾爆炸属性'----------------------------------------------------------
    Public ArrayHurtValue(-1) As Double '伤害半径
    Public ArrayHurtName(-1) As String '伤害半径的名称
    'Public NZ As Short '伤害半径的个数
    ' -------------------------------------------------------------
    '等值线相关的属性，不同的等值线图，其网格点的值是不同的，因此每一个图有其相应的网格点和气象条件
    Public PaintName As String = "" '图的名称
    Public GridPoint(,) As Double '网格点数组，从(0，0)开始，用于绘制等值线图
    Public arrayDamageRange(-1) As Double '伤害数组，从0开始。用于绘制伤害范围
    Public m_nRows, m_nCols As Integer  '网格点数组的大小
    Public m_Xmin As Double = -6000
    Public m_Ymin As Double = -6000
    Public m_Xmax As Double = 6000
    Public m_Ymax As Double = 6000 '网格的最大坐标和最小坐标

    Public ContourPannel As New Pannel '表示当前绘图类的实例
    ''' <summary>
    ''' 标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return Me.m_Title
        End Get
        Set(ByVal value As String)
            Me.m_Title = value
        End Set
    End Property
    ''' <summary>
    ''' 图的类型，0为等值线图表1为火灾爆炸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChartType() As Integer
        Get
            Return Me.m_ChartType
        End Get
        Set(ByVal value As Integer)
            Me.m_ChartType = value
        End Set
    End Property

    ''' <summary>
    ''' 重新设置等值线的数据和颜色渐变
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetCountData()
        If Me.m_ChartType = 0 Then
            '设置等值线的条数、值和名称
            If ContourPannel.Contours.ArrayContour.Length > 0 Then
                ReDim Preserve ContourPannel.Contours.ArrayContour(0 To Me.ContourValue.Length - 1)
            Else
                ReDim ContourPannel.Contours.ArrayContour(0 To Me.ContourValue.Length - 1)
            End If
            For i As Integer = 0 To Me.ContourValue.Length - 1
                ContourPannel.Contours.ArrayContour(i) = New Contour
                ContourPannel.Contours.ArrayContour(i).ContourName = Me.ContourNames(i)
                ContourPannel.Contours.ArrayContour(i).ContourValue = Me.ContourValue(i)

            Next
            For i As Integer = 0 To Me.ArrayHurtValue.Length - 1
                ContourPannel.Contours.ArrayContour(i).HurtValue = ArrayHurtValue(i)
            Next
            If Me.ContourValue.Length > 0 Then
                ContourPannel.Contours.ContourFillColorGradual() '等值填充线颜色渐变
                ContourPannel.Contours.ContourColorGradual() '等值线颜色渐变
            End If

            Me.ContourPannel.Contours.ReCalContour = True
            '设置网格点,最大值，最小值和行列数
            ContourPannel.Contours.GridPoint = GridPoint
            ContourPannel.Contours.Xmin = m_Xmin
            ContourPannel.Contours.Xmax = m_Xmax
            ContourPannel.Contours.Ymin = m_Ymin
            ContourPannel.Contours.Ymax = m_Ymax
            ContourPannel.Contours.nRow = m_nRows
            ContourPannel.Contours.nCol = m_nCols



        Else
            '设置伤害条数、值和名称

            ReDim ContourPannel.Contours.ArrayContour(0 To Me.ArrayHurtValue.Length - 1)
            For i As Integer = 0 To ArrayHurtValue.Length - 1
                ContourPannel.Contours.ArrayContour(i) = New Contour
                ContourPannel.Contours.ArrayContour(i).ContourName = ArrayHurtName(i)
                ContourPannel.Contours.ArrayContour(i).ContourValue = ArrayHurtValue(i)
                ContourPannel.Contours.ArrayContour(i).HurtValue = ArrayHurtValue(i)
                ContourPannel.Contours.ArrayContour(i).ContourLine.ContourLineVisible = False '等值线不可见
                ContourPannel.Contours.ArrayContour(i).ContourLine.HurtVisible = True
                ContourPannel.Contours.ArrayContour(i).ContourLine.HurtLaberVisible = True
                ContourPannel.Contours.ArrayContour(i).ContourFill.ContourFillVisible = False '伤害填充不可见
            Next
            ContourPannel.Contours.ContourFillStartColor = Color.FromArgb(255, 0, 0)  '设置等值线填充的起始颜色
            ContourPannel.Contours.ContourFillEndColor = Color.FromArgb(255, 255, 0) '设置等值线填充的结束颜色
            ContourPannel.Contours.ContourFillColorGradual() '等值填充线颜色渐变

            ContourPannel.Contours.ContourStartColor = Color.FromArgb(255, 0, 0)   '设置等值线的起始颜色
            ContourPannel.Contours.ContourEndColor = Color.FromArgb(255, 255, 0)   '设置等值线的结束颜色
            ContourPannel.Contours.ContourColorGradual() '等值线颜色渐变

            ContourPannel.Legend.LegendContourFillVisible = False '
            Me.ContourPannel.Contours.ReCalContour = True
        End If

    End Sub
    ''' <summary>
    ''' 清空等值线等数组
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        ReDim ContourNames(-1)  '等值线的名称
        ReDim ContourValue(-1)  '等值线的值
        ReDim ArrayWeather(-1)  '气象条件数组
        ReDim ArrayTime(-1)  '时间数组
        ReDim CarePoint(-1)  '关心点数组,从(0)开始
        ReDim CarePointName(-1)  '关心点数组的名称，从(0)开始
        '火灾爆炸属性'----------------------------------------------------------
        ReDim ArrayHurtValue(-1) '伤害半径
        ReDim ArrayHurtName(-1) '伤害半径的名称
        ContourPannel = New Pannel '新的绘图类
    End Sub

    ''' <summary>
    ''' 初始化绘图对象，设置坐标轴，网格点，比例等。在调用此函数之前应先设置坐标轴的值。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitialPaint()

        If Me.ChartType = 0 Then
            '设置图形类型
            PannelSetting.PaintType = 0
            PannelSetting.gWidth = m_Xmax - m_Xmin
            PannelSetting.gHeight = m_Ymax - m_Ymin
            If PannelSetting.gWidth > PannelSetting.gHeight Then '按区域大小
                PannelSetting.mmScale = PannelSetting.gWidth / 100
            Else
                PannelSetting.mmScale = PannelSetting.gHeight / 100
            End If
            PannelSetting.gScale = PannelSetting.mmScale * PannelSetting.MMTOPIX '转换成mm的比例

            PannelSetting.OriginX = (-m_Xmin / PannelSetting.mmScale + 20) / PannelSetting.MMTOPIX
            PannelSetting.OriginY = (m_Ymax / PannelSetting.mmScale + 20) / PannelSetting.MMTOPIX
            PannelSetting.BackOriginX = 10
            PannelSetting.BackOriginY = -10
            PannelSetting.BackgScale = 1 '默认值为1，不放缩。
            PannelSetting.gAxisRect = New Rectangle(m_Xmin, m_Ymin, PannelSetting.gWidth, PannelSetting.gHeight)
        Else
            '设置图形类型
            PannelSetting.PaintType = 1
            PannelSetting.gWidth = m_Xmax - m_Xmin
            PannelSetting.gHeight = m_Ymax - m_Ymin
            If PannelSetting.gWidth > PannelSetting.gHeight Then '按区域大小
                PannelSetting.mmScale = PannelSetting.gWidth / 100
            Else
                PannelSetting.mmScale = PannelSetting.gHeight / 100
            End If
            PannelSetting.gScale = PannelSetting.mmScale * PannelSetting.MMTOPIX '转换成mm的比例

            PannelSetting.OriginX = (-m_Xmin / PannelSetting.mmScale + 20) / PannelSetting.MMTOPIX
            PannelSetting.OriginY = (m_Ymax / PannelSetting.mmScale + 20) / PannelSetting.MMTOPIX
            PannelSetting.BackOriginX = 10
            PannelSetting.BackOriginY = -10
            PannelSetting.BackgScale = 1 '默认值为1，不放缩。
            PannelSetting.gAxisRect = New Rectangle(m_Xmin, m_Ymin, PannelSetting.gWidth, PannelSetting.gHeight)
        End If
    End Sub
    ''' <summary>
    ''' 初始化绘图对象，设置坐标轴，网格点，比例等。在调用此函数之前应先设置坐标轴的值。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetRect()

        If Me.ChartType = 0 Then
            '设置图形类型
            PannelSetting.PaintType = 0
            PannelSetting.gWidth = m_Xmax - m_Xmin
            PannelSetting.gHeight = m_Ymax - m_Ymin

            PannelSetting.gAxisRect = New Rectangle(m_Xmin, m_Ymin, PannelSetting.gWidth, PannelSetting.gHeight)
        Else
            '设置图形类型
            PannelSetting.PaintType = 1
            PannelSetting.gWidth = m_Xmax - m_Xmin
            PannelSetting.gHeight = m_Ymax - m_Ymin
            PannelSetting.gAxisRect = New Rectangle(m_Xmin, m_Ymin, PannelSetting.gWidth, PannelSetting.gHeight)
        End If
    End Sub
    Public Sub DrawShape(ByVal grap As System.Drawing.Graphics)
        'grap.TranslateTransform(70 / PannelSetting.MMTOPIX, 70 / PannelSetting.MMTOPIX, MatrixOrder.Append) '将坐标系统平移
        ContourPannel.DrawPannel(grap) '绘图
    End Sub
    Public Sub setType(ByVal i As Integer)
        Me.m_ChartType = i
        PannelSetting.PaintType = i
    End Sub
    ''' <summary>
    ''' 根据最小值和步长及个数设置图形的坐标属性
    ''' </summary>
    ''' <param name="Xinit"></param>
    ''' <param name="Xdelta"></param>
    ''' <param name="Xnum"></param>
    ''' <param name="yinit"></param>
    ''' <param name="ydelta"></param>
    ''' <param name="ynum"></param>
    ''' <remarks></remarks>
    Public Sub SetGrid(ByVal Xinit As Single, ByVal Xdelta As Single, ByVal Xnum As Single, ByVal yinit As Single, ByVal ydelta As Single, ByVal ynum As Single)
        m_Xmin = Xinit
        m_Xmax = Xinit + (Xnum - 1) * Xdelta
        m_nCols = Xnum
        m_Ymin = yinit
        m_Ymax = yinit + (ynum - 1) * ydelta
        m_nRows = ynum

        ContourPannel.Axes.LeftAxis.MainAxisScale.Min = Xinit
        ContourPannel.Axes.LeftAxis.MainAxisScale.Max = Xinit + (Xnum - 1) * Xdelta
        ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Xdelta
        ContourPannel.Axes.BottomAxis.MainAxisScale.Min = yinit
        ContourPannel.Axes.BottomAxis.MainAxisScale.Max = yinit + (ynum - 1) * ydelta
        ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = ydelta
        ReDim GridPoint(m_nCols - 1, m_nRows - 1) '网格点数组，从(0，0)开始，用于绘制等值线图

    End Sub
End Class
