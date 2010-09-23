Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class Legend
    Public HatchStyle As HatchStyle
    Public BBackColor As Color = Color.White   '填充图案的背景的颜色
    Public BForeColor As Color = Color.White   '填充图案的前景的颜色
    Public BFillVisible As Boolean = False   '背景填充是否可见
    Public BBackTransparent As Integer = 80 '背景透明度。0表示不透明，100表示全透明
    Public BForeTransparent As Integer = 50 '前景透明度。0表示不透明，100表示全透明
    Public BBrushStyle As Integer = 0 '画刷的样式。0为实心画刷，0为图案画刷
    Public SmoothingMode As Boolean = False
    ''' <summary>
    ''' 等值线图例可见
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendContourLineVisible As Boolean = False
    ''' <summary>
    ''' 等值线填充图例可见
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendContourFillVisible As Boolean = True
    ''' <summary>
    ''' 等值线标志图例可见
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendSymbolVisible As Boolean = True
    <NonSerialized()> Private fontFamily As New FontFamily(New GenericFontFamilies)

    ''' <summary>
    '''图例的字体
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendFont As New Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)
    ''' <summary>
    ''' 图例的颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public LegendColor As Color = Color.Black
    ''' <summary>
    ''' 绘制图例
    ''' </summary>
    ''' <param name="Contours">等值线对象</param>
    ''' <param name="Symbols">标志对象</param>
    ''' <remarks>绘制图例</remarks>
    Public Sub DrawLegend(ByVal grap As Graphics, ByVal Contours As Contours, ByVal Symbols As Symbols)

        '在绘制图例前先将绘图画布转换成原来的象素 
        Dim LegendBrush As New SolidBrush(LegendColor)
        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
        graphicsContainer = grap.BeginContainer() '开始嵌套的 Graphics 容器
        myMatrix.Translate(PannelSetting.gRightLegendPoint, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height) '平移到绘等值线填充图的区域的左上角位置
        myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '绘图画布转换成原来的象素 
        myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '反转
        myMatrix.Translate(5, 5)
        grap.Transform = myMatrix
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        FillBlack(grap, Contours, Symbols)
        If SmoothingMode = True Then '消除锯齿
            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        End If
        DrawLegendContourFill(grap, Contours) ' 绘制等值线填充图例
        DrawLegendContourLine(grap, Contours) ' 绘制等值线图例
        DrawLegendSymbol(grap, Symbols) '绘制标志图例
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        grap.EndContainer(graphicsContainer) '退出绘图容器

    End Sub
    ''' <summary>
    ''' 绘制等值线填充图例
    ''' </summary>
    ''' <param name="grap">绘图对象</param>
    ''' <param name="Contours">等值线对象</param>
    ''' <remarks></remarks>
    Private Sub DrawLegendContourFill(ByVal grap As Graphics, ByVal Contours As Contours)

        If LegendContourFillVisible = True Then '如果等值线填充图例可见
            Dim LegendFormat As New StringFormat
            If Contours.ArrayContour IsNot Nothing AndAlso Contours.ArrayContour.Length > 0 Then '如果等值线条数>0进行绘制
                '一共是Contours.ContourCont+1行文字，包括标题。区域的高度应为文字的高度加上间距的高度。间距可取0.2倍文字高度。
                Dim TextWidth, TextHeigth As Double
                TextHeigth = grap.MeasureString("图案", LegendFont).Height
                TextWidth = grap.MeasureString("图案", LegendFont).Width
                PannelSetting.gLegendContourFillRect.Height = (Contours.ArrayContour.Length + 1) * (TextHeigth + 0.2 * TextHeigth)
                Dim i As Integer
                Dim LegendBrush As New SolidBrush(LegendColor)
                '绘制标题
                grap.DrawString("图案", LegendFont, LegendBrush, 0, 0, LegendFormat)
                '绘制图形
                For i = 1 To Contours.ArrayContour.Length
                    Dim ForeAlpha As Integer 'alpha 值越接近于 0，背景颜色的权重越大；alpha 值越接近于 255，线条颜色的权重越大。
                    ForeAlpha = 255 - CInt(Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ForeTransparent * 2.55)
                    Dim ForeColor As Color = Color.FromArgb(ForeAlpha, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourForeColor.R, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourForeColor.G, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourForeColor.B)
                    Dim BackAlpha As Integer 'alpha 值越接近于 0，背景颜色的权重越大；alpha 值越接近于 255，线条颜色的权重越大。
                    BackAlpha = 255 - CInt(Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.BackTransparent * 2.55)
                    Dim BackColor As Color = Color.FromArgb(BackAlpha, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourBackColor.R, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourBackColor.G, Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourBackColor.B)
                    Dim SolidBrush As New SolidBrush(ForeColor)
                    Dim HatchBrush As New HatchBrush(Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.HatchStyle, ForeColor, BackColor)
                    If Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourFillVisible Then '如果等值线可见就填充等值线
                        If Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.BrushStyle = 0 Then '用实心画刷填充
                            grap.FillRectangle(SolidBrush, New Rectangle(0, i * (TextHeigth + 0.2 * TextHeigth) + 0.1 * TextHeigth, TextWidth, TextHeigth - 0.3 * TextHeigth))
                        Else '用图案画刷填充
                            grap.FillRectangle(HatchBrush, New Rectangle(0, i * (TextHeigth + 0.2 * TextHeigth) + 0.1 * TextHeigth, TextWidth, TextHeigth - 0.3 * TextHeigth))
                        End If
                    End If
                Next
                '绘制浓度标题
                Dim TextWidth1 As Integer
                If PannelSetting.PaintType = 0 Then
                    grap.DrawString("值", LegendFont, LegendBrush, TextWidth + 0.2 * TextWidth, 0, LegendFormat)
                    TextWidth1 = grap.MeasureString("值", LegendFont).Width
                Else
                    grap.DrawString("半径(m)", LegendFont, LegendBrush, TextWidth + 0.2 * TextWidth, 0, LegendFormat)
                    TextWidth1 = grap.MeasureString("半径(m)", LegendFont).Width
                End If
                '绘制浓度
                Dim strC As String '浓度
                For i = 1 To Contours.ArrayContour.Length
                    If i = Contours.ArrayContour.Length Then
                        If PannelSetting.PaintType = 0 Then
                            strC = ">" & Contours.ArrayContour(Contours.SortA(i - 1)).ContourValue '大于最大值
                        Else
                            strC = "<" & Contours.ArrayContour(Contours.SortA(i - 1)).ContourValue '大于最大值
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
                '绘制面积标题
                grap.DrawString("面积(m^2)", LegendFont, LegendBrush, TextWidth + TextWidth1 + 0.2 * TextWidth * 2, 0, LegendFormat)
                '绘制面积
                Dim strA As Double = "0" '面积
                Dim FomatStrA As String = ""
                Dim strAWidth As Integer = 0
                For i = 1 To Contours.ArrayContour.Length
                    If i = Contours.ArrayContour.Length Then
                        strA = Contours.ArrayContour(Contours.SortA(i - 1)).ContourFill.ContourArea '最大值的面积
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
                PannelSetting.gLegendContourFillRect.Width = TextWidth + TextWidth1 + 0.2 * TextWidth * 2 + strAWidth '矩形区域的宽度
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
    ''' 绘制等值线图例
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <param name="Contours"></param>
    ''' <remarks></remarks>
    Private Sub DrawLegendContourLine(ByVal grap As Graphics, ByVal Contours As Contours)
        If LegendContourLineVisible = True Then '如果等值线图例可见
            If Contours.ArrayContour IsNot Nothing AndAlso Contours.ArrayContour.Length > 0 Then '如果等值线条数>0进行绘制
                '一共是Contours.ContourCont行文字。区域的高度应为文字的高度加上间距的高度。间距可取0.2倍文字高度。
                Dim TextWidth, TextHeigth As Double
                TextHeigth = grap.MeasureString("等值线", LegendFont).Height
                TextWidth = grap.MeasureString("等值线", LegendFont).Width
                PannelSetting.gLegendContourLineRect.X = PannelSetting.gLegendContourFillRect.X
                PannelSetting.gLegendContourLineRect.Y = PannelSetting.gLegendContourFillRect.Height
                PannelSetting.gLegendContourLineRect.Height = Contours.ArrayContour.Length * (TextHeigth + 0.2 * TextHeigth)
                Dim LegendBrush As New SolidBrush(LegendColor)
                '绘制图形
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
        If LegendSymbolVisible = True Then '如果标志图例可见
            Dim TextWidth, TextHeigth As Double
            TextHeigth = grap.MeasureString("污染源", LegendFont).Height
            TextWidth = grap.MeasureString("污染源", LegendFont).Width
            PannelSetting.gLegendSymbolRect.X = PannelSetting.gLegendContourLineRect.X
            PannelSetting.gLegendSymbolRect.Y = PannelSetting.gLegendContourFillRect.Height + PannelSetting.gLegendContourLineRect.Height
            PannelSetting.gLegendSymbolRect.Height = TextHeigth + 0.2 * TextHeigth
            Dim SymbolShape As New SymbolShape
            Dim LegendBrush As New SolidBrush(LegendColor)
            If Symbols.PolluteSymbol.SourceCount > 0 Then
                SymbolShape.SymbolShapeStyle = Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle '污染源标志的形状
                SymbolShape.SymbolShapeColor = Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeColor '颜色 
                SymbolShape.DrawSymbolShape(grap, New Rectangle(PannelSetting.gLegendSymbolRect.X, PannelSetting.gLegendSymbolRect.Y, 0.7 * TextHeigth, 0.7 * TextHeigth)) '绘制标志
                grap.DrawString("污染源", LegendFont, LegendBrush, CSng(PannelSetting.gLegendSymbolRect.X + TextWidth / 2 + 0.2 * TextWidth), PannelSetting.gLegendSymbolRect.Y)
            End If
            If Symbols.CareSymbols.mArrayCareSymbol IsNot Nothing AndAlso Symbols.CareSymbols.mArrayCareSymbol.Length > 0 Then
                PannelSetting.gLegendSymbolRect.Height = 2 * (TextHeigth + 0.2 * TextHeigth)
                SymbolShape.SymbolShapeStyle = Symbols.CareSymbols.mArrayCareSymbol(0).SymbolSign.SymbolShape.SymbolShapeStyle '关心点标志的形状
                SymbolShape.SymbolShapeColor = Symbols.CareSymbols.mArrayCareSymbol(0).SymbolSign.SymbolShape.SymbolShapeColor '颜色 
                SymbolShape.DrawSymbolShape(grap, New Rectangle(PannelSetting.gLegendSymbolRect.X, PannelSetting.gLegendSymbolRect.Y + TextHeigth + 0.2 * TextHeigth, 0.7 * TextHeigth, 0.7 * TextHeigth)) '绘制标志
                grap.DrawString("关心点", LegendFont, LegendBrush, CSng(PannelSetting.gLegendSymbolRect.X + TextWidth / 2 + 0.2 * TextWidth), PannelSetting.gLegendSymbolRect.Y + TextHeigth + 0.2 * TextHeigth)
            End If
            PannelSetting.gLegendSymbolRect.Width = CSng(PannelSetting.gLegendSymbolRect.X + TextWidth / 2 + 0.2 * TextWidth) + TextWidth
        Else
            PannelSetting.gLegendSymbolRect.Height = 0
            PannelSetting.gLegendSymbolRect.Width = 0
        End If
    End Sub

    Public Sub FillBlack(ByVal grap As Graphics, ByVal contours As Contours, ByVal symbols As Symbols) '填充图例背景
        Dim rect As New Rectangle()
        rect = CalculateFillRect(grap, contours, symbols) '计算区域
        If rect.Width > 0 And rect.Height > 0 Then
            '先扩大矩形的边界
            rect.X = rect.X - 5
            rect.Y = rect.Y - 5
            rect.Width = rect.Width + 10
            rect.Height = rect.Height + 10
            Dim ForeAlpha As Integer 'alpha 值越接近于 0，背景颜色的权重越大；alpha 值越接近于 255，线条颜色的权重越大。
            ForeAlpha = 255 - CInt(BForeTransparent * 2.55)
            Dim ForeColor As Color = Color.FromArgb(ForeAlpha, BForeColor.R, BForeColor.G, BForeColor.B)
            Dim BackAlpha As Integer 'alpha 值越接近于 0，背景颜色的权重越大；alpha 值越接近于 255，线条颜色的权重越大。
            BackAlpha = 255 - CInt(BBackTransparent * 2.55)
            Dim BackColor As Color = Color.FromArgb(BackAlpha, BBackColor.R, BBackColor.G, BBackColor.B)
            Dim SolidBrush As New SolidBrush(ForeColor)
            Dim HatchBrush As New HatchBrush(HatchStyle, ForeColor, BackColor)
            If BFillVisible Then '如果图例背景填充
                If BBrushStyle = 0 Then '用实心画刷填充
                    grap.FillRectangle(SolidBrush, rect)
                Else '用图案画刷填充
                    grap.FillRectangle(HatchBrush, rect)
                End If
                grap.DrawRectangle(Pens.Black, rect) '绘制边框
            End If
        End If
    End Sub
    Private Function CalculateFillRect(ByVal grap As Graphics, ByVal contours As Contours, ByVal symbols As Symbols) As Rectangle
        DrawLegendContourFill(grap, contours) ' 绘制等值线填充图例
        DrawLegendContourLine(grap, contours) ' 绘制等值线图例
        DrawLegendSymbol(grap, symbols) '绘制标志图例

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
