Public Class frmResultSolution

    Private Sub frmResultSolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TreeView1.Nodes.Add("计算结果")
        TreeView1.Nodes.Item(0).Nodes.Add("POST", "逐步值")

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Me.TreeView1.SelectedNode.Text = "逐步值" Then
            Dim frmMain As frmMain
            frmMain = My.Application.ApplicationContext.MainForm
            frmMain.frmResultMain.frmResultSet.ListBox1.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                frmMain.frmResultMain.frmResultSet.ListBox1.Items.Add(Project0.Dis0.Forecast.Met(i).m_DateTime.ToString)
            Next
        End If
    End Sub
End Class