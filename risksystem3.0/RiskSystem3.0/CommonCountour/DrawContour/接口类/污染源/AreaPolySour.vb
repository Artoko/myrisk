''' <summary>
''' 多边形面源类：包括矩形面、多边形等
''' </summary>
''' <remarks>多边形面源类：包括矩形面、多边形等</remarks>
Public Class AreaPolySour
    Inherits BaseSourClass
    ''' <summary>
    ''' 多边形面源中除矩形面源以外的顶点坐标。这些坐标为2D坐标
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayVertex(-1) As Point2D
    ''' <summary>
    ''' 面源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double

    ''' <summary>
    ''' 多边形面源中除矩形面源以外的顶点坐标。这些坐标为2D坐标，他们跟污染源的顶点坐标位于一个水平面上。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ArrayVertex() As Point2D()
        Get
            Return Me.m_ArrayVertex
        End Get
        Set(ByVal value As Point2D())
            Me.m_ArrayVertex = value
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
