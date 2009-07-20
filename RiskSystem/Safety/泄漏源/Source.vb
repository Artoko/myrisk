''' <summary>
''' 污染源类，包含泄漏源、点源、面源和体源的污染源特征
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Source
    Private m_PLeak As New PointLeak '声明连续点源
    Private m_SLeak As New SurfaceLeak '声明连续面源
    Private m_VLeak As New VolumeLeak '声明连续体源


    Private m_MultiPLeak As New MultiLeakSorce '声明多烟团点源
    Private m_MultiSLeak As New MultiLeakSorce '声明多烟团面源
    Private m_MultiVLeak As New MultiLeakSorce '声明多烟团体源
    ''' <summary>
    ''' 声明连续点源
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
    ''' 声明连续面源
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
    ''' 声明连续体源
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
    ''' 声明多烟团点源
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
    ''' 声明多烟团面源
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
    ''' 声明多烟团体源
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
