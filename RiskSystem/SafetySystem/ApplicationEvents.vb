Imports Sunmast.Hardware

Namespace My

    ' 以下事件可用于 MyApplication:
    ' 
    ' Startup: 应用程序启动时在创建启动窗体之前引发。
    ' Shutdown: 在关闭所有应用程序窗体后引发。如果应用程序异常终止，则不会引发此事件。
    ' UnhandledException: 在应用程序遇到未处理的异常时引发。
    ' StartupNextInstance: 在启动单实例应用程序且应用程序已处于活动状态时引发。
    ' NetworkAvailabilityChanged: 在连接或断开网络连接时引发。
    Partial Friend Class MyApplication

        'Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
        '    Vesion = 2 '设置软件版本，0为试用版，1单位版，2为单机版
        '    Try
        '        '先判断用户是否已经注册
        '        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Safety", "Value2", Nothing) Is Nothing Or My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Safety", "Value3", Nothing) Is Nothing Then
        '            '提示注册 
        '            Dim a As New dlgRegedit
        '            If a.ShowDialog() <> DialogResult.OK Then
        '                End
        '            End If
        '        Else
        '            Dim reg2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Safety", "Value2", Nothing)
        '            '根据用户的注册信息进行比较，确定是不是合法用户
        '            Dim reg3 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Safety", "Value3", Nothing)
        '            Dim jm As New Comon.KeyCryp
        '            Dim strjm As String = jm.Encrypto(reg2) '显示给用户的字符串是三次加密的
        '            Dim CalStr As String = ""
        '            Dim strName As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Safety", "Name", Nothing)
        '            Dim dhh As HardDiskInfo
        '            dhh = AtapiDevice.GetHddInfo(0)
        '            CalStr = dhh.SerialNumber & strName & strjmCode '取得硬盘号并加一个字符串用于加密

        '            If strjm <> reg3 Or jm.Encrypto(jm.Encrypto(jm.Encrypto(CalStr))) <> reg3 Then '如果注册信息不正确则提示注册
        '                Dim a As New dlgRegedit
        '                If a.ShowDialog() <> DialogResult.OK Then
        '                    End
        '                End If
        '            End If
        '        End If
        '    Catch
        '        End
        '    End Try
        'End Sub
    End Class
End Namespace

