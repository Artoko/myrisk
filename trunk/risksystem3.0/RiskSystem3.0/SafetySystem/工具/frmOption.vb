Imports System.Windows.Forms

Public Class frmOptionGG

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Project0.Dis0.Forecast.IsCalGrid = CheckCalGrid.Checked
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckCalGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCalGrid.CheckedChanged

    End Sub

    Private Sub frmOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckCalGrid.Checked = Project0.Dis0.Forecast.IsCalGrid
    End Sub
End Class
