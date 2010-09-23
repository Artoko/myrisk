''' <summary>
''' 点源
''' </summary>
''' <remarks></remarks>
Public Class PointSour
    Inherits BaseSourClass
    ''' <summary>
    ''' 烟囱的出口内径
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Diameter As Double
    ''' <summary>
    ''' 烟囱的出口内径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Diameter() As Double
        Get
            Return Me.m_Diameter
        End Get
        Set(ByVal value As Double)
            Me.m_Diameter = value
        End Set
    End Property
End Class
