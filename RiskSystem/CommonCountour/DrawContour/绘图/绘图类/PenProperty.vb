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
    Public Width As Single = PannelSetting.gScale
    ''' <summary>
    ''' 画笔的样式
    ''' </summary>
    ''' <remarks></remarks>
    Public DashStyle As Integer
End Class
