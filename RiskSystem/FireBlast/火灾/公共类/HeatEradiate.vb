''' <summary>
''' 热辐射类
''' </summary>
''' <remarks></remarks>
Public Class HeatEradiate
    Private m_HeatName As String   '损害后果名称
    Private m_Heat As Double       '热辐射通量[W/m^2]
    Private m_Checkd As Boolean = True    '状态是否被选种（T/F）
    ''' <summary>
    ''' 损害后果名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HeatName() As String
        Get
            Return Me.m_HeatName
        End Get
        Set(ByVal value As String)
            Me.m_HeatName = value
        End Set
    End Property
    ''' <summary>
    ''' 热辐射通量[W/m^2]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Heat() As Double
        Get
            Return Me.m_Heat
        End Get
        Set(ByVal value As Double)
            Me.m_Heat = value
        End Set
    End Property
    ''' <summary>
    ''' 状态是否被选种（T/F）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Checkd() As Boolean
        Get
            Return Me.m_Checkd
        End Get
        Set(ByVal value As Boolean)
            Me.m_Checkd = value
        End Set
    End Property
End Class
