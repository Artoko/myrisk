Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class Nesting
    '网格可见
    Public GriddingVisible As Boolean
    Public m_nRows As Integer = 21
    Public m_nCols As Integer = 21
    Public m_Xmin As Integer = -1020
    Public m_Ymin As Integer = -1020
    Public m_XStep As Integer = 50
    Public m_YStep As Integer = 50
    Private m_Contours As New Contours
    ''' <summary>
    ''' 等值线对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Contours() As Contours
        Get
            Return Me.m_Contours
        End Get
        Set(ByVal value As Contours)
            Me.m_Contours = value
        End Set
    End Property
   
    Public Sub Draw(ByVal grap As Graphics)
        Me.m_Contours.DrawContours(grap)
        GriddingDraw(grap)
    End Sub
    ''' <summary>
    ''' 绘制网格
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <remarks></remarks>
    Public Sub GriddingDraw(ByVal grap As Graphics)
        Dim AxisGriddingPen As New Pen(Color.Black)
        AxisGriddingPen.DashStyle = DashStyle.DashDotDot
        AxisGriddingPen.Width = 1 * PannelSetting.gScale
        '根据不同的坐标轴边，设置不同的最大值和最小值
        For i As Integer = 0 To Me.m_nRows - 1
            grap.DrawLine(AxisGriddingPen, CSng(Me.m_Xmin), CSng(Me.m_Ymin + Me.m_YStep * i), CSng(Me.m_Xmin + (Me.m_nCols - 1) * Me.m_XStep), CSng(Me.m_Ymin + Me.m_YStep * i))
        Next
        For i As Integer = 0 To Me.m_nCols - 1
            grap.DrawLine(AxisGriddingPen, CSng(Me.m_Xmin + Me.m_XStep * i), CSng(Me.m_Ymin), CSng(Me.m_Xmin + Me.m_XStep * i), CSng(Me.m_Ymin + (Me.m_nRows - 1) * Me.m_YStep))
        Next
    End Sub


End Class
