<Serializable()> Public Class JetFire


    ''' <summary>
    ''' �¹�Դ����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = "ѹ������" '
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name As String = "����" '
    ''' <summary>
    ''' �¹�Դ����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourcePoint As New Point2D '
    Private m_SourceAngle As Double = 90 '����Ƕȡ���λΪ��

    ''' <summary>
    ''' ���ʵ�ȼ����Hc[J/kg]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Hc As Double = 41792344 '
    ''' <summary>
    ''' �������٣�kg/s��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_M As Double = 5
    ''' <summary>
    ''' �Ӵ�ʱ�䡣��Ա��Ѹ���뿪��ʱ�䣬ȡ40��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_T As Double = 40
    ''' <summary>
    ''' ȼ��Ч�����ӣ�һ��ȡ0.35
    ''' </summary>
    ''' <remarks></remarks>
    Private m_f As Double = 0.35 '

    ''' <summary>
    ''' �������ӣ�ȡ0.2
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Xp As Double = 0.2

    ''' <summary>
    ''' ����ĵ�Դ��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_n As Integer = 101
    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_StepLong As Double = 10  '
    ''' <summary>
    ''' �����ĸ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_StepCount As Integer = 20 '

    ''' <summary>
    ''' �ȷ����������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ArrHeatEradiate(0 To 3) As FireBlast.HeatEradiate '
    ''' <summary>
    ''' �������������������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strResult As String '
    ''' <summary>
    ''' ���沽����Ӧ���ȷ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ResultStepDp(-1) As Double

    ''' <summary>
    ''' ���ȷ���ѹ��Ӧ�ľ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ResultHurtPoint(-1) As hurtPointstruct
#Region "�м����"
    ''' <summary>
    ''' �ػ�ȼ������ kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mf As Double
    ''' <summary>
    ''' �ػ����ʱ�� s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DurationT As Double
    ''' <summary>
    ''' ���泤�ȣ��м����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_L As Double
    ''' <summary>
    ''' ��Դ�ȷ���ͨ�����м���� 
    ''' </summary>
    ''' <remarks></remarks>
    Private m_E As Double
#End Region

#Region "����"

    ''' <summary>
    ''' �¹�Դ����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceName() As String '
        Get
            Return Me.m_SourceName
        End Get
        Set(ByVal value As String)
            Me.m_SourceName = value
        End Set
    End Property
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name() As String '
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property
    ''' <summary>
    ''' �¹�Դ����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourcePoint() As Point2D '
        Get
            Return Me.m_SourcePoint
        End Get
        Set(ByVal value As Point2D)
            Me.m_SourcePoint = value
        End Set
    End Property
    ''' <summary>
    ''' ����Ƕȡ���λΪ��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceAngle() As Double
        Get
            Return Me.m_SourceAngle
        End Get
        Set(ByVal value As Double)
            Me.m_SourceAngle = value
        End Set
    End Property
    ''' <summary>
    ''' ���ʵ�ȼ����Hc[J/kg]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Hc() As Double
        Get
            Return Me.m_Hc
        End Get
        Set(ByVal value As Double)
            Me.m_Hc = value
        End Set
    End Property
    ''' <summary>
    ''' ȼ��Ч������f
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property f() As Double
        Get
            Return Me.m_f
        End Get
        Set(ByVal value As Double)
            Me.m_f = value
        End Set
    End Property
    ''' <summary>
    ''' й©������kg/s��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property M() As Double
        Get
            Return Me.m_M
        End Get
        Set(ByVal value As Double)
            Me.m_M = value
        End Set
    End Property
    ''' <summary>
    ''' �Ӵ�ʱ�䣬һ��Ϊ40S
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property T() As Double
        Get
            Return Me.m_T
        End Get
        Set(ByVal value As Double)
            Me.m_T = value
        End Set
    End Property
    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepLong() As Double
        Get
            Return Me.m_StepLong
        End Get
        Set(ByVal value As Double)
            Me.m_StepLong = value
        End Set
    End Property
    ''' <summary>
    ''' �����ĸ���
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepCount() As Integer
        Get
            Return Me.m_StepCount
        End Get
        Set(ByVal value As Integer)
            Me.m_StepCount = value
        End Set
    End Property

    ''' <summary>
    ''' �ȷ����������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ArrHeatEradiate() As FireBlast.HeatEradiate()
        Get
            Return Me.m_ArrHeatEradiate
        End Get
        Set(ByVal value As FireBlast.HeatEradiate())
            Me.m_ArrHeatEradiate = value
        End Set
    End Property
    ''' <summary>
    ''' ���沽����Ӧ�ĳ�ѹ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultDP() As Double()
        Get
            Return Me.m_ResultStepDp
        End Get
        Set(ByVal value As Double())
            Me.m_ResultStepDp = value
        End Set
    End Property

    ''' <summary>
    ''' ��ͬ�ȷ����Ӧ�ĵ�����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultHurtPoint() As hurtPointstruct()
        Get
            Return Me.m_ResultHurtPoint
        End Get
        Set(ByVal value As hurtPointstruct())
            Me.m_ResultHurtPoint = value
        End Set
    End Property
#End Region

    Public Sub New()
        For i As Integer = 0 To Me.ArrHeatEradiate.Length - 1
            Me.ArrHeatEradiate(i) = New FireBlast.HeatEradiate
        Next
        Me.ArrHeatEradiate(0).HeatName = "����"
        Me.ArrHeatEradiate(0).Heat = Me.FormulaDieQ()
        Me.ArrHeatEradiate(0).Checkd = True

        Me.ArrHeatEradiate(1).HeatName = "��������"
        Me.ArrHeatEradiate(1).Heat = Me.FormulaBurnTwo()
        Me.ArrHeatEradiate(1).Checkd = True

        Me.ArrHeatEradiate(2).HeatName = "һ������"
        Me.ArrHeatEradiate(2).Heat = Me.FormulaBurnOne()
        Me.ArrHeatEradiate(2).Checkd = True

        Me.ArrHeatEradiate(3).HeatName = "�Ʋ���ʧ"
        Me.ArrHeatEradiate(3).Heat = Me.FormulaWealthDamnify()
        Me.ArrHeatEradiate(3).Checkd = True
    End Sub
    ''' <summary>
    ''' ���������������ͨ��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaDieQ() As Double
        Dim DieQ As Double
        DieQ = (1 / Me.m_T * System.Math.Exp((5 + 37.23) / 2.56)) ^ 0.75
        Return DieQ
    End Function
    ''' <summary>
    ''' '����һ�����˾������ͨ��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaBurnOne() As Double
        Dim burnOne As Double

        burnOne = (1 / Me.m_T * System.Math.Exp((5 + 39.83) / 3.0188)) ^ 0.75
        Return burnOne
    End Function
    ''' <summary>
    ''' ����������˾������ͨ��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaBurnTwo() As Double

        Dim burnTwo As Double
        burnTwo = (1 / Me.m_T * System.Math.Exp((5 + 43.14) / 3.0188)) ^ 0.75
        Return burnTwo
    End Function
    ''' <summary>
    '''����Ʋ���ʧ�������ͨ��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaWealthDamnify() As Double

        Dim wealth As Double
        wealth = 6730 * Me.m_T ^ (-0.8) + 25400
        Return wealth
    End Function
    ''' <summary>
    ''' ͨ����������ȷ���ͨ������������������ȷ���ͨ�����������ϵ���Ի��淽��ΪY�ᣬ��ֱ����ΪX������ꡣ
    ''' </summary>
    ''' <param name="point2d">����</param>
    ''' <returns>Ŀ�����ȷ���ͨ��</returns>
    ''' <remarks></remarks>
    Private Function FormulaQ(ByVal point2d As Point2D) As Double
        Dim dblQi As Double = 0
        Dim P As New Point2D
        Dim D As Double
        For i As Integer = 0 To Me.m_n - 1
            P.x = 0
            P.y = (i + 1) * Me.m_L / Me.m_n
            D = Math.Sqrt((point2d.x - P.x) ^ 2 + (point2d.y - P.y) ^ 2)
            'ȷ��D��Ϊ0
            If D <= 0 Then
                D = 0.000000001
            End If
            dblQi += Qi(D)
        Next
        Return dblQi
    End Function
    ''' <summary>
    ''' �����Դxi��ĳ����յ��ȷ���ͨ��
    ''' </summary>
    ''' <param name="xi">��Դ����յ�ľ���</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Qi(ByVal xi As Double)
        Qi = Me.m_Xp * Me.m_E / (4 * Math.PI * xi ^ 2)
    End Function
    ''' <summary>
    ''' �����Ļ��泤��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunctionL() As Double
        Return (Me.m_Hc * Me.m_M) ^ 0.444 / 161.66
    End Function
    ''' <summary>
    ''' �������Դ�ȷ���ͨ����W
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FunctionE() As Double
        Return Me.m_f * Me.m_M * Me.m_Hc / Me.m_n
    End Function

    ''' <summary>
    ''' ���ݸ������ȷ���������þ���
    ''' </summary>
    ''' <param name="y"> ����Ϊyˮƽ��</param>
    ''' <param name="qAny"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RadiusP(ByVal y As Double, ByVal qAny As Double) As Point2D
        'ͨ���ڲ巨���㲻ͬ���˺��뾶
        Dim dblQ As Double
        Dim RINT As New Point2D
        Dim RINT1 As New Point2D
        Dim RINT2 As New Point2D
        RINT1.x = 0 '��СΪ�뾶0��Ϊ�˱������
        RINT1.y = y

        RINT2.x = 10000 '���Ϊ10000��
        RINT2.y = y

        RINT.x = 10000
        RINT.y = y

        Dim P As New Point2D
        P.x = 0
        P.y = y
        dblQ = FormulaQ(P)
        If dblQ < qAny Then '�����ڶ�Ӧ���ȷ�����룬��
            RINT = P
            Return RINT
        Else

            dblQ = FormulaQ(RINT)
            While System.Math.Abs(dblQ - qAny) > 1

                If dblQ - qAny < 0 Then
                    RINT2.x = RINT.x
                Else
                    RINT1.x = RINT.x
                End If
                RINT.x = (RINT1.x + RINT2.x) / 2
                dblQ = FormulaQ(RINT)
            End While
            RadiusP = RINT
        End If
    End Function
    ''' <summary>
    ''' �����˺���Ӧ�ĵ������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetHurtPoints(ByVal dblq As Double) As Point2D()
        Dim p As New Point2D
        Dim a1(-1) As Point2D
        p.y = Me.m_L / 2
        p = RadiusP(p.y, dblq)

        While p.x > 0
            ReDim Preserve a1(a1.Length)
            a1(a1.Length - 1) = New Point2D
            a1(a1.Length - 1).x = p.x
            a1(a1.Length - 1).y = p.y
            p.y += Me.m_L / (Me.m_n + 1)
            p = RadiusP(p.y, dblq)
        End While
        Dim a2(a1.Length - 1) As Point2D
        For i As Integer = 0 To a2.Length - 1
            a2(i) = New Point2D
            a2(i).x = -a1(a1.Length - 1 - i).x
            a2(i).y = a1(a1.Length - 1 - i).y
        Next

        Dim a3(a1.Length - 1) As Point2D
        For i As Integer = 0 To a3.Length - 1
            a3(i) = New Point2D
            a3(i).x = -a1(i).x
            a3(i).y = Me.m_L - a1(i).y
        Next
        Dim a4(a1.Length - 1) As Point2D
        For i As Integer = 0 To a4.Length - 1
            a4(i) = New Point2D
            a4(i).x = a1(a1.Length - 1 - i).x
            a4(i).y = Me.m_L - a1(a1.Length - 1 - i).y
        Next
        Dim a(a1.Length + a2.Length + a3.Length + a4.Length - 1) As Point2D
        For i As Integer = 0 To a1.Length - 1
            a(i) = a1(i)
        Next
        For i As Integer = 0 To a2.Length - 1
            a(i + a1.Length) = a2(i)
        Next
        For i As Integer = 0 To a3.Length - 1
            a(i + a1.Length + a2.Length) = a3(i)
        Next
        For i As Integer = 0 To a4.Length - 1
            a(i + a1.Length + a2.Length + a3.Length) = a4(i)
        Next
        Return a
    End Function


    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <param name="m_carepoint">���������Ӧ�Ĺ��ĵ�</param>
    ''' <param name="ChangeDistance">��������Ӧ�Ĺ��ĵ�</param>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint(), ByVal ChangeDistance As CarePoint())
        '�����Ļ��泤��
        Me.m_L = FunctionL()
        '����Դ�ȷ���ͨ����W
        Me.m_E = FunctionE()
        '���ݲ������ȷ���
        ReDim Me.m_ResultStepDp(Me.m_StepCount - 1)
        Dim c As Integer '����
        Dim Pc As New Point2D '������Ӧ�ĵ������
        For i As Integer = 0 To Me.m_StepCount - 1
            c = (Me.m_StepLong + i * Me.m_StepLong)
            Pc.x = c
            Pc.y = Me.m_L / 2
            m_ResultStepDp(i) = FormulaQ(Pc)
        Next

        '���������뾶���������ˡ�һ�����˺ͲƲ���ʧ��ͨ���Ͱ뾶
        Dim dblQDie As Double
        Dim dblQDamage2 As Double
        Dim dblQDamage1 As Double
        Dim dblQWealth As Double
        '����ͼ��������
        ReDim Me.m_ResultHurtPoint(Me.m_ArrHeatEradiate.Length - 1)
        '������Ӧ�İ뾶
        If Me.m_ArrHeatEradiate(0).Checkd = True Then
            dblQDie = FormulaDieQ() '����������ȷ���ͨ��
            Me.m_ResultHurtPoint(0) = New hurtPointstruct '�¶���
            Me.m_ResultHurtPoint(0).ArrayHurtPoint = GetHurtPoints(dblQDie)
        End If
        If Me.m_ArrHeatEradiate(1).Checkd = True Then '�������˰뾶
            dblQDamage2 = FormulaBurnTwo() '��ö������˵��ȷ���ͨ��
            Me.m_ResultHurtPoint(1) = New hurtPointstruct
            Me.m_ResultHurtPoint(1).ArrayHurtPoint = GetHurtPoints(dblQDamage2)
        End If
        If Me.m_ArrHeatEradiate(2).Checkd = True Then
            dblQDamage1 = FormulaBurnOne()
            Me.m_ResultHurtPoint(2) = New hurtPointstruct
            Me.m_ResultHurtPoint(2).ArrayHurtPoint = GetHurtPoints(dblQDamage1)
        End If
        If Me.m_ArrHeatEradiate(3).Checkd = True Then
            dblQWealth = FormulaWealthDamnify()
            Me.m_ResultHurtPoint(3) = New hurtPointstruct
            Me.m_ResultHurtPoint(3).ArrayHurtPoint = GetHurtPoints(dblQWealth)
        End If
        'ͨ���ȷ���ͨ���������
        If Me.m_ArrHeatEradiate.Length > 4 Then
            For i As Integer = 4 To Me.m_ArrHeatEradiate.Length - 1
                Me.m_ResultHurtPoint(i) = New hurtPointstruct
                Me.m_ResultHurtPoint(i).ArrayHurtPoint = GetHurtPoints(Me.m_ArrHeatEradiate(i).Heat)
            Next
        End If

        '����Ԥ���
        Dim dblQ As Double 'Ŀ�괦���ȷ���ͨ��
        Dim strQ As String
        strQ = ""
        If m_carepoint.Length > 0 Then '����й��ĵ�
            For i As Integer = 0 To m_carepoint.Length - 1
                dblQ = FormulaQ(ChangeDistance(i).Rpoint)
                m_carepoint(i).ResultDistanceDp = dblQ '�ȷ���
                m_carepoint(i).Pr = DiePr.DiePr(m_T, dblQ) '������������ 
                m_carepoint(i).D = DiePr.NormalSchool(m_carepoint(i).Pr) * 100 '�����ٷ���
            Next
        End If
    End Sub
    ''' <summary>
    ''' ���ؼ���������������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint(), ByVal ChangeDistance As CarePoint()) As String
        Dim strResults As String = "" '������
        strResults += "�����Ļ��泤��Ϊ��" & FormatNumber(m_L, 1) & "m" & vbCrLf
        strResults += "�ػ�������ȷ���ͨ��Ϊ��" & FormatNumber(m_E, 0) & "W/m^2" & vbCrLf


        ' �ڿ��аѾ������ʾ����
        'strResults += vbCrLf
        'strResults += "�¹��𺦺��                    �𺦰뾶(m)           ��Ӧ���ȷ���ͨ��(W/m^2)" & vbCrLf


        'For i As Integer = 0 To Me.m_ArrHeatEradiate.Length - 1
        '    If m_ArrHeatEradiate(i).Checkd = True And Me.m_ResultHurtPoint(i).ArrayHurtPoint > 0.0 Then '���ѡ�в�����İ뾶>0
        '        Dim strL As String = ""
        '        strL = LSet(Me.m_ArrHeatEradiate(i).HeatName, 30)

        '        strL += LSet(FormatNumber(m_ResultR(i), dNum, TriState.True, TriState.False, TriState.False), 20)
        '        strL += FormatNumber(m_ArrHeatEradiate(i).Heat, pNum, TriState.True, TriState.False, TriState.False)
        '        strResults = strResults & strL & vbCrLf
        '    End If
        'Next


        If m_carepoint.Length > 0 Then
            strResults += vbCrLf
            strResults += "���������              ����(x,y)          �ȷ���ͨ��(W/m^2)         ��������                ������(%)" & vbCrLf
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
                strL = strL.Insert(20, "(" & ChangeDistance(k).Rpoint.x & "," & ChangeDistance(k).Rpoint.y & ")                              ")
                strL = strL.Insert(40, FormatNumber(m_carepoint(k).ResultDistanceDp, pNum, TriState.True, TriState.False, TriState.False))
                strL = strL.Insert(70, FormatNumber(m_carepoint(k).Pr, 2, TriState.True, TriState.False, TriState.False))
                strL = strL.Insert(100, FormatNumber(m_carepoint(k).D, 1, TriState.True, TriState.False, TriState.False))
                strResults = strResults & strL & vbCrLf
            End If
        Next


        If Me.m_ResultStepDp.Length > 0 Then
            strResults += vbCrLf
            strResults += "����(m)              �ȷ���ͨ��(W/m^2)" & vbCrLf
        End If
        For i As Integer = 0 To m_StepCount - 1
            If Me.m_ResultStepDp(i) = 0 Then
                Dim strL As String = ""
                strL = FormatNumber(Me.m_StepLong * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, "-")
                strResults = strResults & strL & vbCrLf
            Else
                Dim strL As String = ""
                strL = FormatNumber(Me.m_StepLong * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, FormatNumber(Me.m_ResultStepDp(i), pNum, TriState.True, TriState.False, TriState.False))
                strResults = strResults & strL & vbCrLf
            End If
        Next
        Return strResults
    End Function
End Class
