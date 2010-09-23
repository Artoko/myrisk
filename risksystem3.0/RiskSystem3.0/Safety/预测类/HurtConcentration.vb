''' <summary>
''' 伤害浓度
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class HurtConcentration
    Private m_Name As String '伤害名称
    Private m_ConcentrationVale As Double '伤害浓度,mg/m3
    ''' <summary>
    ''' 伤害名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name() As String
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 伤害浓度,mg/m3
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ConcentrationVale() As Double
        Get
            Return Me.m_ConcentrationVale
        End Get
        Set(ByVal value As Double)
            Me.m_ConcentrationVale = value
        End Set
    End Property
End Class
