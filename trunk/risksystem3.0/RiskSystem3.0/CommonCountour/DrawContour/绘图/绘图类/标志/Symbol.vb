Imports System.Drawing.Drawing2D
''' <summary>
''' ��־�࣬���ڻ��Ʊ�־����־������
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Symbol
    Private mVisible As Boolean = True  '��־�ɼ�
    Private mSymbolText As New SymbolText  '��־���ı����ʵ��
    Private mSymbolSign As New SymbolSign '��־�ı�־ʵ��
    Public SmoothingMode As Boolean = True
    ''' <summary>
    ''' ���Ʊ�־�ı��������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SymbolVisible() As Boolean
        Get
            Return mVisible
        End Get
        Set(ByVal value As Boolean)
            mVisible = value
        End Set
    End Property

    Public Property SymbolSign() As SymbolSign
        Get
            Return mSymbolSign
        End Get
        Set(ByVal value As SymbolSign)
            mSymbolSign = value
        End Set
    End Property

    Public Property SymbolText() As SymbolText
        Get
            Return mSymbolText
        End Get
        Set(ByVal value As SymbolText)
            mSymbolText = value
        End Set
    End Property
    ''' <summary>
    ''' ���Ʊ�־����־���ı�
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <remarks></remarks>
    Public Sub DrawSymbol(ByVal grap As Graphics)
        If mVisible Then
            If SmoothingMode = True Then '�������
                grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            End If
            mSymbolSign.DrawSymbolSign(grap) '���Ʊ�־
            Dim SymbolSize As Double = Me.SymbolSign.SymbolSize
            Dim sympoint As PointF = Me.SymbolSign.mSymbolsPoint
            mSymbolText.DrawSymbolText(grap, SymbolSize, sympoint) '���Ʊ�־���ı�
        End If
    End Sub
End Class
