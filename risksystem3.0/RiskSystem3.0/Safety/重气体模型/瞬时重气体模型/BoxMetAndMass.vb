''' <summary>
''' 用于储存气象条件和云团状态的类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class BoxMetAndMass
    ''' <summary>
    ''' 云团属性数组
    ''' </summary>
    ''' <remarks></remarks>
    Private m_BoxAirMass(0) As BoxAirMass

    ''' <summary>
    ''' 高度Z处的风速，Z通常取10m
    ''' </summary>
    ''' <remarks></remarks>
    Private m_u10 As Double = 1.8

    ''' <summary>
    ''' 稳定度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_stab As String = "D"

    ''' <summary>
    ''' 云团属性数组
    ''' </summary>
    ''' <remarks></remarks>
    Property BoxAirMass() As BoxAirMass()
        Get
            Return Me.m_BoxAirMass
        End Get
        Set(ByVal value As BoxAirMass())
            Me.m_BoxAirMass = value
        End Set
    End Property
    ''' <summary>
    ''' 高度Z处的风速，Z通常取10m处的风速
    ''' </summary>
    ''' <remarks></remarks>
    Property u10() As Double
        Get
            Return Me.m_u10
        End Get
        Set(ByVal value As Double)
            Me.m_u10 = value
        End Set
    End Property
    ''' <summary>
    ''' 稳定度
    ''' </summary>
    ''' <remarks></remarks>
    Property stab() As String
        Get
            Return Me.m_stab
        End Get
        Set(ByVal value As String)
            Me.m_stab = value
        End Set
    End Property


End Class
