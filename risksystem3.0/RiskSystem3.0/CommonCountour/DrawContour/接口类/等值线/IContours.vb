''' <summary>
''' 等值类
''' </summary>
''' <remarks></remarks>
Public Class IContours
    Private m_ArrayIContours(-1) As IContour
    ''' <summary>
    ''' 等值线数组 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ArrayIContours() As IContour()
        Get
            Return Me.m_ArrayIContours
        End Get
        Set(ByVal value As IContour())
            Me.m_ArrayIContours = value
        End Set
    End Property
End Class
