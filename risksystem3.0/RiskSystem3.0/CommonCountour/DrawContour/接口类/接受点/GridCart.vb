''' <summary>
''' ֱ����������
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class GridCart
    Private m_Xinit As Integer 'X�����ʼ����
    Private m_Xnum As Integer  'X����������
    Private m_Xdelta As Integer  'X��Ĳ���
    Private m_Yinit As Integer 'Y�����ʼ����
    Private m_Ynum As Integer  'Y����������
    Private m_Ydelta As Integer  'Y��Ĳ���
    Private m_XOriginToUtm As Double
    Private m_YOriginToUtm As Double
    ''' <summary>
    ''' X�����ʼ����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Xinit() As Integer
        Get
            Return Me.m_Xinit
        End Get
        Set(ByVal value As Integer)
            Me.m_Xinit = value
        End Set
    End Property

    ''' <summary>
    ''' X����������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Xnum() As Integer
        Get
            Return Me.m_Xnum
        End Get
        Set(ByVal value As Integer)
            Me.m_Xnum = value
        End Set
    End Property

    ''' <summary>
    ''' Y�����ʼ����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Yinit() As Integer
        Get
            Return Me.m_Yinit
        End Get
        Set(ByVal value As Integer)
            Me.m_Yinit = value
        End Set
    End Property

    ''' <summary>
    ''' Y����������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Ynum() As Integer
        Get
            Return Me.m_Ynum
        End Get
        Set(ByVal value As Integer)
            Me.m_Ynum = value
        End Set
    End Property

    ''' <summary>
    ''' Y��Ĳ���
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Ydelta() As Integer
        Get
            Return Me.m_Ydelta
        End Get
        Set(ByVal value As Integer)
            Me.m_Ydelta = value
        End Set
    End Property

    ''' <summary>
    ''' ԭ��ת��UTM��X������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property XOriginToUtm() As Double
        Get
            Return Me.m_XOriginToUtm
        End Get
        Set(ByVal value As Double)
            Me.m_XOriginToUtm = value
        End Set
    End Property
    ''' <summary>
    ''' ԭ��ת��UTM��Y������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property YOriginToUtm() As Double
        Get
            Return Me.m_YOriginToUtm
        End Get
        Set(ByVal value As Double)
            Me.m_YOriginToUtm = value
        End Set
    End Property

End Class
