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

        '�����ݿ��в������ݣ������� 
        '������ʾ��־�ͱ���
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
                strSign = strSign & "������ѹ��" & vbCrLf
            End If
            If frmNew.txtPl.Text <> "" Then
                Me.txtLeakLiquidPl.Text = frmNew.txtPl.Text
            Else
                Sign = True
                strSign = strSign & "Һ���ܶ�" & vbCrLf
            End If
            If frmNew.txtCP.Text <> "" Then
                Me.txtLeakLiquidCP.Text = frmNew.txtCP.Text
            Else
                Sign = True
                strSign = strSign & "Һ�嶨ѹ����" & vbCrLf
            End If
            If frmNew.txtTb.Text <> "" Then
                Me.txtLeakLiquidTC.Text = frmNew.txtTb.Text
            Else
                Sign = True
                strSign = strSign & "�е�" & vbCrLf
            End If
            If frmNew.txtH.Text <> "" Then
                Me.txtLeakLiquidH.Text = frmNew.txtH.Text
            Else
                Sign = True
                strSign = strSign & "Һ���������" & vbCrLf
            End If
            If Sign = True Then
                MsgBox("���ֶ��������²�����" & vbCrLf & strSign, MsgBoxStyle.Information, "���ݿ�...")
            End If
        End If
    End Sub

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        'ȷ���Ƿ��Ǹ߶�
        Dim strH As String
        If chkHeight.CheckState = 0 Then
            strH = "������Һλ�߶ȵ�ѹ��" & vbCrLf
        Else
            strH = "����Һλ�߶ȵ�ѹ��" & vbCrLf
        End If
        '����Һ��й©��
        Dim QLG As Double
        QLG = DisPuff.Leak.CalculateLeakLiquid((chkHeight.CheckState), CDbl(txtLeakLiquidCd.Text), (txtLeakLiquidHeight.Text), CDbl(txtLeakLiquidA.Text), CDbl(txtLeakLiquidPl.Text), CDbl(txtLeakLiquidP.Text), CDbl(txtLeakLiquidP0.Text))

        Dim strQLG As String
        strQLG = "Һ��й©��Ϊ " & QLG & " kg/s��" & vbCrLf
        '����й©Һ���������

        Dim Fv_Renamed As Double
        Dim E1 As Double
        Dim strFv As String
        If chkEvaporation.CheckState = 0 Then
            strFv = ""
        Else
            If chkLiquid.CheckState = 0 Then
                Fv_Renamed = DisPuff.Leak.CalculateLeakFv(CDbl(txtLeakLiquidCP.Text), CDbl(txtLeakLiquidTLG.Text), CDbl(txtLeakLiquidTC.Text), CDbl(txtLeakLiquidH.Text)) '��������ϵ��
                If Fv_Renamed >= 1.0# Then
                    strFv = "����������ʱ����Һ�ε�����������Һ������ϵ�� Fv= " & Fv_Renamed & vbCrLf & "Fv>1.0��Һ��ȫ������" & vbCrLf & "Һ��������Ϊ " & QLG & " kg/s��"
                ElseIf Fv_Renamed <= 0 Then
                    strFv = "����������ʱ����Һ�ε�����������Һ������ϵ�� Fv= " & Fv_Renamed & vbCrLf & "Fv<=0��Һ�岻�ᷢ������" & vbCrLf & "Һ��������Ϊ 0 kg/s��"
                Else
                    E1 = Fv_Renamed * QLG
                    strFv = "����������ʱ����Һ�ε�����������Һ������ϵ�� Fv= " & Fv_Renamed & vbCrLf & "Fv<1.0��Һ�岿������" & vbCrLf & "Һ��������Ϊ " & E1 & " kg/s��"
                End If
            Else
                Fv_Renamed = DisPuff.Leak.CalculateLeakFv(CDbl(txtLeakLiquidCP.Text), CDbl(txtLeakLiquidTLG.Text), CDbl(txtLeakLiquidTC.Text), CDbl(txtLeakLiquidH.Text)) '��������ϵ��
                If Fv_Renamed >= 0.2 Then
                    strFv = "��������ʱ����Һ�ε�����������Һ������ϵ�� Fv= " & Fv_Renamed & vbCrLf & "Fv>0.2��Һ��ȫ������" & vbCrLf & "Һ��������Ϊ " & QLG & " kg/s��"
                ElseIf Fv_Renamed <= 0 Then
                    strFv = "��������ʱ����Һ�ε�����������Һ������ϵ�� Fv= " & Fv_Renamed & vbCrLf & "Fv<=0��Һ�岻�ᷢ������" & vbCrLf & "Һ��������Ϊ 0 kg/s��"
                Else
                    E1 = Fv_Renamed * 5 * QLG
                    strFv = "��������ʱ����Һ�ε�����������Һ������ϵ�� Fv= " & Fv_Renamed & vbCrLf & "Fv<0.2��Һ�岿������" & vbCrLf & "Һ��������Ϊ " & E1 & " kg/s��"
                End If
            End If
        End If
        RichLeakResult.Text = strH & strQLG & strFv
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakLiquid() '����
    End Sub
    Public Sub SaveLeakLiquid() '����
        Dim SaveFileDialog1 As New SaveFileDialog
        Dim sFile As String
        Dim strNameLast As String = ""
       If CheckIsSaved.Checked = False Then
            With SaveFileDialog1
                .Filter = "��ȫ����ģ��ϵͳ�ļ� (*.sms)|*.sms"
                .ShowDialog()
                If Len(.FileName) = 0 Then
                    Exit Sub
                End If
                sFile = .FileName
            End With
            '�����ļ���
            Me.FileName.Text = sFile
            'strNameLast = GetFileName(sFile)
            Me.Text = "Һ��й©������--" & strNameLast
            OutPutLeakLiquid(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakLiquid(sFile)
            '�����ļ�
        End If
    End Sub
    Private Sub OutPutLeakLiquid(ByRef sFileName As String)  '����Һ��й©������Ԥ������
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
    Public Sub InPutLeakLiquid(ByRef sFileName As String)  '����Һ��й©������Ԥ������
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
    '������ʾ
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakLiquidP, ">0����ֵ���������ڵ�ѹ��Ӧ>=����ѹ��")
        ToolTip1.SetToolTip(txtLeakLiquidP0, ">0����ֵ���һ���ѹ��Ӧ<=�����ڵ�ѹ��")
        ToolTip1.SetToolTip(txtLeakLiquidA, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidCd, "0��1֮�����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidHeight, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidPl, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidTLG, "й©ǰ���¶�Ӧ>�е�")
        ToolTip1.SetToolTip(txtLeakLiquidTC, "�е�Ӧ<й©ǰ���¶�")
        ToolTip1.SetToolTip(txtLeakLiquidCP, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidH, ">0����ֵ")
    End Sub

    Private Sub txtLeakLiquidP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidP.Validating
        If Not IsNumeric(txtLeakLiquidP.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidP, "���������ֵ����>0")
        ElseIf Val(txtLeakLiquidP.Text) < Val(txtLeakLiquidP0.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP, "�����ڵ�ѹ��Ӧ>=����ѹ��")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidP, "")
            ErrorProvider1.SetError(txtLeakLiquidP0, "")
        End If
    End Sub

    Private Sub txtLeakLiquidP0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidP0.Validating
        If Not IsNumeric(txtLeakLiquidP0.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP0, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidP0.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidP0, "���������ֵ����>0")
        ElseIf Val(txtLeakLiquidP.Text) < Val(txtLeakLiquidP0.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidP0, "����ѹ��Ӧ<=�����ڵ�ѹ��")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidP, "")
            ErrorProvider1.SetError(txtLeakLiquidP0, "")
        End If
    End Sub

    Private Sub txtLeakLiquidA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidA.Validating
        If Not IsNumeric(txtLeakLiquidA.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidA, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidA.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidA, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidA, "")
        End If
    End Sub

    Private Sub txtLeakLiquidCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCd.Validating
        If Not IsNumeric(txtLeakLiquidCd.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidCd, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidCd.Text) <= 0 Or Val(txtLeakLiquidCd.Text) >= 1 Then
            ErrorProvider1.SetError(txtLeakLiquidCd, "��ֵ������0��1֮��")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidCd, "")
        End If
    End Sub

    Private Sub txtLeakLiquidCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCP.Validating
        If Not IsNumeric(txtLeakLiquidCP.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidCP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidCP, "")
        End If
    End Sub

    Private Sub txtLeakLiquidHeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidHeight.Validating
        If Not IsNumeric(txtLeakLiquidHeight.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidHeight, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidHeight.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidHeight, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidHeight, "")
        End If
    End Sub

    Private Sub txtLeakLiquidPl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidPl.Validating
        If Not IsNumeric(txtLeakLiquidPl.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidPl, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidPl.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidPl, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidPl, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTLG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTLG.Validating
        If Not IsNumeric(txtLeakLiquidTLG.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTLG, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidTLG.Text) < Val(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTLG, "й©ǰ���¶�Ӧ>�е�")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidTLG, "")
            ErrorProvider1.SetError(txtLeakLiquidTC, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTC.Validating
        If Not IsNumeric(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTC, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidTLG.Text) < Val(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTC, "�е�Ӧ>й©ǰ���¶�")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidTLG, "")
            ErrorProvider1.SetError(txtLeakLiquidTC, "")
        End If
    End Sub

    Private Sub txtLeakLiquidH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidH.Validating
        If Not IsNumeric(txtLeakLiquidH.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidH, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakLiquidH.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidH, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakLiquidH, "")
        End If
    End Sub
End Class