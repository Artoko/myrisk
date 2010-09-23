''' <summary>
''' 矩形面源
''' </summary>
''' <remarks></remarks>
Public Class AreaSour
    Inherits BaseSourClass
    Private m_ArrayTop(2) As Point
    ''' <summary>
    ''' 矩形面源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double
    ''' <summary>
    ''' 矩形面源的其它3个顶点的坐标，不含Z坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ArrayTop() As Point()
        Get
            Return m_ArrayTop
        End Get
        Set(ByVal value As Point())
            m_ArrayTop = value
        End Set
    End Property
    ''' <summary>
    ''' 面源的厚度
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
