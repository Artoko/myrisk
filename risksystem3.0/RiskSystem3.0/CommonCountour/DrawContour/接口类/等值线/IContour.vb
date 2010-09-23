''' <summary>
''' 某一给定浓度值的等值线
''' </summary>
''' <remarks></remarks>
Public Class IContour
    Private m_ArrayIContourPoint(-1) As IContourPoints

    Private m_fValue As Double '等值线高程
    Private m_Color As Color '等值线的颜色


    ''' <summary>
    ''' 同一浓度值有可能有多条等值线
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ArrayIContourPoint() As IContourPoints()
        Get
            Return Me.m_ArrayIContourPoint
        End Get
        Set(ByVal value As IContourPoints())
            Me.m_ArrayIContourPoint = value
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
    ''' <summary>
    ''' 等值线的颜色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Color() As Color
        Get
            Return Me.m_Color
        End Get
        Set(ByVal value As Color)
            Me.m_Color = value
        End Set
    End Property

End Class
