Imports System.Windows.Forms
Imports Sunmast.Hardware
Imports Wjb.ReadOrWriteIniAndReg
Public Class dlgRegedit

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtName.Text = "" Then
            MsgBox("请输入用户名")
        Else
            Dim CalStr As String = ""
            
            Dim dhh As HardDiskInfo
            dhh = AtapiDevice.GetHddInfo(0)
            CalStr = dhh.SerialNumber & Me.txtName.Text & strjmCode '取得硬盘号并加一个字符串用于加密

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
            If txtSn.Text = strcl Then
                MsgBox("您已成功注册本软件，谢谢您的支持!")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Name", Me.txtName.Text) '注册表中的字符串是2次加密的
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Value2", jm.Encrypto(jm.Encrypto(CalStr))) '注册表中的字符串是2次加密的
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Value3", jm.Encrypto(jm.Encrypto(jm.Encrypto(CalStr)))) '注册表中的字符串是3次加密的
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("您输入的注册码不正确，请重新输入!")
        End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgRegedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str1 As String
        Dim dhh As HardDiskInfo
        dhh = AtapiDevice.GetHddInfo(0)
        str1 = dhh.SerialNumber
        Me.txtHD.Text = str1
        Me.txtHD.ReadOnly = True
        Me.Label1.Text = "机器码:"
    End Sub
End Class
