<Serializable()> Public Class NameAndPoints
    ''' <summary>
    ''' 污染点的名称
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' 污染源点位数组,从(0)开始
    ''' </summary>
    ''' <remarks></remarks>
    Public ArrayPoint(-1) As Point3D
    ''' <summary>
    ''' 0多边形、包括矩形；1圆形；2体源；3线形
    ''' </summary>
    ''' <remarks></remarks>
    Public Type As Integer = 0
    ''' <summary>
    ''' 圆的半径或体源的边维
    ''' </summary>
    ''' <remarks></remarks>
    Public Radius As Single = 0
    Public Sub DrawPolluteSymbols(ByVal grap As Graphics, ByVal SourceSymbol As Symbol)
        If ArrayPoint IsNot Nothing AndAlso ArrayPoint.Length > 0 Then
            Dim mSymbol As New Symbol
            mSymbol = SourceSymbol
            mSymbol.SymbolText.Name = Name
            mSymbol.SymbolSign.mSymbolsPoint.X = ArrayPoint(0).x
            mSymbol.SymbolSign.mSymbolsPoint.Y = ArrayPoint(0).y
            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            mSymbol.DrawSymbol(grap)
            Dim DPen As New Pen(mSymbol.SymbolSign.SymbolColor, 0.0001)
            Select Case Type
                Case 0 '多边形
                    Dim pf(ArrayPoint.Length) As PointF
                    For i As Integer = 0 To ArrayPoint.Length - 1
                        pf(i).X = ArrayPoint(i).x
                        pf(i).Y = ArrayPoint(i).y
                    Next
                    '绘制多边形
                    pf(ArrayPoint.Length).X = ArrayPoint(0).x
                    pf(ArrayPoint.Length).Y = ArrayPoint(0).y

                    grap.DrawLines(DPen, pf)

                Case 1 '圆形
                    grap.DrawEllipse(DPen, CSng(ArrayPoint(0).x - Radius), CSng(ArrayPoint(0).y - Radius), 2 * Radius, 2 * Radius)

                Case 2 '体源
                    grap.DrawRectangle(DPen, CSng(ArrayPoint(0).x - Radius / 2), CSng(ArrayPoint(0).y - Radius / 2), Radius, Radius)

                Case 3 '线源
                    Dim pf(ArrayPoint.Length - 1) As PointF
                    For i As Integer = 0 To ArrayPoint.Length - 1
                        pf(i).X = ArrayPoint(i).x
                        pf(i).Y = ArrayPoint(i).y
                    Next
                    grap.DrawLines(DPen, pf)

            End Select


        End If
    End Sub
End Class
