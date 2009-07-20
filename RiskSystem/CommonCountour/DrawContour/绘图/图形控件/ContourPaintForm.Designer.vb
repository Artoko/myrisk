<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContourPaintForm
    Inherits System.Windows.Forms.UserControl

    'UserControl1 重写 Dispose，以清理组件列表。
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
        Me.mnuPaint = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.设置SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.复制CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.复制BMP图形JToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.插入背景图IToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.裁切ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.伸缩埴满SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.背景图可见VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPaint.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPaint
        '
        Me.mnuPaint.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置SToolStripMenuItem, Me.复制CToolStripMenuItem, Me.复制BMP图形JToolStripMenuItem, Me.ToolStripSeparator1, Me.插入背景图IToolStripMenuItem, Me.裁切ToolStripMenuItem, Me.伸缩埴满SToolStripMenuItem, Me.背景图可见VToolStripMenuItem})
        Me.mnuPaint.Name = "mnuPaint"
        Me.mnuPaint.Size = New System.Drawing.Size(155, 186)
        '
        '设置SToolStripMenuItem
        '
        Me.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem"
        Me.设置SToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.设置SToolStripMenuItem.Text = "设置(&S)"
        Me.设置SToolStripMenuItem.ToolTipText = "设置绘图图形相关的参数"
        '
        '复制CToolStripMenuItem
        '
        Me.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem"
        Me.复制CToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.复制CToolStripMenuItem.Text = "复制EMF图形(&C)"
        Me.复制CToolStripMenuItem.ToolTipText = "EMP图形为矢量图形，占用的空间较大。"
        '
        '复制BMP图形JToolStripMenuItem
        '
        Me.复制BMP图形JToolStripMenuItem.Name = "复制BMP图形JToolStripMenuItem"
        Me.复制BMP图形JToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.复制BMP图形JToolStripMenuItem.Text = "复制BMP图形(&J)"
        Me.复制BMP图形JToolStripMenuItem.ToolTipText = "BMP图形为位图，占用的空间较小。"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        '插入背景图IToolStripMenuItem
        '
        Me.插入背景图IToolStripMenuItem.Name = "插入背景图IToolStripMenuItem"
        Me.插入背景图IToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.插入背景图IToolStripMenuItem.Text = "插入背景图(&I)"
        Me.插入背景图IToolStripMenuItem.Visible = False
        '
        '裁切ToolStripMenuItem
        '
        Me.裁切ToolStripMenuItem.Name = "裁切ToolStripMenuItem"
        Me.裁切ToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.裁切ToolStripMenuItem.Text = "裁切背景图"
        '
        '伸缩埴满SToolStripMenuItem
        '
        Me.伸缩埴满SToolStripMenuItem.Name = "伸缩埴满SToolStripMenuItem"
        Me.伸缩埴满SToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.伸缩埴满SToolStripMenuItem.Text = "伸缩填满(&S)"
        '
        '背景图可见VToolStripMenuItem
        '
        Me.背景图可见VToolStripMenuItem.Name = "背景图可见VToolStripMenuItem"
        Me.背景图可见VToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.背景图可见VToolStripMenuItem.Text = "背景图可见(&V)"
        '
        'ContourPaintForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.mnuPaint
        Me.DoubleBuffered = True
        Me.Name = "ContourPaintForm"
        Me.Size = New System.Drawing.Size(370, 264)
        Me.mnuPaint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents 设置SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 复制CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 插入背景图IToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 裁切ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 伸缩埴满SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 背景图可见VToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPaint As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 复制BMP图形JToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
