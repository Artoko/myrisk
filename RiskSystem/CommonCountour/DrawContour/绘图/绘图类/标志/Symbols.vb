''' <summary>
''' ��־�࣬���ڻ�����ȾԴ��־�����ĵ��־��
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Symbols
    Private mPolluteSymbols As New PolluteSymbols
    Private mCareSymbols As New CareSymbols
    Private m_BuildingSymbols As New BuildingSymbols

    ''' <summary>
    ''' ��ȾԴ��־
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PolluteSymbol() As PolluteSymbols
        Get
            Return mPolluteSymbols
        End Get
        Set(ByVal value As PolluteSymbols)
            mPolluteSymbols = value
        End Set
    End Property

    Public Property CareSymbols() As CareSymbols
        Get
            Return mCareSymbols
        End Get
        Set(ByVal value As CareSymbols)
            mCareSymbols = value
        End Set
    End Property
    ''' <summary>
    ''' �������־
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BuildingSymbols() As BuildingSymbols
        Get
            Return Me.m_BuildingSymbols
        End Get
        Set(ByVal value As BuildingSymbols)
            Me.m_BuildingSymbols = value
        End Set
    End Property

    Public Sub DrawSymbols(ByVal grap)
        mPolluteSymbols.DrawPolluteSymbos(grap) '��ȾԴ
        mCareSymbols.DrawCareSymbols(grap) '���ĵ�
        m_BuildingSymbols.DrawBuildingSymbols(grap) '������
    End Sub

End Class
