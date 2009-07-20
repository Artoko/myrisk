Public Class PublicFun
    Public Overloads Shared Function Distance(ByVal P1 As PointF, ByVal P2 As PointF) As Double
        Dim a As Double
        a = Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2)
        Return Math.Sqrt(a)
    End Function
    Public Overloads Shared Function Distance(ByVal P1 As Point, ByVal P2 As Point) As Double
        Dim a As Double
        a = Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2)
        Return Math.Sqrt(a)
    End Function
End Class
