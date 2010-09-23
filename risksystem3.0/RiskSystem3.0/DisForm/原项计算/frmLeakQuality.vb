Imports DataLib
Public Class frmLeakQuality

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        Dim Q3 As Double
        Q3 = DisPuff.Leak.CalculateLeakQuality((cboLeakEvaporationStab.Text), CDbl(txtLeakEvaporationP.Text), CDbl(txtLeakEvaporationM.Text), (txtLeakEvaporationT0.Text), CDbl(txtLeakEvaporationu.Text), CDbl(txtLeakEvaporationS.Text)) '计算质量蒸发速率
        RichLeakResult.Text = "质量蒸发速率为 " & Q3 & " kg/s"
    End Sub

    Private Sub frmLeakQuality_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化稳定度条件
        If CheckIsSaved.Checked = False Then
            cboLeakEvaporationStab.SelectedIndex = 0 ' "不稳定(A，B)"
        End If
        SetTip()
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click

        '在数据库中查找数据，并导入 
        '设置提示标志和变量
        Dim Sign As Boolean = False
        Dim strSign As String = ""
        Dim frmnew As New frmSearchData
        frmnew.txtOutGasP.Visible = True
        frmnew.txtM.Visible = True
        frmnew.txtOutT.Visible = True
        frmnew.txtOutT.Text = Me.txtLeakEvaporationT0.Text
        frmnew.txtName.Text = Me.txtName.Text
        frmnew.ShowDialog()
        If frmnew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmnew.txtOutGasP.Text <> "" Then
                Me.txtLeakEvaporationP.Text = frmnew.txtOutGasP.Text
            Else
                Sign = True
                strSign = strSign & "液体表面蒸气压" & vbCrLf
            End If
            If frmnew.txtM.Text <> "" Then
                Me.txtLeakEvaporationM.Text = frmnew.txtM.Text
            Else
                Sign = True
                strSign = strSign & "液体的分子量" & vbCrLf
            End If
            If Sign = True Then
                MsgBox("请手动输入以下参数：" & vbCrLf & strSign, MsgBoxStyle.Information, "数据库...")
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakQuality() '保存
    End Sub
    Public Sub SaveLeakQuality() '保存
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
            Me.Text = "质量蒸发量计算--" & strNameLast
            OutPutLeakQuality(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakQuality(sFile)
            '保存文件
        End If
    End Sub
    Private Sub OutPutLeakQuality(ByRef sFileName As String) '导出质量蒸发量估算预测数据

        FileOpen(1, sFileName, OpenMode.Output)
        PrintLine(1, "LeakQuality")
        CheckIsSaved.Checked = True
        PrintLine(1, CheckIsSaved.Checked)
        PrintLine(1, txtName.Text)
        PrintLine(1, txtLeakEvaporationS.Text)
        PrintLine(1, txtLeakEvaporationu.Text)
        PrintLine(1, txtLeakEvaporationT0.Text)
        PrintLine(1, cboLeakEvaporationStab.SelectedIndex)
        PrintLine(1, txtLeakEvaporationP.Text)
        PrintLine(1, txtLeakEvaporationM.Text)
        FileClose(1)
    End Sub
    Public Sub InPutLeakQuality(ByRef sFileName As String) '导入质量蒸发量估算预测数据

        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, SaveSign.Text)
        Input(1, CheckIsSaved.Checked)
        Input(1, txtName.Text)
        Input(1, txtLeakEvaporationS.Text)
        Input(1, txtLeakEvaporationu.Text)
        Input(1, txtLeakEvaporationT0.Text)
        Input(1, cboLeakEvaporationStab.SelectedIndex)
        Input(1, txtLeakEvaporationP.Text)
        Input(1, txtLeakEvaporationM.Text)
        FileClose(1)
    End Sub
    '设置提示
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakEvaporationS, ">0的数值")
        ToolTip1.SetToolTip(txtLeakEvaporationu, ">0的数值")
        ToolTip1.SetToolTip(txtLeakEvaporationT0, "数值")
        ToolTip1.SetToolTip(txtLeakEvaporationP, ">0的数值")
        ToolTip1.SetToolTip(txtLeakEvaporationM, ">0的数值")

    End Sub

    Private Sub txtLeakEvaporationS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationS.Validating
        If Not IsNumeric(txtLeakEvaporationS.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "您输入的不是数值")
        ElseIf txtLeakEvaporationS.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationS, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationu.Validating
        If Not IsNumeric(txtLeakEvaporationu.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationu, "您输入的不是数值")
        ElseIf txtLeakEvaporationu.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationu, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationu, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationT0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationT0.Validating
        If Not IsNumeric(txtLeakEvaporationT0.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationT0, "您输入的不是数值")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationT0, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationP.Validating
        If Not IsNumeric(txtLeakEvaporationP.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationP, "您输入的不是数值")
        ElseIf txtLeakEvaporationP.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationP, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationP, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationM.Validating
        If Not IsNumeric(txtLeakEvaporationM.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationM, "您输入的不是数值")
        ElseIf txtLeakEvaporationM.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationM, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationM, "")
        End If
    End Sub
End Class