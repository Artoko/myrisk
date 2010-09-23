<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhysicsExplode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhysicsExplode))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPw = New Chart.CText
        Me.txtVw = New Chart.CText
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBt = New Chart.CText
        Me.txtVl = New Chart.CText
        Me.txtPl = New Chart.CText
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.txtW = New Chart.CText
        Me.txtS2 = New Chart.CText
        Me.txtS1 = New Chart.CText
        Me.txtH2 = New Chart.CText
        Me.txtH1 = New Chart.CText
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtKg = New Chart.CText
        Me.txtVg = New Chart.CText
        Me.txtPg = New Chart.CText
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtsdfasdf = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtVs = New Chart.CText
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtPs = New Chart.CText
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtX = New Chart.CText
        Me.txtY = New Chart.CText
        Me.txtLeakSourceName = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.cmdSeachData = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CTextStep = New Chart.CText
        Me.groupbox = New System.Windows.Forms.GroupBox
        Me.EFlexDistance = New Chart.EFlex
        Me.cmdForcastAdd = New System.Windows.Forms.Button
        Me.cmdForecastDelete = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdDamageAdd = New System.Windows.Forms.Button
        Me.EFlex1 = New Chart.EFlex
        Me.cmdDamageDelete = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.CTextCount = New Chart.CText
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.GroupBoxForecastPoint = New System.Windows.Forms.GroupBox
        Me.txtMaxY = New Chart.CText
        Me.txtMinY = New Chart.CText
        Me.txtMaxX = New Chart.CText
        Me.txtMinX = New Chart.CText
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.groupbox.SuspendLayout()
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EFlex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxForecastPoint.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbType)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.txtLeakSourceName)
        Me.TabPage1.Controls.Add(Me.Label66)
        Me.TabPage1.Controls.Add(Me.Label1)
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
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"压缩气体容器爆炸", "饱和蒸汽容器爆炸", "介质全部为液体时容器爆炸", "液化气体容器爆炸", "饱和水容器爆炸"})
        Me.cmbType.Location = New System.Drawing.Point(378, 24)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(183, 20)
        Me.cmbType.TabIndex = 73
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(289, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 12)
        Me.Label20.TabIndex = 72
        Me.Label20.Text = "选择爆炸模型:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Location = New System.Drawing.Point(274, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 147)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "参数"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.txtPw)
        Me.Panel5.Controls.Add(Me.txtVw)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Location = New System.Drawing.Point(26, 410)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(305, 65)
        Me.Panel5.TabIndex = 83
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(137, 12)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "饱和水容器的压力P[Pa]:"
        '
        'txtPw
        '
        Me.txtPw.DataType = Chart.DataType.DataDouble
        Me.txtPw.Location = New System.Drawing.Point(183, 30)
        Me.txtPw.MaxValue = 0
        Me.txtPw.MinValue = 0
        Me.txtPw.Name = "txtPw"
        Me.txtPw.Size = New System.Drawing.Size(87, 21)
        Me.txtPw.TabIndex = 0
        Me.txtPw.Text = "0"
        Me.txtPw.Value = 0
        '
        'txtVw
        '
        Me.txtVw.DataType = Chart.DataType.DataDouble
        Me.txtVw.Location = New System.Drawing.Point(183, 3)
        Me.txtVw.MaxValue = 0
        Me.txtVw.MinValue = 0
        Me.txtVw.Name = "txtVw"
        Me.txtVw.Size = New System.Drawing.Size(87, 21)
        Me.txtVw.TabIndex = 0
        Me.txtVw.Text = "0"
        Me.txtVw.Value = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(-2, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(179, 12)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "容器内饱和水所占的体积V[m^3]:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtBt)
        Me.Panel3.Controls.Add(Me.txtVl)
        Me.Panel3.Controls.Add(Me.txtPl)
        Me.Panel3.Location = New System.Drawing.Point(26, 175)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(305, 100)
        Me.Panel3.TabIndex = 82
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(69, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 12)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "液体压缩系数Bt:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(57, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 12)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "容器的体积V[m^3]:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "液体的绝对压力P[Pa]:"
        '
        'txtBt
        '
        Me.txtBt.DataType = Chart.DataType.DataDouble
        Me.txtBt.Location = New System.Drawing.Point(170, 57)
        Me.txtBt.MaxValue = 0
        Me.txtBt.MinValue = 0
        Me.txtBt.Name = "txtBt"
        Me.txtBt.Size = New System.Drawing.Size(100, 21)
        Me.txtBt.TabIndex = 0
        Me.txtBt.Text = "0"
        Me.txtBt.Value = 0
        '
        'txtVl
        '
        Me.txtVl.DataType = Chart.DataType.DataDouble
        Me.txtVl.Location = New System.Drawing.Point(170, 30)
        Me.txtVl.MaxValue = 0
        Me.txtVl.MinValue = 0
        Me.txtVl.Name = "txtVl"
        Me.txtVl.Size = New System.Drawing.Size(100, 21)
        Me.txtVl.TabIndex = 0
        Me.txtVl.Text = "0"
        Me.txtVl.Value = 0
        '
        'txtPl
        '
        Me.txtPl.DataType = Chart.DataType.DataDouble
        Me.txtPl.Location = New System.Drawing.Point(170, 3)
        Me.txtPl.MaxValue = 0
        Me.txtPl.MinValue = 0
        Me.txtPl.Name = "txtPl"
        Me.txtPl.Size = New System.Drawing.Size(100, 21)
        Me.txtPl.TabIndex = 0
        Me.txtPl.Text = "0"
        Me.txtPl.Value = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txtW)
        Me.Panel4.Controls.Add(Me.txtS2)
        Me.Panel4.Controls.Add(Me.txtS1)
        Me.Panel4.Controls.Add(Me.txtH2)
        Me.Panel4.Controls.Add(Me.txtH1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Location = New System.Drawing.Point(26, 281)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(305, 123)
        Me.Panel4.TabIndex = 81
        '
        'txtW
        '
        Me.txtW.DataType = Chart.DataType.DataDouble
        Me.txtW.Location = New System.Drawing.Point(200, 87)
        Me.txtW.MaxValue = 0
        Me.txtW.MinValue = 0
        Me.txtW.Name = "txtW"
        Me.txtW.Size = New System.Drawing.Size(70, 21)
        Me.txtW.TabIndex = 4
        Me.txtW.Text = "0"
        Me.txtW.Value = 0
        '
        'txtS2
        '
        Me.txtS2.DataType = Chart.DataType.DataDouble
        Me.txtS2.Location = New System.Drawing.Point(200, 66)
        Me.txtS2.MaxValue = 0
        Me.txtS2.MinValue = 0
        Me.txtS2.Name = "txtS2"
        Me.txtS2.Size = New System.Drawing.Size(70, 21)
        Me.txtS2.TabIndex = 4
        Me.txtS2.Text = "0"
        Me.txtS2.Value = 0
        '
        'txtS1
        '
        Me.txtS1.DataType = Chart.DataType.DataDouble
        Me.txtS1.Location = New System.Drawing.Point(200, 45)
        Me.txtS1.MaxValue = 0
        Me.txtS1.MinValue = 0
        Me.txtS1.Name = "txtS1"
        Me.txtS1.Size = New System.Drawing.Size(70, 21)
        Me.txtS1.TabIndex = 4
        Me.txtS1.Text = "0"
        Me.txtS1.Value = 0
        '
        'txtH2
        '
        Me.txtH2.DataType = Chart.DataType.DataDouble
        Me.txtH2.Location = New System.Drawing.Point(200, 24)
        Me.txtH2.MaxValue = 0
        Me.txtH2.MinValue = 0
        Me.txtH2.Name = "txtH2"
        Me.txtH2.Size = New System.Drawing.Size(70, 21)
        Me.txtH2.TabIndex = 4
        Me.txtH2.Text = "0"
        Me.txtH2.Value = 0
        '
        'txtH1
        '
        Me.txtH1.DataType = Chart.DataType.DataDouble
        Me.txtH1.Location = New System.Drawing.Point(200, 3)
        Me.txtH1.MaxValue = 0
        Me.txtH1.MinValue = 0
        Me.txtH1.Name = "txtH1"
        Me.txtH1.Size = New System.Drawing.Size(70, 21)
        Me.txtH1.TabIndex = 4
        Me.txtH1.Text = "0"
        Me.txtH1.Value = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "饱和液体的质量W[kg]:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "大气压下饱和液体熵S2[J/(kg.K)]:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(191, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "爆炸前饱和液体的熵S1[J/(kg.K)]:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(179, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "大气压力下饱和液体焓H2[J/kg]:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(45, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 12)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "爆炸前液化气体的焓H1[J]:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtKg)
        Me.Panel1.Controls.Add(Me.txtVg)
        Me.Panel1.Controls.Add(Me.txtPg)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtsdfasdf)
        Me.Panel1.Location = New System.Drawing.Point(26, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(305, 87)
        Me.Panel1.TabIndex = 80
        '
        'txtKg
        '
        Me.txtKg.DataType = Chart.DataType.DataDouble
        Me.txtKg.Location = New System.Drawing.Point(170, 57)
        Me.txtKg.MaxValue = 2
        Me.txtKg.MinValue = 1
        Me.txtKg.Name = "txtKg"
        Me.txtKg.Size = New System.Drawing.Size(100, 21)
        Me.txtKg.TabIndex = 31
        Me.txtKg.Text = "0"
        Me.txtKg.Value = 0
        '
        'txtVg
        '
        Me.txtVg.DataType = Chart.DataType.DataDouble
        Me.txtVg.Location = New System.Drawing.Point(170, 30)
        Me.txtVg.MaxValue = 999999999999
        Me.txtVg.MinValue = 0
        Me.txtVg.Name = "txtVg"
        Me.txtVg.Size = New System.Drawing.Size(100, 21)
        Me.txtVg.TabIndex = 30
        Me.txtVg.Text = "0"
        Me.txtVg.Value = 0
        '
        'txtPg
        '
        Me.txtPg.DataType = Chart.DataType.DataDouble
        Me.txtPg.Location = New System.Drawing.Point(170, 3)
        Me.txtPg.MaxValue = 9999999999999
        Me.txtPg.MinValue = 0
        Me.txtPg.Name = "txtPg"
        Me.txtPg.Size = New System.Drawing.Size(100, 21)
        Me.txtPg.TabIndex = 29
        Me.txtPg.Text = "0"
        Me.txtPg.Value = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(3, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(161, 12)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "容器内气体的绝对压力P[Pa]:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(63, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(101, 12)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "气体的绝热指数k:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtsdfasdf
        '
        Me.txtsdfasdf.AutoSize = True
        Me.txtsdfasdf.BackColor = System.Drawing.Color.Transparent
        Me.txtsdfasdf.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtsdfasdf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtsdfasdf.Location = New System.Drawing.Point(57, 33)
        Me.txtsdfasdf.Name = "txtsdfasdf"
        Me.txtsdfasdf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtsdfasdf.Size = New System.Drawing.Size(107, 12)
        Me.txtsdfasdf.TabIndex = 28
        Me.txtsdfasdf.Text = "容器的体积V[m^3]:"
        Me.txtsdfasdf.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtVs)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtPs)
        Me.Panel2.Location = New System.Drawing.Point(26, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(305, 60)
        Me.Panel2.TabIndex = 79
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(57, 34)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 12)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "蒸汽的体积V[m^3]:"
        '
        'txtVs
        '
        Me.txtVs.DataType = Chart.DataType.DataDouble
        Me.txtVs.Location = New System.Drawing.Point(170, 31)
        Me.txtVs.MaxValue = 0
        Me.txtVs.MinValue = 0
        Me.txtVs.Name = "txtVs"
        Me.txtVs.Size = New System.Drawing.Size(100, 21)
        Me.txtVs.TabIndex = 2
        Me.txtVs.Text = "0"
        Me.txtVs.Value = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(21, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(143, 12)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "饱和蒸汽容器的压力[Pa]:"
        '
        'txtPs
        '
        Me.txtPs.DataType = Chart.DataType.DataDouble
        Me.txtPs.Location = New System.Drawing.Point(170, 6)
        Me.txtPs.MaxValue = 0
        Me.txtPs.MinValue = 0
        Me.txtPs.Name = "txtPs"
        Me.txtPs.Size = New System.Drawing.Size(100, 21)
        Me.txtPs.TabIndex = 0
        Me.txtPs.Text = "0"
        Me.txtPs.Value = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtX)
        Me.GroupBox4.Controls.Add(Me.txtY)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 117)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(237, 81)
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
        '
        'cmdSeachData
        '
        Me.cmdSeachData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeachData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSeachData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeachData.Location = New System.Drawing.Point(274, 212)
        Me.cmdSeachData.Name = "cmdSeachData"
        Me.cmdSeachData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSeachData.Size = New System.Drawing.Size(149, 25)
        Me.cmdSeachData.TabIndex = 62
        Me.cmdSeachData.Text = "从数据库中查找物化数据"
        Me.cmdSeachData.UseVisualStyleBackColor = True
        Me.cmdSeachData.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
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
        'CTextStep
        '
        Me.CTextStep.DataType = Chart.DataType.DataDouble
        Me.CTextStep.Location = New System.Drawing.Point(67, 35)
        Me.CTextStep.MaxValue = 9999999999
        Me.CTextStep.MinValue = 1
        Me.CTextStep.Name = "CTextStep"
        Me.CTextStep.Size = New System.Drawing.Size(77, 21)
        Me.CTextStep.TabIndex = 73
        Me.CTextStep.Text = "1"
        Me.CTextStep.Value = 1
        '
        'groupbox
        '
        Me.groupbox.Controls.Add(Me.EFlexDistance)
        Me.groupbox.Controls.Add(Me.cmdForcastAdd)
        Me.groupbox.Controls.Add(Me.cmdForecastDelete)
        Me.groupbox.Location = New System.Drawing.Point(18, 23)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(276, 226)
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
        Me.EFlexDistance.Size = New System.Drawing.Size(264, 171)
        Me.EFlexDistance.StyleInfo = resources.GetString("EFlexDistance.StyleInfo")
        Me.EFlexDistance.TabIndex = 67
        '
        'cmdForcastAdd
        '
        Me.cmdForcastAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdForcastAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdForcastAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdForcastAdd.Location = New System.Drawing.Point(32, 197)
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
        Me.cmdForecastDelete.Location = New System.Drawing.Point(157, 197)
        Me.cmdForecastDelete.Name = "cmdForecastDelete"
        Me.cmdForecastDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdForecastDelete.Size = New System.Drawing.Size(67, 23)
        Me.cmdForecastDelete.TabIndex = 32
        Me.cmdForecastDelete.Text = "删除(&D)"
        Me.cmdForecastDelete.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(168, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "个数:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdDamageAdd)
        Me.GroupBox3.Controls.Add(Me.EFlex1)
        Me.GroupBox3.Controls.Add(Me.cmdDamageDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(316, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(313, 226)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算超压伤害范围"
        '
        'cmdDamageAdd
        '
        Me.cmdDamageAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageAdd.Location = New System.Drawing.Point(43, 197)
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
        Me.EFlex1.Size = New System.Drawing.Size(294, 171)
        Me.EFlex1.StyleInfo = resources.GetString("EFlex1.StyleInfo")
        Me.EFlex1.TabIndex = 75
        '
        'cmdDamageDelete
        '
        Me.cmdDamageDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDamageDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDamageDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDamageDelete.Location = New System.Drawing.Point(173, 197)
        Me.cmdDamageDelete.Name = "cmdDamageDelete"
        Me.cmdDamageDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDamageDelete.Size = New System.Drawing.Size(67, 23)
        Me.cmdDamageDelete.TabIndex = 40
        Me.cmdDamageDelete.Text = "删除(&D)"
        Me.cmdDamageDelete.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "步长(m):"
        '
        'CTextCount
        '
        Me.CTextCount.DataType = Chart.DataType.DataDouble
        Me.CTextCount.Location = New System.Drawing.Point(209, 35)
        Me.CTextCount.MaxValue = 9999999999999
        Me.CTextCount.MinValue = 1
        Me.CTextCount.Name = "CTextCount"
        Me.CTextCount.Size = New System.Drawing.Size(77, 21)
        Me.CTextCount.TabIndex = 74
        Me.CTextCount.Text = "0"
        Me.CTextCount.Value = 0
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 21)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(629, 243)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "计算选项"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(295, 394)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "确定(&O)"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(391, 394)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "取消(&C)"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBoxForecastPoint
        '
        Me.GroupBoxForecastPoint.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMaxY)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinY)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMaxX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label21)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label22)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label23)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label24)
        Me.GroupBoxForecastPoint.Location = New System.Drawing.Point(18, 255)
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
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(6, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(47, 12)
        Me.Label21.TabIndex = 202
        Me.Label21.Text = "x轴[m]:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(149, 44)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(11, 12)
        Me.Label22.TabIndex = 206
        Me.Label22.Text = "-"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(149, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(11, 12)
        Me.Label23.TabIndex = 206
        Me.Label23.Text = "-"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(6, 44)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(47, 12)
        Me.Label24.TabIndex = 206
        Me.Label24.Text = "y轴[m]:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CTextStep)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.CTextCount)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(320, 255)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(308, 71)
        Me.GroupBox2.TabIndex = 270
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "距事故源中心的距离"
        '
        'frmPhysicsExplode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 420)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmPhysicsExplode"
        Me.Text = "物理爆炸模型"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.groupbox.ResumeLayout(False)
        CType(Me.EFlexDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.EFlex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxForecastPoint.ResumeLayout(False)
        Me.GroupBoxForecastPoint.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtX As Chart.CText
    Friend WithEvents txtY As Chart.CText
    Public WithEvents txtLeakSourceName As System.Windows.Forms.TextBox
    Public WithEvents Label66 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents cmdSeachData As System.Windows.Forms.Button
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
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPw As Chart.CText
    Friend WithEvents txtVw As Chart.CText
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBt As Chart.CText
    Friend WithEvents txtVl As Chart.CText
    Friend WithEvents txtPl As Chart.CText
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtW As Chart.CText
    Friend WithEvents txtS2 As Chart.CText
    Friend WithEvents txtS1 As Chart.CText
    Friend WithEvents txtH2 As Chart.CText
    Friend WithEvents txtH1 As Chart.CText
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtKg As Chart.CText
    Friend WithEvents txtVg As Chart.CText
    Friend WithEvents txtPg As Chart.CText
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents txtsdfasdf As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtVs As Chart.CText
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPs As Chart.CText
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxForecastPoint As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As Chart.CText
    Friend WithEvents txtMinY As Chart.CText
    Friend WithEvents txtMaxX As Chart.CText
    Friend WithEvents txtMinX As Chart.CText
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
End Class
