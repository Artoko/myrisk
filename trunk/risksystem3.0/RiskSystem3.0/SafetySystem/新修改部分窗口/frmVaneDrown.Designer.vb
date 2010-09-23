<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVaneDrown
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVaneDrown))
        Me.txtVaneDistance = New Chart.CText
        Me.txtVaneStep = New Chart.CText
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.RadioVaneType2 = New System.Windows.Forms.RadioButton
        Me.RadioVaneType1 = New System.Windows.Forms.RadioButton
        Me.EFlexVan = New Chart.EFlex
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.cmdDelVane = New System.Windows.Forms.Button
        Me.cmdAddVane = New System.Windows.Forms.Button
        CType(Me.EFlexVan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtVaneDistance
        '
        Me.txtVaneDistance.DataType = Chart.DataType.DataDouble
        Me.txtVaneDistance.Location = New System.Drawing.Point(283, 71)
        Me.txtVaneDistance.MaxValue = 0
        Me.txtVaneDistance.MinValue = 0
        Me.txtVaneDistance.Name = "txtVaneDistance"
        Me.txtVaneDistance.Size = New System.Drawing.Size(100, 21)
        Me.txtVaneDistance.TabIndex = 6
        Me.txtVaneDistance.Text = "0"
        Me.txtVaneDistance.Value = 0
        '
        'txtVaneStep
        '
        Me.txtVaneStep.DataType = Chart.DataType.DataDouble
        Me.txtVaneStep.Location = New System.Drawing.Point(283, 44)
        Me.txtVaneStep.MaxValue = 0
        Me.txtVaneStep.MinValue = 0
        Me.txtVaneStep.Name = "txtVaneStep"
        Me.txtVaneStep.Size = New System.Drawing.Size(100, 21)
        Me.txtVaneStep.TabIndex = 5
        Me.txtVaneStep.Text = "0"
        Me.txtVaneStep.Value = 0
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(224, 47)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(53, 12)
        Me.Label64.TabIndex = 2
        Me.Label64.Text = "步长[m]:"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(242, 74)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(35, 12)
        Me.Label65.TabIndex = 3
        Me.Label65.Text = "距离:"
        '
        'RadioVaneType2
        '
        Me.RadioVaneType2.AutoSize = True
        Me.RadioVaneType2.Location = New System.Drawing.Point(245, 12)
        Me.RadioVaneType2.Name = "RadioVaneType2"
        Me.RadioVaneType2.Size = New System.Drawing.Size(95, 16)
        Me.RadioVaneType2.TabIndex = 7
        Me.RadioVaneType2.TabStop = True
        Me.RadioVaneType2.Text = "按等步长预测"
        Me.RadioVaneType2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioVaneType2.UseVisualStyleBackColor = True
        '
        'RadioVaneType1
        '
        Me.RadioVaneType1.AutoSize = True
        Me.RadioVaneType1.Location = New System.Drawing.Point(23, 12)
        Me.RadioVaneType1.Name = "RadioVaneType1"
        Me.RadioVaneType1.Size = New System.Drawing.Size(119, 16)
        Me.RadioVaneType1.TabIndex = 8
        Me.RadioVaneType1.TabStop = True
        Me.RadioVaneType1.Text = "按自定义距离预测"
        Me.RadioVaneType1.UseVisualStyleBackColor = True
        '
        'EFlexVan
        '
        Me.EFlexVan.ColumnInfo = "2,1,0,0,0,0,Columns:0{Width:50;Caption:""序号"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:50;Caption:""距离[m]"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.EFlexVan.IsCopy = True
        Me.EFlexVan.IsCut = True
        Me.EFlexVan.IsPaste = True
        Me.EFlexVan.Location = New System.Drawing.Point(12, 44)
        Me.EFlexVan.Name = "EFlexVan"
        Me.EFlexVan.Rows.Count = 1
        Me.EFlexVan.Rows.DefaultSize = 18
        Me.EFlexVan.Size = New System.Drawing.Size(168, 259)
        Me.EFlexVan.StyleInfo = resources.GetString("EFlexVan.StyleInfo")
        Me.EFlexVan.TabIndex = 9
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(335, 320)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 293
        Me.Cancel_Button.Text = "取消(&C)"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(245, 320)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 292
        Me.OK_Button.Text = "确定(&O)"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'cmdDelVane
        '
        Me.cmdDelVane.Location = New System.Drawing.Point(96, 320)
        Me.cmdDelVane.Name = "cmdDelVane"
        Me.cmdDelVane.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelVane.TabIndex = 295
        Me.cmdDelVane.Text = "删除(&D)"
        Me.cmdDelVane.UseVisualStyleBackColor = True
        '
        'cmdAddVane
        '
        Me.cmdAddVane.Location = New System.Drawing.Point(15, 320)
        Me.cmdAddVane.Name = "cmdAddVane"
        Me.cmdAddVane.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddVane.TabIndex = 294
        Me.cmdAddVane.Text = "添加(&A)"
        Me.cmdAddVane.UseVisualStyleBackColor = True
        '
        'frmVaneDrown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 355)
        Me.Controls.Add(Me.cmdDelVane)
        Me.Controls.Add(Me.cmdAddVane)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.EFlexVan)
        Me.Controls.Add(Me.RadioVaneType1)
        Me.Controls.Add(Me.RadioVaneType2)
        Me.Controls.Add(Me.txtVaneDistance)
        Me.Controls.Add(Me.txtVaneStep)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label65)
        Me.Name = "frmVaneDrown"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "轴线下风向预测点"
        CType(Me.EFlexVan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVaneDistance As Chart.CText
    Friend WithEvents txtVaneStep As Chart.CText
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents RadioVaneType2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioVaneType1 As System.Windows.Forms.RadioButton
    Friend WithEvents EFlexVan As Chart.EFlex
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents cmdDelVane As System.Windows.Forms.Button
    Friend WithEvents cmdAddVane As System.Windows.Forms.Button
End Class
