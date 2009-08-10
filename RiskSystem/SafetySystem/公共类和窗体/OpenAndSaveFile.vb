Public Module OpenAndSaveFile
    Public Function GetFileName(ByRef sName As String) As String
        Dim nStart As Short
        Dim nEnd As Short
        Dim nLen As Short
        nStart = 1
        nEnd = 1
        nLen = Len(sName)
        While nEnd <> 0
            nEnd = InStr(nStart, sName, "\")
            If nEnd <> 0 Then
                nStart = nEnd + 1
            End If
        End While
        GetFileName = Mid(sName, nStart, nLen - 4 - nStart + 1)
    End Function
    Public Function GetExFileName(ByRef sName As String) As String
        Dim nLen As Short
        nLen = Len(sName)
        GetExFileName = Mid(sName, nLen - 2, 3)
    End Function
    Public Function InPutSign(ByRef sFileName As String) As String '读取文件的标志，以确定是什么文件
        Dim sign As String = ""
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, sign)
        FileClose(1)
        InPutSign = sign
    End Function
    Public Function InPutSignGuass(ByRef sFileName As String) As String '读取Gauss文件的标志，以确定是什么预测文件
        Dim InSign As String = ""
        Dim sign As String = ""
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, InSign)
        Input(1, sign)
        FileClose(1)
        InPutSignGuass = sign
    End Function
End Module
