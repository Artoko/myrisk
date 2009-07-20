<Serializable()> Public Class Vane
    Private m_VaneType As Integer = 1 '预测类型。0为自定义步长，1为等步长
    Private m_VaneStep As Integer = 10 '预测步长，m。
    Private m_VaneCount As Integer = 50 '步长的个数，m。
    Private m_VaneA() As Integer = {10, 20, 30} '自定义步长数组
    Private m_VaneDistance As Integer = 2000 '距离
    ''' <summary>
    ''' 预测类型。0为自定义步长，1为等步长
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VaneType() As Integer
        Get
            Return m_VaneType
        End Get
        Set(ByVal value As Integer)
            m_VaneType = value
        End Set
    End Property
    ''' <summary>
    ''' 预测步长，m。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VaneStep() As Integer
        Get
            Return Me.m_VaneStep
        End Get
        Set(ByVal value As Integer)
            Me.m_VaneStep = value
        End Set
    End Property

    ''' <summary>
    ''' 步长的个数，m。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VaneCount() As Integer
        Get
            Return Me.m_VaneCount
        End Get
        Set(ByVal value As Integer)
            Me.m_VaneCount = value
        End Set
    End Property
    ''' <summary>
    ''' 自定义步长数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VaneA() As Integer()
        Get
            Return m_VaneA
        End Get
        Set(ByVal value As Integer())
            m_VaneA = value
        End Set
    End Property

    Property VaneDistance() As Integer '距离
        Get
            Return m_VaneDistance
            m_VaneCount = m_VaneDistance / m_VaneStep
        End Get
        Set(ByVal value As Integer)
            m_VaneDistance = value
        End Set
    End Property
End Class
