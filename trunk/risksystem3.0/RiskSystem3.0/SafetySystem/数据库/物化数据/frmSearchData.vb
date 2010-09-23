Imports System.Windows.Forms
Imports System.Data
Public Class frmSearchData
    Private rstUserList As ADODB.Recordset
    Private strUserName3, strUserName1, strUserName2, strUserName4 As String
    Private strUserName0 As String
    Dim Shomate(100, 100) As String '��������������
    Dim Antoine(10, 20) As String '����������ѹ��Antoine����

    Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click '���Ҳ��б�����
        '����û�û�����룬�򲻲���
        If txtName.Text = "" Then
            MsgBox("������Ҫ���ҵ�����")
            Exit Sub
        End If
        '���б�����ʾ
        ListView1.Items.Clear() '����б�

        UnEncrypt(DataSource) '�������ݿ�

        Call Data_Connect() '�������ݿ�
        rstUserList = New ADODB.Recordset '���ü�¼��

        strSQL = SQLCondiction() '�����û�ѡ��ȷ����ѯ����
        rstUserList.Open(strSQL, conADO) '�򿪼�¼��
        Dim nListIndex As Short
        nListIndex = 1
        Do Until rstUserList.EOF = True  '�����б��
            '�����Ӧ������ΪNULL����Ϊ""

            If IsDBNull(rstUserList.Fields("������1").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("������1").Value
            End If
            If IsDBNull(rstUserList.Fields("������2").Value) Then
                strUserName1 = ""
            Else
                strUserName1 = rstUserList.Fields("������2").Value
            End If
            If IsDBNull(rstUserList.Fields("Ӣ����1").Value) Then
                strUserName2 = ""
            Else
                strUserName2 = rstUserList.Fields("Ӣ����1").Value
            End If
            If IsDBNull(rstUserList.Fields("Ӣ����2").Value) Then
                strUserName3 = ""
            Else
                strUserName3 = rstUserList.Fields("Ӣ����2").Value
            End If
            If IsDBNull(rstUserList.Fields("CAS").Value) Then
                strUserName4 = ""
            Else
                strUserName4 = rstUserList.Fields("CAS").Value
            End If
            '��ѯ����������
            ListView1.Items.Add(strUserName0, 0)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName1)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName2)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName3)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName4)
            nListIndex = nListIndex + 1
            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '�رռ�¼��
        rstUserList = Nothing
        data_Colse() '�Ͽ����ݿ�
        Encrypt(DataSource) '�������ݿ�
        If ListView1.Items.Count < 1 Then
            MsgBox("���ݿ���û����Ҫ���ҵ����ʣ���ſ��ѯ����!��Ҫ���ҡ������ѡ������롮���ѡ����ѡ���")
        End If
    End Sub



    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Encrypt(DataSource) '�������ݿ�
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        UnEncrypt(DataSource) '�������ݿ�
    End Sub
    Private Sub frmSearchData_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cmbSearchType.SelectedIndex = 0
        '��ʼ�����
    End Sub
    Private Function SQLCondiction() As String
        Dim strName As String
        Dim strSQLCondiction As String
        strSQLCondiction = txtName.Text
        '����ַ����к��е����ţ�Ӧת��
        Dim nLen As Short
        Dim nStart As Short
        Dim nEnd As Short
        nStart = 1
        nEnd = 1
        Dim strStart As String
        Dim strEnd As String
        strStart = ""
        strEnd = ""
        nLen = Len(strSQLCondiction)
        nEnd = InStr(nStart, strSQLCondiction, "'")
        While nEnd > 0
            strEnd = Mid(strSQLCondiction, nStart, nEnd - nStart + 1)
            strStart = strStart & strEnd & "'"
            nStart = nEnd + 1
            nEnd = InStr(nStart, strSQLCondiction, "'")
        End While
        strEnd = Mid(strSQLCondiction, nStart, nLen)
        strStart = strStart & strEnd
        strName = strStart

        Select Case cmbSearchType.SelectedIndex
            Case 0
                SQLCondiction = "SELECT * FROM NIST where ������1 like '%" & strName & "%' or " & "������2 like '%" & strName & "%'"
            Case 1
                SQLCondiction = "SELECT * FROM NIST where Ӣ����1 like '%" & strName & "%' or " & "Ӣ����2 like '%" & strName & "%'"
            Case 2
                SQLCondiction = "SELECT * FROM NIST where CAS = '" & strName & "'"

            Case Else
                SQLCondiction = ""
                MsgBox("��ѯ��������������ѡ��")
        End Select
    End Function

    Private Function SQLCondictionResult() As String
        Dim strName As String
        Dim strSQLCondiction As String
        strSQLCondiction = ListView1.FocusedItem.Text
        '����ַ����к��е����ţ�Ӧת��
        Dim nLen As Short
        Dim nStart As Short
        Dim nEnd As Short
        nStart = 1
        nEnd = 1
        Dim strStart As String
        Dim strEnd As String
        strStart = ""
        strEnd = ""
        nLen = Len(strSQLCondiction)
        nEnd = InStr(nStart, strSQLCondiction, "'")
        While nEnd > 0
            strEnd = Mid(strSQLCondiction, nStart, nEnd - nStart + 1)
            strStart = strStart & strEnd & "'"
            nStart = nEnd + 1
            nEnd = InStr(nStart, strSQLCondiction, "'")
        End While
        strEnd = Mid(strSQLCondiction, nStart, nLen)
        strStart = strStart & strEnd
        strName = strStart

        SQLCondictionResult = "SELECT * FROM NIST where ������1 = '" & strName & "'"
    End Function

    Private Sub ListView1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ListView1.Click
        Dim Hv As Double
        Dim Hc As Double
        Dim HCP As Double
        Dim dblGasK As Double
        Dim strGasK As String
        Dim dblP As Double
        Dim strAntoine As String '����ѹ
        If ListView1.Items.Count <> 0 Then
            UnEncrypt(DataSource) '�������ݿ�
            Call Data_Connect() '�������ݿ�
            rstUserList = New ADODB.Recordset '���ü�¼��
            strSQL = SQLCondictionResult() '�����û�ѡ��ȷ����ѯ����
            rstUserList.Open(strSQL, conADO) '�򿪼�¼��
            '�����Ӧ������ΪNULL����Ϊ""
            If IsDBNull(rstUserList.Fields("������1").Value) Then
                txtChineseName1.Text = ""
            Else
                txtChineseName1.Text = rstUserList.Fields("������1").Value
            End If
            If IsDBNull(rstUserList.Fields("������2").Value) Then
                txtChineseName2.Text = ""
            Else
                txtChineseName2.Text = rstUserList.Fields("������2").Value
            End If
            If IsDBNull(rstUserList.Fields("Ӣ����1").Value) Then
                txtEnglishName1.Text = ""
            Else
                txtEnglishName1.Text = rstUserList.Fields("Ӣ����1").Value
            End If
            If IsDBNull(rstUserList.Fields("Ӣ����2").Value) Then
                txtEnglishName2.Text = ""
            Else
                txtEnglishName2.Text = rstUserList.Fields("Ӣ����2").Value
            End If
            If IsDBNull(rstUserList.Fields("CAS").Value) Then
                txtCAS.Text = ""
            Else
                txtCAS.Text = rstUserList.Fields("CAS").Value
            End If
            '���¸�����Ҫ���ҵ����������Ӧ������----------------------------------------
            'Ħ������
            If IsDBNull(rstUserList.Fields("������").Value) Then
                txtM.Text = ""
            Else
                txtM.Text = CStr(Val(rstUserList.Fields("������").Value) * 0.001)
            End If
            'Һ���ܶ�
            If txtPl.Visible = True Then
                If IsDBNull(rstUserList.Fields("����ܶ�ˮ").Value) Then
                    txtPl.Text = ""
                Else
                    txtPl.Text = CStr(Val(rstUserList.Fields("����ܶ�ˮ").Value)) * 1000
                End If
            End If
            '�����ܶ�
            If txtPg.Visible = True Then
                If IsDBNull(rstUserList.Fields("����ܶȿ���").Value) Then
                    txtPg.Text = ""
                Else
                    txtPg.Text = CStr(1.293 * Val(rstUserList.Fields("����ܶȿ���").Value))
                    If CDbl(txtPg.Text) = 0 Then
                        txtPg.Text = ""
                    End If
                End If
            End If
            '�е�
            If txtTb.Visible = True Then
                If IsDBNull(rstUserList.Fields("�е�").Value) Then
                    txtTb.Text = ""
                Else
                    txtTb.Text = CStr(Val(rstUserList.Fields("�е�").Value))
                End If
            End If
            '�����ȣ���λ��KJ/molת����J/kg
            If txtH.Visible = True Then
                If IsDBNull(rstUserList.Fields("Hvap").Value) Then
                    txtH.Text = ""
                Else
                    Hv = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("Hvap").Value) * 1000, 1))
                    txtH.Text = CStr(Hv)
                End If
            End If
            'ȼ���ȣ���λ��KJ/molת����J/kg
            If txtHc.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("Hcliqud").Value) Then

                    Hc = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("Hcliqud").Value) * 1000, 1))
                    txtHc.Text = CStr(Hc)
                ElseIf Not (IsDBNull(rstUserList.Fields("ȼ����").Value) Or rstUserList.Fields("ȼ����").Value = "������" Or rstUserList.Fields("ȼ����").Value = "������") Then
                    Hc = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("ȼ����").Value) * 1000, 1))
                    txtHc.Text = CStr(Hc)
                ElseIf Not IsDBNull(rstUserList.Fields("Hcgas").Value) Then
                    Hc = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("Hcgas").Value) * 1000, 1))
                    txtHc.Text = CStr(Hc)
                Else
                    txtHc.Text = ""
                End If
            End If
            'Һ�嶨ѹ���ȣ���J/molת����J/kg
            If txtCP.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("CpLiquid").Value) Then

                    HCP = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("CpLiquid").Value), 1))
                    txtCP.Text = CStr(HCP)
                Else
                    txtCP.Text = ""
                End If
            End If
            '���嶨ѹ����, ��J / molת����J / kg
            If txtGasCp.Visible = True Then
                Dim strCp As String = ""
                Dim dblCp As Double = 0
                If Not IsDBNull(rstUserList.Fields("Shomate Equation").Value) Then
                    strCp = rstUserList.Fields("Shomate Equation").Value
                    dblCp = ChangeShomateToCp(strCp, CDbl(txtInT.Text) + FreezingPoint) '�����ݼ�������,��������Ӧ���������ϵ��
                    txtGasCp.Text = FormatNumber(dblCp / CDbl(txtM.Text), 0, TriState.True, TriState.False, TriState.False) 'ת����J/kg
                ElseIf Not IsDBNull(rstUserList.Fields("CpGas").Value) Then
                    strCp = rstUserList.Fields("CpGas").Value
                    dblCp = ChangeCpGasToCp(strCp, CDbl(txtInT.Text) + FreezingPoint) '�����ݼ�������,��������Ӧ���������ϵ��
                    txtGasCp.Text = FormatNumber(dblCp / CDbl(txtM.Text), 0, TriState.True, TriState.False, TriState.False) 'ת����J/kg
                Else
                    txtGasCp.Text = ""
                End If
            End If
            '�������ָ�����ȼ�������ĵ�ѹ���ݣ���+8.314��������ĵ�������
            If txtGasK.Visible = True Then

                If Not IsDBNull(rstUserList.Fields("Shomate Equation").Value) Then
                    strGasK = rstUserList.Fields("Shomate Equation").Value
                    dblGasK = ChangeShomate(strGasK, CDbl(txtInT.Text) + FreezingPoint) '�����ݼ�������,��������Ӧ���������ϵ��
                    txtGasK.Text = CStr(dblGasK)
                ElseIf Not IsDBNull(rstUserList.Fields("CpGas").Value) Then
                    strGasK = rstUserList.Fields("CpGas").Value
                    dblGasK = ChangeCpGas(strGasK, CDbl(txtInT.Text) + FreezingPoint) '�����ݼ�������,��������Ӧ���������ϵ��
                    txtGasK.Text = CStr(dblGasK)
                Else
                    txtGasK.Text = ""
                End If
            End If
            '����������ѹ����������ʽ����
            If txtGasP.Visible = True Then

                If Not IsDBNull(rstUserList.Fields("Antoine").Value) Then
                    strAntoine = rstUserList.Fields("Antoine").Value
                    dblP = ChangeAntoine(strAntoine, CDbl(txtInT.Text) + FreezingPoint) '�����ݼ�������
                    txtGasP.Text = CStr(dblP)
                Else
                    txtGasP.Text = ""
                End If
            End If
            '��������ѹ����������ʽ����
            If txtOutGasP.Visible = True Then

                If Not IsDBNull(rstUserList.Fields("Antoine").Value) Then
                    strAntoine = rstUserList.Fields("Antoine").Value
                    dblP = ChangeAntoine(strAntoine, CDbl(txtOutT.Text) + FreezingPoint) '�����ݼ�������
                    txtOutGasP.Text = CStr(dblP)
                Else
                    txtOutGasP.Text = ""
                End If
            End If
            '��������
            If txtLC50.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("LC50").Value) Then
                    txtLC50.Text = rstUserList.Fields("LC50").Value
                Else
                    txtLC50.Text = ""
                End If
            End If
            If txtLMax.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("�й�").Value) Then
                    txtLMax.Text = rstUserList.Fields("�й�").Value
                Else
                    txtLMax.Text = ""
                End If
            End If
           

            rstUserList.Close() '�رռ�¼��
            rstUserList = Nothing
            data_Colse() '�Ͽ����ݿ�

            Encrypt(DataSource) '�������ݿ�
        Else
            MsgBox("�б��ǿյģ����Ȳ��Һ��ٵ����б���ȷ�����ҵ�����!")
        End If
    End Sub

    Private Sub txtName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then '����û��س���ʼ����
            cmdSearch_Click(cmdSearch, New System.EventArgs())
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Function ChangeShomate(ByVal GasK As String, ByVal dbl_T As Double) As Double '���������ݼ���������,������������¶ȼ������ָ��

        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short

        Dim strM As String
        GasK = GasK & " " '���ַ����������һ���ո��Է������ļ���
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '�������
        While nEnd <= nLen - 1 Or nLen <= 0
            '�����ݼ����б���
            nEnd = InStr(nStart, GasK, " ")
            nEnter = InStr(nStartCol, GasK, Chr(13))
            If nEnd > nEnter And nEnter > 0 Then
                i = i + 1
                j = 1
                nStartCol = nEnd + 1
            End If
            If nEnd - nStart > 0 Then
                strM = Mid(GasK, nStart, nEnd - nStart)
                Shomate(i, j) = strM
                j = j + 1
            End If
            nStart = nEnd + 1
        End While
        '���������е��������������ݺ;���ָ��
        Dim Cp As Double
        Dim c, a, b, D As Double
        Dim E As Double


        Dim Tem As String '���ݿ��е��¶ȷ�Χ
        If dbl_T >= Val(Shomate(1, 3)) And dbl_T <= Val(Shomate(1, 5)) Then
            a = Val(Shomate(2, 2))
            b = Val(Shomate(3, 2))
            c = Val(Shomate(4, 2))
            D = Val(Shomate(5, 2))
            E = Val(Shomate(6, 2))
        ElseIf dbl_T >= Val(Shomate(1, 6)) And dbl_T <= Val(Shomate(1, 8)) Then
            a = Val(Shomate(2, 3))
            b = Val(Shomate(3, 3))
            c = Val(Shomate(4, 3))
            D = Val(Shomate(5, 3))
            E = Val(Shomate(6, 3))
        Else
            Tem = Shomate(1, 3) & Shomate(1, 4) & Shomate(1, 5) & Shomate(1, 6) & Shomate(1, 7) & Shomate(1, 8)
            'msg = MsgBox("���ݿ���û������������¶ȷ�Χ���������ָ�����ݣ����ݿ���¶����ݷ�ΧΪ" & Tem & "K��ϵͳ���Ը�����������¶ȹ����������ָ����������¶�ƫ�뷶Χ�ϴ�(>50K)���벻Ҫ���й��㡣ȷ��Ҫ����Ľ����", 4 + 32)
            'If msg = MsgBoxResult.Yes Then
            If dbl_T <= Val(Shomate(1, 3)) Or Shomate(1, 6) = "" Then
                a = Val(Shomate(2, 2))
                b = Val(Shomate(3, 2))
                c = Val(Shomate(4, 2))
                D = Val(Shomate(5, 2))
                E = Val(Shomate(6, 2))
            Else
                a = Val(Shomate(2, 3))
                b = Val(Shomate(3, 3))
                c = Val(Shomate(4, 3))
                D = Val(Shomate(5, 3))
                E = Val(Shomate(6, 3))
            End If
            'Else
            '    Exit Function
            'End If
        End If
        Dim t As Double
        t = dbl_T / 1000
        Cp = a + b * t + c * t ^ 2 + D * t ^ 3 + E / t ^ 2
        Dim K As Double
        K = Cp / (Cp - MooreR)
        ChangeShomate = CDbl(FormatNumber(K, 4))
    End Function

    Private Function ChangeShomateToCp(ByVal GasK As String, ByVal dbl_T As Double) As Double '���������ݼ���������,������������¶ȼ������ָ��

        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short

        Dim strM As String
        GasK = GasK & " " '���ַ����������һ���ո��Է������ļ���
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '�������
        While nEnd <= nLen - 1 Or nLen <= 0
            '�����ݼ����б���
            nEnd = InStr(nStart, GasK, " ")
            nEnter = InStr(nStartCol, GasK, Chr(13))
            If nEnd > nEnter And nEnter > 0 Then
                i = i + 1
                j = 1
                nStartCol = nEnd + 1
            End If
            If nEnd - nStart > 0 Then
                strM = Mid(GasK, nStart, nEnd - nStart)
                Shomate(i, j) = strM
                j = j + 1
            End If
            nStart = nEnd + 1
        End While
        '���������е��������������ݺ;���ָ��
        Dim Cp As Double
        Dim c, a, b, D As Double
        Dim E As Double


        Dim Tem As String '���ݿ��е��¶ȷ�Χ
        If dbl_T >= Val(Shomate(1, 3)) And dbl_T <= Val(Shomate(1, 5)) Then
            a = Val(Shomate(2, 2))
            b = Val(Shomate(3, 2))
            c = Val(Shomate(4, 2))
            D = Val(Shomate(5, 2))
            E = Val(Shomate(6, 2))
        ElseIf dbl_T >= Val(Shomate(1, 6)) And dbl_T <= Val(Shomate(1, 8)) Then
            a = Val(Shomate(2, 3))
            b = Val(Shomate(3, 3))
            c = Val(Shomate(4, 3))
            D = Val(Shomate(5, 3))
            E = Val(Shomate(6, 3))
        Else
            Tem = Shomate(1, 3) & Shomate(1, 4) & Shomate(1, 5) & Shomate(1, 6) & Shomate(1, 7) & Shomate(1, 8)
            'msg = MsgBox("���ݿ���û������������¶ȷ�Χ���������ָ�����ݣ����ݿ���¶����ݷ�ΧΪ" & Tem & "K��ϵͳ���Ը�����������¶ȹ����������ָ����������¶�ƫ�뷶Χ�ϴ�(>50K)���벻Ҫ���й��㡣ȷ��Ҫ����Ľ����", 4 + 32)
            'If msg = MsgBoxResult.Yes Then
            If dbl_T <= Val(Shomate(1, 3)) Or Shomate(1, 6) = "" Then
                a = Val(Shomate(2, 2))
                b = Val(Shomate(3, 2))
                c = Val(Shomate(4, 2))
                D = Val(Shomate(5, 2))
                E = Val(Shomate(6, 2))
            Else
                a = Val(Shomate(2, 3))
                b = Val(Shomate(3, 3))
                c = Val(Shomate(4, 3))
                D = Val(Shomate(5, 3))
                E = Val(Shomate(6, 3))
            End If
            'Else
            '    Exit Function
            'End If
        End If
        Dim t As Double
        t = dbl_T / 1000
        Cp = a + b * t + c * t ^ 2 + D * t ^ 3 + E / t ^ 2
        Return Cp
    End Function

    Sub ClearShomate()  '�������
        Dim i As Short
        Dim j As Short
        For i = 1 To 100 Step 1
            For j = 1 To 100 Step 1
                Shomate(i, j) = ""
            Next j
        Next i
    End Sub
    Private Function ChangeCpGas(ByVal GasK As String, ByVal dbl_T As Double) As Double '���������ݼ���������,������������¶ȼ������ָ��
        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short
        Dim strM As String
        GasK = GasK & " " '���ַ����������һ���ո��Է������ļ���
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '�������
        While nEnd <= nLen - 1 Or nLen <= 0
            '�����ݼ����б���
            nEnd = InStr(nStart, GasK, " ")
            nEnter = InStr(nStartCol, GasK, Chr(13))
            If nEnd > nEnter And nEnter > 0 Then
                i = i + 1
                j = 1
                nStartCol = nEnd + 1
            End If
            If nEnd - nStart > 0 Then
                strM = Mid(GasK, nStart, nEnd - nStart)
                Shomate(i, j) = strM
                j = j + 1
            End If
            nStart = nEnd + 1
        End While
        '���������е��������������ݺ;���ָ��
        Dim Cp As Double
        Dim m As Short
        Dim Tem As String '���ݿ��е��¶ȷ�Χ
        If dbl_T < CDbl(Shomate(1, 2)) Or dbl_T > CDbl(Shomate(i, 2)) Then
            Tem = Shomate(1, 2) & " - " & Shomate(i, 2)
            'msg = MsgBox("���ݿ���û������������¶ȷ�Χ���������ָ�����ݣ����ݿ���¶����ݷ�ΧΪ" & Tem & "K��ϵͳ���Ը�����������¶ȹ����������ָ����������¶�ƫ�뷶Χ�ϴ�(>50K)���벻Ҫ���й��㡣ȷ��Ҫ����Ľ����", 4 + 32)
            'If msg = MsgBoxResult.Yes Then
            If dbl_T <= Val(Shomate(1, 2)) Then
                Cp = CDbl(Shomate(2, 2)) + (dbl_T - CDbl(Shomate(2, 1))) * (CDbl(Shomate(1, 2)) - CDbl(Shomate(2, 2))) / (CDbl(Shomate(1, 1)) - CDbl(Shomate(1, 2)))
            Else
                Cp = CDbl(Shomate(i - 1, 1)) + (dbl_T - CDbl(Shomate(i - 1, 2))) * (CDbl(Shomate(i - 1, 1)) - CDbl(Shomate(i, 1))) / (CDbl(Shomate(i - 1, 2)) - CDbl(Shomate(i, 2)))
            End If
            'Else
            '    Exit Function
            'End If
        Else
        m = 1
        While dbl_T > CDbl(Shomate(m + 1, 2))
            m = m + 1
        End While
        Cp = CDbl(Shomate(m, 1)) + (dbl_T - CDbl(Shomate(m, 2))) * (CDbl(Shomate(m + 1, 1)) - CDbl(Shomate(m, 1))) / (CDbl(Shomate(m + 1, 2)) - CDbl(Shomate(m, 2)))
        End If
        Dim K As Double
        K = Cp / (Cp - MooreR)
        ChangeCpGas = CDbl(FormatNumber(K, 4))
    End Function
    Private Function ChangeCpGasToCp(ByVal GasK As String, ByVal dbl_T As Double) As Double '���������ݼ���������,������������¶ȼ������ָ��
        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short
        Dim strM As String
        GasK = GasK & " " '���ַ����������һ���ո��Է������ļ���
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '�������
        While nEnd <= nLen - 1 Or nLen <= 0
            '�����ݼ����б���
            nEnd = InStr(nStart, GasK, " ")
            nEnter = InStr(nStartCol, GasK, Chr(13))
            If nEnd > nEnter And nEnter > 0 Then
                i = i + 1
                j = 1
                nStartCol = nEnd + 1
            End If
            If nEnd - nStart > 0 Then
                strM = Mid(GasK, nStart, nEnd - nStart)
                Shomate(i, j) = strM
                j = j + 1
            End If
            nStart = nEnd + 1
        End While
        '���������е��������������ݺ;���ָ��
        Dim Cp As Double
        Dim m As Short
        Dim Tem As String '���ݿ��е��¶ȷ�Χ
        If dbl_T < CDbl(Shomate(1, 2)) Or dbl_T > CDbl(Shomate(i, 2)) Then
            Tem = Shomate(1, 2) & " - " & Shomate(i, 2)
            'msg = MsgBox("���ݿ���û������������¶ȷ�Χ���������ָ�����ݣ����ݿ���¶����ݷ�ΧΪ" & Tem & "K��ϵͳ���Ը�����������¶ȹ����������ָ����������¶�ƫ�뷶Χ�ϴ�(>50K)���벻Ҫ���й��㡣ȷ��Ҫ����Ľ����", 4 + 32)
            'If msg = MsgBoxResult.Yes Then
            If dbl_T <= Val(Shomate(1, 2)) Then
                Cp = CDbl(Shomate(2, 2)) + (dbl_T - CDbl(Shomate(2, 1))) * (CDbl(Shomate(1, 2)) - CDbl(Shomate(2, 2))) / (CDbl(Shomate(1, 1)) - CDbl(Shomate(1, 2)))
            Else
                Cp = CDbl(Shomate(i - 1, 1)) + (dbl_T - CDbl(Shomate(i - 1, 2))) * (CDbl(Shomate(i - 1, 1)) - CDbl(Shomate(i, 1))) / (CDbl(Shomate(i - 1, 2)) - CDbl(Shomate(i, 2)))
            End If
            'Else
            '    Exit Function
            'End If
        Else
            m = 1
            While dbl_T > CDbl(Shomate(m + 1, 2))
                m = m + 1
            End While
            Cp = CDbl(Shomate(m, 1)) + (dbl_T - CDbl(Shomate(m, 2))) * (CDbl(Shomate(m + 1, 1)) - CDbl(Shomate(m, 1))) / (CDbl(Shomate(m + 1, 2)) - CDbl(Shomate(m, 2)))
        End If
        Return Cp
    End Function
    Sub ClearAntione()  '���Antione����
        Dim i As Short
        Dim j As Short
        For i = 1 To 10 Step 1
            For j = 1 To 20 Step 1
                Antoine(i, j) = ""
            Next j
        Next i
    End Sub
    Private Function ChangeAntoine(ByVal GasK As String, ByVal dbl_T As Double) As Double '��Antione���ݼ���������,������������¶ȼ�������ѹ

        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short
        Dim strM As String
        GasK = GasK & " " '���ַ����������һ���ո��Է������ļ���
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearAntione() '�������
        While nEnd <= nLen - 1 Or nLen <= 0
            '�����ݼ����б���
            nEnd = InStr(nStart, GasK, " ")
            nEnter = InStr(nStartCol, GasK, Chr(13))
            If nEnd > nEnter And nEnter > 0 Then
                strM = Mid(GasK, nStart, nEnter - nStart)
                Antoine(i, j) = strM
                i = i + 1
                j = 1
                nStartCol = nEnter + 1
                nStart = nEnter + 1
            End If
            If nEnd - nStart > 0 Then
                strM = Mid(GasK, nStart, nEnd - nStart)
                Antoine(i, j) = strM
                j = j + 1
            End If
            nStart = nEnd + 1
        End While
        '���������е�����������ѹ
        Dim p As Double
        Dim a, b As Double
        Dim c As Double
        Dim t As Double
        t = dbl_T


        Dim Tem As String '���ݿ��е��¶ȷ�Χ
        If dbl_T >= Val(Antoine(1, 1)) And dbl_T <= Val(Antoine(1, 3)) Then
            a = Val(Antoine(1, 4))
            b = Val(Antoine(1, 5))
            c = Val(Antoine(1, 6))

        ElseIf dbl_T >= Val(Antoine(2, 1)) And dbl_T <= Val(Antoine(2, 3)) Then
            a = Val(Antoine(2, 4))
            b = Val(Antoine(2, 5))
            c = Val(Antoine(2, 6))

        Else
            Tem = Antoine(1, 1) & Antoine(1, 2) & Antoine(1, 3) & Antoine(2, 1) & Antoine(2, 2) & Antoine(2, 3)
            'msg = MsgBox("���ݿ���û������������¶ȷ�Χ������ѹ���ݣ����ݿ���¶����ݷ�ΧΪ" & Tem & "K��ϵͳ���Ը�����������¶ȹ������ʵ�����ѹ��������¶�ƫ�뷶Χ�ϴ�(>50K)���벻Ҫ���й��㡣ȷ��Ҫ����Ľ����", 4 + 32)
            'If msg = MsgBoxResult.Yes Then
            If dbl_T <= Val(Antoine(1, 1)) Or Antoine(2, 1) = "" Then
                a = Val(Antoine(1, 4))
                b = Val(Antoine(1, 5))
                c = Val(Antoine(1, 6))
            Else
                a = Val(Antoine(2, 4))
                b = Val(Antoine(2, 5))
                c = Val(Antoine(2, 6))
            End If
            '    Else
            '    Exit Function
            'End If
        End If
        p = (10 ^ (a - (b / (t + c)))) * 100000
        ChangeAntoine = CDbl(FormatNumber(p, 2))
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#Region "���ݿ������صĺ���"
    Private conADO As ADODB.Connection
    Private strSQL As String


    Private Function DataSource() As String
        'Database is located in same dir as app

        If My.Application.Info.DirectoryPath = "\" Then
            DataSource = My.Application.Info.DirectoryPath & "Data.txt"
        Else
            DataSource = My.Application.Info.DirectoryPath & "\" & "Data.txt"
        End If

    End Function

    Private Sub Data_Connect()
        'Open database connection to Access 2000 datasource

        strSQL = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source = " & DataSource()

        conADO = New ADODB.Connection
        conADO.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        conADO.Open(strSQL)

    End Sub
    Private Sub data_Colse()
        conADO.Close()
        'UPGRADE_NOTE: �ڶԶ��� conADO ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
        conADO = Nothing

    End Sub
#End Region

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub
End Class
