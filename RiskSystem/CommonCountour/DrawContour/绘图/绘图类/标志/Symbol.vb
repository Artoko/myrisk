Imports System.Drawing.Drawing2D
''' <summary>
''' 标志类，用于绘制标志及标志的文字
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Symbol
    Private mVisible As Boolean = True  '标志可见
    Private mSymbolText As New SymbolText  '标志的文本类的实例
    Private mSymbolSign As New SymbolSign '标志的标志实例
    Public SmoothingMode As Boolean = True
    ''' <summary>
    ''' 绘制标志文本类的属性
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
    ''' 绘制标志及标志的文本
    ''' </summary>
    ''' <param name="grap"></param>
    ''' <remarks></remarks>
    Public Sub DrawSymbol(ByVal grap As Graphics)
        If mVisible Then
            If SmoothingMode = True Then '消除锯齿
                grap.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            End If
            mSymbolSign.DrawSymbolSign(grap) '绘制标志
            Dim SymbolSize As Double = Me.SymbolSign.SymbolSize
            Dim sympoint As PointF = Me.SymbolSign.mSymbolsPoint
            mSymbolText.DrawSymbolText(grap, SymbolSize, sympoint) '绘制标志的文本
        End If
    End Sub
End Class
