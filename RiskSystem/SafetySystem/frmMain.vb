Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI
Imports VS2005Extender
Imports System.IO
Imports System.Threading
Imports System.Xml.Serialization

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
        VS2005Style.Extender.SetSchema(DockPanel, VS2005Style.Extender.Schema.FromBase)

        DockPanel.SuspendLayout(True)
        '�ѿؼ�����Ϊ����
        'Steema.TeeChart.Languages.ChineseSimp.Activate()
        NewAermod()
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        boolClose = True '�رմ���
        Dim configFile As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config")
        DockPanel.SaveAsXml(configFile)

        Do While DockPanel.Contents.Count > 0
            Dim dc As DockContent = DockPanel.Contents(0)
            dc.Close()
        Loop

    End Sub
    Private Function ReloadContent(ByVal persistString As String) As IDockContent

        Select Case persistString

            Case "EIAA_For_Aermod.frmDocument"
                Return Nothing

            Case "EIAA_For_Aermod.frmSolution"

                SolutionExplorer = New frmSolution
                Return SolutionExplorer

            Case "EIAA_For_Aermod.frmProperty"

                Result = New frmResult
                Return Result

        End Select

        Return Nothing

    End Function

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
            SolutionExplorer.Show()
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
        Result.DockState = DockState.DockLeft
        SolutionExplorer.DockState = DockState.DockLeft
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
                Project0.PreMet() 'Ԥ��������
                Project0.Dis0.Cal() '������ɢ
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
        Me.Status.Text = "������ϡ�"
        Dim Mainform As frmMain = My.Application.ApplicationContext.MainForm
        Mainform.Status.Text = "����"
        Mainform.Status2.Text = ""
        Mainform.ProgressBar.Visible = False
        '�ر�ʱ��
        Timer1.Stop()
        MenuRun.Enabled = True
        ToolRun.Enabled = True
        If Me.m_Sucess = True Then
            RefreshResult() ' ���¼�����
            Cursor = Cursors.Default
        End If

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
        Me.Status.Text = "�ܽ��������" & FormatNumber(Project0.Dis0.Results.AllProgress / Project0.Dis0.Results.AllCalMount * 100, 1) & "%"
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

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim op As New frmOptionGG
        If frmOptionGG.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub ���뱳��ͼIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmImage As New frmImportBackImage1
        frmImage.Text = "�������λ��ͼ"
        frmImage.FileName = Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.imageFileName
        If frmImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.LoadBitmap(frmImage.FileName)
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.X = frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Y = frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Width = frmImage.RightTopPoint.X - frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Height = frmImage.RightTopPoint.Y - frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.Refresh()
        End If
    End Sub


    Private Sub ����ƽ��ͼPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmImage As New frmImportBackImage1
        frmImage.Text = "���볡��ƽ��ͼ"
        frmImage.FileName = Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.imageFileName
        If frmImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.LoadBitmap(frmImage.FileName)
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.X = frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Y = frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Width = frmImage.RightTopPoint.X - frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Height = frmImage.RightTopPoint.Y - frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.Refresh()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        Dim sFile As String
        Dim strNameLast As String
        If Project0.IsSaved = False Then

            With SaveFileDialog1
                .Filter = "��ȫ����ģ��ϵͳ�ļ� (*.sms)|*.sms"
                .ShowDialog()
                If Len(.FileName) = 0 Then
                    Exit Sub
                End If
                sFile = .FileName
            End With

            If Project0.PType = 0 Then 'й©
                '�����ļ���
                Dim myObject As DisPuff.Dis = Project0.Dis0
                ' Insert code to set properties and fields of the object.
                Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(DisPuff.Dis))
                ' To write to a file, create a StreamWriter object.
                Dim myWriter As StreamWriter = New StreamWriter(sFile)
                mySerializer.Serialize(myWriter, myObject)
                myWriter.Close()
                strNameLast = GetFileName(sFile)
                Me.Text = My.Application.Info.ProductName & "--" & strNameLast
                Project0.SaveName = sFile
                Project0.IsSaved = True
            Else
                '�����ļ���
                Dim myObject As FireBlast.FAndB = Project0.FAndB
                ' Insert code to set properties and fields of the object.
                Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(FireBlast.FAndB))
                ' To write to a file, create a StreamWriter object.
                Dim myWriter As StreamWriter = New StreamWriter(sFile)
                mySerializer.Serialize(myWriter, myObject)
                myWriter.Close()
                strNameLast = GetFileName(sFile)
                Me.Text = My.Application.Info.ProductName & "--" & strNameLast
                Project0.SaveName = sFile
                Project0.IsSaved = True
            End If

        Else
            '�����ļ���
            Dim myObject As DisPuff.Dis = Project0.Dis0
            ' Insert code to set properties and fields of the object.
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(DisPuff.Dis))
            ' To write to a file, create a StreamWriter object.
            Dim myWriter As StreamWriter = New StreamWriter(Project0.SaveName)
            mySerializer.Serialize(myWriter, myObject)
            myWriter.Close()
            strNameLast = GetFileName(Project0.SaveName)
            Me.Text = My.Application.Info.ProductName & "--" & strNameLast
        End If

    End Sub
    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click

        Dim sFile As String '�ļ���
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Filter = "��ȫ����ģ��ϵͳ�ļ� (*.sms)|*.sms"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            With OpenFileDialog
                If Len(.FileName) = 0 Then
                    Exit Sub
                End If
                sFile = .FileName
            End With
            FileOpen(1, sFile, OpenMode.Input)
            Dim strType As String = ""
            For i As Integer = 0 To 2
                Input(1, strType)
            Next
            FileClose(1)
            If strType.Contains("LeakType") Then 'й©
                Try
                    Dim myObject As DisPuff.Dis
                    ' Construct an instance of the XmlSerializer with the type
                    ' of object that is being deserialized.
                    Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(DisPuff.Dis))
                    ' To read the file, create a FileStream.
                    Dim myFileStream As FileStream = New FileStream(sFile, FileMode.Open)
                    ' Call the Deserialize method and cast to the object type.
                    myObject = CType(mySerializer.Deserialize(myFileStream), DisPuff.Dis)
                    Project0.Dis0 = myObject
                    IntialLeakProject() '��ʼ��
                    RefreshResult() '���¼�����
                Catch ex As Exception
                    MsgBox("�ļ���ʽ�д���!")
                End Try

            ElseIf strType.Contains("FType") Then
                Try
                    Dim myObject As FireBlast.FAndB
                    ' Construct an instance of the XmlSerializer with the type
                    ' of object that is being deserialized.
                    Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(FireBlast.FAndB))
                    ' To read the file, create a FileStream.
                    Dim myFileStream As FileStream = New FileStream(sFile, FileMode.Open)
                    ' Call the Deserialize method and cast to the object type.
                    myObject = CType(mySerializer.Deserialize(myFileStream), FireBlast.FAndB)
                    Project0.FAndB = myObject
                    InitialFireProject() '��ʼ��

                    RefreshResult() '���¼�����
                Catch ex As Exception
                    MsgBox("�ļ���ʽ�д���!")
                End Try
            Else
                MsgBox("�ļ���ʽ�д���!")
            End If
        End If


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
        If Project0.Dis0.Forecast.OutPut.IsSlipChecked = True Then '����ƽ��Ũ��
            Me.DrawContourWindow.cmbRusult.Items.Add("����ƽ��Ũ��")
        End If
        If Project0.Dis0.Forecast.OutPut.IsCharge = True Then
            Me.DrawContourWindow.cmbRusult.Items.Add("�����ٷ���")
            Me.DrawContourWindow.cmbRusult.Items.Add("���˷���ֵ")
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

                For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1
                    newNode2 = newNode1.Nodes.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
                    For j As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                        newTreeNode = New TreeNode(Project0.Dis0.Forecast.OutPut.ForeStart + j * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
                        newTreeNode.Text = Project0.Dis0.Forecast.OutPut.ForeStart + j * Project0.Dis0.Forecast.OutPut.ForeInterval & "min"
                        newNode2.Nodes.Add(newTreeNode)
                    Next
                    If Project0.Dis0.Forecast.OutPut.IsSlipChecked Then
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
        SolutionExplorer.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)

        PorjectToolStripMenuItem.Checked = True
        '��������б���
        Result.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        PropertyToolStripMenuItem.Checked = True
        '��ֵ��ͼͼ�㴰��
        'DrawLay.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        DrawLayToolStripMenuItem.Checked = True

        SolutionExplorer.Activate() '������Ŀ������
        DockPanel.ResumeLayout(True, True)


        '��������
        'Me.GeneralWindow.Show(DockPanel, DockState.Document)
        '��ֵ�ߴ���
        Me.DrawContourWindow.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
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
            ����SToolStripMenuItem.Visible = True
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
            ����SToolStripMenuItem.Visible = False
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
    ''' <summary>
    ''' ��ʼ�����ֱ�ը��Ŀ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitialFireProject()
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
        SolutionExplorer.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        PorjectToolStripMenuItem.Checked = True
        '��������б���
        Result.TreeView1.Nodes.Clear() '��մ���
        Result.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        PropertyToolStripMenuItem.Checked = True
        '��ֵ��ͼͼ�㴰��
        'DrawLay.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.DockLeft)
        DrawLayToolStripMenuItem.Checked = True

        SolutionExplorer.Activate() '������Ŀ������
        DockPanel.ResumeLayout(True, True)


        '��������
        'Me.GeneralWindow.Show(DockPanel, DockState.Document)
        '��ֵ�ߴ���
        Me.DrawContourWindow.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        ��ͼ����ToolStripMenuItem.Checked = True
        ''������ͼ����
        'Me.ResultTNT.Show(DockPanel, DockState.Document)
        'Me.ToolStripMenuItemChart.Checked = True

        Me.DrawContourWindow.Activate() '�����ֵ�߻�ͼ����
        '
        '������Ŀ�����Ӧ�Ĳ˵�
        ActiveMenu()
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

    Private Sub ���뱳��ͼIToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���뱳��ͼIToolStripMenuItem.Click
        Dim frmImage As New frmImportBackImage1
        frmImage.Text = "���뱳��ͼ"
        frmImage.FileName = Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.imageFileName
        If frmImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.LoadBitmap(frmImage.FileName)
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.X = frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Y = frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Width = frmImage.RightTopPoint.X - frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.BackImage.BackRect.Height = frmImage.RightTopPoint.Y - frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.Refresh()
            If frmImage.chkYz.Checked = True Then
                If Project0.PType = 0 Then 'й©�����ֱ�ը
                    Project0.Dis0.Forecast.Grid.MinX = frmImage.LeftBottomPoint.X
                    Project0.Dis0.Forecast.Grid.MinY = frmImage.LeftBottomPoint.Y
                    Project0.Dis0.Forecast.Grid.CountX = (frmImage.RightTopPoint.X - frmImage.LeftBottomPoint.X) / Project0.Dis0.Forecast.Grid.StepX
                    Project0.Dis0.Forecast.Grid.CountY = (frmImage.RightTopPoint.Y - frmImage.LeftBottomPoint.Y) / Project0.Dis0.Forecast.Grid.StepY
                    intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX, Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
                    SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

                Else
                    Project0.FAndB.Grid.MinX = frmImage.LeftBottomPoint.X
                    Project0.FAndB.Grid.MaxX = frmImage.RightTopPoint.X
                    Project0.FAndB.Grid.MinY = frmImage.LeftBottomPoint.Y
                    Project0.FAndB.Grid.MaxY = frmImage.RightTopPoint.Y
                    intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
                    SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)

                End If
            End If
        End If
    End Sub

    Private Sub ����ƽ��ͼPToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmImage As New frmImportBackImage1
        frmImage.Text = "���볡��ƽ��ͼ"
        frmImage.FileName = Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.imageFileName
        If frmImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.LoadBitmap(frmImage.FileName)
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.X = frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Y = frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Width = frmImage.RightTopPoint.X - frmImage.LeftBottomPoint.X
            Me.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.PlanImage.BackRect.Height = frmImage.RightTopPoint.Y - frmImage.LeftBottomPoint.Y
            Me.DrawContourWindow.Refresh()
            If frmImage.chkYz.Checked = True Then
                If Project0.PType = 0 Then 'й©�����ֱ�ը
                    Project0.Dis0.Forecast.Grid.MinX = frmImage.LeftBottomPoint.X
                    Project0.Dis0.Forecast.Grid.MinY = frmImage.LeftBottomPoint.Y
                    Project0.Dis0.Forecast.Grid.CountX = (frmImage.RightTopPoint.X - frmImage.LeftBottomPoint.X) / Project0.Dis0.Forecast.Grid.StepX
                    Project0.Dis0.Forecast.Grid.CountY = (frmImage.RightTopPoint.Y - frmImage.LeftBottomPoint.Y) / Project0.Dis0.Forecast.Grid.StepY
                    intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX, Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
                    SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

                Else
                    Project0.FAndB.Grid.MinX = frmImage.LeftBottomPoint.X
                    Project0.FAndB.Grid.MaxX = frmImage.RightTopPoint.X
                    Project0.FAndB.Grid.MinY = frmImage.LeftBottomPoint.Y
                    Project0.FAndB.Grid.MaxY = frmImage.RightTopPoint.Y
                    intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
                    SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)

                End If
            End If

        End If
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
            Me.ResultVaneMax.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If

    End Sub

    Private Sub ���ĵ�Ũ�ȷ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ĵ�Ũ�ȷ���ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareCon.ReLoad = True
            ResultCareCon.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    Private Sub ���ĵ�Ũ����ֵ����AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ĵ�Ũ����ֵ����AToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareMax.ReLoad = True
            ResultCareMax.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    Private Sub �·���Ũ�ȷ���VToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �·���Ũ�ȷ���VToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultVine.ReLoad = True
            ResultVine.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub
   
   

    Private Sub ������Ũ�ȷ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ������Ũ�ȷ���ToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultHeavy.ReLoad = True
            ResultHeavy.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    Private Sub ����������Ũ�ȷ���SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����������Ũ�ȷ���SToolStripMenuItem.Click
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultSlab.ReLoad = True
            ResultSlab.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
    End Sub

    '���½������
    Private Sub RefreshAllize()
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            Me.ResultVaneMax.ReLoad = True
            Me.ResultVaneMax.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareCon.ReLoad = True
            ResultCareCon.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultCareMax.ReLoad = True
            ResultCareMax.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If
        If Project0.Dis0.Results.MetResults.Length > 0 Then
            ResultVine.ReLoad = True
            ResultVine.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
        Else
            MsgBox("û�м��������������ٷ���!")
        End If


        If Project0.Dis0.IntialSource.IsHeavy Then
            If Project0.Dis0.Results.MetResults.Length > 0 Then
                ResultHeavy.ReLoad = True
                ResultHeavy.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
            Else
                MsgBox("û�м��������������ٷ���!")
            End If
            If Project0.Dis0.Results.MetResults.Length > 0 Then
                ResultSlab.ReLoad = True
                ResultSlab.Show(DockPanel, WeifenLuo.WinFormsUI.DockState.Document)
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
        ResultTNT.Show(DockPanel, DockState.Document)
    End Sub

    Private Sub �����¹��ȷ��ȷ���HToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �����¹��ȷ��ȷ���HToolStripMenuItem.Click
        ResultFire.ReLoad = True
        ResultFire.Show(DockPanel, DockState.Document)
    End Sub

    Private Sub ���ֱ�ը�¹ʸ���GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ֱ�ը�¹ʸ���GToolStripMenuItem.Click

        GeneralWindow.Show(DockPanel, DockState.Document)
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
        NewAermod()
    End Sub

    Private Sub NewAermod()
        '�½�һ����Ŀ
        Project0 = New Project
        Project0.Dis0 = New DisPuff.Dis '�½�һ��й©��Ŀ
        Project0.Dis0.Forecast.IsCalGrid = True
        SetTree()
        Me.Text = My.Application.Info.ProductName & My.Application.Info.Version.ToString.Substring(0, 3) & "--" & SolutionExplorer.TreeView.Nodes(0).Text
        IntialLeakProject()
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

        newTreeNode = New TreeNode("���ĵ�")
        newTreeNode.Text = "���ĵ�"
        newNode2.Nodes.Add(newTreeNode)

        '��������
        newNode2 = newNode1.Nodes.Add("��������")

        newTreeNode = New TreeNode("��������ѡ��")
        newTreeNode.Text = "��������ѡ��"
        newNode2.Nodes.Add(newTreeNode)

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

    Private Sub �½�NToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �½�NToolStripButton.Click
        NewAermod()
    End Sub
End Class
