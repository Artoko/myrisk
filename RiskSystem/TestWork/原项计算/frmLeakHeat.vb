Public Class frmLeakHeat

    Private Sub frmLeakHeat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '��ʼ���������
        If CheckIsSaved.Checked = False Then
            cboLeakEvaporationGround.SelectedIndex = 0 'ˮ��
        End If
        '������ʾ
        SetTip()

    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        '�����ݿ��в������ݣ������� 
        '������ʾ��־�ͱ���
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
                strSign = strSign & "�е�" & vbCrLf
            End If
            If frmnew.txtH.Text <> "" Then
                Me.txtLeakEvaporationH.Text = frmnew.txtH.Text
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
        Dim Q2 As Double
        Q2 = DisPuff.Leak.CalculateLeakHeat(cboLeakEvaporationGround.SelectedIndex, CDbl(txtLeakEvaporationS.Text), CDbl(txtLeakEvaporationT0.Text), CDbl(txtLeakEvaporationTb.Text), CDbl(txtLeakEvaporationH.Text), CDbl(txtleakevaporationt.Text)) '����������������
        RichLeakResult.Text = "������������Ϊ " & Q2 & " kg/s"
    End Sub
    Public Sub SaveLeakHeat() '����
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
            Me.Text = "��������������--" & strNameLast
            OutPutLeakHeat(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakHeat(sFile)
            '�����ļ�
        End If
    End Sub
    Private Sub OutPutLeakHeat(ByRef sFileName As String) '����������������Ԥ������
        FileOpen(1, sFileName, OpenMode.Output)
        '��������
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
    Public Sub InPutLeakHeat(ByRef sFileName As String) '����������������Ԥ������
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
        SaveLeakHeat() '����
    End Sub
    '������ʾ
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakEvaporationS, ">0����ֵ")
        ToolTip1.SetToolTip(txtleakevaporationt, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationT0, ">Һ��е����ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationTb, "<�����¶ȵ���ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationH, ">0����ֵ")
    End Sub

    Private Sub txtLeakEvaporationS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationS.Validating
        If Not IsNumeric(txtLeakEvaporationS.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakEvaporationS.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationS, "")
        End If
    End Sub

    Private Sub txtleakevaporationt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtleakevaporationt.Validating
        If Not IsNumeric(txtleakevaporationt.Text) Then
            ErrorProvider1.SetError(txtleakevaporationt, "������Ĳ�����ֵ")
        ElseIf Val(txtleakevaporationt.Text) <= 0 Then
            ErrorProvider1.SetError(txtleakevaporationt, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtleakevaporationt, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationT0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationT0.Validating
        If Not IsNumeric(txtLeakEvaporationT0.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationT0, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakEvaporationT0.Text) < Val(txtLeakEvaporationTb.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationT0, "�����¶�Ӧ>Һ��е�")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationT0, "")
            ErrorProvider1.SetError(txtLeakEvaporationTb, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationTb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationTb.Validating
        If Not IsNumeric(txtLeakEvaporationTb.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationTb, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakEvaporationT0.Text) < Val(txtLeakEvaporationTb.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationTb, "Һ��е�Ӧ<�����¶�")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationT0, "")
            ErrorProvider1.SetError(txtLeakEvaporationTb, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationH.Validating
        If Not IsNumeric(txtLeakEvaporationH.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationH, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakEvaporationH.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationH, "���������ֵ����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakEvaporationH, "")
        End If
    End Sub
End Class