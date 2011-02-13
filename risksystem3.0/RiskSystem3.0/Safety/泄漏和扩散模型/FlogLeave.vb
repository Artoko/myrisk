''' <summary>
''' 烟团泄漏的初始状态和释放出来的时间
''' </summary>
''' <remarks></remarks>
Public Structure FlogLeave
    ''' <summary>
    ''' 单个烟团的质量,mg
    ''' </summary>
    ''' <remarks></remarks>
    Public Q As Double
    ''' <summary>
    ''' 烟团的位置,m
    ''' </summary>
    ''' <remarks></remarks>
    Public x As Double

    ''' <summary>
    ''' 烟团的位置,m
    ''' </summary>
    ''' <remarks></remarks>
    Public y As Double

    ''' <summary>
    ''' 烟团的位置,m
    ''' </summary>
    ''' <remarks></remarks>
    Public z As Double
    ''' <summary>
    ''' 烟团对应的水平向的扩散参数
    ''' </summary>
    ''' <remarks></remarks>
    Public ax As Double
    ''' <summary>
    ''' 烟团对应的垂直向的扩散参数
    ''' </summary>
    ''' <remarks></remarks>
    Public az As Double
    ''' <summary>
    ''' 烟团释放的初始时刻，这一时刻是从泄漏开始计算的。S
    ''' </summary>
    ''' <remarks></remarks>
    Public LeaveTime As Double
    
End Structure
