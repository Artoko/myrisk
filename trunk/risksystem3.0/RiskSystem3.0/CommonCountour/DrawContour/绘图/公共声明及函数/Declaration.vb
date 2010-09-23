Module Declaration
    Public Const FreezingPoint As Double = 273.15 '0摄氏度的绝对温度
    Public Const MooreR As Double = 8.314 '摩尔气体常数R为8.314J.K-1.mol-1
    Public Const Gravity As Double = 9.8 '重力加速度

End Module
<Serializable()> Public Structure Point3D
    Public x As Double
    Public y As Double
    Public z As Double
End Structure
''' <summary>
''' 极大值的结构
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure MaxCD
    Public MaxC As Double '极大值的浓度
    Public MaxD As Double '极大值出现的距离
    Public maxT As Double '极大值出现的时间
End Structure

<Serializable()> Public Structure Point2D
    Public x As Double
    Public y As Double
End Structure