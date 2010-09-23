''' <summary>
''' ƽ��ģ��
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class SlabHeavy
    ''' <summary>
    ''' Ħ��������kg/mol
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MgMol As Double = 0.07091
    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_K As Double = 1
    ''' <summary>
    ''' �������ٶ�
    ''' </summary>
    ''' <remarks></remarks>
    Private m_g As Double = 9.8
    ''' <summary>
    ''' ����ѹ�����¶��¿������ܶ�
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Densitya As Double = 1.29
    ''' <summary>
    ''' ����ѹ�����¶���й©������ܶ�
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Densityg As Double = 3.16
    ''' <summary>
    ''' �����ӱ�Ե����ϵ��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_a1 As Double = 0.6
    ''' <summary>
    ''' ���鳣��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_a2 As Double = 0.1
    ''' <summary>
    ''' Von Karmans ������ȡ0.4
    ''' </summary>
    ''' <remarks></remarks>
    Private m_kV As Double = 0.4

    ''' <summary>
    ''' �߶�Z��m��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Z As Double = 10
    ''' <summary>
    ''' �������¶ȣ�K
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Tempa As Double = 273.15 + 16
    ''' <summary>
    ''' ���������ݣ�J/K.kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cpa As Double = 1000
    ''' <summary>
    ''' ������ԭй©������������ʣ�kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MgS As Double = 0
    ''' <summary>
    ''' ��ʼ��������Ŀ������������ʣ�kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MaS As Double = 0

    ''' <summary>
    ''' й©��������ݣ�J/K.kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cpg As Double = 1400

    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Ground As String = "ũ�������"
    ''' <summary>
    ''' ����ѹ��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pa As Double = 101325
    ''' <summary>
    ''' ��������������״̬����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_slabMetAndMass As SlabMetAndMass

    ''' <summary>
    ''' ��ʼ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_L0 As Double = 10


#Region "����"




    Property MgMol() As Double
        Get
            Return Me.m_MgMol
        End Get
        Set(ByVal value As Double)
            Me.m_MgMol = value
        End Set
    End Property


    ''' <summary>
    ''' ����ѹ�����¶��¿������ܶ�
    ''' </summary>
    ''' <remarks></remarks>
    Property Densitya() As Double
        Get
            Return Me.m_Densitya
        End Get
        Set(ByVal value As Double)
            Me.m_Densitya = value
        End Set
    End Property
    ''' <summary>
    ''' ����ѹ�����¶���й©������ܶ�
    ''' </summary>
    ''' <remarks></remarks>
    Property Densityg() As Double
        Get
            Return Me.m_Densityg
        End Get
        Set(ByVal value As Double)
            Me.m_Densityg = value
        End Set
    End Property


    ''' <summary>
    ''' �������¶ȣ�K
    ''' </summary>
    ''' <remarks></remarks>
    Property Tempa() As Double
        Get
            Return Me.m_Tempa
        End Get
        Set(ByVal value As Double)
            Me.m_Tempa = value
        End Set
    End Property

    ''' <summary>
    ''' ������ԭй©�����������kg
    ''' </summary>
    ''' <remarks></remarks>
    Property MgS() As Double
        Get
            Return Me.m_MgS
        End Get
        Set(ByVal value As Double)
            Me.m_MgS = value
        End Set
    End Property
    ''' <summary>
    ''' ��ʼ��������Ŀ������������ʣ�kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Property MaS() As Double
        Get
            Return Me.m_MaS
        End Get
        Set(ByVal value As Double)
            Me.m_MaS = value
        End Set
    End Property

    ''' <summary>
    ''' й©��������ݣ�J/K.kg
    ''' </summary>
    ''' <remarks></remarks>
    Property Cpg() As Double
        Get
            Return Me.m_Cpg
        End Get
        Set(ByVal value As Double)
            Me.m_Cpg = value
        End Set
    End Property

    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <remarks></remarks>
    Property Ground() As String
        Get
            Return Me.m_Ground
        End Get
        Set(ByVal value As String)
            Me.m_Ground = value
        End Set
    End Property
    ''' <summary>
    ''' ��������������״̬����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SlabMetAndMass() As SlabMetAndMass
        Get
            Return Me.m_slabMetAndMass
        End Get
        Set(ByVal value As SlabMetAndMass)
            Me.m_slabMetAndMass = value
        End Set
    End Property
    ''' <summary>
    ''' ����ѹ��
    ''' </summary>
    ''' <remarks></remarks>
    Property Pa() As Double
        Get
            Return Me.m_Pa
        End Get
        Set(ByVal value As Double)
            Me.m_Pa = value
        End Set
    End Property
    ''' <summary>
    ''' ��ʼ���
    ''' </summary>
    ''' <remarks></remarks>
    Property L0() As Double
        Get
            Return Me.m_L0
        End Get
        Set(ByVal value As Double)
            Me.m_L0 = value
        End Set
    End Property
#End Region
#Region "����"

    Public Sub New()
        Me.m_slabMetAndMass = New SlabMetAndMass
        Me.m_slabMetAndMass.slabAirMass(0) = New SlabAirMass
        Me.m_slabMetAndMass.slabAirMass(0).m_Ma = Me.m_MaS / Me.m_slabMetAndMass.u10   '��ʾ��ʼ�������ŵ�������kg/m��
        Me.m_slabMetAndMass.slabAirMass(0).m_Temp = 273.15
    End Sub

    ''' <summary>
    '''  �����������������ܶ�
    ''' </summary>
    ''' <param name="dblMa">���������������</param>
    ''' <param name="dblMg">������ԭй©���������</param>
    ''' <param name="dblDensitya">����ѹ�����¶��¿������ܶ�</param>
    ''' <param name="dblDensityg">����ѹ�����¶���й©������ܶ�</param>
    ''' <param name="dblTa">�������¶ȣ�K</param>
    ''' <param name="dblT">���ŵ��¶ȣ�K</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FDensity(ByVal dblMa As Double, ByVal dblMg As Double, ByVal dblDensitya As Double, ByVal dblDensityg As Double, ByVal dblTa As Double, ByVal dblT As Double) As Double
        Return (dblMa + dblMg) / ((dblMa / dblDensitya + dblMg / dblDensityg) * dblT / dblTa)
    End Function
    ''' <summary>
    ''' ��������������Ű���������
    ''' </summary>
    ''' <param name="dbldx">�·��������</param>
    ''' <param name="dblH">���Ÿ߶�</param>
    ''' <param name="dblDensity">�����ܶ�</param>
    ''' <param name="dblDensitya">����ѹ�����¶��¿������ܶ�</param>
    ''' <param name="dblu2">й©�߶ȴ�����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FdL(ByVal dbldx As Double, ByVal dblH As Double, ByVal dblDensity As Double, ByVal dblDensitya As Double, ByVal dblu2 As Double)
        If dblDensity - dblDensitya > 0 Then
            Return (dbldx * Math.Sqrt(Me.m_K * Me.m_g * dblH * (dblDensity - dblDensitya) / dblDensitya)) / dblu2
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    '''���������������ӱ�Ե�������ŵ������� kg��
    ''' </summary>
    ''' <param name="dbldx">�·������</param>
    ''' <param name="dblDensitya">����ѹ�����¶��¿������ܶ�</param>
    ''' <param name="dblH">���Ÿ߶�</param>
    ''' <param name="dblL">ĳһʱ��������İ��</param>
    ''' <param name="dbldL">������İ��ı仯�ٶ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FdMa1(ByVal dbldx As Double, ByVal dblDensitya As Double, ByVal dblH As Double, ByVal dblL As Double, ByVal dbldL As Double)
        'Dim dblMa1 As Double = 2 * Me.m_a1 * dblDensitya * dblH * dbldL * dbldx
        'Return dblMa1

        Dim dblMa1 As Double = 2 * Me.m_a1 * dblDensitya * dblH * dbldL * dbldx
        Return dblMa1

    End Function
    ''' <summary>
    ''' �����Ӷ����������ŵ���������kg
    ''' </summary>
    ''' <param name="dbldx">�·�������������</param>
    ''' <param name="dblDensitya">����ѹ�����¶��¿������ܶ�</param>
    ''' <param name="dblDensity">�����ܶ�</param>
    ''' <param name="dblH">���Ÿ߶�</param>
    ''' <param name="dblR">ĳһʱ�������ŵİ��</param>
    ''' <param name="dblu">�߶�Z���ķ��٣�m/s,Zͨ��ȡ10m</param>
    ''' <param name="dblZ">�߶�Z��ͨ��ȡ10</param>
    ''' <param name="stab">�����ȶ��ȣ�ȡA��B��C��D��E��F�����ȡ������Ҫת��һ��</param>
    ''' <param name="Ground"></param>
    ''' <param name="dblu2">����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fdMa2(ByVal dbldx As Double, ByVal dblDensitya As Double, ByVal dblDensity As Double, ByVal dblH As Double, ByVal dblR As Double, ByVal dblu As Double, ByVal dblZ As Double, ByVal stab As String, ByVal Ground As String, ByVal dblu2 As Double) As Double

        'Dim dblutux As Double

        'If stab = "A" Or stab = "B" Or stab = "A-B" Or stab = "B-C" Then
        '    dblutux = 3.0
        'ElseIf stab = "C" Or stab = "D" Or stab = "C-D" Then
        '    dblutux = 2.4
        'ElseIf stab = "E" Or stab = "F" Then
        '    dblutux = 1.6
        'End If
        'Dim dblZ0 As Double
        'If Ground = "��ԭ��ƽ̹������" Then
        '    dblZ0 = 0.1
        'ElseIf Ground = "ũ�������" Then
        '    dblZ0 = 0.2
        'ElseIf Ground = "���䡢��ɢ������" Then
        '    dblZ0 = 0.65
        'ElseIf Ground = "��ɢ�ĸ߰�������(����)" Then
        '    dblZ0 = 2.5
        'ElseIf Ground = "��ɢ�ĸ߰�������(�����)" Then
        '    dblZ0 = 4
        'End If
        ''��Ls��������
        'Dim dblLs As Double
        'dblLs = 5.88 * dblH ^ 0.48
        'Dim dbluxu As Double
        'dbluxu = 0.4 / Math.Log10(dblZ / dblZ0)

        ''��ˮƽ�����ٶ�
        'Dim dblut As Double
        'dblut = dblutux * dbluxu * dblu
        ''��Ri��
        'Dim dblRi As Double
        'dblRi = Me.m_g * dblLs * (dblDensity - dblDensitya) / dblDensitya * (dblut ^ (-2))
        'Dim dblMa2 As Double
        'dblMa2 = (Me.m_a2 * dblDensitya * 2 * dbldx * dblR * dblut / dblRi) * dbldx / dblu2
        'Return dblMa2

        Dim dblutux As Double

        If stab = "A" Or stab = "B" Or stab = "A-B" Or stab = "B-C" Then
            dblutux = 3.0
        ElseIf stab = "C" Or stab = "D" Or stab = "C-D" Then
            dblutux = 2.4
        ElseIf stab = "E" Or stab = "F" Then
            dblutux = 1.6
        End If
        Dim dblZ0 As Double
        If Ground = "��ԭ��ƽ̹������" Then
            dblZ0 = 0.1
        ElseIf Ground = "ũ�������" Then
            dblZ0 = 0.2
        ElseIf Ground = "���䡢��ɢ������" Then
            dblZ0 = 0.65
        ElseIf Ground = "��ɢ�ĸ߰�������(����)" Then
            dblZ0 = 2.5
        ElseIf Ground = "��ɢ�ĸ߰�������(�����)" Then
            dblZ0 = 4
        End If
        '��Ls��������
        Dim dblLs As Double
        dblLs = 5.88 * dblH ^ 0.48
        Dim dbluxu As Double
        dbluxu = 0.1

        '��ˮƽ�����ٶ�
        Dim dblut As Double
        dblut = dblutux * dbluxu * dblu
        '��Ri��
        Dim dblRi As Double
        dblRi = Me.m_g * dblLs * (dblDensity - dblDensitya) / dblDensitya * (dblut ^ (-2))
        Dim dblMa2 As Double
        dblMa2 = (Me.m_a2 * dblDensitya * 2 * dbldx * dblR * dblut / dblRi) * dbldx / dblu2
        Return dblMa2

    End Function
    ''' <summary>
    ''' ���������¶ȱ仯
    ''' </summary>
    ''' <param name="dblCpa">����������</param>
    ''' <param name="dblCpg">й©���������</param>
    ''' <param name="dbldMa">��������������仯��</param>
    ''' <param name="dblMa">���������������</param>
    ''' <param name="dblMg">������ԭй©���������</param>
    ''' <param name="dblTa">�������¶�,K</param>
    ''' <param name="dblT">�����¶�,K</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FdT(ByVal dblCpa As Double, ByVal dblCpg As Double, ByVal dbldMa As Double, ByVal dblMa As Double, ByVal dblMg As Double, ByVal dblTa As Double, ByVal dblT As Double) As Double
        Dim dbldQ2 As Double = dbldMa * dblCpa * (dblTa - dblT)
        Dim dbldt As Double = dbldQ2 / ((dblMa + dbldMa) * dblCpa + dblMg * dblCpg)
        Return dbldt
    End Function
    ''' <summary>
    ''' ������Ⱦ���Ũ��
    ''' </summary>
    ''' <param name="dblV">���ŵ�����Ľ����,m2</param>
    ''' <param name="dblMg">��λ��������������Ⱦ�������,kg/m</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FC(ByVal dblV As Double, ByVal dblMg As Double) As Double
        Return dblMg * 1000000 / dblV
    End Function

    Public Sub CalHeavy()
        If Me.m_MgS <= 0 Then 'й©����Ϊ0
            Exit Sub
        End If

        '�ڼ���֮ǰ�ȸ��ݻ���ѹ�����¶�����������ܶȺ�й©�����ڸ��¶Ⱥ�ѹ���µ��ܶ�------------
        Me.m_Densitya = Me.m_Pa * 298.15 * 29 / (101325 * Me.m_Tempa * 22.4)
        Me.m_Densityg = Me.m_Pa * 298.15 * Me.m_MgMol * 1000 / (101325 * Me.m_Tempa * 22.4)
        If Me.m_Densityg <= Me.m_Densitya Then
            Exit Sub
        End If
        '--------------------------------------------
        Dim dbldx As Double = 0.1 '�·��������ȡ0.1m
        Dim j As Integer = 0
        Dim dbldL As Double '���������
        Dim dbldMa1 As Double 'ĳһ�·����������ӱ�Ե�������ŵ�����kg�����磬�����򻮷�Ϊ0.1mһ�����Σ���Ϊ��0.1m�ڵĵ�����
        Dim dbldMa2 As Double 'ĳһ�·����������Ӷ����������ŵ�����kg�����磬�����򻮷�Ϊ0.1mһ�����Σ���Ϊ��0.1m�ڵĵ�����
        Dim dbldMa As Double 'ĳһ�·����������������ŵ��ܿ�������kg�����磬�����򻮷�Ϊ0.1mһ�����Σ���Ϊ��0.1m�ڵĵ�����
        Dim dbldTemp As Double 'ĳһ�·�������ɿ�������������¶ȱ仯
        '��ʼ������
        ReDim Preserve Me.m_slabMetAndMass.slabAirMass(0)
        '������ĵ�λתÿһ���е����ʵ���
        Me.m_slabMetAndMass.Mg = Me.m_MgS / Me.m_slabMetAndMass.u10 * dbldx
        Me.m_slabMetAndMass.slabAirMass(0).m_Ma = Me.m_MaS / Me.m_slabMetAndMass.u10 * dbldx

        Me.m_slabMetAndMass.slabAirMass(0).m_Density = FDensity(Me.m_slabMetAndMass.slabAirMass(0).m_Ma, Me.m_slabMetAndMass.Mg, Me.m_Densitya, Me.m_Densityg, Me.m_Tempa, Me.m_slabMetAndMass.slabAirMass(0).m_Temp)
        Me.m_slabMetAndMass.slabAirMass(0).m_V = (Me.m_slabMetAndMass.slabAirMass(0).m_Ma + Me.m_slabMetAndMass.Mg) / Me.m_slabMetAndMass.slabAirMass(0).m_Density '��ʼ������
        Me.m_slabMetAndMass.slabAirMass(0).m_H = Math.Sqrt(Me.m_slabMetAndMass.slabAirMass(0).m_V / 4) / dbldx
        Me.m_slabMetAndMass.slabAirMass(0).m_L = Me.m_slabMetAndMass.slabAirMass(0).m_H * 2
        Me.m_slabMetAndMass.slabAirMass(0).m_C = FC(Me.m_slabMetAndMass.slabAirMass(0).m_V, Me.m_slabMetAndMass.Mg) 'Ũ��

        j = 0
        Do
            ReDim Preserve Me.m_slabMetAndMass.slabAirMass(Me.m_slabMetAndMass.slabAirMass.Length)
            Me.m_slabMetAndMass.slabAirMass(Me.m_slabMetAndMass.slabAirMass.Length - 1) = New SlabAirMass
            '�������������
            dbldL = FdL(dbldx, Me.m_slabMetAndMass.slabAirMass(j).m_H, Me.m_slabMetAndMass.slabAirMass(j).m_Density, Me.m_Densitya, Me.m_slabMetAndMass.u10)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_L = Me.m_slabMetAndMass.slabAirMass(j).m_L + dbldL
            '�����ӱ�Ե�������ŵ�������
            dbldMa1 = FdMa1(dbldx, Me.m_Densitya, Me.m_slabMetAndMass.slabAirMass(j).m_H, Me.m_slabMetAndMass.slabAirMass(j).m_L, dbldL)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma1 = Me.m_slabMetAndMass.slabAirMass(j).m_Ma1 + dbldMa1 'ÿ��0.1�׵�������
            '�����Ӷ����������ŵ���������ÿ��0.1m��������
            dbldMa2 = fdMa2(dbldx, Me.m_Densitya, Me.m_slabMetAndMass.slabAirMass(j).m_Density, Me.m_slabMetAndMass.slabAirMass(j).m_H, Me.m_slabMetAndMass.slabAirMass(j).m_L, Me.m_slabMetAndMass.u10, Me.m_Z, Me.m_slabMetAndMass.stab, Me.m_Ground, Me.m_slabMetAndMass.u10)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma2 = Me.m_slabMetAndMass.slabAirMass(j).m_Ma2 + dbldMa2
            '����������ܵ���������ÿ��0.1m��������
            dbldMa = dbldMa1 + dbldMa2
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma = Me.m_slabMetAndMass.slabAirMass(j).m_Ma + dbldMa
            '���ŵ��¶ȱ仯
            dbldTemp = FdT(Me.m_Cpa, Me.m_Cpg, dbldMa, Me.m_slabMetAndMass.slabAirMass(j).m_Ma, Me.m_slabMetAndMass.Mg, Me.m_Tempa, Me.m_slabMetAndMass.slabAirMass(j).m_Temp)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Temp = Me.m_slabMetAndMass.slabAirMass(j).m_Temp + dbldTemp
            '���ŵ��ܶ�
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Density = FDensity(Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma, Me.m_slabMetAndMass.Mg, Me.m_Densitya, Me.m_Densityg, Me.m_Tempa, Me.m_slabMetAndMass.slabAirMass(j + 1).m_Temp)
            '���ŵ����
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_V = (Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma + Me.m_slabMetAndMass.Mg) / Me.m_slabMetAndMass.slabAirMass(j + 1).m_Density
            '���ŵĸ߶�
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_H = Me.m_slabMetAndMass.slabAirMass(j + 1).m_V / ((Me.m_slabMetAndMass.slabAirMass(j + 1).m_L + Me.m_slabMetAndMass.slabAirMass(j).m_L) * dbldx)
            '���ŵ���ɢ�ľ���
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_x = Me.m_slabMetAndMass.slabAirMass(j).m_x + dbldx
            '��������Ⱦ���Ũ��
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_C = FC(Me.m_slabMetAndMass.slabAirMass(j + 1).m_V, Me.m_slabMetAndMass.Mg)
            Dim dh As Double = Me.m_slabMetAndMass.slabAirMass(j + 1).m_H - Me.m_slabMetAndMass.slabAirMass(j).m_H
            If (Me.m_slabMetAndMass.slabAirMass(j + 1).m_Density - Me.m_Densitya) / Me.m_Densitya < 0.001 Then
                Exit Do
            End If
            j = j + 1
        Loop
        '��ʼ���������

    End Sub
#End Region
End Class
