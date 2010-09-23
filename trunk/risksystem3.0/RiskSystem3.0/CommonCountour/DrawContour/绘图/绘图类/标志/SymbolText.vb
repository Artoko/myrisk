<Serializable()> Public Class SymbolText
    Inherits PaintText
    Private mSymboltextPosition As SymboltextPosition = SymboltextPosition.BottomSide
    Public SmoothingMode As Boolean = False
    Public Property SymboltextPosition() As SymboltextPosition
        Get
            Return mSymboltextPosition
        End Get
        Set(ByVal value As SymboltextPosition)
            mSymboltextPosition = value
        End Set
    End Property
    ''' <summary>
    ''' 绘制标志的文本
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <remarks></remarks>
    Public Sub DrawSymbolText(ByVal grap As Graphics, ByVal SymbolSize As Double, ByVal sympoint As PointF)
        If SmoothingMode = True Then '消除锯齿
            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        End If

        Dim TextHeight As Integer '文本的高度
        TextHeight = grap.MeasureString(Me.Name, Me.mFont).Height * PannelSetting.gScale
        Dim SylSize As Double '标志的大小
        SylSize = SymbolSize * PannelSetting.gScale / PannelSetting.MMTOPIX '将mm大小转化为相对的坐标大小
        Dim mFormat As New StringFormat(New StringAlignment().Near) '字符的对齐方式
        Select Case mSymboltextPosition
            Case DrawContour.SymboltextPosition.TopSide '上
                '调用父类的方法
                mFormat.Alignment = StringAlignment.Center    '文本居中
                Me.mPosition.X = sympoint.X
                Me.mPosition.Y = sympoint.Y + SylSize / 2 + TextHeight / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.BottomSide '下
                '调用父类的方法
                mFormat.Alignment = StringAlignment.Center   '文本居中
                Me.mPosition.X = sympoint.X
                Me.mPosition.Y = sympoint.Y - SylSize / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.LeftSide '左
                '调用父类的方法
                mFormat.Alignment = StringAlignment.Far    '文本居右
                Me.mPosition.X = sympoint.X - SylSize / 2
                Me.mPosition.Y = sympoint.Y + TextHeight / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.RightSide '右
                '调用父类的方法
                mFormat.Alignment = StringAlignment.Near     '文本居左
                Me.mPosition.X = sympoint.X + SylSize / 2
                Me.mPosition.Y = sympoint.Y + TextHeight / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.Center '居中
                '调用父类的方法
                mFormat.Alignment = StringAlignment.Center   '文本居中
                Me.mPosition.X = sympoint.X
                Me.mPosition.Y = sympoint.Y + TextHeight / 2
                Me.DrawText(grap)
        End Select
        Me.DrawText(grap)
    End Sub
End Class
Public Enum SymboltextPosition
    TopSide
    BottomSide
    LeftSide
    RightSide
    Center
End Enum