Public Module DiePr
    ''' <summary>
    '''  根据热辐射计算死亡概率
    ''' </summary>
    ''' <param name="t">接触时间,s</param>
    ''' <param name="q">热辐射通量,W/m^2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DiePr(ByVal t As Double, ByVal q As Double) As Double
        Dim p As Double = 0
        p = -37.23 + 2.56 * Math.Log(t * q ^ (4 / 3))
        If p < 0 Then
            p = 0
        End If
        Return p
    End Function
    ''' <summary>
    ''' 根据冲击波计算死亡概率
    ''' </summary>
    ''' <param name="dP">超压,P</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function TNTDiePr(ByVal dP As Double) As Double
        Dim p As Double = dP / 6900  '将单位转换为pis
        TNTDiePr = 2.47 + 1.43 * Math.Log(p)
    End Function

    ''' <summary>
    ''' 用变步长辛普生公式计算死亡率
    ''' </summary>
    ''' <param name="Pr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NormalSchool(ByVal Pr As Double) As Double
        Dim N As Long
        Dim K As Long
        Dim t2, t1, ep, s1, H, s2 As Double
        Dim p As Double
        Dim x As Double
        Dim a As Double
        Dim eps As Double
        Dim b = Pr - 5
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

    '计算不完全珈玛函数使用的函数
    Public Function F(ByVal u As Double) As Double
        F = 1 / System.Math.Sqrt(2 * Math.PI) * System.Math.Exp(-u ^ 2 / 2)
    End Function
End Module
