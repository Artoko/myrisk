Module tools

    '计算太阳高度角
    Public Function SunHight(ByVal dnDayOfYear As Integer, ByVal dblTimeOfDay As Double, ByVal dblLongDeg As Double, ByVal dblLatDeg As Double) As Double
        '角度以弧度表示
        Dim SunObliquity As Double '太阳倾角
        Dim S1, S As Double '天数参数，360dn/365,deg
        S1 = dnDayOfYear * 360 / 365
        S = S1 * PI / 180 '转化为弧度
        '计算太阳倾角，计算结果以弧度表示，如果要以角度表示，则*180/PI
        SunObliquity = (0.006918 - 0.39912 * Math.Cos(S) + 0.070257 * Math.Sin(S) _
                        - 0.006758 * Math.Cos(2 * S) + 0.000907 * Math.Sin(2 * S) _
                        - 0.002697 * Math.Cos(3 * S) + 0.00148 * Math.Sin(3 * S))

        '计算太阳高度角，以角度表示要*180/PI
        SunHight = (Math.Asin(Math.Sin(dblLatDeg * PI / 180) * Math.Sin(SunObliquity) + Math.Cos(dblLatDeg * PI / 180) * Math.Cos(SunObliquity) * Math.Cos((15 * dblTimeOfDay + dblLongDeg - 300) * PI / 180))) * 180 / PI
    End Function

    '计算太阳辐射等级数
    Public Function RadiateDeg(ByVal nCloudAll As Integer, ByVal nCloudPart As Integer, ByVal h0 As Double, ByVal dblMorning As Double, ByVal dblNight As Double, ByVal dblTimeOfDay As Double) As Integer
        Dim aRadiate(,) As Integer = New Integer(4, 4) {{-2, -1, +1, +2, +3}, _
                                                       {-1, 0, +1, +2, +3}, _
                                                       {-1, 0, 0, +1, +1}, _
                                                       {0, 0, 0, 0, +1}, _
                                                       {0, 0, 0, 0, 0}} '用数组来储存太阳辐射等级数
        Dim i, j As Integer '用来引用数组
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
            MsgBox("太阳辐射等级数有错！")
        End If
    End Function

    '计算大气稳定度等级
    Public Function Pasquill(ByVal dblU10 As Double, ByVal nRadiateDeg As Integer) As String

        Dim SP(,) As String = New String(4, 5) {{"A", "A-B", "B", "D", "E", "F"}, _
                                            {"A-B", "B", "C", "D", "E", "F"}, _
                                            {"B", "B-C", "C", "D", "D", "E"}, _
                                            {"C", "C-D", "D", "D", "D", "D"}, _
                                            {"D", "D", "D", "D", "D", "D"}} '用数组储存大气稳定度
        Dim i, j As Integer '用来引用数组
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
            MsgBox("大气稳定度等级有错！")
        End If

    End Function
End Module
