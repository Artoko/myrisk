Public Class frmResultSet

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If Me.ListBox1.SelectedIndex >= 0 Then
            Dim A(,) As Double = Project0.Dis0.Cal(Me.ListBox1.SelectedIndex)
        End If
    End Sub
End Class