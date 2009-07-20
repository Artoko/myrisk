Imports System.Drawing.Drawing2D
Public Class ContourPorpertyForm
    Public SettingPannel As Pannel '当前绘图类

    Public ContourPaintSetting As ContourPaintSetting 


    Private filename As String '背景图文件名
    Private arrBrushStyleName() As String '画刷样式的名称数组，0-4
    Private brhStyle() As HatchBrush  '画刷数组
    Private arrSymbolShapeName() As String '标志形状的名称数组，0-4
    Private BoolRefresh As Boolean = False '刷新标志


    Private Sub ContourPorpertyForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化对话框的设置
        If Not SettingPannel Is Nothing Then
            If ActivePaintForm.ContourPaintSetting.ChartType = 1 Then '火灾爆炸型
                TabContour.Text = "伤害线"
                Gradient.Text = "伤害线颜色渐变"
                lblContour.Text = "伤害半径(m)"
                ContourLineProperty.Text = "伤害线"
                chkContourVisible.Visible = False
                chkContourLabelVisible.Visible = False
                chkContourFillVisible.Text = "填充伤害范围可见"
            End If
        End If
        BoolRefresh = False
        InitialBrushStyle() '初始化等值线填充画刷
        listAxis.SelectedIndex = 0 '坐标轴设置为左轴
        InitialSymbolShapeStyle() '初始化标志填充样式
        listSymbolType.SelectedIndex = 0 '初始化为选中污染源
        If Not SettingPannel Is Nothing Then
            chkBackVisible.Checked = SettingPannel.BackImage.BackVisible '初始化为
            chkBackInside.Checked = SettingPannel.BackImage.BackInside '初始化为
            Dim i As Double
            ListBoxContour.Items.Clear()
            For i = 0 To ActivePaintForm.ContourPaintSetting.ContourValue.Length - 1
                ListBoxContour.Items.Add(CSng(ActivePaintForm.ContourPaintSetting.ContourValue(i))) '加入等值线值
            Next
            If ListBoxContour.Items.Count > 0 Then '如果不零则设置第一项为选中
                ListBoxContour.SelectedIndex = 0
            End If
            chkLegendContourFillVisible.Checked = SettingPannel.Legend.LegendContourFillVisible '设置等值线填充图例
            chkLegendContourLineVisible.Checked = SettingPannel.Legend.LegendContourLineVisible '设置等值线画线图例
            chkLegendSymbolVisible.Checked = SettingPannel.Legend.LegendSymbolVisible
            chkFillLegend.Checked = SettingPannel.Legend.BFillVisible

            cmdLegendColor.GradColor = SettingPannel.Legend.LegendColor

        End If
        BoolRefresh = True
        If Not SettingPannel Is Nothing Then
            Dim i As Double
            For i = 0 To ListBoxContour.Items.Count - 1
                txtNumber.Value = SettingPannel.Contours.ArrayContour(i).ContourLine.Number
            Next
        End If

    End Sub

    Private Sub chkAxisVisualble_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAxisVisible.CheckedChanged

        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    SettingPannel.Axes.LeftAxis.AxisLine.AxisVisible = chkAxisVisible.Checked
                Case 1 '底轴
                    SettingPannel.Axes.BottomAxis.AxisLine.AxisVisible = chkAxisVisible.Checked
                Case 2 '右轴
                    SettingPannel.Axes.RightAxis.AxisLine.AxisVisible = chkAxisVisible.Checked
                Case 3 '顶轴
                    SettingPannel.Axes.TopAxis.AxisLine.AxisVisible = chkAxisVisible.Checked
            End Select
        End If
        Me.ReflashAll()
    End Sub

    Private Sub listAxis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listAxis.SelectedIndexChanged
        BoolRefresh = False
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线和当前的坐标线画笔
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    chkAxisVisible.Checked = SettingPannel.Axes.LeftAxis.AxisLine.AxisVisible '根据绘图左轴线的可见性确定对话框该选项的值
                    chkTitleVisible.Checked = SettingPannel.Axes.LeftAxis.AxisTitle.TitleVisible '坐标标题是否可见
                    txtTitleName.Text = SettingPannel.Axes.LeftAxis.AxisTitle.TitleName '坐标轴标题
                    chkMainScaleVisible.Checked = SettingPannel.Axes.LeftAxis.MainAxisScale.ScaleVisible '刻度线是否可见
                    txtMin.Text = SettingPannel.Axes.LeftAxis.MainAxisScale.Min  '轴的最小值
                    txtMax.Text = SettingPannel.Axes.LeftAxis.MainAxisScale.Max   '轴的最大值
                    txtIncrease.Text = SettingPannel.Axes.LeftAxis.MainAxisScale.Increase '增加值
                    chkLabelVisible.Checked = SettingPannel.Axes.LeftAxis.AxisLabel.LabelVisible '标注是否可见
                    chkGriddingVisible.Checked = SettingPannel.Axes.LeftAxis.AxisGridding.AxisGriddingVisible '网格是否可见
                Case 1 '底轴
                    chkAxisVisible.Checked = SettingPannel.Axes.BottomAxis.AxisLine.AxisVisible
                    chkTitleVisible.Checked = SettingPannel.Axes.BottomAxis.AxisTitle.TitleVisible '坐标标题是否可见
                    txtTitleName.Text = SettingPannel.Axes.BottomAxis.AxisTitle.TitleName '坐标轴标题
                    chkMainScaleVisible.Checked = SettingPannel.Axes.BottomAxis.MainAxisScale.ScaleVisible '刻度线是否可见
                    txtMin.Text = SettingPannel.Axes.BottomAxis.MainAxisScale.Min  '轴的最小值
                    txtMax.Text = SettingPannel.Axes.BottomAxis.MainAxisScale.Max   '轴的最大值
                    txtIncrease.Text = SettingPannel.Axes.BottomAxis.MainAxisScale.Increase '增加值
                    chkLabelVisible.Checked = SettingPannel.Axes.BottomAxis.AxisLabel.LabelVisible '标注是否可见
                    chkGriddingVisible.Checked = SettingPannel.Axes.BottomAxis.AxisGridding.AxisGriddingVisible '网格是否可见
                Case 2 '右轴
                    chkAxisVisible.Checked = SettingPannel.Axes.RightAxis.AxisLine.AxisVisible
                    chkTitleVisible.Checked = SettingPannel.Axes.RightAxis.AxisTitle.TitleVisible '坐标标题是否可见
                    txtTitleName.Text = SettingPannel.Axes.RightAxis.AxisTitle.TitleName '坐标轴标题
                    chkMainScaleVisible.Checked = SettingPannel.Axes.RightAxis.MainAxisScale.ScaleVisible '刻度线是否可见
                    chkMainScaleVisible.Checked = SettingPannel.Axes.RightAxis.MainAxisScale.ScaleVisible '刻度线是否可见
                    txtMin.Text = SettingPannel.Axes.RightAxis.MainAxisScale.Min  '轴的最小值
                    txtMax.Text = SettingPannel.Axes.RightAxis.MainAxisScale.Max   '轴的最大值
                    txtIncrease.Text = SettingPannel.Axes.RightAxis.MainAxisScale.Increase '增加值
                    chkLabelVisible.Checked = SettingPannel.Axes.RightAxis.AxisLabel.LabelVisible '标注是否可见
                    chkGriddingVisible.Checked = SettingPannel.Axes.RightAxis.AxisGridding.AxisGriddingVisible '网格是否可见

                Case 3 '顶轴
                    chkAxisVisible.Checked = SettingPannel.Axes.TopAxis.AxisLine.AxisVisible
                    chkTitleVisible.Checked = SettingPannel.Axes.TopAxis.AxisTitle.TitleVisible '坐标标题是否可见
                    txtTitleName.Text = SettingPannel.Axes.TopAxis.AxisTitle.TitleName '坐标轴标题
                    chkMainScaleVisible.Checked = SettingPannel.Axes.TopAxis.MainAxisScale.ScaleVisible '刻度线是否可见
                    txtMin.Text = SettingPannel.Axes.TopAxis.MainAxisScale.Min  '轴的最小值
                    txtMax.Text = SettingPannel.Axes.TopAxis.MainAxisScale.Max   '轴的最大值
                    txtIncrease.Text = SettingPannel.Axes.TopAxis.MainAxisScale.Increase '增加值
                    chkLabelVisible.Checked = SettingPannel.Axes.TopAxis.AxisLabel.LabelVisible '标注是否可见
                    chkGriddingVisible.Checked = SettingPannel.Axes.TopAxis.AxisGridding.AxisGriddingVisible '网格是否可见
            End Select
        End If
        Me.Refresh()
        BoolRefresh = True
    End Sub

    Private Sub picAxisLineStyle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picAxisLineStyle.Paint
        '绘制坐标线的线型
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Dim myMatrix As New Matrix()
            myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '调整比例
            e.Graphics.Transform = myMatrix
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    Dim PenProperty As PenProperty = SettingPannel.Axes.LeftAxis.AxisLine.PenProperty
                    Dim LinePen As New Pen(Color.FromArgb(PenProperty.color), PenProperty.Width)
                    LinePen.DashStyle = PenProperty.DashStyle
                    e.Graphics.DrawLine(LinePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 1 '底轴
                    Dim PenProperty As PenProperty = SettingPannel.Axes.BottomAxis.AxisLine.PenProperty
                    Dim LinePen As New Pen(Color.FromArgb(PenProperty.color), PenProperty.Width)
                    LinePen.DashStyle = PenProperty.DashStyle
                    e.Graphics.DrawLine(LinePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 2 '右轴
                    Dim PenProperty As PenProperty = SettingPannel.Axes.RightAxis.AxisLine.PenProperty
                    Dim LinePen As New Pen(Color.FromArgb(PenProperty.color), PenProperty.Width)
                    LinePen.DashStyle = PenProperty.DashStyle
                    e.Graphics.DrawLine(LinePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 3 '顶轴
                    Dim PenProperty As PenProperty = SettingPannel.Axes.TopAxis.AxisLine.PenProperty
                    Dim LinePen As New Pen(Color.FromArgb(PenProperty.color), PenProperty.Width)
                    LinePen.DashStyle = PenProperty.DashStyle
                    e.Graphics.DrawLine(LinePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
            End Select
        End If
    End Sub

    Private Sub cmdAxisLineStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxisLineStyle.Click
        Dim frmLineStyle As New LineStyleEditor
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.LeftAxis.AxisLine.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.LeftAxis.AxisLine.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisLine.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.LeftAxis.AxisLine.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.LeftAxis.AxisLine.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.LeftAxis.AxisLine.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
                Case 1 '底轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.BottomAxis.AxisLine.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.BottomAxis.AxisLine.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisLine.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.BottomAxis.AxisLine.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.BottomAxis.AxisLine.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.BottomAxis.AxisLine.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
                Case 2 '右轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.RightAxis.AxisLine.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.RightAxis.AxisLine.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisLine.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.RightAxis.AxisLine.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.RightAxis.AxisLine.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.RightAxis.AxisLine.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
                Case 3 '顶轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.TopAxis.AxisLine.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.TopAxis.AxisLine.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisLine.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.TopAxis.AxisLine.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.TopAxis.AxisLine.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.TopAxis.AxisLine.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub chkTitleVasuable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTitleVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    SettingPannel.Axes.LeftAxis.AxisTitle.TitleVisible = chkTitleVisible.Checked
                Case 1 '底轴
                    SettingPannel.Axes.BottomAxis.AxisTitle.TitleVisible = chkTitleVisible.Checked
                Case 2 '右轴
                    SettingPannel.Axes.RightAxis.AxisTitle.TitleVisible = chkTitleVisible.Checked
                Case 3 '顶轴
                    SettingPannel.Axes.TopAxis.AxisTitle.TitleVisible = chkTitleVisible.Checked
            End Select
        End If
        Me.ReflashAll()
    End Sub

    Private Sub txtTitleName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTitleName.Validating
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    SettingPannel.Axes.LeftAxis.AxisTitle.TitleName = txtTitleName.Text
                Case 1 '底轴
                    SettingPannel.Axes.BottomAxis.AxisTitle.TitleName = txtTitleName.Text
                Case 2 '右轴
                    SettingPannel.Axes.RightAxis.AxisTitle.TitleName = txtTitleName.Text
                Case 3 '顶轴
                    SettingPannel.Axes.TopAxis.AxisTitle.TitleName = txtTitleName.Text
            End Select
        End If
        Me.ReflashAll()
    End Sub

    Private Sub cmdAxesTitleColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxesTitleColor.Click
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisTitle.TitleColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.LeftAxis.AxisTitle.TitleColor = colorDlg.Color.ToArgb
                    End If
                Case 1 '底轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisTitle.TitleColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.BottomAxis.AxisTitle.TitleColor = colorDlg.Color.ToArgb
                    End If
                Case 2 '右轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisTitle.TitleColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.RightAxis.AxisTitle.TitleColor = colorDlg.Color.ToArgb
                    End If
                Case 3 '顶轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisTitle.TitleColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.TopAxis.AxisTitle.TitleColor = colorDlg.Color.ToArgb
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub cmdAxesTitleColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdAxesTitleColor.Paint
        Dim mycolor As Color
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisTitle.TitleColor)
                Case 1 '底轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisTitle.TitleColor)
                Case 2 '右轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisTitle.TitleColor)
                Case 3 '顶轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisTitle.TitleColor)
            End Select
        End If
        Dim rect As New Rectangle(5, 5, 30, cmdAxesTitleColor.Height - 10)
        Dim LineBrush As New SolidBrush(mycolor)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub cmdTitleFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTitleFont.Click
        Dim fontDlg As New FontDialog
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    fontDlg.Font = SettingPannel.Axes.LeftAxis.AxisTitle.TitleFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.LeftAxis.AxisTitle.TitleFont = fontDlg.Font
                    End If
                Case 1 '底轴
                    fontDlg.Font = SettingPannel.Axes.BottomAxis.AxisTitle.TitleFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.BottomAxis.AxisTitle.TitleFont = fontDlg.Font
                    End If
                Case 2 '右轴
                    fontDlg.Font = SettingPannel.Axes.RightAxis.AxisTitle.TitleFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.RightAxis.AxisTitle.TitleFont = fontDlg.Font
                    End If
                Case 3 '顶轴
                    fontDlg.Font = SettingPannel.Axes.TopAxis.AxisTitle.TitleFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.TopAxis.AxisTitle.TitleFont = fontDlg.Font
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub chkMainScaleVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMainScaleVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该刻度线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    SettingPannel.Axes.LeftAxis.MainAxisScale.ScaleVisible = chkMainScaleVisible.Checked
                Case 1 '底轴
                    SettingPannel.Axes.BottomAxis.MainAxisScale.ScaleVisible = chkMainScaleVisible.Checked
                Case 2 '右轴
                    SettingPannel.Axes.RightAxis.MainAxisScale.ScaleVisible = chkMainScaleVisible.Checked
                Case 3 '顶轴
                    SettingPannel.Axes.TopAxis.MainAxisScale.ScaleVisible = chkMainScaleVisible.Checked
            End Select
        End If
        Me.ReflashAll()
    End Sub


    Private Sub txtMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMin.TextChanged

    End Sub

    Private Sub txtMin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMin.Validating
        If Not IsNumeric(txtMin.Text) Then
            ErrorProvider1.SetError(txtMin, "您输入的不是数值")
        ElseIf CSng(txtMin.Text) >= CSng(txtMax.Text) Then
            ErrorProvider1.SetError(txtMin, "数轴的最小值必须<最大值")
        Else
            ErrorProvider1.SetError(txtMin, "")
            ErrorProvider1.SetError(txtMax, "")
            If Not SettingPannel Is Nothing Then
                '根据当前选中的边轴确定是否绘该刻度线
                Select Case listAxis.SelectedIndex
                    Case 0 '左轴或右轴
                        SettingPannel.Axes.LeftAxis.MainAxisScale.Min = CSng(txtMin.Text)
                    Case 1 '底轴
                        SettingPannel.Axes.BottomAxis.MainAxisScale.Min = CSng(txtMin.Text)
                    Case 2 '右轴
                        SettingPannel.Axes.RightAxis.MainAxisScale.Min = CSng(txtMin.Text)
                    Case 3 '顶轴
                        SettingPannel.Axes.TopAxis.MainAxisScale.Min = CSng(txtMin.Text)
                End Select
            End If
            Me.ReflashAll()
        End If
    End Sub

    Private Sub txtMax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMax.Validating
        If Not IsNumeric(txtMax.Text) Then
            ErrorProvider1.SetError(txtMax, "您输入的不是数值")
        ElseIf CSng(txtMax.Text) <= CSng(txtMin.Text) Then
            ErrorProvider1.SetError(txtMax, "数轴的最大值必须>最小值")
        Else
            ErrorProvider1.SetError(txtMin, "")
            ErrorProvider1.SetError(txtMax, "")
            If Not SettingPannel Is Nothing Then
                '根据当前选中的边轴确定是否绘该刻度线
                Select Case listAxis.SelectedIndex
                    Case 0 '左轴或右轴
                        SettingPannel.Axes.LeftAxis.MainAxisScale.Max = CSng(txtMax.Text)
                    Case 1 '底轴
                        SettingPannel.Axes.BottomAxis.MainAxisScale.Max = CSng(txtMax.Text)
                    Case 2 '右轴
                        SettingPannel.Axes.RightAxis.MainAxisScale.Max = CSng(txtMax.Text)
                    Case 3 '顶轴
                        SettingPannel.Axes.TopAxis.MainAxisScale.Max = CSng(txtMax.Text)
                End Select

            End If
            Me.ReflashAll()
        End If
    End Sub

    Private Sub txtIncrease_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncrease.TextChanged

    End Sub

    Private Sub txtIncrease_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIncrease.Validating
        If Not IsNumeric(txtIncrease.Text) Then
            ErrorProvider1.SetError(txtIncrease, "您输入的不是数值")
        ElseIf CSng(txtIncrease.Text) <= 0 Then
            ErrorProvider1.SetError(txtIncrease, "数轴的间隔必须>0")
        Else
            ErrorProvider1.SetError(txtIncrease, "")
            If Not SettingPannel Is Nothing Then
                '根据当前选中的边轴确定是否绘该刻度线
                Select Case listAxis.SelectedIndex
                    Case 0 '左轴或右轴
                        SettingPannel.Axes.LeftAxis.MainAxisScale.Increase = CSng(txtIncrease.Text)
                    Case 1 '底轴
                        SettingPannel.Axes.BottomAxis.MainAxisScale.Increase = CSng(txtIncrease.Text)
                    Case 2 '右轴
                        SettingPannel.Axes.RightAxis.MainAxisScale.Increase = CSng(txtIncrease.Text)
                    Case 3 '顶轴
                        SettingPannel.Axes.TopAxis.MainAxisScale.Increase = CSng(txtIncrease.Text)
                End Select
            End If
            Me.ReflashAll()
        End If
    End Sub

    Private Sub picAxisLineStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAxisLineStyle.Click

    End Sub

    Private Sub picMainScaleLineStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMainScaleLineStyle.Click

    End Sub

    Private Sub picMainScaleLineStyle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMainScaleLineStyle.Paint
        '绘制坐标线的线型
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Dim myMatrix As New Matrix()
            myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '调整比例
            e.Graphics.Transform = myMatrix
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    Dim ScalePen As New Pen(Color.FromArgb(SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.color))
                    ScalePen.Width = SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.Width
                    ScalePen.DashStyle = SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.DashStyle
                    e.Graphics.DrawLine(ScalePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 1 '底轴
                    Dim ScalePen As New Pen(Color.FromArgb(SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.color))
                    ScalePen.Width = SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.Width
                    ScalePen.DashStyle = SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.DashStyle

                    e.Graphics.DrawLine(ScalePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 2 '右轴
                    Dim ScalePen As New Pen(Color.FromArgb(SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.color))
                    ScalePen.Width = SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.Width
                    ScalePen.DashStyle = SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.DashStyle
                    e.Graphics.DrawLine(ScalePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 3 '顶轴
                    Dim ScalePen As New Pen(Color.FromArgb(SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.color))
                    ScalePen.Width = SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.Width
                    ScalePen.DashStyle = SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.DashStyle
                    e.Graphics.DrawLine(ScalePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
            End Select
        End If
    End Sub

    Private Sub cmdMainScaleLineStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMainScaleLineStyle.Click
        Dim frmLineStyle As New LineStyleEditor
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.LeftAxis.MainAxisScale.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
                Case 1 '底轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.BottomAxis.MainAxisScale.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
                Case 2 '右轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.RightAxis.MainAxisScale.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
                Case 3 '顶轴
                    '分别赋给属性值，进行值传递，并调整宽度比例
                    frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.DashStyle
                    frmLineStyle.penCurLineStyle.Width = SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.Width / PannelSetting.gScale
                    frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.color)
                    If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                        SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                        SettingPannel.Axes.TopAxis.MainAxisScale.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub picAxesTilteFont_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picAxesTilteFont.Paint
        Dim mycolor As Color = Color.Black
        Dim myfont As Font = New Font(SettingPannel.Axes.LeftAxis.AxisTitle.TitleFont, FontStyle.Regular)
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisTitle.TitleColor)
                    myfont = SettingPannel.Axes.LeftAxis.AxisTitle.TitleFont
                Case 1 '底轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisTitle.TitleColor)
                    myfont = SettingPannel.Axes.BottomAxis.AxisTitle.TitleFont
                Case 2 '右轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisTitle.TitleColor)
                    myfont = SettingPannel.Axes.RightAxis.AxisTitle.TitleFont
                Case 3 '顶轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisTitle.TitleColor)
                    myfont = SettingPannel.Axes.TopAxis.AxisTitle.TitleFont
            End Select
        End If
        Dim mybrush As New SolidBrush(mycolor)
        e.Graphics.DrawString("示例", myfont, mybrush, 5, 5)
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged

    End Sub

    Private Sub cmdApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplication.Click
        Me.ReflashAll()
    End Sub
    Private Sub ReflashAll()
        '如果当前窗体为等值线绘图窗体，则根据用户的选择改变
        If BoolRefresh = True Then '
            ActivePaintForm.Refresh()
        End If
    End Sub

    Private Sub cmdAxisLabelFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxisLabelFont.Click
        Dim fontDlg As New FontDialog
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    fontDlg.Font = SettingPannel.Axes.LeftAxis.AxisLabel.LabelFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.LeftAxis.AxisLabel.LabelFont = fontDlg.Font
                    End If
                Case 1 '底轴
                    fontDlg.Font = SettingPannel.Axes.BottomAxis.AxisLabel.LabelFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.BottomAxis.AxisLabel.LabelFont = fontDlg.Font
                    End If
                Case 2 '右轴
                    fontDlg.Font = SettingPannel.Axes.RightAxis.AxisLabel.LabelFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.RightAxis.AxisLabel.LabelFont = fontDlg.Font
                    End If
                Case 3 '顶轴
                    fontDlg.Font = SettingPannel.Axes.TopAxis.AxisLabel.LabelFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.TopAxis.AxisLabel.LabelFont = fontDlg.Font
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub cmdAxisLaberColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxisLaberColor.Click
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisLabel.LabelColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.LeftAxis.AxisLabel.LabelColor = colorDlg.Color.ToArgb
                    End If
                Case 1 '底轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisLabel.LabelColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.BottomAxis.AxisLabel.LabelColor = colorDlg.Color.ToArgb
                    End If
                Case 2 '右轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisLabel.LabelColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.RightAxis.AxisLabel.LabelColor = colorDlg.Color.ToArgb
                    End If
                Case 3 '顶轴
                    colorDlg.Color = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisLabel.LabelColor)
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Axes.TopAxis.AxisLabel.LabelColor = colorDlg.Color.ToArgb
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub cmdAxisLaberColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdAxisLaberColor.Paint
        Dim mycolor As Color
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisLabel.LabelColor)
                Case 1 '底轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisLabel.LabelColor)
                Case 2 '右轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisLabel.LabelColor)
                Case 3 '顶轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisLabel.LabelColor)
            End Select
        End If
        Dim rect As New Rectangle(5, 5, 30, cmdAxisLaberColor.Height - 10)
        Dim LineBrush As New SolidBrush(mycolor)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub picAxesTilteFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAxesTilteFont.Click

    End Sub

    Private Sub picAxisLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAxisLabel.Click

    End Sub

    Private Sub picAxisLabel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picAxisLabel.Paint
        Dim mycolor As Color = Color.Black
        Dim myfont As Font = New Font(SettingPannel.Axes.LeftAxis.AxisLabel.LabelFont, FontStyle.Regular)
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisLabel.LabelColor)
                    myfont = SettingPannel.Axes.LeftAxis.AxisLabel.LabelFont
                Case 1 '底轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisLabel.LabelColor)
                    myfont = SettingPannel.Axes.BottomAxis.AxisLabel.LabelFont
                Case 2 '右轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisLabel.LabelColor)
                    myfont = SettingPannel.Axes.RightAxis.AxisLabel.LabelFont
                Case 3 '顶轴
                    mycolor = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisLabel.LabelColor)
                    myfont = SettingPannel.Axes.TopAxis.AxisLabel.LabelFont
            End Select
        End If
        Dim mybrush As New SolidBrush(mycolor)
        e.Graphics.DrawString("示例", myfont, mybrush, 5, 5)
    End Sub

    Private Sub chkLabelVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLabelVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Select Case listAxis.SelectedIndex
                Case 0 '左轴
                    SettingPannel.Axes.LeftAxis.AxisLabel.LabelVisible = chkLabelVisible.Checked
                Case 1 '底轴
                    SettingPannel.Axes.BottomAxis.AxisLabel.LabelVisible = chkLabelVisible.Checked
                Case 2 '右轴
                    SettingPannel.Axes.RightAxis.AxisLabel.LabelVisible = chkLabelVisible.Checked
                Case 3 '顶轴
                    SettingPannel.Axes.TopAxis.AxisLabel.LabelVisible = chkLabelVisible.Checked
            End Select
        End If
        Me.ReflashAll()
    End Sub


    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InsertBackImage(SettingPannel)
        filename = ImageFileName
        Me.Refresh()
        Me.ReflashAll()
    End Sub
    Private Sub picBack_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim rect As Rectangle
        'rect.Width = picBack.Width
        'rect.Height = picBack.Height
        If filename <> "" Then
            Dim img As Image = Image.FromFile(filename)
            If TypeOf (img) Is Image Then
                e.Graphics.DrawImage(img, rect)
            End If
        End If

    End Sub

    Private Sub chkBackVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            SettingPannel.BackImage.BackVisible = chkBackVisible.Checked
            Me.ReflashAll()
        End If
        Me.Refresh()
    End Sub

    Private Sub chkBackInside_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackInside.CheckedChanged
        If Not SettingPannel Is Nothing Then
            SettingPannel.BackImage.BackInside = chkBackInside.Checked
            Me.ReflashAll()
        End If
        Me.Refresh()
    End Sub

    Private Sub cmdIntialContour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newInitial As New dlgInitialContour
    End Sub

    Private Sub txtMax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMax.TextChanged

    End Sub

    Private Sub chkContourVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContourVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.ContourLineVisible = chkContourVisible.Checked
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub ListBoxContour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxContour.SelectedIndexChanged
        BoolRefresh = False
        If Not SettingPannel Is Nothing Then
            '根据当前选中的等值线值确定设置对话框中的等值线选项
            chkContourVisible.Checked = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.ContourLineVisible '等值线
            chkHurtRangeVisible.Checked = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.HurtVisible '等值线
            chkContourLabelVisible.Checked = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelVisible
            chkHurtRangeLabelVisible.Checked = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.HurtLaberVisible
            chkContourFillVisible.Checked = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourFillVisible
            ForeTransparent.Value = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ForeTransparent
            BackTransparent.Value = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.BackTransparent
            cmbContourFillMode.SelectedIndex = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.BrushStyle '画刷样式
            cmbBrushStyle.SelectedIndex = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.HatchStyle '图案画刷的样式

        End If
        Me.Refresh()
        BoolRefresh = True
    End Sub

    Private Sub cmdContourLineStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContourLineStyle.Click
        If Not SettingPannel Is Nothing Then
            '分别赋给属性值，进行值传递，并调整宽度比例
            Dim frmLineStyle As New LineStyleEditor
            frmLineStyle.penCurLineStyle.DashStyle = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.PenProperty.DashStyle
            frmLineStyle.penCurLineStyle.Width = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.PenProperty.Width / PannelSetting.gScale
            frmLineStyle.penCurLineStyle.Color = Color.FromArgb(SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.PenProperty.color)
            If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                Dim i As Double
                For i = 0 To ListBoxContour.SelectedItems.Count - 1
                    SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.PenProperty.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
                    SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.PenProperty.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
                    SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.PenProperty.color = frmLineStyle.penCurLineStyle.Color.ToArgb
                Next
                Me.ReflashAll()
                Me.Refresh()
            End If
        End If
        '根据当前选中的边轴确定是否绘图该座标线
    End Sub

    Private Sub picContourLineStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picContourLineStyle.Click

    End Sub

    Private Sub picContourLineStyle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picContourLineStyle.Paint
        '绘制坐标线的线型
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Dim myMatrix As New Matrix()
            myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '调整比例
            e.Graphics.Transform = myMatrix
            If ListBoxContour.Items.Count > 0 Then
                If ListBoxContour.SelectedIndex < 0 Then
                    ListBoxContour.SelectedIndex = 0
                End If
                Dim ContourLinePen As New Pen(Color.FromArgb(SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.PenProperty.color))
                ContourLinePen.Width = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.PenProperty.Width
                ContourLinePen.DashStyle = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.PenProperty.DashStyle
                e.Graphics.DrawLine(ContourLinePen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
            End If
        End If
    End Sub

    Private Sub chkContourLabelVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContourLabelVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.LabelVisible = chkContourLabelVisible.Checked
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub cmdContourLabelFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContourLabelFont.Click
        Dim fontDlg As New FontDialog
        If Not SettingPannel Is Nothing Then
            fontDlg.Font = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelFont
            If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                Dim i As Double
                For i = 0 To ListBoxContour.SelectedItems.Count - 1
                    SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.LabelFont = fontDlg.Font
                Next
                Me.ReflashAll()
                Me.Refresh()
            End If
        End If
    End Sub
    Private Sub picContourLabelFont_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picContourLabelFont.Paint
        If ListBoxContour.SelectedIndex >= 0 Then
            Dim mycolor As Color = Color.Black
            Dim myfont As Font = New Font(SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelFont, FontStyle.Regular)
            If Not SettingPannel Is Nothing Then
                mycolor = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelColor
                myfont = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelFont
            End If
            Dim mybrush As New SolidBrush(mycolor)
            e.Graphics.DrawString("示例", myfont, mybrush, 5, 5)
        End If
    End Sub

    '填充样式--------------------------------------------------------------------------------
    Public Sub InitialBrushStyle()
        '初始化绘图画刷等
        cmbContourFillMode.SelectedIndex = 0 '实体填充
        cmbBrushStyle.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '设置为可重绘下拉列表框
        cmbBrushStyle.DropDownStyle = ComboBoxStyle.DropDownList '设置为下拉列表框
        Dim i As Integer
        ReDim arrBrushStyleName(0 To 50)
        For i = 0 To 50
            Dim myhatchstyle As HatchStyle
            myhatchstyle = i
            arrBrushStyleName(i) = myhatchstyle.ToString
        Next
        ReDim brhStyle(0 To 50)
        For i = 0 To 50
            Dim myhatchstyle As HatchStyle
            myhatchstyle = i
            brhStyle(i) = New HatchBrush(myhatchstyle, Color.Red, Color.Yellow)
        Next
        cmbBrushStyle.DataSource = arrBrushStyleName '这条语句不能放到前面

        '初始化为实体填充时变灰
        cmbBrushStyle.Enabled = False
        cmdBackColor.Enabled = False
        BackTransparent.Enabled = False
    End Sub
    Public Sub DrawItemBrushStyle(ByVal e As System.Windows.Forms.DrawItemEventArgs) '绘制填充样式
        e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds)
        e.Graphics.FillRectangle(brhStyle(e.Index), 3, e.Bounds.Y + 3, e.Bounds.Height - 6, e.Bounds.Height - 6)
        e.Graphics.DrawString(arrBrushStyleName(e.Index), e.Font, Brushes.White, 3 + 3 + e.Bounds.Height - 6, e.Bounds.Y + 3)
        'is the mouse hovering over a combobox item??			
        If (e.State = DrawItemState.None) Then
            'this code keeps the last item drawn from having a Bisque background. 
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            e.Graphics.FillRectangle(brhStyle(e.Index), 3, e.Bounds.Y + 3, e.Bounds.Height - 6, e.Bounds.Height - 6)
            e.Graphics.DrawString(arrBrushStyleName(e.Index), e.Font, Brushes.Black, 3 + 3 + e.Bounds.Height - 6, e.Bounds.Y + 3)
        End If
    End Sub

    Private Sub cmbBrushStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cmbBrushStyle.DrawItem
        DrawItemBrushStyle(e)
    End Sub

    Private Sub cmbBrushStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrushStyle.SelectedIndexChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.HatchStyle = cmbBrushStyle.SelectedIndex '图案画刷的样式
            Next
        End If

        Me.ReflashAll()
        Me.Refresh()
    End Sub

    Private Sub PicModel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicModel.Paint
        If Not SettingPannel Is Nothing Then
            If ListBoxContour.SelectedIndex >= 0 Then
                If cmbContourFillMode.SelectedIndex = 0 Then '实体填充
                    Dim mySolidBrush As New SolidBrush(SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourForeColor)
                    e.Graphics.FillRectangle(mySolidBrush, 0, 0, PicModel.Width, PicModel.Height)
                Else
                    Dim myhatchstyle As HatchStyle
                    myhatchstyle = cmbBrushStyle.SelectedIndex '画刷的样式
                    Dim myBrush As New HatchBrush(myhatchstyle, SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourForeColor, SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourBackColor)
                    e.Graphics.FillRectangle(myBrush, 0, 0, PicModel.Width, PicModel.Height)
                End If
            End If
        End If
    End Sub

    Private Sub cmdBackColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBackColor.Click
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            colorDlg.Color = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourBackColor
            If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将画笔给当前画笔
                Dim i As Double
                For i = 0 To ListBoxContour.SelectedItems.Count - 1
                    SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.ContourBackColor = colorDlg.Color
                Next
                Me.ReflashAll()
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub cmdBackColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdBackColor.Paint

        If Not SettingPannel Is Nothing Then
            If ListBoxContour.SelectedIndex >= 0 Then
                Dim rect As New Rectangle(5, 5, 30, cmdBackColor.Height - 10)
                Dim LineBrush As New SolidBrush(SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourBackColor)
                e.Graphics.FillRectangle(LineBrush, rect)
                e.Graphics.DrawRectangle(Pens.Black, rect)
            End If
        End If
    End Sub

    Private Sub cmdForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdForeColor.Click
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            colorDlg.Color = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourForeColor
            If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将画笔给当前画笔
                Dim i As Double
                For i = 0 To ListBoxContour.SelectedItems.Count - 1
                    SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.ContourForeColor = colorDlg.Color
                Next
                Me.ReflashAll()
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub cmdForeColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdForeColor.Paint
        If ListBoxContour.SelectedIndex >= 0 Then
            If Not SettingPannel Is Nothing Then
                Dim rect As New Rectangle(5, 5, 30, cmdBackColor.Height - 10)
                Dim LineBrush As New SolidBrush(SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourFill.ContourForeColor)
                e.Graphics.FillRectangle(LineBrush, rect)
                e.Graphics.DrawRectangle(Pens.Black, rect)
            End If
        End If
    End Sub


    '------------------------------------------------------------------------------------


    Private Sub cmbContourFillMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbContourFillMode.SelectedIndexChanged
        If cmbContourFillMode.SelectedIndex = 0 Then
            cmbBrushStyle.Enabled = False
            cmdBackColor.Enabled = False
            BackTransparent.Enabled = False

        Else
            cmbBrushStyle.Enabled = True
            cmdBackColor.Enabled = True
            BackTransparent.Enabled = True

        End If
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.BrushStyle = cmbContourFillMode.SelectedIndex '画刷样式
            Next
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub chkContourFillVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContourFillVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.ContourFillVisible = chkContourFillVisible.Checked
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub ForeTransparent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForeTransparent.ValueChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.ForeTransparent = ForeTransparent.Value
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub BackTransparent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackTransparent.ValueChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourFill.BackTransparent = BackTransparent.Value
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub cmbSymbolShape_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cmbSymbolShape.DrawItem
        DrawSymbolItemBrushStyle(e)
    End Sub


    '标志下拉框填充样式--------------------------------------------------------------------------------
    Private Sub InitialSymbolShapeStyle()
        '初始化绘图画刷等

        cmbSymbolShape.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '设置为可重绘下拉列表框
        cmbSymbolShape.DropDownStyle = ComboBoxStyle.DropDownList '设置为下拉列表框
        ReDim arrSymbolShapeName(0 To 9)
        arrSymbolShapeName(0) = "圆形"
        arrSymbolShapeName(1) = "实心圆形"
        arrSymbolShapeName(2) = "矩形"
        arrSymbolShapeName(3) = "实心矩形"
        arrSymbolShapeName(4) = "菱形"
        arrSymbolShapeName(5) = "实心菱形"
        arrSymbolShapeName(6) = "上三角形"
        arrSymbolShapeName(7) = "实心上三角形"
        arrSymbolShapeName(8) = "下三角形"
        arrSymbolShapeName(9) = "实心下三角形"

        cmbSymbolShape.DataSource = arrSymbolShapeName '这条语句不能放到前面。这条

    End Sub
    '标志下拉框画笔样式
    Public Sub DrawSymbolItemBrushStyle(ByVal e As System.Windows.Forms.DrawItemEventArgs) '绘制填充样式
        Dim mySymbolShape As New SymbolShape
        Dim rect As New Rectangle(3, e.Bounds.Y + 3, e.Bounds.Height - 6, e.Bounds.Height - 6)
        e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds)
        mySymbolShape.SymbolShapeStyle = e.Index
        mySymbolShape.DrawSymbolShape(e.Graphics, rect)
        e.Graphics.DrawString(arrSymbolShapeName(e.Index), e.Font, Brushes.White, 3 + 3 + e.Bounds.Height - 6, e.Bounds.Y + 3)
        'is the mouse hovering over a combobox item??			
        If (e.State = DrawItemState.None) Then
            'this code keeps the last item drawn from having a Bisque background. 
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            mySymbolShape.SymbolShapeStyle = e.Index
            mySymbolShape.DrawSymbolShape(e.Graphics, rect)
            e.Graphics.DrawString(arrSymbolShapeName(e.Index), e.Font, Brushes.Black, 3 + 3 + e.Bounds.Height - 6, e.Bounds.Y + 3)
        End If
    End Sub

    Private Sub chkSymbolVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSymbolVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0 '污染源
                    SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolVisible = chkSymbolVisible.Checked
                Case 1 '关心点
                    SettingPannel.Symbols.CareSymbols.Symbol.SymbolVisible = chkSymbolVisible.Checked
                Case 2 '建筑物
                    SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolVisible = chkSymbolVisible.Checked
            End Select
        End If
        Me.ReflashAll()
    End Sub


    Private Sub listSymbolType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listSymbolType.SelectedIndexChanged
        BoolRefresh = False
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0 '污染源
                    chkSymbolVisible.Checked = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolVisible
                    cmbSymbolShape.SelectedIndex = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle
                    txtSymbolSize.Text = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolSize
                    '绘制标志文本是否可见
                    chkSymbolLabelVisible.Checked = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.Visible
                    '绘制标志文本的位置
                    cmbSymbolLabelPosition.SelectedIndex = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.SymboltextPosition

                Case 1 '关心点
                    chkSymbolVisible.Checked = SettingPannel.Symbols.CareSymbols.Symbol.SymbolVisible
                    cmbSymbolShape.SelectedIndex = SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle
                    txtSymbolSize.Text = SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolSize
                    '绘制标志文本是否可见
                    chkSymbolLabelVisible.Checked = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.Visible
                    '绘制标志文本的位置
                    cmbSymbolLabelPosition.SelectedIndex = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.SymboltextPosition
                Case 2 '建筑物
                    chkSymbolVisible.Checked = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolVisible
                    cmbSymbolShape.SelectedIndex = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle
                    txtSymbolSize.Text = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolSize
                    '绘制标志文本是否可见
                    chkSymbolLabelVisible.Checked = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.Visible
                    '绘制标志文本的位置
                    cmbSymbolLabelPosition.SelectedIndex = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.SymboltextPosition
            End Select
        End If
        Me.Refresh()
        BoolRefresh = True
    End Sub
    Private Sub cmbSymbolShape_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSymbolShape.SelectedIndexChanged
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0 '污染源
                    SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = cmbSymbolShape.SelectedIndex
                Case 1 '关心点
                    SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = cmbSymbolShape.SelectedIndex
                Case 2 '建筑物
                    SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = cmbSymbolShape.SelectedIndex

            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub


    Private Sub txtSymbolSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSymbolSize.TextChanged

    End Sub

    Private Sub txtSymbolSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSymbolSize.Validating
        If Not IsNumeric(txtSymbolSize.Text) Then
            ErrorProvider1.SetError(txtSymbolSize, "您输入的不是数值")
        ElseIf CSng(txtSymbolSize.Text) < 1 Then
            ErrorProvider1.SetError(txtSymbolSize, "数值必须>1")
        Else
            ErrorProvider1.SetError(txtSymbolSize, "")
            If Not SettingPannel Is Nothing Then
                '根据当前选中的边轴确定是否绘该刻度线
                Select Case listSymbolType.SelectedIndex
                    Case 0
                        SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolSize = CSng(txtSymbolSize.Text)
                    Case 1
                        SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolSize = CSng(txtSymbolSize.Text)
                    Case 2 '建筑物
                        SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolSize = CSng(txtSymbolSize.Text)

                End Select
            End If
            Me.ReflashAll()
        End If
    End Sub

    Private Sub cmdSymbolColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSymbolColor.Click
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            '根据当前选中的标志确定是否绘图该座标线
            Select Case listSymbolType.SelectedIndex
                Case 0 '污染源
                    colorDlg.Color = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolColor
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolColor = colorDlg.Color
                    End If
                Case 1 '底轴
                    colorDlg.Color = SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolColor
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolColor = colorDlg.Color
                    End If
                Case 2 '建筑物
                    colorDlg.Color = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolColor
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolColor = colorDlg.Color
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub picSymbol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSymbol.Click

    End Sub

    Private Sub picSymbol_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picSymbol.Paint
        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer '嵌套的 Graphics 容器 
        graphicsContainer = e.Graphics.BeginContainer() '开始嵌套的 Graphics 容器
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim mySymbolShape As New SymbolShape
        If Not SettingPannel Is Nothing Then

            With SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign
                Select Case listSymbolType.SelectedIndex
                    Case 0 '
                        Dim rect As New Rectangle(3, 3, .SymbolSize, .SymbolSize)
                        mySymbolShape.SymbolShapeColor = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolColor
                        mySymbolShape.SymbolShapeStyle = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle
                        mySymbolShape.DrawSymbolShape(e.Graphics, rect)
                    Case 1 '
                        Dim rect As New Rectangle(3, 3, .SymbolSize, .SymbolSize)
                        mySymbolShape.SymbolShapeColor = SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolColor
                        mySymbolShape.SymbolShapeStyle = SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle
                        mySymbolShape.DrawSymbolShape(e.Graphics, rect)
                    Case 2 '
                        Dim rect As New Rectangle(3, 3, .SymbolSize, .SymbolSize)
                        mySymbolShape.SymbolShapeColor = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolColor
                        mySymbolShape.SymbolShapeStyle = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle
                        mySymbolShape.DrawSymbolShape(e.Graphics, rect)
                End Select
            End With
        End If
        e.Graphics.EndContainer(graphicsContainer) '退出绘图容器
    End Sub

    Private Sub cmdSymbolColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdSymbolColor.Paint
        Dim mycolor As Color
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0 '
                    mycolor = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolSign.SymbolColor
                Case 1 '
                    mycolor = SettingPannel.Symbols.CareSymbols.Symbol.SymbolSign.SymbolColor
                Case 2 '
                    mycolor = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolSign.SymbolColor

            End Select
        End If
        Dim rect As New Rectangle(5, 5, 30, cmdSymbolColor.Height - 10)
        Dim LineBrush As New SolidBrush(mycolor)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub


    Private Sub cmbSymbolLabelPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSymbolLabelPosition.SelectedIndexChanged
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            '根据当前选中的标志确定线
            Select Case listSymbolType.SelectedIndex
                Case 0 '污染源
                    SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.SymboltextPosition = cmbSymbolLabelPosition.SelectedIndex
                Case 1 '底轴
                    SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.SymboltextPosition = cmbSymbolLabelPosition.SelectedIndex
                Case 2 '建筑物
                    SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.SymboltextPosition = cmbSymbolLabelPosition.SelectedIndex

            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub chkSymbolLabelVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSymbolLabelVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的标志确定是否可见
            Select Case listSymbolType.SelectedIndex
                Case 0 '污染源
                    SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.Visible = chkSymbolLabelVisible.Checked
                Case 1 '底轴
                    SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.Visible = chkSymbolLabelVisible.Checked
                Case 2 '建筑物
                    SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.Visible = chkSymbolLabelVisible.Checked
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub cmdSymbolLabelFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSymbolLabelFont.Click
        Dim fontDlg As New FontDialog
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0
                    fontDlg.Font = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.mFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.mFont = fontDlg.Font
                    End If
                Case 1
                    fontDlg.Font = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.mFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.mFont = fontDlg.Font
                    End If
                Case 2 '建筑物
                    fontDlg.Font = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.mFont
                    If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.mFont = fontDlg.Font
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub cmdSymbolLabelColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSymbolLabelColor.Click
        Dim colorDlg As New ColorDialog
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0
                    colorDlg.Color = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.Color
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.Color = colorDlg.Color
                    End If
                Case 1
                    colorDlg.Color = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.Color
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.Color = colorDlg.Color
                    End If

                Case 2 '建筑物
                    colorDlg.Color = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.Color
                    If colorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                        SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.Color = colorDlg.Color
                    End If
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub

    Private Sub cmdSymbolLabelColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdSymbolLabelColor.Paint
        Dim mycolor As Color
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0
                    mycolor = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.Color
                Case 1
                    mycolor = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.Color
                Case 0
                    mycolor = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.Color
            End Select
        End If
        Dim rect As New Rectangle(5, 5, 30, cmdSymbolLabelColor.Height - 10)
        Dim LineBrush As New SolidBrush(mycolor)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub


    Private Sub picSymbolLabel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picSymbolLabel.Paint
        Dim mycolor As Color = Color.Black
        Dim myfont As Font = New Font(SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.mFont, FontStyle.Regular)
        If Not SettingPannel Is Nothing Then
            Select Case listSymbolType.SelectedIndex
                Case 0
                    mycolor = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.Color
                    myfont = SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.mFont
                Case 1
                    mycolor = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.Color
                    myfont = SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.mFont
                Case 0
                    mycolor = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.Color
                    myfont = SettingPannel.Symbols.BuildingSymbols.Symbol.SymbolText.mFont
            End Select
        End If
        Dim mybrush As New SolidBrush(mycolor)
        e.Graphics.DrawString("示例", myfont, mybrush, 5, 5)
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub chkHurtRangeVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHurtRangeVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.HurtVisible = chkHurtRangeVisible.Checked
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub chkHurtRangeLabelVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHurtRangeLabelVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Dim i As Double
            For i = 0 To ListBoxContour.SelectedItems.Count - 1
                SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndices(i)).ContourLine.HurtLaberVisible = chkHurtRangeLabelVisible.Checked
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub Gradient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gradient.Click
        Dim dlgGrad As New dlgGradient
        With dlgGrad
            .CBContourStart.GradColor = SettingPannel.Contours.ContourStartColor
            .CBContourEnd.GradColor = SettingPannel.Contours.ContourEndColor
            .CBContourFillStart.GradColor = SettingPannel.Contours.ContourFillStartColor
            .CBContourFillEnd.GradColor = SettingPannel.Contours.ContourFillEndColor
            .CBContourLabelStart.GradColor = SettingPannel.Contours.ContourLabelStartColor
            .CBContourLabelEnd.GradColor = SettingPannel.Contours.ContourLabelEndColor
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                SettingPannel.Contours.ContourStartColor = .CBContourStart.GradColor
                SettingPannel.Contours.ContourEndColor = .CBContourEnd.GradColor
                SettingPannel.Contours.ContourColorGradual()
                SettingPannel.Contours.ContourFillStartColor = .CBContourFillStart.GradColor
                SettingPannel.Contours.ContourFillEndColor = .CBContourFillEnd.GradColor
                SettingPannel.Contours.ContourFillColorGradual()
                SettingPannel.Contours.ContourLabelStartColor = .CBContourLabelStart.GradColor
                SettingPannel.Contours.ContourLabelEndColor = .CBContourLabelEnd.GradColor
                SettingPannel.Contours.ContourLabelColorGradual()
            End If
        End With
        Me.ReflashAll()
        Me.Refresh()
    End Sub

    Private Sub cmdContourLableColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContourLableColor.Click
        If Not SettingPannel Is Nothing Then
            SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelColor = cmdContourLableColor.GradColor
            Me.ReflashAll()
            Me.Refresh()
        End If
    End Sub

    Private Sub chkGriddingVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGriddingVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘该座标线
            Select Case listAxis.SelectedIndex
                Case 0, 2 '左轴
                    SettingPannel.Axes.LeftAxis.AxisGridding.AxisGriddingVisible = chkGriddingVisible.Checked
                    SettingPannel.Axes.RightAxis.AxisGridding.AxisGriddingVisible = chkGriddingVisible.Checked
                Case 1, 3 '底轴
                    SettingPannel.Axes.BottomAxis.AxisGridding.AxisGriddingVisible = chkGriddingVisible.Checked
                    SettingPannel.Axes.TopAxis.AxisGridding.AxisGriddingVisible = chkGriddingVisible.Checked
            End Select
        End If
        Me.ReflashAll()
    End Sub

    Private Sub cmdGriddingStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGriddingStyle.Click
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该座标线
            Select Case listAxis.SelectedIndex
                Case 0, 2 '左轴

                    SettingPannel.Axes.LeftAxis.AxisGridding.PenProperty = OpenAndGetLine(SettingPannel.Axes.LeftAxis.AxisGridding.PenProperty)
                    SettingPannel.Axes.RightAxis.AxisGridding.PenProperty = SettingPannel.Axes.LeftAxis.AxisGridding.PenProperty
                Case 1, 3 '底轴
                    SettingPannel.Axes.BottomAxis.AxisGridding.PenProperty = OpenAndGetLine(SettingPannel.Axes.BottomAxis.AxisGridding.PenProperty)
                    SettingPannel.Axes.TopAxis.AxisGridding.PenProperty = SettingPannel.Axes.BottomAxis.AxisGridding.PenProperty
            End Select
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub
    ''' <summary>
    ''' 这一函数用来打开线型对话框，并返回相应的线形
    ''' </summary>
    ''' <param name="mypen"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenAndGetLine(ByVal mypen As PenProperty) As PenProperty
        Dim frmLineStyle As New LineStyleEditor
        '分别赋给属性值，进行值传递，并调整宽度比例
        frmLineStyle.penCurLineStyle.DashStyle = mypen.DashStyle
        frmLineStyle.penCurLineStyle.Width = mypen.Width / PannelSetting.gScale
        frmLineStyle.penCurLineStyle.Color = Color.FromArgb(mypen.color)
        If frmLineStyle.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
            mypen.DashStyle = frmLineStyle.penCurLineStyle.DashStyle
            mypen.Width = frmLineStyle.penCurLineStyle.Width * PannelSetting.gScale
            mypen.color = frmLineStyle.penCurLineStyle.Color.ToArgb
        End If
        Return mypen
    End Function

    Private Sub picGriddingStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picGriddingStyle.Click

    End Sub

    Private Sub picGriddingStyle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picGriddingStyle.Paint
        '绘制网格线的线型
        If Not SettingPannel Is Nothing Then
            '根据当前选中的边轴确定是否绘图该网格线
            Dim myMatrix As New Matrix()
            myMatrix.Scale(1 / PannelSetting.gScale, 1 / PannelSetting.gScale) '调整比例
            e.Graphics.Transform = myMatrix
            Select Case listAxis.SelectedIndex
                Case 0, 2 '左轴右轴
                    Dim AxisGriddingPen As New Pen(Color.FromArgb(SettingPannel.Axes.LeftAxis.AxisGridding.PenProperty.color))
                    AxisGriddingPen.Width = SettingPannel.Axes.LeftAxis.AxisGridding.PenProperty.Width
                    AxisGriddingPen.DashStyle = SettingPannel.Axes.LeftAxis.AxisGridding.PenProperty.DashStyle

                    e.Graphics.DrawLine(AxisGriddingPen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))

                    AxisGriddingPen.Color = Color.FromArgb(SettingPannel.Axes.RightAxis.AxisGridding.PenProperty.color)
                    AxisGriddingPen.Width = SettingPannel.Axes.RightAxis.AxisGridding.PenProperty.Width
                    AxisGriddingPen.DashStyle = SettingPannel.Axes.RightAxis.AxisGridding.PenProperty.DashStyle
                    e.Graphics.DrawLine(AxisGriddingPen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
                Case 1, 3 '底轴顶轴
                    Dim AxisGriddingPen As New Pen(Color.FromArgb(SettingPannel.Axes.BottomAxis.AxisGridding.PenProperty.color))
                    AxisGriddingPen.Width = SettingPannel.Axes.BottomAxis.AxisGridding.PenProperty.Width
                    AxisGriddingPen.DashStyle = SettingPannel.Axes.BottomAxis.AxisGridding.PenProperty.DashStyle
                    e.Graphics.DrawLine(AxisGriddingPen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))

                    AxisGriddingPen.Color = Color.FromArgb(SettingPannel.Axes.TopAxis.AxisGridding.PenProperty.color)
                    AxisGriddingPen.Width = SettingPannel.Axes.TopAxis.AxisGridding.PenProperty.Width
                    AxisGriddingPen.DashStyle = SettingPannel.Axes.TopAxis.AxisGridding.PenProperty.DashStyle
                    e.Graphics.DrawLine(AxisGriddingPen, 0, CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale), CInt(e.ClipRectangle.Width * PannelSetting.gScale), CInt(e.ClipRectangle.Height / 2 * PannelSetting.gScale))
            End Select
        End If
    End Sub

    Private Sub Legend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabLegend.Click

    End Sub

    Private Sub cmdFillLegend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFillLegend.Click
        If Not SettingPannel Is Nothing Then
            Dim dlgFill As New FillStyleEditor
            dlgFill.BMode = SettingPannel.Legend.BBrushStyle '样式
            dlgFill.HatchStyle = SettingPannel.Legend.HatchStyle
            dlgFill.clrForeColor = SettingPannel.Legend.BForeColor
            dlgFill.clrBackColor = SettingPannel.Legend.BBackColor
            dlgFill.ForeTransparent.Value = SettingPannel.Legend.BForeTransparent
            dlgFill.BackTransparent.Value = SettingPannel.Legend.BBackTransparent
            If dlgFill.ShowDialog() = Windows.Forms.DialogResult.OK Then
                SettingPannel.Legend.BBrushStyle = dlgFill.BMode   '样式
                SettingPannel.Legend.HatchStyle = dlgFill.HatchStyle
                SettingPannel.Legend.BForeColor = dlgFill.clrForeColor
                SettingPannel.Legend.BBackColor = dlgFill.clrBackColor
                SettingPannel.Legend.BForeTransparent = dlgFill.ForeTransparent.Value
                SettingPannel.Legend.BBackTransparent = dlgFill.BackTransparent.Value
                Me.ReflashAll()
            End If
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.ReflashAll()
        Me.Close()
    End Sub

    Private Sub chkLegendContourFillVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLegendContourFillVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            SettingPannel.Legend.LegendContourFillVisible = chkLegendContourFillVisible.Checked
        End If
        Me.ReflashAll()
    End Sub

    Private Sub chkLegendContourLineVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLegendContourLineVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            SettingPannel.Legend.LegendContourLineVisible = chkLegendContourLineVisible.Checked
        End If
        Me.ReflashAll()
    End Sub

    Private Sub chkLegendSymbolVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLegendSymbolVisible.CheckedChanged
        If Not SettingPannel Is Nothing Then
            SettingPannel.Legend.LegendSymbolVisible = chkLegendSymbolVisible.Checked
        End If
        Me.ReflashAll()
    End Sub

    Private Sub cmdLegengFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLegengFont.Click
        Dim fontDlg As New FontDialog
        If Not SettingPannel Is Nothing Then
            fontDlg.Font = SettingPannel.Legend.LegendFont
            If fontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then '如果用户点击确定，则将线形编程器的画笔给当前画笔
                SettingPannel.Legend.LegendFont = fontDlg.Font
            End If
        End If
        Me.Refresh()
        Me.ReflashAll()
    End Sub


    Private Sub cmdLegendColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLegendColor.Click
        If Not SettingPannel Is Nothing Then
            SettingPannel.Legend.LegendColor = cmdLegendColor.GradColor
            Me.ReflashAll()
            Me.Refresh()
        End If
    End Sub

    Private Sub picLegend_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picLegend.Paint
        Dim mycolor As Color = Color.Black
        Dim myfont As Font = New Font(SettingPannel.Legend.LegendFont, FontStyle.Regular)
        If Not SettingPannel Is Nothing Then
            mycolor = SettingPannel.Legend.LegendColor
            myfont = SettingPannel.Legend.LegendFont
        End If
        Dim mybrush As New SolidBrush(mycolor)
        e.Graphics.DrawString("示例", myfont, mybrush, 5, 5)
    End Sub

    Private Sub chkFillLegend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFillLegend.CheckedChanged
        If Not SettingPannel Is Nothing Then
            SettingPannel.Legend.BFillVisible = chkFillLegend.Checked
            Me.ReflashAll()
        End If
    End Sub

    Private Sub ContourLabelProperty_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ContourLabelProperty.Paint
        If ListBoxContour.Items.Count > 0 Then
            cmdContourLableColor.GradColor = SettingPannel.Contours.ArrayContour(ListBoxContour.SelectedIndex).ContourLine.LabelColor
        End If
    End Sub

    Private Sub chkSmooth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSmooth.CheckedChanged
        Dim i As Integer = 0
        If Not SettingPannel Is Nothing Then
            If chkSmooth.Checked = True Then
                SettingPannel.Symbols.PolluteSymbol.Symbol.SmoothingMode = True
                SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.SmoothingMode = True
                SettingPannel.Symbols.CareSymbols.Symbol.SmoothingMode = True
                SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.SmoothingMode = True
                For i = 0 To SettingPannel.Contours.ArrayContour.Length - 1
                    SettingPannel.Contours.ArrayContour(i).ContourLine.SmoothingMode = True
                Next
                SettingPannel.Legend.SmoothingMode = True
            Else
                SettingPannel.Symbols.PolluteSymbol.Symbol.SmoothingMode = False
                SettingPannel.Symbols.PolluteSymbol.Symbol.SymbolText.SmoothingMode = False
                SettingPannel.Symbols.CareSymbols.Symbol.SmoothingMode = False
                SettingPannel.Symbols.CareSymbols.Symbol.SymbolText.SmoothingMode = False
                For i = 0 To SettingPannel.Contours.ArrayContour.Length - 1
                    SettingPannel.Contours.ArrayContour(i).ContourLine.SmoothingMode = False
                Next
                SettingPannel.Legend.SmoothingMode = False
            End If
            Me.ReflashAll()
        End If
    End Sub

    Private Sub picBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdSetContours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetContours.Click
        Dim newdlgInitialContour As New dlgInitialContour
        Dim i As Integer
        newdlgInitialContour.DataGridContour.RowCount = ActivePaintForm.ContourPaintSetting.ContourValue.Length + 1
        For i = 0 To ActivePaintForm.ContourPaintSetting.ContourValue.Length - 1
            newdlgInitialContour.DataGridContour.Item(0, i).Value = ActivePaintForm.ContourPaintSetting.ContourNames(i)
            newdlgInitialContour.DataGridContour.Item(1, i).Value = ActivePaintForm.ContourPaintSetting.ContourValue(i)
        Next
        If newdlgInitialContour.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ReDim ActivePaintForm.ContourPaintSetting.ContourNames(newdlgInitialContour.DataGridContour.RowCount - 2)
            ReDim ActivePaintForm.ContourPaintSetting.ContourValue(newdlgInitialContour.DataGridContour.RowCount - 2)
            For i = 0 To ActivePaintForm.ContourPaintSetting.ContourValue.Length - 1
                ActivePaintForm.ContourPaintSetting.ContourNames(i) = newdlgInitialContour.DataGridContour.Item(0, i).Value
                ActivePaintForm.ContourPaintSetting.ContourValue(i) = newdlgInitialContour.DataGridContour.Item(1, i).Value
            Next
            ListBoxContour.Items.Clear()
            For i = 0 To ActivePaintForm.ContourPaintSetting.ContourValue.Length - 1
                ListBoxContour.Items.Add(CSng(ActivePaintForm.ContourPaintSetting.ContourValue(i))) '加入等值线值
            Next
            ActivePaintForm.ContourPaintSetting.ResetCountData()
            SettingPannel.Contours.ReCalContour = True '重新计算等值线及区域
        End If
        Me.ReflashAll()
    End Sub

    Private Sub chkCurve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCurve.CheckedChanged
        Dim i As Integer = 0
        If Not SettingPannel Is Nothing Then
            If chkCurve.Checked = True Then
                For i = 0 To SettingPannel.Contours.ArrayContour.Length - 1
                    SettingPannel.Contours.ArrayContour(i).ContourLine.Curve = True
                    SettingPannel.Contours.ArrayContour(i).ContourFill.Curve = True
                Next
            Else
                For i = 0 To SettingPannel.Contours.ArrayContour.Length - 1
                    SettingPannel.Contours.ArrayContour(i).ContourLine.Curve = False
                    SettingPannel.Contours.ArrayContour(i).ContourFill.Curve = False
                Next
            End If
            Me.ReflashAll()
        End If
    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged
        If Not SettingPannel Is Nothing Then
            Dim i As Double
            For i = 0 To ListBoxContour.Items.Count - 1
                SettingPannel.Contours.ArrayContour(i).ContourLine.Number = txtNumber.Value
            Next
        End If
        Me.ReflashAll()
    End Sub

    Private Sub txtTitleName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitleName.TextChanged

    End Sub
End Class