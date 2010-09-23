Imports DataLib
Public Class frmLeakFlash

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        Dim Fv_Renamed As Double
        Dim E1 As Double
        Dim QLG As Double
        Dim strFv As String
        QLG = CDbl(txtQ.Text)

        If chkLiquid.CheckState = 0 Then
            Fv_Renamed = DisPuff.Leak.CalculateLeakFv(CDbl(txtLeakLiquidCP.Text), CDbl(txtLeakLiquidTLG.Text), CDbl(txtLeakLiquidTC.Text), CDbl(txtLeakLiquidH.Text)) '计算蒸发系数
            If Fv_Renamed >= 1.0# Then
                strFv = "不考虑闪蒸时带走液滴的量，蒸发的液体蒸发系数 Fv= " & Fv_Renamed & vbCrLf & "Fv>1.0，液体全部蒸发" & vbCrLf & "液体蒸发量为 " & QLG & " kg/s。"
            ElseIf Fv_Renamed <= 0 Then
                strFv = "不考虑闪蒸时带走液滴的量，蒸发的液体蒸发系数 Fv= " & Fv_Renamed & vbCrLf & "Fv<=0，液体不会发生闪蒸" & vbCrLf & "液体蒸发量为 0 kg/s。"
            Else
                E1 = Fv_Renamed * QLG
                strFv = "不考虑闪蒸时带走液滴的量，蒸发的液体蒸发系数 Fv= " & Fv_Renamed & vbCrLf & "Fv<1.0，液体部分蒸发" & vbCrLf & "液体蒸发量为 " & E1 & " kg/s。"
            End If
        Else
            Fv_Renamed = DisPuff.Leak.CalculateLeakFv(CDbl(txtLeakLiquidCP.Text), CDbl(txtLeakLiquidTLG.Text), CDbl(txtLeakLiquidTC.Text), CDbl(txtLeakLiquidH.Text)) '计算蒸发系数
            If Fv_Renamed >= 0.2 Then
                strFv = "考虑闪蒸时带走液滴的量，蒸发的液体蒸发系数 Fv= " & Fv_Renamed & vbCrLf & "Fv>0.2，液体全部蒸发" & vbCrLf & "液体蒸发量为 " & QLG & " kg/s。"
            ElseIf Fv_Renamed <= 0 Then
                strFv = "考虑闪蒸时带走液滴的量，蒸发的液体蒸发系数 Fv= " & Fv_Renamed & vbCrLf & "Fv<=0，液体不会发生闪蒸" & vbCrLf & "液体蒸发量为 0 kg/s。"
            Else
                E1 = Fv_Renamed * 5 * QLG
                strFv = "考虑闪蒸时带走液滴的量，蒸发的液体蒸发系数 Fv= " & Fv_Renamed & vbCrLf & "Fv<0.2，液体部分蒸发" & vbCrLf & "液体蒸发量为 " & E1 & " kg/s。"
            End If
        End If
        RichLeakResult.Text = strFv
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        '在数据库中查找数据，并导入 
        '设置提示标志和变量
        Dim Sign As Boolean = False
        Dim strSign As String = ""
        Dim frmNew As New frmSearchData
        frmNew.txtCP.Visible = True
        frmNew.txtTb.Visible = True
        frmNew.txtH.Visible = True
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtCP.Text <> "" Then
                Me.txtLeakLiquidCP.Text = frmNew.txtCP.Text
            Else
                Sign = True
                strSign = strSign & "液体定压比热" & vbCrLf
            End If
            If frmNew.txtTb.Text <> "" Then
                Me.txtLeakLiquidTC.Text = frmNew.txtTb.Text
            Else
                Sign = True
                strSign = strSign & "沸点" & vbCrLf
            End If
            If frmNew.txtH.Text <> "" Then
                Me.txtLeakLiquidH.Text = frmNew.txtH.Text
            Else
                Sign = True
                strSign = strSign & "液体的气化热" & vbCrLf
            End If
            If Sign = True Then
                MsgBox("请手动输入以下参数：" & vbCrLf & strSign, MsgBoxStyle.Information, "数据库...")
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakFlash() '保存
    End Sub
    Public Sub SaveLeakFlash() '保存
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
            Me.Text = "闪蒸量计算--" & strNameLast
            '保存数据
            OutPutLeakFlash(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakFlash(sFile)
            '保存文件
        End If
    End Sub
    Private Sub OutPutLeakFlash(ByRef sFileName As String)  '导出闪蒸预测数据
        FileOpen(1, sFileName, OpenMode.Output)
        '导出数据
        PrintLine(1, "LeakFlash")
        CheckIsSaved.Checked = True
        PrintLine(1, CheckIsSaved.Checked)
        PrintLine(1, Me.txtName.Text)
        PrintLine(1, Me.txtQ.Text)
        PrintLine(1, Me.chkLiquid.Checked)
        PrintLine(1, Me.txtLeakLiquidTLG.Text)
        PrintLine(1, Me.txtLeakLiquidTC.Text)
        PrintLine(1, Me.txtLeakLiquidCP.Text)
        PrintLine(1, Me.txtLeakLiquidH.Text)
        FileClose(1)
    End Sub
    Public Sub InPutLeakFlash(ByRef sFileName As String) '导入闪蒸计算预测数据
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, SaveSign.Text)
        Input(1, CheckIsSaved.Checked)
        Input(1, txtName.Text)
        Input(1, txtQ.Text)
        Input(1, chkLiquid.Checked)
        Input(1, txtLeakLiquidTLG.Text)
        Input(1, txtLeakLiquidTC.Text)
        Input(1, txtLeakLiquidCP.Text)
        Input(1, txtLeakLiquidH.Text)
        FileClose(1)
    End Sub

    Private Sub frmLeakFlash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetTip()

    End Sub
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtQ, ">0的数值")
        ToolTip1.SetToolTip(txtLeakLiquidTLG, "数值，应大于沸点的温度")
        ToolTip1.SetToolTip(txtLeakLiquidTC, "数值，应低于泄漏前液体的温度")
        ToolTip1.SetToolTip(txtLeakLiquidCP, ">0的数值")
        ToolTip1.SetToolTip(txtLeakLiquidH, ">0的数值")
    End Sub

    Private Sub txtQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ.Validating
        If Not IsNumeric(txtQ.Text) Then
            ErrorProvider1.SetError(txtQ, "您输入的不是数值")
        ElseIf txtQ.Text <= 0 Then
            ErrorProvider1.SetError(txtQ, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtQ, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTLG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTLG.Validating
        If Not IsNumeric(txtLeakLiquidTLG.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTLG, "您输入的不是数值")
        Else
            ErrorProvider1.SetError(txtLeakLiquidTLG, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTC.Validating
        If Not IsNumeric(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTC, "您输入的不是数值")
        Else
            ErrorProvider1.SetError(txtLeakLiquidTC, "")
        End If
    End Sub

    Private Sub txtLeakLiquidCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCP.Validating
        If Not IsNumeric(txtLeakLiquidCP.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "您输入的不是数值")
        ElseIf txtLeakLiquidCP.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtLeakLiquidCP, "")
        End If
    End Sub

    Private Sub txtLeakLiquidH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidH.Validating
        If Not IsNumeric(txtLeakLiquidH.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidH, "您输入的不是数值")
        ElseIf txtLeakLiquidH.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidH, "您输入数值必须>0")
        Else
            ErrorProvider1.SetError(txtLeakLiquidH, "")
        End If
    End Sub
End Class