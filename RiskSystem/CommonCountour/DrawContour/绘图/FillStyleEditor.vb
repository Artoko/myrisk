Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class FillStyleEditor
    Private arrBrushStyleName() As String '��ˢ��ʽ���������飬0-4
    Private brhStyle() As HatchBrush  '��ˢ����
    Public clrBackColor As Color = Color.White   '��������ɫ
    Public clrForeColor As Color = Color.Black  'ǰ������ɫ
    Public BMode As Integer = 0
    Public HatchStyle As Integer = 0 '��ˢ����ʽ��0Ϊʵ�Ļ�ˢ��0Ϊͼ����ˢ
   
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Public Sub InitialBrushStyle()
        '��ʼ��
        cmbBrushStyle.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed '����Ϊ���ػ������б��
        cmbBrushStyle.DropDownStyle = ComboBoxStyle.DropDownList '����Ϊ�����б��
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
        cmbBrushStyle.DataSource = arrBrushStyleName '������䲻�ܷŵ�ǰ��
    End Sub
    Public Sub DrawItemBrushStyle(ByVal e As System.Windows.Forms.DrawItemEventArgs) '���ƻ�����ʽ
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
        HatchStyle = cmbBrushStyle.SelectedIndex
        Me.Refresh()
    End Sub

    Private Sub PicModel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicModel.Paint
        If cmbMode.SelectedIndex = 0 Then
            Dim myBrush As New SolidBrush(clrForeColor)
            e.Graphics.FillRectangle(myBrush, 0, 0, PicModel.Width, PicModel.Height)
        Else
            Dim myhatchstyle As HatchStyle
            myhatchstyle = cmbBrushStyle.SelectedIndex '��ˢ����ʽ
            Dim myBrush As New HatchBrush(myhatchstyle, clrForeColor, clrBackColor)
            e.Graphics.FillRectangle(myBrush, 0, 0, PicModel.Width, PicModel.Height)
        End If

    End Sub

    Private Sub cmdBackColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBackColor.Click
        Dim colorDlg As New ColorDialog
        colorDlg.Color = clrBackColor
        colorDlg.ShowDialog()
        clrBackColor = colorDlg.Color
        Me.Refresh()
    End Sub

    Private Sub cmdBackColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdBackColor.Paint
        Dim rect As New Rectangle(5, 5, 30, cmdBackColor.Height - 10)
        Dim LineBrush As New SolidBrush(clrBackColor)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub cmdForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdForeColor.Click
        Dim colorDlg As New ColorDialog
        colorDlg.Color = clrForeColor
        colorDlg.ShowDialog()
        clrForeColor = colorDlg.Color
        Me.Refresh()
    End Sub

    Private Sub cmdForeColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdForeColor.Paint
        Dim rect As New Rectangle(5, 5, 30, cmdForeColor.Height - 10)
        Dim LineBrush As New SolidBrush(clrForeColor)
        e.Graphics.FillRectangle(LineBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub FillStyleEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitialBrushStyle()
        cmbMode.SelectedIndex = BMode
        cmbBrushStyle.SelectedIndex = HatchStyle
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMode.SelectedIndexChanged
        If cmbMode.SelectedIndex = 0 Then
            cmbBrushStyle.Enabled = False
            cmdBackColor.Enabled = False
            BackTransparent.Enabled = False
        Else
            cmbBrushStyle.Enabled = True
            cmdBackColor.Enabled = True
            BackTransparent.Enabled = True
        End If
        BMode = cmbMode.SelectedIndex
        Me.Refresh()
    End Sub

    Private Sub PicModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicModel.Click

    End Sub
End Class
