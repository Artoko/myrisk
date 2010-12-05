''' <summary>
''' 计算结果类。包含了多个气象条件下对应的计算结果。
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Results
    ''' <summary>
    ''' 各点高值
    ''' </summary>
    ''' <remarks></remarks>
    Public Rectable As Rectable


    ''' <summary>
    ''' 所有与网格数据相关的计算结果对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AllGridResult As New AllGridResult
    ''' <summary>
    ''' 所有与关心点数据相关的计算结果对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AllCareResult As New AllCareResult

    ''' <summary>
    ''' 气象条件对应的计算结果数组
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MetResults(-1) As MetResult
    ''' <summary>
    ''' 计算的总进度。为按预测时刻计算和按关心点计算的总合
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AllProgress As Integer

    ''' <summary>
    ''' 总计算量
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AllCalMount As Integer
    ''' <summary>
    ''' 子进度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Status2 As String
    ''' <summary>
    ''' 气象条件对应的计算结果数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MetResults() As MetResult()
        Get
            Return Me.m_MetResults
        End Get
        Set(ByVal value As MetResult())
            Me.m_MetResults = value
        End Set
    End Property


    ''' <summary>
    ''' 计算的总进度。为按预测时刻计算和按关心点计算的总合*气象条件
    ''' </summary>
    ''' <remarks></remarks>
    Property AllProgress() As Integer
        Get
            Return Me.m_AllProgress
        End Get
        Set(ByVal value As Integer)
            Me.m_AllProgress = value
        End Set
    End Property

    ''' <summary>
    ''' 总计算量
    ''' </summary>
    ''' <remarks></remarks>
    Property AllCalMount() As Integer
        Get
            Return Me.m_AllCalMount
        End Get
        Set(ByVal value As Integer)
            Me.m_AllCalMount = value
        End Set
    End Property

    ''' <summary>
    ''' 子进度
    ''' </summary>
    ''' <remarks></remarks>
    Property Status2() As String
        Get
            Return Me.m_Status2
        End Get
        Set(ByVal value As String)
            Me.m_Status2 = value
        End Set
    End Property
    ''' <summary>
    ''' 所有与网格相关的计算结果对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllGridResult() As AllGridResult
        Get
            Return m_AllGridResult
        End Get
        Set(ByVal value As AllGridResult)
            m_AllGridResult = value
        End Set
    End Property

    ''' <summary>
    ''' 所有与关心点数据相关的计算结果对象
    ''' </summary>
    ''' <remarks></remarks>
    Property AllCareResult() As AllCareResult
        Get
            Return m_AllCareResult
        End Get
        Set(ByVal value As AllCareResult)
            m_AllCareResult = value
        End Set
    End Property
End Class
