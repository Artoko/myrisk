''' <summary>
''' �ַ���������
''' </summary>
''' <remarks></remarks>
Public Module StringHandle
    Public Function GetStringNumber(ByVal str As String) As Integer
        str = " " & str & " " '���ַ���ǰ�����һ���գ��Ա��ں��洦��
        Dim n As Integer = 0
        Dim n1 As Integer = 0
        Dim n2 As Integer = 0
        If str IsNot Nothing AndAlso str.Length > 2 Then
            While n2 >= 0
                n1 = n2
                n2 = str.IndexOf(" ", n1 + 1)
                If n2 - n1 > 1 Then '������������Ŀո񣬿�ʼ����
                    n = n + 1
                End If
            End While
        End If
        Return n
    End Function
    ''' <summary>
    ''' ȡ�ø���λ�õ��ַ�����������1��ʼ
    ''' </summary>
    ''' <param name="str">�ַ���</param>
    ''' <param name="index">λ��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetString(ByVal str As String, ByVal index As Integer) As String
        str = "  " & str & "  " 'ǰ������������ո��Ա�����ȷ����
        Dim substring As String = ""
        Dim n As Integer = 0
        Dim n1 As Integer = 0
        Dim n2 As Integer = 0
        Try
            For i As Integer = 0 To str.Length - 1
                If str.Substring(i, 1) <> " " Then
                    n1 = i
                    n2 = str.IndexOf(" ", n1)
                    substring = str.Substring(n1, n2 - n1)
                    i = n2
                    n = n + 1
                    If n = index Then
                        Return substring
                        Exit Function
                    End If
                End If
            Next
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' ����Aermod�����н�������������Ϣ
    ''' </summary>
    ''' <param name="AermodName">����ļ�������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAermodError(ByVal AermodName As String)
        Try
            FileOpen(1, AermodName, OpenMode.Input) '���ļ�
            Dim strError As String = ""
            Dim IsError As Boolean = False
            Do Until EOF(1)
                Dim strLine As String = LineInput(1) '��ȡһ��
                If strLine.Contains("FATAL ERROR MESSAGES") Then '�������
                    IsError = True
                End If
                If IsError = True Then
                    If strLine.Contains("WARNING MESSAGES") Or strLine.Contains("SETUP Finishes UN-successfully") Then
                        Exit Do
                    End If
                    strError = strError & strLine & vbCrLf
                End If
            Loop
            FileClose(1) '�ر��ļ�
            Return "������д�����Ϣ���£�" & vbCrLf & strError
        Catch ex As Exception
            Return "�޷���ȡ������Ϣ!"
        Finally
            FileClose(1) '�ر��ļ�
        End Try
        Return "�޷���ȡ������Ϣ!"
    End Function

    ''' <summary>
    ''' ����Aermap�����н�������������Ϣ
    ''' </summary>
    ''' <param name="AermapName">����ļ�������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAermapError(ByVal AermapName As String)
        Try
            FileOpen(1, AermapName, OpenMode.Input) '���ļ�
            Dim strError As String = ""
            Dim IsError As Boolean = False
            Do Until EOF(1)
                Dim strLine As String = LineInput(1) '��ȡһ��
                If strLine.Contains("FATAL ERROR MESSAGES") Then '�������
                    IsError = True
                End If
                If IsError = True Then
                    If strLine.Contains("WARNING MESSAGES") Or strLine.Contains("SETUP Finishes UN-successfully") Then
                        Exit Do
                    End If
                    strError = strError & strLine & vbCrLf
                End If
            Loop
            FileClose(1) '�ر��ļ�
            Return "������д�����Ϣ���£�" & vbCrLf & strError
        Catch ex As Exception
            Return "�޷���ȡ������Ϣ!"
        Finally
            FileClose(1) '�ر��ļ�
        End Try
        Return "�޷���ȡ������Ϣ!"
    End Function
End Module
