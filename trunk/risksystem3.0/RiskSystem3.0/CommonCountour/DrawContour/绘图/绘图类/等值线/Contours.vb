Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
<Serializable()> Public Class Contours
    '��ֵ�������࣬���ڻ��Ƶ�ֵ�����顣
    Public GridPoint(-1, -1) As Double '�����
    Public ContourCont As Integer '��ֵ������
    Public nRow, nCol As Integer '�С�����
    Public Xmin, Ymin, Xmax, Ymax As Double '���������������С����
    Public ArrayDamageRange(-1) As Double '���ڴ����˺���Χ
    Public ArrayContourValue(-1) As Double '��ֵ��ֵ����
    Public ArrayContour(-1) As Contour '��ֵ������
    Public SortA(-1) As Integer '�������������ֵ�ߵ�˳��
    <NonSerialized()> Private FillContourRegion(-1) As Region '���ڴ�������ֵ��ֵ���������
    <NonSerialized()> Private CutFillContourRegion(-1) As Region '���ڴ�����к������ֵ��ֵ���������

    Public ContourFillStartColor As Color = Color.FromArgb(255, 0, 0)
    Public ContourFillEndColor As Color = Color.FromArgb(255, 255, 0)
    Public ContourStartColor As Color = Color.FromArgb(255, 0, 0)
    Public ContourEndColor As Color = Color.FromArgb(255, 255, 0)
    Public ContourLabelStartColor As Color = Color.Black
    Public ContourLabelEndColor As Color = Color.Black  '

    Public ReCalContour As Boolean = True '�������ɵ�ֵ�߱�־�����ǵ��������ɵ�ֵ�ߵ��ٶȽ��������øñ�־����ΪTrueʱ�������ɡ�����û����ı��ֵ�ߣ����������ɸõ�ֵ�ߡ�
    Public x0 As Double '���ֱ�ը��ȾԴ����
    Public y0 As Double '���ֱ�ը��ȾԴ����
    ''' <summary>
    ''' �������õ�ֵ�ߵķּ���ֵ��
    ''' </summary>
    ''' <remarks></remarks>
    Public ContourValueSetting As New ContourValueSetting

    Public Sub IntialContours(ByVal ContourCont As Integer)
        ReDim ArrayContour(0 To ContourCont - 1)
    End Sub
    Public Sub DrawContours(ByVal grap As Graphics)
        Dim k As Integer
        'If ReCalContour = True Then '���¼����ֵ�ߵ�����
        ReDim FillContourRegion(ArrayContour.Length - 1)
        ReDim CutFillContourRegion(ArrayContour.Length - 1)
        For k = 0 To ArrayContour.Length - 1
            FillContourRegion(k) = New Region(New Rectangle(0, 0, 0, 0)) '��������Ϊ�յ�����
            CutFillContourRegion(k) = New Region(New Rectangle(0, 0, 0, 0)) '��������Ϊ�յ�����
        Next
        'End If
        ReDim ArrayContourValue(ArrayContour.Length - 1)
        '�����ֵ��
        SortContour()
        '����ֵ��
        Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ����
        graphicsContainer = grap.BeginContainer() 'Ƕ�׵� Graphics ����
        FillRegions(grap) '���Ƶ�ֵ�ߵ�����
        '�������Ƶ�ֵ��

        Dim i As Integer
        For i = 0 To ArrayContour.Length - 1
            ArrayContour(SortA(i)).DrawContour(grap, SortA(i), GridPoint, nRow, nCol, Xmin, Ymin, Xmax, Ymax, ReCalContour, x0, y0)
        Next
        ReCalContour = False
        grap.EndContainer(graphicsContainer) '�˳���ͼ����
    End Sub
    Private Sub SortContour() '�����ֵ��
        ReDim SortA(ArrayContour.Length - 1) '�������������ֵ�ߵ�˳��
        Dim i, j, Exechange As Integer
        For i = 0 To ArrayContour.Length - 1 '��ʼ����ֵ�������˳��
            SortA(i) = i
        Next
        If PannelSetting.PaintType = 0 Then
            For i = 0 To ArrayContour.Length - 1 '������������򣬰���С�����˳������
                For j = i To ArrayContour.Length - 1
                    If ArrayContour(SortA(i)).ContourValue > ArrayContour(SortA(j)).ContourValue Then '��������������
                        Exechange = SortA(i)
                        SortA(i) = SortA(j)
                        SortA(j) = Exechange
                    End If
                Next
            Next
        Else
            For i = 0 To ArrayContour.Length - 1 '������������򣬰��Ӵ���С��˳������
                For j = i To ArrayContour.Length - 1
                    If ArrayContour(SortA(i)).ContourValue < ArrayContour(SortA(j)).ContourValue Then '��������������
                        Exechange = SortA(i)
                        SortA(i) = SortA(j)
                        SortA(j) = Exechange
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub FillRegions(ByVal grap As Graphics)
        If GridPoint IsNot Nothing Then
            Dim i As Integer
            '��������
            For i = 0 To ArrayContour.Length - 1
                ArrayContourValue(SortA(i)) = ArrayContour(SortA(i)).ContourValue
                ArrayContour(SortA(i)).GetFillRegion(grap, SortA(i), GridPoint, nRow, nCol, Xmin, Ymin, Xmax, Ymax, FillContourRegion, ReCalContour, x0, y0)
            Next
            '��������
            For i = 0 To ArrayContour.Length - 1
                ArrayContour(SortA(i)).ContourFill.CutRegion(SortA(i), FillContourRegion, CutFillContourRegion, ArrayContourValue, ReCalContour)
            Next
            '�������
            For i = 0 To ArrayContour.Length - 1
                ArrayContour(SortA(i)).ContourFill.FillContour(grap, SortA(i), FillContourRegion, CutFillContourRegion)
            Next
        End If
    End Sub

    Public Sub ContourFillColorGradual() '�����ɫ����
        SortContour() '�����ֵ��
        Dim i As Integer
        Dim iColorR As Double  '��ɫ���
        Dim iColorG As Double '��ɫ���
        Dim iColorB As Double '��ɫ���
        Dim R As Integer '��ɫ
        Dim G As Integer '��ɫ
        Dim B As Integer '��ɫ

        If ArrayContour.Length - 1 > 0 Then
            iColorR = (CInt(ContourFillEndColor.R) - CInt(ContourFillStartColor.R)) / (ArrayContour.Length - 1)
            iColorG = (CInt(ContourFillEndColor.G) - CInt(ContourFillStartColor.G)) / (ArrayContour.Length - 1)
            iColorB = (CInt(ContourFillEndColor.B) - CInt(ContourFillStartColor.B)) / (ArrayContour.Length - 1)
            For i = 0 To ArrayContour.Length - 1
                R = ContourFillEndColor.R - iColorR * i
                G = ContourFillEndColor.G - iColorG * i
                B = ContourFillEndColor.B - iColorB * i
                If R > 255 Then
                    R = 255
                ElseIf R < 0 Then
                    R = 0
                End If
                If G > 255 Then
                    G = 255
                ElseIf G < 0 Then
                    G = 0
                End If
                If B > 255 Then
                    B = 255
                ElseIf B < 0 Then
                    B = 0
                End If
                ArrayContour(SortA(i)).ContourFill.ContourForeColor = Color.FromArgb(R, G, B)
            Next
        ElseIf ArrayContour.Length > 0 Then
            ArrayContour(0).ContourFill.ContourForeColor = ContourFillStartColor
        End If
    End Sub
    Public Sub ContourColorGradual() '������ɫ����

        SortContour() '�����ֵ��
        Dim i As Integer
        Dim iColorR As Double  '��ɫ���
        Dim iColorG As Double '��ɫ���
        Dim iColorB As Double '��ɫ���
        Dim R As Integer '��ɫ
        Dim G As Integer '��ɫ
        Dim B As Integer '��ɫ
        If ArrayContour.Length - 1 > 0 Then
            iColorR = (CInt(ContourEndColor.R) - CInt(ContourStartColor.R)) / (ArrayContour.Length - 1)
            iColorG = (CInt(ContourEndColor.G) - CInt(ContourStartColor.G)) / (ArrayContour.Length - 1)
            iColorB = (CInt(ContourEndColor.B) - CInt(ContourStartColor.B)) / (ArrayContour.Length - 1)
            For i = 0 To ArrayContour.Length - 1
                R = ContourEndColor.R - iColorR * i
                G = ContourEndColor.G - iColorG * i
                B = ContourEndColor.B - iColorB * i
                If R > 255 Then
                    R = 255
                ElseIf R < 0 Then
                    R = 0
                End If
                If G > 255 Then
                    G = 255
                ElseIf G < 0 Then
                    G = 0
                End If
                If B > 255 Then
                    B = 255
                ElseIf B < 0 Then
                    B = 0
                End If
                ArrayContour(SortA(i)).ContourLine.PenProperty.color = Color.FromArgb(R, G, B).ToArgb
            Next
        ElseIf ArrayContour.Length > 0 Then
            ArrayContour(0).ContourLine.PenProperty.color = ContourStartColor.ToArgb
        End If

    End Sub
    Public Sub ContourLabelColorGradual() '��ֵ����ɫ����
        SortContour() '�����ֵ��
        Dim i As Integer
        Dim iColorR As Double  '��ɫ���
        Dim iColorG As Double '��ɫ���
        Dim iColorB As Double '��ɫ���
        Dim R As Integer '��ɫ
        Dim G As Integer '��ɫ
        Dim B As Integer '��ɫ
        If ArrayContour.Length - 1 > 0 Then
            iColorR = (CInt(ContourLabelEndColor.R) - CInt(ContourLabelStartColor.R)) / (ArrayContour.Length - 1)
            iColorG = (CInt(ContourLabelEndColor.G) - CInt(ContourLabelStartColor.G)) / (ArrayContour.Length - 1)
            iColorB = (CInt(ContourLabelEndColor.B) - CInt(ContourLabelStartColor.B)) / (ArrayContour.Length - 1)
            For i = 0 To ArrayContour.Length - 1
                R = ContourLabelEndColor.R - iColorR * i
                G = ContourLabelEndColor.G - iColorG * i
                B = ContourLabelEndColor.B - iColorB * i
                If R > 255 Then
                    R = 255
                ElseIf R < 0 Then
                    R = 0
                End If
                If G > 255 Then
                    G = 255
                ElseIf G < 0 Then
                    G = 0
                End If
                If B > 255 Then
                    B = 255
                ElseIf B < 0 Then
                    B = 0
                End If
                ArrayContour(SortA(i)).ContourLine.LabelColor = Color.FromArgb(R, G, B)
            Next
        ElseIf ArrayContour.Length > 0 Then
            ArrayContour(0).ContourLine.LabelColor = ContourLabelStartColor
        End If
    End Sub
    ''' <summary>
    ''' ���ص�ֵ�ߵĸ���
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Contours
        Try
            ' Create a filestream object
            Dim fileStr As Stream = File.Open(ApplicationPath() & "Contour.sav", FileMode.Create)
            ' Create a linked list object and populate it with random nodes
            Dim ObjContours As New Contours
            ObjContours = Me
            ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter
            formatter = CType(New BinaryFormatter, IFormatter)
            ' Serialize the object graph to stream
            formatter.Serialize(fileStr, ObjContours)
            ' All done
            fileStr.Close()
        Catch ex As Exception
            MsgBox("д��ֵ���ļ�����!")
            Return Nothing
        End Try


        Try
            Dim fileStr As Stream = File.Open(ApplicationPath() & "Contour.sav", FileMode.Open)

            ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter

            formatter = CType(New BinaryFormatter, IFormatter)
            ' Deserialize the object graph from stream
            Dim ObjContours As New Contours
            ObjContours = CType(formatter.Deserialize(fileStr), Contours)
            fileStr.Close()
            Return ObjContours
        Catch ex As Exception
            MsgBox("����ֵ���ļ�����!")
            Return Nothing
        End Try
    End Function
    <OnDeserializing()> _
Friend Sub OnDeserializingMethod(ByVal context As StreamingContext)

    End Sub

    <OnDeserialized()> _
    Friend Sub OnDeserializedMethod(ByVal context As StreamingContext)
        '1.3.0.3 ������1.3.0.4
        If Me.ContourValueSetting Is Nothing Then
            Me.ContourValueSetting = New ContourValueSetting
        End If
    End Sub
End Class
