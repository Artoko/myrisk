''' <summary>
''' 气象条件类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Met
    Private m_Vane As String  '风向
    Private m_Wind_Speed As Double '风速,m/s
    Private m_Stab As String '稳定度
    Private m_Frequency As Double = 0.01 '该气象的频率
    Private m_u2 As Double '泄漏口高度处风速
    Private m_U_Ground As Double '声明地面风速，因为在热量蒸发模型中用到
    ''' <summary>
    ''' 风向
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Vane() As String
        Get
            Return Me.m_Vane
        End Get
        Set(ByVal value As String)
            Me.m_Vane = value
        End Set
    End Property
    ''' <summary>
    ''' 风速,m/s
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WindSpeed() As Double
        Get
            Return Me.m_Wind_Speed
        End Get
        Set(ByVal value As Double)
            Me.m_Wind_Speed = value
        End Set
    End Property
    ''' <summary>
    ''' 稳定度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Stab() As String
        Get
            Return Me.m_Stab
        End Get
        Set(ByVal value As String)
            Me.m_Stab = value
        End Set
    End Property
    ''' <summary>
    ''' 该气象的频率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Frequency() As Double '
        Get
            Return m_Frequency
        End Get
        Set(ByVal value As Double)
            m_Frequency = value
        End Set
    End Property
    ''' <summary>
    ''' 泄漏口高度处风速
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property u2() As Double '
        Get
            Return Me.m_u2
        End Get
        Set(ByVal value As Double)
            Me.m_u2 = value
        End Set
    End Property
    ''' <summary>
    ''' 声明地面风速，因为在热量蒸发模型中用到
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property U_Ground() As Double '
        Get
            Return Me.m_U_Ground
        End Get
        Set(ByVal value As Double)
            Me.m_U_Ground = value
        End Set
    End Property
End Class
