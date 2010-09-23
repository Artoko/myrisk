
<Serializable()> Public Class MultiLeakSorce
    ''' <summary>
    ''' 泄漏物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' 泄漏的气相速率，单位mg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public Q As Double
    ''' <summary>
    ''' 排放持续时间，单位s
    ''' </summary>
    ''' <remarks></remarks>
    Public DurationTime As Double
    ''' <summary>
    ''' 排放温度，摄氏度
    ''' </summary>
    ''' <remarks></remarks>
    Public Ts As Double
    ''' <summary>
    ''' 泄漏源有效排放高度，m
    ''' </summary>
    ''' <remarks></remarks>
    Public He As Double
    ''' <summary>
    ''' 排放高度
    ''' </summary>
    ''' <remarks></remarks>
    Public H As Double
    ''' <summary>
    ''' 烟气抬升高度，m
    ''' </summary>
    ''' <remarks></remarks>
    Public DH As Double
    ''' <summary>
    ''' 排气量，m3/s
    ''' </summary>
    ''' <remarks></remarks>
    Public Qv As Double
    ''' <summary>
    ''' 排放口直径，m3/s
    ''' </summary>
    ''' <remarks></remarks>
    Public D As Double
    ''' <summary>
    ''' 烟团的个数
    ''' </summary>
    ''' <remarks></remarks>
    Public n As Integer
    ''' <summary>
    ''' 泄漏速率，kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V()
    ''' <summary>
    ''' 泄漏蒸发速率 kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V1() As Double
    ''' <summary>
    ''' 热量蒸发的速率 kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V2() As Double
    ''' <summary>
    ''' 质量蒸发的速率 kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V3() As Double
    ''' <summary>
    ''' 液池总蒸发速率 kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V4() As Double
    ''' <summary>
    ''' 泄漏的总时间
    ''' </summary>
    ''' <remarks></remarks>
    Public QpAllT As Double
    ''' <summary>
    ''' 蒸发的总时间
    ''' </summary>
    ''' <remarks></remarks>
    Public QsAllT As Double
    ''' <summary>
    ''' 泄漏的总量
    ''' </summary>
    ''' <remarks></remarks>
    Public QpAll As Double
    ''' <summary>
    ''' 蒸发的总量
    ''' </summary>
    ''' <remarks></remarks>
    Public QsAll As Double
    ''' <summary>
    ''' 烟团量 mg
    ''' </summary>
    ''' <remarks></remarks>
    Public Qi() As Double
    ''' <summary>
    ''' 面源或体源的底面积
    ''' </summary>
    ''' <remarks></remarks>
    Public Si() As Double
    Public Thickness() As Double
    ''' <summary>
    ''' 生气体的类型。0表示瞬时重气体，1表示连续重气体，-1表示不是重气体
    ''' </summary>
    ''' <remarks></remarks>
    Public HeavyType As Integer = -1

    Public Sub ResetMulti(ByVal nCount As Integer)
        n = nCount
        ReDim V(0 To n)
        ReDim V1(0 To n)
        ReDim V2(0 To n)
        ReDim V3(0 To n)
        ReDim V4(0 To n)
        ReDim Qi(0 To n)
        ReDim Si(0 To n)
        ReDim Thickness(0 To n)
    End Sub
End Class
