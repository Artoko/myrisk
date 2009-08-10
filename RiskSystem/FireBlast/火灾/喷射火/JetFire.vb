<Serializable()> Public Class JetFire


    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = "压力容器" '
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name As String = "氢气" '
    ''' <summary>
    ''' 事故源坐标
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourcePoint As New Point2D '
    Private m_SourceAngle As Double = 90 '喷射角度。单位为度

    ''' <summary>
    ''' 物质的燃烧热Hc[J/kg]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Hc As Double = 41792344 '
    ''' <summary>
    ''' 质量流速（kg/s）
    ''' </summary>
    ''' <remarks></remarks>
    Private m_M As Double = 5
    ''' <summary>
    ''' 接触时间。人员可迅速离开的时间，取40秒
    ''' </summary>
    ''' <remarks></remarks>
    Private m_T As Double = 40
    ''' <summary>
    ''' 燃烧效率因子，一般取0.35
    ''' </summary>
    ''' <remarks></remarks>
    Private m_f As Double = 0.35 '

    ''' <summary>
    ''' 发射因子，取0.2
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Xp As Double = 0.2

    ''' <summary>
    ''' 假设的点源数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_n As Integer = 101
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
    Private m_ResultHurtPoint(-1) As hurtPointstruct
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
    ''' 火焰长度，中间变量
    ''' </summary>
    ''' <remarks></remarks>
    Private m_L As Double
    ''' <summary>
    ''' 点源热辐射通量，中间变量 
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
    ''' 喷射角度。单位为度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceAngle() As Double
        Get
            Return Me.m_SourceAngle
        End Get
        Set(ByVal value As Double)
            Me.m_SourceAngle = value
        End Set
    End Property
    ''' <summary>
    ''' 物质的燃烧热Hc[J/kg]
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
    ''' 燃烧效率因子f
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property f() As Double
        Get
            Return Me.m_f
        End Get
        Set(ByVal value As Double)
            Me.m_f = value
        End Set
    End Property
    ''' <summary>
    ''' 泄漏流量（kg/s）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property M() As Double
        Get
            Return Me.m_M
        End Get
        Set(ByVal value As Double)
            Me.m_M = value
        End Set
    End Property
    ''' <summary>
    ''' 接触时间，一般为40S
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
    ''' 不同热辐射对应的点序列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultHurtPoint() As hurtPointstruct()
        Get
            Return Me.m_ResultHurtPoint
        End Get
        Set(ByVal value As hurtPointstruct())
            Me.m_ResultHurtPoint = value
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
        DieQ = (1 / Me.m_T * System.Math.Exp((5 + 37.23) / 2.56)) ^ 0.75
        Return DieQ
    End Function
    ''' <summary>
    ''' '计算一度烧伤距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaBurnOne() As Double
        Dim burnOne As Double

        burnOne = (1 / Me.m_T * System.Math.Exp((5 + 39.83) / 3.0188)) ^ 0.75
        Return burnOne
    End Function
    ''' <summary>
    ''' 计算二度烧伤距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaBurnTwo() As Double

        Dim burnTwo As Double
        burnTwo = (1 / Me.m_T * System.Math.Exp((5 + 43.14) / 3.0188)) ^ 0.75
        Return burnTwo
    End Function
    ''' <summary>
    '''计算财产损失距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaWealthDamnify() As Double

        Dim wealth As Double
        wealth = 6730 * Me.m_T ^ (-0.8) + 25400
        Return wealth
    End Function
    ''' <summary>
    ''' 通过距离求得热辐热通。可求得任意坐标点的热辐射通量。这个坐标系是以火焰方向为Y轴，垂直方向为X轴的坐标。
    ''' </summary>
    ''' <param name="point2d">坐标</param>
    ''' <returns>目标点的热辐热通量</returns>
    ''' <remarks></remarks>
    Private Function FormulaQ(ByVal point2d As Point2D) As Double
        Dim dblQi As Double = 0
        Dim P As New Point2D
        Dim D As Double
        For i As Integer = 0 To Me.m_n - 1
            P.x = 0
            P.y = (i + 1) * Me.m_L / Me.m_n
            D = Math.Sqrt((point2d.x - P.x) ^ 2 + (point2d.y - P.y) ^ 2)
            '确保D不为0
            If D <= 0 Then
                D = 0.000000001
            End If
            dblQi += Qi(D)
        Next
        Return dblQi
    End Function
    ''' <summary>
    ''' 距离点源xi处某点接收的热辐射通量
    ''' </summary>
    ''' <param name="xi">点源与接收点的距离</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Qi(ByVal xi As Double)
        Qi = Me.m_Xp * Me.m_E / (4 * Math.PI * xi ^ 2)
    End Function
    ''' <summary>
    ''' 喷射火的火焰长度
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunctionL() As Double
        Return (Me.m_Hc * Me.m_M) ^ 0.444 / 161.66
    End Function
    ''' <summary>
    ''' 计算点热源热辐射通量，W
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunctionE() As Double
        Return Me.m_f * Me.m_M * Me.m_Hc / Me.m_n
    End Function

    ''' <summary>
    ''' 根据给定的热辐射能量求得距离
    ''' </summary>
    ''' <param name="y"> 坐标为y水平线</param>
    ''' <param name="qAny"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RadiusP(ByVal y As Double, ByVal qAny As Double) As Point2D
        '通过内插法计算不同的伤害半径
        Dim dblQ As Double
        Dim RINT As New Point2D
        Dim RINT1 As New Point2D
        Dim RINT2 As New Point2D
        RINT1.x = 0 '最小为半径0，为了避免溢出
        RINT1.y = y

        RINT2.x = 10000 '最大为10000米
        RINT2.y = y

        RINT.x = 10000
        RINT.y = y

        Dim P As New Point2D
        P.x = 0
        P.y = y
        dblQ = FormulaQ(P)
        If dblQ < qAny Then '不存在对应的热辐射距离，则
            RINT = P
            Return RINT
        Else

            dblQ = FormulaQ(RINT)
            While System.Math.Abs(dblQ - qAny) > 1

                If dblQ - qAny < 0 Then
                    RINT2.x = RINT.x
                Else
                    RINT1.x = RINT.x
                End If
                RINT.x = (RINT1.x + RINT2.x) / 2
                dblQ = FormulaQ(RINT)
            End While
            RadiusP = RINT
        End If
    End Function
    ''' <summary>
    ''' 返回伤害对应的点的数组
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetHurtPoints(ByVal dblq As Double) As Point2D()
        Dim p As New Point2D
        Dim a1(-1) As Point2D
        p.y = Me.m_L / 2
        p = RadiusP(p.y, dblq)

        While p.x > 0
            ReDim Preserve a1(a1.Length)
            a1(a1.Length - 1) = New Point2D
            a1(a1.Length - 1).x = p.x
            a1(a1.Length - 1).y = p.y
            p.y += Me.m_L / (Me.m_n + 1)
            p = RadiusP(p.y, dblq)
        End While
        Dim a2(a1.Length - 1) As Point2D
        For i As Integer = 0 To a2.Length - 1
            a2(i) = New Point2D
            a2(i).x = -a1(a1.Length - 1 - i).x
            a2(i).y = a1(a1.Length - 1 - i).y
        Next

        Dim a3(a1.Length - 1) As Point2D
        For i As Integer = 0 To a3.Length - 1
            a3(i) = New Point2D
            a3(i).x = -a1(i).x
            a3(i).y = Me.m_L - a1(i).y
        Next
        Dim a4(a1.Length - 1) As Point2D
        For i As Integer = 0 To a4.Length - 1
            a4(i) = New Point2D
            a4(i).x = a1(a1.Length - 1 - i).x
            a4(i).y = Me.m_L - a1(a1.Length - 1 - i).y
        Next
        Dim a(a1.Length + a2.Length + a3.Length + a4.Length - 1) As Point2D
        For i As Integer = 0 To a1.Length - 1
            a(i) = a1(i)
        Next
        For i As Integer = 0 To a2.Length - 1
            a(i + a1.Length) = a2(i)
        Next
        For i As Integer = 0 To a3.Length - 1
            a(i + a1.Length + a2.Length) = a3(i)
        Next
        For i As Integer = 0 To a4.Length - 1
            a(i + a1.Length + a2.Length + a3.Length) = a4(i)
        Next
        Return a
    End Function


    ''' <summary>
    ''' 计算
    ''' </summary>
    ''' <param name="m_carepoint">绝对坐标对应的关心点</param>
    ''' <param name="ChangeDistance">相对坐标对应的关心点</param>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint(), ByVal ChangeDistance As CarePoint())
        '喷射火的火焰长度
        Me.m_L = FunctionL()
        '点热源热辐射通量，W
        Me.m_E = FunctionE()
        '根据步长求热辐射
        ReDim Me.m_ResultStepDp(Me.m_StepCount - 1)
        Dim c As Integer '步长
        Dim Pc As New Point2D '步长对应的点的坐标
        For i As Integer = 0 To Me.m_StepCount - 1
            c = (Me.m_StepLong + i * Me.m_StepLong)
            Pc.x = c
            Pc.y = Me.m_L / 2
            m_ResultStepDp(i) = FormulaQ(Pc)
        Next

        '计算死亡半径、二度烧伤、一度烧伤和财产损失热通量和半径
        Dim dblQDie As Double
        Dim dblQDamage2 As Double
        Dim dblQDamage1 As Double
        Dim dblQWealth As Double
        '将绘图数组清零
        ReDim Me.m_ResultHurtPoint(Me.m_ArrHeatEradiate.Length - 1)
        '计算相应的半径
        If Me.m_ArrHeatEradiate(0).Checkd = True Then
            dblQDie = FormulaDieQ() '求得死亡的热辐热通量
            Me.m_ResultHurtPoint(0) = New hurtPointstruct '新对象
            Me.m_ResultHurtPoint(0).ArrayHurtPoint = GetHurtPoints(dblQDie)
        End If
        If Me.m_ArrHeatEradiate(1).Checkd = True Then '二度烧伤半径
            dblQDamage2 = FormulaBurnTwo() '求得二度烧伤的热辐射通量
            Me.m_ResultHurtPoint(1) = New hurtPointstruct
            Me.m_ResultHurtPoint(1).ArrayHurtPoint = GetHurtPoints(dblQDamage2)
        End If
        If Me.m_ArrHeatEradiate(2).Checkd = True Then
            dblQDamage1 = FormulaBurnOne()
            Me.m_ResultHurtPoint(2) = New hurtPointstruct
            Me.m_ResultHurtPoint(2).ArrayHurtPoint = GetHurtPoints(dblQDamage1)
        End If
        If Me.m_ArrHeatEradiate(3).Checkd = True Then
            dblQWealth = FormulaWealthDamnify()
            Me.m_ResultHurtPoint(3) = New hurtPointstruct
            Me.m_ResultHurtPoint(3).ArrayHurtPoint = GetHurtPoints(dblQWealth)
        End If
        '通过热辐射通量计算距离
        If Me.m_ArrHeatEradiate.Length > 4 Then
            For i As Integer = 4 To Me.m_ArrHeatEradiate.Length - 1
                Me.m_ResultHurtPoint(i) = New hurtPointstruct
                Me.m_ResultHurtPoint(i).ArrayHurtPoint = GetHurtPoints(Me.m_ArrHeatEradiate(i).Heat)
            Next
        End If

        '计算预测点
        Dim dblQ As Double '目标处的热辐射通量
        Dim strQ As String
        strQ = ""
        If m_carepoint.Length > 0 Then '如果有关心点
            For i As Integer = 0 To m_carepoint.Length - 1
                dblQ = FormulaQ(ChangeDistance(i).Rpoint)
                m_carepoint(i).ResultDistanceDp = dblQ '热辐射
                m_carepoint(i).Pr = DiePr.DiePr(m_T, dblQ) '计算死亡概率 
                m_carepoint(i).D = DiePr.NormalSchool(m_carepoint(i).Pr) * 100 '死亡百分率
            Next
        End If
    End Sub
    ''' <summary>
    ''' 返回计算结果的文字描述
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint(), ByVal ChangeDistance As CarePoint()) As String
        Dim strResults As String = "" '计算结果
        strResults += "喷射火的火焰长度为：" & FormatNumber(m_L, 1) & "m" & vbCrLf
        strResults += "池火焰表面热辐射通量为：" & FormatNumber(m_E, 0) & "W/m^2" & vbCrLf


        ' 在框中把距离给显示出来
        'strResults += vbCrLf
        'strResults += "事故损害后果                    损害半径(m)           对应的热辐射通量(W/m^2)" & vbCrLf


        'For i As Integer = 0 To Me.m_ArrHeatEradiate.Length - 1
        '    If m_ArrHeatEradiate(i).Checkd = True And Me.m_ResultHurtPoint(i).ArrayHurtPoint > 0.0 Then '如果选中并计算的半径>0
        '        Dim strL As String = ""
        '        strL = LSet(Me.m_ArrHeatEradiate(i).HeatName, 30)

        '        strL += LSet(FormatNumber(m_ResultR(i), dNum, TriState.True, TriState.False, TriState.False), 20)
        '        strL += FormatNumber(m_ArrHeatEradiate(i).Heat, pNum, TriState.True, TriState.False, TriState.False)
        '        strResults = strResults & strL & vbCrLf
        '    End If
        'Next


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
                strL = strL.Insert(20, "(" & ChangeDistance(k).Rpoint.x & "," & ChangeDistance(k).Rpoint.y & ")                              ")
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
