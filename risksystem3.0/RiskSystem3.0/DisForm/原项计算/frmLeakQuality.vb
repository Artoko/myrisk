Imports DataLib
Public Class frmLeakQuality

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        Dim Q3 As Double
        Q3 = DisPuff.Leak.CalculateLeakQuality((cboLeakEvaporationStab.Text), CDbl(txtLeakEvaporationP.Text), CDbl(txtLeakEvaporationM.Text), (txtLeakEvaporationT0.Text), CDbl(txtLeakEvaporationu.Text), CDbl(txtLeakEvaporationS.Text)) '����������������
        RichLeakResult.Text = "������������Ϊ " & Q3 & " kg/s"
    End Sub

    Private Sub frmLeakQuality_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '��ʼ���ȶ�������
        If CheckIsSaved.Checked = False Then
            cboLeakEvaporationStab.SelectedIndex = 0 ' "���ȶ�(A��B)"
        End If
        SetTip()
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click

        '�����ݿ��в������ݣ������� 
        '������ʾ��־�ͱ���
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
                strSign = strSign & "Һ���������ѹ" & vbCrLf
            End If
            If frmnew.txtM.Text <> "" Then
                Me.txtLeakEvaporationM.Text = frmnew.txtM.Text
            Else
                Sign = True
                strSign = strSign & "Һ��ķ�����" & vbCrLf
            End If
            If Sign = True Then
                MsgBox("���ֶ��������²�����" & vbCrLf & strSign, MsgBoxStyle.Information, "���ݿ�...")
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakQuality() '����
    End Sub
    Public Sub SaveLeakQuality() '����
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
            OutPutLeakQuality(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakQuality(sFile)
            '�����ļ�
        End If
    End Sub
    Private Sub OutPutLeakQuality(ByRef sFileName As String) '������������������Ԥ������

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
    Public Sub InPutLeakQuality(ByRef sFileName As String) '������������������Ԥ������

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
    '������ʾ
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakEvaporationS, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationu, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationT0, "��ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationP, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakEvaporationM, ">0����ֵ")

    End Sub

    Private Sub txtLeakEvaporationS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationS.Validating
        If Not IsNumeric(txtLeakEvaporationS.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "������Ĳ�����ֵ")
        ElseIf txtLeakEvaporationS.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationS, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationS, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationu.Validating
        If Not IsNumeric(txtLeakEvaporationu.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationu, "������Ĳ�����ֵ")
        ElseIf txtLeakEvaporationu.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationu, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationu, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationT0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationT0.Validating
        If Not IsNumeric(txtLeakEvaporationT0.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationT0, "������Ĳ�����ֵ")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationT0, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationP.Validating
        If Not IsNumeric(txtLeakEvaporationP.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationP, "������Ĳ�����ֵ")
        ElseIf txtLeakEvaporationP.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationP, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationP, "")
        End If
    End Sub

    Private Sub txtLeakEvaporationM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationM.Validating
        If Not IsNumeric(txtLeakEvaporationM.Text) Then
            ErrorProvider1.SetError(txtLeakEvaporationM, "������Ĳ�����ֵ")
        ElseIf txtLeakEvaporationM.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakEvaporationM, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtLeakEvaporationM, "")
        End If
    End Sub
End Class