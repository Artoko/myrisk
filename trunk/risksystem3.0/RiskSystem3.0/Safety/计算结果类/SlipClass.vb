<Serializable()> Public Class SlipClass
    ''' <summary>
    ''' 某一伤害浓度滑移平均最大浓度出现的距离
    ''' </summary>
    ''' <remarks></remarks>
    Private m_HurtLengthSlip(-1) As Double

    

    ''' <summary>
    ''' 某一伤害浓度滑移平均最大浓度出现的距离
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HurtLengthSlip() As Double()
        Get
            Return Me.m_HurtLengthSlip
        End Get
        Set(ByVal value As Double())
            Me.m_HurtLengthSlip = value
        End Set
    End Property

    

    ''' <summary>
    ''' 最大落地浓度出现的位置及浓度值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MaxConAndDistanceSlip As New MaxConAndDistance

    Private m_GridVane(-1) As Double '定义1维数组，用于储存不同气象条件下的下风向浓度：气象条件、预测时间、下风向距离

    ''' <summary>
    ''' 最大落地浓度出现的位置及浓度值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MaxConAndDistanceSlip() As MaxConAndDistance
        Get
            Return Me.m_MaxConAndDistanceSlip
        End Get
        Set(ByVal value As MaxConAndDistance)
            Me.m_MaxConAndDistanceSlip = value
        End Set
    End Property

    ''' <summary>
    ''' 定义1维数组，用于储存不同气象条件下的下风向浓度：气象条件、预测时间、下风向距离
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridVane() As Double()
        Get
            Return Me.m_GridVane
        End Get
        Set(ByVal value As Double())
            Me.m_GridVane = value
        End Set
    End Property

End Class