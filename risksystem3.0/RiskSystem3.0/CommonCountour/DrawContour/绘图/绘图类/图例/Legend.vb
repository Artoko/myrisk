Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class Legend
    Public HatchStyle As HatchStyle
    Public BBackColor As Color = Color.White   '���ͼ���ı�������ɫ
    Public BForeColor As Color = Color.White   '���ͼ����ǰ������ɫ
    Public BFillVisible As Boolean = False   '��������Ƿ�ɼ�
    Public BBackTransparent As Integer = 80 '����͸���ȡ�0��ʾ��͸����100��ʾȫ͸��
    Public BForeTransparent As Integer = 50 'ǰ��͸���ȡ�0��ʾ��͸����100��ʾȫ͸��
    Public BBrushStyle As Integer = 0 '��ˢ����ʽ��0Ϊʵ�Ļ�ˢ��0Ϊͼ����ˢ
    Public SmoothingMode As Boolean = False
    ''' <summary>
    ''' ��ֵ��ͼ���ɼ�
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendContourLineVisible As Boolean = False
    ''' <summary>
    ''' ��ֵ�����ͼ���ɼ�
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendContourFillVisible As Boolean = True
    ''' <summary>
    ''' ��ֵ�߱�־ͼ���ɼ�
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendSymbolVisible As Boolean = True
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)

    ''' <summary>
    '''ͼ��������
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendFont As New Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    ''' <summary>
    ''' ͼ������ɫ
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendColor As Color = Color.Black
    ''' <summary>
    ''' ����ͼ��
    ''' </summary>
    ''' <param name="Contours">��ֵ�߶���</param>
    ''' <param name="Symbols">��־����</param>
    ''' <remarks>����ͼ��</remarks>
    Public Sub DrawLegend(ByVal grap As Graphics, ByVal Contours As Contours, ByVal Symbols As Symbols)

        '�ڻ���ͼ��ǰ�Ƚ���ͼ����ת����ԭ�������� 
        Dim LegendBrush As New SolidBrush(LegendColor)
        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
        graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
        myMatrix.Translate(PannelSetting.gRightLegendPoint, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height) 'ƽ�Ƶ����ֵ�����ͼ����������Ͻ�λ��
        myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '��ͼ����ת����ԭ�������� 
        myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
        myMatrix.Translate(5, 5)
        grap.Transform = myMatrix
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        FillBlack(grap, Contours, Symbols)
        If SmoothingMode = True Then '�������
            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        End If
        DrawLegendContourFill(grap, Contours) ' ���Ƶ�ֵ�����ͼ��
        DrawLegendContourLine(grap, Contours) ' ���Ƶ�ֵ��ͼ��
        DrawLegendSymbol(grap, Symbols) '���Ʊ�־ͼ��
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        grap.EndContainer(graphicsContainer) '�˳���ͼ����

    End Sub
    ''' <summary>
    ''' ���Ƶ�ֵ�����ͼ��
    ''' </summary>
    ''' <param name="grap">��ͼ����</param>
    ''' <param name="Contours">��ֵ�߶���</param>
    ''' <remarks></remarks>
    Private Sub DrawLegendContourFill(ByVal grap As Graphics, ByVal Contours As Contours)

        If LegendContourFillVisible = True Then '�����ֵ�����ͼ���ɼ�
            Dim LegendFormat As New StringFormat
            If Contours.ArrayContour IsNot Nothing AndAlso Contours.ArrayContour.Length > 0 Then '�����ֵ������>0���л���
                'һ����Contours.ContourCont+1�����֣��������⡣����ĸ߶�ӦΪ���ֵĸ߶ȼ��ϼ��ĸ߶ȡ�����ȡ0.2�����ָ߶ȡ�
                Dim TextWidth, TextHeigth As Double
                TextHeigth = grap.MeasureString("ͼ��", LegendFont).Height
                TextWidth = grap.MeasureString("ͼ��", LegendFont).Width
                PannelSetting.gLegendContourFillRect.Height = (Contours.ArrayContour.Length + 1) * (TextHeigth + 0.2 * TextHeigth)
                Dim i As Integer
                Dim LegendBrush As New SolidBrush(LegendColor)
                '���Ʊ���
                grap.DrawString("ͼ��", LegendFont, LegendBrush, 0, 0, LegendFormat)
                '����ͼ��
                For i = 1 To Contours.ArrayContour.Length
                    Dim ForeAlpha As Integer 'alpha ֵԽ�ӽ��� 0��������ɫ��Ȩ��Խ��alpha ֵԽ�ӽ��� 255��������ɫ��Ȩ��Խ��
                    ForeAlpha = 255 - CInt(Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ForeTransparent * 2.55)
                    Dim ForeColor As Color = Color.FromArgb(ForeAlpha, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourForeColor.R, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourForeColor.G, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourForeColor.B)
                    Dim BackAlpha As Integer 'alpha ֵԽ�ӽ��� 0��������ɫ��Ȩ��Խ��alpha ֵԽ�ӽ��� 255��������ɫ��Ȩ��Խ��
                    BackAlpha = 255 - CInt(Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.BackTransparent * 2.55)
                    Dim BackColor As Color = Color.FromArgb(BackAlpha, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourBackColor.R, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourBackColor.G, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourBackColor.B)
                    Dim SolidBrush As New SolidBrush(ForeColor)
                    Dim HatchBrush As New HatchBrush(Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.HatchStyle, ForeColor, BackColor)
                    If Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourFillVisible Then '�����ֵ�߿ɼ�������ֵ��
                        If Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.BrushStyle = 0 Then '��ʵ�Ļ�ˢ���
                            grap.FillRectangle(SolidBrush, New Rectangle(0, i * (TextHeigth + 0.2 * TextHeigth) + 0.1 * TextHeigth, TextWidth, TextHeigth - 0.3 * TextHeigth))
                        Else '��ͼ����ˢ���
                            grap.FillRectangle(HatchBrush, New Rectangle(0, i * (TextHeigth + 0.2 * TextHeigth) + 0.1 * TextHeigth, TextWidth, TextHeigth - 0.3 * TextHeigth))
                        End If
                    End If
                Next
                '����Ũ�ȱ���
                Dim TextWidth1 As Integer
                If PannelSetting.PaintType = 0 Then
                    grap.DrawString("ֵ", LegendFont, LegendBrush, TextWidth + 0.2 * TextWidth, 0, LegendFormat)
                    TextWidth1 = grap.MeasureString("ֵ", LegendFont).Width
                Else
                    grap.DrawString("�뾶(m)", LegendFont, LegendBrush, TextWidth + 0.2 * TextWidth, 0, LegendFormat)
                    TextWidth1 = grap.MeasureString("�뾶(m)", LegendFont).Width
                End If
                '����Ũ��
                Dim strC As String 'Ũ��
                For i = 1 To Contours.ArrayContour.Length
                    If i = Contours.ArrayContour.Length Then
                        If PannelSetting.PaintType = 0 Then
                            strC = ">" & Contours.ArrayContour(Contours.SortA(i - 1)).ContourValue '�������ֵ
                        Else
                            strC = "<" & Contours.ArrayContour(Contours.SortA(i - 1)).ContourValue '�������ֵ
                        End If
                    Else
                        If PannelSetting.PaintType = 0 Then
                            strC = Contours.ArrayContour(Contours.SortA(i - 1)).ContourValue & "-" & Contours.ArrayContour(Contours.SortA(i)).ContourValue
                        Else
                            strC = Contours.ArrayContour(Contours.SortA(i)).ContourValue & "-" & Contours.ArrayContour(Contours.SortA(i - 1)).ContourValue
                        End If
                    End If
                    grap.DrawString(strC, LegendFont, LegendBrush, TextWidth + 0.2 * TextWidth, i * (TextHeigth + 0.2 * TextHeigth), LegendFormat)
                    If TextWidth1 < grap.MeasureString(strC, LegendFont).Width Then
                        TextWidth1 = grap.MeasureString(strC, LegendFont).Width
                    End If
                Next
                '�����������
                grap.DrawString("���(m^2)", LegendFont, LegendBrush, TextWidth + TextWidth1 + 0.2 * TextWidth * 2, 0, LegendFormat)
                '�������
                Dim strA As Double = "0" '���
                Dim FomatStrA As String = ""
                Dim strAWidth As Integer = 0
                For i = 1 To Contours.ArrayContour.Length
                    If i = Contours.ArrayContour.Length Then
                        strA = Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourArea '���ֵ�����
                        FomatStrA = Format(strA, "Scientific")
                        If strAWidth < grap.MeasureString(FomatStrA, LegendFont).Width Then
                            strAWidth = grap.MeasureString(FomatStrA, LegendFont).Width
                        End If
                    Else
                        strA = Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourArea - Contours.ArrayContour(Contours.SortA(i)).ContourFill.ContourArea
                        FomatStrA = Format(strA, "Scientific")
                        If strAWidth < grap.MeasureString(FomatStrA, LegendFont).Width Then
                            strAWidth = grap.MeasureString(FomatStrA, LegendFont).Width
                        End If
                    End If
                    grap.DrawString(FomatStrA, LegendFont, LegendBrush, TextWidth + TextWidth1 + 0.2 * TextWidth * 2, i * (TextHeigth + 0.2 * TextHeigth), LegendFormat)
                Next
                PannelSetting.gLegendContourFillRect.Width = TextWidth + TextWidth1 + 0.2 * TextWidth * 2 + strAWidth '��������Ŀ��
            Else
                PannelSetting.gLegendContourFillRect.Height = 0
                PannelSetting.gLegendContourFillRect.Width = 0
            End If
        Else
            PannelSetting.gLegendContourFillRect.Height = 0
            PannelSetting.gLegendContourFillRect.Width = 0
        End If

    End Sub
    ''' <summary>
    ''' ���Ƶ�ֵ��ͼ��
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <param name="Contours"></param>
    ''' <remarks></remarks>
    Private Sub DrawLegendContourLine(ByVal grap As Graphics, ByVal Contours As Contours)
        If LegendContourLineVisible = True Then '�����ֵ��ͼ���ɼ�
            If Contours.ArrayContour IsNot Nothing AndAlso Contours.ArrayContour.Length > 0 Then '�����ֵ������>0���л���
                'һ����Contours.ContourCont�����֡�����ĸ߶�ӦΪ���ֵĸ߶ȼ��ϼ��ĸ߶ȡ�����ȡ0.2�����ָ߶ȡ�
                Dim TextWidth, TextHeigth As Double
                TextHeigth = grap.MeasureString("��ֵ��", LegendFont).Height
                TextWidth = grap.MeasureString("��ֵ��", LegendFont).Width
                PannelSetting.gLegendContourLineRect.X = PannelSetting.gLegendContourFillRect.X
                PannelSetting.gLegendContourLineRect.Y = PannelSetting.gLegendContourFillRect.Height
                PannelSetting.gLegendContourLineRect.Height = Contours.ArrayContour.Length * (TextHeigth + 0.2 * TextHeigth)
                Dim LegendBrush As New SolidBrush(LegendColor)
                '����ͼ��
                Dim i As Integer
                Dim strAWidth As Integer = 0
                For i = 0 To Contours.ArrayContour.Length - 1
                    Dim LegendPen As New Pen(Color.FromArgb(Contours.ArrayContour(Contours.SortA(i)).ContourLine.PenProperty.color))
                    LegendPen.Width = Contours.ArrayContour(Contours.SortA(i)).ContourLine.PenProperty.WidthReal
                    grap.DrawLine(LegendPen, CSng(PannelSetting.gLegendContourLineRect.X), CSng(PannelSetting.gLegendContourLineRect.Y + i * (TextHeigth + 0.2 * TextHeigth) + 0.5 * TextHeigth), CSng(PannelSetting.gLegendContourLineRect.X + TextWidth), CSng(PannelSetting.gLegendContourLineRect.Y + i * (TextHeigth + 0.2 * TextHeigth) + 0.5 * TextHeigth))
                    grap.DrawString(Contours.ArrayContour(Contours.SortA(i)).ContourName, LegendFont, LegendBrush, CSng(PannelSetting.gLegendContourLineRect.X + TextWidth + 0.2 * TextWidth), CSng(PannelSetting.gLegendContourLineRect.Y + i * (TextHeigth + 0.2 * TextHeigth)))
                    If strAWidth < grap.MeasureString(Contours.ArrayContour(Contours.SortA(i)).ContourName, LegendFont).Width Then
                        strAWidth = grap.MeasureString(Contours.ArrayContour(Contours.SortA(i)).ContourName, LegendFont).Width
                    End If
                Next
                PannelSetting.gLegendContourLineRect.Width = CSng(PannelSetting.gLegendContourLineRect.X + TextWidth + 0.2 * TextWidth) + strAWidth
            Else
                PannelSetting.gLegendContourLineRect.Height = 0
                PannelSetting.gLegendContourLineRect.Width = 0
            End If
        Else
            PannelSetting.gLegendContourLineRect.Height = 0
            PannelSetting.gLegendContourLineRect.Width = 0
        End If
    End Sub
    Private Sub DrawLegendSymbol(ByVal grap As Graphics, ByVal Symbols As Symbols)
        If LegendSymbolVisible = True Then '�����־ͼ���ɼ�
            Dim TextWidth, TextHeigth As Double
            TextHeigth = grap.MeasureString("��ȾԴ", LegendFont).Height
            TextWidth = grap.MeasureString("��ȾԴ", LegendFont).Width
            PannelSetting.gLegendSymbolRect.X = PannelSetting.gLegendContourLineRect.X
            PannelSetting.gLegendSymbolRect.Y = PannelSetting.gLegendContourFillRect.Height + PannelSetting.gLegendContourLineRect.Height
            PannelSetting.gLegendSymbolRect.Height = TextHeigth + 0.2 * TextHeigth
            Dim SymbolShape As New SymbolShape
            Dim LegendBrush As New SolidBrush(LegendColor)
            If Symbols.PolluteSymbol.SourceCount > 0 Then
                SymbolShape.SymbolShapeStyle = Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle '��ȾԴ��־����״
                SymbolShape.SymbolShapeColor = Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeColor '��ɫ 
                SymbolShape.DrawSymbolShape(grap, New Rectangle(PannelSetting.gLegendSymbolRect.X, PannelSetting.gLegendSymbolRect.Y, 0.7 * TextHeigth, 0.7 * TextHeigth)) '���Ʊ�־
                grap.DrawString("��ȾԴ", LegendFont, LegendBrush, CSng(PannelSetting.gLegendSymbolRect.X + TextWidth / 2 + 0.2 * TextWidth), PannelSetting.gLegendSymbolRect.Y)
            End If
            If Symbols.CareSymbols.mArrayCareSymbol IsNot Nothing AndAlso Symbols.CareSymbols.mArrayCareSymbol.Length > 0 Then
                PannelSetting.gLegendSymbolRect.Height = 2 * (TextHeigth + 0.2 * TextHeigth)
                SymbolShape.SymbolShapeStyle = Symbols.CareSymbols.mArrayCareSymbol(0).SymbolSign.SymbolShape.SymbolShapeStyle '���ĵ��־����״
                SymbolShape.SymbolShapeColor = Symbols.CareSymbols.mArrayCareSymbol(0).SymbolSign.SymbolShape.SymbolShapeColor '��ɫ 
                SymbolShape.DrawSymbolShape(grap, New Rectangle(PannelSetting.gLegendSymbolRect.X, PannelSetting.gLegendSymbolRect.Y + TextHeigth + 0.2 * TextHeigth, 0.7 * TextHeigth, 0.7 * TextHeigth)) '���Ʊ�־
                grap.DrawString("���ĵ�", LegendFont, LegendBrush, CSng(PannelSetting.gLegendSymbolRect.X + TextWidth / 2 + 0.2 * TextWidth), PannelSetting.gLegendSymbolRect.Y + TextHeigth + 0.2 * TextHeigth)
            End If
            PannelSetting.gLegendSymbolRect.Width = CSng(PannelSetting.gLegendSymbolRect.X + TextWidth / 2 + 0.2 * TextWidth) + TextWidth
        Else
            PannelSetting.gLegendSymbolRect.Height = 0
            PannelSetting.gLegendSymbolRect.Width = 0
        End If
    End Sub

    Public Sub FillBlack(ByVal grap As Graphics, ByVal contours As Contours, ByVal symbols As Symbols) '���ͼ������
        Dim rect As New Rectangle()
        rect = CalculateFillRect(grap, contours, symbols) '��������
        If rect.Width > 0 And rect.Height > 0 Then
            '��������εı߽�
            rect.X = rect.X - 5
            rect.Y = rect.Y - 5
            rect.Width = rect.Width + 10
            rect.Height = rect.Height + 10
            Dim ForeAlpha As Integer 'alpha ֵԽ�ӽ��� 0��������ɫ��Ȩ��Խ��alpha ֵԽ�ӽ��� 255��������ɫ��Ȩ��Խ��
            ForeAlpha = 255 - CInt(BForeTransparent * 2.55)
            Dim ForeColor As Color = Color.FromArgb(ForeAlpha, BForeColor.R, BForeColor.G, BForeColor.B)
            Dim BackAlpha As Integer 'alpha ֵԽ�ӽ��� 0��������ɫ��Ȩ��Խ��alpha ֵԽ�ӽ��� 255��������ɫ��Ȩ��Խ��
            BackAlpha = 255 - CInt(BBackTransparent * 2.55)
            Dim BackColor As Color = Color.FromArgb(BackAlpha, BBackColor.R, BBackColor.G, BBackColor.B)
            Dim SolidBrush As New SolidBrush(ForeColor)
            Dim HatchBrush As New HatchBrush(HatchStyle, ForeColor, BackColor)
            If BFillVisible Then '���ͼ���������
                If BBrushStyle = 0 Then '��ʵ�Ļ�ˢ���
                    grap.FillRectangle(SolidBrush, rect)
                Else '��ͼ����ˢ���
                    grap.FillRectangle(HatchBrush, rect)
                End If
                grap.DrawRectangle(Pens.Black, rect) '���Ʊ߿�
            End If
        End If
    End Sub
    Private Function CalculateFillRect(ByVal grap As Graphics, ByVal contours As Contours, ByVal symbols As Symbols) As Rectangle
        DrawLegendContourFill(grap, contours) ' ���Ƶ�ֵ�����ͼ��
        DrawLegendContourLine(grap, contours) ' ���Ƶ�ֵ��ͼ��
        DrawLegendSymbol(grap, symbols) '���Ʊ�־ͼ��

        Dim rect As New Rectangle()
        rect.Width = PannelSetting.gLegendContourFillRect.Width
        rect.Height = PannelSetting.gLegendContourFillRect.Height + PannelSetting.gLegendContourLineRect.Height + PannelSetting.gLegendSymbolRect.Height
        If rect.Width < PannelSetting.gLegendContourLineRect.Width Then
            rect.Width = PannelSetting.gLegendContourLineRect.Width
        End If
        If rect.Width < PannelSetting.gLegendSymbolRect.Width Then
            rect.Width = PannelSetting.gLegendSymbolRect.Width
        End If
        Return rect
    End Function
End Class
