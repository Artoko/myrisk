<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatialTNT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMatialTNT))
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CTextStep = New Chart.CText
        Me.Label5 = New System.Windows.Forms.Label
        Me.CTextCount = New Chart.CText
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBoxForecastPoint = New System.Windows.Forms.GroupBox
        Me.txtMaxY = New Chart.CText
        Me.txtMinY = New Chart.CText
        Me.txtMaxX = New Chart.CText
        Me.txtMinX = New Chart.CText
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.groupbox = New System.Windows.Forms.GroupBox
        Me.EFlexDistance = New Chart.EFlex
        Me.cmdForcastAdd = New System.Windows.Forms.Button
        Me.cmdForecastDelete = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdDamageAdd = New System.Windows.Forms.Button
        Me.EFlex1 = New Chart.EFlex
        Me.cmdDamageDelete = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtX = New Chart.CText
        Me.txtY = New Chart.CText
        Me.txtQf = New Chart.CText
        Me.txtLeakSourceName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtWf = New Chart.CText
        Me.cmdOk = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label66 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.cmdSeachData = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.CheckFormula = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtP0 = New Chart.CText
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBoxForecastPoint.SuspendLayout()
        Me.groupbox.SuspendLayout()
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EFlex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBoxForecastPoint)
        Me.TabPage2.Controls.Add(Me.groupbox)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(643, 345)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "预测方案"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CTextStep)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.CTextCount)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Location = New System.Drawing.Point(316, 257)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(315, 72)
        Me.GroupBox5.TabIndex = 270
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "距事故源中心的距离"
        '
        'CTextStep
        '
        Me.CTextStep.DataType = Chart.DataType.DataDouble
        Me.CTextStep.Location = New System.Drawing.Point(74, 35)
        Me.CTextStep.MaxValue = 9999999999
        Me.CTextStep.MinValue = 1
        Me.CTextStep.Name = "CTextStep"
        Me.CTextStep.Size = New System.Drawing.Size(74, 21)
        Me.CTextStep.TabIndex = 73
        Me.CTextStep.Text = "1"
        Me.CTextStep.Value = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "步长(m):"
        '
        'CTextCount
        '
        Me.CTextCount.DataType = Chart.DataType.DataDouble
        Me.CTextCount.Location = New System.Drawing.Point(202, 35)
        Me.CTextCount.MaxValue = 9999999999999
        Me.CTextCount.MinValue = 1
        Me.CTextCount.Name = "CTextCount"
        Me.CTextCount.Size = New System.Drawing.Size(74, 21)
        Me.CTextCount.TabIndex = 74
        Me.CTextCount.Text = "0"
        Me.CTextCount.Value = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(161, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "个数:"
        '
        'GroupBoxForecastPoint
        '
        Me.GroupBoxForecastPoint.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMaxY)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinY)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMaxX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label14)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label9)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label11)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label18)
        Me.GroupBoxForecastPoint.Location = New System.Drawing.Point(18, 257)
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(149, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(11, 12)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "-"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'groupbox
        '
        Me.groupbox.Controls.Add(Me.EFlexDistance)
        Me.groupbox.Controls.Add(Me.cmdForcastAdd)
        Me.groupbox.Controls.Add(Me.cmdForecastDelete)
        Me.groupbox.Location = New System.Drawing.Point(18, 23)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(276, 228)
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
        Me.EFlexDistance.Location = New System.Drawing.Point(6, 20)
        Me.EFlexDistance.Name = "EFlexDistance"
        Me.EFlexDistance.Rows.Count = 1
        Me.EFlexDistance.Rows.DefaultSize = 18
        Me.EFlexDistance.Size = New System.Drawing.Size(264, 173)
        Me.EFlexDistance.StyleInfo = resources.GetString("EFlexDistance.StyleInfo")
        Me.EFlexDistance.TabIndex = 67
        '
        'cmdForcastAdd
        '
        Me.cmdForcastAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdForcastAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdForcastAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdForcastAdd.Location = New System.Drawing.Point(33, 199)
        Me.cmdForcastAdd.Name = "cmdForcastAdd"
        Me.cmdForcastAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdForcastAdd.Size = New System.Drawing.Size(67, 23)
        Me.cmdForcastAdd.TabIndex = 31
        Me.cmdForcastAdd.Text = "增加(&A)"
        Me.cmdForcastAdd.UseVisualStyleBackColor = True
        '
        'cmdForecastDelete
        '
        Me.cmdForecastDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdForecastDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdForecastDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdForecastDelete.Location = New System.Drawing.Point(151, 199)
        Me.cmdForecastDelete.Name = "cmdForecastDelete"
        Me.cmdForecastDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdForecastDelete.Size = New System.Drawing.Size(67, 23)
        Me.cmdForecastDelete.TabIndex = 32
        Me.cmdForecastDelete.Text = "删除(&D)"
        Me.cmdForecastDelete.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdDamageAdd)
        Me.GroupBox3.Controls.Add(Me.EFlex1)
        Me.GroupBox3.Controls.Add(Me.cmdDamageDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(316, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(315, 228)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算超压伤害范围"
        '
        'cmdDamageAdd
        '
        Me.cmdDamageAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageAdd.Location = New System.Drawing.Point(43, 199)
        Me.cmdDamageAdd.Name = "cmdDamageAdd"
        Me.cmdDamageAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDamageAdd.Size = New System.Drawing.Size(67, 23)
        Me.cmdDamageAdd.TabIndex = 41
        Me.cmdDamageAdd.Text = "增加(&A)"
        Me.cmdDamageAdd.UseVisualStyleBackColor = True
        '
        'EFlex1
        '
        Me.EFlex1.ColumnInfo = resources.GetString("EFlex1.ColumnInfo")
        Me.EFlex1.IsCopy = True
        Me.EFlex1.IsCut = True
        Me.EFlex1.IsPaste = True
        Me.EFlex1.Location = New System.Drawing.Point(13, 20)
        Me.EFlex1.Name = "EFlex1"
        Me.EFlex1.Rows.Count = 17
        Me.EFlex1.Rows.DefaultSize = 18
        Me.EFlex1.Size = New System.Drawing.Size(296, 173)
        Me.EFlex1.StyleInfo = resources.GetString("EFlex1.StyleInfo")
        Me.EFlex1.TabIndex = 75
        '
        'cmdDamageDelete
        '
        Me.cmdDamageDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageDelete.Location = New System.Drawing.Point(173, 199)
        Me.cmdDamageDelete.Name = "cmdDamageDelete"
        Me.cmdDamageDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDamageDelete.Size = New System.Drawing.Size(67, 23)
        Me.cmdDamageDelete.TabIndex = 40
        Me.cmdDamageDelete.Text = "删除(&D)"
        Me.cmdDamageDelete.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtX)
        Me.GroupBox4.Controls.Add(Me.txtY)
        Me.GroupBox4.Location = New System.Drawing.Point(303, 30)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 81)
        Me.GroupBox4.TabIndex = 70
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "事故源坐标"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(88, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Y[m]:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "X[m]:"
        '
        'txtX
        '
        Me.txtX.DataType = Chart.DataType.DataInteger
        Me.txtX.Location = New System.Drawing.Point(129, 20)
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
        Me.txtY.Location = New System.Drawing.Point(129, 45)
        Me.txtY.MaxValue = 0
        Me.txtY.MinValue = 0
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(100, 21)
        Me.txtY.TabIndex = 1
        Me.txtY.Text = "0"
        Me.txtY.Value = 0
        '
        'txtQf
        '
        Me.txtQf.DataType = Chart.DataType.DataDouble
        Me.txtQf.Location = New System.Drawing.Point(176, 14)
        Me.txtQf.MaxValue = 1.0E+17
        Me.txtQf.MinValue = 0
        Me.txtQf.Name = "txtQf"
        Me.txtQf.Size = New System.Drawing.Size(100, 21)
        Me.txtQf.TabIndex = 30
        Me.txtQf.Text = "0"
        Me.txtQf.Value = 0
        '
        'txtLeakSourceName
        '
        Me.txtLeakSourceName.AcceptsReturn = True
        Me.txtLeakSourceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakSourceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakSourceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakSourceName.Location = New System.Drawing.Point(121, 50)
        Me.txtLeakSourceName.MaxLength = 0
        Me.txtLeakSourceName.Name = "txtLeakSourceName"
        Me.txtLeakSourceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakSourceName.Size = New System.Drawing.Size(132, 21)
        Me.txtLeakSourceName.TabIndex = 68
        Me.txtLeakSourceName.Text = "库房"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(39, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(131, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "物质的燃烧热Qc[J/kg]:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(19, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "物质总质量W[ kg ]:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtWf
        '
        Me.txtWf.DataType = Chart.DataType.DataDouble
        Me.txtWf.Location = New System.Drawing.Point(138, 20)
        Me.txtWf.MaxValue = 99999999999999
        Me.txtWf.MinValue = 0
        Me.txtWf.Name = "txtWf"
        Me.txtWf.Size = New System.Drawing.Size(100, 21)
        Me.txtWf.TabIndex = 70
        Me.txtWf.Text = "0"
        Me.txtWf.Value = 0
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(307, 387)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "确定(&O)"
        Me.cmdOk.UseVisualStyleBackColor = True
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
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.txtLeakSourceName)
        Me.TabPage1.Controls.Add(Me.Label66)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.txtName)
        Me.TabPage1.Controls.Add(Me.cmdSeachData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(643, 345)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "事故源"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(44, 53)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(71, 12)
        Me.Label66.TabIndex = 69
        Me.Label66.Text = "事故源名称:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtQf)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(303, 117)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 73)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物化性质"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(56, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "物质名称:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtWf)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 73)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本属性"
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(121, 77)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(132, 21)
        Me.txtName.TabIndex = 6
        Me.txtName.Text = "硝酸铵"
        '
        'cmdSeachData
        '
        Me.cmdSeachData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeachData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSeachData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeachData.Location = New System.Drawing.Point(303, 202)
        Me.cmdSeachData.Name = "cmdSeachData"
        Me.cmdSeachData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSeachData.Size = New System.Drawing.Size(149, 25)
        Me.cmdSeachData.TabIndex = 62
        Me.cmdSeachData.Text = "从数据库中查找物化数据"
        Me.cmdSeachData.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CheckFormula)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.txtP0)
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(643, 345)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "计算选项"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CheckFormula
        '
        Me.CheckFormula.AutoSize = True
        Me.CheckFormula.Location = New System.Drawing.Point(48, 85)
        Me.CheckFormula.Name = "CheckFormula"
        Me.CheckFormula.Size = New System.Drawing.Size(228, 16)
        Me.CheckFormula.TabIndex = 21
        Me.CheckFormula.Text = "用公式法计算死亡半径和财产损失半径"
        Me.CheckFormula.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "环境压力P0[Pa]:"
        '
        'txtP0
        '
        Me.txtP0.DataType = Chart.DataType.DataDouble
        Me.txtP0.Location = New System.Drawing.Point(147, 45)
        Me.txtP0.MaxValue = 99999999999
        Me.txtP0.MinValue = 0
        Me.txtP0.Name = "txtP0"
        Me.txtP0.Size = New System.Drawing.Size(100, 21)
        Me.txtP0.TabIndex = 0
        Me.txtP0.Text = "0"
        Me.txtP0.Value = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(403, 387)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "取消(&C)"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmMatialTNT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 422)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMatialTNT"
        Me.Text = "凝聚相爆炸模型"
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBoxForecastPoint.ResumeLayout(False)
        Me.GroupBoxForecastPoint.PerformLayout()
        Me.groupbox.ResumeLayout(False)
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.EFlex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CTextStep As Chart.CText
    Friend WithEvents groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents EFlexDistance As Chart.EFlex
    Public WithEvents cmdForcastAdd As System.Windows.Forms.Button
    Public WithEvents cmdForecastDelete As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents cmdDamageAdd As System.Windows.Forms.Button
    Friend WithEvents EFlex1 As Chart.EFlex
    Public WithEvents cmdDamageDelete As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CTextCount As Chart.CText
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtX As Chart.CText
    Friend WithEvents txtY As Chart.CText
    Friend WithEvents txtQf As Chart.CText
    Public WithEvents txtLeakSourceName As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWf As Chart.CText
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents cmdSeachData As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtP0 As Chart.CText
    Friend WithEvents GroupBoxForecastPoint As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As Chart.CText
    Friend WithEvents txtMinY As Chart.CText
    Friend WithEvents txtMaxX As Chart.CText
    Friend WithEvents txtMinX As Chart.CText
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckFormula As System.Windows.Forms.CheckBox
End Class
