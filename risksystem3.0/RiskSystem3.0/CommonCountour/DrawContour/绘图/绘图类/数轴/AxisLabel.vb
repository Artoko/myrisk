Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class AxisLabel
    'Inherits PublicLabel
    Public LabelVisible As Boolean '�̶ȱ�ע�Ƿ�ɼ�
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)
    Public LabelFont As New Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    Public LabelColor As Integer = Color.Black.ToArgb
    Private MaxValue, MinValue As Double '������������Сֵ
    Private IncreaseValue As Double  '��������ֵ����Сֵ������ֵ
    Private inMax, inMin As Double  '�������ߵ����ֵ����Сֵ��������
    Public AxesSide As AxesSide = AxesSide.LeftSide  '��
    Public Sub AxisLabelDraw(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)

        '���ݲ�ͬ��������ߣ����ò�ͬ�����ֵ����Сֵ
        Select Case AxesSideValue
            Case AxesSide.LeftSide
                MinValue = PannelSetting.gAxisRect.Y
                MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                IncreaseValue = PannelSetting.gVMainIncrease '��ֱ������̶ȼ��
            Case AxesSide.BottomSide
                MinValue = PannelSetting.gAxisRect.X
                MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                IncreaseValue = PannelSetting.gHMainIncrease 'ˮƽ������̶ȼ��  
            Case AxesSide.RightSide
                MinValue = PannelSetting.gAxisRect.Y
                MaxValue = PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height
                IncreaseValue = PannelSetting.gVMainIncrease '��ֱ������̶ȼ��  
            Case AxesSide.TopSide
                MinValue = PannelSetting.gAxisRect.X
                MaxValue = PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width
                IncreaseValue = PannelSetting.gHMainIncrease 'ˮƽ������̶ȼ��  
        End Select

        If IncreaseValue > 0 Then
            inMin = MinValue
            inMax = MaxValue
            Dim nb As Integer
            If (MaxValue - MinValue) / IncreaseValue > 10 Then
                nb = Math.Truncate((MaxValue - MinValue) / IncreaseValue / 10)  '������10����ע
            Else
                nb = Math.Truncate((MaxValue - MinValue) / IncreaseValue)
            End If
            IncreaseValue = IncreaseValue * nb
            Dim i As Integer
            Dim LabelBrush As New SolidBrush(Color.FromArgb(LabelColor))

            Dim TextHeight, TextWidth, MaxTextHeight, MaxTextWidth As Double '�ֵĸ߶ȺͿ��

            If LabelVisible Then '����ɼ��ͻ���������Ŀ̶ȵı�ע
                Dim LabelFormat As New StringFormat
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Far
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
                            graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(PannelSetting.gAxisLabelRect.X, i + TextHeight / 2) 'ƽ�Ƶ����ֵ�
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '�˳���ͼ����
                            If MaxTextWidth < TextWidth Then
                                MaxTextWidth = TextWidth
                            End If
                        Next
                        '��������������������
                        PannelSetting.gAxisTitleRect.X = PannelSetting.gAxisLabelRect.X - MaxTextWidth
                    Case AxesSide.BottomSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Center
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
                            graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(i, PannelSetting.gAxisLabelRect.Y) 'ƽ�Ƶ����ֵ�
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '�˳���ͼ����
                            If MaxTextHeight < TextHeight Then
                                MaxTextHeight = TextHeight
                            End If
                        Next
                        '������������ĵױ�����
                        PannelSetting.gAxisTitleRect.Y = PannelSetting.gAxisLabelRect.Y - MaxTextHeight
                    Case AxesSide.RightSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Near '�����
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
                            graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(PannelSetting.gAxisLabelRect.X + PannelSetting.gAxisLabelRect.Width, i + TextHeight / 2) 'ƽ�Ƶ�������ֵ�
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '�˳���ͼ����
                            If MaxTextWidth < TextWidth Then
                                MaxTextWidth = TextWidth
                            End If
                        Next
                        '��������������ұ�����
                        PannelSetting.gAxisTitleRect.Width = PannelSetting.gAxisLabelRect.Width + MaxTextWidth + (PannelSetting.gAxisLabelRect.X - PannelSetting.gAxisTitleRect.X)
                    Case AxesSide.TopSide
                        For i = inMin To inMax Step IncreaseValue
                            LabelFormat.Alignment = StringAlignment.Center
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
                            graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
                            TextWidth = grap.MeasureString(CStr(i), LabelFont).Width * PannelSetting.gScale
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale
                            myMatrix.Translate(i, PannelSetting.gAxisLabelRect.Y + PannelSetting.gAxisLabelRect.Height + TextHeight) 'ƽ�Ƶ����ֵ�
                            'myMatrix.Rotate(90)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
                            grap.Transform = myMatrix
                            grap.DrawString(CStr(i), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            grap.EndContainer(graphicsContainer) '�˳���ͼ����
                            If MaxTextHeight < TextHeight Then
                                MaxTextHeight = TextHeight
                            End If
                        Next
                        '������������Ķ�������
                        PannelSetting.gAxisTitleRect.Height = PannelSetting.gAxisLabelRect.Height + MaxTextHeight + (PannelSetting.gAxisLabelRect.Y - PannelSetting.gAxisTitleRect.Y)
                End Select
            Else
                Select Case AxesSideValue
                    Case AxesSide.LeftSide
                        '��С�����������������
                        PannelSetting.gAxisTitleRect.X = PannelSetting.gAxisLabelRect.X
                    Case AxesSide.BottomSide
                        '��С���������ĵױ�����
                        PannelSetting.gAxisTitleRect.Y = PannelSetting.gAxisLabelRect.Y
                    Case AxesSide.RightSide
                        '��С�����������ұ�����
                        PannelSetting.gAxisTitleRect.Width = PannelSetting.gAxisLabelRect.Width + (PannelSetting.gAxisLabelRect.X - PannelSetting.gAxisTitleRect.X)
                    Case AxesSide.TopSide
                        '��С���������Ķ�������
                        PannelSetting.gAxisTitleRect.Height = PannelSetting.gAxisLabelRect.Height + (PannelSetting.gAxisLabelRect.Y - PannelSetting.gAxisTitleRect.Y)
                End Select
            End If
        End If
    End Sub
End Class
