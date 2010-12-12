Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI
Public Class frmResultMain
    ''' <summary>
    ''' 计算结果的项目管理器窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public frmResultSolution As New frmResultSolution
    ''' <summary>
    ''' 结果窗口的绘图窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public frmResultMapGis As New frmResultMapGis
    ''' <summary>
    ''' 计算结果的对应项目管理窗口的设置窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public frmResultSet As New frmResultSet
    ''' <summary>
    ''' 计算结果的图层管理窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public frmResultLayersManage As New frmMapLayersManage
    ''' <summary>
    ''' 计算结果的图层对应的属性窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public frmResultProperty As New frmProperty

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' 创建此子窗体的一个新实例。
        Dim ChildForm As New System.Windows.Forms.Form
        ' 在显示该窗体前使其成为此 MDI 窗体的子窗体。
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "窗口 " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: 在此处添加打开文件的代码。
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' 使用 My.Computer.Clipboard 将选择的文本或图像插入剪贴板
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' 使用 My.Computer.Clipboard 将选择的文本或图像插入剪贴板
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        '使用 My.Computer.Clipboard.GetText() 或 My.Computer.Clipboard.GetData 从剪贴板检索信息。
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' 关闭此父窗体的所有子窗体。
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmResultMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.frmResultMapGis.Show(DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document) '显示各点高值窗口
        Me.frmResultMapGis.InitWindow(Project0, Me)

        Me.frmResultSolution.Show(DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
        Me.frmResultSet.Show(frmResultSolution.DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
        Me.frmResultSet.DockTo(frmResultSolution.Pane, DockStyle.Bottom, 0)
        Me.frmResultLayersManage.Show(DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockRight)
        Me.frmResultProperty.Show(Me.frmResultLayersManage.DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockRight)
        Me.frmResultProperty.DockTo(Me.frmResultLayersManage.Pane, DockStyle.Bottom, 0)
    End Sub


  
End Class
