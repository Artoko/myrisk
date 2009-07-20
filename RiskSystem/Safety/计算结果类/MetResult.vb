''' <summary>
''' 气象条件对应的计算结果。该结果中包含了多个预测时刻的计算结果
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class MetResult
    ''' <summary>
    ''' 预测时刻数组
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ForeTimeResults(-1) As ForeTimeResult

    
    ''' <summary>
    ''' 用于储存除关心点外的其它滑移平均最大值的结果
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Slip As New SlipClass

    ''' <summary>
    ''' 预测时刻数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ForeTimeResults() As ForeTimeResult()
        Get
            Return Me.m_ForeTimeResults
        End Get
        Set(ByVal value As ForeTimeResult())
            Me.m_ForeTimeResults = value
        End Set
    End Property

    
    ''' <summary>
    ''' 用于储存除关心点外的其它滑移平均最大值的结果
    ''' </summary>
    ''' <remarks></remarks>
    Property Slip() As SlipClass
        Get
            Return Me.m_Slip
        End Get
        Set(ByVal value As SlipClass)
            Me.m_Slip = value
        End Set
    End Property

End Class
