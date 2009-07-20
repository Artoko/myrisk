
Public Class frmPS
    
    Private Sub txtLongCent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongCent.TextChanged

    End Sub

    Private Sub txtLongDeg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLongDeg.Click
        If txtLongDeg.Text = "��" Then
            txtLongDeg.Text = ""
        
        End If
    End Sub

    Private Sub frmPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        DateTimePicker1.CustomFormat = "yyyy'��'MM'��'dd'��' HH:mm"
        DateTimePickerMorning.CustomFormat = "'����'HH:mm"
        DateTimePickerMorning.Value = New DateTime(2006, 10, 30, 6, 0, 0)
        DateTimePickerNight.CustomFormat = "'����'HH:mm"
        DateTimePickerNight.Value = New DateTime(2006, 10, 30, 20, 0, 0)
        
    End Sub
    'ˢ�½��
    Private Sub cmdReflash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReflash.Click

        Dim n_DayOfYear As Integer 'һ���еĵڼ���
        n_DayOfYear = DateTimePicker1.Value.DayOfYear() - 1

        Dim dbl_TimeOfDay As Double '���ı��е�ʱ��ת��ΪСʱ��ʾ
        dbl_TimeOfDay = DateTimePicker1.Value.Hour() + DateTimePicker1.Value.Minute() / 60

        Dim dbl_Morning As Double '���ı��е�ʱ��ת��ΪСʱ��ʾ
        dbl_Morning = DateTimePickerMorning.Value.Hour() + DateTimePickerMorning.Value.Minute() / 60

        Dim dbl_Night As Double '���ı��е�ʱ��ת��ΪСʱ��ʾ
        dbl_Night = DateTimePickerNight.Value.Hour() + DateTimePickerNight.Value.Minute() / 60

        Dim dbl_LongDeg, dbl_LatDeg As Double '���ı��еĶ���ת��Ϊ�ö�����ʾ
        dbl_LongDeg = CDbl(txtLongDeg.Text) + CDbl(txtLongCent.Text) / 60
        dbl_LatDeg = CDbl(txtLatDeg.Text) + CDbl(txtLatCent.Text) / 60

        Dim h0 As Double '̫���߶Ƚ�
        h0 = SunHight(n_DayOfYear, dbl_TimeOfDay, dbl_LongDeg, dbl_LatDeg)
        Dim RadDeg As Integer '̫������ȼ�
        RadDeg = RadiateDeg(CDbl(txtCloudageAll.Text), CDbl(txtCloudagePart.Text), h0, dbl_Morning, dbl_Night, dbl_TimeOfDay)
        Dim PS As String
        PS = Pasquill(CDbl(txtU10.Text), RadDeg)
        txtResult.Text = "̫���߶Ƚ�Ϊ��" & FormatNumber(h0, 4) & vbCrLf _
                     & "̫������ȼ���Ϊ��" & RadDeg & vbCrLf _
                     & "�����ȶ���Ϊ��" & PS
    End Sub

    Private Sub txtLongDeg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLongDeg.Validating
        If IsNumeric(txtLongDeg.Text) Then
            txtLongDeg.Text = FormatNumber(txtLongDeg.Text, 0)
            txtLongDeg.ForeColor = Color.Black
            ErrorProvider1.SetError(txtLongDeg, "")
        ElseIf txtLongDeg.Text <> "��" Then
            If txtLongDeg.Text <> "" Then
                ErrorProvider1.SetError(txtLongDeg, "������Ĳ������֣�������������")
            End If
            txtLongDeg.Text = "��"
            txtLongDeg.ForeColor = Color.LightSteelBlue
        End If
    End Sub

End Class