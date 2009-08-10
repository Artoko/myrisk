<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrawContour
    Inherits RiskSystem.frmDocking

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
        Me.ContourPaint1 = New RiskContourContol
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.cmbRusult = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cmbMet = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.cmbTime = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContourPaint1
        '
        Me.ContourPaint1.DBlClkSet = False
        Me.ContourPaint1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContourPaint1.Location = New System.Drawing.Point(0, 25)
        Me.ContourPaint1.Menu = True
        Me.ContourPaint1.MouseMoveType = 0
        Me.ContourPaint1.Name = "ContourPaint1"
        Me.ContourPaint1.Size = New System.Drawing.Size(1008, 680)
        Me.ContourPaint1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.cmbRusult, Me.ToolStripLabel1, Me.cmbMet, Me.ToolStripLabel3, Me.cmbTime})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel4.Text = "结果表述:"
        '
        'cmbRusult
        '
        Me.cmbRusult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRusult.Name = "cmbRusult"
        Me.cmbRusult.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel1.Text = "气象类型:"
        '
        'cmbMet
        '
        Me.cmbMet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMet.Name = "cmbMet"
        Me.cmbMet.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabel3.Text = "预测时刻[min]:"
        '
        'cmbTime
        '
        Me.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTime.Name = "cmbTime"
        Me.cmbTime.Size = New System.Drawing.Size(121, 25)
        '
        'frmDrawContour
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 705)
        Me.Controls.Add(Me.ContourPaint1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmDrawContour"
        Me.TabText = "绘图"
        Me.Text = "绘图"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContourPaint1 As DrawContour.ContourPaintForm
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbRusult As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbMet As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbTime As System.Windows.Forms.ToolStripComboBox

End Class
