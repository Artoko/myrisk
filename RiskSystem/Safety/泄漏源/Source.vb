''' <summary>
''' ��ȾԴ�࣬����й©Դ����Դ����Դ����Դ����ȾԴ����
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Source
    Private m_PLeak As New PointLeak '����������Դ
    Private m_SLeak As New SurfaceLeak '����������Դ
    Private m_VLeak As New VolumeLeak '����������Դ


    Private m_MultiPLeak As New MultiLeakSorce '���������ŵ�Դ
    Private m_MultiSLeak As New MultiLeakSorce '������������Դ
    Private m_MultiVLeak As New MultiLeakSorce '������������Դ
    ''' <summary>
    ''' ����������Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PLeak() As PointLeak '
        Get
            Return Me.m_PLeak
        End Get
        Set(ByVal value As PointLeak)
            Me.m_PLeak = value
        End Set
    End Property
    ''' <summary>
    ''' ����������Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SLeak() As SurfaceLeak '
        Get
            Return Me.m_SLeak
        End Get
        Set(ByVal value As SurfaceLeak)
            Me.m_SLeak = value
        End Set
    End Property
    ''' <summary>
    ''' ����������Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VLeak() As VolumeLeak '
        Get
            Return Me.m_VLeak
        End Get
        Set(ByVal value As VolumeLeak)
            Me.m_VLeak = value
        End Set
    End Property
    ''' <summary>
    ''' ���������ŵ�Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MultiPLeak() As MultiLeakSorce
        Get
            Return Me.m_MultiPLeak
        End Get
        Set(ByVal value As MultiLeakSorce)
            Me.m_MultiPLeak = value
        End Set
    End Property
    ''' <summary>
    ''' ������������Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MultiSLeak() As MultiLeakSorce
        Get
            Return Me.m_MultiSLeak
        End Get
        Set(ByVal value As MultiLeakSorce)
            Me.m_MultiSLeak = value
        End Set
    End Property
    ''' <summary>
    ''' ������������Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MultiVLeak() As MultiLeakSorce
        Get
            Return Me.m_MultiVLeak
        End Get
        Set(ByVal value As MultiLeakSorce)
            Me.m_MultiVLeak = value
        End Set
    End Property
End Class
