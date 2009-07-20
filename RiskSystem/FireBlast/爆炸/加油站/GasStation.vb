Public Class GasStation
    Inherits BaseBoo
    
    ''' <summary>
    ''' ��ʾ�ù�ʽ�����������뾶�ͲƲ���ʧ�뾶
    ''' </summary>
    ''' <remarks></remarks>
    Private m_FormulaChecked As Boolean = True
    
    Private m_a As Double = 0.04 '�����Ʊ�ը��Ч�����ӣ��������뱬ը�Ŀ�ȼ����ķ���
    Private m_Wf As Double = 20000 '��������ȼ�ϵ���������kg
    Private m_Qf As Double = 40000000 '������ȼ���ȣ�J/kg
    Private m_QTNT As Double = 4.52 * 1000000 '����TNT�ı�ը�ȣ�һ��ȡ4.52��106J/kg
   
    ''' <summary>
    ''' �����Ʊ�ը��Ч�����ӣ��������뱬ը�Ŀ�ȼ����ķ�����һ��ȡ3%��4%
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property a() As Double
        Get
            Return Me.m_a
        End Get
        Set(ByVal value As Double)
            Me.m_a = value
        End Set
    End Property
    ''' <summary>
    ''' ��������ȼ�ϵ���������kg
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Wf() As Double
        Get
            Return Me.m_Wf
        End Get
        Set(ByVal value As Double)
            Me.m_Wf = value
        End Set
    End Property
    ''' <summary>
    ''' ������ȼ���ȣ�J/kg
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Qf() As Double
        Get
            Return Me.m_Qf
        End Get
        Set(ByVal value As Double)
            Me.m_Qf = value
        End Set
    End Property

    ''' <summary>
    ''' ��ʾ�ù�ʽ�����������뾶�ͲƲ���ʧ�뾶
    ''' </summary>
    ''' <remarks></remarks>
    Property FormulaChecked() As Boolean
        Get
            Return Me.m_FormulaChecked
        End Get
        Set(ByVal value As Boolean)
            Me.m_FormulaChecked = value
        End Set
    End Property

    Public Sub New()
        m_SourceName = "��������"
        m_Name = "����"
    End Sub
    ''' <summary>
    ''' ȡ��TNT����
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WTNT() As Double '���������Ƶ�TNT����
        WTNT = a * Me.m_Wf * Me.m_Qf / Me.m_QTNT
    End Function

    ''' <summary>
    ''' ͨ��������㳬ѹ
    ''' </summary>
    ''' <param name="WTNT"></param>
    ''' <param name="R"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function db(ByVal WTNT As Double, ByVal R As Double) As Double
        Dim P As Double = 8 * (R / (WTNT) ^ (1 / 3)) ^ (-3)
        Return P * 98.0665 * 1000
    End Function
    ''' <summary>
    ''' ��ը�����������ѹ��ľ���
    ''' </summary>
    ''' <param name="WTNT"></param>
    ''' <param name="dP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RTNT(ByVal WTNT As Double, ByVal dP As Double) As Double
        Dim p As Double = dP * 10.1972 / 1000000
        RTNT = 2 * (WTNT / p) ^ (1 / 3)
    End Function

    ''' <summary>
    ''' ������ֱ�ըģ��
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        '�������ò�ͬ�����Ӧ�ĳ�ѹ����
        Me.m_WTNT = WTNT()
        For i As Integer = 0 To m_carepoint.Length - 1
            Dim R As Double = GetR(m_carepoint(i).Rpoint, Me.m_SoucePoint) '�����������õ�����
            m_carepoint(i).ResultDistanceDp = db(m_WTNT, R) '���ݾ������õ���ѹ
            m_carepoint(i).Pr = DiePr.TNTDiePr(m_carepoint(i).ResultDistanceDp) '������������
            m_carepoint(i).D = DiePr.NormalSchool(m_carepoint(i).Pr) * 100 '�������������
        Next
        '���ݲ�����ѹ
        ReDim Me.m_ResultStepDp(Me.m_Tcount - 1)
        Dim c As Integer '����
        For i As Integer = 0 To Me.m_Tcount - 1
            c = (Me.m_Tstep + i * Me.m_Tstep)
            m_ResultStepDp(i) = db(Me.m_WTNT, c)
        Next
        '���ݳ�ѹ�������
        ReDim Me.m_ResultR(Me.m_DestroyR.Length - 1)
        For i As Integer = 0 To Me.m_DestroyR.Length - 1
            Me.m_ResultR(i) = RTNT(Me.m_WTNT, Me.m_DestroyR(i).MDrang) 'ͨ����ѹ�������
        Next
        '�ù�ʽ�����������뾶�ͲƲ���ʧ�뾶
        If Me.m_FormulaChecked = True Then '�ù�ʽ�����������뾶�ͲƲ���ʧ�뾶
            Me.m_ResultR(0) = R05(m_WTNT) '�����뾶
            Me.m_ResultR(3) = RWealth(m_WTNT)
        End If
    End Sub
    ''' <summary>
    ''' ���������뾶
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function R05(ByVal WTNT As Double) As Double '���������뾶
        R05 = 13.6 * (WTNT / 1000) ^ 0.37
    End Function
    ''' <summary>
    ''' ��ʽ������Ʋ���ʧ�뾶
    ''' </summary>
    ''' <param name="WTNT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RWealth(ByVal WTNT As Double) As Double '����Ʋ���ʧ�뾶
        RWealth = 4.6 * WTNT ^ (1 / 3) / ((1 + (3175 / WTNT) ^ 2) ^ (1 / 6))
    End Function
    ''' <summary>
    ''' ���ؼ�������������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint()) As String
        '�޸ĵĴ��룭��������������������������������������������������������������������������
        Dim strResults As String = ""
        strResults = "�¹�Դ" & Me.m_SourceName & "���������£�" & vbCrLf

        strResults = strResults & "TNT����Ϊ" & m_WTNT & "kg" & vbCrLf

        ' �ڿ��аѾ������ʾ����
        If Me.m_DestroyR.Length > 0 Then
            strResults += vbCrLf
            strResults += "�¹��𺦺��                    �𺦰뾶(m)" & vbCrLf
        End If
        For i As Integer = 0 To Me.m_DestroyR.Length - 1
            If m_DestroyR(i).Selected = True And m_DestroyR(i).MDrang > 0.0 Then
                Dim strL As String = ""
                strL = LSet(Me.m_DestroyR(i).MDrangName, 30)
                strL += FormatNumber(m_ResultR(i), dNum, TriState.True, TriState.False, TriState.False)
                strResults = strResults & strL & vbCrLf
            End If
        Next


        If m_carepoint.Length > 0 Then
            strResults += vbCrLf
            strResults += "���������              ����(x,y)           ��ѹֵ(Pa)                ��������                  ������(%)" & vbCrLf
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
            strResults += "����(m)              ��ѹֵ(Pa)" & vbCrLf
        End If
        For i As Integer = 0 To m_Tcount - 1
            If Me.m_ResultStepDp(i) = 0 Then
                Dim strL As String = ""
                strL = FormatNumber(Me.Tstep * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, "-")
                strResults = strResults & strL & vbCrLf
            Else
                Dim strL As String = ""
                strL = FormatNumber(Me.Tstep * (i + 1), dNum) & "                                                      "
                strL = strL.Insert(20, FormatNumber(Me.m_ResultStepDp(i), pNum, TriState.True, TriState.False, TriState.False))
                strResults = strResults & strL & vbCrLf
            End If
        Next

        Return strResults & vbCrLf & vbCrLf
    End Function
End Class
