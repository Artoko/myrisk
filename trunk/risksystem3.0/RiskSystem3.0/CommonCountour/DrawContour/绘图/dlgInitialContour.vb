Imports System.Windows.Forms

Public Class dlgInitialContour

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DataGridContour_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridContour_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim i, j As Short
        For i = 0 To DataGridContour.RowCount - 2
            If (Not IsNumeric(DataGridContour(1, i).Value)) Then
                MsgBox("等值线值必须为数值，请检查您的数据，若不需要该行数据必须删除整行！")
                Exit Sub
            ElseIf DataGridContour(1, i).Value <= 0 Then
                MsgBox("等值线值必须为＞0数值，请检查您的数据，若不需要该行数据必须删除整行！")
                Exit Sub
            End If
        Next
        For i = 0 To DataGridContour.RowCount - 2
            For j = i + 1 To DataGridContour.RowCount - 2
                If DataGridContour(1, i).Value = DataGridContour(1, j).Value Then
                    MsgBox("等值线值不能有相同的数值，请检查您的数据，若不需要该行数据必须删除整行！")
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub DataGridCare_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

   
End Class
