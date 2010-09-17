Imports System.Drawing.Drawing2D
<Serializable()> Public Class Contour
    '��ֵ���࣬���ڻ���һ����ֵ�ߡ���Ҫ������һ����ֵ�ߵ����ԣ����Ƿ�ɼ�����ע��
    Public OneContourLine(-1) As Point3D 'ĳһ����ֵ�ߵ����е�ļ��ϡ����ͬһ����ֵ���ж����ߣ�����Z=-1�ֿ�
    Private ContourLineValue As New ContourLine
    Private ContourFillValue As New ContourFill  '���Ƶ�ֵ���࣬���ڻ��Ƹ����ĵ�ֵ��
    Private GetFillSign As Boolean = True '���¼����ֵ�������־�����ΪTrue�������¼���
    Public ContourVisible As Boolean = True 'ĳһ����ֵ���Ƿ�ɼ�
    Public ContourValue As Double 'ĳһ����ֵ�ߵ�ֵ������<=0
    Public ContourName As String 'ĳһ����ֵ�ߵ�����
    Public HurtValue As Double '�˺���Χ��ֵ
    Public ArrayContourPoints(-1) As ContourPoints '��ֵ�����ݡ���������ÿ��Ԫ�ش�����һ����ֵ�ߵ�����

    Public Property ContourLine() As ContourLine
        Get
            Return ContourLineValue
        End Get
        Set(ByVal value As ContourLine)
            ContourLineValue = value
        End Set
    End Property

    Public Property ContourFill() As ContourFill
        Get
            Return ContourFillValue
        End Get
        Set(ByVal value As ContourFill)
            ContourFillValue = value
        End Set
    End Property


    Public Sub DrawContour(ByVal grap As Graphics, ByVal nContour As Integer, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal ReCalContour As Boolean, ByVal x0 As Double, ByVal y0 As Double)
        If ReCalContour And PannelSetting.PaintType = 0 Then '��ΪTrueʱ�������ɲ���ͼΪ��ֵ��ͼ������û����ı��ֵ�ߣ����������ɸõ�ֵ�ߡ�
            GetOneContour(GridPoint, row, col, X_min, Y_min, X_max, Y_max) '�Ȼ�õ�ֵ�ߣ��ٻ���
            IntiArrayContourPoints(OneContourLine, X_min, Y_min, X_max, Y_max) ' ������õĵ�ֵ��������еĵ�ֵ�߶�
        End If
        '���Ƶ�ֵ�ߺͱ�ע
        ContourLineValue.DrawContourLine(grap, ArrayContourPoints, ContourValue, HurtValue, x0, y0)
    End Sub
    Public Sub GetFillRegion(ByVal grap As Graphics, ByVal nContour As Integer, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal fillcontourregion() As Region, ByVal ReCalContour As Boolean, ByVal x0 As Double, ByVal y0 As Double)
        If ReCalContour Then '��ΪTrueʱ�������ɡ�����û����ı��ֵ�ߣ����������ɸõ�ֵ�ߡ�
            GetOneContour(GridPoint, row, col, X_min, Y_min, X_max, Y_max) '�Ȼ�õ�ֵ�ߣ��ٻ���
            IntiArrayContourPoints(OneContourLine, X_min, Y_min, X_max, Y_max) ' ������õĵ�ֵ��������еĵ�ֵ�߶�
        End If
        '�����ֵ������
        ContourFillValue.CalculateFillContour(grap, ArrayContourPoints, nContour, GridPoint, row, col, X_min, Y_min, X_max, Y_max, fillcontourregion, ContourValue, HurtValue, ReCalContour, x0, y0) '�����ֵ������
    End Sub

    Private Sub GetOneContour(ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double)
        ''ͨ����ֵ�߿ؼ������ĳһ����ֵ�ĵ�ֵ�ߣ�����ֵ������OneContourLine
        'Dim AContour As New Contour 
        'Dim AIn(col - 1, row - 1) As Double
        ''��������е��ñ任�ͷ�ת�任
        'Dim i, j, k As Integer
        'For i = 0 To col - 1
        '    For j = 0 To row - 1
        '        AIn(i, j) = GridPoint(row - 1 - j, i)
        '    Next
        'Next
        ''��ʼ����ֵ��
        'Dim AOut(-1, -1) As ContourDLL.Point3D
        'AContour.Intial(AIn, row, col, X_min, Y_min, X_max, Y_max) '��ʼ����ֵ��
        'AContour.Calculate(ContourValue) '�����ֵ��
        'AContour.PutContour(AOut) '�����ֵ��
        'Dim OneContourLines As Integer 'ͬһֵ�ĵ�ֵ������
        'OneContourLines = AContour.PutLineNumber()
        ''���´��뽫��Ч�ĵ�ֵ��ֵ��������OneContourLine�У����ڶ�����ֵ�ߣ���Z��-1�ֿ�
        'ReDim OneContourLine(-1)
        'k = 0
        'For i = 0 To OneContourLines - 1
        '    j = 0
        '    Do '��������ѭ����ʹ���һ��Z��-1��������������
        '        ReDim Preserve OneContourLine(k)
        '        OneContourLine(k).x = AOut(i, j).x
        '        OneContourLine(k).y = AOut(i, j).y
        '        OneContourLine(k).z = AOut(i, j).z
        '        j = j + 1
        '        k = k + 1
        '    Loop While AOut(i, j - 1).z <> -1
        'Next
    End Sub
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
                    contourPoint(j).x = FormatNumber(OneContourLine(i).x, 9) '��ȷ��9λ������˫�����������һ����������
                    contourPoint(j).y = FormatNumber(OneContourLine(i).y, 9)
                    contourPoint(j).z = FormatNumber(OneContourLine(i).z, 9)
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
End Class
