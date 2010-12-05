<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrawLayer
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    '窗体重写释放，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("背景图")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("平面图")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("坐标轴")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("刻度")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("网格")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("坐标图", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("等值线")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("等值线填充")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("等值线", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("污染源")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("关心点")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("建筑物")
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Checked = True
        TreeNode1.Name = "LayBackPicture"
        TreeNode1.Text = "背景图"
        TreeNode2.Checked = True
        TreeNode2.Name = "LayPlan"
        TreeNode2.Text = "平面图"
        TreeNode3.Checked = True
        TreeNode3.Name = "LayAxis"
        TreeNode3.Text = "坐标轴"
        TreeNode4.Checked = True
        TreeNode4.Name = "LayScale"
        TreeNode4.Text = "刻度"
        TreeNode5.Checked = True
        TreeNode5.Name = "LayGrid"
        TreeNode5.Text = "网格"
        TreeNode6.Checked = True
        TreeNode6.Name = "LayAxes"
        TreeNode6.Text = "坐标图"
        TreeNode7.Checked = True
        TreeNode7.Name = "LayContourLine"
        TreeNode7.Text = "等值线"
        TreeNode8.Checked = True
        TreeNode8.Name = "LayContourPaint"
        TreeNode8.Text = "等值线填充"
        TreeNode9.Checked = True
        TreeNode9.Name = "LayContours"
        TreeNode9.Text = "等值线"
        TreeNode10.Checked = True
        TreeNode10.Name = "LaySource"
        TreeNode10.Text = "污染源"
        TreeNode11.Checked = True
        TreeNode11.Name = "LayCare"
        TreeNode11.Text = "关心点"
        TreeNode12.Checked = True
        TreeNode12.Name = "LayBulding"
        TreeNode12.Text = "建筑物"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode6, TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Me.TreeView1.Size = New System.Drawing.Size(292, 266)
        Me.TreeView1.TabIndex = 0
        '
        'frmDrawLayer
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "frmDrawLayer"
        Me.TabText = "图层"
        Me.Text = "图层"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

End Class
