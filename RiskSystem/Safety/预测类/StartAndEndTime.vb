''' <summary>
''' 用于储存开始时间和结束时间
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class StartAndEndTime
    ''' <summary>
    ''' 开始时间
    ''' </summary>
    ''' <remarks></remarks>
    Public StartTime As Double
    ''' <summary>
    ''' 结束时间
    ''' </summary>
    ''' <remarks></remarks>
    Public EndTime As Double
    ''' <summary>
    ''' 返回起始和结束时间的字符串表达
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStartAndEndTimeTostring()

        Dim str As String = Math.Truncate(StartTime / 60) & "分" & CInt(Me.StartTime - Math.Truncate(StartTime / 60) * 60) & "秒 - " & Math.Truncate(EndTime / 60) & "分" & CInt(EndTime - Math.Truncate(EndTime / 60) * 60) & "秒"
        Return str

    End Function
End Class

