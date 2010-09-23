Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
''' <summary>
''' �����ı��࣬�ṩ�����ı��ķ���
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class PaintText
    Private mVisible As Boolean = True  '��־�����ֿɼ�
    Protected mPosition As PointF '�����ı���λ��
    Private mColor As Color = Color.Black '�ֵ���ɫ
    Private mName As String '��־������
    Protected mAngle As Integer = 0 '��־���ƵĽǶȣ�0-360��
    <NonSerialized()> Protected mfontFamily As New FontFamily(New GenericFontFamilies) '�������ʽ
    Public mFont As New Font(mfontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel) '����

    ''' <summary>
    ''' �ı��Ƿ�ɼ�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Visible() As Boolean
        Get
            Return mVisible
        End Get
        Set(ByVal value As Boolean)
            mVisible = value
        End Set
    End Property
    Public Property Color() As Color
        Get
            Return mColor
        End Get
        Set(ByVal value As Color)
            mColor = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property


    Public Sub DrawText(ByVal grap As Graphics)
        PannelSetting.gAxisTitleRect = PannelSetting.gAxisLabelRect '������������������ڻ��ƿ̶��߱�ע������
        '���ݲ�ͬ��������ߣ����ò�ͬ�����ֵ����Сֵ
        Dim SymbolBrush As New SolidBrush(mColor) '
        If mVisible Then '�����־�����ֿɼ��ͻ��Ʊ�־��־������
            Dim mFormat As New StringFormat(New StringAlignment().Near) '�ַ��Ķ��뷽ʽ

            Dim myMatrix As New Matrix()
            Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
            graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
            myMatrix.Translate(mPosition.X, mPosition.Y) 'ƽ�Ƶ����ֵ�
            myMatrix.Rotate(mAngle)
            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
            grap.Transform = myMatrix
            grap.DrawString(mName, mFont, SymbolBrush, 0, 0, mFormat)
            grap.EndContainer(graphicsContainer) '�˳���ͼ����
        End If
    End Sub
End Class
