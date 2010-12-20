<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSlabCon
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form 重写 Dispose，以清理组件列表。
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSlabCon))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbMet = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbTime = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbNum = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.复制CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EFlexGeneral = New Chart.EFlex()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TChart1 = New Steema.TeeChart.TChart()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.EFlexGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cmbMet, Me.ToolStripLabel3, Me.cmbTime, Me.ToolStripLabel2, Me.cmbNum})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(736, 25)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel1.Text = "气象类型:"
        '
        'cmbMet
        '
        Me.cmbMet.Name = "cmbMet"
        Me.cmbMet.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel3.Text = "步长[m]:"
        '
        'cmbTime
        '
        Me.cmbTime.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbTime.Name = "cmbTime"
        Me.cmbTime.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel2.Text = "小数位数:"
        '
        'cmbNum
        '
        Me.cmbNum.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cmbNum.Name = "cmbNum"
        Me.cmbNum.Size = New System.Drawing.Size(121, 25)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.复制CToolStripMenuItem, Me.设置SToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(113, 48)
        '
        '复制CToolStripMenuItem
        '
        Me.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem"
        Me.复制CToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.复制CToolStripMenuItem.Text = "复制(&C)"
        '
        '设置SToolStripMenuItem
        '
        Me.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem"
        Me.设置SToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.设置SToolStripMenuItem.Text = "设置(&S)"
        '
        'EFlexGeneral
        '
        Me.EFlexGeneral.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.EFlexGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EFlexGeneral.IsCopy = True
        Me.EFlexGeneral.IsCut = True
        Me.EFlexGeneral.IsPaste = True
        Me.EFlexGeneral.Location = New System.Drawing.Point(0, 0)
        Me.EFlexGeneral.Name = "EFlexGeneral"
        Me.EFlexGeneral.Rows.DefaultSize = 18
        Me.EFlexGeneral.Size = New System.Drawing.Size(736, 230)
        Me.EFlexGeneral.StyleInfo = resources.GetString("EFlexGeneral.StyleInfo")
        Me.EFlexGeneral.TabIndex = 21
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.EFlexGeneral)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TChart1)
        Me.SplitContainer1.Size = New System.Drawing.Size(736, 465)
        Me.SplitContainer1.SplitterDistance = 230
        Me.SplitContainer1.TabIndex = 43
        '
        'TChart1
        '
        '
        '
        '
        Me.TChart1.Aspect.ZOffset = 0.0R
        Me.TChart1.Location = New System.Drawing.Point(14, 18)
        Me.TChart1.Name = "TChart1"
        Me.TChart1.Size = New System.Drawing.Size(684, 173)
        Me.TChart1.TabIndex = 0
        '
        'frmSlabCon
        '
        Me.ClientSize = New System.Drawing.Size(736, 490)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "frmSlabCon"
        Me.TabText = "连续重气体参数"
        Me.Text = "连续重气体参数"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.EFlexGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbMet As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbTime As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbNum As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 复制CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EFlexGeneral As Chart.EFlex
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TChart1 As Steema.TeeChart.TChart

End Class
