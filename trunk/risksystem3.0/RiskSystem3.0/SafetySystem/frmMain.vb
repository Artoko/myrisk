Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI
Imports VS2005Extender
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Xml.Serialization
Imports System.Threading
Imports DisForm
Imports DataLib
Public Class frmMain
    Private m_Sucess As Boolean = False

    Public SolutionExplorer As New frmSolution  '项目管理器窗口
    Public Result As New frmResult '结果窗口
    'Public OutWindow As New frmOut '输出窗口

    Public DrawContourWindow As New frmDrawContour '绘图窗口

    'Public DrawLay As New frmDrawLayer '绘图图层窗口
    ''' <summary>
    ''' 火灾爆炸概述窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public GeneralWindow As New frmGeneral
    ''' <summary>
    ''' 下风向浓度计算结果概述
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultVaneMax As New frmVaneMax  '计算结果概述窗口
    ''' <summary>
    ''' 关心点的浓度变化
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultCareCon As New frmCareCon '计算
    ''' <summary>
    ''' 关心点的浓度限值
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultCareMax As New frmCareMax
    ''' <summary>
    ''' 下风向浓度分布
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultVine As New frmVane
    ''' <summary>
    ''' 瞬时重气体浓度分布
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultHeavy As New frmHeavyCon
    ''' <summary>
    ''' 连续重气体参数窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultSlab As New frmSlabCon
    ''' <summary>
    ''' 事故风险值
    ''' </summary>
    ''' <remarks></remarks>
    Public frmRisk As New frmRisk
    ''' <summary>
    ''' 爆炸TNT曲线图
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultTNT As New frmTNTResult
    ''' <summary>
    ''' 火灾曲线图
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultFire As New frmFireResult
    ''----------------------------------------------------------------------------------
    Private m_ChildFormNumber As Integer = 0
    Private oDefaultRenderer As New ToolStripProfessionalRenderer(New PropertyGridEx.CustomColorScheme)
    Public OutPutFileNames(-1) As String '用于储存AERMOD的有所文件名
    Private ControlFileNames(-1) As String '用于储存AERMOD的控制流文件名
    Private Filename() As String = New String() {"frmMain.vb", _
                                                 "frmMain.vb [Design]", _
                                                 "frmDocument.vb", _
                                                 "frmDocument.vb [Design]", _
                                                 "frmProperty.vb", _
                                                 "frmProperty.vb [Design]", _
                                                 "frmSolution.vb", _
                                                 "frmSolution.vb [Design]"}

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.ProductName
        Dim configFile As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config")

        ' Apply a gray professional renderer as a default renderer
        ToolStripManager.Renderer = oDefaultRenderer
        oDefaultRenderer.RoundedEdges = False

        ' Set DockPanel properties
        DockPanel.ActiveAutoHideContent = Nothing
        DockPanel.Parent = Me
        'VS2005Style.Extender.SetSchema(DockPanel, VS2005Style.Extender.Schema.FromBase)

        DockPanel.SuspendLayout(True)
        '把控件设置为中文
        'Steema.TeeChart.Languages.ChineseSimp.Activate()
        NewRisk()
    End Sub
    
    

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Project0.IsSaved = False
        SaveToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub


    Private Sub PorjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorjectToolStripMenuItem.Click
        If PorjectToolStripMenuItem.CheckState = CheckState.Unchecked Then
            Me.SolutionExplorer.Show()
            PorjectToolStripMenuItem.Checked = True
        Else
            SolutionExplorer.Hide()
            PorjectToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub PropertyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyToolStripMenuItem.Click
        If PropertyToolStripMenuItem.CheckState = CheckState.Unchecked Then
            Result.Show()
            PropertyToolStripMenuItem.Checked = True
        Else
            Result.Hide()
            PropertyToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub OutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutToolStripMenuItem.Click
        If OutToolStripMenuItem.CheckState = CheckState.Unchecked Then
            'OutWindow.Show()
            OutToolStripMenuItem.Checked = True
        Else
            'OutWindow.Hide()
            OutToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub 重置窗口布局RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重置窗口布局RToolStripMenuItem.Click
        'OutWindow.DockState = DockState.DockBottom
        Result.DockState = Docking.DockState.DockLeft
        SolutionExplorer.DockState = Docking.DockState.DockLeft
    End Sub

    Private Sub ViewMenu_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ViewMenu.Paint
        'If Me.OutWindow.IsHidden = True Then
        '    OutToolStripMenuItem.Checked = False
        'Else
        '    OutToolStripMenuItem.Checked = True
        'End If
        If Me.SolutionExplorer.IsHidden = True Then
            PorjectToolStripMenuItem.Checked = False
        Else
            PorjectToolStripMenuItem.Checked = True
        End If
        If Me.Result.IsHidden = True Then
            PropertyToolStripMenuItem.Checked = False
        Else
            PropertyToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub 注册RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 注册RToolStripMenuItem.Click
        Dim dlg As New dlgRegedit
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim a As New dlgAbout
        a.ShowDialog()

    End Sub
    Private Sub 运行RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRun.Click
        Run()
    End Sub

    Private Sub Run()
        MenuRun.Enabled = False
        ToolRun.Enabled = False
        Me.Status.Text = "正在计算"
        Me.ProgressBar.Visible = True
        If BackgroundWorkerAermod.IsBusy Then
            '程序正在进行上一个计算，请稍候再计算
            MsgBox("程序正在进行上一个计算，请稍候再计算")
        Else
            Cursor = Cursors.WaitCursor
            BackgroundWorkerAermod.RunWorkerAsync() '执行后台程序
        End If
        '打开时钟
        Timer1.Start()
        
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRun.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '先保存文件
        SaveAs(False)
        '运行
        Run()
    End Sub
    Private Sub BackgroundWorkerAermod_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerAermod.DoWork
        m_Sucess = False
        If Project0.PType = 0 Then
            '初始化计算的气象参数。也就是根据观测的气象数据计算出当天的稳定度来
            If Project0.SurfMet IsNot Nothing AndAlso Project0.SurfMet.ArrayMetData.Length > 0 Then
                Dim SurMet As Met.MetGeneral = Project0.SurfMet.Clone
                If SurMet.IsInsert = True Then '对气象数据插值处理
                    SurMet.InsetAllMetData()
                End If
                For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    If Project0.Dis0.Forecast.Met(i).u2 < 0.3 Then
                        Project0.Dis0.Forecast.Met(i).u2 = 0
                    End If
                Next
                Project0.PreMet() '预处理气象数据
                Project0.Dis0.Intial_CalRisk() '计算风险值
                m_Sucess = True
            Else
                MsgBox("请输入地面气象数据")
            End If

        Else
            Project0.FAndB.Cal() '计算所有的火灾爆炸方案
            m_Sucess = True
        End If

    End Sub

    Private Sub BackgroundWorkerAermod_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerAermod.RunWorkerCompleted
        SaveAs(False)
        Dim Mainform As frmMain = My.Application.ApplicationContext.MainForm
        Mainform.Status2.Text = ""
        Mainform.ProgressBar.Visible = False
        '关闭时钟
        Timer1.Stop()
        MenuRun.Enabled = True
        ToolRun.Enabled = True
        If Me.m_Sucess = True Then
            RefreshResult() ' 更新计算结果
        End If
        Cursor = Cursors.Default
        Mainform.Status.Text = "就绪"
        Me.Status.Text = "计算完毕。"

    End Sub
    ''' <summary>
    ''' 更新计算结果
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshResult()
        If Project0.PType = 0 Then
            '更新等值线图的结果
            RereshResultContour()
            'RereshDisChart()
            Try
                Result.RefreshCoutour(0, 0)
            Catch ex As Exception

            End Try
            RefreshAllize() '结果分析

        Else
            RereshResultContour()
            RefreshFireGeneral() '概述
            Me.Result.RefreshFireCountor() '显示结果
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim pro As Double = Project0.Dis0.Results.AllProgress / Project0.Dis0.Results.AllCalMount
        If pro > 1 Then
            pro = 1
        End If
        Me.Status.Text = "总进度已完成" & FormatNumber(pro * 100, 1) & "%"
        Me.Status2.Text = Project0.Dis0.Results.Status2
    End Sub

    Private Sub 绘图窗口ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 绘图窗口ToolStripMenuItem.Click
        If 绘图窗口ToolStripMenuItem.CheckState = CheckState.Unchecked Then
            Me.DrawContourWindow.Show()
            绘图窗口ToolStripMenuItem.Checked = True
        Else
            Me.DrawContourWindow.Hide()
            绘图窗口ToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub DrawContour()

    End Sub


    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click
        SaveAs(False)
    End Sub
    Private Function SaveAs(ByVal S As Boolean) As Boolean
        Me.Status.Text = "正在保存文件"
        Try
            Dim SaveFileDialog1 As New SaveFileDialog
            Dim sFile As String
            Dim strNameLast As String
            If Project0.IsSaved = False Or S = True Then

                With SaveFileDialog1
                    .Filter = "环境风险评价系统文件 (*.rsk)|*.rsk"
                    .ShowDialog()
                    If Len(.FileName) = 0 Then
                        Return False
                    End If
                    sFile = .FileName
                End With
            Else
                sFile = Project0.SaveName
            End If
            ' To write to a file, create a StreamWriter object.
            strNameLast = GetFileName(sFile)
            Me.Text = My.Application.Info.ProductName & My.Application.Info.Version.ToString.Substring(0, 3) & "--" & strNameLast
            Project0.SaveName = sFile
            SolutionExplorer.TreeView.Nodes(0).Text = strNameLast
            Project0.IsSaved = True

            ' Create a filestream object
            Dim fileStr As Stream = File.Open(sFile, FileMode.Create)
            ' Create a linked list object and populate it with random nodes
            Dim AllProject As New Project
            AllProject = Project0
              ' Create a formatter object based on command line arguments
            Dim formatter As IFormatter
            formatter = CType(New BinaryFormatter, IFormatter)
            ' Serialize the object graph to stream
            formatter.Serialize(fileStr, AllProject)
            fileStr.Dispose()
            ' All done
            fileStr.Close()

            Try
                fileStr = File.Open(sFile, FileMode.Open)

                formatter = CType(New BinaryFormatter, IFormatter)
                fileStr.Seek(0, SeekOrigin.Begin)
                Dim obj As Object = formatter.Deserialize(fileStr)
                ' All done
                fileStr.Close()
            Catch ex As Exception
                fileStr.Close()
                MsgBox("保存文件时出现意外错误，请重新保存!")
                Return False
            End Try
            Me.Status.Text = "文件保存完毕"
            Return True
        Catch ex As Exception
            MsgBox("保存文件时出现意外错误，请重新保存!")
            Return False
        End Try
    End Function


    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click, OpenToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MessageBox.Show("是否要保存当前的项目?", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If Result = MsgBoxResult.Yes Then
            SaveToolStripMenuItem_Click(sender, e) '保存项目
            OpenFilefun()
        ElseIf Result = MsgBoxResult.No Then '不保存
            OpenFilefun()
        ElseIf Result = MsgBoxResult.Cancel Then '取消

        End If
    End Sub
    Private Sub OpenFilefun()
        '--------------------------------------------------------------------
        '正式版代码
        '-----------------------------------------------------------------------

        Dim sFile As String '文件名
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Filter = "环境风险评价系统文件 (*.rsk)|*.rsk"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            With OpenFileDialog
                If Len(.FileName) = 0 Then
                    Exit Sub
                End If
                sFile = .FileName
            End With
            Dim fileStr As Stream = Nothing
            Dim formatter As IFormatter
            Dim AllProject As New Project
            Dim obj As Object

            Try
                fileStr = File.Open(sFile, FileMode.Open)

                ' Create a formatter object based on command line arguments

                formatter = CType(New BinaryFormatter, IFormatter)
                ' Deserialize the object graph from stream
                fileStr.Seek(0, SeekOrigin.Begin)
                obj = formatter.Deserialize(fileStr)
                AllProject = CType(obj, Project)
                AllProject.SaveName = sFile '设置文件名

                Project0 = AllProject
                'DrawContourWindow.ContourPaint1.SetPannelSetting(AllProject.PannelSetting)
                fileStr.Close()
                'Me.DrawContourWindow.SetPolluteDraw() '设置图形
                Dim strNameLast As String = GetFileName(sFile)
                Me.Text = My.Application.Info.ProductName & My.Application.Info.Version.ToString.Substring(0, 3) & "--" & strNameLast
                SolutionExplorer.TreeView.Nodes(0).Text = strNameLast
                'Me.SolutionExplorer.RefreshSolutionTree()
            Catch ex As Exception
                fileStr.Close()
                MsgBox("打开文件错误。可能您用的是较低版本的软件打开了较高版本保存的方案!")
            End Try
        End If
        Try
            Me.RefreshResult() '显示结果
        Catch ex As Exception
            MsgBox("可能您的方案已经改变，请重新计算!")
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '移动
        DrawContourWindow.ContourPaint1.SetMouseType(4)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '在绘图放大 
        DrawContourWindow.ContourPaint1.SetMouseType(2)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '缩小
        DrawContourWindow.ContourPaint1.SetMouseType(3)
    End Sub

    Private Sub 图表窗口ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemChart.Click

    End Sub

    ''' <summary>
    ''' 火灾爆炸概述
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshFireGeneral()
        Me.GeneralWindow.RichTextBox1.Text = ""
        Me.GeneralWindow.RichTextBox1.Text = Project0.FAndB.GetResultString(0, 0)
    End Sub

    ''' <summary>
    ''' 更新等值线图的结果
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RereshResultContour()
        Me.DrawContourWindow.cmbRusult.Items.Clear()
        Me.DrawContourWindow.cmbMet.Items.Clear()
        Me.DrawContourWindow.cmbTime.Items.Clear()
        If Project0.Dis0.Forecast.OutPut.IsInstantaneous = True Then '瞬时浓度
            Me.DrawContourWindow.cmbRusult.Items.Add("瞬时浓度")
            
        End If
        If Project0.Dis0.Forecast.OutPut.IsRisk = True Then
            If Project0.Dis0.Forecast.OutPut.ChargeOrSlip = 1 Then '滑移平均浓度
                Me.DrawContourWindow.cmbRusult.Items.Add("滑移平均浓度")
                Me.DrawContourWindow.cmbRusult.Items.Add("个人风险值")
            Else
                Me.DrawContourWindow.cmbRusult.Items.Add("死亡百分率")
                Me.DrawContourWindow.cmbRusult.Items.Add("个人风险值")
            End If
        End If
        If Me.DrawContourWindow.cmbRusult.Items.Count > 0 Then
            Me.DrawContourWindow.cmbRusult.SelectedIndex = 0
        End If

        Me.Result.TreeView1.Nodes.Clear() '清空
        Select Case Project0.PType
            Case 0 '泄漏
                Dim newNode1 As TreeNode = New TreeNode("泄漏对环境的影响计算结果") '第1层节点
                Dim newNode2 As TreeNode '第二层节点
                Dim newTreeNode As TreeNode

                '添加新的工程
                Me.Result.TreeView1.Nodes.Add(newNode1)

                For i As Integer = 0 To Project0.Dis0.Forecast.MaxMet.Length - 1
                    newNode2 = newNode1.Nodes.Add(Project0.Dis0.Forecast.MaxMet(i).Vane & "," & Project0.Dis0.Forecast.MaxMet(i).WindSpeed & "," & Project0.Dis0.Forecast.MaxMet(i).Stab)
                    For j As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                        newTreeNode = New TreeNode(Project0.Dis0.Forecast.OutPut.ForeStart + j * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
                        newTreeNode.Text = Project0.Dis0.Forecast.OutPut.ForeStart + j * Project0.Dis0.Forecast.OutPut.ForeInterval & "min"
                        newNode2.Nodes.Add(newTreeNode)
                    Next
                    If Project0.Dis0.Forecast.OutPut.IsRisk = True And Project0.Dis0.Forecast.OutPut.ChargeOrSlip = 1 Then
                        newTreeNode = New TreeNode("滑移平均最大浓度")
                        newTreeNode.Text = "滑移平均最大浓度"
                        newNode2.Nodes.Add(newTreeNode)
                    End If
                Next

            Case 1 '火灾爆炸
                Dim newNode1 As TreeNode = New TreeNode("火灾爆炸计算结果") '第1层节点
                Dim newNode2 As TreeNode '第二层节点

                '添加新的工程
                Me.Result.TreeView1.Nodes.Add(newNode1)
                Select Case Project0.FAndB.FType
                    Case 0
                        'TNT爆炸当量法
                        newNode2 = newNode1.Nodes.Add("蒸汽云爆炸，TNT当量法")
                    Case 1
                        '凝聚相爆炸
                        newNode2 = newNode1.Nodes.Add("凝聚相爆炸模型")
                    Case 2
                        '加油站爆炸
                        newNode2 = newNode1.Nodes.Add("加油站爆炸模型")
                    Case 3
                        '物理爆炸
                        newNode2 = newNode1.Nodes.Add("物理爆炸模型")
                    Case 10
                        '池火灾模型
                        newNode2 = newNode1.Nodes.Add("池火灾模型")
                    Case 11
                        '沸腾液体扩展蒸气云爆炸(BLEVE)
                        newNode2 = newNode1.Nodes.Add("沸腾液体扩展蒸气云爆炸(BLEVE)")
                    Case 12
                        '固体火灾
                        newNode2 = newNode1.Nodes.Add("固体火灾模型")
                    Case 13
                        '喷射火
                        newNode2 = newNode1.Nodes.Add("喷射火模型")
                End Select
        End Select
    End Sub
  
    Private Sub RereshCourtour()

    End Sub
    ''' <summary>
    ''' 新建泄漏预测项目
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LToolStripMenuItemL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LToolStripMenuItemL.Click
        Project0 = New Project
        Project0.Dis0 = New DisPuff.Dis '新建一个泄漏项目
        IntialLeakProject() '初始化一个泄漏项目

    End Sub
    ''' <summary>
    ''' 初始化一个泄漏项目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntialLeakProject()
        Project0.PType = 0 '泄漏
        '设置绘图网格
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ChartType = 0
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.Clear() '清空等值线数组
        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX, Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '输出窗口
        'OutWindow.Show(DockPanel, DockState.DockBottom)
        OutToolStripMenuItem.Checked = True
        '解决方案窗口
        SolutionExplorer.ExplorerBar1.Groups(0).Visible = True
        SolutionExplorer.ExplorerBar1.Groups(1).Visible = False
        SolutionExplorer.ExplorerBar1.Groups(2).Visible = False
        SolutionExplorer.ExplorerBar1.Groups(0).Expanded = True
        SolutionExplorer.Show(DockPanel, Docking.DockState.DockLeft)

        PorjectToolStripMenuItem.Checked = True
        '结果树形列表窗口
        Result.Show(DockPanel, Docking.DockState.DockLeft)
        PropertyToolStripMenuItem.Checked = True
        '等值线图图层窗口
        'DrawLay.Show(DockPanel, Docking.DockState.DockLeft)
        DrawLayToolStripMenuItem.Checked = True

        SolutionExplorer.Activate() '激活项目管理器
        DockPanel.ResumeLayout(True, True)


        '概述窗口
        'Me.GeneralWindow.Show(DockPanel, DockState.Document)
        '等值线窗口
        Me.DrawContourWindow.Show(DockPanel, Docking.DockState.Document)
        绘图窗口ToolStripMenuItem.Checked = True
        ''打开轴线图表窗口
        'Me.ResultTNT.Show(DockPanel, DockState.Document)
        'Me.ToolStripMenuItemChart.Checked = True

        Me.DrawContourWindow.Activate() '激活等值线绘图窗口

        '根据项目激活对应的菜单
        ActiveMenu()
    End Sub
    ''' <summary>
    ''' 根据项目激活对应的菜单
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveMenu()
        ' 火灾爆炸概述窗口
        GeneralWindow.Hide()
        ' 下风向浓度计算结果概述
        ResultVaneMax.Hide()
        ' 关心点的浓度变化
        ResultCareCon.Hide() 
        ' 关心点的浓度限值
        ResultCareMax.Hide()
        ' 下风向浓度分布
        ResultVine.Hide()
        ' 瞬时重气体浓度分布
        ResultHeavy.Hide()
        ' 连续重气体参数窗口
        ResultSlab.Hide()
        ' 爆炸TNT曲线图
        ResultTNT.Hide()
        ' 火灾曲线图
        ResultFire.Hide()

        If Project0 IsNot Nothing Then
            执行ToolStripMenuItem.Visible = True
            If Project0.PType = 0 Then '泄漏
                最大浓度及浓度限值分析ToolStripMenuItem.Visible = True
                下风向浓度分析VToolStripMenuItem.Visible = True
                关心点浓度分析ToolStripMenuItem.Visible = True
                关心点浓度限值分析AToolStripMenuItem.Visible = True
                重气体浓度分析ToolStripMenuItem.Visible = True
                连续重气体浓度分析SToolStripMenuItem.Visible = True
                火灾爆炸事故概述GToolStripMenuItem.Visible = False
                火灾事故热辐热分析HToolStripMenuItem.Visible = False
                爆炸事故冲击波超压PToolStripMenuItem.Visible = False
            ElseIf Project0.PType = 1 Then '火灾爆炸
                最大浓度及浓度限值分析ToolStripMenuItem.Visible = False
                下风向浓度分析VToolStripMenuItem.Visible = False
                关心点浓度分析ToolStripMenuItem.Visible = False
                关心点浓度限值分析AToolStripMenuItem.Visible = False
                重气体浓度分析ToolStripMenuItem.Visible = False
                连续重气体浓度分析SToolStripMenuItem.Visible = False
                火灾爆炸事故概述GToolStripMenuItem.Visible = True

                If Project0.FAndB.FType < 10 Then '爆炸事故
                    火灾事故热辐热分析HToolStripMenuItem.Visible = False
                    爆炸事故冲击波超压PToolStripMenuItem.Visible = True
                Else '爆炸
                    火灾事故热辐热分析HToolStripMenuItem.Visible = True
                    爆炸事故冲击波超压PToolStripMenuItem.Visible = False
                End If
            End If
        Else
            执行ToolStripMenuItem.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' 初始化等值线图的最大值，最小值和网格点
    ''' </summary>
    ''' <param name="Xmin"></param>
    ''' <param name="Xstep"></param>
    ''' <param name="XCount"></param>
    ''' <param name="Ymin"></param>
    ''' <param name="Ystep"></param>
    ''' <param name="YCount"></param>
    ''' <remarks></remarks>
    Private Sub intialDrawData(ByVal Xmin As Integer, ByVal Xstep As Integer, ByVal XCount As Integer, ByVal Ymin As Integer, ByVal Ystep As Integer, ByVal YCount As Integer)
        '设置等值线区域x,y方向上的最大值、最小值及网格个数
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '设置起始坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmax = Xmin + (XCount - 1) * Xstep '设置X轴的终点坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nCols = XCount '设置数据的个数
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '设置起始坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymax = Ymin + (YCount - 1) * Ystep  '设置y轴的终点坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nRows = YCount '设置数据的个数
        '初始化网格数组
        ReDim Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.GridPoint( _
                 Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nRows - 1, Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nCols - 1)
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.InitialPaint()
        Me.Refresh()
    End Sub
    ''' <summary>
    ''' 设置等值线的图的属性值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPropety(ByVal Xstep As Integer, ByVal Ystep As Integer)
        With Me.DrawContourWindow.ContourPaint1.ContourPaintSetting
            '设置绘图面板数据
            .ResetCountData()
            '设置等值线图左轴、标题可见
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleName = "Y轴"
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleName = "X轴"
            '设置左轴的增加值,并使左刻度可见
            .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Ystep
            .ContourPannel.Axes.LeftAxis.MainAxisScale.ScaleVisible = True
            '设置底轴的增加值，并使底刻度可见
            .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = Xstep
            .ContourPannel.Axes.BottomAxis.MainAxisScale.ScaleVisible = True
            '设置右轴的增加值,并使左刻度不可见
            .ContourPannel.Axes.RightAxis.MainAxisScale.Increase = .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase
            .ContourPannel.Axes.RightAxis.MainAxisScale.ScaleVisible = False
            '设置顶轴增加值，并使底刻度不可见
            .ContourPannel.Axes.TopAxis.MainAxisScale.Increase = .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase
            .ContourPannel.Axes.TopAxis.MainAxisScale.ScaleVisible = False

            '设置左轴刻度的标注可见
            .ContourPannel.Axes.LeftAxis.AxisLabel.LabelVisible = True
            '设置底轴刻度的标注可见
            .ContourPannel.Axes.BottomAxis.AxisLabel.LabelVisible = True

            '设置网格不可见
            .ContourPannel.Axes.LeftAxis.AxisGridding.AxisGriddingVisible = False
            .ContourPannel.Axes.BottomAxis.AxisGridding.AxisGriddingVisible = False


            Me.Refresh()
        End With
    End Sub
    Private Sub intialFireDrawData(ByVal Xmin As Integer, ByVal XMax As Integer, ByVal Ymin As Integer, ByVal Ymax As Integer)
        '设置等值线区域x,y方向上的最大值、最小值及网格个数
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '设置起始坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmax = XMax '设置X轴的终点坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '设置起始坐标
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymax = Ymax  '设置y轴的终点坐标
        '初始化网格数组
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.InitialPaint()
        Me.Refresh()
    End Sub
    Private Sub ToolStripMenuItemF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemF.Click
        Project0 = New Project
        Project0.FAndB = New FireBlast.FAndB '新建火灾爆炸模型
        InitialFireProject() ' 初始化火灾爆炸项目
    End Sub
   

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '关心点
        DrawContourWindow.ContourPaint1.SetMouseType(5)
    End Sub

    Private Sub mnuLeakGas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakGas.Click
        '打开气体泄漏量计算对话框
        Dim frmNewLeakGas As New frmLeakGas
        Static nGas As Short
        nGas = nGas + 1
        Dim strName As String
        strName = "未标题" & nGas
        frmNewLeakGas.Text = "气体泄漏量计算--" & strName
        frmNewLeakGas.ShowDialog()
    End Sub


    Private Sub mnuLeakTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakTwo.Click
        '打开两相流计算对话框
        Dim frmNewLeakTwo As New frmLeakTwo
        Static nTwo As Short
        nTwo = nTwo + 1
        Dim strName As String
        strName = "未标题" & nTwo
        frmNewLeakTwo.Text = "两相流泄漏量计算--" & strName
        frmNewLeakTwo.ShowDialog()
    End Sub

    Private Sub mnuLeakFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakFlash.Click
        '打开液体闪蒸量计算对话框
        Dim frmNewLeakFlash As New frmLeakFlash
        Static nFlash As Short
        nFlash = nFlash + 1
        Dim strName As String
        strName = "未标题" & nFlash
        frmNewLeakFlash.Text = "闪蒸量计算--" & strName
        frmNewLeakFlash.ShowDialog()
    End Sub

    Private Sub mnuLeakHeat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakHeat.Click
        '打开热量蒸发量计算对话框
        Dim frmNewLeakHeat As New frmLeakHeat
        Static nHeat As Short
        nHeat = nHeat + 1
        Dim strName As String
        strName = "未标题" & nHeat
        frmNewLeakHeat.Text = "热量蒸发量计算--" & strName
        frmNewLeakHeat.ShowDialog()
    End Sub

    Private Sub mnuLeakQuality_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakQuality.Click
        '打开质量蒸发量计算对话框
        Dim frmNewLeakQuality As New frmLeakQuality
        Static nQuality As Short
        nQuality = nQuality + 1
        Dim strName As String
        strName = "未标题" & nQuality
        frmNewLeakQuality.Text = "质量蒸发量计算--" & strName
        frmNewLeakQuality.ShowDialog()
    End Sub

    Private Sub mnuLeakLiquid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakLiquid.Click
        '打开液体泄漏量计算对话框
        Dim frmNewLeakLiquid As New frmLeakLiquid
        Static nLiquid As Short
        nLiquid = nLiquid + 1
        Dim strName As String
        strName = "未标题" & nLiquid
        frmNewLeakLiquid.Text = "液体泄漏量计算--" & strName
        frmNewLeakLiquid.ShowDialog()
    End Sub

    Private Sub 常用危险化学品物理化学性质数据库ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 常用危险化学品物理化学性质数据库ToolStripMenuItem.Click
        Dim frmNew As New frmSearchData
        frmNew.txtInT.Visible = True
        frmNew.txtInT.Text = 30
        frmNew.txtGasP.Visible = True
        frmNew.txtGasK.Visible = True
        frmNew.txtHc.Visible = True
        frmNew.txtCP.Visible = True
        frmNew.txtGasCp.Visible = True
        frmNew.txtH.Visible = True
        frmNew.txtOutT.Visible = True
        frmNew.txtOutT.Text = 30
        frmNew.txtOutGasP.Visible = True
        frmNew.txtLC50.Visible = True
        frmNew.txtLMax.Visible = True
        frmNew.ShowDialog()
    End Sub

    Private Sub 全国各地气压数据库PToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全国各地气压数据库PToolStripMenuItem.Click
        Dim frmRang As New SelectDrang
        frmRang.ShowDialog()
    End Sub

    
    Private Sub 最大浓度及浓度限值分析ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 最大浓度及浓度限值分析ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            Me.ResultVaneMax.ReLoad = True
            Me.ResultVaneMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If

    End Sub

    Private Sub 关心点浓度分析ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 关心点浓度分析ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareCon.ReLoad = True
            ResultCareCon.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
    End Sub

    Private Sub 关心点浓度限值分析AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 关心点浓度限值分析AToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareMax.ReLoad = True
            ResultCareMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
    End Sub

    Private Sub 下风向浓度分析VToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 下风向浓度分析VToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultVine.ReLoad = True
            ResultVine.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
    End Sub



    Private Sub 重气体浓度分析ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重气体浓度分析ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultHeavy.ReLoad = True
            ResultHeavy.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
    End Sub

    Private Sub 连续重气体浓度分析SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 连续重气体浓度分析SToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultSlab.ReLoad = True
            ResultSlab.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
    End Sub

    '更新结果分析
    Private Sub RefreshAllize()
        If Project0.Dis0.Results.AllGridResult.ArrayRisk.Length > 0 Then
            Me.frmRisk.ReLoad = True
            Me.frmRisk.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            Me.ResultVaneMax.ReLoad = True
            Me.ResultVaneMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareCon.ReLoad = True
            ResultCareCon.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareMax.ReLoad = True
            ResultCareMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultVine.ReLoad = True
            ResultVine.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("没有计算结果，请计算后再分析!")
        End If


        If Project0.Dis0.IntialSource.IsHeavy Then
            If Project0.Dis0.Results.MetResults.Length > 0 Then
                ResultHeavy.ReLoad = True
                ResultHeavy.Show(DockPanel, Docking.DockState.Document)
            Else
                MsgBox("没有计算结果，请计算后再分析!")
            End If
            If Project0.Dis0.Results.MetResults.Length > 0 Then
                ResultSlab.ReLoad = True
                ResultSlab.Show(DockPanel, Docking.DockState.Document)
            Else
                MsgBox("没有计算结果，请计算后再分析!")
            End If
        End If
    End Sub

    Private Sub 大气稳定度计算SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 大气稳定度计算SToolStripMenuItem.Click


        Dim frmNewPS As New frmPS
        frmNewPS.Text = "大气稳定度计算"
        frmNewPS.ShowDialog()
    End Sub

    Private Sub 爆炸事故冲击波超压PToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 爆炸事故冲击波超压PToolStripMenuItem.Click
        ResultTNT.ReLoad = True
        ResultTNT.Show(DockPanel, Docking.DockState.Document)
    End Sub

    Private Sub 火灾事故热辐热分析HToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 火灾事故热辐热分析HToolStripMenuItem.Click
        ResultFire.ReLoad = True
        ResultFire.Show(DockPanel, Docking.DockState.Document)
    End Sub

    Private Sub 火灾爆炸事故概述GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 火灾爆炸事故概述GToolStripMenuItem.Click

        GeneralWindow.Show(DockPanel, Docking.DockState.Document)
    End Sub

    Private Sub ToolStripButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '剪切区域
        DrawContourWindow.ContourPaint1.SetMouseType(6)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '箭头形
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
    End Sub

    Private Sub IndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndexToolStripMenuItem.Click, HelpToolStripButton.Click
        Dim Help As String
        If My.Application.Info.DirectoryPath = "\" Then
            Help = My.Application.Info.DirectoryPath & "HELP.chm"
        Else
            Help = My.Application.Info.DirectoryPath & "\" & "HELP.chm"
        End If
        Shell("hh.exe " & Help, AppWinStyle.NormalFocus)
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MessageBox.Show("是否要保存当前的项目?", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If Result = MsgBoxResult.Yes Then
            SaveToolStripMenuItem_Click(sender, e) '保存项目
            NewRisk() '新建1个项目
        ElseIf Result = MsgBoxResult.No Then '不保存
            NewRisk() '新建1个项目
        ElseIf Result = MsgBoxResult.Cancel Then '取消

        End If
        NewRisk()
    End Sub

    Private Sub NewRisk()
        '新建一个项目
        Project0 = New Project
        Project0.Dis0.Forecast.IsCalGrid = True
        SetTree()
        Me.Text = My.Application.Info.ProductName & My.Application.Info.Version.ToString.Substring(0, 3) & "--" & SolutionExplorer.TreeView.Nodes(0).Text
        IntialLeakProject()
        SetPropety()
        '网格嵌套


        Me.DrawContourWindow.SetPolluteDraw() '设置图形
        'Me.ModifyResults() '修改结果
        'Me.ResultTypeDayWindow.Hide()
        'Me.ResultDataWindow.Hide()
        'Me.MaxResultWindow.Hide()
        'Me.MaxiFileWindow.Hide()
        'PostFileWinow.Hide()


    End Sub
    ''' <summary>
    ''' 设置项目在列表中的内容
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTree()
        Static n As Integer = 0
        n = n + 1
        SolutionExplorer.TreeView.Nodes.Clear() '删除现有项目

        If SolutionExplorer.IsActivated = False Then '如果未激活，则激活
            SolutionExplorer.Activate()
        End If


        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm '当前活动的主窗口
        Dim newNode1 As TreeNode = New TreeNode("未命名工程" & n) '第1层节点
        Dim newNode2 As TreeNode '第二层节点
        Dim newTreeNode As TreeNode

        '添加新的工程
        SolutionExplorer.TreeView.Nodes.Add(newNode1)

        '背景图
        newNode2 = newNode1.Nodes.Add("背景图")
        newTreeNode = New TreeNode("地理位置图")
        newTreeNode.Text = "地理位置图"
        newNode2.Nodes.Add(newTreeNode)
        newTreeNode = New TreeNode("厂区平面图")
        newTreeNode.Text = "厂区平面图"
        newNode2.Nodes.Add(newTreeNode)

        '污染源

        newNode2 = newNode1.Nodes.Add("事故源")

        newTreeNode = New TreeNode("事故源项")
        newTreeNode.Text = "事故源项"
        newNode2.Nodes.Add(newTreeNode)

        '物质属性
        newNode2 = newNode1.Nodes.Add("物质属性")
        newTreeNode = New TreeNode("物质的物理化学性质及毒性")
        newTreeNode.Text = "物质的物理化学性质及毒性"
        newNode2.Nodes.Add(newTreeNode)

        '网格和关心点
        newNode2 = newNode1.Nodes.Add("计算点")

        newTreeNode = New TreeNode("下风向")
        newTreeNode.Text = "下风向"
        newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("网格")
        newTreeNode.Text = "网格"
        newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("人口分布")
        newTreeNode.Text = "人口分布"
        newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("关心点")
        newTreeNode.Text = "关心点"
        newNode2.Nodes.Add(newTreeNode)

        '气象条件
        newNode2 = newNode1.Nodes.Add("气象数据")

        'newTreeNode = New TreeNode("气象数据选项")
        'newTreeNode.Text = "气象数据选项"
        'newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("逐时地面气象数据")
        newTreeNode.Text = "逐时地面气象数据"
        newNode2.Nodes.Add(newTreeNode)
        ''地形数据
        'newNode2 = newNode1.Nodes.Add("地形数据")

        'newTreeNode = New TreeNode("地形数据选项")
        'newTreeNode.Text = "地形数据选项"
        'newNode2.Nodes.Add(newTreeNode)

        '输出控制
        newNode2 = newNode1.Nodes.Add("输出控制")
        newTreeNode = New TreeNode("输出选项")
        newTreeNode.Text = "输出选项"
        newNode2.Nodes.Add(newTreeNode)

        '展开所有节点
        SolutionExplorer.TreeView.ExpandAll()
        '计算结果

        '绘图
        'ModifyTree()
    End Sub

    ''' <summary>
    ''' 初始化火灾爆炸项目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitialFireProject()
        '设置绘图网格
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting = New DrawContour.ContourPaintSetting

        Project0.PType = 1 '火灾爆炸
        '设置绘图网格
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ChartType = 1
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.Clear()

        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)

        '输出窗口
        'OutWindow.Show(DockPanel, DockState.DockBottom)
        OutToolStripMenuItem.Checked = True
        '解决方案窗口

        SolutionExplorer.ExplorerBar1.Groups(0).Visible = False
        SolutionExplorer.ExplorerBar1.Groups(1).Visible = True
        SolutionExplorer.ExplorerBar1.Groups(2).Visible = True
        SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True
        SolutionExplorer.ExplorerBar1.Groups(1).Expanded = True
        SolutionExplorer.ExplorerBar1.Groups(2).Expanded = True
        SolutionExplorer.Show(DockPanel, Docking.DockState.DockLeft)
        PorjectToolStripMenuItem.Checked = True
        '结果树形列表窗口
        Result.TreeView1.Nodes.Clear() '清空窗口
        Result.Show(DockPanel, Docking.DockState.DockLeft)
        PropertyToolStripMenuItem.Checked = True
        '等值线图图层窗口
        'DrawLay.Show(DockPanel, Docking.DockState.DockLeft)
        DrawLayToolStripMenuItem.Checked = True

        SolutionExplorer.Activate() '激活项目管理器
        DockPanel.ResumeLayout(True, True)


        '概述窗口
        'Me.GeneralWindow.Show(DockPanel, DockState.Document)
        '等值线窗口
        Me.DrawContourWindow.Show(DockPanel, Docking.DockState.Document)
        绘图窗口ToolStripMenuItem.Checked = True
        ''打开轴线图表窗口
        'Me.ResultTNT.Show(DockPanel, DockState.Document)
        'Me.ToolStripMenuItemChart.Checked = True

        Me.DrawContourWindow.Activate() '激活等值线绘图窗口
        '
        '根据项目激活对应的菜单
        ActiveMenu()
    End Sub

    ''' <summary>
    ''' 设置等值线的图的属性值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPropety()
        With Me.DrawContourWindow.ContourPaint1.ContourPaintSetting
            '初始化绘图面板
            .InitialPaint()
            '设置绘图面板数据
            .ResetCountData()

            '设置左轴的增加值,并使左刻度可见
            .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Project0.Dis0.Forecast.Grid.StepY
            '设置底轴的增加值，并使底刻度可见
            .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = Project0.Dis0.Forecast.Grid.StepX
            '设置右轴的增加值,并使左刻度不可见
            .ContourPannel.Axes.RightAxis.MainAxisScale.Increase = .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase

            '设置顶轴增加值，并使底刻度不可见
            .ContourPannel.Axes.TopAxis.MainAxisScale.Increase = .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase

            Me.Refresh()
        End With
    End Sub
    Private Sub 新建NToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新建NToolStripButton.Click
        NewRisk()
    End Sub

    
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Me.DrawContourWindow.ContourPaint1.SetMouseType(1) '十字形
        Me.DrawContourWindow.AddProject = True
        Me.DrawContourWindow.SourceType = 11 '建筑物
        Me.DrawContourWindow.ContourPaint1.ContextMenuStrip = Me.DrawContourWindow.MenuPoly
        ReDim Me.DrawContourWindow.ArrayPoint(-1) '初始化坐标
    End Sub

    Private Sub ToolResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolResult.Click
        Dim frmReslt As New frmResultMain
        frmReslt.ShowDialog()

    End Sub
End Class
