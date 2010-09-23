Imports System.Drawing.Drawing2D
Public Class Foursquare
    Private LeftTopRegion As New Region(New Rectangle(0, 0, 0, 0))
    Private LeftBottomRegion As New Region(New Rectangle(0, 0, 0, 0))
    Private RightTopRegion As New Region(New Rectangle(0, 0, 0, 0))
    Private RightBottomRegion As New Region(New Rectangle(0, 0, 0, 0))
    ''' <summary>
    ''' �����ĸ���
    ''' </summary>
    ''' <param name="grap">��������</param>
    ''' <param name="point">��ǰ����λ��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DrawFoursquare(ByVal grap As Graphics, ByVal point As PointF, ByVal myrect As Rectangle) As Boolean '������з���T
        Dim FWidth As Integer = 5 * PannelSetting.gScale
        Dim region As New Region(myrect)
        If FWidth < 2 Then
            FWidth = 2
        End If
        If region.IsVisible(point, grap) Or LeftTopRegion.IsVisible(point, grap) Or LeftBottomRegion.IsVisible(point, grap) Or RightTopRegion.IsVisible(point, grap) Or RightBottomRegion.IsVisible(point, grap) Then '����������������4����
            '�ڻ���4����ǰ�Ƚ�����ת��Ϊ����
            Dim rect As Rectangle
            '�������Ͻ�
            rect = New Rectangle(myrect.X - FWidth, myrect.Y + myrect.Height, FWidth, FWidth)
            grap.FillRectangle(Brushes.Black, rect)
            LeftTopRegion = New Region(rect)
            '�������½�
            rect = New Rectangle(myrect.X - FWidth, myrect.Y - FWidth, FWidth, FWidth)
            grap.FillRectangle(Brushes.Black, rect)
            LeftBottomRegion = New Region(rect)
            '�������Ͻ�
            rect = New Rectangle(myrect.X + myrect.Width, myrect.Y + myrect.Height, FWidth, FWidth)
            grap.FillRectangle(Brushes.Black, rect)
            RightTopRegion = New Region(rect)
            '�������½�
            rect = New Rectangle(myrect.X + myrect.Width, myrect.Y - FWidth, FWidth, FWidth)
            grap.FillRectangle(Brushes.Black, rect)
            RightBottomRegion = New Region(rect)
            If region.IsVisible(point, grap) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' �����ķ��ε�����
    ''' </summary>
    ''' <param name="grap">��������</param>
    ''' <param name="prePoint">����������ʱ��λ��</param>
    ''' <param name="Point">��ǰ����λ��</param>
    ''' <remarks></remarks>
    Public Sub DrawRectangle(ByVal grap As Graphics, ByVal prePoint As PointF, ByVal Point As PointF, ByVal myrect As Rectangle)
        Dim region As New Region(myrect)
        DrawFoursquare(grap, prePoint, myrect)
        Dim mypen As New Pen(Color.Black)
        mypen.DashStyle = DashStyle.Dash
        mypen.Width = 0
        Dim rect As Rectangle
        If LeftTopRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(Point.X, myrect.Y, myrect.Width + myrect.X - Point.X, myrect.Height + (myrect.X - Point.X) * myrect.Height / myrect.Width)
            grap.DrawRectangle(mypen, rect)
        ElseIf LeftBottomRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(Point.X, myrect.Y - (myrect.X - Point.X) * myrect.Height / myrect.Width, myrect.Width + myrect.X - Point.X, myrect.Height + (myrect.X - Point.X) * myrect.Height / myrect.Width)
            grap.DrawRectangle(mypen, rect)
        ElseIf RightTopRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(myrect.X, myrect.Y, Point.X - myrect.X, (Point.X - myrect.X) * myrect.Height / myrect.Width)
            grap.DrawRectangle(mypen, rect)
        ElseIf RightBottomRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(myrect.X, myrect.Y - (Point.X - (myrect.X + myrect.Width)) * myrect.Height / myrect.Width, Point.X - myrect.X, (Point.X - myrect.X) * myrect.Height / myrect.Width)
            grap.DrawRectangle(mypen, rect)
        ElseIf region.IsVisible(prePoint, grap) Then '������ƶ�ͼ��
            rect = New Rectangle(myrect.X + Point.X - prePoint.X, myrect.Y + Point.Y - prePoint.Y, myrect.Width, myrect.Height)
            grap.DrawRectangle(mypen, rect)
        End If
    End Sub
    ''' <summary>
    ''' �ƶ�ͼ�β��ػ�ͼ��
    ''' </summary>
    ''' <param name="grap">��������</param>
    ''' <param name="prePoint">����������ʱ��λ��</param>
    ''' <param name="Point">��ǰ����λ��</param>
    ''' <remarks></remarks>
    Public Sub Redraw(ByVal grap As Graphics, ByVal prePoint As PointF, ByVal Point As PointF, ByVal myrect As Rectangle, ByRef OX As Double, ByRef OY As Double, ByRef myScale As Double)
        Dim region As New Region(myrect)
        Dim rect As Rectangle
        Dim dx As Integer
        Dim dy As Integer
        If LeftTopRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(Point.X, myrect.Y, myrect.Width + myrect.X - Point.X, myrect.Height + (myrect.X - Point.X) * myrect.Height / myrect.Width)
            dx = (myrect.Width + myrect.X) * (rect.Width - myrect.Width) / myrect.Width
            OX = OX - dx / myScale
            dy = myrect.Y - myrect.Y * rect.Height / myrect.Height
            OY = OY - dy / myScale
            myScale = myrect.Width / rect.Width * myScale
        ElseIf LeftBottomRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(Point.X, myrect.Y - (myrect.X - Point.X) * myrect.Height / myrect.Width, myrect.Width + myrect.X - Point.X, myrect.Height + (myrect.X - Point.X) * myrect.Height / myrect.Width)
            dx = (myrect.Width + myrect.X) * (rect.Width - myrect.Width) / myrect.Width
            OX = OX - dx / myScale
            dy = (myrect.Height + myrect.Y) * (rect.Height - myrect.Height) / myrect.Height
            OY = OY + dy / myScale
            myScale = myrect.Width / rect.Width * myScale
        ElseIf RightTopRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(myrect.X, myrect.Y, Point.X - myrect.X, (Point.X - myrect.X) * myrect.Height / myrect.Width)
            dx = myrect.X - myrect.X * rect.Width / myrect.Width
            OX = OX + dx / myScale
            dy = myrect.Y - myrect.Y * rect.Height / myrect.Height
            OY = OY - dy / myScale
            myScale = myrect.Width / rect.Width * myScale
        ElseIf RightBottomRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(myrect.X, myrect.Y - (Point.X - (myrect.X + myrect.Width)) * myrect.Height / myrect.Width, Point.X - myrect.X, (Point.X - myrect.X) * myrect.Height / myrect.Width)
            dx = myrect.X - myrect.X * rect.Width / myrect.Width
            OX = OX + dx / myScale
            dy = (myrect.Height + myrect.Y) * (rect.Height - myrect.Height) / myrect.Height
            OY = OY + dy / myScale
            myScale = myrect.Width / rect.Width * myScale
        ElseIf region.IsVisible(prePoint, grap) Then '������ƶ�ͼ��
            rect = New Rectangle(myrect.X + Point.X - prePoint.X, myrect.Y + Point.Y - prePoint.Y, myrect.Width, myrect.Height)
            dx = (Point.X - prePoint.X)
            OX = OX + dx / myScale
            dy = (Point.Y - prePoint.Y)
            OY = OY - dy / myScale
        End If
    End Sub
    Public Function LeftTopAndRightBottomCursor(ByVal grap As Graphics, ByVal prePoint As PointF) As Boolean
        If LeftTopRegion.IsVisible(prePoint, grap) Or RightBottomRegion.IsVisible(prePoint, grap) Then '��������Ͻǻ����½�
            Return True
        Else
            Return False
        End If
    End Function
    Public Function LeftBottomAndRightTopCursor(ByVal grap As Graphics, ByVal prePoint As PointF) As Boolean
        If LeftBottomRegion.IsVisible(prePoint, grap) Or RightTopRegion.IsVisible(prePoint, grap) Then '��������½ǻ����Ͻ�
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' ���µ�������ͼ�Ĵ�С��λ��
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <param name="prePoint"></param>
    ''' <param name="Point"></param>
    ''' <param name="myrect"></param>
    ''' <param name="OX"></param>
    ''' <param name="OY"></param>
    ''' <param name="myScale"></param>
    ''' <remarks></remarks>
    Public Sub BackRedraw(ByVal grap As Graphics, ByVal prePoint As PointF, ByVal Point As PointF, ByRef myrect As Rectangle, ByRef OX As Double, ByRef OY As Double, ByRef myScale As Double)
        Dim region As New Region(myrect)
        Dim rect As Rectangle
        Dim dx As Integer
        Dim dy As Integer
        If LeftTopRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(Point.X, myrect.Y, myrect.Width + myrect.X - Point.X, myrect.Height + (myrect.X - Point.X) * myrect.Height / myrect.Width)
            dx = (rect.Width - myrect.Width)
            OX = OX - dx / PannelSetting.gScale
            dy = (rect.Height - myrect.Height)
            OY = OY + dy / PannelSetting.gScale
            myScale *= rect.Width / myrect.Width
        ElseIf LeftBottomRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(Point.X, myrect.Y - (myrect.X - Point.X) * myrect.Height / myrect.Width, myrect.Width + myrect.X - Point.X, myrect.Height + (myrect.X - Point.X) * myrect.Height / myrect.Width)
            dx = (rect.Width - myrect.Width)
            OX = OX - dx / PannelSetting.gScale
            myScale *= rect.Width / myrect.Width
        ElseIf RightTopRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(myrect.X, myrect.Y, Point.X - myrect.X, (Point.X - myrect.X) * myrect.Height / myrect.Width)
            dy = (rect.Height - myrect.Height)
            OY = OY + dy / PannelSetting.gScale
            myScale *= rect.Width / myrect.Width
        ElseIf RightBottomRegion.IsVisible(prePoint, grap) Then
            rect = New Rectangle(myrect.X, myrect.Y - (Point.X - (myrect.X + myrect.Width)) * myrect.Height / myrect.Width, Point.X - myrect.X, (Point.X - myrect.X) * myrect.Height / myrect.Width)
            myScale *= rect.Width / myrect.Width
        ElseIf region.IsVisible(prePoint, grap) Then '������ƶ�ͼ��
            rect = New Rectangle(myrect.X + Point.X - prePoint.X, myrect.Y + Point.Y - prePoint.Y, myrect.Width, myrect.Height)
            dx = (Point.X - prePoint.X)
            OX = OX + dx / PannelSetting.gScale
            dy = (Point.Y - prePoint.Y)
            OY = OY + dy / PannelSetting.gScale
        End If
    End Sub


End Class
