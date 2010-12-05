Imports System.IO
Public Class frmOut

    Private Sub frmOut_DockStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockStateChanged
        For Each item As ToolStripMenuItem In ContextMenuDock.Items
            item.Checked = False
        Next
        Select Case Me.DockState

            Case WeifenLuo.WinFormsUI.Docking.DockState.Document
                TabbedDocumentToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.Docking.DockState.Float
                FloatingToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide, _
                 WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide, _
                 WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide, _
                WeifenLuo.WinFormsUI.Docking.DockState.DockTopAutoHide

                AutoHideToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.Docking.DockState.DockBottom, _
                 WeifenLuo.WinFormsUI.Docking.DockState.DockLeft, _
                 WeifenLuo.WinFormsUI.Docking.DockState.DockRight, _
                WeifenLuo.WinFormsUI.Docking.DockState.DockTop

                DockableToolStripMenuItem.Checked = True

        End Select
    End Sub


#Region "ContextMenuStrip Window Position"
    Private Sub FloatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FloatingToolStripMenuItem.Click
        Me.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Float
    End Sub

    Private Sub DockableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DockableToolStripMenuItem.Click
        Me.DockState = Me.ShowHint
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
        Dim MainForm As frmMain
        MainForm = My.Application.ApplicationContext.MainForm
        MainForm.OutToolStripMenuItem.Checked = False
    End Sub

    Private Sub AutoHideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoHideToolStripMenuItem.Click
        Select Case Me.DockState
            Case WeifenLuo.WinFormsUI.Docking.DockState.DockBottom
                DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide
            Case WeifenLuo.WinFormsUI.Docking.DockState.DockTop
                DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockTopAutoHide
            Case WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
                DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide
            Case WeifenLuo.WinFormsUI.Docking.DockState.DockRight
                DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide
        End Select
    End Sub

    Private Sub TabbedDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabbedDocumentToolStripMenuItem.Click
        DockState = WeifenLuo.WinFormsUI.Docking.DockState.Document
    End Sub
#End Region

   

    Private Sub frmOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolcmbFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolcmbFile.Click

    End Sub

    Private Sub ToolcmbFile_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolcmbFile.SelectedIndexChanged
        '在窗口输入控件流文件

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
