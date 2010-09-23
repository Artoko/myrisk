Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Text
<Serializable()> Public Class AxisTitle

    Public TitleName As String
    Public TitleVisible As Boolean
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)
    Public TitleFont As New Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    Public TitleColor As Integer = Color.Black.ToArgb

    Public Sub DrawTitle(ByVal grap As Graphics, ByVal AxesSideValue As AxesSide)
        'rect ����Ϊ����ʾ��ȥ����̶ȼ������ע���������
        If TitleVisible Then '����ɼ��ͻ��������������
            Dim TitleFormat As New StringFormat
            If TitleName <> Nothing Then '����ַ�����Ϊ��
                Dim TitleBrush As New SolidBrush(Color.FromArgb(TitleColor))
                TitleFormat.Alignment = StringAlignment.Center
                Dim myMatrix As New Matrix()
                Dim TextHeight As Double '�ֵĸ߶�
                TextHeight = grap.MeasureString(TitleName, TitleFont).Height * PannelSetting.gScale
                Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ����
                graphicsContainer = grap.BeginContainer() 'Ƕ�׵� Graphics ����
                Select Case AxesSideValue  '��������������ڵı߲�ͬ�����ò�ͬ������任����
                    Case AxesSide.LeftSide
                        myMatrix.Translate(PannelSetting.gAxisTitleRect.X - TextHeight, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height / 2)
                        myMatrix.Rotate(90)
                    Case AxesSide.BottomSide
                        myMatrix.Translate(PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width / 2, PannelSetting.gAxisTitleRect.Y - 2 * PannelSetting.gScale)
                        myMatrix.Rotate(0)
                    Case AxesSide.RightSide
                        myMatrix.Translate(PannelSetting.gAxisTitleRect.X + PannelSetting.gAxisTitleRect.Width + 2 * PannelSetting.gScale, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height / 2)
                        myMatrix.Rotate(90)
                        '�����ұ�ͼ���Ļ���λ��
                        PannelSetting.gRightLegendPoint = PannelSetting.gAxisTitleRect.X + PannelSetting.gAxisTitleRect.Width + 10 * PannelSetting.gScale + TextHeight
                    Case AxesSide.TopSide
                        myMatrix.Translate(PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width / 2, PannelSetting.gAxisTitleRect.Y + PannelSetting.gAxisTitleRect.Height + TextHeight)
                        myMatrix.Rotate(0)
                End Select
                myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
                myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0))
                grap.Transform = myMatrix
                grap.DrawString(TitleName, TitleFont, TitleBrush, 0, 0, TitleFormat)
                grap.EndContainer(graphicsContainer) '�˳���ͼ����
            End If
        Else
            Select Case AxesSideValue  '��������������ڵı߲�ͬ�����ò�ͬ������任����
                Case AxesSide.RightSide
                    '��С�ұ�ͼ���Ļ���λ��
                    PannelSetting.gRightLegendPoint = PannelSetting.gAxisTitleRect.X + PannelSetting.gAxisTitleRect.Width + 10 * PannelSetting.gScale
            End Select
        End If
    End Sub

End Class
