<Serializable()> Public Class OutPut
    Private m_GroundCharacter As String = "平原地区农村及城市远郊区"  '地面特征。
    Private m_ForeStart As Double = 2 '预测开始时间。min
    Private m_ForeInterval As Double = 2 '预测时间间隔。min
    Private m_ForeCount As Integer = 10 '预测时间个数。
    Private m_Model As Integer = 0 '预测模型
    Private m_IntervalTime As Integer = 10 '烟团间隔时间,s
    Private m_SamplingTime As Double = 1 '取样时间，min
    ''' <summary>
    ''' 高斯模型的类型：0为多烟团模型，1为非正常模型
    ''' </summary>
    ''' <remarks></remarks>
    Private m_GaussModelType As Integer = 0
    ''' <summary>
    ''' 滑移平均时间段，单位min
    ''' </summary>
    ''' <remarks></remarks>
    Private m_InhalationTime As Double = 30
    ''' <summary>
    ''' 确定是否计算滑移平均
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IsInstantaneous As Boolean = True '是否计算瞬时浓度
    Private m_ChargeOrSlip As Integer = 0 '是计算物质的毒性负荷还是计算滑移平均,再计算风险值
    Private m_IsRisk As Boolean = True '是否计算风险值

    ''' <summary>
    ''' 地面特征。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GroundCharacter() As String '
        Get
            Return Me.m_GroundCharacter
        End Get
        Set(ByVal value As String)
            Me.m_GroundCharacter = value
        End Set
    End Property
    ''' <summary>
    ''' 预测开始时间。min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ForeStart() As Double
        Get
            Return Me.m_ForeStart
        End Get
        Set(ByVal value As Double)
            Me.m_ForeStart = value
        End Set
    End Property
    ''' <summary>
    ''' 预测时间间隔。min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ForeInterval() As Double
        Get
            Return Me.m_ForeInterval
        End Get
        Set(ByVal value As Double)
            Me.m_ForeInterval = value
        End Set
    End Property
    ''' <summary>
    ''' 预测时间个数。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ForeCount() As Integer
        Get
            Return Me.m_ForeCount
        End Get
        Set(ByVal value As Integer)
            Me.m_ForeCount = value
        End Set
    End Property

    ''' <summary>
    ''' 预测模型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Model() As Integer
        Get
            Return Me.m_Model
        End Get
        Set(ByVal value As Integer)
            Me.m_Model = value
        End Set
    End Property
    ''' <summary>
    ''' 烟团间隔时间,s
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IntervalTime() As Integer
        Get
            Return Me.m_IntervalTime
        End Get
        Set(ByVal value As Integer)
            Me.m_IntervalTime = value
        End Set
    End Property

    ''' <summary>
    ''' 取样时间，min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SamplingTime() As Double
        Get
            Return Me.m_SamplingTime
        End Get
        Set(ByVal value As Double)
            Me.m_SamplingTime = value
        End Set
    End Property


    ''' <summary>
    ''' 高斯模型的类型：0为多烟团模型，1为非正常模型
    ''' </summary>
    ''' <remarks></remarks>
    Property GaussModelType() As Integer
        Get
            Return Me.m_GaussModelType
        End Get
        Set(ByVal value As Integer)
            Me.m_GaussModelType = value
        End Set
    End Property
    ''' <summary>
    ''' 有毒物吸收时间段，单位min
    ''' </summary>
    ''' <remarks></remarks>
    Property InhalationTime() As Double
        Get
            Return Me.m_InhalationTime
        End Get
        Set(ByVal value As Double)
            Me.m_InhalationTime = value
        End Set
    End Property
    ''' <summary>
    ''' 是否计算瞬时浓度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsInstantaneous() As Boolean
        Get
            Return m_IsInstantaneous
        End Get
        Set(ByVal value As Boolean)
            m_IsInstantaneous = value
        End Set
    End Property
    ''' <summary>
    ''' 是计算物质的毒性负荷还是计算滑移平均,再计算风险值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ChargeOrSlip() As Integer
        Get
            Return m_ChargeOrSlip
        End Get
        Set(ByVal value As Integer)
            m_ChargeOrSlip = value
        End Set
    End Property
    ''' <summary>
    ''' 是否计算风险值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsRisk() As Boolean
        Get
            Return Me.m_IsRisk
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsRisk = value
        End Set
    End Property
End Class
