''' <summary>
''' 所有与关心点有关的计算结果的类。
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class AllCareResult
    ''' <summary>
    ''' 瞬时计算结果数组依次表示为：气象条件，预测时刻，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Private m_InstantaneousCareC(-1, -1, -1) As Double    '计算结果数组。
    ''' <summary>
    ''' 关心点的滑移平均最大浓度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SlipCare(-1, -1) As Slippage
    ''' <summary>
    ''' 用于储存关心点出现最大浓度及出现的时间该:气象条件、关心点
    ''' </summary>
    ''' <remarks></remarks>
    Private m_CarePointMaxCT(-1, -1) As MaxCD

    ''' <summary>
    ''' 定义2维数组，用于储存关心点出现某一浓度的浓度限值的开始和结束时间:气象条件，关心点，给定浓度值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_CarePointTime(-1, -1, -1) As StartAndEndTime


    ''' <summary>
    ''' 死亡概率：气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pr(-1, -1) As Double
    ''' <summary>
    ''' 死亡百分率 %：气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Private m_D(-1, -1) As Double

    ''' <summary>
    ''' 瞬时计算结果数组依次表示为：气象条件，预测时刻，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property InstantaneousCareC() As Double(,,)    '计算结果数组。
        Get
            Return m_InstantaneousCareC
        End Get
        Set(ByVal value As Double(,,))
            m_InstantaneousCareC = value
        End Set
    End Property
    ''' <summary>
    ''' 关心点的滑移平均最大浓度:气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property SlipCare() As Slippage(,)
        Get
            Return m_SlipCare
        End Get
        Set(ByVal value As Slippage(,))
            m_SlipCare = value
        End Set
    End Property



    ''' <summary>
    ''' 用于储存关心点出现最大浓度及出现的时间:气象条件、关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property CarePointMaxCT() As MaxCD(,)
        Get
            Return Me.m_CarePointMaxCT
        End Get
        Set(ByVal value As MaxCD(,))
            Me.m_CarePointMaxCT = value
        End Set
    End Property



    ''' <summary>
    ''' 定义1维数组，用于储存关心点出现某一浓度的浓度限值的开始和结束时间:气象条件，关心点，给定浓度值
    ''' </summary>
    ''' <remarks></remarks>
    Property CarePointTime() As StartAndEndTime(,,)
        Get
            Return Me.m_CarePointTime
        End Get
        Set(ByVal value As StartAndEndTime(,,))
            Me.m_CarePointTime = value
        End Set
    End Property



    ''' <summary>
    ''' 死亡概率：气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property Pr() As Double(,)
        Get
            Return Me.m_Pr
        End Get
        Set(ByVal value As Double(,))
            Me.m_Pr = value
        End Set
    End Property

    ''' <summary>
    ''' 死亡百分率 %：气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property D() As Double(,)
        Get
            Return Me.m_D
        End Get
        Set(ByVal value As Double(,))
            Me.m_D = value
        End Set
    End Property
End Class
