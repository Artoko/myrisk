Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Public Class ContourPaintForm
    Public ContourPaintSetting As New ContourPaintSetting

    Private prePoint As PointF '鼠标按下的点
    Private ReDrawSign As Boolean = False '鼠标松开后的重绘标志
    Public CloseForm As Boolean = False

    '属性----------------------------------------------
    Private boolMenu As Boolean
    Private boolDblClkSet As Boolean
    ''' <summary>
    ''' 鼠标移动的类型:0指针形，1十字形，2放大，3缩小，4移动。
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MouseMoveType As Integer = 0 '
#Region "属性"
   
    ''' <summary>
    ''' 鼠标移动的类型，如果鼠标为0，则为一般鼠标，如果为1，则用于定位。
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
    ''' 设置是否通过左键激活菜单
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
    ''' 设置是否通过双击激活设置对话框
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
    End Sub '关闭窗口标志，默认值为flase,即不关闭
    ''' <summary>
    ''' 设置公共的参数
    ''' </summary>
    ''' <param name="pannel"></param>
    ''' <remarks></remarks>
    Public Sub SetPannelSetting(ByVal pannel As PannelSettingClass)
        PannelSetting = pannel
    End Sub
    ''' <summary>
    ''' 获取公共参数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPannelSetting() As PannelSettingClass
        Return PannelSetting
    End Function
    Private Sub ContourPaint_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.Refresh()
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.m_MouseMoveType = 2 Then '放大
                Me.zoomin(New Point(e.X, e.Y))
            ElseIf Me.m_MouseMoveType = 3 Then '缩小
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
        If Me.Cursor = Cursors.SizeAll Then '移动

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
            ElseIf Me.m_MouseMoveType = 6 Then '设置切断区域
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
                '按用户拖动重新绘制
                If ContourPaintSetting.ContourPannel.Axes.LeftTopAndRightBottomCursor(Me.CreateGraphics, prePoint) = True _
                     Or ContourPaintSetting.ContourPannel.Axes.LeftBottomAndRightTopCursor(Me.CreateGraphics, prePoint) = True _
                     Or ContourPaintSetting.ContourPannel.Axes.DrawFoursquare(Me.CreateGraphics, prePoint) = True Then
                    ContourPaintSetting.ContourPannel.Axes.Redraw(Me.CreateGraphics, prePoint, point)
                    ReDrawSign = False
                End If
                Me.Refresh()
            ElseIf Me.m_MouseMoveType = 6 Then '设置切断区域
                If MsgBox("确定要设置新的坐标区域吗？", MsgBoxStyle.OkCancel, "设置坐标区域") = MsgBoxResult.Ok Then
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
    ''' 绘制剪切时的
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

        If e.Delta > 0 Then '放大
            Me.zoomin(New Point(e.X, e.Y))
        ElseIf e.Delta < 0 Then '缩小
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

    Private Sub 裁切ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 裁切ToolStripMenuItem.Click
        CutImage(Me.ContourPaintSetting.ContourPannel)
    End Sub

    Private Sub 裁切ToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles 裁切ToolStripMenuItem.Paint
        If Me.ContourPaintSetting.ContourPannel.BackImage.CutImage = True Then
            裁切ToolStripMenuItem.Checked = True
        Else
            裁切ToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub 插入背景图IToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 插入背景图IToolStripMenuItem.Click
        InsertBackImage(Me.ContourPaintSetting.ContourPannel)
        Me.Refresh()
    End Sub

    Private Sub 设置SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置SToolStripMenuItem.Click
        SetContour()
    End Sub

    Private Sub 复制CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制CToolStripMenuItem.Click
        Me.CopyEMF()
    End Sub

    Private Sub 伸缩埴满SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 伸缩埴满SToolStripMenuItem.Click
        StretchImage(Me.ContourPaintSetting.ContourPannel)
    End Sub

    Private Sub 背景图可见VToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 背景图可见VToolStripMenuItem.Click
        ImageVisible(Me.ContourPaintSetting.ContourPannel)
    End Sub

    Private Sub 背景图可见VToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles 背景图可见VToolStripMenuItem.Paint
        If Me.ContourPaintSetting.ContourPannel.BackImage.BackVisible = True Then
            背景图可见VToolStripMenuItem.Checked = True
        Else
            背景图可见VToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub 伸缩埴满SToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles 伸缩埴满SToolStripMenuItem.Paint
        If Me.ContourPaintSetting.ContourPannel.BackImage.BackInside = True Then
            伸缩埴满SToolStripMenuItem.Checked = True
        Else
            伸缩埴满SToolStripMenuItem.Checked = False
        End If

    End Sub
    ''' <summary>
    ''' 复制为EMF图形
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
                    MsgBox("复制文件出错，请与作者联系!")
                End Try
            End If
        End If
    End Sub
    ''' <summary>
    ''' 复制为EMF图形
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
                    MsgBox("复制文件出错，请与作者联系!")
                End Try
            End If
        End If
    End Sub
    Private Sub ContourPaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ContourPaintSetting.InitialPaint() '初始化等值线控件
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
    ''' 按倍数放大图形
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
                Me.Cursor = Cursors.Cross '设置点位
            Case 2
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\ZoomIn.cur") '放大
            Case 3
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\ZoomOut.cur") '缩小
            Case 4 '移动
                Me.Cursor = Cursors.SizeAll '移动
            Case 5
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\Care.cur") '关心点
            Case 6 '设置剪切的区域
                Me.Cursor = New Cursor(My.Application.Info.DirectoryPath & "\3dgarro.cur") '关心点

        End Select
    End Sub
    


    Private Sub 复制JPEG图形JToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制BMP图形JToolStripMenuItem.Click
        CopyBmp()
    End Sub
End Class
