Imports System.Windows.Forms

Public Class dlgGradient

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgGradient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ActivePaintForm.ContourPaintSetting.ChartType = 1 Then '���ֱ�ը��
            Me.GroupBoxLine.Text = "�˺���"
            Me.GroupBoxFill.Text = "�˺������"
            Me.GroupBoxLabel.Text = "�˺��߱�ע"
        End If
    End Sub
End Class
