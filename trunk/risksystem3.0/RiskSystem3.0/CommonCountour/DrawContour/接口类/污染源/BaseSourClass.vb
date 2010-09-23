
Public Class BaseSourClass
    ''' <summary>
    ''' 污染源的顶点类。如果是圆形面源和体源表示为为源的中心点，其它的表示为起点
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Location As New Location
    ''' <summary>
    ''' 污染源中心的离地面的高度。如果是点源为烟囱顶的离地高度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Height As Double
    ''' <summary>
    ''' 污染源的名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = ""
    ''' <summary>
    ''' 污染源的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Color As Color

    ''' <summary>
    ''' 污染源的顶点类。如果是圆形面源表示为圆形在源的中心点，其它的表示为起点
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Location() As Location
        Get
            Return Me.m_Location
        End Get
        Set(ByVal value As Location)
            Me.m_Location = value
        End Set
    End Property
    ''' <summary>
    ''' 污染源离地面的高度
    ''' </summary>
    ''' <remarks></remarks>
    Property Height() As Double
        Get
            Return Me.m_Height
        End Get
        Set(ByVal value As Double)
            Me.m_Height = value
        End Set
    End Property
    ''' <summary>
    ''' 污染源的名称
    ''' </summary>
    ''' <remarks></remarks>
    Property SourceName() As String
        Get
            Return Me.m_SourceName
        End Get
        Set(ByVal value As String)
            Me.m_SourceName = value
        End Set
    End Property

    ''' <summary>
    ''' 污染源的颜色
    ''' </summary>
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
