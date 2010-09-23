''' <summary>
''' 字符串处理函数
''' </summary>
''' <remarks></remarks>
Public Module StringHandle
    Public Function GetStringNumber(ByVal str As String) As Integer
        str = " " & str & " " '在字符串前后各加一个空，以便于后面处理
        Dim n As Integer = 0
        Dim n1 As Integer = 0
        Dim n2 As Integer = 0
        If str IsNot Nothing AndAlso str.Length > 2 Then
            While n2 >= 0
                n1 = n2
                n2 = str.IndexOf(" ", n1 + 1)
                If n2 - n1 > 1 Then '如果不是连续的空格，开始计数
                    n = n + 1
                End If
            End While
        End If
        Return n
    End Function
    ''' <summary>
    ''' 取得给定位置的字符串，索引从1开始
    ''' </summary>
    ''' <param name="str">字符串</param>
    ''' <param name="index">位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetString(ByVal str As String, ByVal index As Integer) As String
        str = "  " & str & "  " '前后各增加两个空格，以便于正确处理
        Dim substring As String = ""
        Dim n As Integer = 0
        Dim n1 As Integer = 0
        Dim n2 As Integer = 0
        Try
            For i As Integer = 0 To str.Length - 1
                If str.Substring(i, 1) <> " " Then
                    n1 = i
                    n2 = str.IndexOf(" ", n1)
                    substring = str.Substring(n1, n2 - n1)
                    i = n2
                    n = n + 1
                    If n = index Then
                        Return substring
                        Exit Function
                    End If
                End If
            Next
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' 根据Aermod的运行结果给出错误的信息
    ''' </summary>
    ''' <param name="AermodName">结果文件的名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAermodError(ByVal AermodName As String)
        Try
            FileOpen(1, AermodName, OpenMode.Input) '打开文件
            Dim strError As String = ""
            Dim IsError As Boolean = False
            Do Until EOF(1)
                Dim strLine As String = LineInput(1) '读取一行
                If strLine.Contains("FATAL ERROR MESSAGES") Then '如果错误
                    IsError = True
                End If
                If IsError = True Then
                    If strLine.Contains("WARNING MESSAGES") Or strLine.Contains("SETUP Finishes UN-successfully") Then
                        Exit Do
                    End If
                    strError = strError & strLine & vbCrLf
                End If
            Loop
            FileClose(1) '关闭文件
            Return "软件运行错误信息如下：" & vbCrLf & strError
        Catch ex As Exception
            Return "无法获取错误信息!"
        Finally
            FileClose(1) '关闭文件
        End Try
        Return "无法获取错误信息!"
    End Function

    ''' <summary>
    ''' 根据Aermap的运行结果给出错误的信息
    ''' </summary>
    ''' <param name="AermapName">结果文件的名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAermapError(ByVal AermapName As String)
        Try
            FileOpen(1, AermapName, OpenMode.Input) '打开文件
            Dim strError As String = ""
            Dim IsError As Boolean = False
            Do Until EOF(1)
                Dim strLine As String = LineInput(1) '读取一行
                If strLine.Contains("FATAL ERROR MESSAGES") Then '如果错误
                    IsError = True
                End If
                If IsError = True Then
                    If strLine.Contains("WARNING MESSAGES") Or strLine.Contains("SETUP Finishes UN-successfully") Then
                        Exit Do
                    End If
                    strError = strError & strLine & vbCrLf
                End If
            Loop
            FileClose(1) '关闭文件
            Return "软件运行错误信息如下：" & vbCrLf & strError
        Catch ex As Exception
            Return "无法获取错误信息!"
        Finally
            FileClose(1) '关闭文件
        End Try
        Return "无法获取错误信息!"
    End Function
End Module
