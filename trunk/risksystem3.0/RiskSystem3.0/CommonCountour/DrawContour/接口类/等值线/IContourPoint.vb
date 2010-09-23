''' <summary>
''' 单条等值线
''' </summary>
''' <remarks></remarks>
Public Class IContourPoints
    Private m_VecPoints(-1) As Point2D '等值线点列
    Private m_fValue As Double '等值线高程
    ''' <summary>
    ''' 等值线的闭合线
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VecPoints() As Point2D() '等值线点列
        Get
            Return Me.m_VecPoints
        End Get
        Set(ByVal value As Point2D())
            Me.m_VecPoints = value
        End Set
    End Property
    ''' <summary>
    ''' 等值线的浓度值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property fValue() As Double '
        Get
            Return Me.m_fValue
        End Get
        Set(ByVal value As Double)
            Me.m_fValue = value
        End Set
    End Property

End Class
