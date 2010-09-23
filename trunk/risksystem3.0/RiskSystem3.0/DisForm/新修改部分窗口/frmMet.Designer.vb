<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMet
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMet))
        Me.EFlexMet = New Chart.EFlex
        Me.cmdDelMet = New System.Windows.Forms.Button
        Me.cmdAddMet = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtPa = New Chart.CText
        Me.txtTa = New Chart.CText
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        CType(Me.EFlexMet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'EFlexMet
        '
        Me.EFlexMet.ColumnInfo = resources.GetString("EFlexMet.ColumnInfo")
        Me.EFlexMet.Dock = System.Windows.Forms.DockStyle.Top
        Me.EFlexMet.IsCopy = True
        Me.EFlexMet.IsCut = True
        Me.EFlexMet.IsPaste = True
        Me.EFlexMet.Location = New System.Drawing.Point(3, 3)
        Me.EFlexMet.Name = "EFlexMet"
        Me.EFlexMet.Rows.Count = 2
        Me.EFlexMet.Rows.DefaultSize = 18
        Me.EFlexMet.Size = New System.Drawing.Size(687, 416)
        Me.EFlexMet.StyleInfo = resources.GetString("EFlexMet.StyleInfo")
        Me.EFlexMet.TabIndex = 259
        '
        'cmdDelMet
        '
        Me.cmdDelMet.Location = New System.Drawing.Point(241, 425)
        Me.cmdDelMet.Name = "cmdDelMet"
        Me.cmdDelMet.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelMet.TabIndex = 261
        Me.cmdDelMet.Text = "删除(&D)"
        Me.cmdDelMet.UseVisualStyleBackColor = True
        '
        'cmdAddMet
        '
        Me.cmdAddMet.Location = New System.Drawing.Point(160, 425)
        Me.cmdAddMet.Name = "cmdAddMet"
        Me.cmdAddMet.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddMet.TabIndex = 260
        Me.cmdAddMet.Text = "添加(&A)"
        Me.cmdAddMet.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtPa)
        Me.GroupBox9.Controls.Add(Me.txtTa)
        Me.GroupBox9.Controls.Add(Me.Label3)
        Me.GroupBox9.Controls.Add(Me.Label27)
        Me.GroupBox9.Location = New System.Drawing.Point(20, 22)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(251, 83)
        Me.GroupBox9.TabIndex = 269
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "环境参数"
        '
        'txtPa
        '
        Me.txtPa.DataType = Chart.DataType.DataDouble
        Me.txtPa.Location = New System.Drawing.Point(114, 47)
        Me.txtPa.MaxValue = 201325
        Me.txtPa.MinValue = 0
        Me.txtPa.Name = "txtPa"
        Me.txtPa.Size = New System.Drawing.Size(100, 21)
        Me.txtPa.TabIndex = 50
        Me.txtPa.Text = "0"
        Me.txtPa.Value = 0
        '
        'txtTa
        '
        Me.txtTa.DataType = Chart.DataType.DataDouble
        Me.txtTa.Location = New System.Drawing.Point(114, 20)
        Me.txtTa.MaxValue = 60
        Me.txtTa.MinValue = -50
        Me.txtTa.Name = "txtTa"
        Me.txtTa.Size = New System.Drawing.Size(100, 21)
        Me.txtTa.TabIndex = 49
        Me.txtTa.Text = "0"
        Me.txtTa.Value = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(13, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "环境温度Ta[℃]:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(13, 50)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(95, 12)
        Me.Label27.TabIndex = 47
        Me.Label27.Text = "大气压力Pa[Pa]:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(374, 276)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(701, 476)
        Me.TabControl1.TabIndex = 271
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.cmdDelMet)
        Me.TabPage1.Controls.Add(Me.EFlexMet)
        Me.TabPage1.Controls.Add(Me.cmdAddMet)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(693, 451)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "气象条件"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GroupBox9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(693, 451)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "环境参数"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(602, 493)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 293
        Me.Cancel_Button.Text = "取消(&C)"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(512, 493)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 292
        Me.OK_Button.Text = "确定(&O)"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'frmMet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 528)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmMet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "气象数据"
        CType(Me.EFlexMet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EFlexMet As Chart.EFlex
    Friend WithEvents cmdDelMet As System.Windows.Forms.Button
    Friend WithEvents cmdAddMet As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPa As Chart.CText
    Friend WithEvents txtTa As Chart.CText
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
End Class
