Imports DataLib
Public Class frmLeakTwo

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        Dim QLG As Double '������
        QLG = DisPuff.Leak.CalculateLeakTwo(CDbl(txtLeakTwoCP.Text), CDbl(txtLeakTwoTLG.Text), CDbl(txtLeakTwoTC.Text), CDbl(txtLeakTwoH.Text), CDbl(txtLeakTwoPg.Text), CDbl(txtLeakTwoPl.Text), CDbl(txtLeakTwoCd.Text), CDbl(txtLeakTwoA.Text), CDbl(txtLeakTwoP.Text), CDbl(txtLeakTwoPC.Text)) 'ͨ�����ù�ʽ����������
        RichLeakResult.Text = "������й©����Ϊ��" & QLG & " kg/s��"
    End Sub

    Private Sub txtLeakTwoP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeakTwoP.TextChanged
        If txtLeakTwoP.Text <> "" And IsNumeric(txtLeakTwoP.Text) Then
            txtLeakTwoPC.Text = CStr(0.55 * CDbl(txtLeakTwoP.Text))
        End If
    End Sub



    Private Sub Command��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command��.Click

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
        frmNew.txtInT.Text = Me.txtLeakTwoTLG.Text
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
            If frmNew.txtGasP.Text <> "" And Val(frmNew.txtGasP.Text) > 101325 Then
                Me.txtLeakTwoP.Text = frmNew.txtGasP.Text
            Else
                Sign = True
                strSign = strSign & "������ѹ��" & vbCrLf
            End If
            If frmNew.txtPl.Text <> "" Then
                Me.txtLeakTwoPl.Text = frmNew.txtPl.Text
            Else
                Sign = True
                strSign = strSign & "Һ���ܶ�" & vbCrLf
            End If
            If frmNew.txtPg.Text <> "" Then
                Me.txtLeakTwoPg.Text = frmNew.txtPg.Text
            Else
                Sign = True
                strSign = strSign & "�����ܶ�" & vbCrLf
            End If
            If frmNew.txtCP.Text <> "" Then
                Me.txtLeakTwoCP.Text = frmNew.txtCP.Text
            Else
                Sign = True
                strSign = strSign & "Һ�嶨ѹ����" & vbCrLf
            End If
            If frmNew.txtTb.Text <> "" Then
                Me.txtLeakTwoTC.Text = frmNew.txtTb.Text
            Else
                Sign = True
                strSign = strSign & "�е�" & vbCrLf
            End If
            If frmNew.txtH.Text <> "" Then
                Me.txtLeakTwoH.Text = frmNew.txtH.Text
            Else
                Sign = True
                strSign = strSign & "Һ���������" & vbCrLf
            End If
            If Sign = True Then
                MsgBox("���ֶ��������²�����" & vbCrLf & strSign, MsgBoxStyle.Information, "���ݿ�...")
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakTwo() '����
    End Sub
    Public Sub SaveLeakTwo() '����
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
            Me.Text = "������й©������--" & strNameLast
            OutPutLeakTwo(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakTwo(sFile)
            '�����ļ�
        End If
    End Sub
    Private Sub OutPutLeakTwo(ByRef sFileName As String)  '����������й©������Ԥ������
        FileOpen(1, sFileName, OpenMode.Output)
        PrintLine(1, "LeakTwo")
        CheckIsSaved.Checked = True
        PrintLine(1, CheckIsSaved.Checked)
        PrintLine(1, txtName.Text)
        PrintLine(1, txtLeakTwoP.Text)
        PrintLine(1, txtLeakTwoPC.Text)
        PrintLine(1, txtLeakTwoA.Text)
        PrintLine(1, txtLeakTwoCd.Text)
        PrintLine(1, txtLeakTwoPl.Text)
        PrintLine(1, txtLeakTwoPg.Text)
        PrintLine(1, txtLeakTwoTLG.Text)
        PrintLine(1, txtLeakTwoTC.Text)
        PrintLine(1, txtLeakTwoH.Text)
        PrintLine(1, txtLeakTwoCP.Text)
        FileClose(1)
    End Sub
    Public Sub InPutLeakTwo(ByRef sFileName As String)  '����������й©������Ԥ������
        FileOpen(1, sFileName, OpenMode.Input)
        Input(1, SaveSign.Text)
        Input(1, CheckIsSaved.Checked)
        Input(1, txtName.Text)
        Input(1, txtLeakTwoP.Text)
        Input(1, txtLeakTwoPC.Text)
        Input(1, txtLeakTwoA.Text)
        Input(1, txtLeakTwoCd.Text)
        Input(1, txtLeakTwoPl.Text)
        Input(1, txtLeakTwoPg.Text)
        Input(1, txtLeakTwoTLG.Text)
        Input(1, txtLeakTwoTC.Text)
        Input(1, txtLeakTwoH.Text)
        Input(1, txtLeakTwoCP.Text)
        FileClose(1)
    End Sub

    Private Sub frmLeakTwo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetTip()
    End Sub
    '������ʾ
    Private Sub SetTip()
        ToolTip1.SetToolTip(txtLeakTwoP, ">0����ֵ������Ӧ�������ѹ��")
        ToolTip1.SetToolTip(txtLeakTwoA, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakTwoCd, "��ֵ��һ��ɲ�����")
        ToolTip1.SetToolTip(txtLeakTwoTLG, ">�е����ֵ")
        ToolTip1.SetToolTip(txtLeakTwoPl, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakTwoPg, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakTwoTC, "<�������¶�")
        ToolTip1.SetToolTip(txtLeakTwoH, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakTwoCP, ">0����ֵ")
    End Sub
    Private Sub txtLeakTwoP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoP.Validating
        If Not IsNumeric(txtLeakTwoP.Text) Then
            ErrorProvider1.SetError(txtLeakTwoP, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakTwoP, "������ѹ���������0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoP, "")
        End If
    End Sub

    Private Sub txtLeakTwoA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoA.Validating
        If Not IsNumeric(txtLeakTwoA.Text) Then
            ErrorProvider1.SetError(txtLeakTwoA, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoA.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakTwoA, "����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoA, "")
        End If
    End Sub

    Private Sub txtLeakTwoCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoCd.Validating
        If Not IsNumeric(txtLeakTwoCd.Text) Then
            ErrorProvider1.SetError(txtLeakTwoCd, "������Ĳ�����ֵ��")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoCd, "")
        End If
    End Sub

    Private Sub txtLeakTwoTLG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoTLG.Validating
        If Not IsNumeric(txtLeakTwoTLG.Text) Then
            ErrorProvider1.SetError(txtLeakTwoTLG, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoTLG.Text) <= Val(txtLeakTwoTC.Text) Then
            ErrorProvider1.SetError(txtLeakTwoTLG, "�������¶�Ӧ>Һ��ķе�")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoTLG, "")
            ErrorProvider1.SetError(txtLeakTwoTC, "")
        End If
    End Sub

    Private Sub txtLeakTwoPl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoPl.Validating
        If Not IsNumeric(txtLeakTwoPl.Text) Then
            ErrorProvider1.SetError(txtLeakTwoPl, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoPl.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakTwoPl, "����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoPl, "")
        End If
    End Sub

    Private Sub txtLeakTwoPg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoPg.Validating
        If Not IsNumeric(txtLeakTwoPg.Text) Then
            ErrorProvider1.SetError(txtLeakTwoPg, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoPg.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakTwoPg, "����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoPg, "")
        End If
    End Sub

    Private Sub txtLeakTwoTC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoTC.Validating
        If Not IsNumeric(txtLeakTwoTC.Text) Then
            ErrorProvider1.SetError(txtLeakTwoTC, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoTLG.Text) <= Val(txtLeakTwoTC.Text) Then
            ErrorProvider1.SetError(txtLeakTwoTC, "Һ��ķе�Ӧ<�������¶�")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoTLG, "")
            ErrorProvider1.SetError(txtLeakTwoTC, "")
        End If
    End Sub

    Private Sub txtLeakTwoH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoH.Validating
        If Not IsNumeric(txtLeakTwoH.Text) Then
            ErrorProvider1.SetError(txtLeakTwoH, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoH.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakTwoH, "����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoH, "")
        End If
    End Sub

    Private Sub txtLeakTwoCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoCP.Validating
        If Not IsNumeric(txtLeakTwoCP.Text) Then
            ErrorProvider1.SetError(txtLeakTwoCP, "������Ĳ�����ֵ��")
        ElseIf Val(txtLeakTwoCP.Text) <= 0 Then
            ErrorProvider1.SetError(txtLeakTwoCP, "����>0")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(txtLeakTwoCP, "")
        End If
    End Sub
End Class