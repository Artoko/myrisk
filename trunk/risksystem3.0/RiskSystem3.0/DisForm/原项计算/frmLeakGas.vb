Imports DataLib
Public Class frmLeakGas
    Private Sub txtLeakGasP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP.Validating
        If Not IsNumeric(txtLeakGasP.Text) Then
            ErrorProvider1.SetError(txtLeakGasP, "您输入的不是数值")
        ElseIf Val(txtLeakGasP.Text) < Val(txtLeakGasP0.Text) Or Val(txtLeakGasP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasP, "容器内压力必须大于0，且大于或等于环境压力。")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasP, "")
            ErrorProvider1.SetError(txtLeakGasP0, "")
        End If
    End Sub
    Private Sub txtLeakGasP0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP0.Validating
        If Not IsNumeric(txtLeakGasP0.Text) Then
            ErrorProvider1.SetError(txtLeakGasP0, "您输入的不是数值")
        ElseIf Val(txtLeakGasP.Text) < Val(txtLeakGasP0.Text) Or Val(txtLeakGasP0.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasP0, "环境压力必须大于0，且小于或等于容器内压力。")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasP0, "")
            ErrorProvider1.SetError(txtLeakGasP, "")
        End If
    End Sub
    Private Sub txtLeakGasA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasA.Validating
        If Not IsNumeric(txtLeakGasA.Text) Then
            ErrorProvider1.SetError(txtLeakGasA, "您输入的不是数值")
        ElseIf Val(txtLeakGasA.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasA, "裂口面积必须大于0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasA, "")
        End If
    End Sub


    Private Sub txtLeakGasM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasM.Validating
        If Not IsNumeric(txtLeakGasM.Text) Then
            ErrorProvider1.SetError(txtLeakGasM, "您输入的不是数值")
        ElseIf Val(txtLeakGasM.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasM, "分子量必须大于0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasM, "")
        End If
    End Sub

    Private Sub txtLeakGasTG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasTG.Validating
        If Not IsNumeric(txtLeakGasTG.Text) Then
            ErrorProvider1.SetError(txtLeakGasTG, "您输入的不是数值")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasTG, "")
        End If
    End Sub

    Private Sub txtLeakGasK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasK.Validating
        If Not IsNumeric(txtLeakGasK.Text) Then
            ErrorProvider1.SetError(txtLeakGasK, "您输入的不是数值")
        ElseIf Val(txtLeakGasK.Text) < 1 Or Val(txtLeakGasK.Text) >= 2 Then
            ErrorProvider1.SetError(txtLeakGasK, "绝热指数必须在1和2之间")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasK, "")
        End If
    End Sub

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        '计算结果
        Dim QG As Double
        Dim y As String
        y = DisPuff.Leak.strY(CDbl(txtLeakGasP0.Text), CDbl(txtLeakGasP.Text), CDbl(txtLeakGasK.Text)) '判断是否临界流
        Dim t As Double
        t = CDbl(txtLeakGasTG.Text) + 273.15 '将摄氏度转化为绝对温度
        QG = DisPuff.Leak.CalculateLeakGas(cboLeakGasShape.SelectedIndex, t, CDbl(txtLeakGasK.Text), CDbl(txtLeakGasP0.Text), CDbl(txtLeakGasP.Text), CDbl(txtLeakGasA.Text), CDbl(txtLeakGasM.Text)) '计算气体泄漏速率
        RichLeakResult.Text = y & "气体泄漏速率为：" & QG & " kg/s。"
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        '在数据库中查找数据，并导入 
        '设置提示标志和变量
        Dim Sign As Boolean = False
        Dim strSign As String = ""
        Dim frmNew As New frmSearchData
        frmNew.txtGasP.Visible = True
        frmNew.txtGasK.Visible = True
        frmNew.txtInT.Visible = True
        frmNew.txtInT.Text = Me.txtLeakGasTG.Text
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtGasP.Text <> "" And Val(frmNew.txtGasP.Text) > Val(Me.txtLeakGasP0.Text) Then
                Me.txtLeakGasP.Text = frmNew.txtGasP.Text
            Else
                Sign = True
                strSign = strSign & "贮罐内压力" & vbCrLf
            End If
            If frmNew.txtM.Text <> "" Then
                Me.txtLeakGasM.Text = frmNew.txtM.Text
            Else
                Sign = True
                strSign = strSign & "分子量" & vbCrLf
            End If
            If frmNew.txtGasK.Text <> "" Then
                Me.txtLeakGasK.Text = frmNew.txtGasK.Text
            Else
                Sign = True
                strSign = strSign & "气体绝热指数" & vbCrLf
            End If
            If frmNew.txtInT.Text <> "" Then
                Me.txtLeakGasTG.Text = frmNew.txtInT.Text
            End If
            If Sign = True Then
                MsgBox("请手动输入以下参数：" & vbCrLf & strSign, MsgBoxStyle.Information, "数据库...")
            End If
        End If
    End Sub
    Private Sub frmLeakGas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化气体泄漏裂口形状
        If CheckIsSaved.Checked = False Then
            cboLeakGasShape.SelectedIndex = 0
        End If
        '设置提示
        SetTip()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakGas() '保存
    End Sub
    Public Sub SaveLeakGas() '保存
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
            Me.Text = "气体泄漏量计算--" & strNameLast
            OutPutLeakGas(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakGas(sFile)
            '保存文件
        End If
    End Sub
    Private Sub OutPutLeakGas(ByRef sFileName As String) '导出气体估算预测数据

        FileOpen(1, sFileName, OpenMode.Output)
        PrintLine(1, "LeakGas")
        CheckIsSaved.Checked = True
        PrintLine(1, CheckIsSaved.Checked)
        PrintLine(1, txtName.Text)
        PrintLine(1, txtLeakGasP.Text)
        PrintLine(1, txtLeakGasP0.Text)
        PrintLine(1, cboLeakGasShape.SelectedIndex)
        PrintLine(1, txtLeakGasA.Text)
        PrintLine(1, txtLeakGasM.Text)
        PrintLine(1, txtLeakGasTG.Text)
        PrintLine(1, txtLeakGasK.Text)
        FileClose(1)
    End Sub
    Public Sub InPutLeakGas(ByRef sFileName As String)  '导入气体泄漏量计算预测数据
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, SaveSign.Text)
        Input(1, CheckIsSaved.Checked)
        Input(1, txtName.Text)
        Input(1, txtLeakGasP.Text)
        Input(1, txtLeakGasP0.Text)
        Input(1, cboLeakGasShape.SelectedIndex)
        Input(1, txtLeakGasA.Text)
        Input(1, txtLeakGasM.Text)
        Input(1, txtLeakGasTG.Text)
        Input(1, txtLeakGasK.Text)

        FileClose(1)
    End Sub
    '设置提示
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakGasP, ">0的数值，且>=环境压力")
        ToolTip1.SetToolTip(txtLeakGasP0, ">0的数值，且<=容器压力")
        ToolTip1.SetToolTip(txtLeakGasA, ">0的数值")
        ToolTip1.SetToolTip(txtLeakGasM, ">0的数值")
        ToolTip1.SetToolTip(txtLeakGasTG, "数值")
        ToolTip1.SetToolTip(txtLeakGasK, "1到2之间的数值")
    End Sub
End Class