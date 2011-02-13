''' <summary>
''' 单个烟团的轨迹。这个对象用于记录每个烟团的位置和烟团对应的扩散参数
''' </summary>
''' <remarks></remarks>
Public Structure FlogTrack
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
    ''' 烟团走过的距离
    ''' </summary>
    ''' <remarks></remarks>
    Public Distance As Double
End Structure
