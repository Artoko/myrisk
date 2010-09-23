Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
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
    'Private m_Nestings(-1) As Nesting '���ڶ��Ƕ�����������
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
    ''' <summary>
    ''' ���ڶ��Ƕ�����������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Property Nestings() As Nesting()
    '    Get
    '        Return Me.m_Nestings
    '    End Get
    '    Set(ByVal value As Nesting())
    '        Me.m_Nestings = value
    '    End Set
    'End Property

    Public Sub DrawPannel(ByVal grap As Graphics)
        ''����任
        grap.TranslateTransform(PannelSetting.OriginX, PannelSetting.OriginY, MatrixOrder.Append) '������ϵͳƽ��
        Dim graphicsContainer As GraphicsContainer
        graphicsContainer = grap.BeginContainer() '��ͼ����
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '��ֱ��ת�任
        myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '������Ϊ
        grap.Transform = myMatrix
        Try
            BackImageValue.DrawImage(grap) '���Ʊ���ͼ
        Catch ex As Exception
            MessageBox.Show("���Ʊ���ͼ����")
        End Try
        Try
            Me.m_PlanImage.DrawImage(grap) '����ƽ��ͼ
        Catch ex As Exception

        End Try
        Try
            ContoursValue.DrawContours(grap) '���Ƶ�ֵ��
        Catch ex As Exception

        End Try
        Try
            AxesValue.DrawAxes(grap) '��������
        Catch ex As Exception

        End Try
        'Try
        '    If Me.m_Nestings IsNot Nothing Then
        '        For i As Integer = 0 To Me.m_Nestings.Length - 1 '����Ƕ��
        '            Me.m_Nestings(i).Draw(grap)
        '        Next
        '    End If
        'Catch ex As Exception

        'End Try

        Try
            mSymbols.DrawSymbols(grap) '���Ʊ�־

        Catch ex As Exception

        End Try
        Try
            mLegend.DrawLegend(grap, ContoursValue, mSymbols) '����ͼ��

        Catch ex As Exception

        End Try
        Try
            DrawTR(grap)

        Catch ex As Exception

        End Try
        grap.EndContainer(graphicsContainer)
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
    ''' <summary>
    ''' ���ص�ֵ�ߵĸ���
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Pannel
        Try
            ' Create a filestream object
            Dim fileStr As Stream = File.Open(ApplicationPath() & "Pannel.sav", FileMode.Create)
            ' Create a linked list object and populate it with random nodes
            Dim ObjPannel As New Pannel
            ObjPannel = Me
            ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter
            formatter = CType(New BinaryFormatter, IFormatter)
            ' Serialize the object graph to stream
            formatter.Serialize(fileStr, ObjPannel)
            ' All done
            fileStr.Close()
        Catch ex As Exception
            MsgBox("д��ֵ���ļ�����!")
            Return Nothing
        End Try


        Try
            Dim fileStr As Stream = File.Open(ApplicationPath() & "Pannel.sav", FileMode.Open)

            ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter

            formatter = CType(New BinaryFormatter, IFormatter)
            ' Deserialize the object graph from stream
            Dim ObjPannel As New Pannel
            ObjPannel = CType(formatter.Deserialize(fileStr), Pannel)
            fileStr.Close()
            Return ObjPannel
        Catch ex As Exception
            MsgBox("����ֵ���ļ�����!")
            Return Nothing
        End Try
    End Function
End Class
