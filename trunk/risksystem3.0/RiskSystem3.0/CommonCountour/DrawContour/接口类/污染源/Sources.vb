''' <summary>
''' 污染源类。包含了多个污染源数组
''' </summary>
''' <remarks></remarks>
Public Class Sources
    ''' <summary>
    ''' 点源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayPointSour(-1) As PointSour
    
    ''' <summary>
    ''' 多边形面源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayAreaPolySour(-1) As AreaPolySour
    ''' <summary>
    ''' 圆形面源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayAreaCircleSour(-1) As AreaCircleSour
    ''' <summary>
    ''' 体源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayVolumeSour(-1) As VolumeSour

    ''' <summary>
    ''' 矩形面源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayAreaSour(-1) As AreaSour

    ''' <summary>
    ''' 敞口源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayOpenSour(-1) As OpenSour

    ''' <summary>
    ''' 点源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Property ArrayPointSour() As PointSour()
        Get
            Return Me.m_ArrayPointSour
        End Get
        Set(ByVal value As PointSour())
            Me.m_ArrayPointSour = value
        End Set
    End Property
    ''' <summary>
    ''' 多边形面源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Property ArrayAreaPolySour() As AreaPolySour()
        Get
            Return Me.m_ArrayAreaPolySour
        End Get
        Set(ByVal value As AreaPolySour())
            Me.m_ArrayAreaPolySour = value
        End Set
    End Property
    ''' <summary>
    ''' 圆形面源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Property ArrayAreaCircleSour() As AreaCircleSour()
        Get
            Return Me.m_ArrayAreaCircleSour
        End Get
        Set(ByVal value As AreaCircleSour())
            Me.m_ArrayAreaCircleSour = value
        End Set
    End Property
    ''' <summary>
    ''' 体源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Property ArrayVolumeSour() As VolumeSour()
        Get
            Return Me.m_ArrayVolumeSour
        End Get
        Set(ByVal value As VolumeSour())
            Me.m_ArrayVolumeSour = value
        End Set
    End Property
    ''' <summary>
    ''' 矩形面源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ArrayAreaSour() As AreaSour()
        Get
            Return Me.m_ArrayAreaSour
        End Get
        Set(ByVal value As AreaSour())
            Me.m_ArrayAreaSour = value
        End Set
    End Property
    ''' <summary>
    ''' 敞口源数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ArryOpenSour() As OpenSour()
        Get
            Return Me.m_ArrayOpenSour
        End Get
        Set(ByVal value As OpenSour())
            Me.m_ArrayOpenSour = value
        End Set
    End Property
    

End Class
