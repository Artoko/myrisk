<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRisk
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRisk))
        Me.EFlexRisk = New Chart.EFlex
        CType(Me.EFlexRisk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EFlexRisk
        '
        Me.EFlexRisk.ColumnInfo = "10,1,0,0,0,0,Columns:"
        Me.EFlexRisk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EFlexRisk.IsCopy = True
        Me.EFlexRisk.IsCut = True
        Me.EFlexRisk.IsPaste = True
        Me.EFlexRisk.Location = New System.Drawing.Point(0, 0)
        Me.EFlexRisk.Name = "EFlexRisk"
        Me.EFlexRisk.Rows.DefaultSize = 18
        Me.EFlexRisk.Size = New System.Drawing.Size(1042, 651)
        Me.EFlexRisk.StyleInfo = resources.GetString("EFlexRisk.StyleInfo")
        Me.EFlexRisk.TabIndex = 22
        '
        'frmRisk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 651)
        Me.Controls.Add(Me.EFlexRisk)
        Me.Name = "frmRisk"
        Me.TabText = "风险值"
        Me.Text = "风险值"
        CType(Me.EFlexRisk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EFlexRisk As Chart.EFlex
End Class
