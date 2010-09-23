<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeakQuality
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
        Me.SaveSign = New System.Windows.Forms.TextBox
        Me.FileName = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.RichLeakResult = New System.Windows.Forms.TextBox
        Me.cmdCalculateLeak = New System.Windows.Forms.Button
        Me.txtLeakEvaporationM = New System.Windows.Forms.TextBox
        Me.txtLeakEvaporationP = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtLeakEvaporationS = New System.Windows.Forms.TextBox
        Me.txtLeakEvaporationT0 = New System.Windows.Forms.TextBox
        Me.txtLeakEvaporationu = New System.Windows.Forms.TextBox
        Me.cboLeakEvaporationStab = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckIsSaved = New System.Windows.Forms.CheckBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveSign
        '
        Me.SaveSign.AcceptsReturn = True
        Me.SaveSign.BackColor = System.Drawing.SystemColors.Window
        Me.SaveSign.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaveSign.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SaveSign.Location = New System.Drawing.Point(354, 14)
        Me.SaveSign.MaxLength = 0
        Me.SaveSign.Name = "SaveSign"
        Me.SaveSign.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SaveSign.Size = New System.Drawing.Size(41, 21)
        Me.SaveSign.TabIndex = 33
        Me.SaveSign.Text = "LeakQuality"
        Me.SaveSign.Visible = False
        '
        'FileName
        '
        Me.FileName.AcceptsReturn = True
        Me.FileName.BackColor = System.Drawing.SystemColors.Window
        Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FileName.Location = New System.Drawing.Point(406, 14)
        Me.FileName.MaxLength = 0
        Me.FileName.Name = "FileName"
        Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FileName.Size = New System.Drawing.Size(61, 21)
        Me.FileName.TabIndex = 32
        Me.FileName.Visible = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(309, 147)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(149, 25)
        Me.Command1.TabIndex = 31
        Me.Command1.Text = "从数据库中查找物化数据"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(91, 22)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(161, 21)
        Me.txtName.TabIndex = 29
        Me.txtName.Text = "液氨"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(15, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(89, 25)
        Me.cmdSave.TabIndex = 22
        Me.cmdSave.Text = "保存(&S)"
        Me.cmdSave.UseVisualStyleBackColor = True
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
        Me.RichLeakResult.Size = New System.Drawing.Size(416, 87)
        Me.RichLeakResult.TabIndex = 5
        '
        'cmdCalculateLeak
        '
        Me.cmdCalculateLeak.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculateLeak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculateLeak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculateLeak.Location = New System.Drawing.Point(15, 20)
        Me.cmdCalculateLeak.Name = "cmdCalculateLeak"
        Me.cmdCalculateLeak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculateLeak.Size = New System.Drawing.Size(89, 25)
        Me.cmdCalculateLeak.TabIndex = 4
        Me.cmdCalculateLeak.Text = "计算(&C)"
        Me.cmdCalculateLeak.UseVisualStyleBackColor = True
        '
        'txtLeakEvaporationM
        '
        Me.txtLeakEvaporationM.AcceptsReturn = True
        Me.txtLeakEvaporationM.BackColor = System.Drawing.Color.White
        Me.txtLeakEvaporationM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationM.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakEvaporationM.Location = New System.Drawing.Point(143, 47)
        Me.txtLeakEvaporationM.MaxLength = 0
        Me.txtLeakEvaporationM.Name = "txtLeakEvaporationM"
        Me.txtLeakEvaporationM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationM.Size = New System.Drawing.Size(93, 21)
        Me.txtLeakEvaporationM.TabIndex = 19
        Me.txtLeakEvaporationM.Text = "0.017"
        '
        'txtLeakEvaporationP
        '
        Me.txtLeakEvaporationP.AcceptsReturn = True
        Me.txtLeakEvaporationP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationP.ForeColor = System.Drawing.Color.Blue
        Me.txtLeakEvaporationP.Location = New System.Drawing.Point(143, 20)
        Me.txtLeakEvaporationP.MaxLength = 0
        Me.txtLeakEvaporationP.Name = "txtLeakEvaporationP"
        Me.txtLeakEvaporationP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationP.Size = New System.Drawing.Size(93, 21)
        Me.txtLeakEvaporationP.TabIndex = 18
        Me.txtLeakEvaporationP.Text = "60662"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(24, 50)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(113, 12)
        Me.Label34.TabIndex = 21
        Me.Label34.Text = "摩尔质量M[kg/mol]:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(12, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(125, 12)
        Me.Label30.TabIndex = 20
        Me.Label30.Text = "液体表面蒸气压P[Pa]:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLeakEvaporationS
        '
        Me.txtLeakEvaporationS.AcceptsReturn = True
        Me.txtLeakEvaporationS.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakEvaporationS.Location = New System.Drawing.Point(145, 20)
        Me.txtLeakEvaporationS.MaxLength = 0
        Me.txtLeakEvaporationS.Name = "txtLeakEvaporationS"
        Me.txtLeakEvaporationS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationS.Size = New System.Drawing.Size(93, 21)
        Me.txtLeakEvaporationS.TabIndex = 12
        Me.txtLeakEvaporationS.Text = "5"
        '
        'txtLeakEvaporationT0
        '
        Me.txtLeakEvaporationT0.AcceptsReturn = True
        Me.txtLeakEvaporationT0.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationT0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationT0.ForeColor = System.Drawing.Color.Black
        Me.txtLeakEvaporationT0.Location = New System.Drawing.Point(145, 74)
        Me.txtLeakEvaporationT0.MaxLength = 0
        Me.txtLeakEvaporationT0.Name = "txtLeakEvaporationT0"
        Me.txtLeakEvaporationT0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationT0.Size = New System.Drawing.Size(93, 21)
        Me.txtLeakEvaporationT0.TabIndex = 11
        Me.txtLeakEvaporationT0.Text = "30"
        '
        'txtLeakEvaporationu
        '
        Me.txtLeakEvaporationu.AcceptsReturn = True
        Me.txtLeakEvaporationu.BackColor = System.Drawing.SystemColors.Window
        Me.txtLeakEvaporationu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLeakEvaporationu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLeakEvaporationu.Location = New System.Drawing.Point(145, 47)
        Me.txtLeakEvaporationu.MaxLength = 0
        Me.txtLeakEvaporationu.Name = "txtLeakEvaporationu"
        Me.txtLeakEvaporationu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLeakEvaporationu.Size = New System.Drawing.Size(93, 21)
        Me.txtLeakEvaporationu.TabIndex = 10
        Me.txtLeakEvaporationu.Text = "2.0"
        '
        'cboLeakEvaporationStab
        '
        Me.cboLeakEvaporationStab.BackColor = System.Drawing.SystemColors.Window
        Me.cboLeakEvaporationStab.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLeakEvaporationStab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeakEvaporationStab.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLeakEvaporationStab.Items.AddRange(New Object() {"不稳定(A，B)", "中性(D)", "稳定(E，F)"})
        Me.cboLeakEvaporationStab.Location = New System.Drawing.Point(145, 101)
        Me.cboLeakEvaporationStab.Name = "cboLeakEvaporationStab"
        Me.cboLeakEvaporationStab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLeakEvaporationStab.Size = New System.Drawing.Size(93, 20)
        Me.cboLeakEvaporationStab.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(44, 23)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(95, 12)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "液池面积S[m^2];"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(44, 77)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(95, 12)
        Me.Label25.TabIndex = 15
        Me.Label25.Text = "环境温度T0[℃]:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(20, 50)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(119, 12)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "液体表面风速u[m/s]:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(68, 104)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(71, 12)
        Me.Label32.TabIndex = 13
        Me.Label32.Text = "大气稳定度:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "物质名称:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLeakEvaporationS)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtLeakEvaporationT0)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.txtLeakEvaporationu)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.cboLeakEvaporationStab)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 130)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "泄漏参数"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLeakEvaporationM)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.txtLeakEvaporationP)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Location = New System.Drawing.Point(309, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 80)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "物料物性"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdSave)
        Me.GroupBox3.Controls.Add(Me.cmdCalculateLeak)
        Me.GroupBox3.Controls.Add(Me.RichLeakResult)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 185)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(559, 123)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算结果"
        '
        'CheckIsSaved
        '
        Me.CheckIsSaved.AutoSize = True
        Me.CheckIsSaved.Location = New System.Drawing.Point(477, 19)
        Me.CheckIsSaved.Name = "CheckIsSaved"
        Me.CheckIsSaved.Size = New System.Drawing.Size(96, 16)
        Me.CheckIsSaved.TabIndex = 45
        Me.CheckIsSaved.Text = "CheckIsSaved"
        Me.CheckIsSaved.UseVisualStyleBackColor = True
        Me.CheckIsSaved.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmLeakQuality
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 366)
        Me.Controls.Add(Me.CheckIsSaved)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SaveSign)
        Me.Controls.Add(Me.FileName)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeakQuality"
        Me.Text = "质量蒸发量估算"
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
    Public WithEvents SaveSign As System.Windows.Forms.TextBox
    Public WithEvents FileName As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents RichLeakResult As System.Windows.Forms.TextBox
    Public WithEvents cmdCalculateLeak As System.Windows.Forms.Button
    Public WithEvents txtLeakEvaporationM As System.Windows.Forms.TextBox
    Public WithEvents txtLeakEvaporationP As System.Windows.Forms.TextBox
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents txtLeakEvaporationS As System.Windows.Forms.TextBox
    Public WithEvents txtLeakEvaporationT0 As System.Windows.Forms.TextBox
    Public WithEvents txtLeakEvaporationu As System.Windows.Forms.TextBox
    Public WithEvents cboLeakEvaporationStab As System.Windows.Forms.ComboBox
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckIsSaved As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
