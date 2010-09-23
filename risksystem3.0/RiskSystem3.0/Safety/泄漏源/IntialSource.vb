''' <summary>
''' 原始泄漏源类。用户输入的泄漏源。程序会根据用户输入的泄漏来转换成相应的点、面、体源模型。
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class IntialSource
    ''' <summary>
    ''' 泄漏事故预测类型
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakType As Integer = 0 '初始化为手动计算类型

    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakSourceName As String = "贮罐"
    ''' <summary>
    ''' 泄漏源类型。0点源，1面源，3体源
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceType As Integer = 0
    ''' <summary>
    ''' 坐标
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Coordinate As New Point3D

    ''' <summary>
    ''' 源排放速率，单位kg/s。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Q0 As Double = 3
    ''' <summary>
    ''' 排放温度，单位摄氏度。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Ts0 As Double = 25
    ''' <summary>
    ''' 排放持续时间，min。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DurationT0 As Double = 10
    ''' <summary>
    ''' 排气量，m3/s。对于泄漏源可不考虑。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Qv_P As Double = 0
    ''' <summary>
    ''' 排放口直径，m。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_D_P As Double = 0.5
    
    ''' <summary>
    ''' 面源面积，m2。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_S_S As Double = 100
    ''' <summary>
    ''' 体源的高度（厚度）,m。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double = 3


    '泄漏源参数
    ''' <summary>
    ''' 贮存量,kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Q As Double = 5000
    ''' <summary>
    ''' 容器内温度,摄氏度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_InT As Double = 25
    ''' <summary>
    ''' 容器内压力，Pa
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakGasP As Double = 1170000
    ''' <summary>
    '''裂口面积，m2
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakGasA As Double = 0.0000785
    ''' <summary>
    ''' 裂口高度，m
    ''' </summary>
    ''' <remarks></remarks>
    Private m_H As Double = 3
    ''' <summary>
    ''' 裂口形状
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakGasShape As Integer = 0
    ''' <summary>
    ''' 喷射角度，0-90
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Angle As Double = 0
    ''' <summary>
    ''' 裂口之上液位高度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakLiquidHeight As Double = 5
    ''' <summary>
    ''' 持续时间，min
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DurationT As Double = 10
    ''' <summary>
    ''' 液体泄漏系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakLiquidCd As Double = 0.62
    ''' <summary>
    ''' 两相流泄漏系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakTwoCd As Double = 0.8


    ''' <summary>
    ''' 地面情况
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakEvaporationGround As Integer = 0
    ''' <summary>
    ''' 围堰面积[m^2]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_S As Double = 50
    ''' <summary>
    ''' 蒸发时间[min]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_VolatilizationT As Double = 30
    ''' <summary>
    ''' 环境温度下液体表面蒸气压P[Pa]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakEvaporationP As Double = 60662
    ''' <summary>
    ''' 液池面源有效高度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SHe As Double = 1.0
    ''' <summary>
    ''' 是否自动计算容器压力的标志
    ''' </summary>
    ''' <remarks></remarks>
    Private m_chkLeakGasP As Integer = 0
    ''' <summary>
    ''' 是否自动计算液面蒸汽压力的标志
    ''' </summary>
    ''' <remarks></remarks>
    Private m_chkVap As Integer = 0

    ''' <summary>
    ''' 表示是否按重气体模型考虑
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IsHeavy As Boolean = False
    ''' <summary>
    ''' 初始空气混入的比例
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AirProportion As Double = 0.5
    ''' <summary>
    ''' 事故发生的概率
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Probability As Double = 0.00001
    ''' <summary>
    ''' 泄漏事故预测类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakType() As Integer
        Get
            Return Me.m_LeakType
        End Get
        Set(ByVal value As Integer)
            Me.m_LeakType = value
        End Set
    End Property
    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakSourceName() As String
        Get
            Return Me.m_LeakSourceName
        End Get
        Set(ByVal value As String)
            Me.m_LeakSourceName = value
        End Set
    End Property

    ''' <summary>
    ''' 污染源的坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Coordinate() As Point3D
        Get
            Return Me.m_Coordinate
        End Get
        Set(ByVal value As Point3D)
            Me.m_Coordinate = value
        End Set
    End Property
    ''' <summary>
    ''' 泄漏源类型。0点源，1面源，3体源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceType() As Integer
        Get
            Return Me.m_SourceType
        End Get
        Set(ByVal value As Integer)
            Me.m_SourceType = value
        End Set
    End Property
    ''' <summary>
    ''' 源排放速率，单位kg/s。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Q0() As Double
        Get
            Return Me.m_Q0
        End Get
        Set(ByVal value As Double)
            Me.m_Q0 = value
        End Set
    End Property
    ''' <summary>
    ''' 排放温度，单位摄氏度。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Ts0() As Double
        Get
            Return Me.m_Ts0
        End Get
        Set(ByVal value As Double)
            Me.m_Ts0 = value
        End Set
    End Property
    ''' <summary>
    ''' 排放持续时间，min。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DurationT0() As Double
        Get
            Return Me.m_DurationT0
        End Get
        Set(ByVal value As Double)
            Me.m_DurationT0 = value
        End Set
    End Property
    ''' <summary>
    ''' 排气量，m3/s。对于泄漏源可不考虑。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Qv_P() As Double
        Get
            Return Me.m_Qv_P
        End Get
        Set(ByVal value As Double)
            Me.m_Qv_P = value
        End Set
    End Property
    
    ''' <summary>
    ''' 排放口直径，m。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property D_P() As Double
        Get
            Return Me.m_D_P
        End Get
        Set(ByVal value As Double)
            Me.m_D_P = value
        End Set
    End Property
    
    ''' <summary>
    ''' 面源面积，m2。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property S_S() As Double
        Get
            Return Me.m_S_S
        End Get
        Set(ByVal value As Double)
            Me.m_S_S = value
        End Set
    End Property
    
    ''' <summary>
    ''' 体源的高度（厚度）,m。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Thickness() As Double
        Get
            Return Me.m_Thickness
        End Get
        Set(ByVal value As Double)
            Me.m_Thickness = value
        End Set
    End Property



    ''' <summary>
    ''' 贮存量,kg
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Q() As Double
        Get
            Return Me.m_Q
        End Get
        Set(ByVal value As Double)
            Me.m_Q = value
        End Set
    End Property
    ''' <summary>
    ''' 容器内温度,摄氏度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InT() As Double
        Get
            Return Me.m_InT
        End Get
        Set(ByVal value As Double)
            Me.m_InT = value
        End Set
    End Property
    ''' <summary>
    ''' 容器内压力，Pa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakGasP() As Double
        Get
            Return Me.m_LeakGasP
        End Get
        Set(ByVal value As Double)
            Me.m_LeakGasP = value
        End Set
    End Property
    ''' <summary>
    ''' 裂口面积，m2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakGasA() As Double
        Get
            Return Me.m_LeakGasA
        End Get
        Set(ByVal value As Double)
            Me.m_LeakGasA = value
        End Set
    End Property

    ''' <summary>
    ''' 裂口高度，m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property H() As Double
        Get
            Return Me.m_H
        End Get
        Set(ByVal value As Double)
            Me.m_H = value
        End Set
    End Property
    ''' <summary>
    ''' 裂口形状
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakGasShape() As Integer
        Get
            Return Me.m_LeakGasShape
        End Get
        Set(ByVal value As Integer)
            Me.m_LeakGasShape = value
        End Set
    End Property
    ''' <summary>
    ''' 喷射角度，0-90
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Angle() As Double
        Get
            Return Me.m_Angle
        End Get
        Set(ByVal value As Double)
            Me.m_Angle = value
        End Set
    End Property
    ''' <summary>
    ''' 裂口之上液位高度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakLiquidHeight() As Double
        Get
            Return Me.m_LeakLiquidHeight
        End Get
        Set(ByVal value As Double)
            Me.m_LeakLiquidHeight = value
        End Set
    End Property
    ''' <summary>
    ''' 持续时间，min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DurationT() As Double
        Get
            Return Me.m_DurationT
        End Get
        Set(ByVal value As Double)
            Me.m_DurationT = value
        End Set
    End Property
    ''' <summary>
    '''  液体泄漏系数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakLiquidCd() As Double
        Get
            Return Me.m_LeakLiquidCd
        End Get
        Set(ByVal value As Double)
            Me.m_LeakLiquidCd = value
        End Set
    End Property
    ''' <summary>
    ''' 两相流泄漏系数
    ''' </summary>
    ''' <remarks></remarks>
    Property LeakTwoCd() As Double
        Get
            Return Me.m_LeakTwoCd
        End Get
        Set(ByVal value As Double)
            Me.m_LeakTwoCd = value
        End Set
    End Property


    ''' <summary>
    ''' 地面情况
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakEvaporationGround() As Integer
        Get
            Return Me.m_LeakEvaporationGround
        End Get
        Set(ByVal value As Integer)
            Me.m_LeakEvaporationGround = value
        End Set
    End Property
    ''' <summary>
    ''' 围堰面积[m^2]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property S() As Double
        Get
            Return Me.m_S
        End Get
        Set(ByVal value As Double)
            Me.m_S = value
        End Set
    End Property

    ''' <summary>
    ''' 是否自动计算容器压力的标志
    ''' </summary>
    ''' <remarks></remarks>
    Property chkLeakGasP() As Integer
        Get
            Return m_chkLeakGasP
        End Get
        Set(ByVal value As Integer)
            m_chkLeakGasP = value
        End Set
    End Property
    ''' <summary>
    ''' 是否自动计算液面蒸汽压力的标志
    ''' </summary>
    ''' <remarks></remarks>
    Property chkVap() As Integer
        Get
            Return m_chkVap
        End Get
        Set(ByVal value As Integer)
            m_chkVap = value
        End Set
    End Property
    ''' <summary>
    ''' 蒸发时间[min]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VolatilizationT() As Double
        Get
            Return Me.m_VolatilizationT
        End Get
        Set(ByVal value As Double)
            Me.m_VolatilizationT = value
        End Set
    End Property

    ''' <summary>
    ''' 环境温度下液体表面蒸气压P[Pa]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakEvaporationP() As Double
        Get
            Return Me.m_LeakEvaporationP
        End Get
        Set(ByVal value As Double)
            Me.m_LeakEvaporationP = value
        End Set
    End Property
    ''' <summary>
    ''' 液池面源有效高度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SHe() As Double
        Get
            Return Me.m_SHe
        End Get
        Set(ByVal value As Double)
            Me.m_SHe = value
        End Set
    End Property

    ''' <summary>
    ''' 表示是否按重气体模型考虑
    ''' </summary>
    ''' <remarks></remarks>
    Property IsHeavy() As Boolean
        Get
            Return Me.m_IsHeavy
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsHeavy = value
        End Set
    End Property

    ''' <summary>
    ''' 初始空气混入的比例
    ''' </summary>
    ''' <remarks></remarks>
    Property AirProportion() As Double
        Get
            Return m_AirProportion
        End Get
        Set(ByVal value As Double)
            m_AirProportion = value
        End Set
    End Property
    ''' <summary>
    ''' 事故发生的概率
    ''' </summary>
    ''' <remarks></remarks>
    Property Probability() As Double
        Get
            Return m_Probability
        End Get
        Set(ByVal value As Double)
            m_Probability = value
        End Set
    End Property
    ''' <summary>
    ''' 根据物化数据和用户设置的选项初始化参数
    ''' </summary>
    ''' <param name="chem">化学物质性质对象</param>
    ''' <param name="OutT">环境温度，摄氏度</param>
    ''' <param name="OutP">环境压力，Pa</param>
    '''  <returns></returns>
    ''' <remarks></remarks>
    Public Function IntialPara(ByVal chem As Chemical, ByVal OutT As Double, ByVal OutP As Double) As Boolean
        Select Case m_LeakType
            Case 3, 8 '压力液化气
                If m_chkLeakGasP Then
                    m_LeakGasP = chem.GetP(m_InT + FreezingPoint)
                    m_LeakEvaporationP = OutP
                End If
                If m_LeakGasP = 0 Then
                    'MsgBox("无法自动计算容器内的压力，请检查物化数据中是否已经设置了该物质的安托因参数!", MsgBoxStyle.OkOnly, "自动计算压力错误")
                    Return False
                Else
                    Return True
                End If
            Case 4 '压力液化气
                If m_chkLeakGasP Then
                    m_LeakGasP = chem.GetP(m_InT + FreezingPoint)
                End If
                If m_LeakGasP = 0 Then
                    'MsgBox("无法自动计算容器内的压力，请检查物化数据中是否已经设置了该物质的安托因参数!", MsgBoxStyle.OkOnly, "自动计算压力错误")
                    Return False
                Else
                    Return True
                End If
            Case 6, 7 '常压液化
                If m_chkVap Then
                    m_LeakEvaporationP = chem.GetP(OutT + FreezingPoint)
                End If
                If m_LeakEvaporationP = 0 Then
                    'MsgBox("无法自动计液体表面蒸气压，请检查物化数据中是否已经设置了该物质的安托因参数!", MsgBoxStyle.OkOnly, "自动计算压力错误")
                    Return False
                Else
                    Return True
                End If
            Case 5, 9, 10 '
                m_LeakEvaporationP = OutP
                If m_LeakEvaporationP = 0 Then
                    Return False
                Else
                    Return True
                End If
        End Select
        Return True
    End Function
End Class
