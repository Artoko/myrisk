Public Class Bleve

    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = "储罐" '
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name As String = "丁二烯" '
    ''' <summary>
    ''' 事故源坐标
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourcePoint As New Point2D '

    Private m_Wf As Double = 10000 '物质总质量Wf[ kg ]:
    Private m_MemoryType As String = "单罐储存" '物质存储方式:
    Private m_Hc As Double = 50409000  '物质燃烧热Hc[J/kg]
    Private m_Model As String = "H.R.Greengerg&J.J.Cramer模型"   '火球半径和持续时间模型 >>选择模型:
    Private m_AccountFashion As Integer   '燃烧辐射分数计算方法 F/PA
    Private m_F As Double = 0.3 '通过系数估算f
    Private m_Pa As Double = 10125 '通过容器内压力计算[Pa]
    Private m_StepLong As Double = 20 '步长
    Private m_StepCount As Integer = 20  ' 个数
    Private m_ArrHeatEradiate(0 To 3) As FireBlast.HeatEradiate  '热通量数组

   
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

    Private RichResult As String '用于储存事故时的结果文字描述

#Region "中间变量"
    ''' <summary>
    ''' 火球半径
    ''' </summary>
    ''' <remarks></remarks>
    Private m_R As Double
    ''' <summary>
    ''' 火球持续时间
    ''' </summary>
    ''' <remarks></remarks>
    Private m_T As Double

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
    ''' 物质总质量Wf[ kg ]  double
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Wf() As Double
        Get
            Return Me.m_Wf
        End Get
        Set(ByVal value As Double)
            Me.m_Wf = value
        End Set
    End Property
    ''' <summary>
    ''' 通过系数估算f
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
    ''' 通过容器内压力计算[Pa]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Pa() As Double
        Get
            Return Me.m_Pa
        End Get
        Set(ByVal value As Double)
            Me.m_Pa = value
        End Set
    End Property
    ''' <summary>
    ''' 物质存储方式 string
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MemoryType() As String
        Get
            Return Me.m_MemoryType
        End Get
        Set(ByVal value As String)
            Me.m_MemoryType = value
        End Set
    End Property

    ''' <summary>
    ''' '物质燃烧热Hc[J/kg] double
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
    ''' 火球半径和持续时间模型 >>选择模型: string
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Model() As String
        Get
            Return Me.m_Model
        End Get
        Set(ByVal value As String)
            Me.m_Model = value
        End Set
    End Property
    ''' <summary>
    ''' 燃烧辐射分数计算方法
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AccountFashion() As Integer
        Get
            Return Me.m_AccountFashion
        End Get
        Set(ByVal value As Integer)
            Me.m_AccountFashion = value
        End Set
    End Property
    ''' <summary>
    '''  步长
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
    ''' 个数
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
    ''' 热辐射通量数组
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
        Me.ArrHeatEradiate(0).Heat = 28710
        Me.ArrHeatEradiate(0).Checkd = True

        Me.ArrHeatEradiate(1).HeatName = "二度烧伤"
        Me.ArrHeatEradiate(1).Heat = 19551
        Me.ArrHeatEradiate(1).Checkd = True

        Me.ArrHeatEradiate(2).HeatName = "一度烧伤"
        Me.ArrHeatEradiate(2).Heat = 8574
        Me.ArrHeatEradiate(2).Checkd = True

        Me.ArrHeatEradiate(3).HeatName = "财产损失"
        Me.ArrHeatEradiate(3).Heat = 26111
        Me.ArrHeatEradiate(3).Checkd = True
    End Sub



    Private Function R() As Double '计算火球半径

        '根据储存罐的数量确定系数
        Dim dblF As Double
        If Me.m_MemoryType = "单罐储存" Then
            dblF = 0.5
        ElseIf m_MemoryType = "双罐储存" Then
            dblF = 0.7
        ElseIf m_MemoryType = "多罐储存" Then
            dblF = 0.9
        End If
        '根据模型计算半径的系数
        Dim a As Double
        Dim b As Double
        If Model = "ILO 模型" Then
            a = 2.9
            b = 1 / 3
        ElseIf Model = "H.R.Greengerg&J.J.Cramer模型" Then
            a = 2.665
            b = 0.327
        ElseIf Model = "修正模型" Then
            a = 2.8
            b = 0.323
        End If
        R = a * (dblF * Me.m_Wf) ^ b
    End Function
    Private Function t() As Double '计算火球持续时间
        '根据储存罐的数量确定系数
        Dim dblF As Double
        If Me.m_MemoryType = "单罐储存" Then
            dblF = 0.5
        ElseIf m_MemoryType = "双罐储存" Then
            dblF = 0.7
        ElseIf m_MemoryType = "多罐储存" Then
            dblF = 0.9
        End If
        '根据模型计算半径的系数
        Dim a As Double
        Dim b As Double
        If Model = "ILO 模型" Then
            a = 0.45
            b = 1 / 3
        ElseIf Model = "H.R.Greengerg&J.J.Cramer模型" Then
            a = 1.089
            b = 0.327
        ElseIf Model = "修正模型" Then
            a = 1.26
            b = 0.224
        End If

        t = a * (dblF * Me.m_Wf) ^ b
    End Function
    ''' <summary>
    ''' 目标接收到热辐射通量的计算
    ''' </summary>
    ''' <param name="H">火球中心高度</param>
    ''' <param name="x">距离</param>
    ''' <param name="tx">火灾持续时间</param>
    ''' <param name="fx">燃烧系数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Q(ByRef H As Double, ByRef x As Double, ByRef tx As Double, ByRef fx As Double, ByRef W As Double, ByRef Hc As Double) As Double
        '目标接收到热辐射通量的计算
        Q = fx * W * Hc * (1 - 0.058 * System.Math.Log(x)) / (4 * Math.PI * tx * (H ^ 2 + x ^ 2))
    End Function

    ''' <summary>
    ''' 计算死亡距离的热通量
    ''' </summary>
    ''' <param name="tDie">人员暴露时间</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function qDie(ByRef tDie As Double) As Double
        '
        qDie = (1 / tDie * System.Math.Exp((5 + 37.23) / 2.56)) ^ 0.75
    End Function
    ''' <summary>
    ''' 计算二度烧伤距离的热通量
    ''' </summary>
    ''' <param name="tWound2">人员暴露时间</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function qWound2(ByRef tWound2 As Double) As Double
        '
        qWound2 = (1 / tWound2 * System.Math.Exp((5 + 43.14) / 3.0188)) ^ 0.75
    End Function
    ''' <summary>
    ''' 计算一度烧伤距离的热通量
    ''' </summary>
    ''' <param name="tWound1">人员暴露时间</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function qWound1(ByRef tWound1 As Double) As Double
        '
        qWound1 = (1 / tWound1 * System.Math.Exp((5 + 39.83) / 3.0188)) ^ 0.75
    End Function
    ''' <summary>
    ''' 计算财产损失距离的热通量
    ''' </summary>
    ''' <param name="tWealth">物品暴露时间</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function qWealth(ByRef tWealth As Double) As Double
        '
        qWealth = 6730 * tWealth ^ (-0.8) + 25400
    End Function

    Private Function Radius(ByRef H As Double, ByRef tx As Double, ByRef fx As Double, ByRef W As Double, ByRef Hc As Double, ByRef qAny As Double) As Double
        '通过内插法计算不同的伤害半径
        Dim dblQ As Double
        Dim RINT As Double
        Dim RINT1 As Double
        Dim RINT2 As Double
        RINT1 = 0
        RINT2 = 10000
        RINT = 10000
        dblQ = Q(H, RINT, tx, fx, W, Hc)
        While System.Math.Abs(dblQ - qAny) > 1

            If dblQ - qAny < 0 Then
                RINT2 = RINT
            Else
                RINT1 = RINT
            End If
            RINT = (RINT1 + RINT2) / 2
            dblQ = Q(H, RINT, tx, fx, W, Hc)
        End While
        Radius = RINT
    End Function


    Public Sub Cal(ByVal m_CarePoint As CarePoint())
        '计算火球半径
        Dim strR As String = ""

        m_R = R()
        '计算火球时间
        Dim strT As String = ""
        m_T = t()
        '计算死亡半径、二度烧伤、一度烧伤和财产损失热通量和半径
        Dim dblQDie As Double
        Dim dblQDamage2 As Double
        Dim dblQDamage1 As Double
        Dim dblQWealth As Double
        Dim dblRDie As Double
        Dim dblRDamage2 As Double
        Dim dblRDamage1 As Double
        Dim dblRWealth As Double

        '判断是否考虑火球高度
        Dim dblH As Double
        dblH = m_R
        '计算燃烧的质量
        Dim dblW As Double
        If Me.m_MemoryType = "单罐储存" Then
            dblW = 0.5 * CDbl(Me.m_Wf)
        ElseIf Me.m_MemoryType = "双罐储存" Then
            dblW = 0.7 * CDbl(Me.m_Wf)
        ElseIf Me.m_MemoryType = "多罐储存" Then
            dblW = 0.9 * CDbl(Me.m_Wf)
        End If

        '计算燃烧系数
        Dim dblF As Double
        If Me.m_AccountFashion = 0 Then
            dblF = Me.m_F
        Else
            dblF = 0.27 * ((Me.m_Pa / 1000000) ^ 0.32)
        End If


        ReDim Me.m_ResultR(Me.m_ArrHeatEradiate.Length - 1)

        '计算相应的半径
        If Me.m_ArrHeatEradiate(0).Checkd = True Then
            dblQDie = qDie(m_T) '求得死亡的热辐热通量
            dblRDie = Radius(dblH, m_T, dblF, dblW, Me.m_Hc, dblQDie) '计算死亡半径
            '将要画的结果压入数组
            Me.m_ArrHeatEradiate(0).Heat = dblQDie '热辐射通量
            Me.m_ResultR(0) = dblRDie '死亡半径
        End If

        If Me.m_ArrHeatEradiate(1).Checkd = True Then '二度烧伤半径
            dblQDamage2 = qWound2(m_T) '求得二度烧伤的热辐射通量
            dblRDamage2 = Radius(dblH, m_T, dblF, dblW, Me.m_Hc, dblQDamage2)

            '将要画的结果压入数组
            Me.m_ArrHeatEradiate(1).Heat = dblQDamage2 '热辐射通量
            Me.m_ResultR(1) = dblRDamage2 '二度烧伤半径

        End If

        If Me.m_ArrHeatEradiate(2).Checkd = True Then
            dblQDamage1 = qWound1(m_T)
            dblRDamage1 = Radius(dblH, m_T, dblF, dblW, Me.m_Hc, dblQDamage1)

            Me.m_ArrHeatEradiate(2).Heat = dblQDamage1 '热辐射通量
            Me.m_ResultR(2) = dblRDamage1 '一度烧伤半径
        End If

        If Me.m_ArrHeatEradiate(3).Checkd = True Then
            dblQWealth = qWealth(m_T)
            dblRWealth = Radius(dblH, m_T, dblF, dblW, Me.m_Hc, dblQWealth)
            '将半径压入数组
            Me.m_ArrHeatEradiate(3).Heat = dblQWealth '热辐射通量
            Me.m_ResultR(3) = dblRWealth '财产损失半径
        End If
        '通过热辐射通量计算距离
        Dim dblR1 As Double

        If Me.m_ArrHeatEradiate.Length > 4 Then
            For i As Integer = 4 To Me.m_ArrHeatEradiate.Length - 1
                dblR1 = Radius(dblH, m_T, dblF, dblW, Me.m_Hc, Me.m_ArrHeatEradiate(i).Heat)
                If Me.m_ArrHeatEradiate(i).Checkd = True Then
                    If dblR1 = 0 Then
                    Else
                        Me.m_ResultR(i) = dblR1 '对应的损失半径
                    End If
                End If
            Next
        End If

        '根据步长求热辐射
        ReDim Me.m_ResultStepDp(Me.m_StepCount - 1)
        Dim c As Integer '步长
        For i As Integer = 0 To Me.m_StepCount - 1
            c = (Me.m_StepLong + i * Me.m_StepLong)
            m_ResultStepDp(i) = Q(dblH, c, m_T, dblF, dblW, Me.m_Hc)
        Next

        '计算预测点
        Dim dblQ As Double '目标处的热辐射通量
        If m_CarePoint.Length > 0 Then '如果有关心点
            For i As Integer = 0 To m_CarePoint.Length - 1
                Dim R As Double = GetR(m_CarePoint(i).Rpoint, Me.m_SourcePoint) '先求出距离

                dblQ = Q(dblH, R, m_T, dblF, dblW, Me.m_Hc) '计算热辐射通量
                m_CarePoint(i).ResultDistanceDp = dblQ
                m_CarePoint(i).Pr = DiePr.DiePr(m_T, dblQ) '计算死亡概率
                m_CarePoint(i).D = DiePr.NormalSchool(m_CarePoint(i).Pr) * 100
            Next
        End If

    End Sub
    ''' <summary>
    ''' 返回计算结果的文字描述
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_CarePoint As CarePoint()) As String
        Dim strResults As String '计算结果
        strResults = "火球半径为：" & m_R & " m" & vbCrLf
        strResults += "火球持续时间为：" & FormatNumber(m_T, 3) & " s" & vbCrLf

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


        If m_CarePoint.Length > 0 Then
            strResults += vbCrLf
            strResults += "计算点名称              坐标(x,y)          热辐射通量(W/m^2)         死亡概率                死亡率(%)" & vbCrLf
        End If
        For k As Integer = 0 To m_CarePoint.Length - 1

            If m_CarePoint(k).ResultDistanceDp = 0 Then
                Dim strL As String = ""
                strL = m_CarePoint(k).Dist & "                                                      "
                strL = strL.Insert(20, "(" & m_CarePoint(k).Rpoint.x & "," & m_CarePoint(k).Rpoint.y & ")                              ")
                strL = strL.Insert(40, "-")
                strResults = strResults & strL & vbCrLf
            Else
                Dim strL As String = ""
                strL = m_CarePoint(k).Dist & "                                                      "
                strL = strL.Insert(20, "(" & m_CarePoint(k).Rpoint.x & "," & m_CarePoint(k).Rpoint.y & ")                              ")
                strL = strL.Insert(40, FormatNumber(m_CarePoint(k).ResultDistanceDp, pNum, TriState.True, TriState.False, TriState.False))
                strL = strL.Insert(70, FormatNumber(m_CarePoint(k).Pr, 2, TriState.True, TriState.False, TriState.False))
                strL = strL.Insert(100, FormatNumber(m_CarePoint(k).D, 1, TriState.True, TriState.False, TriState.False))
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
