<Serializable()> Public Class CareSymbols
    Private mCareSymbol As New Symbol
    Public mArrayCareSymbol(-1) As Symbol '���ĵ����顣��ʹ�ù��ĵ�����ǰӦ�Թ��ĵ�������г�ʼ����ֵ
    Public ArrayCareName(-1) As String  '���ĵ������,��(0)��ʼ
    Public ArrayCarePoint(-1) As Point3D '���ĵ�����,��(0)��ʼ
    Public Sub IntialCareSymbols()
        If ArrayCareName IsNot Nothing AndAlso ArrayCareName.Length > 0 Then
            ReDim mArrayCareSymbol(ArrayCareName.Length - 1) '��ʼ����ֵ��
        End If
    End Sub
    Public Property Symbol() As Symbol
        Get
            Return mCareSymbol
        End Get
        Set(ByVal value As Symbol)
            mCareSymbol = value
        End Set
    End Property
    Public Sub New()
        Me.mCareSymbol.SymbolSign.SymbolShape.SymbolShapeStyle = SymbolShapeStyle.SolidUpwardTriangle
        Me.mCareSymbol.SymbolSign.SymbolShape.SymbolShapeColor = Color.Green
        Me.mCareSymbol.SymbolSign.SymbolColor = Color.Green
    End Sub
    Public Sub DrawCareSymbols(ByVal grap As Graphics)
        If ArrayCareName IsNot Nothing AndAlso ArrayCareName.Length > 0 Then
            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim i As Integer = 0
            For i = 0 To ArrayCareName.Length - 1
                mArrayCareSymbol(i) = mCareSymbol
                mArrayCareSymbol(i).SymbolText.Name = ArrayCareName(i)
                mArrayCareSymbol(i).SymbolSign.mSymbolsPoint.X = ArrayCarePoint(i).x
                mArrayCareSymbol(i).SymbolSign.mSymbolsPoint.Y = ArrayCarePoint(i).y
                mArrayCareSymbol(i).DrawSymbol(grap)
            Next
        End If

    End Sub

End Class
