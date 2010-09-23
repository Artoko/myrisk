''' <summary>
''' ��ȾԴ��־��
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PolluteSymbols
    Private m_Symbol As New Symbol '�����ı�־


    Private m_PointSourceSymbols As New SourceSymbols
    Private m_AreaSourceSymbols As New SourceSymbols
    Private m_AreaPolySource As New SourceSymbols
    Private m_AreaCircleSource As New SourceSymbols
    Private m_OpenPitSource As New SourceSymbols
    Private m_VolumeSourceOption As New SourceSymbols
    Private m_LineSourceOption As New SourceSymbols
    ''' <summary>
    ''' ��������ȾԴ��־�����ڿؼ����е�Դ�ı�־
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Symbol() As Symbol
        Get
            Return m_Symbol
        End Get
        Set(ByVal value As Symbol)
            m_Symbol = value
        End Set
    End Property


    ''' <summary>
    ''' ��Դ��־
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PointSourceSymbols() As SourceSymbols
        Get
            Return Me.m_PointSourceSymbols
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_PointSourceSymbols = value
        End Set
    End Property
    ''' <summary>
    ''' ������Դ��־
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AreaSourceSymbols() As SourceSymbols
        Get
            Return Me.m_AreaSourceSymbols
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_AreaSourceSymbols = value
        End Set
    End Property
    ''' <summary>
    ''' �������Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AreaPolySource() As SourceSymbols
        Get
            Return Me.m_AreaPolySource
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_AreaPolySource = value
        End Set
    End Property
    ''' <summary>
    ''' Բ����Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AreaCircleSource() As SourceSymbols
        Get
            Return Me.m_AreaCircleSource
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_AreaCircleSource = value
        End Set
    End Property
    ''' <summary>
    ''' ����Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OpenPitSource() As SourceSymbols
        Get
            Return Me.m_OpenPitSource
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_OpenPitSource = value
        End Set
    End Property
    ''' <summary>
    ''' ��Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property VolumeSourceOption() As SourceSymbols
        Get
            Return Me.m_VolumeSourceOption
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_VolumeSourceOption = value
        End Set
    End Property
    ''' <summary>
    ''' ��Դ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LineSourceOption() As SourceSymbols
        Get
            Return Me.m_LineSourceOption
        End Get
        Set(ByVal value As SourceSymbols)
            Me.m_LineSourceOption = value
        End Set
    End Property

    Public Function SourceCount() As Integer
        Return m_PointSourceSymbols.ArrayPointSourceNameAndPoints.Length _
            + m_AreaSourceSymbols.ArrayPointSourceNameAndPoints.Length _
            + m_AreaPolySource.ArrayPointSourceNameAndPoints.Length _
            + m_AreaCircleSource.ArrayPointSourceNameAndPoints.Length _
            + m_OpenPitSource.ArrayPointSourceNameAndPoints.Length _
            + m_VolumeSourceOption.ArrayPointSourceNameAndPoints.Length _
            + m_LineSourceOption.ArrayPointSourceNameAndPoints.Length
    End Function

    Public Sub DrawPolluteSymbos(ByVal grap As Graphics)
        PointSourceSymbols.DrawPolluteSymbols(grap, m_Symbol) '���Ƶ�Դ
        AreaSourceSymbols.DrawPolluteSymbols(grap, m_Symbol) '���ƾ�����Դ
        AreaPolySource.DrawPolluteSymbols(grap, m_Symbol) '���ƶ������Դ
        AreaCircleSource.DrawPolluteSymbols(grap, m_Symbol) 'Բ����Դ
        OpenPitSource.DrawPolluteSymbols(grap, m_Symbol) '����Դ
        VolumeSourceOption.DrawPolluteSymbols(grap, m_Symbol) '��Դ
        LineSourceOption.DrawPolluteSymbols(grap, m_Symbol) '��Դ
    End Sub

End Class
