<Serializable()> Public Class SourceSymbols

    Public ArrayPointSourceNameAndPoints(-1) As NameAndPoints 'ËùµãÔ´

    Public Sub DrawPolluteSymbols(ByVal grap As Graphics, ByVal PolluteSymbol As Symbol)
        If ArrayPointSourceNameAndPoints IsNot Nothing AndAlso ArrayPointSourceNameAndPoints.Length > 0 Then
            For i As Integer = 0 To ArrayPointSourceNameAndPoints.Length - 1
                ArrayPointSourceNameAndPoints(i).DrawPolluteSymbols(grap, PolluteSymbol)
            Next
        End If
    End Sub

End Class
