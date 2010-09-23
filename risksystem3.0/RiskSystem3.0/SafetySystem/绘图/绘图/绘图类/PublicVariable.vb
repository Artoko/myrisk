Module PublicVariable

    Public gAxisRect As Rectangle '标示绘制坐标轴的矩形区域，转换了坐标后的区域
    Public gAxisLabelRect As Rectangle '表示绘制坐标轴的标注的区域，转换了坐标后的区域
    Public gAxisTitleRect As Rectangle '表示绘制坐标轴的标题的区域，转换了坐标后的区域
    Public gTitleRect As Rectangle '表示绘制标题的区域
    Public gLegendContourFillRect As Rectangle '等值线填充图例的区域，未转换坐标的区域
    Public gLegendContourLineRect As Rectangle '等值线填充图例的区域，未转换坐标的区域
    Public gLegendSymbolRect As Rectangle '等值线填充图例的区域，未转换坐标的区域

    Public gRightLegendPoint As Single '表示右轴的标题的右边，用于绘制图例
    Public mmScale As Single = 10 '1mm表示10m，实际比例为1:10000。本程序以1000m作为100mm默认的宽度，如果宽度为5000m，则应该改变比例,应为5000/1000。因此，实际比例应为mmScale*1000
    Public gScale As Single = 1 '绘图比例，由于采用象素绘图，还应将比例换为mm。
    Public gWidth As Single = 2000 '区域的宽度默认宽度为2000m
    Public gHeight As Single = 2000 '区域的宽度默认高度为2000m
    Public gVMainIncrease As Single = 500 '垂直轴的主刻度间隔
    Public gHMainIncrease As Single = 500 '水平轴的主刻度间隔
    Public Const MMTOPIX = 0.265 '把象素换成mm的常数

    Public OriginX As Integer = 70 / MMTOPIX
    Public OriginY As Integer = 70 / MMTOPIX
    Public BackOriginX As Integer = 10
    Public BackOriginY As Integer = -10
    Public BackgScale As Single = 1 '默认值为1，不放缩。

    Public PaintType As Single = 0 '绘图的类型，0为等值线，1为火灾爆炸


    Public OriginToUtm As Point

End Module
