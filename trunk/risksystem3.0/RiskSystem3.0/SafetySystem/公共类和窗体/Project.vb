''' <summary>
''' 工程类，用于管理所有的工程
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Project
    ''' <summary>
    ''' 工程类型：0泄漏预测项目，1为火灾爆炸项目
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PType As Integer
    ''' <summary>
    ''' 泄漏扩散模型对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Dis0 As New DisPuff.Dis
    ''' <summary>
    ''' 火灾爆炸模型类
    ''' </summary>
    ''' <remarks></remarks>
    Private m_FAB As New FireBlast.FAndB
    ''' <summary>
    ''' 逐次地面气象数据
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SurfMet As New Met.MetGeneral

    ''' <summary>
    ''' 保存标志
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IsSaved As Boolean = False

    Private m_SaveName As String

    Public ImportImage0 As New ImportImages '地理位置和厂区平面图

    ''' <summary>
    ''' 工程类型：0泄漏预测项目，1为火灾爆炸项目
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PType() As Integer
        Get
            Return Me.m_PType
        End Get
        Set(ByVal value As Integer)
            Me.m_PType = value
        End Set
    End Property
    ''' <summary>
    ''' 泄漏扩散模型对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Dis0() As DisPuff.Dis
        Get
            Return Me.m_Dis0
        End Get
        Set(ByVal value As DisPuff.Dis)
            Me.m_Dis0 = value
        End Set
    End Property
    ''' <summary>
    ''' 火灾爆炸模型类
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FAndB() As FireBlast.FAndB
        Get
            Return Me.m_FAB
        End Get
        Set(ByVal value As FireBlast.FAndB)
            Me.m_FAB = value
        End Set
    End Property
    ''' <summary>
    ''' 逐次地面气象数据
    ''' </summary>
    ''' <remarks></remarks>
    Property SurfMet() As Met.MetGeneral
        Get
            Return Me.m_SurfMet
        End Get
        Set(ByVal value As Met.MetGeneral)
            Me.m_SurfMet = value
        End Set
    End Property

    ''' <summary>
    ''' 保存标志
    ''' </summary>
    ''' <remarks></remarks>
    Property IsSaved() As Boolean
        Get
            Return Me.m_IsSaved
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsSaved = value
        End Set
    End Property
    ''' <summary>
    ''' 保存文件的名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SaveName() As String
        Get
            Return Me.m_SaveName
        End Get
        Set(ByVal value As String)
            Me.m_SaveName = value
        End Set
    End Property


    ''' <summary>
    ''' 对气象数据进行预处理。计算出等值线来
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PreMet()
        ReDim Me.m_Dis0.Forecast.Met(Me.m_SurfMet.ArrayMetData.Length - 1)
        For i As Integer = 0 To Me.m_Dis0.Forecast.Met.Length - 1
            Me.m_Dis0.Forecast.Met(i) = New DisPuff.Met
            Me.m_Dis0.Forecast.Met(i).m_DateTime = Me.m_SurfMet.ArrayMetData(i).m_DateTime
            Me.m_Dis0.Forecast.Met(i).WindType = 1
            Me.m_Dis0.Forecast.Met(i).WindSpeed = Me.m_SurfMet.ArrayMetData(i).m_WindSpeed / 10 '对单位进行转换
            Me.m_Dis0.Forecast.Met(i).WindDer = Me.m_SurfMet.ArrayMetData(i).m_Vane * 10 '对单位进行转换
            Dim Lon As Double = Me.m_SurfMet.Location.Longitude.Number '经度
            Dim Lat As Double = Me.m_SurfMet.Location.Latitude.Number '纬度
            Dim u10 As Double = Me.m_Dis0.Forecast.Met(i).WindSpeed '10米处风速
            Dim TotalCloud As Integer = Me.m_SurfMet.ArrayMetData(i).m_TotalCloud
            Dim LowCloud As Integer = Me.m_SurfMet.ArrayMetData(i).m_LowCloud '低云量
            Dim LeakTime As Date = Me.m_SurfMet.ArrayMetData(i).m_DateTime '泄漏时刻
            Dim SunriseTime As New DateTime(LeakTime.Year, LeakTime.Month, LeakTime.Day, 6, 0, 0)
            Dim SunsetTime As New DateTime(LeakTime.Year, LeakTime.Month, LeakTime.Day, 20, 0, 0)
            Me.m_Dis0.Forecast.Met(i).Stab = DisPuff.GetPs(Lon, Lat, u10, TotalCloud, LowCloud, LeakTime, SunriseTime, SunsetTime) '计算稳定度
            Me.m_Dis0.Forecast.Met(i).Frequency = 1 / Me.m_Dis0.Forecast.Met.Length
        Next

    End Sub
End Class
