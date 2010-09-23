Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class ContourLine
    '����ֵ�ߵ��ࡣ��������ཫ����õĵ�ֵ������ĵ����ӵ�һ��
    Public PenProperty As New PenProperty '���ʵĻڸ���
    Public ContourLineVisible As Boolean = True '��ֵ���Ƿ�ɼ�
    Public LabelVisible As Boolean = False   '��ֵ�߱�ע�Ƿ�ɼ�
    Public HurtVisible As Boolean = False '�˺���Χ���ɼ�
    Public HurtLaberVisible As Boolean = False '�˺���ע���ɼ�
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)
    Public LabelFont As New Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel)
    Public LabelColor As Color = Color.Black
    Public SmoothingMode As Boolean = False
    Public Curve As Boolean = False '����
    Public Number As Integer = 6 '��ע��С����λ��


    Public Sub DrawContourLine(ByVal grap As Graphics, ByVal ArrayContourPoints() As ContourPoints, ByVal ContourValue As Double, ByVal HurtValue As Double, ByVal x0 As Double, ByVal y0 As Double)  '����ĳһ����ֵ��
        Dim ContourLinePen As New Pen(Color.FromArgb(PenProperty.color))
        ContourLinePen.DashStyle = PenProperty.DashStyle
        ContourLinePen.Width = PenProperty.WidthReal * PannelSetting.gScale
        Dim LabelBrush As New SolidBrush(LabelColor)
        If ContourLineVisible Then '�����ֵ�߿ɼ��ͻ��Ƶ�ֵ��
            '���Ƶ�ֵ�ߵı�ע,��ͨ��pathȡ�û��Ʊ�ע��·��
            Dim ContourRegion As New Region(PannelSetting.gAxisRect) '���ֵ�ߵķ������������ֵ�����������򲻻���
            grap.SetClip(ContourRegion.Clone, CombineMode.Replace)

            Dim contourPoint() As Point3D '���ڴ���ĳ����ֵ�����е�ֵ���е�һ��,��x,y�ֱ�Ϊ�����͡�����������ڻ�ͼ
            Dim i As Integer = 0
            Dim j As Integer = 0
            If ArrayContourPoints IsNot Nothing AndAlso ArrayContourPoints.Length > 0 Then
                For i = 0 To ArrayContourPoints.Length - 1
                    contourPoint = ArrayContourPoints(i).vecContourPoints
                    If contourPoint.Length >= 2 Then '������飾��2������������������򲻻���
                        '���¸���ÿһ����ֵ�ߵ�������л��Ƶ�ֵ�ߵı�ע
                        If LabelVisible Then '�����ֵ�ߵı�ע�ɼ����ͻ��Ƶ�ֵ�ߵı�ע
                            Dim LabelFormat As New StringFormat
                            Dim TextHeight As Double '�ֵĸ߶�
                            LabelFormat.Alignment = StringAlignment.Center   '���������
                            Dim myMatrix As New Matrix()
                            Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
                            graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
                            '������ֵ�λ��
                            Dim n As Integer
                            n = contourPoint.Length * 2 / 3
                            'If n <= 0 Then
                            '    n = 1
                            'End If
                            myMatrix.Translate((contourPoint(n).x + contourPoint(n - 1).x) / 2, (contourPoint(n).y + contourPoint(n - 1).y) / 2) 'ƽ�Ƶ�����֮��
                            '������ֵĽǶ�
                            Dim Angle As Double
                            Dim DL As Double
                            DL = Math.Sqrt((contourPoint(n).y - contourPoint(n - 1).y) ^ 2 + (contourPoint(n).x - contourPoint(n - 1).x) ^ 2)
                            'If (contourPoint(n + 1).Y - contourPoint(n - 1).Y) * (contourPoint(n + 1).X - contourPoint(n - 1).X) < 0 Then
                            '    DL = -1 * DL
                            'End If
                            Angle = 180 / Math.PI * Math.Asin((contourPoint(n).y - contourPoint(n - 1).y) / DL)
                            If contourPoint(n).x - contourPoint(n - 1).x < 0 Then '�ڶ��͵������ޣ�-180��
                                Angle = -Angle
                            End If
                            TextHeight = grap.MeasureString(CStr(i), LabelFont).Height * PannelSetting.gScale

                            myMatrix.Rotate(Angle)
                            myMatrix.Translate(0, TextHeight / 2)
                            myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                            myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
                            grap.Transform = myMatrix
                            If SmoothingMode = True Then '�������
                                grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            End If
                            Try
                                grap.DrawString(FormatNumber(ContourValue, Number), LabelFont, LabelBrush, 0, 0, LabelFormat)
                            Catch

                            End Try
                            grap.EndContainer(graphicsContainer) '�˳���ͼ����
                            'ͨ��·���任������ֵ�����
                            Dim Mypath As New GraphicsPath()
                            Mypath.AddString(FormatNumber(ContourValue, Number), LabelFont.FontFamily, LabelFont.Style, LabelFont.Size, New PointF(0, 0), LabelFormat)
                            Mypath.Transform(myMatrix)
                            Dim rectf As RectangleF = Mypath.GetBounds()
                            Dim region As New Region(rectf) '��ͼ�ı�ע��·������ 
                            ContourRegion.Exclude(region.Clone) '���
                            grap.SetClip(ContourRegion.Clone, CombineMode.Replace)
                        End If
                        If SmoothingMode = True Then '�������
                            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        End If
                        Dim m As Integer
                        Dim DrawContour(contourPoint.Length - 1) As PointF
                        For m = 0 To contourPoint.Length - 1
                            DrawContour(m).X = contourPoint(m).x
                            DrawContour(m).Y = contourPoint(m).y
                        Next
                        If Curve = True Then
                            grap.DrawCurve(ContourLinePen, DrawContour)
                        Else
                            grap.DrawLines(ContourLinePen, DrawContour)
                        End If
                    End If
                Next
            End If
        End If
        '�����˺�����
        If HurtVisible And HurtValue > 0 Then '����˺��߿ɼ��ͻ�����
            '�����˺��ߵı�ע,��ͨ��pathȡ�û��Ʊ�ע��·��
            Dim HurtRegion As New Region(PannelSetting.gAxisRect) '���˺��ߵķ�����������˺������������򲻻���
            grap.SetClip(HurtRegion.Clone, CombineMode.Replace)
            If HurtLaberVisible Then '����˺���ע�ɼ�
                Dim TextHeight As Double '�ֵĸ߶�
                Dim LabelFormat As New StringFormat

                LabelFormat.Alignment = StringAlignment.Center   '���������
                Dim myMatrix As New Matrix()
                Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
                graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
                '������ֵ�λ�á�����ǻ��ֵ�λ��λ��30�Ƚ��ϡ�

                Dim MoveAngle As Integer = 90
                myMatrix.Translate(HurtValue * Math.Cos(MoveAngle / 180 * Math.PI), HurtValue * Math.Sin(MoveAngle / 180 * Math.PI)) 'ƽ�Ƶ����Ƶ�
                '������ֵĽǶ�
                Dim Angle As Double
                Angle = MoveAngle - 90
                TextHeight = grap.MeasureString(CStr(HurtValue), LabelFont).Height * PannelSetting.gScale
                myMatrix.Rotate(Angle)
                myMatrix.Translate(0 + x0, TextHeight / 2 + y0)
                myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
                grap.Transform = myMatrix
                Try
                    If SmoothingMode = True Then '�������
                        grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    End If
                    grap.DrawString(FormatNumber(HurtValue, Number) & "m", LabelFont, LabelBrush, 0, 0, LabelFormat)
                Catch

                End Try
                grap.EndContainer(graphicsContainer) '�˳���ͼ����
                'ͨ��·���任������ֵ�����
                Dim Mypath As New GraphicsPath()
                Mypath.AddString(FormatNumber(HurtValue, Number) & " m", LabelFont.FontFamily, LabelFont.Style, LabelFont.Size, New PointF(0, 0), LabelFormat)
                Mypath.Transform(myMatrix)
                Dim rectf As RectangleF = Mypath.GetBounds()
                Dim region As New Region(rectf) '��ͼ�ı�ע��·������ 
                HurtRegion.Exclude(region.Clone) '���
                grap.SetClip(HurtRegion.Clone, CombineMode.Replace)
            End If
            If SmoothingMode = True Then '�������
                grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            End If
            grap.DrawEllipse(ContourLinePen, CSng(-HurtValue + x0), CSng(-HurtValue + y0), 2 * CSng(HurtValue), 2 * CSng(HurtValue))
        End If
    End Sub
End Class
