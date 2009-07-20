Public Class frmVaneDrown
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
    Private Sub RadioVaneType1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioVaneType1.CheckedChanged, RadioVaneType2.CheckedChanged
        If RadioVaneType1.Checked = True Then
            m_Dis.Forecast.Vane.VaneType = 0
            EFlexVan.Enabled = True
            cmdAddVane.Enabled = True
            cmdDelVane.Enabled = True
            txtVaneStep.Enabled = False
            txtVaneDistance.Enabled = False
        Else
            m_Dis.Forecast.Vane.VaneType = 1
            EFlexVan.Enabled = False
            cmdAddVane.Enabled = False
            cmdDelVane.Enabled = False
            txtVaneStep.Enabled = True
            txtVaneDistance.Enabled = True
        End If
    End Sub

    

    Private Sub frmVaneDrown_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_Dis.Forecast.Vane.VaneType = 0 Then
            RadioVaneType1.Checked = True
        Else
            RadioVaneType2.Checked = True
        End If
        RadioVaneType1_CheckedChanged(sender, e)
        txtVaneStep.Value = m_Dis.Forecast.Vane.VaneStep
        txtVaneDistance.Value = m_Dis.Forecast.Vane.VaneDistance
        RefreshEFlexVane()
    End Sub

    Private Sub txtVaneStep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVaneStep.Validating
        m_Dis.Forecast.Vane.VaneStep = txtVaneStep.Value
    End Sub

    Private Sub txtVaneDistance_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVaneDistance.Validating
        m_Dis.Forecast.Vane.VaneDistance = txtVaneDistance.Value
    End Sub

    Private Sub cmdAddVane_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddVane.Click
        ReDim Preserve Me.m_Dis.Forecast.Vane.VaneA(Me.m_Dis.Forecast.Vane.VaneA.Length) '数组长度加1
        RefreshEFlexVane()
    End Sub

    Private Sub cmdDelVane_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelVane.Click
        Dim index As Integer = Me.EFlexVan.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_Dis.Forecast.Vane.VaneA.Length - 2
                Me.m_Dis.Forecast.Vane.VaneA(i) = Me.m_Dis.Forecast.Vane.VaneA(i + 1)
            Next
            ReDim Preserve Me.m_Dis.Forecast.Vane.VaneA(Me.m_Dis.Forecast.Vane.VaneA.Length - 2)
            RefreshEFlexVane()
        End If
    End Sub

    Private Sub EFlexVan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexVan.Validating
        Dim nCount As Integer = EFlexVan.Rows.Count - 1
        ReDim Me.m_Dis.Forecast.Vane.VaneA(nCount - 1)
        For i As Integer = 0 To nCount - 1
            Me.m_Dis.Forecast.Vane.VaneA(i) = Me.EFlexVan.GetData(i + 1, 1) '距离
        Next
    End Sub

    ''' <summary>
    ''' 用气象条件更新表格
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshEFlexVane()
        Dim nCount As Integer = Me.m_Dis.Forecast.Vane.VaneA.Length
        Me.EFlexVan.Rows.Count = nCount + 1
        For i As Integer = 0 To nCount - 1
            Me.EFlexVan.SetData(i + 1, 0, i + 1)
            Me.EFlexVan.SetData(i + 1, 1, Me.m_Dis.Forecast.Vane.VaneA(i))
        Next
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub
End Class