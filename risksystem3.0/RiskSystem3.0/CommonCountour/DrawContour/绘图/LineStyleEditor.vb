Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class LineStyleEditor
    Private arrLineStyle() As String '�ߵ���ʽ���������飬0-4
    Private arrLineWidth() As String '�ߵĿ�ȵ��������飬���ȡ0-9
    Private penArrStyle() As Pen
    Private penArrWidth() As Pen
    Public penCurLineStyle As New Pen(Color.Black) '��ǰ����
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Public Sub InitialLineStyle()
        '��ʼ��
        ComboBoxLineStyle.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '����Ϊ���ػ������б��
        ComboBoxLineStyle.DropDownStyle = ComboBoxStyle.DropDownList '����Ϊ�����б��

        Dim i As Integer
        ReDim arrLineStyle(0 To 4)
        For i = 0 To 4
            arrLineStyle(i) = "��ʽ"
        Next
        ReDim penArrStyle(0 To 4)
        For i = 0 To 4
            penArrStyle(i) = New Pen(Color.Black)
            penArrStyle(i).DashStyle = i
            penArrStyle(i).Width = penCurLineStyle.Width
        Next
        ComboBoxLineStyle.DataSource = arrLineStyle '������䲻�ܷŵ�ǰ��
    End Sub
    Public Sub InitialLineWidth()
        '��ʼ��
        ComboBoxLineWidth.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '����Ϊ���ػ������б��
        ComboBoxLineWidth.DropDownStyle = ComboBoxStyle.DropDownList '����Ϊ�����б��

        Dim i As Integer
        ReDim arrLineWidth(0 To 9)
        For i = 0 To 9
            arrLineWidth(i) = "���"
        Next
        ReDim penArrWidth(0 To 9)
        For i = 0 To 9
            penArrWidth(i) = New Pen(Color.Black)
            penArrWidth(i).DashStyle = penCurLineStyle.DashStyle
            penArrWidth(i).Width = i + 1
        Next
        ComboBoxLineWidth.DataSource = arrLineWidth '������䲻�ܷŵ�ǰ��
    End Sub
    Public Sub DrawItemLineStyle(ByVal e As System.Windows.Forms.DrawItemEventArgs) '������ʽ
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

        DrawItemLineWidht(e) '�ػ��������ߵĿ��
    End Sub

    Private Sub ComboBoxLineWidth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxLineWidth.SelectedIndexChanged
        Me.Refresh()
    End Sub

    Private Sub ComboBoxLineStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBoxLineStyle.DrawItem

        penCurLineStyle.Width = ComboBoxLineWidth.SelectedIndex + 1 '�ı������Ŀ��

        DrawItemLineStyle(e) '�ػ��������ߵ���ʽ
    End Sub

    Private Sub ComboBoxLineStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxLineStyle.SelectedIndexChanged
        Me.Refresh()
    End Sub

    Private Sub LineStyleEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '��ʼ����ֵ��
        InitialLineStyle() '��ʼ����ֵ����ʽ�����б��
        InitialLineWidth() '��ʼ����ֵ�߿�������б��
        '��ʼ���ߵ���ʽ����Ⱥ���ɫ
        ComboBoxLineStyle.SelectedIndex = CInt(penCurLineStyle.DashStyle)
        ComboBoxLineWidth.SelectedIndex = CInt(penCurLineStyle.Width - 1)
    End Sub

    Private Sub PicModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicModel.Click

    End Sub
End Class
