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
    ''' ���Ʊ�־���ı�
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <remarks></remarks>
    Public Sub DrawSymbolText(ByVal grap As Graphics, ByVal SymbolSize As Double, ByVal sympoint As PointF)
        If SmoothingMode = True Then '�������
            grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        End If

        Dim TextHeight As Integer '�ı��ĸ߶�
        TextHeight = grap.MeasureString(Me.Name, Me.mFont).Height * PannelSetting.gScale
        Dim SylSize As Double '��־�Ĵ�С
        SylSize = SymbolSize * PannelSetting.gScale / PannelSetting.MMTOPIX '��mm��Сת��Ϊ��Ե������С
        Dim mFormat As New StringFormat(New StringAlignment().Near) '�ַ��Ķ��뷽ʽ
        Select Case mSymboltextPosition
            Case DrawContour.SymboltextPosition.TopSide '��
                '���ø���ķ���
                mFormat.Alignment = StringAlignment.Center    '�ı�����
                Me.mPosition.X = sympoint.X
                Me.mPosition.Y = sympoint.Y + SylSize / 2 + TextHeight / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.BottomSide '��
                '���ø���ķ���
                mFormat.Alignment = StringAlignment.Center   '�ı�����
                Me.mPosition.X = sympoint.X
                Me.mPosition.Y = sympoint.Y - SylSize / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.LeftSide '��
                '���ø���ķ���
                mFormat.Alignment = StringAlignment.Far    '�ı�����
                Me.mPosition.X = sympoint.X - SylSize / 2
                Me.mPosition.Y = sympoint.Y + TextHeight / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.RightSide '��
                '���ø���ķ���
                mFormat.Alignment = StringAlignment.Near     '�ı�����
                Me.mPosition.X = sympoint.X + SylSize / 2
                Me.mPosition.Y = sympoint.Y + TextHeight / 2
                Me.DrawText(grap)
            Case DrawContour.SymboltextPosition.Center '����
                '���ø���ķ���
                mFormat.Alignment = StringAlignment.Center   '�ı�����
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