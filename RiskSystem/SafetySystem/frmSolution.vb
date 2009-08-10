Imports WeifenLuo.WinFormsUI

Public Class frmSolution
    Inherits DockContent

#Region "ContextMenuStrip Window Position"
    Private Sub FloatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DockState = WeifenLuo.WinFormsUI.DockState.Float
    End Sub

    Private Sub DockableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DockState = Me.ShowHint
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Dim MainForm As frmMain
        MainForm = My.Application.ApplicationContext.MainForm
        MainForm.PorjectToolStripMenuItem.Checked = False
    End Sub

    Private Sub AutoHideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case Me.DockState
            Case WeifenLuo.WinFormsUI.DockState.DockBottom
                DockState = WeifenLuo.WinFormsUI.DockState.DockBottomAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockTop
                DockState = WeifenLuo.WinFormsUI.DockState.DockTopAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockLeft
                DockState = WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockRight
                DockState = WeifenLuo.WinFormsUI.DockState.DockRightAutoHide
        End Select
    End Sub

    Private Sub TabbedDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DockState = WeifenLuo.WinFormsUI.DockState.Document
    End Sub
#End Region

    Private Sub frmSolution_DockStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockStateChanged
        'For Each item As ToolStripMenuItem In ContextMenuDock.Items
        '    item.Checked = False
        'Next
        'Select Case Me.DockState

        '    Case WeifenLuo.WinFormsUI.DockState.Document
        '        TabbedDocumentToolStripMenuItem.Checked = True

        '    Case WeifenLuo.WinFormsUI.DockState.Float
        '        FloatingToolStripMenuItem.Checked = True

        '    Case WeifenLuo.WinFormsUI.DockState.DockBottomAutoHide, _
        '         WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide, _
        '         WeifenLuo.WinFormsUI.DockState.DockRightAutoHide, _
        '         WeifenLuo.WinFormsUI.DockState.DockTopAutoHide

        '        AutoHideToolStripMenuItem.Checked = True

        '    Case WeifenLuo.WinFormsUI.DockState.DockBottom, _
        '         WeifenLuo.WinFormsUI.DockState.DockLeft, _
        '         WeifenLuo.WinFormsUI.DockState.DockRight, _
        '         WeifenLuo.WinFormsUI.DockState.DockTop

        '        DockableToolStripMenuItem.Checked = True

        'End Select
    End Sub

    Private Sub frmSolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ExplorerBar1.Groups(0).Items(0).Checked = True
    End Sub

    Private Sub ExplorerBar1_ItemCheckStateChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemCheckStateChanged
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm

        Select Case Project0.PType
            Case 0 '泄漏
                Select Case Me.ExplorerBar1.CheckedItem.Index
                    Case 0 '空
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
                        myFrmMain.DrawContourWindow.AddProject = False
                        myFrmMain.DrawContourWindow.leakType = -1
                    Case 1 '气体泄漏
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 0
                    Case 2 '液体泄漏
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 1
                    Case 3 '两相流泄漏
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 2
                    Case 4 '气体容器破裂
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 3
                    Case 5 '液体容器破裂
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 4

                    Case 6 '中等密度云扩散
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 10
                    Case 7 '瞬时重气扩散模型
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 11
                    Case 8 '瞬时重气扩散模型
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 12

                End Select
            Case 1 '火灾爆炸
                Select Case Me.ExplorerBar1.CheckedItem.Group.Index
                    Case 1 ' 爆炸
                        Select Case Me.ExplorerBar1.CheckedItem.Index
                            Case 0 '空
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
                                myFrmMain.DrawContourWindow.AddProject = False
                                myFrmMain.DrawContourWindow.FireBlastType = -1
                            Case 1 '蒸汽云爆炸，TNT当量法
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 0
                            Case 2 '凝聚相爆炸，TNT当量法
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 1
                            Case 3 '加油站爆炸
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 2
                            Case 4 '物理爆炸
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 3

                        End Select

                    Case 2 '火灾
                        Select Case Me.ExplorerBar1.CheckedItem.Index
                            Case 0 '空
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
                                myFrmMain.DrawContourWindow.AddProject = False
                                myFrmMain.DrawContourWindow.FireBlastType = -1
                            Case 1 '蒸汽云爆炸，TNT当量法
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 10
                            Case 2 'Bleve
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 11
                            Case 3 '固体火灾
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 12

                            Case 4 '喷射火
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 13

                        End Select
                End Select

        End Select
    End Sub

   
  
    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub TreeView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub TreeView_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView.NodeMouseDoubleClick
        'Me.TreeView.SelectedNode = Nothing
        '改变鼠标样式为等待
        My.Application.ApplicationContext.MainForm.Cursor = Cursors.WaitCursor

        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        Dim myTreeNode As TreeNode
        '如果结点没有窗口则新建，否则激活
        If Me.TreeView.SelectedNode IsNot Nothing Then
            myTreeNode = Me.TreeView.SelectedNode
            If myTreeNode.Text.Contains("物质的物理化学性质及毒性") Then
                Chemical()
            ElseIf myTreeNode.Text.Contains("事故源项") Then
                SourceOption()
            ElseIf myTreeNode.Text.Contains("下风向") Then
                VaneOption()
            ElseIf myTreeNode.Text.Contains("网格") Then
                GridOption()
            ElseIf myTreeNode.Text.Contains("关心点") Then
                CareOption()
            ElseIf myTreeNode.Text.Contains("气象数据选项") Then
                metOption()
            ElseIf myTreeNode.Text.Contains("逐时地面气象数据") Then
                SurfMetOption()
            ElseIf myTreeNode.Text.Contains("地形数据选项") Then
                'Aermap()
            ElseIf myTreeNode.Text.Contains("输出选项") Then
                OutOption()
            End If
        End If
        '根据用户设置的污染源情况修改解决方案的中的污染源
        'RefreshSolutionTree()
        '改变鼠标样式为默认
        My.Application.ApplicationContext.MainForm.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' 设置点源
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SourceOption()
        Dim frmLeakSource As frmLeakSource = New frmLeakSource()
        frmLeakSource.Dis = Project0.Dis0.Clone
        If frmLeakSource.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmLeakSource.Dis.Clone
        End If
    End Sub
    ''' <summary>
    '''设置控制选项
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Chemical()
        Dim frmChem As frmChemistry = New frmChemistry()
        frmChem.Dis = Project0.Dis0.Clone
        If frmChem.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmChem.Dis.Clone
        End If
    End Sub

    Private Sub GridOption()
        Dim frmGrid As frmGrid = New frmGrid()
        frmGrid.Dis = Project0.Dis0.Clone
        If frmGrid.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmGrid.Dis.Clone
        End If
    End Sub

    Private Sub CareOption()
        Dim frmCare As frmCare = New frmCare()
        frmCare.Dis = Project0.Dis0.Clone
        If frmCare.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmCare.Dis.Clone
        End If
    End Sub

    Private Sub MetOption()
        Dim frmMet As frmMet = New frmMet()
        frmMet.Dis = Project0.Dis0.Clone
        If frmMet.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmMet.Dis.Clone
        End If
    End Sub
    ''' <summary>
    ''' 逐时地面气象数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SurfMetOption()
        Dim frmGeneralMet As New Met.frmGeneralMetData
        frmGeneralMet.Aermet.Stage2.MetGeneral = Project0.SurfMet.Clone
        If frmGeneralMet.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.SurfMet = frmGeneralMet.Aermet.Stage2.MetGeneral.Clone
        End If
    End Sub

    Private Sub OutOption()
        Dim frmOut As frmOutOption = New frmOutOption()
        frmOut.Dis = Project0.Dis0.Clone
        If frmOut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmOut.Dis.Clone
        End If
    End Sub
    Private Sub VaneOption()
        Dim frmVane As frmVaneDrown = New frmVaneDrown
        frmVane.Dis = Project0.Dis0.Clone
        If frmVane.ShowDialog = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmVane.Dis
        End If
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect

    End Sub
End Class