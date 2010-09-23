<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPoolFire
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPoolFire))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me._Box_0 = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtX = New Chart.CText
        Me.txtY = New Chart.CText
        Me.txtLeakSourceName = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ctxtHc = New Chart.CText
        Me.ctxtHv = New Chart.CText
        Me.ctxtCp = New Chart.CText
        Me.ctxtTb = New Chart.CText
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ctxtD = New Chart.CText
        Me.ctxtTime = New Chart.CText
        Me.ctxtTa = New Chart.CText
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ctxtW = New Chart.CText
        Me.cmdSeachData = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me._Box_1 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.ctxtLong = New Chart.CText
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ctxtCount = New Chart.CText
        Me.GroupBoxForecastPoint = New System.Windows.Forms.GroupBox
        Me.txtMaxY = New Chart.CText
        Me.txtMinY = New Chart.CText
        Me.txtMaxX = New Chart.CText
        Me.txtMinX = New Chart.CText
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.EFlexHeatRadiate = New Chart.EFlex
        Me.cmdDamageAdd = New System.Windows.Forms.Button
        Me.cmdDamageDelete = New System.Windows.Forms.Button
        Me.groupbox = New System.Windows.Forms.GroupBox
        Me.EFlexDistance = New Chart.EFlex
        Me.cmdForcastAdd = New System.Windows.Forms.Button
        Me.cmdForecastDelete = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me._Box_2 = New System.Windows.Forms.Panel
        Me.ctxtF = New Chart.CText
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me._Box_0.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me._Box_1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBoxForecastPoint.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EFlexHeatRadiate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupbox.SuspendLayout()
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me._Box_2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(651, 370)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me._Box_0)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(643, 345)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "事故源"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '_Box_0
        '
        Me._Box_0.BackColor = System.Drawing.Color.Transparent
        Me._Box_0.Controls.Add(Me.GroupBox4)
        Me._Box_0.Controls.Add(Me.txtLeakSourceName)
        Me._Box_0.Controls.Add(Me.Label66)
        Me._Box_0.Controls.Add(Me.GroupBox2)
        Me._Box_0.Controls.Add(Me.GroupBox1)
        Me._Box_0.Controls.Add(Me.cmdSeachData)
        Me._Box_0.Controls.Add(Me.txtName)
        Me._Box_0.Controls.Add(Me.Label1)
        Me._Box_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Box_0.Dock = System.Windows.Forms.DockStyle.Fill
        Me._Box_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Box_0.Location = New System.Drawing.Point(3, 3)
        Me._Box_0.Name = "_Box_0"
        Me._Box_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Box_0.Size = New System.Drawing.Size(637, 339)
        Me._Box_0.TabIndex = 2
        Me._Box_0.TabStop = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtX)
        Me.GroupBox4.Controls.Add(Me.txtY)
        Me.GroupBox4.Location = New System.Drawing.Point(293, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 67)
        Me.GroupBox4.TabIndex = 71
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "事故源坐标"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(88, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Y[m]:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(88, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "X[m]:"
        '
        'txtX
        '
        Me.txtX.DataType = Chart.DataType.DataInteger
        Me.txtX.Location = New System.Drawing.Point(129, 12)
        Me.txtX.MaxValue = 0
        Me.txtX.MinValue = 0
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(100, 21)
        Me.txtX.TabIndex = 0
        Me.txtX.Text = "0"
        Me.txtX.Value = 0
        '
        'txtY
        '
        Me.txtY.DataType = Chart.DataType.DataInteger
        Me.txtY.Location = New System.Drawing.Point(129, 39)
        Me.txtY.MaxValue = 0
        Me.txtY.MinValue = 0
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(100, 21)
        Me.txtY.TabIndex = 1
        Me.txtY.Text = "0"
        Me.txtY.Value = 0
        '
        'txtLeakSourceName
        '
        Me.txtLeakSourceName.AcceptsReturn = True
        Me.txtLeakSourceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakSourceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakSourceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakSourceName.Location = New System.Drawing.Point(135, 34)
        Me.txtLeakSourceName.MaxLength = 0
        Me.txtLeakSourceName.Name = "txtLeakSourceName"
        Me.txtLeakSourceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakSourceName.Size = New System.Drawing.Size(120, 21)
        Me.txtLeakSourceName.TabIndex = 68
        Me.txtLeakSourceName.Text = "苯储罐"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(58, 37)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(71, 12)
        Me.Label66.TabIndex = 69
        Me.Label66.Text = "事故源名称:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ctxtHc)
        Me.GroupBox2.Controls.Add(Me.ctxtHv)
        Me.GroupBox2.Controls.Add(Me.ctxtCp)
        Me.GroupBox2.Controls.Add(Me.ctxtTb)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(293, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 114)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物化性质"
        '
        'ctxtHc
        '
        Me.ctxtHc.DataType = Chart.DataType.DataDouble
        Me.ctxtHc.Location = New System.Drawing.Point(196, 20)
        Me.ctxtHc.MaxValue = 0
        Me.ctxtHc.MinValue = 0
        Me.ctxtHc.Name = "ctxtHc"
        Me.ctxtHc.Size = New System.Drawing.Size(100, 21)
        Me.ctxtHc.TabIndex = 70
        Me.ctxtHc.Text = "0"
        Me.ctxtHc.Value = 0
        '
        'ctxtHv
        '
        Me.ctxtHv.DataType = Chart.DataType.DataDouble
        Me.ctxtHv.Location = New System.Drawing.Point(196, 41)
        Me.ctxtHv.MaxValue = 0
        Me.ctxtHv.MinValue = 0
        Me.ctxtHv.Name = "ctxtHv"
        Me.ctxtHv.Size = New System.Drawing.Size(100, 21)
        Me.ctxtHv.TabIndex = 71
        Me.ctxtHv.Text = "0"
        Me.ctxtHv.Value = 0
        '
        'ctxtCp
        '
        Me.ctxtCp.DataType = Chart.DataType.DataDouble
        Me.ctxtCp.Location = New System.Drawing.Point(196, 62)
        Me.ctxtCp.MaxValue = 0
        Me.ctxtCp.MinValue = 0
        Me.ctxtCp.Name = "ctxtCp"
        Me.ctxtCp.Size = New System.Drawing.Size(100, 21)
        Me.ctxtCp.TabIndex = 72
        Me.ctxtCp.Text = "0"
        Me.ctxtCp.Value = 0
        '
        'ctxtTb
        '
        Me.ctxtTb.DataType = Chart.DataType.DataDouble
        Me.ctxtTb.Location = New System.Drawing.Point(196, 83)
        Me.ctxtTb.MaxValue = 0
        Me.ctxtTb.MinValue = 0
        Me.ctxtTb.Name = "ctxtTb"
        Me.ctxtTb.Size = New System.Drawing.Size(100, 21)
        Me.ctxtTb.TabIndex = 73
        Me.ctxtTb.Text = "0"
        Me.ctxtTb.Value = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(59, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(131, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "液体的燃烧热Hc[J/kg]:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(35, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(155, 12)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "液体常压下的沸点Tb[ ℃ ]:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(17, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(173, 12)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "液体比定压热容Cp[J/(kg·K)]:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(23, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(167, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "常压沸点下的蒸发热Hv[J/kg]:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ctxtD)
        Me.GroupBox1.Controls.Add(Me.ctxtTime)
        Me.GroupBox1.Controls.Add(Me.ctxtTa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.ctxtW)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 114)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本属性"
        '
        'ctxtD
        '
        Me.ctxtD.DataType = Chart.DataType.DataDouble
        Me.ctxtD.Location = New System.Drawing.Point(135, 62)
        Me.ctxtD.MaxValue = 0
        Me.ctxtD.MinValue = 0
        Me.ctxtD.Name = "ctxtD"
        Me.ctxtD.Size = New System.Drawing.Size(100, 21)
        Me.ctxtD.TabIndex = 73
        Me.ctxtD.Text = "0"
        Me.ctxtD.Value = 0
        '
        'ctxtTime
        '
        Me.ctxtTime.DataType = Chart.DataType.DataDouble
        Me.ctxtTime.Location = New System.Drawing.Point(135, 83)
        Me.ctxtTime.MaxValue = 0
        Me.ctxtTime.MinValue = 0
        Me.ctxtTime.Name = "ctxtTime"
        Me.ctxtTime.Size = New System.Drawing.Size(100, 21)
        Me.ctxtTime.TabIndex = 72
        Me.ctxtTime.Text = "0"
        Me.ctxtTime.Value = 0
        '
        'ctxtTa
        '
        Me.ctxtTa.DataType = Chart.DataType.DataDouble
        Me.ctxtTa.Location = New System.Drawing.Point(135, 41)
        Me.ctxtTa.MaxValue = 0
        Me.ctxtTa.MinValue = 0
        Me.ctxtTa.Name = "ctxtTa"
        Me.ctxtTa.Size = New System.Drawing.Size(100, 21)
        Me.ctxtTa.TabIndex = 71
        Me.ctxtTa.Text = "0"
        Me.ctxtTa.Value = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "物质总质量W[ kg ]:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(34, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(95, 12)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "暴露时间t[ s ]:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(28, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(101, 12)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "液池直径D[  m ]:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(22, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(107, 12)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "环境温度Ta[ ℃ ]:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ctxtW
        '
        Me.ctxtW.DataType = Chart.DataType.DataDouble
        Me.ctxtW.Location = New System.Drawing.Point(135, 20)
        Me.ctxtW.MaxValue = 0
        Me.ctxtW.MinValue = 0
        Me.ctxtW.Name = "ctxtW"
        Me.ctxtW.Size = New System.Drawing.Size(100, 21)
        Me.ctxtW.TabIndex = 70
        Me.ctxtW.Text = "0"
        Me.ctxtW.Value = 0
        '
        'cmdSeachData
        '
        Me.cmdSeachData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeachData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSeachData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeachData.Location = New System.Drawing.Point(293, 213)
        Me.cmdSeachData.Name = "cmdSeachData"
        Me.cmdSeachData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSeachData.Size = New System.Drawing.Size(149, 25)
        Me.cmdSeachData.TabIndex = 62
        Me.cmdSeachData.Text = "从数据库中查找物化数据"
        Me.cmdSeachData.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(135, 55)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(120, 21)
        Me.txtName.TabIndex = 6
        Me.txtName.Text = "苯"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(70, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "物质名称:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me._Box_1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(643, 345)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "预测方案"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '_Box_1
        '
        Me._Box_1.BackColor = System.Drawing.Color.Transparent
        Me._Box_1.Controls.Add(Me.GroupBox5)
        Me._Box_1.Controls.Add(Me.GroupBoxForecastPoint)
        Me._Box_1.Controls.Add(Me.GroupBox3)
        Me._Box_1.Controls.Add(Me.groupbox)
        Me._Box_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Box_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me._Box_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Box_1.Location = New System.Drawing.Point(3, 3)
        Me._Box_1.Name = "_Box_1"
        Me._Box_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Box_1.Size = New System.Drawing.Size(637, 339)
        Me._Box_1.TabIndex = 3
        Me._Box_1.TabStop = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ctxtLong)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.ctxtCount)
        Me.GroupBox5.Location = New System.Drawing.Point(317, 255)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(311, 71)
        Me.GroupBox5.TabIndex = 270
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "距事故源中心的距离"
        '
        'ctxtLong
        '
        Me.ctxtLong.DataType = Chart.DataType.DataDouble
        Me.ctxtLong.Location = New System.Drawing.Point(81, 26)
        Me.ctxtLong.MaxValue = 0
        Me.ctxtLong.MinValue = 0
        Me.ctxtLong.Name = "ctxtLong"
        Me.ctxtLong.Size = New System.Drawing.Size(76, 21)
        Me.ctxtLong.TabIndex = 69
        Me.ctxtLong.Text = "0"
        Me.ctxtLong.Value = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "步长(m):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(174, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "个数:"
        '
        'ctxtCount
        '
        Me.ctxtCount.DataType = Chart.DataType.DataDouble
        Me.ctxtCount.Location = New System.Drawing.Point(215, 26)
        Me.ctxtCount.MaxValue = 0
        Me.ctxtCount.MinValue = 0
        Me.ctxtCount.Name = "ctxtCount"
        Me.ctxtCount.Size = New System.Drawing.Size(76, 21)
        Me.ctxtCount.TabIndex = 70
        Me.ctxtCount.Text = "0"
        Me.ctxtCount.Value = 0
        '
        'GroupBoxForecastPoint
        '
        Me.GroupBoxForecastPoint.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMaxY)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinY)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMaxX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label10)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label11)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label12)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label19)
        Me.GroupBoxForecastPoint.Location = New System.Drawing.Point(22, 255)
        Me.GroupBoxForecastPoint.Name = "GroupBoxForecastPoint"
        Me.GroupBoxForecastPoint.Size = New System.Drawing.Size(276, 72)
        Me.GroupBoxForecastPoint.TabIndex = 269
        Me.GroupBoxForecastPoint.TabStop = False
        Me.GroupBoxForecastPoint.Text = "坐标范围"
        '
        'txtMaxY
        '
        Me.txtMaxY.DataType = Chart.DataType.DataDouble
        Me.txtMaxY.Location = New System.Drawing.Point(166, 41)
        Me.txtMaxY.MaxValue = 0
        Me.txtMaxY.MinValue = 0
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.Size = New System.Drawing.Size(78, 21)
        Me.txtMaxY.TabIndex = 210
        Me.txtMaxY.Text = "0"
        Me.txtMaxY.Value = 0
        '
        'txtMinY
        '
        Me.txtMinY.DataType = Chart.DataType.DataDouble
        Me.txtMinY.Location = New System.Drawing.Point(59, 41)
        Me.txtMinY.MaxValue = 0
        Me.txtMinY.MinValue = 0
        Me.txtMinY.Name = "txtMinY"
        Me.txtMinY.Size = New System.Drawing.Size(78, 21)
        Me.txtMinY.TabIndex = 210
        Me.txtMinY.Text = "0"
        Me.txtMinY.Value = 0
        '
        'txtMaxX
        '
        Me.txtMaxX.DataType = Chart.DataType.DataDouble
        Me.txtMaxX.Location = New System.Drawing.Point(166, 20)
        Me.txtMaxX.MaxValue = 0
        Me.txtMaxX.MinValue = 0
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.Size = New System.Drawing.Size(78, 21)
        Me.txtMaxX.TabIndex = 209
        Me.txtMaxX.Text = "0"
        Me.txtMaxX.Value = 0
        '
        'txtMinX
        '
        Me.txtMinX.DataType = Chart.DataType.DataDouble
        Me.txtMinX.Location = New System.Drawing.Point(59, 20)
        Me.txtMinX.MaxValue = 0
        Me.txtMinX.MinValue = 0
        Me.txtMinX.Name = "txtMinX"
        Me.txtMinX.Size = New System.Drawing.Size(78, 21)
        Me.txtMinX.TabIndex = 209
        Me.txtMinX.Text = "0"
        Me.txtMinX.Value = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(47, 12)
        Me.Label10.TabIndex = 202
        Me.Label10.Text = "x轴[m]:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(149, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "-"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(149, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(11, 12)
        Me.Label12.TabIndex = 206
        Me.Label12.Text = "-"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(6, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(47, 12)
        Me.Label19.TabIndex = 206
        Me.Label19.Text = "y轴[m]:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.EFlexHeatRadiate)
        Me.GroupBox3.Controls.Add(Me.cmdDamageAdd)
        Me.GroupBox3.Controls.Add(Me.cmdDamageDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(317, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(311, 229)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算结果包含"
        '
        'EFlexHeatRadiate
        '
        Me.EFlexHeatRadiate.ColumnInfo = resources.GetString("EFlexHeatRadiate.ColumnInfo")
        Me.EFlexHeatRadiate.IsCopy = True
        Me.EFlexHeatRadiate.IsCut = True
        Me.EFlexHeatRadiate.IsPaste = True
        Me.EFlexHeatRadiate.Location = New System.Drawing.Point(16, 17)
        Me.EFlexHeatRadiate.Name = "EFlexHeatRadiate"
        Me.EFlexHeatRadiate.Rows.Count = 5
        Me.EFlexHeatRadiate.Rows.DefaultSize = 18
        Me.EFlexHeatRadiate.Size = New System.Drawing.Size(289, 177)
        Me.EFlexHeatRadiate.StyleInfo = resources.GetString("EFlexHeatRadiate.StyleInfo")
        Me.EFlexHeatRadiate.TabIndex = 71
        '
        'cmdDamageAdd
        '
        Me.cmdDamageAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageAdd.Location = New System.Drawing.Point(54, 200)
        Me.cmdDamageAdd.Name = "cmdDamageAdd"
        Me.cmdDamageAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDamageAdd.Size = New System.Drawing.Size(65, 23)
        Me.cmdDamageAdd.TabIndex = 41
        Me.cmdDamageAdd.Text = "增加(&A)"
        Me.cmdDamageAdd.UseVisualStyleBackColor = True
        '
        'cmdDamageDelete
        '
        Me.cmdDamageDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageDelete.Location = New System.Drawing.Point(158, 200)
        Me.cmdDamageDelete.Name = "cmdDamageDelete"
        Me.cmdDamageDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDamageDelete.Size = New System.Drawing.Size(65, 23)
        Me.cmdDamageDelete.TabIndex = 40
        Me.cmdDamageDelete.Text = "删除(&D)"
        Me.cmdDamageDelete.UseVisualStyleBackColor = True
        '
        'groupbox
        '
        Me.groupbox.Controls.Add(Me.EFlexDistance)
        Me.groupbox.Controls.Add(Me.cmdForcastAdd)
        Me.groupbox.Controls.Add(Me.cmdForecastDelete)
        Me.groupbox.Location = New System.Drawing.Point(22, 20)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(276, 229)
        Me.groupbox.TabIndex = 67
        Me.groupbox.TabStop = False
        Me.groupbox.Text = "预测点"
        '
        'EFlexDistance
        '
        Me.EFlexDistance.ColumnInfo = resources.GetString("EFlexDistance.ColumnInfo")
        Me.EFlexDistance.IsCopy = True
        Me.EFlexDistance.IsCut = True
        Me.EFlexDistance.IsPaste = True
        Me.EFlexDistance.Location = New System.Drawing.Point(12, 20)
        Me.EFlexDistance.Name = "EFlexDistance"
        Me.EFlexDistance.Rows.Count = 1
        Me.EFlexDistance.Rows.DefaultSize = 18
        Me.EFlexDistance.Size = New System.Drawing.Size(246, 174)
        Me.EFlexDistance.StyleInfo = resources.GetString("EFlexDistance.StyleInfo")
        Me.EFlexDistance.TabIndex = 71
        '
        'cmdForcastAdd
        '
        Me.cmdForcastAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdForcastAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdForcastAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdForcastAdd.Location = New System.Drawing.Point(42, 200)
        Me.cmdForcastAdd.Name = "cmdForcastAdd"
        Me.cmdForcastAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdForcastAdd.Size = New System.Drawing.Size(65, 23)
        Me.cmdForcastAdd.TabIndex = 31
        Me.cmdForcastAdd.Text = "增加(&A)"
        Me.cmdForcastAdd.UseVisualStyleBackColor = True
        '
        'cmdForecastDelete
        '
        Me.cmdForecastDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdForecastDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdForecastDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdForecastDelete.Location = New System.Drawing.Point(137, 200)
        Me.cmdForecastDelete.Name = "cmdForecastDelete"
        Me.cmdForecastDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdForecastDelete.Size = New System.Drawing.Size(65, 23)
        Me.cmdForecastDelete.TabIndex = 32
        Me.cmdForecastDelete.Text = "删除(&D)"
        Me.cmdForecastDelete.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me._Box_2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(643, 345)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "计算选项"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        '_Box_2
        '
        Me._Box_2.BackColor = System.Drawing.Color.Transparent
        Me._Box_2.Controls.Add(Me.ctxtF)
        Me._Box_2.Controls.Add(Me.Label17)
        Me._Box_2.Controls.Add(Me.Label13)
        Me._Box_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Box_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me._Box_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Box_2.Location = New System.Drawing.Point(3, 3)
        Me._Box_2.Name = "_Box_2"
        Me._Box_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Box_2.Size = New System.Drawing.Size(637, 339)
        Me._Box_2.TabIndex = 4
        Me._Box_2.TabStop = True
        '
        'ctxtF
        '
        Me.ctxtF.DataType = Chart.DataType.DataDouble
        Me.ctxtF.Location = New System.Drawing.Point(115, 60)
        Me.ctxtF.MaxValue = 0
        Me.ctxtF.MinValue = 0
        Me.ctxtF.Name = "ctxtF"
        Me.ctxtF.Size = New System.Drawing.Size(100, 21)
        Me.ctxtF.TabIndex = 50
        Me.ctxtF.Text = "0"
        Me.ctxtF.Value = 0
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(32, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(77, 17)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "热辐射系数f:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(32, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(241, 25)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "热辐射系数，范围为0.13～0.35，你可根据需要选取，保守取值为0.35。"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(444, 387)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "取消(&C)"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(348, 387)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "确定(&O)"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmPoolFire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 422)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPoolFire"
        Me.Text = "池火模型"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me._Box_0.ResumeLayout(False)
        Me._Box_0.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me._Box_1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBoxForecastPoint.ResumeLayout(False)
        Me.GroupBoxForecastPoint.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.EFlexHeatRadiate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupbox.ResumeLayout(False)
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me._Box_2.ResumeLayout(False)
        Me._Box_2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents _Box_0 As System.Windows.Forms.Panel
    Public WithEvents cmdSeachData As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Public WithEvents _Box_1 As System.Windows.Forms.Panel
    Public WithEvents cmdForecastDelete As System.Windows.Forms.Button
    Public WithEvents cmdForcastAdd As System.Windows.Forms.Button
    Public WithEvents _Box_2 As System.Windows.Forms.Panel
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents groupbox As System.Windows.Forms.GroupBox
    Public WithEvents txtLeakSourceName As System.Windows.Forms.TextBox
    Public WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents cmdDamageAdd As System.Windows.Forms.Button
    Public WithEvents cmdDamageDelete As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents EFlexHeatRadiate As Chart.EFlex
    Friend WithEvents ctxtHc As Chart.CText
    Friend WithEvents ctxtHv As Chart.CText
    Friend WithEvents ctxtCp As Chart.CText
    Friend WithEvents ctxtTb As Chart.CText
    Friend WithEvents ctxtD As Chart.CText
    Friend WithEvents ctxtTime As Chart.CText
    Friend WithEvents ctxtTa As Chart.CText
    Friend WithEvents ctxtW As Chart.CText
    Friend WithEvents ctxtF As Chart.CText
    Friend WithEvents ctxtCount As Chart.CText
    Friend WithEvents ctxtLong As Chart.CText
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EFlexDistance As Chart.EFlex
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtX As Chart.CText
    Friend WithEvents txtY As Chart.CText
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents GroupBoxForecastPoint As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As Chart.CText
    Friend WithEvents txtMinY As Chart.CText
    Friend WithEvents txtMaxX As Chart.CText
    Friend WithEvents txtMinX As Chart.CText
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
