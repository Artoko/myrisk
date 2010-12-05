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

    Public SolutionExplorer As New frmSolution  '��Ŀ����������
    Public Result As New frmResult '�������
    'Public OutWindow As New frmOut '�������

    Public DrawContourWindow As New frmDrawContour '��ͼ����

    'Public DrawLay As New frmDrawLayer '��ͼͼ�㴰��
    ''' <summary>
    ''' ���ֱ�ը��������
    ''' </summary>
    ''' <remarks></remarks>
    Public GeneralWindow As New frmGeneral
    ''' <summary>
    ''' �·���Ũ�ȼ���������
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultVaneMax As New frmVaneMax  '��������������
    ''' <summary>
    ''' ���ĵ��Ũ�ȱ仯
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultCareCon As New frmCareCon '����
    ''' <summary>
    ''' ���ĵ��Ũ����ֵ
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultCareMax As New frmCareMax
    ''' <summary>
    ''' �·���Ũ�ȷֲ�
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultVine As New frmVane
    ''' <summary>
    ''' ˲ʱ������Ũ�ȷֲ�
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultHeavy As New frmHeavyCon
    ''' <summary>
    ''' �����������������
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultSlab As New frmSlabCon
    ''' <summary>
    ''' �¹ʷ���ֵ
    ''' </summary>
    ''' <remarks></remarks>
    Public frmRisk As New frmRisk
    ''' <summary>
    ''' ��ըTNT����ͼ
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultTNT As New frmTNTResult
    ''' <summary>
    ''' ��������ͼ
    ''' </summary>
    ''' <remarks></remarks>
    Public ResultFire As New frmFireResult
    ''----------------------------------------------------------------------------------
    Private m_ChildFormNumber As Integer = 0
    Private oDefaultRenderer As New ToolStripProfessionalRenderer(New PropertyGridEx.CustomColorScheme)
    Public OutPutFileNames(-1) As String '���ڴ���AERMOD�������ļ���
    Private ControlFileNames(-1) As String '���ڴ���AERMOD�Ŀ������ļ���
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
        '�ѿؼ�����Ϊ����
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

    Private Sub ���ô��ڲ���RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ô��ڲ���RToolStripMenuItem.Click
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

    Private Sub ע��RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ע��RToolStripMenuItem.Click
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
    Private Sub ����RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRun.Click
        Run()
    End Sub

    Private Sub Run()
        MenuRun.Enabled = False
        ToolRun.Enabled = False
        Me.Status.Text = "���ڼ���"
        Me.ProgressBar.Visible = True
        If BackgroundWorkerAermod.IsBusy Then
            '�������ڽ�����һ�����㣬���Ժ��ټ���
            MsgBox("�������ڽ�����һ�����㣬���Ժ��ټ���")
        Else
            Cursor = Cursors.WaitCursor
            BackgroundWorkerAermod.RunWorkerAsync() 'ִ�к�̨����
        End If
        '��ʱ��
        Timer1.Start()
        
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRun.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '�ȱ����ļ�
        SaveAs(False)
        '����
        Run()
    End Sub
    Private Sub BackgroundWorkerAermod_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerAermod.DoWork
        m_Sucess = False
        If Project0.PType = 0 Then
            '��ʼ����������������Ҳ���Ǹ��ݹ۲���������ݼ����������ȶ�����
            If Project0.SurfMet IsNot Nothing AndAlso Project0.SurfMet.ArrayMetData.Length > 0 Then
                Dim SurMet As Met.MetGeneral = Project0.SurfMet.Clone
                If SurMet.IsInsert = True Then '���������ݲ�ֵ����
                    SurMet.InsetAllMetData()
                End If
                For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    If Project0.Dis0.Forecast.Met(i).u2 < 0.3 Then
                        Project0.Dis0.Forecast.Met(i).u2 = 0
                    End If
                Next
                Project0.PreMet() 'Ԥ������������
                Project0.Dis0.Intial_CalRisk() '�������ֵ
                m_Sucess = True
            Else
                MsgBox("�����������������")
            End If

        Else
            Project0.FAndB.Cal() '�������еĻ��ֱ�ը����
            m_Sucess = True
        End If

    End Sub

    Private Sub BackgroundWorkerAermod_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerAermod.RunWorkerCompleted
        SaveAs(False)
        Dim Mainform As frmMain = My.Application.ApplicationContext.MainForm
        Mainform.Status2.Text = ""
        Mainform.ProgressBar.Visible = False
        '�ر�ʱ��
        Timer1.Stop()
        MenuRun.Enabled = True
        ToolRun.Enabled = True
        If Me.m_Sucess = True Then
            RefreshResult() ' ���¼�����
        End If
        Cursor = Cursors.Default
        Mainform.Status.Text = "����"
        Me.Status.Text = "������ϡ�"

    End Sub
    ''' <summary>
    ''' ���¼�����
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshResult()
        If Project0.PType = 0 Then
            '���µ�ֵ��ͼ�Ľ��
            RereshResultContour()
            'RereshDisChart()
            Try
                Result.RefreshCoutour(0, 0)
            Catch ex As Exception

            End Try
            RefreshAllize() '�������

        Else
            RereshResultContour()
            RefreshFireGeneral() '����
            Me.Result.RefreshFireCountor() '��ʾ���
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim pro As Double = Project0.Dis0.Results.AllProgress / Project0.Dis0.Results.AllCalMount
        If pro > 1 Then
            pro = 1
        End If
        Me.Status.Text = "�ܽ��������" & FormatNumber(pro * 100, 1) & "%"
        Me.Status2.Text = Project0.Dis0.Results.Status2
    End Sub

    Private Sub ��ͼ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��ͼ����ToolStripMenuItem.Click
        If ��ͼ����ToolStripMenuItem.CheckState = CheckState.Unchecked Then
            Me.DrawContourWindow.Show()
            ��ͼ����ToolStripMenuItem.Checked = True
        Else
            Me.DrawContourWindow.Hide()
            ��ͼ����ToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub DrawContour()

    End Sub


    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click
        SaveAs(False)
    End Sub
    Private Function SaveAs(ByVal S As Boolean) As Boolean
        Me.Status.Text = "���ڱ����ļ�"
        Try
            Dim SaveFileDialog1 As New SaveFileDialog
            Dim sFile As String
            Dim strNameLast As String
            If Project0.IsSaved = False Or S = True Then

                With SaveFileDialog1
                    .Filter = "������������ϵͳ�ļ� (*.rsk)|*.rsk"
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
                MsgBox("�����ļ�ʱ����������������±���!")
                Return False
            End Try
            Me.Status.Text = "�ļ��������"
            Return True
        Catch ex As Exception
            MsgBox("�����ļ�ʱ����������������±���!")
            Return False
        End Try
    End Function


    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click, OpenToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MessageBox.Show("�Ƿ�Ҫ���浱ǰ����Ŀ?", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If Result = MsgBoxResult.Yes Then
            SaveToolStripMenuItem_Click(sender, e) '������Ŀ
            OpenFilefun()
        ElseIf Result = MsgBoxResult.No Then '������
            OpenFilefun()
        ElseIf Result = MsgBoxResult.Cancel Then 'ȡ��

        End If
    End Sub
    Private Sub OpenFilefun()
        '--------------------------------------------------------------------
        '��ʽ�����
        '-----------------------------------------------------------------------

        Dim sFile As String '�ļ���
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Filter = "������������ϵͳ�ļ� (*.rsk)|*.rsk"
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
                AllProject.SaveName = sFile '�����ļ���

                Project0 = AllProject
                'DrawContourWindow.ContourPaint1.SetPannelSetting(AllProject.PannelSetting)
                fileStr.Close()
                'Me.DrawContourWindow.SetPolluteDraw() '����ͼ��
                Dim strNameLast As String = GetFileName(sFile)
                Me.Text = My.Application.Info.ProductName & My.Application.Info.Version.ToString.Substring(0, 3) & "--" & strNameLast
                SolutionExplorer.TreeView.Nodes(0).Text = strNameLast
                'Me.SolutionExplorer.RefreshSolutionTree()
            Catch ex As Exception
                fileStr.Close()
                MsgBox("���ļ����󡣿������õ��ǽϵͰ汾��������˽ϸ߰汾����ķ���!")
            End Try
        End If
        Try
            Me.RefreshResult() '��ʾ���
        Catch ex As Exception
            MsgBox("�������ķ����Ѿ��ı䣬�����¼���!")
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '�ƶ�
        DrawContourWindow.ContourPaint1.SetMouseType(4)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '�ڻ�ͼ�Ŵ� 
        DrawContourWindow.ContourPaint1.SetMouseType(2)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '��С
        DrawContourWindow.ContourPaint1.SetMouseType(3)
    End Sub

    Private Sub ͼ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemChart.Click

    End Sub

    ''' <summary>
    ''' ���ֱ�ը����
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshFireGeneral()
        Me.GeneralWindow.RichTextBox1.Text = ""
        Me.GeneralWindow.RichTextBox1.Text = Project0.FAndB.GetResultString(0, 0)
    End Sub

    ''' <summary>
    ''' ���µ�ֵ��ͼ�Ľ��
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RereshResultContour()
        Me.DrawContourWindow.cmbRusult.Items.Clear()
        Me.DrawContourWindow.cmbMet.Items.Clear()
        Me.DrawContourWindow.cmbTime.Items.Clear()
        If Project0.Dis0.Forecast.OutPut.IsInstantaneous = True Then '˲ʱŨ��
            Me.DrawContourWindow.cmbRusult.Items.Add("˲ʱŨ��")
            
        End If
        If Project0.Dis0.Forecast.OutPut.IsRisk = True Then
            If Project0.Dis0.Forecast.OutPut.ChargeOrSlip = 1 Then '����ƽ��Ũ��
                Me.DrawContourWindow.cmbRusult.Items.Add("����ƽ��Ũ��")
                Me.DrawContourWindow.cmbRusult.Items.Add("���˷���ֵ")
            Else
                Me.DrawContourWindow.cmbRusult.Items.Add("�����ٷ���")
                Me.DrawContourWindow.cmbRusult.Items.Add("���˷���ֵ")
            End If
        End If
        If Me.DrawContourWindow.cmbRusult.Items.Count > 0 Then
            Me.DrawContourWindow.cmbRusult.SelectedIndex = 0
        End If

        Me.Result.TreeView1.Nodes.Clear() '���
        Select Case Project0.PType
            Case 0 'й©
                Dim newNode1 As TreeNode = New TreeNode("й©�Ի�����Ӱ�������") '��1��ڵ�
                Dim newNode2 As TreeNode '�ڶ���ڵ�
                Dim newTreeNode As TreeNode

                '����µĹ���
                Me.Result.TreeView1.Nodes.Add(newNode1)

                For i As Integer = 0 To Project0.Dis0.Forecast.MaxMet.Length - 1
                    newNode2 = newNode1.Nodes.Add(Project0.Dis0.Forecast.MaxMet(i).Vane & "," & Project0.Dis0.Forecast.MaxMet(i).WindSpeed & "," & Project0.Dis0.Forecast.MaxMet(i).Stab)
                    For j As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                        newTreeNode = New TreeNode(Project0.Dis0.Forecast.OutPut.ForeStart + j * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
                        newTreeNode.Text = Project0.Dis0.Forecast.OutPut.ForeStart + j * Project0.Dis0.Forecast.OutPut.ForeInterval & "min"
                        newNode2.Nodes.Add(newTreeNode)
                    Next
                    If Project0.Dis0.Forecast.OutPut.IsRisk = True And Project0.Dis0.Forecast.OutPut.ChargeOrSlip = 1 Then
                        newTreeNode = New TreeNode("����ƽ�����Ũ��")
                        newTreeNode.Text = "����ƽ�����Ũ��"
                        newNode2.Nodes.Add(newTreeNode)
                    End If
                Next

            Case 1 '���ֱ�ը
                Dim newNode1 As TreeNode = New TreeNode("���ֱ�ը������") '��1��ڵ�
                Dim newNode2 As TreeNode '�ڶ���ڵ�

                '����µĹ���
                Me.Result.TreeView1.Nodes.Add(newNode1)
                Select Case Project0.FAndB.FType
                    Case 0
                        'TNT��ը������
                        newNode2 = newNode1.Nodes.Add("�����Ʊ�ը��TNT������")
                    Case 1
                        '�����౬ը
                        newNode2 = newNode1.Nodes.Add("�����౬ըģ��")
                    Case 2
                        '����վ��ը
                        newNode2 = newNode1.Nodes.Add("����վ��ըģ��")
                    Case 3
                        '����ը
                        newNode2 = newNode1.Nodes.Add("����ըģ��")
                    Case 10
                        '�ػ���ģ��
                        newNode2 = newNode1.Nodes.Add("�ػ���ģ��")
                    Case 11
                        '����Һ����չ�����Ʊ�ը(BLEVE)
                        newNode2 = newNode1.Nodes.Add("����Һ����չ�����Ʊ�ը(BLEVE)")
                    Case 12
                        '�������
                        newNode2 = newNode1.Nodes.Add("�������ģ��")
                    Case 13
                        '�����
                        newNode2 = newNode1.Nodes.Add("�����ģ��")
                End Select
        End Select
    End Sub
  
    Private Sub RereshCourtour()

    End Sub
    ''' <summary>
    ''' �½�й©Ԥ����Ŀ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LToolStripMenuItemL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LToolStripMenuItemL.Click
        Project0 = New Project
        Project0.Dis0 = New DisPuff.Dis '�½�һ��й©��Ŀ
        IntialLeakProject() '��ʼ��һ��й©��Ŀ

    End Sub
    ''' <summary>
    ''' ��ʼ��һ��й©��Ŀ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntialLeakProject()
        Project0.PType = 0 'й©
        '���û�ͼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ChartType = 0
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.Clear() '��յ�ֵ������
        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX, Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '�������
        'OutWindow.Show(DockPanel, DockState.DockBottom)
        OutToolStripMenuItem.Checked = True
        '�����������
        SolutionExplorer.ExplorerBar1.Groups(0).Visible = True
        SolutionExplorer.ExplorerBar1.Groups(1).Visible = False
        SolutionExplorer.ExplorerBar1.Groups(2).Visible = False
        SolutionExplorer.ExplorerBar1.Groups(0).Expanded = True
        SolutionExplorer.Show(DockPanel, Docking.DockState.DockLeft)

        PorjectToolStripMenuItem.Checked = True
        '��������б���
        Result.Show(DockPanel, Docking.DockState.DockLeft)
        PropertyToolStripMenuItem.Checked = True
        '��ֵ��ͼͼ�㴰��
        'DrawLay.Show(DockPanel, Docking.DockState.DockLeft)
        DrawLayToolStripMenuItem.Checked = True

        SolutionExplorer.Activate() '������Ŀ������
        DockPanel.ResumeLayout(True, True)


        '��������
        'Me.GeneralWindow.Show(DockPanel, DockState.Document)
        '��ֵ�ߴ���
        Me.DrawContourWindow.Show(DockPanel, Docking.DockState.Document)
        ��ͼ����ToolStripMenuItem.Checked = True
        ''������ͼ����
        'Me.ResultTNT.Show(DockPanel, DockState.Document)
        'Me.ToolStripMenuItemChart.Checked = True

        Me.DrawContourWindow.Activate() '�����ֵ�߻�ͼ����

        '������Ŀ�����Ӧ�Ĳ˵�
        ActiveMenu()
    End Sub
    ''' <summary>
    ''' ������Ŀ�����Ӧ�Ĳ˵�
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveMenu()
        ' ���ֱ�ը��������
        GeneralWindow.Hide()
        ' �·���Ũ�ȼ���������
        ResultVaneMax.Hide()
        ' ���ĵ��Ũ�ȱ仯
        ResultCareCon.Hide() 
        ' ���ĵ��Ũ����ֵ
        ResultCareMax.Hide()
        ' �·���Ũ�ȷֲ�
        ResultVine.Hide()
        ' ˲ʱ������Ũ�ȷֲ�
        ResultHeavy.Hide()
        ' �����������������
        ResultSlab.Hide()
        ' ��ըTNT����ͼ
        ResultTNT.Hide()
        ' ��������ͼ
        ResultFire.Hide()

        If Project0 IsNot Nothing Then
            ִ��ToolStripMenuItem.Visible = True
            If Project0.PType = 0 Then 'й©
                ���Ũ�ȼ�Ũ����ֵ����ToolStripMenuItem.Visible = True
                �·���Ũ�ȷ���VToolStripMenuItem.Visible = True
                ���ĵ�Ũ�ȷ���ToolStripMenuItem.Visible = True
                ���ĵ�Ũ����ֵ����AToolStripMenuItem.Visible = True
                ������Ũ�ȷ���ToolStripMenuItem.Visible = True
                ����������Ũ�ȷ���SToolStripMenuItem.Visible = True
                ���ֱ�ը�¹ʸ���GToolStripMenuItem.Visible = False
                �����¹��ȷ��ȷ���HToolStripMenuItem.Visible = False
                ��ը�¹ʳ������ѹPToolStripMenuItem.Visible = False
            ElseIf Project0.PType = 1 Then '���ֱ�ը
                ���Ũ�ȼ�Ũ����ֵ����ToolStripMenuItem.Visible = False
                �·���Ũ�ȷ���VToolStripMenuItem.Visible = False
                ���ĵ�Ũ�ȷ���ToolStripMenuItem.Visible = False
                ���ĵ�Ũ����ֵ����AToolStripMenuItem.Visible = False
                ������Ũ�ȷ���ToolStripMenuItem.Visible = False
                ����������Ũ�ȷ���SToolStripMenuItem.Visible = False
                ���ֱ�ը�¹ʸ���GToolStripMenuItem.Visible = True

                If Project0.FAndB.FType < 10 Then '��ը�¹�
                    �����¹��ȷ��ȷ���HToolStripMenuItem.Visible = False
                    ��ը�¹ʳ������ѹPToolStripMenuItem.Visible = True
                Else '��ը
                    �����¹��ȷ��ȷ���HToolStripMenuItem.Visible = True
                    ��ը�¹ʳ������ѹPToolStripMenuItem.Visible = False
                End If
            End If
        Else
            ִ��ToolStripMenuItem.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' ��ʼ����ֵ��ͼ�����ֵ����Сֵ�������
    ''' </summary>
    ''' <param name="Xmin"></param>
    ''' <param name="Xstep"></param>
    ''' <param name="XCount"></param>
    ''' <param name="Ymin"></param>
    ''' <param name="Ystep"></param>
    ''' <param name="YCount"></param>
    ''' <remarks></remarks>
    Private Sub intialDrawData(ByVal Xmin As Integer, ByVal Xstep As Integer, ByVal XCount As Integer, ByVal Ymin As Integer, ByVal Ystep As Integer, ByVal YCount As Integer)
        '���õ�ֵ������x,y�����ϵ����ֵ����Сֵ���������
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '������ʼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmax = Xmin + (XCount - 1) * Xstep '����X����յ�����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nCols = XCount '�������ݵĸ���
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '������ʼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymax = Ymin + (YCount - 1) * Ystep  '����y����յ�����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nRows = YCount '�������ݵĸ���
        '��ʼ����������
        ReDim Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.GridPoint( _
                 Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nRows - 1, Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nCols - 1)
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.InitialPaint()
        Me.Refresh()
    End Sub
    ''' <summary>
    ''' ���õ�ֵ�ߵ�ͼ������ֵ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPropety(ByVal Xstep As Integer, ByVal Ystep As Integer)
        With Me.DrawContourWindow.ContourPaint1.ContourPaintSetting
            '���û�ͼ�������
            .ResetCountData()
            '���õ�ֵ��ͼ���ᡢ����ɼ�
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleName = "Y��"
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleName = "X��"
            '�������������ֵ,��ʹ��̶ȿɼ�
            .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Ystep
            .ContourPannel.Axes.LeftAxis.MainAxisScale.ScaleVisible = True
            '���õ��������ֵ����ʹ�׿̶ȿɼ�
            .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = Xstep
            .ContourPannel.Axes.BottomAxis.MainAxisScale.ScaleVisible = True
            '�������������ֵ,��ʹ��̶Ȳ��ɼ�
            .ContourPannel.Axes.RightAxis.MainAxisScale.Increase = .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase
            .ContourPannel.Axes.RightAxis.MainAxisScale.ScaleVisible = False
            '���ö�������ֵ����ʹ�׿̶Ȳ��ɼ�
            .ContourPannel.Axes.TopAxis.MainAxisScale.Increase = .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase
            .ContourPannel.Axes.TopAxis.MainAxisScale.ScaleVisible = False

            '��������̶ȵı�ע�ɼ�
            .ContourPannel.Axes.LeftAxis.AxisLabel.LabelVisible = True
            '���õ���̶ȵı�ע�ɼ�
            .ContourPannel.Axes.BottomAxis.AxisLabel.LabelVisible = True

            '�������񲻿ɼ�
            .ContourPannel.Axes.LeftAxis.AxisGridding.AxisGriddingVisible = False
            .ContourPannel.Axes.BottomAxis.AxisGridding.AxisGriddingVisible = False


            Me.Refresh()
        End With
    End Sub
    Private Sub intialFireDrawData(ByVal Xmin As Integer, ByVal XMax As Integer, ByVal Ymin As Integer, ByVal Ymax As Integer)
        '���õ�ֵ������x,y�����ϵ����ֵ����Сֵ���������
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '������ʼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Xmax = XMax '����X����յ�����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '������ʼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_Ymax = Ymax  '����y����յ�����
        '��ʼ����������
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.InitialPaint()
        Me.Refresh()
    End Sub
    Private Sub ToolStripMenuItemF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemF.Click
        Project0 = New Project
        Project0.FAndB = New FireBlast.FAndB '�½����ֱ�ըģ��
        InitialFireProject() ' ��ʼ�����ֱ�ը��Ŀ
    End Sub
   

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '���ĵ�
        DrawContourWindow.ContourPaint1.SetMouseType(5)
    End Sub

    Private Sub mnuLeakGas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakGas.Click
        '������й©������Ի���
        Dim frmNewLeakGas As New frmLeakGas
        Static nGas As Short
        nGas = nGas + 1
        Dim strName As String
        strName = "δ����" & nGas
        frmNewLeakGas.Text = "����й©������--" & strName
        frmNewLeakGas.ShowDialog()
    End Sub


    Private Sub mnuLeakTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakTwo.Click
        '������������Ի���
        Dim frmNewLeakTwo As New frmLeakTwo
        Static nTwo As Short
        nTwo = nTwo + 1
        Dim strName As String
        strName = "δ����" & nTwo
        frmNewLeakTwo.Text = "������й©������--" & strName
        frmNewLeakTwo.ShowDialog()
    End Sub

    Private Sub mnuLeakFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakFlash.Click
        '��Һ������������Ի���
        Dim frmNewLeakFlash As New frmLeakFlash
        Static nFlash As Short
        nFlash = nFlash + 1
        Dim strName As String
        strName = "δ����" & nFlash
        frmNewLeakFlash.Text = "����������--" & strName
        frmNewLeakFlash.ShowDialog()
    End Sub

    Private Sub mnuLeakHeat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakHeat.Click
        '����������������Ի���
        Dim frmNewLeakHeat As New frmLeakHeat
        Static nHeat As Short
        nHeat = nHeat + 1
        Dim strName As String
        strName = "δ����" & nHeat
        frmNewLeakHeat.Text = "��������������--" & strName
        frmNewLeakHeat.ShowDialog()
    End Sub

    Private Sub mnuLeakQuality_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakQuality.Click
        '����������������Ի���
        Dim frmNewLeakQuality As New frmLeakQuality
        Static nQuality As Short
        nQuality = nQuality + 1
        Dim strName As String
        strName = "δ����" & nQuality
        frmNewLeakQuality.Text = "��������������--" & strName
        frmNewLeakQuality.ShowDialog()
    End Sub

    Private Sub mnuLeakLiquid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLeakLiquid.Click
        '��Һ��й©������Ի���
        Dim frmNewLeakLiquid As New frmLeakLiquid
        Static nLiquid As Short
        nLiquid = nLiquid + 1
        Dim strName As String
        strName = "δ����" & nLiquid
        frmNewLeakLiquid.Text = "Һ��й©������--" & strName
        frmNewLeakLiquid.ShowDialog()
    End Sub

    Private Sub ����Σ�ջ�ѧƷ����ѧ�������ݿ�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����Σ�ջ�ѧƷ����ѧ�������ݿ�ToolStripMenuItem.Click
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

    Private Sub ȫ��������ѹ���ݿ�PToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ȫ��������ѹ���ݿ�PToolStripMenuItem.Click
        Dim frmRang As New SelectDrang
        frmRang.ShowDialog()
    End Sub

    
    Private Sub ���Ũ�ȼ�Ũ����ֵ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���Ũ�ȼ�Ũ����ֵ����ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            Me.ResultVaneMax.ReLoad = True
            Me.ResultVaneMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If

    End Sub

    Private Sub ���ĵ�Ũ�ȷ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ĵ�Ũ�ȷ���ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareCon.ReLoad = True
            ResultCareCon.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    Private Sub ���ĵ�Ũ����ֵ����AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ĵ�Ũ����ֵ����AToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareMax.ReLoad = True
            ResultCareMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    Private Sub �·���Ũ�ȷ���VToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �·���Ũ�ȷ���VToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultVine.ReLoad = True
            ResultVine.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub



    Private Sub ������Ũ�ȷ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ������Ũ�ȷ���ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultHeavy.ReLoad = True
            ResultHeavy.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    Private Sub ����������Ũ�ȷ���SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����������Ũ�ȷ���SToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultSlab.ReLoad = True
            ResultSlab.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    '���½������
    Private Sub RefreshAllize()
        If Project0.Dis0.Results.AllGridResult.ArrayRisk.Length > 0 Then
            Me.frmRisk.ReLoad = True
            Me.frmRisk.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            Me.ResultVaneMax.ReLoad = True
            Me.ResultVaneMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareCon.ReLoad = True
            ResultCareCon.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareMax.ReLoad = True
            ResultCareMax.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultVine.ReLoad = True
            ResultVine.Show(DockPanel, Docking.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If


        If Project0.Dis0.IntialSource.IsHeavy Then
            If Project0.Dis0.Results.MetResults.Length > 0 Then
                ResultHeavy.ReLoad = True
                ResultHeavy.Show(DockPanel, Docking.DockState.Document)
            Else
                MsgBox("û�м��������������ٷ���!")
            End If
            If Project0.Dis0.Results.MetResults.Length > 0 Then
                ResultSlab.ReLoad = True
                ResultSlab.Show(DockPanel, Docking.DockState.Document)
            Else
                MsgBox("û�м��������������ٷ���!")
            End If
        End If
    End Sub

    Private Sub �����ȶ��ȼ���SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �����ȶ��ȼ���SToolStripMenuItem.Click


        Dim frmNewPS As New frmPS
        frmNewPS.Text = "�����ȶ��ȼ���"
        frmNewPS.ShowDialog()
    End Sub

    Private Sub ��ը�¹ʳ������ѹPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��ը�¹ʳ������ѹPToolStripMenuItem.Click
        ResultTNT.ReLoad = True
        ResultTNT.Show(DockPanel, Docking.DockState.Document)
    End Sub

    Private Sub �����¹��ȷ��ȷ���HToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �����¹��ȷ��ȷ���HToolStripMenuItem.Click
        ResultFire.ReLoad = True
        ResultFire.Show(DockPanel, Docking.DockState.Document)
    End Sub

    Private Sub ���ֱ�ը�¹ʸ���GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ֱ�ը�¹ʸ���GToolStripMenuItem.Click

        GeneralWindow.Show(DockPanel, Docking.DockState.Document)
    End Sub

    Private Sub ToolStripButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
        DrawContourWindow.AddProject = False
        DrawContourWindow.FireBlastType = -1
        '��������
        DrawContourWindow.ContourPaint1.SetMouseType(6)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        DrawContourWindow.ContourPaint1.SetMouseType(0) '��ͷ��
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
        Dim Result As MsgBoxResult = MessageBox.Show("�Ƿ�Ҫ���浱ǰ����Ŀ?", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If Result = MsgBoxResult.Yes Then
            SaveToolStripMenuItem_Click(sender, e) '������Ŀ
            NewRisk() '�½�1����Ŀ
        ElseIf Result = MsgBoxResult.No Then '������
            NewRisk() '�½�1����Ŀ
        ElseIf Result = MsgBoxResult.Cancel Then 'ȡ��

        End If
        NewRisk()
    End Sub

    Private Sub NewRisk()
        '�½�һ����Ŀ
        Project0 = New Project
        Project0.Dis0.Forecast.IsCalGrid = True
        SetTree()
        Me.Text = My.Application.Info.ProductName & My.Application.Info.Version.ToString.Substring(0, 3) & "--" & SolutionExplorer.TreeView.Nodes(0).Text
        IntialLeakProject()
        SetPropety()
        '����Ƕ��


        Me.DrawContourWindow.SetPolluteDraw() '����ͼ��
        'Me.ModifyResults() '�޸Ľ��
        'Me.ResultTypeDayWindow.Hide()
        'Me.ResultDataWindow.Hide()
        'Me.MaxResultWindow.Hide()
        'Me.MaxiFileWindow.Hide()
        'PostFileWinow.Hide()


    End Sub
    ''' <summary>
    ''' ������Ŀ���б��е�����
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTree()
        Static n As Integer = 0
        n = n + 1
        SolutionExplorer.TreeView.Nodes.Clear() 'ɾ��������Ŀ

        If SolutionExplorer.IsActivated = False Then '���δ����򼤻�
            SolutionExplorer.Activate()
        End If


        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm '��ǰ���������
        Dim newNode1 As TreeNode = New TreeNode("δ��������" & n) '��1��ڵ�
        Dim newNode2 As TreeNode '�ڶ���ڵ�
        Dim newTreeNode As TreeNode

        '����µĹ���
        SolutionExplorer.TreeView.Nodes.Add(newNode1)

        '����ͼ
        newNode2 = newNode1.Nodes.Add("����ͼ")
        newTreeNode = New TreeNode("����λ��ͼ")
        newTreeNode.Text = "����λ��ͼ"
        newNode2.Nodes.Add(newTreeNode)
        newTreeNode = New TreeNode("����ƽ��ͼ")
        newTreeNode.Text = "����ƽ��ͼ"
        newNode2.Nodes.Add(newTreeNode)

        '��ȾԴ

        newNode2 = newNode1.Nodes.Add("�¹�Դ")

        newTreeNode = New TreeNode("�¹�Դ��")
        newTreeNode.Text = "�¹�Դ��"
        newNode2.Nodes.Add(newTreeNode)

        '��������
        newNode2 = newNode1.Nodes.Add("��������")
        newTreeNode = New TreeNode("���ʵ�����ѧ���ʼ�����")
        newTreeNode.Text = "���ʵ�����ѧ���ʼ�����"
        newNode2.Nodes.Add(newTreeNode)

        '����͹��ĵ�
        newNode2 = newNode1.Nodes.Add("�����")

        newTreeNode = New TreeNode("�·���")
        newTreeNode.Text = "�·���"
        newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("����")
        newTreeNode.Text = "����"
        newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("�˿ڷֲ�")
        newTreeNode.Text = "�˿ڷֲ�"
        newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("���ĵ�")
        newTreeNode.Text = "���ĵ�"
        newNode2.Nodes.Add(newTreeNode)

        '��������
        newNode2 = newNode1.Nodes.Add("��������")

        'newTreeNode = New TreeNode("��������ѡ��")
        'newTreeNode.Text = "��������ѡ��"
        'newNode2.Nodes.Add(newTreeNode)

        newTreeNode = New TreeNode("��ʱ������������")
        newTreeNode.Text = "��ʱ������������"
        newNode2.Nodes.Add(newTreeNode)
        ''��������
        'newNode2 = newNode1.Nodes.Add("��������")

        'newTreeNode = New TreeNode("��������ѡ��")
        'newTreeNode.Text = "��������ѡ��"
        'newNode2.Nodes.Add(newTreeNode)

        '�������
        newNode2 = newNode1.Nodes.Add("�������")
        newTreeNode = New TreeNode("���ѡ��")
        newTreeNode.Text = "���ѡ��"
        newNode2.Nodes.Add(newTreeNode)

        'չ�����нڵ�
        SolutionExplorer.TreeView.ExpandAll()
        '������

        '��ͼ
        'ModifyTree()
    End Sub

    ''' <summary>
    ''' ��ʼ�����ֱ�ը��Ŀ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitialFireProject()
        '���û�ͼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting = New DrawContour.ContourPaintSetting

        Project0.PType = 1 '���ֱ�ը
        '���û�ͼ����
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ChartType = 1
        Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.Clear()

        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)

        '�������
        'OutWindow.Show(DockPanel, DockState.DockBottom)
        OutToolStripMenuItem.Checked = True
        '�����������

        SolutionExplorer.ExplorerBar1.Groups(0).Visible = False
        SolutionExplorer.ExplorerBar1.Groups(1).Visible = True
        SolutionExplorer.ExplorerBar1.Groups(2).Visible = True
        SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True
        SolutionExplorer.ExplorerBar1.Groups(1).Expanded = True
        SolutionExplorer.ExplorerBar1.Groups(2).Expanded = True
        SolutionExplorer.Show(DockPanel, Docking.DockState.DockLeft)
        PorjectToolStripMenuItem.Checked = True
        '��������б���
        Result.TreeView1.Nodes.Clear() '��մ���
        Result.Show(DockPanel, Docking.DockState.DockLeft)
        PropertyToolStripMenuItem.Checked = True
        '��ֵ��ͼͼ�㴰��
        'DrawLay.Show(DockPanel, Docking.DockState.DockLeft)
        DrawLayToolStripMenuItem.Checked = True

        SolutionExplorer.Activate() '������Ŀ������
        DockPanel.ResumeLayout(True, True)


        '��������
        'Me.GeneralWindow.Show(DockPanel, DockState.Document)
        '��ֵ�ߴ���
        Me.DrawContourWindow.Show(DockPanel, Docking.DockState.Document)
        ��ͼ����ToolStripMenuItem.Checked = True
        ''������ͼ����
        'Me.ResultTNT.Show(DockPanel, DockState.Document)
        'Me.ToolStripMenuItemChart.Checked = True

        Me.DrawContourWindow.Activate() '�����ֵ�߻�ͼ����
        '
        '������Ŀ�����Ӧ�Ĳ˵�
        ActiveMenu()
    End Sub

    ''' <summary>
    ''' ���õ�ֵ�ߵ�ͼ������ֵ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPropety()
        With Me.DrawContourWindow.ContourPaint1.ContourPaintSetting
            '��ʼ����ͼ���
            .InitialPaint()
            '���û�ͼ�������
            .ResetCountData()

            '�������������ֵ,��ʹ��̶ȿɼ�
            .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Project0.Dis0.Forecast.Grid.StepY
            '���õ��������ֵ����ʹ�׿̶ȿɼ�
            .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = Project0.Dis0.Forecast.Grid.StepX
            '�������������ֵ,��ʹ��̶Ȳ��ɼ�
            .ContourPannel.Axes.RightAxis.MainAxisScale.Increase = .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase

            '���ö�������ֵ����ʹ�׿̶Ȳ��ɼ�
            .ContourPannel.Axes.TopAxis.MainAxisScale.Increase = .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase

            Me.Refresh()
        End With
    End Sub
    Private Sub �½�NToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �½�NToolStripButton.Click
        NewRisk()
    End Sub

    
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Me.DrawContourWindow.ContourPaint1.SetMouseType(1) 'ʮ����
        Me.DrawContourWindow.AddProject = True
        Me.DrawContourWindow.SourceType = 11 '������
        Me.DrawContourWindow.ContourPaint1.ContextMenuStrip = Me.DrawContourWindow.MenuPoly
        ReDim Me.DrawContourWindow.ArrayPoint(-1) '��ʼ������
    End Sub

    Private Sub ToolResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolResult.Click
        Dim frmReslt As New frmResultMain
        frmReslt.ShowDialog()

    End Sub
End Class
