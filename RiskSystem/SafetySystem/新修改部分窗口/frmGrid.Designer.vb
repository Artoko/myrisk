<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrid))
        Me.GroupBoxForecastPoint = New System.Windows.Forms.GroupBox
        Me.txtCountX = New Chart.CText
        Me.txtStepX = New Chart.CText
        Me.txtMinX = New Chart.CText
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.chkGrid = New System.Windows.Forms.CheckBox
        Me.txtWGH = New Chart.CText
        Me.txtCountY = New Chart.CText
        Me.txtStepY = New Chart.CText
        Me.txtMinY = New Chart.CText
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmdSetPopular = New System.Windows.Forms.Button
        Me.txtPopulation = New Chart.CText
        Me.Label3 = New System.Windows.Forms.Label
        Me.flexPopulation = New Chart.EFlex
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.GroupBoxForecastPoint.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.flexPopulation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxForecastPoint
        '
        Me.GroupBoxForecastPoint.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtCountX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtStepX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.txtMinX)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label14)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label1)
        Me.GroupBoxForecastPoint.Controls.Add(Me.Label18)
        Me.GroupBoxForecastPoint.Location = New System.Drawing.Point(21, 54)
        Me.GroupBoxForecastPoint.Name = "GroupBoxForecastPoint"
        Me.GroupBoxForecastPoint.Size = New System.Drawing.Size(236, 114)
        Me.GroupBoxForecastPoint.TabIndex = 271
        Me.GroupBoxForecastPoint.TabStop = False
        Me.GroupBoxForecastPoint.Text = "X轴"
        '
        'txtCountX
        '
        Me.txtCountX.DataType = Chart.DataType.DataDouble
        Me.txtCountX.Location = New System.Drawing.Point(107, 47)
        Me.txtCountX.MaxValue = 301
        Me.txtCountX.MinValue = 11
        Me.txtCountX.Name = "txtCountX"
        Me.txtCountX.Size = New System.Drawing.Size(100, 21)
        Me.txtCountX.TabIndex = 211
        Me.txtCountX.Text = "0"
        Me.txtCountX.Value = 0
        '
        'txtStepX
        '
        Me.txtStepX.DataType = Chart.DataType.DataDouble
        Me.txtStepX.Location = New System.Drawing.Point(107, 74)
        Me.txtStepX.MaxValue = 0
        Me.txtStepX.MinValue = 0
        Me.txtStepX.Name = "txtStepX"
        Me.txtStepX.Size = New System.Drawing.Size(100, 21)
        Me.txtStepX.TabIndex = 210
        Me.txtStepX.Text = "0"
        Me.txtStepX.Value = 0
        '
        'txtMinX
        '
        Me.txtMinX.DataType = Chart.DataType.DataDouble
        Me.txtMinX.Location = New System.Drawing.Point(107, 20)
        Me.txtMinX.MaxValue = 0
        Me.txtMinX.MinValue = 0
        Me.txtMinX.Name = "txtMinX"
        Me.txtMinX.Size = New System.Drawing.Size(100, 21)
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
        Me.Label14.Location = New System.Drawing.Point(24, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(77, 12)
        Me.Label14.TabIndex = 202
        Me.Label14.Text = "起始坐标[m]:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(30, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "网格点个数:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(48, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(53, 12)
        Me.Label18.TabIndex = 206
        Me.Label18.Text = "步长[m]:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkGrid
        '
        Me.chkGrid.AutoSize = True
        Me.chkGrid.Location = New System.Drawing.Point(35, 32)
        Me.chkGrid.Name = "chkGrid"
        Me.chkGrid.Size = New System.Drawing.Size(84, 16)
        Me.chkGrid.TabIndex = 213
        Me.chkGrid.Text = "计算网格点"
        Me.chkGrid.UseVisualStyleBackColor = True
        '
        'txtWGH
        '
        Me.txtWGH.DataType = Chart.DataType.DataDouble
        Me.txtWGH.Location = New System.Drawing.Point(128, 185)
        Me.txtWGH.MaxValue = 0
        Me.txtWGH.MinValue = 0
        Me.txtWGH.Name = "txtWGH"
        Me.txtWGH.Size = New System.Drawing.Size(100, 21)
        Me.txtWGH.TabIndex = 212
        Me.txtWGH.Text = "0"
        Me.txtWGH.Value = 0
        '
        'txtCountY
        '
        Me.txtCountY.DataType = Chart.DataType.DataDouble
        Me.txtCountY.Location = New System.Drawing.Point(121, 47)
        Me.txtCountY.MaxValue = 301
        Me.txtCountY.MinValue = 11
        Me.txtCountY.Name = "txtCountY"
        Me.txtCountY.Size = New System.Drawing.Size(100, 21)
        Me.txtCountY.TabIndex = 211
        Me.txtCountY.Text = "0"
        Me.txtCountY.Value = 0
        '
        'txtStepY
        '
        Me.txtStepY.DataType = Chart.DataType.DataDouble
        Me.txtStepY.Location = New System.Drawing.Point(121, 74)
        Me.txtStepY.MaxValue = 0
        Me.txtStepY.MinValue = 0
        Me.txtStepY.Name = "txtStepY"
        Me.txtStepY.Size = New System.Drawing.Size(100, 21)
        Me.txtStepY.TabIndex = 210
        Me.txtStepY.Text = "0"
        Me.txtStepY.Value = 0
        '
        'txtMinY
        '
        Me.txtMinY.DataType = Chart.DataType.DataDouble
        Me.txtMinY.Location = New System.Drawing.Point(121, 20)
        Me.txtMinY.MaxValue = 0
        Me.txtMinY.MinValue = 0
        Me.txtMinY.Name = "txtMinY"
        Me.txtMinY.Size = New System.Drawing.Size(100, 21)
        Me.txtMinY.TabIndex = 209
        Me.txtMinY.Text = "0"
        Me.txtMinY.Value = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(38, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "起始坐标[m]:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(44, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 206
        Me.Label4.Text = "网格点个数:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(62, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "步长[m]:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(33, 188)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(89, 12)
        Me.Label19.TabIndex = 208
        Me.Label19.Text = "网格点高度[m]:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMinY)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCountY)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtStepY)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(275, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 114)
        Me.GroupBox1.TabIndex = 273
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Y轴"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(742, 396)
        Me.TabControl1.TabIndex = 274
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.chkGrid)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtWGH)
        Me.TabPage1.Controls.Add(Me.GroupBoxForecastPoint)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(734, 371)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "网格点"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.cmdSetPopular)
        Me.TabPage2.Controls.Add(Me.txtPopulation)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.flexPopulation)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(734, 371)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "人口分布"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmdSetPopular
        '
        Me.cmdSetPopular.Location = New System.Drawing.Point(266, 342)
        Me.cmdSetPopular.Name = "cmdSetPopular"
        Me.cmdSetPopular.Size = New System.Drawing.Size(75, 23)
        Me.cmdSetPopular.TabIndex = 3
        Me.cmdSetPopular.Text = "设置(&S)"
        Me.cmdSetPopular.UseVisualStyleBackColor = True
        '
        'txtPopulation
        '
        Me.txtPopulation.DataType = Chart.DataType.DataDouble
        Me.txtPopulation.Location = New System.Drawing.Point(160, 344)
        Me.txtPopulation.MaxValue = 0
        Me.txtPopulation.MinValue = 0
        Me.txtPopulation.Name = "txtPopulation"
        Me.txtPopulation.Size = New System.Drawing.Size(100, 21)
        Me.txtPopulation.TabIndex = 2
        Me.txtPopulation.Text = "0"
        Me.txtPopulation.Value = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 347)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "人口密度[人/km^2]:"
        '
        'flexPopulation
        '
        Me.flexPopulation.ColumnInfo = "10,1,0,0,0,0,Columns:1{Style:""TextAlign:GeneralCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.flexPopulation.IsCopy = True
        Me.flexPopulation.IsCut = True
        Me.flexPopulation.IsPaste = True
        Me.flexPopulation.Location = New System.Drawing.Point(1, 1)
        Me.flexPopulation.Name = "flexPopulation"
        Me.flexPopulation.Rows.DefaultSize = 18
        Me.flexPopulation.Size = New System.Drawing.Size(733, 337)
        Me.flexPopulation.StyleInfo = resources.GetString("flexPopulation.StyleInfo")
        Me.flexPopulation.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(633, 402)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 289
        Me.Cancel_Button.Text = "取消(&C)"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(543, 402)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 288
        Me.OK_Button.Text = "确定(&O)"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'frmGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 427)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmGrid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "网格点"
        Me.GroupBoxForecastPoint.ResumeLayout(False)
        Me.GroupBoxForecastPoint.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.flexPopulation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxForecastPoint As System.Windows.Forms.GroupBox
    Friend WithEvents chkGrid As System.Windows.Forms.CheckBox
    Friend WithEvents txtWGH As Chart.CText
    Friend WithEvents txtCountY As Chart.CText
    Friend WithEvents txtCountX As Chart.CText
    Friend WithEvents txtStepY As Chart.CText
    Friend WithEvents txtStepX As Chart.CText
    Friend WithEvents txtMinY As Chart.CText
    Friend WithEvents txtMinX As Chart.CText
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents flexPopulation As Chart.EFlex
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents cmdSetPopular As System.Windows.Forms.Button
    Friend WithEvents txtPopulation As Chart.CText
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
