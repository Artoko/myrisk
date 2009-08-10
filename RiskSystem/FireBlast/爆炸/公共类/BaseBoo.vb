<Serializable()> Public Class BaseBoo
    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_SourceName As String = "储罐"
    ''' <summary>
    ''' 泄漏源名称
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_Name As String = "丁二烯"
    ''' <summary>
    ''' 污染源坐标
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_SoucePoint As New Point2D

    ''' <summary>
    ''' 步长
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_Tstep As Double = 10
    ''' <summary>
    ''' 个数
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_Tcount As Integer = 20


    Protected m_DestroyR(0 To 16) As Drang '超压数组

    ''' <summary>
    ''' 储存步长对应的超压
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_ResultStepDp(-1) As Double

    ''' <summary>
    ''' 不同超压对应的距离
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_ResultR(-1) As Double
    ''' <summary>
    ''' 爆炸物质的TNT当量
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_WTNT As Double

    ''' <summary>
    ''' 事故源名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceName() As String
        Get
            Return Me.m_SourceName
        End Get
        Set(ByVal value As String)
            Me.m_SourceName = value
        End Set
    End Property
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name() As String
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property



    ''' <summary>
    ''' 事故点坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SoucePoint() As Point2D
        Get
            Return Me.m_SoucePoint
        End Get
        Set(ByVal value As Point2D)
            Me.m_SoucePoint = value
        End Set
    End Property

    ''' <summary>
    ''' 步长
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Tstep() As Double
        Get
            Return Me.m_Tstep
        End Get
        Set(ByVal value As Double)
            Me.m_Tstep = value
        End Set
    End Property
    ''' <summary>
    ''' 个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Tcount() As Integer
        Get
            Return Me.m_Tcount
        End Get
        Set(ByVal value As Integer)
            Me.m_Tcount = value
        End Set
    End Property

    ''' <summary>
    ''' 超压数组，Pa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DestroyRr() As Drang()
        Get
            Return Me.m_DestroyR
        End Get
        Set(ByVal value As Drang())
            Me.m_DestroyR = value

        End Set
    End Property


    ''' <summary>
    ''' 储存步长对应的超压
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
    ''' 不同超压对应的距离
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
    ''' <summary>
    ''' 在构造中实例化对象
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub New()
        For i As Integer = 0 To Me.m_DestroyR.Length - 1
            Me.m_DestroyR(i) = New Drang
        Next
        m_DestroyR(0).MDrangName = "死亡"
        Me.m_DestroyR(0).MDrang = 90 * 1000
        Me.m_DestroyR(0).Selected = True

        m_DestroyR(1).MDrangName = "重伤"
        Me.m_DestroyR(1).MDrang = 44 * 1000
        Me.m_DestroyR(1).Selected = True

        m_DestroyR(2).MDrangName = "轻伤"
        Me.m_DestroyR(2).MDrang = 17 * 1000
        Me.m_DestroyR(2).Selected = True

        m_DestroyR(3).MDrangName = "财产损失"
        Me.m_DestroyR(3).MDrang = 13.8 * 1000
        Me.m_DestroyR(3).Selected = True

        m_DestroyR(4).MDrangName = "小窗户损坏"
        Me.m_DestroyR(4).MDrang = 0.69 * 1000
        Me.m_DestroyR(4).Selected = False

        m_DestroyR(5).MDrangName = "玻璃损坏"
        Me.m_DestroyR(5).MDrang = 1.035 * 1000
        Me.m_DestroyR(5).Selected = False

        m_DestroyR(6).MDrangName = "10%玻璃破裂"
        Me.m_DestroyR(6).MDrang = 2.7 * 1000
        Me.m_DestroyR(6).Selected = False

        m_DestroyR(7).MDrangName = "窗户损坏，房屋结构较小的破坏"
        Me.m_DestroyR(7).MDrang = 3.45 * 1000
        Me.m_DestroyR(7).Selected = False

        m_DestroyR(8).MDrangName = "对人可逆影响的上限"
        Me.m_DestroyR(8).MDrang = 4.83 * 1000
        Me.m_DestroyR(8).Selected = False

        m_DestroyR(9).MDrangName = "房屋部分损坏；金属板扭曲；玻璃碎片划伤"
        Me.m_DestroyR(9).MDrang = 6.9 * 1000
        Me.m_DestroyR(9).Selected = False

        m_DestroyR(10).MDrangName = "墙和屋顶部分坍塌"
        Me.m_DestroyR(10).MDrang = 13.8 * 1000
        Me.m_DestroyR(10).Selected = False

        m_DestroyR(11).MDrangName = "暴露人员的耳膜破裂"
        Me.m_DestroyR(11).MDrang = 16.56 * 1000
        Me.m_DestroyR(11).Selected = False

        m_DestroyR(12).MDrangName = "人员致死的临界量"
        Me.m_DestroyR(12).MDrang = 17.25 * 1000
        Me.m_DestroyR(12).Selected = False

        m_DestroyR(13).MDrangName = "钢结构建筑扭曲和基础位移"
        Me.m_DestroyR(13).MDrang = 20.7 * 1000
        Me.m_DestroyR(13).Selected = False

        m_DestroyR(14).MDrangName = "木结构断裂"
        Me.m_DestroyR(14).MDrang = 34.5 * 1000
        Me.m_DestroyR(14).Selected = False

        m_DestroyR(15).MDrangName = "几乎所有建筑坍塌，肺出血"
        Me.m_DestroyR(15).MDrang = 69.0 * 1000
        Me.m_DestroyR(15).Selected = False

        m_DestroyR(16).MDrangName = "直接冲击波造成100%死亡"
        Me.m_DestroyR(16).MDrang = 138 * 1000
        Me.m_DestroyR(16).Selected = False


    End Sub


End Class
