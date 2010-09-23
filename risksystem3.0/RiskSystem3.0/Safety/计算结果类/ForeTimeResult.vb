''' <summary>
''' 用于储存某一计算时刻的计算结果
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class ForeTimeResult
    ''' <summary>
    ''' 最大落地浓度出现的位置及浓度值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MaxConAndDistance As New MaxConAndDistance
    ''' <summary>
    ''' 某一伤害浓度出现的距离
    ''' </summary>
    ''' <remarks></remarks>
    Private m_HurtLength(-1) As Double



    Private m_GridVane(-1) As Double '定义1维数组，用于储存不同气象条件下的下风向浓度：气象条件、预测时间、下风向距离


    Private m_GridUpVane(-1) As Double '定义1维数组，用于储存不同气象条件下的下风向浓度：气象条件、预测时间、下风向距离

    ''' <summary>
    ''' 最大落地浓度出现的位置及浓度值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MaxConAndDistance() As MaxConAndDistance
        Get
            Return Me.m_MaxConAndDistance
        End Get
        Set(ByVal value As MaxConAndDistance)
            Me.m_MaxConAndDistance = value
        End Set
    End Property
    ''' <summary>
    ''' 某一伤害浓度出现的距离
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HurtLength() As Double()
        Get
            Return Me.m_HurtLength
        End Get
        Set(ByVal value As Double())
            Me.m_HurtLength = value
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

    ''' <summary>
    ''' 定义1维数组，用于储存不同气象条件下的上风向浓度：气象条件、预测时间、下风向距离
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridUpVane() As Double()
        Get
            Return Me.m_GridUpVane
        End Get
        Set(ByVal value As Double())
            Me.m_GridUpVane = value
        End Set
    End Property

End Class
