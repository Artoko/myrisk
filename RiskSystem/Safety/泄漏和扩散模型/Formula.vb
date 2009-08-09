Public Module Formula

    '单一气象条件下高斯单烟团模型
    Public Function GaussFog(ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal t As Double, ByVal u As Double, ByVal He As Double, ByVal ax As Double, ByVal ay As Double, ByVal az As Double) As Double
        Dim dblx As Double '储存x轴向计算结果
        Dim dbly As Double '储存z轴向计算结果
        Dim dblz As Double '储存y轴向计算结果
        dblx = System.Math.Exp(-(x - u * t) * (x - u * t) / (2 * ax * ax))
        dbly = System.Math.Exp(-y * y / (2 * ay * ay))
        dblz = System.Math.Exp(-(z - He) * (z - He) / (2 * az * az)) + System.Math.Exp(-(z + He) * (z + He) / (2 * az * az))
        Return Q / (Math.Sqrt((2 * PI) * (2 * PI) * (2 * PI)) * ax * ay * az) * dblx * dbly * dblz
    End Function

    '非正常排放模式，风速＞＝1.5,其中Ts为非正常排放时间，t为预测时间
    Public Function UnormalModal15(ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal t As Double, ByVal Ts As Double, ByVal u As Double, ByVal He As Double, ByVal ax As Double, ByVal ay As Double, ByVal az As Double) As Double
        Dim dbly As Double
        Dim dblz As Double
        Dim G1 As Double
        dblz = System.Math.Exp(-(z - He) * (z - He) / (2 * az * az)) + System.Math.Exp(-(z + He) * (z + He) / (2 * az * az))
        dbly = System.Math.Exp(-y * y / (2 * ay * ay))
        If t <= Ts Then
            G1 = NormalSchool((u * t - x) / ax) + NormalSchool(x / ax) - 1
        Else
            G1 = NormalSchool((u * t - x) / ax) - NormalSchool((u * t - u * Ts - x) / ax)
        End If
        UnormalModal15 = Q / (2 * PI * u * ay * az) * dbly * dblz * G1
    End Function

    '非正常排放模式，风速＜1.5，其中Ts为非正常排放时间，t为预测时间，u为x轴风速，v为y轴风速
    Public Function UnormalModal0_15(ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal t As Double, ByVal Ts As Double, ByVal u As Double, ByVal v As Double, ByVal He As Double, ByVal r01 As Double, ByVal r02 As Double) As Double
        Dim A0 As Double
        Dim A1 As Double
        Dim A2 As Double
        Dim A3 As Double
        Dim B1 As Double
        Dim B2 As Double
        Dim B3 As Double
        Dim B4 As Double
        Dim G2 As Double
        Dim H As Double
        H = He - z '如果z不为0，按有效源高为H=he-z计算
        A0 = x * x + y * y + (r01 * H / r02) * (r01 * H / r02)
        A1 = A0 / (2 * r01 * r01)
        A2 = (u * x + v * y) / A0
        A3 = System.Math.Exp(-1 / (2 * A0) * ((u * y - v * x) * (u * y - v * x) / (r01 * r01) + (v * v + u * u) * (H / r02) * (H / r02)))
        B1 = System.Math.Exp(-A1 * (1 / t - A2) * (1 / t - A2))
        B2 = NormalSchool(System.Math.Sqrt(2 * A1) * (1 / t - A2))

        If t <= Ts Then
            G2 = 1 / A1 * B1 + 2 * System.Math.Sqrt(PI / A1) * A2 * (1 - B2)
        ElseIf t > Ts Then
            B3 = NormalSchool(System.Math.Sqrt(2 * A1) * (1 / (t - Ts) - A2))
            B4 = System.Math.Exp(-A1 * (1 / (t - Ts) - A2) * (1 / (t - Ts) - A2))
            G2 = 1 / A1 * (B1 - B4) + 2 * System.Math.Sqrt(PI / A1) * A2 * (B3 - B2)
        End If
        UnormalModal0_15 = Q * A3 / (Math.Sqrt((2 * PI) * (2 * PI) * (2 * PI)) * r01 * r01 * r02) * G2


        'Dim A0 As Double
        'Dim A1 As Double
        'Dim A2 As Double
        'Dim A3 As Double
        'Dim B1 As Double
        'Dim B2 As Double
        'Dim B3 As Double
        'Dim B4 As Double
        'Dim G2 As Double
        'Dim H As Double
        'H = He - z '如果z不为0，按有效源高为H=he-z计算
        'A0 = x ^ 2 + y ^ 2 + (r01 * H / r02) ^ 2
        'A1 = A0 / (2 * r01 ^ 2)
        'A2 = (u * x + v * y) / A0
        'A3 = System.Math.Exp(-1 / (2 * A0) * ((u * y - v * x) ^ 2 / r01 ^ 2 + (v ^ 2 + u ^ 2) * (H / r02) ^ 2))
        'B1 = System.Math.Exp(-A1 * (1 / t - A2) ^ 2)
        'B2 = NormalSchool(System.Math.Sqrt(2 * A1) * (1 / t - A2))

        'If t <= Ts Then
        '    G2 = 1 / A1 * B1 + 2 * System.Math.Sqrt(PI / A1) * A2 * (1 - B2)
        'ElseIf t > Ts Then
        '    B3 = NormalSchool(System.Math.Sqrt(2 * A1) * (1 / (t - Ts) - A2))
        '    B4 = System.Math.Exp(-A1 * (1 / (t - Ts) - A2) ^ 2)
        '    G2 = 1 / A1 * (B1 - B4) + 2 * System.Math.Sqrt(PI / A1) * A2 * (B3 - B2)
        'End If
        'UnormalModal0_15 = Q * A3 / ((2 * PI) ^ (3 / 2) * r01 ^ 2 * r02) * G2
    End Function

    '单一气象条件下单烟团，瞬时泄漏模式
    Public Function SingleFlogModel(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal ForecastTime As Double, ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String) As Double
        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double
        Dim ay As Double
        Dim az As Double
        '根据10米处的风速选取相应的计算
        If u10 < 1.5 Then
            '计算0.5小时回归系数
            dblR01 = r01(u10, Stab)
            dblR02 = r02(u10, Stab)
            '计算相应取样时间的回归系数
            dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
            dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
            '计算相应取样时间的扩散参数
            ay = dblR01 * ForecastTime
            ax = ay
            az = dblR02 * ForecastTime
            '用点源预测模式计算
            SingleFlogModel = GaussFog(Q, x, y, z, ForecastTime, u2, He, ax, ay, az) '用高斯模式计算
        ElseIf u10 >= 1.5 And x > 0.01 Then  '当风速>=1.5m/s时，预测距离必须>0
            '如果风速＞＝1.5，用有风模式计算
            '计算0.5小时取样时间扩散参数
            ay = DiffuseY15(x, Stab, GroundCharacter) 'y轴扩散参数
            ax = ay
            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z轴扩散参数
            '计算相应取样时间的扩散参数
            ay = aySamplingTime(0.5, SamplingTime, ay)
            ax = ay
            '用点源预测模式计算
            SingleFlogModel = GaussFog(Q, x, y, z, ForecastTime, u2, He, ax, ay, az) '用高斯模式计算
        End If
    End Function

    '单一气象条件下，多烟团，短时泄漏排放模式计算
    Public Function MultiFlogModel(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal DurationT As Double, ByVal ForecastTime As Double, ByVal Q As Double, ByVal count As Short, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String) As Double
        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double
        Dim ay As Double
        Dim az As Double

        If u10 >= 1.5 And x > 0.01 Then '当风速>=1.5时，扩散参数是距离的函数，因此可以在循环外计算，这样可以减少计算量
            '如果风速＞＝1.5，用有风模式计算
            '计算0.5小时取样时间扩散参数
            ay = DiffuseY15(x, Stab, GroundCharacter) 'y轴扩散参数
            ax = ay
            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z轴扩散参数
            '计算相应取样时间的扩散参数
            ay = aySamplingTime(0.5, SamplingTime, ay)
            ax = ay
        End If

        '计算烟团排放持续时间到预测时间之差
        Dim N As Short
        N = 0 '烟团个数
        Dim dblForeTime As Double
        dblForeTime = ForecastTime - N * DurationT / count
        '计算每个烟团的排放量
        Dim EveryQ As Double
        EveryQ = Q * DurationT / count
        Dim Ci As Double '每个烟团的贡献浓度
        Ci = 0
        Dim CZ As Double '所有烟团的贡献浓度
        CZ = 0
        While N <= count - 1 And dblForeTime > 0
            If u10 < 1.5 Then
                '如果风速＜1.5，计算小风时的扩散参数。因为采用了多烟团模式，计算小风时的扩散参数是时间的函数，必有在循环内计算出每个烟团的扩散参数
                '计算0.5小时回归系数
                dblR01 = r01(u10, Stab)
                dblR02 = r02(u10, Stab)
                '计算相应取样时间的回归系数
                dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
                dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
                '计算相应取样时间的扩散参数
                ay = dblR01 * dblForeTime
                ax = ay
                az = dblR02 * dblForeTime
                '计算每个烟团的贡献浓度
                Ci = GaussFog(EveryQ, x, y, z, dblForeTime, u2, He, ax, ay, az)
                '叠加
                CZ = CZ + Ci
            ElseIf u10 >= 1.5 And x > 1 Then
                '计算每个烟团的贡献浓度
                Ci = GaussFog(EveryQ, x, y, z, dblForeTime, u2, He, ax, ay, az)
                '叠加
                CZ = CZ + Ci
            End If
            N = N + 1
            '计算预测时间与烟团排放的时间之差
            dblForeTime = ForecastTime - N * DurationT / count
        End While
        MultiFlogModel = CZ

    End Function

    

    '计算不完全珈玛函数使用的函数
    Public Function F(ByVal t As Double) As Double
        F = 1 / System.Math.Sqrt(2 * 3.1415926) * System.Math.Exp(-t * t / 2)
    End Function

    '用变步长辛普生公式计算不完全珈玛函数
    Public Function NormalSchool(ByVal b As Double) As Double
        Dim N As Long
        Dim K As Long
        Dim t2, t1, ep, s1, H, s2 As Double
        Dim p As Double
        Dim x As Double
        Dim a As Double
        Dim eps As Double
        If b <= -10 Then
            NormalSchool = 0
        ElseIf b >= 10 Then
            NormalSchool = 1
        Else
            eps = 0.0000000001
            a = -10
            N = 1
            H = b - a
            t1 = H * (F(a) + F(b)) / 2.0#
            s1 = t1
            ep = eps + 1.0#
            While (ep >= eps)
                p = 0.0#
                For K = 0 To N - 1
                    x = a + (K + 0.5) * H
                    p = p + F(x)
                Next K
                t2 = (t1 + H * p) / 2.0#
                s2 = (4.0# * t2 - t1) / 3
                ep = System.Math.Abs(s2 - s1)
                t1 = t2
                s1 = s2
                N = N + N
                H = H / 2.0#
            End While
            If s2 > 1 - 0.0000000001 Then '如果小于精确度则赋值为1
                s2 = 1
            ElseIf s2 < 0.0000000001 Then '如果小于精确度则赋值为0
                s2 = 0
            End If

            NormalSchool = s2
        End If
    End Function

    '扩散参数稳定度提级
    Public Function RiseStab(ByVal Stab As String, ByVal Ground As String) As String
        '根据地形确定稳定度，先根据地形将稳定度提级。
        '(1)平原地区农村及城市远郊区的扩散参数选取方法如下：A、A－B、B、B－C、C级稳定度直接由表3-和表B4查算，D、E、F级稳定度则需向不稳定方向提半级后由表B3和表B4查算。D-E由于没有其稳定度，不提级。
        '(2)工业区或城区中的点源，其扩散参数选取方法如下：   A、B级不提级，C级提到B级，D、E、F级向不稳定方向提一级，再按表B3和表B4查算。
        '(3)丘陵山区的农村或城市，其扩散参数选取方法同工业区

        If Ground = "平原地区农村及城市远郊区" Then
            If Stab = "D" Then
                RiseStab = "C-D"
            ElseIf Stab = "E" Then
                RiseStab = "D-E"
            ElseIf Stab = "F" Then
                RiseStab = "E"
            Else
                RiseStab = Stab
            End If
        Else ' Ground = "工业区或城区" Or Ground = "丘陵山区的农村或城市"
            If Stab = "C" Then
                RiseStab = "B"
            ElseIf Stab = "C-D" Then
                RiseStab = "B-C"
            ElseIf Stab = "D" Then
                RiseStab = "C"
            ElseIf Stab = "E" Then
                RiseStab = "D"
            ElseIf Stab = "F" Then
                RiseStab = "E"
            Else
                RiseStab = Stab
            End If
        End If
    End Function


    '计算Y轴的扩散参数
    Public Function DiffuseY15(ByVal x As Double, ByVal Stab As String, ByVal Ground As String) As Double
        Dim strStab As String
        strStab = RiseStab(Stab, Ground) '根据稳定度及地形提级
        DiffuseY15 = DiffuseParameterY15(x, strStab) '根据参数计算扩散参数
    End Function

    '计算Z轴的扩散参数
    Public Function DiffuseZ15(ByVal x As Double, ByVal Stab As String, ByVal Ground As String) As Double
        Dim strStab As String
        strStab = RiseStab(Stab, Ground) '根据稳定度及地形提级
        DiffuseZ15 = DiffuseParameterZ15(x, strStab) '根据参数计算扩散参数
    End Function

    '国标方法计算有风时Y轴扩散参数，风速＞＝1.5。x1表示下风向距离，Stab表示稳定度
    Public Function DiffuseParameterY15(ByVal x1 As Double, ByVal Stab As String) As Double

        Dim A1 As Double '扩散系数
        Dim r1 As Double '扩散系数
        If Stab = "A" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.901074
                r1 = 0.425809
            ElseIf x1 > 1000 Then
                A1 = 0.850934
                r1 = 0.602052
            End If
        ElseIf Stab = "A-B" Then   '取平均值得出
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.907722
                r1 = 0.3538275
            ElseIf x1 > 1000 Then
                A1 = 0.857974
                r1 = 0.4992025
            End If
        ElseIf Stab = "B" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.91437
                r1 = 0.281846
            ElseIf x1 > 1000 Then
                A1 = 0.865014
                r1 = 0.396353
            End If
        ElseIf Stab = "B-C" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.919325
                r1 = 0.2295
            ElseIf x1 > 1000 Then
                A1 = 0.875086
                r1 = 0.314238
            End If
        ElseIf Stab = "C" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.924279
                r1 = 0.177154
            ElseIf x1 > 1000 Then
                A1 = 0.885157
                r1 = 0.232123
            End If
        ElseIf Stab = "C-D" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.926849
                r1 = 0.14394
            ElseIf x1 > 1000 Then
                A1 = 0.88694
                r1 = 0.189396
            End If
        ElseIf Stab = "D" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.929418
                r1 = 0.110726
            ElseIf x1 > 1000 Then
                A1 = 0.888723
                r1 = 0.146669
            End If
        ElseIf Stab = "D-E" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.925118
                r1 = 0.0985631
            ElseIf x1 > 1000 Then
                A1 = 0.892794
                r1 = 0.124308
            End If
        ElseIf Stab = "E" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.920818
                r1 = 0.0864001
            ElseIf x1 > 1000 Then
                A1 = 0.896864
                r1 = 0.101947
            End If
        ElseIf Stab = "F" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.929418
                r1 = 0.0553634
            ElseIf x1 > 1000 Then
                A1 = 0.888723
                r1 = 0.0733348
            End If
        End If
        DiffuseParameterY15 = r1 * (x1 ^ A1)
    End Function

    '国标方法计算有风时Z轴扩散参数，风速＞＝1.5。x1表示下风向距离，Stab表示稳定度。中间值取平均值得出。
    Public Function DiffuseParameterZ15(ByVal x2 As Double, ByVal Stab As String) As Double

        Dim A2 As Double '扩散系数
        Dim r2 As Double '扩散系数
        If Stab = "A" Then
            If x2 > 0 And x2 <= 300 Then
                A2 = 1.12154
                r2 = 0.0799904
            ElseIf x2 > 300 And x2 <= 500 Then
                A2 = 1.5136
                r2 = 0.00854771
            ElseIf x2 > 500 Then
                A2 = 2.10881
                r2 = 0.000211545
            End If
        ElseIf Stab = "A-B" Then
            If x2 > 0 And x2 <= 300 Then
                A2 = 1.0429875
                r2 = 0.1035902
            ElseIf x2 > 300 And x2 <= 500 Then
                A2 = 1.2390175
                r2 = 0.067868855
            ElseIf x2 > 500 Then
                A2 = 1.601185
                r2 = 0.028618323
            End If
        ElseIf Stab = "B" Then
            If x2 > 0 And x2 <= 500 Then
                A2 = 0.964435
                r2 = 0.12719
            ElseIf x2 > 500 Then
                A2 = 1.09356
                r2 = 0.0570251
            End If
        ElseIf Stab = "B-C" Then
            If x2 > 0 And x2 <= 500 Then
                A2 = 0.941015
                r2 = 0.114682
            ElseIf x2 > 500 Then
                A2 = 1.0077
                r2 = 0.0757182
            End If
        ElseIf Stab = "C" Then
            If x2 > 0 Then
                A2 = 0.917595
                r2 = 0.106803
            End If
        ElseIf Stab = "C-D" Then
            If x2 > 0 And x2 <= 2000 Then
                A2 = 0.838628
                r2 = 0.126152
            ElseIf x2 > 2000 And x2 <= 10000 Then
                A2 = 0.75641
                r2 = 0.235667
            ElseIf x2 > 10000 Then
                A2 = 0.815575
                r2 = 0.136659
            End If
        ElseIf Stab = "D" Then
            If x2 > 0 And x2 <= 1000 Then
                A2 = 0.826212
                r2 = 0.104634
            ElseIf x2 > 1000 And x2 <= 10000 Then
                A2 = 0.632023
                r2 = 0.400167
            ElseIf x2 > 10000 Then
                A2 = 0.55536
                r2 = 0.810763
            End If
        ElseIf Stab = "D-E" Then
            If x2 > 0 And x2 <= 2000 Then
                A2 = 0.776864
                r2 = 0.111771
            ElseIf x2 > 2000 And x2 <= 10000 Then
                A2 = 0.572347
                r2 = 0.528992
            ElseIf x2 > 10000 Then
                A2 = 0.499149
                r2 = 1.0381
            End If
        ElseIf Stab = "E" Then
            If x2 > 0 And x2 <= 1000 Then
                A2 = 0.78837
                r2 = 0.0927529
            ElseIf x2 > 1000 And x2 <= 10000 Then
                A2 = 0.565188
                r2 = 0.433384
            ElseIf x2 > 10000 Then
                A2 = 0.414743
                r2 = 1.73241
            End If
        ElseIf Stab = "F" Then
            If x2 > 0 And x2 <= 1000 Then
                A2 = 0.7844
                r2 = 0.0620765
            ElseIf x2 > 1000 And x2 <= 10000 Then
                A2 = 0.525969
                r2 = 0.370015
            ElseIf x2 > 10000 Then
                A2 = 0.322659
                r2 = 2.40691
            End If
        End If
        DiffuseParameterZ15 = r2 * x2 ^ A2
    End Function

    '根据风速求回归系数r01，对于A-B、B-C、C-D、D-E稳定度下的参数按内插法取平均值
    Public Function r01(ByVal u As Double, ByVal Stab As String) As Double
        If u < 0.5 Then
            If Stab = "A" Then
                r01 = 0.93
            ElseIf Stab = "A-B" Then
                r01 = 0.845
            ElseIf Stab = "B" Then
                r01 = 0.76
            ElseIf Stab = "B-C" Then
                r01 = (0.76 + 0.55) / 2
            ElseIf Stab = "C" Then
                r01 = 0.55
            ElseIf Stab = "C-D" Then
                r01 = (0.55 + 0.47) / 2
            ElseIf Stab = "D" Then
                r01 = 0.47
            ElseIf Stab = "D-E" Then
                r01 = (0.47 + 0.44) / 2
            ElseIf Stab = "E" Then
                r01 = 0.44
            ElseIf Stab = "F" Then
                r01 = 0.44
            End If
        ElseIf u >= 0.5 And u < 1.5 Then
            If Stab = "A" Then
                r01 = 0.76
            ElseIf Stab = "A-B" Then
                r01 = 0.66
            ElseIf Stab = "B" Then
                r01 = 0.56
            ElseIf Stab = "B-C" Then
                r01 = (0.56 + 0.35) / 2
            ElseIf Stab = "C" Then
                r01 = 0.35
            ElseIf Stab = "C-D" Then
                r01 = (0.35 + 0.27) / 2
            ElseIf Stab = "D" Then
                r01 = 0.27
            ElseIf Stab = "D-E" Then
                r01 = (0.27 + 0.24) / 2
            ElseIf Stab = "E" Then
                r01 = 0.24
            ElseIf Stab = "F" Then
                r01 = 0.24
            End If
        End If
    End Function

    '根据风速求回归系数r02，与风速大小无关。对于A-B、B-C、C-D、D-E稳定度下的参数按内插法取平均值
    Public Function r02(ByVal u As Double, ByVal Stab As String) As Double
        If Stab = "A" Then
            r02 = 1.57
        ElseIf Stab = "A-B" Then
            r02 = 1.02
        ElseIf Stab = "B" Then
            r02 = 0.47
        ElseIf Stab = "B-C" Then
            r02 = (0.47 + 0.21) / 2
        ElseIf Stab = "C" Then
            r02 = 0.21
        ElseIf Stab = "C-D" Then
            r02 = (0.21 + 0.12) / 2
        ElseIf Stab = "D" Then
            r02 = 0.12
        ElseIf Stab = "D-E" Then
            r02 = (0.12 + 0.07) / 2
        ElseIf Stab = "E" Then
            r02 = 0.07
        ElseIf Stab = "F" Then
            r02 = 0.05
        End If
    End Function

    '通过公式求排放源所在高度的风速，只适用于高度小于200m的情况。对于A-B、B-C、C-D、D-E稳定度下的参数按内插法取平均值
    Public Function UP(ByVal u10 As Double, ByVal z2 As Double, ByVal Ground As String, ByVal Stab As String) As Double
        Dim p As Double
        If Ground = "平原地区农村及城市远郊区" Then
            If Stab = "A" Then
                p = 0.07
            ElseIf Stab = "A-B" Then
                p = 0.07
            ElseIf Stab = "B" Then
                p = 0.07
            ElseIf Stab = "B-C" Then
                p = (0.07 + 0.1) / 2
            ElseIf Stab = "C" Then
                p = 0.1
            ElseIf Stab = "C-D" Then
                p = (0.1 + 0.15) / 2
            ElseIf Stab = "D" Then
                p = 0.15
            ElseIf Stab = "D-E" Then
                p = (0.15 + 0.25) / 2
            ElseIf Stab = "E" Or Stab = "F" Then
                p = 0.25
            End If
        ElseIf Ground = "工业区或城区" Or Ground = "丘陵山区的农村或城市" Then
            If Stab = "A" Then
                p = 0.1
            ElseIf Stab = "A-B" Then
                p = (0.1 + 0.15) / 2
            ElseIf Stab = "B" Then
                p = 0.15
            ElseIf Stab = "B-C" Then
                p = (0.15 + 0.2) / 2
            ElseIf Stab = "C" Then
                p = 0.2
            ElseIf Stab = "C-D" Then
                p = (0.2 + 0.25) / 2
            ElseIf Stab = "D" Then
                p = 0.25
            ElseIf Stab = "D-E" Then
                p = (0.25 + 0.3) / 2
            ElseIf Stab = "E" Or Stab = "F" Then
                p = 0.3
            End If
        End If
        UP = u10 * (z2 / 10) ^ p
    End Function

    '取样时间
    Public Function aySamplingTime(ByVal t1 As Double, ByVal t2 As Double, ByVal ay1 As Double) As Double
        Dim Q As Double
        If t2 >= 0.5 And t2 < 1 Then
            Q = 0.2
        ElseIf t2 >= 1 Then
            Q = 0.3
        End If
        aySamplingTime = ay1 * (t2 / t1) ^ Q
    End Function

    '取样时间
    Public Function rSamplingTime(ByVal t1 As Double, ByVal t2 As Double, ByVal r1 As Double) As Double
        Dim Q As Double
        If t2 >= 0.5 And t2 < 1 Then
            Q = 0.2
        ElseIf t2 >= 1 Then
            Q = 0.3
        End If
        rSamplingTime = r1 * (t2 / t1) ^ Q
    End Function

    ''' <summary>
    ''' 将绝对坐标转换为相对坐标，X轴转换
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="Direction"></param>
    ''' <param name="x0"></param>
    ''' <param name="y0"></param>
    ''' <param name="Angle360"></param>
    ''' <param name="WindType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CoordinateX(ByVal x As Double, ByVal y As Double, ByVal Direction As String, ByVal x0 As Double, ByVal y0 As Double, ByVal Angle360 As Double, ByVal WindType As Integer) As Double
        Dim Angle As Double
        If WindType = 0 Then
            If Direction = "N" Then
                Angle = 12 / 16 * 2 * PI
            ElseIf Direction = "NNE" Then
                Angle = 11 / 16 * 2 * PI
            ElseIf Direction = "NE" Then
                Angle = 10 / 16 * 2 * PI
            ElseIf Direction = "ENE" Then
                Angle = 9 / 16 * 2 * PI
            ElseIf Direction = "E" Then
                Angle = 8 / 16 * 2 * PI
            ElseIf Direction = "ESE" Then
                Angle = 7 / 16 * 2 * PI
            ElseIf Direction = "SE" Then
                Angle = 6 / 16 * 2 * PI
            ElseIf Direction = "SSE" Then
                Angle = 5 / 16 * 2 * PI
            ElseIf Direction = "S" Then
                Angle = 4 / 16 * 2 * PI
            ElseIf Direction = "SSW" Then
                Angle = 3 / 16 * 2 * PI
            ElseIf Direction = "SW" Then
                Angle = 2 / 16 * 2 * PI
            ElseIf Direction = "WSW" Then
                Angle = 1 / 16 * 2 * PI
            ElseIf Direction = "W" Then
                Angle = 0 / 16 * 2 * PI
            ElseIf Direction = "WNW" Then
                Angle = 15 / 16 * 2 * PI
            ElseIf Direction = "NW" Then
                Angle = 14 / 16 * 2 * PI
            ElseIf Direction = "NNW" Then
                Angle = 13 / 16 * 2 * PI
            End If
        ElseIf WindType = 1 Then
            Angle = (270 - Angle360) / 360 * 2 * PI
        End If

        CoordinateX = (x - x0) * System.Math.Cos(Angle) + (y - y0) * System.Math.Sin(Angle)

    End Function


    '将绝对坐标转换为相对坐标，Y轴转换
    Public Function CoordinateY(ByVal x As Double, ByVal y As Double, ByVal Direction As String, ByVal x0 As Double, ByVal y0 As Double, ByVal Angle360 As Double, ByVal WindType As Integer) As Double
        Dim Angle As Double
        If WindType = 0 Then
            If Direction = "N" Then
                Angle = 12 / 16 * 2 * PI
            ElseIf Direction = "NNE" Then
                Angle = 11 / 16 * 2 * PI
            ElseIf Direction = "NE" Then
                Angle = 10 / 16 * 2 * PI
            ElseIf Direction = "ENE" Then
                Angle = 9 / 16 * 2 * PI
            ElseIf Direction = "E" Then
                Angle = 8 / 16 * 2 * PI
            ElseIf Direction = "ESE" Then
                Angle = 7 / 16 * 2 * PI
            ElseIf Direction = "SE" Then
                Angle = 6 / 16 * 2 * PI
            ElseIf Direction = "SSE" Then
                Angle = 5 / 16 * 2 * PI
            ElseIf Direction = "S" Then
                Angle = 4 / 16 * 2 * PI
            ElseIf Direction = "SSW" Then
                Angle = 3 / 16 * 2 * PI
            ElseIf Direction = "SW" Then
                Angle = 2 / 16 * 2 * PI
            ElseIf Direction = "WSW" Then
                Angle = 1 / 16 * 2 * PI
            ElseIf Direction = "W" Then
                Angle = 0 / 16 * 2 * PI
            ElseIf Direction = "WNW" Then
                Angle = 15 / 16 * 2 * PI
            ElseIf Direction = "NW" Then
                Angle = 14 / 16 * 2 * PI
            ElseIf Direction = "NNW" Then
                Angle = 13 / 16 * 2 * PI
            End If
        ElseIf WindType = 1 Then
            Angle = (270 - Angle360) / 360 * 2 * PI
        End If
        CoordinateY = (y - y0) * System.Math.Cos(Angle) - (x - x0) * System.Math.Sin(Angle)
    End Function
    '变天条件下，多烟团模式,第i个烟团在tw时刻在(x,y,z)处的浓度，mg/m3；
    Public Function Cwi(ByVal Qi As Double, ByVal axeff As Double, ByVal ayeff As Double, ByVal azeff As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal xwi As Double, ByVal ywi As Double, ByVal He As Double)
        Dim dblx As Double '储存x轴向计算结果
        Dim dbly As Double '储存z轴向计算结果
        Dim dblz As Double '储存y轴向计算结果
        dblx = System.Math.Exp(-(x - xwi) ^ 2 / (2 * axeff ^ 2))
        dbly = System.Math.Exp(-(y - ywi) ^ 2 / (2 * ayeff ^ 2))
        dblz = System.Math.Exp(-(z - He) ^ 2 / (2 * azeff ^ 2)) + System.Math.Exp(-(z + He) ^ 2 / (2 * azeff ^ 2))
        Cwi = Qi / ((2 * PI) ^ 1.5 * axeff * ayeff * azeff) * dblx * dbly * dblz
    End Function
    'w时段沿x方向的等效扩散参数（m）
    Public Function axeff(ByVal w As Integer) As Double

    End Function


    ''' <summary>
    ''' 非正常排放模式，含点源、面源、体源。计算过程考虑了重气体对扩散参数的修正
    ''' </summary>
    ''' <param name="u10">10m高处的风速</param>
    ''' <param name="u2">泄漏源高度处的风速</param>
    ''' <param name="He">有效高度</param>
    ''' <param name="Stab">稳定度</param>
    ''' <param name="SamplingTime">取样时间</param>
    ''' <param name="DurationT">泄漏时间</param>
    ''' <param name="ForecastTime">预测时间</param>
    ''' <param name="Q">泄漏速率</param>
    ''' <param name="x">预测点下风向距离</param>
    ''' <param name="y">预测点垂直下风向距离</param>
    ''' <param name="z">预测点高度</param>
    ''' <param name="GroundCharacter">地面特征</param>
    ''' <param name="S">底面积</param>
    ''' <param name="Thickness">厚度</param>
    ''' <param name="HeavyB">重气体对象的直径或橫向距离</param>
    ''' <param name="HeavyH">重气体对象的高度</param>
    ''' <param name="HeavyT">重气体对象的最大持续时间</param>
    ''' <param name="HeavyX">重气体对象的在预测时间时最大持续距离</param>
    ''' <param name="IsHeavy">是否按重气体考虑</param>
    ''' <param name="ModolType">重气扩散的模型类型，1表示瞬时，2表示连续</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UnormalModelPSV(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal DurationT As Double, ByVal ForecastTime As Double, ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String, ByVal S As Double, ByVal Thickness As Double, ByVal HeavyB As Double, ByVal HeavyH As Double, ByVal HeavyT As Double, ByVal HeavyX As Double, ByVal IsHeavy As Boolean, ByVal ModolType As Integer) As Double
        '-----------------------------------增加了重气体模型

        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double
        Dim ay As Double
        Dim az As Double
        Dim D As Double '体源的直径
        D = Math.Sqrt(S / PI) * 2
        Dim t0 As Double '初始时刻
        If u10 < CDbl(CStr(1.5)) Then

            '计算0.5小时回归系数
            dblR01 = r01(u10, Stab)
            dblR02 = r02(u10, Stab)
            '计算相应取样时间的回归系数
            dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
            dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)

            If Thickness > 0 Then            '如果是体源，计算初始时间
                t0 = ((D * D * Thickness) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3
                '用时和距离进行修正
                x = x + t0 * u2
                ForecastTime = ForecastTime + t0

                If IsHeavy = True Then '瞬时重气体扩散----------------------------------------------------------

                    If ModolType = 1 Then
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                        If ForecastTime <= HeavyT Then
                            '修改重气体模型的有效高度
                            ay = dblR01 * (t0)
                            ax = ay
                            az = dblR02 * (t0)
                        Else
                            ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                            ax = ay
                            az = dblR02 * (t0 + (ForecastTime - HeavyT))
                        End If
                        dblR01 = ay / (ForecastTime)
                        dblR02 = az / (ForecastTime)

                    Else '连续重气体模型。当风速小于1.5时，暂时不能用这个模型。

                        '用时和距离进行修正
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                        If ForecastTime <= HeavyT Then
                            '修改重气体模型的有效高度
                            ay = dblR01 * (t0)
                            ax = ay
                            az = dblR02 * (t0)
                        Else
                            ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                            ax = ay
                            az = dblR02 * (t0 + (ForecastTime - HeavyT))
                        End If
                    End If
                    He = HeavyH / 2
                End If
            Else '否则是面源或点源
                ay = dblR01 * ForecastTime
                ax = ay
                az = dblR02 * ForecastTime
                If IsHeavy = True Then '瞬时重气体扩散----------------------------------------------------------

                    If ModolType = 1 Then
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                        If ForecastTime <= HeavyT Then
                            '修改重气体模型的有效高度
                            ay = dblR01 * (t0)
                            ax = ay
                            az = dblR02 * (t0)
                        Else
                            ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                            ax = ay
                            az = dblR02 * (t0 + (ForecastTime - HeavyT))
                        End If
                        dblR01 = ay / (ForecastTime)
                        dblR02 = az / (ForecastTime)

                    Else '连续重气体模型。当风速小于1.5时，暂时不能用这个模型。

                        '用时和距离进行修正
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                        If ForecastTime <= HeavyT Then
                            '修改重气体模型的有效高度
                            ay = dblR01 * (t0)
                            ax = ay
                            az = dblR02 * (t0)
                        Else
                            ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                            ax = ay
                            az = dblR02 * (t0 + (ForecastTime - HeavyT))
                        End If
                    End If
                    He = HeavyH / 2
                End If
            End If
            '用风速<1.5mg/s的非正常排放模式计算
            UnormalModelPSV = UnormalModal0_15(Q, x, y, z, ForecastTime, DurationT, u2, 0, He, dblR01, dblR02)

        ElseIf u10 >= 1.5 And x > 0.01 Then  '当风速>=1.5m/s时，预测距离必须>0
            '如果风速＞＝1.5，用有风模式计算,采用点源修正法
            '计算0.5小时取样时间扩散参数
            If S = 0 Then
                ay = DiffuseY15(x, Stab, GroundCharacter) 'y轴扩散参数
                az = DiffuseZ15(x, Stab, GroundCharacter) 'Z轴扩散参数
                '计算相应取样时间的扩散参数
                ay = aySamplingTime(0.5, SamplingTime, ay)
                ax = ay
                If IsHeavy = True Then '重气体修正---------------------------------------
                    Dim dxx As Double = 0
                    If x < HeavyX Then
                        dxx = 0
                    Else
                        dxx = x - HeavyX
                    End If
                    ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y轴扩散参数
                    az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
                    '计算相应取样时间的扩散参数
                    ay = aySamplingTime(0.5, SamplingTime, ay)
                    '点源修正后的扩散参数
                    ax = ay

                    '修改重气体泄漏源的有效源高为重气体的高度的一半
                    He = HeavyH / 2
                    '并对风速进行修正，取10m处的风速为U2
                    u2 = u10
                End If
            ElseIf S > 0 And Thickness = 0 Then
                '面源
                ay = DiffuseY15(x, Stab, GroundCharacter)  'y轴扩散参数
                ax = ay
                az = DiffuseZ15(x, Stab, GroundCharacter) + He / 2.15 'Z轴扩散参数，点源修正
                '计算相应取样时间的扩散参数
                ay = aySamplingTime(0.5, SamplingTime, ay)
                ax = ay
                '点源修正后的扩散参数
                ay = ay + D / 4.3  'y轴扩散参数
                If IsHeavy = True Then '重气体修正---------------------------------------
                    Dim dxx As Double = 0
                    If x < HeavyX Then
                        dxx = 0
                    Else
                        dxx = x - HeavyX
                    End If
                    ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y轴扩散参数
                    az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
                    '计算相应取样时间的扩散参数
                    ay = aySamplingTime(0.5, SamplingTime, ay)
                    '点源修正后的扩散参数
                    ax = ay

                    '修改重气体泄漏源的有效源高为重气体的高度的一半
                    He = HeavyH / 2
                    '并对风速进行修正，取10m处的风速为U2
                    u2 = u10
                End If

            Else
                ay = DiffuseY15(x, Stab, GroundCharacter)  'y轴扩散参数
                ax = ay
                az = DiffuseZ15(x, Stab, GroundCharacter) + Thickness / 4.3 'Z轴扩散参数，点源修正
                '计算相应取样时间的扩散参数
                ay = aySamplingTime(0.5, SamplingTime, ay)
                ax = ay
                '点源修正后的扩散参数
                ay = ay + D / 4.3  'y轴扩散参数

                If IsHeavy = True Then '重气体修正---------------------------------------
                    Dim dxx As Double = 0
                    If x < HeavyX Then
                        dxx = 0
                    Else
                        dxx = x - HeavyX
                    End If
                    ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y轴扩散参数
                    az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
                    '计算相应取样时间的扩散参数
                    ay = aySamplingTime(0.5, SamplingTime, ay)
                    '点源修正后的扩散参数
                    ax = ay

                    '修改重气体泄漏源的有效源高为重气体的高度的一半
                    He = HeavyH / 2
                    '并对风速进行修正，取10m处的风速为U2
                    u2 = u10
                End If
            End If
            '用风速>=1.5mg/s的非正常排放模式计算
            UnormalModelPSV = UnormalModal15(Q, x, y, z, ForecastTime, DurationT, u2, He, ax, ay, az)
        End If
    End Function

    '单一气象条件下，多烟团，短时泄漏排放模式计算，含点源、面源体源
    Public Function MultiFlogPSV(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal IntervalT As Double, ByVal ForecastTime As Double, ByVal MultiSource As MultiLeakSorce, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String, ByVal HeavyB As Double, ByVal HeavyH As Double, ByVal HeavyT As Double, ByVal HeavyX As Double, ByVal IsHeavy As Boolean, ByVal ModolType As Integer) As Double
        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double = 0
        Dim ay As Double = 0
        Dim az As Double = 0
        Dim D As Double '体源的直径
        Dim t0 As Double '初始时刻

        '计算烟团排放持续时间到预测时间之差
        Dim Ni As Integer
        Ni = 0 '烟团个数
        Dim dblForeTime As Double
        dblForeTime = ForecastTime - Ni * IntervalT

        Dim Ci As Double = 0 '每个烟团的贡献浓度
        Dim CZ As Double = 0 '所有烟团的贡献浓度

        While Ni <= MultiSource.n - 1 And dblForeTime > 0
            If u10 < 1.5 Then
                '如果风速＜1.5，计算小风时的扩散参数。因为采用了多烟团模式，计算小风时的扩散参数是时间的函数，必有在循环内计算出每个烟团的扩散参数
                '计算0.5小时回归系数
                If dblR01 < 1.0E-40 And dblR02 < 1.0E-40 Then
                    dblR01 = r01(u10, Stab)
                    dblR02 = r02(u10, Stab)
                    '计算相应取样时间的回归系数
                    dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
                    dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
                End If
                If MultiSource.Thickness(Ni + 1) > 0 Then            '如果是体源，计算初始时间
                    D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
                    t0 = ((D * D * MultiSource.Thickness(Ni + 1)) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3
                    '计算相应预测时间的扩散参数,修正后
                    ay = dblR01 * (dblForeTime + t0)
                    ax = ay
                    az = dblR02 * (dblForeTime + t0)
                    If IsHeavy = True Then '瞬时重气体扩散----------------------------------------------------------

                        If ModolType = 1 Then
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                            If ForecastTime <= HeavyT Then
                                '修改重气体模型的有效高度
                                ay = dblR01 * (t0)
                                ax = ay
                                az = dblR02 * (t0)
                            Else
                                ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                                ax = ay
                                az = dblR02 * (t0 + (ForecastTime - HeavyT))
                            End If
                            dblR01 = ay / (ForecastTime)
                            dblR02 = az / (ForecastTime)

                        Else '连续重气体模型。当风速小于1.5时，暂时不能用这个模型。

                            '用时和距离进行修正
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                            If ForecastTime <= HeavyT Then
                                '修改重气体模型的有效高度
                                ay = dblR01 * (t0)
                                ax = ay
                                az = dblR02 * (t0)
                            Else
                                ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                                ax = ay
                                az = dblR02 * (t0 + (ForecastTime - HeavyT))
                            End If
                        End If
                        He = HeavyH / 2
                    End If
                Else '否则是面源或点源
                    ay = dblR01 * dblForeTime
                    ax = ay
                    az = dblR02 * dblForeTime
                    If IsHeavy = True Then '瞬时重气体扩散----------------------------------------------------------

                        If ModolType = 1 Then
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                            If ForecastTime <= HeavyT Then
                                '修改重气体模型的有效高度
                                ay = dblR01 * (t0)
                                ax = ay
                                az = dblR02 * (t0)
                            Else
                                ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                                ax = ay
                                az = dblR02 * (t0 + (ForecastTime - HeavyT))
                            End If
                            dblR01 = ay / (ForecastTime)
                            dblR02 = az / (ForecastTime)

                        Else '连续重气体模型。当风速小于1.5时，暂时不能用这个模型。

                            '用时和距离进行修正
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
                            If ForecastTime <= HeavyT Then
                                '修改重气体模型的有效高度
                                ay = dblR01 * (t0)
                                ax = ay
                                az = dblR02 * (t0)
                            Else
                                ay = dblR01 * (t0 + (ForecastTime - HeavyT))
                                ax = ay
                                az = dblR02 * (t0 + (ForecastTime - HeavyT))
                            End If
                        End If
                        He = HeavyH / 2
                    End If
                End If
                '计算每个烟团的贡献浓度
                Ci = GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)
                '叠加
                CZ = CZ + Ci
            ElseIf u10 >= 1.5 And x > 0.01 Then
                '如果风速＞＝1.5，用有风模式计算
                '计算0.5小时取样时间扩散参数
                If MultiSource.Si(Ni + 1) = 0 Then
                    If ax <= 1.0E-40 And ay <= 1.0E-40 Then '如果扩散参数为0，则要重新计算扩散参数，否则不需要再进行计算。这样做可以节省时间
                        If IsHeavy = True Then '重气体修正---------------------------------------
                            Dim dxx As Double = 0
                            If x < HeavyX Then
                                dxx = 0
                            Else
                                dxx = x - HeavyX
                            End If
                            ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y轴扩散参数
                            az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
                            '计算相应取样时间的扩散参数
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            '点源修正后的扩散参数
                            ax = ay

                            '修改重气体泄漏源的有效源高为重气体的高度的一半
                            He = HeavyH / 2
                            '并对风速进行修正，取10m处的风速为U2
                            u2 = u10
                        Else '非重气体
                            ay = DiffuseY15(x, Stab, GroundCharacter) 'y轴扩散参数
                            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z轴扩散参数
                            '计算相应取样时间的扩散参数
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            ax = ay
                        End If
                    End If

                ElseIf MultiSource.Si(Ni + 1) > 0 And MultiSource.Thickness(Ni + 1) = 0 Then


                    If IsHeavy = True Then '重气体修正---------------------------------------
                        If ax = 0 And ay = 0 Then '如果扩散参数为0，则要重新计算扩散参数，否则不需要再进行计算。这样做可以节省时间
                            Dim dxx As Double = 0
                            If x < HeavyX Then
                                dxx = 0
                            Else
                                dxx = x - HeavyX
                            End If
                            ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y轴扩散参数
                            az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
                            '计算相应取样时间的扩散参数
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            '点源修正后的扩散参数
                            ax = ay

                            '修改重气体泄漏源的有效源高为重气体的高度的一半
                            He = HeavyH / 2
                            '并对风速进行修正，取10m处的风速为U2
                            u2 = u10
                        End If
                    Else '非重气体
                        If ax = 0 And ay = 0 Then '如果扩散参数为0，则要重新计算扩散参数，否则不需要再进行计算。这样做可以节省时间
                            '面源
                            ay = DiffuseY15(x, Stab, GroundCharacter)  'y轴扩散参数
                            ax = ay
                            az = DiffuseZ15(x, Stab, GroundCharacter) + He / 2.15 'Z轴扩散参数，点源修正
                            '计算相应取样时间的扩散参数
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            ax = ay
                            '点源修正后的扩散参数
                            D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
                            ay = ay + D / 4.3  'y轴扩散参数
                        End If
                    End If
                Else

                    If IsHeavy = True Then '重气体修正---------------------------------------
                        If ax = 0 And ay = 0 Then '如果扩散参数为0，则要重新计算扩散参数，否则不需要再进行计算。这样做可以节省时间
                            Dim dxx As Double = 0
                            If x < HeavyX Then
                                dxx = 0
                            Else
                                dxx = x - HeavyX
                            End If
                            ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y轴扩散参数
                            az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
                            '计算相应取样时间的扩散参数
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            '点源修正后的扩散参数
                            ax = ay

                            '修改重气体泄漏源的有效源高为重气体的高度的一半
                            He = HeavyH / 2
                            '并对风速进行修正，取10m处的风速为U2
                            u2 = u10
                        End If
                    Else '非重气体
                        If ax = 0 And ay = 0 Then '如果扩散参数为0，则要重新计算扩散参数，否则不需要再进行计算。这样做可以节省时间
                            ay = DiffuseY15(x, Stab, GroundCharacter)  'y轴扩散参数
                            ax = ay
                            az = DiffuseZ15(x, Stab, GroundCharacter) + MultiSource.Thickness(Ni + 1) / 4.3 'Z轴扩散参数，点源修正
                            '计算相应取样时间的扩散参数
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            ax = ay
                            '点源修正后的扩散参数
                            D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
                            ay = ay + D / 4.3  'y轴扩散参数
                        End If
                    End If
                End If
                '叠加
                CZ += GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)

            End If
            Ni = Ni + 1
            '计算预测时间与烟团排放的时间之差
            dblForeTime = ForecastTime - Ni * IntervalT
        End While
        Return CZ


        'Dim dblR01 As Double
        'Dim dblR02 As Double
        'Dim ax As Double
        'Dim ay As Double
        'Dim az As Double
        'Dim D As Double '体源的直径
        'Dim t0 As Double '初始时刻

        ''计算烟团排放持续时间到预测时间之差
        'Dim Ni As Integer
        'Ni = 0 '烟团个数
        'Dim dblForeTime As Double
        'dblForeTime = ForecastTime - Ni * IntervalT

        'Dim Ci As Double = 0 '每个烟团的贡献浓度
        'Dim CZ As Double = 0 '所有烟团的贡献浓度

        'While Ni <= MultiSource.n - 1 And dblForeTime > 0
        '    If u10 < 1.5 Then
        '        '如果风速＜1.5，计算小风时的扩散参数。因为采用了多烟团模式，计算小风时的扩散参数是时间的函数，必有在循环内计算出每个烟团的扩散参数
        '        '计算0.5小时回归系数
        '        dblR01 = r01(u10, Stab)
        '        dblR02 = r02(u10, Stab)
        '        '计算相应取样时间的回归系数
        '        dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
        '        dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
        '        If MultiSource.Thickness(Ni + 1) > 0 Then            '如果是体源，计算初始时间
        '            D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
        '            t0 = ((D * D * MultiSource.Thickness(Ni + 1)) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3
        '            '计算相应预测时间的扩散参数,修正后
        '            ay = dblR01 * (dblForeTime + t0)
        '            ax = ay
        '            az = dblR02 * (dblForeTime + t0)
        '            If IsHeavy = True Then '瞬时重气体扩散----------------------------------------------------------

        '                If ModolType = 1 Then
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
        '                    If ForecastTime <= HeavyT Then
        '                        '修改重气体模型的有效高度
        '                        ay = dblR01 * (t0)
        '                        ax = ay
        '                        az = dblR02 * (t0)
        '                    Else
        '                        ay = dblR01 * (t0 + (ForecastTime - HeavyT))
        '                        ax = ay
        '                        az = dblR02 * (t0 + (ForecastTime - HeavyT))
        '                    End If
        '                    dblR01 = ay / (ForecastTime)
        '                    dblR02 = az / (ForecastTime)

        '                Else '连续重气体模型。当风速小于1.5时，暂时不能用这个模型。

        '                    '用时和距离进行修正
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
        '                    If ForecastTime <= HeavyT Then
        '                        '修改重气体模型的有效高度
        '                        ay = dblR01 * (t0)
        '                        ax = ay
        '                        az = dblR02 * (t0)
        '                    Else
        '                        ay = dblR01 * (t0 + (ForecastTime - HeavyT))
        '                        ax = ay
        '                        az = dblR02 * (t0 + (ForecastTime - HeavyT))
        '                    End If
        '                End If
        '                He = HeavyH / 2
        '            End If
        '        Else '否则是面源或点源
        '            ay = dblR01 * dblForeTime
        '            ax = ay
        '            az = dblR02 * dblForeTime
        '            If IsHeavy = True Then '瞬时重气体扩散----------------------------------------------------------

        '                If ModolType = 1 Then
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
        '                    If ForecastTime <= HeavyT Then
        '                        '修改重气体模型的有效高度
        '                        ay = dblR01 * (t0)
        '                        ax = ay
        '                        az = dblR02 * (t0)
        '                    Else
        '                        ay = dblR01 * (t0 + (ForecastTime - HeavyT))
        '                        ax = ay
        '                        az = dblR02 * (t0 + (ForecastTime - HeavyT))
        '                    End If
        '                    dblR01 = ay / (ForecastTime)
        '                    dblR02 = az / (ForecastTime)

        '                Else '连续重气体模型。当风速小于1.5时，暂时不能用这个模型。

        '                    '用时和距离进行修正
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '计算出重气
        '                    If ForecastTime <= HeavyT Then
        '                        '修改重气体模型的有效高度
        '                        ay = dblR01 * (t0)
        '                        ax = ay
        '                        az = dblR02 * (t0)
        '                    Else
        '                        ay = dblR01 * (t0 + (ForecastTime - HeavyT))
        '                        ax = ay
        '                        az = dblR02 * (t0 + (ForecastTime - HeavyT))
        '                    End If
        '                End If
        '                He = HeavyH / 2
        '            End If
        '        End If
        '        '计算每个烟团的贡献浓度
        '        Ci = GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)
        '        '叠加
        '        CZ = CZ + Ci
        '    ElseIf u10 >= 1.5 And x > 0.01 Then
        '        '如果风速＞＝1.5，用有风模式计算
        '        '计算0.5小时取样时间扩散参数
        '        D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2

        '        If MultiSource.Si(Ni + 1) = 0 Then
        '            ay = DiffuseY15(x, Stab, GroundCharacter) 'y轴扩散参数
        '            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z轴扩散参数
        '            '计算相应取样时间的扩散参数
        '            ay = aySamplingTime(0.5, SamplingTime, ay)
        '            ax = ay

        '            If IsHeavy = True Then '重气体修正---------------------------------------
        '                Dim dxx As Double = 0
        '                If x < HeavyX Then
        '                    dxx = 0
        '                Else
        '                    dxx = x - HeavyX
        '                End If
        '                ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y轴扩散参数
        '                az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
        '                '计算相应取样时间的扩散参数
        '                ay = aySamplingTime(0.5, SamplingTime, ay)
        '                '点源修正后的扩散参数
        '                ax = ay

        '                '修改重气体泄漏源的有效源高为重气体的高度的一半
        '                He = HeavyH / 2
        '                '并对风速进行修正，取10m处的风速为U2
        '                u2 = u10
        '            End If '重气体修正结束---------------------------------------

        '        ElseIf MultiSource.Si(Ni + 1) > 0 And MultiSource.Thickness(Ni + 1) = 0 Then
        '            '面源
        '            ay = DiffuseY15(x, Stab, GroundCharacter)  'y轴扩散参数
        '            ax = ay
        '            az = DiffuseZ15(x, Stab, GroundCharacter) + He / 2.15 'Z轴扩散参数，点源修正
        '            '计算相应取样时间的扩散参数
        '            ay = aySamplingTime(0.5, SamplingTime, ay)
        '            ax = ay
        '            '点源修正后的扩散参数
        '            ay = ay + D / 4.3  'y轴扩散参数

        '            If IsHeavy = True Then '重气体修正---------------------------------------
        '                Dim dxx As Double = 0
        '                If x < HeavyX Then
        '                    dxx = 0
        '                Else
        '                    dxx = x - HeavyX
        '                End If
        '                ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y轴扩散参数
        '                az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
        '                '计算相应取样时间的扩散参数
        '                ay = aySamplingTime(0.5, SamplingTime, ay)
        '                '点源修正后的扩散参数
        '                ax = ay

        '                '修改重气体泄漏源的有效源高为重气体的高度的一半
        '                He = HeavyH / 2
        '                '并对风速进行修正，取10m处的风速为U2
        '                u2 = u10
        '            End If '重气体修正结束---------------------------------------
        '        Else
        '            ay = DiffuseY15(x, Stab, GroundCharacter)  'y轴扩散参数
        '            ax = ay
        '            az = DiffuseZ15(x, Stab, GroundCharacter) + MultiSource.Thickness(Ni + 1) / 4.3 'Z轴扩散参数，点源修正
        '            '计算相应取样时间的扩散参数
        '            ay = aySamplingTime(0.5, SamplingTime, ay)
        '            ax = ay
        '            '点源修正后的扩散参数
        '            ay = ay + D / 4.3  'y轴扩散参数

        '            If IsHeavy = True Then '重气体修正---------------------------------------
        '                Dim dxx As Double = 0
        '                If x < HeavyX Then
        '                    dxx = 0
        '                Else
        '                    dxx = x - HeavyX
        '                End If
        '                ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y轴扩散参数
        '                az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z轴扩散参数，点源修正
        '                '计算相应取样时间的扩散参数
        '                ay = aySamplingTime(0.5, SamplingTime, ay)
        '                '点源修正后的扩散参数
        '                ax = ay

        '                '修改重气体泄漏源的有效源高为重气体的高度的一半
        '                He = HeavyH / 2
        '                '并对风速进行修正，取10m处的风速为U2
        '                u2 = u10
        '            End If '重气体修正结束---------------------------------------
        '        End If
        '        '计算每个烟团的贡献浓度
        '        Ci = GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)
        '        '叠加
        '        CZ = CZ + Ci
        '    End If
        '    Ni = Ni + 1
        '    '计算预测时间与烟团排放的时间之差
        '    dblForeTime = ForecastTime - Ni * IntervalT
        'End While
        'MultiFlogPSV = CZ
    End Function


    ''' <summary>
    ''' 为单烟团公式的反公式。该公式主要用于计算下风下某一距离点x0的浓度扩散至1000000分这1时的扩散距离|x-x0|。这个距离用来计算下风下浓度计算点的间距。如果小于0则返回负值。
    ''' </summary>
    ''' <param name="x">下风向距离</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DX_G(ByVal x As Double) As Double
        Dim az As Double
        az = DiffuseZ15(x, "F", "平原地区农村及城市远郊区") 'Z轴扩散参数。F稳定度下的扩散参数作为计算的依据
        Return az * 2
    End Function
End Module
