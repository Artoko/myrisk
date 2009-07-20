''' <summary>
''' 污染源标志类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PolluteSymbols
    Private m_Symbol As New Symbol '公共的标志


    Private m_PointSourceSymbols As New SourceSymbols
    Private m_AreaSourceSymbols As New SourceSymbols
    Private m_AreaPolySource As New SourceSymbols
    Private m_AreaCircleSource As New SourceSymbols
    Private m_OpenPitSource As New SourceSymbols
    Private m_VolumeSourceOption As New SourceSymbols
    Private m_LineSourceOption As New SourceSymbols
    ''' <summary>
    ''' 公共的污染源标志，用于控件所有的源的标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Symbol() As Symbol
        Get
            Return m_Symbol
        End Get
        Set(ByVal value As Symbol)
            m_Symbol = value
        End Set
    End Property


    ''' <summary>
    ''' 点源标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PointSourceSymbols() As SourceSymbols
        Get
            Return Me.m_PointSourceSymbols
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_PointSourceSymbols = value
        End Set
    End Property
    ''' <summary>
    ''' 矩形面源标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AreaSourceSymbols() As SourceSymbols
        Get
            Return Me.m_AreaSourceSymbols
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_AreaSourceSymbols = value
        End Set
    End Property
    ''' <summary>
    ''' 多边形面源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AreaPolySource() As SourceSymbols
        Get
            Return Me.m_AreaPolySource
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_AreaPolySource = value
        End Set
    End Property
    ''' <summary>
    ''' 圆形面源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AreaCircleSource() As SourceSymbols
        Get
            Return Me.m_AreaCircleSource
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_AreaCircleSource = value
        End Set
    End Property
    ''' <summary>
    ''' 敞口源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OpenPitSource() As SourceSymbols
        Get
            Return Me.m_OpenPitSource
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_OpenPitSource = value
        End Set
    End Property
    ''' <summary>
    ''' 体源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VolumeSourceOption() As SourceSymbols
        Get
            Return Me.m_VolumeSourceOption
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_VolumeSourceOption = value
        End Set
    End Property
    ''' <summary>
    ''' 线源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LineSourceOption() As SourceSymbols
        Get
            Return Me.m_LineSourceOption
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_LineSourceOption = value
        End Set
    End Property

    Public Function SourceCount() As Integer
        Return m_PointSourceSymbols.ArrayPointSourceNameAndPoints.Length _
            + m_AreaSourceSymbols.ArrayPointSourceNameAndPoints.Length _
            + m_AreaPolySource.ArrayPointSourceNameAndPoints.Length _
            + m_AreaCircleSource.ArrayPointSourceNameAndPoints.Length _
            + m_OpenPitSource.ArrayPointSourceNameAndPoints.Length _
            + m_VolumeSourceOption.ArrayPointSourceNameAndPoints.Length _
            + m_LineSourceOption.ArrayPointSourceNameAndPoints.Length
    End Function

    Public Sub DrawPolluteSymbos(ByVal grap As Graphics)
        PointSourceSymbols.DrawPolluteSymbols(grap, m_Symbol) '给制点源
        AreaSourceSymbols.DrawPolluteSymbols(grap, m_Symbol) '绘制矩形面源
        AreaPolySource.DrawPolluteSymbols(grap, m_Symbol) '绘制多边形面源
        AreaCircleSource.DrawPolluteSymbols(grap, m_Symbol) '圆形面源
        OpenPitSource.DrawPolluteSymbols(grap, m_Symbol) '敞口源
        VolumeSourceOption.DrawPolluteSymbols(grap, m_Symbol) '体源
        LineSourceOption.DrawPolluteSymbols(grap, m_Symbol) '线源
    End Sub

End Class
