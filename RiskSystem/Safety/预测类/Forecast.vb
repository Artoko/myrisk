﻿<Serializable()> Public Class Forecast
#Region "属性"
   
   
    Private m_Vane As New Vane '下风向类
    Private m_Grid As New Grid '预测网格
    Private m_Met(0 To 0) As Met '气象条件数组
    
    Private m_Ta As Double = 16 '环境温度，摄氏度
    Private m_Pa As Double = 101325 '大气压力,Pa
    Private m_HurtConcentration(0 To 1) As HurtConcentration '伤害浓度
    Private m_CareReceptor(-1) As CareReceptor '关心点数组

    Private m_OutPut As New OutPut '输出控制选项

    
    ''' <summary>
    ''' 下风向类
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Vane() As Vane
        Get
            Return Me.m_Vane
        End Get
        Set(ByVal value As Vane)
            Me.m_Vane = value
        End Set
    End Property

    ''' <summary>
    ''' 气象条件数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Met() As Met()
        Get
            Return Me.m_Met

        End Get
        Set(ByVal value As Met())
            Me.m_Met = value
        End Set
    End Property
   
    ''' <summary>
    ''' 环境温度，摄氏度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Ta() As Double
        Get
            Return Me.m_Ta
        End Get
        Set(ByVal value As Double)
            Me.m_Ta = value
        End Set
    End Property
    ''' <summary>
    ''' 大气压力,Pa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
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
    ''' 伤害浓度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HurtConcentration() As HurtConcentration()
        Get
            Return Me.m_HurtConcentration
        End Get
        Set(ByVal value As HurtConcentration())
            Me.m_HurtConcentration = value
        End Set
    End Property
    
    ''' <summary>
    ''' 关心点数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CareReceptor() As CareReceptor()
        Get
            Return Me.m_CareReceptor
        End Get
        Set(ByVal value As CareReceptor())
            Me.m_CareReceptor = value
        End Set
    End Property
    ''' <summary>
    ''' 预测网格对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Grid() As Grid
        Get
            Return Me.m_Grid
        End Get
        Set(ByVal value As Grid)
            Me.m_Grid = value
        End Set
    End Property
    ''' <summary>
    ''' 输出控制选项
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OutPut() As OutPut
        Get
            Return m_OutPut
        End Get
        Set(ByVal value As OutPut)
            m_OutPut = value
        End Set
    End Property

#End Region
#Region "方法"
    Public Sub New()
        ReDim Me.m_Met(0 To 1)
        Me.m_Met(0) = New Met
        Me.m_Met(0).Vane = "N"
        Me.m_Met(0).WindSpeed = 1.8
        Me.m_Met(0).Stab = "D"

        Me.m_Met(1) = New Met
        Me.m_Met(1).Vane = "N"
        Me.m_Met(1).WindSpeed = 2.4
        Me.m_Met(1).Stab = "E"



        ReDim Me.m_HurtConcentration(0 To 1)
        For i As Integer = 0 To Me.m_HurtConcentration.Length - 1
            Me.m_HurtConcentration(i) = New HurtConcentration
        Next
        Me.m_HurtConcentration(0).Name = "半致死浓度LC(50)"
        Me.m_HurtConcentration(0).ConcentrationVale = 1390

        Me.m_HurtConcentration(1).Name = "短时间接触允许浓度限值"
        Me.m_HurtConcentration(1).ConcentrationVale = 30

    End Sub
#End Region
End Class
