﻿Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
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
    ''' <summary>
    ''' 污染源数组。临时变量。这个变量用于储存事故源转换成点、面源后不同的气象数据下的事故源。因为不同的气象条件，事故排放源强会不一样。
    ''' </summary>
    ''' <remarks></remarks>
    <NonSerialized()> Private m_Sources(-1) As Source '
    Private vane As String '声明风向，因为在网格点计算中用到风向
    Private GridSign As Boolean '网格数据是否由单击事件引起的
    Private LeakQ(0, 0, 0) As Double '定义3维数组，用于储存不同气象条件下的泄漏情况

    Private arrayDamageRange(-1, -1) As Double '伤害范围
    Private ReCalculate As Boolean = True '重新计算标志


#End Region

#Region "属性变量"
    ''' <summary>
    ''' 所有的事故泄漏源
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ListLeakSource As New ListLeakSource
    ''' <summary>
    ''' 物化数据类
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Chemical As New Chemical


    ''' <summary>
    ''' 重气体对象数组对象。这应为临时对象
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
    ''' 所有的事故泄漏源
    ''' </summary>
    ''' <remarks></remarks>
    Property ListLeakSource As ListLeakSource
        Get
            Return Me.m_ListLeakSource
        End Get
        Set(ByVal value As ListLeakSource)
            Me.m_ListLeakSource = value
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
    Public Function Intial_CalRisk(ByVal workpath As String) As Boolean
        '初始化泄漏源列表的状态参数
        For iSource As Integer = 0 To Me.m_ListLeakSource.IntialSource.Count - 1
            If Me.m_ListLeakSource.IntialSource(iSource).IntialPara(Me.m_Chemical, Me.m_ForeCast.Ta, Me.m_ForeCast.Pa) = False Then
                Return False
            End If
        Next
        For iSource As Integer = 0 To Me.m_ListLeakSource.IntialSource.Count - 1
            '污染源数组。不同的气象条件同一泄漏源有可能污染源强不一样
            ReDim Me.m_Sources(Me.m_ForeCast.Met.Length - 1)
            '重气体数组。不同的气象条件同一泄漏源有可能污染源强不一样
            ReDim Me.m_Heavy(Me.m_ForeCast.Met.Length - 1)
            '计算结果初始化对象，建立新的实例
            ReDim Me.m_Results.MetResults(Me.m_ForeCast.Met.Length - 1)
            '------------------------------------------------------------------------------------
            '初始化计算结果的对象
            '------------------------------------------------------------------------------------
            '各点高值
            ReDim Me.m_Results.Rectable.GridRectbleConAndTime(0, Me.Forecast.Grid.CountY, Me.Forecast.Grid.CountX)
            ReDim Me.m_Results.Rectable.CareRectbleConAndTime(0, Me.Forecast.CareReceptor.Length - 1)

            Dim MaxTen As Integer = ModelSetting.MaxTable
            If Me.m_ForeCast.Met.Length < ModelSetting.MaxTable Then
                MaxTen = Me.m_ForeCast.Met.Length
            End If
            '初始化设置网格点对象中的瞬时网格点数组。风险值最大的前n个浓度分布
            ReDim Me.m_Results.AllGridResult.InstantaneousGridC(MaxTen - 1, Me.m_ForeCast.OutPut.ForeCount - 1, Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)

            '初始化设置网格点滑移平均最大浓度。风险值最大的前n个浓度分布
            ReDim Me.m_Results.AllGridResult.SlipGrid(MaxTen - 1, Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                '网格点滑移平均最大浓度网格初始化。风险值最大的前10浓度分布
                For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1
                    For k As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1
                        Me.m_Results.AllGridResult.SlipGrid(SN, j, k) = New Slippage
                        Me.m_Results.AllGridResult.SlipGrid(SN, j, k).StartAndEndTimeTime = New StartAndEndTime
                    Next
                Next
            Next

            '初始化设置网格点死亡概率和死亡百分率
            ReDim Me.m_Results.AllGridResult.Pr(MaxTen - 1)
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                ReDim Me.m_Results.AllGridResult.Pr(SN)(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
            Next
            ReDim Me.m_Results.AllGridResult.D(MaxTen - 1)
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                ReDim Me.m_Results.AllGridResult.D(SN)(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
            Next
            ReDim Me.m_Results.AllGridResult.DiePeople(MaxTen - 1)
            ReDim Me.m_Results.AllGridResult.PersonalRisk(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1)
            ReDim Me.m_Results.AllGridResult.ArrayRisk(MaxTen - 1)
            Me.m_Results.AllGridResult.AllRisk = 0
            '初始化设置关心点对象中的瞬时浓度。风险值最大的前10浓度分布
            ReDim Me.m_Results.AllCareResult.InstantaneousCareC(MaxTen - 1, Me.m_ForeCast.OutPut.ForeCount - 1, Me.m_ForeCast.CareReceptor.Length - 1) '某关心点的多个时刻的浓度

            '初始化设置关心点对象中的滑移平均最大浓度。风险值最大的前10浓度分布

            ReDim Me.m_Results.AllCareResult.SlipCare(MaxTen - 1, Me.m_ForeCast.CareReceptor.Length - 1)
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                For j As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
                    Me.m_Results.AllCareResult.SlipCare(SN, j) = New Slippage
                    Me.m_Results.AllCareResult.SlipCare(SN, j).StartAndEndTimeTime = New StartAndEndTime
                Next
            Next
            '初始化设置关心点对象中的最大浓度及出现的时间该:气象条件、关心点
            ReDim Me.m_Results.AllCareResult.CarePointMaxCT(MaxTen - 1, Me.m_ForeCast.CareReceptor.Length - 1)
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                For j As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
                    Me.m_Results.AllCareResult.CarePointMaxCT(SN, j) = New MaxCD
                Next
            Next
            '初始化设置关心点对象中关心点出现某伤害一浓度的浓度限值的开始和结束时间:气象条件，关心点，给定浓度值
            ReDim Me.m_Results.AllCareResult.CarePointTime(MaxTen - 1, Me.m_ForeCast.CareReceptor.Length - 1, Me.m_ForeCast.HurtConcentration.Length - 1)
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                For i As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
                    For j As Integer = 0 To Me.m_ForeCast.HurtConcentration.Length - 1
                        Me.m_Results.AllCareResult.CarePointTime(SN, i, j) = New StartAndEndTime
                    Next
                Next
            Next

            '初始化设置关心点对象中死亡概率：气象条件，关心点
            ReDim Me.m_Results.AllCareResult.Pr(MaxTen - 1, Me.m_ForeCast.CareReceptor.Length - 1)

            '初始化设置关心点对象中死亡百分率 %：气象条件，关心点
            ReDim Me.m_Results.AllCareResult.D(MaxTen - 1, Me.m_ForeCast.CareReceptor.Length - 1)
            '-----------------------------------------------------------------------------------
            '初始化计算结果的对象结束
            '-----------------------------------------------------------------------------------
            For SN As Integer = 0 To MaxTen - 1 '气象条件
                Me.m_Results.MetResults(SN) = New MetResult
                ReDim Me.m_Results.MetResults(SN).ForeTimeResults(Me.m_ForeCast.OutPut.ForeCount - 1)

                For i As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
                    Me.m_Results.MetResults(SN).ForeTimeResults(i) = New ForeTimeResult '轴线最大浓度及距离
                    ReDim Me.m_Results.MetResults(SN).ForeTimeResults(i).HurtLength(Me.m_ForeCast.HurtConcentration.Length - 1) '某一浓度伤害范围
                    ReDim Me.m_Results.MetResults(SN).ForeTimeResults(i).GridVane(0 To Me.m_ForeCast.Vane.VaneCount) '预测的时间个数和预测的下风向个数,从0开始，所以增加一个
                    ReDim Me.m_Results.MetResults(SN).ForeTimeResults(i).GridUpVane(0 To Me.m_ForeCast.Vane.VaneCount) '预测的时间个数和预测的上风向个数,从0开始，所以增加一个
                Next
                '网格点滑移平均最大浓度网格初始化

                ReDim Me.m_Results.MetResults(SN).Slip.HurtLengthSlip(Me.m_ForeCast.HurtConcentration.Length - 1) '某一浓度伤害范围
                ReDim Me.m_Results.MetResults(SN).Slip.GridVane(0 To Me.m_ForeCast.Vane.VaneCount) '预测的时间个数和预测的下风向个数,从0开始，所以增加一个

                For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1
                    For k As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1
                        Me.m_Results.AllGridResult.SlipGrid(SN, j, k) = New Slippage
                    Next
                Next
            Next
            '设置总的计算量
            'If Me.m_ForeCast.IsCalGrid = True Then
            '    Me.m_Results.AllCalMount = (Me.m_ForeCast.OutPut.ForeCount * 3 + Me.m_ForeCast.OutPut.ForeCount * Me.m_ForeCast.CareReceptor.Length) * MaxTen
            'Else
            '    Me.m_Results.AllCalMount = (Me.m_ForeCast.OutPut.ForeCount * 2 + Me.m_ForeCast.OutPut.ForeCount * Me.m_ForeCast.CareReceptor.Length) * MaxTen
            'End If
            Me.m_Results.AllCalMount = Me.m_ForeCast.Met.Length

            '初始化最不利的气象条件
            ReDim Me.m_ForeCast.MaxMet(MaxTen - 1)
            For i As Integer = 0 To MaxTen - 1
                Me.m_ForeCast.MaxMet(i) = New Met
            Next
            '初始化进度
            Me.m_Results.AllProgress = 0
            For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '气象条件
                InitiaMetList(SN, Me.m_ListLeakSource.IntialSource(iSource))   '计算概述
            Next SN
            For SN As Integer = 0 To Me.m_ForeCast.Met.Length - 1 '逐气象条件计算风险
                '泄漏量计算
                Dim u10 As Double = Me.m_ForeCast.Met(SN).WindSpeed  '第0行第2列，风速
                Dim stab As String = Me.m_ForeCast.Met(SN).Stab  '第0行第3列，风速稳定度
                CalLeakSource(SN, u10, stab, Me.m_ListLeakSource.IntialSource(iSource)) '计算泄漏量，因为不同的气象泄漏量可能不一样。

                CalculateRisk(SN, workpath, Me.m_ListLeakSource.IntialSource(iSource)) '逐步计算浓度、风险等

                '设置计算进度
                Me.m_Results.AllProgress += 1
            Next SN
        Next
        Return (True)
    End Function

    ''' <summary>
    ''' 计算结果返回某一气象条件下的多个预测时刻的计算结果。(计算时刻，计算结果)
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Cal(ByVal SN) As Double(,)
        'InitiaMetList(SN)   '计算概述
        '泄漏量计算
        Dim u10 As Double = Me.m_ForeCast.Met(SN).WindSpeed  '第0行第2列，风速
        Dim stab As String = Me.m_ForeCast.Met(SN).Stab  '第0行第3列，风速稳定度
        'CalLeakSource(SN, u10, stab) '计算泄漏量，因为不同的气象泄漏量可能不一样。

        Dim ArrayPoint(-1) As Point3D
        Dim n As Integer = 0
        If Me.Forecast.IsCalGrid = True Then
            ReDim Preserve ArrayPoint(Me.Forecast.Grid.CountX * Me.Forecast.Grid.CountY - 1)
            For j As Integer = 0 To Me.Forecast.Grid.CountY - 1
                For i As Integer = 0 To Me.Forecast.Grid.CountX - 1
                    ArrayPoint(n) = New Point3D
                    ArrayPoint(n).x = Me.Forecast.Grid.MinX + Me.Forecast.Grid.StepX * i
                    ArrayPoint(n).y = Me.Forecast.Grid.MinY + Me.Forecast.Grid.StepY * j
                    ArrayPoint(n).z = Me.Forecast.Grid.WGH
                    n += 1
                Next
            Next
        End If
        If Me.Forecast.IsCalCare = True Then
            ReDim Preserve ArrayPoint(ArrayPoint.Length + Me.Forecast.CareReceptor.Length - 1)
            For i As Integer = 0 To Me.Forecast.CareReceptor.Length - 1
                ArrayPoint(n) = Me.Forecast.CareReceptor(i).Point3D
                n += 1
            Next
        End If

        Dim MaxArrayResult(ArrayPoint.Length - 1) As RectableConAndTime  '储存当前气象条件的最大值
        Dim AllArrayResult(Me.m_ForeCast.OutPut.ForeCount - 1, ArrayPoint.Length - 1) As Double '当前气象条件下所有时刻的值。方便后面进行毒性负荷和滑移平均
        'Me.CalculateInstance(SN, ArrayPoint, MaxArrayResult, AllArrayResult) '计算当前气象条件下的浓度
        Return AllArrayResult
    End Function


    ''' <summary>
    ''' 参数化气象数据。计算出10米风速、稳定度、泄漏口处风速、液池高度处的风速
    ''' </summary>
    ''' <param name="Sn">气象条件的序号</param>
    ''' <remarks></remarks>
    Public Sub InitiaMetList(ByVal Sn As Integer, ByVal InSource As IntialSource)

        '清空表格

        '按预测的序号进行计算
        'vane = Me.m_ForeCast.Met(Sn).Vane  '第0行第1列,风向
        Dim u10 As Double = Me.m_ForeCast.Met(Sn).WindSpeed  '第0行第2列，风速
        Dim stab As String = Me.m_ForeCast.Met(Sn).Stab  '第0行第3列，风速稳定度

        Me.m_ForeCast.Met(Sn).u2 = UP(u10, InSource.H, Me.m_ForeCast.OutPut.GroundCharacter, stab)
        '计算地面液池高度处的风速
        Me.m_ForeCast.Met(Sn).U_Ground = UP(u10, InSource.SHe, Me.m_ForeCast.OutPut.GroundCharacter, stab)

    End Sub

    ''' <summary>
    ''' 初始化泄漏源强和重气体的初始参数
    ''' </summary>
    ''' <param name="sn">气象数组序号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalLeakSource(ByVal sn As Integer, ByVal u10 As Double, ByVal stab As String, ByVal InSource As IntialSource) As Boolean
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

        Select Case InSource.LeakType
            Case 0 '手动计算
                Select Case InSource.SourceType
                    Case 0 '点源
                        '多烟团泄漏源
                        With MultiPLeak
                            .Name = Me.m_Chemical.Name0  '泄漏物质名称
                            .Q = InSource.Q0 * 1000000 '泄漏物质的速率mg/s
                            .Ts = InSource.Ts0 + 273.15  '设置温度，摄氏度
                            .DurationTime = InSource.DurationT * 60   '排放持续时间转化为S
                            .Qv = InSource.Qv_P  '排气量　m3/s
                            .H = InSource.H '排放高度
                            .D = InSource.D_P '直径
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
                                    .Qi(i) = ((InSource.DurationT * 60) - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                                End If
                            Next i
                        End With
                        '非正常泄漏源
                        Me.m_Sources(sn).PLeak = New PointLeak '实例化点源对象
                        Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                        Me.m_Sources(sn).PLeak.Q = InSource.Q0 * 1000000 '泄漏物质的速率mg/s
                        Me.m_Sources(sn).PLeak.Ts = InSource.Ts0 + 273.15 '设置温度，摄氏度
                        Me.m_Sources(sn).PLeak.DurationTime = InSource.DurationT * 60  '排放持续时间转化为S
                        Me.m_Sources(sn).PLeak.Qv = InSource.Qv_P '排气量　m3/s
                        Me.m_Sources(sn).PLeak.H = InSource.H '排放高度
                        Me.m_Sources(sn).PLeak.D = InSource.D_P '直径
                        '计算烟气抬升高度和有效高度
                        Me.m_Sources(sn).PLeak.DH = RiseH(Pa_BP, Me.m_Sources(sn).PLeak.Qv, Me.m_Sources(sn).PLeak.D, Me.m_Sources(sn).PLeak.H, Me.m_Sources(sn).PLeak.Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, 90)
                        Me.m_Sources(sn).PLeak.He = Me.m_Sources(sn).PLeak.DH + Me.m_Sources(sn).PLeak.H
                    Case 1 '面源
                        '多烟团
                        With MultiSLeak
                            .Name = Me.m_Chemical.Name0    '泄漏物质名称
                            .Q = InSource.Q0 * 1000000 '泄漏物质的速率mg/s
                            .Ts = InSource.Ts0 + 273.15  '设置温度，摄氏度
                            .DurationTime = InSource.DurationT * 60  '排放持续时间转化为S
                            .He = InSource.H  '有效排放高度
                            If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                            Else
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                            End If
                            .ResetMulti(.n) '设置烟团个数为n个
                            For i = 1 To .n Step 1
                                .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                                .Si(i) = InSource.S_S
                                .Thickness(i) = 0
                                If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                    .Qi(i) = ((InSource.DurationT * 60) - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                                End If
                            Next i
                        End With
                        '非正常
                        Me.m_Sources(sn).SLeak = New SurfaceLeak '实例化面源对象
                        Me.m_Sources(sn).SLeak.Name = Me.m_Chemical.Name0   '泄漏物质名称
                        Me.m_Sources(sn).SLeak.Q = InSource.Q0 * 1000000 '泄漏物质的速率mg/s
                        Me.m_Sources(sn).SLeak.Ts = InSource.Ts0 + 273.15 '设置温度，摄氏度
                        Me.m_Sources(sn).SLeak.DurationTime = InSource.DurationT * 60  '排放持续时间转化为S
                        Me.m_Sources(sn).SLeak.He = InSource.H '有效排放高度
                        Me.m_Sources(sn).SLeak.S = InSource.S_S '面源的面积
                    Case 2 '体源
                        '多烟团
                        With MultiVLeak
                            .Name = Me.m_Chemical.Name0  '泄漏物质名称
                            .Q = InSource.Q0 * 1000000 '泄漏物质的速率mg/s
                            .Ts = InSource.Ts0 + 273.15 '设置温度，摄氏度
                            .DurationTime = InSource.DurationT * 60 '排放持续时间转化为S
                            .He = InSource.H   '有效排放高度
                            If .DurationTime Mod Me.Forecast.OutPut.IntervalTime > 0 Then
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime) + 1 '烟团个数
                            Else
                                .n = Fix(.DurationTime / Me.Forecast.OutPut.IntervalTime)
                            End If
                            .ResetMulti(.n) '设置烟团个数为n个
                            For i = 1 To .n Step 1
                                .Qi(i) = .Q * Me.Forecast.OutPut.IntervalTime
                                .Si(i) = InSource.S_S
                                .Thickness(i) = InSource.Thickness  '体源的厚度
                                If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                    .Qi(i) = ((InSource.DurationT * 60) - (i - 1) * Me.Forecast.OutPut.IntervalTime) * .Q
                                End If
                            Next i
                        End With

                        '非正常

                        Me.m_Sources(sn).VLeak = New VolumeLeak '实例化体源对象
                        Me.m_Sources(sn).VLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                        Me.m_Sources(sn).VLeak.Q = InSource.Q0 * 1000000 '泄漏物质的速率mg/s
                        Me.m_Sources(sn).VLeak.Ts = InSource.Ts0 + 273.15 '设置温度，摄氏度
                        Me.m_Sources(sn).VLeak.DurationTime = InSource.DurationT * 60  '排放持续时间转化为S
                        Me.m_Sources(sn).VLeak.He = InSource.H  '有效排放高度
                        Me.m_Sources(sn).VLeak.S = InSource.S_S  '体源的底面积
                        Me.m_Sources(sn).VLeak.Hv = InSource.Thickness  '体源的厚度
                End Select
            Case 1 '(2)气体容器小孔、中孔泄漏
                Dim QG As Double '排放速率kg/s
                Dim Q1 As Double  '排气量，m3/s
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .H = InSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = InSource.InT + 273.15  '将摄氏度转化为绝对温度
                    QG = CalculateLeakGas(InSource.LeakGasShape, .Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, InSource.LeakGasP, InSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                    If QG = ErrorValue Then
                        Return False
                    End If
                    .Q = QG * 1000000 '泄漏速率，mg/s
                    Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                    .Qv = Q1 * Me.m_ForeCast.Pa / InSource.LeakGasP  '等效排气量
                    .D = System.Math.Sqrt(InSource.LeakGasA / Math.PI) * 2 '等效排气筒直径
                    .DH = RiseH(Pa_BP, .Qv, .D, .H, .Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, InSource.Angle) '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If InSource.DurationT * 60 <= InSource.Q / QG Then
                        .DurationTime = InSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = InSource.Q / QG '泄漏持续时间
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
                Me.m_Sources(sn).PLeak.H = InSource.H    '排放高度
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度

                QG = CalculateLeakGas(InSource.LeakGasShape, Me.m_Sources(sn).PLeak.Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, InSource.LeakGasP, InSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                Me.m_Sources(sn).PLeak.QAll = QG * 1000000 '泄漏速率，mg/s
                Me.m_Sources(sn).PLeak.Q = QG * 1000000 '泄漏速率，mg/s
                Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                Me.m_Sources(sn).PLeak.Qv = Q1 * Me.m_ForeCast.Pa / InSource.LeakGasP  '等效排气量m3/s，
                Me.m_Sources(sn).PLeak.D = System.Math.Sqrt(InSource.LeakGasA / Math.PI) * 2 ' 等效排气筒直径
                Me.m_Sources(sn).PLeak.DH = RiseH(Pa_BP, Me.m_Sources(sn).PLeak.Qv, Me.m_Sources(sn).PLeak.D, Me.m_Sources(sn).PLeak.H, Me.m_Sources(sn).PLeak.Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, InSource.Angle) '烟气抬升高度
                Me.m_Sources(sn).PLeak.He = Me.m_Sources(sn).PLeak.H + Me.m_Sources(sn).PLeak.DH  '泄漏源有效高度
                If InSource.DurationT * 60 <= InSource.Q / QG Then
                    Me.m_Sources(sn).PLeak.DurationTime = InSource.DurationT * 60 '泄漏持续时间，S
                Else
                    Me.m_Sources(sn).PLeak.DurationTime = InSource.Q / QG '泄漏持续时间，S
                End If

            Case 2 '(3)气体容器爆裂
                '多烟团模型
                QLG = InSource.Q   '总的储存量
                E1 = QLG
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .Q = QLG * 1000000 '泄漏速率，mg/s
                    .H = InSource.H
                    .He = InSource.H  '泄漏源有效高度
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
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度
                Me.m_Sources(sn).PLeak.Qv = 0 '排气量　m3/s
                Me.m_Sources(sn).PLeak.H = MultiPLeak.He  '排放高度
                Me.m_Sources(sn).PLeak.D = 1 '直径
                '计算烟气抬升有效高度
                Me.m_Sources(sn).PLeak.He = MultiPLeak.He
            Case 3 '(4)压力液化气容器液下小孔、中孔泄漏

                '计算液体泄漏速率kg/s
                QLG = CalculateLeakLiquid(1, InSource.LeakLiquidCd, InSource.LeakLiquidHeight, InSource.LeakGasA, Me.m_Chemical.LeakLiquidPl, InSource.LeakGasP, Me.m_ForeCast.Pa)
                If QLG = ErrorValue Then
                    Return False
                End If
                '计算泄漏液体的蒸发量速率kg/s
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, InSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
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
                    .H = InSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = InSource.InT + 273.15 '将摄氏度转化为绝对温度
                    .QpAll = QLG * 1000000
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .DH = 0 '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If InSource.DurationT * 60 <= InSource.Q / E1 Then
                        .DurationTime = InSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = InSource.Q / E1 '泄漏持续时间
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个

                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * Me.m_ForeCast.OutPut.IntervalTime To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                If j * E1 <= InSource.Q Then  '计算某一时刻的泄漏到地面的量，以便计算液池半径
                                    QGround = j * (QLG - E1)  'kg
                                Else
                                    QGround = InSource.Q  'kg
                                End If
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QGround, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                '先根据热量蒸发和质量蒸发速率求出最大液池面积，二分法--------------------------------------
                                Dim S1, S2 As Double
                                S1 = 0
                                S2 = 1000000
                                Smax = 0
                                Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If Vh + Vq > QLG - E1 Then '如果蒸发速率大于泄漏速率,则计算最大面积
                                    S2 = Sj
                                    While Math.Abs(Vh + Vq - (QLG - E1)) > 0.000001
                                        Smax = (S2 + S1) / 2
                                        Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Smax, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                        Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Smax) '计算质量蒸发速率,kg/s,1km^2
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
                                Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
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
                    .H = InSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = InSource.InT + 273.15  '将摄氏度转化为绝对温度
                    QG = CalculateLeakGas(InSource.LeakGasShape, .Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, InSource.LeakGasP, InSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                    If QG = ErrorValue Then
                        Return False
                    End If
                    .Q = QG * 1000000 '泄漏速率，mg/s
                    Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                    .Qv = Q1 * Me.m_ForeCast.Pa / InSource.LeakGasP  '等效排气量
                    .D = System.Math.Sqrt(InSource.LeakGasA / Math.PI) * 2 '等效排气筒直径
                    .DH = RiseH(Pa_BP, .Qv, .D, .H, .Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, InSource.Angle) '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If InSource.DurationT * 60 <= InSource.Q / QG Then
                        .DurationTime = InSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = InSource.Q / QG '泄漏持续时间
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
                Me.m_Sources(sn).PLeak.H = InSource.H    '排放高度
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度

                QG = CalculateLeakGas(InSource.LeakGasShape, Me.m_Sources(sn).PLeak.Ts, Me.m_Chemical.LeakGasK, Me.m_ForeCast.Pa, InSource.LeakGasP, InSource.LeakGasA, Me.m_Chemical.LeakM) '计算气体泄漏速率,kg/s
                Me.m_Sources(sn).PLeak.QAll = QG * 1000000 '泄漏速率，mg/s
                Me.m_Sources(sn).PLeak.Q = QG * 1000000 '泄漏速率，mg/s
                Q1 = QG / Me.m_Chemical.LeakM * 22.4 / 1000
                Me.m_Sources(sn).PLeak.Qv = Q1 * Me.m_ForeCast.Pa / InSource.LeakGasP  '等效排气量m3/s，
                Me.m_Sources(sn).PLeak.D = System.Math.Sqrt(InSource.LeakGasA / Math.PI) * 2 ' 等效排气筒直径
                Me.m_Sources(sn).PLeak.DH = RiseH(Pa_BP, Me.m_Sources(sn).PLeak.Qv, Me.m_Sources(sn).PLeak.D, Me.m_Sources(sn).PLeak.H, Me.m_Sources(sn).PLeak.Ts, Ta_K, u10, Me.m_ForeCast.OutPut.GroundCharacter, stab, InSource.Angle) '烟气抬升高度
                Me.m_Sources(sn).PLeak.He = Me.m_Sources(sn).PLeak.H + Me.m_Sources(sn).PLeak.DH  '泄漏源有效高度
                If InSource.DurationT * 60 <= InSource.Q / QG Then
                    Me.m_Sources(sn).PLeak.DurationTime = InSource.DurationT * 60 '泄漏持续时间，S
                Else
                    Me.m_Sources(sn).PLeak.DurationTime = InSource.Q / QG '泄漏持续时间，S
                End If
            Case 5 '(6)压力液化气容器爆裂
                '多烟团模型
                QLG = InSource.Q   '总的储存量
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, InSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
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
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .H = InSource.H
                    .He = InSource.H  '泄漏源有效高度
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度
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
                QLG = CalculateLeakLiquid(1, InSource.LeakLiquidCd, InSource.LeakLiquidHeight, InSource.LeakGasA, Me.m_Chemical.LeakLiquidPl, InSource.LeakGasP, Me.m_ForeCast.Pa)
                If QLG = ErrorValue Then
                    Return False
                End If
                '计算泄漏液体的蒸发量速率kg/s
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, InSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
                E1 = 0
                With MultiPLeak
                    .Name = Me.m_Chemical.Name0
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .H = InSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = InSource.InT + 273.15 '将摄氏度转化为绝对温度
                    .QpAll = QLG * 1000000
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .DH = 0 '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If InSource.DurationT * 60 <= InSource.Q / E1 Then
                        .DurationTime = InSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = InSource.Q / E1 '泄漏持续时间
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个

                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * Me.m_ForeCast.OutPut.IntervalTime To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                If j * E1 <= InSource.Q Then  '计算某一时刻的泄漏到地面的量，以便计算液池半径
                                    QGround = j * (QLG - E1)  'kg
                                Else
                                    QGround = InSource.Q  'kg
                                End If
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QGround, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                '先根据热量蒸发和质量蒸发速率求出最大液池面积，二分法--------------------------------------
                                Dim S1, S2 As Double
                                S1 = 0
                                S2 = 1000000
                                Smax = 0
                                Vh = 0 '热量蒸发速率,kg/s
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If Vh + Vq > QLG - E1 Then '如果蒸发速率大于泄漏速率,则计算最大面积
                                    S2 = Sj
                                    While Math.Abs(Vh + Vq - (QLG - E1)) > 0.000001
                                        Smax = (S2 + S1) / 2
                                        Vh = 0 '热量蒸发速率,kg/s
                                        Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Smax) '计算质量蒸发速率,kg/s,1km^2
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
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
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
                QLG = InSource.Q   '总的储存量
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
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .H = InSource.H
                    .He = InSource.H  '泄漏源有效高度
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                Vh = 0 '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度
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
                QLG = CalculateLeakTwo(Me.m_Chemical.LeakLiquidCP, InSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, m_Chemical.Pg, m_Chemical.LeakLiquidPl, InSource.LeakTwoCd, InSource.LeakGasA, InSource.LeakGasP, InSource.LeakGasP * 0.55)
                '计算泄漏液体的蒸发量速率kg/s
                Fv_Renamed = CalculateLeakFv(Me.m_Chemical.LeakLiquidCP, InSource.InT, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH) '计算蒸发系数
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
                    .H = InSource.H   '泄漏源高度
                    '计算结果泄漏速率
                    .Ts = InSource.InT + 273.15 '将摄氏度转化为绝对温度
                    .QpAll = QLG * 1000000
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .DH = 0 '烟气抬升高度
                    .He = .H + .DH  '泄漏源有效高度
                    If InSource.DurationT * 60 <= InSource.Q / E1 Then
                        .DurationTime = InSource.DurationT * 60 '泄漏持续时间
                    Else
                        .DurationTime = InSource.Q / E1 '泄漏持续时间
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个

                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * Me.m_ForeCast.OutPut.IntervalTime To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                If j * E1 <= InSource.Q Then  '计算某一时刻的泄漏到地面的量，以便计算液池半径
                                    QGround = j * (QLG - E1)  'kg
                                Else
                                    QGround = InSource.Q  'kg
                                End If
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QGround, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                '先根据热量蒸发和质量蒸发速率求出最大液池面积，二分法--------------------------------------
                                Dim S1, S2 As Double
                                S1 = 0
                                S2 = 1000000
                                Smax = 0
                                Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
                                If Vh = ErrorValue Or Vq = ErrorValue Then
                                    Return False
                                End If
                                If Vh + Vq > QLG - E1 Then '如果蒸发速率大于泄漏速率,则计算最大面积
                                    S2 = Sj
                                    While Math.Abs(Vh + Vq - (QLG - E1)) > 0.000001
                                        Smax = (S2 + S1) / 2
                                        Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Smax, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                        Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Smax) '计算质量蒸发速率,kg/s,1km^2
                                        If Vh + Vq > QLG - E1 Then
                                            S2 = Smax
                                        Else
                                            S1 = Smax
                                        End If
                                    End While
                                    Sj = Smax
                                End If
                                Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率,kg/s
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率,kg/s
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
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
                QLG = InSource.Q   '总的储存量
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
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .H = InSource.H
                    .He = InSource.H  '泄漏源有效高度
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                Vh = CalculateLeakHeat(InSource.LeakEvaporationGround, Sj, Me.m_ForeCast.Ta, Me.m_Chemical.LeakEvaporationTb, Me.m_Chemical.LeakLiquidH, j) '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度
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
                QLG = InSource.Q   '总的储存量
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
                    .Q = E1 * 1000000 '泄漏速率，mg/s
                    .H = InSource.H
                    .He = InSource.H  '泄漏源有效高度
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
                        .He = InSource.SHe  '面源的有效高度
                        .DurationTime = InSource.VolatilizationT * 60 '面源的蒸发时间
                        If (InSource.VolatilizationT * 60) Mod Me.m_ForeCast.OutPut.IntervalTime > 0 Then
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime) + 1 '烟团个数
                        Else
                            .n = Fix((InSource.VolatilizationT * 60) / Me.m_ForeCast.OutPut.IntervalTime)
                        End If
                        .ResetMulti(.n) '设置烟团个数为n个
                        For i = 1 To .n Step 1
                            Ti = Fix(Me.m_ForeCast.OutPut.IntervalTime) * i
                            If i = .n Then  '第n个烟团的时间应为泄漏持续时间
                                Ti = InSource.VolatilizationT * 60
                            End If
                            For j = stepT + (i - 1) * CDbl(Me.m_ForeCast.OutPut.IntervalTime) To Ti Step stepT '步长为0.1秒，求出每0.1秒的扩散面积及热量蒸发和质量蒸发量
                                r = PoolR(Me.m_Chemical.LeakLiquidPl, QLG - E1, j, MultiPLeak.QpAllT)
                                Sj = PI * r * r
                                If Sj >= InSource.S Then '如果扩散面积>=液池面积，则取液池面积
                                    Sj = InSource.S
                                    r = Math.Sqrt(InSource.S / Math.PI)
                                End If
                                Vh = 0 '热量蒸发速率
                                Q2 = Q2 + Vh * stepT  '通过计算热量蒸发速率,计算出单位烟团的排放量kg
                                Vq = CalculateLeakQuality(stab, InSource.LeakEvaporationP, Me.m_Chemical.LeakM, Me.m_ForeCast.Ta, Me.m_ForeCast.Met(sn).U_Ground, Sj) '计算质量蒸发速率
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
                        .Q = .QsAll * 1000000 / MultiSLeak.DurationTime '泄漏物质的速率mg/s
                    End With
                End If
                '非正常排放模型,点源
                Me.m_Sources(sn).PLeak.Name = Me.m_Chemical.Name0  '泄漏物质名称
                Me.m_Sources(sn).PLeak.QAll = MultiPLeak.QpAll
                Me.m_Sources(sn).PLeak.Q = MultiPLeak.V1(1) * 1000000 '泄漏物质的速率mg/s
                Me.m_Sources(sn).PLeak.DurationTime = MultiPLeak.DurationTime '排放持续时间转化为S
                Me.m_Sources(sn).PLeak.Ts = InSource.InT + 273.15 '设置温度，摄氏度
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
        If InSource.IsHeavy Then
            '瞬时重气体模型
            m_Heavy(sn) = New DisPuff.AllHeavy
            m_Heavy(sn).BoxHeavy.MgMol = m_Chemical.LeakM '摩尔质量
            m_Heavy(sn).BoxHeavy.Cpg = m_Chemical.Cpg   '气体的定压比热容
            m_Heavy(sn).BoxHeavy.Pa = Forecast.Pa '环境压力
            m_Heavy(sn).BoxHeavy.Tempa = Forecast.Ta + 273.15 '环境温度
            m_Heavy(sn).BoxHeavy.boxMetAndMass.u10 = m_ForeCast.Met(sn).WindSpeed '风速
            m_Heavy(sn).BoxHeavy.boxMetAndMass.stab = m_ForeCast.Met(sn).Stab '稳定度
            m_Heavy(sn).BoxHeavy.boxMetAndMass.BoxAirMass(0) = New DisPuff.BoxAirMass
            m_Heavy(sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_Temp = InSource.InT + 273.15 '云团的初始温度


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
            m_Heavy(sn).SlabHeavy.SlabMetAndMass.slabAirMass(0).m_Temp = InSource.InT + 273.15 '云团的初始温度


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
            m_Heavy(sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_Ma = InSource.AirProportion * m_Heavy(sn).BoxHeavy.Mg  '卷入空气的初始质量

            m_Heavy(sn).SlabHeavy.MaS = InSource.AirProportion * m_Heavy(sn).SlabHeavy.MgS '卷入空气的初始质量,kg/s

            '计算重气体参数
            m_Heavy(sn).BoxHeavy.CalHeavy()
            m_Heavy(sn).SlabHeavy.CalHeavy()
        End If
    End Function



    ''' <summary>
    ''' 计算绝对坐标的关心点浓度
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateRisk(ByVal Sn As Integer, ByVal workpath As String, ByVal InSource As IntialSource)
        '计算某一浓度关心点的最大浓度及出现时刻--------------------------------------------------------------------
        Dim startTime, endTime As Double '最大值可能出现的起始和结束时间
        startTime = 0
        endTime = 0
        'For i = 0 To Me.m_ForeCast.CareReceptor.Length - 1 Step 1 '按关心点计算
        '    '计算某一关心点的最大浓度出现时间
        'Dim dblMax As MaxCD = CarePointGroldCutCT(Sn, 0, 600 * 3600, Me.m_ForeCast.CareReceptor(i).Point3D.x, Me.m_ForeCast.CareReceptor(i).Point3D.y, Me.m_ForeCast.CareReceptor(i).Point3D.z)

        '    Me.m_Results.AllCareResult.CarePointMaxCT(Sn, i) = dblMax
        '    '计算某一浓度出现在某一关心点的时刻--------------------------------------------------------------------
        '    Dim iCustomC As Integer
        '    For iCustomC = 0 To Me.m_ForeCast.HurtConcentration.Length - 1 '按浓度阀值进行预测
        '        Dim specifyC As Double = Me.m_ForeCast.HurtConcentration(iCustomC).ConcentrationVale '伤害浓度值
        '        Dim specifyStartTime, specifyEndTime As Double '给定浓度值的开始时间和结束时间
        '        If dblMax.MaxC >= specifyC Then '如果最大浓度大于浓度阀值则进行计算，否则不计算
        '            '首先计算开始时间。先从数组找出第一个大于浓度阀值的极大值
        '            '采用二分法求出该时间
        '            specifyStartTime = CarePointCandT(Sn, Me.m_ForeCast.CareReceptor(i).Point3D.x, Me.m_ForeCast.CareReceptor(i).Point3D.y, Me.m_ForeCast.CareReceptor(i).Point3D.z, 0, dblMax.maxT, specifyC)
        '            '再计算结束时间。先从数组找出最后一个大于浓度阀值的极大值

        '            '采用二分法求出该时间
        '            specifyEndTime = CarePointCandT(Sn, Me.m_ForeCast.CareReceptor(i).Point3D.x, Me.m_ForeCast.CareReceptor(i).Point3D.y, Me.m_ForeCast.CareReceptor(i).Point3D.z, 600 * 3600, dblMax.maxT, specifyC)
        '            '将计算结果存入关心点数组中listResult.CheckedItems
        '            If specifyStartTime > 0 Or specifyEndTime > 0 Then
        '                Me.m_Results.AllCareResult.CarePointTime(Sn, i, iCustomC).StartTime = specifyStartTime  '开始时间
        '                Me.m_Results.AllCareResult.CarePointTime(Sn, i, iCustomC).EndTime = specifyEndTime '结束时间
        '            End If
        '            Result = 0 '将结果置0
        '        End If
        '    Next iCustomC
        'Next i



        '以下开始按关心点的瞬时浓度、死亡概率和死亡百分率-------------------------------------------------------------------

        '创建预测点的数组
        Dim ArrayPoint(-1) As Point3D
        Dim n As Integer = 0
        If Me.Forecast.IsCalGrid = True Then
            ReDim Preserve ArrayPoint(Me.Forecast.Grid.CountX * Me.Forecast.Grid.CountY - 1)
            For j As Integer = 0 To Me.Forecast.Grid.CountY - 1
                For i As Integer = 0 To Me.Forecast.Grid.CountX - 1
                    ArrayPoint(n) = New Point3D
                    ArrayPoint(n).x = Me.Forecast.Grid.MinX + Me.Forecast.Grid.StepX * i
                    ArrayPoint(n).y = Me.Forecast.Grid.MinY + Me.Forecast.Grid.StepY * j
                    ArrayPoint(n).z = Me.Forecast.Grid.WGH
                    n += 1
                Next
            Next
        End If
        If Me.Forecast.IsCalCare = True Then
            ReDim Preserve ArrayPoint(ArrayPoint.Length + Me.Forecast.CareReceptor.Length - 1)
            For i As Integer = 0 To Me.Forecast.CareReceptor.Length - 1
                ArrayPoint(n) = Me.Forecast.CareReceptor(i).Point3D
                n += 1
            Next
        End If

        Dim MaxArrayResult(ArrayPoint.Length - 1) As RectableConAndTime  '储存当前气象条件的最大值
        Dim AllArrayResult(Me.m_ForeCast.OutPut.ForeCount - 1, ArrayPoint.Length - 1) As Double '当前气象条件下所有时刻的值。方便后面进行毒性负荷和滑移平均

        '当前气象条件下所有时刻的值。方便后面进行毒性负荷和滑移平均
        Me.CalculateInstance(Sn, ArrayPoint, MaxArrayResult, AllArrayResult, InSource) '计算当前气象条件下的浓度

        '根据计算结果把所有的计算结果储存成网格和关心点的形式
        Dim Post As New PostCon
        Dim L As Integer = 0
        ReDim Post.GridCon(Me.m_ForeCast.OutPut.ForeCount - 1, Me.Forecast.Grid.CountY - 1, Me.Forecast.Grid.CountX - 1)
        ReDim Post.CareCon(Me.m_ForeCast.OutPut.ForeCount - 1, Me.Forecast.CareReceptor.Length - 1)

        For nIndex As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
            L = 0
            If Me.m_ForeCast.IsCalGrid Then
                For j As Integer = 0 To Me.Forecast.Grid.CountY - 1
                    For i As Integer = 0 To Me.Forecast.Grid.CountX - 1
                        Post.GridCon(nIndex, j, i) = AllArrayResult(nIndex, L)
                        L += 1
                    Next
                Next
            End If
            For i As Integer = 0 To Me.Forecast.CareReceptor.Length - 1
                If MaxArrayResult(L + i).MaxConcentration > Me.m_Results.Rectable.CareRectbleConAndTime(0, i).MaxConcentration Then
                    Me.m_Results.Rectable.CareRectbleConAndTime(nIndex, i) = MaxArrayResult(L + i)
                End If
            Next
        Next
        Post.m_MetDateTime = Me.Forecast.Met(Sn).m_DateTime
        Post.m_StartTime = Me.Forecast.OutPut.ForeStart
        Post.m_TimeStep = Me.Forecast.OutPut.ForeInterval
        Post.m_TimeCount = Me.Forecast.OutPut.ForeCount
        '在这里把计算结果写到磁盘上
        Post.Save(workpath & "Post\", InSource.ID)

        '找出全部的气象数组对应的各点高值来-----------------------------------
        L = 0
        If Me.m_ForeCast.IsCalGrid Then
            For j As Integer = 0 To Me.Forecast.Grid.CountY - 1
                For i As Integer = 0 To Me.Forecast.Grid.CountX - 1
                    If MaxArrayResult(L).MaxConcentration > Me.m_Results.Rectable.GridRectbleConAndTime(0, j, i).MaxConcentration Then
                        Me.m_Results.Rectable.GridRectbleConAndTime(0, j, i) = MaxArrayResult(L)
                    End If
                    L += 1
                Next
            Next
        End If
        For i As Integer = 0 To Me.Forecast.CareReceptor.Length - 1
            If MaxArrayResult(L + i).MaxConcentration > Me.m_Results.Rectable.CareRectbleConAndTime(0, i).MaxConcentration Then
                Me.m_Results.Rectable.CareRectbleConAndTime(0, i) = MaxArrayResult(L + i)
            End If
        Next
        '根据上面的瞬时计算结果来计算风险值----------------------------------------------------------------------------------------
        Dim Result As Double '定义计算结果
        If Me.m_ForeCast.OutPut.IsRisk = True Then

            Dim Pr(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1) As Double '用于暂时储存网格点的概率值Y
            Dim D(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1) As Double '用于暂时储存网格点的概率值D
            Dim MetRisk As Double = 0 '某一种气象条件下的事故风险值
            Dim Risk As Double = 0 '用于暂时储存该气象条件下的风险值
            Dim SlipGrid(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1) As Slippage
            Dim DiePeople As Double = 0 '死亡人数
            If Me.m_ForeCast.OutPut.ChargeOrSlip = 0 Then
                '---------------------------------------------------------------
                '计算毒性负荷
                '---------------------------------------------------------------
                Dim nToxinConut As Integer = Me.m_ForeCast.Grid.CountX * Me.m_ForeCast.Grid.CountY
                Dim k As Integer = 0
                '以下开始按网格点计算浓度分布-------------------------------------------------------------------
                For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1 Step 1 '按Y轴计算
                    For i As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1 Step 1 '按X轴计算
                        Dim ArrayC(Me.m_ForeCast.OutPut.ForeCount - 1) As Double '用于储存某一网格点的浓度值
                        For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
                            ArrayC(nCount) = AllArrayResult(nCount, k)
                        Next
                        '计算某一网格点的最大浓度出现时间及该网格点对应的时间步长各时刻的瞬时浓度。
                        If MaxArrayResult(k).MaxConcentration > 0.0001 Then
                            'Dim dblCnt As Double = ToxinCharge(Sn, dblx, dbly, dblz, dblMax.maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, dblMax.maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2) '用变步长求得毒性负荷的积分
                            Dim dblCnt As Double = ToxinCharge(ArrayC, Me.m_ForeCast.OutPut.ForeInterval * 60) '用变步长求得毒性负荷的积分
                            Pr(j, i) = m_Chemical.PrA + m_Chemical.PrB * Math.Log(dblCnt) '计算概率值

                            If Pr(j, i) < 0 Then
                                Pr(j, i) = 0
                            Else
                                D(j, i) = DiePr.NormalSchool(Pr(j, i)) * 100 '计算死亡率，含百分号
                                Me.m_Results.AllGridResult.PersonalRisk(j, i) += D(j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100 '个人风险值叠加
                                DiePeople += D(j, i) * Me.m_ForeCast.Grid.GridPopulation(j, i) / 100
                                MetRisk += D(j, i) * Me.m_ForeCast.Grid.GridPopulation(j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100 '事故风险值叠加
                                Me.m_Results.AllGridResult.AllRisk += D(j, i) * Me.m_ForeCast.Grid.GridPopulation(j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100 '总的事故风险值叠加
                            End If
                        End If
                        Result = 0 '将结果置0
                        '修改进度
                        Me.m_Results.Status2 = "正在计算网格点的死亡概率和死亡百分率，已完成" & FormatNumber((i * Me.m_ForeCast.Grid.CountY + j) / nToxinConut * 100, 1) & "%"
                        k += 1
                    Next i
                Next j

            Else
                ''----------------------------------------------------------------------------------------------------------------------------------------
                ''计算网格的滑移平均最大浓度－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
                ''----------------------------------------------------------------------------------------------------------------------------------------
                ''计算网格点的扩散参数和浓度-----------------------
                'MinX = Me.m_ForeCast.Grid.MinX  'X轴从坐标负数到正数开始计算浓度
                'MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) 'y轴从坐标正数到负数开始计算浓度
                'dblx = MinX
                'dbly = MaxY
                'dblz = Me.m_ForeCast.Grid.WGH
                ''开始按网格点来计算预测浓度--------------------------------------------------------------
                ''是绝对坐标系统，需转换坐标
                'dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y, Me.m_ForeCast.Met(Sn).WindDer, Me.m_ForeCast.Met(Sn).WindType)
                'dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y, Me.m_ForeCast.Met(Sn).WindDer, Me.m_ForeCast.Met(Sn).WindType)

                'Dim nSlipConut As Integer = Me.m_ForeCast.Grid.CountX * Me.m_ForeCast.Grid.CountY
                ''以下开始按网格点计算浓度分布-------------------------------------------------------------------

                'For i As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1 Step 1 '按X轴计算
                '    For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1 Step 1 '按Y轴计算
                '        If SlipGrid(j, i) Is Nothing Then
                '            SlipGrid(j, i) = New Slippage
                '        End If

                '        '计算某一将网格点的最大浓度出现时间
                '        Dim dblMax As MaxCD = CarePointGroldCutCT(Sn, 0, 24 * 3600, dblx, dbly, dblz, 10)

                '        '计算将网格点的滑移平均最大浓度
                '        If dblMax.MaxC > 1 Then
                '            SlipGrid(j, i) = ReceptorMaxSlipAverage(Sn, dblx, dbly, dblz, dblMax.maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, dblMax.maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2)
                '            If SlipGrid(j, i).MaxCon >= Me.m_ForeCast.HurtConcentration(0).ConcentrationVale Then '如果滑移平均浓度>=LC50，则死亡概率为50，否则为0
                '                D(j, i) = 50 '计算死亡百分率%
                '                Me.m_Results.AllGridResult.PersonalRisk(j, i) += D(j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100 '个人风险值叠加
                '                DiePeople += D(j, i) * Me.m_ForeCast.Grid.GridPopulation(j, i) / 100
                '                MetRisk += D(j, i) * Me.m_ForeCast.Grid.GridPopulation(j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100 '事故风险值叠加
                '                Me.m_Results.AllGridResult.AllRisk += D(j, i) * Me.m_ForeCast.Grid.GridPopulation(j, i) * Me.m_ForeCast.Met(Sn).Frequency / 100  '总的事故概率叠加
                '            Else
                '                D(j, i) = 0
                '            End If
                '        End If

                '        MaxY = MaxY - Me.m_ForeCast.Grid.StepY  'y值逐渐减小
                '        '将网格点赋值给相应的坐标
                '        dblx = MinX / 1.0#
                '        dbly = MaxY / 1.0#

                '        dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y, Me.m_ForeCast.Met(Sn).WindDer, Me.m_ForeCast.Met(Sn).WindType)
                '        dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y, Me.m_ForeCast.Met(Sn).WindDer, Me.m_ForeCast.Met(Sn).WindType)

                '        Result = 0 '将结果置0

                '        '修改进度
                '        Me.m_Results.Status2 = "正在计算网格点的滑移平均最大值，已完成" & FormatNumber((i * Me.m_ForeCast.Grid.CountY + j) / nSlipConut * 100, 1) & "%"

                '    Next j
                '    MaxY = Me.m_ForeCast.Grid.MinY + Me.m_ForeCast.Grid.StepY * (Me.m_ForeCast.Grid.CountY - 1) '给maxY初始值
                '    MinX = MinX + Me.m_ForeCast.Grid.StepX  'minx增加
                '    '将网格点赋值给相应的坐标
                '    dblx = MinX / 1.0#
                '    dbly = MaxY / 1.0#
                '    '转换坐标
                '    dblx = CoordinateX(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y, Me.m_ForeCast.Met(Sn).WindDer, Me.m_ForeCast.Met(Sn).WindType)
                '    dbly = CoordinateY(MinX, MaxY, Me.m_ForeCast.Met(Sn).Vane, Me.m_IntialSource.Coordinate.x, Me.m_IntialSource.Coordinate.y, Me.m_ForeCast.Met(Sn).WindDer, Me.m_ForeCast.Met(Sn).WindType)
                'Next i
            End If

            ''根据计算结果找出前n大值来
            'For iMet As Integer = 0 To nMaxMet - 1
            '    If MetRisk > Me.m_Results.AllGridResult.ArrayRisk(iMet) Then
            '        For jMet As Integer = nMaxMet - 2 To iMet Step -1
            '            Me.m_Results.AllGridResult.ArrayRisk(jMet + 1) = Me.m_Results.AllGridResult.ArrayRisk(jMet)
            '            Me.m_Results.AllGridResult.Pr(jMet + 1) = Me.m_Results.AllGridResult.Pr(jMet).Clone
            '            Me.m_Results.AllGridResult.D(jMet + 1) = Me.m_Results.AllGridResult.D(jMet).Clone
            '            Me.m_Results.AllGridResult.DiePeople(jMet + 1) = Me.m_Results.AllGridResult.DiePeople(jMet)
            '            Me.m_ForeCast.MaxMet(jMet + 1) = Me.m_ForeCast.MaxMet(jMet).Clone
            '            Me.m_Results.AllGridResult.SlipGrid(jMet + 1) = Me.m_Results.AllGridResult.SlipGrid(jMet).Clone
            '        Next
            '        Me.m_Results.AllGridResult.ArrayRisk(iMet) = MetRisk
            '        Me.m_Results.AllGridResult.Pr(iMet) = Pr.Clone
            '        Me.m_Results.AllGridResult.D(iMet) = D.Clone
            '        Me.m_Results.AllGridResult.DiePeople(iMet) = DiePeople
            '        Me.m_ForeCast.MaxMet(iMet) = Me.m_ForeCast.Met(Sn).Clone
            '        Me.m_Results.AllGridResult.SlipGrid(iMet) = SlipGrid.Clone
            '        Exit Sub
            '    End If
            'Next
        End If

        ''计算关心点的滑移平均最大浓度
        'If Me.Forecast.OutPut.IsRisk = True Then
        '    If Me.Forecast.OutPut.ChargeOrSlip = 0 Then
        '        'dblCnt = ToxinCharge(Sn, dblx, dbly, dblz, Me.m_Results.AllCareResult.CarePointMaxCT(Sn, i).maxT - Me.Forecast.OutPut.InhalationTime * 60 / 2, Me.m_Results.AllCareResult.CarePointMaxCT(Sn, i).maxT + Me.Forecast.OutPut.InhalationTime * 60 / 2) '用变步长求得毒性负荷的积分
        '        Me.m_Results.AllCareResult.Pr(Sn, i) = m_Chemical.PrA + m_Chemical.PrB * Math.Log(dblCnt) '计算概率值
        '        If Me.m_Results.AllCareResult.Pr(Sn, i) < 0 Then
        '            Me.m_Results.AllCareResult.Pr(Sn, i) = 0
        '        End If
        '        Me.m_Results.AllCareResult.D(Sn, i) = DiePr.NormalSchool(Me.m_Results.AllCareResult.Pr(Sn, i)) * 100 '计算死亡百分率%
        '    Else
        '        Me.m_Results.AllCareResult.SlipCare(Sn, i) = CalculateCareSlip(Sn, Me.m_ForeCast.CareReceptor(i).Point3D.x, Me.m_ForeCast.CareReceptor(i).Point3D.y, Me.m_ForeCast.CareReceptor(i).Point3D.z)
        '        If Me.m_Results.AllCareResult.SlipCare(Sn, i).MaxCon > Me.m_ForeCast.HurtConcentration(0).ConcentrationVale Then
        '            Me.m_Results.AllCareResult.D(Sn, i) = 50
        '        Else
        '            Me.m_Results.AllCareResult.D(Sn, i) = 0
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub CalculateInstance(ByVal Sn As Integer, ByVal ArrayPoint As Point3D(), ByRef MaxArrayResult As RectableConAndTime(), ByRef AllArrayResult As Double(,), ByVal InSource As IntialSource)


        '计算中气体参数-------------------------------------------------------
        Dim HeavyT, HeavyX As Double '重气团直径、高度、最大扩散时间、最大扩散距离、是否按重气团模型计算
        Dim Is_Heavy As Boolean = False   '是否按重气体模型
        Dim ModolType As Integer = -1
        Dim dx As Double '云团下风向距离间隔  
        Dim dt As Double '云团时间间隔
        If Me.m_Sources(Sn).MultiPLeak.HeavyType = 0 Then '点源为瞬时重气体模型
            '重气体模型--------------------------------------------------------
            If InSource.IsHeavy = True Then
                If Me.m_Heavy(Sn).BoxHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                    HeavyT = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_t
                    HeavyX = HeavyT * Me.m_ForeCast.Met(Sn).u2
                    dt = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(1).m_t - Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(0).m_t '计算云团时间间隔
                    Is_Heavy = True
                End If
                ModolType = 0
            End If
        ElseIf Me.m_Sources(Sn).MultiPLeak.HeavyType = 1 Then '点源为连续重气体模型
            '重气体模型--------------------------------------------------------
            If InSource.IsHeavy = True Then
                If Me.m_Heavy(Sn).SlabHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                    HeavyX = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_x
                    HeavyT = HeavyX / Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.u10
                    dx = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(1).m_x - Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(0).m_x '计算云团下风向距离间隔
                    Is_Heavy = True
                End If
                ModolType = 1
            End If
        End If
        '计算中气体参数结束-------------------------------------------------------

        For nCount As Integer = 0 To Me.m_ForeCast.OutPut.ForeCount - 1
            '处理计算时刻
            Dim dblForecastTime As Double = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60 '将预测列表中的预测时刻按顺序赋值上述变量，乘以60，将单位转化为秒


            '根据计算时刻来计算关心点的浓度-----------------------------
            '计算前需要先获取烟团的初始状态，然后再根据烟团的初始状态获取计算时刻时所有烟团的轨迹和扩散参数，再计算得到浓度
            Dim ListFlogLave As New List(Of FlogLeave())
            If Me.Sources(Sn).MultiPLeak.Q Then '点源泄漏
                Dim FlogLeave(Me.Sources(Sn).MultiPLeak.Qi.Length - 2) As FlogLeave
                For i As Integer = 0 To FlogLeave.Length - 1
                    FlogLeave(i).Q = Me.Sources(Sn).MultiPLeak.Qi(i + 1)
                    FlogLeave(i).z = Me.Sources(Sn).MultiPLeak.He
                    FlogLeave(i).x = InSource.Coordinate.x
                    FlogLeave(i).y = InSource.Coordinate.y
                    FlogLeave(i).ax = 0
                    FlogLeave(i).az = 0
                    FlogLeave(i).LeaveTime = Me.Forecast.OutPut.IntervalTime * i
                Next
                ListFlogLave.Add(FlogLeave)
            End If
            Dim TotalArrayResult(ArrayPoint.Length - 1) As Double
            For i As Integer = 0 To ListFlogLave.Count - 1
                '生成烟团的轨迹和扩散参数
                Dim ArrayFlogTrack() As FlogTrack = Formula.CreateMultiFlogTrack(Me.Forecast.Met, Sn, dblForecastTime, Me.Forecast.OutPut.GroundCharacter, ListFlogLave(i), Me.m_Sources(Sn).MultiPLeak.HeavyType, InSource.IsHeavy, Me.m_Heavy(Sn), HeavyT, HeavyX, dt, dx)
                '对扩散参数进行重气体修正
                'HeavyPara(ArrayFlogTrack, Sn, dx, dt, dblForecastTime, HeavyT, HeavyX)
                '根据烟团的扩散参数和位置，计算浓度
                Dim ArrayResult() As Double = Formula.Multi_Point_CommonGaussFog(ArrayFlogTrack, ArrayPoint)
                For j As Integer = 0 To ArrayResult.Length - 1
                    TotalArrayResult(j) += ArrayResult(j)
                Next
            Next
            For j As Integer = 0 To TotalArrayResult.Length - 1
                AllArrayResult(nCount, j) = TotalArrayResult(j)
                If TotalArrayResult(j) > MaxArrayResult(j).MaxConcentration Then
                    MaxArrayResult(j).MaxConcentration = TotalArrayResult(j)
                    MaxArrayResult(j).LeakTime = Me.m_ForeCast.Met(Sn).m_DateTime
                    MaxArrayResult(j).ForeTime = (Me.m_ForeCast.OutPut.ForeStart + Me.m_ForeCast.OutPut.ForeInterval * nCount) * 60
                End If
            Next
            '设置计算进度
            Me.m_Results.AllProgress += 1
        Next nCount
    End Sub
    ''' <summary>
    ''' 根据重气体对扩散参数进行修正
    ''' </summary>
    ''' <param name="ArryFlogLeave"></param>
    ''' <param name="Sn"></param>
    ''' <param name="dx"></param>
    ''' <param name="dt"></param>
    ''' <param name="dblForecastTime"></param>
    ''' <param name="HeavyT"></param>
    ''' <param name="HeavyX"></param>
    ''' <remarks></remarks>
    Private Sub HeavyPara(ByVal ArryFlogLeave As FlogTrack(), ByVal Sn As Integer, ByVal dx As Double, ByVal dt As Double, ByVal dblForecastTime As Double, ByVal HeavyT As Double, ByVal HeavyX As Double, ByVal IsHeavy As Boolean)
        '对扩散参数进行重气体的修正
        Dim HeavyB, HeavyH As Double
        For j As Integer = 0 To ArryFlogLeave.Length - 1
            If Me.m_Sources(Sn).MultiPLeak.HeavyType = 0 Then '点源为瞬时重气体模型
                '重气体模型--------------------------------------------------------
                If IsHeavy = True Then
                    If Me.m_Heavy(Sn).BoxHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        If dblForecastTime <= HeavyT Then '如果预测时间小于重气体最大扩散时间
                            Dim nIndex As Integer = dblForecastTime / dt
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(nIndex).m_H '云团高度
                        Else
                            HeavyB = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_R * 2 '云团直径
                            HeavyH = Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass(Me.m_Heavy(Sn).BoxHeavy.boxMetAndMass.BoxAirMass.Length - 1).m_H '云团高度
                        End If
                    End If
                End If
            ElseIf Me.m_Sources(Sn).MultiPLeak.HeavyType = 1 Then '点源为连续重气体模型
                '重气体模型--------------------------------------------------------
                If IsHeavy = True Then
                    If Me.m_Heavy(Sn).SlabHeavy IsNot Nothing AndAlso Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length > 2 Then '重气云团至少有3个及以上气团持续时间
                        If ArryFlogLeave(j).Distance > 0 And ArryFlogLeave(j).Distance <= HeavyX Then '如果烟团中心距离小于重气体最大扩散距离
                            Dim nIndex As Integer = ArryFlogLeave(j).Distance / dx
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(nIndex).m_H '云羽高度
                        ElseIf ArryFlogLeave(j).Distance > 0 Then
                            HeavyB = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_L * 2 '云羽宽度
                            HeavyH = Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass(Me.m_Heavy(Sn).SlabHeavy.SlabMetAndMass.slabAirMass.Length - 1).m_H '云羽高度
                        End If
                    End If
                End If
            End If
            If IsHeavy = True Then '重气体修正---------------------------------------
                If ArryFlogLeave(j).Distance <= HeavyX Then
                    Dim ay As Double = HeavyB / 4.3 'y轴扩散参数
                    Dim az As Double = HeavyH / 2.15 'Z轴扩散参数，点源修正
                    '计算相应取样时间的扩散参数
                    ay = aySamplingTime(0.5, Me.Forecast.OutPut.SamplingTime, ay)
                    '点源修正后的扩散参数
                    Dim ax As Double = ay

                    '修改重气体泄漏源的有效源高为重气体的高度的一半
                    ArryFlogLeave(j).z = HeavyH / 2
                    ArryFlogLeave(j).ax = ax
                    ArryFlogLeave(j).az = az
                Else

                End If
            End If
        Next
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
    Private Function ResultC(ByVal Sn As Integer, ByVal dblForecastTime As Double, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, ByVal InSource As IntialSource) As Double
        '点源泄漏
        Dim result As Double = 0

        If Me.m_Sources(Sn).MultiPLeak.Q > 0 Then '点源源强大于0。
            Dim HeavyB, HeavyH, HeavyT, HeavyX As Double '重气团直径、高度、最大扩散时间、最大扩散距离、是否按重气团模型计算
            Dim Is_Heavy As Boolean = False   '是否按重气体模型
            Dim ModolType As Integer = -1
            If Me.m_Sources(Sn).MultiPLeak.HeavyType = 0 Then '点源为瞬时重气体模型
                '重气体模型--------------------------------------------------------
                If InSource.IsHeavy = True Then
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
                If InSource.IsHeavy = True Then
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
            Dim u10 As Double = Me.m_ForeCast.Met(Sn).WindSpeed  '第0行第2列，风速
            Dim stab As String = Me.m_ForeCast.Met(Sn).Stab  '第0行第3列，风速稳定度
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
                If InSource.IsHeavy = True Then
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
                If InSource.IsHeavy = True Then
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
            Dim u10 As Double = Me.m_ForeCast.Met(Sn).WindSpeed  '第0行第2列，风速
            Dim stab As String = Me.m_ForeCast.Met(Sn).Stab  '第0行第3列，风速稳定度

            If Me.Forecast.OutPut.GaussModelType = 0 Then '多烟团模型
                Select Case InSource.LeakType
                    Case 0 '手动计算 ，重气体模型的瞬时手动计算
                        '计算排放高度处的风速
                        result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).MultiSLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiSLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
                    Case Else  '液体泄漏,两相流泄漏,液体容器破裂泄漏
                        result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).U_Ground, Me.m_Sources(Sn).MultiSLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiSLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)
                End Select
            Else '非正常模型
                Select Case InSource.LeakType
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
                If InSource.IsHeavy = True Then
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
                If InSource.IsHeavy = True Then
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
            Dim u10 As Double = Me.m_ForeCast.Met(Sn).WindSpeed  '第0行第2列，风速
            Dim stab As String = Me.m_ForeCast.Met(Sn).Stab  '第0行第3列，风速稳定度

            If Me.Forecast.OutPut.GaussModelType = 0 Then '多烟团模型
                result = result + MultiFlogPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).MultiVLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.Forecast.OutPut.IntervalTime, dblForecastTime, Me.m_Sources(Sn).MultiVLeak, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, HeavyB, HeavyH, HeavyT, HeavyX, Is_Heavy, ModolType)

            Else '非正常模型
                result = result + UnormalModelPSV(u10, Me.m_ForeCast.Met(Sn).u2, Me.m_Sources(Sn).VLeak.He, stab, Me.m_ForeCast.OutPut.SamplingTime, Me.m_Sources(Sn).VLeak.DurationTime, dblForecastTime, Me.m_Sources(Sn).VLeak.Q, dblx, dbly, dblz, Me.m_ForeCast.OutPut.GroundCharacter, Me.m_Sources(Sn).VLeak.S, Me.m_Sources(Sn).VLeak.Hv, HeavyB, HeavyH, HeavyT, HeavyX, InSource.IsHeavy, ModolType)

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



    '毒性负荷
    Public Overloads Function ToxinCharge(ByVal ArrayC As Double(), ByVal steptime As Integer) As Double
        '  注意浓度单位为ppm，时间单位为min
        Dim All As Double = 0
        For i As Integer = 0 To ArrayC.Length - 1
            All += Math.Pow((ArrayC(i) / m_Chemical.Pg), m_Chemical.Prn) * steptime
        Next
        Return All / 60
    End Function
    ''' <summary>
    ''' 用变步长辛普生公式计算时间段内的毒性负荷。采用变步长普生公式计算时间段内的毒性负荷对于浓度不连续时不好用。
    ''' </summary>
    ''' <param name="Sn">预测气象条件对应的序号</param>
    ''' <param name="LowT">较小的时刻</param>
    ''' <param name="HeighT">较大的时刻</param>
    ''' <param name="dblx">x坐标</param>
    ''' <param name="dbly">y坐标</param>
    ''' <param name="dblz">z坐标</param>
    ''' <returns>返回MaxCD结构</returns>
    ''' <remarks></remarks>
    'Public Overloads Function ToxinCharge(ByVal Sn As Integer, ByVal dblx As Double, ByVal dbly As Double, ByVal dblz As Double, ByVal LowT As Double, ByVal HeighT As Double) As Double
    '变步长辛普生公式计算时间段内的毒性负荷
    'Dim N As Long
    'Dim K As Long
    'Dim t2, t1, ep, s1, H, s2 As Double
    'Dim p As Double
    'Dim xt As Double
    'Dim a, b As Double
    'a = LowT
    'b = HeighT

    'Dim eps As Double
    'eps = 0.0000000001
    'N = 1
    'H = HeighT - a


    'Dim F1 As Double
    'F1 = Math.Pow((ResultC(Sn, a, dblx, dbly, dblz) / m_Chemical.Pg), m_Chemical.Prn) '注意浓度单位为ppm，时间单位为min


    'Dim F2 As Double
    'F2 = Math.Pow((ResultC(Sn, HeighT, dblx, dbly, dblz) / m_Chemical.Pg), m_Chemical.Prn) '注意浓度单位为ppm，时间单位为min

    't1 = H * (F1 + F2) / 2.0#
    's1 = t1
    'ep = eps + 1.0#

    'Dim i As Integer = 0
    'While (ep >= 0.1 And N < 64)
    '    p = 0.0#
    '    For K = 0 To N - 1
    '        xt = a + (K + 0.5) * H
    '        p = p + Math.Pow((ResultC(Sn, xt, dblx, dbly, dblz) / m_Chemical.Pg), m_Chemical.Prn)
    '        i = i + 1
    '    Next K
    '    t2 = (t1 + H * p) / 2.0#
    '    s2 = (4.0# * t2 - t1) / 3
    '    ep = System.Math.Abs(s2 - s1)
    '    t1 = t2
    '    s1 = s2
    '    N = N + N
    '    H = H / 2.0#

    'End While
    'Return s2 / 60 '转成min




    'End Function

#End Region

#Region "提供给宇图的接口方法"

    ''' <summary>
    ''' 初始化泄漏源的名称和坐标。如果以污染源作为原点，可把X和Y分别设置为0。
    ''' </summary>
    ''' <param name="strName">泄漏源的名称</param>
    ''' <param name="x">X轴坐标</param>
    ''' <param name="y">Y轴坐标</param>
    ''' <remarks></remarks>
    Public Sub SetSourceNameAndLocation(ByVal strName As String, ByVal x As Double, ByVal y As Double)
        'Me.m_IntialSource.LeakSourceName = strName
        'Me.m_IntialSource.Coordinate.x = x
        'Me.m_IntialSource.Coordinate.y = y
    End Sub


    ''' <summary>
    ''' 自定义泄漏量的类型为点源泄漏。
    ''' </summary>
    ''' <param name="Q0">污染物泄漏到空气中的速率，单位kg/s。</param>
    ''' <param name="DurationT">污染物泄漏到空气中持续的时间，单位min。</param>
    ''' <remarks></remarks>
    Public Sub SetLeakCustomPoint(ByVal Q0 As Double, ByVal DurationT As Double)
        'Me.m_IntialSource.LeakType = 0 '泄漏类型设置为自定义类型
        'Me.m_IntialSource.SourceType = 0 '设置为点源
        'Me.m_IntialSource.Q0 = Q0 '泄漏到空气中的速率
        'Me.m_IntialSource.DurationT = DurationT  '泄漏到空气中持续的时间
    End Sub
    ''' <summary>
    ''' 设置预测的时刻。可以设置等间距的多个时刻
    ''' </summary>
    ''' <param name="ForeTime">预测的时刻，单位min</param>
    ''' <remarks></remarks>
    Public Sub SetForecastTime(ByVal ForeTime As Double)
        Me.m_ForeCast.OutPut.ForeStart = ForeTime
        Me.m_ForeCast.OutPut.ForeInterval = 10
        Me.m_ForeCast.OutPut.ForeCount = 1
    End Sub
    ''' <summary>
    ''' 计算稳定度
    ''' </summary>
    ''' <param name="dblLongDeg">经度，单位用度表示</param>
    ''' <param name="dblLatDeg">纬度，单位用度表示</param>
    ''' <param name="WindDer">风向，单位度。以正北为0度，顺时针旋转，共360度</param>
    ''' <param name="dblU10">10米处风速，单位m/s</param>
    ''' <param name="nCloudAll">总云量，十分制云量</param>
    ''' <param name="nCloudPart">低云量，十分制云量</param>
    ''' <param name="LeakDateTime">泄漏时的时刻</param>
    ''' <param name="DateTimeMorning">日出时刻</param>
    ''' <param name="DateTimeNight">日落时刻</param>
    ''' <param name="Ta">环境温度，单位摄氏度</param>
    ''' <param name="Pa">环境压力，单位Pa</param>
    ''' <remarks></remarks>
    Public Sub SetMet(ByVal dblLongDeg As Double, ByVal dblLatDeg As Double, ByVal WindDer As Double, ByVal dblU10 As Double, ByVal nCloudAll As Integer, ByVal nCloudPart As Integer _
                          , ByVal LeakDateTime As DateTime, ByVal DateTimeMorning As DateTime, ByVal DateTimeNight As DateTime, ByVal Ta As Double, ByVal Pa As Double)




        Dim stab As String = GetPs(dblLongDeg, dblLatDeg, dblU10, nCloudAll, nCloudPart, LeakDateTime, DateTimeMorning, DateTimeNight)

        ReDim Me.m_ForeCast.Met(0)
        Me.m_ForeCast.Met(0) = New Met
        Me.m_ForeCast.Met(0).WindType = 1 '风的类型设置为1
        Me.m_ForeCast.Met(0).WindDer = WindDer
        Me.m_ForeCast.Met(0).WindSpeed = dblU10
        Me.m_ForeCast.Met(0).Stab = stab
        Me.m_ForeCast.Ta = Ta
        Me.m_ForeCast.Pa = Pa
    End Sub
    ''' <summary>
    ''' 设置关心点数组
    ''' </summary>
    ''' <param name="CareReceptor"></param>
    ''' <remarks></remarks>
    Public Sub SetCare(ByVal CareReceptor As CareReceptor())
        Me.m_ForeCast.IsCalCare = True
        Me.m_ForeCast.CareReceptor = CareReceptor
    End Sub
    ''' <summary>
    ''' 设置网格点
    ''' </summary>
    ''' <param name="MinX">X轴的起始坐标,m</param>
    ''' <param name="StepX">X轴的步长,m</param>
    ''' <param name="CountX">X轴的网格数</param>
    ''' <param name="MinY">Y轴的起始坐标,m</param>
    ''' <param name="StepY">Y轴的步长,m</param>
    ''' <param name="CountY">Y轴的网格数</param>
    ''' <param name="Height">Z轴的高度,m</param>
    ''' <remarks></remarks>
    Public Sub SetGrid(ByVal MinX As Integer, ByVal StepX As Integer, ByVal CountX As Integer _
                     , ByVal MinY As Integer, ByVal StepY As Integer, ByVal CountY As Integer, ByVal Height As Double)
        Me.m_ForeCast.IsCalGrid = True
        Me.m_ForeCast.Grid.MinX = MinX
        Me.m_ForeCast.Grid.StepX = StepX
        Me.m_ForeCast.Grid.CountX = CountX
        Me.m_ForeCast.Grid.MinY = MinY
        Me.m_ForeCast.Grid.StepY = StepY
        Me.m_ForeCast.Grid.CountY = CountY
        Me.m_ForeCast.Grid.WGH = Height
    End Sub
    ''' <summary>
    ''' 设置网格点的个数和网格点的高度
    ''' </summary>
    ''' <param name="Count">网格数</param>
    ''' <param name="Height">Z轴的高度,m</param>
    ''' <remarks></remarks>
    Public Sub SetGridCount(ByVal Count As Integer, ByVal Height As Double)
        Me.m_ForeCast.IsCalGrid = True
        Me.m_ForeCast.Grid.CountX = Count
        Me.m_ForeCast.Grid.CountY = Count
        Me.m_ForeCast.Grid.WGH = Height
    End Sub

    ''' <summary>
    ''' 设置地表特征
    ''' </summary>
    ''' <param name="Index">地表特征的序号：0--平原地区农村及城市远郊区；1--工业区或城区；2--丘陵山区的农村或城市</param>
    ''' <remarks></remarks>
    Public Sub SetGround(ByVal Index As Integer)
        Select Case Index
            Case 0
                Me.m_ForeCast.OutPut.GroundCharacter = "平原地区农村及城市远郊区"
            Case 1
                Me.m_ForeCast.OutPut.GroundCharacter = "工业区或城区"

            Case 2
                Me.m_ForeCast.OutPut.GroundCharacter = "丘陵山区的农村或城市"

        End Select
    End Sub

    ''' <summary>
    ''' 获取一个预测刻的多个关心点的浓度值
    ''' </summary>
    ''' <param name="OutPutCareData">输出的关心点浓度值的数组，对应关心点的浓度</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCareData(ByRef OutPutCareData As Double()) As Boolean

        Dim OutPut(Me.m_ForeCast.CareReceptor.Length - 1) As Double
        For j As Integer = 0 To Me.m_ForeCast.CareReceptor.Length - 1
            OutPut(j) = Me.m_Results.AllCareResult.InstantaneousCareC(0, 0, j)
        Next
        OutPutCareData = OutPut
        If Me.m_ForeCast.IsCalCare = True Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' 获取网格数据
    ''' </summary>
    ''' <param name="OutPutGridData"></param>
    ''' <param name="MinX"></param>
    ''' <param name="StepX"></param>
    ''' <param name="MinY"></param>
    ''' <param name="StepY"></param>
    ''' <param name="Count"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGridData(ByRef OutPutGridData As Double(,), ByRef MinX As Integer, ByRef StepX As Integer _
                     , ByRef MinY As Integer, ByRef StepY As Integer, ByRef Count As Integer)
        Dim OutPut(Me.m_ForeCast.Grid.CountY - 1, Me.m_ForeCast.Grid.CountX - 1) As Double
        For j As Integer = 0 To Me.m_ForeCast.Grid.CountY - 1
            For k As Integer = 0 To Me.m_ForeCast.Grid.CountX - 1
                OutPut(j, k) = Me.m_Results.AllGridResult.InstantaneousGridC(0, 0, j, k)
            Next
        Next
        OutPutGridData = OutPut
        MinX = Me.m_ForeCast.Grid.MinX
        StepX = Me.m_ForeCast.Grid.StepX
        MinY = Me.m_ForeCast.Grid.MinY
        StepY = Me.m_ForeCast.Grid.StepY
        Count = Me.m_ForeCast.Grid.CountX

        If Me.m_ForeCast.IsCalGrid = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub SetToxicity(ByVal HurtConcentration As HurtConcentration())
        ReDim Me.Forecast.HurtConcentration(HurtConcentration.Length - 1)
        For i As Integer = 0 To HurtConcentration.Length - 1
            Me.Forecast.HurtConcentration(i) = New DisPuff.HurtConcentration
            Me.Forecast.HurtConcentration(i).Name = HurtConcentration(i).Name  '名称
            Me.Forecast.HurtConcentration(i).ConcentrationVale = HurtConcentration(i).ConcentrationVale  '浓度值
        Next
    End Sub


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
            'MsgBox("写dis文件错误!")
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
            'MsgBox("读dis文件错误!")
            Return Nothing
        End Try

    End Function
End Class
