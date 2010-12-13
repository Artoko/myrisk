Public Class frmResultSet
    Private post As DisPuff.PostCon
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If Me.ListBox1.SelectedIndex >= 0 Then
            Dim path As String = Project_Calculated.GetProjWorkPath & "post\"
            Dim fileTime As Date = Project_Calculated.Dis0.Forecast.Met(Me.ListBox1.SelectedIndex).m_DateTime
            Dim FileName As String = path & fileTime.Year.ToString & "-" & fileTime.Month.ToString & "-" & fileTime.Day.ToString & "-" & fileTime.Hour.ToString & ".pst"
            post = DisPuff.PostCon.Open(FileName)

            Me.TrackBar1.Minimum = 0
            Me.TrackBar1.Maximum = post.m_TimeStep * post.m_TimeCount - 1
            Me.TrackBar1.Value = 0
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll

    End Sub
End Class