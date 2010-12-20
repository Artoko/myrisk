<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVaneMax
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVaneMax))
        Me.cmbTime = New System.Windows.Forms.ToolStripComboBox()
        Me.EFlexGeneral = New Chart.EFlex()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbRusult = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbMet = New System.Windows.Forms.ToolStripComboBox()
        Me.cmbNum = New System.Windows.Forms.ToolStripComboBox()
        CType(Me.EFlexGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbTime
        '
        Me.cmbTime.Name = "cmbTime"
        Me.cmbTime.Size = New System.Drawing.Size(121, 25)
        '
        'EFlexGeneral
        '
        Me.EFlexGeneral.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.EFlexGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EFlexGeneral.IsCopy = True
        Me.EFlexGeneral.IsCut = True
        Me.EFlexGeneral.IsPaste = True
        Me.EFlexGeneral.Location = New System.Drawing.Point(0, 25)
        Me.EFlexGeneral.Name = "EFlexGeneral"
        Me.EFlexGeneral.Rows.DefaultSize = 18
        Me.EFlexGeneral.Size = New System.Drawing.Size(943, 524)
        Me.EFlexGeneral.StyleInfo = resources.GetString("EFlexGeneral.StyleInfo")
        Me.EFlexGeneral.TabIndex = 36
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabel3.Text = "预测时刻[min]:"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel2.Text = "小数位数:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.cmbRusult, Me.ToolStripLabel1, Me.cmbMet, Me.ToolStripLabel3, Me.cmbTime, Me.ToolStripLabel2, Me.cmbNum})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(943, 25)
        Me.ToolStrip1.TabIndex = 37
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
        Me.cmbMet.Name = "cmbMet"
        Me.cmbMet.Size = New System.Drawing.Size(121, 25)
        '
        'cmbNum
        '
        Me.cmbNum.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cmbNum.Name = "cmbNum"
        Me.cmbNum.Size = New System.Drawing.Size(121, 25)
        '
        'frmVaneMax
        '
        Me.ClientSize = New System.Drawing.Size(943, 549)
        Me.Controls.Add(Me.EFlexGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "frmVaneMax"
        Me.TabText = "结果概述"
        Me.Text = "结果概述"
        CType(Me.EFlexGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTime As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents EFlexGeneral As Chart.EFlex
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbMet As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cmbNum As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbRusult As System.Windows.Forms.ToolStripComboBox

End Class
