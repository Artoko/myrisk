Module tools

    '����̫���߶Ƚ�
    Public Function SunHight(ByVal dnDayOfYear As Integer, ByVal dblTimeOfDay As Double, ByVal dblLongDeg As Double, ByVal dblLatDeg As Double) As Double
        '�Ƕ��Ի��ȱ�ʾ
        Dim SunObliquity As Double '̫�����
        Dim S1, S As Double '����������360dn/365,deg
        S1 = dnDayOfYear * 360 / 365
        S = S1 * PI / 180 'ת��Ϊ����
        '����̫����ǣ��������Ի��ȱ�ʾ�����Ҫ�ԽǶȱ�ʾ����*180/PI
        SunObliquity = (0.006918 - 0.39912 * Math.Cos(S) + 0.070257 * Math.Sin(S) _
                        - 0.006758 * Math.Cos(2 * S) + 0.000907 * Math.Sin(2 * S) _
                        - 0.002697 * Math.Cos(3 * S) + 0.00148 * Math.Sin(3 * S))

        '����̫���߶Ƚǣ��ԽǶȱ�ʾҪ*180/PI
        SunHight = (Math.Asin(Math.Sin(dblLatDeg * PI / 180) * Math.Sin(SunObliquity) + Math.Cos(dblLatDeg * PI / 180) * Math.Cos(SunObliquity) * Math.Cos((15 * dblTimeOfDay + dblLongDeg - 300) * PI / 180))) * 180 / PI
    End Function

    '����̫������ȼ���
    Public Function RadiateDeg(ByVal nCloudAll As Integer, ByVal nCloudPart As Integer, ByVal h0 As Double, ByVal dblMorning As Double, ByVal dblNight As Double, ByVal dblTimeOfDay As Double) As Integer
        Dim aRadiate(,) As Integer = New Integer(4, 4) {{-2, -1, +1, +2, +3}, _
                                                       {-1, 0, +1, +2, +3}, _
                                                       {-1, 0, 0, +1, +1}, _
                                                       {0, 0, 0, 0, +1}, _
                                                       {0, 0, 0, 0, 0}} '������������̫������ȼ���
        Dim i, j As Integer '������������
        i = -1 : j = -1

        If nCloudAll <= 4 And nCloudPart <= 4 Then
            i = 0
        ElseIf nCloudAll >= 5 And nCloudAll <= 7 And nCloudPart <= 4 Then
            i = 1
        ElseIf nCloudAll >= 8 And nCloudPart <= 4 Then
            i = 2
        ElseIf nCloudAll >= 5 And nCloudPart >= 5 And nCloudPart <= 7 Then
            i = 3
        ElseIf nCloudAll >= 8 And nCloudPart >= 8 Then
            i = 4
        End If

        If dblTimeOfDay < dblMorning Or dblTimeOfDay > dblNight Then
            j = 0
        ElseIf h0 <= 15 Then
            j = 1
        ElseIf h0 > 15 And h0 <= 35 Then
            j = 2
        ElseIf h0 > 35 And h0 <= 65 Then
            j = 3
        ElseIf h0 > 65 Then
            j = 4
        End If
        If i <> -1 And j <> -1 Then
            RadiateDeg = aRadiate(i, j)
        Else
            MsgBox("̫������ȼ����д�")
        End If
    End Function

    '��������ȶ��ȵȼ�
    Public Function Pasquill(ByVal dblU10 As Double, ByVal nRadiateDeg As Integer) As String

        Dim SP(,) As String = New String(4, 5) {{"A", "A-B", "B", "D", "E", "F"}, _
                                            {"A-B", "B", "C", "D", "E", "F"}, _
                                            {"B", "B-C", "C", "D", "D", "E"}, _
                                            {"C", "C-D", "D", "D", "D", "D"}, _
                                            {"D", "D", "D", "D", "D", "D"}} '�����鴢������ȶ���
        Dim i, j As Integer '������������
        i = -1 : j = -1

        If dblU10 < 2 Then
            i = 0
        ElseIf dblU10 >= 2 And dblU10 < 3 Then
            i = 1
        ElseIf dblU10 >= 3 And dblU10 < 5 Then
            i = 2
        ElseIf dblU10 >= 5 And dblU10 < 6 Then
            i = 3
        ElseIf dblU10 >= 6 Then
            i = 4
        End If
        Select Case nRadiateDeg
            Case +3
                j = 0
            Case +2
                j = 1
            Case +1
                j = 2
            Case 0
                j = 3
            Case -1
                j = 4
            Case -2
                j = 5
        End Select

        If i <> -1 And j <> -1 Then
            Pasquill = SP(i, j)
        Else
            Pasquill = ""
            MsgBox("�����ȶ��ȵȼ��д�")
        End If

    End Function
End Module
