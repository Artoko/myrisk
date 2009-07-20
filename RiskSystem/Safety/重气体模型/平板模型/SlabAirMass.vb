''' <summary>
''' 平板模型的云团参数
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class SlabAirMass
    ''' <summary>
    ''' 云团每一划分段的初始体积m3
    ''' </summary>
    ''' <remarks></remarks>
    Public m_V As Double
    ''' <summary>
    ''' 表示平板模型的半宽
    ''' </summary>
    ''' <remarks></remarks>
    Public m_L As Double
    ''' <summary>
    ''' 云团的下风向距离
    ''' </summary>
    ''' <remarks></remarks>
    Public m_x As Double
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

