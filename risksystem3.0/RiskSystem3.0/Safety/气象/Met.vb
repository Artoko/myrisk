﻿''' <summary>
''' 气象条件类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Met
    Implements ICloneable

    ''' <summary>
    ''' 时间
    ''' </summary>
    ''' <remarks></remarks>
    Public m_DateTime As DateTime '日期
    Private m_WindType As Integer = 0 '风的类型。0
    Private m_WindDer As Double '风向度
    Private m_Vane As String  '风向
    Private m_Wind_Speed As Double '10米处的风速,m/s
    Private m_Stab As String '稳定度
    Private m_Frequency As Double = 0.01 '该气象的频率
    Private m_u2 As Double '泄漏口高度处风速
    Private m_U_Ground As Double '声明地面风速，因为在热量蒸发模型中用到
    Property WindDer() As Double '风向度
        Get
            Return Me.m_WindDer
        End Get
        Set(ByVal value As Double)
            Me.m_WindDer = value
        End Set
    End Property
    ''' <summary>
    ''' 风的类型。0表示用字符来表示，1表示用度数来表示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WindType() As Integer
        Get
            Return Me.m_WindType
        End Get
        Set(ByVal value As Integer)
            Me.m_WindType = value
        End Set
    End Property

    ''' <summary>
    ''' 风向
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Vane() As String
        Get
            Return Me.m_Vane
        End Get
        Set(ByVal value As String)
            Me.m_Vane = value
        End Set
    End Property
    ''' <summary>
    ''' 风速,m/s
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WindSpeed() As Double
        Get
            Return Me.m_Wind_Speed
        End Get
        Set(ByVal value As Double)
            Me.m_Wind_Speed = value
        End Set
    End Property
    ''' <summary>
    ''' 稳定度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Stab() As String
        Get
            Return Me.m_Stab
        End Get
        Set(ByVal value As String)
            Me.m_Stab = value
        End Set
    End Property
    ''' <summary>
    ''' 该气象的频率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Frequency() As Double '
        Get
            Return m_Frequency
        End Get
        Set(ByVal value As Double)
            m_Frequency = value
        End Set
    End Property
    ''' <summary>
    ''' 泄漏口高度处风速
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property u2() As Double '
        Get
            Return Me.m_u2
        End Get
        Set(ByVal value As Double)
            Me.m_u2 = value
        End Set
    End Property
    ''' <summary>
    ''' 声明地面风速，因为在热量蒸发模型中用到
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property U_Ground() As Double '
        Get
            Return Me.m_U_Ground
        End Get
        Set(ByVal value As Double)
            Me.m_U_Ground = value
        End Set
    End Property

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim objCopy As New Met()
        objCopy.m_DateTime = Me.m_DateTime '日期
        objCopy.m_WindType = Me.m_WindType '风的类型。0
        objCopy.m_WindDer = Me.m_WindDer  '风向度
        objCopy.m_Vane = Me.m_Vane   '风向
        objCopy.m_Wind_Speed = Me.m_Wind_Speed  '风速,m/s
        objCopy.m_Stab = Me.m_Stab  '稳定度
        objCopy.m_Frequency = Me.m_Frequency  '该气象的频率
        objCopy.m_u2 = Me.m_u2 '泄漏口高度处风速
        objCopy.m_U_Ground = Me.m_U_Ground  '声明地面风速，因为在热量蒸发模型中用到
        Return objCopy
    End Function
End Class
