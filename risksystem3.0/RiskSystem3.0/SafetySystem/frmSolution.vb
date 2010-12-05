Imports WeifenLuo.WinFormsUI
Imports DisForm
Public Class frmSolution
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

#Region "ContextMenuStrip Window Position"
    Private Sub FloatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DockState = Docking.DockState.Float
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
            Case Docking.DockState.DockBottom
                DockState = Docking.DockState.DockBottomAutoHide
            Case Docking.DockState.DockTop
                DockState = Docking.DockState.DockTopAutoHide
            Case Docking.DockState.DockLeft
                DockState = Docking.DockState.DockLeftAutoHide
            Case Docking.DockState.DockRight
                DockState = Docking.DockState.DockRightAutoHide
        End Select
    End Sub

    Private Sub TabbedDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DockState = Docking.DockState.Document
    End Sub
#End Region

    Private Sub frmSolution_DockStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockStateChanged
        'For Each item As ToolStripMenuItem In ContextMenuDock.Items
        '    item.Checked = False
        'Next
        'Select Case Me.DockState

        '    Case Docking.DockState.Document
        '        TabbedDocumentToolStripMenuItem.Checked = True

        '    Case Docking.DockState.Float
        '        FloatingToolStripMenuItem.Checked = True

        '    Case Docking.DockState.DockBottomAutoHide, _
        '         Docking.DockState.DockLeftAutoHide, _
        '         Docking.DockState.DockRightAutoHide, _
        '         Docking.DockState.DockTopAutoHide

        '        AutoHideToolStripMenuItem.Checked = True

        '    Case Docking.DockState.DockBottom, _
        '         Docking.DockState.DockLeft, _
        '         Docking.DockState.DockRight, _
        '         Docking.DockState.DockTop

        '        DockableToolStripMenuItem.Checked = True

        'End Select
    End Sub

    Private Sub frmSolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ExplorerBar1.Groups(0).Items(0).Checked = True
    End Sub

    Private Sub ExplorerBar1_ItemCheckStateChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemCheckStateChanged
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm

        Select Case Project0.PType
            Case 0 'й©
                Select Case Me.ExplorerBar1.CheckedItem.Index
                    Case 0 '��
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
                        myFrmMain.DrawContourWindow.AddProject = False
                        myFrmMain.DrawContourWindow.leakType = -1
                    Case 1 '����й©
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 0
                    Case 2 'Һ��й©
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 1
                    Case 3 '������й©
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 2
                    Case 4 '������������
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 3
                    Case 5 'Һ����������
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 4

                    Case 6 '�е��ܶ�����ɢ
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 10
                    Case 7 '˲ʱ������ɢģ��
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 11
                    Case 8 '˲ʱ������ɢģ��
                        myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                        myFrmMain.DrawContourWindow.AddProject = True
                        myFrmMain.DrawContourWindow.leakType = 12

                End Select
            Case 1 '���ֱ�ը
                Select Case Me.ExplorerBar1.CheckedItem.Group.Index
                    Case 1 ' ��ը
                        Select Case Me.ExplorerBar1.CheckedItem.Index
                            Case 0 '��
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
                                myFrmMain.DrawContourWindow.AddProject = False
                                myFrmMain.DrawContourWindow.FireBlastType = -1
                            Case 1 '�����Ʊ�ը��TNT������
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 0
                            Case 2 '�����౬ը��TNT������
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 1
                            Case 3 '����վ��ը
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 2
                            Case 4 '����ը
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 3

                        End Select

                    Case 2 '����
                        Select Case Me.ExplorerBar1.CheckedItem.Index
                            Case 0 '��
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
                                myFrmMain.DrawContourWindow.AddProject = False
                                myFrmMain.DrawContourWindow.FireBlastType = -1
                            Case 1 '�����Ʊ�ը��TNT������
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 10
                            Case 2 'Bleve
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 11
                            Case 3 '�������
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
                                myFrmMain.DrawContourWindow.AddProject = True
                                myFrmMain.DrawContourWindow.FireBlastType = 12

                            Case 4 '�����
                                myFrmMain.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
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
        '�ı������ʽΪ�ȴ�
        My.Application.ApplicationContext.MainForm.Cursor = Cursors.WaitCursor

        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        Dim myTreeNode As TreeNode
        '������û�д������½������򼤻�
        If Me.TreeView.SelectedNode IsNot Nothing Then
            myTreeNode = Me.TreeView.SelectedNode
            If myTreeNode.Text.Contains("���ʵ�����ѧ���ʼ�����") Then
                Chemical()
            ElseIf myTreeNode.Text.Contains("�¹�Դ��") Then
                SourceOption()
            ElseIf myTreeNode.Text.Contains("�·���") Then
                VaneOption()
            ElseIf myTreeNode.Text.Contains("����") Then
                GridOption()
            ElseIf myTreeNode.Text.Contains("�˿ڷֲ�") Then
                GridPopulation()

            ElseIf myTreeNode.Text.Contains("���ĵ�") Then
                CareOption()
            ElseIf myTreeNode.Text.Contains("��������ѡ��") Then
                metOption()
            ElseIf myTreeNode.Text.Contains("��ʱ������������") Then
                SurfMetOption()
            ElseIf myTreeNode.Text.Contains("��������ѡ��") Then
                'Aermap()
            ElseIf myTreeNode.Text.Contains("���ѡ��") Then
                OutOption()
            ElseIf myTreeNode.Text.Contains("����λ��ͼ") Then
                ImportBackImage1()
            ElseIf myTreeNode.Text.Contains("����ƽ��ͼ") Then
                ImportBackImage2()
            End If
        End If
        '�����û����õ���ȾԴ����޸Ľ���������е���ȾԴ
        'RefreshSolutionTree()
        '�ı������ʽΪĬ��
        My.Application.ApplicationContext.MainForm.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    '''���ÿ���ѡ��
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImportBackImage1()
        Dim frmImage As New CImPortImage.frmImportBackImage1
        frmImage.Text = "�������λ��ͼ"
        frmImage.ImportImageControl1.InsertImage = Project0.ImportImage0.ImportBack1.Clone
        If frmImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.LoadBitmap(frmImage.ImportImageControl1.InsertImage.FileName)
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.X = frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.X
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Y = frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.Y
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Width = frmImage.ImportImageControl1.InsertImage.RightTopPoint.X - frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.X
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Height = frmImage.ImportImageControl1.InsertImage.RightTopPoint.Y - frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.Y
            myFrmMain.DrawContourWindow.Refresh()
            Project0.ImportImage0.ImportBack1 = frmImage.ImportImageControl1.InsertImage.Clone
        End If
    End Sub
    ''' <summary>
    '''���ÿ���ѡ��
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImportBackImage2()
        Dim frmImage As New CImPortImage.frmImportBackImage1
        frmImage.Text = "���볡��ƽ��ͼ"
        frmImage.ImportImageControl1.InsertImage = Project0.ImportImage0.ImportBack2.Clone
        If frmImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.LoadBitmap(frmImage.ImportImageControl1.InsertImage.FileName)
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.X = frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.X
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Y = frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.Y
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Width = frmImage.ImportImageControl1.InsertImage.RightTopPoint.X - frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.X
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Height = frmImage.ImportImageControl1.InsertImage.RightTopPoint.Y - frmImage.ImportImageControl1.InsertImage.LeftBottomPoint.Y
            myFrmMain.DrawContourWindow.Refresh()
            Project0.ImportImage0.ImportBack2 = frmImage.ImportImageControl1.InsertImage.Clone
        End If
    End Sub
    ''' <summary>
    ''' ���õ�Դ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SourceOption()
        Dim frmLeakSource As frmLeakSource = New frmLeakSource()
        frmLeakSource.Dis = Project0.Dis0.Clone
        If frmLeakSource.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmLeakSource.Dis.Clone
            Dim frmMain As frmMain = My.Application.ApplicationContext.MainForm
            frmMain.DrawContourWindow.SetPolluteDraw()
        End If
    End Sub
    ''' <summary>
    '''���ÿ���ѡ��
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
            Dim frmMain As frmMain = My.Application.ApplicationContext.MainForm
            frmMain.DrawContourWindow.SetPolluteDraw()
        End If
    End Sub
    Private Sub GridPopulation()
        Dim frmP As frmPopulation = New frmPopulation
        frmP.PopulationRegions = Project0.Dis0.Forecast.PopulationRegions.Clone
        If frmP.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0.Forecast.PopulationRegions = frmP.PopulationRegions.Clone
            Dim frmMain As frmMain = My.Application.ApplicationContext.MainForm
            frmMain.DrawContourWindow.SetPolluteDraw()
            Project0.Dis0.Forecast.SetPopulation()
        End If
    End Sub

    Private Sub CareOption()
        Dim frmCare As frmCare = New frmCare()
        frmCare.Dis = Project0.Dis0.Clone
        If frmCare.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project0.Dis0 = frmCare.Dis.Clone
            Dim frmMain As frmMain = My.Application.ApplicationContext.MainForm
            frmMain.DrawContourWindow.SetPolluteDraw()
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
    ''' ��ʱ������������
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