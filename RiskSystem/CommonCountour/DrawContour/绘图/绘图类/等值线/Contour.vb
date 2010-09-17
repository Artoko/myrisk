Imports System.Drawing.Drawing2D
<Serializable()> Public Class Contour
    '等值线类，用于绘制一条等值线。主要包括这一条等值线的属性，如是否可见，标注等
    Public OneContourLine(-1) As Point3D '某一条等值线的所有点的集合。如果同一条等值线有多条线，则用Z=-1分开
    Private ContourLineValue As New ContourLine
    Private ContourFillValue As New ContourFill  '绘制等值线类，用于绘制给定的等值线
    Private GetFillSign As Boolean = True '重新计算等值线区域标志，如果为True，则重新计算
    Public ContourVisible As Boolean = True '某一条等值线是否可见
    Public ContourValue As Double '某一条等值线的值，不能<=0
    Public ContourName As String '某一条等值线的名称
    Public HurtValue As Double '伤害范围的值
    Public ArrayContourPoints(-1) As ContourPoints '等值线数据。该数组中每个元素储存了一条等值线的数组

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
        If ReCalContour And PannelSetting.PaintType = 0 Then '当为True时重新生成并且图为等值线图。如果用户不改变等值线，则不重新生成该等值线。
            GetOneContour(GridPoint, row, col, X_min, Y_min, X_max, Y_max) '先获得等值线，再绘制
            IntiArrayContourPoints(OneContourLine, X_min, Y_min, X_max, Y_max) ' 根据求得的等值线求出所有的等值线段
        End If
        '绘制等值线和标注
        ContourLineValue.DrawContourLine(grap, ArrayContourPoints, ContourValue, HurtValue, x0, y0)
    End Sub
    Public Sub GetFillRegion(ByVal grap As Graphics, ByVal nContour As Integer, ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double, ByVal fillcontourregion() As Region, ByVal ReCalContour As Boolean, ByVal x0 As Double, ByVal y0 As Double)
        If ReCalContour Then '当为True时重新生成。如果用户不改变等值线，则不重新生成该等值线。
            GetOneContour(GridPoint, row, col, X_min, Y_min, X_max, Y_max) '先获得等值线，再绘制
            IntiArrayContourPoints(OneContourLine, X_min, Y_min, X_max, Y_max) ' 根据求得的等值线求出所有的等值线段
        End If
        '计算等值线区域
        ContourFillValue.CalculateFillContour(grap, ArrayContourPoints, nContour, GridPoint, row, col, X_min, Y_min, X_max, Y_max, fillcontourregion, ContourValue, HurtValue, ReCalContour, x0, y0) '计算等值线区域
    End Sub

    Private Sub GetOneContour(ByVal GridPoint(,) As Double, ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double)
        ''通过等值线控件，获得某一给定值的等值线，并将值给数据OneContourLine
        'Dim AContour As New Contour 
        'Dim AIn(col - 1, row - 1) As Double
        ''对数组进行倒置变换和反转变换
        'Dim i, j, k As Integer
        'For i = 0 To col - 1
        '    For j = 0 To row - 1
        '        AIn(i, j) = GridPoint(row - 1 - j, i)
        '    Next
        'Next
        ''初始化等值线
        'Dim AOut(-1, -1) As ContourDLL.Point3D
        'AContour.Intial(AIn, row, col, X_min, Y_min, X_max, Y_max) '初始化等值线
        'AContour.Calculate(ContourValue) '计算等值线
        'AContour.PutContour(AOut) '输出等值线
        'Dim OneContourLines As Integer '同一值的等值线条数
        'OneContourLines = AContour.PutLineNumber()
        ''以下代码将有效的等值线值加入数组OneContourLine中，对于多条等值线，用Z＝-1分开
        'ReDim OneContourLine(-1)
        'k = 0
        'For i = 0 To OneContourLines - 1
        '    j = 0
        '    Do '采用这种循环可使最后一个Z＝-1的数加入数组中
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
                    contourPoint(j).x = FormatNumber(OneContourLine(i).x, 9) '精确到9位，避免双精度数据最后一倍引起的误差
                    contourPoint(j).y = FormatNumber(OneContourLine(i).y, 9)
                    contourPoint(j).z = FormatNumber(OneContourLine(i).z, 9)
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
End Class
