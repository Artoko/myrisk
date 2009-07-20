Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class AxisLabel
    'Inherits PublicLabel
    Public LabelVisible As Boolean '刻度标注是否可见
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)
    Public LabelFont As New Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    Public LabelColor As Integer = Color.Black.ToArgb
    Private MaxValue, MinValue As Double '轴的最大轴与最小值
    Private IncreaseValue As Double  '坐标的最大值、最小值和增加值
    Private inMax, inMin As Double  '用来画线的最大值和最小值，是整数
    Public AxesSide As AxesSide = AxesSide.LeftSide  '边
    Public Sub AxisLabelDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)

        '根据不同的坐标轴边，设置不同的最大值和最小值
        Select Case AxesSideValue
            Case AxesSide.LeftSide
                MinValue = PannelSetting.gAxisRect.Y
                MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                IncreaseValue = PannelSetting.gVMainIncrease '垂直轴的主刻度间隔
            Case AxesSide.BottomSide
                MinValue = PannelSetting.gAxisRect.X
                MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                IncreaseValue = PannelSetting.gHMainIncrease '水平轴的主刻度间隔  
            Case AxesSide.RightSide
                MinValue = PannelSetting.gAxisRect.Y
                MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                IncreaseValue = PannelSetting.gVMainIncrease '垂直轴的主刻度间隔  
            Case AxesSide.TopSide
                MinValue = PannelSetting.gAxisRect.X
                MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                IncreaseValue = PannelSetting.gHMainIncrease '水平轴的主刻度间隔  
        End Select

        If IncreaseValue > 0 Then
            inMin = MinValue
            inMax = MaxValue
            Dim nb As Integer
            If (MaxValue - MinValue) / IncreaseValue > 10 Then
                nb = Math.Truncate((MaxValue - MinValue) / IncreaseValue / 10)  '最多绘制10个标注
            Else
                nb = Math.Truncate((MaxValue - MinValue) / IncreaseValue)
            End If
            IncreaseValue = IncreaseValue * nb
            Dim i As Integer
            Dim LabelBrush As New SolidBrush(Color.FromArgb(LabelColor))

            Dim TextHeight, TextWidth, MaxTextHeight, MaxTextWidth As Double '字的高度和宽度

            If LabelVisible Then '如果可见就绘制坐标轴的刻度的标注
                Dim LabelFormat As New StringFormat
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Far
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
                            graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(PannelSetting.gAxisLabelRect.X, i + TextHeight / 2) '平移到绘字点
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '退出绘图容器
                            If MaxTextWidth < TextWidth Then
                                MaxTextWidth = TextWidth
                            End If
                        Next
                        '扩大绘制轴标题的左边区域
                        PannelSetting.gAxisTitleRect.X = PannelSetting.gAxisLabelRect.X - MaxTextWidth
                    Case AxesSide.BottomSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Center
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
                            graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(i, PannelSetting.gAxisLabelRect.Y) '平移到绘字点
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '退出绘图容器
                            If MaxTextHeight < TextHeight Then
                                MaxTextHeight = TextHeight
                            End If
                        Next
                        '扩大绘制轴标题的底边区域
                        PannelSetting.gAxisTitleRect.Y = PannelSetting.gAxisLabelRect.Y - MaxTextHeight
                    Case AxesSide.RightSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Near '左对齐
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
                            graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(PannelSetting.gAxisLabelRect.X + PannelSetting.gAxisLabelRect.Width, i + TextHeight / 2) '平移到右轴绘字点
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '退出绘图容器
                            If MaxTextWidth < TextWidth Then
                                MaxTextWidth = TextWidth
                            End If
                        Next
                        '扩大绘制轴标题的右边区域
                        PannelSetting.gAxisTitleRect.Width = PannelSetting.gAxisLabelRect.Width + MaxTextWidth + (PannelSetting.gAxisLabelRect.X - PannelSetting.gAxisTitleRect.X)
                    Case AxesSide.TopSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Center
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
                            graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(i, PannelSetting.gAxisLabelRect.Y + PannelSetting.gAxisLabelRect.Height + TextHeight) '平移到绘字点
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '退出绘图容器
                            If MaxTextHeight < TextHeight Then
                                MaxTextHeight = TextHeight
                            End If
                        Next
                        '扩大绘制轴标题的顶边区域
                        PannelSetting.gAxisTitleRect.Height = PannelSetting.gAxisLabelRect.Height + MaxTextHeight + (PannelSetting.gAxisLabelRect.Y - PannelSetting.gAxisTitleRect.Y)
                End Select
            Else
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        '缩小绘制轴标题的左边区域
                        PannelSetting.gAxisTitleRect.X = PannelSetting.gAxisLabelRect.X
                    Case AxesSide.BottomSide
                        '缩小绘制轴标题的底边区域
                        PannelSetting.gAxisTitleRect.Y = PannelSetting.gAxisLabelRect.Y
                    Case AxesSide.RightSide
                        '缩小绘制轴标题的右边区域
                        PannelSetting.gAxisTitleRect.Width = PannelSetting.gAxisLabelRect.Width + (PannelSetting.gAxisLabelRect.X - PannelSetting.gAxisTitleRect.X)
                    Case AxesSide.TopSide
                        '缩小绘制轴标题的顶边区域
                        PannelSetting.gAxisTitleRect.Height = PannelSetting.gAxisLabelRect.Height + (PannelSetting.gAxisLabelRect.Y - PannelSetting.gAxisTitleRect.Y)
                End Select
            End If
        End If
    End Sub
End Class
