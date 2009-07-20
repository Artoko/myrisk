
Public Class frmPS
    
    Private Sub txtLongCent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongCent.TextChanged

    End Sub

    Private Sub txtLongDeg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLongDeg.Click
        If txtLongDeg.Text = "度" Then
            txtLongDeg.Text = ""
        
        End If
    End Sub

    Private Sub frmPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        DateTimePicker1.CustomFormat = "yyyy'年'MM'月'dd'日' HH:mm"
        DateTimePickerMorning.CustomFormat = "'早上'HH:mm"
        DateTimePickerMorning.Value = New DateTime(2006, 10, 30, 6, 0, 0)
        DateTimePickerNight.CustomFormat = "'晚上'HH:mm"
        DateTimePickerNight.Value = New DateTime(2006, 10, 30, 20, 0, 0)
        
    End Sub
    '刷新结果
    Private Sub cmdReflash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReflash.Click

        Dim n_DayOfYear As Integer '一年中的第几天
        n_DayOfYear = DateTimePicker1.Value.DayOfYear() - 1

        Dim dbl_TimeOfDay As Double '将文本中的时间转换为小时表示
        dbl_TimeOfDay = DateTimePicker1.Value.Hour() + DateTimePicker1.Value.Minute() / 60

        Dim dbl_Morning As Double '将文本中的时间转换为小时表示
        dbl_Morning = DateTimePickerMorning.Value.Hour() + DateTimePickerMorning.Value.Minute() / 60

        Dim dbl_Night As Double '将文本中的时间转换为小时表示
        dbl_Night = DateTimePickerNight.Value.Hour() + DateTimePickerNight.Value.Minute() / 60

        Dim dbl_LongDeg, dbl_LatDeg As Double '将文本中的度数转换为用度数表示
        dbl_LongDeg = CDbl(txtLongDeg.Text) + CDbl(txtLongCent.Text) / 60
        dbl_LatDeg = CDbl(txtLatDeg.Text) + CDbl(txtLatCent.Text) / 60

        Dim h0 As Double '太阳高度角
        h0 = SunHight(n_DayOfYear, dbl_TimeOfDay, dbl_LongDeg, dbl_LatDeg)
        Dim RadDeg As Integer '太阳辐射等级
        RadDeg = RadiateDeg(CDbl(txtCloudageAll.Text), CDbl(txtCloudagePart.Text), h0, dbl_Morning, dbl_Night, dbl_TimeOfDay)
        Dim PS As String
        PS = Pasquill(CDbl(txtU10.Text), RadDeg)
        txtResult.Text = "太阳高度角为：" & FormatNumber(h0, 4) & vbCrLf _
                     & "太阳辐射等级数为：" & RadDeg & vbCrLf _
                     & "大气稳定度为：" & PS
    End Sub

    Private Sub txtLongDeg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLongDeg.Validating
        If IsNumeric(txtLongDeg.Text) Then
            txtLongDeg.Text = FormatNumber(txtLongDeg.Text, 0)
            txtLongDeg.ForeColor = Color.Black
            ErrorProvider1.SetError(txtLongDeg, "")
        ElseIf txtLongDeg.Text <> "度" Then
            If txtLongDeg.Text <> "" Then
                ErrorProvider1.SetError(txtLongDeg, "您输入的不是数字，请输入整数。")
            End If
            txtLongDeg.Text = "度"
            txtLongDeg.ForeColor = Color.LightSteelBlue
        End If
    End Sub

End Class