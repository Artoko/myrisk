''' <summary>
''' 物质爆炸
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PhysicsExplode
    Inherits BaseBoo
    ''' <summary>
    ''' 物理爆炸的类型：0表示压缩气体容器爆炸，1表示饱和蒸汽容器爆炸，2介质全部为液体时容器爆炸，3表示液化气体容器爆炸，4表示高温饱和水容器的爆炸
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ExplodeType As Integer '


    ''' <summary>
    ''' 中间变量。物理爆炸的能量
    ''' </summary>
    ''' <remarks></remarks>
    Private m_E As Double
    ''' <summary>
    ''' 容器内气体的绝对压力 Pa 。公式中的压力为Ma，计算时注意转换。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pg As Double = 1100000
    ''' <summary>
    ''' 容器的体积，m3
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Vg As Double = 100
    ''' <summary>
    ''' 气体绝热指数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_kg As Double = 1.4

    ''' <summary>
    ''' 饱和蒸汽容器的压力。用于计算 饱和蒸汽容器爆炸能量系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Ps As Double = 1100000
    ''' <summary>
    ''' 饱和蒸汽容器爆炸能量系数 J/m3
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cs As Double
    ''' <summary>
    ''' 蒸汽的体积，m3
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Vs As Double = 100
    ''' <summary>
    ''' 液体的绝对压力,Pa
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pl As Double = 1100000
    ''' <summary>
    ''' 容器的体积，m3
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Vl As Double = 100
    ''' <summary>
    ''' 液体在压力P和温度T下气体压缩系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Bt As Double = 0.000000000452
    ''' <summary>
    ''' 爆炸前液化液体的焓,J/kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_H1 As Double = 2000000
    ''' <summary>
    ''' 爆炸后液化液体的焓,J/kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_H2 As Double = 1000000
    ''' <summary>
    ''' 爆炸前饱和液体的熵J/(kg·K)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_S1 As Double = 100000
    ''' <summary>
    ''' 大气压力下饱和液体的熵 J/(kg·K)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_S2 As Double = 200000
    ''' <summary>
    ''' 介质在大气压力下的沸点,摄氏度。公式中为K，注意转换。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Tb As Double = 60
    ''' <summary>
    ''' 饱和液体的质量，kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_W As Double = 5000
    ''' <summary>
    ''' 饱和水的压力。用于计算爆炸能量系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pw As Double = 1.1 * 1000000

    ''' <summary>
    ''' 饱和水爆炸能量系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cw As Double
    ''' <summary>
    ''' 窗口内饱和水所占的体积(m3)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Vw As Double = 100


    ''' <summary>
    ''' TNT的爆炸热，一般取4.52×106J/kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_QTNT As Double = 4.52 * 1000000 '——TNT的爆炸热，一般取4.52×106J/kg



    ''' <summary>
    ''' 物理爆炸的类型：0表示压缩气体容器爆炸，1表示饱和蒸汽容器爆炸，2介质全部为液体时容器爆炸，3表示液化气体容器爆炸，4表示高温饱和水容器的爆炸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ExplodeType() As Integer
        Get
            Return Me.m_ExplodeType
        End Get
        Set(ByVal value As Integer)
            Me.m_ExplodeType = value
        End Set
    End Property


    ''' <summary>
    ''' 中间变量。物理爆炸的能量
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property E() As Double
        Get
            Return Me.m_E
        End Get
    End Property
    ''' <summary>
    ''' 容器内气体的绝对压力 Pa 。公式中的压力为Ma，计算时注意转换。
    ''' </summary>
    ''' <remarks></remarks>
    Property Pg() As Double
        Get
            Return Me.m_Pg
        End Get
        Set(ByVal value As Double)
            Me.m_Pg = value
        End Set
    End Property
    ''' <summary>
    ''' 容器的体积，m3
    ''' </summary>
    ''' <remarks></remarks>
    Property Vg() As Double
        Get
            Return Me.m_Vg
        End Get
        Set(ByVal value As Double)
            Me.m_Vg = value
        End Set
    End Property
    ''' <summary>
    ''' 气体绝热指数
    ''' </summary>
    ''' <remarks></remarks>
    Property kg() As Double
        Get
            Return Me.m_kg
        End Get
        Set(ByVal value As Double)
            Me.m_kg = value
        End Set
    End Property
    ''' <summary>
    ''' 饱和蒸汽容器的压力 Pa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Ps() As Double
        Get
            Return Me.m_Ps
        End Get
        Set(ByVal value As Double)
            Me.m_Ps = value
        End Set
    End Property

    ''' <summary>
    ''' 蒸汽的体积，m3
    ''' </summary>
    ''' <remarks></remarks>
    Property Vs() As Double
        Get
            Return Me.m_Vs
        End Get
        Set(ByVal value As Double)
            Me.m_Vs = value
        End Set
    End Property
    ''' <summary>
    ''' 液体的绝对压力,Pa
    ''' </summary>
    ''' <remarks></remarks>
    Property Pl() As Double
        Get
            Return Me.m_Pl
        End Get
        Set(ByVal value As Double)
            Me.m_Pl = value
        End Set
    End Property
    ''' <summary>
    ''' 容器的体积，m3
    ''' </summary>
    ''' <remarks></remarks>
    Property Vl() As Double
        Get
            Return Me.m_Vl
        End Get
        Set(ByVal value As Double)
            Me.m_Vl = value
        End Set
    End Property
    ''' <summary>
    ''' 液体在压力P和温度T下气体压缩系数
    ''' </summary>
    ''' <remarks></remarks>
    Property Bt() As Double
        Get
            Return Me.m_Bt
        End Get
        Set(ByVal value As Double)
            Me.m_Bt = value
        End Set
    End Property
    ''' <summary>
    ''' 爆炸前液化液体的焓,J/kg
    ''' </summary>
    ''' <remarks></remarks>
    Property H1() As Double
        Get
            Return Me.m_H1
        End Get
        Set(ByVal value As Double)
            Me.m_H2 = value
        End Set
    End Property
    ''' <summary>
    ''' 爆炸后液化液体的焓,J/kg
    ''' </summary>
    ''' <remarks></remarks>
    Property H2() As Double
        Get
            Return Me.m_H2
        End Get
        Set(ByVal value As Double)
            Me.m_H2 = value
        End Set
    End Property
    ''' <summary>
    ''' 爆炸前饱和液体的熵J/(kg·K)
    ''' </summary>
    ''' <remarks></remarks>
    Property S1() As Double
        Get
            Return Me.m_S1
        End Get
        Set(ByVal value As Double)
            Me.m_S1 = value
        End Set
    End Property
    ''' <summary>
    ''' 大气压力下饱和液体的熵 J/(kg·K)
    ''' </summary>
    ''' <remarks></remarks>
    Property S2() As Double
        Get
            Return Me.m_S2
        End Get
        Set(ByVal value As Double)
            Me.m_S2 = value
        End Set
    End Property
    ''' <summary>
    ''' 介质在大气压力下的沸点,摄氏度。公式中为K，注意转换。
    ''' </summary>
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
    ''' 饱和液体的质量，kg
    ''' </summary>
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
    ''' 饱和水的压力。用于计算爆炸能量系数
    ''' </summary>
    ''' <remarks></remarks>
    Property Pw() As Double
        Get
            Return Me.m_Pw
        End Get
        Set(ByVal value As Double)
            Me.m_Pw = value
        End Set
    End Property
    ''' <summary>
    ''' 窗口内饱和水所占的体积(m3)
    ''' </summary>
    ''' <remarks></remarks>
    Property Vw() As Double
        Get
            Return Me.m_Vw
        End Get
        Set(ByVal value As Double)
            Me.m_Vw = value
        End Set
    End Property

    ''' <summary>
    ''' 内插法计算饱和蒸汽容器爆炸能量系数
    ''' </summary>
    ''' <param name="P0"></param>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <param name="Cs1"></param>
    ''' <param name="Cs2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function functionCs(ByVal P0 As Double, ByVal P1 As Double, ByVal P2 As Double, ByVal Cs1 As Double, ByVal Cs2 As Double)
        Return ((P0 - P1) * (Cs1 - Cs2) / (P1 - P2) + Cs1) * 1000000
    End Function
    ''' <summary>
    ''' 计算饱和蒸汽容器爆炸能量系数
    ''' </summary>
    ''' <param name="p0"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalCs(ByVal p0 As Double) As Double

        Dim Cs0 As Double = 0
        If p0 <= 0.5 Then
            Cs0 = functionCs(p0, 0.4, 0.5, 0.437, 0.628)

        ElseIf p0 > 0.5 And p0 <= 0.6 Then
            Cs0 = functionCs(p0, 0.5, 0.6, 0.628, 0.831)

        ElseIf p0 > 0.6 And p0 <= 0.8 Then
            Cs0 = functionCs(p0, 0.6, 0.8, 0.831, 1.27)

        ElseIf p0 > 0.8 And p0 <= 0.9 Then
            Cs0 = functionCs(p0, 0.8, 0.9, 1.27, 1.5)

        ElseIf p0 > 0.9 And p0 <= 1.1 Then
            Cs0 = functionCs(p0, 0.9, 1.1, 1.5, 1.98)

        ElseIf p0 > 1.1 And p0 <= 1.4 Then
            Cs0 = functionCs(p0, 1.1, 1.4, 1.98, 2.75)

        ElseIf p0 > 1.4 And p0 <= 1.7 Then
            Cs0 = functionCs(p0, 1.4, 1.7, 2.75, 3.56)

        ElseIf p0 > 1.7 And p0 <= 2.6 Then
            Cs0 = functionCs(p0, 1.7, 2.6, 3.56, 6.24)

        ElseIf p0 > 2.6 Then
            Cs0 = functionCs(p0, 2.6, 3.1, 6.24, 7.77)

        End If
        Return Cs0
    End Function


    ''' <summary>
    ''' 计算饱和蒸汽容器爆炸能量系数
    ''' </summary>
    ''' <param name="p0"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalCw(ByVal p0 As Double) As Double

        Dim Cs0 As Double = 0
        If p0 <= 0.5 Then
            Cs0 = functionCs(p0, 0.4, 0.5, 23.8, 27.2)

        ElseIf p0 > 0.5 And p0 <= 0.6 Then
            Cs0 = functionCs(p0, 0.5, 0.6, 27.2, 32.5)

        ElseIf p0 > 0.6 And p0 <= 0.8 Then
            Cs0 = functionCs(p0, 0.6, 0.8, 32.5, 41.4)

        ElseIf p0 > 0.8 And p0 <= 0.9 Then
            Cs0 = functionCs(p0, 0.8, 0.9, 41.4, 45.6)

        ElseIf p0 > 0.9 And p0 <= 1.1 Then
            Cs0 = functionCs(p0, 0.9, 1.1, 45.6, 53.6)

        ElseIf p0 > 1.1 And p0 <= 1.4 Then
            Cs0 = functionCs(p0, 1.1, 1.4, 53.6, 63.5)

        ElseIf p0 > 1.4 And p0 <= 1.7 Then
            Cs0 = functionCs(p0, 1.4, 1.7, 63.5, 72.4)

        ElseIf p0 > 1.7 And p0 <= 2.6 Then
            Cs0 = functionCs(p0, 1.7, 2.6, 72.4, 95.6)

        ElseIf p0 > 2.6 Then
            Cs0 = functionCs(p0, 2.6, 3.1, 95.6, 106)

        End If
        Return Cs0
    End Function

    ''' <summary>
    ''' 返回物理爆炸的能量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunctionE() As Double
        Dim dblE As Double '单位为J
        Select Case Me.m_ExplodeType '物理爆炸的类型：
            Case 0 '0表示压缩气体容器爆炸
                dblE = Me.m_Pg * 0.000001 * Me.m_Vg / (Me.m_kg - 1) * (1 - (0.1013 / (Me.m_Pg * 0.000001)) ^ ((Me.m_kg - 1) / Me.m_kg)) * 1000000
            Case 1 '1表示饱和蒸汽容器爆炸
                Me.m_Cs = CalCs(Me.m_Ps / 1000000)
                dblE = Me.m_Cs * Me.m_Vs
            Case 2 '2介质全部为液体时容器爆炸
                dblE = (Me.m_Pl - 1) ^ 2 * Me.m_Vl * Me.m_Bt / 2 * 1000
            Case 3 '3表示液化气体容器爆炸
                dblE = ((Me.m_H1 - Me.m_H2) - (Me.m_S1 - Me.m_S2) * Me.m_Tb) * Me.m_W
            Case 4 '4表示高温饱和水容器的爆炸
                Me.m_Cw = CalCw(Me.m_Pw / 1000000)
                dblE = Me.m_Cw * Me.m_Vw
        End Select
        Return dblE
    End Function

    ''' <summary>
    ''' 取得TNT当量,kg
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WTNT() As Double ' 
        Dim dble = FunctionE()
        WTNT = dble / Me.m_QTNT
    End Function
    Public Sub New()
        m_SourceName = "容器"
        m_Name = ""
    End Sub
    ''' <summary>
    ''' 通过距离计算超压
    ''' </summary>
    ''' <param name="WTNT"></param>
    ''' <param name="R"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function db(ByVal WTNT As Double, ByVal R As Double) As Double
        Dim dblW As Double = WTNT
        Dim dbla As Double = (dblW / 1000) ^ (1 / 3)
        Dim R0 As Double = R / dbla '与模拟实验中的相当距离m
        '根据当量距离查表求出距离对应的超压
        Dim P0 As Double
        If R0 < 6 Then
            P0 = functionNCP(R0, 5, 6, 2.94, 2.06)
        ElseIf R0 > 6 And R0 <= 7 Then
            P0 = functionNCP(R0, 6, 7, 2.06, 1.67)
        ElseIf R0 > 7 And R0 <= 8 Then
            P0 = functionNCP(R0, 7, 8, 1.67, 1.27)
        ElseIf R0 > 8 And R0 <= 9 Then
            P0 = functionNCP(R0, 8, 9, 1.27, 0.95)
        ElseIf R0 > 9 And R0 <= 10 Then
            P0 = functionNCP(R0, 9, 10, 0.95, 0.76)
        ElseIf R0 > 10 And R0 <= 12 Then
            P0 = functionNCP(R0, 10, 12, 0.76, 0.5)
        ElseIf R0 > 12 And R0 <= 14 Then
            P0 = functionNCP(R0, 12, 14, 0.5, 0.33)
        ElseIf R0 > 14 And R0 <= 16 Then
            P0 = functionNCP(R0, 14, 16, 0.33, 0.235)
        ElseIf R0 > 16 And R0 <= 18 Then
            P0 = functionNCP(R0, 16, 18, 0.235, 0.17)
        ElseIf R0 > 18 And R0 <= 20 Then
            P0 = functionNCP(R0, 18, 20, 0.17, 0.126)
        ElseIf R0 > 20 And R0 <= 25 Then
            P0 = functionNCP(R0, 20, 25, 0.126, 0.079)
        ElseIf R0 > 25 And R0 <= 30 Then
            P0 = functionNCP(R0, 25, 30, 0.079, 0.057)
        ElseIf R0 > 30 And R0 <= 35 Then
            P0 = functionNCP(R0, 30, 35, 0.057, 0.043)
        ElseIf R0 > 35 And R0 <= 40 Then
            P0 = functionNCP(R0, 35, 40, 0.043, 0.033)
        ElseIf R0 > 40 And R0 <= 45 Then
            P0 = functionNCP(R0, 40, 45, 0.033, 0.027)
        ElseIf R0 > 45 And R0 <= 50 Then
            P0 = functionNCP(R0, 45, 50, 0.027, 0.0235)
        ElseIf R0 > 50 And R0 <= 55 Then
            P0 = functionNCP(R0, 50, 55, 0.0235, 0.0205)
        ElseIf R0 > 55 And R0 <= 60 Then
            P0 = functionNCP(R0, 55, 60, 0.0205, 0.018)
        ElseIf R0 > 60 And R0 <= 65 Then
            P0 = functionNCP(R0, 60, 65, 0.018, 0.016)
        ElseIf R0 > 65 And R0 <= 70 Then
            P0 = functionNCP(R0, 65, 70, 0.016, 0.0143)
        ElseIf R0 > 70 Then
            P0 = functionNCP(R0, 70, 75, 0.0143, 0.013)
        End If
        P0 = P0 * 1000000
        If P0 < 0 Then
            P0 = 0
        End If
        Return P0
    End Function
    ''' <summary>
    ''' 用内插法求距离对应的超压
    ''' </summary>
    ''' <param name="R0"></param>
    ''' <param name="R1"></param>
    ''' <param name="R2"></param>
    ''' <param name="P1"></param>
    ''' <param name="P2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function functionNCP(ByVal R0 As Double, ByVal R1 As Double, ByVal R2 As Double, ByVal P1 As Double, ByVal P2 As Double)
        Return (R0 - R1) * (P1 - P2) / (R1 - R2) + P1
    End Function
    ''' <summary>
    ''' 爆炸中心与给定超压间的距离
    ''' </summary>
    ''' <param name="WTNT"></param>
    ''' <param name="dP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RTNT(ByVal WTNT As Double, ByVal dP As Double) As Double
        Dim TCenter, F1, F2, FCenter As Double
        '根据上面求出的数组，从后向前找出浓度值的范围。再用二分法求出给定的值
        Dim LowT As Double = 10000
        Dim HeighT As Double = 0
        F1 = db(WTNT, LowT) '从10000m开始求
        F2 = db(WTNT, HeighT) '从0米开始
        '采用二分法求给定值
        Do
            TCenter = (LowT + HeighT) / 2
            FCenter = db(WTNT, TCenter) '计算出中间值的超压值
            If FCenter <= dP Then '如果中间值>=指定值
                LowT = TCenter
                F1 = FCenter
            Else
                HeighT = TCenter
                F2 = FCenter
            End If
        Loop While Math.Abs(LowT - HeighT) > 0.01
        Return TCenter
    End Function
    ''' <summary>
    ''' 计算火灾爆炸模型
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        '重新设置不同距离对应的超压数组
        '计算蒸汽云的TNT当量
        m_WTNT = WTNT()
        For i As Integer = 0 To m_carepoint.Length - 1
            Dim R As Double = GetR(m_carepoint(i).Rpoint, Me.m_SoucePoint) '根据坐标计算得到距离
            m_carepoint(i).ResultDistanceDp = db(m_WTNT, R) '根据距离计算得到超压
            m_carepoint(i).Pr = DiePr.TNTDiePr(m_carepoint(i).ResultDistanceDp) '计算死亡概率
            m_carepoint(i).D = DiePr.NormalSchool(m_carepoint(i).Pr) * 100 '计算死亡半分率
        Next
        '根据步长求超压
        ReDim Me.m_ResultStepDp(Me.m_Tcount - 1)
        Dim c As Integer '步长
        For i As Integer = 0 To Me.m_Tcount - 1
            c = (Me.m_Tstep + i * Me.m_Tstep)
            m_ResultStepDp(i) = db(m_WTNT, c)
        Next
        '根据超压计算距离
        ReDim Me.m_ResultR(Me.m_DestroyR.Length - 1)
        For i As Integer = 0 To Me.m_DestroyR.Length - 1
            Me.m_ResultR(i) = RTNT(m_WTNT, Me.m_DestroyR(i).MDrang) '通过超压计算距离
        Next

    End Sub

    ''' <summary>
    ''' 返回计算后的文字描述
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint()) As String
        '修改的代码－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        Dim strResults As String = ""
        strResults = "事故源" & Me.m_SourceName & "计算结果如下：" & vbCrLf

        Select Case Me.m_ExplodeType '物理爆炸的类型：
            Case 0 '0表示压缩气体容器爆炸
            Case 1 '1表示饱和蒸汽容器爆炸
                strResults = "饱和蒸汽的爆炸能量系数为" & Me.m_Cs & "J/m^3" & vbCrLf
            Case 2 '2介质全部为液体时容器爆炸
            Case 3 '3表示液化气体容器爆炸
            Case 4 '4表示高温饱和水容器的爆炸
                strResults = "饱和水容器的爆炸能量系数为" & Me.m_Cw & "J/m^3" & vbCrLf
        End Select
        strResults = strResults & "TNT当量为" & m_WTNT & "kg" & vbCrLf

        If Me.m_DestroyR.Length > 0 Then
            strResults += vbCrLf
            strResults += "事故损害后果                    损害半径(m)" & vbCrLf
        End If
        For i As Integer = 0 To Me.m_DestroyR.Length - 1
            If m_DestroyR(i).Selected = True And m_DestroyR(i).MDrang > 0.0 Then
                Dim strL As String = ""
                strL = LSet(Me.m_DestroyR(i).MDrangName, 30)
                strL += FormatNumber(m_ResultR(i), dNum, TriState.True, TriState.False, TriState.False)
                strResults = strResults & strL & vbCrLf
            End If
        Next


        If m_carepoint.Length > 0 Then
            strResults += vbCrLf
            strResults += "计算点名称              坐标(x,y)           超压值(Pa)                死亡概率                  死亡率(%)" & vbCrLf
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
            strResults += "距离(m)              超压值(Pa)" & vbCrLf
        End If
        For i As Integer = 0 To m_Tcount - 1
            If Me.m_ResultStepDp(i) = 0 Then
                Dim strL As String = ""
                strL = FormatNumber(Me.Tstep * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, "-")
                strResults = strResults & strL & vbCrLf
            Else
                Dim strL As String = ""
                strL = FormatNumber(Me.Tstep * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, FormatNumber(Me.m_ResultStepDp(i), pNum, TriState.True, TriState.False, TriState.False))
                strResults = strResults & strL & vbCrLf
            End If
        Next
        ' 在框中把距离给显示出来

        Return strResults & vbCrLf & vbCrLf
    End Function
End Class
