<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAermodGradient
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.间距 = New System.Windows.Forms.Label
        Me.txtGradMix = New Chart.CText
        Me.txtGradMax = New Chart.CText
        Me.txtDistanse = New Chart.CText
        Me.RadioButtonGrade = New System.Windows.Forms.RadioButton
        Me.RadioButtonCustom = New System.Windows.Forms.RadioButton
        Me.txtCustom = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(235, 158)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "确定"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "最小值:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "最大值:"
        '
        '间距
        '
        Me.间距.AutoSize = True
        Me.间距.Location = New System.Drawing.Point(269, 50)
        Me.间距.Name = "间距"
        Me.间距.Size = New System.Drawing.Size(35, 12)
        Me.间距.TabIndex = 4
        Me.间距.Text = "间距:"
        '
        'txtGradMix
        '
        Me.txtGradMix.DataType = Chart.DataType.DataDouble
        Me.txtGradMix.Location = New System.Drawing.Point(65, 46)
        Me.txtGradMix.MaxValue = 0
        Me.txtGradMix.MinValue = 0
        Me.txtGradMix.Name = "txtGradMix"
        Me.txtGradMix.Size = New System.Drawing.Size(66, 21)
        Me.txtGradMix.TabIndex = 5
        Me.txtGradMix.Text = "0"
        Me.txtGradMix.Value = 0
        '
        'txtGradMax
        '
        Me.txtGradMax.DataType = Chart.DataType.DataDouble
        Me.txtGradMax.Location = New System.Drawing.Point(190, 46)
        Me.txtGradMax.MaxValue = 0
        Me.txtGradMax.MinValue = 0
        Me.txtGradMax.Name = "txtGradMax"
        Me.txtGradMax.Size = New System.Drawing.Size(66, 21)
        Me.txtGradMax.TabIndex = 6
        Me.txtGradMax.Text = "0"
        Me.txtGradMax.Value = 0
        '
        'txtDistanse
        '
        Me.txtDistanse.DataType = Chart.DataType.DataDouble
        Me.txtDistanse.Location = New System.Drawing.Point(310, 46)
        Me.txtDistanse.MaxValue = 0
        Me.txtDistanse.MinValue = 0
        Me.txtDistanse.Name = "txtDistanse"
        Me.txtDistanse.Size = New System.Drawing.Size(66, 21)
        Me.txtDistanse.TabIndex = 7
        Me.txtDistanse.Text = "0"
        Me.txtDistanse.Value = 0
        '
        'RadioButtonGrade
        '
        Me.RadioButtonGrade.AutoSize = True
        Me.RadioButtonGrade.Location = New System.Drawing.Point(12, 12)
        Me.RadioButtonGrade.Name = "RadioButtonGrade"
        Me.RadioButtonGrade.Size = New System.Drawing.Size(59, 16)
        Me.RadioButtonGrade.TabIndex = 8
        Me.RadioButtonGrade.TabStop = True
        Me.RadioButtonGrade.Text = "等间距"
        Me.RadioButtonGrade.UseVisualStyleBackColor = True
        '
        'RadioButtonCustom
        '
        Me.RadioButtonCustom.AutoSize = True
        Me.RadioButtonCustom.Location = New System.Drawing.Point(12, 83)
        Me.RadioButtonCustom.Name = "RadioButtonCustom"
        Me.RadioButtonCustom.Size = New System.Drawing.Size(59, 16)
        Me.RadioButtonCustom.TabIndex = 9
        Me.RadioButtonCustom.TabStop = True
        Me.RadioButtonCustom.Text = "自定义"
        Me.RadioButtonCustom.UseVisualStyleBackColor = True
        '
        'txtCustom
        '
        Me.txtCustom.Location = New System.Drawing.Point(14, 114)
        Me.txtCustom.Name = "txtCustom"
        Me.txtCustom.Size = New System.Drawing.Size(362, 21)
        Me.txtCustom.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.txtCustom, "数据之间用逗号分开。如：0.01,0.02,0.04")
        '
        'dlgAermodGradient
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(393, 196)
        Me.Controls.Add(Me.txtCustom)
        Me.Controls.Add(Me.RadioButtonCustom)
        Me.Controls.Add(Me.RadioButtonGrade)
        Me.Controls.Add(Me.txtDistanse)
        Me.Controls.Add(Me.txtGradMax)
        Me.Controls.Add(Me.txtGradMix)
        Me.Controls.Add(Me.间距)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAermodGradient"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "设置等值线范围"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 间距 As System.Windows.Forms.Label
    Friend WithEvents txtGradMix As Chart.CText
    Friend WithEvents txtGradMax As Chart.CText
    Friend WithEvents txtDistanse As Chart.CText
    Friend WithEvents RadioButtonGrade As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCustom As System.Windows.Forms.RadioButton
    Friend WithEvents txtCustom As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
