Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Text
<Serializable()> Public Class AxisTitle

    Public TitleName As String
    Public TitleVisible As Boolean
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)
    Public TitleFont As New Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    Public TitleColor As Integer = Color.Black.ToArgb

    Public Sub DrawTitle(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)
        'rect 参数为来表示除去坐标刻度及坐标标注以外的区域
        If TitleVisible Then '如果可见就绘制坐标轴的轴线
            Dim TitleFormat As New StringFormat
            If TitleName <> Nothing Then '如果字符串不为空
                Dim TitleBrush As New SolidBrush(Color.FromArgb(TitleColor))
                TitleFormat.Alignment = StringAlignment.Center
                Dim myMatrix As New Matrix()
                Dim TextHeight As Double '字的高度
                TextHeight = grap.MeasureString(TitleName, TitleFont).Height * PannelSetting.gScale
                Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器
                graphicsContainer = grap.BeginContainer() '嵌套的 Graphics 容器
                Select Case AxesSideValue  '根据坐标标题所在的边不同，采用不同的坐标变换方法
                    Case AxesSide.LeftSide
                        myMatrix.Translate(PannelSetting.gAxisTitleRect.X - TextHeight, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height / 2)
                        myMatrix.Rotate(90)
                    Case AxesSide.BottomSide
                        myMatrix.Translate(PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width / 2, PannelSetting.gAxisTitleRect.Y - 2 * PannelSetting.gScale)
                        myMatrix.Rotate(0)
                    Case AxesSide.RightSide
                        myMatrix.Translate(PannelSetting.gAxisTitleRect.X + PannelSetting.gAxisTitleRect.Width + 2 * PannelSetting.gScale, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height / 2)
                        myMatrix.Rotate(90)
                        '扩大右边图例的绘制位置
                        PannelSetting.gRightLegendPoint = PannelSetting.gAxisTitleRect.X + PannelSetting.gAxisTitleRect.Width + 10 * PannelSetting.gScale + TextHeight
                    Case AxesSide.TopSide
                        myMatrix.Translate(PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width / 2, PannelSetting.gAxisTitleRect.Y + PannelSetting.gAxisTitleRect.Height + TextHeight)
                        myMatrix.Rotate(0)
                End Select
                myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0))
                grap.Transform = myMatrix
                grap.DrawString(TitleName, TitleFont, TitleBrush, 0, 0, TitleFormat)
                grap.EndContainer(graphicsContainer) '退出绘图容器
            End If
        Else
            Select Case AxesSideValue  '根据坐标标题所在的边不同，采用不同的坐标变换方法
                Case AxesSide.RightSide
                    '缩小右边图例的绘制位置
                    PannelSetting.gRightLegendPoint = PannelSetting.gAxisTitleRect.X + PannelSetting.gAxisTitleRect.Width + 10 * PannelSetting.gScale
            End Select
        End If
    End Sub

End Class
