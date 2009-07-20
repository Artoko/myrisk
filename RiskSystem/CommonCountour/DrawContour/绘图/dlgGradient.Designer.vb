<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGradient
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
        Me.GroupBoxLine = New System.Windows.Forms.GroupBox
        Me.CBContourStart = New ColorButton.ColorButton
        Me.CBContourEnd = New ColorButton.ColorButton
        Me.GroupBoxFill = New System.Windows.Forms.GroupBox
        Me.CBContourFillStart = New ColorButton.ColorButton
        Me.CBContourFillEnd = New ColorButton.ColorButton
        Me.GroupBoxLabel = New System.Windows.Forms.GroupBox
        Me.CBContourLabelStart = New ColorButton.ColorButton
        Me.CBContourLabelEnd = New ColorButton.ColorButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxLine.SuspendLayout()
        Me.GroupBoxFill.SuspendLayout()
        Me.GroupBoxLabel.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(50, 202)
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
        'GroupBoxLine
        '
        Me.GroupBoxLine.Controls.Add(Me.CBContourStart)
        Me.GroupBoxLine.Controls.Add(Me.CBContourEnd)
        Me.GroupBoxLine.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(183, 56)
        Me.GroupBoxLine.TabIndex = 3
        Me.GroupBoxLine.TabStop = False
        Me.GroupBoxLine.Text = "等值线"
        '
        'CBContourStart
        '
        Me.CBContourStart.GradColor = System.Drawing.Color.Black
        Me.CBContourStart.Location = New System.Drawing.Point(6, 20)
        Me.CBContourStart.Name = "CBContourStart"
        Me.CBContourStart.Size = New System.Drawing.Size(75, 23)
        Me.CBContourStart.TabIndex = 1
        Me.CBContourStart.Text = "开始"
        Me.CBContourStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CBContourStart.UseVisualStyleBackColor = True
        '
        'CBContourEnd
        '
        Me.CBContourEnd.GradColor = System.Drawing.Color.Black
        Me.CBContourEnd.Location = New System.Drawing.Point(97, 20)
        Me.CBContourEnd.Name = "CBContourEnd"
        Me.CBContourEnd.Size = New System.Drawing.Size(75, 23)
        Me.CBContourEnd.TabIndex = 2
        Me.CBContourEnd.Text = "结束"
        Me.CBContourEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CBContourEnd.UseVisualStyleBackColor = True
        '
        'GroupBoxFill
        '
        Me.GroupBoxFill.Controls.Add(Me.CBContourFillStart)
        Me.GroupBoxFill.Controls.Add(Me.CBContourFillEnd)
        Me.GroupBoxFill.Location = New System.Drawing.Point(12, 74)
        Me.GroupBoxFill.Name = "GroupBoxFill"
        Me.GroupBoxFill.Size = New System.Drawing.Size(183, 56)
        Me.GroupBoxFill.TabIndex = 3
        Me.GroupBoxFill.TabStop = False
        Me.GroupBoxFill.Text = "等值线填充"
        '
        'CBContourFillStart
        '
        Me.CBContourFillStart.GradColor = System.Drawing.Color.Black
        Me.CBContourFillStart.Location = New System.Drawing.Point(6, 20)
        Me.CBContourFillStart.Name = "CBContourFillStart"
        Me.CBContourFillStart.Size = New System.Drawing.Size(75, 23)
        Me.CBContourFillStart.TabIndex = 1
        Me.CBContourFillStart.Text = "开始"
        Me.CBContourFillStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CBContourFillStart.UseVisualStyleBackColor = True
        '
        'CBContourFillEnd
        '
        Me.CBContourFillEnd.GradColor = System.Drawing.Color.Black
        Me.CBContourFillEnd.Location = New System.Drawing.Point(97, 20)
        Me.CBContourFillEnd.Name = "CBContourFillEnd"
        Me.CBContourFillEnd.Size = New System.Drawing.Size(75, 23)
        Me.CBContourFillEnd.TabIndex = 2
        Me.CBContourFillEnd.Text = "结束"
        Me.CBContourFillEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CBContourFillEnd.UseVisualStyleBackColor = True
        '
        'GroupBoxLabel
        '
        Me.GroupBoxLabel.Controls.Add(Me.CBContourLabelStart)
        Me.GroupBoxLabel.Controls.Add(Me.CBContourLabelEnd)
        Me.GroupBoxLabel.Location = New System.Drawing.Point(12, 136)
        Me.GroupBoxLabel.Name = "GroupBoxLabel"
        Me.GroupBoxLabel.Size = New System.Drawing.Size(183, 56)
        Me.GroupBoxLabel.TabIndex = 3
        Me.GroupBoxLabel.TabStop = False
        Me.GroupBoxLabel.Text = "等值线标注"
        '
        'CBContourLabelStart
        '
        Me.CBContourLabelStart.GradColor = System.Drawing.Color.Black
        Me.CBContourLabelStart.Location = New System.Drawing.Point(6, 20)
        Me.CBContourLabelStart.Name = "CBContourLabelStart"
        Me.CBContourLabelStart.Size = New System.Drawing.Size(75, 23)
        Me.CBContourLabelStart.TabIndex = 1
        Me.CBContourLabelStart.Text = "开始"
        Me.CBContourLabelStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CBContourLabelStart.UseVisualStyleBackColor = True
        '
        'CBContourLabelEnd
        '
        Me.CBContourLabelEnd.GradColor = System.Drawing.Color.Black
        Me.CBContourLabelEnd.Location = New System.Drawing.Point(97, 20)
        Me.CBContourLabelEnd.Name = "CBContourLabelEnd"
        Me.CBContourLabelEnd.Size = New System.Drawing.Size(75, 23)
        Me.CBContourLabelEnd.TabIndex = 2
        Me.CBContourLabelEnd.Text = "结束"
        Me.CBContourLabelEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CBContourLabelEnd.UseVisualStyleBackColor = True
        '
        'dlgGradient
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(208, 240)
        Me.Controls.Add(Me.GroupBoxLabel)
        Me.Controls.Add(Me.GroupBoxFill)
        Me.Controls.Add(Me.GroupBoxLine)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgGradient"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "颜色渐变"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxLine.ResumeLayout(False)
        Me.GroupBoxFill.ResumeLayout(False)
        Me.GroupBoxLabel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CBContourStart As ColorButton.ColorButton
    Friend WithEvents CBContourEnd As ColorButton.ColorButton
    Friend WithEvents GroupBoxLine As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxFill As System.Windows.Forms.GroupBox
    Friend WithEvents CBContourFillStart As ColorButton.ColorButton
    Friend WithEvents CBContourFillEnd As ColorButton.ColorButton
    Friend WithEvents GroupBoxLabel As System.Windows.Forms.GroupBox
    Friend WithEvents CBContourLabelStart As ColorButton.ColorButton
    Friend WithEvents CBContourLabelEnd As ColorButton.ColorButton

End Class
