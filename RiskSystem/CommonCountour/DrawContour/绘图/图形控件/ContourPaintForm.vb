Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Public Class ContourPaintForm
    Public ContourPaintSetting As New ContourPaintSetting

    Private prePoint As PointF '��갴�µĵ�
    Private ReDrawSign As Boolean = False '����ɿ�����ػ��־
    Public CloseForm As Boolean = False

    '����----------------------------------------------
    Private boolMenu As Boolean
    Private boolDblClkSet As Boolean
    ''' <summary>
    ''' ����ƶ�������:0ָ���Σ�1ʮ���Σ�2�Ŵ�3��С��4�ƶ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MouseMoveType As Integer = 0 '
#Region "����"
   
    ''' <summary>
    ''' ����ƶ������ͣ�������Ϊ0����Ϊһ����꣬���Ϊ1�������ڶ�λ��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MouseMoveType() As Integer
        Get
            Return Me.m_MouseMoveType
        End Get
        Set(ByVal value As Integer)
            Me.m_MouseMoveType = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' �����Ƿ�ͨ���������˵�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Menu() As Boolean
        Get
            Return boolMenu
        End Get
        Set(ByVal value As Boolean)
            boolMenu = value
        End Set
    End Property
    ''' <summary>
    ''' �����Ƿ�ͨ��˫���������öԻ���
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DBlClkSet() As Boolean
        Get
            Return boolDblClkSet
        End Get
        Set(ByVal value As Boolean)
            boolDblClkSet = value
        End Set
    End Property
    Public Sub OpenSetDialog()
        SetContour()
    End Sub

    Private Sub ContourPaint_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        'If boolDblClkSet = True Then
        '    SetContour()
        'End If
    End Sub '�رմ��ڱ�־��Ĭ��ֵΪflase,�����ر�
    ''' <summary>
    ''' ���ù����Ĳ���
    ''' </summary>
    ''' <param name="pannel"></param>
    ''' <remarks></remarks>
    Public Sub SetPannelSetting(ByVal pannel As PannelSettingClass)
        PannelSetting = pannel
    End Sub
    ''' <summary>
    ''' ��ȡ��������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPannelSetting() As PannelSettingClass
        Return PannelSetting
    End Function
    Private Sub ContourPaint_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.Refresh()
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.m_MouseMoveType = 2 Then '�Ŵ�
                Me.zoomin(New Point(e.X, e.Y))
            ElseIf Me.m_MouseMoveType = 3 Then '��С
                Me.zoomout(New Point(e.X, e.Y))
            End If
            Dim point As New Point(e.X, e.Y)
            prePoint = point
        End If
    End Sub
    Public Function PointToLocation(ByVal point As PointF) As PointF
        point.X = point.X - PannelSetting.OriginX
        point.Y = point.Y - PannelSetting.OriginY
        point.Y = -point.Y
        point.X = point.X * PannelSetting.gScale
        point.Y = point.Y * PannelSetting.gScale
        Return point
    End Function

    Private Sub ContourPaint_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Me.Cursor = Cursors.SizeAll Then '�ƶ�

        End If
        Dim point As New Point(e.X, e.Y)
        Dim precur As Cursor
        precur = Me.Cursor
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Refresh()
            If Me.m_MouseMoveType = 4 And ContourPaintSetting.ContourPannel.Axes.LeftTopAndRightBottomCursor(Me.CreateGraphics, prePoint) = True Then
                Me.Cursor = Cursors.SizeNWSE
                ContourPaintSetting.ContourPannel.Axes.DrawRectangle(Me.CreateGraphics, prePoint, point)
                ReDrawSign = True
            ElseIf Me.m_MouseMoveType = 4 And ContourPaintSetting.ContourPannel.Axes.LeftBottomAndRightTopCursor(Me.CreateGraphics, prePoint) = True Then
                Me.Cursor = Cursors.SizeNESW
                ContourPaintSetting.ContourPannel.Axes.DrawRectangle(Me.CreateGraphics, prePoint, point)
                ReDrawSign = True
            ElseIf Me.m_MouseMoveType = 4 And ContourPaintSetting.ContourPannel.Axes.DrawFoursquare(Me.CreateGraphics, prePoint) = True Then
                Me.Cursor = Cursors.SizeAll
                ContourPaintSetting.ContourPannel.Axes.DrawRectangle(Me.CreateGraphics, prePoint, point)
                ReDrawSign = True
            ElseIf Me.m_MouseMoveType = 6 Then '�����ж�����
                DrawCutRT(prePoint, point)
            Else
                Me.Cursor = precur
            End If

        Else
            If Me.m_MouseMoveType = 4 And ContourPaintSetting.ContourPannel.Axes.LeftTopAndRightBottomCursor(Me.CreateGraphics, point) = True Then
                Me.Cursor = Cursors.SizeNWSE
            ElseIf Me.m_MouseMoveType = 4 And ContourPaintSetting.ContourPannel.Axes.LeftBottomAndRightTopCursor(Me.CreateGraphics, point) = True Then
                Me.Cursor = Cursors.SizeNESW
            ElseIf Me.m_MouseMoveType = 4 Then
                Me.Cursor = Cursors.SizeAll
            Else
                Me.Cursor = precur
            End If
        End If
    End Sub

    Private Sub ContourPaint_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim point As New Point(e.X, e.Y)
            If ReDrawSign = True Then
                '���û��϶����»���
                If ContourPaintSetting.ContourPannel.Axes.LeftTopAndRightBottomCursor(Me.CreateGraphics, prePoint) = True _
                     Or ContourPaintSetting.ContourPannel.Axes.LeftBottomAndRightTopCursor(Me.CreateGraphics, prePoint) = True _
                     Or ContourPaintSetting.ContourPannel.Axes.DrawFoursquare(Me.CreateGraphics, prePoint) = True Then
                    ContourPaintSetting.ContourPannel.Axes.Redraw(Me.CreateGraphics, prePoint, point)
                    ReDrawSign = False
                End If
                Me.Refresh()
            ElseIf Me.m_MouseMoveType = 6 Then '�����ж�����
                If MsgBox("ȷ��Ҫ�����µ�����������", MsgBoxStyle.OkCancel, "������������") = MsgBoxResult.Ok Then
                    Dim PreP As PointF = PointToLocation(prePoint)
                    Dim P As PointF = PointToLocation(point)

                    If PreP.X < P.X Then
                        ContourPaintSetting.ContourPannel.Axes.BottomAxis.MainAxisScale.Min = PreP.X
                        ContourPaintSetting.ContourPannel.Axes.BottomAxis.MainAxisScale.Max = P.X
                    Else
                        ContourPaintSetting.ContourPannel.Axes.BottomAxis.MainAxisScale.Min = P.X
                        ContourPaintSetting.ContourPannel.Axes.BottomAxis.MainAxisScale.Max = PreP.X
                    End If

                    If PreP.Y < P.Y Then
                        ContourPaintSetting.ContourPannel.Axes.LeftAxis.MainAxisScale.Min = PreP.Y
                        ContourPaintSetting.ContourPannel.Axes.LeftAxis.MainAxisScale.Max = P.Y
                    Else
                        ContourPaintSetting.ContourPannel.Axes.LeftAxis.MainAxisScale.Min = P.Y
                        ContourPaintSetting.ContourPannel.Axes.LeftAxis.MainAxisScale.Max = PreP.Y
                    End If
                End If

                Me.Refresh()
            End If
        End If

    End Sub
    ''' <summary>
    ''' ���Ƽ���ʱ��
    ''' </summary>
    ''' <param name="prePoint"></param>
    ''' <param name="point"></param>
    ''' <remarks></remarks>
    Private Sub DrawCutRT(ByVal prePoint As PointF, ByVal point As PointF)

        Me.CreateGraphics.DrawLine(Pens.Blue, prePoint.X, prePoint.Y, prePoint.X, point.Y)
        Me.CreateGraphics.DrawLine(Pens.Blue, prePoint.X, point.Y, point.X, point.Y)
        Me.CreateGraphics.DrawLine(Pens.Blue, point.X, point.Y, point.X, prePoint.Y)
        Me.CreateGraphics.DrawLine(Pens.Blue, point.X, prePoint.Y, prePoint.X, prePoint.Y)
        'Dim Pre_point As New PointF
        'Pre_point = PointToLocation(prePoint)

    End Sub


    Private Sub ContourPaint_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        Me.Refresh()

        If e.Delta > 0 Then '�Ŵ�
            Me.zoomin(New Point(e.X, e.Y))
        ElseIf e.Delta < 0 Then '��С
            Me.zoomout(New Point(e.X, e.Y))
        End If
        Dim point As New Point(e.X, e.Y)
        prePoint = point
    End Sub
    Public Sub Draw()
        Dim mygraphics As Graphics
        mygraphics = Me.CreateGraphics
        If mygraphics IsNot Nothing Then
            Me.ContourPaintSetting.DrawShape(mygraphics)
        End If
    End Sub
    Private Sub SetContour()
        ActivePaintForm = Me
        Dim ContourPorpertyForm As New ContourPorpertyForm
        ContourPorpertyForm.SettingPannel = Me.ContourPaintSetting.ContourPannel
        ContourPorpertyForm.ShowDialog()
    End Sub

    Private Sub ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ToolStripMenuItem.Click
        CutImage(Me.ContourPaintSetting.ContourPannel)
    End Sub

    Private Sub ����ToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ����ToolStripMenuItem.Paint
        If Me.ContourPaintSetting.ContourPannel.BackImage.CutImage = True Then
            ����ToolStripMenuItem.Checked = True
        Else
            ����ToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ���뱳��ͼIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���뱳��ͼIToolStripMenuItem.Click
        InsertBackImage(Me.ContourPaintSetting.ContourPannel)
        Me.Refresh()
    End Sub

    Private Sub ����SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����SToolStripMenuItem.Click
        SetContour()
    End Sub

    Private Sub ����CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����CToolStripMenuItem.Click
        Me.CopyEMF()
    End Sub

    Private Sub ��������SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������SToolStripMenuItem.Click
        StretchImage(Me.ContourPaintSetting.ContourPannel)
    End Sub

    Private Sub ����ͼ�ɼ�VToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ͼ�ɼ�VToolStripMenuItem.Click
        ImageVisible(Me.ContourPaintSetting.ContourPannel)
    End Sub

    Private Sub ����ͼ�ɼ�VToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ����ͼ�ɼ�VToolStripMenuItem.Paint
        If Me.ContourPaintSetting.ContourPannel.BackImage.BackVisible = True Then
            ����ͼ�ɼ�VToolStripMenuItem.Checked = True
        Else
            ����ͼ�ɼ�VToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ��������SToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ��������SToolStripMenuItem.Paint
        If Me.ContourPaintSetting.ContourPannel.BackImage.BackInside = True Then
            ��������SToolStripMenuItem.Checked = True
        Else
            ��������SToolStripMenuItem.Checked = False
        End If

    End Sub
    ''' <summary>
    ''' ����ΪEMFͼ��
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopyEMF()
        If ActivePaintForm IsNot Nothing Then
            Dim emfFile As String
            If My.Application.Info.DirectoryPath = "\" Then
                emfFile = My.Application.Info.DirectoryPath & "riskpaint.emf"
            Else
                emfFile = My.Application.Info.DirectoryPath & "\" & "riskpaint.emf"
            End If
            ' new metafile
            If My.Computer.FileSystem.FileExists(emfFile) Then
                My.Computer.FileSystem.DeleteFile(emfFile)
            End If
            Dim metaFile As Metafile = New Metafile(emfFile, Graphics.FromHwnd(ActivePaintForm.Handle).GetHdc(), EmfType.EmfPlusDual, "A test")
            'draw image to metafile
            Dim g As Graphics = Graphics.FromImage(metaFile)
            'g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height)
            ActivePaintForm.ContourPaintSetting.DrawShape(g)
            g.Dispose()
            metaFile.Dispose()

            My.Computer.Clipboard.Clear()
            If My.Computer.FileSystem.FileExists(emfFile) Then
                Try
                    metaFile = New Metafile(emfFile)
                    ClipboardMetafile.PutEnhMetafileOnClipboard(Me.Handle, metaFile)
                    My.Computer.FileSystem.DeleteFile(emfFile)
                Catch ex As Exception
                    MsgBox("�����ļ���������������ϵ!")
                End Try
            End If
        End If
    End Sub
    ''' <summary>
    ''' ����ΪEMFͼ��
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopyBmp()

        If ActivePaintForm IsNot Nothing Then
            Dim emfFile As String
            If My.Application.Info.DirectoryPath = "\" Then
                emfFile = My.Application.Info.DirectoryPath & "riskpaint.emf"
            Else
                emfFile = My.Application.Info.DirectoryPath & "\" & "riskpaint.emf"
            End If
            ' new metafile
            If My.Computer.FileSystem.FileExists(emfFile) Then
                My.Computer.FileSystem.DeleteFile(emfFile)
            End If
            Dim metaFile As Metafile = New Metafile(emfFile, Graphics.FromHwnd(ActivePaintForm.Handle).GetHdc(), EmfType.EmfPlusDual, "A test")
            'draw image to metafile
            Dim g As Graphics = Graphics.FromImage(metaFile)
            'g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height)
            ActivePaintForm.ContourPaintSetting.DrawShape(g)
            g.Dispose()


            My.Computer.Clipboard.Clear()
            If My.Computer.FileSystem.FileExists(emfFile) Then
                Try
                    Dim img As Image = Image.FromFile(emfFile)
                    Dim width As Integer = img.Width * 1.1
                    Dim height As Integer = img.Height * 1.1
                    Dim bmp As New Bitmap(width, height)

                    Dim grap As Graphics = Graphics.FromImage(bmp)
                    grap.FillRectangle(Brushes.White, New RectangleF(0, 0, width, height))
                    grap.DrawImage(img, New PointF(0, 0))
                    Clipboard.SetImage(bmp)
                    img.Dispose()
                    bmp.Dispose()
                    metaFile.Dispose()
                    'metaFile = New Metafile(emfFile)
                    'ClipboardMetafile.PutEnhMetafileOnClipboard(Me.Handle, metaFile)
                    My.Computer.FileSystem.DeleteFile(emfFile)
                Catch ex As Exception
                    MsgBox("�����ļ���������������ϵ!")
                End Try
            End If
        End If
    End Sub
    Private Sub ContourPaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ContourPaintSetting.InitialPaint() '��ʼ����ֵ�߿ؼ�
        ActivePaintForm = Me
        If boolMenu = False Then
            Me.ContextMenuStrip = Nothing
        End If
    End Sub

    Private Sub mnuPaint_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuPaint.Opening
        ActivePaintForm = Me
    End Sub

    Private Sub ContourPaint_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If Me.ContourPaintSetting IsNot Nothing Then
            Me.ContourPaintSetting.DrawShape(e.Graphics)
        End If
    End Sub
    ''' <summary>
    ''' �������Ŵ�ͼ��
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub zoomin(ByVal point As PointF)
        If PannelSetting.gScale < 0.1 Then
            Exit Sub
        End If
        PannelSetting.gScale = PannelSetting.gScale / 1.5
        PannelSetting.OriginX = PannelSetting.OriginX - (point.X - PannelSetting.OriginX) * (1.5 - 1)
        PannelSetting.OriginY = PannelSetting.OriginY - (point.Y - PannelSetting.OriginY) * (1.5 - 1)
        Me.Refresh()
    End Sub
    Public Sub zoomout(ByVal point As PointF)
        PannelSetting.gScale = PannelSetting.gScale * 1.5
        PannelSetting.OriginX = PannelSetting.OriginX - (point.X - PannelSetting.OriginX) * (1 / 1.5 - 1)
        PannelSetting.OriginY = PannelSetting.OriginY - (point.Y - PannelSetting.OriginY) * (1 / 1.5 - 1)
        Me.Refresh()
    End Sub
    Public Sub SetMouseType(ByVal i As Integer)
        Me.m_MouseMoveType = i
        Select Case Me.m_MouseMoveType
            Case 0
                Me.Cursor = Cursors.Arrow
            Case 1
                Me.Cursor = Cursors.Cross '���õ�λ
            Case 2
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\ZoomIn.cur") '�Ŵ�
            Case 3
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\ZoomOut.cur") '��С
            Case 4 '�ƶ�
                Me.Cursor = Cursors.SizeAll '�ƶ�
            Case 5
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\Care.cur") '���ĵ�
            Case 6 '���ü��е�����
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\3dgarro.cur") '���ĵ�

        End Select
    End Sub
    


    Private Sub ����JPEGͼ��JToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����BMPͼ��JToolStripMenuItem.Click
        CopyBmp()
    End Sub
End Class
