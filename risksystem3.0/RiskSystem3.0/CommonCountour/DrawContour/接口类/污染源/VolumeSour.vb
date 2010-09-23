''' <summary>
''' 体源
''' </summary>
''' <remarks></remarks>
Public Class VolumeSour
    Inherits BaseSourClass
    ''' <summary>
    ''' 体源的宽度。体源的长度和宽度是一样的，因此同时也表示了体源的长度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Width As Double
    ''' <summary>
    ''' 体源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Thickness As Double


    ''' <summary>
    ''' 体源的宽度。体源的长度和宽度是一样的，因此同时也表示了体源的长度
    ''' </summary>
    ''' <remarks></remarks>
    Property Width() As Double
        Get
            Return Me.m_Width
        End Get
        Set(ByVal value As Double)
            Me.m_Width = value
        End Set
    End Property
    ''' <summary>
    ''' 体源的厚度
    ''' </summary>
    ''' <remarks></remarks>
    Property Thickness() As Double
        Get
            Return Me.m_Thickness
        End Get
        Set(ByVal value As Double)
            Me.m_Thickness = value
        End Set
    End Property

End Class
