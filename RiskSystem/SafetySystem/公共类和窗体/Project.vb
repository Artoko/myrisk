''' <summary>
''' 工程类，用于管理所有的工程
''' </summary>
''' <remarks></remarks>
Public Class Project
    ''' <summary>
    ''' 工程类型：0泄漏预测项目，1为火灾爆炸项目
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PType As Integer
    ''' <summary>
    ''' 泄漏扩散模型对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Dis0 As New DisPuff.Dis
    ''' <summary>
    ''' 火灾爆炸模型类
    ''' </summary>
    ''' <remarks></remarks>
    Private m_FAB As New FireBlast.FAndB
    ''' <summary>
    ''' 保存标志
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IsSaved As Boolean = False

    Private m_SaveName As String

    ''' <summary>
    ''' 工程类型：0泄漏预测项目，1为火灾爆炸项目
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PType() As Integer
        Get
            Return Me.m_PType
        End Get
        Set(ByVal value As Integer)
            Me.m_PType = value
        End Set
    End Property
    ''' <summary>
    ''' 泄漏扩散模型对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Dis0() As DisPuff.Dis
        Get
            Return Me.m_Dis0
        End Get
        Set(ByVal value As DisPuff.Dis)
            Me.m_Dis0 = value
        End Set
    End Property
    ''' <summary>
    ''' 火灾爆炸模型类
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FAndB() As FireBlast.FAndB
        Get
            Return Me.m_FAB
        End Get
        Set(ByVal value As FireBlast.FAndB)
            Me.m_FAB = value
        End Set
    End Property
    ''' <summary>
    ''' 保存标志
    ''' </summary>
    ''' <remarks></remarks>
    Property IsSaved() As Boolean
        Get
            Return Me.m_IsSaved
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsSaved = value
        End Set
    End Property
    ''' <summary>
    ''' 保存文件的名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SaveName() As String
        Get
            Return Me.m_SaveName
        End Get
        Set(ByVal value As String)
            Me.m_SaveName = value
        End Set
    End Property
End Class
