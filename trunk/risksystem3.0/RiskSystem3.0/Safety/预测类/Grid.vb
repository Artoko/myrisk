<Serializable()> Public Class Grid
    ''' <summary>
    ''' �Ƿ���������ı�־
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MinX As Integer = -1000 'X�����ʼ����,m
    Private m_StepX As Integer = 20 'X��Ĳ���,m
    Private m_CountX As Integer = 101 'X���������
    Private m_MinY As Integer = -1000 'Y�����ʼ����,m
    Private m_StepY As Integer = 20 'Y��Ĳ���,m
    Private m_CountY As Integer = 101 'Y���������
    Private m_WGH As Double 'Z��ĸ߶�,m
    Private m_GridPopulation(-1, -1) As Double '�˿ڷֲ�����
    Private m_Population As Double '�˿��ܶ�
   
    ''' <summary>
    ''' X�����ʼ����,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MinX() As Integer
        Get
            Return Me.m_MinX
        End Get
        Set(ByVal value As Integer)
            Me.m_MinX = value
        End Set
    End Property
    ''' <summary>
    ''' X��Ĳ���,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepX() As Integer
        Get
            Return Me.m_StepX
        End Get
        Set(ByVal value As Integer)
            Me.m_StepX = value
        End Set
    End Property
    ''' <summary>
    ''' X���������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CountX() As Integer
        Get
            Return Me.m_CountX
        End Get
        Set(ByVal value As Integer)
            Me.m_CountX = value
        End Set
    End Property
    ''' <summary>
    ''' Y�����ʼ����,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MinY() As Integer
        Get
            Return Me.m_MinY
        End Get
        Set(ByVal value As Integer)
            Me.m_MinY = value
        End Set
    End Property
    ''' <summary>
    ''' Y��Ĳ���,m
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property StepY() As Integer
        Get
            Return Me.m_StepY
        End Get
        Set(ByVal value As Integer)
            Me.m_StepY = value
        End Set
    End Property
    ''' <summary>
    ''' Y���������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CountY() As Integer
        Get
            Return Me.m_CountY
        End Get
        Set(ByVal value As Integer)
            Me.m_CountY = value
        End Set
    End Property
    ''' <summary>
    ''' Z��ĸ߶�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WGH() As Double
        Get
            Return Me.m_WGH
        End Get
        Set(ByVal value As Double)
            Me.m_WGH = value
        End Set
    End Property
    ''' <summary>
    ''' �˿ڷֲ�����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridPopulation() As Double(,)
        Get
            Return m_GridPopulation
        End Get
        Set(ByVal value As Double(,))
            m_GridPopulation = value
        End Set
    End Property
    ''' <summary>
    ''' �˿��ܶ�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Population() As Double
        Get
            Return Me.m_Population
        End Get
        Set(ByVal value As Double)
            Me.m_Population = value
        End Set
    End Property

    Public Sub New()
        ReDim m_GridPopulation(m_CountY - 1, m_CountX - 1)
    End Sub
End Class
