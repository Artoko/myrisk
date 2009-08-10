''' <summary>
''' 超压类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Drang
    Private m_Drang As Double
    Private m_DrangName As String
    Private m_Selected As Boolean
    ''' <summary>
    ''' 是否被选中
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Selected() As Boolean
        Get
            Return Me.m_Selected
        End Get
        Set(ByVal value As Boolean)
            Me.m_Selected = value
        End Set

    End Property
    ''' <summary>
    ''' 超压
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MDrang() As Double
        Get
            Return Me.m_Drang
        End Get
        Set(ByVal value As Double)
            Me.m_Drang = value

        End Set
    End Property
    ''' <summary>
    ''' 损害后果名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MDrangName() As String
        Get
            Return m_DrangName
        End Get
        Set(ByVal value As String)
            Me.m_DrangName = value
        End Set
    End Property

End Class
