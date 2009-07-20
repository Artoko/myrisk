Public Class SolidFire
    ''' <summary>
    ''' �¹�Դ����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceName As String = "�ⷿ" '
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name As String = "���" '
    ''' <summary>
    ''' �¹�Դ����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourcePoint As New Point2D '
    ''' <summary>
    ''' ����������W[ kg ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_W As Double = 100000  '
   
    ''' <summary>
    ''' ��¶ʱ��t[ s ]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_T As Double = 40 '
    ''' <summary>
    ''' Һ���ȼ����Hc[J/kg]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Hc As Double = 41792344 '
    ''' <summary>
    ''' ȼ�����ʣ�kg/s��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MC As Double = 5
    
    ''' <summary>
    ''' �ȷ���ϵ��f
    ''' </summary>
    ''' <remarks></remarks>
    Private m_F As Double = 0.25 '
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
    Private m_ResultR(-1) As Double


#Region "�м����"
    ''' <summary>
    ''' ȼ������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mf

    Private m_DurationT As Double
    ''' <summary>
    ''' �ػ�߶�
    ''' </summary>
    ''' <remarks></remarks>
    Private m_L As Double
    ''' <summary>
    ''' ��������ȷ�������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_E As Double
#End Region
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
    ''' ����������W[ kg ]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property W() As Double
        Get
            Return Me.m_W
        End Get
        Set(ByVal value As Double)
            Me.m_W = value
        End Set
    End Property
    
    ''' <summary>
    ''' ��¶ʱ��t[ s ]
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
    ''' Һ���ȼ����Hc[J/kg]
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
    ''' �ȷ���ϵ��f
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property F() As Double
        Get
            Return Me.m_F
        End Get
        Set(ByVal value As Double)
            Me.m_F = value
        End Set
    End Property
    ''' <summary>
    ''' ȼ�����ʣ�kg/s��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Mc() As Double
        Get
            Return Me.m_MC
        End Get
        Set(ByVal value As Double)
            Me.m_MC = value
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
    ''' ��ͬ��ѹ��Ӧ�ľ���
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultR() As Double()
        Get
            Return Me.m_ResultR
        End Get
        Set(ByVal value As Double())
            Me.m_ResultR = value
        End Set
    End Property
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
    ''' '����Ʋ���ʧ�������ͨ��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaWealthDamnify() As Double

        Dim wealth As Double
        wealth = 6730 * Me.m_T ^ (-0.8) + 25400
        Return wealth
    End Function
    ''' <summary>
    ''' 'ȼ�ճ���ʱ��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FormulaTime() As Double
        Dim T As Double = Me.m_W / Me.m_MC
        Return T
    End Function
   
    ''' <summary>
    ''' ͨ����������ȷ���ͨ
    ''' </summary>
    ''' <param name="paraX">����</param>
    ''' <returns>Ŀ�����ȷ���ͨ��</returns>
    ''' <remarks></remarks>
    Private Function FormulaQ(ByVal paraX As Double) As Double
        FormulaQ = Me.m_F * Me.m_MC * Me.m_Hc / (4 * Math.PI * paraX ^ 2)
    End Function


    ''' <summary>
    ''' ���ݸ������ȷ���������þ���
    ''' </summary>
    ''' <param name="q">Ŀ����ȷ���ͨ��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Radius(ByVal q As Double) As Double
        Return Math.Sqrt(Me.m_F * Me.m_MC * Me.m_Hc / (4 * Math.PI * q))
    End Function
    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        '�ػ����ȼ������

        m_mf = Me.m_MC

        '����ȼ��ʱ��
        m_DurationT = FormulaTime()


        '���������뾶���������ˡ�һ�����˺ͲƲ���ʧ��ͨ���Ͱ뾶
        Dim dblQDie As Double
        Dim dblQDamage2 As Double
        Dim dblQDamage1 As Double
        Dim dblQWealth As Double
        Dim dblRDie As Double
        Dim dblRDamage2 As Double
        Dim dblRDamage1 As Double
        Dim dblRWealth As Double

        ReDim Me.m_ResultR(Me.m_ArrHeatEradiate.Length - 1)
        '������Ӧ�İ뾶
        If Me.m_ArrHeatEradiate(0).Checkd = True Then
            dblQDie = FormulaDieQ() '����������ȷ���ͨ��
            dblRDie = Radius(dblQDie)
            If dblRDie = 0 Then
            Else
                '��Ҫ���Ľ��ѹ������
                Me.m_ArrHeatEradiate(0).Heat = dblQDie '�ȷ���ͨ��
                Me.m_ResultR(0) = dblRDie '�����뾶
            End If
        End If
        If Me.m_ArrHeatEradiate(1).Checkd = True Then '�������˰뾶
            dblQDamage2 = FormulaBurnTwo() '��ö������˵��ȷ���ͨ��
            dblRDamage2 = Radius(dblQDamage2)
            If dblRDamage2 = 0 Then
            Else
                '��Ҫ���Ľ��ѹ������
                Me.m_ArrHeatEradiate(1).Heat = dblQDamage2 '�ȷ���ͨ��
                Me.m_ResultR(1) = dblRDamage2 '�������˰뾶

            End If
        End If
        If Me.m_ArrHeatEradiate(2).Checkd = True Then
            dblQDamage1 = FormulaBurnOne()
            dblRDamage1 = Radius(dblQDamage1)
            If dblRDamage1 = 0 Then
            Else
            End If
            Me.m_ArrHeatEradiate(2).Heat = dblQDamage1 '�ȷ���ͨ��
            Me.m_ResultR(2) = dblRDamage1 'һ�����˰뾶
        End If
        If Me.m_ArrHeatEradiate(3).Checkd = True Then
            dblQWealth = FormulaWealthDamnify()
            dblRWealth = Radius(dblQWealth)
            If dblRWealth = 0 Then
            Else
                '���뾶ѹ������
                Me.m_ArrHeatEradiate(3).Heat = dblQWealth '�ȷ���ͨ��
                Me.m_ResultR(3) = dblRWealth '�Ʋ���ʧ�뾶
            End If
        End If

        'ͨ���ȷ���ͨ���������
        Dim dblR1 As Double
        Dim strR1 As String
        strR1 = ""
        If Me.m_ArrHeatEradiate.Length > 4 Then
            For i As Integer = 4 To Me.m_ArrHeatEradiate.Length - 1
                dblR1 = Radius(Me.m_ArrHeatEradiate(i).Heat)
                If Me.m_ArrHeatEradiate(i).Checkd = True Then
                    If dblR1 = 0 Then
                    Else
                        Me.m_ResultR(i) = dblR1
                    End If
                End If
            Next
        End If

        '���ݲ������ȷ���
        ReDim Me.m_ResultStepDp(Me.m_StepCount - 1)
        Dim c As Integer '����
        For i As Integer = 0 To Me.m_StepCount - 1
            c = (Me.m_StepLong + i * Me.m_StepLong)
            m_ResultStepDp(i) = FormulaQ(c)
        Next

        '����Ԥ���
        Dim dblQ As Double 'Ŀ�괦���ȷ���ͨ��
        Dim strQ As String
        strQ = ""
        If m_carepoint.Length > 0 Then '����й��ĵ�
            For i As Integer = 0 To m_carepoint.Length - 1
                Dim R As Double = GetR(m_carepoint(i).Rpoint, Me.m_SourcePoint) '���������

                dblQ = FormulaQ(R)
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
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint()) As String
        Dim strResults As String = "" '������
        'strResults = "�ػ�λ���ȼ������Ϊ" & m_mf & "kg/��s" & vbCrLf
        'strResults += "�ػ����ʱ��Ϊ��" & FormatNumber(m_DurationT, 0) & " s" & vbCrLf

        ' �ڿ��аѾ������ʾ����

        strResults += vbCrLf
        strResults += "�¹��𺦺��                    �𺦰뾶(m)           ��Ӧ���ȷ���ͨ��(W/m^2)" & vbCrLf


        For i As Integer = 0 To Me.m_ArrHeatEradiate.Length - 1
            If m_ArrHeatEradiate(i).Checkd = True And m_ResultR(i) > 0.0 Then '���ѡ�в�����İ뾶>0
                Dim strL As String = ""
                strL = LSet(Me.m_ArrHeatEradiate(i).HeatName, 30)

                strL += LSet(FormatNumber(m_ResultR(i), dNum, TriState.True, TriState.False, TriState.False), 20)
                strL += FormatNumber(m_ArrHeatEradiate(i).Heat, pNum, TriState.True, TriState.False, TriState.False)
                strResults = strResults & strL & vbCrLf
            End If
        Next


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
                strL = strL.Insert(20, "(" & m_carepoint(k).Rpoint.x & "," & m_carepoint(k).Rpoint.y & ")                              ")
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
