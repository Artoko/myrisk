Public Class frmLeakLiquid


    Private Sub chkHeight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeight.CheckedChanged
        If chkHeight.CheckState = 0 Then
            txtLeakLiquidHeight.Enabled = False
        Else
            txtLeakLiquidHeight.Enabled = True
        End If
    End Sub

    Private Sub chkEvaporation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEvaporation.CheckedChanged
        If chkEvaporation.CheckState = 0 Then
            txtLeakLiquidCP.Enabled = False
            txtLeakLiquidTLG.Enabled = False
            txtLeakLiquidTC.Enabled = False
            txtLeakLiquidH.Enabled = False
            chkLiquid.Enabled = False
        Else
            txtLeakLiquidCP.Enabled = True
            txtLeakLiquidTLG.Enabled = True
            txtLeakLiquidTC.Enabled = True
            txtLeakLiquidH.Enabled = True
            chkLiquid.Enabled = True
        End If
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
        frmNew.txtPl.Visible = True
        frmNew.txtGasP.Visible = True
        frmNew.txtInT.Visible = True
        frmNew.txtInT.Text = Me.txtLeakLiquidTLG.Text
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtGasP.Text <> "" And Val(frmNew.txtGasP.Text) > Val(Me.txtLeakLiquidP0.Text) Then
                Me.txtLeakLiquidP.Text = frmNew.txtGasP.Text
            Else
                Sign = True
                strSign = strSign & "容器内压力" & vbCrLf
            End If
            If frmNew.txtPl.Text <> "" Then
                Me.txtLeakLiquidPl.Text = frmNew.txtPl.Text
            Else
                Sign = True
                strSign = strSign & "液体密度" & vbCrLf
            End If
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

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        '确定是否考虑高度
        Dim strH As String
        If chkHeight.CheckState = 0 Then
            strH = "不考虑液位高度的压力" & vbCrLf
        Else
            strH = "考虑液位高度的压力" & vbCrLf
        End If
        '计算液体泄漏量
        Dim QLG As Double
        QLG = DisPuff.Leak.CalculateLeakLiquid((chkHeight.CheckState), CDbl(txtLeakLiquidCd.Text), (txtLeakLiquidHeight.Text), CDbl(txtLeakLiquidA.Text), CDbl(txtLeakLiquidPl.Text), CDbl(txtLeakLiquidP.Text), CDbl(txtLeakLiquidP0.Text))

        Dim strQLG As String
        strQLG = "液体泄漏量为 " & QLG & " kg/s。" & vbCrLf
        '计算泄漏液体的蒸发量

        Dim Fv_Renamed As Double
        Dim E1 As Double
        Dim strFv As String
        If chkEvaporation.CheckState = 0 Then
            strFv = ""
        Else
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
        End If
        RichLeakResult.Text = strH & strQLG & strFv
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakLiquid() '保存
    End Sub
    Public Sub SaveLeakLiquid() '保存
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
            Me.Text = "液体泄漏量计算--" & strNameLast
            OutPutLeakLiquid(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakLiquid(sFile)
            '保存文件
        End If
    End Sub
    Private Sub OutPutLeakLiquid(ByRef sFileName As String)  '导出液体泄漏量估算预测数据
        FileOpen(1, sFileName, OpenMode.Output)
        PrintLine(1, "LeakLiquid")
        CheckIsSaved.Checked = True
        PrintLine(1, CheckIsSaved.Checked)
        PrintLine(1, txtName.Text)
        PrintLine(1, txtLeakLiquidP.Text)
        PrintLine(1, txtLeakLiquidP0.Text)
        PrintLine(1, txtLeakLiquidA.Text)
        PrintLine(1, txtLeakLiquidCd.Text)
        PrintLine(1, chkHeight.Checked)
        PrintLine(1, txtLeakLiquidHeight.Text)
        PrintLine(1, txtLeakLiquidPl.Text)
        PrintLine(1, chkEvaporation.Checked)
        PrintLine(1, chkLiquid.Checked)
        PrintLine(1, txtLeakLiquidTLG.Text)
        PrintLine(1, txtLeakLiquidTC.Text)
        PrintLine(1, txtLeakLiquidCP.Text)
        PrintLine(1, txtLeakLiquidH.Text)
        FileClose(1)
    End Sub
    Public Sub InPutLeakLiquid(ByRef sFileName As String)  '导入液体泄漏量估算预测数据
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, SaveSign.Text)
        Input(1, CheckIsSaved.Checked)
        Input(1, txtName.Text)
        Input(1, txtLeakLiquidP.Text)
        Input(1, txtLeakLiquidP0.Text)
        Input(1, txtLeakLiquidA.Text)
        Input(1, txtLeakLiquidCd.Text)
        Input(1, chkHeight.Checked)
        Input(1, txtLeakLiquidHeight.Text)
        Input(1, txtLeakLiquidPl.Text)
        Input(1, chkEvaporation.Checked)
        Input(1, chkLiquid.Checked)
        Input(1, txtLeakLiquidTLG.Text)
        Input(1, txtLeakLiquidTC.Text)
        Input(1, txtLeakLiquidCP.Text)
        Input(1, txtLeakLiquidH.Text)
        FileClose(1)
    End Sub

    Private Sub frmLeakLiquid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetTip()
    End Sub
    '设置提示
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakLiquidP, ">0的数值，且容器内的压力应>=环境压力")
        ToolTip1.SetToolTip(txtLeakLiquidP0, ">0的数值，且环境压力应<=容器内的压力")
        ToolTip1.SetToolTip(txtLeakLiquidA, ">0的数值")
        ToolTip1.SetToolTip(txtLeakLiquidCd, "0到1之间的数值")
        ToolTip1.SetToolTip(txtLeakLiquidHeight, ">0的数值")
        ToolTip1.SetToolTip(txtLeakLiquidPl, ">0的数值")
        ToolTip1.SetToolTip(txtLeakLiquidTLG, "泄漏前的温度应>沸点")
        ToolTip1.SetToolTip(txtLeakLiquidTC, "沸点应<泄漏前的温度")
        ToolTip1.SetToolTip(txtLeakLiquidCP, ">0的数值")
        ToolTip1.SetToolTip(txtLeakLiquidH, ">0的数值")
    End Sub

    Private Sub txtLeakLiquidP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidP.Validating
        If Not IsNumeric(txtLeakLiquidP.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidP, "您输入的数值必须>0")
        ElseIf Val(txtLeakLiquidP.Text) < Val(txtLeakLiquidP0.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP, "容器内的压力应>=环境压力")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidP, "")
            ErrorProvider1.SetError(txtLeakLiquidP0, "")
        End If
    End Sub

    Private Sub txtLeakLiquidP0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidP0.Validating
        If Not IsNumeric(txtLeakLiquidP0.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP0, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidP0.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidP0, "您输入的数值必须>0")
        ElseIf Val(txtLeakLiquidP.Text) < Val(txtLeakLiquidP0.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP0, "环境压力应<=容器内的压力")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidP, "")
            ErrorProvider1.SetError(txtLeakLiquidP0, "")
        End If
    End Sub

    Private Sub txtLeakLiquidA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidA.Validating
        If Not IsNumeric(txtLeakLiquidA.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidA, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidA.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidA, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidA, "")
        End If
    End Sub

    Private Sub txtLeakLiquidCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCd.Validating
        If Not IsNumeric(txtLeakLiquidCd.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidCd, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidCd.Text) <= 0 Or Val(txtLeakLiquidCd.Text) >= 1 Then
            ErrorProvider1.SetError(txtLeakLiquidCd, "数值必须在0到1之间")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidCd, "")
        End If
    End Sub

    Private Sub txtLeakLiquidCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCP.Validating
        If Not IsNumeric(txtLeakLiquidCP.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidCP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidCP, "")
        End If
    End Sub

    Private Sub txtLeakLiquidHeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidHeight.Validating
        If Not IsNumeric(txtLeakLiquidHeight.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidHeight, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidHeight.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidHeight, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidHeight, "")
        End If
    End Sub

    Private Sub txtLeakLiquidPl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidPl.Validating
        If Not IsNumeric(txtLeakLiquidPl.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidPl, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidPl.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidPl, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidPl, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTLG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTLG.Validating
        If Not IsNumeric(txtLeakLiquidTLG.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTLG, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidTLG.Text) < Val(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTLG, "泄漏前的温度应>沸点")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidTLG, "")
            ErrorProvider1.SetError(txtLeakLiquidTC, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTC.Validating
        If Not IsNumeric(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTC, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidTLG.Text) < Val(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTC, "沸点应>泄漏前的温度")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidTLG, "")
            ErrorProvider1.SetError(txtLeakLiquidTC, "")
        End If
    End Sub

    Private Sub txtLeakLiquidH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidH.Validating
        If Not IsNumeric(txtLeakLiquidH.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidH, "您输入的不是数值")
        ElseIf Val(txtLeakLiquidH.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidH, "您输入的数值必须>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidH, "")
        End If
    End Sub
End Class