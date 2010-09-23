<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBleve
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBleve))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me._Box_0 = New System.Windows.Forms.Panel
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtX = New Chart.CText
        Me.txtY = New Chart.CText
        Me.txtLeakSourceName = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ctxtHc = New Chart.CText
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ctxtWf = New Chart.CText
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdSeachData = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me._Box_1 = New System.Windows.Forms.Panel
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ctxtLong = New Chart.CText
        Me.Label5 = New System.Windows.Forms.Label
        Me.ctxtCount = New Chart.CText
        Me.GroupBoxForecastPoint = New System.Windows.Forms.GroupBox
        Me.txtMaxY = New Chart.CText
        Me.txtMinY = New Chart.CText
        Me.txtMaxX = New Chart.CText
        Me.txtMinX = New Chart.CText
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.ctxtPa = New Chart.CText
        Me.ctxtF = New Chart.CText
        Me.OptionF2 = New System.Windows.Forms.RadioButton
        Me.OptionF1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmbBleveRTModel = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkH = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me._Box_0.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me._Box_1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBoxForecastPoint.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EFlexHeatRadiate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupbox.SuspendLayout()
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me._Box_2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.TabControl1.TabIndex = 1
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
        Me._Box_0.Controls.Add(Me.GroupBox6)
        Me._Box_0.Controls.Add(Me.txtLeakSourceName)
        Me._Box_0.Controls.Add(Me.Label66)
        Me._Box_0.Controls.Add(Me.txtName)
        Me._Box_0.Controls.Add(Me.GroupBox2)
        Me._Box_0.Controls.Add(Me.GroupBox1)
        Me._Box_0.Controls.Add(Me.cmdSeachData)
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
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.txtX)
        Me.GroupBox6.Controls.Add(Me.txtY)
        Me.GroupBox6.Location = New System.Drawing.Point(298, 45)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(302, 67)
        Me.GroupBox6.TabIndex = 72
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "事故源坐标"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(88, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Y[m]:"
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
        Me.txtLeakSourceName.Location = New System.Drawing.Point(129, 57)
        Me.txtLeakSourceName.MaxLength = 0
        Me.txtLeakSourceName.Name = "txtLeakSourceName"
        Me.txtLeakSourceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakSourceName.Size = New System.Drawing.Size(118, 21)
        Me.txtLeakSourceName.TabIndex = 66
        Me.txtLeakSourceName.Text = "丁二烯储罐"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(52, 60)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(71, 12)
        Me.Label66.TabIndex = 67
        Me.Label66.Text = "事故源名称:"
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(129, 84)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(118, 21)
        Me.txtName.TabIndex = 65
        Me.txtName.Text = "丁二烯"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ctxtHc)
        Me.GroupBox2.Location = New System.Drawing.Point(298, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 61)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物化性质"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(30, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(119, 12)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "物质燃烧热Hc[J/kg]:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ctxtHc
        '
        Me.ctxtHc.DataType = Chart.DataType.DataDouble
        Me.ctxtHc.Location = New System.Drawing.Point(155, 27)
        Me.ctxtHc.MaxValue = 0
        Me.ctxtHc.MinValue = 0
        Me.ctxtHc.Name = "ctxtHc"
        Me.ctxtHc.Size = New System.Drawing.Size(100, 21)
        Me.ctxtHc.TabIndex = 69
        Me.ctxtHc.Text = "0"
        Me.ctxtHc.Value = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ctxtWf)
        Me.GroupBox1.Controls.Add(Me.cmbType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 71)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本属性"
        '
        'ctxtWf
        '
        Me.ctxtWf.DataType = Chart.DataType.DataDouble
        Me.ctxtWf.Location = New System.Drawing.Point(131, 14)
        Me.ctxtWf.MaxValue = 0
        Me.ctxtWf.MinValue = 0
        Me.ctxtWf.Name = "ctxtWf"
        Me.ctxtWf.Size = New System.Drawing.Size(100, 21)
        Me.ctxtWf.TabIndex = 68
        Me.ctxtWf.Text = "0"
        Me.ctxtWf.Value = 0
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbType.Items.AddRange(New Object() {"单罐储存", "双罐储存", "多罐储存"})
        Me.cmbType.Location = New System.Drawing.Point(131, 41)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbType.Size = New System.Drawing.Size(100, 20)
        Me.cmbType.TabIndex = 61
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(119, 12)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "物质总质量Wf[ kg ]:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(39, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "物质存储方式:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSeachData
        '
        Me.cmdSeachData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeachData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSeachData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeachData.Location = New System.Drawing.Point(298, 200)
        Me.cmdSeachData.Name = "cmdSeachData"
        Me.cmdSeachData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSeachData.Size = New System.Drawing.Size(149, 25)
        Me.cmdSeachData.TabIndex = 62
        Me.cmdSeachData.Text = "从数据库中查找物化数据"
        Me.cmdSeachData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(64, 87)
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
        Me._Box_1.Controls.Add(Me.GroupBox7)
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
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.ctxtLong)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.ctxtCount)
        Me.GroupBox7.Location = New System.Drawing.Point(318, 249)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(298, 72)
        Me.GroupBox7.TabIndex = 269
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "距事故源中心的距离"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "步长[m]:"
        '
        'ctxtLong
        '
        Me.ctxtLong.DataType = Chart.DataType.DataDouble
        Me.ctxtLong.Location = New System.Drawing.Point(77, 26)
        Me.ctxtLong.MaxValue = 0
        Me.ctxtLong.MinValue = 0
        Me.ctxtLong.Name = "ctxtLong"
        Me.ctxtLong.Size = New System.Drawing.Size(65, 21)
        Me.ctxtLong.TabIndex = 74
        Me.ctxtLong.Text = "0"
        Me.ctxtLong.Value = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(165, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "个数:"
        '
        'ctxtCount
        '
        Me.ctxtCount.DataType = Chart.DataType.DataDouble
        Me.ctxtCount.Location = New System.Drawing.Point(206, 26)
        Me.ctxtCount.MaxValue = 0
        Me.ctxtCount.MinValue = 0
        Me.ctxtCount.Name = "ctxtCount"
        Me.ctxtCount.Size = New System.Drawing.Size(65, 21)
        Me.ctxtCount.TabIndex = 76
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
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label14)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label8)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label11)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label18)
        Me.GroupBoxForecastPoint.Location = New System.Drawing.Point(23, 249)
        Me.GroupBoxForecastPoint.Name = "GroupBoxForecastPoint"
        Me.GroupBoxForecastPoint.Size = New System.Drawing.Size(276, 72)
        Me.GroupBoxForecastPoint.TabIndex = 268
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(6, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(47, 12)
        Me.Label14.TabIndex = 202
        Me.Label14.Text = "x轴[m]:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(149, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "-"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(149, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "-"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(6, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(47, 12)
        Me.Label18.TabIndex = 206
        Me.Label18.Text = "y轴[m]:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.EFlexHeatRadiate)
        Me.GroupBox3.Controls.Add(Me.cmdDamageAdd)
        Me.GroupBox3.Controls.Add(Me.cmdDamageDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(318, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 226)
        Me.GroupBox3.TabIndex = 75
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
        Me.EFlexHeatRadiate.Size = New System.Drawing.Size(276, 174)
        Me.EFlexHeatRadiate.StyleInfo = resources.GetString("EFlexHeatRadiate.StyleInfo")
        Me.EFlexHeatRadiate.TabIndex = 71
        '
        'cmdDamageAdd
        '
        Me.cmdDamageAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageAdd.Location = New System.Drawing.Point(73, 197)
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
        Me.cmdDamageDelete.Location = New System.Drawing.Point(188, 197)
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
        Me.groupbox.Location = New System.Drawing.Point(23, 17)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(276, 226)
        Me.groupbox.TabIndex = 71
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
        Me.EFlexDistance.Size = New System.Drawing.Size(246, 171)
        Me.EFlexDistance.StyleInfo = resources.GetString("EFlexDistance.StyleInfo")
        Me.EFlexDistance.TabIndex = 71
        '
        'cmdForcastAdd
        '
        Me.cmdForcastAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdForcastAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdForcastAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdForcastAdd.Location = New System.Drawing.Point(47, 197)
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
        Me.cmdForecastDelete.Location = New System.Drawing.Point(142, 197)
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
        Me._Box_2.Controls.Add(Me.GroupBox5)
        Me._Box_2.Controls.Add(Me.GroupBox4)
        Me._Box_2.Controls.Add(Me.chkH)
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ctxtPa)
        Me.GroupBox5.Controls.Add(Me.ctxtF)
        Me.GroupBox5.Controls.Add(Me.OptionF2)
        Me.GroupBox5.Controls.Add(Me.OptionF1)
        Me.GroupBox5.Location = New System.Drawing.Point(44, 98)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(285, 79)
        Me.GroupBox5.TabIndex = 48
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "燃烧辐射分数计算方法"
        '
        'ctxtPa
        '
        Me.ctxtPa.DataType = Chart.DataType.DataDouble
        Me.ctxtPa.Location = New System.Drawing.Point(173, 46)
        Me.ctxtPa.MaxValue = 0
        Me.ctxtPa.MinValue = 0
        Me.ctxtPa.Name = "ctxtPa"
        Me.ctxtPa.Size = New System.Drawing.Size(89, 21)
        Me.ctxtPa.TabIndex = 56
        Me.ctxtPa.Text = "0"
        Me.ctxtPa.Value = 0
        '
        'ctxtF
        '
        Me.ctxtF.DataType = Chart.DataType.DataDouble
        Me.ctxtF.Location = New System.Drawing.Point(173, 20)
        Me.ctxtF.MaxValue = 0
        Me.ctxtF.MinValue = 0
        Me.ctxtF.Name = "ctxtF"
        Me.ctxtF.Size = New System.Drawing.Size(89, 21)
        Me.ctxtF.TabIndex = 55
        Me.ctxtF.Text = "0"
        Me.ctxtF.Value = 0
        '
        'OptionF2
        '
        Me.OptionF2.AutoSize = True
        Me.OptionF2.BackColor = System.Drawing.Color.Transparent
        Me.OptionF2.Cursor = System.Windows.Forms.Cursors.Default
        Me.OptionF2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptionF2.Location = New System.Drawing.Point(6, 47)
        Me.OptionF2.Name = "OptionF2"
        Me.OptionF2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OptionF2.Size = New System.Drawing.Size(161, 16)
        Me.OptionF2.TabIndex = 54
        Me.OptionF2.TabStop = True
        Me.OptionF2.Text = "通过容器内压力计算[Pa]:"
        Me.OptionF2.UseVisualStyleBackColor = False
        '
        'OptionF1
        '
        Me.OptionF1.AutoSize = True
        Me.OptionF1.BackColor = System.Drawing.Color.Transparent
        Me.OptionF1.Checked = True
        Me.OptionF1.Cursor = System.Windows.Forms.Cursors.Default
        Me.OptionF1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptionF1.Location = New System.Drawing.Point(60, 21)
        Me.OptionF1.Name = "OptionF1"
        Me.OptionF1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OptionF1.Size = New System.Drawing.Size(107, 16)
        Me.OptionF1.TabIndex = 52
        Me.OptionF1.TabStop = True
        Me.OptionF1.Text = "通过系数估算f="
        Me.OptionF1.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbBleveRTModel)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(44, 39)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(285, 53)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "火球半径和持续时间模型"
        '
        'cmbBleveRTModel
        '
        Me.cmbBleveRTModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBleveRTModel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBleveRTModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBleveRTModel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbBleveRTModel.Items.AddRange(New Object() {"ILO 模型", "H.R.Greengerg&J.J.Cramer模型", "修正模型"})
        Me.cmbBleveRTModel.Location = New System.Drawing.Point(77, 20)
        Me.cmbBleveRTModel.Name = "cmbBleveRTModel"
        Me.cmbBleveRTModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbBleveRTModel.Size = New System.Drawing.Size(185, 20)
        Me.cmbBleveRTModel.TabIndex = 46
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(12, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "选择模型:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkH
        '
        Me.chkH.AutoSize = True
        Me.chkH.BackColor = System.Drawing.Color.Transparent
        Me.chkH.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkH.Location = New System.Drawing.Point(44, 183)
        Me.chkH.Name = "chkH"
        Me.chkH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkH.Size = New System.Drawing.Size(180, 16)
        Me.chkH.TabIndex = 44
        Me.chkH.Text = "计算结果忽略火球高度的影响"
        Me.chkH.UseVisualStyleBackColor = False
        Me.chkH.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(516, 388)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "取消(&C)"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(420, 388)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "确定(&O)"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmBleve
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
        Me.Name = "frmBleve"
        Me.Text = "沸腾液体扩展蒸气云爆炸(BLEVE)模型"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me._Box_0.ResumeLayout(False)
        Me._Box_0.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me._Box_1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBoxForecastPoint.ResumeLayout(False)
        Me.GroupBoxForecastPoint.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.EFlexHeatRadiate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupbox.ResumeLayout(False)
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me._Box_2.ResumeLayout(False)
        Me._Box_2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents _Box_0 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSeachData As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents _Box_1 As System.Windows.Forms.Panel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Public WithEvents _Box_2 As System.Windows.Forms.Panel
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents cmbType As System.Windows.Forms.ComboBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents chkH As System.Windows.Forms.CheckBox
    Public WithEvents txtLeakSourceName As System.Windows.Forms.TextBox
    Public WithEvents Label66 As System.Windows.Forms.Label
    Public WithEvents cmbBleveRTModel As System.Windows.Forms.ComboBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents OptionF1 As System.Windows.Forms.RadioButton
    Public WithEvents OptionF2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ctxtHc As Chart.CText
    Friend WithEvents ctxtF As Chart.CText
    Friend WithEvents ctxtPa As Chart.CText
    Friend WithEvents ctxtWf As Chart.CText
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ctxtCount As Chart.CText
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents EFlexHeatRadiate As Chart.EFlex
    Public WithEvents cmdDamageAdd As System.Windows.Forms.Button
    Public WithEvents cmdDamageDelete As System.Windows.Forms.Button
    Friend WithEvents ctxtLong As Chart.CText
    Friend WithEvents groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents EFlexDistance As Chart.EFlex
    Public WithEvents cmdForcastAdd As System.Windows.Forms.Button
    Public WithEvents cmdForecastDelete As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtX As Chart.CText
    Friend WithEvents txtY As Chart.CText
    Friend WithEvents GroupBoxForecastPoint As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As Chart.CText
    Friend WithEvents txtMinY As Chart.CText
    Friend WithEvents txtMaxX As Chart.CText
    Friend WithEvents txtMinX As Chart.CText
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
End Class
