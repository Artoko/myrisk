<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResult
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResult))
        Me.ContextMenuDock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FloatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DockableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabbedDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoHideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ContextMenuDock.SuspendLayout()
        Me.SuspendLayout()
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
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(584, 419)
        Me.TreeView1.TabIndex = 1
        '
        'frmResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 419)
        Me.Controls.Add(Me.TreeView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmResult"
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
        Me.TabPageContextMenuStrip = Me.ContextMenuDock
        Me.TabText = "结果"
        Me.Text = "结果"
        Me.ContextMenuDock.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuDock As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FloatingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabbedDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoHideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
