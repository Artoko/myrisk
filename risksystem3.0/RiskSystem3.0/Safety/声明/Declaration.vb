Public Module Declaration
    Public Const PI As Double = 3.1415926
    Public Const FREEZINGPOINT As Double = 273.15 '0摄氏度的绝对温度
    Public Const MooreR As Double = 8.314 '摩尔气体常数R为8.314J.K-1.mol-1
    Public Const Gravity As Double = 9.8 '重力加速度
    Public Const ErrorValue As Integer = -999 '计算错误
    Public Vesion As Single '版本0为试用版，1为正式版，2为单机版
End Module
<Serializable()> Public Class Point3D
    Public x As Double
    Public y As Double
    Public z As Double
End Class

