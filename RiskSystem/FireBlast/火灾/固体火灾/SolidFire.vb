Public Class SolidFire
    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = "库房" '
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name As String = "硫磺" '
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
    ''' 燃烧速率（kg/s）
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MC As Double = 5
    
    ''' <summary>
    ''' 热辐射系数f
    ''' </summary>
    ''' <remarks></remarks>
    Private m_F As Double = 0.25 '
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
    ''' 燃烧速率
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mf

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
    ''' 燃烧速率（kg/s）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Mc() As Double
        Get
            Return Me.m_MC
        End Get
        Set(ByVal value As Double)
            Me.m_MC = value
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
    ''' '计算财产损失距离的热通量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaWealthDamnify() As Double

        Dim wealth As Double
        wealth = 6730 * Me.m_T ^ (-0.8) + 25400
        Return wealth
    End Function
    ''' <summary>
    ''' '燃烧持续时间
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaTime() As Double
        Dim T As Double = Me.m_W / Me.m_MC
        Return T
    End Function
   
    ''' <summary>
    ''' 通过距离求得热辐热通
    ''' </summary>
    ''' <param name="paraX">距离</param>
    ''' <returns>目标点的热辐热通量</returns>
    ''' <remarks></remarks>
    Private Function FormulaQ(ByVal paraX As Double) As Double
        FormulaQ = Me.m_F * Me.m_MC * Me.m_Hc / (4 * Math.PI * paraX ^ 2)
    End Function


    ''' <summary>
    ''' 根据给定的热辐射能量求得距离
    ''' </summary>
    ''' <param name="q">目标的热辐射通量</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Radius(ByVal q As Double) As Double
        Return Math.Sqrt(Me.m_F * Me.m_MC * Me.m_Hc / (4 * Math.PI * q))
    End Function
    ''' <summary>
    ''' 计算
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        '池火计算燃烧速率

        m_mf = Me.m_MC

        '计算燃烧时间
        m_DurationT = FormulaTime()


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
            dblRDie = Radius(dblQDie)
            If dblRDie = 0 Then
            Else
                '将要画的结果压入数组
                Me.m_ArrHeatEradiate(0).Heat = dblQDie '热辐射通量
                Me.m_ResultR(0) = dblRDie '死亡半径
            End If
        End If
        If Me.m_ArrHeatEradiate(1).Checkd = True Then '二度烧伤半径
            dblQDamage2 = FormulaBurnTwo() '求得二度烧伤的热辐射通量
            dblRDamage2 = Radius(dblQDamage2)
            If dblRDamage2 = 0 Then
            Else
                '将要画的结果压入数组
                Me.m_ArrHeatEradiate(1).Heat = dblQDamage2 '热辐射通量
                Me.m_ResultR(1) = dblRDamage2 '二度烧伤半径

            End If
        End If
        If Me.m_ArrHeatEradiate(2).Checkd = True Then
            dblQDamage1 = FormulaBurnOne()
            dblRDamage1 = Radius(dblQDamage1)
            If dblRDamage1 = 0 Then
            Else
            End If
            Me.m_ArrHeatEradiate(2).Heat = dblQDamage1 '热辐射通量
            Me.m_ResultR(2) = dblRDamage1 '一度烧伤半径
        End If
        If Me.m_ArrHeatEradiate(3).Checkd = True Then
            dblQWealth = FormulaWealthDamnify()
            dblRWealth = Radius(dblQWealth)
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
                dblR1 = Radius(Me.m_ArrHeatEradiate(i).Heat)
                If Me.m_ArrHeatEradiate(i).Checkd = True Then
                    If dblR1 = 0 Then
                    Else
                        Me.m_ResultR(i) = dblR1
                    End If
                End If
            Next
        End If

        '根据步长求热辐射
        ReDim Me.m_ResultStepDp(Me.m_StepCount - 1)
        Dim c As Integer '步长
        For i As Integer = 0 To Me.m_StepCount - 1
            c = (Me.m_StepLong + i * Me.m_StepLong)
            m_ResultStepDp(i) = FormulaQ(c)
        Next

        '计算预测点
        Dim dblQ As Double '目标处的热辐射通量
        Dim strQ As String
        strQ = ""
        If m_carepoint.Length > 0 Then '如果有关心点
            For i As Integer = 0 To m_carepoint.Length - 1
                Dim R As Double = GetR(m_carepoint(i).Rpoint, Me.m_SourcePoint) '先求出距离

                dblQ = FormulaQ(R)
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
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint()) As String
        Dim strResults As String = "" '计算结果
        'strResults = "池火单位面积燃烧速率为" & m_mf & "kg/·s" & vbCrLf
        'strResults += "池火持续时间为：" & FormatNumber(m_DurationT, 0) & " s" & vbCrLf

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
