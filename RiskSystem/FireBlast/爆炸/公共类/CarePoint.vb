''' <summary>
''' 距离类
''' </summary>
''' <remarks></remarks>
Public Class CarePoint
    Private m_Dist As String = ""
    Private m_Rpoint As New Point2D
    Private m_ResultDistanceDp As Double
    Private m_Pr As Double = 0
    Private m_D As Double = 0
    ''' <summary>
    ''' 距离名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Dist() As String
        Get
            Return Me.m_Dist
        End Get
        Set(ByVal value As String)
            Me.m_Dist = value
        End Set
    End Property
    ''' <summary>
    ''' 热辐射
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultDistanceDp() As Double
        Get
            Return Me.m_ResultDistanceDp
        End Get
        Set(ByVal value As Double)
            Me.m_ResultDistanceDp = value
        End Set
    End Property
    ''' <summary>
    ''' 死亡概率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Pr() As Double
        Get
            Return Me.m_Pr
        End Get
        Set(ByVal value As Double)
            Me.m_Pr = value
        End Set
    End Property
    ''' <summary>
    ''' 死亡百分率 %
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property D() As Double
        Get
            Return Me.m_D
        End Get
        Set(ByVal value As Double)
            Me.m_D = value
        End Set
    End Property
    ''' <summary>
    ''' 事故源坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Rpoint() As Point2D
        Get
            Return Me.m_Rpoint
        End Get
        Set(ByVal value As Point2D)
            Me.m_Rpoint = value
        End Set
    End Property
End Class
