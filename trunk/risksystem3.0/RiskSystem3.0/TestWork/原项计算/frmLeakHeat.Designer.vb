<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakHeat
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Me.SaveSign = New System.Windows.Forms.TextBox
        Me.FileName = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.frame2 = New System.Windows.Forms.GroupBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.RichLeakResult = New System.Windows.Forms.TextBox
        Me.cmdCalculateLeak = New System.Windows.Forms.Button
        Me.txtLeakEvaporationTb = New System.Windows.Forms.TextBox
        Me.txtLeakEvaporationH = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtLeakEvaporationS = New System.Windows.Forms.TextBox
        Me.txtleakevaporationt = New System.Windows.Forms.TextBox
        Me.cboLeakEvaporationGround = New System.Windows.Forms.ComboBox
        Me.txtLeakEvaporationT0 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckIsSaved = New System.Windows.Forms.CheckBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.frame2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveSign
        '
        Me.SaveSign.AcceptsReturn = True
        Me.SaveSign.BackColor = System.Drawing.SystemColors.Window
        Me.SaveSign.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaveSign.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SaveSign.Location = New System.Drawing.Point(399, 51)
        Me.SaveSign.MaxLength = 0
        Me.SaveSign.Name = "SaveSign"
        Me.SaveSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SaveSign.Size = New System.Drawing.Size(76, 21)
        Me.SaveSign.TabIndex = 33
        Me.SaveSign.Text = "LeakHeat"
        Me.SaveSign.Visible = False
        '
        'FileName
        '
        Me.FileName.AcceptsReturn = True
        Me.FileName.BackColor = System.Drawing.SystemColors.Window
        Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FileName.Location = New System.Drawing.Point(486, 51)
        Me.FileName.MaxLength = 0
        Me.FileName.Name = "FileName"
        Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileName.Size = New System.Drawing.Size(61, 21)
        Me.FileName.TabIndex = 32
        Me.FileName.Visible = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(299, 176)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(149, 25)
        Me.Command1.TabIndex = 31
        Me.Command1.Text = "从数据库中查找物化数据"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(94, 34)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(161, 21)
        Me.txtName.TabIndex = 29
        Me.txtName.Text = "液氨"
        '
        'frame2
        '
        Me.frame2.BackColor = System.Drawing.SystemColors.Control
        Me.frame2.Controls.Add(Me.cmdSave)
        Me.frame2.Controls.Add(Me.RichLeakResult)
        Me.frame2.Controls.Add(Me.cmdCalculateLeak)
        Me.frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frame2.Location = New System.Drawing.Point(12, 218)
        Me.frame2.Name = "frame2"
        Me.frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frame2.Size = New System.Drawing.Size(559, 118)
        Me.frame2.TabIndex = 28
        Me.frame2.TabStop = False
        Me.frame2.Text = "计算结果"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(30, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 25)
        Me.cmdSave.TabIndex = 25
        Me.cmdSave.Text = "保存(&S)"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'RichLeakResult
        '
        Me.RichLeakResult.AcceptsReturn = True
        Me.RichLeakResult.BackColor = System.Drawing.SystemColors.Window
        Me.RichLeakResult.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichLeakResult.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RichLeakResult.Location = New System.Drawing.Point(129, 20)
        Me.RichLeakResult.MaxLength = 0
        Me.RichLeakResult.Multiline = True
        Me.RichLeakResult.Name = "RichLeakResult"
        Me.RichLeakResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RichLeakResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RichLeakResult.Size = New System.Drawing.Size(406, 80)
        Me.RichLeakResult.TabIndex = 24
        '
        'cmdCalculateLeak
        '
        Me.cmdCalculateLeak.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculateLeak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculateLeak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculateLeak.Location = New System.Drawing.Point(30, 20)
        Me.cmdCalculateLeak.Name = "cmdCalculateLeak"
        Me.cmdCalculateLeak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculateLeak.Size = New System.Drawing.Size(89, 25)
        Me.cmdCalculateLeak.TabIndex = 23
        Me.cmdCalculateLeak.Text = "计算(&C)"
        Me.cmdCalculateLeak.UseVisualStyleBackColor = True
        '
        'txtLeakEvaporationTb
        '
        Me.txtLeakEvaporationTb.AcceptsReturn = True
        Me.txtLeakEvaporationTb.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationTb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationTb.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakEvaporationTb.Location = New System.Drawing.Point(141, 20)
        Me.txtLeakEvaporationTb.MaxLength = 0
        Me.txtLeakEvaporationTb.Name = "txtLeakEvaporationTb"
        Me.txtLeakEvaporationTb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationTb.Size = New System.Drawing.Size(107, 21)
        Me.txtLeakEvaporationTb.TabIndex = 19
        Me.txtLeakEvaporationTb.Text = "-33"
        '
        'txtLeakEvaporationH
        '
        Me.txtLeakEvaporationH.AcceptsReturn = True
        Me.txtLeakEvaporationH.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationH.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakEvaporationH.Location = New System.Drawing.Point(141, 47)
        Me.txtLeakEvaporationH.MaxLength = 0
        Me.txtLeakEvaporationH.Name = "txtLeakEvaporationH"
        Me.txtLeakEvaporationH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationH.Size = New System.Drawing.Size(107, 21)
        Me.txtLeakEvaporationH.TabIndex = 18
        Me.txtLeakEvaporationH.Text = "25000"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(34, 23)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(101, 12)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "液体沸点 Tb[℃]:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(16, 50)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(119, 12)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "液体气化热 H[J/kg]:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLeakEvaporationS
        '
        Me.txtLeakEvaporationS.AcceptsReturn = True
        Me.txtLeakEvaporationS.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakEvaporationS.Location = New System.Drawing.Point(129, 20)
        Me.txtLeakEvaporationS.MaxLength = 0
        Me.txtLeakEvaporationS.Name = "txtLeakEvaporationS"
        Me.txtLeakEvaporationS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationS.Size = New System.Drawing.Size(113, 21)
        Me.txtLeakEvaporationS.TabIndex = 12
        Me.txtLeakEvaporationS.Text = "5"
        '
        'txtleakevaporationt
        '
        Me.txtleakevaporationt.AcceptsReturn = True
        Me.txtleakevaporationt.BackColor = System.Drawing.SystemColors.Window
        Me.txtleakevaporationt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtleakevaporationt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtleakevaporationt.Location = New System.Drawing.Point(129, 47)
        Me.txtleakevaporationt.MaxLength = 0
        Me.txtleakevaporationt.Name = "txtleakevaporationt"
        Me.txtleakevaporationt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtleakevaporationt.Size = New System.Drawing.Size(113, 21)
        Me.txtleakevaporationt.TabIndex = 11
        Me.txtleakevaporationt.Text = "20"
        '
        'cboLeakEvaporationGround
        '
        Me.cboLeakEvaporationGround.BackColor = System.Drawing.SystemColors.Window
        Me.cboLeakEvaporationGround.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLeakEvaporationGround.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeakEvaporationGround.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLeakEvaporationGround.Items.AddRange(New Object() {"水泥", "土地(含水8%)", "干阔土地", "湿地", "砂砾地"})
        Me.cboLeakEvaporationGround.Location = New System.Drawing.Point(129, 101)
        Me.cboLeakEvaporationGround.Name = "cboLeakEvaporationGround"
        Me.cboLeakEvaporationGround.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLeakEvaporationGround.Size = New System.Drawing.Size(113, 20)
        Me.cboLeakEvaporationGround.TabIndex = 10
        '
        'txtLeakEvaporationT0
        '
        Me.txtLeakEvaporationT0.AcceptsReturn = True
        Me.txtLeakEvaporationT0.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationT0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationT0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakEvaporationT0.Location = New System.Drawing.Point(129, 74)
        Me.txtLeakEvaporationT0.MaxLength = 0
        Me.txtLeakEvaporationT0.Name = "txtLeakEvaporationT0"
        Me.txtLeakEvaporationT0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationT0.Size = New System.Drawing.Size(113, 21)
        Me.txtLeakEvaporationT0.TabIndex = 9
        Me.txtLeakEvaporationT0.Text = "30"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(28, 23)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(95, 12)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "液池面积S[m^2];"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(40, 50)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(83, 12)
        Me.Label33.TabIndex = 15
        Me.Label33.Text = "蒸发时刻t[s]:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(64, 104)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(59, 12)
        Me.Label29.TabIndex = 14
        Me.Label29.Text = "地面情况:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(28, 77)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(95, 12)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "环境温度T0[℃]:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(29, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "物质名称:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLeakEvaporationS)
        Me.GroupBox1.Controls.Add(Me.cboLeakEvaporationGround)
        Me.GroupBox1.Controls.Add(Me.txtleakevaporationt)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtLeakEvaporationT0)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 134)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "泄漏参数"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLeakEvaporationTb)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtLeakEvaporationH)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Location = New System.Drawing.Point(299, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 80)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物料物性"
        '
        'CheckIsSaved
        '
        Me.CheckIsSaved.AutoSize = True
        Me.CheckIsSaved.Location = New System.Drawing.Point(462, 29)
        Me.CheckIsSaved.Name = "CheckIsSaved"
        Me.CheckIsSaved.Size = New System.Drawing.Size(96, 16)
        Me.CheckIsSaved.TabIndex = 45
        Me.CheckIsSaved.Text = "CheckIsSaved"
        Me.CheckIsSaved.UseVisualStyleBackColor = True
        Me.CheckIsSaved.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmLeakHeat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 366)
        Me.Controls.Add(Me.CheckIsSaved)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SaveSign)
        Me.Controls.Add(Me.FileName)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.frame2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeakHeat"
        Me.Text = "热量蒸发估算"
        Me.frame2.ResumeLayout(False)
        Me.frame2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents SaveSign As System.Windows.Forms.TextBox
    Public WithEvents FileName As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents frame2 As System.Windows.Forms.GroupBox
    Public WithEvents txtLeakEvaporationTb As System.Windows.Forms.TextBox
    Public WithEvents txtLeakEvaporationH As System.Windows.Forms.TextBox
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents txtLeakEvaporationS As System.Windows.Forms.TextBox
    Public WithEvents txtleakevaporationt As System.Windows.Forms.TextBox
    Public WithEvents cboLeakEvaporationGround As System.Windows.Forms.ComboBox
    Public WithEvents txtLeakEvaporationT0 As System.Windows.Forms.TextBox
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents RichLeakResult As System.Windows.Forms.TextBox
    Public WithEvents cmdCalculateLeak As System.Windows.Forms.Button
    Friend WithEvents CheckIsSaved As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
