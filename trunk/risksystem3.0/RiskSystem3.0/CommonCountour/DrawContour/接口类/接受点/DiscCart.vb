''' <summary>
''' 直角坐标关心点
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class DiscCart
    Private m_Name As String = "" '计算点的名称
    Private m_Xcoord As Double = 0 'X坐标
    Private m_Ycoord As Double = 0 'Y坐标
    Private m_Zelev As Double = 0 '
    ''' <summary>
    ''' 计算点的名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 关心点的X坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Xcoord() As Double
        Get
            Return Me.m_Xcoord
        End Get
        Set(ByVal value As Double)
            Me.m_Xcoord = value
        End Set
    End Property
    ''' <summary>
    ''' 关心点的Z坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Ycoord() As Double
        Get
            Return Me.m_Ycoord
        End Get
        Set(ByVal value As Double)
            Me.m_Ycoord = value
        End Set
    End Property
    ''' <summary>
    ''' 关心点Z坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Zelev() As Double
        Get
            Return Me.m_Zelev
        End Get
        Set(ByVal value As Double)
            Me.m_Zelev = value
        End Set
    End Property
End Class
