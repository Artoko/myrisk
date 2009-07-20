Public Module Leak
    ''' <summary>
    ''' ������й©��ʽ
    ''' </summary>
    ''' <param name="LeakTwoCP">��������Ķ�ѹ���ȣ�J/��kg��K��</param>
    ''' <param name="LeakTwoTLG">����������¶ȣ����϶�</param>
    ''' <param name="LeakTwoTC">Һ�����ٽ�ѹ���µķе㣬���϶�</param>
    ''' <param name="LeakTwoH">Һ��������ȣ�J/kg</param>
    ''' <param name="LeakTwoPg">��̬��Һ�������ܶȣ�kg/m3</param>
    ''' <param name="LeakTwoPl">Һ���ܶȣ�kg/m3</param>
    ''' <param name="LeakTwoCd">������й©ϵ������ȡ0.8</param>
    ''' <param name="LeakTwoA">�ѿ������m2</param>
    ''' <param name="LeakTwoP">����ѹ��������ѹ����Pa</param>
    ''' <param name="LeakTwoPC">�ٽ�ѹ����Pa����ȡPC=0.55P</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CalculateLeakTwo(ByVal LeakTwoCP As Double, ByVal LeakTwoTLG As Double, ByVal LeakTwoTC As Double, ByVal LeakTwoH As Double, ByVal LeakTwoPg As Double, ByVal LeakTwoPl As Double, ByVal LeakTwoCd As Double, ByVal LeakTwoA As Double, ByVal LeakTwoP As Double, ByVal LeakTwoPC As Double) As Double
        If LeakTwoH = 0 Then
            MsgBox("���������ʵ�Һ���������!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        If LeakTwoCP = 0 Then
            MsgBox("���������ʵ�Һ��Ķ�ѹ����!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        '�ڼ���ǰӦ���ݳ�ѹ������ܶȼ��������ѹ����������ܶ�
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
        '�ж����������Ƿ������ٷ�Χ(�ٽ���)
        Dim flow As Double
        flow = (2 / (LeakGasK + 1)) ^ (LeakGasK / (LeakGasK - 1))
        If LeakGasP0 / LeakGasP <= flow Then
            strY = "�������������ٷ�Χ�����ٽ�����" & vbCrLf
        Else
            strY = "���������������ٷ�Χ���Ǵ��ٽ�����" & vbCrLf
        End If

    End Function

    '����й©���㹫ʽ
    Public Function CalculateLeakGas(ByVal LeakGasShape As String, ByVal LeakGasTG As Double, ByVal LeakGasK As Double, ByVal LeakGasP0 As Double, ByVal LeakGasP As Double, ByVal LeakGasA As Double, ByVal LeakGasM As Double) As Double
        If LeakGasK = 0 Then
            MsgBox("���������ʵ��������ָ��!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        If LeakGasM = 0 Then
            MsgBox("���������ʵ�Ħ������!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        '��������й©ϵ��
        Dim Cd As Double
        Select Case LeakGasShape
            Case 0 'Բ  ��
                Cd = 1.0#
            Case 1 '������
                Cd = 0.95
            Case 2 '������
                Cd = 0.9
        End Select
        Dim t As Double
        t = LeakGasTG
        '�ж����������Ƿ������ٷ�Χ(�ٽ���),����������ϵ��Y
        Dim flow As Double
        Dim strY As String
        flow = (2 / (LeakGasK + 1)) ^ (LeakGasK / (LeakGasK - 1))
        Dim Y As Double
        Dim k1 As Double
        Dim k2 As Double
        Dim k3 As Double
        If LeakGasP0 / LeakGasP <= flow Then
            Y = 1
            strY = "�������������ٷ�Χ�����ٽ�����" & vbCrLf
        Else
            k1 = (LeakGasP0 / LeakGasP) ^ (1 / LeakGasK)
            k2 = (1 - ((LeakGasP0 / LeakGasP) ^ ((LeakGasK - 1) / LeakGasK))) ^ 0.5
            k3 = (2 / (LeakGasK - 1) * ((LeakGasK + 1) / 2) ^ ((LeakGasK + 1) / (LeakGasK - 1))) ^ 0.5
            Y = k1 * k2 * k3
            strY = "���������������ٷ�Χ���Ǵ��ٽ�����" & vbCrLf
        End If
        '��������й©����QG
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
    'Һ��й©��ʽ
    Public Function CalculateLeakLiquid(ByVal chkHeight As Short, ByVal LeakLiquidCd As Double, ByVal LeakLiquidHeight As Double, ByVal LeakLiquidA As Double, ByVal LeakLiquidPl As Double, ByVal LeakLiquidP As Double, ByVal LeakLiquidP0 As Double) As Double
        If LeakLiquidPl = 0 Then
            MsgBox("���������ʵ�Һ���ܶ�!", MsgBoxStyle.OkOnly, "�����������ݳ���")
            Return ErrorValue
        End If
        'ȷ���Ƿ��Ǹ߶�
        Dim H As Double
        If chkHeight = 0 Then '������Һλ�߶ȵ�ѹ��
            H = 0
        Else
            H = LeakLiquidHeight '����Һλ�߶ȵ�ѹ��
        End If
        '����Һ��й©��
        Dim QLG As Double
        QLG = LeakLiquidCd * LeakLiquidA * LeakLiquidPl * (2 * (LeakLiquidP - LeakLiquidP0) / LeakLiquidPl + 2 * 9.8 * H) ^ 0.5
        CalculateLeakLiquid = QLG
    End Function
    Public Function CalculateLeakFv(ByVal LeakLiquidCP As Double, ByVal LeakLiquidTLG As Double, ByVal LeakLiquidTC As Double, ByVal LeakLiquidH As Double) As Double
        If LeakLiquidH = 0 Then
            MsgBox("���������ʵ�Һ���������!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        If LeakLiquidCP = 0 Then
            MsgBox("���������ʵ�Һ��Ķ�ѹ����!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        '����Һ��������
        CalculateLeakFv = LeakLiquidCP * (LeakLiquidTLG - LeakLiquidTC) / LeakLiquidH
    End Function
    '����������ʽ
    Public Function CalculateLeakHeat(ByVal LeakEvaporationGround As Integer, ByVal LeakEvaporationS As Double, ByVal LeakEvaporationT0 As Double, ByVal LeakEvaporationTb As Double, ByVal LeakEvaporationH As Double, ByVal LeakEvaporationt As Double) As Double
        If LeakEvaporationH = 0 Then
            MsgBox("���������ʵ�Һ���������!", MsgBoxStyle.OkOnly, "�������ʳ���!")
            Return ErrorValue
        End If
        'ѡ������ȵ�ϵ��������ɢϵ��
        Dim l As Double
        Dim a As Double
        Select Case LeakEvaporationGround
            Case 0 'ˮ��
                l = 1.1
                a = 1.29 / 10000000
            Case 1 '����(��ˮ8%)
                l = 0.9
                a = 4.3 / 10000000
            Case 2 '��������
                l = 0.3
                a = 2.3 / 10000000
            Case 3 'ʪ��
                l = 0.6
                a = 2.5 / 10000000
            Case 4 'ɰ����
                l = 2.5
                a = 11.0# / 10000000
        End Select

        '����������������
        Dim Q2 As Double
        Q2 = l * LeakEvaporationS * (LeakEvaporationT0 - LeakEvaporationTb) / (LeakEvaporationH * (PI * a * LeakEvaporationt) ^ 0.5)

        CalculateLeakHeat = Q2

    End Function
    '����������ʽ
    Public Function CalculateLeakQuality(ByVal LeakEvaporationStab As String, ByVal LeakEvaporationP As Double, ByVal LeakEvaporationM As Double, ByVal LeakEvaporationT0 As Double, ByVal LeakEvaporationU As Double, ByVal LeakEvaporationS As Double) As Double
        'ѡ���ȶ���
        Dim N As Double
        Dim a As Double
        If LeakEvaporationStab = "���ȶ�(A��B)" Or LeakEvaporationStab = "A" Or LeakEvaporationStab = "A-B" Or LeakEvaporationStab = "B" Or LeakEvaporationStab = "B-C" Or LeakEvaporationStab = "C" Or LeakEvaporationStab = "C-D" Then
            N = 0.2
            a = 3.846 / 1000
        ElseIf LeakEvaporationStab = "����(D)" Or LeakEvaporationStab = "D" Then
            N = 0.25
            a = 4.685 / 1000
        ElseIf LeakEvaporationStab = "�ȶ�(E��F)" Or LeakEvaporationStab = "D-E" Or LeakEvaporationStab = "E" Or LeakEvaporationStab = "E-F" Or LeakEvaporationStab = "F" Then
            N = 0.3
            a = 5.285 / 1000
        End If
        Dim Q3 As Double
        Q3 = a * LeakEvaporationP * LeakEvaporationM / (8.314 * (LeakEvaporationT0 + 273.15)) * LeakEvaporationU ^ ((2 - N) / (2 + N)) * ((LeakEvaporationS / PI) ^ 0.5) ^ ((4 + N) / (2 + N))
        CalculateLeakQuality = Q3
    End Function
    'Һ����ɢ��ʽ�����ĳһʱ��Һ�صİ뾶��plΪ�ܶȣ�kg/m3��mΪĳһʱ�̵�������tΪй©ʱ��
    Public Function PoolR(ByVal pl As Double, ByVal m As Double, ByVal t As Double, ByVal AllT As Double) As Double
        Dim B As Double
        If AllT < 30 Then  '���й©ʱ��С��30m����˲ʱ�ŷż���
            B = (PI * pl / (8 * Gravity * m)) ^ 0.5
            PoolR = (t / B) ^ 0.5
        Else
            B = (PI * pl / (32 * Gravity * m)) ^ (1 / 3.0)
            PoolR = (t / B) ^ (3 / 4.0)
        End If
    End Function
    'Һ�ص�������
    Public Function Smax(ByVal pl As Double, ByVal m As Double) As Double
        Smax = m / (pl * 0.01)
    End Function
End Module
