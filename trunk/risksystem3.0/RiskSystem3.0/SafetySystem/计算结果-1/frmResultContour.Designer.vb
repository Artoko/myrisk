<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultContour
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
        Me.ContourPaint1 = New DrawContour.ContourPaintForm
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContourPaint1
        '
        Me.ContourPaint1.DBlClkSet = False
        Me.ContourPaint1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContourPaint1.Location = New System.Drawing.Point(0, 0)
        Me.ContourPaint1.Menu = True
        Me.ContourPaint1.MouseMoveType = 0
        Me.ContourPaint1.Name = "ContourPaint1"
        Me.ContourPaint1.Size = New System.Drawing.Size(853, 598)
        Me.ContourPaint1.TabIndex = 1
        '
        'TrackBar1
        '
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(0, 553)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(853, 45)
        Me.TrackBar1.TabIndex = 2
        '
        'frmResultContour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 598)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.ContourPaint1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "frmResultContour"
        Me.Text = "frmResultContour"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContourPaint1 As DrawContour.ContourPaintForm
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
End Class
