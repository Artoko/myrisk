Imports System.Windows.Forms
Imports Sunmast.Hardware
Imports Wjb.ReadOrWriteIniAndReg
Public Class dlgRegedit

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtName.Text = "" Then
            MsgBox("�������û���")
        Else
            Dim CalStr As String = ""
            
            Dim dhh As HardDiskInfo
            dhh = AtapiDevice.GetHddInfo(0)
            CalStr = dhh.SerialNumber & Me.txtName.Text & strjmCode 'ȡ��Ӳ�̺Ų���һ���ַ������ڼ���

            Dim jm As New Comon.KeyCryp
            Dim strjm As String = jm.Encrypto(jm.Encrypto(jm.Encrypto(CalStr))) '��ʾ���û����ַ��������μ��ܵ�
            strjm = strjm.ToUpper()
            Dim strcl As String = "" '�Լ��ܵ��ַ������д���ȡ16��ĸ������Ϊ��д�ġ�
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
                MsgBox("���ѳɹ�ע�᱾�����лл����֧��!")
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Name", Me.txtName.Text) 'ע����е��ַ�����2�μ��ܵ�
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Value2", jm.Encrypto(jm.Encrypto(CalStr))) 'ע����е��ַ�����2�μ��ܵ�
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\YT", "Value3", jm.Encrypto(jm.Encrypto(jm.Encrypto(CalStr)))) 'ע����е��ַ�����3�μ��ܵ�
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("�������ע���벻��ȷ������������!")
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
        Me.Label1.Text = "������:"
    End Sub
End Class
