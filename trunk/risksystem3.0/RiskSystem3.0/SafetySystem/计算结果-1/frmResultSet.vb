Public Class frmResultSet
    Private m_post As DisPuff.PostCon
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If Me.ListBox1.SelectedIndex >= 0 Then
            Dim path As String = Project_Calculated.GetProjWorkPath & "post\"
            Dim fileTime As Date = Project_Calculated.Dis0.Forecast.Met(Me.ListBox1.SelectedIndex).m_DateTime
            Dim FileName As String = path & fileTime.Year.ToString & "-" & fileTime.Month.ToString & "-" & fileTime.Day.ToString & "-" & fileTime.Hour.ToString & ".pst"
            m_post = DisPuff.PostCon.Open(FileName)

            Me.TrackBar1.Minimum = 0
            Me.TrackBar1.Maximum = m_post.m_TimeCount - 1
            Me.TrackBar1.Value = 0
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim Grid(Project_Calculated.Dis0.Forecast.Grid.CountY - 1, Project_Calculated.Dis0.Forecast.Grid.CountX - 1) As Double
        For j As Integer = 0 To Project_Calculated.Dis0.Forecast.Grid.CountY - 1
            For i As Integer = 0 To Project_Calculated.Dis0.Forecast.Grid.CountX - 1
                Grid(j, i) = Me.m_post.GridCon(Me.TrackBar1.Value, j, i)
            Next
        Next
        Dim frmMain As frmMain
        frmMain = My.Application.ApplicationContext.MainForm
        frmMain.frmResultMain.frmResultMapGis.ChangeContours(Grid, Project_Calculated.Dis0.Forecast.Grid.MinX _
                                                             , Project_Calculated.Dis0.Forecast.Grid.StepX _
                                                             , Project_Calculated.Dis0.Forecast.Grid.CountX _
                                                             , Project_Calculated.Dis0.Forecast.Grid.MinY _
                                                             , Project_Calculated.Dis0.Forecast.Grid.StepY _
                                                             , Project_Calculated.Dis0.Forecast.Grid.CountY _
                                                             , 0, 0, "Contour", False)

    End Sub

    Private Sub frmResultSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class