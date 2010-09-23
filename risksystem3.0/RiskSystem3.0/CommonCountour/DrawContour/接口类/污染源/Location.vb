''' <summary>
''' 污染源基底的位置
''' </summary>
''' <remarks></remarks>
Public Class Location

    ''' <summary>
    ''' 污染源底坐坐标的x值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Xs As Double

    ''' <summary>
    ''' 污染源底坐坐标的y值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Ys As Double

    ''' <summary>
    ''' 污染源底坐坐标的z值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Zs As Double


    ''' <summary>
    ''' 污染源底坐坐标的x值
    ''' </summary>
    ''' <remarks></remarks>
    Property Xs() As Double
        Get
            Return Me.m_Xs
        End Get
        Set(ByVal value As Double)
            Me.m_Xs = value
        End Set
    End Property
    ''' <summary>
    ''' 污染源底坐坐标的y值
    ''' </summary>
    ''' <remarks></remarks>
    Property Ys() As Double
        Get
            Return Me.m_Ys
        End Get
        Set(ByVal value As Double)
            Me.m_Ys = value
        End Set
    End Property
    ''' <summary>
    ''' 污染源底坐坐标的z值
    ''' </summary>
    ''' <remarks></remarks>
    Property Zs() As Double
        Get
            Return Me.m_Zs
        End Get
        Set(ByVal value As Double)
            Me.m_Zs = value
        End Set
    End Property

End Class
