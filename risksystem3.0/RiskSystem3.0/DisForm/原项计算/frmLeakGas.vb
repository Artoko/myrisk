Imports DataLib
Public Class frmLeakGas
    Private Sub txtLeakGasP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP.Validating
        If Not IsNumeric(txtLeakGasP.Text) Then
            ErrorProvider1.SetError(txtLeakGasP, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakGasP.Text) < Val(txtLeakGasP0.Text) Or Val(txtLeakGasP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasP, "������ѹ���������0���Ҵ��ڻ���ڻ���ѹ����")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasP, "")
            ErrorProvider1.SetError(txtLeakGasP0, "")
        End If
    End Sub
    Private Sub txtLeakGasP0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP0.Validating
        If Not IsNumeric(txtLeakGasP0.Text) Then
            ErrorProvider1.SetError(txtLeakGasP0, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakGasP.Text) < Val(txtLeakGasP0.Text) Or Val(txtLeakGasP0.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasP0, "����ѹ���������0����С�ڻ����������ѹ����")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasP0, "")
            ErrorProvider1.SetError(txtLeakGasP, "")
        End If
    End Sub
    Private Sub txtLeakGasA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasA.Validating
        If Not IsNumeric(txtLeakGasA.Text) Then
            ErrorProvider1.SetError(txtLeakGasA, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakGasA.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasA, "�ѿ�����������0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasA, "")
        End If
    End Sub


    Private Sub txtLeakGasM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasM.Validating
        If Not IsNumeric(txtLeakGasM.Text) Then
            ErrorProvider1.SetError(txtLeakGasM, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakGasM.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakGasM, "�������������0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasM, "")
        End If
    End Sub

    Private Sub txtLeakGasTG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasTG.Validating
        If Not IsNumeric(txtLeakGasTG.Text) Then
            ErrorProvider1.SetError(txtLeakGasTG, "������Ĳ�����ֵ")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasTG, "")
        End If
    End Sub

    Private Sub txtLeakGasK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasK.Validating
        If Not IsNumeric(txtLeakGasK.Text) Then
            ErrorProvider1.SetError(txtLeakGasK, "������Ĳ�����ֵ")
        ElseIf Val(txtLeakGasK.Text) < 1 Or Val(txtLeakGasK.Text) >= 2 Then
            ErrorProvider1.SetError(txtLeakGasK, "����ָ��������1��2֮��")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakGasK, "")
        End If
    End Sub

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        '������
        Dim QG As Double
        Dim y As String
        y = DisPuff.Leak.strY(CDbl(txtLeakGasP0.Text), CDbl(txtLeakGasP.Text), CDbl(txtLeakGasK.Text)) '�ж��Ƿ��ٽ���
        Dim t As Double
        t = CDbl(txtLeakGasTG.Text) + 273.15 '�����϶�ת��Ϊ�����¶�
        QG = DisPuff.Leak.CalculateLeakGas(cboLeakGasShape.SelectedIndex, t, CDbl(txtLeakGasK.Text), CDbl(txtLeakGasP0.Text), CDbl(txtLeakGasP.Text), CDbl(txtLeakGasA.Text), CDbl(txtLeakGasM.Text)) '��������й©����
        RichLeakResult.Text = y & "����й©����Ϊ��" & QG & " kg/s��"
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        '�����ݿ��в������ݣ������� 
        '������ʾ��־�ͱ���
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
                strSign = strSign & "������ѹ��" & vbCrLf
            End If
            If frmNew.txtM.Text <> "" Then
                Me.txtLeakGasM.Text = frmNew.txtM.Text
            Else
                Sign = True
                strSign = strSign & "������" & vbCrLf
            End If
            If frmNew.txtGasK.Text <> "" Then
                Me.txtLeakGasK.Text = frmNew.txtGasK.Text
            Else
                Sign = True
                strSign = strSign & "�������ָ��" & vbCrLf
            End If
            If frmNew.txtInT.Text <> "" Then
                Me.txtLeakGasTG.Text = frmNew.txtInT.Text
            End If
            If Sign = True Then
                MsgBox("���ֶ��������²�����" & vbCrLf & strSign, MsgBoxStyle.Information, "���ݿ�...")
            End If
        End If
    End Sub
    Private Sub frmLeakGas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '��ʼ������й©�ѿ���״
        If CheckIsSaved.Checked = False Then
            cboLeakGasShape.SelectedIndex = 0
        End If
        '������ʾ
        SetTip()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakGas() '����
    End Sub
    Public Sub SaveLeakGas() '����
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
            Me.Text = "����й©������--" & strNameLast
            OutPutLeakGas(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakGas(sFile)
            '�����ļ�
        End If
    End Sub
    Private Sub OutPutLeakGas(ByRef sFileName As String) '�����������Ԥ������

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
    Public Sub InPutLeakGas(ByRef sFileName As String)  '��������й©������Ԥ������
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
    '������ʾ
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakGasP, ">0����ֵ����>=����ѹ��")
        ToolTip1.SetToolTip(txtLeakGasP0, ">0����ֵ����<=����ѹ��")
        ToolTip1.SetToolTip(txtLeakGasA, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakGasM, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakGasTG, "��ֵ")
        ToolTip1.SetToolTip(txtLeakGasK, "1��2֮�����ֵ")
    End Sub
End Class