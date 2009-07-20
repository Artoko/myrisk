Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class Pannel
    Private AxesValue As New Axes '������
    Private BackImageValue As New BackImage '����ͼ
    Private m_PlanImage As New BackImage 'ƽ��ͼ
    Private ContoursValue As New Contours  '��ֵ���࣬���ڻ��Ƶ�ֵ��
    Private mSymbols As New Symbols '��־��ļ��ϣ����ڻ�����ȾԴ��־�����ĵ��־��
    Private mLegend As New Legend 'ͼ��
    Private m_PannelSeting As New PannelSettingClass  '�������õ�ǰ��ͼ������ȹ�������

    ''' <summary>
    ''' ƽ��ͼ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Axes() As Axes
        Get
            Return AxesValue
        End Get
        Set(ByVal value As Axes)
            AxesValue = value
        End Set
    End Property
    ''' <summary>
    ''' ����ͼ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BackImage() As BackImage
        Get
            Return BackImageValue
        End Get
        Set(ByVal value As BackImage)
            BackImageValue = value
        End Set
    End Property

    Public Property Contours() As Contours
        Get
            Return ContoursValue
        End Get
        Set(ByVal value As Contours)
            ContoursValue = value
        End Set
    End Property

    Public Property Symbols() As Symbols
        Get
            Return mSymbols
        End Get
        Set(ByVal value As Symbols)
            mSymbols = value
        End Set
    End Property

    Public Property Legend() As Legend
        Get
            Return mLegend
        End Get
        Set(ByVal value As Legend)
            mLegend = value
        End Set
    End Property
    ''' <summary>
    ''' ƽ��ͼ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PlanImage() As BackImage
        Get
            Return Me.m_PlanImage
        End Get
        Set(ByVal value As BackImage)
            Me.m_PlanImage = value
        End Set
    End Property
    ''' <summary>
    ''' �������õ�ǰ��ͼ������ȹ�������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PannelSeting() As PannelSettingClass
        Get
            Return Me.m_PannelSeting
        End Get
        Set(ByVal value As PannelSettingClass)
            m_PannelSeting = value
        End Set
    End Property

    Public Sub DrawPannel(ByVal grap As Graphics)
        ''����任
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
        grap.Transform = myMatrix
        BackImageValue.DrawImage(grap) '���Ʊ���ͼ
        Me.m_PlanImage.DrawImage(grap) '����ƽ��ͼ
        ContoursValue.DrawContours(grap) '���Ƶ�ֵ��
        AxesValue.DrawAxes(grap) '��������
        mSymbols.DrawSymbols(grap) '���Ʊ�־
        mLegend.DrawLegend(grap, ContoursValue, mSymbols) '����ͼ��
        DrawTR(grap)
        grap.EndContainer(graphicsContainer)
        PannelSetting.PreScale = PannelSetting.gScale '��ֵ��ǰһ��ֵ
    End Sub
    Private Sub DrawTR(ByVal grap As Graphics)
        Dim fontFamily As New FontFamily(New GenericFontFamilies)
        Dim newFont As New Font(fontFamily, 900 / PannelSetting.gScale, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim x, y As Integer
        x = (AxesValue.BottomAxis.MainAxisScale.Max + AxesValue.BottomAxis.MainAxisScale.Min) / 2
        y = (AxesValue.LeftAxis.MainAxisScale.Max + AxesValue.LeftAxis.MainAxisScale.Min) / 2
        Dim labelformat As New StringFormat()
        labelformat.Alignment = StringAlignment.Center
        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
        graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
        myMatrix.Translate(x, y) 'ƽ�Ƶ����ֵ�
        If PannelSetting.gScale > 2 Then
            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
        End If
        myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
        grap.Transform = myMatrix
        'grap.DrawString("���ð�", newFont, New SolidBrush(Color.Gray), 0, 0, labelformat) '��ʽ��ע�������ɡ�
        grap.EndContainer(graphicsContainer) '�˳���ͼ����
    End Sub
End Class
