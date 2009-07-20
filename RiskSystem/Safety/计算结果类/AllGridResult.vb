''' <summary>
''' 所有与网格有关的计算结果的类。
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class AllGridResult
    ''' <summary>
    ''' 瞬时计算结果数组依次表示为：气象条件，时间，Y轴，X轴
    ''' </summary>
    ''' <remarks></remarks>
    Private m_InstantaneousGridC(-1, -1, -1, -1) As Double    '计算结果数组。
    ''' <summary>
    ''' 网格滑移平均最大浓度：气象条件，Y轴，X轴
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SlipGrid(-1, -1, -1) As Slippage
    ''' <summary>
    ''' 死亡概率：气象条件，Y轴，X轴
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pr(-1, -1, -1) As Double
    ''' <summary>
    ''' 死亡百分率 %：气象条件，Y轴，X轴
    ''' </summary>
    ''' <remarks></remarks>
    Private m_D(-1, -1, -1) As Double
    ''' <summary>
    ''' 个人风险值。所有气象条件下的个人风险值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PersonalRisk(-1, -1) As Double
    ''' <summary>
    ''' 不同气象条件下的事故风险值：气象条件
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrayRisk(-1) As Double
    ''' <summary>
    ''' 所有气象条件下的事故风险值的和
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AllRisk As Double
    ''' <summary>
    ''' 瞬时计算结果数组依次表示为：气象条件，预测时刻，Y行，X列
    ''' </summary>
    ''' <remarks></remarks>
    Property InstantaneousGridC() As Double(,,,)
        Get
            Return m_InstantaneousGridC
        End Get
        Set(ByVal value As Double(,,,))
            m_InstantaneousGridC = value
        End Set
    End Property
    ''' <summary>
    ''' 网格滑移平均最大浓度
    ''' </summary>
    ''' <remarks></remarks>
    Property SlipGrid() As Slippage(,,)
        Get
            Return m_SlipGrid
        End Get
        Set(ByVal value As Slippage(,,))
            m_SlipGrid = value
        End Set
    End Property

    ''' <summary>
    ''' 死亡概率：气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property Pr() As Double(,,)
        Get
            Return Me.m_Pr
        End Get
        Set(ByVal value As Double(,,))
            Me.m_Pr = value
        End Set
    End Property

    ''' <summary>
    ''' 死亡百分率 %：气象条件，关心点
    ''' </summary>
    ''' <remarks></remarks>
    Property D() As Double(,,)
        Get
            Return Me.m_D
        End Get
        Set(ByVal value As Double(,,))
            Me.m_D = value
        End Set
    End Property
    ''' <summary>
    ''' 个人风险值。所有气象条件下的个人风险值
    ''' </summary>
    ''' <remarks></remarks>
    Property PersonalRisk() As Double(,)
        Get
            Return m_PersonalRisk
        End Get
        Set(ByVal value As Double(,))
            m_PersonalRisk = value
        End Set
    End Property

    ''' <summary>
    ''' 不同气象条件下的事故风险值：气象条件
    ''' </summary>
    ''' <remarks></remarks>
    Property ArrayRisk() As Double()
        Get
            Return m_ArrayRisk
        End Get
        Set(ByVal value As Double())
            m_ArrayRisk = value
        End Set
    End Property
    ''' <summary>
    ''' 所有气象条件下的事故风险值的和
    ''' </summary>
    ''' <remarks></remarks>
    Property AllRisk() As Double
        Get
            Return m_AllRisk
        End Get
        Set(ByVal value As Double)
            m_AllRisk = value
        End Set
    End Property
End Class
