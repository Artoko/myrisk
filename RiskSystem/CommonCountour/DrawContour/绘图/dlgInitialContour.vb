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
                MsgBox("��ֵ��ֵ����Ϊ��ֵ�������������ݣ�������Ҫ�������ݱ���ɾ�����У�")
                Exit Sub
            ElseIf DataGridContour(1, i).Value <= 0 Then
                MsgBox("��ֵ��ֵ����Ϊ��0��ֵ�������������ݣ�������Ҫ�������ݱ���ɾ�����У�")
                Exit Sub
            End If
        Next
        For i = 0 To DataGridContour.RowCount - 2
            For j = i + 1 To DataGridContour.RowCount - 2
                If DataGridContour(1, i).Value = DataGridContour(1, j).Value Then
                    MsgBox("��ֵ��ֵ��������ͬ����ֵ�������������ݣ�������Ҫ�������ݱ���ɾ�����У�")
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub DataGridCare_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

   
End Class
