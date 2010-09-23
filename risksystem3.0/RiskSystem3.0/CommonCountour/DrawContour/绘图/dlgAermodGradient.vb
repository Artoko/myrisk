Imports System.Windows.Forms

Public Class dlgAermodGradient
    Private m_A() As Double
    ''' <summary>
    ''' 数组用于储存等值线值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property A() As Double()
        Get
            Return m_A
        End Get
        Set(ByVal value As Double())
            m_A = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ReDim m_A(-1)
        If RadioButtonGrade.Checked = True Then
            '判断是否是合法
            If Me.txtGradMax.Value - txtGradMix.Value < 0 Then
                MessageBox.Show("最大值应大于最小值!请调整。")
                Exit Sub
            End If
        Else
            '先检查数据格式
            Dim nEnd As Integer = 0
            Dim nstart As Integer = 0
            Try
                While nstart < txtCustom.Text.Length - 1
                    nEnd = txtCustom.Text.IndexOf(",", nstart)
                    If nEnd > 1 Then
                        Dim dlbA As Double = txtCustom.Text.Substring(nstart, nEnd - nstart)
                        ReDim Preserve m_A(m_A.Length)
                        m_A(m_A.Length - 1) = dlbA
                        nstart = nEnd + 1
                    Else
                        If nstart > 1 And nstart < txtCustom.Text.Length - 1 Then
                            Dim dlbA As Double = txtCustom.Text.Substring(nstart, txtCustom.Text.Length - nstart)
                            ReDim Preserve m_A(m_A.Length)
                            m_A(m_A.Length - 1) = dlbA
                        End If
                        Exit While
                    End If
                End While
            Catch ex As Exception
                MessageBox.Show("输入的格式错误，请重新输入。自定义数据之间用逗号分开。如：0.01,0.02,0.04")
                Exit Sub
            End Try
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgAermodGradient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_A.Length > 0 Then
            txtCustom.Text = m_A(0)
        End If
        For i As Integer = 1 To m_A.Length - 1
            txtCustom.Text = txtCustom.Text & "," & ActivePaintForm.ContourPaintSetting.ContourPannel.Contours.ArrayContourValue(i)
        Next
    End Sub
End Class
