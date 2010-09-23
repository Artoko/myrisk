<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDrang
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstProvince = New System.Windows.Forms.ListBox
        Me.lstCity = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ctxtCity = New Chart.CText
        Me.ctxtP = New Chart.CText
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ctxtE = New Chart.CText
        Me.ctxtN = New Chart.CText
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ctxtSeason = New Chart.CText
        Me.Label7 = New System.Windows.Forms.Label
        Me.cobSeason = New System.Windows.Forms.ComboBox
        Me.OK = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "省份："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "地区："
        '
        'lstProvince
        '
        Me.lstProvince.FormattingEnabled = True
        Me.lstProvince.ItemHeight = 12
        Me.lstProvince.Location = New System.Drawing.Point(14, 24)
        Me.lstProvince.Name = "lstProvince"
        Me.lstProvince.Size = New System.Drawing.Size(96, 280)
        Me.lstProvince.TabIndex = 2
        '
        'lstCity
        '
        Me.lstCity.FormattingEnabled = True
        Me.lstCity.ItemHeight = 12
        Me.lstCity.Location = New System.Drawing.Point(128, 24)
        Me.lstCity.Name = "lstCity"
        Me.lstCity.Size = New System.Drawing.Size(114, 280)
        Me.lstCity.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ctxtCity)
        Me.GroupBox1.Controls.Add(Me.ctxtP)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(265, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 80)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "城市名称"
        '
        'ctxtCity
        '
        Me.ctxtCity.DataType = Chart.DataType.DataDouble
        Me.ctxtCity.Location = New System.Drawing.Point(77, 46)
        Me.ctxtCity.MaxValue = 0
        Me.ctxtCity.MinValue = 0
        Me.ctxtCity.Name = "ctxtCity"
        Me.ctxtCity.Size = New System.Drawing.Size(117, 21)
        Me.ctxtCity.TabIndex = 3
        Me.ctxtCity.Text = "0"
        Me.ctxtCity.Value = 0
        '
        'ctxtP
        '
        Me.ctxtP.DataType = Chart.DataType.DataDouble
        Me.ctxtP.Enabled = False
        Me.ctxtP.Location = New System.Drawing.Point(77, 14)
        Me.ctxtP.MaxValue = 0
        Me.ctxtP.MinValue = 0
        Me.ctxtP.Name = "ctxtP"
        Me.ctxtP.Size = New System.Drawing.Size(117, 21)
        Me.ctxtP.TabIndex = 2
        Me.ctxtP.Text = "0"
        Me.ctxtP.Value = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "地区："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "省份："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ctxtE)
        Me.GroupBox2.Controls.Add(Me.ctxtN)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(265, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 100)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "站台位置"
        '
        'ctxtE
        '
        Me.ctxtE.DataType = Chart.DataType.DataDouble
        Me.ctxtE.Location = New System.Drawing.Point(77, 60)
        Me.ctxtE.MaxValue = 0
        Me.ctxtE.MinValue = 0
        Me.ctxtE.Name = "ctxtE"
        Me.ctxtE.Size = New System.Drawing.Size(117, 21)
        Me.ctxtE.TabIndex = 3
        Me.ctxtE.Text = "0"
        Me.ctxtE.Value = 0
        '
        'ctxtN
        '
        Me.ctxtN.DataType = Chart.DataType.DataDouble
        Me.ctxtN.Location = New System.Drawing.Point(77, 22)
        Me.ctxtN.MaxValue = 0
        Me.ctxtN.MinValue = 0
        Me.ctxtN.Name = "ctxtN"
        Me.ctxtN.Size = New System.Drawing.Size(117, 21)
        Me.ctxtN.TabIndex = 2
        Me.ctxtN.Text = "0"
        Me.ctxtN.Value = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "东经："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "北纬："
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ctxtSeason)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cobSeason)
        Me.GroupBox3.Location = New System.Drawing.Point(265, 201)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(206, 61)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "大气压力"
        '
        'ctxtSeason
        '
        Me.ctxtSeason.DataType = Chart.DataType.DataDouble
        Me.ctxtSeason.Location = New System.Drawing.Point(113, 25)
        Me.ctxtSeason.MaxValue = 0
        Me.ctxtSeason.MinValue = 0
        Me.ctxtSeason.Name = "ctxtSeason"
        Me.ctxtSeason.Size = New System.Drawing.Size(81, 21)
        Me.ctxtSeason.TabIndex = 13
        Me.ctxtSeason.Text = "0"
        Me.ctxtSeason.Value = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "季节："
        '
        'cobSeason
        '
        Me.cobSeason.FormattingEnabled = True
        Me.cobSeason.Items.AddRange(New Object() {"夏季", "冬季"})
        Me.cobSeason.Location = New System.Drawing.Point(49, 25)
        Me.cobSeason.Name = "cobSeason"
        Me.cobSeason.Size = New System.Drawing.Size(58, 20)
        Me.cobSeason.TabIndex = 12
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(265, 281)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(75, 23)
        Me.OK.TabIndex = 5
        Me.OK.Text = "确定"
        Me.OK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(378, 281)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "退出"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'SelectDrang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 332)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstCity)
        Me.Controls.Add(Me.lstProvince)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SelectDrang"
        Me.Text = "全国各地大气压数据库"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstProvince As System.Windows.Forms.ListBox
    Friend WithEvents lstCity As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ctxtCity As Chart.CText
    Friend WithEvents ctxtP As Chart.CText
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ctxtE As Chart.CText
    Friend WithEvents ctxtN As Chart.CText
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents cobSeason As System.Windows.Forms.ComboBox
    Friend WithEvents ctxtSeason As Chart.CText
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
