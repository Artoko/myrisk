<Serializable()> Public Class AllHeavy
   
    ''' <summary>
    ''' Boxģ��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_BoxHeavy As New BoxHeavy
    ''' <summary>
    ''' Slabģ��
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SlabHeavy As New SlabHeavy

    ''' <summary>
    ''' Boxģ��
    ''' </summary>
    ''' <remarks></remarks>
    Property BoxHeavy() As BoxHeavy
        Get
            Return Me.m_BoxHeavy
        End Get
        Set(ByVal value As BoxHeavy)
            Me.m_BoxHeavy = value
        End Set
    End Property
    ''' <summary>
    ''' Slabģ��
    ''' </summary>
    ''' <remarks></remarks>
    Property SlabHeavy() As SlabHeavy
        Get
            Return Me.m_SlabHeavy
        End Get
        Set(ByVal value As SlabHeavy)
            Me.m_SlabHeavy = value
        End Set
    End Property
End Class
