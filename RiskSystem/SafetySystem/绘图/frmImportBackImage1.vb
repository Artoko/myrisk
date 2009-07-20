Imports System.Windows.Forms
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Public Class frmImportBackImage1
    Private m_InsertImage As New InsertImage
    Private m_FileName As String
    Private m_Point1 As Point
    Private m_Point2 As Point
    Private m_LeftBottomPoint As Point '图形的左下角坐标
    Private m_RightTopPoint As Point '图形的右上角坐标
    Private m_SetPoint As Integer '

    ''' <summary>
    ''' 背景图的文件名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FileName() As String
        Get
            Return Me.m_FileName
        End Get
        Set(ByVal value As String)
            Me.m_FileName = value
        End Set
    End Property
    ''' <summary>
    ''' 图形的左下角坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LeftBottomPoint() As Point
        Get
            Return Me.m_LeftBottomPoint
        End Get
    End Property
    ''' <summary>
    ''' 图形的右上角坐标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RightTopPoint() As Point
        Get
            Return Me.m_RightTopPoint
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If (Me.m_Point2.X - m_Point1.X) * (txtX2.Text - txtX1.Text) <= 0 Or (m_Point2.Y - m_Point1.Y) * (txtY2.Text - txtY1.Text) <= 0 Then
            MsgBox("设置的坐标反向，请重新设置!", MsgBoxStyle.Information, "错误")
        Else
            Me.m_LeftBottomPoint.X = txtX2.Text + (Me.m_InsertImage.BackRect.X - m_Point2.X) * (txtX1.Text - txtX2.Text) / (m_Point1.X - m_Point2.X)
            Me.m_LeftBottomPoint.Y = txtY2.Text + (Me.m_InsertImage.BackRect.Y - m_Point2.Y) * (txtY1.Text - txtY2.Text) / (m_Point1.Y - m_Point2.Y)
            Me.m_RightTopPoint.X = txtX1.Text + (Me.m_InsertImage.BackRect.X + Me.m_InsertImage.BackRect.Width - m_Point1.X) * (txtX2.Text - txtX1.Text) / (m_Point2.X - m_Point1.X)
            Me.m_RightTopPoint.Y = txtY1.Text + (Me.m_InsertImage.BackRect.Y + Me.m_InsertImage.BackRect.Height - m_Point1.Y) * (txtY2.Text - txtY1.Text) / (m_Point2.Y - m_Point1.Y)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' 导入地图
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdImports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImports.Click
        Dim frmDialog As New OpenFileDialog
        frmDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
        If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_FileName = frmDialog.FileName
            Me.TextBox1.Text = frmDialog.FileName
            m_InsertImage.LoadBitmap(frmDialog.FileName)
            Me.Panel3.Visible = True
            chkYz.Visible = True
            Me.OK_Button.Enabled = True
            Me.Refresh()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '定位第2个点
        m_SetPoint = 2
    End Sub

    Private Sub 鼠标定位_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 鼠标定位.Click
        '定位第一个点
        m_SetPoint = 1
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And m_SetPoint = 1 Then '设置第一点
            Dim p As Point
            p.X = e.X
            p.Y = e.Y
            m_Point1 = Me.m_InsertImage.ScreenToDraw(p)
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And m_SetPoint = 2 Then
            Dim p As Point
            p.X = e.X
            p.Y = e.Y
            m_Point2 = Me.m_InsertImage.ScreenToDraw(p)
        End If
        Me.Refresh()
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Me.m_InsertImage.DrawImage(e.Graphics, m_Point1, m_Point2)
    End Sub

    Private Sub chkYz_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYz.CheckedChanged

    End Sub
End Class

Public Class InsertImage
    Public BackRect As New Rectangle() '背景图的矩形。放缩后的矩形
    Public ImageRect As New Rectangle() '图形的大小和位置
    Public imageFileName As String '背景图的文件名
    Private bmp As Bitmap '底图
    Public gScale As Single = 1 '绘图比例，由于采用象素绘图，还应将比例换为mm。
    Public OriginX As Integer = 225
    Public OriginY As Integer = 225
    Public BackOriginX As Integer = 10
    Public BackOriginY As Integer = -10
    Public BackgScale As Single = 1 '默认值为1，不放缩。

    Public Sub LoadBitmap(ByVal imageFile As String)
        imageFileName = imageFile
        bmp = New Bitmap(imageFileName)
        ImageRect.Width = bmp.Width
        ImageRect.Height = bmp.Height
    End Sub
    Public Sub UnloadBitmap()
        If bmp IsNot Nothing Then
            bmp.Dispose()
            bmp = Nothing
        End If
    End Sub
    Public Sub DrawImage(ByVal grap As Graphics, ByVal P1 As Point, ByVal P2 As Point)
        If bmp IsNot Nothing Then
            '坐标变换
            grap.TranslateTransform(OriginX, OriginY, MatrixOrder.Append) '将坐标系统平移
            Dim graphicsContainer As GraphicsContainer
            graphicsContainer = grap.BeginContainer() '绘图容器
            Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0) '垂直翻转变换
            If bmp.Width / 450 > bmp.Height / 450 Then
                gScale = bmp.Width / 450
            Else
                gScale = bmp.Height / 450
            End If
            myMatrix.Scale(1 / gScale, 1 / gScale) '比例尺为
            grap.Transform = myMatrix
            DrawBack(grap, P1, P2)
            grap.EndContainer(graphicsContainer)
        End If
    End Sub
    Private Sub DrawBack(ByVal grap As Graphics, ByVal P1 As Point, ByVal P2 As Point)
        If bmp IsNot Nothing Then
            BackRect.X = -ImageRect.Width / 2
            BackRect.Y = -ImageRect.Height / 2
            BackRect.Width = ImageRect.Width
            BackRect.Height = ImageRect.Height
            Dim destinationPoints As Point() = { _
                                     New Point(BackRect.X, BackRect.Y + BackRect.Height), _
                                     New Point(BackRect.X + BackRect.Width, BackRect.Y + BackRect.Height), _
                                     New Point(BackRect.X, BackRect.Y)}
            grap.DrawImage(bmp, destinationPoints)
        End If
        If P1 <> P2 Then
            grap.FillRectangle(Brushes.Red, New Rectangle(P1.X - 2 * gScale, P1.Y - 2 * gScale, 4 * gScale, 4 * gScale))
            grap.FillRectangle(Brushes.Red, New Rectangle(P2.X - 2 * gScale, P2.Y - 2 * gScale, 4 * gScale, 4 * gScale))

        End If
    End Sub

    Public Function ScreenToDraw(ByVal point As Point) As Point
        Dim x As Double = (point.X - OriginX) * gScale
        Dim y As Double = (OriginX - point.Y) * gScale
        Dim p As New Point(x, y)
        Return p
    End Function
End Class