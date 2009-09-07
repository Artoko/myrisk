<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakGas
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCalculateLeak = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.FileName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SaveSign = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Command1 = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RichLeakResult = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboLeakGasShape = New System.Windows.Forms.ComboBox
        Me.txtLeakGasA = New System.Windows.Forms.TextBox
        Me.txtLeakGasP = New System.Windows.Forms.TextBox
        Me.txtLeakGasP0 = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtLeakGasM = New System.Windows.Forms.TextBox
        Me.txtLeakGasTG = New System.Windows.Forms.TextBox
        Me.txtLeakGasK = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CheckIsSaved = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(42, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "气体绝热指数κ:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(20, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 25)
        Me.cmdSave.TabIndex = 24
        Me.cmdSave.Text = "保存(&S)"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCalculateLeak
        '
        Me.cmdCalculateLeak.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculateLeak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculateLeak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculateLeak.Location = New System.Drawing.Point(20, 20)
        Me.cmdCalculateLeak.Name = "cmdCalculateLeak"
        Me.cmdCalculateLeak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculateLeak.Size = New System.Drawing.Size(89, 25)
        Me.cmdCalculateLeak.TabIndex = 5
        Me.cmdCalculateLeak.Text = "计算(&C)"
        Me.cmdCalculateLeak.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(36, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(101, 12)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "分子量M[kg/mol]:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FileName
        '
        Me.FileName.AcceptsReturn = True
        Me.FileName.BackColor = System.Drawing.SystemColors.Window
        Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FileName.Location = New System.Drawing.Point(447, 30)
        Me.FileName.MaxLength = 0
        Me.FileName.Name = "FileName"
        Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileName.Size = New System.Drawing.Size(78, 21)
        Me.FileName.TabIndex = 36
        Me.FileName.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(30, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(107, 12)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "气体的温度TG[℃]:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SaveSign
        '
        Me.SaveSign.AcceptsReturn = True
        Me.SaveSign.BackColor = System.Drawing.SystemColors.Window
        Me.SaveSign.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaveSign.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SaveSign.Location = New System.Drawing.Point(348, 30)
        Me.SaveSign.MaxLength = 0
        Me.SaveSign.Name = "SaveSign"
        Me.SaveSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SaveSign.Size = New System.Drawing.Size(76, 21)
        Me.SaveSign.TabIndex = 35
        Me.SaveSign.Text = "LeakGas"
        Me.SaveSign.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(35, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(95, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "环境压力P0[Pa]:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(304, 183)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(149, 25)
        Me.Command1.TabIndex = 34
        Me.Command1.Text = "从数据库中查找物化数据"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(35, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(95, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "裂口面积A[m^2]:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(71, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "裂口形状:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(88, 27)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(177, 21)
        Me.txtName.TabIndex = 31
        Me.txtName.Text = "液氨"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(22, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "物质名称:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(41, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "容器压力P[Pa]:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RichLeakResult)
        Me.GroupBox1.Controls.Add(Me.cmdCalculateLeak)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 123)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "计算结果"
        '
        'RichLeakResult
        '
        Me.RichLeakResult.AcceptsReturn = True
        Me.RichLeakResult.BackColor = System.Drawing.SystemColors.Window
        Me.RichLeakResult.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichLeakResult.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RichLeakResult.Location = New System.Drawing.Point(115, 20)
        Me.RichLeakResult.MaxLength = 0
        Me.RichLeakResult.Multiline = True
        Me.RichLeakResult.Name = "RichLeakResult"
        Me.RichLeakResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RichLeakResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RichLeakResult.Size = New System.Drawing.Size(425, 89)
        Me.RichLeakResult.TabIndex = 37
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboLeakGasShape)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtLeakGasA)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtLeakGasP)
        Me.GroupBox2.Controls.Add(Me.txtLeakGasP0)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(261, 139)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "泄漏参数"
        '
        'cboLeakGasShape
        '
        Me.cboLeakGasShape.BackColor = System.Drawing.SystemColors.Window
        Me.cboLeakGasShape.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLeakGasShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeakGasShape.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLeakGasShape.Items.AddRange(New Object() {"圆  形", "三角形", "长方形"})
        Me.cboLeakGasShape.Location = New System.Drawing.Point(136, 74)
        Me.cboLeakGasShape.Name = "cboLeakGasShape"
        Me.cboLeakGasShape.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLeakGasShape.Size = New System.Drawing.Size(105, 20)
        Me.cboLeakGasShape.TabIndex = 43
        '
        'txtLeakGasA
        '
        Me.txtLeakGasA.AcceptsReturn = True
        Me.txtLeakGasA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakGasA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakGasA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakGasA.Location = New System.Drawing.Point(136, 100)
        Me.txtLeakGasA.MaxLength = 0
        Me.txtLeakGasA.Name = "txtLeakGasA"
        Me.txtLeakGasA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakGasA.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakGasA.TabIndex = 42
        Me.txtLeakGasA.Text = "0.0000785"
        '
        'txtLeakGasP
        '
        Me.txtLeakGasP.AcceptsReturn = True
        Me.txtLeakGasP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakGasP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakGasP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakGasP.Location = New System.Drawing.Point(136, 20)
        Me.txtLeakGasP.MaxLength = 0
        Me.txtLeakGasP.Name = "txtLeakGasP"
        Me.txtLeakGasP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakGasP.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakGasP.TabIndex = 41
        Me.txtLeakGasP.Text = "1170000"
        '
        'txtLeakGasP0
        '
        Me.txtLeakGasP0.AcceptsReturn = True
        Me.txtLeakGasP0.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakGasP0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakGasP0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakGasP0.Location = New System.Drawing.Point(136, 47)
        Me.txtLeakGasP0.MaxLength = 0
        Me.txtLeakGasP0.Name = "txtLeakGasP0"
        Me.txtLeakGasP0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakGasP0.Size = New System.Drawing.Size(105, 21)
        Me.txtLeakGasP0.TabIndex = 40
        Me.txtLeakGasP0.Text = "101325"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtLeakGasM)
        Me.GroupBox3.Controls.Add(Me.txtLeakGasTG)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtLeakGasK)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(304, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(276, 108)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "物料物性"
        '
        'txtLeakGasM
        '
        Me.txtLeakGasM.AcceptsReturn = True
        Me.txtLeakGasM.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakGasM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakGasM.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakGasM.Location = New System.Drawing.Point(143, 20)
        Me.txtLeakGasM.MaxLength = 0
        Me.txtLeakGasM.Name = "txtLeakGasM"
        Me.txtLeakGasM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakGasM.Size = New System.Drawing.Size(117, 21)
        Me.txtLeakGasM.TabIndex = 42
        Me.txtLeakGasM.Text = "0.017"
        '
        'txtLeakGasTG
        '
        Me.txtLeakGasTG.AcceptsReturn = True
        Me.txtLeakGasTG.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakGasTG.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakGasTG.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakGasTG.Location = New System.Drawing.Point(143, 47)
        Me.txtLeakGasTG.MaxLength = 0
        Me.txtLeakGasTG.Name = "txtLeakGasTG"
        Me.txtLeakGasTG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakGasTG.Size = New System.Drawing.Size(117, 21)
        Me.txtLeakGasTG.TabIndex = 41
        Me.txtLeakGasTG.Text = "30"
        '
        'txtLeakGasK
        '
        Me.txtLeakGasK.AcceptsReturn = True
        Me.txtLeakGasK.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakGasK.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakGasK.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakGasK.Location = New System.Drawing.Point(143, 74)
        Me.txtLeakGasK.MaxLength = 0
        Me.txtLeakGasK.Name = "txtLeakGasK"
        Me.txtLeakGasK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakGasK.Size = New System.Drawing.Size(117, 21)
        Me.txtLeakGasK.TabIndex = 40
        Me.txtLeakGasK.Text = "1.310"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CheckIsSaved
        '
        Me.CheckIsSaved.AutoSize = True
        Me.CheckIsSaved.Location = New System.Drawing.Point(447, 47)
        Me.CheckIsSaved.Name = "CheckIsSaved"
        Me.CheckIsSaved.Size = New System.Drawing.Size(96, 16)
        Me.CheckIsSaved.TabIndex = 45
        Me.CheckIsSaved.Text = "CheckIsSaved"
        Me.CheckIsSaved.UseVisualStyleBackColor = True
        Me.CheckIsSaved.Visible = False
        '
        'frmLeakGas
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
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeakGas"
        Me.Text = "气体泄漏量估算"
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
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents cmdCalculateLeak As System.Windows.Forms.Button
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents FileName As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents SaveSign As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents cboLeakGasShape As System.Windows.Forms.ComboBox
    Public WithEvents txtLeakGasA As System.Windows.Forms.TextBox
    Public WithEvents txtLeakGasP As System.Windows.Forms.TextBox
    Public WithEvents txtLeakGasP0 As System.Windows.Forms.TextBox
    Public WithEvents txtLeakGasM As System.Windows.Forms.TextBox
    Public WithEvents txtLeakGasTG As System.Windows.Forms.TextBox
    Public WithEvents txtLeakGasK As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Public WithEvents RichLeakResult As System.Windows.Forms.TextBox
    Friend WithEvents CheckIsSaved As System.Windows.Forms.CheckBox
End Class
