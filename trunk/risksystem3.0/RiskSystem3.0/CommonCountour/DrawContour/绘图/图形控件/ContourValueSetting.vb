<Serializable()> Public Class ContourValueSetting
    Implements ICloneable


    ' 等值线属性-------------------------------------
    Public ContourNames(-1) As String '等值线的名称
    Public ContourValue(-1) As Double '等值线的值
    Private m_ContourValueType As Boolean = 0
    Private m_ContourMin As Double '最小值
    Private m_ContourMax As Double '最大值
    Private m_ContourIntel As Double '间距
    ''' <summary>
    ''' 表示设置等值线的方式。0表时等间距，1表示自定义
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ContourValueType() As Integer
        Get
            Return m_ContourValueType
        End Get
        Set(ByVal value As Integer)
            m_ContourValueType = value
        End Set
    End Property

    ''' <summary>
    ''' 最小值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContourMin() As Double
        Get
            Return m_ContourMin
        End Get
    End Property
    ''' <summary>
    ''' 最大值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContourMax() As Double
        Get
            Return m_ContourMax
        End Get
    End Property
    ''' <summary>
    ''' 间距
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContourIntel() As Double
        Get
            Return m_ContourIntel
        End Get
    End Property

    Public Sub SetContourValue(ByVal min As Double, ByVal max As Double, ByVal intel As Double)
        Me.m_ContourMin = min
        Me.m_ContourMax = max
        Me.m_ContourIntel = intel
        ''判断是否是合法
        'If Me.m_ContourMax - Me.m_ContourMin < 0 Then
        '    MessageBox.Show("最大值应大于最小值!请调整。")
        '    Exit Sub
        'End If

        For i As Integer = 0 To Math.Truncate((Me.m_ContourMax - m_ContourMin) / m_ContourIntel)
            ReDim Preserve ContourNames(i)
            ReDim Preserve ContourValue(i)
            ContourNames(i) = m_ContourMin + i * m_ContourIntel
            ContourValue(i) = m_ContourMin + i * m_ContourIntel
        Next
        If ContourValue(ContourValue.Length - 1) < m_ContourMax Then
            ReDim Preserve ContourNames(ContourNames.Length)
            ReDim Preserve ContourValue(ContourValue.Length)
            ContourNames(ContourNames.Length - 1) = m_ContourMax
            ContourValue(ContourValue.Length - 1) = m_ContourMax
        End If
    End Sub



    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim obj As New ContourValueSetting
        ReDim obj.ContourNames(Me.ContourNames.Length - 1)
        For i As Integer = 0 To Me.ContourNames.Length - 1
            obj.ContourNames(i) = Me.ContourNames(i)
        Next
        ReDim obj.ContourValue(Me.ContourValue.Length - 1)
        For i As Integer = 0 To Me.ContourValue.Length - 1
            obj.ContourValue(i) = Me.ContourValue(i)
        Next
        obj.m_ContourValueType = Me.m_ContourValueType
        obj.m_ContourMin = Me.m_ContourMin
        obj.m_ContourMax = Me.m_ContourMax
        obj.m_ContourIntel = Me.m_ContourIntel
        Return obj
    End Function
End Class
