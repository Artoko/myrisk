Public Class frmLeakHeat

    Private Sub frmLeakHeat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化地面情况
        If CheckIsSaved.Checked = False Then
            cboLeakEvaporationGround.SelectedIndex = 0 '水泥
        End If
        '设置提示
        SetTip()

    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        '在数据库中查找数据，并导入 
        '设置提示标志和变量
        Dim Sign As Boolean = False
        Dim strSign As String = ""
        Dim frmnew As New frmSearchData
        frmnew.txtTb.Visible = True
        frmnew.txtH.Visible = True
        frmnew.txtName.Text = Me.txtName.Text
        frmnew.ShowDialog()
        If frmnew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmnew.txtTb.Text <> "" Then
                Me.txtLeakEvaporationTb.Text = frmnew.txtTb.Text
            Else
                Sign = True
                strSign = strSign & "沸点" & vbCrLf
            End If
            If frmnew.txtH.Text <> "" Then
                Me.txtLeakEvaporationH.Text = frmnew.txtH.Text
            Else
                Sign = True
                strSign = strSign & "液体的气化热" & vbCrLf
            End If
            If Sign = True Then
                MsgBox("请手动输入以下参数：" & vbCrLf & strSign, MsgBoxStyle.Information, "数据库...")
            End If
        End If
    End Sub

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        Dim Q2 As Double
        Q2 = DisPuff.Leak.CalculateLeakHeat(cboLeakEvaporationGround.SelectedIndex, CDbl(txtLeakEvaporationS.Text), CDbl(txtLeakEvaporationT0.Text), CDbl(txtLeakEvaporationTb.Text), CDbl(txtLeakEvaporationH.Text), CDbl(txtleakevaporationt.Text)) '计算热量蒸发速率
        RichLeakResult.Text = "热量蒸发速率为 " & Q2 & " kg/s"
    End Sub
    Public Sub SaveLeakHeat() '保存
        Dim SaveFileDialog1 As New SaveFileDialog
        Dim sFile As String
        Dim strNameLast As String = ""
        If CheckIsSaved.Checked = False Then
            With SaveFileDialog1
                .Filter = "安全评价模拟系统文件 (*.sms)|*.sms"
                .ShowDialog()
                If Len(.FileName) = 0 Then
                    Exit Sub
                End If
                sFile = .FileName
            End With
            '保存文件名
            Me.FileName.Text = sFile
            'strNameLast = GetFileName(sFile)
            Me.Text = "热量蒸发量计算--" & strNameLast
            OutPutLeakHeat(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakHeat(sFile)
            '保存文件
        End If
    End Sub
    Private Sub OutPutLeakHeat(ByRef sFileName As String) '导出热量蒸发估算预测数据
        FileOpen(1, sFileName, OpenMode.Output)
        '导出数据
        PrintLine(1, "LeakHeat")
        CheckIsSaved.Checked = True
        PrintLine(1, CheckIsSaved.Checked)
        PrintLine(1, txtName.Text)
        PrintLine(1, txtLeakEvaporationS.Text)
        PrintLine(1, txtleakevaporationt.Text)
        PrintLine(1, txtLeakEvaporationT0.Text)
        PrintLine(1, cboLeakEvaporationGround.SelectedIndex)
        PrintLine(1, txtLeakEvaporationTb.Text)
        PrintLine(1, txtLeakEvaporationH.Text)
        FileClose(1)
    End Sub
    Public Sub InPutLeakHeat(ByRef sFileName As String) '导出热量蒸发估算预测数据
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, SaveSign.Text)
        Input(1, CheckIsSaved.Checked)
        Input(1, txtName.Text)
        Input(1, txtLeakEvaporationS.Text)
        Input(1, txtleakevaporationt.Text)
        Input(1, txtLeakEvaporationT0.Text)
        Input(1, cboLeakEvaporationGround.SelectedIndex)
        Input(1, txtLeakEvaporationTb.Text)
        Input(1, txtLeakEvaporationH.Text)
        FileClose(1)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakHeat() '保存
    End Sub
    '设置提示
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakEvaporationS, ">0的数值")
        ToolTip1.SetToolTip(txtleakevaporationt, ">0的数值")
        ToolTip1.SetToolTip(txtLeakEvaporationT0, ">液体沸点的数值")
        ToolTip1.SetToolTip(txtLeakEvaporationTb, "<环境温度的数值")
        ToolTip1.SetToolTip(txtLeakEvaporationH, ">0的数值")
    End Sub

    Private Sub txtLeakEvaporationS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationS.Validating
        If Not IsNumeric(txtLeakEvaporationS.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "您输入的不是数值")
        ElseIf Val(txtLeakEvaporationS.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationS, "")
        End If
    End Sub

    Private Sub txtleakevaporationt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtleakevaporationt.Validating
        If Not IsNumeric(txtleakevaporationt.Text) Then
            ErrorProvider1.SetError(txtleakevaporationt, "您输入的不是数值")
        ElseIf Val(txtleakevaporationt.Text) <= 0 Then
            ErrorProvider1.SetError(txtleakevaporationt, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtleakevaporationt, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationT0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationT0.Validating
        If Not IsNumeric(txtLeakEvaporationT0.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationT0, "您输入的不是数值")
        ElseIf Val(txtLeakEvaporationT0.Text) < Val(txtLeakEvaporationTb.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationT0, "环境温度应>液体沸点")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationT0, "")
            ErrorProvider1.SetError(txtLeakEvaporationTb, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationTb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationTb.Validating
        If Not IsNumeric(txtLeakEvaporationTb.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationTb, "您输入的不是数值")
        ElseIf Val(txtLeakEvaporationT0.Text) < Val(txtLeakEvaporationTb.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationTb, "液体沸点应<环境温度")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationT0, "")
            ErrorProvider1.SetError(txtLeakEvaporationTb, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationH.Validating
        If Not IsNumeric(txtLeakEvaporationH.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationH, "您输入的不是数值")
        ElseIf Val(txtLeakEvaporationH.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationH, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationH, "")
        End If
    End Sub
End Class