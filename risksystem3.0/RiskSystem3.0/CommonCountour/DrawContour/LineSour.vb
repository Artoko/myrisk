
Public Class LineSour
    Inherits BaseSourClass
    Private m_LinePoints(-1) As Point3D '用于储存线源的顶点的数组。数组的第一个点为线源的起点。
    Private m_Width As Double = 10 '用于储存线源的宽度
    ''' <summary>
    ''' 线源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double
    ''' <summary>
    ''' 用于储存线源的数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LinePoints() As Point3D() '
        Get
            Return Me.m_LinePoints
        End Get
        Set(ByVal value As Point3D())
            Me.m_LinePoints = value
        End Set
    End Property
    ''' <summary>
    ''' 用于储存线源的宽度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Width() As Double '
        Get
            Return Me.m_Width
        End Get
        Set(ByVal value As Double)
            Me.m_Width = value
        End Set
    End Property
    ''' <summary>
    ''' 线源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Property Thickness() As Double
        Get
            Return Me.m_Thickness
        End Get
        Set(ByVal value As Double)
            Me.m_Thickness = value
        End Set
    End Property
End Class
