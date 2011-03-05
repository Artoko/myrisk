Public Class frmResultSolution

    Private Sub frmResultSolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To Project_Calculated.Dis0.ListLeakSource.IntialSource.Count - 1
            TreeView1.Nodes.Add(Project_Calculated.Dis0.ListLeakSource.IntialSource(i).LeakSourceName)
            TreeView1.Nodes.Item(i).Nodes.Add("社会平均风险值")
            TreeView1.Nodes.Item(i).Nodes.Add("个人风险值")
            TreeView1.Nodes.Item(i).Nodes.Add("各点风险最大值")
            TreeView1.Nodes.Item(i).Nodes.Add("各点浓度最大值")
            TreeView1.Nodes.Item(i).Nodes.Add("所有网格点最大值")
            TreeView1.Nodes.Item(i).Nodes.Add("特定值")
            TreeView1.Nodes.Item(i).Nodes.Add("逐步值")
        Next

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Me.TreeView1.SelectedNode.Text = "逐步值" Then
            '根据用户的选择，先找出对应的污染源的ID
            Dim Index As Integer = Me.TreeView1.SelectedNode.Parent.Index
            Dim ID As String = Project_Calculated.Dis0.ListLeakSource.IntialSource(Index).ID
            Dim frmMain As frmMain
            frmMain = My.Application.ApplicationContext.MainForm
            frmMain.frmResultMain.frmResultSet.ListBox1.Items.Clear()
            For i As Integer = 0 To Project_Calculated.Dis0.Forecast.Met.Length - 1
                frmMain.frmResultMain.frmResultSet.ListBox1.Items.Add(Project_Calculated.Dis0.Forecast.Met(i).m_DateTime.ToString)
            Next
        End If
    End Sub
End Class