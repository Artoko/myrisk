''' <summary>
''' 敞口源
''' </summary>
''' <remarks></remarks>
Public Class OpenSour
    Inherits BaseSourClass
    Private m_ArrayTop(2) As Point
    ''' <summary>
    ''' 敞口面源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double
    ''' <summary>
    ''' 敞口源的其它3个顶点的坐标，不含Z坐标
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
    ''' 敞口源的厚度
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
