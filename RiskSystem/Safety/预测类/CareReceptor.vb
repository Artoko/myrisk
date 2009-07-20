''' <summary>
''' 预测点类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class CareReceptor
    Private m_Name As String = "" '预测点名称
    Private m_Point3D As Point3D '预测点的坐标
    ''' <summary>
    ''' 预测点的名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name() As String
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 预测点的坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Point3D() As Point3D
        Get
            Return Me.m_Point3D
        End Get
        Set(ByVal value As Point3D)
            Me.m_Point3D = value
        End Set
    End Property
End Class
