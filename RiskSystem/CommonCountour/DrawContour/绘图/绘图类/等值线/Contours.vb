Imports System.Drawing.Drawing2D
<Serializable()> Public Class Contours
    '等值线数组类，用于绘制等值线数组。
    Public GridPoint(-1, -1) As Double '网格点
    Public ContourCont As Integer '等值线条数
    Public nRow, nCol As Integer '行、列数
    Public Xmin, Ymin, Xmax, Ymax As Double '网格的最大坐标和最小坐标
    Public ArrayDamageRange(-1) As Double '用于储存伤害范围
    Private ArrayContourValue(-1) As Double '等值线值数组
    Public ArrayContour(-1) As Contour '等值线数组
    Public SortA(-1) As Integer '用数组来储存等值线的顺序
    <NonSerialized()> Private FillContourRegion(-1) As Region '用于储存填充等值线值区域的数组
    <NonSerialized()> Private CutFillContourRegion(-1) As Region '用于储存剪切后的填充等值线值区域的数组

    Public ContourFillStartColor As Color = Color.FromArgb(255, 0, 0)
    Public ContourFillEndColor As Color = Color.FromArgb(255, 255, 0)
    Public ContourStartColor As Color = Color.FromArgb(255, 0, 0)
    Public ContourEndColor As Color = Color.FromArgb(255, 255, 0)
    Public ContourLabelStartColor As Color = Color.Black
    Public ContourLabelEndColor As Color = Color.Black  '

    Public ReCalContour As Boolean = True '重新生成等值线标志。考虑到重新生成等值线的速度较慢，设置该标志。当为True时重新生成。如果用户不改变等值线，则不重新生成该等值线。
    Public x0 As Double '火灾爆炸污染源坐标
    Public y0 As Double '火灾爆炸污染源坐标

    Public Sub IntialContours(ByVal ContourCont As Integer)
        ReDim ArrayContour(0 To ContourCont - 1)
    End Sub
    Public Sub DrawContours(ByVal grap As Graphics)
        Dim k As Integer
        If ReCalContour = True Then '重新计算等值线的区域
            ReDim FillContourRegion(ArrayContour.Length - 1)
            ReDim CutFillContourRegion(ArrayContour.Length - 1)
            For k = 0 To ArrayContour.Length - 1
                FillContourRegion(k) = New Region(New Rectangle(0, 0, 0, 0)) '设置区域为空的区域
                CutFillContourRegion(k) = New Region(New Rectangle(0, 0, 0, 0)) '设置区域为空的区域
            Next
        End If
        ReDim ArrayContourValue(ArrayContour.Length - 1)
        '排序等值线
        SortContour()
        '填充等值线
        Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器
        graphicsContainer = grap.BeginContainer() '嵌套的 Graphics 容器
        FillRegions(grap) '绘制等值线的区域
        '逐条绘制等值线

        Dim i As Integer
        For i = 0 To ArrayContour.Length - 1
            ArrayContour(SortA(i)).DrawContour(grap, SortA(i), GridPoint, nRow, nCol, Xmin, Ymin, Xmax, Ymax, ReCalContour, x0, y0)
        Next
        ReCalContour = False
        grap.EndContainer(graphicsContainer) '退出绘图容器
    End Sub
    Private Sub SortContour() '排序等值线
        ReDim SortA(ArrayContour.Length - 1) '用数组来储存等值线的顺序
        Dim i, j, Exechange As Integer
        For i = 0 To ArrayContour.Length - 1 '初始化等值线数组的顺序
            SortA(i) = i
        Next
        If PannelSetting.PaintType = 0 Then
            For i = 0 To ArrayContour.Length - 1 '对数组进行排序，按从小至大的顺序排序
                For j = i To ArrayContour.Length - 1
                    If ArrayContour(SortA(i)).ContourValue > ArrayContour(SortA(j)).ContourValue Then '交换法进行排序
                        Exechange = SortA(i)
                        SortA(i) = SortA(j)
                        SortA(j) = Exechange
                    End If
                Next
            Next
        Else
            For i = 0 To ArrayContour.Length - 1 '对数组进行排序，按从大至小的顺序排序
                For j = i To ArrayContour.Length - 1
                    If ArrayContour(SortA(i)).ContourValue < ArrayContour(SortA(j)).ContourValue Then '交换法进行排序
                        Exechange = SortA(i)
                        SortA(i) = SortA(j)
                        SortA(j) = Exechange
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub FillRegions(ByVal grap As Graphics)
        Dim i As Integer
        '计算区域
        For i = 0 To ArrayContour.Length - 1
            ArrayContourValue(SortA(i)) = ArrayContour(SortA(i)).ContourValue
            ArrayContour(SortA(i)).GetFillRegion(grap, SortA(i), GridPoint, nRow, nCol, Xmin, Ymin, Xmax, Ymax, FillContourRegion, ReCalContour, x0, y0)
        Next
        '剪切区域
        For i = 0 To ArrayContour.Length - 1
            ArrayContour(SortA(i)).ContourFill.CutRegion(SortA(i), FillContourRegion, CutFillContourRegion, ArrayContourValue, ReCalContour)
        Next
        '填充区域
        For i = 0 To ArrayContour.Length - 1
            ArrayContour(SortA(i)).ContourFill.FillContour(grap, SortA(i), FillContourRegion, CutFillContourRegion)
        Next
    End Sub

    Public Sub ContourFillColorGradual() '填充颜色渐变
        SortContour() '排序等值线
        Dim i As Integer
        Dim iColorR As Double  '红色间距
        Dim iColorG As Double '绿色间距
        Dim iColorB As Double '蓝色间距
        Dim R As Integer '红色
        Dim G As Integer '绿色
        Dim B As Integer '蓝色

        If ArrayContour.Length - 1 > 0 Then
            iColorR = (CInt(ContourFillEndColor.R) - CInt(ContourFillStartColor.R)) / (ArrayContour.Length - 1)
            iColorG = (CInt(ContourFillEndColor.G) - CInt(ContourFillStartColor.G)) / (ArrayContour.Length - 1)
            iColorB = (CInt(ContourFillEndColor.B) - CInt(ContourFillStartColor.B)) / (ArrayContour.Length - 1)
            For i = 0 To ArrayContour.Length - 1
                R = ContourFillEndColor.R - iColorR * i
                G = ContourFillEndColor.G - iColorG * i
                B = ContourFillEndColor.B - iColorB * i
                If R > 255 Then
                    R = 255
                ElseIf R < 0 Then
                    R = 0
                End If
                If G > 255 Then
                    G = 255
                ElseIf G < 0 Then
                    G = 0
                End If
                If B > 255 Then
                    B = 255
                ElseIf B < 0 Then
                    B = 0
                End If
                ArrayContour(SortA(i)).ContourFill.ContourForeColor = Color.FromArgb(R, G, B)
            Next
        ElseIf ArrayContour.Length > 0 Then
            ArrayContour(0).ContourFill.ContourForeColor = ContourFillStartColor
        End If
    End Sub
    Public Sub ContourColorGradual() '画线颜色渐变

        SortContour() '排序等值线
        Dim i As Integer
        Dim iColorR As Double  '红色间距
        Dim iColorG As Double '绿色间距
        Dim iColorB As Double '蓝色间距
        Dim R As Integer '红色
        Dim G As Integer '绿色
        Dim B As Integer '蓝色
        If ArrayContour.Length - 1 > 0 Then
            iColorR = (CInt(ContourEndColor.R) - CInt(ContourStartColor.R)) / (ArrayContour.Length - 1)
            iColorG = (CInt(ContourEndColor.G) - CInt(ContourStartColor.G)) / (ArrayContour.Length - 1)
            iColorB = (CInt(ContourEndColor.B) - CInt(ContourStartColor.B)) / (ArrayContour.Length - 1)
            For i = 0 To ArrayContour.Length - 1
                R = ContourEndColor.R - iColorR * i
                G = ContourEndColor.G - iColorG * i
                B = ContourEndColor.B - iColorB * i
                If R > 255 Then
                    R = 255
                ElseIf R < 0 Then
                    R = 0
                End If
                If G > 255 Then
                    G = 255
                ElseIf G < 0 Then
                    G = 0
                End If
                If B > 255 Then
                    B = 255
                ElseIf B < 0 Then
                    B = 0
                End If
                ArrayContour(SortA(i)).ContourLine.PenProperty.color = Color.FromArgb(R, G, B).ToArgb
            Next
        ElseIf ArrayContour.Length > 0 Then
            ArrayContour(0).ContourLine.PenProperty.color = ContourStartColor.ToArgb
        End If

    End Sub
    Public Sub ContourLabelColorGradual() '等值线颜色渐变
        SortContour() '排序等值线
        Dim i As Integer
        Dim iColorR As Double  '红色间距
        Dim iColorG As Double '绿色间距
        Dim iColorB As Double '蓝色间距
        Dim R As Integer '红色
        Dim G As Integer '绿色
        Dim B As Integer '蓝色
        If ArrayContour.Length - 1 > 0 Then
            iColorR = (CInt(ContourLabelEndColor.R) - CInt(ContourLabelStartColor.R)) / (ArrayContour.Length - 1)
            iColorG = (CInt(ContourLabelEndColor.G) - CInt(ContourLabelStartColor.G)) / (ArrayContour.Length - 1)
            iColorB = (CInt(ContourLabelEndColor.B) - CInt(ContourLabelStartColor.B)) / (ArrayContour.Length - 1)
            For i = 0 To ArrayContour.Length - 1
                R = ContourLabelEndColor.R - iColorR * i
                G = ContourLabelEndColor.G - iColorG * i
                B = ContourLabelEndColor.B - iColorB * i
                If R > 255 Then
                    R = 255
                ElseIf R < 0 Then
                    R = 0
                End If
                If G > 255 Then
                    G = 255
                ElseIf G < 0 Then
                    G = 0
                End If
                If B > 255 Then
                    B = 255
                ElseIf B < 0 Then
                    B = 0
                End If
                ArrayContour(SortA(i)).ContourLine.LabelColor = Color.FromArgb(R, G, B)
            Next
        ElseIf ArrayContour.Length > 0 Then
            ArrayContour(0).ContourLine.LabelColor = ContourLabelStartColor
        End If
    End Sub

End Class
