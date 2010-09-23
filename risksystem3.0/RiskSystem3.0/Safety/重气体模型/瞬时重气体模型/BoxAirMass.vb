<Serializable()> Public Class BoxAirMass
    ''' <summary>
    ''' 云团的初始体积
    ''' </summary>
    ''' <remarks></remarks>
    Public m_V As Double
    ''' <summary>
    ''' 云团半径，当为连续泄漏时表示平板模型的半宽
    ''' </summary>
    ''' <remarks></remarks>
    Public m_R As Double
    ''' <summary>
    ''' 云团的扩散时间
    ''' </summary>
    ''' <remarks></remarks>
    Public m_t As Double
    ''' <summary>
    ''' 云团高度
    ''' </summary>
    ''' <remarks></remarks>
    Public m_H As Double
    ''' <summary>
    ''' 云团密度
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Density As Double
    ''' <summary>
    ''' 空气从边缘进入气团的质量
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Ma1 As Double
    ''' <summary>
    ''' 空气从顶部进入气团的质量
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Ma2 As Double

    ''' <summary>
    ''' 云团温度，K
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Temp As Double
    ''' <summary>
    ''' 卷入空气的总质量
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Ma As Double
    ''' <summary>
    ''' 污染物的平均浓度
    ''' </summary>
    ''' <remarks></remarks>
    Public m_C As Double

End Class
