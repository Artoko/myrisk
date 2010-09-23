Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class LineStyleEditor
    Private arrLineStyle() As String '线的样式的名称数组，0-4
    Private arrLineWidth() As String '线的宽度的名称数组，最多取0-9
    Private penArrStyle() As Pen
    Private penArrWidth() As Pen
    Public penCurLineStyle As New Pen(Color.Black) '当前画笔
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Public Sub InitialLineStyle()
        '初始化
        ComboBoxLineStyle.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '设置为可重绘下拉列表框
        ComboBoxLineStyle.DropDownStyle = ComboBoxStyle.DropDownList '设置为下拉列表框

        Dim i As Integer
        ReDim arrLineStyle(0 To 4)
        For i = 0 To 4
            arrLineStyle(i) = "样式"
        Next
        ReDim penArrStyle(0 To 4)
        For i = 0 To 4
            penArrStyle(i) = New Pen(Color.Black)
            penArrStyle(i).DashStyle = i
            penArrStyle(i).Width = penCurLineStyle.Width
        Next
        ComboBoxLineStyle.DataSource = arrLineStyle '这条语句不能放到前面
    End Sub
    Public Sub InitialLineWidth()
        '初始化
        ComboBoxLineWidth.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '设置为可重绘下拉列表框
        ComboBoxLineWidth.DropDownStyle = ComboBoxStyle.DropDownList '设置为下拉列表框

        Dim i As Integer
        ReDim arrLineWidth(0 To 9)
        For i = 0 To 9
            arrLineWidth(i) = "宽度"
        Next
        ReDim penArrWidth(0 To 9)
        For i = 0 To 9
            penArrWidth(i) = New Pen(Color.Black)
            penArrWidth(i).DashStyle = penCurLineStyle.DashStyle
            penArrWidth(i).Width = i + 1
        Next
        ComboBoxLineWidth.DataSource = arrLineWidth '这条语句不能放到前面
    End Sub
    Public Sub DrawItemLineStyle(ByVal e As System.Windows.Forms.DrawItemEventArgs) '绘制样式
        Dim i As Integer
        For i = 0 To 4
            penArrStyle(i).Width = penCurLineStyle.Width
            penArrStyle(i).Color = penCurLineStyle.Color
        Next
        'Lets highlight the currently selected item like any well behaved combo box should
        e.Graphics.FillRectangle(Brushes.Bisque, e.Bounds)
        e.Graphics.DrawLine(penArrStyle(e.Index), 0, e.Bounds.Y + 8, e.Bounds.Width, e.Bounds.Y + 8)
        'is the mouse hovering over a combobox item??			
        If (e.State = DrawItemState.None) Then
            'this code keeps the last item drawn from having a Bisque background. 
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            e.Graphics.DrawLine(penArrStyle(e.Index), 0, e.Bounds.Y + 8, e.Bounds.Width, e.Bounds.Y + 8)
        End If
    End Sub
    Public Sub DrawItemLineWidht(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Try
            Dim i As Integer
            For i = 0 To 9
                penArrWidth(i).DashStyle = penCurLineStyle.DashStyle
                penArrWidth(i).Color = penCurLineStyle.Color
            Next
            e.Graphics.FillRectangle(Brushes.Bisque, e.Bounds)
            e.Graphics.DrawLine(penArrWidth(e.Index), 0, e.Bounds.Y + 8, e.Bounds.Width, e.Bounds.Y + 8)

            If (e.State = DrawItemState.None) Then
                'this code keeps the last item drawn from having a Bisque background. 
                e.Graphics.FillRectangle(Brushes.White, e.Bounds)
                e.Graphics.DrawLine(penArrWidth(e.Index), 0, e.Bounds.Y + 8, e.Bounds.Width, e.Bounds.Y + 8)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LineComboBoxContourStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refresh()
    End Sub

    Private Sub LineComboBoxContourWidth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Refresh()
    End Sub

    Private Sub LineColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLineColor.Click
        Dim colorDlg As New ColorDialog
        colorDlg.Color = penCurLineStyle.Color
        colorDlg.ShowDialog()
        penCurLineStyle.Color = colorDlg.Color
        Me.Refresh()
    End Sub

    Private Sub LineColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ButtonLineColor.Paint
        Dim rect As New Rectangle(5, 5, 30, ButtonLineColor.Height - 10)
        Dim LineBrush As New SolidBrush(penCurLineStyle.Color)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub PicModel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicModel.Paint
        
        e.Graphics.DrawLine(penCurLineStyle, 0, CInt(PicModel.Height / 2), CInt(PicModel.Width), CInt(PicModel.Height / 2))
    End Sub

    Private Sub ComboBoxLineWidth_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBoxLineWidth.DrawItem

        penCurLineStyle.DashStyle = ComboBoxLineStyle.SelectedIndex

        DrawItemLineWidht(e) '重绘下拉列线的宽度
    End Sub

    Private Sub ComboBoxLineWidth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxLineWidth.SelectedIndexChanged
        Me.Refresh()
    End Sub

    Private Sub ComboBoxLineStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBoxLineStyle.DrawItem

        penCurLineStyle.Width = ComboBoxLineWidth.SelectedIndex + 1 '改变线条的宽度

        DrawItemLineStyle(e) '重绘下拉列线的样式
    End Sub

    Private Sub ComboBoxLineStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxLineStyle.SelectedIndexChanged
        Me.Refresh()
    End Sub

    Private Sub LineStyleEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化等值线
        InitialLineStyle() '初始化等值线样式下拉列表框
        InitialLineWidth() '初始化等值线宽度下拉列表框
        '初始化线的样式、宽度和颜色
        ComboBoxLineStyle.SelectedIndex = CInt(penCurLineStyle.DashStyle)
        ComboBoxLineWidth.SelectedIndex = CInt(penCurLineStyle.Width - 1)
    End Sub

    Private Sub PicModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicModel.Click

    End Sub
End Class
