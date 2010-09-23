Imports System.Drawing.Drawing2D
<Serializable()> Public Class ContourFill

    '填充等值线的类。可用这个类将计算好的等值线数组进行填充
    Public HatchStyle As HatchStyle
    Public ContourBackColor As Color = Color.White   '填充图案的背景的颜色
    Public ContourForeColor As Color = Color.Black  '填充图案的前景的颜色
    Public ContourFillVisible As Boolean = True  '等值线填充是否可见
    Public BackTransparent As Integer = 80 '背景透明度。0表示不透明，100表示全透明
    Public ForeTransparent As Integer = 50 '前景透明度。0表示不透明，100表示全透明
    Public BrushStyle As Integer = 0 '画刷的样式。0为实心画刷，0为图案画刷
    Public ContourArea As Double  '区域面积单位为km。
    Public Curve As Boolean '样条
    '等值线填充数组
    Private ArrayEdgePt(-1) As EdgePt '区域边界点的数组
    Private ArrayContourRegion(-1) As ContourRegion '等值线区数组。该数据中第一个元素储存了一个等值线区域的边界点
    Private ArrayContourPoints(-1) As ContourPoints '等值线数据。该数组中每个元素储存了一条等值线的数组
    Public Sub CalculateFillContour(ByVal grap As Graphics, ByVal ArrayContour() As ContourPoints, ByVal nContour As Integer, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal FillContourRegion() As Region, ByVal Contourvalue As Double, ByVal HurtValue As Double, ByVal ReCalContour As Boolean, ByVal x0 As Double, ByVal y0 As Double) '求得某一条等值线
        If PannelSetting.PaintType = 0 Then '泄漏事故
            '求出非闭合等值线围成的区域---------------------------------------------------------------
            ArrayContourPoints = ArrayContour ' 根据求得的等值线求出所有的等值线段
            IntiArrayEdgePt(GridPoint, row, col, X_min, Y_min, X_max, Y_max) '初始化边界点序列的数组
            IntiArrayContourRegion(GridPoint, row, col, X_min, Y_min, X_max, Y_max, Contourvalue) '初始化等值线区域数组
            '通过本函数求还求得这一等值线区域的面积
            ContourArea = 0 '初始化面积为0
            Dim UnionContourRegion As New Region(New Rectangle(0, 0, 0, 0)) '所有等值线区域的并集为空
            '首先求得等值线的所有线条和它的起点与终点
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim k As Integer = 0
            If ArrayContourRegion IsNot Nothing AndAlso ArrayContourRegion.Length > 0 Then '如果等值线区域数组不为空，则根据该数组形成的顶点开始求其围成的区域
                For i = 0 To ArrayContourRegion.Length - 1
                    Dim ConnectContour(-1) As Point3D  '用于储存一条连通的等值线
                    For j = 0 To ArrayContourRegion(i).vecContourRegPoints.Length - 2 '将所有的点连接起来
                        Dim n As Integer = ArrayContourRegion(i).vecContourRegPoints(j).nContourIndex
                        Dim OneContour(0) As Point3D
                        If n >= 0 Then '如果有等值线，将等值线的值给数组。否则
                            OneContour = ArrayContourPoints(n).vecContourPoints.Clone
                        Else
                            OneContour(0) = ArrayContourRegion(i).vecContourRegPoints(j).ptEdge
                        End If
                        If ArrayContourRegion(i).vecContourRegPoints(j).nContourIndex = ArrayContourRegion(i).vecContourRegPoints(j + 1).nContourIndex And ArrayContourRegion(i).vecContourRegPoints(j).nPtAttribute <> 2 Then '如果是等值线且该等值线没连接过，则连接
                            If ArrayContourRegion(i).vecContourRegPoints(j).nPtAttribute = 1 Then '如果是等值线的尾开始连接，则逆序
                                Dim ReOneContour As Point3D
                                For k = 0 To OneContour.Length / 2 - 1
                                    ReOneContour = OneContour(k)
                                    OneContour(k) = OneContour(OneContour.Length - 1 - k)
                                    OneContour(OneContour.Length - 1 - k) = ReOneContour
                                Next
                            End If
                            ReDim Preserve ConnectContour(ConnectContour.Length + OneContour.Length - 1)
                            For k = 0 To OneContour.Length - 1
                                ConnectContour(ConnectContour.Length - OneContour.Length + k) = OneContour(k) '连接
                            Next
                            j = j + 1
                        ElseIf OneContour.Length = 1 Then '否则是一个点，直接连接该点
                            ReDim Preserve ConnectContour(ConnectContour.Length + OneContour.Length - 1)
                            For k = 0 To OneContour.Length - 1
                                ConnectContour(ConnectContour.Length - OneContour.Length + k) = OneContour(k) '连接
                            Next
                        End If
                    Next
                    '将最后一个点与等值线相连
                    ReDim Preserve ConnectContour(ConnectContour.Length)
                    ConnectContour(ConnectContour.Length - 1) = ArrayContourRegion(i).vecContourRegPoints(ArrayContourRegion(i).vecContourRegPoints.Length - 1).ptEdge
                    ''将中间重复的点去除
                    'Dim Rn, Re As Integer
                    'For Rn = 0 To ConnectContour.Length - 2
                    '    If ConnectContour(Rn) = ConnectContour(Rn + 1) Then '如果两个相近的点相同，则去除该点
                    '        For Re = Rn To ConnectContour.Length - 2
                    '            ConnectContour(Re) = ConnectContour(Re + 1)
                    '        Next
                    '        ReDim Preserve ConnectContour(ConnectContour.Length - 2) '数组减1
                    '        Rn -= 1 '外围数组减1
                    '    End If
                    '    If Rn = ConnectContour.Length - 2 Then '如果相等则跳出
                    '        Exit For
                    '    End If
                    'Next
                    If ConnectContour IsNot Nothing AndAlso ConnectContour.Length > 1 Then '对于只有四个角点的线，不进行交集
                        Dim m As Integer
                        Dim DrawContour(ConnectContour.Length - 1) As PointF
                        For m = 0 To ConnectContour.Length - 1
                            DrawContour(m).X = ConnectContour(m).x
                            DrawContour(m).Y = ConnectContour(m).y
                        Next
                        Dim path As New GraphicsPath()
                        If Curve = True Then
                            path.AddCurve(DrawContour)
                        Else
                            path.AddLines(DrawContour)
                        End If
                        '求这个区域的交集
                        Dim region As New Region(path)
                        Dim ContourRegion As New Region(PannelSetting.gAxisRect) '绘等值线的方形区域，如果等值线在区域外则不绘制
                        ContourRegion.Intersect(region)
                        UnionContourRegion.Union(ContourRegion) '求并集，得出所有等值线的区域
                        '求这一条等值线的区域围成的面积
                        ContourArea = ContourArea + TriFillContourArea(DrawContour, region)
                    End If
                Next
            End If
            '找出封闭等值线的区域---------------------------------------------------
            For i = 0 To ArrayContourPoints.Length - 1
                If ArrayContourPoints(i).vecContourPoints(0).x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x _
                And ArrayContourPoints(i).vecContourPoints(0).y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y Then '如果首尾相等，则为闭合等值线
                    '先找到内部的点
                    Dim m As Integer
                    Dim DrawContour(ArrayContourPoints(i).vecContourPoints.Length - 1) As PointF
                    For m = 0 To ArrayContourPoints(i).vecContourPoints.Length - 1
                        DrawContour(m).X = ArrayContourPoints(i).vecContourPoints(m).x
                        DrawContour(m).Y = ArrayContourPoints(i).vecContourPoints(m).y
                    Next
                    Dim path As New GraphicsPath()
                    If Curve = True Then
                        path.AddCurve(DrawContour)
                    Else
                        path.AddLines(DrawContour)
                    End If
                    '求这个区域的交集
                    Dim region As New Region(path)
                    If IsGreat(DrawContour, GridPoint, row, col, X_min, Y_min, X_max, Y_max, Contourvalue, region.Clone) Then '如果封闭曲线的内部区域>=等值线，则该等值线的区域为并集，否则应排除该区域
                        UnionContourRegion.Union(region) '求并集，得出所有等值线的区域
                        '求这一条等值线的区域围成的面积
                        ContourArea = ContourArea + TriFillContourArea(DrawContour, region)
                    Else
                        UnionContourRegion.Exclude(region)
                        '求这一条等值线的区域围成的面积
                        ContourArea = ContourArea - TriFillContourArea(DrawContour, region)
                    End If
                End If
            Next
            '根据上面求得的区域，将区域的值给数组
            FillContourRegion(nContour) = UnionContourRegion
            'End If
        Else '火灾事故
        ContourArea = Math.PI * HurtValue ^ 2
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(-HurtValue + x0, -HurtValue + y0, HurtValue * 2, HurtValue * 2)
        path.AddEllipse(rect)
        '求这个区域的交集
        Dim region As New Region(path)
        Dim ARegion As New Region(PannelSetting.gAxisRect) '绘等值线的方形区域，如果等值线在区域外则不绘制
        ARegion.Intersect(region)
        FillContourRegion(nContour) = ARegion
        End If

    End Sub
    Private Function IsGreat(ByVal ContourPoints() As PointF, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal ContourValue As Double, ByVal Aregion As Region) As Boolean
        For i As Integer = 0 To col - 1
            For j As Integer = 0 To row - 1
                Dim xStep As Double = (X_max - X_min) / (col - 1)
                Dim yStep As Double = (Y_max - Y_min) / (row - 1)
                Dim x As Double = X_min + xStep * i
                Dim y As Double = Y_max - yStep * j
                If Aregion.IsVisible(x, y) And GridPoint(j, i) > ContourValue Then
                    Return True
                End If
            Next
        Next
        Return False

        'Dim path As New GraphicsPath()
        'path.AddLines(ContourPoints)
        'Dim region As New Region(path)
        'Dim i, ai, aj, x1, y1 As Integer
        'Dim p1, p2, p3, pCenter As PointF
        'For i = 0 To ContourPoints.Length - 3
        '    p1 = ContourPoints(i)
        '    p2 = ContourPoints(i + 1)
        '    p3 = ContourPoints(i + 2)
        '    If p1 <> p2 And p1 <> p3 And p2 <> p3 Then
        '        pCenter = Center(p1, p2, p3)
        '        ai = row - 1 - CInt((pCenter.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
        '        aj = CInt((pCenter.X - X_min) / ((X_max - X_min) / (col - 1)))
        '        x1 = aj * ((X_max - X_min) / (col - 1)) + X_min
        '        y1 = (row - 1 - ai) * ((Y_max - Y_min) / (row - 1)) + Y_min
        '        '判断这个点是否在三角形的任何一条边上
        '        If IsOnLine(p1, p2, p3, New Point(x1, y1)) = False Then '如果该点不在三角形的任何一边上，则
        '            If region.IsVisible(x1, y1) = True Then
        '                If GridPoint(ai, aj) >= ContourValue Then '如果一个点的中间点>=等值线值
        '                    IsGreat = True
        '                    Exit Function
        '                Else
        '                    IsGreat = False
        '                    Exit Function
        '                End If
        '            End If
        '        End If
        '    End If
        'Next
        'IsGreat = False
    End Function
    Private Function IsOnLine(ByVal p1 As PointF, ByVal p2 As PointF, ByVal p3 As PointF, ByVal pG As PointF) As Boolean
        '根据三角形定理，任意三角形的两边的差，小于第三边
        If Math.Abs(TwoPointsDistance(pG, p1) - TwoPointsDistance(pG, p2)) >= TwoPointsDistance(p1, p2) Then
            Return True
        ElseIf Math.Abs(TwoPointsDistance(pG, p2) - TwoPointsDistance(pG, p3)) >= TwoPointsDistance(p2, p3) Then
            Return True
        ElseIf Math.Abs(TwoPointsDistance(pG, p3) - TwoPointsDistance(pG, p1)) >= TwoPointsDistance(p3, p1) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function TwoPointsDistance(ByVal point1 As PointF, ByVal point2 As PointF) As Double
        Return Math.Sqrt(((point1.X - point2.X) ^ 2 + (point1.Y - point2.Y) ^ 2))
    End Function
    Public Sub CutRegion(ByVal nContour As Integer, ByVal FillContourRegion() As Region, ByVal CutFillContourRegion() As Region, ByVal ArrayContourValue() As Double, ByVal ReCalContour As Boolean)
        '根据等值线填充区域求出等值线填充的剪切区域
        If PannelSetting.PaintType = 0 Then '如果是等值线区域
            Dim region As Region = FillContourRegion(nContour)
            Dim LitleRegion As New Region()
            Dim i As Integer
            Dim conValue As Double = -1
            For i = 0 To FillContourRegion.Length - 1 '先找出最大值
                If ArrayContourValue(i) > conValue Then
                    conValue = ArrayContourValue(i)
                    LitleRegion = FillContourRegion(i).Clone
                End If
            Next
            If conValue <> -1 Then
                Dim EXC As Boolean = False
                For i = 0 To FillContourRegion.Length - 1 '找出小于本区域的邻近区域
                    If ArrayContourValue(i) > ArrayContourValue(nContour) And ArrayContourValue(i) <= conValue Then
                        conValue = ArrayContourValue(i)
                        LitleRegion = FillContourRegion(i).Clone
                        EXC = True
                    End If
                Next
                If EXC Then '如果不是本区域
                    region.Exclude(LitleRegion.Clone)
                End If
                CutFillContourRegion(nContour) = region.Clone
            End If
        Else '伤害区域
            Dim region As Region = FillContourRegion(nContour)
            Dim LitleRegion As New Region()
            Dim i As Integer
            Dim conValue As Double = 1000000000
            For i = 0 To FillContourRegion.Length - 1 '先找出最小值
                If ArrayContourValue(i) < conValue Then
                    conValue = ArrayContourValue(i)
                    LitleRegion = FillContourRegion(i).Clone
                End If
            Next
            If conValue <> -1 Then
                Dim EXC As Boolean = False
                For i = 0 To FillContourRegion.Length - 1 '找出小于本区域的邻近区域
                    If ArrayContourValue(i) < ArrayContourValue(nContour) And ArrayContourValue(i) >= conValue Then
                        conValue = ArrayContourValue(i)
                        LitleRegion = FillContourRegion(i).Clone
                        EXC = True
                    End If
                Next
                If EXC Then '如果不是本区域
                    region.Exclude(LitleRegion.Clone)
                End If
                CutFillContourRegion(nContour) = region.Clone
            End If
        End If
    End Sub
    Public Sub FillContour(ByVal grap As Graphics, ByVal nContour As Integer, ByVal FillContourRegion() As Region, ByVal CutFillContourRegion() As Region) '填充某一条等值线

        Dim ForeAlpha As Integer 'alpha 值越接近于 0，背景颜色的权重越大；alpha 值越接近于 255，线条颜色的权重越大。
        ForeAlpha = 255 - CInt(ForeTransparent * 2.55)
        Dim ForeColor As Color = Color.FromArgb(ForeAlpha, ContourForeColor.R, ContourForeColor.G, ContourForeColor.B)

        Dim BackAlpha As Integer 'alpha 值越接近于 0，背景颜色的权重越大；alpha 值越接近于 255，线条颜色的权重越大。
        BackAlpha = 255 - CInt(BackTransparent * 2.55)
        Dim BackColor As Color = Color.FromArgb(BackAlpha, ContourBackColor.R, ContourBackColor.G, ContourBackColor.B)
        Dim SolidBrush As New SolidBrush(ForeColor)
        Dim HatchBrush As New HatchBrush(HatchStyle, ForeColor, BackColor)
        If ContourFillVisible And CutFillContourRegion.Length > 0 Then '如果等值线可见就填充等值线
            '根据等值线填充区域求出等值线填充的剪切区域
            grap.SetClip(CutFillContourRegion(nContour).Clone, CombineMode.Replace)
            If BrushStyle = 0 Then '用实心画刷填充
                grap.FillRegion(SolidBrush, CutFillContourRegion(nContour).Clone)
            Else '用图案画刷填充
                grap.FillRegion(HatchBrush, CutFillContourRegion(nContour).Clone)
            End If
        End If

    End Sub
    ''' <summary>
    ''' 采用三角形法求数组的面积
    ''' </summary>
    ''' <param name="FillLine">某一条等值线和周围围成的线段，是一条首尾相连的线段</param>
    ''' <param name="FillRegion">某一条等值线和周围围成的区域</param>
    ''' <remarks></remarks>
    Private Function TriFillContourArea1(ByVal FillLine() As PointF, ByVal FillRegion As Region) As Double
        If FillLine IsNot Nothing AndAlso FillLine.Length >= 3 Then
            Dim AoBianXing(-1) As PointF '被剪裁掉的多边形
            Dim TuBianXimg(-1) As PointF '剪裁后的凸多边形
            Dim AoArea As Double = 0 '被剪裁掉的多边形面积的加和
            Dim TuArea As Double = 0 '剪裁后的凸多边形的面积
            TuBianXimg = FillLine
            AoArea = TraceTriFillContourArea(TuBianXimg, FillRegion)
            TuArea = MutiProtrudingAngleArea(TuBianXimg)
            Return TuArea - AoArea '返回多边形的面积。
        End If
    End Function
    Private Function TriFillContourArea(ByVal FillLine() As PointF, ByVal FillRegion As Region) As Double
        Dim i As Integer
        Dim s As Double
        Dim voucnt As Integer = FillLine.Length
        If voucnt < 3 Then
            Return 0
        End If
        s = FillLine(0).Y * (FillLine(FillLine.Length - 1).X - FillLine(1).X)
        For i = 1 To voucnt - 1
            s += FillLine(i).Y * (FillLine(i - 1).X - FillLine((i + 1) Mod voucnt).X)
        Next
        Return Math.Abs(s / 2)
    End Function
    Private Function TraceTriFillContourArea(ByRef FillLine() As PointF, ByVal FillRegion As Region) As Double
        If FillLine IsNot Nothing AndAlso FillLine.Length >= 3 Then
            '采用三角形法求等值线面积的方法是参考《计算复杂多边形面积的组合三角形法.pdf》得到的。在剪裁时要多次进行，反复剪裁
            '本程序由点围成的区域，起点==终点。因此在循环时要排除最后一个点，即最后一个点不进行计算。
            Dim AoBianXing(-1) As PointF '被剪裁掉的多边形
            Dim TuBianXimg(-1) As PointF '剪裁后的凸多边形
            Dim AoArea As Double = 0 '被剪裁掉的多边形面积的加和
            Dim TuArea As Double = 0 '剪裁后的凸多边形的面积
            Dim n1, n2, n3, nCneter As PointF '三角形的三个顶点
            Dim i As Integer
            Dim boolAo As Boolean = False '是否有凹边形标志，用于判断是否再进一步进行追踪
            ReDim Preserve TuBianXimg(0)
            TuBianXimg(0) = FillLine(0)
            For i = 0 To FillLine.Length - 3 '循环求被剪裁掉的面积,并连成一个凸边形
                n1 = FillLine(i)
                n2 = FillLine(i + 1)
                n3 = FillLine(i + 2)
                nCneter = Center(n1, n2, n3) '求得中间点
                '判断这个三角形是不是形成一个凸边形,如果是则加入凸边形数组中，否则加入被剪裁掉的多边形数组中。采用凸边形是否
                If FillRegion.IsVisible(nCneter) Or Math.Abs(TwoPointsDistance(n3, n1) - TwoPointsDistance(n3, n2)) >= TwoPointsDistance(n2, n1) Then '采用中点法判断是不是凸边形时，还应判断是不是三点在同一直线上，如果在同一直线上也认为在这区域内
                    ReDim Preserve TuBianXimg(TuBianXimg.Length)
                    TuBianXimg(TuBianXimg.Length - 1) = n2
                    If AoBianXing.Length > 0 Then ''如果被剪裁掉的多边形数组不为空，则最后一个点应与第一个点为同一点
                        ReDim Preserve AoBianXing(AoBianXing.Length)
                        AoBianXing(AoBianXing.Length - 1) = AoBianXing(0)
                        '求出这个被剪裁掉的多边形的面积，并叠加
                        AoArea = AoArea + MutiProtrudingAngleArea(AoBianXing)
                        '计算面积后将这个数组设置为空
                        ReDim AoBianXing(-1)
                    End If
                Else '直接采用中点法判断时在极端情况下可能会出现误判，因此，可加一个函数用于判断是不是有其它的点在这个三角形围成的区域内，如果有，则还是多边形
                    Dim k As Integer
                    Dim path As New GraphicsPath()
                    Dim triAngleLine(2) As PointF
                    triAngleLine(0) = n1
                    triAngleLine(1) = n2
                    triAngleLine(2) = n3
                    path.AddLines(triAngleLine)
                    Dim region As New Region(path)
                    Dim IsIn As Boolean = False '用于判断是不是在三角形中
                    Dim Tpoint As PointF
                    For k = 0 To FillLine.Length - 2
                        Tpoint = FillLine(k)
                        If Tpoint <> n1 And Tpoint <> n2 And Tpoint <> n3 Then
                            If region.IsVisible(Tpoint) Then
                                IsIn = True
                                Exit For
                            End If
                        End If
                    Next
                    If IsIn = True Then
                        ReDim Preserve TuBianXimg(TuBianXimg.Length)
                        TuBianXimg(TuBianXimg.Length - 1) = n2
                        If AoBianXing.Length > 0 Then ''如果被剪裁掉的多边形数组不为空，则最后一个点应与第一个点为同一点
                            ReDim Preserve AoBianXing(AoBianXing.Length)
                            AoBianXing(AoBianXing.Length - 1) = AoBianXing(0)
                            '求出这个被剪裁掉的多边形的面积，并叠加
                            AoArea = AoArea + MutiProtrudingAngleArea(AoBianXing)
                            '计算面积后将这个数组设置为空
                            ReDim AoBianXing(-1)
                        End If
                    Else
                        If AoBianXing.Length <= 0 Then '如果数组为空，第一个点应为n1
                            ReDim AoBianXing(1)
                            AoBianXing(0) = n1
                            AoBianXing(1) = n2
                        End If
                        ReDim Preserve AoBianXing(AoBianXing.Length) '以后的点应为n3
                        AoBianXing(AoBianXing.Length - 1) = n3
                        boolAo = True
                    End If
                End If
            Next
            '如果凸边形的数组不为空，最后一个点应与第一个点为同一点。为了下一次追踪时仍能正确判断
            If boolAo = True Then
                ReDim Preserve TuBianXimg(TuBianXimg.Length)
                TuBianXimg(TuBianXimg.Length - 1) = TuBianXimg(0)
                Dim path As New GraphicsPath()
                path.AddLines(TuBianXimg)
                Dim region As New Region(path)
                FillLine = TuBianXimg '将凸边形的数组传回去
                Return AoArea + TraceTriFillContourArea(FillLine, region)
            Else
                Exit Function
            End If
        End If
    End Function

    ''' <summary>
    ''' 凸边形的面积
    ''' </summary>
    ''' <param name="MutiProtrudingAngle">围成凸边形的线条，首尾相连</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MutiProtrudingAngleArea(ByVal MutiProtrudingAngle() As PointF) As Double
        Dim Area As Double = 0
        Dim i As Integer
        For i = 1 To MutiProtrudingAngle.Length - 2 '循环求面积，叠加
            Area = Area + TriPointArea(MutiProtrudingAngle(0), MutiProtrudingAngle(i), MutiProtrudingAngle(i + 1))
        Next
        Return Area
    End Function

    ''' <summary>
    ''' 根据三边计算三角形的面积
    ''' </summary>
    ''' <param name="a">三角形的一条边</param>
    ''' <param name="b">三角形的一条边</param>
    ''' <param name="c">三角形的一条边</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TriArea(ByVal a As Double, ByVal b As Double, ByVal c As Double) As Double
        Dim area As Double
        area = 1 / 4 * (a ^ 2 * b ^ 2 - ((a ^ 2 + b ^ 2 - c ^ 2) / 2) ^ 2)
        If area <= 0 Then
            Return 0
        Else
            Return Math.Sqrt(area)
        End If
    End Function
    ''' <summary>
    ''' 根据三个顶点计算三角形的面积
    ''' </summary>
    ''' <param name="n1">三角形的顶点</param>
    ''' <param name="n2">三角形的顶点</param>
    ''' <param name="n3">三角形的顶点</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TriPointArea(ByVal n1 As PointF, ByVal n2 As PointF, ByVal n3 As PointF) As Double
        Dim a, b, c As Double '三条边
        a = Math.Sqrt((n2.X - n1.X) ^ 2 + (n2.Y - n1.Y) ^ 2)
        b = Math.Sqrt((n3.X - n2.X) ^ 2 + (n3.Y - n2.Y) ^ 2)
        c = Math.Sqrt((n1.X - n3.X) ^ 2 + (n1.Y - n3.Y) ^ 2)
        TriPointArea = TriArea(a, b, c)
    End Function
    ''' <summary>
    ''' 求两点的中点
    ''' </summary>
    ''' <param name="n1">第一点点的坐标</param>
    ''' <param name="n3">第三个点的坐标</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Center(ByVal n1 As PointF, ByVal n2 As PointF, ByVal n3 As PointF) As PointF
        '为避免中线上的点可能会出现在区域的外面，因此，求三角形的中心点，免出现误判
        Dim x, y, x1, y1 As Integer
        x = (n1.X + n3.X) / 2
        y = (n1.Y + n3.Y) / 2
        x1 = (x + n2.X) / 2
        y1 = (y + n2.Y) / 2
        Center = New Point(x1, y1)
    End Function

    ''' <summary>
    ''' 根据求得的等值线求出所有的等值线段
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntiArrayContourPoints(ByVal OneContourLine() As Point3D, ByVal Xmin As Double, ByVal Ymin As Double, ByVal Xmax As Double, ByVal Ymax As Double)
        Dim i, j As Integer
        Dim contourPoint() As Point3D '用于储存某给定值的所有等值线中的一条,其x,y分别为整数型。这个数组用于绘图
        ReDim ArrayContourPoints(-1)
        If OneContourLine IsNot Nothing Then '如果不为空，则求
            While i <= OneContourLine.Length - 1
                ReDim contourPoint(-1) '设置数组为空
                j = 0
                While j <= OneContourLine.Length - 1 AndAlso i <= OneContourLine.Length - 1 AndAlso OneContourLine(i).z <> -1 AndAlso i <= OneContourLine.Length - 1
                    ReDim Preserve contourPoint(j)
                    contourPoint(j).x = OneContourLine(i).x
                    contourPoint(j).y = OneContourLine(i).y
                    i = i + 1
                    j = j + 1
                End While
                If contourPoint.Length >= 2 Then '如果数组＞＝2个点则加入等值线数组中
                    ReDim Preserve ArrayContourPoints(ArrayContourPoints.Length)
                    ArrayContourPoints(ArrayContourPoints.Length - 1).vecContourPoints = contourPoint
                    ArrayContourPoints(ArrayContourPoints.Length - 1).fValue = OneContourLine(i - 1).z
                End If
                If i <= OneContourLine.Length - 1 AndAlso OneContourLine(i).z = -1 Then
                    i = i + 1
                End If
            End While
        End If
    End Sub
    ''' <summary>
    ''' 初始化边界点序列的数组
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntiArrayEdgePt(ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal Xmin As Double, ByVal Ymin As Double, ByVal Xmax As Double, ByVal Ymax As Double)
        '将所有非封闭等值线的起点、终点以及区域矩形的四个顶点按逆时针顺序排序。从左上角开始
        Dim i, j As Integer
        Dim nstart As Integer '用于记录每一次排序的起点
        Dim tempEdgePt As EdgePt '用于储存边界点的临时变量
        ReDim ArrayEdgePt(0)
        ArrayEdgePt(0).ptEdge.x = CInt(Xmin)
        ArrayEdgePt(0).ptEdge.y = CInt(Ymax)
        ArrayEdgePt(0).nPtAttribute = 2 '边界线的顶点
        ArrayEdgePt(0).bUseFlag = False
        ArrayEdgePt(0).nContourIndex = -1
        ArrayEdgePt(0).fValue = GridPoint(0, 0) ' 将左上角的值给变量
        ArrayEdgePt(0).n = 0
        '找出所有的左边界点，并排序
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).x = CInt(Xmin) Then '如果等值线的第一个点与左边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '等值线的起点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x = CInt(Xmin) Then '如果等值线的最后一个点与左边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '等值线的终点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '排序左边界的所有点。交换法
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.y < ArrayEdgePt(j).ptEdge.y Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '设置边界点的顺序值
        Next
        '加入左下角的点
        ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = CInt(Xmin)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = CInt(Ymin)
        ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 '等值线的起点
        ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
        ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = -1
        ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = GridPoint(row - 1, 0)
        ArrayEdgePt(i).n = i '设置边界点的顺序值
        '找出所有的底边界点，并排序
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).y = CInt(Ymin) Then '如果等值线的第一个点与底边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '等值线的起点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y = CInt(Ymin) Then '如果等值线的最后一个点与底边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '等值线的终点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '排序底边界的所有点。交换法
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.x > ArrayEdgePt(j).ptEdge.x Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '设置边界点的顺序值
        Next
        '加入右下角的点
        ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = CInt(Xmax)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = CInt(Ymin)
        ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 '等值线的起点
        ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
        ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = -1
        ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = GridPoint(row - 1, col - 1)
        ArrayEdgePt(i).n = i '设置边界点的顺序值
        '找出所有的右边界点，并排序
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).x = CInt(Xmax) Then '如果等值线的第一个点与右边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '等值线的起点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x = CInt(Xmax) Then '如果等值线的最后一个点与右边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '等值线的终点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '排序右边界的所有点。交换法
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.y > ArrayEdgePt(j).ptEdge.y Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '设置边界点的顺序值
        Next
        '加入右上角的点
        ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = CInt(Xmax)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = CInt(Ymax)
        ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 '等值线的起点
        ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
        ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = -1
        ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = GridPoint(0, col - 1)
        ArrayEdgePt(i).n = i '设置边界点的顺序值
        '找出所有的顶边界点，并排序
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).y = CInt(Ymax) Then '如果等值线的第一个点与顶边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '等值线的起点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y = CInt(Ymax) Then '如果等值线的最后一个点与底边相交，则开始加入数组中
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '等值线的终点
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '排序项边界的所有点。交换法
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.x < ArrayEdgePt(j).ptEdge.x Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '设置边界点的顺序值
        Next
        '重新排序数组，将数组中重复角的点去除。
        Dim len As Integer = ArrayEdgePt.Length - 1
        For i = 0 To len - 2
            If ArrayEdgePt(i).ptEdge.x = ArrayEdgePt(i + 1).ptEdge.x And ArrayEdgePt(i).ptEdge.y = ArrayEdgePt(i + 1).ptEdge.y And (ArrayEdgePt(i).nPtAttribute = 2 Or ArrayEdgePt(i + 1).nPtAttribute = 2) Then
                For j = i To ArrayEdgePt.Length - 2
                    ArrayEdgePt(j) = ArrayEdgePt(j + 1)
                    ArrayEdgePt(j).n -= 1
                Next j
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length - 2) '长度减1
                len = len - 1
                i = i - 1
            End If
            If i = len - 2 Then
                Exit For
            End If
        Next i
        '如果第一个点和最后一个点的位置相同，去掉最后一个点
        If ArrayEdgePt(0).ptEdge.x = ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x And ArrayEdgePt(0).ptEdge.y = ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y And ArrayEdgePt(0).nContourIndex = ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex Then
            ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length - 2) '长度减1
        End If
    End Sub
    ''' <summary>
    ''' 初始化等值线区域数组
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntiArrayContourRegion(ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal ContourValue As Double)
        ReDim Preserve ArrayContourRegion(-1)
        Dim i As Integer
        For i = 0 To ArrayEdgePt.Length - 2
            If ArrayEdgePt(i).bUseFlag = False Then '如果没用过，就开始追踪
                Dim LastEdgept As EdgePt = ArrayEdgePt(i)
                Dim AEdgePt(0) As EdgePt
                AEdgePt(0) = ArrayEdgePt(i)
                '为避免从四个角开始追踪等值线，应从边上开始追踪
                If ArrayEdgePt(i).nPtAttribute <> 2 Then
                    TraceEdgePt(i, LastEdgept, AEdgePt, GridPoint, row, col, X_min, Y_min, X_max, Y_max, ContourValue)
                    If AEdgePt.Length > 1 Then
                        ReDim Preserve ArrayContourRegion(ArrayContourRegion.Length)
                        ArrayContourRegion(ArrayContourRegion.Length - 1).vecContourRegPoints = AEdgePt
                    End If
                End If
            End If
        Next
        '有一种特殊的情况，请是等值线没有与边相交，如果该等值线的值小于四个角上的值，则由四个角组成的区域为等值线区。否则为空白区
        If ArrayContourRegion.Length = 0 Then
            If GridPoint(0, 0) >= ContourValue Then
                ReDim Preserve ArrayContourRegion(ArrayContourRegion.Length)
                ReDim ArrayContourRegion(ArrayContourRegion.Length - 1).vecContourRegPoints(3)
                ArrayContourRegion(ArrayContourRegion.Length - 1).vecContourRegPoints = ArrayEdgePt
            End If
        End If
    End Sub
    Private Sub TraceEdgePt(ByVal i As Integer, ByVal LastEdgePt As EdgePt, ByRef AEdgePt() As EdgePt, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal ContourValue As Double) '返回下一个边界点，直到头尾相连
        ArrayEdgePt(i).bUseFlag = True
        LastEdgePt.bUseFlag = True

        Dim k As Integer
        Dim HeadAndEnd As Boolean = False '表示同一等值线首尾连接
        For k = 0 To ArrayEdgePt.Length - 1
            If LastEdgePt.nContourIndex = ArrayEdgePt(k).nContourIndex And LastEdgePt.nContourIndex <> -1 Then '如果与边相交的等值线为头与边相交则找出该等值线的尾，并连接尾
                If ArrayEdgePt(k).bUseFlag = False Then
                    ArrayEdgePt(k).bUseFlag = True
                    ReDim Preserve AEdgePt(AEdgePt.Length)
                    AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(k)
                    HeadAndEnd = True
                    '如果找到则退出循环

                End If
            End If
        Next
        If HeadAndEnd = False Then '如果不是同一等值线首尾连接，则相交边前后一定有一个点的中间值大于该等值线值()
            ReDim Preserve AEdgePt(AEdgePt.Length)
            '有一种特殊的情况，即当前点为4个角或下一个将要连接的点为4个角时，有可能出现中间值<小于的情况
            If LastEdgePt.nPtAttribute = 2 Then '如果为4个角
                If i = 0 Then '左上角
                    If ArrayEdgePt(i + 1).bUseFlag = False Then
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    ElseIf ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False Then
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(ArrayEdgePt.Length - 1)
                    Else '首尾相连
                        AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                    End If
                Else '其它角
                    If i + 1 > ArrayEdgePt.Length - 1 Then '如果为右上角，且下一个角是左上角
                        If ArrayEdgePt(0).bUseFlag = False Then
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(0)
                        ElseIf ArrayEdgePt(i - 1).bUseFlag = False Then
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    Else
                        If ArrayEdgePt(i + 1).bUseFlag = False Then
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                        ElseIf ArrayEdgePt(i - 1).bUseFlag = False Then
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                End If
            Else '如果不是四个角
                Dim CenterPoint As PointF
                Dim ai, aj As Integer
                If i + 1 > ArrayEdgePt.Length - 1 Then '如果是最后一个点，则下一个点为起点。即左上角，因此只要比较左上角是不是<=该点即可，如果>=则直接连接 
                    If ArrayEdgePt(0).fValue >= ContourValue And ArrayEdgePt(0).bUseFlag = False Then '如果与下一个点起点>=等值线值，则连接
                        ArrayEdgePt(0).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(0)
                    ElseIf ArrayEdgePt(i - 1).nPtAttribute = 2 Then '与前一个点进行连接比较看是不是四个角，如果是
                        If ArrayEdgePt(i - 1).fValue >= 0 And ArrayEdgePt(i - 1).bUseFlag = False Then
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    Else
                        CenterPoint.X = (ArrayEdgePt(i - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '如果前一个点的中间点>=等值线值，则连接
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else '否则首尾相连
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf i - 1 < 0 Then '如果是第一个点
                    If ArrayEdgePt(i + 1).fValue >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '如果与下一个点的中间点>=等值线值，则连接
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    ElseIf ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 Then '与前一个点进行连接比较看是不是四个角，如果是
                        If ArrayEdgePt(ArrayEdgePt.Length - 1).fValue >= 0 And ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False Then
                            ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(ArrayEdgePt.Length - 1)
                        Else
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    Else '与前一个点进行连接比较
                        CenterPoint.X = (ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False Then '如果前一个点的中间点>=等值线值，则连接
                            ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(ArrayEdgePt.Length - 1)
                        Else '否则首尾相连
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf ArrayEdgePt(i + 1).nPtAttribute = 2 And ArrayEdgePt(i - 1).nPtAttribute = 2 Then '如果前后均为角
                    If ArrayEdgePt(i + 1).fValue >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    Else
                        If ArrayEdgePt(i - 1).fValue >= 0 And ArrayEdgePt(i - 1).bUseFlag = False Then
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf ArrayEdgePt(i + 1).nPtAttribute = 2 And ArrayEdgePt(i - 1).nPtAttribute <> 2 Then '下一个点为角上一个点不为角
                    If ArrayEdgePt(i + 1).fValue >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '如果与下一个点的>=等值线值，则连接
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    Else
                        CenterPoint.X = (ArrayEdgePt(i - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '如果前一个点的中间点>=等值线值，则连接
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else '否则首尾相连
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf ArrayEdgePt(i - 1).nPtAttribute = 2 And ArrayEdgePt(i + 1).nPtAttribute <> 2 Then '上一个点为角下一个点不为角
                    If ArrayEdgePt(i - 1).fValue >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '如果与上一个点>=等值线值，则连接
                        ArrayEdgePt(i - 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                    Else
                        CenterPoint.X = (ArrayEdgePt(i + 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i + 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '如果下一个点的中间点>=等值线值，则连接
                            ArrayEdgePt(i + 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                        Else '否则首尾相连
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                Else '前后均不为角
                    CenterPoint.X = (ArrayEdgePt(i + 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                    CenterPoint.Y = (ArrayEdgePt(i + 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                    ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                    aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                    If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '如果与下一个点的中间点>=等值线值，则连接
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    Else '与前一个点进行连接比较
                        CenterPoint.X = (ArrayEdgePt(i - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '如果前一个点的中间点>=等值线值，则连接
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else '否则首尾相连
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                End If
            End If
        End If

        If AEdgePt.Length >= 3 And AEdgePt(0).ptEdge.x = AEdgePt(AEdgePt.Length - 1).ptEdge.x And AEdgePt(0).ptEdge.y = AEdgePt(AEdgePt.Length - 1).ptEdge.y Then '如果头尾相同，则退出
            Exit Sub
        Else
            LastEdgePt = AEdgePt(AEdgePt.Length - 1)
            TraceEdgePt(LastEdgePt.n, LastEdgePt, AEdgePt, GridPoint, row, col, X_min, Y_min, X_max, Y_max, ContourValue) '叠代求值
        End If
    End Sub
End Class

''' <summary>
''' 区域边界点的数据结构
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure EdgePt
    Dim ptEdge As Point3D ' 取边界上的点(边界线顶点或等值线与边界线的交点)
    Dim nPtAttribute As Integer '点的属性:0 :等值线的起点,1 :等值线的终点,2 :边界线的顶点
    Dim bUseFlag As Boolean '该点是否已用过
    Dim nContourIndex As Integer '对应的等值线编号,若为顶点,值为- 1
    Dim fValue As Double ' 此点对应的等值线的高程,若为顶点,高程为该顶点的值
    Dim n As Integer '表示边界点在边界点数组中的顺序，用于追踪前后边界点
End Structure
''' <summary>
''' 等值区数据结构
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure ContourRegion
    Dim vecContourRegPoints() As EdgePt '边界点列
End Structure
''' <summary>
''' 等值线数据结构
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure ContourPoints
    Dim vecContourPoints() As Point3D '等值线点列
    Dim fValue As Double '等值线高程
End Structure



