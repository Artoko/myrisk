Public Module 加密解密数据库
    ''' <summary>
    ''' 加密数据库
    ''' </summary>
    ''' <param name="strDataSource">需要加密的数据库的文件名，含路径</param>
    ''' <remarks></remarks>
    Public Sub Encrypt(ByVal strDataSource As String)
        Dim c(16) As Byte
        c(1) = 108
        c(2) = 122
        c(3) = 7
        c(4) = 45
        c(5) = 83
        c(6) = 16
        c(7) = 27
        c(8) = 80
        c(9) = 10
        c(10) = 9
        c(11) = 14
        c(12) = 10
        c(13) = 0
        c(14) = 79
        c(15) = 11
        c(16) = 106
        FileOpen(1, strDataSource, OpenMode.Binary)
        Dim i As Short
        For i = 1 To 16 Step 1
            FilePut(1, c(i))
        Next i
        FileClose(1)
    End Sub
    ''' <summary>
    ''' 解密数据库
    ''' </summary>
    ''' <param name="strDataSource">需要解密的数据库的文件名，含路径</param>
    ''' <remarks></remarks>
    Public Sub UnEncrypt(ByVal strDataSource As String)
        Dim b(16) As Byte
        b(1) = 0
        b(2) = 1
        b(3) = 0
        b(4) = 0
        b(5) = 83
        b(6) = 116
        b(7) = 97
        b(8) = 110
        b(9) = 100
        b(10) = 97
        b(11) = 114
        b(12) = 100
        b(13) = 32
        b(14) = 74
        b(15) = 101
        b(16) = 116
        FileOpen(1, strDataSource, OpenMode.Binary)
        Dim i As Short
        For i = 1 To 16 Step 1
            FilePut(1, b(i))
        Next i
        FileClose(1)
    End Sub
End Module
