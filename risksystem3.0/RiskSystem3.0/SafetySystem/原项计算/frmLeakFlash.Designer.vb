<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakFlash
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
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCalculateLeak = New System.Windows.Forms.Button
        Me.RichLeakResult = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidCP = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidTLG = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidTC = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidH = New System.Windows.Forms.TextBox
        Me.text5 = New System.Windows.Forms.Label
        Me.lable28 = New System.Windows.Forms.Label
        Me.table28 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkLiquid = New System.Windows.Forms.CheckBox
        Me.txtQ = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckIsSaved = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveSign
        '
        Me.SaveSign.AcceptsReturn = True
        Me.SaveSign.BackColor = System.Drawing.SystemColors.Window
        Me.SaveSign.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaveSign.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SaveSign.Location = New System.Drawing.Point(210, 176)
        Me.SaveSign.MaxLength = 0
        Me.SaveSign.Name = "SaveSign"
        Me.SaveSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SaveSign.Size = New System.Drawing.Size(41, 21)
        Me.SaveSign.TabIndex = 32
        Me.SaveSign.Text = "LeakFlash"
        Me.SaveSign.Visible = False
        '
        'FileName
        '
        Me.FileName.AcceptsReturn = True
        Me.FileName.BackColor = System.Drawing.SystemColors.Window
        Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FileName.Location = New System.Drawing.Point(259, 176)
        Me.FileName.MaxLength = 0
        Me.FileName.Name = "FileName"
        Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileName.Size = New System.Drawing.Size(61, 21)
        Me.FileName.TabIndex = 31
        Me.FileName.Visible = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(12, 172)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(149, 25)
        Me.Command1.TabIndex = 30
        Me.Command1.Text = "从数据库中查找物化数据"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(13, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 25)
        Me.cmdSave.TabIndex = 21
        Me.cmdSave.Text = "保存(&S)"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCalculateLeak
        '
        Me.cmdCalculateLeak.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculateLeak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculateLeak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculateLeak.Location = New System.Drawing.Point(12, 20)
        Me.cmdCalculateLeak.Name = "cmdCalculateLeak"
        Me.cmdCalculateLeak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculateLeak.Size = New System.Drawing.Size(89, 25)
        Me.cmdCalculateLeak.TabIndex = 6
        Me.cmdCalculateLeak.Text = "计算(&C)"
        Me.cmdCalculateLeak.UseVisualStyleBackColor = True
        '
        'RichLeakResult
        '
        Me.RichLeakResult.AcceptsReturn = True
        Me.RichLeakResult.BackColor = System.Drawing.SystemColors.Window
        Me.RichLeakResult.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichLeakResult.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RichLeakResult.Location = New System.Drawing.Point(108, 20)
        Me.RichLeakResult.MaxLength = 0
        Me.RichLeakResult.Multiline = True
        Me.RichLeakResult.Name = "RichLeakResult"
        Me.RichLeakResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RichLeakResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RichLeakResult.Size = New System.Drawing.Size(445, 91)
        Me.RichLeakResult.TabIndex = 5
        '
        'txtLeakLiquidCP
        '
        Me.txtLeakLiquidCP.AcceptsReturn = True
        Me.txtLeakLiquidCP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidCP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidCP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidCP.Location = New System.Drawing.Point(176, 44)
        Me.txtLeakLiquidCP.MaxLength = 0
        Me.txtLeakLiquidCP.Name = "txtLeakLiquidCP"
        Me.txtLeakLiquidCP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidCP.Size = New System.Drawing.Size(89, 21)
        Me.txtLeakLiquidCP.TabIndex = 16
        Me.txtLeakLiquidCP.Text = "4.6"
        '
        'txtLeakLiquidTLG
        '
        Me.txtLeakLiquidTLG.AcceptsReturn = True
        Me.txtLeakLiquidTLG.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidTLG.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidTLG.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakLiquidTLG.Location = New System.Drawing.Point(159, 44)
        Me.txtLeakLiquidTLG.MaxLength = 0
        Me.txtLeakLiquidTLG.Name = "txtLeakLiquidTLG"
        Me.txtLeakLiquidTLG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidTLG.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakLiquidTLG.TabIndex = 15
        Me.txtLeakLiquidTLG.Text = "30"
        '
        'txtLeakLiquidTC
        '
        Me.txtLeakLiquidTC.AcceptsReturn = True
        Me.txtLeakLiquidTC.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidTC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidTC.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidTC.Location = New System.Drawing.Point(176, 17)
        Me.txtLeakLiquidTC.MaxLength = 0
        Me.txtLeakLiquidTC.Name = "txtLeakLiquidTC"
        Me.txtLeakLiquidTC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidTC.Size = New System.Drawing.Size(89, 21)
        Me.txtLeakLiquidTC.TabIndex = 14
        Me.txtLeakLiquidTC.Text = "-33"
        '
        'txtLeakLiquidH
        '
        Me.txtLeakLiquidH.AcceptsReturn = True
        Me.txtLeakLiquidH.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidH.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidH.Location = New System.Drawing.Point(176, 71)
        Me.txtLeakLiquidH.MaxLength = 0
        Me.txtLeakLiquidH.Name = "txtLeakLiquidH"
        Me.txtLeakLiquidH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidH.Size = New System.Drawing.Size(89, 21)
        Me.txtLeakLiquidH.TabIndex = 13
        Me.txtLeakLiquidH.Text = "1367"
        '
        'text5
        '
        Me.text5.AutoSize = True
        Me.text5.BackColor = System.Drawing.SystemColors.Control
        Me.text5.Cursor = System.Windows.Forms.Cursors.Default
        Me.text5.ForeColor = System.Drawing.Color.Blue
        Me.text5.Location = New System.Drawing.Point(9, 47)
        Me.text5.Name = "text5"
        Me.text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.text5.Size = New System.Drawing.Size(161, 12)
        Me.text5.TabIndex = 20
        Me.text5.Text = "液体定压比热CP[J/(kg·K)]:"
        Me.text5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lable28
        '
        Me.lable28.AutoSize = True
        Me.lable28.BackColor = System.Drawing.SystemColors.Control
        Me.lable28.Cursor = System.Windows.Forms.Cursors.Default
        Me.lable28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lable28.Location = New System.Drawing.Point(10, 47)
        Me.lable28.Name = "lable28"
        Me.lable28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lable28.Size = New System.Drawing.Size(143, 12)
        Me.lable28.TabIndex = 19
        Me.lable28.Text = "泄漏前液体的温度TL[℃]:"
        Me.lable28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'table28
        '
        Me.table28.AutoSize = True
        Me.table28.BackColor = System.Drawing.SystemColors.Control
        Me.table28.Cursor = System.Windows.Forms.Cursors.Default
        Me.table28.ForeColor = System.Drawing.Color.Blue
        Me.table28.Location = New System.Drawing.Point(16, 22)
        Me.table28.Name = "table28"
        Me.table28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.table28.Size = New System.Drawing.Size(155, 12)
        Me.table28.TabIndex = 18
        Me.table28.Text = "液体在常压下的沸点Tb[℃]:"
        Me.table28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(45, 75)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(125, 12)
        Me.Label24.TabIndex = 17
        Me.Label24.Text = "液体的气化热H[J/kg]:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkLiquid)
        Me.GroupBox1.Controls.Add(Me.lable28)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidTLG)
        Me.GroupBox1.Controls.Add(Me.txtQ)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 101)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "泄漏参数"
        '
        'chkLiquid
        '
        Me.chkLiquid.AutoSize = True
        Me.chkLiquid.BackColor = System.Drawing.SystemColors.Control
        Me.chkLiquid.Checked = True
        Me.chkLiquid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLiquid.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLiquid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLiquid.Location = New System.Drawing.Point(12, 71)
        Me.chkLiquid.Name = "chkLiquid"
        Me.chkLiquid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLiquid.Size = New System.Drawing.Size(156, 16)
        Me.chkLiquid.TabIndex = 39
        Me.chkLiquid.Text = "考虑闪蒸时带走液滴的量"
        Me.chkLiquid.UseVisualStyleBackColor = False
        '
        'txtQ
        '
        Me.txtQ.AcceptsReturn = True
        Me.txtQ.BackColor = System.Drawing.SystemColors.Window
        Me.txtQ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQ.Location = New System.Drawing.Point(159, 17)
        Me.txtQ.MaxLength = 0
        Me.txtQ.Name = "txtQ"
        Me.txtQ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQ.Size = New System.Drawing.Size(100, 21)
        Me.txtQ.TabIndex = 38
        Me.txtQ.Text = "1.0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 12)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "物料泄漏量Q[kg/s]:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(77, 38)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(194, 21)
        Me.txtName.TabIndex = 38
        Me.txtName.Text = "液氨"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "物质名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLeakLiquidCP)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtLeakLiquidTC)
        Me.GroupBox2.Controls.Add(Me.table28)
        Me.GroupBox2.Controls.Add(Me.txtLeakLiquidH)
        Me.GroupBox2.Controls.Add(Me.text5)
        Me.GroupBox2.Location = New System.Drawing.Point(300, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 101)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物料物性"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdCalculateLeak)
        Me.GroupBox3.Controls.Add(Me.cmdSave)
        Me.GroupBox3.Controls.Add(Me.RichLeakResult)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 203)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(570, 127)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算结果"
        '
        'CheckIsSaved
        '
        Me.CheckIsSaved.AutoSize = True
        Me.CheckIsSaved.Location = New System.Drawing.Point(347, 178)
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
        'frmLeakFlash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 368)
        Me.Controls.Add(Me.CheckIsSaved)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SaveSign)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FileName)
        Me.Controls.Add(Me.Command1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeakFlash"
        Me.Text = "闪蒸估算"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents SaveSign As System.Windows.Forms.TextBox
    Public WithEvents FileName As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents cmdCalculateLeak As System.Windows.Forms.Button
    Public WithEvents RichLeakResult As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidCP As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidTLG As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidTC As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidH As System.Windows.Forms.TextBox
    Public WithEvents text5 As System.Windows.Forms.Label
    Public WithEvents lable28 As System.Windows.Forms.Label
    Public WithEvents table28 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents chkLiquid As System.Windows.Forms.CheckBox
    Public WithEvents txtQ As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckIsSaved As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
