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
    Public x0 As Double

    ''' <summary>
    ''' 烟团的位置,m
    ''' </summary>
    ''' <remarks></remarks>
    Public y0 As Double

    ''' <summary>
    ''' 烟团的位置,m
    ''' </summary>
    ''' <remarks></remarks>
    Public z0 As Double
    ''' <summary>
    ''' 水平向的扩散参数
    ''' </summary>
    ''' <remarks></remarks>
    Public ax As Double
    ''' <summary>
    ''' 垂直向的扩散参数
    ''' </summary>
    ''' <remarks></remarks>
    Public az As Double
End Structure
