Public Class frmOutOption
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
    Private Sub frmNewOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbGroundCharacter.Text = Me.m_Dis.Forecast.OutPut.GroundCharacter
        txtForeStart.Value = Me.m_Dis.Forecast.OutPut.ForeStart
        txtForeInterval.Value = Me.m_Dis.Forecast.OutPut.ForeInterval
        txtForeCount.Value = Me.m_Dis.Forecast.OutPut.ForeCount

        '滑移平均最大浓度时间。改为有毒物质吸入时间
        chkSlip.Checked = Me.m_Dis.Forecast.OutPut.IsSlipChecked
        txtInhalationTime.Value = Me.m_Dis.Forecast.OutPut.InhalationTime

        '取样时间
        txtSamplingTime.Value = Me.m_Dis.Forecast.OutPut.SamplingTime
        '模型
        cmbModel.SelectedIndex = Me.m_Dis.Forecast.OutPut.GaussModelType
        txtIntervalTime.Value = Me.m_Dis.Forecast.OutPut.IntervalTime
        chkInstantaneous.Checked = Me.m_Dis.Forecast.OutPut.IsInstantaneous '瞬时浓度
        cmbModel_SelectedIndexChanged(sender, e)
        chkInstantaneous_CheckedChanged(sender, e)
        Me.chkCharge.Checked = Me.m_Dis.Forecast.OutPut.IsCharge '毒性负荷法
    End Sub

    Private Sub txtForeStart_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtForeStart.Validating
        Me.m_Dis.Forecast.OutPut.ForeStart = txtForeStart.Value

    End Sub

    Private Sub txtForeInterval_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtForeInterval.Validating
        Me.m_Dis.Forecast.OutPut.ForeInterval = txtForeInterval.Value

    End Sub

    Private Sub txtForeCount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtForeCount.Validating
        Me.m_Dis.Forecast.OutPut.ForeCount = txtForeCount.Value

    End Sub

    Private Sub txtSamplingTime_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSamplingTime.Validating
        Me.m_Dis.Forecast.OutPut.SamplingTime = txtSamplingTime.Value
    End Sub

    Private Sub cmbGroundCharacter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroundCharacter.SelectedIndexChanged
        Me.m_Dis.Forecast.OutPut.GroundCharacter = cmbGroundCharacter.Text
    End Sub

    Private Sub cmbModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModel.SelectedIndexChanged
        If cmbModel.SelectedIndex = 0 Then
            LabelIntervalTime.Visible = True
            txtIntervalTime.Visible = True
        Else
            LabelIntervalTime.Visible = False
            txtIntervalTime.Visible = False
        End If
        Me.m_Dis.Forecast.OutPut.GaussModelType = cmbModel.SelectedIndex
    End Sub

    Private Sub txtIntervalTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIntervalTime.Validating
        Me.m_Dis.Forecast.OutPut.IntervalTime = txtIntervalTime.Value
    End Sub

    Private Sub txtInhalationTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInhalationTime.Validating
        Me.m_Dis.Forecast.OutPut.InhalationTime = txtInhalationTime.Value
    End Sub

    Private Sub chkSlip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSlip.CheckedChanged
        txtInhalationTime.Enabled = chkSlip.Checked
        Me.m_Dis.Forecast.OutPut.IsSlipChecked = chkSlip.Checked
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub txtIntervalTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIntervalTime.TextChanged

    End Sub

    Private Sub chkInstantaneous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInstantaneous.CheckedChanged
        Me.m_Dis.Forecast.OutPut.IsInstantaneous = chkInstantaneous.Checked
        txtForeStart.Enabled = chkInstantaneous.Checked
        txtForeInterval.Enabled = chkInstantaneous.Checked
        txtForeCount.Enabled = chkInstantaneous.Checked
    End Sub

    
    Private Sub chkCharge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCharge.CheckedChanged
        Me.m_Dis.Forecast.OutPut.IsCharge = Me.chkCharge.Checked
    End Sub
End Class