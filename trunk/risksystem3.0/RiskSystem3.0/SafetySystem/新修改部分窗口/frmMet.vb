Public Class frmMet
    Protected m_Dis As New DisPuff.Dis
    ''' <summary>
    ''' 泄漏预测对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Dis() As DisPuff.Dis
        Get
            Return Me.m_Dis
        End Get
        Set(ByVal value As DisPuff.Dis)
            Me.m_Dis = value
        End Set
    End Property
    Private Sub frmMet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshEFlexMet()
        txtTa.Value = Me.m_Dis.Forecast.Ta
        txtPa.Value = Me.m_Dis.Forecast.Pa
    End Sub
    Private Sub EFlexMet_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexMet.Validating
        Dim nCount As Integer = EFlexMet.Rows.Count - 1
        ReDim Me.m_Dis.Forecast.Met(nCount - 1)
        For i As Integer = 0 To nCount - 1
            Me.m_Dis.Forecast.Met(i) = New DisPuff.Met
            Me.m_Dis.Forecast.Met(i).Vane = Me.EFlexMet.GetData(i + 1, 1) '风向
            Me.m_Dis.Forecast.Met(i).WindSpeed = Me.EFlexMet.GetData(i + 1, 2) '风速
            Me.m_Dis.Forecast.Met(i).Stab = Me.EFlexMet.GetData(i + 1, 3) '稳定度
            Me.m_Dis.Forecast.Met(i).Frequency = Me.EFlexMet.GetData(i + 1, 4) '频率
        Next
    End Sub

    Private Sub cmdAddMet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMet.Click
        ReDim Preserve Me.m_Dis.Forecast.Met(Me.m_Dis.Forecast.Met.Length) '数组长度加1
        Me.m_Dis.Forecast.Met(Me.m_Dis.Forecast.Met.Length - 1) = New DisPuff.Met
        RefreshEFlexMet()
    End Sub

    Private Sub cmdDelMet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelMet.Click
        Dim index As Integer = Me.EFlexMet.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_Dis.Forecast.Met.Length - 2
                Me.m_Dis.Forecast.Met(i) = Me.m_Dis.Forecast.Met(i + 1)
            Next
            ReDim Preserve Me.m_Dis.Forecast.Met(Me.m_Dis.Forecast.Met.Length - 2)
            RefreshEFlexMet()
        End If
    End Sub

    ''' <summary>
    ''' 用气象条件更新表格
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshEFlexMet()
        Dim nCount As Integer = Me.m_Dis.Forecast.Met.Length
        Me.EFlexMet.Rows.Count = nCount + 1
        For i As Integer = 0 To nCount - 1
            Me.EFlexMet.SetData(i + 1, 0, i + 1)
            Me.EFlexMet.SetData(i + 1, 1, Me.m_Dis.Forecast.Met(i).Vane)
            Me.EFlexMet.SetData(i + 1, 2, Me.m_Dis.Forecast.Met(i).WindSpeed)
            Me.EFlexMet.SetData(i + 1, 3, Me.m_Dis.Forecast.Met(i).Stab)
            Me.EFlexMet.SetData(i + 1, 4, Me.m_Dis.Forecast.Met(i).Frequency)
        Next
    End Sub

    Private Sub txtTa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTa.Validating
        Me.m_Dis.Forecast.Ta = txtTa.Value

    End Sub

    Private Sub txtPa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPa.Validating
        Me.m_Dis.Forecast.Pa = txtPa.Value

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

   
End Class