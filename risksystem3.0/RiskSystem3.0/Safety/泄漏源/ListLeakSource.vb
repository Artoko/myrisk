Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
''' <summary>
''' 管理事故泄漏源的类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class ListLeakSource
    ''' <summary>
    ''' 表示污染源的计数器，防止污染源ID出现重复编号
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceIndex As Integer

    ''' <summary>
    ''' 事故泄漏初始对象。这个对象是最初的泄漏源
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IntialSource As New List(Of IntialSource)


    ''' <summary>
    ''' 表示污染源的计数器，防止污染源ID出现重复编号
    ''' </summary>
    ''' <remarks></remarks>
    Property SourceIndex As Integer
        Get
            Return Me.m_SourceIndex
        End Get
        Set(ByVal value As Integer)
            Me.m_SourceIndex = value
        End Set
    End Property


    ''' <summary>
    ''' 事故泄漏初始对象集合。即多个事故泄漏源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IntialSource() As List(Of IntialSource)
        Get
            Return m_IntialSource
        End Get
        Set(ByVal value As List(Of IntialSource))
            m_IntialSource = value
        End Set
    End Property
End Class
