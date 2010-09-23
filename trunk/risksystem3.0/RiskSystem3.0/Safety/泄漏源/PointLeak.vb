''' <summary>
''' 点源
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PointLeak
    Inherits LeakSource
    ''' <summary>
    ''' 泄漏源高度，m
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

End Class
