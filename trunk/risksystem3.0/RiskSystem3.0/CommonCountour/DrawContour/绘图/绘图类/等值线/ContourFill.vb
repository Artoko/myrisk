Imports System.Drawing.Drawing2D
<Serializable()> Public Class ContourFill

    '����ֵ�ߵ��ࡣ��������ཫ����õĵ�ֵ������������
    Public HatchStyle As HatchStyle
    Public ContourBackColor As Color = Color.White   '���ͼ���ı�������ɫ
    Public ContourForeColor As Color = Color.Black  '���ͼ����ǰ������ɫ
    Public ContourFillVisible As Boolean = True  '��ֵ������Ƿ�ɼ�
    Public BackTransparent As Integer = 80 '����͸���ȡ�0��ʾ��͸����100��ʾȫ͸��
    Public ForeTransparent As Integer = 50 'ǰ��͸���ȡ�0��ʾ��͸����100��ʾȫ͸��
    Public BrushStyle As Integer = 0 '��ˢ����ʽ��0Ϊʵ�Ļ�ˢ��0Ϊͼ����ˢ
    Public ContourArea As Double  '���������λΪkm��
    Public Curve As Boolean '����
    '��ֵ���������
    Private ArrayEdgePt(-1) As EdgePt '����߽�������
    Private ArrayContourRegion(-1) As ContourRegion '��ֵ�������顣�������е�һ��Ԫ�ش�����һ����ֵ������ı߽��
    Private ArrayContourPoints(-1) As ContourPoints '��ֵ�����ݡ���������ÿ��Ԫ�ش�����һ����ֵ�ߵ�����
    Public Sub CalculateFillContour(ByVal grap As Graphics, ByVal ArrayContour() As ContourPoints, ByVal nContour As Integer, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal FillContourRegion() As Region, ByVal Contourvalue As Double, ByVal HurtValue As Double, ByVal ReCalContour As Boolean, ByVal x0 As Double, ByVal y0 As Double) '���ĳһ����ֵ��
        If PannelSetting.PaintType = 0 Then 'й©�¹�
            '����Ǳպϵ�ֵ��Χ�ɵ�����---------------------------------------------------------------
            ArrayContourPoints = ArrayContour ' ������õĵ�ֵ��������еĵ�ֵ�߶�
            IntiArrayEdgePt(GridPoint, row, col, X_min, Y_min, X_max, Y_max) '��ʼ���߽�����е�����
            IntiArrayContourRegion(GridPoint, row, col, X_min, Y_min, X_max, Y_max, Contourvalue) '��ʼ����ֵ����������
            'ͨ���������������һ��ֵ����������
            ContourArea = 0 '��ʼ�����Ϊ0
            Dim UnionContourRegion As New Region(New Rectangle(0, 0, 0, 0)) '���е�ֵ������Ĳ���Ϊ��
            '������õ�ֵ�ߵ���������������������յ�
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim k As Integer = 0
            If ArrayContourRegion IsNot Nothing AndAlso ArrayContourRegion.Length > 0 Then '�����ֵ���������鲻Ϊ�գ�����ݸ������γɵĶ��㿪ʼ����Χ�ɵ�����
                For i = 0 To ArrayContourRegion.Length - 1
                    Dim ConnectContour(-1) As Point3D  '���ڴ���һ����ͨ�ĵ�ֵ��
                    For j = 0 To ArrayContourRegion(i).vecContourRegPoints.Length - 2 '�����еĵ���������
                        Dim n As Integer = ArrayContourRegion(i).vecContourRegPoints(j).nContourIndex
                        Dim OneContour(0) As Point3D
                        If n >= 0 Then '����е�ֵ�ߣ�����ֵ�ߵ�ֵ�����顣����
                            OneContour = ArrayContourPoints(n).vecContourPoints.Clone
                        Else
                            OneContour(0) = ArrayContourRegion(i).vecContourRegPoints(j).ptEdge
                        End If
                        If ArrayContourRegion(i).vecContourRegPoints(j).nContourIndex = ArrayContourRegion(i).vecContourRegPoints(j + 1).nContourIndex And ArrayContourRegion(i).vecContourRegPoints(j).nPtAttribute <> 2 Then '����ǵ�ֵ���Ҹõ�ֵ��û���ӹ���������
                            If ArrayContourRegion(i).vecContourRegPoints(j).nPtAttribute = 1 Then '����ǵ�ֵ�ߵ�β��ʼ���ӣ�������
                                Dim ReOneContour As Point3D
                                For k = 0 To OneContour.Length / 2 - 1
                                    ReOneContour = OneContour(k)
                                    OneContour(k) = OneContour(OneContour.Length - 1 - k)
                                    OneContour(OneContour.Length - 1 - k) = ReOneContour
                                Next
                            End If
                            ReDim Preserve ConnectContour(ConnectContour.Length + OneContour.Length - 1)
                            For k = 0 To OneContour.Length - 1
                                ConnectContour(ConnectContour.Length - OneContour.Length + k) = OneContour(k) '����
                            Next
                            j = j + 1
                        ElseIf OneContour.Length = 1 Then '������һ���㣬ֱ�����Ӹõ�
                            ReDim Preserve ConnectContour(ConnectContour.Length + OneContour.Length - 1)
                            For k = 0 To OneContour.Length - 1
                                ConnectContour(ConnectContour.Length - OneContour.Length + k) = OneContour(k) '����
                            Next
                        End If
                    Next
                    '�����һ�������ֵ������
                    ReDim Preserve ConnectContour(ConnectContour.Length)
                    ConnectContour(ConnectContour.Length - 1) = ArrayContourRegion(i).vecContourRegPoints(ArrayContourRegion(i).vecContourRegPoints.Length - 1).ptEdge
                    ''���м��ظ��ĵ�ȥ��
                    'Dim Rn, Re As Integer
                    'For Rn = 0 To ConnectContour.Length - 2
                    '    If ConnectContour(Rn) = ConnectContour(Rn + 1) Then '�����������ĵ���ͬ����ȥ���õ�
                    '        For Re = Rn To ConnectContour.Length - 2
                    '            ConnectContour(Re) = ConnectContour(Re + 1)
                    '        Next
                    '        ReDim Preserve ConnectContour(ConnectContour.Length - 2) '�����1
                    '        Rn -= 1 '��Χ�����1
                    '    End If
                    '    If Rn = ConnectContour.Length - 2 Then '������������
                    '        Exit For
                    '    End If
                    'Next
                    If ConnectContour IsNot Nothing AndAlso ConnectContour.Length > 1 Then '����ֻ���ĸ��ǵ���ߣ������н���
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
                        '���������Ľ���
                        Dim region As New Region(path)
                        Dim ContourRegion As New Region(PannelSetting.gAxisRect) '���ֵ�ߵķ������������ֵ�����������򲻻���
                        ContourRegion.Intersect(region)
                        UnionContourRegion.Union(ContourRegion) '�󲢼����ó����е�ֵ�ߵ�����
                        '����һ����ֵ�ߵ�����Χ�ɵ����
                        ContourArea = ContourArea + TriFillContourArea(DrawContour, region)
                    End If
                Next
            End If
            '�ҳ���յ�ֵ�ߵ�����---------------------------------------------------
            For i = 0 To ArrayContourPoints.Length - 1
                If ArrayContourPoints(i).vecContourPoints(0).x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x _
                And ArrayContourPoints(i).vecContourPoints(0).y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y Then '�����β��ȣ���Ϊ�պϵ�ֵ��
                    '���ҵ��ڲ��ĵ�
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
                    '���������Ľ���
                    Dim region As New Region(path)
                    If IsGreat(DrawContour, GridPoint, row, col, X_min, Y_min, X_max, Y_max, Contourvalue, region.Clone) Then '���������ߵ��ڲ�����>=��ֵ�ߣ���õ�ֵ�ߵ�����Ϊ����������Ӧ�ų�������
                        UnionContourRegion.Union(region) '�󲢼����ó����е�ֵ�ߵ�����
                        '����һ����ֵ�ߵ�����Χ�ɵ����
                        ContourArea = ContourArea + TriFillContourArea(DrawContour, region)
                    Else
                        UnionContourRegion.Exclude(region)
                        '����һ����ֵ�ߵ�����Χ�ɵ����
                        ContourArea = ContourArea - TriFillContourArea(DrawContour, region)
                    End If
                End If
            Next
            '����������õ����򣬽������ֵ������
            FillContourRegion(nContour) = UnionContourRegion
            'End If
        Else '�����¹�
        ContourArea = Math.PI * HurtValue ^ 2
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(-HurtValue + x0, -HurtValue + y0, HurtValue * 2, HurtValue * 2)
        path.AddEllipse(rect)
        '���������Ľ���
        Dim region As New Region(path)
        Dim ARegion As New Region(PannelSetting.gAxisRect) '���ֵ�ߵķ������������ֵ�����������򲻻���
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
        '        '�ж�������Ƿ��������ε��κ�һ������
        '        If IsOnLine(p1, p2, p3, New Point(x1, y1)) = False Then '����õ㲻�������ε��κ�һ���ϣ���
        '            If region.IsVisible(x1, y1) = True Then
        '                If GridPoint(ai, aj) >= ContourValue Then '���һ������м��>=��ֵ��ֵ
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
        '���������ζ������������ε����ߵĲС�ڵ�����
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
        '���ݵ�ֵ��������������ֵ�����ļ�������
        If PannelSetting.PaintType = 0 Then '����ǵ�ֵ������
            Dim region As Region = FillContourRegion(nContour)
            Dim LitleRegion As New Region()
            Dim i As Integer
            Dim conValue As Double = -1
            For i = 0 To FillContourRegion.Length - 1 '���ҳ����ֵ
                If ArrayContourValue(i) > conValue Then
                    conValue = ArrayContourValue(i)
                    LitleRegion = FillContourRegion(i).Clone
                End If
            Next
            If conValue <> -1 Then
                Dim EXC As Boolean = False
                For i = 0 To FillContourRegion.Length - 1 '�ҳ�С�ڱ�������ڽ�����
                    If ArrayContourValue(i) > ArrayContourValue(nContour) And ArrayContourValue(i) <= conValue Then
                        conValue = ArrayContourValue(i)
                        LitleRegion = FillContourRegion(i).Clone
                        EXC = True
                    End If
                Next
                If EXC Then '������Ǳ�����
                    region.Exclude(LitleRegion.Clone)
                End If
                CutFillContourRegion(nContour) = region.Clone
            End If
        Else '�˺�����
            Dim region As Region = FillContourRegion(nContour)
            Dim LitleRegion As New Region()
            Dim i As Integer
            Dim conValue As Double = 1000000000
            For i = 0 To FillContourRegion.Length - 1 '���ҳ���Сֵ
                If ArrayContourValue(i) < conValue Then
                    conValue = ArrayContourValue(i)
                    LitleRegion = FillContourRegion(i).Clone
                End If
            Next
            If conValue <> -1 Then
                Dim EXC As Boolean = False
                For i = 0 To FillContourRegion.Length - 1 '�ҳ�С�ڱ�������ڽ�����
                    If ArrayContourValue(i) < ArrayContourValue(nContour) And ArrayContourValue(i) >= conValue Then
                        conValue = ArrayContourValue(i)
                        LitleRegion = FillContourRegion(i).Clone
                        EXC = True
                    End If
                Next
                If EXC Then '������Ǳ�����
                    region.Exclude(LitleRegion.Clone)
                End If
                CutFillContourRegion(nContour) = region.Clone
            End If
        End If
    End Sub
    Public Sub FillContour(ByVal grap As Graphics, ByVal nContour As Integer, ByVal FillContourRegion() As Region, ByVal CutFillContourRegion() As Region) '���ĳһ����ֵ��

        Dim ForeAlpha As Integer 'alpha ֵԽ�ӽ��� 0��������ɫ��Ȩ��Խ��alpha ֵԽ�ӽ��� 255��������ɫ��Ȩ��Խ��
        ForeAlpha = 255 - CInt(ForeTransparent * 2.55)
        Dim ForeColor As Color = Color.FromArgb(ForeAlpha, ContourForeColor.R, ContourForeColor.G, ContourForeColor.B)

        Dim BackAlpha As Integer 'alpha ֵԽ�ӽ��� 0��������ɫ��Ȩ��Խ��alpha ֵԽ�ӽ��� 255��������ɫ��Ȩ��Խ��
        BackAlpha = 255 - CInt(BackTransparent * 2.55)
        Dim BackColor As Color = Color.FromArgb(BackAlpha, ContourBackColor.R, ContourBackColor.G, ContourBackColor.B)
        Dim SolidBrush As New SolidBrush(ForeColor)
        Dim HatchBrush As New HatchBrush(HatchStyle, ForeColor, BackColor)
        If ContourFillVisible And CutFillContourRegion.Length > 0 Then '�����ֵ�߿ɼ�������ֵ��
            '���ݵ�ֵ��������������ֵ�����ļ�������
            grap.SetClip(CutFillContourRegion(nContour).Clone, CombineMode.Replace)
            If BrushStyle = 0 Then '��ʵ�Ļ�ˢ���
                grap.FillRegion(SolidBrush, CutFillContourRegion(nContour).Clone)
            Else '��ͼ����ˢ���
                grap.FillRegion(HatchBrush, CutFillContourRegion(nContour).Clone)
            End If
        End If

    End Sub
    ''' <summary>
    ''' ���������η�����������
    ''' </summary>
    ''' <param name="FillLine">ĳһ����ֵ�ߺ���ΧΧ�ɵ��߶Σ���һ����β�������߶�</param>
    ''' <param name="FillRegion">ĳһ����ֵ�ߺ���ΧΧ�ɵ�����</param>
    ''' <remarks></remarks>
    Private Function TriFillContourArea1(ByVal FillLine() As PointF, ByVal FillRegion As Region) As Double
        If FillLine IsNot Nothing AndAlso FillLine.Length >= 3 Then
            Dim AoBianXing(-1) As PointF '�����õ��Ķ����
            Dim TuBianXimg(-1) As PointF '���ú��͹�����
            Dim AoArea As Double = 0 '�����õ��Ķ��������ļӺ�
            Dim TuArea As Double = 0 '���ú��͹����ε����
            TuBianXimg = FillLine
            AoArea = TraceTriFillContourArea(TuBianXimg, FillRegion)
            TuArea = MutiProtrudingAngleArea(TuBianXimg)
            Return TuArea - AoArea '���ض���ε������
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
            '���������η����ֵ������ķ����ǲο������㸴�Ӷ�����������������η�.pdf���õ��ġ��ڼ���ʱҪ��ν��У���������
            '�������ɵ�Χ�ɵ��������==�յ㡣�����ѭ��ʱҪ�ų����һ���㣬�����һ���㲻���м��㡣
            Dim AoBianXing(-1) As PointF '�����õ��Ķ����
            Dim TuBianXimg(-1) As PointF '���ú��͹�����
            Dim AoArea As Double = 0 '�����õ��Ķ��������ļӺ�
            Dim TuArea As Double = 0 '���ú��͹����ε����
            Dim n1, n2, n3, nCneter As PointF '�����ε���������
            Dim i As Integer
            Dim boolAo As Boolean = False '�Ƿ��а����α�־�������ж��Ƿ��ٽ�һ������׷��
            ReDim Preserve TuBianXimg(0)
            TuBianXimg(0) = FillLine(0)
            For i = 0 To FillLine.Length - 3 'ѭ���󱻼��õ������,������һ��͹����
                n1 = FillLine(i)
                n2 = FillLine(i + 1)
                n3 = FillLine(i + 2)
                nCneter = Center(n1, n2, n3) '����м��
                '�ж�����������ǲ����γ�һ��͹����,����������͹���������У�������뱻���õ��Ķ���������С�����͹�����Ƿ�
                If FillRegion.IsVisible(nCneter) Or Math.Abs(TwoPointsDistance(n3, n1) - TwoPointsDistance(n3, n2)) >= TwoPointsDistance(n2, n1) Then '�����е㷨�ж��ǲ���͹����ʱ����Ӧ�ж��ǲ���������ͬһֱ���ϣ������ͬһֱ����Ҳ��Ϊ����������
                    ReDim Preserve TuBianXimg(TuBianXimg.Length)
                    TuBianXimg(TuBianXimg.Length - 1) = n2
                    If AoBianXing.Length > 0 Then ''��������õ��Ķ�������鲻Ϊ�գ������һ����Ӧ���һ����Ϊͬһ��
                        ReDim Preserve AoBianXing(AoBianXing.Length)
                        AoBianXing(AoBianXing.Length - 1) = AoBianXing(0)
                        '�����������õ��Ķ���ε������������
                        AoArea = AoArea + MutiProtrudingAngleArea(AoBianXing)
                        '��������������������Ϊ��
                        ReDim AoBianXing(-1)
                    End If
                Else 'ֱ�Ӳ����е㷨�ж�ʱ�ڼ�������¿��ܻ�������У���ˣ��ɼ�һ�����������ж��ǲ����������ĵ������������Χ�ɵ������ڣ�����У����Ƕ����
                    Dim k As Integer
                    Dim path As New GraphicsPath()
                    Dim triAngleLine(2) As PointF
                    triAngleLine(0) = n1
                    triAngleLine(1) = n2
                    triAngleLine(2) = n3
                    path.AddLines(triAngleLine)
                    Dim region As New Region(path)
                    Dim IsIn As Boolean = False '�����ж��ǲ�������������
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
                        If AoBianXing.Length > 0 Then ''��������õ��Ķ�������鲻Ϊ�գ������һ����Ӧ���һ����Ϊͬһ��
                            ReDim Preserve AoBianXing(AoBianXing.Length)
                            AoBianXing(AoBianXing.Length - 1) = AoBianXing(0)
                            '�����������õ��Ķ���ε������������
                            AoArea = AoArea + MutiProtrudingAngleArea(AoBianXing)
                            '��������������������Ϊ��
                            ReDim AoBianXing(-1)
                        End If
                    Else
                        If AoBianXing.Length <= 0 Then '�������Ϊ�գ���һ����ӦΪn1
                            ReDim AoBianXing(1)
                            AoBianXing(0) = n1
                            AoBianXing(1) = n2
                        End If
                        ReDim Preserve AoBianXing(AoBianXing.Length) '�Ժ�ĵ�ӦΪn3
                        AoBianXing(AoBianXing.Length - 1) = n3
                        boolAo = True
                    End If
                End If
            Next
            '���͹���ε����鲻Ϊ�գ����һ����Ӧ���һ����Ϊͬһ�㡣Ϊ����һ��׷��ʱ������ȷ�ж�
            If boolAo = True Then
                ReDim Preserve TuBianXimg(TuBianXimg.Length)
                TuBianXimg(TuBianXimg.Length - 1) = TuBianXimg(0)
                Dim path As New GraphicsPath()
                path.AddLines(TuBianXimg)
                Dim region As New Region(path)
                FillLine = TuBianXimg '��͹���ε����鴫��ȥ
                Return AoArea + TraceTriFillContourArea(FillLine, region)
            Else
                Exit Function
            End If
        End If
    End Function

    ''' <summary>
    ''' ͹���ε����
    ''' </summary>
    ''' <param name="MutiProtrudingAngle">Χ��͹���ε���������β����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MutiProtrudingAngleArea(ByVal MutiProtrudingAngle() As PointF) As Double
        Dim Area As Double = 0
        Dim i As Integer
        For i = 1 To MutiProtrudingAngle.Length - 2 'ѭ�������������
            Area = Area + TriPointArea(MutiProtrudingAngle(0), MutiProtrudingAngle(i), MutiProtrudingAngle(i + 1))
        Next
        Return Area
    End Function

    ''' <summary>
    ''' �������߼��������ε����
    ''' </summary>
    ''' <param name="a">�����ε�һ����</param>
    ''' <param name="b">�����ε�һ����</param>
    ''' <param name="c">�����ε�һ����</param>
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
    ''' ��������������������ε����
    ''' </summary>
    ''' <param name="n1">�����εĶ���</param>
    ''' <param name="n2">�����εĶ���</param>
    ''' <param name="n3">�����εĶ���</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TriPointArea(ByVal n1 As PointF, ByVal n2 As PointF, ByVal n3 As PointF) As Double
        Dim a, b, c As Double '������
        a = Math.Sqrt((n2.X - n1.X) ^ 2 + (n2.Y - n1.Y) ^ 2)
        b = Math.Sqrt((n3.X - n2.X) ^ 2 + (n3.Y - n2.Y) ^ 2)
        c = Math.Sqrt((n1.X - n3.X) ^ 2 + (n1.Y - n3.Y) ^ 2)
        TriPointArea = TriArea(a, b, c)
    End Function
    ''' <summary>
    ''' ��������е�
    ''' </summary>
    ''' <param name="n1">��һ��������</param>
    ''' <param name="n3">�������������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Center(ByVal n1 As PointF, ByVal n2 As PointF, ByVal n3 As PointF) As PointF
        'Ϊ���������ϵĵ���ܻ��������������棬��ˣ��������ε����ĵ㣬���������
        Dim x, y, x1, y1 As Integer
        x = (n1.X + n3.X) / 2
        y = (n1.Y + n3.Y) / 2
        x1 = (x + n2.X) / 2
        y1 = (y + n2.Y) / 2
        Center = New Point(x1, y1)
    End Function

    ''' <summary>
    ''' ������õĵ�ֵ��������еĵ�ֵ�߶�
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntiArrayContourPoints(ByVal OneContourLine() As Point3D, ByVal Xmin As Double, ByVal Ymin As Double, ByVal Xmax As Double, ByVal Ymax As Double)
        Dim i, j As Integer
        Dim contourPoint() As Point3D '���ڴ���ĳ����ֵ�����е�ֵ���е�һ��,��x,y�ֱ�Ϊ�����͡�����������ڻ�ͼ
        ReDim ArrayContourPoints(-1)
        If OneContourLine IsNot Nothing Then '�����Ϊ�գ�����
            While i <= OneContourLine.Length - 1
                ReDim contourPoint(-1) '��������Ϊ��
                j = 0
                While j <= OneContourLine.Length - 1 AndAlso i <= OneContourLine.Length - 1 AndAlso OneContourLine(i).z <> -1 AndAlso i <= OneContourLine.Length - 1
                    ReDim Preserve contourPoint(j)
                    contourPoint(j).x = OneContourLine(i).x
                    contourPoint(j).y = OneContourLine(i).y
                    i = i + 1
                    j = j + 1
                End While
                If contourPoint.Length >= 2 Then '������飾��2����������ֵ��������
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
    ''' ��ʼ���߽�����е�����
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntiArrayEdgePt(ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal Xmin As Double, ByVal Ymin As Double, ByVal Xmax As Double, ByVal Ymax As Double)
        '�����зǷ�յ�ֵ�ߵ���㡢�յ��Լ�������ε��ĸ����㰴��ʱ��˳�����򡣴����Ͻǿ�ʼ
        Dim i, j As Integer
        Dim nstart As Integer '���ڼ�¼ÿһ����������
        Dim tempEdgePt As EdgePt '���ڴ���߽�����ʱ����
        ReDim ArrayEdgePt(0)
        ArrayEdgePt(0).ptEdge.x = CInt(Xmin)
        ArrayEdgePt(0).ptEdge.y = CInt(Ymax)
        ArrayEdgePt(0).nPtAttribute = 2 '�߽��ߵĶ���
        ArrayEdgePt(0).bUseFlag = False
        ArrayEdgePt(0).nContourIndex = -1
        ArrayEdgePt(0).fValue = GridPoint(0, 0) ' �����Ͻǵ�ֵ������
        ArrayEdgePt(0).n = 0
        '�ҳ����е���߽�㣬������
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).x = CInt(Xmin) Then '�����ֵ�ߵĵ�һ����������ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '��ֵ�ߵ����
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x = CInt(Xmin) Then '�����ֵ�ߵ����һ����������ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '��ֵ�ߵ��յ�
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '������߽�����е㡣������
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.y < ArrayEdgePt(j).ptEdge.y Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        Next
        '�������½ǵĵ�
        ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = CInt(Xmin)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = CInt(Ymin)
        ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 '��ֵ�ߵ����
        ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
        ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = -1
        ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = GridPoint(row - 1, 0)
        ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        '�ҳ����еĵױ߽�㣬������
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).y = CInt(Ymin) Then '�����ֵ�ߵĵ�һ������ױ��ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '��ֵ�ߵ����
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y = CInt(Ymin) Then '�����ֵ�ߵ����һ������ױ��ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '��ֵ�ߵ��յ�
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '����ױ߽�����е㡣������
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.x > ArrayEdgePt(j).ptEdge.x Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        Next
        '�������½ǵĵ�
        ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = CInt(Xmax)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = CInt(Ymin)
        ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 '��ֵ�ߵ����
        ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
        ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = -1
        ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = GridPoint(row - 1, col - 1)
        ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        '�ҳ����е��ұ߽�㣬������
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).x = CInt(Xmax) Then '�����ֵ�ߵĵ�һ�������ұ��ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '��ֵ�ߵ����
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x = CInt(Xmax) Then '�����ֵ�ߵ����һ�������ұ��ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '��ֵ�ߵ��յ�
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '�����ұ߽�����е㡣������
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.y > ArrayEdgePt(j).ptEdge.y Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        Next
        '�������Ͻǵĵ�
        ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = CInt(Xmax)
        ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = CInt(Ymax)
        ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 '��ֵ�ߵ����
        ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
        ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = -1
        ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = GridPoint(0, col - 1)
        ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        '�ҳ����еĶ��߽�㣬������
        nstart = ArrayEdgePt.Length
        For i = 0 To ArrayContourPoints.Length - 1
            If ArrayContourPoints(i).vecContourPoints(0).y = CInt(Ymax) Then '�����ֵ�ߵĵ�һ�����붥���ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(0).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(0).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 0 '��ֵ�ߵ����
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
            If ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y = CInt(Ymax) Then '�����ֵ�ߵ����һ������ױ��ཻ����ʼ����������
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length)
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).x
                ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y = ArrayContourPoints(i).vecContourPoints(ArrayContourPoints(i).vecContourPoints.Length - 1).y
                ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 1 '��ֵ�ߵ��յ�
                ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False
                ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex = i
                ArrayEdgePt(ArrayEdgePt.Length - 1).fValue = ArrayContourPoints(i).fValue
            End If
        Next
        '������߽�����е㡣������
        For i = nstart To ArrayEdgePt.Length - 1
            For j = i + 1 To ArrayEdgePt.Length - 1
                If ArrayEdgePt(i).ptEdge.x < ArrayEdgePt(j).ptEdge.x Then
                    tempEdgePt = ArrayEdgePt(i)
                    ArrayEdgePt(i) = ArrayEdgePt(j)
                    ArrayEdgePt(j) = tempEdgePt
                End If
            Next
            ArrayEdgePt(i).n = i '���ñ߽���˳��ֵ
        Next
        '�����������飬���������ظ��ǵĵ�ȥ����
        Dim len As Integer = ArrayEdgePt.Length - 1
        For i = 0 To len - 2
            If ArrayEdgePt(i).ptEdge.x = ArrayEdgePt(i + 1).ptEdge.x And ArrayEdgePt(i).ptEdge.y = ArrayEdgePt(i + 1).ptEdge.y And (ArrayEdgePt(i).nPtAttribute = 2 Or ArrayEdgePt(i + 1).nPtAttribute = 2) Then
                For j = i To ArrayEdgePt.Length - 2
                    ArrayEdgePt(j) = ArrayEdgePt(j + 1)
                    ArrayEdgePt(j).n -= 1
                Next j
                ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length - 2) '���ȼ�1
                len = len - 1
                i = i - 1
            End If
            If i = len - 2 Then
                Exit For
            End If
        Next i
        '�����һ��������һ�����λ����ͬ��ȥ�����һ����
        If ArrayEdgePt(0).ptEdge.x = ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x And ArrayEdgePt(0).ptEdge.y = ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y And ArrayEdgePt(0).nContourIndex = ArrayEdgePt(ArrayEdgePt.Length - 1).nContourIndex Then
            ReDim Preserve ArrayEdgePt(ArrayEdgePt.Length - 2) '���ȼ�1
        End If
    End Sub
    ''' <summary>
    ''' ��ʼ����ֵ����������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntiArrayContourRegion(ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal ContourValue As Double)
        ReDim Preserve ArrayContourRegion(-1)
        Dim i As Integer
        For i = 0 To ArrayEdgePt.Length - 2
            If ArrayEdgePt(i).bUseFlag = False Then '���û�ù����Ϳ�ʼ׷��
                Dim LastEdgept As EdgePt = ArrayEdgePt(i)
                Dim AEdgePt(0) As EdgePt
                AEdgePt(0) = ArrayEdgePt(i)
                'Ϊ������ĸ��ǿ�ʼ׷�ٵ�ֵ�ߣ�Ӧ�ӱ��Ͽ�ʼ׷��
                If ArrayEdgePt(i).nPtAttribute <> 2 Then
                    TraceEdgePt(i, LastEdgept, AEdgePt, GridPoint, row, col, X_min, Y_min, X_max, Y_max, ContourValue)
                    If AEdgePt.Length > 1 Then
                        ReDim Preserve ArrayContourRegion(ArrayContourRegion.Length)
                        ArrayContourRegion(ArrayContourRegion.Length - 1).vecContourRegPoints = AEdgePt
                    End If
                End If
            End If
        Next
        '��һ���������������ǵ�ֵ��û������ཻ������õ�ֵ�ߵ�ֵС���ĸ����ϵ�ֵ�������ĸ�����ɵ�����Ϊ��ֵ����������Ϊ�հ���
        If ArrayContourRegion.Length = 0 Then
            If GridPoint(0, 0) >= ContourValue Then
                ReDim Preserve ArrayContourRegion(ArrayContourRegion.Length)
                ReDim ArrayContourRegion(ArrayContourRegion.Length - 1).vecContourRegPoints(3)
                ArrayContourRegion(ArrayContourRegion.Length - 1).vecContourRegPoints = ArrayEdgePt
            End If
        End If
    End Sub
    Private Sub TraceEdgePt(ByVal i As Integer, ByVal LastEdgePt As EdgePt, ByRef AEdgePt() As EdgePt, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal ContourValue As Double) '������һ���߽�㣬ֱ��ͷβ����
        ArrayEdgePt(i).bUseFlag = True
        LastEdgePt.bUseFlag = True

        Dim k As Integer
        Dim HeadAndEnd As Boolean = False '��ʾͬһ��ֵ����β����
        For k = 0 To ArrayEdgePt.Length - 1
            If LastEdgePt.nContourIndex = ArrayEdgePt(k).nContourIndex And LastEdgePt.nContourIndex <> -1 Then '�������ཻ�ĵ�ֵ��Ϊͷ����ཻ���ҳ��õ�ֵ�ߵ�β��������β
                If ArrayEdgePt(k).bUseFlag = False Then
                    ArrayEdgePt(k).bUseFlag = True
                    ReDim Preserve AEdgePt(AEdgePt.Length)
                    AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(k)
                    HeadAndEnd = True
                    '����ҵ����˳�ѭ��

                End If
            End If
        Next
        If HeadAndEnd = False Then '�������ͬһ��ֵ����β���ӣ����ཻ��ǰ��һ����һ������м�ֵ���ڸõ�ֵ��ֵ()
            ReDim Preserve AEdgePt(AEdgePt.Length)
            '��һ����������������ǰ��Ϊ4���ǻ���һ����Ҫ���ӵĵ�Ϊ4����ʱ���п��ܳ����м�ֵ<С�ڵ����
            If LastEdgePt.nPtAttribute = 2 Then '���Ϊ4����
                If i = 0 Then '���Ͻ�
                    If ArrayEdgePt(i + 1).bUseFlag = False Then
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    ElseIf ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False Then
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(ArrayEdgePt.Length - 1)
                    Else '��β����
                        AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                    End If
                Else '������
                    If i + 1 > ArrayEdgePt.Length - 1 Then '���Ϊ���Ͻǣ�����һ���������Ͻ�
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
            Else '��������ĸ���
                Dim CenterPoint As PointF
                Dim ai, aj As Integer
                If i + 1 > ArrayEdgePt.Length - 1 Then '��������һ���㣬����һ����Ϊ��㡣�����Ͻǣ����ֻҪ�Ƚ����Ͻ��ǲ���<=�õ㼴�ɣ����>=��ֱ������ 
                    If ArrayEdgePt(0).fValue >= ContourValue And ArrayEdgePt(0).bUseFlag = False Then '�������һ�������>=��ֵ��ֵ��������
                        ArrayEdgePt(0).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(0)
                    ElseIf ArrayEdgePt(i - 1).nPtAttribute = 2 Then '��ǰһ����������ӱȽϿ��ǲ����ĸ��ǣ������
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
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '���ǰһ������м��>=��ֵ��ֵ��������
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else '������β����
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf i - 1 < 0 Then '����ǵ�һ����
                    If ArrayEdgePt(i + 1).fValue >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '�������һ������м��>=��ֵ��ֵ��������
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    ElseIf ArrayEdgePt(ArrayEdgePt.Length - 1).nPtAttribute = 2 Then '��ǰһ����������ӱȽϿ��ǲ����ĸ��ǣ������
                        If ArrayEdgePt(ArrayEdgePt.Length - 1).fValue >= 0 And ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False Then
                            ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(ArrayEdgePt.Length - 1)
                        Else
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    Else '��ǰһ����������ӱȽ�
                        CenterPoint.X = (ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(ArrayEdgePt.Length - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = False Then '���ǰһ������м��>=��ֵ��ֵ��������
                            ArrayEdgePt(ArrayEdgePt.Length - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(ArrayEdgePt.Length - 1)
                        Else '������β����
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf ArrayEdgePt(i + 1).nPtAttribute = 2 And ArrayEdgePt(i - 1).nPtAttribute = 2 Then '���ǰ���Ϊ��
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
                ElseIf ArrayEdgePt(i + 1).nPtAttribute = 2 And ArrayEdgePt(i - 1).nPtAttribute <> 2 Then '��һ����Ϊ����һ���㲻Ϊ��
                    If ArrayEdgePt(i + 1).fValue >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '�������һ�����>=��ֵ��ֵ��������
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    Else
                        CenterPoint.X = (ArrayEdgePt(i - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '���ǰһ������м��>=��ֵ��ֵ��������
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else '������β����
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                ElseIf ArrayEdgePt(i - 1).nPtAttribute = 2 And ArrayEdgePt(i + 1).nPtAttribute <> 2 Then '��һ����Ϊ����һ���㲻Ϊ��
                    If ArrayEdgePt(i - 1).fValue >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '�������һ����>=��ֵ��ֵ��������
                        ArrayEdgePt(i - 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                    Else
                        CenterPoint.X = (ArrayEdgePt(i + 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i + 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '�����һ������м��>=��ֵ��ֵ��������
                            ArrayEdgePt(i + 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                        Else '������β����
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                Else 'ǰ�����Ϊ��
                    CenterPoint.X = (ArrayEdgePt(i + 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                    CenterPoint.Y = (ArrayEdgePt(i + 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                    ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                    aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                    If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i + 1).bUseFlag = False Then '�������һ������м��>=��ֵ��ֵ��������
                        ArrayEdgePt(i + 1).bUseFlag = True
                        AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i + 1)
                    Else '��ǰһ����������ӱȽ�
                        CenterPoint.X = (ArrayEdgePt(i - 1).ptEdge.x + LastEdgePt.ptEdge.x) / 2
                        CenterPoint.Y = (ArrayEdgePt(i - 1).ptEdge.y + LastEdgePt.ptEdge.y) / 2
                        ai = row - 1 - CInt((CenterPoint.Y - Y_min) / ((Y_max - Y_min) / (row - 1)))
                        aj = CInt((CenterPoint.X - X_min) / ((X_max - X_min) / (col - 1)))
                        If GridPoint(ai, aj) >= ContourValue And ArrayEdgePt(i - 1).bUseFlag = False Then '���ǰһ������м��>=��ֵ��ֵ��������
                            ArrayEdgePt(i - 1).bUseFlag = True
                            AEdgePt(AEdgePt.Length - 1) = ArrayEdgePt(i - 1)
                        Else '������β����
                            AEdgePt(AEdgePt.Length - 1) = AEdgePt(0)
                        End If
                    End If
                End If
            End If
        End If

        If AEdgePt.Length >= 3 And AEdgePt(0).ptEdge.x = AEdgePt(AEdgePt.Length - 1).ptEdge.x And AEdgePt(0).ptEdge.y = AEdgePt(AEdgePt.Length - 1).ptEdge.y Then '���ͷβ��ͬ�����˳�
            Exit Sub
        Else
            LastEdgePt = AEdgePt(AEdgePt.Length - 1)
            TraceEdgePt(LastEdgePt.n, LastEdgePt, AEdgePt, GridPoint, row, col, X_min, Y_min, X_max, Y_max, ContourValue) '������ֵ
        End If
    End Sub
End Class

''' <summary>
''' ����߽������ݽṹ
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure EdgePt
    Dim ptEdge As Point3D ' ȡ�߽��ϵĵ�(�߽��߶�����ֵ����߽��ߵĽ���)
    Dim nPtAttribute As Integer '�������:0 :��ֵ�ߵ����,1 :��ֵ�ߵ��յ�,2 :�߽��ߵĶ���
    Dim bUseFlag As Boolean '�õ��Ƿ����ù�
    Dim nContourIndex As Integer '��Ӧ�ĵ�ֵ�߱��,��Ϊ����,ֵΪ- 1
    Dim fValue As Double ' �˵��Ӧ�ĵ�ֵ�ߵĸ߳�,��Ϊ����,�߳�Ϊ�ö����ֵ
    Dim n As Integer '��ʾ�߽���ڱ߽�������е�˳������׷��ǰ��߽��
End Structure
''' <summary>
''' ��ֵ�����ݽṹ
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure ContourRegion
    Dim vecContourRegPoints() As EdgePt '�߽����
End Structure
''' <summary>
''' ��ֵ�����ݽṹ
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure ContourPoints
    Dim vecContourPoints() As Point3D '��ֵ�ߵ���
    Dim fValue As Double '��ֵ�߸߳�
End Structure



