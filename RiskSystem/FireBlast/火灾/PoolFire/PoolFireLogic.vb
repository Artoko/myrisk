Public Class PoolFireLogic
    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = "储罐" '
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name As String = "甲苯" '
    ''' <summary>
    ''' 事故源坐标
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourcePoint As New Point2D '
    ''' <summary>
    ''' 物质总质量W[ kg ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_W As Double = 100000  '
    ''' <summary>
    ''' 环境温度Ta[ ℃ ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Ta As Double = 25 '
    ''' <summary>
    ''' 液池直径D[  m ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_D As Double = 20 '
    ''' <summary>
    ''' 暴露时间t[ s ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_T As Double = 40 '
    ''' <summary>
    ''' 液体的燃烧热Hc[J/kg]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Hc As Double = 41792344 '
    ''' <summary>
    ''' 常压沸点下的蒸发热Hv[J/kg]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Hv As Double = 394487 '
    ''' <summary>
    ''' 液体比定压热容Cp[J/(kg·K)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cp As Double = 1700 '
    ''' <summary>
    ''' 液体常压下的沸点Tb[ ℃ ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Tb As Double = 80.1 '
    ''' <summary>
    ''' 热辐射系数f
    ''' </summary>
    ''' <remarks></remarks>
    Private m_F As Double = 0.35 '
    ''' <summary>
    ''' 步长
    ''' </summary>
    ''' <remarks></remarks>
    Private m_StepLong As Double = 10  '
    ''' <summary>
    ''' 步长的个数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_StepCount As Integer = 20 '
   
    ''' <summary>
    ''' 热辐射类的数组
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrHeatEradiate(0 To 3) As FireBlast.HeatEradiate '
    ''' <summary>
    ''' 储存计算结果的文字描述
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strResult As String '
    ''' <summary>
    ''' 储存步长对应的热辐射
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ResultStepDp(-1) As Double
    
    ''' <summary>
    ''' 不热辐射压对应的距离
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ResultR(-1) As Double

#Region "中间变量"
    ''' <summary>
    ''' 池火燃烧速率 kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mf As Double
    ''' <summary>
    ''' 池火持续时间 s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DurationT As Double
    ''' <summary>
    ''' 池火高度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_L As Double
    ''' <summary>
    ''' 火焰表面热辐热能量
    ''' </summary>
    ''' <remarks></remarks>
    Private m_E As Double
#End Region

#Region "属性"
    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceName() As String '
        Get
            Return Me.m_SourceName
        End Get
        Set(ByVal value As String)
            Me.m_SourceName = value
        End Set
    End Property
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name() As String '
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 事故源坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourcePoint() As Point2D '
        Get
            Return Me.m_SourcePoint
        End Get
        Set(ByVal value As Point2D)
            Me.m_SourcePoint = value
        End Set
    End Property
    ''' <summary>
    ''' 物质总质量W[ kg ]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property W() As Double
        Get
            Return Me.m_W
        End Get
        Set(ByVal value As Double)
            Me.m_W = value
        End Set
    End Property
    ''' <summary>
    ''' 环境温度Ta[ ℃ ]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Ta() As Double
        Get
            Return Me.m_Ta
        End Get
        Set(ByVal value As Double)
            Me.m_Ta = value
        End Set
    End Property
    ''' <summary>
    ''' 液池直径D[  m ]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property D() As Double
        Get
            Return Me.m_D
        End Get
        Set(ByVal value As Double)
            Me.m_D = value
        End Set
    End Property
    ''' <summary>
    ''' 暴露时间t[ s ]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property T() As Double
        Get
            Return Me.m_T
        End Get
        Set(ByVal value As Double)
            Me.m_T = value
        End Set
    End Property
    ''' <summary>
    ''' 液体的燃烧热Hc[J/kg]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Hc() As Double
        Get
            Return Me.m_Hc
        End Get
        Set(ByVal value As Double)
            Me.m_Hc = value
        End Set
    End Property
    ''' <summary>
    ''' 常压沸点下的蒸发热Hv[J/kg]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Hv() As Double
        Get
            Return Me.m_Hv
        End Get
        Set(ByVal value As Double)
            Me.m_Hv = value
        End Set
    End Property
    ''' <summary>
    ''' 液体比定压热容Cp[J/(kg·K)]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Cp() As Double
        Get
            Return Me.m_Cp
        End Get
        Set(ByVal value As Double)
            Me.m_Cp = value
        End Set
    End Property
    ''' <summary>
    ''' 液体常压下的沸点Tb[ ℃ ]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Tb() As Double
        Get
            Return Me.m_Tb
        End Get
        Set(ByVal value As Double)
            Me.m_Tb = value
        End Set
    End Property
    ''' <summary>
    ''' 热辐射系数f
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property F() As Double
        Get
            Return Me.m_F
        End Get
        Set(ByVal value As Double)
            Me.m_F = value
        End Set
    End Property
    ''' <summary>
    ''' 步长
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepLong() As Double
        Get
            Return Me.m_StepLong
        End Get
        Set(ByVal value As Double)
            Me.m_StepLong = value
        End Set
    End Property
    ''' <summary>
    ''' 步长的个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepCount() As Integer
        Get
            Return Me.m_StepCount
        End Get
        Set(ByVal value As Integer)
            Me.m_StepCount = value
        End Set
    End Property
    
    ''' <summary>
    ''' 热辐射类的数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ArrHeatEradiate() As FireBlast.HeatEradiate()
        Get
            Return Me.m_ArrHeatEradiate
        End Get
        Set(ByVal value As FireBlast.HeatEradiate())
            Me.m_ArrHeatEradiate = value
        End Set
    End Property
    ''' <summary>
    ''' 储存步长对应的超压
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultDP() As Double()
        Get
            Return Me.m_ResultStepDp
        End Get
        Set(ByVal value As Double())
            Me.m_ResultStepDp = value
        End Set
    End Property
    ''' <summary>
    ''' 不同超压对应的距离
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultR() As Double()
        Get
            Return Me.m_ResultR
        End Get
        Set(ByVal value As Double())
            Me.m_ResultR = value
        End Set
    End Property
#End Region

    
    Public Sub New()
        For i As Integer = 0 To Me.ArrHeatEradiate.Length - 1
            Me.ArrHeatEradiate(i) = New FireBlast.HeatEradiate
        Next
        Me.ArrHeatEradiate(0).HeatName = "死亡"
        Me.ArrHeatEradiate(0).Heat = Me.FormulaDieQ()
        Me.ArrHeatEradiate(0).Checkd = True

        Me.ArrHeatEradiate(1).HeatName = "二度烧伤"
        Me.ArrHeatEradiate(1).Heat = Me.FormulaBurnTwo()
        Me.ArrHeatEradiate(1).Checkd = True

        Me.ArrHeatEradiate(2).HeatName = "一度烧伤"
        Me.ArrHeatEradiate(2).Heat = Me.FormulaBurnOne()
        Me.ArrHeatEradiate(2).Checkd = True

        Me.ArrHeatEradiate(3).HeatName = "财产损失"
        Me.ArrHeatEradiate(3).Heat = Me.FormulaWealthDamnify()
        Me.ArrHeatEradiate(3).Checkd = True
    End Sub
    ''' <summary>
    ''' 计算死亡距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaDieQ() As Double
        Dim DieQ As Double
        DieQ = (1 / Me.T * System.Math.Exp((5 + 37.23) / 2.56)) ^ 0.75
        Return DieQ
    End Function
    ''' <summary>
    ''' '计算一度烧伤距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaBurnOne() As Double
        Dim burnOne As Double

        burnOne = (1 / Me.T * System.Math.Exp((5 + 39.83) / 3.0188)) ^ 0.75
        Return burnOne
    End Function
    ''' <summary>
    ''' 计算二度烧伤距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaBurnTwo() As Double

        Dim burnTwo As Double
        burnTwo = (1 / Me.T * System.Math.Exp((5 + 43.14) / 3.0188)) ^ 0.75
        Return burnTwo
    End Function
    ''' <summary>
    ''' '计算财产损失距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaWealthDamnify() As Double

        Dim wealth As Double
        wealth = 6730 * Me.T ^ (-0.8) + 25400
        Return wealth
    End Function
    ''' <summary>
    ''' '计算单位面积燃烧速率
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaMf() As Double

        Dim mf As Double

        If Me.m_Tb >= Me.m_Ta Then
            '如果液体的沸点高于环境温度
            mf = 0.001 * Me.m_Hc / (Me.m_Cp * (Me.m_Tb - Me.m_Ta) + Me.m_Hv)
        Else
            mf = 0.001 * Me.m_Hc / Me.m_Hv
        End If
        Return mf
    End Function
    ''' <summary>
    ''' '燃烧持续时间
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaTime() As Double

        Dim R As Double = Me.m_D / 2
        Dim mf As Double = Me.FormulaMf()
        Dim T As Double = Me.m_W / (R * R * Math.PI * mf)
        Return T
    End Function
    ''' <summary>
    ''' '计算火焰高度
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaHight() As Double

        Dim pa As Double '空气的密度
        pa = 1.29
        Dim L As Double
        Dim mf As Double = Me.FormulaMf()
        L = 42 * Me.m_D * (mf / (pa * System.Math.Sqrt(9.8 * Me.m_D))) ^ 0.61
        Return L
    End Function
    ''' <summary>
    '''  计算火焰表面热辐射能量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaE() As Double
        Dim E As Double
        Dim mf As Double = Me.FormulaMf()
        Dim L As Double = Me.FormulaHight()
        E = 0.25 * Math.PI * Me.m_D * Me.m_D * Me.m_F * mf * Me.m_Hc / (0.25 * Math.PI * Me.m_D * Me.m_D + Math.PI * Me.m_D * L)
        Return E
    End Function
    ''' <summary>
    ''' 通过距离求得热辐热通
    ''' </summary>
    ''' <param name="paraE">池火表面热辐热通量</param>
    ''' <param name="paraV">视解系数</param>
    ''' <param name="paraX">距离</param>
    ''' <returns>目标点的热辐热通量</returns>
    ''' <remarks></remarks>
    Private Function FormulaQ(ByVal paraE As Double, ByVal paraV As Double, ByVal paraX As Double) As Double
        FormulaQ = paraE * paraV * (1 - 0.058 * System.Math.Log(paraX))
    End Function
    ''' <summary>
    ''' 视角系数的计算  V
    ''' </summary>
    ''' <param name="paraL">火焰高度</param>
    ''' <param name="paraD">液池直径</param>
    ''' <param name="paraX">目标处距离</param>
    ''' <returns>视角系数</returns>
    ''' <remarks></remarks> 
    Private Function FormulaV(ByVal paraL As Double, ByVal paraD As Double, ByVal paraX As Double) As Object
        Dim S As Double
        Dim H As Double
        Dim a As Double
        Dim b As Double
        Dim K As Double
        Dim j As Double
        Dim Vv As Double
        Dim VH As Double
        Dim bigA As Double
        Dim bigB As Double
        Dim v As Double
        S = 2 * paraX / paraD
        H = paraL / paraD

        a = (H ^ 2 + S ^ 2 + 1) / (2 * S)
        b = (1 + S ^ 2) / (2 * S)
        K = System.Math.Atan(((S - 1) / (S + 1)) ^ 0.5)
        j = (a / (a ^ 2 - 1) ^ 0.5) * System.Math.Atan(((a + 1) * (S - 1) / ((a - 1) * (S + 1))) ^ 0.5)
        bigA = (b - 1 / S) * System.Math.Atan(((b + 1) * (S - 1) / ((b - 1) * (S + 1))) ^ 0.5) / (b ^ 2 - 1) ^ 0.5
        bigB = (a - 1 / S) * System.Math.Atan(((a + 1) * (S - 1) / ((a - 1) * (S + 1))) ^ 0.5) / (a ^ 2 - 1) ^ 0.5
        VH = (bigA - bigB) / Math.PI
        Vv = (System.Math.Atan(H / (S ^ 2 - 1) ^ 0.5) + H * (j - K)) / S / Math.PI
        v = System.Math.Sqrt(Vv ^ 2 + VH ^ 2)
        Return v
    End Function

    ''' <summary>
    ''' 根据给定的热辐射能量求得距离
    ''' </summary>
    ''' <param name="paraE"></param>
    ''' <param name="paraL"></param>
    ''' <param name="paraD"></param>
    ''' <param name="qAny"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Radius(ByVal paraE As Double, ByVal paraL As Double, ByVal paraD As Double, ByVal qAny As Double) As Double
        '通过内插法计算不同的伤害半径
        Dim dblQ As Double
        Dim dblV As Double
        Dim RINT As Double
        Dim RINT1 As Double
        Dim RINT2 As Double
        RINT1 = paraD / 2 + 0.1 '最小为半径+0.1米，为了避免溢出
        RINT2 = 10000 '最大为10000米
        RINT = 10000
        dblV = FormulaV(paraL, paraD, RINT1)
        dblQ = FormulaQ(paraE, dblV, RINT1)
        If dblQ < qAny Then '如果池火半径上的热辐射通量小于对应的伤害半径的热辐射通量，则不存在对应的热辐射半径
            Radius = 0
        Else
            dblV = FormulaV(paraL, paraD, RINT)
            dblQ = FormulaQ(paraE, dblV, RINT)

            While System.Math.Abs(dblQ - qAny) > 1

                If dblQ - qAny < 0 Then
                    RINT2 = RINT
                Else
                    RINT1 = RINT
                End If
                RINT = (RINT1 + RINT2) / 2
                dblV = FormulaV(paraL, paraD, RINT)
                dblQ = FormulaQ(paraE, dblV, RINT)
            End While
            Radius = RINT
        End If
    End Function
    ''' <summary>
    ''' 计算
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        '池火计算燃烧速率
        m_mf = FormulaMf()
        '计算燃烧时间
        m_DurationT = FormulaTime()
        '计算池火高度
        m_L = FormulaHight()
        '计算火焰表面热辐射能量E       
        m_E = FormulaE()


        '计算死亡半径、二度烧伤、一度烧伤和财产损失热通量和半径
        Dim dblQDie As Double
        Dim dblQDamage2 As Double
        Dim dblQDamage1 As Double
        Dim dblQWealth As Double
        Dim dblRDie As Double
        Dim dblRDamage2 As Double
        Dim dblRDamage1 As Double
        Dim dblRWealth As Double


        ReDim Me.m_ResultR(Me.m_ArrHeatEradiate.Length - 1)
        '计算相应的半径
        If Me.m_ArrHeatEradiate(0).Checkd = True Then
            dblQDie = FormulaDieQ() '求得死亡的热辐热通量
            dblRDie = Radius(m_E, m_L, Me.m_D, dblQDie)
            If dblRDie = 0 Then
            Else
                '将要画的结果压入数组
                Me.m_ArrHeatEradiate(0).Heat = dblQDie '热辐射通量
                Me.m_ResultR(0) = dblRDie '死亡半径
            End If
        End If
        If Me.m_ArrHeatEradiate(1).Checkd = True Then '二度烧伤半径
            dblQDamage2 = FormulaBurnTwo() '求得二度烧伤的热辐射通量
            dblRDamage2 = Radius(m_E, m_L, Me.m_D, dblQDamage2)
            If dblRDamage2 = 0 Then
            Else
                Me.m_ArrHeatEradiate(1).Heat = dblQDamage2 '热辐射通量
                Me.m_ResultR(1) = dblRDamage2 '二度烧伤半径

            End If
        End If
        If Me.m_ArrHeatEradiate(2).Checkd = True Then
            dblQDamage1 = FormulaBurnOne()
            dblRDamage1 = Radius(m_E, m_L, Me.m_D, dblQDamage1)
            If dblRDamage1 = 0 Then
            Else
                Me.m_ArrHeatEradiate(2).Heat = dblQDamage1 '热辐射通量
                Me.m_ResultR(2) = dblRDamage1 '一度烧伤半径
            End If
        End If
        If Me.m_ArrHeatEradiate(3).Checkd = True Then
            dblQWealth = FormulaWealthDamnify()
            dblRWealth = Radius(m_E, m_L, Me.m_D, dblQWealth)
            If dblRWealth = 0 Then
            Else
                '将半径压入数组
                Me.m_ArrHeatEradiate(3).Heat = dblQWealth '热辐射通量
                Me.m_ResultR(3) = dblRWealth '财产损失半径
            End If
        End If

        '通过热辐射通量计算距离
        Dim dblR1 As Double
        Dim strR1 As String
        strR1 = ""

        If Me.m_ArrHeatEradiate.Length > 4 Then
            For i As Integer = 4 To Me.m_ArrHeatEradiate.Length - 1
                dblR1 = Radius(m_E, m_L, Me.m_D, Me.m_ArrHeatEradiate(i).Heat)
                If Me.m_ArrHeatEradiate(i).Checkd = True Then
                    If dblR1 = 0 Then
                    Else
                        Me.m_ResultR(i) = dblR1
                    End If
                End If
            Next
        End If


        Dim dblV1 As Double '视角系数
        '根据步长求热辐射
        ReDim Me.m_ResultStepDp(Me.m_StepCount - 1)
        Dim c As Integer '步长
        For i As Integer = 0 To Me.m_StepCount - 1
            c = (Me.m_StepLong + i * Me.m_StepLong)
            If c <= Me.m_D / 2 Then '距离小于液池半径
            Else
                dblV1 = FormulaV(m_L, Me.m_D, c)
                m_ResultStepDp(i) = FormulaQ(m_E, dblV1, c)
            End If
        Next

        '计算预测点
        Dim dblQ As Double '目标处的热辐射通量
        Dim strQ As String

        strQ = ""

        If m_carepoint.Length > 0 Then '如果有关心点
            For i As Integer = 0 To m_carepoint.Length - 1
                Dim R As Double = GetR(m_carepoint(i).Rpoint, Me.m_SourcePoint) '先求出距离
                If R <= Me.m_D / 2 Then '距离小于液池半径
                Else
                    dblV1 = FormulaV(m_L, Me.m_D, R)
                    dblQ = FormulaQ(m_E, dblV1, R)
                    m_carepoint(i).ResultDistanceDp = dblQ '热辐射
                    m_carepoint(i).Pr = DiePr.DiePr(m_T, dblQ) '计算死亡概率 
                    m_carepoint(i).D = DiePr.NormalSchool(m_carepoint(i).Pr) * 100 '死亡百分率
                End If
            Next
        End If


    End Sub
    ''' <summary>
    ''' 返回计算结果的文字描述
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint()) As String
        Dim strResults As String '计算结果
        strResults = "池火单位面积燃烧速率为" & m_mf & "kg/(m^2·s)" & vbCrLf
        strResults += "池火持续时间为：" & FormatNumber(m_DurationT, 0) & " s" & vbCrLf
        strResults += "池火的火焰高度为：" & FormatNumber(m_L, 1) & "m" & vbCrLf
        strResults += "池火焰表面热辐射通量为：" & FormatNumber(m_E, 0) & "W/m^2" & vbCrLf


        ' 在框中把距离给显示出来
        strResults += vbCrLf
        strResults += "事故损害后果                    损害半径(m)           对应的热辐射通量(W/m^2)" & vbCrLf


        For i As Integer = 0 To Me.m_ArrHeatEradiate.Length - 1
            If m_ArrHeatEradiate(i).Checkd = True And m_ResultR(i) > 0.0 Then '如果选中并计算的半径>0
                Dim strL As String = ""
                strL = LSet(Me.m_ArrHeatEradiate(i).HeatName, 30)

                strL += LSet(FormatNumber(m_ResultR(i), dNum, TriState.True, TriState.False, TriState.False), 20)
                strL += FormatNumber(m_ArrHeatEradiate(i).Heat, pNum, TriState.True, TriState.False, TriState.False)
                strResults = strResults & strL & vbCrLf
            End If
        Next


        If m_carepoint.Length > 0 Then
            strResults += vbCrLf
            strResults += "计算点名称              坐标(x,y)          热辐射通量(W/m^2)         死亡概率                死亡率(%)" & vbCrLf
        End If
        For k As Integer = 0 To m_carepoint.Length - 1

            If m_carepoint(k).ResultDistanceDp = 0 Then
                Dim strL As String = ""
                strL = m_carepoint(k).Dist & "                                                      "
                strL = strL.Insert(20, "(" & m_carepoint(k).Rpoint.x & "," & m_carepoint(k).Rpoint.y & ")                              ")
                strL = strL.Insert(40, "-")
                strResults = strResults & strL & vbCrLf
            Else
                Dim strL As String = ""
                strL = m_carepoint(k).Dist & "                                                      "
                strL = strL.Insert(20, "(" & m_carepoint(k).Rpoint.x & "," & m_carepoint(k).Rpoint.y & ")                              ")
                strL = strL.Insert(40, FormatNumber(m_carepoint(k).ResultDistanceDp, pNum, TriState.True, TriState.False, TriState.False))
                strL = strL.Insert(70, FormatNumber(m_carepoint(k).Pr, 2, TriState.True, TriState.False, TriState.False))
                strL = strL.Insert(100, FormatNumber(m_carepoint(k).D, 1, TriState.True, TriState.False, TriState.False))
                strResults = strResults & strL & vbCrLf
            End If
        Next

        If Me.m_ResultStepDp.Length > 0 Then
            strResults += vbCrLf
            strResults += "距离(m)              热辐射通量(W/m^2)" & vbCrLf
        End If
        For i As Integer = 0 To m_StepCount - 1
            If Me.m_ResultStepDp(i) = 0 Then
                Dim strL As String = ""
                strL = FormatNumber(Me.m_StepLong * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, "-")
                strResults = strResults & strL & vbCrLf
            Else
                Dim strL As String = ""
                strL = FormatNumber(Me.m_StepLong * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, FormatNumber(Me.m_ResultStepDp(i), pNum, TriState.True, TriState.False, TriState.False))
                strResults = strResults & strL & vbCrLf
            End If
        Next
        Return strResults
    End Function
End Class

