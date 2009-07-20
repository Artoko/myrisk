''' <summary>
''' TNT当量法类
''' </summary>
''' <remarks></remarks>
Public Class MaterialTNT
    Inherits BaseBoo
    
    ''' <summary>
    ''' 表示用公式法计算死亡半径和财产损失半径
    ''' </summary>
    ''' <remarks></remarks>
    Private m_FormulaChecked As Boolean = True
    ''' <summary>
    ''' 环境压力，一般取101325Pa
    ''' </summary>
    ''' <remarks></remarks>
    Private m_P0 As Double = 101325 '
    
    Private m_Wf As Double = 5000 '蒸汽云中燃料的总质量，kg
    Private m_Qf As Double = 60000000 '蒸汽的燃料热，J/kg
    Private m_QTNT As Double = 4.52 * 1000000 '——TNT的爆炸热，一般取4.52×106J/kg
    Private m_Reflect As Boolean = True  '是否考虑地面反射作用；对于地面爆炸，由于地面反射使用使爆炸威力几乎加倍，一般应乘以地面爆炸系数1.8。
    Private m_E As Double '爆炸总能量，J
    ''' <summary>
    ''' 环境压力，一般取101325Pa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Pa() As Double
        Get
            Return Me.m_P0
        End Get
        Set(ByVal value As Double)
            Me.m_P0 = value
        End Set
    End Property
   

    ''' <summary>
    ''' 蒸汽云中燃料的总质量，kg
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
    ''' 蒸汽的燃料热，J/kg
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Qf() As Double
        Get
            Return Me.m_Qf
        End Get
        Set(ByVal value As Double)
            Me.m_Qf = value
        End Set
    End Property
    ''' <summary>
    ''' 是否考虑地面反射作用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Reflect() As Boolean
        Get
            Return Me.m_Reflect
        End Get
        Set(ByVal value As Boolean)
            Me.m_Reflect = value
        End Set
    End Property

    ''' <summary>
    ''' 表示用公式法计算死亡半径和财产损失半径
    ''' </summary>
    ''' <remarks></remarks>
    Property FormulaChecked() As Boolean
        Get
            Return Me.m_FormulaChecked
        End Get
        Set(ByVal value As Boolean)
            Me.m_FormulaChecked = value
        End Set
    End Property
    ''' <summary>
    ''' 爆炸总能量，J
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property E() As Double
        Get
            Return Me.m_E
        End Get
        Set(ByVal value As Double)
            Me.m_E = value
        End Set
    End Property
    Public Sub New()
        m_SourceName = "危险品库"
        m_Name = "硝酸铵"
    End Sub

    ''' <summary>
    ''' 爆炸总能量，J
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FunctionE() As Double
        Return 1.8 * Me.m_Wf * Me.m_Qf
    End Function

    ''' <summary>
    ''' TNT当量,kg
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WTNT() As Double
        WTNT = 1.8 * Me.m_Wf * Me.m_Qf / Me.m_QTNT
    End Function

    ''' <summary>
    ''' 通过距离计算超压
    ''' </summary>
    ''' <param name="Eb">爆源总能量 J</param>
    ''' <param name="R">距离 m</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function db(ByVal Eb As Double, ByVal R As Double) As Double
        Dim z As Double = R / ((Eb / Me.m_P0) ^ (1 / 3)) '无量纲距离
        Dim dps As Double = 0.137 * z ^ (-3) + 0.119 * z ^ (-2) + 0.269 * z ^ (-1) - 0.019
        Dim dp As Double = dps * Me.m_P0
        Return dp
    End Function
    ''' <summary>
    ''' 爆炸中心与给定超压间的距离
    ''' </summary>
    ''' <param name="Eb">爆源总能量 J</param>
    ''' <param name="dP">超压 Pa</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RTNT(ByVal Eb As Double, ByVal dP As Double) As Double
        Dim TCenter, F1, F2, FCenter As Double
        '根据上面求出的数组，从后向前找出浓度值的范围。再用二分法求出给定的值
        Dim LowT As Double = 10000
        Dim HeighT As Double = 0
        F1 = db(Eb, LowT) '从10000m开始求
        F2 = db(Eb, HeighT) '从0米开始
        '采用二分法求给定值
        Do
            TCenter = (LowT + HeighT) / 2
            FCenter = db(Eb, TCenter) '计算出中间值的超压值
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
    ''' 计算死亡半径
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function R05(ByVal WTNT As Double) As Double '计算死亡半径
        R05 = 13.6 * (WTNT / 1000) ^ 0.37
    End Function
    ''' <summary>
    ''' 公式法计算财产损失半径
    ''' </summary>
    ''' <param name="WTNT">TNT当量</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RWealth(ByVal WTNT As Double) As Double '计算财产损失半径
        RWealth = 4.6 * WTNT ^ (1 / 3) / ((1 + (3175 / WTNT) ^ 2) ^ (1 / 6))
    End Function

    ''' <summary>
    ''' 计算火灾爆炸模型
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        '重新设置不同距离对应的超压数组
        Me.m_E = FunctionE() '爆源总能量
        For i As Integer = 0 To m_carepoint.Length - 1
            Dim R As Double = GetR(m_carepoint(i).Rpoint, Me.m_SoucePoint) '根据坐标计算得到距离
            m_carepoint(i).ResultDistanceDp = db(m_E, R) '根据距离计算得到超压
            m_carepoint(i).Pr = DiePr.TNTDiePr(m_carepoint(i).ResultDistanceDp) '计算死亡概率
            m_carepoint(i).D = DiePr.NormalSchool(m_carepoint(i).Pr) * 100 '计算死亡半分率
        Next
        '根据步长求超压
        ReDim Me.m_ResultStepDp(Me.m_Tcount - 1)
        Dim c As Integer '步长
        For i As Integer = 0 To Me.m_Tcount - 1
            c = (Me.m_Tstep + i * Me.m_Tstep)
            m_ResultStepDp(i) = db(Me.m_E, c)
        Next
        '根据超压计算距离
        ReDim Me.m_ResultR(Me.m_DestroyR.Length - 1)
        For i As Integer = 0 To Me.m_DestroyR.Length - 1
            Me.m_ResultR(i) = RTNT(Me.m_E, Me.m_DestroyR(i).MDrang) '通过超压计算距离
        Next
        '用公式法计算死亡半径和财产损失半径
        Me.m_WTNT = WTNT() 'TNT当量
        If Me.m_FormulaChecked = True Then '用公式法计算死亡半径和财产损失半径
            Me.m_ResultR(0) = R05(m_WTNT) '死亡半径
            Me.m_ResultR(3) = RWealth(m_WTNT)
        End If
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

        strResults = strResults & "爆源总能量" & m_WTNT & "J" & vbCrLf

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

