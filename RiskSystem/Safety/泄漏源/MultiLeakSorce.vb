
<Serializable()> Public Class MultiLeakSorce
    ''' <summary>
    ''' й©��������
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' й©���������ʣ���λmg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public Q As Double
    ''' <summary>
    ''' �ŷų���ʱ�䣬��λs
    ''' </summary>
    ''' <remarks></remarks>
    Public DurationTime As Double
    ''' <summary>
    ''' �ŷ��¶ȣ����϶�
    ''' </summary>
    ''' <remarks></remarks>
    Public Ts As Double
    ''' <summary>
    ''' й©Դ��Ч�ŷŸ߶ȣ�m
    ''' </summary>
    ''' <remarks></remarks>
    Public He As Double
    ''' <summary>
    ''' �ŷŸ߶�
    ''' </summary>
    ''' <remarks></remarks>
    Public H As Double
    ''' <summary>
    ''' ����̧���߶ȣ�m
    ''' </summary>
    ''' <remarks></remarks>
    Public DH As Double
    ''' <summary>
    ''' ��������m3/s
    ''' </summary>
    ''' <remarks></remarks>
    Public Qv As Double
    ''' <summary>
    ''' �ŷſ�ֱ����m3/s
    ''' </summary>
    ''' <remarks></remarks>
    Public D As Double
    ''' <summary>
    ''' ���ŵĸ���
    ''' </summary>
    ''' <remarks></remarks>
    Public n As Integer
    ''' <summary>
    ''' й©���ʣ�kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V()
    ''' <summary>
    ''' й©�������� kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V1() As Double
    ''' <summary>
    ''' �������������� kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V2() As Double
    ''' <summary>
    ''' �������������� kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V3() As Double
    ''' <summary>
    ''' Һ������������ kg/s
    ''' </summary>
    ''' <remarks></remarks>
    Public V4() As Double
    ''' <summary>
    ''' й©����ʱ��
    ''' </summary>
    ''' <remarks></remarks>
    Public QpAllT As Double
    ''' <summary>
    ''' ��������ʱ��
    ''' </summary>
    ''' <remarks></remarks>
    Public QsAllT As Double
    ''' <summary>
    ''' й©������
    ''' </summary>
    ''' <remarks></remarks>
    Public QpAll As Double
    ''' <summary>
    ''' ����������
    ''' </summary>
    ''' <remarks></remarks>
    Public QsAll As Double
    ''' <summary>
    ''' ������ mg
    ''' </summary>
    ''' <remarks></remarks>
    Public Qi() As Double
    ''' <summary>
    ''' ��Դ����Դ�ĵ����
    ''' </summary>
    ''' <remarks></remarks>
    Public Si() As Double
    Public Thickness() As Double
    ''' <summary>
    ''' ����������͡�0��ʾ˲ʱ�����壬1��ʾ���������壬-1��ʾ����������
    ''' </summary>
    ''' <remarks></remarks>
    Public HeavyType As Integer = -1

    Public Sub ResetMulti(ByVal nCount As Integer)
        n = nCount
        ReDim V(0 To n)
        ReDim V1(0 To n)
        ReDim V2(0 To n)
        ReDim V3(0 To n)
        ReDim V4(0 To n)
        ReDim Qi(0 To n)
        ReDim Si(0 To n)
        ReDim Thickness(0 To n)
    End Sub
End Class
