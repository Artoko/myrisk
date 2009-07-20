Public Module path
    ''' <summary>
    ''' 获得Models目录的路径，已经包含了"/"。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ModelsPath()
        Dim path As String
        '执行气象数据程序
        If My.Application.Info.DirectoryPath = "\" Then
            path = My.Application.Info.DirectoryPath
        Else
            path = My.Application.Info.DirectoryPath & "\"
        End If
        Return path
    End Function
End Module
