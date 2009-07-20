Public Module Leak
    ''' <summary>
    ''' 两相流泄漏公式
    ''' </summary>
    ''' <param name="LeakTwoCP">两相混合物的定压比热，J/（kg·K）</param>
    ''' <param name="LeakTwoTLG">两相混合物的温度，摄氏度</param>
    ''' <param name="LeakTwoTC">液体在临界压力下的沸点，摄氏度</param>
    ''' <param name="LeakTwoH">液体的气化热，J/kg</param>
    ''' <param name="LeakTwoPg">标态下液体蒸气密度，kg/m3</param>
    ''' <param name="LeakTwoPl">液体密度，kg/m3</param>
    ''' <param name="LeakTwoCd">两相流泄漏系数，可取0.8</param>
    ''' <param name="LeakTwoA">裂口面积，m2</param>
    ''' <param name="LeakTwoP">操作压力或容器压力，Pa</param>
    ''' <param name="LeakTwoPC">临界压力，Pa，可取PC=0.55P</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CalculateLeakTwo(ByVal LeakTwoCP As Double, ByVal LeakTwoTLG As Double, ByVal LeakTwoTC As Double, ByVal LeakTwoH As Double, ByVal LeakTwoPg As Double, ByVal LeakTwoPl As Double, ByVal LeakTwoCd As Double, ByVal LeakTwoA As Double, ByVal LeakTwoP As Double, ByVal LeakTwoPC As Double) As Double
        If LeakTwoH = 0 Then
            MsgBox("请设置物质的液体的气化热!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        If LeakTwoCP = 0 Then
            MsgBox("请设置物质的液体的定压比热!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        '在计算前应根据常压气体的密度计算出给定压力下气体的密度
        Dim pg_1 As Double = LeakTwoPg * 298.15 * LeakTwoP / ((LeakTwoTLG + 273.15) * 101325)

        Dim Fv_Renamed As Double
        Fv_Renamed = LeakTwoCP * (LeakTwoTLG - LeakTwoTC) / LeakTwoH
        Dim Pm As Double
        Pm = 1 / (Fv_Renamed / pg_1 + (1 - Fv_Renamed) / LeakTwoPl)
        Dim QLG As Double
        QLG = LeakTwoCd * LeakTwoA * (2 * Pm * (LeakTwoP - LeakTwoPC)) ^ 0.5
        CalculateLeakTwo = QLG
    End Function
    Public Function strY(ByVal LeakGasP0 As Double, ByVal LeakGasP As Double, ByVal LeakGasK As Double) As String
        '判断气体流速是否在音速范围(临界流)
        Dim flow As Double
        flow = (2 / (LeakGasK + 1)) ^ (LeakGasK / (LeakGasK - 1))
        If LeakGasP0 / LeakGasP <= flow Then
            strY = "气体流速在音速范围，是临界流。" & vbCrLf
        Else
            strY = "气体流速在亚音速范围，是次临界流。" & vbCrLf
        End If

    End Function

    '气体泄漏计算公式
    Public Function CalculateLeakGas(ByVal LeakGasShape As String, ByVal LeakGasTG As Double, ByVal LeakGasK As Double, ByVal LeakGasP0 As Double, ByVal LeakGasP As Double, ByVal LeakGasA As Double, ByVal LeakGasM As Double) As Double
        If LeakGasK = 0 Then
            MsgBox("请设置物质的气体绝热指数!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        If LeakGasM = 0 Then
            MsgBox("请设置物质的摩尔质量!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        '计算气体泄漏系数
        Dim Cd As Double
        Select Case LeakGasShape
            Case 0 '圆  形
                Cd = 1.0#
            Case 1 '三角形
                Cd = 0.95
            Case 2 '长方形
                Cd = 0.9
        End Select
        Dim t As Double
        t = LeakGasTG
        '判断气体流速是否在音速范围(临界流),并计算流出系数Y
        Dim flow As Double
        Dim strY As String
        flow = (2 / (LeakGasK + 1)) ^ (LeakGasK / (LeakGasK - 1))
        Dim Y As Double
        Dim k1 As Double
        Dim k2 As Double
        Dim k3 As Double
        If LeakGasP0 / LeakGasP <= flow Then
            Y = 1
            strY = "气体流速在音速范围，是临界流。" & vbCrLf
        Else
            k1 = (LeakGasP0 / LeakGasP) ^ (1 / LeakGasK)
            k2 = (1 - ((LeakGasP0 / LeakGasP) ^ ((LeakGasK - 1) / LeakGasK))) ^ 0.5
            k3 = (2 / (LeakGasK - 1) * ((LeakGasK + 1) / 2) ^ ((LeakGasK + 1) / (LeakGasK - 1))) ^ 0.5
            Y = k1 * k2 * k3
            strY = "气体流速在亚音速范围，是次临界流。" & vbCrLf
        End If
        '计算气体泄漏速率QG
        Dim QG As Double
        Dim w1 As Double
        Dim w2 As Double
        Dim w3 As Double
        Dim w4 As Double
        w1 = Y * Cd * LeakGasA * LeakGasP
        w2 = (LeakGasM * LeakGasK) / (8.314 * t)
        w3 = (2 / (LeakGasK + 1)) ^ ((LeakGasK + 1) / (LeakGasK - 1))
        w4 = (w2 * w3) ^ 0.5
        QG = w1 * w4
        CalculateLeakGas = QG
    End Function
    '液体泄漏公式
    Public Function CalculateLeakLiquid(ByVal chkHeight As Short, ByVal LeakLiquidCd As Double, ByVal LeakLiquidHeight As Double, ByVal LeakLiquidA As Double, ByVal LeakLiquidPl As Double, ByVal LeakLiquidP As Double, ByVal LeakLiquidP0 As Double) As Double
        If LeakLiquidPl = 0 Then
            MsgBox("请输入物质的液体密度!", MsgBoxStyle.OkOnly, "物质性质数据出错")
            Return ErrorValue
        End If
        '确定是否考虑高度
        Dim H As Double
        If chkHeight = 0 Then '不考虑液位高度的压力
            H = 0
        Else
            H = LeakLiquidHeight '考虑液位高度的压力
        End If
        '计算液体泄漏量
        Dim QLG As Double
        QLG = LeakLiquidCd * LeakLiquidA * LeakLiquidPl * (2 * (LeakLiquidP - LeakLiquidP0) / LeakLiquidPl + 2 * 9.8 * H) ^ 0.5
        CalculateLeakLiquid = QLG
    End Function
    Public Function CalculateLeakFv(ByVal LeakLiquidCP As Double, ByVal LeakLiquidTLG As Double, ByVal LeakLiquidTC As Double, ByVal LeakLiquidH As Double) As Double
        If LeakLiquidH = 0 Then
            MsgBox("请设置物质的液体的气化热!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        If LeakLiquidCP = 0 Then
            MsgBox("请设置物质的液体的定压比热!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        '计算液体蒸发量
        CalculateLeakFv = LeakLiquidCP * (LeakLiquidTLG - LeakLiquidTC) / LeakLiquidH
    End Function
    '热量蒸发公式
    Public Function CalculateLeakHeat(ByVal LeakEvaporationGround As Integer, ByVal LeakEvaporationS As Double, ByVal LeakEvaporationT0 As Double, ByVal LeakEvaporationTb As Double, ByVal LeakEvaporationH As Double, ByVal LeakEvaporationt As Double) As Double
        If LeakEvaporationH = 0 Then
            MsgBox("请设置物质的液体的气化热!", MsgBoxStyle.OkOnly, "物质性质出错!")
            Return ErrorValue
        End If
        '选择表面热导系数和热扩散系数
        Dim l As Double
        Dim a As Double
        Select Case LeakEvaporationGround
            Case 0 '水泥
                l = 1.1
                a = 1.29 / 10000000
            Case 1 '土地(含水8%)
                l = 0.9
                a = 4.3 / 10000000
            Case 2 '干阔土地
                l = 0.3
                a = 2.3 / 10000000
            Case 3 '湿地
                l = 0.6
                a = 2.5 / 10000000
            Case 4 '砂砾地
                l = 2.5
                a = 11.0# / 10000000
        End Select

        '计算热量蒸发速率
        Dim Q2 As Double
        Q2 = l * LeakEvaporationS * (LeakEvaporationT0 - LeakEvaporationTb) / (LeakEvaporationH * (PI * a * LeakEvaporationt) ^ 0.5)

        CalculateLeakHeat = Q2

    End Function
    '质量蒸发公式
    Public Function CalculateLeakQuality(ByVal LeakEvaporationStab As String, ByVal LeakEvaporationP As Double, ByVal LeakEvaporationM As Double, ByVal LeakEvaporationT0 As Double, ByVal LeakEvaporationU As Double, ByVal LeakEvaporationS As Double) As Double
        '选择稳定度
        Dim N As Double
        Dim a As Double
        If LeakEvaporationStab = "不稳定(A，B)" Or LeakEvaporationStab = "A" Or LeakEvaporationStab = "A-B" Or LeakEvaporationStab = "B" Or LeakEvaporationStab = "B-C" Or LeakEvaporationStab = "C" Or LeakEvaporationStab = "C-D" Then
            N = 0.2
            a = 3.846 / 1000
        ElseIf LeakEvaporationStab = "中性(D)" Or LeakEvaporationStab = "D" Then
            N = 0.25
            a = 4.685 / 1000
        ElseIf LeakEvaporationStab = "稳定(E，F)" Or LeakEvaporationStab = "D-E" Or LeakEvaporationStab = "E" Or LeakEvaporationStab = "E-F" Or LeakEvaporationStab = "F" Then
            N = 0.3
            a = 5.285 / 1000
        End If
        Dim Q3 As Double
        Q3 = a * LeakEvaporationP * LeakEvaporationM / (8.314 * (LeakEvaporationT0 + 273.15)) * LeakEvaporationU ^ ((2 - N) / (2 + N)) * ((LeakEvaporationS / PI) ^ 0.5) ^ ((4 + N) / (2 + N))
        CalculateLeakQuality = Q3
    End Function
    '液池扩散公式，求得某一时刻液池的半径。pl为密度，kg/m3，m为某一时刻的质量，t为泄漏时间
    Public Function PoolR(ByVal pl As Double, ByVal m As Double, ByVal t As Double, ByVal AllT As Double) As Double
        Dim B As Double
        If AllT < 30 Then  '如果泄漏时间小于30m，按瞬时排放计算
            B = (PI * pl / (8 * Gravity * m)) ^ 0.5
            PoolR = (t / B) ^ 0.5
        Else
            B = (PI * pl / (32 * Gravity * m)) ^ (1 / 3.0)
            PoolR = (t / B) ^ (3 / 4.0)
        End If
    End Function
    '液池的最大面积
    Public Function Smax(ByVal pl As Double, ByVal m As Double) As Double
        Smax = m / (pl * 0.01)
    End Function
End Module
