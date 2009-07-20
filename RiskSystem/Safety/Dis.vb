Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
''' <summary>
''' 泄漏源参数
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Dis

#Region "中间变量"
    Private Const MaxTime = 60 * 60 * 60 '60个小时
    Private Const MaxLength = 50 * 1000 '50公里
    Private Const Precision = 0.00001 '精度为1E-5
    Private GriddingSign As Short '网格标志
    Private m_Sources(-1) As Source '污染源数组
    Private vane As String '声明风向，因为在网格点计算中用到风向
    Private stab As String '声明稳定度，因为在质量蒸发中用到稳定度，所以为全局变量
    Private u10 As Double '10m 处的风速，因为在初始化烟气抬升高度和排气筒有效高度时用到

    Private GridSign As Boolean '网格数据是否由单击事件引起的
    Private LeakQ(0, 0, 0) As Double '定义3维数组，用于储存不同气象条件下的泄漏情况

    Private arrayDamageRange(-1, -1) As Double '伤害范围
    Private ReCalculate As Boolean = True '重新计算标志


#End Region

#Region "属性变量"


    Private m_IntialSource As New IntialSource  '事故泄漏初始对象
    Private m_Chemical As New Chemical '物化数据类
    

    ''' <summary>
    ''' 重气体对象数组对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Heavy(-1) As DisPuff.AllHeavy
    
   
    ''' <summary>
    ''' 预测方案
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ForeCast As New Forecast
   

    Private m_IsCalUpVane As Boolean = False
    

    ''' <summary>
    ''' 计算结果对象
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Results As New Results
    Private m_GridVaneN1 As Integer = -1
    Private m_GridVaneN2 As Integer = -1
    Private m_GridVaneN3 As Integer = -1
    Private m_GirdVaneLine() As Double


#End Region

#Region "属性"
    ''' <summary>
    ''' 事故泄漏初始对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IntialSource() As IntialSource
        Get
            Return m_IntialSource
        End Get
        Set(ByVal value As IntialSource)
            m_IntialSource = value
        End Set
    End Property
    ''' <summary>
    ''' 物化数据对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Chemical() As Chemical '物化数据类
        Get
            Return m_Chemical
        End Get
        Set(ByVal value As Chemical)
            m_Chemical = value
        End Set
    End Property

    ''' <summary>
    ''' 事故源。对于液体泄漏，地面蒸发量不一样。因此，不同的气象条件有不同的速率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Sources() As Source()
        Get
            Return Me.m_Sources
        End Get
        Set(ByVal value As Source())
            Me.m_Sources = value
        End Set
    End Property



    ''' <summary>
    ''' 预测方案
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Forecast() As Forecast
        Get
            Return Me.m_ForeCast
        End Get
        Set(ByVal value As Forecast)
            Me.m_ForeCast = value
        End Set
    End Property
    ''' <summary>
    ''' 重气体模型数组对象。每一个元素对应一种气象条件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Heavy() As DisPuff.AllHeavy()
        Get
            Return Me.m_Heavy
        End Get
        Set(ByVal value As DisPuff.AllHeavy())
            Me.m_Heavy = value
        End Set
    End Property

    ''' <summary>
    ''' 是否计算上风向浓度的标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsCalUpVane() As Boolean
        Get
            Return Me.m_IsCalUpVane
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsCalUpVane = value
        End Set
    End Property

#End Region

#Region "结果数组"
    ''' <summary>
    ''' 计算结果对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Results() As Results
        Get
            Return Me.m_Results
        End Get
        Set(ByVal value As Results)
            Me.m_Results = value
        End Set
    End Property

    ''' <summary>
    ''' 下风向数组的0组个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridVaneN1() As Integer
        Get
            Return Me.m_GridVaneN1
        End Get
        Set(ByVal value As Integer)
            Me.m_GridVaneN1 = value
        End Set
    End Property
    ''' <summary>
    ''' 下风向数组的0组个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridVaneN2() As Integer
        Get
            Return Me.m_GridVaneN2
        End Get
        Set(ByVal value As Integer)
            Me.m_GridVaneN2 = value
        End Set
    End Property
    ''' <summary>
    ''' 下风向数组的0组个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridVaneN3() As Integer
        Get
            Return Me.m_GridVaneN3
        End Get
        Set(ByVal value As Integer)
            Me.m_GridVaneN3 = value
        End Set
    End Property
    ''' <summary>
    ''' 用1维数组来进行序列化
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GirdVaneLine() As Double()
        Get
            Return Me.m_GirdVaneLine
        End Get
        Set(ByVal value As Double())
            Me.m_GirdVaneLine = value
        End Set
    End Property
#End Region

#Region "方法"
    ''' <summary>
    ''' 计算结果
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Cal() As Boolean
        '初始化泄漏源的参数
        If m_IntialSource.IntialPara(m_Chemical, m_ForeCast.Ta, m_ForeCast.Pa) = False Then
            Return False
        End If
        '污染源数组
        ReDim Me.m_Sources(Me.m_ForeCast.Met.Length - 1)
        '重气体数组
        ReDim Me.m_Heavy(Me.m_ForeCast.Met.Length - 1)
        '计算结果初始化对象，建立新的实例
        ReDim Me.m_Results.MetResults(Me.m_ForeCast.Met.Length - 1)
        '------------------------------------------------------------------------------------
        '初始化计算结果的对象
        '------------------------------------------------------------------------------------

        '初始化设置网格点对象中的瞬时网格点数组
        ReDim Me.m_Results.AllGridResult.InstantaneousGridC(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.OutPut.ForeCount - 1, Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)

        '初始化设置网格点滑移平均最大浓度
        'If Me.Forecast.OutPut.IsSlipChecked Then
        ReDim Me.m_Results.AllGridResult.SlipGrid(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
        For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
            '网格点滑移平均最大浓度网格初始化
            For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1
                For k As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1
                    Me.m_Results.AllGridResult.SlipGrid(SN, j, k) = New Slippage
                    Me.m_Results.AllGridResult.SlipGrid(SN, j, k).StartAndEndTimeTime = New StartAndEndTime
                Next
            Next
        Next
        'End If

        '初始化设置网格点死亡概率和死亡百分率
        ReDim Me.m_Results.AllGridResult.Pr(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
        ReDim Me.m_Results.AllGridResult.D(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
        ReDim Me.m_Results.AllGridResult.PersonalRisk(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
        ReDim Me.m_Results.AllGridResult.ArrayRisk(Me.m_ForeCast.Met.Length - 1)
        Me.m_Results.AllGridResult.AllRisk = 0
        '初始化设置关心点对象中的瞬时浓度
        ReDim Me.m_Results.AllCareResult.InstantaneousCareC(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.OutPut.ForeCount - 1, Me.m_ForeCast.CareReceptor.Length - 1) '某关心点的多个时刻的浓度

        '初始化设置关心点对象中的滑移平均最大浓度
        'If Me.Forecast.OutPut.IsSlipChecked Then
        ReDim Me.m_Results.AllCareResult.SlipCare(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.CareReceptor.Length - 1)
        For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
            For j As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
                Me.m_Results.AllCareResult.SlipCare(SN, j) = New Slippage
                Me.m_Results.AllCareResult.SlipCare(SN, j).StartAndEndTimeTime = New StartAndEndTime
            Next
        Next
        'End If
        '初始化设置关心点对象中的最大浓度及出现的时间该:气象条件、关心点
        ReDim Me.m_Results.AllCareResult.CarePointMaxCT(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.CareReceptor.Length - 1)
        For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
            For j As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
                Me.m_Results.AllCareResult.CarePointMaxCT(SN, j) = New MaxCD
            Next
        Next
        '初始化设置关心点对象中关心点出现某伤害一浓度的浓度限值的开始和结束时间:气象条件，关心点，给定浓度值
        ReDim Me.m_Results.AllCareResult.CarePointTime(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.CareReceptor.Length - 1, Me.m_ForeCast.HurtConcentration.Length - 1)
        For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
            For i As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
                For j As Integer = 0 To Me.m_ForeCast.HurtConcentration.Length - 1
                    Me.m_Results.AllCareResult.CarePointTime(SN, i, j) = New StartAndEndTime
                Next
            Next
        Next

        '初始化设置关心点对象中死亡概率：气象条件，关心点
        ReDim Me.m_Results.AllCareResult.Pr(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.CareReceptor.Length - 1)

        '初始化设置关心点对象中死亡百分率 %：气象条件，关心点
        ReDim Me.m_Results.AllCareResult.D(Me.m_ForeCast.Met.Length - 1, Me.m_ForeCast.CareReceptor.Length - 1)
        '-----------------------------------------------------------------------------------
        '初始化计算结果的对象结束
        '-----------------------------------------------------------------------------------

        For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
            Me.m_Results.MetResults(SN) = New MetResult
            ReDim Me.m_Results.MetResults(SN).ForeTimeResults(Me.m_ForeCast.OutPut.ForeCount - 1)

            For i As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
                Me.m_Results.MetResults(SN).ForeTimeResults(i) = New ForeTimeResult '轴线最大浓度及距离
                ReDim Me.m_Results.MetResults(SN).ForeTimeResults(i).HurtLength(Me.m_ForeCast.HurtConcentration.Length - 1) '某一浓度伤害范围
                ReDim Me.m_Results.MetResults(SN).ForeTimeResults(i).GridVane(0 To Me.m_ForeCast.Vane.VaneCount) '预测的时间个数和预测的下风向个数,从0开始，所以增加一个
                ReDim Me.m_Results.MetResults(SN).ForeTimeResults(i).GridUpVane(0 To Me.m_ForeCast.Vane.VaneCount) '预测的时间个数和预测的上风向个数,从0开始，所以增加一个
            Next

            '网格点滑移平均最大浓度网格初始化
            If Me.Forecast.OutPut.IsSlipChecked Then
                ReDim Me.m_Results.MetResults(SN).Slip.HurtLengthSlip(Me.m_ForeCast.HurtConcentration.Length - 1) '某一浓度伤害范围
                ReDim Me.m_Results.MetResults(SN).Slip.GridVane(0 To Me.m_ForeCast.Vane.VaneCount) '预测的时间个数和预测的下风向个数,从0开始，所以增加一个

                For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1
                    For k As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1
                        Me.m_Results.AllGridResult.SlipGrid(SN, j, k) = New Slippage
                    Next
                Next
            End If
        Next
        '设置总的计算量
        If Me.m_ForeCast.Grid.IsCalGrid = True Then
            Me.m_Results.AllCalMount = (Me.m_ForeCast.OutPut.ForeCount * 3 + Me.m_ForeCast.OutPut.ForeCount * Me.m_ForeCast.CareReceptor.Length) * Me.m_ForeCast.Met.Length
        Else
            Me.m_Results.AllCalMount = (Me.m_ForeCast.OutPut.ForeCount * 2 + Me.m_ForeCast.OutPut.ForeCount * Me.m_ForeCast.CareReceptor.Length) * Me.m_ForeCast.Met.Length
        End If
        '初始化进度
        Me.m_Results.AllProgress = 0
        For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
            CalculateGeneral(SN)   '计算概述
            '泄漏量计算
            CalLeakSource(SN) '计算泄漏量
            CalculateVaneMaxC(SN) '计算最大落地浓度及出现距离
            If Me.Forecast.Grid.IsCalGrid = True Then
                CalculateGrid(SN) '计算网格点
            End If
            CalculateVane(SN) '计算下风向

            CalculateCare(SN) '计算关心点

        Next SN
    End Function
    ''' <summary>
    ''' 概述结果
    ''' </summary>
    ''' <param name="Sn">气象条件的序号</param>
    ''' <remarks></remarks>
    Public Sub CalculateGeneral(ByVal Sn As Integer)
        '清空表格

        '按预测的序号进行计算
        vane = Me.m_ForeCast.Met(Sn).Vane  '第0行第1列,风向
        u10 = Me.m_ForeCast.Met(Sn).WindSpeed  '第0行第2列，风速
        stab = Me.m_ForeCast.Met(Sn).Stab  '第0行第3列，风速稳定度

        Me.m_ForeCast.Met(Sn).u2 = UP(u10, Me.m_IntialSource.H, Me.m_ForeCast.OutPut.GroundCharacter, stab)
        '计算地面液池高度处的风速
        Me.m_ForeCast.Met(Sn).U_Ground = UP(u10, Me.m_IntialSource.SHe, Me.m_ForeCast.OutPut.GroundCharacter, stab)

    End Sub

    ''' <summary>
    ''' 初始化泄漏源强和重气体的初始参数
    ''' </summary>
    ''' <param name="sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalLeakSource(ByVal sn As Integer) As Boolean
        Dim Ta_K As Double
        '转换环境温度的单位
        Ta_K = Me.m_ForeCast.Ta + 273.15 '将摄氏温度转化为绝对温度,环境温度
        Dim Pa_BP As Double
        Pa_BP = Me.m_ForeCast.Pa / 100 '公式中的单位是百帕(hPa)

        Dim i As Integer
        Dim j As Integer
        Dim Sj As Double = 0 '临时面积
        Dim Q2 As Double = 0 '临时热量蒸发量，单位kg/s
        Dim Q3 As Double = 0 '临时质量蒸发量，单位kg/s
        Dim Q4 As Double = 0 '临时液池总蒸发量，单位kg/s
        Dim QGround As Double '某一时刻，泄漏到地面的量，kg
        Dim QGroundAll As Double '泄漏至地面的总量，kg
        Dim Smax As Double = 0 '泄漏的扩散的最大面积
        Dim stepT As Double = 1 '时间步长
        Dim r As Double '半径
        Dim Fv_Renamed As Double
        Dim E1 As Double
        Dim QLG As Double '总的储存量
        Dim Ti As Double '临时预测时间
        Dim Vh, Vq As Double '瞬时热量蒸发速率和质量蒸发速率，kg/s

        '暂时保留
        Dim MultiPLeak As New MultiLeakSorce '实例化
        Dim MultiSLeak As New MultiLeakSorce
        Dim MultiVLeak As New MultiLeakSorce

        Me.m_Sources(sn) = New Source '实例化污染源对象
        Me.m_Sources(sn).PLeak = New PointLeak '实例化点源对象
        Me.m_Sources(sn).SLeak = New SurfaceLeak '实例化面源对象

        Select Case m_IntialSource.LeakType
            Case 0 '手动计算
                Select Case Me.m_IntialSource.SourceType
                    Case 0 '点源
                        '多烟团泄漏源
                        With MultiPLeak
                            .Name = Me.m_Chemical.Name0  '泄漏物质名称
                            .Q = Me.m_IntialSource.Q0 * 1000000 '泄漏物质的速率mg/s
                            .Ts = Me.m_IntialSource.Ts0 + 273.15  '设置温度，摄氏度
                            .DurationTime = Me.m_IntialSource.DurationT0 * 60   '排放持续时间转化为S
                            .Qv = Me.m_IntialSource.Qv_P  '排气量　m3/s
                            .H = Me.m_IntialSource.H '排放高度
                            .D = Me.m_IntialSource.D_P '直径
                            '计算烟气抬升高度和有效高度
                            .DH = RiseH(Pa_BP, .Qv, .D, .H, .Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, 90)
                            .He = .DH + .H
                            If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                            Else
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                            End If
                            .ResetMulti(.n) '设置烟团个数为n个
                            For i = 1 To .n Step 1
                                .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                                .Si(i) = 0
                                .Thickness(i) = 0
                                If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                    .Qi(i) = ((Me.m_IntialSource.DurationT0 * 60) - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                                End If
                            Next i
                        End With
                        '非正常泄漏源
                        Me.m_Sources(sn).PLeak = New PointLeak '实例化点源对象
                        Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                        Me.m_Sources(sn).PLeak.Q = Me.m_IntialSource.Q0 * 1000000 '泄漏物质的速率mg/s
                        Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.Ts0 + 273.15 '设置温度，摄氏度
                        Me.m_Sources(sn).PLeak.DurationTime = Me.m_IntialSource.DurationT0 * 60  '排放持续时间转化为S
                        Me.m_Sources(sn).PLeak.Qv = Me.m_IntialSource.Qv_P '排气量　m3/s
                        Me.m_Sources(sn).PLeak.H = Me.m_IntialSource.H '排放高度
                        Me.m_Sources(sn).PLeak.D = Me.m_IntialSource.D_P '直径
                        '计算烟气抬升高度和有效高度
                        Me.m_Sources(sn).PLeak.DH = RiseH(Pa_BP, Me.m_Sources(sn).PLeak.Qv, Me.m_Sources(sn).PLeak.D, Me.m_Sources(sn).PLeak.H, Me.m_Sources(sn).PLeak.Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, 90)
                        Me.m_Sources(sn).PLeak.He = Me.m_Sources(sn).PLeak.DH + Me.m_Sources(sn).PLeak.H
                    Case 1 '面源
                        '多烟团
                        With MultiSLeak
                            .Name = Me.m_Chemical.Name0    '泄漏物质名称
                            .Q = Me.m_IntialSource.Q0 * 1000000 '泄漏物质的速率mg/s
                            .Ts = Me.m_IntialSource.Ts0 + 273.15  '设置温度，摄氏度
                            .DurationTime = Me.m_IntialSource.DurationT0 * 60  '排放持续时间转化为S
                            .He = Me.m_IntialSource.H  '有效排放高度
                            If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                            Else
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                            End If
                            .ResetMulti(.n) '设置烟团个数为n个
                            For i = 1 To .n Step 1
                                .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                                .Si(i) = Me.m_IntialSource.S_S
                                .Thickness(i) = 0
                                If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                    .Qi(i) = ((Me.m_IntialSource.DurationT0 * 60) - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                                End If
                            Next i
                        End With
                        '非正常
                        Me.m_Sources(sn).SLeak = New SurfaceLeak '实例化面源对象
                        Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                        Me.m_Sources(sn).SLeak.Q = Me.m_IntialSource.Q0 * 1000000 '泄漏物质的速率mg/s
                        Me.m_Sources(sn).SLeak.Ts = Me.m_IntialSource.Ts0 + 273.15 '设置温度，摄氏度
                        Me.m_Sources(sn).SLeak.DurationTime = Me.m_IntialSource.DurationT0 * 60  '排放持续时间转化为S
                        Me.m_Sources(sn).SLeak.He = Me.m_IntialSource.H '有效排放高度
                        Me.m_Sources(sn).SLeak.S = Me.m_IntialSource.S_S '面源的面积
                    Case 2 '体源
                        '多烟团
                        With MultiVLeak
                            .Name = Me.m_Chemical.Name0  '泄漏物质名称
                            .Q = Me.m_IntialSource.Q0 * 1000000 '泄漏物质的速率mg/s
                            .Ts = Me.m_IntialSource.Ts0 + 273.15 '设置温度，摄氏度
                            .DurationTime = Me.m_IntialSource.DurationT0 * 60 '排放持续时间转化为S
                            .He = Me.m_IntialSource.H   '有效排放高度
                            If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                            Else
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                            End If
                            .ResetMulti(.n) '设置烟团个数为n个
                            For i = 1 To .n Step 1
                                .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                                .Si(i) = Me.m_IntialSource.S_S
                                .Thickness(i) = Me.m_IntialSource.Thickness  '体源的厚度
                                If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                    .Qi(i) = ((Me.m_IntialSource.DurationT0 * 60) - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                                End If
                            Next i
                        End With

                        '非正常

                        Me.m_Sources(sn).VLeak = New VolumeLeak '实例化体源对象
                        Me.m_Sources(sn).VLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                        Me.m_Sources(sn).VLeak.Q = Me.m_IntialSource.Q0 * 1000000 '泄漏物质的速率mg/s
                        Me.m_Sources(sn).VLeak.Ts = Me.m_IntialSource.Ts0 + 273.15 '设置温度，摄氏度
                        Me.m_Sources(sn).VLeak.DurationTime = Me.m_IntialSource.DurationT0 * 60  '排放持续时间转化为S
                        Me.m_Sources(sn).VLeak.He = Me.m_IntialSource.H  '有效排放高度
                        Me.m_Sources(sn).VLeak.S = Me.m_IntialSource.S_S  '体源的底面积
                        Me.m_Sources(sn).VLeak.Hv = Me.m_IntialSource.Thickness  '体源的厚度
                End Select
            Case 1 '(2)气体容器小孔、中孔泄漏
                Dim QG As Double '排放速率kg/s
                Dim Q1 As Double  '排气量，m3/s
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = Me.m_IntialSource.InT + 273.15  '将摄氏度转化为绝对温度
                    QG = CalculateLeakGas(Me.m_IntialSource.LeakGasShape, .Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, Me.m_IntialSource.LeakGasP, Me.m_IntialSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                    If QG = ErrorValue Then
                        Return False
                    End If
                    .Q = QG * 1000000 '泄漏速率，mg/s
                    Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                    .Qv = Q1 * Me.m_ForeCast.Pa / Me.m_IntialSource.LeakGasP  '等效排气量
                    .D = System.Math.Sqrt(Me.m_IntialSource.LeakGasA / Math.PI) * 2 '等效排气筒直径
                    .DH = RiseH(Pa_BP, .Qv, .D, .H, .Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, Me.m_IntialSource.Angle) '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / QG Then
                        .DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = Me.m_IntialSource.Q / QG '泄漏持续时间
                    End If

                    If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                        .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                    Else
                        .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                    End If
                    .ResetMulti(.n) '设置烟团个数为n个

                    For i = 1 To .n Step 1
                        .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                        .Si(i) = 0
                        .Thickness(i) = 0
                        If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                            .Qi(i) = (.DurationTime - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                        End If
                        .V(i) = .Q / 1000000 '泄漏速率为kg/s表示
                    Next i
                    .QpAllT = .DurationTime
                End With
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.H = Me.m_IntialSource.H    '排放高度
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度

                QG = CalculateLeakGas(Me.m_IntialSource.LeakGasShape, Me.m_Sources(sn).PLeak.Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, Me.m_IntialSource.LeakGasP, Me.m_IntialSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                Me.m_Sources(sn).PLeak.QAll = QG * 1000000 '泄漏速率，mg/s
                Me.m_Sources(sn).PLeak.Q = QG * 1000000 '泄漏速率，mg/s
                Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                Me.m_Sources(sn).PLeak.Qv = Q1 * Me.m_ForeCast.Pa / Me.m_IntialSource.LeakGasP  '等效排气量m3/s，
                Me.m_Sources(sn).PLeak.D = System.Math.Sqrt(Me.m_IntialSource.LeakGasA / Math.PI) * 2 ' 等效排气筒直径
                Me.m_Sources(sn).PLeak.DH = RiseH(Pa_BP, Me.m_Sources(sn).PLeak.Qv, Me.m_Sources(sn).PLeak.D, Me.m_Sources(sn).PLeak.H, Me.m_Sources(sn).PLeak.Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, Me.m_IntialSource.Angle) '烟气抬升高度
                Me.m_Sources(sn).PLeak.He = Me.m_Sources(sn).PLeak.H + Me.m_Sources(sn).PLeak.DH  '泄漏源有效高度
                If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / QG Then
                    Me.m_Sources(sn).PLeak.DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间，S
                Else
                    Me.m_Sources(sn).PLeak.DurationTime = Me.m_IntialSource.Q / QG '泄漏持续时间，S
                End If

            Case 2 '(3)气体容器爆裂
                '多烟团模型
                QLG = Me.m_IntialSource.Q   '总的储存量
                E1 = QLG
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H
                    .He = Me.m_IntialSource.H  '泄漏源有效高度
                    .DurationTime = 1
                    .QpAll = QLG * 1000000
                    .QpAllT = 1
                    .n = 1
                    .ResetMulti(.n) '设置烟团个数为1个
                    .V(1) = QLG / 1 '泄漏速率,kg/s 
                    .V1(1) = E1 / 1 '泄漏蒸发速率,kg/s 间
                    .QpAll = QLG * 1000000
                    .Qi(1) = E1 * 1000000 '闪蒸量,mg/s
                    .Si(1) = 0  '面积
                    .Thickness(1) = 0 '厚度
                End With

                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0 '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.He  '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
            Case 3 '(4)压力液化气容器液下小孔、中孔泄漏

                '计算液体泄漏速率kg/s
                QLG = CalculateLeakLiquid(1, Me.m_IntialSource.LeakLiquidCd, Me.m_IntialSource.LeakLiquidHeight, Me.m_IntialSource.LeakGasA, Me.m_Chemical.LeakLiquidPl, Me.m_IntialSource.LeakGasP, Me.m_ForeCast.Pa)
                If QLG = ErrorValue Then
                    Return False
                End If
                '计算泄漏液体的蒸发量速率kg/s
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, Me.m_IntialSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
                If Fv_Renamed >= 0.2 Then
                    Return False
                End If
                If Fv_Renamed >= 0.2 Then
                    E1 = QLG
                ElseIf Fv_Renamed <= 0 Then
                    E1 = 0
                Else
                    E1 = Fv_Renamed * 5 * QLG
                End If
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = Me.m_IntialSource.InT + 273.15 '将摄氏度转化为绝对温度
                    .QpAll = QLG * 1000000
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .DH = 0 '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / E1 Then
                        .DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = Me.m_IntialSource.Q / E1 '泄漏持续时间
                    End If
                    If .DurationTime Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                        .n = Fix(.DurationTime / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                    Else
                        .n = Fix(.DurationTime / Me.m_ForeCast.OutPut.IntervalTime)
                    End If
                    .ResetMulti(.n) '设置烟团个数为n个
                    For i = 1 To .n Step 1
                        .Qi(i) = .Q * Me.m_ForeCast.OutPut.IntervalTime
                        .Si(i) = 0
                        .Thickness(i) = 0
                        If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                            .Qi(i) = (.DurationTime - (i - 1) * Me.m_ForeCast.OutPut.IntervalTime) * .Q
                        End If
                        .V(i) = QLG
                        .V1(i) = E1
                    Next i
                    .QpAllT = .DurationTime
                    QGroundAll = (QLG - E1) * .QpAllT '泄漏到地面的总量
                End With
                '计算泄漏后形成液池
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个

                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * Me.m_ForeCast.OutPut.IntervalTime To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                If j * E1 <= Me.m_IntialSource.Q Then  '计算某一时刻的泄漏到地面的量，以便计算液池半径
                                    QGround = j * (QLG - E1)  'kg
                                Else
                                    QGround = Me.m_IntialSource.Q  'kg
                                End If
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QGround, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                '先根据热量蒸发和质量蒸发速率求出最大液池面积，二分法--------------------------------------
                                Dim S1, S2 As Double
                                S1 = 0
                                S2 = 1000000
                                Smax = 0
                                Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If Vh + Vq > QLG - E1 Then '如果蒸发速率大于泄漏速率,则计算最大面积
                                    S2 = Sj
                                    While Math.Abs(Vh + Vq - (QLG - E1)) > 0.000001
                                        Smax = (S2 + S1) / 2
                                        Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Smax, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                        Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Smax) '计算质量蒸发速率,kg/s,1km^2
                                        If Vh = ErrorValue Or Vq = ErrorValue Then
                                            Return False
                                        End If
                                        If Vh + Vq > QLG - E1 Then
                                            S2 = Smax
                                        Else
                                            S1 = Smax
                                        End If
                                    End While
                                    Sj = Smax
                                End If
                                Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                Q4 = Q2 + Q3 '计算出总的蒸发量
                                .QsAllT = j '总的蒸发时间
                                If .QsAll + Q4 >= QGroundAll Then '蒸发量大于泄漏至地面的总量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If
                            Next j
                            If .QsAll + Q4 >= QGroundAll Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .QsAll = QGroundAll
                                .Qi(i) = (QGroundAll - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                If Vh + Vq <= QLG - E1 Then
                                    .V4(i) = .V2(i) + .V3(i) '计算出总的蒸发量
                                Else '如果热量蒸发量与质量蒸发量之和大于泄漏到地面的量，则取泄漏到地面的量
                                    .V4(i) = QLG - E1
                                End If
                                Exit For
                            End If
                            If Vh = ErrorValue Or Vq = ErrorValue Then
                                Return False
                            End If
                            .Qi(i) = Q4 * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .QsAll = .QsAll + Q4
                            .V4(i) = .V2(i) + .V3(i) '计算出总的蒸发量
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                            Q4 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.Q '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = MultiPLeak.Ts '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0   '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.H '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = MultiSLeak.QsAll * 1000000 / MultiSLeak.DurationTime  '泄漏物质的蒸发的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积
            Case 4 '(5)压力液化气容器液上小孔、中孔泄漏
                Dim QG As Double '排放速率kg/s
                Dim Q1 As Double  '排气量，m3/s
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = Me.m_IntialSource.InT + 273.15  '将摄氏度转化为绝对温度
                    QG = CalculateLeakGas(Me.m_IntialSource.LeakGasShape, .Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, Me.m_IntialSource.LeakGasP, Me.m_IntialSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                    If QG = ErrorValue Then
                        Return False
                    End If
                    .Q = QG * 1000000 '泄漏速率，mg/s
                    Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                    .Qv = Q1 * Me.m_ForeCast.Pa / Me.m_IntialSource.LeakGasP  '等效排气量
                    .D = System.Math.Sqrt(Me.m_IntialSource.LeakGasA / Math.PI) * 2 '等效排气筒直径
                    .DH = RiseH(Pa_BP, .Qv, .D, .H, .Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, Me.m_IntialSource.Angle) '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / QG Then
                        .DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = Me.m_IntialSource.Q / QG '泄漏持续时间
                    End If

                    If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                        .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                    Else
                        .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                    End If
                    .ResetMulti(.n) '设置烟团个数为n个

                    For i = 1 To .n Step 1
                        .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                        .Si(i) = 0
                        .Thickness(i) = 0
                        If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                            .Qi(i) = (.DurationTime - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                        End If
                        .V(i) = .Q / 1000000 '泄漏速率为kg/s表示
                    Next i
                    .QpAllT = .DurationTime
                End With
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.H = Me.m_IntialSource.H    '排放高度
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度

                QG = CalculateLeakGas(Me.m_IntialSource.LeakGasShape, Me.m_Sources(sn).PLeak.Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, Me.m_IntialSource.LeakGasP, Me.m_IntialSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                Me.m_Sources(sn).PLeak.QAll = QG * 1000000 '泄漏速率，mg/s
                Me.m_Sources(sn).PLeak.Q = QG * 1000000 '泄漏速率，mg/s
                Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                Me.m_Sources(sn).PLeak.Qv = Q1 * Me.m_ForeCast.Pa / Me.m_IntialSource.LeakGasP  '等效排气量m3/s，
                Me.m_Sources(sn).PLeak.D = System.Math.Sqrt(Me.m_IntialSource.LeakGasA / Math.PI) * 2 ' 等效排气筒直径
                Me.m_Sources(sn).PLeak.DH = RiseH(Pa_BP, Me.m_Sources(sn).PLeak.Qv, Me.m_Sources(sn).PLeak.D, Me.m_Sources(sn).PLeak.H, Me.m_Sources(sn).PLeak.Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, Me.m_IntialSource.Angle) '烟气抬升高度
                Me.m_Sources(sn).PLeak.He = Me.m_Sources(sn).PLeak.H + Me.m_Sources(sn).PLeak.DH  '泄漏源有效高度
                If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / QG Then
                    Me.m_Sources(sn).PLeak.DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间，S
                Else
                    Me.m_Sources(sn).PLeak.DurationTime = Me.m_IntialSource.Q / QG '泄漏持续时间，S
                End If
            Case 5 '(6)压力液化气容器爆裂
                '多烟团模型
                QLG = Me.m_IntialSource.Q   '总的储存量
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, Me.m_IntialSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
                If QLG = ErrorValue Or Fv_Renamed = ErrorValue Then
                    Return ErrorValue
                End If
                If Fv_Renamed >= 0.2 Then
                    E1 = QLG
                ElseIf Fv_Renamed <= 0 Then
                    E1 = 0
                Else
                    E1 = Fv_Renamed * 5 * QLG
                End If
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H
                    .He = Me.m_IntialSource.H  '泄漏源有效高度
                    .DurationTime = 1
                    .QpAll = QLG * 1000000
                    .QpAllT = 1
                    .n = 1
                    .ResetMulti(.n) '设置烟团个数为1个
                    .V(1) = QLG / 1 '泄漏速率,kg/s 
                    .V1(1) = E1 / 1 '泄漏蒸发速率,kg/s 间
                    .Qi(1) = E1 * 1000000 '闪蒸量,mg/s
                    .Si(1) = 0  '面积
                    .Thickness(1) = 0 '厚度
                End With
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                .QsAllT = j '总的蒸发时间
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If

                            Next j
                            If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .Qi(i) = (QLG - E1 - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                Exit For
                            End If
                            .Qi(i) = (Q2 + Q3) * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                            .QsAll = .QsAll + Q2 + Q3
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0 '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.He  '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0 '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = (QLG - E1) * 1000000 / MultiSLeak.DurationTime  '泄漏物质的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积
            Case 6 '(7)常压液体容器小孔、中孔泄漏

                '计算液体泄漏速率kg/s
                QLG = CalculateLeakLiquid(1, Me.m_IntialSource.LeakLiquidCd, Me.m_IntialSource.LeakLiquidHeight, Me.m_IntialSource.LeakGasA, Me.m_Chemical.LeakLiquidPl, Me.m_IntialSource.LeakGasP, Me.m_ForeCast.Pa)
                If QLG = ErrorValue Then
                    Return False
                End If
                '计算泄漏液体的蒸发量速率kg/s
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, Me.m_IntialSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
                E1 = 0
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = Me.m_IntialSource.InT + 273.15 '将摄氏度转化为绝对温度
                    .QpAll = QLG * 1000000
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .DH = 0 '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / E1 Then
                        .DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = Me.m_IntialSource.Q / E1 '泄漏持续时间
                    End If
                    If .DurationTime Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                        .n = Fix(.DurationTime / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                    Else
                        .n = Fix(.DurationTime / Me.m_ForeCast.OutPut.IntervalTime)
                    End If
                    .ResetMulti(.n) '设置烟团个数为n个
                    For i = 1 To .n Step 1
                        .Qi(i) = .Q * Me.m_ForeCast.OutPut.IntervalTime
                        .Si(i) = 0
                        .Thickness(i) = 0
                        If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                            .Qi(i) = (.DurationTime - (i - 1) * Me.m_ForeCast.OutPut.IntervalTime) * .Q
                        End If
                        .V(i) = QLG
                        .V1(i) = E1
                    Next i
                    .QpAllT = .DurationTime
                    QGroundAll = (QLG - E1) * .QpAllT '泄漏到地面的总量
                End With
                '计算泄漏后形成液池
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个

                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * Me.m_ForeCast.OutPut.IntervalTime To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                If j * E1 <= Me.m_IntialSource.Q Then  '计算某一时刻的泄漏到地面的量，以便计算液池半径
                                    QGround = j * (QLG - E1)  'kg
                                Else
                                    QGround = Me.m_IntialSource.Q  'kg
                                End If
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QGround, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                '先根据热量蒸发和质量蒸发速率求出最大液池面积，二分法--------------------------------------
                                Dim S1, S2 As Double
                                S1 = 0
                                S2 = 1000000
                                Smax = 0
                                Vh = 0 '热量蒸发速率,kg/s
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If Vh + Vq > QLG - E1 Then '如果蒸发速率大于泄漏速率,则计算最大面积
                                    S2 = Sj
                                    While Math.Abs(Vh + Vq - (QLG - E1)) > 0.000001
                                        Smax = (S2 + S1) / 2
                                        Vh = 0 '热量蒸发速率,kg/s
                                        Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Smax) '计算质量蒸发速率,kg/s,1km^2
                                        If Vh = ErrorValue Or Vq = ErrorValue Then
                                            Return False
                                        End If
                                        If Vh + Vq > QLG - E1 Then
                                            S2 = Smax
                                        Else
                                            S1 = Smax
                                        End If
                                    End While
                                    Sj = Smax
                                End If
                                Vh = 0 '热量蒸发速率,kg/s
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                Q4 = Q2 + Q3 '计算出总的蒸发量
                                .QsAllT = j '总的蒸发时间
                                If .QsAll + Q4 >= QGroundAll Then '蒸发量大于泄漏至地面的总量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If
                            Next j
                            If .QsAll + Q4 >= QGroundAll Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .QsAll = QGroundAll
                                .Qi(i) = (QGroundAll - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                If Vh + Vq <= QLG - E1 Then
                                    .V4(i) = .V2(i) + .V3(i) '计算出总的蒸发量
                                Else '如果热量蒸发量与质量蒸发量之和大于泄漏到地面的量，则取泄漏到地面的量
                                    .V4(i) = QLG - E1
                                End If
                                Exit For
                            End If
                            If Vh = ErrorValue Or Vq = ErrorValue Then
                                Return False
                            End If
                            .Qi(i) = Q4 * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .QsAll = .QsAll + Q4
                            .V4(i) = .V2(i) + .V3(i) '计算出总的蒸发量
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                            Q4 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.Q '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = MultiPLeak.Ts '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0   '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.H '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = MultiSLeak.QsAll * 1000000 / MultiSLeak.DurationTime  '泄漏物质的蒸发的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积

            Case 7 '(8)常压液体容器爆裂
                '多烟团模型
                QLG = Me.m_IntialSource.Q   '总的储存量
                Fv_Renamed = 0 '计算蒸发系数
                If QLG = ErrorValue Or Fv_Renamed = ErrorValue Then
                    Return ErrorValue
                End If
                If Fv_Renamed >= 0.2 Then
                    E1 = QLG
                ElseIf Fv_Renamed <= 0 Then
                    E1 = 0
                Else
                    E1 = Fv_Renamed * 5 * QLG
                End If
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H
                    .He = Me.m_IntialSource.H  '泄漏源有效高度
                    .DurationTime = 1
                    .QpAll = QLG * 1000000
                    .QpAllT = 1
                    .n = 1
                    .ResetMulti(.n) '设置烟团个数为1个
                    .V(1) = QLG / 1 '泄漏速率,kg/s 
                    .V1(1) = E1 / 1 '泄漏蒸发速率,kg/s 间
                    .Qi(1) = E1 * 1000000 '闪蒸量,mg/s
                    .Si(1) = 0  '面积
                    .Thickness(1) = 0 '厚度
                End With
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                Vh = 0 '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                .QsAllT = j '总的蒸发时间
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If

                            Next j
                            If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .Qi(i) = (QLG - E1 - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                Exit For
                            End If
                            .Qi(i) = (Q2 + Q3) * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                            .QsAll = .QsAll + Q2 + Q3
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0 '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.He  '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0 '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = (QLG - E1) * 1000000 / MultiSLeak.DurationTime  '泄漏物质的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积


            Case 8 '(9)压力液化气容器两相流泄漏
                '计算两相泄漏速率kg/s
                QLG = CalculateLeakTwo(Me.m_Chemical.LeakLiquidCP, Me.m_IntialSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, m_Chemical.Pg, m_Chemical.LeakLiquidPl, m_IntialSource.LeakTwoCd, m_IntialSource.LeakGasA, m_IntialSource.LeakGasP, m_IntialSource.LeakGasP * 0.55)
                '计算泄漏液体的蒸发量速率kg/s
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, Me.m_IntialSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
                If Fv_Renamed >= 0.2 Then
                    E1 = QLG
                ElseIf Fv_Renamed <= 0 Then
                    E1 = 0
                Else
                    E1 = Fv_Renamed * 5 * QLG
                End If
                If QLG = ErrorValue Or Fv_Renamed = ErrorValue Then
                    Return ErrorValue
                End If
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = Me.IntialSource.InT + 273.15 '将摄氏度转化为绝对温度
                    .QpAll = QLG * 1000000
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .DH = 0 '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If Me.m_IntialSource.DurationT * 60 <= Me.m_IntialSource.Q / E1 Then
                        .DurationTime = Me.m_IntialSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = Me.m_IntialSource.Q / E1 '泄漏持续时间
                    End If
                    If .DurationTime Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                        .n = Fix(.DurationTime / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                    Else
                        .n = Fix(.DurationTime / Me.m_ForeCast.OutPut.IntervalTime)
                    End If
                    .ResetMulti(.n) '设置烟团个数为n个
                    For i = 1 To .n Step 1
                        .Qi(i) = .Q * Me.m_ForeCast.OutPut.IntervalTime
                        .Si(i) = 0
                        .Thickness(i) = 0
                        If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                            .Qi(i) = (.DurationTime - (i - 1) * Me.m_ForeCast.OutPut.IntervalTime) * .Q
                        End If
                        .V(i) = QLG
                        .V1(i) = E1
                    Next i
                    .QpAllT = .DurationTime
                    QGroundAll = (QLG - E1) * .QpAllT '泄漏到地面的总量
                End With
                '计算泄漏后形成液池
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个

                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * Me.m_ForeCast.OutPut.IntervalTime To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                If j * E1 <= Me.m_IntialSource.Q Then  '计算某一时刻的泄漏到地面的量，以便计算液池半径
                                    QGround = j * (QLG - E1)  'kg
                                Else
                                    QGround = Me.m_IntialSource.Q  'kg
                                End If
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QGround, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                '先根据热量蒸发和质量蒸发速率求出最大液池面积，二分法--------------------------------------
                                Dim S1, S2 As Double
                                S1 = 0
                                S2 = 1000000
                                Smax = 0
                                Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If Vh + Vq > QLG - E1 Then '如果蒸发速率大于泄漏速率,则计算最大面积
                                    S2 = Sj
                                    While Math.Abs(Vh + Vq - (QLG - E1)) > 0.000001
                                        Smax = (S2 + S1) / 2
                                        Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Smax, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                        Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Smax) '计算质量蒸发速率,kg/s,1km^2
                                        If Vh + Vq > QLG - E1 Then
                                            S2 = Smax
                                        Else
                                            S1 = Smax
                                        End If
                                    End While
                                    Sj = Smax
                                End If
                                Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                Q4 = Q2 + Q3 '计算出总的蒸发量
                                .QsAllT = j '总的蒸发时间
                                If .QsAll + Q4 >= QGroundAll Then '蒸发量大于泄漏至地面的总量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If
                            Next j
                            If .QsAll + Q4 >= QGroundAll Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .QsAll = QGroundAll
                                .Qi(i) = (QGroundAll - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                If Vh + Vq <= QLG - E1 Then
                                    .V4(i) = .V2(i) + .V3(i) '计算出总的蒸发量
                                Else '如果热量蒸发量与质量蒸发量之和大于泄漏到地面的量，则取泄漏到地面的量
                                    .V4(i) = QLG - E1
                                End If
                                Exit For
                            End If
                            .Qi(i) = Q4 * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .QsAll = .QsAll + Q4
                            .V4(i) = .V2(i) + .V3(i) '计算出总的蒸发量
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                            Q4 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.Q '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = MultiPLeak.Ts '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0   '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.H '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = MultiSLeak.QsAll * 1000000 / MultiSLeak.DurationTime  '泄漏物质的蒸发的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积

            Case 9 '(10)冷冻液化气容器小孔、中孔泄漏
                '多烟团模型
                QLG = Me.m_IntialSource.Q   '总的储存量
                Fv_Renamed = 0 '计算蒸发系数
                If QLG = ErrorValue Or Fv_Renamed = ErrorValue Then
                    Return ErrorValue
                End If
                If Fv_Renamed >= 0.2 Then
                    E1 = QLG
                ElseIf Fv_Renamed <= 0 Then
                    E1 = 0
                Else
                    E1 = Fv_Renamed * 5 * QLG
                End If
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H
                    .He = Me.m_IntialSource.H  '泄漏源有效高度
                    .DurationTime = 1
                    .QpAll = QLG * 1000000
                    .QpAllT = 1
                    .n = 1
                    .ResetMulti(.n) '设置烟团个数为1个
                    .V(1) = QLG / 1 '泄漏速率,kg/s 
                    .V1(1) = E1 / 1 '泄漏蒸发速率,kg/s 间
                    .Qi(1) = E1 * 1000000 '闪蒸量,mg/s
                    .Si(1) = 0  '面积
                    .Thickness(1) = 0 '厚度
                End With
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                Vh = CalculateLeakHeat(Me.m_IntialSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                .QsAllT = j '总的蒸发时间
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If

                            Next j
                            If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .Qi(i) = (QLG - E1 - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                Exit For
                            End If
                            .Qi(i) = (Q2 + Q3) * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                            .QsAll = .QsAll + Q2 + Q3
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0 '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.He  '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0 '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = (QLG - E1) * 1000000 / MultiSLeak.DurationTime  '泄漏物质的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积

            Case 10 '(11)冷冻液化气容器爆裂
                '多烟团模型
                QLG = Me.m_IntialSource.Q   '总的储存量
                Fv_Renamed = 0 '计算蒸发系数
                If QLG = ErrorValue Or Fv_Renamed = ErrorValue Then
                    Return ErrorValue
                End If
                If Fv_Renamed >= 0.2 Then
                    E1 = QLG
                ElseIf Fv_Renamed <= 0 Then
                    E1 = 0
                Else
                    E1 = Fv_Renamed * 5 * QLG
                End If
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = Me.m_IntialSource.H
                    .He = Me.m_IntialSource.H  '泄漏源有效高度
                    .DurationTime = 1
                    .QpAll = QLG * 1000000
                    .QpAllT = 1
                    .n = 1
                    .ResetMulti(.n) '设置烟团个数为1个
                    .V(1) = QLG / 1 '泄漏速率,kg/s 
                    .V1(1) = E1 / 1 '泄漏蒸发速率,kg/s 间
                    .Qi(1) = E1 * 1000000 '闪蒸量,mg/s
                    .Si(1) = 0  '面积
                    .Thickness(1) = 0 '厚度
                End With
                If Fv_Renamed < 0.2 Then   '如果有液体形成液池
                    With MultiSLeak
                        .Name = Me.m_Chemical.Name0
                        .He = Me.m_IntialSource.SHe  '面源的有效高度
                        .DurationTime = Me.m_IntialSource.VolatilizationT * 60 '面源的蒸发时间
                        If (Me.m_IntialSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((Me.m_IntialSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = Me.m_IntialSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r ^ 2
                                If Sj >= Me.m_IntialSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = Me.m_IntialSource.S
                                    r = Math.Sqrt(Me.m_IntialSource.S / Math.PI)
                                End If
                                Vh = 0 '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, Me.m_IntialSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
                                Q3 = Q3 + Vq * stepT '计算质量蒸发速率,计算出单位烟团的排放量kg
                                .QsAllT = j '总的蒸发时间
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一的烟团的量给Q(i)
                                    Exit For
                                End If

                            Next j
                            If .QsAll + Q2 + Q3 >= QLG - E1 Then '蒸发量大于泄漏至地面的量，则退出循环，并将最后一个的烟团的量给Q(i)
                                .Qi(i) = (QLG - E1 - .QsAll) * 1000000 '第i个烟团的量，mg
                                .V2(i) = Vh '热量蒸发速率
                                .V3(i) = Vq   '质量蒸发速率
                                .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                                .Si(i) = Sj
                                .Thickness(i) = 0
                                .DurationTime = .QsAllT  '蒸发时间
                                Exit For
                            End If
                            .Qi(i) = (Q2 + Q3) * 1000000   '第i个烟团的量，mg
                            .V2(i) = Vh '热量蒸发速率
                            .V3(i) = Vq   '质量蒸发速率
                            .V4(i) = .V2(i) + .V3(i) '总的液池蒸发量
                            .QsAll = .QsAll + Q2 + Q3
                            .Si(i) = Sj
                            .Thickness(i) = 0
                            Q2 = 0
                            Q3 = 0
                        Next i
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = Me.m_IntialSource.InT + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0 '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.He  '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
                '非正常排放模型,面源
                Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0 '泄漏物质名称
                Me.m_Sources(sn).SLeak.Q = (QLG - E1) * 1000000 / MultiSLeak.DurationTime  '泄漏物质的速率mg/s
                Me.m_Sources(sn).SLeak.Ts = Me.m_ForeCast.Ta + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).SLeak.DurationTime = MultiSLeak.DurationTime  '排放持续时间转化为S
                Me.m_Sources(sn).SLeak.He = MultiSLeak.He   '有效排放高度
                Me.m_Sources(sn).SLeak.S = Sj '面源的面积

        End Select

        Me.m_Sources(sn).MultiPLeak = MultiPLeak
        Me.m_Sources(sn).MultiSLeak = MultiSLeak
        Me.m_Sources(sn).MultiVLeak = MultiVLeak

        '重气体参数化
        If Me.m_IntialSource.IsHeavy Then
            '瞬时重气体模型
            m_Heavy(sn) = New DisPuff.AllHeavy
            m_Heavy(sn).BoxHeavy.MgMol = m_Chemical.LeakM '摩尔质量
            m_Heavy(sn).BoxHeavy.Cpg = m_Chemical.Cpg   '气体的定压比热容
            m_Heavy(sn).BoxHeavy.Pa = Forecast.Pa '环境压力
            m_Heavy(sn).BoxHeavy.Tempa = Forecast.Ta + 273.15 '环境温度
            m_Heavy(sn).BoxHeavy.boxMetAndMass.u10 = m_ForeCast.Met(sn).WindSpeed '风速
            m_Heavy(sn).BoxHeavy.boxMetAndMass.stab = m_ForeCast.Met(sn).Stab '稳定度
            m_Heavy(sn).BoxHeavy.boxMetAndMass.BoxAirMass(0) = New DisPuff.BoxAirMass
            m_Heavy(sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_Temp = m_IntialSource.InT + 273.15 '云团的初始温度


            '连续重气体模型
            m_Heavy(sn).SlabHeavy.MgMol = m_Chemical.LeakM '摩尔质量
            m_Heavy(sn).SlabHeavy.Cpg = m_Chemical.Cpg   '气体的定压比热容
            m_Heavy(sn).SlabHeavy.Pa = Forecast.Pa '环境压力
            m_Heavy(sn).BoxHeavy.Tempa = Forecast.Ta + 273.15 '环境温度
            m_Heavy(sn).SlabHeavy.SlabMetAndMass = New DisPuff.SlabMetAndMass
            m_Heavy(sn).SlabHeavy.SlabMetAndMass.u10 = m_ForeCast.Met(sn).WindSpeed '风速
            m_Heavy(sn).SlabHeavy.SlabMetAndMass.stab = m_ForeCast.Met(sn).Stab '稳定度
            '设置初始状态
            m_Heavy(sn).SlabHeavy.SlabMetAndMass.slabAirMass(0) = New DisPuff.SlabAirMass
            m_Heavy(sn).SlabHeavy.SlabMetAndMass.slabAirMass(0).m_Temp = m_IntialSource.InT + 273.15 '云团的初始温度


            '设置泄漏的量
            If Me.m_Sources(sn).MultiPLeak.n = 1 Then
                Me.m_Sources(sn).MultiPLeak.HeavyType = 0 '设置重气体
                m_Heavy(sn).BoxHeavy.Mg = Me.m_Sources(sn).MultiPLeak.Qi(1) / 1000000 '泄漏物质的量
            ElseIf Me.m_Sources(sn).MultiPLeak.n > 1 Then
                Me.m_Sources(sn).MultiPLeak.HeavyType = 1 '设置重气体
                m_Heavy(sn).SlabHeavy.MgS = Me.m_Sources(sn).MultiPLeak.Q / 1000000 '泄漏物质的质量kg/s
            End If

            If Me.m_Sources(sn).MultiSLeak.n = 1 Then
                Me.m_Sources(sn).MultiSLeak.HeavyType = 0 '设置重气体
                m_Heavy(sn).BoxHeavy.Mg = m_Heavy(sn).BoxHeavy.Mg + Me.m_Sources(sn).MultiSLeak.Qi(1) / 1000000 '泄漏物质的量
            ElseIf Me.m_Sources(sn).MultiSLeak.n > 1 Then
                Me.m_Sources(sn).MultiSLeak.HeavyType = 1 '设置重气体
                m_Heavy(sn).SlabHeavy.MgS = m_Heavy(sn).SlabHeavy.MgS + Me.m_Sources(sn).MultiSLeak.Q / 1000000 '泄漏物质的质量kg/s
            End If

            If Me.m_Sources(sn).MultiVLeak.n = 1 Then
                Me.m_Sources(sn).MultiVLeak.HeavyType = 0 '设置重气体
                m_Heavy(sn).BoxHeavy.Mg = m_Heavy(sn).BoxHeavy.Mg + Me.m_Sources(sn).MultiVLeak.Qi(1) / 1000000 '泄漏物质的量
            ElseIf Me.m_Sources(sn).MultiVLeak.n > 1 Then
                Me.m_Sources(sn).MultiVLeak.HeavyType = 1 '设置重气体
                m_Heavy(sn).SlabHeavy.MgS = m_Heavy(sn).SlabHeavy.MgS + Me.m_Sources(sn).MultiVLeak.Q / 1000000 '泄漏物质的质量kg/s
            End If
            '设置空气卷入的量
            m_Heavy(sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_Ma = m_IntialSource.AirProportion * m_Heavy(sn).BoxHeavy.Mg  '卷入空气的初始质量

            m_Heavy(sn).SlabHeavy.MaS = m_IntialSource.AirProportion * m_Heavy(sn).SlabHeavy.MgS '卷入空气的初始质量,kg/s

            '计算重气体参数
            m_Heavy(sn).BoxHeavy.CalHeavy()
            m_Heavy(sn).SlabHeavy.CalHeavy()
        End If
    End Function

    ''' <summary>
    ''' 计算网格点的瞬时浓度、滑移平均浓度、毒性负荷死亡概率和死亡百分率
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateGrid(ByVal Sn As Integer) '计算网格点浓度分布
        Dim dblx As Double 'X轴坐标
        Dim dbly As Double 'Y轴坐标
        Dim dblz As Double 'Z轴坐标
        Dim dblForecastTime As Double '定义一下变量用来储存预测时刻
        Dim MinX As Double
        Dim MaxY As Double
        Dim Result As Double '定义计算结果
        Dim i, j As Integer
        If Me.m_ForeCast.OutPut.IsInstantaneous = True Then '计算瞬时浓度
            For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
                '处理数组 
                dblForecastTime = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60 '将预测列表中的预测时刻按顺序赋值上述变量，乘以60，将单位转化为秒
                '计算网格点的扩散参数和浓度-----------------------
                MinX = Me.m_ForeCast.Grid.MinX  'X轴从坐标负数到正数开始计算浓度
                MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) 'y轴从坐标正数到负数开始计算浓度
                dblx = MinX
                dbly = MaxY
                dblz = Me.m_ForeCast.Grid.WGH
                '开始按网格点来计算预测浓度--------------------------------------------------------------
                '是绝对坐标系统，需转换坐标
                dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)


                '以下开始按网格点计算浓度分布-------------------------------------------------------------------
                For i = 0 To Me.m_ForeCast.Grid.CountX - 1 Step 1 '按X轴计算
                    For j = 0 To Me.m_ForeCast.Grid.CountY - 1 Step 1 '按Y轴计算
                        Result = ResultC(Sn, dblForecastTime, dblx, dbly, dblz) '计算给定时间和坐标的浓度值
                        '将计算结果存入网格数组中

                        Me.Results.AllGridResult.InstantaneousGridC(Sn, nCount, j, i) = Result '瞬时浓度

                        MaxY = MaxY - Me.m_ForeCast.Grid.StepY  'y值逐渐减小
                        '将网格点赋值给相应的坐标
                        dblx = MinX / 1.0#
                        dbly = MaxY / 1.0#
                        'If OptionCoordinate2.Checked = True Then
                        dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                        dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                        'End If

                        Result = 0 '将结果置0
                    Next j
                    MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) '给maxY初始值
                    MinX = MinX + Me.m_ForeCast.Grid.StepX  'minx增加
                    '将网格点赋值给相应的坐标
                    dblx = MinX / 1.0#
                    dbly = MaxY / 1.0#
                    '转换坐标
                    dblx = CoordinateX(MinX / 1.0#, MaxY / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                    dbly = CoordinateY(MinX / 1.0#, MaxY / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                Next i
                '设置计算进度
                Me.m_Results.AllProgress += 1
            Next nCount
        End If

        '---------------------------------------------------------------
        '计算毒性负荷
        '---------------------------------------------------------------
        MinX = Me.m_ForeCast.Grid.MinX  'X轴从坐标负数到正数开始计算浓度
        MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) 'y轴从坐标正数到负数开始计算浓度
        dblx = MinX
        dbly = MaxY
        dblz = Me.m_ForeCast.Grid.WGH
        '开始按网格点来计算预测浓度--------------------------------------------------------------
        '是绝对坐标系统，需转换坐标
        dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
        dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)

        Dim nToxinConut As Integer = Me.m_ForeCast.Grid.CountX * Me.m_ForeCast.Grid.CountY

        '以下开始按网格点计算浓度分布-------------------------------------------------------------------
        For i = 0 To Me.m_ForeCast.Grid.CountX - 1 Step 1 '按X轴计算
            For j = 0 To Me.m_ForeCast.Grid.CountY - 1 Step 1 '按Y轴计算
                '计算某一将网格点的最大浓度出现时间
                Dim dblMax As MaxCD = CarePointGroldCutCT(Sn, 0, 24 * 3600, dblx, dbly, dblz, 10)
                If dblMax.MaxC > 1 Then
                    Dim dblCnt As Double = ToxinCharge(Sn, dblx, dbly, dblz, dblMax.maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, dblMax.maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2) '用变步长求得毒性负荷的积分
                    Me.m_Results.AllGridResult.Pr(Sn, j, i) = m_Chemical.PrA + m_Chemical.PrB * Math.Log(dblCnt) '计算概率值

                    If Me.m_Results.AllGridResult.Pr(Sn, j, i) < 0 Then
                        Me.m_Results.AllGridResult.Pr(Sn, j, i) = 0
                    Else
                        Me.m_Results.AllGridResult.D(Sn, j, i) = DiePr.NormalSchool(Me.m_Results.AllGridResult.Pr(Sn, j, i)) * 100 '计算死亡百分率%
                        Me.m_Results.AllGridResult.PersonalRisk(j, i) += Me.m_Results.AllGridResult.D(Sn, j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100  '个人风险值叠加
                        Me.m_Results.AllGridResult.ArrayRisk(Sn) += Me.m_Results.AllGridResult.D(Sn, j, i) * Me.m_ForeCast.Met(Sn).Frequency * Me.m_ForeCast.Grid.GridPopulation(j, i) / 100 '事故风险值叠加
                        Me.m_Results.AllGridResult.AllRisk += Me.m_Results.AllGridResult.D(Sn, j, i) * Me.m_ForeCast.Met(Sn).Frequency * Me.m_ForeCast.Grid.GridPopulation(j, i) / 100 '总的事故概率叠加
                    End If
                End If

                MaxY = MaxY - Me.m_ForeCast.Grid.StepY  'y值逐渐减小
                '将网格点赋值给相应的坐标
                dblx = MinX / 1.0#
                dbly = MaxY / 1.0#
                'If OptionCoordinate2.Checked = True Then
                dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                'End If
                Result = 0 '将结果置0
                '修改进度
                Me.m_Results.Status2 = "正在计算网格点的死亡概率和死亡百分率，已完成" & FormatNumber((i * Me.m_ForeCast.Grid.CountY + j) / nToxinConut * 100, 1) & "%"

            Next j
            MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) '给maxY初始值
            MinX = MinX + Me.m_ForeCast.Grid.StepX  'minx增加
            '将网格点赋值给相应的坐标
            dblx = MinX / 1.0#
            dbly = MaxY / 1.0#
            '转换坐标
            'If OptionCoordinate2.Checked = True Then
            dblx = CoordinateX(MinX / 1.0#, MaxY / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
            dbly = CoordinateY(MinX / 1.0#, MaxY / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
            'End If
        Next i

        ''----------------------------------------------------------------------------------------------------------------------------------------
        ''计算网格的滑移平均最大浓度－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        ''----------------------------------------------------------------------------------------------------------------------------------------
        'If Me.Forecast.OutPut.IsSlipChecked = True Then
        '    '计算网格点的扩散参数和浓度-----------------------
        '    MinX = Me.m_ForeCast.Grid.MinX  'X轴从坐标负数到正数开始计算浓度
        '    MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) 'y轴从坐标正数到负数开始计算浓度
        '    dblx = MinX
        '    dbly = MaxY
        '    dblz = Me.m_ForeCast.Grid.WGH
        '    '开始按网格点来计算预测浓度--------------------------------------------------------------
        '    '是绝对坐标系统，需转换坐标
        '    dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
        '    dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)

        '    Dim nSlipConut As Integer = Me.m_ForeCast.Grid.CountX * Me.m_ForeCast.Grid.CountY
        '    '以下开始按网格点计算浓度分布-------------------------------------------------------------------
        '    For i = 0 To Me.m_ForeCast.Grid.CountX - 1 Step 1 '按X轴计算
        '        For j = 0 To Me.m_ForeCast.Grid.CountY - 1 Step 1 '按Y轴计算

        '            '计算某一将网格点的最大浓度出现时间
        '            Dim dblMax As MaxCD = CarePointGroldCutCT(Sn, 0, 600 * 3600, dblx, dbly, dblz)

        '            '计算将网格点的滑移平均最大浓度
        '            If dblMax.MaxC > 1 Then
        '                Me.m_Results.AllGridResult.SlipGrid(Sn, j, i) = ReceptorMaxSlipAverage(Sn, dblx, dbly, dblz, dblMax.maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, dblMax.maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2)

        '            End If

        '            MaxY = MaxY - Me.m_ForeCast.Grid.StepY  'y值逐渐减小
        '            '将网格点赋值给相应的坐标
        '            dblx = MinX / 1.0#
        '            dbly = MaxY / 1.0#
        '            'If OptionCoordinate2.Checked = True Then
        '            dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
        '            dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
        '            'End If
        '            Result = 0 '将结果置0

        '            '修改进度
        '            Me.m_Results.Status2 = "正在计算网格点的滑移平均最大值，已完成" & FormatNumber((i * Me.m_ForeCast.Grid.CountY + j) / nSlipConut * 100, 1) & "%"

        '        Next j
        '        MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) '给maxY初始值
        '        MinX = MinX + Me.m_ForeCast.Grid.StepX  'minx增加
        '        '将网格点赋值给相应的坐标
        '        dblx = MinX / 1.0#
        '        dbly = MaxY / 1.0#
        '        '转换坐标
        '        'If OptionCoordinate2.Checked = True Then
        '        dblx = CoordinateX(MinX / 1.0#, MaxY / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
        '        dbly = CoordinateY(MinX / 1.0#, MaxY / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
        '        'End If
        '    Next i
        '    Me.m_Results.Status2 = ""
        'End If
    End Sub


    '计算下风向浓度分布
    Private Sub CalculateVane(ByVal Sn As Integer) '计算下风向浓度分布
        Dim dblForecastTime As Double '定义一下变量用来储存预测时刻
        Dim Result As Double '定义计算结果
        Dim dblx As Double 'X轴坐标
        Dim dbly As Double 'Y轴坐标
        Dim dblz As Double 'Z轴坐标
        Dim i As Integer

        For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
            '处理数组
            dblForecastTime = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60 '将预测列表中的预测时刻按顺序赋值上述变量，乘以60，将单位转化为秒
            '计算下风向的扩散参数和浓度-----------------------
            dblx = 0
            dbly = 0
            dblz = Me.m_ForeCast.Grid.WGH

            Dim AAA(-1) As Integer  '数组
            If m_ForeCast.Vane.VaneType = 0 Then
                AAA = m_ForeCast.Vane.VaneA
            Else
                ReDim AAA(Me.m_ForeCast.Vane.VaneCount)
                For i = 0 To Me.m_ForeCast.Vane.VaneCount Step 1
                    AAA(i) = i * Me.m_ForeCast.Vane.VaneStep
                Next
            End If

            For i = 0 To AAA.Length - 1 Step 1 '按下风向计算，从0开始直到最后一个
                dblx = AAA(i)

                Result = ResultC(Sn, dblForecastTime, dblx, dbly, dblz) '计算浓度
                '将计算结果存入网格数组中
                Me.m_Results.MetResults(Sn).ForeTimeResults(nCount).GridVane(i) = Result
                '将网格点赋值给相应的坐标
                Result = 0 '将结果置0
            Next i
            '设置计算进度
            Me.m_Results.AllProgress += 1
        Next nCount

        '---------------------------------------------------------------------------------------------------------------------------------------
        '下风向滑移平均最大值
        '---------------------------------------------------------------------------------------------------------------------------------------
        If Me.Forecast.OutPut.IsSlipChecked Then
            '计算下风向的扩散参数和浓度-----------------------
            dblx = 0
            dbly = 0
            dblz = Me.m_ForeCast.Grid.WGH

            Dim AAA(-1) As Integer  '数组
            If m_ForeCast.Vane.VaneType = 0 Then
                AAA = m_ForeCast.Vane.VaneA
            Else
                ReDim AAA(Me.m_ForeCast.Vane.VaneCount)
                For i = 0 To Me.m_ForeCast.Vane.VaneCount Step 1
                    AAA(i) = i * Me.m_ForeCast.Vane.VaneStep
                Next
            End If
            For i = 0 To AAA.Length - 1 Step 1 '按下风向计算，从0开始直到最后一个
                dblx = AAA(i)

                Result = CalculateCareSlip(Sn, dblx, dbly, dblz).MaxCon  '计算滑移平均最大浓度
                '将计算结果存入网格数组中
                Me.m_Results.MetResults(Sn).Slip.GridVane(i) = Result
                '将网格点赋值给相应的坐标
                Result = 0 '将结果置0
            Next i
            '设置计算进度
        End If
    End Sub

    ''' <summary>
    ''' 计算绝对坐标的关心点浓度
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateCare(ByVal Sn As Integer)
        Dim Result As Double '定义计算结果
        Dim dblx As Double 'X轴坐标
        Dim dbly As Double 'Y轴坐标
        Dim dblz As Double 'Z轴坐标
        Dim i As Integer
        Dim dblForecastTime As Double '定义一下变量用来储存预测时刻
        '计算某一浓度关心点的最大浓度及出现时刻--------------------------------------------------------------------
        Dim startTime, endTime As Double '最大值可能出现的起始和结束时间
        startTime = 0 : endTime = 0
        Dim strMax As String = "" '用于储存最大浓度及出现时间

        For i = 0 To Me.m_ForeCast.CareReceptor.Length - 1 Step 1 '按关心点计算
            dblz = Me.m_ForeCast.CareReceptor(i).Point3D.z
            '如果是绝对坐标系统，需转换坐标
            dblx = CoordinateX(Me.m_ForeCast.CareReceptor(i).Point3D.x / 1.0#, Me.m_ForeCast.CareReceptor(i).Point3D.y / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
            dbly = CoordinateY(Me.m_ForeCast.CareReceptor(i).Point3D.x / 1.0#, Me.m_ForeCast.CareReceptor(i).Point3D.y / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)


            '计算某一关心点的最大浓度出现时间
            Dim dblMax As MaxCD = CarePointGroldCutCT(Sn, 0, 600 * 3600, dblx, dbly, dblz)
            Me.m_Results.AllCareResult.CarePointMaxCT(Sn, i) = dblMax

            '计算某一浓度出现在某一关心点的时刻--------------------------------------------------------------------
            Dim iCustomC As Integer
            For iCustomC = 0 To Me.m_ForeCast.HurtConcentration.Length - 1 '按浓度阀值进行预测
                Dim specifyC As Double = Me.m_ForeCast.HurtConcentration(iCustomC).ConcentrationVale '伤害浓度值
                Dim specifyStartTime, specifyEndTime As Double '给定浓度值的开始时间和结束时间
                If dblMax.MaxC >= specifyC Then '如果最大浓度大于浓度阀值则进行计算，否则不计算
                    '首先计算开始时间。先从数组找出第一个大于浓度阀值的极大值
                    '采用二分法求出该时间
                    specifyStartTime = CarePointCandT(Sn, dblx, dbly, dblz, 0, dblMax.maxT, specifyC)
                    '再计算结束时间。先从数组找出最后一个大于浓度阀值的极大值

                    '采用二分法求出该时间
                    specifyEndTime = CarePointCandT(Sn, dblx, dbly, dblz, 600 * 3600, dblMax.maxT, specifyC)
                    '将计算结果存入关心点数组中listResult.CheckedItems
                    If specifyStartTime > 0 Or specifyEndTime > 0 Then
                        Me.m_Results.AllCareResult.CarePointTime(Sn, i, iCustomC).StartTime = specifyStartTime  '开始时间
                        Me.m_Results.AllCareResult.CarePointTime(Sn, i, iCustomC).EndTime = specifyEndTime '结束时间
                    End If
                    Result = 0 '将结果置0
                End If
            Next iCustomC
            '计算关心点的滑移平均最大浓度
            If Me.Forecast.OutPut.IsSlipChecked Then
                Me.m_Results.AllCareResult.SlipCare(Sn, i) = CalculateCareSlip(Sn, dblx, dbly, dblz)
            End If
        Next i
        '以下开始按关心点的瞬时浓度、死亡概率和死亡百分率-------------------------------------------------------------------
        For i = 0 To Me.m_ForeCast.CareReceptor.Length - 1 Step 1 '按关心点计算
            Dim dblCnt As Double = 0 '用于储存概率函数括号内的累积值
            '计算瞬时浓度
            For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
                '处理数组
                dblForecastTime = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60 '将预测列表中的预测时刻按顺序赋值上述变量，乘以60，将单位转化为秒

                dblz = Me.m_ForeCast.CareReceptor(i).Point3D.z
                '如果是绝对坐标系统，需转换坐标
                dblx = CoordinateX(Me.m_ForeCast.CareReceptor(i).Point3D.x / 1.0#, Me.m_ForeCast.CareReceptor(i).Point3D.y / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                dbly = CoordinateY(Me.m_ForeCast.CareReceptor(i).Point3D.x / 1.0#, Me.m_ForeCast.CareReceptor(i).Point3D.y / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
                Result = ResultC(Sn, dblForecastTime, dblx, dbly, dblz) '计算给定时间和坐标的浓度值
                '将计算结果存入关心数组中
                Me.m_Results.AllCareResult.InstantaneousCareC(Sn, nCount, i) = Result
                '将关心点赋值给相应的坐标
                Result = 0 '将结果置0
                '设置计算进度
                Me.m_Results.AllProgress += 1
            Next nCount

            dblz = Me.m_ForeCast.CareReceptor(i).Point3D.z
            '如果是绝对坐标系统，需转换坐标
            dblx = CoordinateX(Me.m_ForeCast.CareReceptor(i).Point3D.x / 1.0#, Me.m_ForeCast.CareReceptor(i).Point3D.y / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
            dbly = CoordinateY(Me.m_ForeCast.CareReceptor(i).Point3D.x / 1.0#, Me.m_ForeCast.CareReceptor(i).Point3D.y / 1.0#, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y)
            dblCnt = ToxinCharge(Sn, dblx, dbly, dblz, Me.m_Results.AllCareResult.CarePointMaxCT(Sn, i).maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, Me.m_Results.AllCareResult.CarePointMaxCT(Sn, i).maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2) '用变步长求得毒性负荷的积分
            Me.m_Results.AllCareResult.Pr(Sn, i) = m_Chemical.PrA + m_Chemical.PrB * Math.Log(dblCnt) '计算概率值
            If Me.m_Results.AllCareResult.Pr(Sn, i) < 0 Then
                Me.m_Results.AllCareResult.Pr(Sn, i) = 0
            End If
            Me.m_Results.AllCareResult.D(Sn, i) = DiePr.NormalSchool(Me.m_Results.AllCareResult.Pr(Sn, i)) * 100 '计算死亡百分率%
        Next i

    End Sub

    ''' <summary>
    ''' 计算绝对坐标的关心点浓度
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CalculateCareSlip(ByVal Sn As Integer, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double) As Slippage
        '计算某一浓度关心点的最大浓度及出现时刻--------------------------------------------------------------------
        Dim startTime, endTime As Double '最大值可能出现的起始和结束时间
        startTime = 0 : endTime = 0
        Dim strMax As String = "" '用于储存最大浓度及出现时间

        '计算某一关心点的最大浓度出现时间
        Dim dblMax As MaxCD = CarePointGroldCutCT(Sn, 0, 600 * 3600, dblx, dbly, dblz)
        '计算关心点的滑移平均最大浓度
        Dim ASlip As New Slippage
        ASlip = ReceptorMaxSlipAverage(Sn, dblx, dbly, dblz, dblMax.maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, dblMax.maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2)
        Return ASlip
    End Function
    ''' <summary>
    ''' 计算下风向轴线最大浓度值及出现距离
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateVaneMaxC(ByVal sn As Integer)
        Dim dblForecastTime As Double '定义一下变量用来储存预测时刻
        Dim Result As Double '定义计算结果
        Dim dblx As Double 'X轴坐标
        Dim dbly As Double 'Y轴坐标
        Dim dblz As Double 'Z轴坐标
        Dim i As Integer
        For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
            '首先找出等间距的最大值，再从中找出最大值。

            '处理数组
            dblForecastTime = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60 '将预测列表中的预测时刻按顺序赋值上述变量，乘以60，将单位转化为秒
            '计算下风向的扩散参数和浓度-----------------------
            dblx = 0
            dbly = 0
            dblz = Me.m_ForeCast.Grid.WGH

            '在计算前先计算出该风速下最大的浓度出现的最大可能距离。即风速*预测时间。然后再每隔10米计算一个数值。
            Dim iStep As Integer = 10
            Dim iCount As Integer = Math.Round(dblForecastTime * Me.m_ForeCast.Met(sn).u2 / iStep) + 1
            Dim max As New MaxConAndDistance '用于储存最大值
            For i = 0 To iCount Step 1 '按下风向计算，从0开始直到最后一个
                dblx = i * iStep
                '参数化结束
                Result = ResultC(sn, dblForecastTime, dblx, dbly, dblz) '计算浓度
                If Result > max.MaxCon Then '得到等间距的最大值
                    max.MaxCon = Result
                    max.MaxDistance = dblx
                End If
                '将网格点赋值给相应的坐标
                Result = 0 '将结果置0
            Next i
            '根据前面得到的等间距的最大值，用斐波那契法(黄金分割法)计算极大值浓度----------------------------------------------------------
            Dim High As Double
            Dim Low As Double
            Low = max.MaxDistance - iStep
            If Low <= 0 Then
                Low = 0.00000001
            End If
            High = max.MaxDistance + iStep
            Dim x1 As Double
            Dim x2 As Double
            x1 = Low + 0.618 * (High - Low)
            x2 = High - 0.618 * (High - Low)
            Dim F1 As Double
            Dim F2 As Double
            Dim Fmax As Double
            Dim xmax As Double
            While (High - Low) > 0.01

                F1 = ResultC(sn, dblForecastTime, x1, dbly, dblz) '计算浓度

                F2 = ResultC(sn, dblForecastTime, x2, dbly, dblz) '计算浓度
                If F1 < F2 Or F1 <= 0 Then
                    High = x1
                    x1 = x2
                    x2 = High - 0.618 * (High - Low)
                Else
                    Low = x2
                    x2 = x1
                    x1 = Low + 0.618 * (High - Low)
                End If
            End While
            xmax = (x1 + x2) / 2
            If F2 > F1 Then
                Fmax = F2
            Else
                Fmax = F1
            End If
            Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxDistance = xmax
            Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxCon = Fmax

            '找出某一浓度值出现的范围
            Dim X_1, X_2, XCenter, FX1, FX2, FXCenter As Double
            Dim Range As Double = 0 '浓度出现的范围
            For nDamage As Integer = 0 To Forecast.HurtConcentration.Length - 1 '循环求出所有设置的伤害浓度的范围
                Dim SpecifyC As Double = Forecast.HurtConcentration(nDamage).ConcentrationVale   '给定的浓度值
                If Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxCon >= SpecifyC Then '首先看看最大落地浓度是否大于该浓度，如果大于则开始求，否则为0
                    X_1 = Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxDistance
                    X_2 = MaxLength '最远距离为50km
                    FX1 = Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxCon
                    FX2 = 0
                    '采用二分法求给定值
                    Do
                        XCenter = (X_1 + X_2) / 2
                        FXCenter = ResultC(sn, dblForecastTime, XCenter, dbly, dblz) '计算浓度
                        If FXCenter >= SpecifyC Then '如果中间值>=指定值
                            X_1 = XCenter
                            FX1 = FXCenter
                        Else
                            X_2 = XCenter
                            FX2 = FXCenter
                        End If
                    Loop While Math.Abs(X_2 - X_1) > 0.01
                    '将求得的值给结果数组
                    Me.m_Results.MetResults(sn).ForeTimeResults(nCount).HurtLength(nDamage) = XCenter
                End If
            Next nDamage
            '设置计算进度
            Me.m_Results.AllProgress += 1
        Next nCount




        '------------------------------------------------------------------------------------------------------------------------------
        '计算滑移平均浓度
        '------------------------------------------------------------------------------------------------------------------------------
        If Me.Forecast.OutPut.IsSlipChecked = True Then
            '首先找出等间距的最大值，再从中找出最大值。

            '计算下风向的扩散参数和浓度-----------------------
            dblx = 0
            dbly = 0
            dblz = Me.m_ForeCast.Grid.WGH


            '在计算前先计算出该风速下最大的浓度出现的最大可能距离。即风速*预测时间。然后再每隔10米计算一个数值。
            Dim iStep As Integer = 10
            Dim iCount As Integer = Math.Round(dblForecastTime * Me.m_ForeCast.Met(sn).u2 / iStep) + 1
            Dim max As New MaxConAndDistance '用于储存最大值
            For i = 0 To iCount Step 1 '按下风向计算，从0开始直到最后一个
                dblx = i * iStep
                Result = CalculateCareSlip(sn, dblx, dbly, dblz).MaxCon  '计算浓度
                If Result > max.MaxCon Then '得到等间距的最大值
                    max.MaxCon = Result
                    max.MaxDistance = dblx
                End If
                '将网格点赋值给相应的坐标
                Result = 0 '将结果置0
            Next i
            '根据前面得到的等间距的最大值，用斐波那契法(黄金分割法)计算极大值浓度----------------------------------------------------------
            Dim High As Double
            Dim Low As Double
            Low = max.MaxDistance - iStep
            If Low <= 0 Then
                Low = 0.00000001
            End If
            High = max.MaxDistance + iStep
            Dim x1 As Double
            Dim x2 As Double
            x1 = Low + 0.618 * (High - Low)
            x2 = High - 0.618 * (High - Low)
            Dim F1 As Double
            Dim F2 As Double
            Dim Fmax As Double
            Dim xmax As Double
            While (High - Low) > 0.1

                F1 = CalculateCareSlip(sn, x1, dbly, dblz).MaxCon  '计算浓度
                F2 = CalculateCareSlip(sn, x2, dbly, dblz).MaxCon  '计算浓度
                If F1 < F2 Or F1 <= 0 Then
                    High = x1
                    x1 = x2
                    x2 = High - 0.618 * (High - Low)
                Else
                    Low = x2
                    x2 = x1
                    x1 = Low + 0.618 * (High - Low)
                End If
            End While
            xmax = (x1 + x2) / 2
            If F2 > F1 Then
                Fmax = F2
            Else
                Fmax = F1
            End If
            Me.m_Results.MetResults(sn).Slip.MaxConAndDistanceSlip.MaxDistance = xmax
            Me.m_Results.MetResults(sn).Slip.MaxConAndDistanceSlip.MaxCon = Fmax

            '找出某一浓度值出现的范围
            Dim X_1, X_2, XCenter, FX1, FX2, FXCenter As Double
            Dim Range As Double = 0 '浓度出现的范围
            For nDamage As Integer = 0 To Forecast.HurtConcentration.Length - 1 '循环求出所有设置的伤害浓度的范围
                Dim SpecifyC As Double = Forecast.HurtConcentration(nDamage).ConcentrationVale   '给定的浓度值
                If Me.m_Results.MetResults(sn).Slip.MaxConAndDistanceSlip.MaxCon >= SpecifyC Then '首先看看最大落地浓度是否大于该浓度，如果大于则开始求，否则为0
                    X_1 = Me.m_Results.MetResults(sn).Slip.MaxConAndDistanceSlip.MaxDistance
                    X_2 = MaxLength '最远距离为50km
                    FX1 = Me.m_Results.MetResults(sn).Slip.MaxConAndDistanceSlip.MaxCon
                    FX2 = 0
                    '采用二分法求给定值
                    Do
                        XCenter = (X_1 + X_2) / 2
                        FXCenter = CalculateCareSlip(sn, XCenter, dbly, dblz).MaxCon  '计算浓度
                        If FXCenter >= SpecifyC Then '如果中间值>=指定值
                            X_1 = XCenter
                            FX1 = FXCenter
                        Else
                            X_2 = XCenter
                            FX2 = FXCenter
                        End If
                    Loop While Math.Abs(X_2 - X_1) > 0.1
                    '将求得的值给结果数组
                    Me.m_Results.MetResults(sn).Slip.HurtLengthSlip(nDamage) = XCenter
                End If
            Next nDamage
            '设置计算进度
        End If
    End Sub

    ''' <summary>
    ''' 计算上风向轴线最大浓度值及出现距离
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateUpVaneMaxC(ByVal sn As Integer)
        Dim dblForecastTime As Double '定义一下变量用来储存预测时刻
        Dim Result As Double '定义计算结果
        Dim dblx As Double 'X轴坐标
        Dim dbly As Double 'Y轴坐标
        Dim dblz As Double 'Z轴坐标
        Dim i As Integer
        For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
            '首先找出等间距的最大值，再从中找出最大值。

            '处理数组
            dblForecastTime = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60 '将预测列表中的预测时刻按顺序赋值上述变量，乘以60，将单位转化为秒
            '计算下风向的扩散参数和浓度-----------------------
            dblx = 0
            dbly = 0
            dblz = Me.m_ForeCast.Grid.WGH


            '在计算前先计算出该风速下最大的浓度出现的最大可能距离。即风速*预测时间。然后再每隔10米计算一个数值。
            Dim iStep As Integer = 10
            Dim iCount As Integer = Math.Round(dblForecastTime * Me.m_ForeCast.Met(sn).u2 / iStep) + 1
            Dim max As New MaxConAndDistance '用于储存最大值
            For i = 0 To iCount Step 1 '按下风向计算，从0开始直到最后一个
                dblx = i * iStep
                Result = ResultC(sn, dblForecastTime, dblx, dbly, dblz) '计算浓度
                If Result > max.MaxCon Then '得到等间距的最大值
                    max.MaxCon = Result
                    max.MaxDistance = dblx
                End If
                '将网格点赋值给相应的坐标
                Result = 0 '将结果置0
            Next i
            '根据前面得到的等间距的最大值，用斐波那契法(黄金分割法)计算极大值浓度----------------------------------------------------------
            Dim High As Double
            Dim Low As Double
            Low = max.MaxDistance - iStep
            If Low <= 0 Then
                Low = 0.00000001
            End If
            High = max.MaxDistance + iStep
            Dim x1 As Double
            Dim x2 As Double
            x1 = Low + 0.618 * (High - Low)
            x2 = High - 0.618 * (High - Low)
            Dim F1 As Double
            Dim F2 As Double
            Dim Fmax As Double
            Dim xmax As Double
            While (High - Low) > 0.01

                F1 = ResultC(sn, dblForecastTime, x1, dbly, dblz) '计算浓度

                F2 = ResultC(sn, dblForecastTime, x2, dbly, dblz) '计算浓度
                If F1 < F2 Or F1 <= 0 Then
                    High = x1
                    x1 = x2
                    x2 = High - 0.618 * (High - Low)
                Else
                    Low = x2
                    x2 = x1
                    x1 = Low + 0.618 * (High - Low)
                End If
            End While
            xmax = (x1 + x2) / 2
            If F2 > F1 Then
                Fmax = F2
            Else
                Fmax = F1
            End If
            Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxDistance = xmax
            Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxCon = Fmax

            '找出某一浓度值出现的范围
            Dim X_1, X_2, XCenter, FX1, FX2, FXCenter As Double
            Dim Range As Double = 0 '浓度出现的范围
            For nDamage As Integer = 0 To Forecast.HurtConcentration.Length - 1 '循环求出所有设置的伤害浓度的范围
                Dim SpecifyC As Double = Forecast.HurtConcentration(nDamage).ConcentrationVale   '给定的浓度值
                If Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxCon >= SpecifyC Then '首先看看最大落地浓度是否大于该浓度，如果大于则开始求，否则为0
                    X_1 = (-1) * MaxLength '最远距离为-50km
                    X_2 = Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxDistance
                    FX1 = 0
                    FX2 = Me.m_Results.MetResults(sn).ForeTimeResults(nCount).MaxConAndDistance.MaxCon
                    '采用二分法求给定值
                    Do
                        XCenter = (X_1 + X_2) / 2
                        FXCenter = ResultC(sn, dblForecastTime, XCenter, dbly, dblz) '计算浓度
                        If FXCenter >= SpecifyC Then '如果中间值>=指定值
                            X_1 = XCenter
                            FX1 = FXCenter
                        Else
                            X_2 = XCenter
                            FX2 = FXCenter
                        End If
                    Loop While Math.Abs(X_2 - X_1) > 0.01
                    '将求得的值给结果数组
                    If XCenter > 0 Then
                        XCenter = 0
                    End If
                    Me.m_Results.MetResults(sn).ForeTimeResults(nCount).HurtLength(nDamage) = XCenter
                End If
            Next nDamage
            '设置计算进度
            Me.m_Results.AllProgress += 1
        Next nCount
    End Sub
    ''' <summary>
    ''' 这一模块用于计算不同的污染源的情况下的浓度值。
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="dblForecastTime">预测时间,s</param>
    ''' <param name="dblx">x坐标,m</param>
    ''' <param name="dbly">y坐标,m</param>
    ''' <param name="dblz">z坐标,m</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ResultC(ByVal Sn As Integer, ByVal dblForecastTime As Double, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double) As Double
        '点源泄漏
        Dim result As Double = 0

        If Me.m_Sources(Sn).MultiPLeak.Q > 0 Then
            Dim HeavyB, HeavyH, HeavyT, HeavyX As Double '重气团直径、高度、最大扩散时间、最大扩散距离、是否按重气团模型计算
            Dim Is_Heavy As Boolean = False   '是否按重气体模型
            Dim ModolType As Integer = -1
            If Me.m_Sources(Sn).MultiPLeak.HeavyType = 0 Then '点源为瞬时重气体模型
                '重气体模型--------------------------------------------------------
                If Me.m_IntialSource.IsHeavy = True Then
                    If Me.m_Heavy(Sn).BoxHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        HeavyT = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t
                        HeavyX = HeavyT * Me.m_ForeCast.Met(Sn).u2
                        Dim dt As Double = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(1).m_t - Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_t '计算云团时间间隔
                        If dblForecastTime <= HeavyT Then '如果预测时间小于重气体最大扩散时间
                            Dim nIndex As Integer = dblForecastTime / dt
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_H '云团高度
                        Else
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_H '云团高度
                        End If
                        Is_Heavy = True
                    End If
                    ModolType = 0
                End If
            ElseIf Me.m_Sources(Sn).MultiPLeak.HeavyType = 1 Then '点源为连续重气体模型
                '重气体模型--------------------------------------------------------
                If Me.m_IntialSource.IsHeavy = True Then
                    If Me.m_Heavy(Sn).SlabHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        HeavyX = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_x
                        HeavyT = HeavyX / Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.u10
                        Dim dx As Double = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(1).m_x - Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(0).m_x '计算云团下风向距离间隔

                        If dblx > 0 And dblx <= HeavyX Then '如果预测距离小于重气体最大扩散距离
                            Dim nIndex As Integer = dblx / dx
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_H '云羽高度
                        ElseIf dblx > 0 Then
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_H '云羽高度
                        End If
                        Is_Heavy = True
                    End If
                    ModolType = 1
                End If
            End If
            '计算浓度
            If Me.Forecast.OutPut.GaussModelType = 0 Then '多烟团模型
                result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).MultiPLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiPLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
            Else '非正常模型
                result = result + UnormalModelPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).PLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.m_Sources(Sn).PLeak.DurationTime, dblForecastTime, Me.m_Sources(Sn).PLeak.Q, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, 0, 0, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
            End If
        End If
        '面源泄漏
        If Me.m_Sources(Sn).MultiSLeak.Q > 0 Then
            Dim HeavyB, HeavyH, HeavyT, HeavyX As Double '重气团直径、高度、最大扩散时间、最大扩散距离、是否按重气团模型计算
            Dim Is_Heavy As Boolean = False   '是否按重气体模型
            Dim ModolType As Integer = -1
            If Me.m_Sources(Sn).MultiSLeak.HeavyType = 0 Then '点源为瞬时重气体模型
                '重气体模型--------------------------------------------------------
                If Me.m_IntialSource.IsHeavy = True Then
                    If Me.m_Heavy(Sn).BoxHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        HeavyT = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t
                        HeavyX = HeavyT * Me.m_ForeCast.Met(Sn).u2
                        Dim dt As Double = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(1).m_t - Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_t '计算云团时间间隔
                        If dblForecastTime <= HeavyT Then '如果预测时间小于重气体最大扩散时间
                            Dim nIndex As Integer = dblForecastTime / dt
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_H '云团高度
                        Else
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_H '云团高度
                        End If
                        Is_Heavy = True
                    End If
                    ModolType = 0
                End If
            ElseIf Me.m_Sources(Sn).MultiSLeak.HeavyType = 1 Then '点源为连续重气体模型
                '重气体模型--------------------------------------------------------
                If Me.m_IntialSource.IsHeavy = True Then
                    If Me.m_Heavy(Sn).SlabHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        HeavyX = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_x
                        HeavyT = HeavyX / Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.u10
                        Dim dx As Double = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(1).m_x - Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(0).m_x '计算云团下风向距离间隔

                        If dblx > 0 And dblx <= HeavyX Then '如果预测距离小于重气体最大扩散距离
                            Dim nIndex As Integer = dblx / dx
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_H '云羽高度
                        ElseIf dblx > 0 Then
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_H '云羽高度
                        End If
                        Is_Heavy = True
                    End If
                    ModolType = 1
                End If
            End If
            '计算面源浓度
            If Me.Forecast.OutPut.GaussModelType = 0 Then '多烟团模型
                Select Case m_IntialSource.LeakType
                    Case 0 '手动计算 ，重气体模型的瞬时手动计算
                        '计算排放高度处的风速
                        result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).MultiSLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiSLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
                    Case Else  '液体泄漏,两相流泄漏,液体容器破裂泄漏
                        result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).U_Ground, Me.m_Sources(Sn).MultiSLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiSLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
                End Select
            Else '非正常模型
                Select Case m_IntialSource.LeakType
                    Case 0 '手动计算 ，重气体模型的瞬时手动计算
                        result = result + UnormalModelPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).SLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.m_Sources(Sn).SLeak.DurationTime, dblForecastTime, Me.m_Sources(Sn).SLeak.Q, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, Me.m_Sources(Sn).SLeak.S, 0, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
                    Case Else '液体泄漏,两相流泄漏,液体容器破裂泄漏
                        result = result + UnormalModelPSV(u10, Me.m_ForeCast.Met(Sn).U_Ground, Me.m_Sources(Sn).SLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.m_Sources(Sn).SLeak.DurationTime, dblForecastTime, Me.m_Sources(Sn).SLeak.Q, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, Me.m_Sources(Sn).SLeak.S, 0, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
                End Select
            End If
        End If

        '体源泄漏
        If Me.m_Sources(Sn).MultiVLeak.Q > 0 Then
            Dim HeavyB, HeavyH, HeavyT, HeavyX As Double '重气团直径、高度、最大扩散时间、最大扩散距离、是否按重气团模型计算
            Dim Is_Heavy As Boolean = False   '是否按重气体模型
            Dim ModolType As Integer = -1
            If Me.m_Sources(Sn).MultiVLeak.HeavyType = 0 Then '点源为瞬时重气体模型
                '重气体模型--------------------------------------------------------
                If Me.m_IntialSource.IsHeavy = True Then
                    If Me.m_Heavy(Sn).BoxHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        HeavyT = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t
                        HeavyX = HeavyT * Me.m_ForeCast.Met(Sn).u2
                        Dim dt As Double = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(1).m_t - Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_t '计算云团时间间隔
                        If dblForecastTime <= HeavyT Then '如果预测时间小于重气体最大扩散时间
                            Dim nIndex As Integer = dblForecastTime / dt
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_H '云团高度
                        Else
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_H '云团高度
                        End If
                        Is_Heavy = True
                    End If
                    ModolType = 0
                End If
            ElseIf Me.m_Sources(Sn).MultiVLeak.HeavyType = 1 Then '点源为连续重气体模型
                '重气体模型--------------------------------------------------------
                If Me.m_IntialSource.IsHeavy = True Then
                    If Me.m_Heavy(Sn).SlabHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        HeavyX = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_x
                        HeavyT = HeavyX / Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.u10
                        Dim dx As Double = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(1).m_x - Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(0).m_x '计算云团下风向距离间隔

                        If dblx > 0 And dblx <= HeavyX Then '如果预测距离小于重气体最大扩散距离
                            Dim nIndex As Integer = dblx / dx
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_H '云羽高度
                        ElseIf dblx > 0 Then
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_H '云羽高度
                        End If
                        Is_Heavy = True
                    End If
                    ModolType = 1
                End If
            End If
            '计算体源浓度
            If Me.Forecast.OutPut.GaussModelType = 0 Then '多烟团模型
                result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).MultiVLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiVLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)

            Else '非正常模型
                result = result + UnormalModelPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).VLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.m_Sources(Sn).VLeak.DurationTime, dblForecastTime, Me.m_Sources(Sn).VLeak.Q, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, Me.m_Sources(Sn).VLeak.S, Me.m_Sources(Sn).VLeak.Hv, HeavyB, HeavyH, HeavyT, HeavyX, Me.m_IntialSource.IsHeavy, ModolType)

            End If
        End If
        Return result
    End Function

    'Private Function CarePointStartTime(ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double) As Double
    '    If u10 < 0.1 Then
    '        Return 0
    '    Else
    '        Dim startTime As Double '最大值可能出现的开始时间
    '        Dim uL, uS As Double '泄漏口和液池处的风速
    '        If TabControl1.TabPages.Contains(TabPage1) Then   '第一页－－－－－－－－－－－－－－－－
    '            If cmbModel.SelectedIndex = 0 Then '多烟团模型
    '                If cbmSourceType.SelectedIndex = 0 Then '用多烟团点源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(MultiPLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 1 Then '用多烟团排放面源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(MultiSLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 2 Then '用多烟团体源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(MultiVLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                End If

    '            ElseIf cmbModel.SelectedIndex = 1 Then '用非正常排放模型预测
    '                If cbmSourceType.SelectedIndex = 0 Then '用多烟团点源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(PLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 1 Then '用多烟团排放面源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(Me.m_Sources(sn).SLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 2 Then '用多烟团体源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(Me.m_Sources(sn).VLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                End If
    '                startTime = dblx / uL '开始时间为该风速下第一个烟团到达关心点的时间
    '            End If
    '        Else '第二页－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
    '            If cmbModel.SelectedIndex = 0 Then '多烟团模型
    '                '计算排放高度处的风速
    '                uL = UP(u10, CDbl(MultiPLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                '计算液池高度处的风速
    '                uS = UP(u10, CDbl(MultiSLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                If uL >= uS Then
    '                    startTime = dblx / uL
    '                Else
    '                    startTime = dblx / uS
    '                End If
    '            ElseIf cmbModel.SelectedIndex = 1 Then '非正常模型
    '                '计算排放高度处的风速
    '                uL = UP(u10, CDbl(PLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                '计算液池高度处的风速
    '                uS = UP(u10, CDbl(Me.m_Sources(sn).SLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                If uL >= uS Then
    '                    startTime = dblx / uL
    '                Else
    '                    startTime = dblx / uS
    '                End If
    '            End If
    '        End If
    '        Return startTime
    '    End If
    'End Function
    'Private Function CarePointEndTime(ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double) As Double
    '    If u10 < 0.1 Then
    '        Return MaxTime '最大值取60小时
    '    Else
    '        Dim endTime As Double '最大值可能出现的开始时间
    '        Dim uL, uS As Double '泄漏口和液池处的风速
    '        If TabControl1.TabPages.Contains(TabPage1) Then   '第一页－－－－－－－－－－－－－－－－
    '            If cmbModel.SelectedIndex = 0 Then '多烟团模型
    '                If cbmSourceType.SelectedIndex = 0 Then '用多烟团点源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(MultiPLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 1 Then '用多烟团排放面源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(MultiSLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 2 Then '用多烟团体源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(MultiVLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                End If
    '            ElseIf cmbModel.SelectedIndex = 1 Then
    '                If cbmSourceType.SelectedIndex = 0 Then '用多烟团点源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(PLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 1 Then '用多烟团排放面源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(Me.m_Sources(sn).SLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                ElseIf cbmSourceType.SelectedIndex = 2 Then '用多烟团体源模式计算
    '                    '计算排放高度处的风速
    '                    uL = UP(u10, CDbl(Me.m_Sources(sn).VLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                End If
    '            End If
    '            endTime = dblx / uL + CDbl(txtDurationT0.Text) * 60 '开始时间为该风速下第一个烟团到达关心点的时间
    '        Else '第二页－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
    '            Dim endTimeL, endTimeS As Double
    '            If cmbModel.SelectedIndex = 0 Then '用多烟团模型计算
    '                '计算排放高度处的风速
    '                uL = UP(u10, CDbl(MultiPLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                endTimeL = dblx / uL + MultiPLeak.DurationTime
    '                '计算排放高度处的风速
    '                If MultiSLeak.He > 0 Then
    '                    uS = UP(u10, CDbl(MultiSLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                    endTimeS = dblx / uS + MultiSLeak.DurationTime
    '                End If
    '            Else  '用非正常模型计算
    '                '计算排放高度处的风速
    '                uL = UP(u10, CDbl(PLeak.H), Me.m_ForeCast.output.GroundCharacter, stab)
    '                endTimeL = dblx / uL +Me.m_Sources(sn).pleak.DurationTime
    '                If Me.m_Sources(sn).SLeak.Q > 0 Then
    '                    '计算排放高度处的风速
    '                    uS = UP(u10, CDbl(Me.m_Sources(sn).SLeak.He), Me.m_ForeCast.output.GroundCharacter, stab)
    '                    endTimeS = dblx / uS + Me.m_Sources(sn).SLeak.DurationTime
    '                End If
    '            End If
    '            If endTimeL >= endTimeS Then
    '                endTime = endTimeL
    '            Else
    '                endTime = endTimeS
    '            End If
    '        End If
    '        Return endTime
    '    End If
    'End Function

    ''' <summary>
    ''' 这一模块返回两个时间之间给定浓度值的时刻
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="dblx">预测点的x轴坐标,m</param>
    ''' <param name="dbly">预测点的y轴坐标,m</param>
    ''' <param name="dblz">预测点的z轴坐标,m</param>
    ''' <param name="LowT">浓度值较低的时刻,s</param>
    ''' <param name="HeighT">浓度值较高的时刻,s</param>
    ''' <param name="SpecifyC">给定的浓度值,mg/m^3</param>
    ''' <returns>返回给定的浓度值出现的时间,s</returns>
    ''' <remarks></remarks>
    Private Function CarePointCandT(ByVal Sn As Integer, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, ByVal LowT As Double, ByVal HeighT As Double, ByVal SpecifyC As Double) As Double
        
        Dim TCenter, F1, F2, FCenter As Double
        '根据上面求出的数组，从后向前找出浓度值的范围。再用二分法求出给定的值
        F1 = ResultC(Sn, LowT, dblx, dbly, dblz)


        F2 = ResultC(Sn, HeighT, dblx, dbly, dblz)
        '采用二分法求给定值
        Do
            TCenter = (LowT + HeighT) / 2

            FCenter = ResultC(Sn, TCenter, dblx, dbly, dblz) '计算出中间值的浓度
            If FCenter <= SpecifyC Then '如果中间值>=指定值
                LowT = TCenter
                F1 = FCenter
            Else
                HeighT = TCenter
                F2 = FCenter
            End If
        Loop While Math.Abs(LowT - HeighT) > 0.1
        Return TCenter
    End Function
    ''' <summary>
    ''' 采用黄金分割法求给定关心点在某一时间内的最大值的浓度及时间
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="LowT">较小的时刻</param>
    ''' <param name="HighT">较大的时刻</param>
    ''' <param name="dblx">x坐标</param>
    ''' <param name="dbly">y坐标</param>
    ''' <param name="dblz">z坐标</param>
    ''' <param name="IntelTime">时间精度控制</param>
    ''' <returns>返回MaxCD结构</returns>
    ''' <remarks></remarks>
    Private Function CarePointGroldCutCT(ByVal Sn As Integer, ByVal LowT As Double, ByVal HighT As Double, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, Optional ByVal IntelTime As Double = 0.1) As MaxCD
        '采用黄金分割法求出给定时间段的最大值------------------
        Dim T1 As Double
        Dim T2 As Double
        T1 = LowT + 0.618 * (HighT - LowT)
        T2 = HighT - 0.618 * (HighT - LowT)
        Dim F1 As Double
        Dim F2 As Double
        Dim Fmax As Double
        Dim Tmax As Double
        Dim i As Integer = 1
        While (HighT - LowT) > IntelTime

            F1 = ResultC(Sn, T1, dblx, dbly, dblz) '计算浓度
            F2 = ResultC(Sn, T2, dblx, dbly, dblz) '计算浓度
            If F1 < F2 Or F1 <= 0 Then
                HighT = T1
                T1 = T2
                T2 = HighT - 0.618 * (HighT - LowT)
            Else
                LowT = T2
                T2 = T1
                T1 = LowT + 0.618 * (HighT - LowT)
            End If
            i += 1
        End While
        Tmax = (T1 + T2) / 2
        If F2 > F1 Then
            Fmax = F2
        Else
            Fmax = F1
        End If
        '黄金分割法结束------------------------------------------ 
        Dim M As New MaxCD
        M.MaxC = Fmax
        M.maxT = Tmax
        Return M
    End Function

    ''' <summary>
    ''' 用于求任意给定点的最大滑移平均对象
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="LowT">较小的时刻</param>
    ''' <param name="HeighT">较大的时刻</param>
    ''' <param name="dblx">x坐标</param>
    ''' <param name="dbly">y坐标</param>
    ''' <param name="dblz">z坐标</param>
    ''' <returns>返回MaxCD结构</returns>
    ''' <remarks></remarks>
    Public Function ReceptorMaxSlipAverage(ByVal Sn As Integer, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, ByVal LowT As Double, ByVal HeighT As Double) As Slippage
        If LowT < 0 Then
            HeighT = HeighT + Math.Abs(LowT)
            LowT = 0
        End If
        '每指定间隔秒向前或向后求一个时间平均与最大值进行比较。
        Dim ItialMax As Double = ReceptorIntegralAverage(Sn, dblx, dbly, dblz, LowT, HeighT)
        Dim Intp As Integer = 10
        Dim Lt As Double
        Dim Ht As Double
        Dim MaxTime As New StartAndEndTime
        MaxTime.StartTime = LowT
        MaxTime.EndTime = HeighT
        Lt = LowT + Intp
        Ht = HeighT + Intp
        Dim slipmax_1 As Double = ReceptorIntegralAverage(Sn, dblx, dbly, dblz, Lt, Ht)

        While slipmax_1 > ItialMax
            ItialMax = slipmax_1
            Lt = Lt
            Ht = Ht
            slipmax_1 = ReceptorIntegralAverage(Sn, dblx, dbly, dblz, Lt, Ht)
            MaxTime.StartTime = Lt
            MaxTime.EndTime = HeighT
        End While
        If LowT - Intp > 0 Then
            Lt = LowT - Intp
            Ht = HeighT - Intp
            slipmax_1 = ReceptorIntegralAverage(Sn, dblx, dbly, dblz, Lt, Ht)
            While slipmax_1 > ItialMax And Lt > 0
                ItialMax = slipmax_1
                Lt = Lt
                Ht = Ht
                slipmax_1 = ReceptorIntegralAverage(Sn, dblx, dbly, dblz, Lt, Ht)
                MaxTime.StartTime = Lt
                MaxTime.EndTime = HeighT
            End While
        End If
        Dim sss As New Slippage
        sss.MaxCon = ItialMax / (MaxTime.EndTime - MaxTime.StartTime)
        sss.StartAndEndTimeTime = New StartAndEndTime
        sss.StartAndEndTimeTime = MaxTime
        Return sss

    End Function

    ''' <summary>
    ''' 用变步长辛普生公式计算时间段内的浓度积分
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="LowT">较小的时刻</param>
    ''' <param name="HeighT">较大的时刻</param>
    ''' <param name="dblx">x坐标</param>
    ''' <param name="dbly">y坐标</param>
    ''' <param name="dblz">z坐标</param>
    ''' <returns>返回MaxCD结构</returns>
    ''' <remarks></remarks>
    Public Function ReceptorIntegralAverage(ByVal Sn As Integer, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, ByVal LowT As Double, ByVal HeighT As Double) As Double


        Dim N As Long
        Dim K As Long
        Dim t2, t1, ep, s1, H, s2 As Double
        Dim p As Double
        Dim x As Double
        Dim a, b As Double
        a = LowT
        b = HeighT

        Dim eps As Double
        eps = 0.0000000001
        N = 1
        H = HeighT - a


        Dim F1 As Double
        
        F1 = ResultC(Sn, a, dblx, dbly, dblz)

        Dim F2 As Double

        F2 = ResultC(Sn, HeighT, dblx, dbly, dblz)

        t1 = H * (F1 + F2) / 2.0#
        s1 = t1
        ep = eps + 1.0#
        While (ep >= s1 / 100 + 0.1 Or N < 100)
            p = 0.0#
            For K = 0 To N - 1
                x = a + (K + 0.5) * H
                p = p + ResultC(Sn, x, dblx, dbly, dblz)
            Next K
            t2 = (t1 + H * p) / 2.0#
            s2 = (4.0# * t2 - t1) / 3
            ep = System.Math.Abs(s2 - s1)
            t1 = t2
            s1 = s2
            N = N + N
            H = H / 2.0#
        End While
        Return s2
    End Function

    ''' <summary>
    ''' 用变步长辛普生公式计算时间段内的毒性负荷
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="LowT">较小的时刻</param>
    ''' <param name="HeighT">较大的时刻</param>
    ''' <param name="dblx">x坐标</param>
    ''' <param name="dbly">y坐标</param>
    ''' <param name="dblz">z坐标</param>
    ''' <returns>返回MaxCD结构</returns>
    ''' <remarks></remarks>
    Public Function ToxinCharge(ByVal Sn As Integer, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, ByVal LowT As Double, ByVal HeighT As Double) As Double

        Dim N As Long
        Dim K As Long
        Dim t2, t1, ep, s1, H, s2 As Double
        Dim p As Double
        Dim xt As Double
        Dim a, b As Double
        a = LowT
        b = HeighT

        Dim eps As Double
        eps = 0.0000000001
        N = 1
        H = HeighT - a


        Dim F1 As Double
        F1 = (ResultC(Sn, a, dblx, dbly, dblz) / m_Chemical.Pg) ^ m_Chemical.Prn  '注意浓度单位为ppm，时间单位为min


        Dim F2 As Double
        F2 = (ResultC(Sn, HeighT, dblx, dbly, dblz) / m_Chemical.Pg) ^ m_Chemical.Prn  '注意浓度单位为ppm，时间单位为min

        t1 = H * (F1 + F2) / 2.0#
        s1 = t1
        ep = eps + 1.0#

        Dim i As Integer = 0
        While (ep >= 0.1 And N < 64)
            p = 0.0#
            For K = 0 To N - 1
                xt = a + (K + 0.5) * H
                p = p + (ResultC(Sn, xt, dblx, dbly, dblz) / m_Chemical.Pg) ^ m_Chemical.Prn
                i = i + 1
            Next K
            t2 = (t1 + H * p) / 2.0#
            s2 = (4.0# * t2 - t1) / 3
            ep = System.Math.Abs(s2 - s1)
            t1 = t2
            s1 = s2
            N = N + N
            H = H / 2.0#

        End While
        Return s2 / 60 '转成min
    End Function

#End Region
    Public Function Clone() As Dis
        Try
            ' Create a filestream object
            Dim fileStr As Stream = File.Open(DisPuff.path.ModelsPath & "dis.sav", FileMode.Create)
            ' Create a linked list object and populate it with random nodes
            Dim sdis As New Dis
            sdis = Me
            ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter
            formatter = CType(New BinaryFormatter, IFormatter)
            ' Serialize the object graph to stream
            formatter.Serialize(fileStr, sdis)
            ' All done
            fileStr.Close()
        Catch ex As Exception
            MsgBox("写dis文件错误!")
            Return Nothing
        End Try


        Try
            Dim fileStr As Stream = File.Open(DisPuff.path.ModelsPath & "dis.sav", FileMode.Open)

            ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter

            formatter = CType(New BinaryFormatter, IFormatter)
            ' Deserialize the object graph from stream
            Dim sdis As New Dis
            sdis = CType(formatter.Deserialize(fileStr), Dis)
            fileStr.Close()
            Return sdis
        Catch ex As Exception
            MsgBox("读dis文件错误!")
            Return Nothing
        End Try

    End Function
End Class
