<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LineStyleEditor
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.ComboBoxLineWidth = New System.Windows.Forms.ComboBox
        Me.ComboBoxLineStyle = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonLineColor = New System.Windows.Forms.Button
        Me.PicModel = New System.Windows.Forms.PictureBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PicModel, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ComboBoxLineWidth
        '
        Me.ComboBoxLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLineWidth.FormattingEnabled = True
        Me.ComboBoxLineWidth.Location = New System.Drawing.Point(53, 38)
        Me.ComboBoxLineWidth.Name = "ComboBoxLineWidth"
        Me.ComboBoxLineWidth.Size = New System.Drawing.Size(207, 20)
        Me.ComboBoxLineWidth.TabIndex = 27
        '
        'ComboBoxLineStyle
        '
        Me.ComboBoxLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLineStyle.FormattingEnabled = True
        Me.ComboBoxLineStyle.Location = New System.Drawing.Point(53, 12)
        Me.ComboBoxLineStyle.Name = "ComboBoxLineStyle"
        Me.ComboBoxLineStyle.Size = New System.Drawing.Size(207, 20)
        Me.ComboBoxLineStyle.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "宽度:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "样式:"
        '
        'ButtonLineColor
        '
        Me.ButtonLineColor.Location = New System.Drawing.Point(14, 64)
        Me.ButtonLineColor.Name = "ButtonLineColor"
        Me.ButtonLineColor.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLineColor.TabIndex = 23
        Me.ButtonLineColor.Text = "颜色"
        Me.ButtonLineColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonLineColor.UseVisualStyleBackColor = True
        '
        'PicModel
        '
        Me.PicModel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.PicModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicModel.Location = New System.Drawing.Point(14, 93)
        Me.PicModel.Name = "PicModel"
        Me.PicModel.Size = New System.Drawing.Size(246, 41)
        Me.PicModel.TabIndex = 22
        Me.PicModel.TabStop = False
        '
        'LineStyleEditor
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(275, 205)
        Me.Controls.Add(Me.ComboBoxLineWidth)
        Me.Controls.Add(Me.ComboBoxLineStyle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonLineColor)
        Me.Controls.Add(Me.PicModel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LineStyleEditor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "线型编辑器"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PicModel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ComboBoxLineWidth As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxLineStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonLineColor As System.Windows.Forms.Button
    Friend WithEvents PicModel As System.Windows.Forms.PictureBox

End Class
