''' <summary>
''' 绘图接口类
''' </summary>
''' <remarks></remarks>
Public Class InterfacePannel
    Private m_Sources As New Sources
    Private m_Receptor As New Receptor

    ''' <summary>
    ''' 污染源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sources() As Sources
        Get
            Return Me.m_Sources
        End Get
        Set(ByVal value As Sources)
            Me.m_Sources = value
        End Set
    End Property
    ''' <summary>
    ''' 关心点和网格
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Receptor() As Receptor
        Get
            Return Me.m_Receptor
        End Get
        Set(ByVal value As Receptor)
            Me.m_Receptor = value
        End Set
    End Property

    Public Property IContours() As IContours
        Get

        End Get
        Set(ByVal value As IContours)

        End Set
    End Property
End Class
