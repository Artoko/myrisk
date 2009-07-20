<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChemistry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChemistry))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtPrn = New Chart.CText
        Me.txtPrB = New Chart.CText
        Me.txtPrA = New Chart.CText
        Me.Label100 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.EFlexHurt = New Chart.EFlex
        Me.cmdDelHurt = New System.Windows.Forms.Button
        Me.cmdAddHurt = New System.Windows.Forms.Button
        Me.txtCpg = New Chart.CText
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtLeakGasK = New Chart.CText
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtLeakLiquidH = New Chart.CText
        Me.txtLeakLiquidCP = New Chart.CText
        Me.text5 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtLeakEvaporationTb = New Chart.CText
        Me.txtPg = New Chart.CText
        Me.txtLeakLiquidPl = New Chart.CText
        Me.txtLeakM = New Chart.CText
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label43 = New System.Windows.Forms.Label
        Me.cmbName = New System.Windows.Forms.ComboBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me._ListView1_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
        Me.cmbSearchType = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtAntoineC = New Chart.CText
        Me.txtAntoineB = New Chart.CText
        Me.txtAntoineA = New Chart.CText
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.EFlexHurt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtPrn)
        Me.GroupBox5.Controls.Add(Me.txtPrB)
        Me.GroupBox5.Controls.Add(Me.txtPrA)
        Me.GroupBox5.Controls.Add(Me.Label100)
        Me.GroupBox5.Controls.Add(Me.Label70)
        Me.GroupBox5.Controls.Add(Me.Label60)
        Me.GroupBox5.Location = New System.Drawing.Point(310, 425)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(357, 49)
        Me.GroupBox5.TabIndex = 273
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "毒性负荷参数"
        '
        'txtPrn
        '
        Me.txtPrn.DataType = Chart.DataType.DataDouble
        Me.txtPrn.Location = New System.Drawing.Point(239, 17)
        Me.txtPrn.MaxValue = 0
        Me.txtPrn.MinValue = 0
        Me.txtPrn.Name = "txtPrn"
        Me.txtPrn.Size = New System.Drawing.Size(72, 21)
        Me.txtPrn.TabIndex = 5
        Me.txtPrn.Text = "0"
        Me.txtPrn.Value = 0
        '
        'txtPrB
        '
        Me.txtPrB.DataType = Chart.DataType.DataDouble
        Me.txtPrB.Location = New System.Drawing.Point(138, 17)
        Me.txtPrB.MaxValue = 0
        Me.txtPrB.MinValue = 0
        Me.txtPrB.Name = "txtPrB"
        Me.txtPrB.Size = New System.Drawing.Size(72, 21)
        Me.txtPrB.TabIndex = 4
        Me.txtPrB.Text = "0"
        Me.txtPrB.Value = 0
        '
        'txtPrA
        '
        Me.txtPrA.DataType = Chart.DataType.DataDouble
        Me.txtPrA.Location = New System.Drawing.Point(37, 17)
        Me.txtPrA.MaxValue = 0
        Me.txtPrA.MinValue = 0
        Me.txtPrA.Name = "txtPrA"
        Me.txtPrA.Size = New System.Drawing.Size(72, 21)
        Me.txtPrA.TabIndex = 3
        Me.txtPrA.Text = "0"
        Me.txtPrA.Value = 0
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(216, 20)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(17, 12)
        Me.Label100.TabIndex = 2
        Me.Label100.Text = "n:"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(115, 20)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(17, 12)
        Me.Label70.TabIndex = 1
        Me.Label70.Text = "B:"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(14, 20)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(17, 12)
        Me.Label60.TabIndex = 0
        Me.Label60.Text = "A:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.EFlexHurt)
        Me.GroupBox4.Controls.Add(Me.cmdDelHurt)
        Me.GroupBox4.Controls.Add(Me.cmdAddHurt)
        Me.GroupBox4.Location = New System.Drawing.Point(310, 216)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(357, 203)
        Me.GroupBox4.TabIndex = 272
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "浓度限值"
        '
        'EFlexHurt
        '
        Me.EFlexHurt.ColumnInfo = resources.GetString("EFlexHurt.ColumnInfo")
        Me.EFlexHurt.IsCopy = True
        Me.EFlexHurt.IsCut = True
        Me.EFlexHurt.IsPaste = True
        Me.EFlexHurt.Location = New System.Drawing.Point(18, 20)
        Me.EFlexHurt.Name = "EFlexHurt"
        Me.EFlexHurt.Rows.Count = 2
        Me.EFlexHurt.Rows.DefaultSize = 18
        Me.EFlexHurt.Size = New System.Drawing.Size(333, 144)
        Me.EFlexHurt.StyleInfo = resources.GetString("EFlexHurt.StyleInfo")
        Me.EFlexHurt.TabIndex = 264
        '
        'cmdDelHurt
        '
        Me.cmdDelHurt.Location = New System.Drawing.Point(273, 170)
        Me.cmdDelHurt.Name = "cmdDelHurt"
        Me.cmdDelHurt.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelHurt.TabIndex = 263
        Me.cmdDelHurt.Text = "删除(&D)"
        Me.cmdDelHurt.UseVisualStyleBackColor = True
        '
        'cmdAddHurt
        '
        Me.cmdAddHurt.Location = New System.Drawing.Point(192, 170)
        Me.cmdAddHurt.Name = "cmdAddHurt"
        Me.cmdAddHurt.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddHurt.TabIndex = 262
        Me.cmdAddHurt.Text = "添加(&A)"
        Me.cmdAddHurt.UseVisualStyleBackColor = True
        '
        'txtCpg
        '
        Me.txtCpg.DataType = Chart.DataType.DataDouble
        Me.txtCpg.ForeColor = System.Drawing.Color.Blue
        Me.txtCpg.Location = New System.Drawing.Point(181, 88)
        Me.txtCpg.MaxValue = 1.0E+17
        Me.txtCpg.MinValue = 0
        Me.txtCpg.Name = "txtCpg"
        Me.txtCpg.Size = New System.Drawing.Size(100, 21)
        Me.txtCpg.TabIndex = 281
        Me.txtCpg.Text = "0"
        Me.txtCpg.Value = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(32, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 12)
        Me.Label5.TabIndex = 280
        Me.Label5.Text = "气体的定压比热[J/K.kg]:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLeakGasK)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.txtCpg)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidH)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLeakLiquidCP)
        Me.GroupBox1.Controls.Add(Me.text5)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 348)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 115)
        Me.GroupBox1.TabIndex = 279
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "物化参数"
        '
        'txtLeakGasK
        '
        Me.txtLeakGasK.DataType = Chart.DataType.DataDouble
        Me.txtLeakGasK.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakGasK.Location = New System.Drawing.Point(181, 67)
        Me.txtLeakGasK.MaxValue = 0
        Me.txtLeakGasK.MinValue = 0
        Me.txtLeakGasK.Name = "txtLeakGasK"
        Me.txtLeakGasK.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakGasK.TabIndex = 8
        Me.txtLeakGasK.Text = "0"
        Me.txtLeakGasK.Value = 0
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.ForeColor = System.Drawing.Color.Blue
        Me.Label40.Location = New System.Drawing.Point(74, 70)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(101, 12)
        Me.Label40.TabIndex = 5
        Me.Label40.Text = "气体绝热指数 κ:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLeakLiquidH
        '
        Me.txtLeakLiquidH.DataType = Chart.DataType.DataDouble
        Me.txtLeakLiquidH.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidH.Location = New System.Drawing.Point(181, 46)
        Me.txtLeakLiquidH.MaxValue = 0
        Me.txtLeakLiquidH.MinValue = 0
        Me.txtLeakLiquidH.Name = "txtLeakLiquidH"
        Me.txtLeakLiquidH.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakLiquidH.TabIndex = 10
        Me.txtLeakLiquidH.Text = "0"
        Me.txtLeakLiquidH.Value = 0
        '
        'txtLeakLiquidCP
        '
        Me.txtLeakLiquidCP.DataType = Chart.DataType.DataDouble
        Me.txtLeakLiquidCP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidCP.Location = New System.Drawing.Point(181, 25)
        Me.txtLeakLiquidCP.MaxValue = 0
        Me.txtLeakLiquidCP.MinValue = 0
        Me.txtLeakLiquidCP.Name = "txtLeakLiquidCP"
        Me.txtLeakLiquidCP.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakLiquidCP.TabIndex = 9
        Me.txtLeakLiquidCP.Text = "0"
        Me.txtLeakLiquidCP.Value = 0
        '
        'text5
        '
        Me.text5.AutoSize = True
        Me.text5.BackColor = System.Drawing.Color.Transparent
        Me.text5.Cursor = System.Windows.Forms.Cursors.Default
        Me.text5.ForeColor = System.Drawing.Color.Blue
        Me.text5.Location = New System.Drawing.Point(14, 28)
        Me.text5.Name = "text5"
        Me.text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.text5.Size = New System.Drawing.Size(161, 12)
        Me.text5.TabIndex = 6
        Me.text5.Text = "液体定压比热CP[J/(kg·K)]:"
        Me.text5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(50, 49)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(125, 12)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "液体的气化热H[J/kg]:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtLeakEvaporationTb)
        Me.GroupBox7.Controls.Add(Me.txtPg)
        Me.GroupBox7.Controls.Add(Me.txtLeakLiquidPl)
        Me.GroupBox7.Controls.Add(Me.txtLeakM)
        Me.GroupBox7.Controls.Add(Me.Label41)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Location = New System.Drawing.Point(13, 216)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(291, 126)
        Me.GroupBox7.TabIndex = 277
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "物理参数"
        '
        'txtLeakEvaporationTb
        '
        Me.txtLeakEvaporationTb.DataType = Chart.DataType.DataDouble
        Me.txtLeakEvaporationTb.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakEvaporationTb.Location = New System.Drawing.Point(182, 89)
        Me.txtLeakEvaporationTb.MaxValue = 0
        Me.txtLeakEvaporationTb.MinValue = 0
        Me.txtLeakEvaporationTb.Name = "txtLeakEvaporationTb"
        Me.txtLeakEvaporationTb.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakEvaporationTb.TabIndex = 46
        Me.txtLeakEvaporationTb.Text = "0"
        Me.txtLeakEvaporationTb.Value = 0
        '
        'txtPg
        '
        Me.txtPg.DataType = Chart.DataType.DataDouble
        Me.txtPg.ForeColor = System.Drawing.Color.Blue
        Me.txtPg.Location = New System.Drawing.Point(182, 68)
        Me.txtPg.MaxValue = 0
        Me.txtPg.MinValue = 0
        Me.txtPg.Name = "txtPg"
        Me.txtPg.Size = New System.Drawing.Size(100, 21)
        Me.txtPg.TabIndex = 45
        Me.txtPg.Text = "0"
        Me.txtPg.Value = 0
        '
        'txtLeakLiquidPl
        '
        Me.txtLeakLiquidPl.DataType = Chart.DataType.DataDouble
        Me.txtLeakLiquidPl.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakLiquidPl.Location = New System.Drawing.Point(182, 47)
        Me.txtLeakLiquidPl.MaxValue = 0
        Me.txtLeakLiquidPl.MinValue = 0
        Me.txtLeakLiquidPl.Name = "txtLeakLiquidPl"
        Me.txtLeakLiquidPl.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakLiquidPl.TabIndex = 44
        Me.txtLeakLiquidPl.Text = "0"
        Me.txtLeakLiquidPl.Value = 0
        '
        'txtLeakM
        '
        Me.txtLeakM.DataType = Chart.DataType.DataDouble
        Me.txtLeakM.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakM.Location = New System.Drawing.Point(182, 26)
        Me.txtLeakM.MaxValue = 1000
        Me.txtLeakM.MinValue = 0
        Me.txtLeakM.Name = "txtLeakM"
        Me.txtLeakM.Size = New System.Drawing.Size(100, 21)
        Me.txtLeakM.TabIndex = 43
        Me.txtLeakM.Text = "0"
        Me.txtLeakM.Value = 0
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(63, 29)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(113, 12)
        Me.Label41.TabIndex = 40
        Me.Label41.Text = "摩尔质量M[kg/mol]:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(51, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(125, 12)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "蒸气密度ρg[kg/m^3]:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(51, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(125, 12)
        Me.Label23.TabIndex = 41
        Me.Label23.Text = "液体密度ρl[kg/m^3]:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(51, 92)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(125, 12)
        Me.Label26.TabIndex = 42
        Me.Label26.Text = "液体常压沸点 Tb[℃]:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearch.Location = New System.Drawing.Point(518, 13)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearch.Size = New System.Drawing.Size(149, 25)
        Me.cmdSearch.TabIndex = 276
        Me.cmdSearch.Text = "从数据库中查找物化数据"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(12, 18)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(59, 12)
        Me.Label43.TabIndex = 283
        Me.Label43.Text = "物料名称:"
        '
        'cmbName
        '
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Items.AddRange(New Object() {"氯", "氨", "丙烯醛", "四氯化碳", "氯化氢", "甲基溴", "光气", "氟化氢", "丙烯腈", "丙烯醇", "氰化氢", "硫化氢", "磷化氢", "对硫磷"})
        Me.cmbName.Location = New System.Drawing.Point(77, 15)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(153, 20)
        Me.cmbName.TabIndex = 284
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(399, 497)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 25)
        Me.Command1.TabIndex = 85
        Me.Command1.Text = "加密"
        Me.Command1.UseVisualStyleBackColor = False
        Me.Command1.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(446, 497)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(41, 25)
        Me.Command2.TabIndex = 86
        Me.Command2.Text = "解密"
        Me.Command2.UseVisualStyleBackColor = False
        Me.Command2.Visible = False
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.SystemColors.Window
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._ListView1_ColumnHeader_1, Me._ListView1_ColumnHeader_2, Me._ListView1_ColumnHeader_3, Me._ListView1_ColumnHeader_4, Me._ListView1_ColumnHeader_5})
        Me.ListView1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(13, 42)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(654, 168)
        Me.ListView1.TabIndex = 83
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        '_ListView1_ColumnHeader_1
        '
        Me._ListView1_ColumnHeader_1.Text = "中文名1"
        Me._ListView1_ColumnHeader_1.Width = 126
        '
        '_ListView1_ColumnHeader_2
        '
        Me._ListView1_ColumnHeader_2.Text = "中文名2"
        Me._ListView1_ColumnHeader_2.Width = 104
        '
        '_ListView1_ColumnHeader_3
        '
        Me._ListView1_ColumnHeader_3.Text = "英文名1"
        Me._ListView1_ColumnHeader_3.Width = 99
        '
        '_ListView1_ColumnHeader_4
        '
        Me._ListView1_ColumnHeader_4.Text = "英文名2"
        Me._ListView1_ColumnHeader_4.Width = 108
        '
        '_ListView1_ColumnHeader_5
        '
        Me._ListView1_ColumnHeader_5.Text = "CAS 号"
        Me._ListView1_ColumnHeader_5.Width = 170
        '
        'cmbSearchType
        '
        Me.cmbSearchType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSearchType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSearchType.Items.AddRange(New Object() {"中文名", "英文名", "CAS号"})
        Me.cmbSearchType.Location = New System.Drawing.Point(310, 16)
        Me.cmbSearchType.Name = "cmbSearchType"
        Me.cmbSearchType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSearchType.Size = New System.Drawing.Size(174, 20)
        Me.cmbSearchType.TabIndex = 80
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(236, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "查找方式:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(493, 497)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 286
        Me.OK_Button.Text = "确定(&O)"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(583, 497)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 287
        Me.Cancel_Button.Text = "取消(&C)"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'txtAntoineC
        '
        Me.txtAntoineC.DataType = Chart.DataType.DataDouble
        Me.txtAntoineC.Location = New System.Drawing.Point(215, 25)
        Me.txtAntoineC.MaxValue = 0
        Me.txtAntoineC.MinValue = 0
        Me.txtAntoineC.Name = "txtAntoineC"
        Me.txtAntoineC.Size = New System.Drawing.Size(67, 21)
        Me.txtAntoineC.TabIndex = 293
        Me.txtAntoineC.Text = "0"
        Me.txtAntoineC.Value = 0
        '
        'txtAntoineB
        '
        Me.txtAntoineB.DataType = Chart.DataType.DataDouble
        Me.txtAntoineB.Location = New System.Drawing.Point(119, 25)
        Me.txtAntoineB.MaxValue = 0
        Me.txtAntoineB.MinValue = 0
        Me.txtAntoineB.Name = "txtAntoineB"
        Me.txtAntoineB.Size = New System.Drawing.Size(67, 21)
        Me.txtAntoineB.TabIndex = 292
        Me.txtAntoineB.Text = "0"
        Me.txtAntoineB.Value = 0
        '
        'txtAntoineA
        '
        Me.txtAntoineA.DataType = Chart.DataType.DataDouble
        Me.txtAntoineA.Location = New System.Drawing.Point(29, 25)
        Me.txtAntoineA.MaxValue = 0
        Me.txtAntoineA.MinValue = 0
        Me.txtAntoineA.Name = "txtAntoineA"
        Me.txtAntoineA.Size = New System.Drawing.Size(67, 21)
        Me.txtAntoineA.TabIndex = 291
        Me.txtAntoineA.Text = "0"
        Me.txtAntoineA.Value = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(192, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 290
        Me.Label4.Text = "C:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(101, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 289
        Me.Label7.Text = "B:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 288
        Me.Label8.Text = "A:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtAntoineC)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtAntoineB)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtAntoineA)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 469)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(291, 58)
        Me.GroupBox2.TabIndex = 294
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "安托因参数"
        '
        'frmChemistry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 546)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbName)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.cmbSearchType)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "frmChemistry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "物化性质和毒性参数"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.EFlexHurt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrn As Chart.CText
    Friend WithEvents txtPrB As Chart.CText
    Friend WithEvents txtPrA As Chart.CText
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents EFlexHurt As Chart.EFlex
    Friend WithEvents cmdDelHurt As System.Windows.Forms.Button
    Friend WithEvents cmdAddHurt As System.Windows.Forms.Button
    Friend WithEvents txtCpg As Chart.CText
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLeakLiquidH As Chart.CText
    Friend WithEvents txtLeakLiquidCP As Chart.CText
    Public WithEvents text5 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtLeakGasK As Chart.CText
    Public WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLeakEvaporationTb As Chart.CText
    Friend WithEvents txtPg As Chart.CText
    Friend WithEvents txtLeakLiquidPl As Chart.CText
    Friend WithEvents txtLeakM As Chart.CText
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cmbName As System.Windows.Forms.ComboBox
    Public WithEvents ListView1 As System.Windows.Forms.ListView
    Public WithEvents _ListView1_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
    Public WithEvents cmbSearchType As System.Windows.Forms.ComboBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtAntoineC As Chart.CText
    Friend WithEvents txtAntoineB As Chart.CText
    Friend WithEvents txtAntoineA As Chart.CText
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
