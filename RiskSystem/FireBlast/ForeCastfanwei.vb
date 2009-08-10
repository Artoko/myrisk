<Serializable()> Public Class Grid
    Private m_MinX As Integer = -200 'X轴的起始坐标,m
    Private m_StepX As Integer = 10 'X轴的步长,m
    Private m_CountX As Integer = 41 'X轴的网格数
    Private m_MinY As Integer = -200 'Y轴的起始坐标,m
    Private m_StepY As Integer = 10 'Y轴的步长,m
    Private m_CountY As Integer = 41 'Y轴的网格数
    Private m_MaxX As Integer = 200 'X轴的结束坐标,m
    Private m_MaxY As Integer = 200 'Y轴的结束坐标,m
    ''' <summary>
    ''' X轴的起始坐标,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MinX() As Integer
        Get
            Return Me.m_MinX
        End Get
        Set(ByVal value As Integer)
            Me.m_MinX = value
        End Set
    End Property
    ''' <summary>
    ''' X轴的步长,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepX() As Integer
        Get
            Return Me.m_StepX
        End Get
        Set(ByVal value As Integer)
            Me.m_StepX = value
        End Set
    End Property
    ''' <summary>
    ''' X轴的网格数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CountX() As Integer
        Get
            Return Me.m_CountX
        End Get
        Set(ByVal value As Integer)
            Me.m_CountX = value
        End Set
    End Property
    ''' <summary>
    ''' Y轴的起始坐标,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MinY() As Integer
        Get
            Return Me.m_MinY
        End Get
        Set(ByVal value As Integer)
            Me.m_MinY = value
        End Set
    End Property
    ''' <summary>
    ''' Y轴的步长,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepY() As Integer
        Get
            Return Me.m_StepY
        End Get
        Set(ByVal value As Integer)
            Me.m_StepY = value
        End Set
    End Property
    ''' <summary>
    ''' Y轴的网格数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CountY() As Integer
        Get
            Return Me.m_CountY
        End Get
        Set(ByVal value As Integer)
            Me.m_CountY = value
        End Set
    End Property
    ''' <summary>
    ''' X轴的结束坐标,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MaxX() As Integer
        Get
            Return Me.m_MaxX
        End Get
        Set(ByVal value As Integer)
            Me.m_MaxX = value
        End Set
    End Property
    ''' <summary>
    ''' Y轴的结束坐标,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MaxY() As Integer
        Get
            Return Me.m_MaxY
        End Get
        Set(ByVal value As Integer)
            Me.m_MaxY = value
        End Set
    End Property
End Class
