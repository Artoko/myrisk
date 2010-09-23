<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddCare
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.cmd_OK = New System.Windows.Forms.Button
        Me.cmd_Cancel = New System.Windows.Forms.Button
        Me.txtX = New Chart.CText
        Me.txtY = New Chart.CText
        Me.txtZ = New Chart.CText
        Me.LabelZ = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "关心点名称:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "X:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(119, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Y:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(98, 15)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(113, 21)
        Me.txtName.TabIndex = 2
        '
        'cmd_OK
        '
        Me.cmd_OK.Location = New System.Drawing.Point(47, 112)
        Me.cmd_OK.Name = "cmd_OK"
        Me.cmd_OK.Size = New System.Drawing.Size(64, 21)
        Me.cmd_OK.TabIndex = 3
        Me.cmd_OK.Text = "确定(&O)"
        Me.cmd_OK.UseVisualStyleBackColor = True
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.Location = New System.Drawing.Point(142, 112)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(64, 21)
        Me.cmd_Cancel.TabIndex = 4
        Me.cmd_Cancel.Text = "取消(&C)"
        Me.cmd_Cancel.UseVisualStyleBackColor = True
        '
        'txtX
        '
        Me.txtX.DataType = Chart.DataType.DataInteger
        Me.txtX.Location = New System.Drawing.Point(44, 50)
        Me.txtX.MaxValue = 0
        Me.txtX.MinValue = 0
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(67, 21)
        Me.txtX.TabIndex = 5
        Me.txtX.Text = "0"
        Me.txtX.Value = 0
        '
        'txtY
        '
        Me.txtY.DataType = Chart.DataType.DataInteger
        Me.txtY.Location = New System.Drawing.Point(142, 50)
        Me.txtY.MaxValue = 0
        Me.txtY.MinValue = 0
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(69, 21)
        Me.txtY.TabIndex = 6
        Me.txtY.Text = "0"
        Me.txtY.Value = 0
        '
        'txtZ
        '
        Me.txtZ.DataType = Chart.DataType.DataInteger
        Me.txtZ.Location = New System.Drawing.Point(44, 77)
        Me.txtZ.MaxValue = 0
        Me.txtZ.MinValue = 0
        Me.txtZ.Name = "txtZ"
        Me.txtZ.Size = New System.Drawing.Size(67, 21)
        Me.txtZ.TabIndex = 7
        Me.txtZ.Text = "0"
        Me.txtZ.Value = 0
        '
        'LabelZ
        '
        Me.LabelZ.AutoSize = True
        Me.LabelZ.Location = New System.Drawing.Point(21, 80)
        Me.LabelZ.Name = "LabelZ"
        Me.LabelZ.Size = New System.Drawing.Size(17, 12)
        Me.LabelZ.TabIndex = 1
        Me.LabelZ.Text = "Z:"
        '
        'frmAddCare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 155)
        Me.Controls.Add(Me.txtZ)
        Me.Controls.Add(Me.txtY)
        Me.Controls.Add(Me.txtX)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.cmd_OK)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelZ)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddCare"
        Me.Text = "添加关心点"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cmd_OK As System.Windows.Forms.Button
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents txtX As Chart.CText
    Friend WithEvents txtY As Chart.CText
    Friend WithEvents txtZ As Chart.CText
    Friend WithEvents LabelZ As System.Windows.Forms.Label
End Class
