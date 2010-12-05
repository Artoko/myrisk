<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOut
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
        Me.components = New System.ComponentModel.Container
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolcmbFile = New System.Windows.Forms.ToolStripComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ContextMenuDock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FloatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DockableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabbedDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoHideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuDock.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolcmbFile})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(496, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel1.Text = "选择文件:"
        '
        'ToolcmbFile
        '
        Me.ToolcmbFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolcmbFile.Name = "ToolcmbFile"
        Me.ToolcmbFile.Size = New System.Drawing.Size(121, 25)
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 25)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(496, 302)
        Me.TextBox1.TabIndex = 1
        '
        'ContextMenuDock
        '
        Me.ContextMenuDock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FloatingToolStripMenuItem, Me.DockableToolStripMenuItem, Me.TabbedDocumentToolStripMenuItem, Me.AutoHideToolStripMenuItem, Me.HideToolStripMenuItem})
        Me.ContextMenuDock.Name = "ContextMenuStrip1"
        Me.ContextMenuDock.Size = New System.Drawing.Size(161, 114)
        Me.ContextMenuDock.Text = "Window Position"
        '
        'FloatingToolStripMenuItem
        '
        Me.FloatingToolStripMenuItem.CheckOnClick = True
        Me.FloatingToolStripMenuItem.Name = "FloatingToolStripMenuItem"
        Me.FloatingToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.FloatingToolStripMenuItem.Text = "浮动(&F)"
        '
        'DockableToolStripMenuItem
        '
        Me.DockableToolStripMenuItem.Checked = True
        Me.DockableToolStripMenuItem.CheckOnClick = True
        Me.DockableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DockableToolStripMenuItem.Name = "DockableToolStripMenuItem"
        Me.DockableToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DockableToolStripMenuItem.Text = "可停靠(&K)"
        '
        'TabbedDocumentToolStripMenuItem
        '
        Me.TabbedDocumentToolStripMenuItem.CheckOnClick = True
        Me.TabbedDocumentToolStripMenuItem.Name = "TabbedDocumentToolStripMenuItem"
        Me.TabbedDocumentToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TabbedDocumentToolStripMenuItem.Text = "选项卡式文档(&T)"
        '
        'AutoHideToolStripMenuItem
        '
        Me.AutoHideToolStripMenuItem.CheckOnClick = True
        Me.AutoHideToolStripMenuItem.Name = "AutoHideToolStripMenuItem"
        Me.AutoHideToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.AutoHideToolStripMenuItem.Text = "自动隐藏(&A)"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.CheckOnClick = True
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.HideToolStripMenuItem.Text = "隐藏(&H)"
        '
        'frmOut
        '
        Me.ClientSize = New System.Drawing.Size(496, 327)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.HideOnClose = True
        Me.Name = "frmOut"
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom
        Me.ShowIcon = False
        Me.TabPageContextMenuStrip = Me.ContextMenuDock
        Me.TabText = "输出"
        Me.Text = "输出"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuDock.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuDock As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FloatingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabbedDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoHideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolcmbFile As System.Windows.Forms.ToolStripComboBox

End Class
