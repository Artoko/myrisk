Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()> Public Class PenProperty
    ''' <summary>
    ''' 用32位整数表示颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public color As Integer = Drawing.Color.Black.ToArgb
    ''' <summary>
    ''' 画笔的宽
    ''' </summary>
    ''' <remarks></remarks>
    Private Width As Single = 1
    ''' <summary>
    ''' 画笔的样式
    ''' </summary>
    ''' <remarks></remarks>
    Public DashStyle As Integer
    ''' <summary>
    ''' 画笔的宽。新的参数
    ''' </summary>
    ''' <remarks></remarks>
    Public WidthReal As Single = 1
    <OnDeserializing()> _
 Friend Sub OnDeserializingMethod(ByVal context As StreamingContext)

    End Sub

    <OnDeserialized()> _
    Friend Sub OnDeserializedMethod(ByVal context As StreamingContext)
        If Me.Width > 2 Then
            Me.WidthReal = 1
        End If
    End Sub
End Class
