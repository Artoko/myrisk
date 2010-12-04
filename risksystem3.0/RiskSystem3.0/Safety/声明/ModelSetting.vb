Public Class ModelSetting
    ''' <summary>
    ''' 输出前n大的计算结果
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared MaxTable As Integer = 10
    ''' <summary>
    ''' 泄漏后的最大计算时间。默认值为6小时。单位S
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared MaxForeTime As Integer = 3600 * 6
    ''' <summary>
    ''' 计算风险值和最大浓度值采用的时间步长。单位S
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared TimeStep As Integer = 60
End Class
