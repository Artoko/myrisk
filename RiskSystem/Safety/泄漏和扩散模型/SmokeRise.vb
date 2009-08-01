Module SmokeRise
    '计算烟气热释放率Qh
    Private Function FQh(ByVal pa As Double, ByVal Qv As Double, ByVal Ts As Double, ByVal Ta As Double) As Double
        FQh = 0.35 * pa * Qv * (Ts - Ta) / Ts
    End Function

    Private Function RiseH1(ByVal Qh As Double, ByVal u As Double, ByVal H As Double, ByVal Ground As String) As Double
        'u 为烟气排气筒出口风速
        Dim n0 As Double '烟气热状况及地表系数
        Dim n1 As Double '烟气热释放率指数
        Dim n2 As Double '排气筒高度指数
        '以下计算系数
        If Qh >= 21000 Then
            If Ground = "平原地区农村及城市远郊区" Then
                n0 = 1.427
            Else
                n0 = 1.303
            End If
            n1 = 1 / 3.0#
            n2 = 2 / 3.0#
        Else
            If Ground = "平原地区农村及城市远郊区" Then
                n0 = 0.332
            Else
                n0 = 0.292
            End If
            n1 = 3 / 5.0#
            n2 = 2 / 5.0#
        End If
        '如果排气筒高度>240，取240
        If H > 240 Then
            H = 240
        End If
        RiseH1 = n0 * Qh ^ n1 * H ^ n2 / u
    End Function

    Private Function RiseH2(ByVal Qh As Double, ByVal Qv As Double, ByVal D As Double, ByVal u As Double, ByVal H As Double, ByVal Ground As String, ByVal Angle As Double) As Double
        Dim H1 As Double
        Dim H2 As Double
        Dim Vs As Double
        Vs = Qv / (PI * (D / 2) ^ 2) * System.Math.Sin(Angle / 180 * PI)
        H2 = RiseH1(Qh, u, H, Ground)
        H1 = 2 * (1.5 * Vs * D + 0.01 * Qh) / u - 0.048 * (Qh - 1700) / u
        RiseH2 = H1 + (H2 - H1) * (Qh - 1700) / 400
    End Function

    Private Function RiseH3(ByVal Qh As Double, ByVal Qv As Double, ByVal D As Double, ByVal u As Double, ByVal Angle As Double) As Double
        Dim Vs As Double
        If D = 0 Then
            Vs = 0
        Else
            Vs = Qv / (PI * (D / 2) ^ 2) * System.Math.Sin(Angle / 180 * PI)
            RiseH3 = 2 * (1.5 * Vs * D + 0.01 * Qh) / u
        End If
    End Function

    Private Function RiseU15HUnstab(ByVal Qh As Double, ByVal Qv As Double, ByVal D As Double, ByVal u As Double, ByVal H As Double, ByVal Ts As Double, ByVal Tb As Double, ByVal Ground As String, ByVal Angle As Double) As Double
        If Qh >= 2100 And Ts - Tb >= 35 Then
            RiseU15HUnstab = RiseH1(Qh, u, H, Ground)
        ElseIf Qh <= 1700 Or Ts - Tb < 35 Then
            RiseU15HUnstab = RiseH3(Qh, Qv, D, u, Angle)
        Else
            RiseU15HUnstab = RiseH2(Qh, Qv, D, u, H, Ground, Angle)
        End If
    End Function

    Private Function RiseHU15Stab(ByVal Qh As Double, ByVal dTz As Double, ByVal u As Double) As Double
        '当烟气热释放率<0时，计算结果没有意义。因此，取0
        If Qh < 0 Then
            Qh = 0
        End If
        RiseHU15Stab = Qh ^ (1 / 3) * (dTz + 0.0098) ^ (-1 / 3) * u ^ (-1 / 3)
    End Function

    Private Function RiseHU0_15(ByVal Qh As Double, ByVal dTz As Double) As Double
        '当烟气热释放率<0时，计算结果没有意义。因此，取0
        If Qh < 0 Then
            Qh = 0
        End If
        RiseHU0_15 = 5.5 * Qh ^ (1 / 4) * (dTz + 0.0098) ^ (-3 / 8)
    End Function

    '温度梯度
    Public Function FdTz(ByVal Stab As String) As String
        If Stab = "A" Then
            FdTz = -0.019
        ElseIf Stab = "A-B" Then
            FdTz = -0.0185
        ElseIf Stab = "B" Then
            FdTz = -0.018
        ElseIf Stab = "B-C" Then
            FdTz = -0.017
        ElseIf Stab = "C" Then
            FdTz = -0.016
        ElseIf Stab = "C-D" Then
            FdTz = -0.014
        ElseIf Stab = "D" Then
            FdTz = -0.0098
        ElseIf Stab = "D-E" Then
            FdTz = -0.005
        ElseIf Stab = "E" Then
            FdTz = 0
        ElseIf Stab = "F" Then
            FdTz = 0.01
        Else
            FdTz = 0
            'MsgBox("温度梯度出错")
        End If

    End Function

    '计算烟气抬升高度
    Public Function RiseH(ByVal pa As Double, ByVal Qv As Double, ByVal D As Double, ByVal H As Double, ByVal Ts As Double, ByVal Ta As Double, ByVal u10 As Double, ByVal Ground As String, ByVal Stab As String, ByVal Angle As Double) As Double '计算烟气抬升的总公式
        '计算烟气热释放率
        Dim Qh As Double
        Qh = FQh(pa, Qv, Ts, Ta)
        If Qh < 0 Then '如果烟气热释放率小于0时取0
            Qh = 0
        End If
        '计算排气口处的平均风速
        Dim u As Double
        u = UP(u10, H, Ground, Stab)
        '计算温度梯度
        Dim dTz As Double
        dTz = FdTz(Stab)
        If u10 >= 1.5 Then '有风情况
            If Stab = "A" Or Stab = "A-B" Or Stab = "B" Or Stab = "B-C" Or Stab = "C" Or Stab = "C-D" Or Stab = "D" Then
                RiseH = RiseU15HUnstab(Qh, Qv, D, u, H, Ts, Ta, Ground, Angle)
            Else
                RiseH = RiseHU15Stab(Qh, dTz, u)
            End If
        Else
            If dTz > -0.0098 Then
                If dTz < 0.01 Then
                    dTz = 0.01
                End If
                RiseH = RiseHU0_15(Qh, dTz)
            Else
                u = UP(1.5, H, Ground, Stab)
                RiseH = RiseU15HUnstab(Qh, Qv, D, u, H, Ts, Ta, Ground, Angle)
            End If
        End If
    End Function
End Module
