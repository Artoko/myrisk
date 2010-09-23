<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FillStyleEditor
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.cmbMode = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdForeColor = New System.Windows.Forms.Button
        Me.ForeTransparent = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.PicModel = New System.Windows.Forms.PictureBox
        Me.cmdBackColor = New System.Windows.Forms.Button
        Me.BackTransparent = New System.Windows.Forms.NumericUpDown
        Me.cmbBrushStyle = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ForeTransparent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicModel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BackTransparent, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(117, 167)
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
        'cmbMode
        '
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"实体", "阴影"})
        Me.cmbMode.Location = New System.Drawing.Point(53, 12)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(210, 20)
        Me.cmbMode.TabIndex = 44
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "方式:"
        '
        'cmdForeColor
        '
        Me.cmdForeColor.Location = New System.Drawing.Point(53, 64)
        Me.cmdForeColor.Name = "cmdForeColor"
        Me.cmdForeColor.Size = New System.Drawing.Size(75, 23)
        Me.cmdForeColor.TabIndex = 42
        Me.cmdForeColor.Text = "颜色"
        Me.cmdForeColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdForeColor.UseVisualStyleBackColor = True
        '
        'ForeTransparent
        '
        Me.ForeTransparent.Location = New System.Drawing.Point(175, 65)
        Me.ForeTransparent.Name = "ForeTransparent"
        Me.ForeTransparent.Size = New System.Drawing.Size(71, 21)
        Me.ForeTransparent.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "前景:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "透明:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(252, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 12)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "%"
        '
        'PicModel
        '
        Me.PicModel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.PicModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicModel.Location = New System.Drawing.Point(14, 122)
        Me.PicModel.Name = "PicModel"
        Me.PicModel.Size = New System.Drawing.Size(249, 37)
        Me.PicModel.TabIndex = 37
        Me.PicModel.TabStop = False
        '
        'cmdBackColor
        '
        Me.cmdBackColor.Location = New System.Drawing.Point(53, 92)
        Me.cmdBackColor.Name = "cmdBackColor"
        Me.cmdBackColor.Size = New System.Drawing.Size(75, 23)
        Me.cmdBackColor.TabIndex = 36
        Me.cmdBackColor.Text = "颜色"
        Me.cmdBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBackColor.UseVisualStyleBackColor = True
        '
        'BackTransparent
        '
        Me.BackTransparent.Location = New System.Drawing.Point(175, 95)
        Me.BackTransparent.Name = "BackTransparent"
        Me.BackTransparent.Size = New System.Drawing.Size(71, 21)
        Me.BackTransparent.TabIndex = 35
        '
        'cmbBrushStyle
        '
        Me.cmbBrushStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBrushStyle.FormattingEnabled = True
        Me.cmbBrushStyle.Location = New System.Drawing.Point(53, 38)
        Me.cmbBrushStyle.Name = "cmbBrushStyle"
        Me.cmbBrushStyle.Size = New System.Drawing.Size(210, 20)
        Me.cmbBrushStyle.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 12)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(134, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "透明:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "背景:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "样式:"
        '
        'FillStyleEditor
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(275, 205)
        Me.Controls.Add(Me.cmbMode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdForeColor)
        Me.Controls.Add(Me.ForeTransparent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PicModel)
        Me.Controls.Add(Me.cmdBackColor)
        Me.Controls.Add(Me.BackTransparent)
        Me.Controls.Add(Me.cmbBrushStyle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FillStyleEditor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "填充样式编辑器"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ForeTransparent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicModel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BackTransparent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmbMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdForeColor As System.Windows.Forms.Button
    Friend WithEvents ForeTransparent As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PicModel As System.Windows.Forms.PictureBox
    Friend WithEvents cmdBackColor As System.Windows.Forms.Button
    Friend WithEvents BackTransparent As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbBrushStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
