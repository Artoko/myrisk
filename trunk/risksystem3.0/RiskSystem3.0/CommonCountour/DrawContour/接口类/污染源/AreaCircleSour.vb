''' <summary>
''' 圆形面源
''' </summary>
''' <remarks></remarks>
Public Class AreaCircleSour
    Inherits BaseSourClass
    ''' <summary>
    ''' 圆形面源半径
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Radius As Double

    ''' <summary>
    ''' 面源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double

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

    ''' <summary>
    ''' 圆形面源半径
    ''' </summary>
    ''' <remarks></remarks>
    Property Radius() As Double
        Get
            Return Me.m_Radius
        End Get
        Set(ByVal value As Double)
            Me.m_Radius = value
        End Set
    End Property
End Class
