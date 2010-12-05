''' <summary>
''' 各点高值浓度值及出现该浓度的泄漏时刻及泄漏后的预测时刻
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure RectableConAndTime
    ''' <summary>
    ''' 最大浓度值
    ''' </summary>
    ''' <remarks></remarks>
    Public MaxConcentration As Double
    ''' <summary>
    ''' 泄漏的时刻
    ''' </summary>
    ''' <remarks></remarks>
    Public LeakTime As DateTime
    ''' <summary>
    ''' 泄漏开始后的预测时刻
    ''' </summary>
    ''' <remarks></remarks>
    Public ForeTime As Double
End Structure
