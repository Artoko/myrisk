<Serializable()> Public Class Grid
    ''' <summary>
    ''' 是否计算网格点的标志
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MinX As Integer = -1000 'X轴的起始坐标,m
    Private m_StepX As Integer = 20 'X轴的步长,m
    Private m_CountX As Integer = 101 'X轴的网格数
    Private m_MinY As Integer = -1000 'Y轴的起始坐标,m
    Private m_StepY As Integer = 20 'Y轴的步长,m
    Private m_CountY As Integer = 101 'Y轴的网格数
    Private m_WGH As Double 'Z轴的高度,m
    Private m_GridPopulation(-1, -1) As Double '人口分布网格
    Private m_Population As Double '人口密度
   
    ''' <summary>
    ''' X轴的起始坐标,m
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
    ''' X轴的步长,m
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
    ''' X轴的网格数
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
    ''' Y轴的起始坐标,m
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
    ''' Y轴的步长,m
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
    ''' Y轴的网格数
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
    ''' Z轴的高度
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
    ''' 人口分布网格
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
    ''' 人口密度
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
