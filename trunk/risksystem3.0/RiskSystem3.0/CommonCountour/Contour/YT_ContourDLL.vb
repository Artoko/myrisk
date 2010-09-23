Public Structure Point3D
    Public x As Double
    Public y As Double
    Public z As Double
End Structure
Public Structure ACountourOut
    Public AContour() As Point3D
End Structure
Public Class YT_ContourDLL
    Private AIn(,) As Double '输入数组，用于储存输入的网格数据，(0,0)为坐标最小值对应的数值，（nCol,nRow）为坐标最大值对应的数值
    ' Private AContour(-1, -1) As Point3D '输出数组，用于储存某一给定值的等值线的x,y,z值及条数
    Private nContourLine, nMaxContourPoint As Integer '等值线条数和每一条值线的最大点数
    Private AOneContour() As Point3D '用于储存追踪1条等值线 
    Private nRow, nCol As Integer '行、列数
    Private Xmin, Ymin, Xmax, Ymax As Double '网格的最大坐标和最小坐标
    Private ArrayACountourOut(-1) As ACountourOut '储存等值线值
    Private m_pre As Double = 0.0000000001 '误差值
    '初始化数据
    Public Sub Intial(ByVal a As Double(,), ByVal row As Integer, ByVal col As Integer, ByVal X_min As Double, ByVal Y_min As Double, ByVal X_max As Double, ByVal Y_max As Double)
        AIn = a
        nRow = row
        nCol = col
        Xmin = X_min
        Ymin = Y_min
        Xmax = X_max
        Ymax = Y_max
    End Sub
    Public Sub Calculate(ByVal ZK As Double)
        For iRow As Integer = 0 To nRow - 1
            For jCol As Integer = 0 To nCol - 1
                If Math.Abs(AIn(jCol, iRow) - ZK) < m_pre / 100 Then
                    AIn(jCol, iRow) = ZK + m_pre / 100
                End If
            Next
        Next
        Dim i, j, k, m As Integer
        Dim XA, XB, YA, YB, FA, FB, X0, Y0 As Double

        Dim bool_RepeatPoint As Boolean '用于判断是否有重复的点
        nContourLine = 0
        nMaxContourPoint = 0
        '初始化数组为0
        ReDim ArrayACountourOut(-1)

        '-------------------------------------------------先找出四个边框的等值线
        '先求左边框的等值线
        i = 0
        XA = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
        XB = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
        For j = 0 To nRow - 2 '由下至上，要减1
            YA = Ymin + j * (Ymax - Ymin) / (nRow - 1) 'Y值等步长增加
            YB = Ymin + (j + 1) * (Ymax - Ymin) / (nRow - 1)
            FA = AIn(i, j)
            FB = AIn(i, j + 1)
            bool_RepeatPoint = False '初始化重复标志
            If (FA - ZK) * (FB - ZK) <= 0 Then
                Y0 = F(YA, YB, FA, FB, ZK) '求交点的坐标
                X0 = XA
                '先判断是否是一个重复的点
                If Not ArrayACountourOut Is Nothing Then '如果不为空
                    For k = 0 To ArrayACountourOut.Length - 1
                        If ArrayACountourOut(k).AContour Is Nothing Then
                            ReDim ArrayACountourOut(k).AContour(-1)
                        End If
                        For m = 0 To ArrayACountourOut(k).AContour.Length - 1
                            If (ArrayACountourOut(k).AContour(m).x - X0) ^ 2 + (ArrayACountourOut(k).AContour(m).y - Y0) ^ 2 < m_pre Then '如果不是重复点则
                                bool_RepeatPoint = True
                            End If
                        Next
                    Next
                End If

                If bool_RepeatPoint = False Then '如果没有重复点则开始追踪等值线
                    '分配数组
                    ReDim Preserve AOneContour(0 To 0)
                    AOneContour(0).x = X0
                    AOneContour(0).y = Y0
                    AOneContour(0).z = ZK
                    Dim maxcount As Integer = 1
                    Dim xpre As Double = X0 - m_pre
                    Dim ypre As Double = Y0 - m_pre
                    Dim x As Double = X0
                    Dim y As Double = Y0
                    Dim iA As Double = i
                    Dim jA As Double = j
                    Dim iB As Double = i
                    Dim jB As Double = j + 1
                    Dim sucess As Boolean
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                    If sucess = False Then
                        Do
                            maxcount = 1
                            TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                        Loop Until sucess = True
                    End If
                    nContourLine = nContourLine + 1 '增加等值线条数
                    If nMaxContourPoint < AOneContour.Length Then '增加最大点数
                        nMaxContourPoint = AOneContour.Length
                    End If
                    '改------------------------------------------
                    ReDim Preserve ArrayACountourOut(nContourLine - 1)
                    ArrayACountourOut(nContourLine - 1).AContour = AOneContour
                End If
            End If
        Next j

        '再求顶边框的等值线
        j = (nRow - 1)
        YA = Ymin + j * (Ymax - Ymin) / (nRow - 1) 'Y值不变
        YB = Ymin + j * (Ymax - Ymin) / (nRow - 1)
        For i = 0 To nCol - 2 '由下至上
            If i = nCol - 1 Then
                Exit For
            End If
            XA = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
            XB = Xmin + (i + 1) * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
            FA = AIn(i, j)
            FB = AIn(i + 1, j)
            bool_RepeatPoint = False '初始化重复标志
            If (FA - ZK) * (FB - ZK) <= 0 Then
                X0 = F(XA, XB, FA, FB, ZK) '求交点的坐标
                Y0 = YA
                '先判断是否是一个重复的点
                If Not ArrayACountourOut Is Nothing Then '如果不为空
                    For k = 0 To ArrayACountourOut.Length - 1
                        If ArrayACountourOut(k).AContour Is Nothing Then
                            ReDim ArrayACountourOut(k).AContour(-1)
                        End If
                        For m = 0 To ArrayACountourOut(k).AContour.Length - 1
                            If (ArrayACountourOut(k).AContour(m).x - X0) ^ 2 + (ArrayACountourOut(k).AContour(m).y - Y0) ^ 2 < m_pre Then '如果不是重复点则
                                bool_RepeatPoint = True
                            End If
                        Next
                    Next
                End If
                If bool_RepeatPoint = False Then '如果没有重复点则开始追踪等值线
                    '分配数组
                    ReDim Preserve AOneContour(0 To 0)
                    AOneContour(0).x = X0
                    AOneContour(0).y = Y0
                    AOneContour(0).z = ZK
                    Dim maxcount As Integer = 1
                    If j = nRow - 1 Then
                        Dim xpre As Double = X0 + m_pre
                        Dim ypre As Double = Y0 + m_pre
                        Dim x As Double = X0
                        Dim y As Double = Y0
                        Dim iA As Double = i
                        Dim jA As Double = j
                        Dim iB As Double = i + 1
                        Dim jB As Double = j
                        Dim sucess As Boolean
                        TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess) '输入不同的pre值，追踪的方向不同。这是从上边开始
                        If sucess = False Then
                            Do
                                maxcount = 1
                                TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                            Loop Until sucess = True
                        End If
                    Else
                        Dim xpre As Double = X0 - m_pre
                        Dim ypre As Double = Y0 - m_pre
                        Dim x As Double = X0
                        Dim y As Double = Y0
                        Dim iA As Double = i
                        Dim jA As Double = j
                        Dim iB As Double = i + 1
                        Dim jB As Double = j
                        Dim sucess As Boolean
                        TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess) '输入不同的pre值，追踪的方向不同。这是从下边开始
                        If sucess = False Then
                            Do
                                maxcount = 1
                                TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                            Loop Until sucess = True
                        End If
                    End If
                    nContourLine = nContourLine + 1 '增加等值线条数
                    If nMaxContourPoint < AOneContour.Length Then '增加最大点数
                        nMaxContourPoint = AOneContour.Length
                    End If
                    '改------------------------------------------
                    ReDim Preserve ArrayACountourOut(nContourLine - 1)
                    ArrayACountourOut(nContourLine - 1).AContour = AOneContour
                End If
            End If
        Next i

        '再求右边框的等值线
        i = nCol - 1
        XA = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
        XB = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
        For j = 0 To nRow - 2 '由下至上，要减1
            YA = Ymin + j * (Ymax - Ymin) / (nRow - 1) 'Y值等步长增加
            YB = Ymin + (j + 1) * (Ymax - Ymin) / (nRow - 1)
            FA = AIn(i, j)
            FB = AIn(i, j + 1)
            bool_RepeatPoint = False '初始化重复标志
            If (FA - ZK) * (FB - ZK) <= 0 Then
                Y0 = F(YA, YB, FA, FB, ZK) '求交点的坐标
                X0 = XA

                '先判断是否是一个重复的点
                If Not ArrayACountourOut Is Nothing Then '如果不为空
                    For k = 0 To ArrayACountourOut.Length - 1
                        If ArrayACountourOut(k).AContour Is Nothing Then
                            ReDim ArrayACountourOut(k).AContour(-1)
                        End If
                        For m = 0 To ArrayACountourOut(k).AContour.Length - 1
                            If (ArrayACountourOut(k).AContour(m).x - X0) ^ 2 + (ArrayACountourOut(k).AContour(m).y - Y0) ^ 2 < m_pre Then '如果不是重复点则
                                bool_RepeatPoint = True
                            End If
                        Next
                    Next
                End If

                If bool_RepeatPoint = False Then '如果没有重复点则开始追踪等值线
                    '分配数组
                    ReDim Preserve AOneContour(0 To 0)
                    AOneContour(0).x = X0
                    AOneContour(0).y = Y0
                    AOneContour(0).z = ZK
                    Dim maxcount As Integer = 1
                    Dim xpre As Double = X0 + m_pre
                    Dim ypre As Double = Y0 + m_pre
                    Dim x As Double = X0
                    Dim y As Double = Y0
                    Dim iA As Double = i
                    Dim jA As Double = j
                    Dim iB As Double = i
                    Dim jB As Double = j + 1
                    Dim sucess As Boolean
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                    If sucess = False Then
                        Do
                            maxcount = 1
                            TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                        Loop Until sucess = True
                    End If
                    nContourLine = nContourLine + 1 '增加等值线条数
                    If nMaxContourPoint < AOneContour.Length Then '增加最大点数
                        nMaxContourPoint = AOneContour.Length
                    End If
                    '改------------------------------------------
                    ReDim Preserve ArrayACountourOut(nContourLine - 1)
                    ArrayACountourOut(nContourLine - 1).AContour = AOneContour
                End If
            End If
        Next j

        '再求底边框的等值线
        j = 0
        YA = Ymin + j * (Ymax - Ymin) / (nRow - 1) 'Y值不变
        YB = Ymin + j * (Ymax - Ymin) / (nRow - 1)
        For i = 0 To nCol - 2 '由下至上
            If i = nCol - 1 Then
                Exit For
            End If
            XA = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
            XB = Xmin + (i + 1) * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
            FA = AIn(i, j)
            FB = AIn(i + 1, j)
            bool_RepeatPoint = False '初始化重复标志
            If (FA - ZK) * (FB - ZK) <= 0 Then
                X0 = F(XA, XB, FA, FB, ZK) '求交点的坐标
                Y0 = YA
                '先判断是否是一个重复的点
                If Not ArrayACountourOut Is Nothing Then '如果不为空
                    For k = 0 To ArrayACountourOut.Length - 1
                        If ArrayACountourOut(k).AContour Is Nothing Then
                            ReDim ArrayACountourOut(k).AContour(-1)
                        End If
                        For m = 0 To ArrayACountourOut(k).AContour.Length - 1
                            If (ArrayACountourOut(k).AContour(m).x - X0) ^ 2 + (ArrayACountourOut(k).AContour(m).y - Y0) ^ 2 < m_pre Then '如果不是重复点则
                                bool_RepeatPoint = True
                            End If
                        Next
                    Next
                End If
                If bool_RepeatPoint = False Then '如果没有重复点则开始追踪等值线
                    '分配数组
                    ReDim Preserve AOneContour(0 To 0)
                    AOneContour(0).x = X0
                    AOneContour(0).y = Y0
                    AOneContour(0).z = ZK
                    Dim maxcount As Integer = 1

                    If j = nRow - 1 Then
                        Dim xpre As Double = X0 + m_pre
                        Dim ypre As Double = Y0 + m_pre
                        Dim x As Double = X0
                        Dim y As Double = Y0
                        Dim iA As Double = i
                        Dim jA As Double = j
                        Dim iB As Double = i + 1
                        Dim jB As Double = j
                        Dim sucess As Boolean
                        TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess) '输入不同的pre值，追踪的方向不同。这是从上边开始
                        If sucess = False Then
                            Do
                                maxcount = 1
                                TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                            Loop Until sucess = True
                        End If
                    Else
                        Dim xpre As Double = X0 - m_pre
                        Dim ypre As Double = Y0 - m_pre
                        Dim x As Double = X0
                        Dim y As Double = Y0
                        Dim iA As Double = i
                        Dim jA As Double = j
                        Dim iB As Double = i + 1
                        Dim jB As Double = j
                        Dim sucess As Boolean
                        TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess) '输入不同的pre值，追踪的方向不同。这是从下边开始
                        If sucess = False Then
                            Do
                                maxcount = 1
                                TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                            Loop Until sucess = True
                        End If
                    End If
                    nContourLine = nContourLine + 1 '增加等值线条数
                    If nMaxContourPoint < AOneContour.Length Then '增加最大点数
                        nMaxContourPoint = AOneContour.Length
                    End If
                    '改------------------------------------------
                    ReDim Preserve ArrayACountourOut(nContourLine - 1)
                    ArrayACountourOut(nContourLine - 1).AContour = AOneContour
                End If
            End If
        Next i

        '-------------------------------------------------先找出四个边框的等值线，结束
        For i = 0 To nCol - 2 '由左至右求值
            XA = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
            '从左边框开始
            For j = 0 To nRow - 2 '由下至上，要减1
                XB = Xmin + i * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
                YA = Ymin + j * (Ymax - Ymin) / (nRow - 1) 'Y值等步长增加
                YB = Ymin + (j + 1) * (Ymax - Ymin) / (nRow - 1)
                FA = AIn(i, j)
                FB = AIn(i, j + 1)
                bool_RepeatPoint = False '初始化重复标志
                If (FA - ZK) * (FB - ZK) <= 0 Then
                    Y0 = F(YA, YB, FA, FB, ZK) '求交点的坐标
                    X0 = XA

                    '先判断是否是一个重复的点
                    If Not ArrayACountourOut Is Nothing Then '如果不为空
                        For k = 0 To ArrayACountourOut.Length - 1
                            If ArrayACountourOut(k).AContour Is Nothing Then
                                ReDim ArrayACountourOut(k).AContour(-1)
                            End If
                            For m = 0 To ArrayACountourOut(k).AContour.Length - 1
                                If (ArrayACountourOut(k).AContour(m).x - X0) ^ 2 + (ArrayACountourOut(k).AContour(m).y - Y0) ^ 2 < m_pre Then '如果不是重复点则
                                    bool_RepeatPoint = True
                                End If
                            Next
                        Next
                    End If

                    If bool_RepeatPoint = False Then '如果没有重复点则开始追踪等值线
                        '分配数组
                        ReDim Preserve AOneContour(0 To 0)
                        AOneContour(0).x = X0
                        AOneContour(0).y = Y0
                        AOneContour(0).z = ZK
                        Dim maxcount As Integer = 1
                        Dim xpre As Double = X0 - m_pre
                        Dim ypre As Double = Y0 - m_pre
                        Dim x As Double = X0
                        Dim y As Double = Y0
                        Dim iA As Double = i
                        Dim jA As Double = j
                        Dim iB As Double = i
                        Dim jB As Double = j + 1
                        Dim sucess As Boolean
                        TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                        If sucess = False Then
                            Do
                                maxcount = 1
                                TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                            Loop Until sucess = True
                        End If
                        nContourLine = nContourLine + 1 '增加等值线条数
                        If nMaxContourPoint < AOneContour.Length Then '增加最大点数
                            nMaxContourPoint = AOneContour.Length
                        End If
                        '改------------------------------------------
                        ReDim Preserve ArrayACountourOut(nContourLine - 1)
                        ArrayACountourOut(nContourLine - 1).AContour = AOneContour
                    End If
                End If
            Next j
            '从底边框开始
            For j = 0 To nRow - 1 '由下至上
                If i = nCol - 1 Then
                    Exit For
                End If
                XB = Xmin + (i + 1) * (Xmax - Xmin) / (nCol - 1) 'X值等步长增加
                YA = Ymin + j * (Ymax - Ymin) / (nRow - 1) 'Y值等步长增加
                YB = Ymin + j * (Ymax - Ymin) / (nRow - 1)
                FA = AIn(i, j)
                FB = AIn(i + 1, j)
                bool_RepeatPoint = False '初始化重复标志
                If (FA - ZK) * (FB - ZK) <= 0 Then
                    X0 = F(XA, XB, FA, FB, ZK) '求交点的坐标
                    Y0 = YA
                    '先判断是否是一个重复的点
                    If Not ArrayACountourOut Is Nothing Then '如果不为空
                        For k = 0 To ArrayACountourOut.Length - 1
                            If ArrayACountourOut(k).AContour Is Nothing Then
                                ReDim ArrayACountourOut(k).AContour(-1)
                            End If
                            For m = 0 To ArrayACountourOut(k).AContour.Length - 1
                                If (ArrayACountourOut(k).AContour(m).x - X0) ^ 2 + (ArrayACountourOut(k).AContour(m).y - Y0) ^ 2 < m_pre Then '如果不是重复点则
                                    bool_RepeatPoint = True
                                End If
                            Next
                        Next
                    End If
                    If bool_RepeatPoint = False Then '如果没有重复点则开始追踪等值线
                        '分配数组
                        ReDim Preserve AOneContour(0 To 0)
                        AOneContour(0).x = X0
                        AOneContour(0).y = Y0
                        AOneContour(0).z = ZK
                        Dim maxcount As Integer = 1

                        If j = nRow - 1 Then
                            Dim xpre As Double = X0 + m_pre
                            Dim ypre As Double = Y0 + m_pre
                            Dim x As Double = X0
                            Dim y As Double = Y0
                            Dim iA As Double = i
                            Dim jA As Double = j
                            Dim iB As Double = i + 1
                            Dim jB As Double = j
                            Dim sucess As Boolean
                            TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess) '输入不同的pre值，追踪的方向不同。这是从上边开始
                            If sucess = False Then
                                Do
                                    maxcount = 1
                                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                                Loop Until sucess = True
                            End If
                        Else
                            Dim xpre As Double = X0 - m_pre
                            Dim ypre As Double = Y0 - m_pre
                            Dim x As Double = X0
                            Dim y As Double = Y0
                            Dim iA As Double = i
                            Dim jA As Double = j
                            Dim iB As Double = i + 1
                            Dim jB As Double = j
                            Dim sucess As Boolean
                            TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess) '输入不同的pre值，追踪的方向不同。这是从下边开始
                            If sucess = False Then
                                Do
                                    maxcount = 1
                                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, maxcount, sucess)
                                Loop Until sucess = True
                            End If
                        End If
                        nContourLine = nContourLine + 1 '增加等值线条数
                        If nMaxContourPoint < AOneContour.Length Then '增加最大点数
                            nMaxContourPoint = AOneContour.Length
                        End If
                        '改------------------------------------------
                        ReDim Preserve ArrayACountourOut(nContourLine - 1)
                        ArrayACountourOut(nContourLine - 1).AContour = AOneContour
                    End If
                End If
            Next j
        Next i
    End Sub
    ''' <summary>
    ''' 输出等值线
    ''' </summary>
    ''' <param name="AOut">输出的等值线数组。每个值里有多条等值线</param>
    ''' <remarks></remarks>
    Public Sub PutContour(ByRef AOut(,) As Point3D)
        '通过引用输出等值线数组
        ReDim AOut(nContourLine - 1, nMaxContourPoint) '最后一个数为-1
        Dim i, j As Integer
        For i = 0 To nContourLine - 1
            For j = 0 To nMaxContourPoint
                AOut(i, j).x = 0
                AOut(i, j).y = 0
                AOut(i, j).z = -1 '初始化为-1
            Next
        Next
        For i = 0 To ArrayACountourOut.Length - 1
            For j = 0 To ArrayACountourOut(i).AContour.Length - 1

                AOut(i, j) = ArrayACountourOut(i).AContour(j)

            Next
        Next
    End Sub
    '
    Private Function F(ByVal A As Double, ByVal B As Double, ByVal F_A As Double, ByVal F_B As Double, ByVal Z_K As Double) As Double
        F = A + (Z_K - F_A) / (F_B - F_A) * (B - A)
    End Function
    Private Sub TraceContour(ByRef xpre As Double, ByRef ypre As Double, ByRef x As Double, ByRef y As Double, ByRef iA As Integer, ByRef jA As Integer, ByRef iB As Integer, ByRef jB As Integer, ByVal ZK As Double, ByRef MaxCount As Integer, ByRef sucess As Boolean)
        If MaxCount > 100 Then
            sucess = False
            Exit Sub
        End If
        MaxCount = MaxCount + 1
        'xpre,ypre 为前一个网格交点的坐标
        'iA,jA,iB,jB 分别为当前A，B点的数组下标
        'Zk 为要求的Z值
        Dim xA, yA, xB, yB As Double  'A，B点的坐标
        Dim q As Integer = -1 '表示是垂直边，还是水平边，1为垂直边，0为水平边
        Dim ex1, ex2 As Double
        If iA = iB Then
            q = 1 '为垂直边
        Else
            q = 0 '为水平边
        End If
        xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
        yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1) '
        ex1 = xA - xpre '如果大于0为左边，否则为右边
        ex2 = yA - ypre '如果大于0为下边，否则为上边
        If q = 1 And ex1 >= 0 And iA < nCol - 1 Then '左垂直边且不为右边框 ,按上、对、底边追踪---------------------------------------
            If (AIn(iA, jA + 1) - ZK) * (AIn(iB + 1, jB) - ZK) <= 0 Then '如果上边没有越界且有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA
                jA = jA + 1
                iB = iB + 1
                jB = jB
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                y = yA
                x = F(xA, xB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果上边为最大值或返回起点，则退出
                If (jB = nRow - 1 Or jB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If

            ElseIf (AIn(iA + 1, jA) - ZK) * (AIn(iB + 1, jB) - ZK) <= 0 Then '如果右边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA + 1
                jA = jA
                iB = iB + 1
                jB = jB
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                x = xA
                y = F(yA, yB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果对边为最大值或最小值或返回起点，则退出
                If (iB = nCol - 1 Or iB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            ElseIf (AIn(iA, jA) - ZK) * (AIn(iB + 1, jB - 1) - ZK) <= 0 Then '如果底边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA
                jA = jA
                iB = iB + 1
                jB = jB - 1
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                y = yA
                x = F(xA, xB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果上边为最大值或最小值或返回起点，则退出
                If (jB = nRow - 1 Or jB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            Else
                sucess = True
                Exit Sub
            End If
        ElseIf q = 1 And ex1 < 0 And iA > 0 Then '右垂直边且不为左边框,按底、对、上边追踪-----------------------------------------------------------
            If (AIn(iA - 1, jA) - ZK) * (AIn(iB, jB - 1) - ZK) <= 0 Then '如果底边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA - 1
                jA = jA
                iB = iB
                jB = jB - 1
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                y = yA
                x = F(xA, xB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果上对边为最大值或最小值或返回起点，则退出
                If (jB = nRow - 1 Or jB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If

            ElseIf (AIn(iA - 1, jA) - ZK) * (AIn(iB - 1, jB) - ZK) <= 0 Then '如果左边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA - 1
                jA = jA
                iB = iB - 1
                jB = jB
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                x = xA
                y = F(yA, yB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果对边为最大值或最小值或返回起点，则退出
                If (iB = nCol - 1 Or iB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            ElseIf (AIn(iA - 1, jA + 1) - ZK) * (AIn(iB, jB) - ZK) <= 0 Then '如果上边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA - 1
                jA = jA + 1
                iB = iB
                jB = jB
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                y = yA
                x = F(xA, xB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK

                '如果上边为最大值或返回起点，则退出
                If (jB = nRow - 1 Or jB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)

                End If

            Else
                sucess = True
                Exit Sub
            End If
        ElseIf q = 0 And ex2 >= 0 And jB < nRow - 1 Then '底水平边,且不为顶边,按右、顶、左边追踪
            If (AIn(iA + 1, jA) - ZK) * (AIn(iB, jB + 1) - ZK) <= 0 Then '如果右边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA + 1
                jA = jA
                iB = iB
                jB = jB + 1
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                x = xA
                y = F(yA, yB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果右边为最大值或最小值或返回起点，则退出
                If (iB = nCol - 1 Or iB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            ElseIf (AIn(iA, jA + 1) - ZK) * (AIn(iB, jB + 1) - ZK) <= 0 Then '如果上边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA
                jA = jA + 1
                iB = iB
                jB = jB + 1
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                y = yA
                x = F(xA, xB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK

                '如果上边为最大值或返回起点，则退出
                If (jB = nRow - 1 Or jB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)

                End If
            ElseIf (AIn(iA, jA) - ZK) * (AIn(iB - 1, jB + 1) - ZK) <= 0 Then '如果左边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA
                jA = jA
                iB = iB - 1
                jB = jB + 1
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                x = xA
                y = F(yA, yB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果右边为最大值或最小值或返回起点，则退出
                If (iB = nCol - 1 Or iB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            Else
                sucess = True
                Exit Sub
            End If
        ElseIf q = 0 And ex2 < 0 And jA > 0 Then  '顶水平边，且不为底边

            If (AIn(iA, jA - 1) - ZK) * (AIn(iB - 1, jB) - ZK) <= 0 Then '如果左边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA
                jA = jA - 1
                iB = iB - 1
                jB = jB
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                x = xA
                y = F(yA, yB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果右边为最大值或最小值或返回起点，则退出
                If (iB = nCol - 1 Or iB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            ElseIf (AIn(iA, jA - 1) - ZK) * (AIn(iB, jB - 1) - ZK) <= 0 Then '如果底边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA
                jA = jA - 1
                iB = iB
                jB = jB - 1
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                y = yA
                x = F(xA, xB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK

                '如果上边为最大值或返回起点，则退出
                If (jB = nRow - 1 Or jB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            ElseIf (AIn(iA + 1, jA - 1) - ZK) * (AIn(iB, jB) - ZK) <= 0 Then '如果右边有交点，则继续追踪
                '求出交点的坐标
                If AOneContour Is Nothing Then
                    ReDim Preserve AOneContour(0 To 0)
                Else
                    ReDim Preserve AOneContour(0 To AOneContour.Length)
                End If
                '将现在的点赋给前一个点
                xpre = x
                ypre = y
                '改变A、B点
                iA = iA + 1
                jA = jA - 1
                iB = iB
                jB = jB
                xA = Xmin + iA * (Xmax - Xmin) / (nCol - 1)
                yA = Ymin + jA * (Ymax - Ymin) / (nRow - 1)
                xB = Xmin + iB * (Xmax - Xmin) / (nCol - 1)
                yB = Ymin + jB * (Ymax - Ymin) / (nRow - 1)
                x = xA
                y = F(yA, yB, AIn(iA, jA), AIn(iB, jB), ZK)
                AOneContour(AOneContour.Length - 1).x = x
                AOneContour(AOneContour.Length - 1).y = y
                AOneContour(AOneContour.Length - 1).z = ZK
                '如果右边为最大值或最小值或返回起点，则退出
                If (iB = nCol - 1 Or iB = 0 Or (AOneContour(AOneContour.Length - 1).x - AOneContour(0).x) ^ 2 + (AOneContour(AOneContour.Length - 1).y - AOneContour(0).y) ^ 2 < 0.000001) And AOneContour.Length > 0 Then
                    sucess = True
                    Exit Sub
                Else
                    '叠代
                    TraceContour(xpre, ypre, x, y, iA, jA, iB, jB, ZK, MaxCount, sucess)
                End If
            Else
                sucess = True
                Exit Sub
            End If
        Else
            sucess = False
            Exit Sub
        End If
    End Sub
    Public Function PutLineNumber() As Integer  '输出某一等值线条数
        PutLineNumber = nContourLine
    End Function
    Public Function PutLinePointNumber(ByVal i As Integer) As Integer '输出第i条等值线的点数
        If i <= nContourLine - 1 Then
            PutLinePointNumber = ArrayACountourOut(i).AContour.Length
        Else
            '如果超出最大条数，报错
            Return -1
        End If
    End Function
    Public Function PutPoint(ByVal i As Integer, ByVal j As Integer) As Point3D '输出第i个等值线的第j个点
        If i < ArrayACountourOut.Length AndAlso j < ArrayACountourOut(i).AContour.Length Then
            PutPoint = ArrayACountourOut(i).AContour(j)
        Else
            Return New Point3D()
        End If
    End Function
End Class
