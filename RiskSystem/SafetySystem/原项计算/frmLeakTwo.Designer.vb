<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakTwo
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
        Me.Command１ = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtLeakTwoCd = New System.Windows.Forms.TextBox
        Me.txtLeakTwoA = New System.Windows.Forms.TextBox
        Me.txtLeakTwoPC = New System.Windows.Forms.TextBox
        Me.txtLeakTwoTLG = New System.Windows.Forms.TextBox
        Me.txtLeakTwoP = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtLeakTwoPg = New System.Windows.Forms.TextBox
        Me.txtLeakTwoPl = New System.Windows.Forms.TextBox
        Me.txtLeakTwoCP = New System.Windows.Forms.TextBox
        Me.txtLeakTwoTC = New System.Windows.Forms.TextBox
        Me.txtLeakTwoH = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.RichLeakResult = New System.Windows.Forms.TextBox
        Me.cmdCalculateLeak = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CheckIsSaved = New System.Windows.Forms.CheckBox
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
        Me.FileName.Location = New System.Drawing.Point(432, 10)
        Me.FileName.MaxLength = 0
        Me.FileName.Name = "FileName"
        Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileName.Size = New System.Drawing.Size(61, 21)
        Me.FileName.TabIndex = 41
        Me.FileName.Visible = False
        '
        'SaveSign
        '
        Me.SaveSign.AcceptsReturn = True
        Me.SaveSign.BackColor = System.Drawing.SystemColors.Window
        Me.SaveSign.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaveSign.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SaveSign.Location = New System.Drawing.Point(368, 10)
        Me.SaveSign.MaxLength = 0
        Me.SaveSign.Name = "SaveSign"
        Me.SaveSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SaveSign.Size = New System.Drawing.Size(41, 21)
        Me.SaveSign.TabIndex = 40
        Me.SaveSign.Text = "LeakTwo"
        Me.SaveSign.Visible = False
        '
        'Command１
        '
        Me.Command１.BackColor = System.Drawing.SystemColors.Control
        Me.Command１.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command１.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command１.Location = New System.Drawing.Point(12, 210)
        Me.Command１.Name = "Command１"
        Me.Command１.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command１.Size = New System.Drawing.Size(149, 25)
        Me.Command１.TabIndex = 39
        Me.Command１.Text = "从数据库中查找物化数据"
        Me.Command１.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(92, 16)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(165, 21)
        Me.txtName.TabIndex = 36
        Me.txtName.Text = "液氨"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(27, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "物质名称:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLeakTwoCd)
        Me.GroupBox1.Controls.Add(Me.txtLeakTwoA)
        Me.GroupBox1.Controls.Add(Me.txtLeakTwoPC)
        Me.GroupBox1.Controls.Add(Me.txtLeakTwoTLG)
        Me.GroupBox1.Controls.Add(Me.txtLeakTwoP)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 158)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "泄漏参数"
        '
        'txtLeakTwoCd
        '
        Me.txtLeakTwoCd.AcceptsReturn = True
        Me.txtLeakTwoCd.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoCd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoCd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakTwoCd.Location = New System.Drawing.Point(145, 101)
        Me.txtLeakTwoCd.MaxLength = 0
        Me.txtLeakTwoCd.Name = "txtLeakTwoCd"
        Me.txtLeakTwoCd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoCd.Size = New System.Drawing.Size(97, 21)
        Me.txtLeakTwoCd.TabIndex = 16
        Me.txtLeakTwoCd.Text = "0.8"
        '
        'txtLeakTwoA
        '
        Me.txtLeakTwoA.AcceptsReturn = True
        Me.txtLeakTwoA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakTwoA.Location = New System.Drawing.Point(145, 74)
        Me.txtLeakTwoA.MaxLength = 0
        Me.txtLeakTwoA.Name = "txtLeakTwoA"
        Me.txtLeakTwoA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoA.Size = New System.Drawing.Size(97, 21)
        Me.txtLeakTwoA.TabIndex = 15
        Me.txtLeakTwoA.Text = "0.0000785"
        '
        'txtLeakTwoPC
        '
        Me.txtLeakTwoPC.AcceptsReturn = True
        Me.txtLeakTwoPC.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoPC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoPC.Enabled = False
        Me.txtLeakTwoPC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakTwoPC.Location = New System.Drawing.Point(145, 47)
        Me.txtLeakTwoPC.MaxLength = 0
        Me.txtLeakTwoPC.Name = "txtLeakTwoPC"
        Me.txtLeakTwoPC.ReadOnly = True
        Me.txtLeakTwoPC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoPC.Size = New System.Drawing.Size(97, 21)
        Me.txtLeakTwoPC.TabIndex = 14
        Me.txtLeakTwoPC.Text = "643500"
        '
        'txtLeakTwoTLG
        '
        Me.txtLeakTwoTLG.AcceptsReturn = True
        Me.txtLeakTwoTLG.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoTLG.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoTLG.ForeColor = System.Drawing.Color.Black
        Me.txtLeakTwoTLG.Location = New System.Drawing.Point(145, 128)
        Me.txtLeakTwoTLG.MaxLength = 0
        Me.txtLeakTwoTLG.Name = "txtLeakTwoTLG"
        Me.txtLeakTwoTLG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoTLG.Size = New System.Drawing.Size(97, 21)
        Me.txtLeakTwoTLG.TabIndex = 28
        Me.txtLeakTwoTLG.Text = "30"
        '
        'txtLeakTwoP
        '
        Me.txtLeakTwoP.AcceptsReturn = True
        Me.txtLeakTwoP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakTwoP.Location = New System.Drawing.Point(145, 20)
        Me.txtLeakTwoP.MaxLength = 0
        Me.txtLeakTwoP.Name = "txtLeakTwoP"
        Me.txtLeakTwoP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoP.Size = New System.Drawing.Size(97, 21)
        Me.txtLeakTwoP.TabIndex = 13
        Me.txtLeakTwoP.Text = "1170000"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(32, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(107, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "两相流泄漏系数Cd:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(44, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(95, 12)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "临界压力PC[Pa]:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(50, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(89, 12)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "容器压力P[Pa]:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(44, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(95, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "裂口面积A[m^2]:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(2, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(137, 12)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "两相混合物温度TLG[℃]:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLeakTwoPg)
        Me.GroupBox2.Controls.Add(Me.txtLeakTwoPl)
        Me.GroupBox2.Controls.Add(Me.txtLeakTwoCP)
        Me.GroupBox2.Controls.Add(Me.txtLeakTwoTC)
        Me.GroupBox2.Controls.Add(Me.txtLeakTwoH)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(293, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(287, 158)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物料物性"
        '
        'txtLeakTwoPg
        '
        Me.txtLeakTwoPg.AcceptsReturn = True
        Me.txtLeakTwoPg.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoPg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoPg.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakTwoPg.Location = New System.Drawing.Point(186, 47)
        Me.txtLeakTwoPg.MaxLength = 0
        Me.txtLeakTwoPg.Name = "txtLeakTwoPg"
        Me.txtLeakTwoPg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoPg.Size = New System.Drawing.Size(90, 21)
        Me.txtLeakTwoPg.TabIndex = 31
        Me.txtLeakTwoPg.Text = "5.48"
        '
        'txtLeakTwoPl
        '
        Me.txtLeakTwoPl.AcceptsReturn = True
        Me.txtLeakTwoPl.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoPl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoPl.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakTwoPl.Location = New System.Drawing.Point(186, 20)
        Me.txtLeakTwoPl.MaxLength = 0
        Me.txtLeakTwoPl.Name = "txtLeakTwoPl"
        Me.txtLeakTwoPl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoPl.Size = New System.Drawing.Size(90, 21)
        Me.txtLeakTwoPl.TabIndex = 30
        Me.txtLeakTwoPl.Text = "1070"
        '
        'txtLeakTwoCP
        '
        Me.txtLeakTwoCP.AcceptsReturn = True
        Me.txtLeakTwoCP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoCP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoCP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakTwoCP.Location = New System.Drawing.Point(186, 128)
        Me.txtLeakTwoCP.MaxLength = 0
        Me.txtLeakTwoCP.Name = "txtLeakTwoCP"
        Me.txtLeakTwoCP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoCP.Size = New System.Drawing.Size(90, 21)
        Me.txtLeakTwoCP.TabIndex = 29
        Me.txtLeakTwoCP.Text = "4.6"
        '
        'txtLeakTwoTC
        '
        Me.txtLeakTwoTC.AcceptsReturn = True
        Me.txtLeakTwoTC.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoTC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoTC.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakTwoTC.Location = New System.Drawing.Point(186, 74)
        Me.txtLeakTwoTC.MaxLength = 0
        Me.txtLeakTwoTC.Name = "txtLeakTwoTC"
        Me.txtLeakTwoTC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoTC.Size = New System.Drawing.Size(90, 21)
        Me.txtLeakTwoTC.TabIndex = 27
        Me.txtLeakTwoTC.Text = "-33"
        '
        'txtLeakTwoH
        '
        Me.txtLeakTwoH.AcceptsReturn = True
        Me.txtLeakTwoH.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakTwoH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakTwoH.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakTwoH.Location = New System.Drawing.Point(186, 101)
        Me.txtLeakTwoH.MaxLength = 0
        Me.txtLeakTwoH.Name = "txtLeakTwoH"
        Me.txtLeakTwoH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakTwoH.Size = New System.Drawing.Size(90, 21)
        Me.txtLeakTwoH.TabIndex = 26
        Me.txtLeakTwoH.Text = "1367"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(55, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(125, 12)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "蒸气密度ρg[kg/m^3]:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(55, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(125, 12)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "液体密度ρl[kg/m^3]:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(161, 12)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "液体定压比热CP[J/(kg·K)]:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(37, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(143, 12)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "临界压力下的沸点TC[℃]:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(55, 104)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(125, 12)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "液体的气化热H[J/kg]:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdSave)
        Me.GroupBox3.Controls.Add(Me.RichLeakResult)
        Me.GroupBox3.Controls.Add(Me.cmdCalculateLeak)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 113)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算结果"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(34, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 25)
        Me.cmdSave.TabIndex = 33
        Me.cmdSave.Text = "保存(&S)"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'RichLeakResult
        '
        Me.RichLeakResult.AcceptsReturn = True
        Me.RichLeakResult.BackColor = System.Drawing.SystemColors.Window
        Me.RichLeakResult.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichLeakResult.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RichLeakResult.Location = New System.Drawing.Point(131, 20)
        Me.RichLeakResult.MaxLength = 0
        Me.RichLeakResult.Multiline = True
        Me.RichLeakResult.Name = "RichLeakResult"
        Me.RichLeakResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RichLeakResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RichLeakResult.Size = New System.Drawing.Size(409, 77)
        Me.RichLeakResult.TabIndex = 32
        '
        'cmdCalculateLeak
        '
        Me.cmdCalculateLeak.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculateLeak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculateLeak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculateLeak.Location = New System.Drawing.Point(34, 20)
        Me.cmdCalculateLeak.Name = "cmdCalculateLeak"
        Me.cmdCalculateLeak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculateLeak.Size = New System.Drawing.Size(89, 25)
        Me.cmdCalculateLeak.TabIndex = 31
        Me.cmdCalculateLeak.Text = "计算(&C)"
        Me.cmdCalculateLeak.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CheckIsSaved
        '
        Me.CheckIsSaved.AutoSize = True
        Me.CheckIsSaved.Location = New System.Drawing.Point(499, 12)
        Me.CheckIsSaved.Name = "CheckIsSaved"
        Me.CheckIsSaved.Size = New System.Drawing.Size(96, 16)
        Me.CheckIsSaved.TabIndex = 45
        Me.CheckIsSaved.Text = "CheckIsSaved"
        Me.CheckIsSaved.UseVisualStyleBackColor = True
        Me.CheckIsSaved.Visible = False
        '
        'frmLeakTwo
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
        Me.Controls.Add(Me.Command１)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeakTwo"
        Me.RightToLeftLayout = True
        Me.Text = "两相流泄漏量估算"
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
    Public WithEvents Command１ As System.Windows.Forms.Button
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtLeakTwoCd As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoA As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoPC As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoP As System.Windows.Forms.TextBox
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents txtLeakTwoPg As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoPl As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoCP As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoTLG As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoTC As System.Windows.Forms.TextBox
    Public WithEvents txtLeakTwoH As System.Windows.Forms.TextBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents RichLeakResult As System.Windows.Forms.TextBox
    Public WithEvents cmdCalculateLeak As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents CheckIsSaved As System.Windows.Forms.CheckBox
End Class
