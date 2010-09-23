''' <summary>
''' 平板模型
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class SlabHeavy
    ''' <summary>
    ''' 摩尔质量，kg/mol
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MgMol As Double = 0.07091
    ''' <summary>
    ''' 常数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_K As Double = 1
    ''' <summary>
    ''' 重力加速度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_g As Double = 9.8
    ''' <summary>
    ''' 环境压力和温度下空气的密度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Densitya As Double = 1.29
    ''' <summary>
    ''' 环境压力和温度下泄漏气体的密度
    ''' </summary>
    ''' <remarks></remarks>
    Public m_Densityg As Double = 3.16
    ''' <summary>
    ''' 空气从边缘卷入系数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_a1 As Double = 0.6
    ''' <summary>
    ''' 经验常数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_a2 As Double = 0.1
    ''' <summary>
    ''' Von Karmans 常数，取0.4
    ''' </summary>
    ''' <remarks></remarks>
    Private m_kV As Double = 0.4

    ''' <summary>
    ''' 高度Z，m；
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Z As Double = 10
    ''' <summary>
    ''' 空气的温度，K
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Tempa As Double = 273.15 + 16
    ''' <summary>
    ''' 空气的热容，J/K.kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cpa As Double = 1000
    ''' <summary>
    ''' 气团中原泄漏气体的质量速率，kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MgS As Double = 0
    ''' <summary>
    ''' 初始混入云羽的空气的质量速率，kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MaS As Double = 0

    ''' <summary>
    ''' 泄漏气体的热容，J/K.kg
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cpg As Double = 1400

    ''' <summary>
    ''' 地形特征
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Ground As String = "农作物地区"
    ''' <summary>
    ''' 环境压力
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pa As Double = 101325
    ''' <summary>
    ''' 气象条件和云团状态数组
    ''' </summary>
    ''' <remarks></remarks>
    Private m_slabMetAndMass As SlabMetAndMass

    ''' <summary>
    ''' 初始半宽
    ''' </summary>
    ''' <remarks></remarks>
    Private m_L0 As Double = 10


#Region "属性"




    Property MgMol() As Double
        Get
            Return Me.m_MgMol
        End Get
        Set(ByVal value As Double)
            Me.m_MgMol = value
        End Set
    End Property


    ''' <summary>
    ''' 环境压力和温度下空气的密度
    ''' </summary>
    ''' <remarks></remarks>
    Property Densitya() As Double
        Get
            Return Me.m_Densitya
        End Get
        Set(ByVal value As Double)
            Me.m_Densitya = value
        End Set
    End Property
    ''' <summary>
    ''' 环境压力和温度下泄漏气体的密度
    ''' </summary>
    ''' <remarks></remarks>
    Property Densityg() As Double
        Get
            Return Me.m_Densityg
        End Get
        Set(ByVal value As Double)
            Me.m_Densityg = value
        End Set
    End Property


    ''' <summary>
    ''' 空气的温度，K
    ''' </summary>
    ''' <remarks></remarks>
    Property Tempa() As Double
        Get
            Return Me.m_Tempa
        End Get
        Set(ByVal value As Double)
            Me.m_Tempa = value
        End Set
    End Property

    ''' <summary>
    ''' 气团中原泄漏气体的质量，kg
    ''' </summary>
    ''' <remarks></remarks>
    Property MgS() As Double
        Get
            Return Me.m_MgS
        End Get
        Set(ByVal value As Double)
            Me.m_MgS = value
        End Set
    End Property
    ''' <summary>
    ''' 初始混入云羽的空气的质量速率，kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Property MaS() As Double
        Get
            Return Me.m_MaS
        End Get
        Set(ByVal value As Double)
            Me.m_MaS = value
        End Set
    End Property

    ''' <summary>
    ''' 泄漏气体的热容，J/K.kg
    ''' </summary>
    ''' <remarks></remarks>
    Property Cpg() As Double
        Get
            Return Me.m_Cpg
        End Get
        Set(ByVal value As Double)
            Me.m_Cpg = value
        End Set
    End Property

    ''' <summary>
    ''' 地形特征
    ''' </summary>
    ''' <remarks></remarks>
    Property Ground() As String
        Get
            Return Me.m_Ground
        End Get
        Set(ByVal value As String)
            Me.m_Ground = value
        End Set
    End Property
    ''' <summary>
    ''' 气象条件和云团状态数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SlabMetAndMass() As SlabMetAndMass
        Get
            Return Me.m_slabMetAndMass
        End Get
        Set(ByVal value As SlabMetAndMass)
            Me.m_slabMetAndMass = value
        End Set
    End Property
    ''' <summary>
    ''' 环境压力
    ''' </summary>
    ''' <remarks></remarks>
    Property Pa() As Double
        Get
            Return Me.m_Pa
        End Get
        Set(ByVal value As Double)
            Me.m_Pa = value
        End Set
    End Property
    ''' <summary>
    ''' 初始半宽
    ''' </summary>
    ''' <remarks></remarks>
    Property L0() As Double
        Get
            Return Me.m_L0
        End Get
        Set(ByVal value As Double)
            Me.m_L0 = value
        End Set
    End Property
#End Region
#Region "函数"

    Public Sub New()
        Me.m_slabMetAndMass = New SlabMetAndMass
        Me.m_slabMetAndMass.slabAirMass(0) = New SlabAirMass
        Me.m_slabMetAndMass.slabAirMass(0).m_Ma = Me.m_MaS / Me.m_slabMetAndMass.u10   '表示初始混入气团的质量，kg/m。
        Me.m_slabMetAndMass.slabAirMass(0).m_Temp = 273.15
    End Sub

    ''' <summary>
    '''  计算任意距离的气团密度
    ''' </summary>
    ''' <param name="dblMa">卷入空气的总质量</param>
    ''' <param name="dblMg">气团中原泄漏气体的质量</param>
    ''' <param name="dblDensitya">环境压力和温度下空气的密度</param>
    ''' <param name="dblDensityg">环境压力和温度下泄漏气体的密度</param>
    ''' <param name="dblTa">空气的温度，K</param>
    ''' <param name="dblT">气团的温度，K</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FDensity(ByVal dblMa As Double, ByVal dblMg As Double, ByVal dblDensitya As Double, ByVal dblDensityg As Double, ByVal dblTa As Double, ByVal dblT As Double) As Double
        Return (dblMa + dblMg) / ((dblMa / dblDensitya + dblMg / dblDensityg) * dblT / dblTa)
    End Function
    ''' <summary>
    ''' 计算任意距离气团半宽的增加量
    ''' </summary>
    ''' <param name="dbldx">下风向距离间隔</param>
    ''' <param name="dblH">云团高度</param>
    ''' <param name="dblDensity">云团密度</param>
    ''' <param name="dblDensitya">环境压力和温度下空气的密度</param>
    ''' <param name="dblu2">泄漏高度处风速</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FdL(ByVal dbldx As Double, ByVal dblH As Double, ByVal dblDensity As Double, ByVal dblDensitya As Double, ByVal dblu2 As Double)
        If dblDensity - dblDensitya > 0 Then
            Return (dbldx * Math.Sqrt(Me.m_K * Me.m_g * dblH * (dblDensity - dblDensitya) / dblDensitya)) / dblu2
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    '''计算任意距离空气从边缘进入气团的增加量 kg。
    ''' </summary>
    ''' <param name="dbldx">下风向距离</param>
    ''' <param name="dblDensitya">环境压力和温度下空气的密度</param>
    ''' <param name="dblH">云团高度</param>
    ''' <param name="dblL">某一时刻下云羽的半宽</param>
    ''' <param name="dbldL">云云羽的半宽的变化速度</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FdMa1(ByVal dbldx As Double, ByVal dblDensitya As Double, ByVal dblH As Double, ByVal dblL As Double, ByVal dbldL As Double)
        'Dim dblMa1 As Double = 2 * Me.m_a1 * dblDensitya * dblH * dbldL * dbldx
        'Return dblMa1

        Dim dblMa1 As Double = 2 * Me.m_a1 * dblDensitya * dblH * dbldL * dbldx
        Return dblMa1

    End Function
    ''' <summary>
    ''' 空气从顶部进入气团的增加量，kg
    ''' </summary>
    ''' <param name="dbldx">下风向距离的增加量</param>
    ''' <param name="dblDensitya">环境压力和温度下空气的密度</param>
    ''' <param name="dblDensity">云团密度</param>
    ''' <param name="dblH">云团高度</param>
    ''' <param name="dblR">某一时刻下云团的半宽</param>
    ''' <param name="dblu">高度Z处的风速，m/s,Z通常取10m</param>
    ''' <param name="dblZ">高度Z，通常取10</param>
    ''' <param name="stab">大气稳定度，取A，B，C，D，E，F，如果取其它的要转换一下</param>
    ''' <param name="Ground"></param>
    ''' <param name="dblu2">风速</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fdMa2(ByVal dbldx As Double, ByVal dblDensitya As Double, ByVal dblDensity As Double, ByVal dblH As Double, ByVal dblR As Double, ByVal dblu As Double, ByVal dblZ As Double, ByVal stab As String, ByVal Ground As String, ByVal dblu2 As Double) As Double

        'Dim dblutux As Double

        'If stab = "A" Or stab = "B" Or stab = "A-B" Or stab = "B-C" Then
        '    dblutux = 3.0
        'ElseIf stab = "C" Or stab = "D" Or stab = "C-D" Then
        '    dblutux = 2.4
        'ElseIf stab = "E" Or stab = "F" Then
        '    dblutux = 1.6
        'End If
        'Dim dblZ0 As Double
        'If Ground = "草原、平坦开阔地" Then
        '    dblZ0 = 0.1
        'ElseIf Ground = "农作物地区" Then
        '    dblZ0 = 0.2
        'ElseIf Ground = "村落、分散的树林" Then
        '    dblZ0 = 0.65
        'ElseIf Ground = "分散的高矮建筑物(城市)" Then
        '    dblZ0 = 2.5
        'ElseIf Ground = "分散的高矮建筑物(大城市)" Then
        '    dblZ0 = 4
        'End If
        ''求Ls紊流长度
        'Dim dblLs As Double
        'dblLs = 5.88 * dblH ^ 0.48
        'Dim dbluxu As Double
        'dbluxu = 0.4 / Math.Log10(dblZ / dblZ0)

        ''求水平紊流速度
        'Dim dblut As Double
        'dblut = dblutux * dbluxu * dblu
        ''求Ri数
        'Dim dblRi As Double
        'dblRi = Me.m_g * dblLs * (dblDensity - dblDensitya) / dblDensitya * (dblut ^ (-2))
        'Dim dblMa2 As Double
        'dblMa2 = (Me.m_a2 * dblDensitya * 2 * dbldx * dblR * dblut / dblRi) * dbldx / dblu2
        'Return dblMa2

        Dim dblutux As Double

        If stab = "A" Or stab = "B" Or stab = "A-B" Or stab = "B-C" Then
            dblutux = 3.0
        ElseIf stab = "C" Or stab = "D" Or stab = "C-D" Then
            dblutux = 2.4
        ElseIf stab = "E" Or stab = "F" Then
            dblutux = 1.6
        End If
        Dim dblZ0 As Double
        If Ground = "草原、平坦开阔地" Then
            dblZ0 = 0.1
        ElseIf Ground = "农作物地区" Then
            dblZ0 = 0.2
        ElseIf Ground = "村落、分散的树林" Then
            dblZ0 = 0.65
        ElseIf Ground = "分散的高矮建筑物(城市)" Then
            dblZ0 = 2.5
        ElseIf Ground = "分散的高矮建筑物(大城市)" Then
            dblZ0 = 4
        End If
        '求Ls紊流长度
        Dim dblLs As Double
        dblLs = 5.88 * dblH ^ 0.48
        Dim dbluxu As Double
        dbluxu = 0.1

        '求水平紊流速度
        Dim dblut As Double
        dblut = dblutux * dbluxu * dblu
        '求Ri数
        Dim dblRi As Double
        dblRi = Me.m_g * dblLs * (dblDensity - dblDensitya) / dblDensitya * (dblut ^ (-2))
        Dim dblMa2 As Double
        dblMa2 = (Me.m_a2 * dblDensitya * 2 * dbldx * dblR * dblut / dblRi) * dbldx / dblu2
        Return dblMa2

    End Function
    ''' <summary>
    ''' 计算气体温度变化
    ''' </summary>
    ''' <param name="dblCpa">空气的热容</param>
    ''' <param name="dblCpg">泄漏气体的热容</param>
    ''' <param name="dbldMa">卷入空气的质量变化量</param>
    ''' <param name="dblMa">卷入空气的总质量</param>
    ''' <param name="dblMg">气团中原泄漏气体的质量</param>
    ''' <param name="dblTa">空气的温度,K</param>
    ''' <param name="dblT">云团温度,K</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FdT(ByVal dblCpa As Double, ByVal dblCpg As Double, ByVal dbldMa As Double, ByVal dblMa As Double, ByVal dblMg As Double, ByVal dblTa As Double, ByVal dblT As Double) As Double
        Dim dbldQ2 As Double = dbldMa * dblCpa * (dblTa - dblT)
        Dim dbldt As Double = dbldQ2 / ((dblMa + dbldMa) * dblCpa + dblMg * dblCpg)
        Return dbldt
    End Function
    ''' <summary>
    ''' 计算污染物的浓度
    ''' </summary>
    ''' <param name="dblV">气团的体积的截面积,m2</param>
    ''' <param name="dblMg">单位长度内气团内污染物的质量,kg/m</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FC(ByVal dblV As Double, ByVal dblMg As Double) As Double
        Return dblMg * 1000000 / dblV
    End Function

    Public Sub CalHeavy()
        If Me.m_MgS <= 0 Then '泄漏速率为0
            Exit Sub
        End If

        '在计算之前先根据环境压力和温度求出空气的密度和泄漏物质在该温度和压力下的密度------------
        Me.m_Densitya = Me.m_Pa * 298.15 * 29 / (101325 * Me.m_Tempa * 22.4)
        Me.m_Densityg = Me.m_Pa * 298.15 * Me.m_MgMol * 1000 / (101325 * Me.m_Tempa * 22.4)
        If Me.m_Densityg <= Me.m_Densitya Then
            Exit Sub
        End If
        '--------------------------------------------
        Dim dbldx As Double = 0.1 '下风向距离间隔取0.1m
        Dim j As Integer = 0
        Dim dbldL As Double '半宽增加量
        Dim dbldMa1 As Double '某一下风向距离空气从边缘卷入气团的量，kg。比如，本程序划分为0.1m一个梯形，则为这0.1m内的的质量
        Dim dbldMa2 As Double '某一下风向距离空气从顶部卷入气团的量，kg。比如，本程序划分为0.1m一个梯形，则为这0.1m内的的质量
        Dim dbldMa As Double '某一下风向距离空气卷入气团的总空气量，kg。比如，本程序划分为0.1m一个梯形，则为这0.1m内的的质量
        Dim dbldTemp As Double '某一下风向距离由空气卷入带进的温度变化
        '初始化数据
        ReDim Preserve Me.m_slabMetAndMass.slabAirMass(0)
        '将云羽的单位转每一段中的物质的量
        Me.m_slabMetAndMass.Mg = Me.m_MgS / Me.m_slabMetAndMass.u10 * dbldx
        Me.m_slabMetAndMass.slabAirMass(0).m_Ma = Me.m_MaS / Me.m_slabMetAndMass.u10 * dbldx

        Me.m_slabMetAndMass.slabAirMass(0).m_Density = FDensity(Me.m_slabMetAndMass.slabAirMass(0).m_Ma, Me.m_slabMetAndMass.Mg, Me.m_Densitya, Me.m_Densityg, Me.m_Tempa, Me.m_slabMetAndMass.slabAirMass(0).m_Temp)
        Me.m_slabMetAndMass.slabAirMass(0).m_V = (Me.m_slabMetAndMass.slabAirMass(0).m_Ma + Me.m_slabMetAndMass.Mg) / Me.m_slabMetAndMass.slabAirMass(0).m_Density '初始横截面积
        Me.m_slabMetAndMass.slabAirMass(0).m_H = Math.Sqrt(Me.m_slabMetAndMass.slabAirMass(0).m_V / 4) / dbldx
        Me.m_slabMetAndMass.slabAirMass(0).m_L = Me.m_slabMetAndMass.slabAirMass(0).m_H * 2
        Me.m_slabMetAndMass.slabAirMass(0).m_C = FC(Me.m_slabMetAndMass.slabAirMass(0).m_V, Me.m_slabMetAndMass.Mg) '浓度

        j = 0
        Do
            ReDim Preserve Me.m_slabMetAndMass.slabAirMass(Me.m_slabMetAndMass.slabAirMass.Length)
            Me.m_slabMetAndMass.slabAirMass(Me.m_slabMetAndMass.slabAirMass.Length - 1) = New SlabAirMass
            '云羽半宽的增加量
            dbldL = FdL(dbldx, Me.m_slabMetAndMass.slabAirMass(j).m_H, Me.m_slabMetAndMass.slabAirMass(j).m_Density, Me.m_Densitya, Me.m_slabMetAndMass.u10)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_L = Me.m_slabMetAndMass.slabAirMass(j).m_L + dbldL
            '空气从边缘卷入气团的增加量
            dbldMa1 = FdMa1(dbldx, Me.m_Densitya, Me.m_slabMetAndMass.slabAirMass(j).m_H, Me.m_slabMetAndMass.slabAirMass(j).m_L, dbldL)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma1 = Me.m_slabMetAndMass.slabAirMass(j).m_Ma1 + dbldMa1 '每隔0.1米的增加量
            '空气从顶部卷入气团的增加量，每隔0.1m的增加量
            dbldMa2 = fdMa2(dbldx, Me.m_Densitya, Me.m_slabMetAndMass.slabAirMass(j).m_Density, Me.m_slabMetAndMass.slabAirMass(j).m_H, Me.m_slabMetAndMass.slabAirMass(j).m_L, Me.m_slabMetAndMass.u10, Me.m_Z, Me.m_slabMetAndMass.stab, Me.m_Ground, Me.m_slabMetAndMass.u10)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma2 = Me.m_slabMetAndMass.slabAirMass(j).m_Ma2 + dbldMa2
            '空气进入的总的增加量，每隔0.1m的增加量
            dbldMa = dbldMa1 + dbldMa2
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma = Me.m_slabMetAndMass.slabAirMass(j).m_Ma + dbldMa
            '云团的温度变化
            dbldTemp = FdT(Me.m_Cpa, Me.m_Cpg, dbldMa, Me.m_slabMetAndMass.slabAirMass(j).m_Ma, Me.m_slabMetAndMass.Mg, Me.m_Tempa, Me.m_slabMetAndMass.slabAirMass(j).m_Temp)
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Temp = Me.m_slabMetAndMass.slabAirMass(j).m_Temp + dbldTemp
            '云团的密度
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_Density = FDensity(Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma, Me.m_slabMetAndMass.Mg, Me.m_Densitya, Me.m_Densityg, Me.m_Tempa, Me.m_slabMetAndMass.slabAirMass(j + 1).m_Temp)
            '云团的体积
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_V = (Me.m_slabMetAndMass.slabAirMass(j + 1).m_Ma + Me.m_slabMetAndMass.Mg) / Me.m_slabMetAndMass.slabAirMass(j + 1).m_Density
            '云团的高度
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_H = Me.m_slabMetAndMass.slabAirMass(j + 1).m_V / ((Me.m_slabMetAndMass.slabAirMass(j + 1).m_L + Me.m_slabMetAndMass.slabAirMass(j).m_L) * dbldx)
            '云团的扩散的距离
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_x = Me.m_slabMetAndMass.slabAirMass(j).m_x + dbldx
            '云团中污染物的浓度
            Me.m_slabMetAndMass.slabAirMass(j + 1).m_C = FC(Me.m_slabMetAndMass.slabAirMass(j + 1).m_V, Me.m_slabMetAndMass.Mg)
            Dim dh As Double = Me.m_slabMetAndMass.slabAirMass(j + 1).m_H - Me.m_slabMetAndMass.slabAirMass(j).m_H
            If (Me.m_slabMetAndMass.slabAirMass(j + 1).m_Density - Me.m_Densitya) / Me.m_Densitya < 0.001 Then
                Exit Do
            End If
            j = j + 1
        Loop
        '初始化计算参数

    End Sub
#End Region
End Class
