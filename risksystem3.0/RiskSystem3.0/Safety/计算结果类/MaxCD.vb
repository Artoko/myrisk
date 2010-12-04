''' <summary>
''' 极大值的结构
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class MaxCD
    Public MaxC As Double '极大值的浓度
    Public MaxD As Double '极大值出现的距离
    Public maxT As Double '极大值出现的时间
    Public StepTime As Double '步长
    Public ArrayC(-1) As Double '浓度值数组
End Class
