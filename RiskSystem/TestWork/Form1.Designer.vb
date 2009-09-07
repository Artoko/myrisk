<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.mnuLeakGas = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeakTwo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeakLiquid = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeakFlash = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeakHeat = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLeakQuality = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.mnuSourceItemLeak = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(102, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "设置点源排放方案"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(26, 132)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(325, 528)
        Me.TextBox1.TabIndex = 1
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.C1FlexGrid1.Location = New System.Drawing.Point(386, 78)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.DefaultSize = 18
        Me.C1FlexGrid1.Size = New System.Drawing.Size(652, 215)
        Me.C1FlexGrid1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(399, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "网格点预测时刻[min]:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(540, 52)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "关心点"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(387, 331)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "获取等值线"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(387, 360)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(598, 268)
        Me.TextBox2.TabIndex = 9
        '
        'mnuLeakGas
        '
        Me.mnuLeakGas.Name = "mnuLeakGas"
        Me.mnuLeakGas.Size = New System.Drawing.Size(184, 22)
        Me.mnuLeakGas.Text = "气体泄漏量计算(&G)"
        '
        'mnuLeakTwo
        '
        Me.mnuLeakTwo.Name = "mnuLeakTwo"
        Me.mnuLeakTwo.Size = New System.Drawing.Size(184, 22)
        Me.mnuLeakTwo.Text = "两相流泄漏量计算(&T)"
        '
        'mnuLeakLiquid
        '
        Me.mnuLeakLiquid.Name = "mnuLeakLiquid"
        Me.mnuLeakLiquid.Size = New System.Drawing.Size(184, 22)
        Me.mnuLeakLiquid.Text = "液体泄漏量计算(&L)"
        '
        'mnuLeakFlash
        '
        Me.mnuLeakFlash.Name = "mnuLeakFlash"
        Me.mnuLeakFlash.Size = New System.Drawing.Size(184, 22)
        Me.mnuLeakFlash.Text = "闪蒸量计算(&F)"
        '
        'mnuLeakHeat
        '
        Me.mnuLeakHeat.Name = "mnuLeakHeat"
        Me.mnuLeakHeat.Size = New System.Drawing.Size(184, 22)
        Me.mnuLeakHeat.Text = "热量蒸发量计算(&H)"
        '
        'mnuLeakQuality
        '
        Me.mnuLeakQuality.Name = "mnuLeakQuality"
        Me.mnuLeakQuality.Size = New System.Drawing.Size(184, 22)
        Me.mnuLeakQuality.Text = "质量蒸发量计算(&Q)"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSourceItemLeak})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1050, 24)
        Me.MenuStrip.TabIndex = 10
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuSourceItemLeak
        '
        Me.mnuSourceItemLeak.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.mnuSourceItemLeak.Name = "mnuSourceItemLeak"
        Me.mnuSourceItemLeak.Size = New System.Drawing.Size(83, 20)
        Me.mnuSourceItemLeak.Text = "源项分析(&S)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem1.Text = "气体泄漏量计算(&G)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem2.Text = "两相流泄漏量计算(&T)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem3.Text = "液体泄漏量计算(&L)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem4.Text = "闪蒸量计算(&F)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem5.Text = "热量蒸发量计算(&H)"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem6.Text = "质量蒸发量计算(&Q)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(353, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "根据泄漏类型的不同，您可以选择以下两种方法之一来设置方案。"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(102, 85)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(168, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "设置典型事故泄漏方案"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 672)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Public WithEvents mnuLeakGas As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLeakTwo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLeakLiquid As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLeakFlash As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLeakHeat As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLeakQuality As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Public WithEvents mnuSourceItemLeak As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
