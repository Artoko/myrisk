Imports Sunmast.Hardware
Public Module Regedit
    ''' <summary>
    ''' 获取硬件码
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHD() As String
        Dim str1 As String
        Dim dhh As HardDiskInfo
        dhh = AtapiDevice.GetHddInfo(0)
        str1 = dhh.SerialNumber
        Return str1
    End Function
    ''' <summary>
    ''' 对软件进行注册
    ''' </summary>
    ''' <param name="Name">用户名</param>
    ''' <param name="Sn">注册码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InPutNameAndReg(ByVal Name As String, ByVal Sn As String) As Boolean
        If Name = "" Then
            Return False
        Else
            Dim CalStr As String = ""

            Dim dhh As HardDiskInfo
            dhh = AtapiDevice.GetHddInfo(0)
            CalStr = dhh.SerialNumber & Name & strjmCode '取得硬盘号并加一个字符串用于加密

            Dim jm As New Comon.KeyCryp
            Dim strjm As String = jm.Encrypto(jm.Encrypto(jm.Encrypto(CalStr))) '显示给用户的字符串是三次加密的
            strjm = strjm.ToUpper()
            Dim strcl As String = "" '对加密的字符串进行处理，取16字母，并换为大写的。
            Dim str1 As String = ""
            Dim i As Single = 0
            Dim j As Single = 0
            While i < 30
                str1 = strjm.Chars(i + j)
                While str1 < "A" Or str1 > "Z"
                    j += 1
                    str1 = strjm.Chars(i + j)
                End While
                strcl = strcl + str1
                i += 1
            End While
            If Sn = strcl Then
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Name", Name) '注册表中的字符串是2次加密的
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Value2", jm.Encrypto(jm.Encrypto(CalStr))) '注册表中的字符串是2次加密的
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Value3", jm.Encrypto(jm.Encrypto(jm.Encrypto(CalStr)))) '注册表中的字符串是3次加密的
                Return True
            Else
                Return False
            End If
        End If
    End Function
End Module
