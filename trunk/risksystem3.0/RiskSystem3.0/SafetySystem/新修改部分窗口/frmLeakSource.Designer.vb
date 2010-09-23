<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakSource
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeakSource))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtDurationT = New Chart.CText
        Me.txtAngle = New Chart.CText
        Me.txtH = New Chart.CText
        Me.txtLeakGasA = New Chart.CText
        Me.txtLeakTwoCd = New Chart.CText
        Me.cmbLeakGasShape = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.txtLeakLiquidCd = New Chart.CText
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtLeakLiquidHeight = New Chart.CText
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.chkAutoCalLeakP = New System.Windows.Forms.CheckBox
        Me.txtLeakGasP = New Chart.CText
        Me.txtInT = New Chart.CText
        Me.txtQ = New Chart.CText
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtY = New Chart.CText
        Me.txtX = New Chart.CText
        Me.txtLeakSourceName = New System.Windows.Forms.TextBox
        Me.Label67 = New System.Windows.Forms.Label
        Me.lblQ8 = New System.Windows.Forms.Label
        Me.txtQ0 = New Chart.CText
        Me.cbmSourceType = New System.Windows.Forms.ComboBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.LabelS = New System.Windows.Forms.Label
        Me.txtS_S = New Chart.CText
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtThickness = New Chart.CText
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkAutoCalVapP = New System.Windows.Forms.CheckBox
        Me.txtLeakEvaporationP = New Chart.CText
        Me.txtSHe = New Chart.CText
        Me.txtVolatilizationT = New Chart.CText
        Me.txtS = New Chart.CText
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cmbLeakEvaporationGround = New System.Windows.Forms.ComboBox
        Me.txtAirProportion = New Chart.CText
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbLeakType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.m_OK = New System.Windows.Forms.Button
        Me.m_Cancel = New System.Windows.Forms.Button
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.chkIsHeavy = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProbability = New Chart.CText
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtPa = New Chart.CText
        Me.txtTa = New Chart.CText
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDurationT)
        Me.GroupBox6.Controls.Add(Me.txtAngle)
        Me.GroupBox6.Controls.Add(Me.txtH)
        Me.GroupBox6.Controls.Add(Me.txtLeakGasA)
        Me.GroupBox6.Controls.Add(Me.txtLeakTwoCd)
        Me.GroupBox6.Controls.Add(Me.cmbLeakGasShape)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.Label59)
        Me.GroupBox6.Controls.Add(Me.txtLeakLiquidCd)
        Me.GroupBox6.Controls.Add(Me.Label52)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.Label46)
        Me.GroupBox6.Controls.Add(Me.txtLeakLiquidHeight)
        Me.GroupBox6.Controls.Add(Me.Label45)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Location = New System.Drawing.Point(31, 296)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(253, 199)
        Me.GroupBox6.TabIndex = 217
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "泄漏参数"
        '
        'txtDurationT
        '
        Me.txtDurationT.DataType = Chart.DataType.DataDouble
        Me.txtDurationT.Location = New System.Drawing.Point(143, 20)
        Me.txtDurationT.MaxValue = 0
        Me.txtDurationT.MinValue = 0
        Me.txtDurationT.Name = "txtDurationT"
        Me.txtDurationT.Size = New System.Drawing.Size(96, 21)
        Me.txtDurationT.TabIndex = 85
        Me.txtDurationT.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtDurationT, resources.GetString("txtDurationT.ToolTip"))
        Me.txtDurationT.Value = 0
        '
        'txtAngle
        '
        Me.txtAngle.DataType = Chart.DataType.DataDouble
        Me.txtAngle.Location = New System.Drawing.Point(143, 103)
        Me.txtAngle.MaxValue = 90
        Me.txtAngle.MinValue = 0
        Me.txtAngle.Name = "txtAngle"
        Me.txtAngle.Size = New System.Drawing.Size(96, 21)
        Me.txtAngle.TabIndex = 83
        Me.txtAngle.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtAngle, resources.GetString("txtAngle.ToolTip"))
        Me.txtAngle.Value = 0
        '
        'txtH
        '
        Me.txtH.DataType = Chart.DataType.DataDouble
        Me.txtH.Location = New System.Drawing.Point(143, 62)
        Me.txtH.MaxValue = 0
        Me.txtH.MinValue = 0
        Me.txtH.Name = "txtH"
        Me.txtH.Size = New System.Drawing.Size(96, 21)
        Me.txtH.TabIndex = 82
        Me.txtH.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtH, resources.GetString("txtH.ToolTip"))
        Me.txtH.Value = 0
        '
        'txtLeakGasA
        '
        Me.txtLeakGasA.DataType = Chart.DataType.DataDouble
        Me.txtLeakGasA.Location = New System.Drawing.Point(143, 41)
        Me.txtLeakGasA.MaxValue = 0
        Me.txtLeakGasA.MinValue = 0
        Me.txtLeakGasA.Name = "txtLeakGasA"
        Me.txtLeakGasA.Size = New System.Drawing.Size(96, 21)
        Me.txtLeakGasA.TabIndex = 81
        Me.txtLeakGasA.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtLeakGasA, resources.GetString("txtLeakGasA.ToolTip"))
        Me.txtLeakGasA.Value = 0
        '
        'txtLeakTwoCd
        '
        Me.txtLeakTwoCd.DataType = Chart.DataType.DataDouble
        Me.txtLeakTwoCd.Location = New System.Drawing.Point(143, 166)
        Me.txtLeakTwoCd.MaxValue = 0
        Me.txtLeakTwoCd.MinValue = 0
        Me.txtLeakTwoCd.Name = "txtLeakTwoCd"
        Me.txtLeakTwoCd.Size = New System.Drawing.Size(96, 21)
        Me.txtLeakTwoCd.TabIndex = 241
        Me.txtLeakTwoCd.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtLeakTwoCd, resources.GetString("txtLeakTwoCd.ToolTip"))
        Me.txtLeakTwoCd.Value = 0
        '
        'cmbLeakGasShape
        '
        Me.cmbLeakGasShape.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLeakGasShape.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbLeakGasShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLeakGasShape.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLeakGasShape.Items.AddRange(New Object() {"圆  形", "三角形", "长方形"})
        Me.cmbLeakGasShape.Location = New System.Drawing.Point(143, 83)
        Me.cmbLeakGasShape.Name = "cmbLeakGasShape"
        Me.cmbLeakGasShape.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbLeakGasShape.Size = New System.Drawing.Size(96, 20)
        Me.cmbLeakGasShape.TabIndex = 22
        Me.C1SuperTooltip1.SetToolTip(Me.cmbLeakGasShape, resources.GetString("cmbLeakGasShape.ToolTip"))
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(30, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(107, 12)
        Me.Label3.TabIndex = 240
        Me.Label3.Text = "两相流泄漏系数Cd:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(36, 44)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(101, 12)
        Me.Label39.TabIndex = 30
        Me.Label39.Text = "裂口面积 A[m^2]:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(30, 148)
        Me.Label59.Name = "Label59"
        Me.Label59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label59.Size = New System.Drawing.Size(107, 12)
        Me.Label59.TabIndex = 238
        Me.Label59.Text = "液体泄漏系数  Cd:"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLeakLiquidCd
        '
        Me.txtLeakLiquidCd.DataType = Chart.DataType.DataDouble
        Me.txtLeakLiquidCd.Location = New System.Drawing.Point(143, 145)
        Me.txtLeakLiquidCd.MaxValue = 0
        Me.txtLeakLiquidCd.MinValue = 0
        Me.txtLeakLiquidCd.Name = "txtLeakLiquidCd"
        Me.txtLeakLiquidCd.Size = New System.Drawing.Size(96, 21)
        Me.txtLeakLiquidCd.TabIndex = 239
        Me.txtLeakLiquidCd.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtLeakLiquidCd, resources.GetString("txtLeakLiquidCd.ToolTip"))
        Me.txtLeakLiquidCd.Value = 0
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(6, 127)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(131, 12)
        Me.Label52.TabIndex = 236
        Me.Label52.Text = "裂口之上液位高度h[m]:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(78, 86)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(59, 12)
        Me.Label38.TabIndex = 27
        Me.Label38.Text = "裂口形状:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(54, 106)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(83, 12)
        Me.Label46.TabIndex = 28
        Me.Label46.Text = "泄漏喷射角度:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLeakLiquidHeight
        '
        Me.txtLeakLiquidHeight.DataType = Chart.DataType.DataDouble
        Me.txtLeakLiquidHeight.Location = New System.Drawing.Point(143, 124)
        Me.txtLeakLiquidHeight.MaxValue = 0
        Me.txtLeakLiquidHeight.MinValue = 0
        Me.txtLeakLiquidHeight.Name = "txtLeakLiquidHeight"
        Me.txtLeakLiquidHeight.Size = New System.Drawing.Size(96, 21)
        Me.txtLeakLiquidHeight.TabIndex = 237
        Me.txtLeakLiquidHeight.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtLeakLiquidHeight, resources.GetString("txtLeakLiquidHeight.ToolTip"))
        Me.txtLeakLiquidHeight.Value = 0
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(60, 65)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(77, 12)
        Me.Label45.TabIndex = 29
        Me.Label45.Text = "裂口高度[m]:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "泄漏持续时间[min]:"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.chkAutoCalLeakP)
        Me.GroupBox11.Controls.Add(Me.txtLeakGasP)
        Me.GroupBox11.Controls.Add(Me.txtInT)
        Me.GroupBox11.Controls.Add(Me.txtQ)
        Me.GroupBox11.Controls.Add(Me.Label44)
        Me.GroupBox11.Controls.Add(Me.Label47)
        Me.GroupBox11.Controls.Add(Me.Label37)
        Me.GroupBox11.Location = New System.Drawing.Point(31, 165)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(253, 125)
        Me.GroupBox11.TabIndex = 216
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "容器参数"
        '
        'chkAutoCalLeakP
        '
        Me.chkAutoCalLeakP.AutoSize = True
        Me.chkAutoCalLeakP.Location = New System.Drawing.Point(32, 66)
        Me.chkAutoCalLeakP.Name = "chkAutoCalLeakP"
        Me.chkAutoCalLeakP.Size = New System.Drawing.Size(180, 16)
        Me.chkAutoCalLeakP.TabIndex = 67
        Me.chkAutoCalLeakP.Text = "通过安托因公式计算容器压力"
        Me.C1SuperTooltip1.SetToolTip(Me.chkAutoCalLeakP, resources.GetString("chkAutoCalLeakP.ToolTip"))
        Me.chkAutoCalLeakP.UseVisualStyleBackColor = True
        '
        'txtLeakGasP
        '
        Me.txtLeakGasP.DataType = Chart.DataType.DataDouble
        Me.txtLeakGasP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakGasP.Location = New System.Drawing.Point(143, 88)
        Me.txtLeakGasP.MaxValue = 0
        Me.txtLeakGasP.MinValue = 0
        Me.txtLeakGasP.Name = "txtLeakGasP"
        Me.txtLeakGasP.Size = New System.Drawing.Size(96, 21)
        Me.txtLeakGasP.TabIndex = 21
        Me.txtLeakGasP.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtLeakGasP, resources.GetString("txtLeakGasP.ToolTip"))
        Me.txtLeakGasP.Value = 0
        '
        'txtInT
        '
        Me.txtInT.DataType = Chart.DataType.DataDouble
        Me.txtInT.Location = New System.Drawing.Point(143, 38)
        Me.txtInT.MaxValue = 0
        Me.txtInT.MinValue = 0
        Me.txtInT.Name = "txtInT"
        Me.txtInT.Size = New System.Drawing.Size(96, 21)
        Me.txtInT.TabIndex = 20
        Me.txtInT.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtInT, resources.GetString("txtInT.ToolTip"))
        Me.txtInT.Value = 0
        '
        'txtQ
        '
        Me.txtQ.DataType = Chart.DataType.DataDouble
        Me.txtQ.Location = New System.Drawing.Point(143, 14)
        Me.txtQ.MaxValue = 9999999999
        Me.txtQ.MinValue = 0
        Me.txtQ.Name = "txtQ"
        Me.txtQ.Size = New System.Drawing.Size(96, 21)
        Me.txtQ.TabIndex = 19
        Me.txtQ.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtQ, resources.GetString("txtQ.ToolTip"))
        Me.txtQ.Value = 0
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(66, 17)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(71, 12)
        Me.Label44.TabIndex = 18
        Me.Label44.Text = "贮存量[kg]:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(30, 41)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(107, 12)
        Me.Label47.TabIndex = 16
        Me.Label47.Text = "容器内温度Ts[℃]:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(42, 91)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(95, 12)
        Me.Label37.TabIndex = 17
        Me.Label37.Text = "容器压力 P[Pa]:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label8)
        Me.GroupBox12.Controls.Add(Me.Label9)
        Me.GroupBox12.Controls.Add(Me.txtY)
        Me.GroupBox12.Controls.Add(Me.txtX)
        Me.GroupBox12.Location = New System.Drawing.Point(31, 86)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(253, 72)
        Me.GroupBox12.TabIndex = 225
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "事故源坐标"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(51, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "Y[m]:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(51, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 205
        Me.Label9.Text = "X[m]:"
        '
        'txtY
        '
        Me.txtY.DataType = Chart.DataType.DataInteger
        Me.txtY.Location = New System.Drawing.Point(92, 40)
        Me.txtY.MaxValue = 0
        Me.txtY.MinValue = 0
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(144, 21)
        Me.txtY.TabIndex = 204
        Me.txtY.Text = "0"
        Me.txtY.Value = 0
        '
        'txtX
        '
        Me.txtX.DataType = Chart.DataType.DataInteger
        Me.txtX.Location = New System.Drawing.Point(92, 20)
        Me.txtX.MaxValue = 0
        Me.txtX.MinValue = 0
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(144, 21)
        Me.txtX.TabIndex = 203
        Me.txtX.Text = "0"
        Me.txtX.Value = 0
        '
        'txtLeakSourceName
        '
        Me.txtLeakSourceName.AcceptsReturn = True
        Me.txtLeakSourceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakSourceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakSourceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakSourceName.Location = New System.Drawing.Point(128, 55)
        Me.txtLeakSourceName.MaxLength = 0
        Me.txtLeakSourceName.Name = "txtLeakSourceName"
        Me.txtLeakSourceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakSourceName.Size = New System.Drawing.Size(142, 21)
        Me.txtLeakSourceName.TabIndex = 223
        Me.txtLeakSourceName.Text = "液氨储罐"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(51, 58)
        Me.Label67.Name = "Label67"
        Me.Label67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label67.Size = New System.Drawing.Size(71, 12)
        Me.Label67.TabIndex = 224
        Me.Label67.Text = "事故源名称:"
        '
        'lblQ8
        '
        Me.lblQ8.AutoSize = True
        Me.lblQ8.BackColor = System.Drawing.Color.Transparent
        Me.lblQ8.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQ8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQ8.Location = New System.Drawing.Point(361, 86)
        Me.lblQ8.Name = "lblQ8"
        Me.lblQ8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQ8.Size = New System.Drawing.Size(101, 12)
        Me.lblQ8.TabIndex = 226
        Me.lblQ8.Text = "排放速率Q[kg/s]:"
        Me.lblQ8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtQ0
        '
        Me.txtQ0.DataType = Chart.DataType.DataDouble
        Me.txtQ0.Location = New System.Drawing.Point(468, 83)
        Me.txtQ0.MaxValue = 0
        Me.txtQ0.MinValue = 0
        Me.txtQ0.Name = "txtQ0"
        Me.txtQ0.Size = New System.Drawing.Size(100, 21)
        Me.txtQ0.TabIndex = 227
        Me.txtQ0.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtQ0, resources.GetString("txtQ0.ToolTip"))
        Me.txtQ0.Value = 0
        '
        'cbmSourceType
        '
        Me.cbmSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmSourceType.FormattingEnabled = True
        Me.cbmSourceType.Items.AddRange(New Object() {"点源", "面源", "体源"})
        Me.cbmSourceType.Location = New System.Drawing.Point(468, 55)
        Me.cbmSourceType.Name = "cbmSourceType"
        Me.cbmSourceType.Size = New System.Drawing.Size(100, 20)
        Me.cbmSourceType.TabIndex = 229
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(427, 58)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(35, 12)
        Me.Label49.TabIndex = 228
        Me.Label49.Text = "类型:"
        '
        'LabelS
        '
        Me.LabelS.AutoSize = True
        Me.LabelS.Location = New System.Drawing.Point(367, 113)
        Me.LabelS.Name = "LabelS"
        Me.LabelS.Size = New System.Drawing.Size(95, 12)
        Me.LabelS.TabIndex = 230
        Me.LabelS.Text = "面源面积S[m^2]:"
        '
        'txtS_S
        '
        Me.txtS_S.DataType = Chart.DataType.DataDouble
        Me.txtS_S.Location = New System.Drawing.Point(468, 110)
        Me.txtS_S.MaxValue = 0
        Me.txtS_S.MinValue = 0
        Me.txtS_S.Name = "txtS_S"
        Me.txtS_S.Size = New System.Drawing.Size(100, 21)
        Me.txtS_S.TabIndex = 231
        Me.txtS_S.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtS_S, resources.GetString("txtS_S.ToolTip"))
        Me.txtS_S.Value = 0
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(367, 140)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(95, 12)
        Me.Label29.TabIndex = 233
        Me.Label29.Text = "体源的厚度H[m]:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtThickness
        '
        Me.txtThickness.DataType = Chart.DataType.DataDouble
        Me.txtThickness.Location = New System.Drawing.Point(468, 137)
        Me.txtThickness.MaxValue = 0
        Me.txtThickness.MinValue = 0
        Me.txtThickness.Name = "txtThickness"
        Me.txtThickness.Size = New System.Drawing.Size(100, 21)
        Me.txtThickness.TabIndex = 232
        Me.txtThickness.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtThickness, resources.GetString("txtThickness.ToolTip"))
        Me.txtThickness.Value = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkAutoCalVapP)
        Me.GroupBox5.Controls.Add(Me.txtLeakEvaporationP)
        Me.GroupBox5.Controls.Add(Me.txtSHe)
        Me.GroupBox5.Controls.Add(Me.txtVolatilizationT)
        Me.GroupBox5.Controls.Add(Me.txtS)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.cmbLeakEvaporationGround)
        Me.GroupBox5.Location = New System.Drawing.Point(332, 165)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(253, 166)
        Me.GroupBox5.TabIndex = 235
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "泄漏到地面后的挥发"
        '
        'chkAutoCalVapP
        '
        Me.chkAutoCalVapP.AutoSize = True
        Me.chkAutoCalVapP.Location = New System.Drawing.Point(21, 109)
        Me.chkAutoCalVapP.Name = "chkAutoCalVapP"
        Me.chkAutoCalVapP.Size = New System.Drawing.Size(216, 16)
        Me.chkAutoCalVapP.TabIndex = 67
        Me.chkAutoCalVapP.Text = "通过安托因公式计算液体表面蒸气压"
        Me.C1SuperTooltip1.SetToolTip(Me.chkAutoCalVapP, resources.GetString("chkAutoCalVapP.ToolTip"))
        Me.chkAutoCalVapP.UseVisualStyleBackColor = True
        '
        'txtLeakEvaporationP
        '
        Me.txtLeakEvaporationP.DataType = Chart.DataType.DataDouble
        Me.txtLeakEvaporationP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakEvaporationP.Location = New System.Drawing.Point(137, 131)
        Me.txtLeakEvaporationP.MaxValue = 0
        Me.txtLeakEvaporationP.MinValue = 0
        Me.txtLeakEvaporationP.Name = "txtLeakEvaporationP"
        Me.txtLeakEvaporationP.Size = New System.Drawing.Size(96, 21)
        Me.txtLeakEvaporationP.TabIndex = 65
        Me.txtLeakEvaporationP.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtLeakEvaporationP, resources.GetString("txtLeakEvaporationP.ToolTip"))
        Me.txtLeakEvaporationP.Value = 0
        '
        'txtSHe
        '
        Me.txtSHe.DataType = Chart.DataType.DataDouble
        Me.txtSHe.Location = New System.Drawing.Point(140, 82)
        Me.txtSHe.MaxValue = 0
        Me.txtSHe.MinValue = 0
        Me.txtSHe.Name = "txtSHe"
        Me.txtSHe.Size = New System.Drawing.Size(96, 21)
        Me.txtSHe.TabIndex = 64
        Me.txtSHe.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtSHe, resources.GetString("txtSHe.ToolTip"))
        Me.txtSHe.Value = 0
        '
        'txtVolatilizationT
        '
        Me.txtVolatilizationT.DataType = Chart.DataType.DataDouble
        Me.txtVolatilizationT.Location = New System.Drawing.Point(140, 61)
        Me.txtVolatilizationT.MaxValue = 0
        Me.txtVolatilizationT.MinValue = 0
        Me.txtVolatilizationT.Name = "txtVolatilizationT"
        Me.txtVolatilizationT.Size = New System.Drawing.Size(96, 21)
        Me.txtVolatilizationT.TabIndex = 62
        Me.txtVolatilizationT.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtVolatilizationT, resources.GetString("txtVolatilizationT.ToolTip"))
        Me.txtVolatilizationT.Value = 0
        '
        'txtS
        '
        Me.txtS.DataType = Chart.DataType.DataDouble
        Me.txtS.Location = New System.Drawing.Point(140, 40)
        Me.txtS.MaxValue = 0
        Me.txtS.MinValue = 0
        Me.txtS.Name = "txtS"
        Me.txtS.Size = New System.Drawing.Size(96, 21)
        Me.txtS.TabIndex = 61
        Me.txtS.Text = "0"
        Me.C1SuperTooltip1.SetToolTip(Me.txtS, resources.GetString("txtS.ToolTip"))
        Me.txtS.Value = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(75, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "地面情况:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 12)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "液体表面蒸气压[Pa]:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(33, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 12)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "面源有效高度[m]:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(45, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "围堰面积[m^2]:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(45, 64)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(89, 12)
        Me.Label34.TabIndex = 58
        Me.Label34.Text = "蒸发时间[min]:"
        '
        'cmbLeakEvaporationGround
        '
        Me.cmbLeakEvaporationGround.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLeakEvaporationGround.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbLeakEvaporationGround.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLeakEvaporationGround.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLeakEvaporationGround.Items.AddRange(New Object() {"水泥", "土地(含水8%)", "干阔土地", "湿地", "砂砾地"})
        Me.cmbLeakEvaporationGround.Location = New System.Drawing.Point(140, 20)
        Me.cmbLeakEvaporationGround.Name = "cmbLeakEvaporationGround"
        Me.cmbLeakEvaporationGround.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbLeakEvaporationGround.Size = New System.Drawing.Size(96, 20)
        Me.cmbLeakEvaporationGround.TabIndex = 52
        '
        'txtAirProportion
        '
        Me.txtAirProportion.DataType = Chart.DataType.DataDouble
        Me.txtAirProportion.Location = New System.Drawing.Point(136, 24)
        Me.txtAirProportion.MaxValue = 999999999999
        Me.txtAirProportion.MinValue = 0
        Me.txtAirProportion.Name = "txtAirProportion"
        Me.txtAirProportion.Size = New System.Drawing.Size(96, 21)
        Me.txtAirProportion.TabIndex = 243
        Me.txtAirProportion.Text = "0"
        Me.txtAirProportion.Value = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 12)
        Me.Label4.TabIndex = 242
        Me.Label4.Text = "初始卷入空气的比例:"
        '
        'cmbLeakType
        '
        Me.cmbLeakType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLeakType.FormattingEnabled = True
        Me.cmbLeakType.Items.AddRange(New Object() {"(1)自定义泄漏源", "(2)气体容器小孔、中孔泄漏", "(3)气体容器爆裂", "(4)压力液化气容器液下小孔、中孔泄漏", "(5)压力液化气容器液上小孔、中孔泄漏", "(6)压力液化气容器爆裂", "(7)常压液体容器小孔、中孔泄漏", "(8)常压液体容器爆裂", "(9)压力液化气容器两相流泄漏", "(10)冷冻液化气容器小孔、中孔泄漏", "(11)冷冻液化气容器爆裂"})
        Me.cmbLeakType.Location = New System.Drawing.Point(117, 22)
        Me.cmbLeakType.Name = "cmbLeakType"
        Me.cmbLeakType.Size = New System.Drawing.Size(320, 20)
        Me.cmbLeakType.TabIndex = 246
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 12)
        Me.Label11.TabIndex = 247
        Me.Label11.Text = "泄漏事故类型:"
        '
        'm_OK
        '
        Me.m_OK.Location = New System.Drawing.Point(391, 521)
        Me.m_OK.Name = "m_OK"
        Me.m_OK.Size = New System.Drawing.Size(75, 23)
        Me.m_OK.TabIndex = 248
        Me.m_OK.Text = "确定(&O)"
        Me.m_OK.UseVisualStyleBackColor = True
        '
        'm_Cancel
        '
        Me.m_Cancel.Location = New System.Drawing.Point(472, 521)
        Me.m_Cancel.Name = "m_Cancel"
        Me.m_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.m_Cancel.TabIndex = 249
        Me.m_Cancel.Text = "取消(&C)"
        Me.m_Cancel.UseVisualStyleBackColor = True
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.Images.Add(New C1.Win.C1SuperTooltip.ImageEntry("setup.bmp", CType(resources.GetObject("C1SuperTooltip1.Images"), System.Drawing.Image)))
        '
        'chkIsHeavy
        '
        Me.chkIsHeavy.AutoSize = True
        Me.chkIsHeavy.Location = New System.Drawing.Point(6, 0)
        Me.chkIsHeavy.Name = "chkIsHeavy"
        Me.chkIsHeavy.Size = New System.Drawing.Size(168, 16)
        Me.chkIsHeavy.TabIndex = 250
        Me.chkIsHeavy.Text = "如果是重气体按重气体考虑"
        Me.chkIsHeavy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAirProportion)
        Me.GroupBox1.Controls.Add(Me.chkIsHeavy)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(332, 420)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 60)
        Me.GroupBox1.TabIndex = 251
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "       "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(403, 492)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "事故概率;"
        '
        'txtProbability
        '
        Me.txtProbability.DataType = Chart.DataType.DataDouble
        Me.txtProbability.ForeColor = System.Drawing.Color.Red
        Me.txtProbability.Location = New System.Drawing.Point(468, 486)
        Me.txtProbability.MaxValue = 1
        Me.txtProbability.MinValue = 0.00000000001
        Me.txtProbability.Name = "txtProbability"
        Me.txtProbability.Size = New System.Drawing.Size(96, 21)
        Me.txtProbability.TabIndex = 253
        Me.txtProbability.Text = "0"
        Me.txtProbability.Value = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtPa)
        Me.GroupBox9.Controls.Add(Me.txtTa)
        Me.GroupBox9.Controls.Add(Me.Label12)
        Me.GroupBox9.Controls.Add(Me.Label27)
        Me.GroupBox9.Location = New System.Drawing.Point(332, 337)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(251, 77)
        Me.GroupBox9.TabIndex = 270
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(13, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(95, 12)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "环境温度Ta[℃]:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'frmLeakSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 556)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.txtProbability)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbLeakType)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.LabelS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtThickness)
        Me.Controls.Add(Me.txtLeakSourceName)
        Me.Controls.Add(Me.txtS_S)
        Me.Controls.Add(Me.m_Cancel)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.cbmSourceType)
        Me.Controls.Add(Me.m_OK)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txtQ0)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.lblQ8)
        Me.Name = "frmLeakSource"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "事故泄漏源项"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDurationT As Chart.CText
    Friend WithEvents txtAngle As Chart.CText
    Friend WithEvents txtH As Chart.CText
    Friend WithEvents txtLeakGasA As Chart.CText
    Public WithEvents cmbLeakGasShape As System.Windows.Forms.ComboBox
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents Label45 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLeakGasP As Chart.CText
    Friend WithEvents txtInT As Chart.CText
    Friend WithEvents txtQ As Chart.CText
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents Label47 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtY As Chart.CText
    Friend WithEvents txtX As Chart.CText
    Friend WithEvents txtLeakSourceName As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Public WithEvents lblQ8 As System.Windows.Forms.Label
    Friend WithEvents txtQ0 As Chart.CText
    Friend WithEvents cbmSourceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents LabelS As System.Windows.Forms.Label
    Friend WithEvents txtS_S As Chart.CText
    Public WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtThickness As Chart.CText
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSHe As Chart.CText
    Friend WithEvents txtVolatilizationT As Chart.CText
    Friend WithEvents txtS As Chart.CText
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents cmbLeakEvaporationGround As System.Windows.Forms.ComboBox
    Friend WithEvents txtLeakLiquidHeight As Chart.CText
    Public WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtLeakLiquidCd As Chart.CText
    Public WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtLeakTwoCd As Chart.CText
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAirProportion As Chart.CText
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbLeakType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents m_OK As System.Windows.Forms.Button
    Friend WithEvents m_Cancel As System.Windows.Forms.Button
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents txtLeakEvaporationP As Chart.CText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAutoCalLeakP As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoCalVapP As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsHeavy As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProbability As Chart.CText
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPa As Chart.CText
    Friend WithEvents txtTa As Chart.CText
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
End Class
