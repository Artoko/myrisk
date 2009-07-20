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
        If ActivePaintForm.ContourPaintSetting.ChartType = 1 Then 'ª‘÷±¨’®–Õ
            Me.GroupBoxLine.Text = "…À∫¶œﬂ"
            Me.GroupBoxFill.Text = "…À∫¶œﬂÃÓ≥‰"
            Me.GroupBoxLabel.Text = "…À∫¶œﬂ±Í◊¢"
        End If
    End Sub
End Class
