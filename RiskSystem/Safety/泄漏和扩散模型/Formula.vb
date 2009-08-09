Public Module Formula

    '��һ���������¸�˹������ģ��
    Public Function GaussFog(ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal t As Double, ByVal u As Double, ByVal He As Double, ByVal ax As Double, ByVal ay As Double, ByVal az As Double) As Double
        Dim dblx As Double '����x���������
        Dim dbly As Double '����z���������
        Dim dblz As Double '����y���������
        dblx = System.Math.Exp(-(x - u * t) * (x - u * t) / (2 * ax * ax))
        dbly = System.Math.Exp(-y * y / (2 * ay * ay))
        dblz = System.Math.Exp(-(z - He) * (z - He) / (2 * az * az)) + System.Math.Exp(-(z + He) * (z + He) / (2 * az * az))
        Return Q / (Math.Sqrt((2 * PI) * (2 * PI) * (2 * PI)) * ax * ay * az) * dblx * dbly * dblz
    End Function

    '�������ŷ�ģʽ�����٣���1.5,����TsΪ�������ŷ�ʱ�䣬tΪԤ��ʱ��
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

    '�������ŷ�ģʽ�����٣�1.5������TsΪ�������ŷ�ʱ�䣬tΪԤ��ʱ�䣬uΪx����٣�vΪy�����
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
        H = He - z '���z��Ϊ0������ЧԴ��ΪH=he-z����
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
        'H = He - z '���z��Ϊ0������ЧԴ��ΪH=he-z����
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

    '��һ���������µ����ţ�˲ʱй©ģʽ
    Public Function SingleFlogModel(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal ForecastTime As Double, ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String) As Double
        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double
        Dim ay As Double
        Dim az As Double
        '����10�״��ķ���ѡȡ��Ӧ�ļ���
        If u10 < 1.5 Then
            '����0.5Сʱ�ع�ϵ��
            dblR01 = r01(u10, Stab)
            dblR02 = r02(u10, Stab)
            '������Ӧȡ��ʱ��Ļع�ϵ��
            dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
            dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
            '������Ӧȡ��ʱ�����ɢ����
            ay = dblR01 * ForecastTime
            ax = ay
            az = dblR02 * ForecastTime
            '�õ�ԴԤ��ģʽ����
            SingleFlogModel = GaussFog(Q, x, y, z, ForecastTime, u2, He, ax, ay, az) '�ø�˹ģʽ����
        ElseIf u10 >= 1.5 And x > 0.01 Then  '������>=1.5m/sʱ��Ԥ��������>0
            '������٣���1.5�����з�ģʽ����
            '����0.5Сʱȡ��ʱ����ɢ����
            ay = DiffuseY15(x, Stab, GroundCharacter) 'y����ɢ����
            ax = ay
            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z����ɢ����
            '������Ӧȡ��ʱ�����ɢ����
            ay = aySamplingTime(0.5, SamplingTime, ay)
            ax = ay
            '�õ�ԴԤ��ģʽ����
            SingleFlogModel = GaussFog(Q, x, y, z, ForecastTime, u2, He, ax, ay, az) '�ø�˹ģʽ����
        End If
    End Function

    '��һ���������£������ţ���ʱй©�ŷ�ģʽ����
    Public Function MultiFlogModel(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal DurationT As Double, ByVal ForecastTime As Double, ByVal Q As Double, ByVal count As Short, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String) As Double
        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double
        Dim ay As Double
        Dim az As Double

        If u10 >= 1.5 And x > 0.01 Then '������>=1.5ʱ����ɢ�����Ǿ���ĺ�������˿�����ѭ������㣬�������Լ��ټ�����
            '������٣���1.5�����з�ģʽ����
            '����0.5Сʱȡ��ʱ����ɢ����
            ay = DiffuseY15(x, Stab, GroundCharacter) 'y����ɢ����
            ax = ay
            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z����ɢ����
            '������Ӧȡ��ʱ�����ɢ����
            ay = aySamplingTime(0.5, SamplingTime, ay)
            ax = ay
        End If

        '���������ŷų���ʱ�䵽Ԥ��ʱ��֮��
        Dim N As Short
        N = 0 '���Ÿ���
        Dim dblForeTime As Double
        dblForeTime = ForecastTime - N * DurationT / count
        '����ÿ�����ŵ��ŷ���
        Dim EveryQ As Double
        EveryQ = Q * DurationT / count
        Dim Ci As Double 'ÿ�����ŵĹ���Ũ��
        Ci = 0
        Dim CZ As Double '�������ŵĹ���Ũ��
        CZ = 0
        While N <= count - 1 And dblForeTime > 0
            If u10 < 1.5 Then
                '������٣�1.5������С��ʱ����ɢ��������Ϊ�����˶�����ģʽ������С��ʱ����ɢ������ʱ��ĺ�����������ѭ���ڼ����ÿ�����ŵ���ɢ����
                '����0.5Сʱ�ع�ϵ��
                dblR01 = r01(u10, Stab)
                dblR02 = r02(u10, Stab)
                '������Ӧȡ��ʱ��Ļع�ϵ��
                dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
                dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
                '������Ӧȡ��ʱ�����ɢ����
                ay = dblR01 * dblForeTime
                ax = ay
                az = dblR02 * dblForeTime
                '����ÿ�����ŵĹ���Ũ��
                Ci = GaussFog(EveryQ, x, y, z, dblForeTime, u2, He, ax, ay, az)
                '����
                CZ = CZ + Ci
            ElseIf u10 >= 1.5 And x > 1 Then
                '����ÿ�����ŵĹ���Ũ��
                Ci = GaussFog(EveryQ, x, y, z, dblForeTime, u2, He, ax, ay, az)
                '����
                CZ = CZ + Ci
            End If
            N = N + 1
            '����Ԥ��ʱ���������ŷŵ�ʱ��֮��
            dblForeTime = ForecastTime - N * DurationT / count
        End While
        MultiFlogModel = CZ

    End Function

    

    '���㲻��ȫ���꺯��ʹ�õĺ���
    Public Function F(ByVal t As Double) As Double
        F = 1 / System.Math.Sqrt(2 * 3.1415926) * System.Math.Exp(-t * t / 2)
    End Function

    '�ñ䲽����������ʽ���㲻��ȫ���꺯��
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
            If s2 > 1 - 0.0000000001 Then '���С�ھ�ȷ����ֵΪ1
                s2 = 1
            ElseIf s2 < 0.0000000001 Then '���С�ھ�ȷ����ֵΪ0
                s2 = 0
            End If

            NormalSchool = s2
        End If
    End Function

    '��ɢ�����ȶ����ἶ
    Public Function RiseStab(ByVal Stab As String, ByVal Ground As String) As String
        '���ݵ���ȷ���ȶ��ȣ��ȸ��ݵ��ν��ȶ����ἶ��
        '(1)ƽԭ����ũ�弰����Զ��������ɢ����ѡȡ�������£�A��A��B��B��B��C��C���ȶ���ֱ���ɱ�3-�ͱ�B4���㣬D��E��F���ȶ����������ȶ�������뼶���ɱ�B3�ͱ�B4���㡣D-E����û�����ȶ��ȣ����ἶ��
        '(2)��ҵ��������еĵ�Դ������ɢ����ѡȡ�������£�   A��B�����ἶ��C���ᵽB����D��E��F�����ȶ�������һ�����ٰ���B3�ͱ�B4���㡣
        '(3)����ɽ����ũ�����У�����ɢ����ѡȡ����ͬ��ҵ��

        If Ground = "ƽԭ����ũ�弰����Զ����" Then
            If Stab = "D" Then
                RiseStab = "C-D"
            ElseIf Stab = "E" Then
                RiseStab = "D-E"
            ElseIf Stab = "F" Then
                RiseStab = "E"
            Else
                RiseStab = Stab
            End If
        Else ' Ground = "��ҵ�������" Or Ground = "����ɽ����ũ������"
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


    '����Y�����ɢ����
    Public Function DiffuseY15(ByVal x As Double, ByVal Stab As String, ByVal Ground As String) As Double
        Dim strStab As String
        strStab = RiseStab(Stab, Ground) '�����ȶ��ȼ������ἶ
        DiffuseY15 = DiffuseParameterY15(x, strStab) '���ݲ���������ɢ����
    End Function

    '����Z�����ɢ����
    Public Function DiffuseZ15(ByVal x As Double, ByVal Stab As String, ByVal Ground As String) As Double
        Dim strStab As String
        strStab = RiseStab(Stab, Ground) '�����ȶ��ȼ������ἶ
        DiffuseZ15 = DiffuseParameterZ15(x, strStab) '���ݲ���������ɢ����
    End Function

    '���귽�������з�ʱY����ɢ���������٣���1.5��x1��ʾ�·�����룬Stab��ʾ�ȶ���
    Public Function DiffuseParameterY15(ByVal x1 As Double, ByVal Stab As String) As Double

        Dim A1 As Double '��ɢϵ��
        Dim r1 As Double '��ɢϵ��
        If Stab = "A" Then
            If x1 > 0 And x1 <= 1000 Then
                A1 = 0.901074
                r1 = 0.425809
            ElseIf x1 > 1000 Then
                A1 = 0.850934
                r1 = 0.602052
            End If
        ElseIf Stab = "A-B" Then   'ȡƽ��ֵ�ó�
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

    '���귽�������з�ʱZ����ɢ���������٣���1.5��x1��ʾ�·�����룬Stab��ʾ�ȶ��ȡ��м�ֵȡƽ��ֵ�ó���
    Public Function DiffuseParameterZ15(ByVal x2 As Double, ByVal Stab As String) As Double

        Dim A2 As Double '��ɢϵ��
        Dim r2 As Double '��ɢϵ��
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

    '���ݷ�����ع�ϵ��r01������A-B��B-C��C-D��D-E�ȶ����µĲ������ڲ巨ȡƽ��ֵ
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

    '���ݷ�����ع�ϵ��r02������ٴ�С�޹ء�����A-B��B-C��C-D��D-E�ȶ����µĲ������ڲ巨ȡƽ��ֵ
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

    'ͨ����ʽ���ŷ�Դ���ڸ߶ȵķ��٣�ֻ�����ڸ߶�С��200m�����������A-B��B-C��C-D��D-E�ȶ����µĲ������ڲ巨ȡƽ��ֵ
    Public Function UP(ByVal u10 As Double, ByVal z2 As Double, ByVal Ground As String, ByVal Stab As String) As Double
        Dim p As Double
        If Ground = "ƽԭ����ũ�弰����Զ����" Then
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
        ElseIf Ground = "��ҵ�������" Or Ground = "����ɽ����ũ������" Then
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

    'ȡ��ʱ��
    Public Function aySamplingTime(ByVal t1 As Double, ByVal t2 As Double, ByVal ay1 As Double) As Double
        Dim Q As Double
        If t2 >= 0.5 And t2 < 1 Then
            Q = 0.2
        ElseIf t2 >= 1 Then
            Q = 0.3
        End If
        aySamplingTime = ay1 * (t2 / t1) ^ Q
    End Function

    'ȡ��ʱ��
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
    ''' ����������ת��Ϊ������꣬X��ת��
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


    '����������ת��Ϊ������꣬Y��ת��
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
    '���������£�������ģʽ,��i��������twʱ����(x,y,z)����Ũ�ȣ�mg/m3��
    Public Function Cwi(ByVal Qi As Double, ByVal axeff As Double, ByVal ayeff As Double, ByVal azeff As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal xwi As Double, ByVal ywi As Double, ByVal He As Double)
        Dim dblx As Double '����x���������
        Dim dbly As Double '����z���������
        Dim dblz As Double '����y���������
        dblx = System.Math.Exp(-(x - xwi) ^ 2 / (2 * axeff ^ 2))
        dbly = System.Math.Exp(-(y - ywi) ^ 2 / (2 * ayeff ^ 2))
        dblz = System.Math.Exp(-(z - He) ^ 2 / (2 * azeff ^ 2)) + System.Math.Exp(-(z + He) ^ 2 / (2 * azeff ^ 2))
        Cwi = Qi / ((2 * PI) ^ 1.5 * axeff * ayeff * azeff) * dblx * dbly * dblz
    End Function
    'wʱ����x����ĵ�Ч��ɢ������m��
    Public Function axeff(ByVal w As Integer) As Double

    End Function


    ''' <summary>
    ''' �������ŷ�ģʽ������Դ����Դ����Դ��������̿��������������ɢ����������
    ''' </summary>
    ''' <param name="u10">10m�ߴ��ķ���</param>
    ''' <param name="u2">й©Դ�߶ȴ��ķ���</param>
    ''' <param name="He">��Ч�߶�</param>
    ''' <param name="Stab">�ȶ���</param>
    ''' <param name="SamplingTime">ȡ��ʱ��</param>
    ''' <param name="DurationT">й©ʱ��</param>
    ''' <param name="ForecastTime">Ԥ��ʱ��</param>
    ''' <param name="Q">й©����</param>
    ''' <param name="x">Ԥ����·������</param>
    ''' <param name="y">Ԥ��㴹ֱ�·������</param>
    ''' <param name="z">Ԥ���߶�</param>
    ''' <param name="GroundCharacter">��������</param>
    ''' <param name="S">�����</param>
    ''' <param name="Thickness">���</param>
    ''' <param name="HeavyB">����������ֱ����M�����</param>
    ''' <param name="HeavyH">���������ĸ߶�</param>
    ''' <param name="HeavyT">����������������ʱ��</param>
    ''' <param name="HeavyX">������������Ԥ��ʱ��ʱ����������</param>
    ''' <param name="IsHeavy">�Ƿ������忼��</param>
    ''' <param name="ModolType">������ɢ��ģ�����ͣ�1��ʾ˲ʱ��2��ʾ����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UnormalModelPSV(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal DurationT As Double, ByVal ForecastTime As Double, ByVal Q As Double, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String, ByVal S As Double, ByVal Thickness As Double, ByVal HeavyB As Double, ByVal HeavyH As Double, ByVal HeavyT As Double, ByVal HeavyX As Double, ByVal IsHeavy As Boolean, ByVal ModolType As Integer) As Double
        '-----------------------------------������������ģ��

        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double
        Dim ay As Double
        Dim az As Double
        Dim D As Double '��Դ��ֱ��
        D = Math.Sqrt(S / PI) * 2
        Dim t0 As Double '��ʼʱ��
        If u10 < CDbl(CStr(1.5)) Then

            '����0.5Сʱ�ع�ϵ��
            dblR01 = r01(u10, Stab)
            dblR02 = r02(u10, Stab)
            '������Ӧȡ��ʱ��Ļع�ϵ��
            dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
            dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)

            If Thickness > 0 Then            '�������Դ�������ʼʱ��
                t0 = ((D * D * Thickness) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3
                '��ʱ�;����������
                x = x + t0 * u2
                ForecastTime = ForecastTime + t0

                If IsHeavy = True Then '˲ʱ��������ɢ----------------------------------------------------------

                    If ModolType = 1 Then
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                        If ForecastTime <= HeavyT Then
                            '�޸�������ģ�͵���Ч�߶�
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

                    Else '����������ģ�͡�������С��1.5ʱ����ʱ���������ģ�͡�

                        '��ʱ�;����������
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                        If ForecastTime <= HeavyT Then
                            '�޸�������ģ�͵���Ч�߶�
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
            Else '��������Դ���Դ
                ay = dblR01 * ForecastTime
                ax = ay
                az = dblR02 * ForecastTime
                If IsHeavy = True Then '˲ʱ��������ɢ----------------------------------------------------------

                    If ModolType = 1 Then
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                        If ForecastTime <= HeavyT Then
                            '�޸�������ģ�͵���Ч�߶�
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

                    Else '����������ģ�͡�������С��1.5ʱ����ʱ���������ģ�͡�

                        '��ʱ�;����������
                        t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                        If ForecastTime <= HeavyT Then
                            '�޸�������ģ�͵���Ч�߶�
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
            '�÷���<1.5mg/s�ķ������ŷ�ģʽ����
            UnormalModelPSV = UnormalModal0_15(Q, x, y, z, ForecastTime, DurationT, u2, 0, He, dblR01, dblR02)

        ElseIf u10 >= 1.5 And x > 0.01 Then  '������>=1.5m/sʱ��Ԥ��������>0
            '������٣���1.5�����з�ģʽ����,���õ�Դ������
            '����0.5Сʱȡ��ʱ����ɢ����
            If S = 0 Then
                ay = DiffuseY15(x, Stab, GroundCharacter) 'y����ɢ����
                az = DiffuseZ15(x, Stab, GroundCharacter) 'Z����ɢ����
                '������Ӧȡ��ʱ�����ɢ����
                ay = aySamplingTime(0.5, SamplingTime, ay)
                ax = ay
                If IsHeavy = True Then '����������---------------------------------------
                    Dim dxx As Double = 0
                    If x < HeavyX Then
                        dxx = 0
                    Else
                        dxx = x - HeavyX
                    End If
                    ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y����ɢ����
                    az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
                    '������Ӧȡ��ʱ�����ɢ����
                    ay = aySamplingTime(0.5, SamplingTime, ay)
                    '��Դ���������ɢ����
                    ax = ay

                    '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
                    He = HeavyH / 2
                    '���Է��ٽ���������ȡ10m���ķ���ΪU2
                    u2 = u10
                End If
            ElseIf S > 0 And Thickness = 0 Then
                '��Դ
                ay = DiffuseY15(x, Stab, GroundCharacter)  'y����ɢ����
                ax = ay
                az = DiffuseZ15(x, Stab, GroundCharacter) + He / 2.15 'Z����ɢ��������Դ����
                '������Ӧȡ��ʱ�����ɢ����
                ay = aySamplingTime(0.5, SamplingTime, ay)
                ax = ay
                '��Դ���������ɢ����
                ay = ay + D / 4.3  'y����ɢ����
                If IsHeavy = True Then '����������---------------------------------------
                    Dim dxx As Double = 0
                    If x < HeavyX Then
                        dxx = 0
                    Else
                        dxx = x - HeavyX
                    End If
                    ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y����ɢ����
                    az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
                    '������Ӧȡ��ʱ�����ɢ����
                    ay = aySamplingTime(0.5, SamplingTime, ay)
                    '��Դ���������ɢ����
                    ax = ay

                    '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
                    He = HeavyH / 2
                    '���Է��ٽ���������ȡ10m���ķ���ΪU2
                    u2 = u10
                End If

            Else
                ay = DiffuseY15(x, Stab, GroundCharacter)  'y����ɢ����
                ax = ay
                az = DiffuseZ15(x, Stab, GroundCharacter) + Thickness / 4.3 'Z����ɢ��������Դ����
                '������Ӧȡ��ʱ�����ɢ����
                ay = aySamplingTime(0.5, SamplingTime, ay)
                ax = ay
                '��Դ���������ɢ����
                ay = ay + D / 4.3  'y����ɢ����

                If IsHeavy = True Then '����������---------------------------------------
                    Dim dxx As Double = 0
                    If x < HeavyX Then
                        dxx = 0
                    Else
                        dxx = x - HeavyX
                    End If
                    ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y����ɢ����
                    az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
                    '������Ӧȡ��ʱ�����ɢ����
                    ay = aySamplingTime(0.5, SamplingTime, ay)
                    '��Դ���������ɢ����
                    ax = ay

                    '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
                    He = HeavyH / 2
                    '���Է��ٽ���������ȡ10m���ķ���ΪU2
                    u2 = u10
                End If
            End If
            '�÷���>=1.5mg/s�ķ������ŷ�ģʽ����
            UnormalModelPSV = UnormalModal15(Q, x, y, z, ForecastTime, DurationT, u2, He, ax, ay, az)
        End If
    End Function

    '��һ���������£������ţ���ʱй©�ŷ�ģʽ���㣬����Դ����Դ��Դ
    Public Function MultiFlogPSV(ByVal u10 As Double, ByVal u2 As Double, ByVal He As Double, ByVal Stab As String, ByVal SamplingTime As Double, ByVal IntervalT As Double, ByVal ForecastTime As Double, ByVal MultiSource As MultiLeakSorce, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal GroundCharacter As String, ByVal HeavyB As Double, ByVal HeavyH As Double, ByVal HeavyT As Double, ByVal HeavyX As Double, ByVal IsHeavy As Boolean, ByVal ModolType As Integer) As Double
        Dim dblR01 As Double
        Dim dblR02 As Double
        Dim ax As Double = 0
        Dim ay As Double = 0
        Dim az As Double = 0
        Dim D As Double '��Դ��ֱ��
        Dim t0 As Double '��ʼʱ��

        '���������ŷų���ʱ�䵽Ԥ��ʱ��֮��
        Dim Ni As Integer
        Ni = 0 '���Ÿ���
        Dim dblForeTime As Double
        dblForeTime = ForecastTime - Ni * IntervalT

        Dim Ci As Double = 0 'ÿ�����ŵĹ���Ũ��
        Dim CZ As Double = 0 '�������ŵĹ���Ũ��

        While Ni <= MultiSource.n - 1 And dblForeTime > 0
            If u10 < 1.5 Then
                '������٣�1.5������С��ʱ����ɢ��������Ϊ�����˶�����ģʽ������С��ʱ����ɢ������ʱ��ĺ�����������ѭ���ڼ����ÿ�����ŵ���ɢ����
                '����0.5Сʱ�ع�ϵ��
                If dblR01 < 1.0E-40 And dblR02 < 1.0E-40 Then
                    dblR01 = r01(u10, Stab)
                    dblR02 = r02(u10, Stab)
                    '������Ӧȡ��ʱ��Ļع�ϵ��
                    dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
                    dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
                End If
                If MultiSource.Thickness(Ni + 1) > 0 Then            '�������Դ�������ʼʱ��
                    D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
                    t0 = ((D * D * MultiSource.Thickness(Ni + 1)) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3
                    '������ӦԤ��ʱ�����ɢ����,������
                    ay = dblR01 * (dblForeTime + t0)
                    ax = ay
                    az = dblR02 * (dblForeTime + t0)
                    If IsHeavy = True Then '˲ʱ��������ɢ----------------------------------------------------------

                        If ModolType = 1 Then
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                            If ForecastTime <= HeavyT Then
                                '�޸�������ģ�͵���Ч�߶�
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

                        Else '����������ģ�͡�������С��1.5ʱ����ʱ���������ģ�͡�

                            '��ʱ�;����������
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                            If ForecastTime <= HeavyT Then
                                '�޸�������ģ�͵���Ч�߶�
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
                Else '��������Դ���Դ
                    ay = dblR01 * dblForeTime
                    ax = ay
                    az = dblR02 * dblForeTime
                    If IsHeavy = True Then '˲ʱ��������ɢ----------------------------------------------------------

                        If ModolType = 1 Then
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                            If ForecastTime <= HeavyT Then
                                '�޸�������ģ�͵���Ч�߶�
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

                        Else '����������ģ�͡�������С��1.5ʱ����ʱ���������ģ�͡�

                            '��ʱ�;����������
                            t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 * dblR01 * dblR02)) ^ (1 / 3) / 4.3 '���������
                            If ForecastTime <= HeavyT Then
                                '�޸�������ģ�͵���Ч�߶�
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
                '����ÿ�����ŵĹ���Ũ��
                Ci = GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)
                '����
                CZ = CZ + Ci
            ElseIf u10 >= 1.5 And x > 0.01 Then
                '������٣���1.5�����з�ģʽ����
                '����0.5Сʱȡ��ʱ����ɢ����
                If MultiSource.Si(Ni + 1) = 0 Then
                    If ax <= 1.0E-40 And ay <= 1.0E-40 Then '�����ɢ����Ϊ0����Ҫ���¼�����ɢ������������Ҫ�ٽ��м��㡣���������Խ�ʡʱ��
                        If IsHeavy = True Then '����������---------------------------------------
                            Dim dxx As Double = 0
                            If x < HeavyX Then
                                dxx = 0
                            Else
                                dxx = x - HeavyX
                            End If
                            ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y����ɢ����
                            az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
                            '������Ӧȡ��ʱ�����ɢ����
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            '��Դ���������ɢ����
                            ax = ay

                            '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
                            He = HeavyH / 2
                            '���Է��ٽ���������ȡ10m���ķ���ΪU2
                            u2 = u10
                        Else '��������
                            ay = DiffuseY15(x, Stab, GroundCharacter) 'y����ɢ����
                            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z����ɢ����
                            '������Ӧȡ��ʱ�����ɢ����
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            ax = ay
                        End If
                    End If

                ElseIf MultiSource.Si(Ni + 1) > 0 And MultiSource.Thickness(Ni + 1) = 0 Then


                    If IsHeavy = True Then '����������---------------------------------------
                        If ax = 0 And ay = 0 Then '�����ɢ����Ϊ0����Ҫ���¼�����ɢ������������Ҫ�ٽ��м��㡣���������Խ�ʡʱ��
                            Dim dxx As Double = 0
                            If x < HeavyX Then
                                dxx = 0
                            Else
                                dxx = x - HeavyX
                            End If
                            ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y����ɢ����
                            az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
                            '������Ӧȡ��ʱ�����ɢ����
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            '��Դ���������ɢ����
                            ax = ay

                            '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
                            He = HeavyH / 2
                            '���Է��ٽ���������ȡ10m���ķ���ΪU2
                            u2 = u10
                        End If
                    Else '��������
                        If ax = 0 And ay = 0 Then '�����ɢ����Ϊ0����Ҫ���¼�����ɢ������������Ҫ�ٽ��м��㡣���������Խ�ʡʱ��
                            '��Դ
                            ay = DiffuseY15(x, Stab, GroundCharacter)  'y����ɢ����
                            ax = ay
                            az = DiffuseZ15(x, Stab, GroundCharacter) + He / 2.15 'Z����ɢ��������Դ����
                            '������Ӧȡ��ʱ�����ɢ����
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            ax = ay
                            '��Դ���������ɢ����
                            D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
                            ay = ay + D / 4.3  'y����ɢ����
                        End If
                    End If
                Else

                    If IsHeavy = True Then '����������---------------------------------------
                        If ax = 0 And ay = 0 Then '�����ɢ����Ϊ0����Ҫ���¼�����ɢ������������Ҫ�ٽ��м��㡣���������Խ�ʡʱ��
                            Dim dxx As Double = 0
                            If x < HeavyX Then
                                dxx = 0
                            Else
                                dxx = x - HeavyX
                            End If
                            ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y����ɢ����
                            az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
                            '������Ӧȡ��ʱ�����ɢ����
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            '��Դ���������ɢ����
                            ax = ay

                            '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
                            He = HeavyH / 2
                            '���Է��ٽ���������ȡ10m���ķ���ΪU2
                            u2 = u10
                        End If
                    Else '��������
                        If ax = 0 And ay = 0 Then '�����ɢ����Ϊ0����Ҫ���¼�����ɢ������������Ҫ�ٽ��м��㡣���������Խ�ʡʱ��
                            ay = DiffuseY15(x, Stab, GroundCharacter)  'y����ɢ����
                            ax = ay
                            az = DiffuseZ15(x, Stab, GroundCharacter) + MultiSource.Thickness(Ni + 1) / 4.3 'Z����ɢ��������Դ����
                            '������Ӧȡ��ʱ�����ɢ����
                            ay = aySamplingTime(0.5, SamplingTime, ay)
                            ax = ay
                            '��Դ���������ɢ����
                            D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
                            ay = ay + D / 4.3  'y����ɢ����
                        End If
                    End If
                End If
                '����
                CZ += GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)

            End If
            Ni = Ni + 1
            '����Ԥ��ʱ���������ŷŵ�ʱ��֮��
            dblForeTime = ForecastTime - Ni * IntervalT
        End While
        Return CZ


        'Dim dblR01 As Double
        'Dim dblR02 As Double
        'Dim ax As Double
        'Dim ay As Double
        'Dim az As Double
        'Dim D As Double '��Դ��ֱ��
        'Dim t0 As Double '��ʼʱ��

        ''���������ŷų���ʱ�䵽Ԥ��ʱ��֮��
        'Dim Ni As Integer
        'Ni = 0 '���Ÿ���
        'Dim dblForeTime As Double
        'dblForeTime = ForecastTime - Ni * IntervalT

        'Dim Ci As Double = 0 'ÿ�����ŵĹ���Ũ��
        'Dim CZ As Double = 0 '�������ŵĹ���Ũ��

        'While Ni <= MultiSource.n - 1 And dblForeTime > 0
        '    If u10 < 1.5 Then
        '        '������٣�1.5������С��ʱ����ɢ��������Ϊ�����˶�����ģʽ������С��ʱ����ɢ������ʱ��ĺ�����������ѭ���ڼ����ÿ�����ŵ���ɢ����
        '        '����0.5Сʱ�ع�ϵ��
        '        dblR01 = r01(u10, Stab)
        '        dblR02 = r02(u10, Stab)
        '        '������Ӧȡ��ʱ��Ļع�ϵ��
        '        dblR01 = rSamplingTime(0.5, SamplingTime, dblR01)
        '        dblR02 = rSamplingTime(0.5, SamplingTime, dblR02)
        '        If MultiSource.Thickness(Ni + 1) > 0 Then            '�������Դ�������ʼʱ��
        '            D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2
        '            t0 = ((D * D * MultiSource.Thickness(Ni + 1)) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3
        '            '������ӦԤ��ʱ�����ɢ����,������
        '            ay = dblR01 * (dblForeTime + t0)
        '            ax = ay
        '            az = dblR02 * (dblForeTime + t0)
        '            If IsHeavy = True Then '˲ʱ��������ɢ----------------------------------------------------------

        '                If ModolType = 1 Then
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '���������
        '                    If ForecastTime <= HeavyT Then
        '                        '�޸�������ģ�͵���Ч�߶�
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

        '                Else '����������ģ�͡�������С��1.5ʱ����ʱ���������ģ�͡�

        '                    '��ʱ�;����������
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '���������
        '                    If ForecastTime <= HeavyT Then
        '                        '�޸�������ģ�͵���Ч�߶�
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
        '        Else '��������Դ���Դ
        '            ay = dblR01 * dblForeTime
        '            ax = ay
        '            az = dblR02 * dblForeTime
        '            If IsHeavy = True Then '˲ʱ��������ɢ----------------------------------------------------------

        '                If ModolType = 1 Then
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '���������
        '                    If ForecastTime <= HeavyT Then
        '                        '�޸�������ģ�͵���Ч�߶�
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

        '                Else '����������ģ�͡�������С��1.5ʱ����ʱ���������ģ�͡�

        '                    '��ʱ�;����������
        '                    t0 = ((HeavyB * HeavyB * HeavyH) / (dblR01 ^ 2 * dblR02)) ^ (1 / 3) / 4.3 '���������
        '                    If ForecastTime <= HeavyT Then
        '                        '�޸�������ģ�͵���Ч�߶�
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
        '        '����ÿ�����ŵĹ���Ũ��
        '        Ci = GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)
        '        '����
        '        CZ = CZ + Ci
        '    ElseIf u10 >= 1.5 And x > 0.01 Then
        '        '������٣���1.5�����з�ģʽ����
        '        '����0.5Сʱȡ��ʱ����ɢ����
        '        D = Math.Sqrt(MultiSource.Si(Ni + 1) / PI) * 2

        '        If MultiSource.Si(Ni + 1) = 0 Then
        '            ay = DiffuseY15(x, Stab, GroundCharacter) 'y����ɢ����
        '            az = DiffuseZ15(x, Stab, GroundCharacter) 'Z����ɢ����
        '            '������Ӧȡ��ʱ�����ɢ����
        '            ay = aySamplingTime(0.5, SamplingTime, ay)
        '            ax = ay

        '            If IsHeavy = True Then '����������---------------------------------------
        '                Dim dxx As Double = 0
        '                If x < HeavyX Then
        '                    dxx = 0
        '                Else
        '                    dxx = x - HeavyX
        '                End If
        '                ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3 'y����ɢ����
        '                az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
        '                '������Ӧȡ��ʱ�����ɢ����
        '                ay = aySamplingTime(0.5, SamplingTime, ay)
        '                '��Դ���������ɢ����
        '                ax = ay

        '                '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
        '                He = HeavyH / 2
        '                '���Է��ٽ���������ȡ10m���ķ���ΪU2
        '                u2 = u10
        '            End If '��������������---------------------------------------

        '        ElseIf MultiSource.Si(Ni + 1) > 0 And MultiSource.Thickness(Ni + 1) = 0 Then
        '            '��Դ
        '            ay = DiffuseY15(x, Stab, GroundCharacter)  'y����ɢ����
        '            ax = ay
        '            az = DiffuseZ15(x, Stab, GroundCharacter) + He / 2.15 'Z����ɢ��������Դ����
        '            '������Ӧȡ��ʱ�����ɢ����
        '            ay = aySamplingTime(0.5, SamplingTime, ay)
        '            ax = ay
        '            '��Դ���������ɢ����
        '            ay = ay + D / 4.3  'y����ɢ����

        '            If IsHeavy = True Then '����������---------------------------------------
        '                Dim dxx As Double = 0
        '                If x < HeavyX Then
        '                    dxx = 0
        '                Else
        '                    dxx = x - HeavyX
        '                End If
        '                ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y����ɢ����
        '                az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
        '                '������Ӧȡ��ʱ�����ɢ����
        '                ay = aySamplingTime(0.5, SamplingTime, ay)
        '                '��Դ���������ɢ����
        '                ax = ay

        '                '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
        '                He = HeavyH / 2
        '                '���Է��ٽ���������ȡ10m���ķ���ΪU2
        '                u2 = u10
        '            End If '��������������---------------------------------------
        '        Else
        '            ay = DiffuseY15(x, Stab, GroundCharacter)  'y����ɢ����
        '            ax = ay
        '            az = DiffuseZ15(x, Stab, GroundCharacter) + MultiSource.Thickness(Ni + 1) / 4.3 'Z����ɢ��������Դ����
        '            '������Ӧȡ��ʱ�����ɢ����
        '            ay = aySamplingTime(0.5, SamplingTime, ay)
        '            ax = ay
        '            '��Դ���������ɢ����
        '            ay = ay + D / 4.3  'y����ɢ����

        '            If IsHeavy = True Then '����������---------------------------------------
        '                Dim dxx As Double = 0
        '                If x < HeavyX Then
        '                    dxx = 0
        '                Else
        '                    dxx = x - HeavyX
        '                End If
        '                ay = DiffuseY15(dxx, Stab, GroundCharacter) + HeavyB / 4.3  'y����ɢ����
        '                az = DiffuseZ15(dxx, Stab, GroundCharacter) + HeavyH / 2.15 'Z����ɢ��������Դ����
        '                '������Ӧȡ��ʱ�����ɢ����
        '                ay = aySamplingTime(0.5, SamplingTime, ay)
        '                '��Դ���������ɢ����
        '                ax = ay

        '                '�޸�������й©Դ����ЧԴ��Ϊ������ĸ߶ȵ�һ��
        '                He = HeavyH / 2
        '                '���Է��ٽ���������ȡ10m���ķ���ΪU2
        '                u2 = u10
        '            End If '��������������---------------------------------------
        '        End If
        '        '����ÿ�����ŵĹ���Ũ��
        '        Ci = GaussFog(MultiSource.Qi(Ni + 1), x, y, z, dblForeTime, u2, He, ax, ay, az)
        '        '����
        '        CZ = CZ + Ci
        '    End If
        '    Ni = Ni + 1
        '    '����Ԥ��ʱ���������ŷŵ�ʱ��֮��
        '    dblForeTime = ForecastTime - Ni * IntervalT
        'End While
        'MultiFlogPSV = CZ
    End Function


    ''' <summary>
    ''' Ϊ�����Ź�ʽ�ķ���ʽ���ù�ʽ��Ҫ���ڼ����·���ĳһ�����x0��Ũ����ɢ��1000000����1ʱ����ɢ����|x-x0|������������������·���Ũ�ȼ����ļ�ࡣ���С��0�򷵻ظ�ֵ��
    ''' </summary>
    ''' <param name="x">�·������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DX_G(ByVal x As Double) As Double
        Dim az As Double
        az = DiffuseZ15(x, "F", "ƽԭ����ũ�弰����Զ����") 'Z����ɢ������F�ȶ����µ���ɢ������Ϊ���������
        Return az * 2
    End Function
End Module
