<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopulation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopulation))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.cmdDel = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ListSubGrid = New System.Windows.Forms.ListBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.BCrooCr = New System.Windows.Forms.Button
        Me.BCrooDel = New System.Windows.Forms.Button
        Me.EFlexCoor = New Chart.EFlex
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPopulation = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txt = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EFlexCoor, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(301, 361)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 3
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
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.AutomaticDelay = 200
        Me.C1SuperTooltip1.AutoPopDelay = 8000
        Me.C1SuperTooltip1.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Blue
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RoundedCorners = True
        '
        'cmdDel
        '
        Me.cmdDel.Location = New System.Drawing.Point(69, 329)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(57, 20)
        Me.cmdDel.TabIndex = 30
        Me.cmdDel.Text = "删除(&D)"
        Me.C1SuperTooltip1.SetToolTip(Me.cmdDel, resources.GetString("cmdDel.ToolTip"))
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(3, 329)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(57, 20)
        Me.cmdAdd.TabIndex = 29
        Me.cmdAdd.Text = "添加(&A)"
        Me.C1SuperTooltip1.SetToolTip(Me.cmdAdd, resources.GetString("cmdAdd.ToolTip"))
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(1, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "区域名称:"
        '
        'ListSubGrid
        '
        Me.ListSubGrid.FormattingEnabled = True
        Me.ListSubGrid.ItemHeight = 12
        Me.ListSubGrid.Location = New System.Drawing.Point(3, 25)
        Me.ListSubGrid.Name = "ListSubGrid"
        Me.ListSubGrid.Size = New System.Drawing.Size(132, 292)
        Me.ListSubGrid.TabIndex = 31
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BCrooCr)
        Me.GroupBox5.Controls.Add(Me.BCrooDel)
        Me.GroupBox5.Controls.Add(Me.EFlexCoor)
        Me.GroupBox5.Location = New System.Drawing.Point(150, 72)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(288, 245)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "顶点坐标"
        '
        'BCrooCr
        '
        Me.BCrooCr.Location = New System.Drawing.Point(31, 216)
        Me.BCrooCr.Name = "BCrooCr"
        Me.BCrooCr.Size = New System.Drawing.Size(66, 23)
        Me.BCrooCr.TabIndex = 7
        Me.BCrooCr.Text = "增加"
        Me.BCrooCr.UseVisualStyleBackColor = True
        '
        'BCrooDel
        '
        Me.BCrooDel.Location = New System.Drawing.Point(142, 216)
        Me.BCrooDel.Name = "BCrooDel"
        Me.BCrooDel.Size = New System.Drawing.Size(66, 23)
        Me.BCrooDel.TabIndex = 8
        Me.BCrooDel.Text = "删除"
        Me.BCrooDel.UseVisualStyleBackColor = True
        '
        'EFlexCoor
        '
        Me.EFlexCoor.ColumnInfo = resources.GetString("EFlexCoor.ColumnInfo")
        Me.EFlexCoor.IsCopy = True
        Me.EFlexCoor.IsCut = True
        Me.EFlexCoor.IsPaste = True
        Me.EFlexCoor.Location = New System.Drawing.Point(6, 20)
        Me.EFlexCoor.Name = "EFlexCoor"
        Me.EFlexCoor.Rows.Count = 1
        Me.EFlexCoor.Rows.DefaultSize = 18
        Me.EFlexCoor.Size = New System.Drawing.Size(247, 181)
        Me.EFlexCoor.StyleInfo = resources.GetString("EFlexCoor.StyleInfo")
        Me.EFlexCoor.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(154, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "区域名称:"
        '
        'txtPopulation
        '
        Me.txtPopulation.Location = New System.Drawing.Point(219, 45)
        Me.txtPopulation.Name = "txtPopulation"
        Me.txtPopulation.Size = New System.Drawing.Size(116, 21)
        Me.txtPopulation.TabIndex = 35
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(219, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(116, 21)
        Me.txtName.TabIndex = 36
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(166, 48)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(47, 12)
        Me.txt.TabIndex = 37
        Me.txt.Text = "人口数:"
        '
        'frmPopulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 400)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtPopulation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.ListSubGrid)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPopulation"
        Me.Text = "区域人口"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.EFlexCoor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListSubGrid As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BCrooCr As System.Windows.Forms.Button
    Friend WithEvents BCrooDel As System.Windows.Forms.Button
    Friend WithEvents EFlexCoor As Chart.EFlex
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPopulation As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txt As System.Windows.Forms.Label
End Class
