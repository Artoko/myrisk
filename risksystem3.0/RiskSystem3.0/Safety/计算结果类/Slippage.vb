''' <summary>
''' 滑移平均最大浓度类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Slippage
    Implements ICloneable


    ''' <summary>
    ''' 滑移平均最大浓度
    ''' </summary>
    ''' <remarks></remarks>
    Public MaxCon As Double
    ''' <summary>
    ''' 用于储存预测出现某的滑移平均最大浓度开始和结束时间
    ''' </summary>
    ''' <remarks></remarks>
    Public StartAndEndTimeTime As StartAndEndTime


    ''' <summary>
    ''' 返回对象的拷贝
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim obj As New Slippage
        obj.MaxCon = Me.MaxCon
        obj.StartAndEndTimeTime = Me.StartAndEndTimeTime.Clone
        Return obj
    End Function
End Class
