''' <summary>
''' ���ڴ�����������������״̬����
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class SlabMetAndMass
    ''' <summary>
    ''' ������ԭй©����ĵ�λ�����µ��������ʣ�kg/m
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Mg As Double

    ''' <summary>
    ''' ������������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SlabAirMass(0) As SlabAirMass

    ''' <summary>
    ''' �߶�Z���ķ��٣�Zͨ��ȡ10m
    ''' </summary>
    ''' <remarks></remarks>
    Private m_u10 As Double = 1.8

    ''' <summary>
    ''' �ȶ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_stab As String = "D"

    ''' <summary>
    ''' ������������
    ''' </summary>
    ''' <remarks></remarks>
    Property slabAirMass() As SlabAirMass()
        Get
            Return Me.m_SlabAirMass
        End Get
        Set(ByVal value As SlabAirMass())
            Me.m_SlabAirMass = value
        End Set
    End Property
    ''' <summary>
    ''' �߶�Z���ķ��٣�Zͨ��ȡ10m���ķ���
    ''' </summary>
    ''' <remarks></remarks>
    Property u10() As Double
        Get
            Return Me.m_u10
        End Get
        Set(ByVal value As Double)
            Me.m_u10 = value
        End Set
    End Property
    ''' <summary>
    ''' �ȶ���
    ''' </summary>
    ''' <remarks></remarks>
    Property stab() As String
        Get
            Return Me.m_stab
        End Get
        Set(ByVal value As String)
            Me.m_stab = value
        End Set
    End Property
    ''' <summary>
    ''' ������ԭй©����ĵ�λ�����µ��������ʣ�kg/m
    ''' </summary>
    ''' <remarks></remarks>
    Property Mg() As Double
        Get
            Return Me.m_Mg
        End Get
        Set(ByVal value As Double)
            Me.m_Mg = value
        End Set
    End Property
End Class
