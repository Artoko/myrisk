''' <summary>
''' 接受点和网格类
''' </summary>
''' <remarks></remarks>
Public Class Receptor
    Private m_GridCart As New GridCart
    Private m_ArrayDiscCarts(-1) As DiscCart '离散点数组
    ''' <summary>
    ''' 网格
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridCart() As GridCart
        Get
            Return Me.m_GridCart
        End Get
        Set(ByVal value As GridCart)
            Me.m_GridCart = value
        End Set
    End Property
    ''' <summary>
    ''' 离散点数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ArrayDiscCarts() As DiscCart()
        Get
            Return Me.m_ArrayDiscCarts
        End Get
        Set(ByVal value As DiscCart())
            Me.m_ArrayDiscCarts = value
        End Set
    End Property
End Class
