''' <summary>
''' 物化数据类。这个类主要用于储存物质的名称、物化性质及属性等，同时根据设置的数据，提供相应的蒸气压等数据给其它对象
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Chemical
    ''' <summary>
    ''' 物质名称
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Name0 As String = "氯"
    ''' <summary>
    ''' 摩尔质量M[kg/mol]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakM As Double = 0.07091
    ''' <summary>
    ''' 液体密度ρl[kg/m^3]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakLiquidPl As Double = 1470
    ''' <summary>
    ''' 蒸气密度ρg[kg/m^3]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Pg As Double = 3.20664
    ''' <summary>
    ''' 液体常压沸点 Tb[℃]
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakEvaporationTb As Double = -34.5
    ''' <summary>
    ''' 液体定压比热容
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakLiquidCP As Double = 960 '
    ''' <summary>
    ''' 液体气化热
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakLiquidH As Double = 289000
    ''' <summary>
    ''' 气体绝热指数
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LeakGasK As Double = 1.3244
    ''' <summary>
    ''' 概率函数的参数A
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PrA As Double = -5.3

    Private m_PrB As Double = 0.5

    Private m_Prn As Double = 2.75

    Private m_AntoineA As Double = 4.28814
    Private m_AntoineB As Double = 969.992
    Private m_AntoineC As Double = -12.791
    ''' <summary>
    ''' 气体定压比热
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Cpg As Double = 479
    ''' <summary>
    ''' 气体绝热指数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakGasK() As Double
        Get
            Return Me.m_LeakGasK
        End Get
        Set(ByVal value As Double)
            Me.m_LeakGasK = value
        End Set
    End Property
    ''' <summary>
    ''' 摩尔质量M[kg/mol]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakM() As Double
        Get
            Return Me.m_LeakM
        End Get
        Set(ByVal value As Double)
            Me.m_LeakM = value
        End Set
    End Property
    ''' <summary>
    ''' 液体密度ρl[kg/m^3]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakLiquidPl() As Double
        Get
            Return Me.m_LeakLiquidPl
        End Get
        Set(ByVal value As Double)
            Me.m_LeakLiquidPl = value
        End Set
    End Property
    ''' <summary>
    ''' 蒸气密度ρg[kg/m^3]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Pg() As Double
        Get
            Return Me.m_Pg
        End Get
        Set(ByVal value As Double)
            Me.m_Pg = value
        End Set
    End Property
    ''' <summary>
    ''' 液体常压沸点 Tb[℃]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LeakEvaporationTb() As Double
        Get
            Return Me.m_LeakEvaporationTb
        End Get
        Set(ByVal value As Double)
            Me.m_LeakEvaporationTb = value
        End Set
    End Property

    ''' <summary>
    ''' 液体定压比热容
    ''' </summary>
    ''' <remarks></remarks>
    Property LeakLiquidCP() As Double '
        Get
            Return m_LeakLiquidCP
        End Get
        Set(ByVal value As Double)
            m_LeakLiquidCP = value
        End Set
    End Property
    ''' <summary>
    ''' 液体气化热
    ''' </summary>
    ''' <remarks></remarks>
    Property LeakLiquidH() As Double
        Get
            Return Me.m_LeakLiquidH
        End Get
        Set(ByVal value As Double)
            Me.m_LeakLiquidH = value
        End Set
    End Property
    ''' <summary>
    '''物质名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name0() As String
        Get
            Return Me.m_Name0
        End Get
        Set(ByVal value As String)
            Me.m_Name0 = value
        End Set
    End Property
    ''' <summary>
    ''' 概率函数的参数A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PrA() As Double
        Get
            Return Me.m_PrA
        End Get
        Set(ByVal value As Double)
            Me.m_PrA = value
        End Set
    End Property
    ''' <summary>
    ''' 概率函数的参数B
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PrB() As Double
        Get
            Return Me.m_PrB
        End Get
        Set(ByVal value As Double)
            Me.m_PrB = value
        End Set
    End Property
    ''' <summary>
    ''' 概率函数的参数C
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Prn() As Double
        Get
            Return Me.m_Prn
        End Get
        Set(ByVal value As Double)
            Me.m_Prn = value
        End Set
    End Property
   
    Property AntoineA() As Double
        Get
            Return m_AntoineA
        End Get
        Set(ByVal value As Double)
            m_AntoineA = value
        End Set
    End Property
    Property AntoineB() As Double
        Get
            Return m_AntoineB
        End Get
        Set(ByVal value As Double)
            m_AntoineB = value
        End Set
    End Property
    Property AntoineC() As Double
        Get
            Return m_AntoineC
        End Get
        Set(ByVal value As Double)
            m_AntoineC = value
        End Set
    End Property
    ''' <summary>
    ''' 气体的定压比热
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Cpg() As Double
        Get
            Return m_Cpg
        End Get
        Set(ByVal value As Double)
            m_Cpg = value
        End Set
    End Property
    ''' <summary>
    ''' 根据用户输入的温度来计算相应的压力
    ''' </summary>
    ''' <param name="T">温度，K</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetP(ByVal T As Double) As Integer
        If m_AntoineA <> 0 And m_AntoineB <> 0 And m_AntoineC <> 0 Then
            Return (10 ^ (m_AntoineA - (m_AntoineB / (T + m_AntoineC)))) * 100000
        Else
            Return 0
        End If

    End Function

End Class
