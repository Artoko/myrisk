Imports DataLib
Public Class frmLeakFlash

    Private Sub cmdCalculateLeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculateLeak.Click
        Dim Fv_Renamed As Double
        Dim E1 As Double
        Dim QLG As Double
        Dim strFv As String
        QLG = CDbl(txtQ.Text)

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
        RichLeakResult.Text = strFv
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
        frmNew.txtName.Text = Me.txtName.Text
        frmNew.ShowDialog()
        If frmNew.DialogResult = Windows.Forms.DialogResult.OK Then
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveLeakFlash() '����
    End Sub
    Public Sub SaveLeakFlash() '����
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
            Me.Text = "����������--" & strNameLast
            '��������
            OutPutLeakFlash(sFile)
        Else
            sFile = Me.FileName.Text
            OutPutLeakFlash(sFile)
            '�����ļ�
        End If
    End Sub
    Private Sub OutPutLeakFlash(ByRef sFileName As String)  '��������Ԥ������
        FileOpen(1, sFileName, OpenMode.Output)
        '��������
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
    Public Sub InPutLeakFlash(ByRef sFileName As String) '������������Ԥ������
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
        ToolTip1.SetToolTip(txtQ, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidTLG, "��ֵ��Ӧ���ڷе���¶�")
        ToolTip1.SetToolTip(txtLeakLiquidTC, "��ֵ��Ӧ����й©ǰҺ����¶�")
        ToolTip1.SetToolTip(txtLeakLiquidCP, ">0����ֵ")
        ToolTip1.SetToolTip(txtLeakLiquidH, ">0����ֵ")
    End Sub

    Private Sub txtQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ.Validating
        If Not IsNumeric(txtQ.Text) Then
            ErrorProvider1.SetError(txtQ, "������Ĳ�����ֵ")
        ElseIf txtQ.Text <= 0 Then
            ErrorProvider1.SetError(txtQ, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtQ, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTLG_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTLG.Validating
        If Not IsNumeric(txtLeakLiquidTLG.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTLG, "������Ĳ�����ֵ")
        Else
            ErrorProvider1.SetError(txtLeakLiquidTLG, "")
        End If
    End Sub

    Private Sub txtLeakLiquidTC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidTC.Validating
        If Not IsNumeric(txtLeakLiquidTC.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidTC, "������Ĳ�����ֵ")
        Else
            ErrorProvider1.SetError(txtLeakLiquidTC, "")
        End If
    End Sub

    Private Sub txtLeakLiquidCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCP.Validating
        If Not IsNumeric(txtLeakLiquidCP.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "������Ĳ�����ֵ")
        ElseIf txtLeakLiquidCP.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidCP, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtLeakLiquidCP, "")
        End If
    End Sub

    Private Sub txtLeakLiquidH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidH.Validating
        If Not IsNumeric(txtLeakLiquidH.Text) Then
            ErrorProvider1.SetError(txtLeakLiquidH, "������Ĳ�����ֵ")
        ElseIf txtLeakLiquidH.Text <= 0 Then
            ErrorProvider1.SetError(txtLeakLiquidH, "��������ֵ����>0")
        Else
            ErrorProvider1.SetError(txtLeakLiquidH, "")
        End If
    End Sub
End Class