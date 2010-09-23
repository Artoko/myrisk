Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class ContourLine
    '画等值线的类。可用这个类将计算好的等值线数组的点连接到一起
    Public PenProperty As New PenProperty '画笔的悔改类
    Public ContourLineVisible As Boolean = True '等值线是否可见
    Public LabelVisible As Boolean = False   '等值线标注是否可见
    Public HurtVisible As Boolean = False '伤害范围不可见
    Public HurtLaberVisible As Boolean = False '伤害标注不可见
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)
    Public LabelFont As New Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel)
    Public LabelColor As Color = Color.Black
    Public SmoothingMode As Boolean = False
    Public Curve As Boolean = False '样条
    Public Number As Integer = 6 '标注的小数点位数


    Public Sub DrawContourLine(ByVal grap As Graphics, ByVal ArrayContourPoints() As ContourPoints, ByVal ContourValue As Double, ByVal HurtValue As Double, ByVal x0 As Double, ByVal y0 As Double)  '绘制某一条等值线
        Dim ContourLinePen As New Pen(Color.FromArgb(PenProperty.color))
        ContourLinePen.DashStyle = PenProperty.DashStyle
        ContourLinePen.Width = PenProperty.WidthReal * PannelSetting.gScale
        Dim LabelBrush As New SolidBrush(LabelColor)
        If ContourLineVisible Then '如果等值线可见就绘制等值线
            '绘制等值线的标注,并通过path取得绘制标注的路径
            Dim ContourRegion As New Region(PannelSetting.gAxisRect) '绘等值线的方形区域，如果等值线在区域外则不绘制
            grap.SetClip(ContourRegion.Clone, CombineMode.Replace)

            Dim contourPoint() As Point3D '用于储存某给定值的所有等值线中的一条,其x,y分别为整数型。这个数组用于绘图
            Dim i As Integer = 0
            Dim j As Integer = 0
            If ArrayContourPoints IsNot Nothing AndAlso ArrayContourPoints.Length > 0 Then
                For i = 0 To ArrayContourPoints.Length - 1
                    contourPoint = ArrayContourPoints(i).vecContourPoints
                    If contourPoint.Length >= 2 Then '如果数组＞＝2个点则绘制线条，否则不绘制
                        '以下根据每一条等值线的情况进行绘制等值线的标注
                        If LabelVisible Then '如果等值线的标注可见，就绘制等值线的标注
                            Dim LabelFormat As New StringFormat
                            Dim TextHeight As Double '字的高度
                            LabelFormat.Alignment = StringAlignment.Center   '文字左对齐
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
                            graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
                            '求出绘字的位置
                            Dim n As Integer
                            n = contourPoint.Length * 2 / 3
                            'If n <= 0 Then
                            '    n = 1
                            'End If
                            myMatrix.Translate((contourPoint(n).x + contourPoint(n - 1).x) / 2, (contourPoint(n).y + contourPoint(n - 1).y) / 2) '平移到两点之间
                            '求出绘字的角度
                            Dim Angle As Double
                            Dim DL As Double
                            DL = Math.Sqrt((contourPoint(n).y - contourPoint(n - 1).y) ^ 2 + (contourPoint(n).x - contourPoint(n - 1).x) ^ 2)
                            'If (contourPoint(n + 1).Y - contourPoint(n - 1).Y) * (contourPoint(n + 1).X - contourPoint(n - 1).X) < 0 Then
                            '    DL = -1 * DL
                            'End If
                            Angle = 180 / Math.PI * Math.Asin((contourPoint(n).y - contourPoint(n - 1).y) / DL)
                            If contourPoint(n).x - contourPoint(n - 1).x < 0 Then '第二和第三象限，-180度
                                Angle = -Angle
                            End If
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale

                            myMatrix.Rotate(Angle)
                            myMatrix.Translate(0, TextHeight / 2)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
                            grap.Transform = myMatrix
                            If SmoothingMode = True Then '消除锯齿
                                grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            End If
                            Try
                                grap.DrawString(FormatNumber(ContourValue, Number), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            Catch

                            End Try
                            grap.EndContainer(graphicsContainer) '退出绘图容器
                            '通过路径变换获得制字的区域
                            Dim Mypath As New GraphicsPath()
                            Mypath.AddString(FormatNumber(ContourValue, Number), LabelFont.FontFamily, LabelFont.Style, LabelFont.Size, New PointF(0, 0), LabelFormat)
                            Mypath.Transform(myMatrix)
                            Dim rectf As RectangleF = Mypath.GetBounds()
                            Dim region As New Region(rectf) '绘图的标注的路径区域 
                            ContourRegion.Exclude(region.Clone) '相减
                            grap.SetClip(ContourRegion.Clone, CombineMode.Replace)
                        End If
                        If SmoothingMode = True Then '消除锯齿
                            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        End If
                        Dim m As Integer
                        Dim DrawContour(contourPoint.Length - 1) As PointF
                        For m = 0 To contourPoint.Length - 1
                            DrawContour(m).X = contourPoint(m).x
                            DrawContour(m).Y = contourPoint(m).y
                        Next
                        If Curve = True Then
                            grap.DrawCurve(ContourLinePen, DrawContour)
                        Else
                            grap.DrawLines(ContourLinePen, DrawContour)
                        End If
                    End If
                Next
            End If
        End If
        '绘制伤害区域
        If HurtVisible And HurtValue > 0 Then '如果伤害线可见就绘制线
            '绘制伤害线的标注,并通过path取得绘制标注的路径
            Dim HurtRegion As New Region(PannelSetting.gAxisRect) '绘伤害线的方形区域，如果伤害线在区域外则不绘制
            grap.SetClip(HurtRegion.Clone, CombineMode.Replace)
            If HurtLaberVisible Then '如果伤害标注可见
                Dim TextHeight As Double '字的高度
                Dim LabelFormat As New StringFormat

                LabelFormat.Alignment = StringAlignment.Center   '文字左对齐
                Dim myMatrix As New Matrix()
                Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
                graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
                '求出绘字的位置。如果是绘字的位置位于30度角上。

                Dim MoveAngle As Integer = 90
                myMatrix.Translate(HurtValue * Math.Cos(MoveAngle / 180 * Math.PI), HurtValue * Math.Sin(MoveAngle / 180 * Math.PI)) '平移到绘制点
                '求出绘字的角度
                Dim Angle As Double
                Angle = MoveAngle - 90
                TextHeight = grap.MeasureString(CStr(HurtValue), LabelFont).Height * PannelSetting.gScale
                myMatrix.Rotate(Angle)
                myMatrix.Translate(0 + x0, TextHeight / 2 + y0)
                myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '将字体按比例回放
                myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
                grap.Transform = myMatrix
                Try
                    If SmoothingMode = True Then '消除锯齿
                        grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    End If
                    grap.DrawString(FormatNumber(HurtValue, Number) & "m", LabelFont, LabelBrush, 0, 0, LabelFormat)
                Catch

                End Try
                grap.EndContainer(graphicsContainer) '退出绘图容器
                '通过路径变换获得制字的区域
                Dim Mypath As New GraphicsPath()
                Mypath.AddString(FormatNumber(HurtValue, Number) & " m", LabelFont.FontFamily, LabelFont.Style, LabelFont.Size, New PointF(0, 0), LabelFormat)
                Mypath.Transform(myMatrix)
                Dim rectf As RectangleF = Mypath.GetBounds()
                Dim region As New Region(rectf) '绘图的标注的路径区域 
                HurtRegion.Exclude(region.Clone) '相减
                grap.SetClip(HurtRegion.Clone, CombineMode.Replace)
            End If
            If SmoothingMode = True Then '消除锯齿
                grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            End If
            grap.DrawEllipse(ContourLinePen, CSng(-HurtValue + x0), CSng(-HurtValue + y0), 2 * CSng(HurtValue), 2 * CSng(HurtValue))
        End If
    End Sub
End Class
