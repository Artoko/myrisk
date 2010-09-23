Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing
Imports System.Drawing.Drawing2D
''' <summary>
''' 用于计算人口密度的区域
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PopulationRegion
    Implements ICloneable


    ''' <summary>
    ''' 区域的名称
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    Public ArrayLocation(-1) As PointF
    ''' <summary>
    ''' 指定区域内的总人口数
    ''' </summary>
    ''' <remarks></remarks>
    Public AllPopulateion As Integer
    ''' <summary>
    ''' 设置这个区域内的人口
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <remarks></remarks>
    Public Sub SetPopulation(ByRef Grid As Grid)
        Dim nCount As Integer = 0
        '求出在这个区域内的网格点数
        For i As Integer = 0 To Grid.CountY - 1
            For j As Integer = 0 To Grid.CountX - 1
                Dim Point As PointF
                Point.Y = Grid.MinY + (Grid.CountY - 1 - i) * Grid.StepY
                Point.X = Grid.MinX + j * Grid.StepX
                If Inside(Me.ArrayLocation, Point) = True Then
                    nCount += 1
                End If
            Next
        Next
        '计算得到每个网格点上的人口数
        Dim Density As Double = Me.AllPopulateion / nCount
        '设置网格点的人口数
        For i As Integer = 0 To Grid.CountY - 1
            For j As Integer = 0 To Grid.CountX - 1
                Dim Point As PointF
                Point.Y = Grid.MinY + (Grid.CountY - 1 - i) * Grid.StepY
                Point.X = Grid.MinX + j * Grid.StepX
                If Inside(Me.ArrayLocation, Point) = True Then
                    Grid.GridPopulation(i, j) = Density
                End If
            Next
        Next
    End Sub

    Private Function TriFillContourArea(ByVal FillLine() As PointF) As Double
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
    Public Function Inside(ByVal points() As PointF, ByVal Point As PointF)
        Dim path As New GraphicsPath()
        path.AddLines(points)
        Dim region As New Region(path)
        Dim IsIn As Boolean = False '用于判断是不是在三角形中
        If region.IsVisible(Point) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim obj As New PopulationRegion
        obj.Name = Me.Name
        ReDim obj.ArrayLocation(Me.ArrayLocation.Length - 1)
        For i As Integer = 0 To Me.ArrayLocation.Length - 1
            obj.ArrayLocation(i).X = Me.ArrayLocation(i).X
            obj.ArrayLocation(i).Y = Me.ArrayLocation(i).Y

        Next
        obj.AllPopulateion = Me.AllPopulateion
        Return obj
    End Function
End Class
