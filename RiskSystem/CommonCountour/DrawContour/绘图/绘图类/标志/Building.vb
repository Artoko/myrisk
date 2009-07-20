<Serializable()> Public Class BuildingSymbols
    Private m_Symbol As New Symbol
    Public m_ArrayCareSymbol() As Symbol '关心点数组。在使用关心点数组前应对关心点数组进行初始化赋值
    Public ArrayCareName() As String  '关心点的名称,从(0)开始
    Public ArrayCarePoint() As Point3D '关心点数组,从(0)开始
    Public Sub IntialCareSymbols()
        If ArrayCareName IsNot Nothing AndAlso ArrayCareName.Length > 0 Then
            ReDim m_ArrayCareSymbol(ArrayCareName.Length - 1) '初始化等值线
        End If
    End Sub
    Public Property Symbol() As Symbol
        Get
            Return m_Symbol
        End Get
        Set(ByVal value As Symbol)
            m_Symbol = value
        End Set
    End Property

    Private m_BuildingPoly As New SourceSymbols

    ''' <summary>
    ''' 多边形建筑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BuildingPoly() As SourceSymbols
        Get
            Return Me.m_BuildingPoly
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_BuildingPoly = value
        End Set
    End Property
    Public Sub New()
        m_Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = SymbolShapeStyle.SolidSquare
        m_Symbol.SymbolSign.SymbolShape.SymbolShapeColor = Color.Blue
        m_Symbol.SymbolSign.SymbolColor = Color.Blue
    End Sub
    Public Function BuildingCount() As Integer
        Return m_BuildingPoly.ArrayPointSourceNameAndPoints.Length
    End Function
    Public Sub DrawBuildingSymbols(ByVal grap)
        Me.m_BuildingPoly.DrawPolluteSymbols(grap, m_Symbol)
    End Sub
End Class
