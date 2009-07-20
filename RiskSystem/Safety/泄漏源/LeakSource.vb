<Serializable()> Public Class LeakSource
    ''' <summary>
    ''' 泄漏物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' 所有泄漏速率，对于液体泄漏包含液体的泄漏速率mg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public QAll As Double

    ''' <summary>
    ''' 泄漏速率，单位mg/s。指泄漏后气体部分的速率
    ''' </summary>
    ''' <remarks></remarks>
    Public Q As Double
    ''' <summary>
    ''' 排放温度，摄氏度
    ''' </summary>
    ''' <remarks></remarks>
    Public Ts As Double
    ''' <summary>
    ''' 排放持续时间，单位s
    ''' </summary>
    ''' <remarks></remarks>
    Public DurationTime As Double
    ''' <summary>
    ''' 泄漏源有效排放高度，m
    ''' </summary>
    ''' <remarks></remarks>
    Public He As Double

End Class

