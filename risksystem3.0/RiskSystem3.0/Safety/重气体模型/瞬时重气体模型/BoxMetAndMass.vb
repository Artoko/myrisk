''' <summary>
''' ���ڴ�����������������״̬����
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class BoxMetAndMass
    ''' <summary>
    ''' ������������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_BoxAirMass(0) As BoxAirMass

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
    Property BoxAirMass() As BoxAirMass()
        Get
            Return Me.m_BoxAirMass
        End Get
        Set(ByVal value As BoxAirMass())
            Me.m_BoxAirMass = value
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


End Class
