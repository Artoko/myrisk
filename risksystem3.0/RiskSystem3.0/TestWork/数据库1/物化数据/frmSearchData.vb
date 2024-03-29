Imports System.Windows.Forms
Imports System.Data
Public Class frmSearchData
    Private rstUserList As ADODB.Recordset
    Private strUserName3, strUserName1, strUserName2, strUserName4 As String
    Private strUserName0 As String
    Dim Shomate(100, 100) As String '用来放热容数据
    Dim Antoine(10, 20) As String '用来放蒸气压的Antoine常数

    Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click '查找并列表数据
        '如果用户没有输入，则不查找
        If txtName.Text = "" Then
            MsgBox("请输入要查找的内容")
            Exit Sub
        End If
        '在列表中显示
        ListView1.Items.Clear() '清空列表


        Call Data_Connect() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集

        strSQL = SQLCondiction() '根据用户选择确定查询条件
        rstUserList.Open(strSQL, conADO) '打开记录集
        Dim nListIndex As Short
        nListIndex = 1
        Do Until rstUserList.EOF = True  '加入列表框
            '如果相应的数据为NULL，则为""

            If IsDBNull(rstUserList.Fields("中文名1").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("中文名1").Value
            End If
            If IsDBNull(rstUserList.Fields("中文名2").Value) Then
                strUserName1 = ""
            Else
                strUserName1 = rstUserList.Fields("中文名2").Value
            End If
            If IsDBNull(rstUserList.Fields("英文名1").Value) Then
                strUserName2 = ""
            Else
                strUserName2 = rstUserList.Fields("英文名1").Value
            End If
            If IsDBNull(rstUserList.Fields("英文名2").Value) Then
                strUserName3 = ""
            Else
                strUserName3 = rstUserList.Fields("英文名2").Value
            End If
            If IsDBNull(rstUserList.Fields("CAS").Value) Then
                strUserName4 = ""
            Else
                strUserName4 = rstUserList.Fields("CAS").Value
            End If
            '查询结果加入表中
            ListView1.Items.Add(strUserName0, 0)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName1)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName2)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName3)
            ListView1.Items(nListIndex - 1).SubItems.Add(strUserName4)
            nListIndex = nListIndex + 1
            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        data_Colse() '断开数据库

        If ListView1.Items.Count < 1 Then
            MsgBox("数据库中没有您要查找的物质，请放宽查询条件!如要查找‘二甲醚’，输入‘甲醚’或‘醚’。")
        End If
    End Sub


    Private Sub frmSearchData_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cmbSearchType.SelectedIndex = 0
        '初始化表格
    End Sub
    Private Function SQLCondiction() As String
        Dim strName As String
        Dim strSQLCondiction As String
        strSQLCondiction = txtName.Text
        '如果字符串中含有单引号，应转换
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
                SQLCondiction = "SELECT * FROM NIST where 中文名1 like '%" & strName & "%' or " & "中文名2 like '%" & strName & "%'"
            Case 1
                SQLCondiction = "SELECT * FROM NIST where 英文名1 like '%" & strName & "%' or " & "英文名2 like '%" & strName & "%'"
            Case 2
                SQLCondiction = "SELECT * FROM NIST where CAS = '" & strName & "'"

            Case Else
                SQLCondiction = ""
                MsgBox("查询条件错误，请重新选择！")
        End Select
    End Function

    Private Function SQLCondictionResult() As String
        Dim strName As String
        Dim strSQLCondiction As String
        strSQLCondiction = ListView1.FocusedItem.Text
        '如果字符串中含有单引号，应转换
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

        SQLCondictionResult = "SELECT * FROM NIST where 中文名1 = '" & strName & "'"
    End Function

    Private Sub ListView1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ListView1.Click
        Dim Hv As Double
        Dim Hc As Double
        Dim HCP As Double
        Dim dblGasK As Double
        Dim strGasK As String
        Dim dblP As Double
        Dim strAntoine As String '蒸气压
        If ListView1.Items.Count <> 0 Then
            Call Data_Connect() '连接数据库
            rstUserList = New ADODB.Recordset '设置记录集
            strSQL = SQLCondictionResult() '根据用户选择确定查询条件
            rstUserList.Open(strSQL, conADO) '打开记录集
            '如果相应的数据为NULL，则为""
            If IsDBNull(rstUserList.Fields("中文名1").Value) Then
                txtChineseName1.Text = ""
            Else
                txtChineseName1.Text = rstUserList.Fields("中文名1").Value
            End If
            If IsDBNull(rstUserList.Fields("中文名2").Value) Then
                txtChineseName2.Text = ""
            Else
                txtChineseName2.Text = rstUserList.Fields("中文名2").Value
            End If
            If IsDBNull(rstUserList.Fields("英文名1").Value) Then
                txtEnglishName1.Text = ""
            Else
                txtEnglishName1.Text = rstUserList.Fields("英文名1").Value
            End If
            If IsDBNull(rstUserList.Fields("英文名2").Value) Then
                txtEnglishName2.Text = ""
            Else
                txtEnglishName2.Text = rstUserList.Fields("英文名2").Value
            End If
            If IsDBNull(rstUserList.Fields("CAS").Value) Then
                txtCAS.Text = ""
            Else
                txtCAS.Text = rstUserList.Fields("CAS").Value
            End If
            '以下根据需要查找的情况查找相应的数据----------------------------------------
            '摩尔质量
            If IsDBNull(rstUserList.Fields("分子量").Value) Then
                txtM.Text = ""
            Else
                txtM.Text = CStr(Val(rstUserList.Fields("分子量").Value) * 0.001)
            End If
            '液体密度
            If txtPl.Visible = True Then
                If IsDBNull(rstUserList.Fields("相对密度水").Value) Then
                    txtPl.Text = ""
                Else
                    txtPl.Text = CStr(Val(rstUserList.Fields("相对密度水").Value)) * 1000
                End If
            End If
            '蒸汽密度
            If txtPg.Visible = True Then
                If IsDBNull(rstUserList.Fields("相对密度空气").Value) Then
                    txtPg.Text = ""
                Else
                    txtPg.Text = CStr(1.293 * Val(rstUserList.Fields("相对密度空气").Value))
                    If CDbl(txtPg.Text) = 0 Then
                        txtPg.Text = ""
                    End If
                End If
            End If
            '沸点
            If txtTb.Visible = True Then
                If IsDBNull(rstUserList.Fields("沸点").Value) Then
                    txtTb.Text = ""
                Else
                    txtTb.Text = CStr(Val(rstUserList.Fields("沸点").Value))
                End If
            End If
            '气化热，单位从KJ/mol转化成J/kg
            If txtH.Visible = True Then
                If IsDBNull(rstUserList.Fields("Hvap").Value) Then
                    txtH.Text = ""
                Else
                    Hv = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("Hvap").Value) * 1000, 1))
                    txtH.Text = CStr(Hv)
                End If
            End If
            '燃烧热，单位从KJ/mol转化成J/kg
            If txtHc.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("Hcliqud").Value) Then

                    Hc = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("Hcliqud").Value) * 1000, 1))
                    txtHc.Text = CStr(Hc)
                ElseIf Not (IsDBNull(rstUserList.Fields("燃烧热").Value) Or rstUserList.Fields("燃烧热").Value = "无资料" Or rstUserList.Fields("燃烧热").Value = "无意义") Then
                    Hc = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("燃烧热").Value) * 1000, 1))
                    txtHc.Text = CStr(Hc)
                ElseIf Not IsDBNull(rstUserList.Fields("Hcgas").Value) Then
                    Hc = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("Hcgas").Value) * 1000, 1))
                    txtHc.Text = CStr(Hc)
                Else
                    txtHc.Text = ""
                End If
            End If
            '液体定压比热，从J/mol转化成J/kg
            If txtCP.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("CpLiquid").Value) Then

                    HCP = CDbl(FormatNumber(1.0# / CDbl(txtM.Text) * Val(rstUserList.Fields("CpLiquid").Value), 1))
                    txtCP.Text = CStr(HCP)
                Else
                    txtCP.Text = ""
                End If
            End If
            '气体定压比热, 从J / mol转化成J / kg
            If txtGasCp.Visible = True Then
                Dim strCp As String = ""
                Dim dblCp As Double = 0
                If Not IsDBNull(rstUserList.Fields("Shomate Equation").Value) Then
                    strCp = rstUserList.Fields("Shomate Equation").Value
                    dblCp = ChangeShomateToCp(strCp, CDbl(txtInT.Text) + FreezingPoint) '将数据加入数组,并计算相应的气体绝热系数
                    txtGasCp.Text = FormatNumber(dblCp / CDbl(txtM.Text), 0, TriState.True, TriState.False, TriState.False) '转换成J/kg
                ElseIf Not IsDBNull(rstUserList.Fields("CpGas").Value) Then
                    strCp = rstUserList.Fields("CpGas").Value
                    dblCp = ChangeCpGasToCp(strCp, CDbl(txtInT.Text) + FreezingPoint) '将数据加入数组,并计算相应的气体绝热系数
                    txtGasCp.Text = FormatNumber(dblCp / CDbl(txtM.Text), 0, TriState.True, TriState.False, TriState.False) '转换成J/kg
                Else
                    txtGasCp.Text = ""
                End If
            End If
            '气体绝热指数，先计算气体的等压热容，再+8.314计算气体的等容热容
            If txtGasK.Visible = True Then

                If Not IsDBNull(rstUserList.Fields("Shomate Equation").Value) Then
                    strGasK = rstUserList.Fields("Shomate Equation").Value
                    dblGasK = ChangeShomate(strGasK, CDbl(txtInT.Text) + FreezingPoint) '将数据加入数组,并计算相应的气体绝热系数
                    txtGasK.Text = CStr(dblGasK)
                ElseIf Not IsDBNull(rstUserList.Fields("CpGas").Value) Then
                    strGasK = rstUserList.Fields("CpGas").Value
                    dblGasK = ChangeCpGas(strGasK, CDbl(txtInT.Text) + FreezingPoint) '将数据加入数组,并计算相应的气体绝热系数
                    txtGasK.Text = CStr(dblGasK)
                Else
                    txtGasK.Text = ""
                End If
            End If
            '贮罐内蒸气压，按安托因公式计算
            If txtGasP.Visible = True Then

                If Not IsDBNull(rstUserList.Fields("Antoine").Value) Then
                    strAntoine = rstUserList.Fields("Antoine").Value
                    dblP = ChangeAntoine(strAntoine, CDbl(txtInT.Text) + FreezingPoint) '将数据加入数组
                    txtGasP.Text = CStr(dblP)
                Else
                    txtGasP.Text = ""
                End If
            End If
            '环境蒸气压，按安托因公式计算
            If txtOutGasP.Visible = True Then

                If Not IsDBNull(rstUserList.Fields("Antoine").Value) Then
                    strAntoine = rstUserList.Fields("Antoine").Value
                    dblP = ChangeAntoine(strAntoine, CDbl(txtOutT.Text) + FreezingPoint) '将数据加入数组
                    txtOutGasP.Text = CStr(dblP)
                Else
                    txtOutGasP.Text = ""
                End If
            End If
            '毒性数据
            If txtLC50.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("LC50").Value) Then
                    txtLC50.Text = rstUserList.Fields("LC50").Value
                Else
                    txtLC50.Text = ""
                End If
            End If
            If txtLMax.Visible = True Then
                If Not IsDBNull(rstUserList.Fields("中国").Value) Then
                    txtLMax.Text = rstUserList.Fields("中国").Value
                Else
                    txtLMax.Text = ""
                End If
            End If
           

            rstUserList.Close() '关闭记录集
            rstUserList = Nothing
            data_Colse() '断开数据库
        Else
            MsgBox("列表是空的，请先查找后再单击列表，以确定查找的物质!")
        End If
    End Sub

    Private Sub txtName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Then '如果用户回车则开始查找
            cmdSearch_Click(cmdSearch, New System.EventArgs())
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Function ChangeShomate(ByVal GasK As String, ByVal dbl_T As Double) As Double '将热容数据加入数组中,并根据输入的温度计算绝热指数

        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short

        Dim strM As String
        GasK = GasK & " " '在字符串最后增加一个空格，以方便后面的计算
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '清空数据
        While nEnd <= nLen - 1 Or nLen <= 0
            '将数据加入列表中
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
        '根据数据中的数计算气体热容和绝热指数
        Dim Cp As Double
        Dim c, a, b, D As Double
        Dim E As Double


        Dim Tem As String '数据库中的温度范围
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
            'msg = MsgBox("数据库中没有您所输入的温度范围的气体绝热指数数据，数据库的温度数据范围为" & Tem & "K，系统可以根据您输入的温度估算气体绝热指数，但如果温度偏离范围较大(>50K)，请不要进行估算。确定要估算的结果吗？", 4 + 32)
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

    Private Function ChangeShomateToCp(ByVal GasK As String, ByVal dbl_T As Double) As Double '将热容数据加入数组中,并根据输入的温度计算绝热指数

        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short

        Dim strM As String
        GasK = GasK & " " '在字符串最后增加一个空格，以方便后面的计算
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '清空数据
        While nEnd <= nLen - 1 Or nLen <= 0
            '将数据加入列表中
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
        '根据数据中的数计算气体热容和绝热指数
        Dim Cp As Double
        Dim c, a, b, D As Double
        Dim E As Double


        Dim Tem As String '数据库中的温度范围
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
            'msg = MsgBox("数据库中没有您所输入的温度范围的气体绝热指数数据，数据库的温度数据范围为" & Tem & "K，系统可以根据您输入的温度估算气体绝热指数，但如果温度偏离范围较大(>50K)，请不要进行估算。确定要估算的结果吗？", 4 + 32)
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

    Sub ClearShomate()  '清空数组
        Dim i As Short
        Dim j As Short
        For i = 1 To 100 Step 1
            For j = 1 To 100 Step 1
                Shomate(i, j) = ""
            Next j
        Next i
    End Sub
    Private Function ChangeCpGas(ByVal GasK As String, ByVal dbl_T As Double) As Double '将热容数据加入数组中,并根据输入的温度计算绝热指数
        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short
        Dim strM As String
        GasK = GasK & " " '在字符串最后增加一个空格，以方便后面的计算
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '清空数据
        While nEnd <= nLen - 1 Or nLen <= 0
            '将数据加入列表中
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
        '根据数据中的数计算气体热容和绝热指数
        Dim Cp As Double
        Dim m As Short
        Dim Tem As String '数据库中的温度范围
        If dbl_T < CDbl(Shomate(1, 2)) Or dbl_T > CDbl(Shomate(i, 2)) Then
            Tem = Shomate(1, 2) & " - " & Shomate(i, 2)
            'msg = MsgBox("数据库中没有您所输入的温度范围的气体绝热指数数据，数据库的温度数据范围为" & Tem & "K，系统可以根据您输入的温度估算气体绝热指数，但如果温度偏离范围较大(>50K)，请不要进行估算。确定要估算的结果吗？", 4 + 32)
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
    Private Function ChangeCpGasToCp(ByVal GasK As String, ByVal dbl_T As Double) As Double '将热容数据加入数组中,并根据输入的温度计算绝热指数
        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short
        Dim strM As String
        GasK = GasK & " " '在字符串最后增加一个空格，以方便后面的计算
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearShomate() '清空数据
        While nEnd <= nLen - 1 Or nLen <= 0
            '将数据加入列表中
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
        '根据数据中的数计算气体热容和绝热指数
        Dim Cp As Double
        Dim m As Short
        Dim Tem As String '数据库中的温度范围
        If dbl_T < CDbl(Shomate(1, 2)) Or dbl_T > CDbl(Shomate(i, 2)) Then
            Tem = Shomate(1, 2) & " - " & Shomate(i, 2)
            'msg = MsgBox("数据库中没有您所输入的温度范围的气体绝热指数数据，数据库的温度数据范围为" & Tem & "K，系统可以根据您输入的温度估算气体绝热指数，但如果温度偏离范围较大(>50K)，请不要进行估算。确定要估算的结果吗？", 4 + 32)
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
    Sub ClearAntione()  '清空Antione数组
        Dim i As Short
        Dim j As Short
        For i = 1 To 10 Step 1
            For j = 1 To 20 Step 1
                Antoine(i, j) = ""
            Next j
        Next i
    End Sub
    Private Function ChangeAntoine(ByVal GasK As String, ByVal dbl_T As Double) As Double '将Antione数据加入数组中,并根据输入的温度计算蒸气压

        Dim nEnd, nStart, nEnter As Short
        Dim nStartCol As Short
        Dim nLen As Short
        Dim i As Short
        Dim j As Short
        Dim strM As String
        GasK = GasK & " " '在字符串最后增加一个空格，以方便后面的计算
        i = 1
        j = 1
        nLen = Len(GasK)
        nStart = 1
        nStartCol = 1
        nEnd = 0
        ClearAntione() '清空数据
        While nEnd <= nLen - 1 Or nLen <= 0
            '将数据加入列表中
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
        '根据数据中的数计算蒸气压
        Dim p As Double
        Dim a, b As Double
        Dim c As Double
        Dim t As Double
        t = dbl_T


        Dim Tem As String '数据库中的温度范围
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
            'msg = MsgBox("数据库中没有您所输入的温度范围的蒸气压数据，数据库的温度数据范围为" & Tem & "K，系统可以根据您输入的温度估算物质的蒸气压，但如果温度偏离范围较大(>50K)，请不要进行估算。确定要估算的结果吗？", 4 + 32)
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

#Region "数据库查找相关的函数"
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
        'UPGRADE_NOTE: 在对对象 conADO 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        conADO = Nothing

    End Sub
#End Region

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub
End Class
