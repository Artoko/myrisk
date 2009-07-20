<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCare))
        Me.cmdDelCare = New System.Windows.Forms.Button
        Me.cmdAddCare = New System.Windows.Forms.Button
        Me.EFlexCare = New Chart.EFlex
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        CType(Me.EFlexCare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelCare
        '
        Me.cmdDelCare.Location = New System.Drawing.Point(129, 269)
        Me.cmdDelCare.Name = "cmdDelCare"
        Me.cmdDelCare.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelCare.TabIndex = 2
        Me.cmdDelCare.Text = "删除(&D)"
        Me.cmdDelCare.UseVisualStyleBackColor = True
        '
        'cmdAddCare
        '
        Me.cmdAddCare.Location = New System.Drawing.Point(48, 269)
        Me.cmdAddCare.Name = "cmdAddCare"
        Me.cmdAddCare.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddCare.TabIndex = 1
        Me.cmdAddCare.Text = "添加(&A)"
        Me.cmdAddCare.UseVisualStyleBackColor = True
        '
        'EFlexCare
        '
        Me.EFlexCare.ColumnInfo = resources.GetString("EFlexCare.ColumnInfo")
        Me.EFlexCare.IsCopy = True
        Me.EFlexCare.IsCut = True
        Me.EFlexCare.IsPaste = True
        Me.EFlexCare.Location = New System.Drawing.Point(-1, 0)
        Me.EFlexCare.Name = "EFlexCare"
        Me.EFlexCare.Rows.Count = 1
        Me.EFlexCare.Rows.DefaultSize = 18
        Me.EFlexCare.Size = New System.Drawing.Size(494, 263)
        Me.EFlexCare.StyleInfo = resources.GetString("EFlexCare.StyleInfo")
        Me.EFlexCare.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(386, 269)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 291
        Me.Cancel_Button.Text = "取消(&C)"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(296, 269)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 290
        Me.OK_Button.Text = "确定(&O)"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'frmCare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 307)
        Me.Controls.Add(Me.cmdDelCare)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.cmdAddCare)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.EFlexCare)
        Me.Name = "frmCare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "关心点"
        CType(Me.EFlexCare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdDelCare As System.Windows.Forms.Button
    Friend WithEvents cmdAddCare As System.Windows.Forms.Button
    Friend WithEvents EFlexCare As Chart.EFlex
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
End Class
