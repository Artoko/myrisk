<Serializable()> Public Class Grid
    Private m_MinX As Integer = -200 'X�����ʼ����,m
    Private m_StepX As Integer = 10 'X��Ĳ���,m
    Private m_CountX As Integer = 41 'X���������
    Private m_MinY As Integer = -200 'Y�����ʼ����,m
    Private m_StepY As Integer = 10 'Y��Ĳ���,m
    Private m_CountY As Integer = 41 'Y���������
    Private m_MaxX As Integer = 200 'X��Ľ�������,m
    Private m_MaxY As Integer = 200 'Y��Ľ�������,m
    ''' <summary>
    ''' X�����ʼ����,m
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
    ''' X��Ĳ���,m
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
    ''' X���������
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
    ''' Y�����ʼ����,m
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
    ''' Y��Ĳ���,m
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
    ''' Y���������
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
    ''' X��Ľ�������,m
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
    ''' Y��Ľ�������,m
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
