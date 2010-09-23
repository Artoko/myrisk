<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutOption
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
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.RdioChargeOrSlip2 = New System.Windows.Forms.RadioButton
        Me.RdioChargeOrSlip1 = New System.Windows.Forms.RadioButton
        Me.chkRisk = New System.Windows.Forms.CheckBox
        Me.txtInhalationTime = New Chart.CText
        Me.Label6111 = New System.Windows.Forms.Label
        Me.cmbGroundCharacter = New System.Windows.Forms.ComboBox
        Me.txtForeCount = New Chart.CText
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtIntervalTime = New Chart.CText
        Me.txtForeInterval = New Chart.CText
        Me.cmbModel = New System.Windows.Forms.ComboBox
        Me.txtForeStart = New Chart.CText
        Me.LabelIntervalTime = New System.Windows.Forms.Label
        Me.txtSamplingTime = New Chart.CText
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.chkInstantaneous = New System.Windows.Forms.CheckBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RdioChargeOrSlip2)
        Me.GroupBox6.Controls.Add(Me.RdioChargeOrSlip1)
        Me.GroupBox6.Controls.Add(Me.chkRisk)
        Me.GroupBox6.Controls.Add(Me.txtInhalationTime)
        Me.GroupBox6.Controls.Add(Me.Label6111)
        Me.GroupBox6.Location = New System.Drawing.Point(297, 124)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(259, 99)
        Me.GroupBox6.TabIndex = 279
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "              "
        '
        'RdioChargeOrSlip2
        '
        Me.RdioChargeOrSlip2.AutoSize = True
        Me.RdioChargeOrSlip2.Location = New System.Drawing.Point(49, 42)
        Me.RdioChargeOrSlip2.Name = "RdioChargeOrSlip2"
        Me.RdioChargeOrSlip2.Size = New System.Drawing.Size(191, 16)
        Me.RdioChargeOrSlip2.TabIndex = 6
        Me.RdioChargeOrSlip2.TabStop = True
        Me.RdioChargeOrSlip2.Text = "计算滑移平均最大浓度及风险值"
        Me.RdioChargeOrSlip2.UseVisualStyleBackColor = True
        '
        'RdioChargeOrSlip1
        '
        Me.RdioChargeOrSlip1.AutoSize = True
        Me.RdioChargeOrSlip1.Location = New System.Drawing.Point(49, 19)
        Me.RdioChargeOrSlip1.Name = "RdioChargeOrSlip1"
        Me.RdioChargeOrSlip1.Size = New System.Drawing.Size(155, 16)
        Me.RdioChargeOrSlip1.TabIndex = 5
        Me.RdioChargeOrSlip1.TabStop = True
        Me.RdioChargeOrSlip1.Text = "用毒性负荷法计算风险值"
        Me.RdioChargeOrSlip1.UseVisualStyleBackColor = True
        '
        'chkRisk
        '
        Me.chkRisk.AutoSize = True
        Me.chkRisk.Enabled = False
        Me.chkRisk.Location = New System.Drawing.Point(6, 0)
        Me.chkRisk.Name = "chkRisk"
        Me.chkRisk.Size = New System.Drawing.Size(84, 16)
        Me.chkRisk.TabIndex = 4
        Me.chkRisk.Text = "计算风险值"
        Me.chkRisk.UseVisualStyleBackColor = True
        '
        'txtInhalationTime
        '
        Me.txtInhalationTime.DataType = Chart.DataType.DataDouble
        Me.txtInhalationTime.ForeColor = System.Drawing.Color.Red
        Me.txtInhalationTime.Location = New System.Drawing.Point(141, 64)
        Me.txtInhalationTime.MaxValue = 999999999
        Me.txtInhalationTime.MinValue = 0
        Me.txtInhalationTime.Name = "txtInhalationTime"
        Me.txtInhalationTime.Size = New System.Drawing.Size(100, 21)
        Me.txtInhalationTime.TabIndex = 2
        Me.txtInhalationTime.Text = "0"
        Me.txtInhalationTime.Value = 0
        '
        'Label6111
        '
        Me.Label6111.AutoSize = True
        Me.Label6111.ForeColor = System.Drawing.Color.Red
        Me.Label6111.Location = New System.Drawing.Point(46, 67)
        Me.Label6111.Name = "Label6111"
        Me.Label6111.Size = New System.Drawing.Size(89, 12)
        Me.Label6111.TabIndex = 1
        Me.Label6111.Text = "吸入时间[min]:"
        '
        'cmbGroundCharacter
        '
        Me.cmbGroundCharacter.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGroundCharacter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGroundCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroundCharacter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbGroundCharacter.Items.AddRange(New Object() {"平原地区农村及城市远郊区", "工业区或城区", "丘陵山区的农村或城市"})
        Me.cmbGroundCharacter.Location = New System.Drawing.Point(82, 47)
        Me.cmbGroundCharacter.Name = "cmbGroundCharacter"
        Me.cmbGroundCharacter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbGroundCharacter.Size = New System.Drawing.Size(157, 20)
        Me.cmbGroundCharacter.TabIndex = 263
        '
        'txtForeCount
        '
        Me.txtForeCount.DataType = Chart.DataType.DataDouble
        Me.txtForeCount.Location = New System.Drawing.Point(142, 61)
        Me.txtForeCount.MaxValue = 0
        Me.txtForeCount.MinValue = 0
        Me.txtForeCount.Name = "txtForeCount"
        Me.txtForeCount.Size = New System.Drawing.Size(100, 21)
        Me.txtForeCount.TabIndex = 189
        Me.txtForeCount.Text = "0"
        Me.txtForeCount.Value = 0
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(17, 50)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(59, 12)
        Me.Label48.TabIndex = 264
        Me.Label48.Text = "地面特征:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(14, 23)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(77, 12)
        Me.Label31.TabIndex = 219
        Me.Label31.Text = "取样时间[h]:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtIntervalTime
        '
        Me.txtIntervalTime.DataType = Chart.DataType.DataInteger
        Me.txtIntervalTime.ForeColor = System.Drawing.Color.Red
        Me.txtIntervalTime.Location = New System.Drawing.Point(122, 54)
        Me.txtIntervalTime.MaxValue = 60
        Me.txtIntervalTime.MinValue = 1
        Me.txtIntervalTime.Name = "txtIntervalTime"
        Me.txtIntervalTime.Size = New System.Drawing.Size(119, 21)
        Me.txtIntervalTime.TabIndex = 284
        Me.txtIntervalTime.Text = "0"
        Me.txtIntervalTime.Value = 0
        '
        'txtForeInterval
        '
        Me.txtForeInterval.DataType = Chart.DataType.DataDouble
        Me.txtForeInterval.Location = New System.Drawing.Point(142, 40)
        Me.txtForeInterval.MaxValue = 0
        Me.txtForeInterval.MinValue = 0
        Me.txtForeInterval.Name = "txtForeInterval"
        Me.txtForeInterval.Size = New System.Drawing.Size(100, 21)
        Me.txtForeInterval.TabIndex = 188
        Me.txtForeInterval.Text = "0"
        Me.txtForeInterval.Value = 0
        '
        'cmbModel
        '
        Me.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModel.Enabled = False
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Items.AddRange(New Object() {"多烟团模型", "非正常排放模型"})
        Me.cmbModel.Location = New System.Drawing.Point(79, 23)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(162, 20)
        Me.cmbModel.TabIndex = 282
        '
        'txtForeStart
        '
        Me.txtForeStart.DataType = Chart.DataType.DataDouble
        Me.txtForeStart.Location = New System.Drawing.Point(142, 19)
        Me.txtForeStart.MaxValue = 1.0E+17
        Me.txtForeStart.MinValue = 0
        Me.txtForeStart.Name = "txtForeStart"
        Me.txtForeStart.Size = New System.Drawing.Size(100, 21)
        Me.txtForeStart.TabIndex = 184
        Me.txtForeStart.Text = "0"
        Me.txtForeStart.Value = 0
        '
        'LabelIntervalTime
        '
        Me.LabelIntervalTime.AutoSize = True
        Me.LabelIntervalTime.ForeColor = System.Drawing.Color.Red
        Me.LabelIntervalTime.Location = New System.Drawing.Point(15, 57)
        Me.LabelIntervalTime.Name = "LabelIntervalTime"
        Me.LabelIntervalTime.Size = New System.Drawing.Size(101, 12)
        Me.LabelIntervalTime.TabIndex = 283
        Me.LabelIntervalTime.Text = "烟团时间间隔[s]:"
        '
        'txtSamplingTime
        '
        Me.txtSamplingTime.DataType = Chart.DataType.DataDouble
        Me.txtSamplingTime.ForeColor = System.Drawing.Color.Red
        Me.txtSamplingTime.Location = New System.Drawing.Point(97, 20)
        Me.txtSamplingTime.MaxValue = 0
        Me.txtSamplingTime.MinValue = 0
        Me.txtSamplingTime.Name = "txtSamplingTime"
        Me.txtSamplingTime.Size = New System.Drawing.Size(142, 21)
        Me.txtSamplingTime.TabIndex = 220
        Me.txtSamplingTime.Text = "0"
        Me.txtSamplingTime.Value = 0
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(53, 64)
        Me.Label61.Name = "Label61"
        Me.Label61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label61.Size = New System.Drawing.Size(83, 12)
        Me.Label61.TabIndex = 183
        Me.Label61.Text = "预测时间个数:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(15, 26)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(59, 12)
        Me.Label51.TabIndex = 281
        Me.Label51.Text = "预测模型:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSamplingTime)
        Me.GroupBox2.Controls.Add(Me.cmbGroundCharacter)
        Me.GroupBox2.Controls.Add(Me.Label48)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 99)
        Me.GroupBox2.TabIndex = 280
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "扩散参数选项"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(25, 22)
        Me.Label68.Name = "Label68"
        Me.Label68.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label68.Size = New System.Drawing.Size(113, 12)
        Me.Label68.TabIndex = 183
        Me.Label68.Text = "预测开始时间[min]:"
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.chkInstantaneous)
        Me.GroupBox10.Controls.Add(Me.txtForeCount)
        Me.GroupBox10.Controls.Add(Me.txtForeInterval)
        Me.GroupBox10.Controls.Add(Me.txtForeStart)
        Me.GroupBox10.Controls.Add(Me.Label61)
        Me.GroupBox10.Controls.Add(Me.Label68)
        Me.GroupBox10.Controls.Add(Me.Label36)
        Me.GroupBox10.Location = New System.Drawing.Point(297, 28)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(259, 90)
        Me.GroupBox10.TabIndex = 278
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "           "
        '
        'chkInstantaneous
        '
        Me.chkInstantaneous.AutoSize = True
        Me.chkInstantaneous.ForeColor = System.Drawing.Color.Blue
        Me.chkInstantaneous.Location = New System.Drawing.Point(6, -1)
        Me.chkInstantaneous.Name = "chkInstantaneous"
        Me.chkInstantaneous.Size = New System.Drawing.Size(72, 16)
        Me.chkInstantaneous.TabIndex = 296
        Me.chkInstantaneous.Text = "瞬时浓度"
        Me.chkInstantaneous.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(17, 43)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(119, 12)
        Me.Label36.TabIndex = 183
        Me.Label36.Text = "预测时间间隔 [min]:"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(481, 239)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 295
        Me.Cancel_Button.Text = "取消(&C)"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(391, 239)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 294
        Me.OK_Button.Text = "确定(&O)"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbModel)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.LabelIntervalTime)
        Me.GroupBox1.Controls.Add(Me.txtIntervalTime)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 90)
        Me.GroupBox1.TabIndex = 296
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "模型选项"
        '
        'frmOutOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 283)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox10)
        Me.Name = "frmOutOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "输出选项"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInhalationTime As Chart.CText
    Friend WithEvents Label6111 As System.Windows.Forms.Label
    Public WithEvents cmbGroundCharacter As System.Windows.Forms.ComboBox
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtIntervalTime As Chart.CText
    Friend WithEvents txtForeInterval As Chart.CText
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents txtForeStart As Chart.CText
    Friend WithEvents LabelIntervalTime As System.Windows.Forms.Label
    Friend WithEvents txtSamplingTime As Chart.CText
    Public WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Public WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents chkInstantaneous As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtForeCount As Chart.CText
    Friend WithEvents chkRisk As System.Windows.Forms.CheckBox
    Friend WithEvents RdioChargeOrSlip2 As System.Windows.Forms.RadioButton
    Friend WithEvents RdioChargeOrSlip1 As System.Windows.Forms.RadioButton
End Class
