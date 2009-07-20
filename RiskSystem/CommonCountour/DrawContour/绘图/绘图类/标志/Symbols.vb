''' <summary>
''' 标志类，用于绘制污染源标志、关心点标志等
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Symbols
    Private mPolluteSymbols As New PolluteSymbols
    Private mCareSymbols As New CareSymbols
    Private m_BuildingSymbols As New BuildingSymbols

    ''' <summary>
    ''' 污染源标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PolluteSymbol() As PolluteSymbols
        Get
            Return mPolluteSymbols
        End Get
        Set(ByVal value As PolluteSymbols)
            mPolluteSymbols = value
        End Set
    End Property

    Public Property CareSymbols() As CareSymbols
        Get
            Return mCareSymbols
        End Get
        Set(ByVal value As CareSymbols)
            mCareSymbols = value
        End Set
    End Property
    ''' <summary>
    ''' 建筑物标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BuildingSymbols() As BuildingSymbols
        Get
            Return Me.m_BuildingSymbols
        End Get
        Set(ByVal value As BuildingSymbols)
            Me.m_BuildingSymbols = value
        End Set
    End Property

    Public Sub DrawSymbols(ByVal grap)
        mPolluteSymbols.DrawPolluteSymbos(grap) '污染源
        mCareSymbols.DrawCareSymbols(grap) '关心点
        m_BuildingSymbols.DrawBuildingSymbols(grap) '建筑物
    End Sub

End Class
