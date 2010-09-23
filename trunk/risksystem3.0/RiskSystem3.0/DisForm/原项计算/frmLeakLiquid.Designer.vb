<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakLiquid
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
        Me.FileName = New System.Windows.Forms.TextBox
        Me.SaveSign = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.frame2 = New System.Windows.Forms.GroupBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCalculateLeak = New System.Windows.Forms.Button
        Me.RichLeakResult = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.chkEvaporation = New System.Windows.Forms.CheckBox
        Me.txtLeakLiquidHeight = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidCd = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidA = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidP0 = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidP = New System.Windows.Forms.TextBox
        Me.chkHeight = New System.Windows.Forms.CheckBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtLeakLiquidPl = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.chkLiquid = New System.Windows.Forms.CheckBox
        Me.txtLeakLiquidH = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidCP = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidTC = New System.Windows.Forms.TextBox
        Me.txtLeakLiquidTLG = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.text5 = New System.Windows.Forms.Label
        Me.table28 = New System.Windows.Forms.Label
        Me.lable28 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckIsSaved = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.frame2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FileName
        '
        Me.FileName.AcceptsReturn = True
        Me.FileName.BackColor = System.Drawing.SystemColors.Window
        Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FileName.Location = New System.Drawing.Point(224, 215)
        Me.FileName.MaxLength = 0
        Me.FileName.Name = "FileName"
        Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileName.Size = New System.Drawing.Size(61, 21)
        Me.FileName.TabIndex = 48
        Me.FileName.Visible = False
        '
        'SaveSign
        '
        Me.SaveSign.AcceptsReturn = True
        Me.SaveSign.BackColor = System.Drawing.SystemColors.Window
        Me.SaveSign.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaveSign.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SaveSign.Location = New System.Drawing.Point(167, 215)
        Me.SaveSign.MaxLength = 0
        Me.SaveSign.Name = "SaveSign"
        Me.SaveSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SaveSign.Size = New System.Drawing.Size(41, 21)
        Me.SaveSign.TabIndex = 47
        Me.SaveSign.Text = "LeakLiquid"
        Me.SaveSign.Visible = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(12, 212)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(149, 25)
        Me.Command1.TabIndex = 46
        Me.Command1.Text = "从数据库中查找物化数据"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'frame2
        '
        Me.frame2.BackColor = System.Drawing.SystemColors.Control
        Me.frame2.Controls.Add(Me.cmdSave)
        Me.frame2.Controls.Add(Me.cmdCalculateLeak)
        Me.frame2.Controls.Add(Me.RichLeakResult)
        Me.frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frame2.Location = New System.Drawing.Point(12, 253)
        Me.frame2.Name = "frame2"
        Me.frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frame2.Size = New System.Drawing.Size(562, 101)
        Me.frame2.TabIndex = 45
        Me.frame2.TabStop = False
        Me.frame2.Text = "计算结果"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(24, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 25)
        Me.cmdSave.TabIndex = 38
        Me.cmdSave.Text = "保存(&S)"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCalculateLeak
        '
        Me.cmdCalculateLeak.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculateLeak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculateLeak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculateLeak.Location = New System.Drawing.Point(24, 20)
        Me.cmdCalculateLeak.Name = "cmdCalculateLeak"
        Me.cmdCalculateLeak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculateLeak.Size = New System.Drawing.Size(89, 25)
        Me.cmdCalculateLeak.TabIndex = 37
        Me.cmdCalculateLeak.Text = "计算(&C)"
        Me.cmdCalculateLeak.UseVisualStyleBackColor = True
        '
        'RichLeakResult
        '
        Me.RichLeakResult.AcceptsReturn = True
        Me.RichLeakResult.BackColor = System.Drawing.SystemColors.Window
        Me.RichLeakResult.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichLeakResult.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RichLeakResult.Location = New System.Drawing.Point(119, 20)
        Me.RichLeakResult.MaxLength = 0
        Me.RichLeakResult.Multiline = True
        Me.RichLeakResult.Name = "RichLeakResult"
        Me.RichLeakResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RichLeakResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RichLeakResult.Size = New System.Drawing.Size(425, 71)
        Me.RichLeakResult.TabIndex = 36
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(77, 12)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(161, 21)
        Me.txtName.TabIndex = 44
        Me.txtName.Text = "液氨"
        '
        'chkEvaporation
        '
        Me.chkEvaporation.AutoSize = True
        Me.chkEvaporation.BackColor = System.Drawing.SystemColors.Control
        Me.chkEvaporation.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEvaporation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEvaporation.Location = New System.Drawing.Point(5, 0)
        Me.chkEvaporation.Name = "chkEvaporation"
        Me.chkEvaporation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEvaporation.Size = New System.Drawing.Size(108, 16)
        Me.chkEvaporation.TabIndex = 41
        Me.chkEvaporation.Text = "计算液体蒸发量"
        Me.chkEvaporation.UseVisualStyleBackColor = False
        '
        'txtLeakLiquidHeight
        '
        Me.txtLeakLiquidHeight.AcceptsReturn = True
        Me.txtLeakLiquidHeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidHeight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidHeight.Enabled = False
        Me.txtLeakLiquidHeight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakLiquidHeight.Location = New System.Drawing.Point(145, 132)
        Me.txtLeakLiquidHeight.MaxLength = 0
        Me.txtLeakLiquidHeight.Name = "txtLeakLiquidHeight"
        Me.txtLeakLiquidHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidHeight.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakLiquidHeight.TabIndex = 12
        Me.txtLeakLiquidHeight.Text = "5"
        '
        'txtLeakLiquidCd
        '
        Me.txtLeakLiquidCd.AcceptsReturn = True
        Me.txtLeakLiquidCd.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidCd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidCd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakLiquidCd.Location = New System.Drawing.Point(145, 83)
        Me.txtLeakLiquidCd.MaxLength = 0
        Me.txtLeakLiquidCd.Name = "txtLeakLiquidCd"
        Me.txtLeakLiquidCd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidCd.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakLiquidCd.TabIndex = 11
        Me.txtLeakLiquidCd.Text = "0.62"
        '
        'txtLeakLiquidA
        '
        Me.txtLeakLiquidA.AcceptsReturn = True
        Me.txtLeakLiquidA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakLiquidA.Location = New System.Drawing.Point(145, 62)
        Me.txtLeakLiquidA.MaxLength = 0
        Me.txtLeakLiquidA.Name = "txtLeakLiquidA"
        Me.txtLeakLiquidA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidA.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakLiquidA.TabIndex = 10
        Me.txtLeakLiquidA.Text = "0.0000785"
        '
        'txtLeakLiquidP0
        '
        Me.txtLeakLiquidP0.AcceptsReturn = True
        Me.txtLeakLiquidP0.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidP0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidP0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakLiquidP0.Location = New System.Drawing.Point(145, 41)
        Me.txtLeakLiquidP0.MaxLength = 0
        Me.txtLeakLiquidP0.Name = "txtLeakLiquidP0"
        Me.txtLeakLiquidP0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidP0.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakLiquidP0.TabIndex = 9
        Me.txtLeakLiquidP0.Text = "101325"
        '
        'txtLeakLiquidP
        '
        Me.txtLeakLiquidP.AcceptsReturn = True
        Me.txtLeakLiquidP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidP.Location = New System.Drawing.Point(145, 20)
        Me.txtLeakLiquidP.MaxLength = 0
        Me.txtLeakLiquidP.Name = "txtLeakLiquidP"
        Me.txtLeakLiquidP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidP.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakLiquidP.TabIndex = 8
        Me.txtLeakLiquidP.Text = "1170000"
        '
        'chkHeight
        '
        Me.chkHeight.AutoSize = True
        Me.chkHeight.BackColor = System.Drawing.SystemColors.Control
        Me.chkHeight.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkHeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkHeight.Location = New System.Drawing.Point(10, 110)
        Me.chkHeight.Name = "chkHeight"
        Me.chkHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkHeight.Size = New System.Drawing.Size(156, 16)
        Me.chkHeight.TabIndex = 7
        Me.chkHeight.Text = "考虑液位高度产生的压力"
        Me.chkHeight.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(8, 133)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(131, 12)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "裂口之上液位高度h[m]:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(44, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(95, 12)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "环境压力P0[Pa]:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(32, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(107, 12)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "容器内压力 P[Pa]:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(44, 65)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(95, 12)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "裂口面积A[m^2]:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(32, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(107, 12)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "液体泄漏系数  Cd:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLeakLiquidPl
        '
        Me.txtLeakLiquidPl.AcceptsReturn = True
        Me.txtLeakLiquidPl.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidPl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidPl.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidPl.Location = New System.Drawing.Point(179, 20)
        Me.txtLeakLiquidPl.MaxLength = 0
        Me.txtLeakLiquidPl.Name = "txtLeakLiquidPl"
        Me.txtLeakLiquidPl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidPl.Size = New System.Drawing.Size(73, 21)
        Me.txtLeakLiquidPl.TabIndex = 19
        Me.txtLeakLiquidPl.Text = "1070"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(24, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(149, 12)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "泄漏液体密度ρl[kg/m^3]:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkLiquid
        '
        Me.chkLiquid.AutoSize = True
        Me.chkLiquid.BackColor = System.Drawing.SystemColors.Control
        Me.chkLiquid.Checked = True
        Me.chkLiquid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLiquid.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLiquid.Enabled = False
        Me.chkLiquid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLiquid.Location = New System.Drawing.Point(14, 22)
        Me.chkLiquid.Name = "chkLiquid"
        Me.chkLiquid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLiquid.Size = New System.Drawing.Size(156, 16)
        Me.chkLiquid.TabIndex = 29
        Me.chkLiquid.Text = "考虑闪蒸时带走液滴的量"
        Me.chkLiquid.UseVisualStyleBackColor = False
        '
        'txtLeakLiquidH
        '
        Me.txtLeakLiquidH.AcceptsReturn = True
        Me.txtLeakLiquidH.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidH.Enabled = False
        Me.txtLeakLiquidH.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidH.Location = New System.Drawing.Point(179, 101)
        Me.txtLeakLiquidH.MaxLength = 0
        Me.txtLeakLiquidH.Name = "txtLeakLiquidH"
        Me.txtLeakLiquidH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidH.Size = New System.Drawing.Size(73, 21)
        Me.txtLeakLiquidH.TabIndex = 26
        Me.txtLeakLiquidH.Text = "1367"
        '
        'txtLeakLiquidCP
        '
        Me.txtLeakLiquidCP.AcceptsReturn = True
        Me.txtLeakLiquidCP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidCP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidCP.Enabled = False
        Me.txtLeakLiquidCP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidCP.Location = New System.Drawing.Point(179, 80)
        Me.txtLeakLiquidCP.MaxLength = 0
        Me.txtLeakLiquidCP.Name = "txtLeakLiquidCP"
        Me.txtLeakLiquidCP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidCP.Size = New System.Drawing.Size(73, 21)
        Me.txtLeakLiquidCP.TabIndex = 30
        Me.txtLeakLiquidCP.Text = "4.6"
        '
        'txtLeakLiquidTC
        '
        Me.txtLeakLiquidTC.AcceptsReturn = True
        Me.txtLeakLiquidTC.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidTC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidTC.Enabled = False
        Me.txtLeakLiquidTC.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidTC.Location = New System.Drawing.Point(179, 59)
        Me.txtLeakLiquidTC.MaxLength = 0
        Me.txtLeakLiquidTC.Name = "txtLeakLiquidTC"
        Me.txtLeakLiquidTC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidTC.Size = New System.Drawing.Size(73, 21)
        Me.txtLeakLiquidTC.TabIndex = 27
        Me.txtLeakLiquidTC.Text = "-33"
        '
        'txtLeakLiquidTLG
        '
        Me.txtLeakLiquidTLG.AcceptsReturn = True
        Me.txtLeakLiquidTLG.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakLiquidTLG.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakLiquidTLG.Enabled = False
        Me.txtLeakLiquidTLG.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidTLG.Location = New System.Drawing.Point(179, 38)
        Me.txtLeakLiquidTLG.MaxLength = 0
        Me.txtLeakLiquidTLG.Name = "txtLeakLiquidTLG"
        Me.txtLeakLiquidTLG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakLiquidTLG.Size = New System.Drawing.Size(73, 21)
        Me.txtLeakLiquidTLG.TabIndex = 28
        Me.txtLeakLiquidTLG.Text = "30"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(48, 104)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(125, 12)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "液体的气化热H[J/kg]:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'text5
        '
        Me.text5.AutoSize = True
        Me.text5.BackColor = System.Drawing.SystemColors.Control
        Me.text5.Cursor = System.Windows.Forms.Cursors.Default
        Me.text5.ForeColor = System.Drawing.Color.Blue
        Me.text5.Location = New System.Drawing.Point(12, 83)
        Me.text5.Name = "text5"
        Me.text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.text5.Size = New System.Drawing.Size(161, 12)
        Me.text5.TabIndex = 31
        Me.text5.Text = "液体定压比热CP[J/(kg·K)]:"
        Me.text5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'table28
        '
        Me.table28.AutoSize = True
        Me.table28.BackColor = System.Drawing.SystemColors.Control
        Me.table28.Cursor = System.Windows.Forms.Cursors.Default
        Me.table28.ForeColor = System.Drawing.Color.Blue
        Me.table28.Location = New System.Drawing.Point(18, 62)
        Me.table28.Name = "table28"
        Me.table28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.table28.Size = New System.Drawing.Size(155, 12)
        Me.table28.TabIndex = 33
        Me.table28.Text = "液体在常压下的沸点Tb[℃]:"
        Me.table28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lable28
        '
        Me.lable28.AutoSize = True
        Me.lable28.BackColor = System.Drawing.SystemColors.Control
        Me.lable28.Cursor = System.Windows.Forms.Cursors.Default
        Me.lable28.ForeColor = System.Drawing.Color.Blue
        Me.lable28.Location = New System.Drawing.Point(30, 41)
        Me.lable28.Name = "lable28"
        Me.lable28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lable28.Size = New System.Drawing.Size(143, 12)
        Me.lable28.TabIndex = 32
        Me.lable28.Text = "泄漏前液体的温度TL[℃]:"
        Me.lable28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "物质名称:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidHeight)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidCd)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidA)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidP0)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidP)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.chkHeight)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 167)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "泄漏参数"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLeakLiquidPl)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Location = New System.Drawing.Point(301, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(273, 50)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "泄漏液体密度"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkLiquid)
        Me.GroupBox3.Controls.Add(Me.txtLeakLiquidH)
        Me.GroupBox3.Controls.Add(Me.lable28)
        Me.GroupBox3.Controls.Add(Me.txtLeakLiquidCP)
        Me.GroupBox3.Controls.Add(Me.table28)
        Me.GroupBox3.Controls.Add(Me.txtLeakLiquidTC)
        Me.GroupBox3.Controls.Add(Me.text5)
        Me.GroupBox3.Controls.Add(Me.txtLeakLiquidTLG)
        Me.GroupBox3.Controls.Add(Me.chkEvaporation)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Location = New System.Drawing.Point(301, 95)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(273, 152)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算液体蒸发量"
        '
        'CheckIsSaved
        '
        Me.CheckIsSaved.AutoSize = True
        Me.CheckIsSaved.Location = New System.Drawing.Point(189, 242)
        Me.CheckIsSaved.Name = "CheckIsSaved"
        Me.CheckIsSaved.Size = New System.Drawing.Size(96, 16)
        Me.CheckIsSaved.TabIndex = 52
        Me.CheckIsSaved.Text = "CheckIsSaved"
        Me.CheckIsSaved.UseVisualStyleBackColor = True
        Me.CheckIsSaved.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmLeakLiquid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 366)
        Me.Controls.Add(Me.CheckIsSaved)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FileName)
        Me.Controls.Add(Me.SaveSign)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.frame2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeakLiquid"
        Me.Text = "液体泄漏量估算"
        Me.frame2.ResumeLayout(False)
        Me.frame2.PerformLayout()
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
    Public WithEvents FileName As System.Windows.Forms.TextBox
    Public WithEvents SaveSign As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents frame2 As System.Windows.Forms.GroupBox
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents chkEvaporation As System.Windows.Forms.CheckBox
    Public WithEvents txtLeakLiquidHeight As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidCd As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidA As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidP0 As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidP As System.Windows.Forms.TextBox
    Public WithEvents chkHeight As System.Windows.Forms.CheckBox
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents txtLeakLiquidPl As System.Windows.Forms.TextBox
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents chkLiquid As System.Windows.Forms.CheckBox
    Public WithEvents txtLeakLiquidH As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidCP As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidTC As System.Windows.Forms.TextBox
    Public WithEvents txtLeakLiquidTLG As System.Windows.Forms.TextBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents text5 As System.Windows.Forms.Label
    Public WithEvents table28 As System.Windows.Forms.Label
    Public WithEvents lable28 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents cmdCalculateLeak As System.Windows.Forms.Button
    Public WithEvents RichLeakResult As System.Windows.Forms.TextBox
    Friend WithEvents CheckIsSaved As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
