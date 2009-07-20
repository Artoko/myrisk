<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchData
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.txtLMax = New System.Windows.Forms.TextBox
        Me.txtLC50 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCAS = New System.Windows.Forms.TextBox
        Me.txtEnglishName2 = New System.Windows.Forms.TextBox
        Me.txtEnglishName1 = New System.Windows.Forms.TextBox
        Me.txtChineseName2 = New System.Windows.Forms.TextBox
        Me.txtChineseName1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTb = New System.Windows.Forms.TextBox
        Me.txtPg = New System.Windows.Forms.TextBox
        Me.txtPl = New System.Windows.Forms.TextBox
        Me.txtM = New System.Windows.Forms.TextBox
        Me.table28 = New System.Windows.Forms.Label
        Me.Command1 = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me._ListView1_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
        Me._ListView1_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
        Me.Label24 = New System.Windows.Forms.Label
        Me.Command2 = New System.Windows.Forms.Button
        Me.txtGasP = New System.Windows.Forms.TextBox
        Me.txtGasK = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtHc = New System.Windows.Forms.TextBox
        Me.txtCP = New System.Windows.Forms.TextBox
        Me.txtH = New System.Windows.Forms.TextBox
        Me.text5 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbSearchType = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtGasCp = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtOutGasP = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtInT = New System.Windows.Forms.TextBox
        Me.txtOutT = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(451, 465)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "取消"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "确定"
        '
        'txtLMax
        '
        Me.txtLMax.AcceptsReturn = True
        Me.txtLMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtLMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLMax.Location = New System.Drawing.Point(95, 40)
        Me.txtLMax.MaxLength = 0
        Me.txtLMax.Name = "txtLMax"
        Me.txtLMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLMax.Size = New System.Drawing.Size(191, 21)
        Me.txtLMax.TabIndex = 16
        Me.txtLMax.Visible = False
        '
        'txtLC50
        '
        Me.txtLC50.AcceptsReturn = True
        Me.txtLC50.BackColor = System.Drawing.SystemColors.Window
        Me.txtLC50.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLC50.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLC50.Location = New System.Drawing.Point(95, 19)
        Me.txtLC50.MaxLength = 0
        Me.txtLC50.Name = "txtLC50"
        Me.txtLC50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLC50.Size = New System.Drawing.Size(191, 21)
        Me.txtLC50.TabIndex = 17
        Me.txtLC50.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(16, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(125, 12)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "液体密度ρl[kg/m^3]:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(28, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(113, 12)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "摩尔质量M[kg/mol]:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCAS
        '
        Me.txtCAS.AcceptsReturn = True
        Me.txtCAS.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCAS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCAS.Location = New System.Drawing.Point(83, 104)
        Me.txtCAS.MaxLength = 0
        Me.txtCAS.Name = "txtCAS"
        Me.txtCAS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCAS.Size = New System.Drawing.Size(161, 21)
        Me.txtCAS.TabIndex = 32
        '
        'txtEnglishName2
        '
        Me.txtEnglishName2.AcceptsReturn = True
        Me.txtEnglishName2.BackColor = System.Drawing.SystemColors.Window
        Me.txtEnglishName2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEnglishName2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEnglishName2.Location = New System.Drawing.Point(83, 83)
        Me.txtEnglishName2.MaxLength = 0
        Me.txtEnglishName2.Name = "txtEnglishName2"
        Me.txtEnglishName2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEnglishName2.Size = New System.Drawing.Size(161, 21)
        Me.txtEnglishName2.TabIndex = 33
        '
        'txtEnglishName1
        '
        Me.txtEnglishName1.AcceptsReturn = True
        Me.txtEnglishName1.BackColor = System.Drawing.SystemColors.Window
        Me.txtEnglishName1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEnglishName1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEnglishName1.Location = New System.Drawing.Point(83, 62)
        Me.txtEnglishName1.MaxLength = 0
        Me.txtEnglishName1.Name = "txtEnglishName1"
        Me.txtEnglishName1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEnglishName1.Size = New System.Drawing.Size(161, 21)
        Me.txtEnglishName1.TabIndex = 34
        '
        'txtChineseName2
        '
        Me.txtChineseName2.AcceptsReturn = True
        Me.txtChineseName2.BackColor = System.Drawing.SystemColors.Window
        Me.txtChineseName2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtChineseName2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtChineseName2.Location = New System.Drawing.Point(83, 41)
        Me.txtChineseName2.MaxLength = 0
        Me.txtChineseName2.Name = "txtChineseName2"
        Me.txtChineseName2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtChineseName2.Size = New System.Drawing.Size(161, 21)
        Me.txtChineseName2.TabIndex = 35
        '
        'txtChineseName1
        '
        Me.txtChineseName1.AcceptsReturn = True
        Me.txtChineseName1.BackColor = System.Drawing.SystemColors.Window
        Me.txtChineseName1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtChineseName1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtChineseName1.Location = New System.Drawing.Point(83, 20)
        Me.txtChineseName1.MaxLength = 0
        Me.txtChineseName1.Name = "txtChineseName1"
        Me.txtChineseName1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtChineseName1.Size = New System.Drawing.Size(161, 21)
        Me.txtChineseName1.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(36, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "CAS号:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(24, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "英文名2:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "英文名1:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "中文名2:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "中文名1:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(30, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(59, 12)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "允许浓度:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(54, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "LC50:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(125, 12)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "蒸气密度ρg[kg/m^3]:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTb
        '
        Me.txtTb.AcceptsReturn = True
        Me.txtTb.BackColor = System.Drawing.SystemColors.Window
        Me.txtTb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTb.Location = New System.Drawing.Point(147, 83)
        Me.txtTb.MaxLength = 0
        Me.txtTb.Name = "txtTb"
        Me.txtTb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTb.Size = New System.Drawing.Size(97, 21)
        Me.txtTb.TabIndex = 22
        '
        'txtPg
        '
        Me.txtPg.AcceptsReturn = True
        Me.txtPg.BackColor = System.Drawing.SystemColors.Window
        Me.txtPg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPg.Location = New System.Drawing.Point(147, 62)
        Me.txtPg.MaxLength = 0
        Me.txtPg.Name = "txtPg"
        Me.txtPg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPg.Size = New System.Drawing.Size(97, 21)
        Me.txtPg.TabIndex = 23
        '
        'txtPl
        '
        Me.txtPl.AcceptsReturn = True
        Me.txtPl.BackColor = System.Drawing.SystemColors.Window
        Me.txtPl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPl.Location = New System.Drawing.Point(147, 41)
        Me.txtPl.MaxLength = 0
        Me.txtPl.Name = "txtPl"
        Me.txtPl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPl.Size = New System.Drawing.Size(97, 21)
        Me.txtPl.TabIndex = 24
        '
        'txtM
        '
        Me.txtM.AcceptsReturn = True
        Me.txtM.BackColor = System.Drawing.SystemColors.Window
        Me.txtM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtM.Location = New System.Drawing.Point(147, 20)
        Me.txtM.MaxLength = 0
        Me.txtM.Name = "txtM"
        Me.txtM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtM.Size = New System.Drawing.Size(97, 21)
        Me.txtM.TabIndex = 25
        '
        'table28
        '
        Me.table28.AutoSize = True
        Me.table28.BackColor = System.Drawing.SystemColors.Control
        Me.table28.Cursor = System.Windows.Forms.Cursors.Default
        Me.table28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.table28.Location = New System.Drawing.Point(70, 86)
        Me.table28.Name = "table28"
        Me.table28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.table28.Size = New System.Drawing.Size(71, 12)
        Me.table28.TabIndex = 26
        Me.table28.Text = "沸点Tb[℃]:"
        Me.table28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(112, 464)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(41, 25)
        Me.Command1.TabIndex = 69
        Me.Command1.Text = "加密"
        Me.Command1.UseVisualStyleBackColor = False
        Me.Command1.Visible = False
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(322, 5)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(174, 21)
        Me.txtName.TabIndex = 68
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.SystemColors.Window
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._ListView1_ColumnHeader_1, Me._ListView1_ColumnHeader_2, Me._ListView1_ColumnHeader_3, Me._ListView1_ColumnHeader_4, Me._ListView1_ColumnHeader_5})
        Me.ListView1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(12, 59)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(582, 101)
        Me.ListView1.TabIndex = 67
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
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(97, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(89, 12)
        Me.Label24.TabIndex = 13
        Me.Label24.Text = "气化热H[J/kg]:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(159, 464)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(41, 25)
        Me.Command2.TabIndex = 70
        Me.Command2.Text = "解密"
        Me.Command2.UseVisualStyleBackColor = False
        Me.Command2.Visible = False
        '
        'txtGasP
        '
        Me.txtGasP.AcceptsReturn = True
        Me.txtGasP.BackColor = System.Drawing.SystemColors.Window
        Me.txtGasP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGasP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGasP.Location = New System.Drawing.Point(128, 41)
        Me.txtGasP.MaxLength = 0
        Me.txtGasP.Name = "txtGasP"
        Me.txtGasP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGasP.Size = New System.Drawing.Size(157, 21)
        Me.txtGasP.TabIndex = 46
        Me.txtGasP.Visible = False
        '
        'txtGasK
        '
        Me.txtGasK.AcceptsReturn = True
        Me.txtGasK.BackColor = System.Drawing.SystemColors.Window
        Me.txtGasK.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGasK.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGasK.Location = New System.Drawing.Point(128, 20)
        Me.txtGasK.MaxLength = 0
        Me.txtGasK.Name = "txtGasK"
        Me.txtGasK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGasK.Size = New System.Drawing.Size(157, 21)
        Me.txtGasK.TabIndex = 45
        Me.txtGasK.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(9, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(113, 12)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "贮罐内蒸气压P[Pa]:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(27, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(95, 12)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "气体绝热指数κ:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtHc
        '
        Me.txtHc.AcceptsReturn = True
        Me.txtHc.BackColor = System.Drawing.SystemColors.Window
        Me.txtHc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHc.Location = New System.Drawing.Point(192, 44)
        Me.txtHc.MaxLength = 0
        Me.txtHc.Name = "txtHc"
        Me.txtHc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHc.Size = New System.Drawing.Size(93, 21)
        Me.txtHc.TabIndex = 9
        Me.txtHc.Visible = False
        '
        'txtCP
        '
        Me.txtCP.AcceptsReturn = True
        Me.txtCP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCP.Location = New System.Drawing.Point(192, 65)
        Me.txtCP.MaxLength = 0
        Me.txtCP.Name = "txtCP"
        Me.txtCP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCP.Size = New System.Drawing.Size(93, 21)
        Me.txtCP.TabIndex = 8
        Me.txtCP.Visible = False
        '
        'txtH
        '
        Me.txtH.AcceptsReturn = True
        Me.txtH.BackColor = System.Drawing.SystemColors.Window
        Me.txtH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtH.Location = New System.Drawing.Point(192, 23)
        Me.txtH.MaxLength = 0
        Me.txtH.Name = "txtH"
        Me.txtH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtH.Size = New System.Drawing.Size(93, 21)
        Me.txtH.TabIndex = 10
        Me.txtH.Visible = False
        '
        'text5
        '
        Me.text5.AutoSize = True
        Me.text5.BackColor = System.Drawing.SystemColors.Control
        Me.text5.Cursor = System.Windows.Forms.Cursors.Default
        Me.text5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.text5.Location = New System.Drawing.Point(25, 68)
        Me.text5.Name = "text5"
        Me.text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.text5.Size = New System.Drawing.Size(161, 12)
        Me.text5.TabIndex = 11
        Me.text5.Text = "液体定压比热CP[J/(kg·K)]:"
        Me.text5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(67, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(119, 12)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "物质燃烧热Hc[J/kg]:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbSearchType
        '
        Me.cmbSearchType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSearchType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSearchType.Items.AddRange(New Object() {"中文名", "英文名", "CAS号"})
        Me.cmbSearchType.Location = New System.Drawing.Point(77, 6)
        Me.cmbSearchType.Name = "cmbSearchType"
        Me.cmbSearchType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSearchType.Size = New System.Drawing.Size(174, 20)
        Me.cmbSearchType.TabIndex = 58
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearch.Location = New System.Drawing.Point(504, 5)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearch.Size = New System.Drawing.Size(90, 21)
        Me.cmdSearch.TabIndex = 57
        Me.cmdSearch.Text = "查找(&S)"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(257, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "查找内容:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "查找方式:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCAS)
        Me.GroupBox1.Controls.Add(Me.txtChineseName1)
        Me.GroupBox1.Controls.Add(Me.txtEnglishName2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEnglishName1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtChineseName2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 137)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本数据"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtGasCp)
        Me.GroupBox2.Controls.Add(Me.txtCP)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtHc)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtH)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.text5)
        Me.GroupBox2.Location = New System.Drawing.Point(292, 166)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 118)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物化数据"
        '
        'txtGasCp
        '
        Me.txtGasCp.Location = New System.Drawing.Point(192, 86)
        Me.txtGasCp.Name = "txtGasCp"
        Me.txtGasCp.Size = New System.Drawing.Size(93, 21)
        Me.txtGasCp.TabIndex = 14
        Me.txtGasCp.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(29, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(161, 12)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "气体定压比热CP[J/(kg·K)]:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtOutGasP)
        Me.GroupBox3.Controls.Add(Me.txtGasP)
        Me.GroupBox3.Controls.Add(Me.txtGasK)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(292, 290)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(302, 88)
        Me.GroupBox3.TabIndex = 73
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "与温度相关的数据"
        '
        'txtOutGasP
        '
        Me.txtOutGasP.AcceptsReturn = True
        Me.txtOutGasP.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutGasP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutGasP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutGasP.Location = New System.Drawing.Point(128, 62)
        Me.txtOutGasP.MaxLength = 0
        Me.txtOutGasP.Name = "txtOutGasP"
        Me.txtOutGasP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOutGasP.Size = New System.Drawing.Size(157, 21)
        Me.txtOutGasP.TabIndex = 46
        Me.txtOutGasP.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(21, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(101, 12)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "环境蒸气压P[Pa]:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtLMax)
        Me.GroupBox4.Controls.Add(Me.txtLC50)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Location = New System.Drawing.Point(291, 384)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(303, 75)
        Me.GroupBox4.TabIndex = 74
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "毒性数据"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtTb)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.txtPg)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.txtPl)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtM)
        Me.GroupBox5.Controls.Add(Me.table28)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 309)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(264, 122)
        Me.GroupBox5.TabIndex = 75
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "物理数据"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(12, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(101, 12)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "贮罐内温度T[℃]:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtInT
        '
        Me.txtInT.AcceptsReturn = True
        Me.txtInT.BackColor = System.Drawing.SystemColors.Window
        Me.txtInT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInT.Location = New System.Drawing.Point(119, 32)
        Me.txtInT.MaxLength = 0
        Me.txtInT.Name = "txtInT"
        Me.txtInT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInT.Size = New System.Drawing.Size(132, 21)
        Me.txtInT.TabIndex = 77
        Me.txtInT.Text = "30"
        Me.txtInT.Visible = False
        '
        'txtOutT
        '
        Me.txtOutT.AcceptsReturn = True
        Me.txtOutT.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutT.Location = New System.Drawing.Point(352, 32)
        Me.txtOutT.MaxLength = 0
        Me.txtOutT.Name = "txtOutT"
        Me.txtOutT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOutT.Size = New System.Drawing.Size(144, 21)
        Me.txtOutT.TabIndex = 77
        Me.txtOutT.Text = "16"
        Me.txtOutT.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(257, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(89, 12)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "环境温度T[℃]:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmSearchData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(609, 503)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtOutT)
        Me.Controls.Add(Me.txtInT)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.cmbSearchType)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "在数据库中查找..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Public WithEvents txtLMax As System.Windows.Forms.TextBox
    Public WithEvents txtLC50 As System.Windows.Forms.TextBox
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents txtCAS As System.Windows.Forms.TextBox
    Public WithEvents txtEnglishName2 As System.Windows.Forms.TextBox
    Public WithEvents txtEnglishName1 As System.Windows.Forms.TextBox
    Public WithEvents txtChineseName2 As System.Windows.Forms.TextBox
    Public WithEvents txtChineseName1 As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txtTb As System.Windows.Forms.TextBox
    Public WithEvents txtPg As System.Windows.Forms.TextBox
    Public WithEvents txtPl As System.Windows.Forms.TextBox
    Public WithEvents txtM As System.Windows.Forms.TextBox
    Public WithEvents table28 As System.Windows.Forms.Label
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents ListView1 As System.Windows.Forms.ListView
    Public WithEvents _ListView1_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
    Public WithEvents _ListView1_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents txtGasP As System.Windows.Forms.TextBox
    Public WithEvents txtGasK As System.Windows.Forms.TextBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents txtHc As System.Windows.Forms.TextBox
    Public WithEvents txtCP As System.Windows.Forms.TextBox
    Public WithEvents txtH As System.Windows.Forms.TextBox
    Public WithEvents text5 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents cmbSearchType As System.Windows.Forms.ComboBox
    Public WithEvents cmdSearch As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents txtInT As System.Windows.Forms.TextBox
    Public WithEvents txtOutT As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents txtOutGasP As System.Windows.Forms.TextBox
    Public WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtGasCp As System.Windows.Forms.TextBox
    Public WithEvents Label18 As System.Windows.Forms.Label

End Class
