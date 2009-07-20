Module Formular
    Public Function GetR(ByVal pointCare2D As Point2D, ByVal pointSource2D As Point2D) As Double
        Return Math.Sqrt((pointCare2D.x - pointSource2D.x) ^ 2 + (pointCare2D.y - pointSource2D.y) ^ 2)
    End Function

End Module
