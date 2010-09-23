<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPS
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLongDeg = New System.Windows.Forms.TextBox
        Me.txtLongCent = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLatDeg = New System.Windows.Forms.TextBox
        Me.txtLatCent = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCloudageAll = New System.Windows.Forms.TextBox
        Me.txtCloudagePart = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdReflash = New System.Windows.Forms.Button
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DateTimePickerMorning = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerNight = New System.Windows.Forms.DateTimePicker
        Me.txtU10 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "当地经度[度/分]:"
        '
        'txtLongDeg
        '
        Me.txtLongDeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLongDeg.Location = New System.Drawing.Point(145, 16)
        Me.txtLongDeg.Name = "txtLongDeg"
        Me.txtLongDeg.Size = New System.Drawing.Size(100, 21)
        Me.txtLongDeg.TabIndex = 1
        Me.txtLongDeg.Text = "121"
        '
        'txtLongCent
        '
        Me.txtLongCent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLongCent.Location = New System.Drawing.Point(251, 16)
        Me.txtLongCent.Name = "txtLongCent"
        Me.txtLongCent.Size = New System.Drawing.Size(100, 21)
        Me.txtLongCent.TabIndex = 2
        Me.txtLongCent.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "当地纬度[度/分]:"
        '
        'txtLatDeg
        '
        Me.txtLatDeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLatDeg.Location = New System.Drawing.Point(145, 43)
        Me.txtLatDeg.Name = "txtLatDeg"
        Me.txtLatDeg.Size = New System.Drawing.Size(100, 21)
        Me.txtLatDeg.TabIndex = 5
        Me.txtLatDeg.Text = "29"
        '
        'txtLatCent
        '
        Me.txtLatCent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLatCent.Location = New System.Drawing.Point(251, 43)
        Me.txtLatCent.Name = "txtLatCent"
        Me.txtLatCent.Size = New System.Drawing.Size(100, 21)
        Me.txtLatCent.TabIndex = 6
        Me.txtLatCent.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "观测时刻:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "云量[总云/低云]:"
        '
        'txtCloudageAll
        '
        Me.txtCloudageAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCloudageAll.Location = New System.Drawing.Point(145, 124)
        Me.txtCloudageAll.Name = "txtCloudageAll"
        Me.txtCloudageAll.Size = New System.Drawing.Size(100, 21)
        Me.txtCloudageAll.TabIndex = 14
        Me.txtCloudageAll.Text = "10"
        '
        'txtCloudagePart
        '
        Me.txtCloudagePart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCloudagePart.Location = New System.Drawing.Point(251, 124)
        Me.txtCloudagePart.Name = "txtCloudagePart"
        Me.txtCloudagePart.Size = New System.Drawing.Size(100, 21)
        Me.txtCloudagePart.TabIndex = 15
        Me.txtCloudagePart.Text = "5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "昼夜交替时间:"
        '
        'cmdReflash
        '
        Me.cmdReflash.Location = New System.Drawing.Point(22, 185)
        Me.cmdReflash.Name = "cmdReflash"
        Me.cmdReflash.Size = New System.Drawing.Size(75, 23)
        Me.cmdReflash.TabIndex = 17
        Me.cmdReflash.Text = "刷新结果"
        Me.cmdReflash.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(16, 214)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(498, 114)
        Me.txtResult.TabIndex = 18
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(145, 97)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(206, 21)
        Me.DateTimePicker1.TabIndex = 19
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DateTimePickerMorning
        '
        Me.DateTimePickerMorning.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerMorning.Location = New System.Drawing.Point(145, 151)
        Me.DateTimePickerMorning.Name = "DateTimePickerMorning"
        Me.DateTimePickerMorning.ShowUpDown = True
        Me.DateTimePickerMorning.Size = New System.Drawing.Size(100, 21)
        Me.DateTimePickerMorning.TabIndex = 20
        '
        'DateTimePickerNight
        '
        Me.DateTimePickerNight.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerNight.Location = New System.Drawing.Point(251, 151)
        Me.DateTimePickerNight.Name = "DateTimePickerNight"
        Me.DateTimePickerNight.ShowUpDown = True
        Me.DateTimePickerNight.Size = New System.Drawing.Size(100, 21)
        Me.DateTimePickerNight.TabIndex = 20
        '
        'txtU10
        '
        Me.txtU10.Location = New System.Drawing.Point(145, 70)
        Me.txtU10.Name = "txtU10"
        Me.txtU10.Size = New System.Drawing.Size(206, 21)
        Me.txtU10.TabIndex = 21
        Me.txtU10.Text = "1.8"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 12)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "地面10m风速[m/s]:"
        '
        'frmPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 346)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtU10)
        Me.Controls.Add(Me.DateTimePickerNight)
        Me.Controls.Add(Me.DateTimePickerMorning)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.cmdReflash)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCloudagePart)
        Me.Controls.Add(Me.txtCloudageAll)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLatCent)
        Me.Controls.Add(Me.txtLatDeg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLongCent)
        Me.Controls.Add(Me.txtLongDeg)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPS"
        Me.Text = "大气稳定度计算"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLongDeg As System.Windows.Forms.TextBox
    Friend WithEvents txtLongCent As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLatDeg As System.Windows.Forms.TextBox
    Friend WithEvents txtLatCent As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCloudageAll As System.Windows.Forms.TextBox
    Friend WithEvents txtCloudagePart As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdReflash As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DateTimePickerNight As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerMorning As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtU10 As System.Windows.Forms.TextBox
End Class
