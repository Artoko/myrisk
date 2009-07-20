Public Class frmLeakSource
    Private m_Dis As New DisPuff.Dis
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
    Private Sub frmLeakSource_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbLeakType.SelectedIndex = Me.m_Dis.IntialSource.LeakType '泄漏类型
        txtLeakSourceName.Text = Me.m_Dis.IntialSource.LeakSourceName  '泄漏源名称
        txtX.Value = Me.m_Dis.IntialSource.Coordinate.x
        txtY.Value = Me.m_Dis.IntialSource.Coordinate.y
        txtQ.Value = Me.m_Dis.IntialSource.Q
        txtInT.Value = Me.m_Dis.IntialSource.InT
        txtLeakGasP.Value = Me.m_Dis.IntialSource.LeakGasP
        txtLeakGasA.Value = Me.m_Dis.IntialSource.LeakGasA
        txtH.Value = Me.m_Dis.IntialSource.H
        txtLeakLiquidHeight.Value = Me.m_Dis.IntialSource.LeakLiquidHeight
        txtDurationT.Value = Me.m_Dis.IntialSource.DurationT
        txtLeakLiquidCd.Value = Me.m_Dis.IntialSource.LeakLiquidCd
        cmbLeakEvaporationGround.SelectedIndex = Me.m_Dis.IntialSource.LeakEvaporationGround
        txtS.Value = Me.m_Dis.IntialSource.S
        txtS_S.Value = Me.m_Dis.IntialSource.S_S
        txtVolatilizationT.Value = Me.m_Dis.IntialSource.VolatilizationT
        txtSHe.Value = Me.m_Dis.IntialSource.H
        cbmSourceType.SelectedIndex = Me.m_Dis.IntialSource.SourceType
        txtQ0.Value = Me.m_Dis.IntialSource.Q0
        txtThickness.Value = Me.m_Dis.IntialSource.Thickness
        cmbLeakGasShape.SelectedIndex = Me.m_Dis.IntialSource.LeakGasShape
        txtAngle.Value = Me.m_Dis.IntialSource.Angle
        txtLeakTwoCd.Value = Me.m_Dis.IntialSource.LeakTwoCd
        txtLeakLiquidCd.Value = Me.m_Dis.IntialSource.LeakLiquidCd

        chkAutoCalLeakP.Checked = Me.m_Dis.IntialSource.chkLeakGasP
        chkAutoCalVapP.Checked = Me.m_Dis.IntialSource.chkVap
        txtLeakEvaporationP.Value = Me.m_Dis.IntialSource.LeakEvaporationP
        cmbLeakType_SelectedIndexChanged(sender, e)
        chkIsHeavy.Checked = Me.m_Dis.IntialSource.IsHeavy
        txtAirProportion.Enabled = chkIsHeavy.Checked
        txtAirProportion.Value = Me.m_Dis.IntialSource.AirProportion

        txtProbability.Value = Me.m_Dis.IntialSource.Probability

    End Sub
    Private Sub txtLeakSourceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        Me.m_Dis.IntialSource.LeakSourceName = txtLeakSourceName.Text   '泄漏源名称
    End Sub

    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        Me.m_Dis.IntialSource.Coordinate.x = txtX.Value
    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        Me.m_Dis.IntialSource.Coordinate.y = txtY.Value
    End Sub

    Private Sub txtQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ.Validating
        Me.m_Dis.IntialSource.Q = txtQ.Value
    End Sub

    Private Sub txtInT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInT.Validating
        Me.m_Dis.IntialSource.InT = txtInT.Value
    End Sub

    Private Sub txtLeakGasP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP.Validating
        Me.m_Dis.IntialSource.LeakGasP = txtLeakGasP.Value

    End Sub

    Private Sub txtLeakGasA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasA.Validating
        Me.m_Dis.IntialSource.LeakGasA = txtLeakGasA.Value
    End Sub

    Private Sub txtH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtH.Validating
        Me.m_Dis.IntialSource.H = txtH.Value
    End Sub

    Private Sub cmbLeakGasShape_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLeakGasShape.SelectedIndexChanged
        Me.m_Dis.IntialSource.LeakGasShape = cmbLeakGasShape.SelectedIndex

    End Sub

    Private Sub txtAngle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAngle.Validating
        Me.m_Dis.IntialSource.Angle = txtAngle.Value
    End Sub
    Private Sub txtDurationT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDurationT.Validating
        Me.m_Dis.IntialSource.DurationT = txtDurationT.Value
    End Sub
    Private Sub txtLeakLiquidHeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidHeight.Validating
        Me.m_Dis.IntialSource.LeakLiquidHeight = txtLeakLiquidHeight.Value
    End Sub

    Private Sub txtLeakLiquidCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCd.Validating
        Me.m_Dis.IntialSource.LeakLiquidCd = txtLeakLiquidCd.Value
    End Sub


    Private Sub cmbLeakEvaporationGround_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLeakEvaporationGround.SelectedIndexChanged
        Me.m_Dis.IntialSource.LeakEvaporationGround = cmbLeakEvaporationGround.SelectedIndex
    End Sub

    Private Sub txtS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS.TextChanged

    End Sub

    Private Sub txtS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS.Validating
        Me.m_Dis.IntialSource.S = txtS.Value
    End Sub

    Private Sub txtVolatilizationT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVolatilizationT.TextChanged

    End Sub

    Private Sub txtVolatilizationT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVolatilizationT.Validating
        Me.m_Dis.IntialSource.VolatilizationT = txtVolatilizationT.Value
    End Sub

    Private Sub txtSHe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSHe.TextChanged

    End Sub

    Private Sub txtSHe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSHe.Validating
        Me.m_Dis.IntialSource.SHe = txtSHe.Value
    End Sub
    Private Sub txtQ0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ0.Validating
        Me.m_Dis.IntialSource.Q0 = txtQ0.Value

    End Sub

    Private Sub txtS_S_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS_S.Validating
        Me.m_Dis.IntialSource.S_S = txtS_S.Value
    End Sub

    Private Sub txtThickness_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtThickness.Validating
        Me.m_Dis.IntialSource.Thickness = txtThickness.Value
    End Sub

    Private Sub txtLeakTwoCd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoCd.Validating
        Me.m_Dis.IntialSource.LeakTwoCd = txtLeakTwoCd.Value
    End Sub

    Private Sub cbmSourceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbmSourceType.SelectedIndexChanged
        '根据泄漏源的类型，显示不同的参数
        If Me.cbmSourceType.SelectedIndex >= 0 Then
            Me.m_Dis.IntialSource.SourceType = Me.cbmSourceType.SelectedIndex
        End If
        Select Case cbmSourceType.SelectedIndex
            Case 0 '点源
                txtQ0.Enabled = cbmSourceType.Enabled
                txtS_S.Enabled = False
                txtThickness.Enabled = False
            Case 1 '面源
                txtQ0.Enabled = False
                txtS_S.Enabled = cbmSourceType.Enabled
                txtThickness.Enabled = False

                txtS_S.Value = Me.m_Dis.IntialSource.S_S
                LabelS.Text = "面源面积S[m^2]:"
            Case 2 '体源
                txtQ0.Enabled = False
                txtS_S.Enabled = cbmSourceType.Enabled
                txtThickness.Enabled = cbmSourceType.Enabled
                txtS_S.Value = Me.m_Dis.IntialSource.S_S
                LabelS.Text = "体源面积S[m^2]:"

        End Select
    End Sub

    Private Sub m_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_OK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub m_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub cmbLeakType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLeakType.SelectedIndexChanged
        If cmbLeakType.SelectedIndex >= 0 Then
            Me.m_Dis.IntialSource.LeakType = cmbLeakType.SelectedIndex
        End If
        Select Case cmbLeakType.SelectedIndex
            Case 0 '(1)自定义泄漏源

                txtQ.Enabled = False
                txtInT.Enabled = False
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = False
                txtH.Enabled = False
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = True
                txtQ0.Enabled = True
                txtS_S.Enabled = True
                txtThickness.Enabled = True
                cmbLeakEvaporationGround.Enabled = False
                txtS.Enabled = False
                txtVolatilizationT.Enabled = False
                txtSHe.Enabled = False
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 1 '(2)气体容器小孔、中孔泄漏、
                txtQ.Enabled = True
                txtInT.Enabled = True
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = True
                txtLeakGasA.Enabled = True
                txtH.Enabled = True
                cmbLeakGasShape.Enabled = True
                txtAngle.Enabled = True
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = False
                txtS.Enabled = False
                txtVolatilizationT.Enabled = False
                txtSHe.Enabled = False
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False


            Case 2 '(3)气体容器爆裂
                txtQ.Enabled = True
                txtInT.Enabled = False
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = False
                txtH.Enabled = True
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = False
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = False
                txtS.Enabled = False
                txtVolatilizationT.Enabled = False
                txtSHe.Enabled = False
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 3 '(4)压力液化气容器液下小孔、中孔泄漏
                txtQ.Enabled = True
                txtInT.Enabled = True
                Me.chkAutoCalLeakP.Enabled = True
                If Me.chkAutoCalLeakP.Checked = True Then
                    txtLeakGasP.Enabled = False
                Else
                    txtLeakGasP.Enabled = True
                End If
                txtLeakGasA.Enabled = True
                txtH.Enabled = True
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = True
                txtLeakLiquidCd.Enabled = True
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 4 '(5)压力液化气容器液上小孔、中孔泄漏
                txtQ.Enabled = True
                txtInT.Enabled = True
                Me.chkAutoCalLeakP.Enabled = True
                If Me.chkAutoCalLeakP.Checked = True Then
                    txtLeakGasP.Enabled = False
                Else
                    txtLeakGasP.Enabled = True
                End If
                txtLeakGasA.Enabled = True
                txtH.Enabled = True
                cmbLeakGasShape.Enabled = True
                txtAngle.Enabled = True
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = False
                txtS.Enabled = False
                txtVolatilizationT.Enabled = False
                txtSHe.Enabled = False
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 5 '(6)压力液化气容器爆裂
                txtQ.Enabled = True
                txtInT.Enabled = False
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = False
                txtH.Enabled = True
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 6 '(7)常压液体容器小孔、中孔泄漏
                txtQ.Enabled = True
                txtInT.Enabled = True
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = True
                txtH.Enabled = False
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = True
                txtLeakLiquidCd.Enabled = True
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = True
                If Me.chkAutoCalVapP.Checked = True Then
                    txtLeakEvaporationP.Enabled = False
                Else
                    txtLeakEvaporationP.Enabled = True
                End If

            Case 7 ' (8)常压液体容器爆裂
                txtQ.Enabled = True
                txtInT.Enabled = False
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = False
                txtH.Enabled = False
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = False
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = True
                If Me.chkAutoCalVapP.Checked = True Then
                    txtLeakEvaporationP.Enabled = False
                Else
                    txtLeakEvaporationP.Enabled = True
                End If
            Case 8 '(9)压力液化气容器两相流泄漏
                txtQ.Enabled = True
                txtInT.Enabled = True
                Me.chkAutoCalLeakP.Enabled = True
                If Me.chkAutoCalLeakP.Checked = True Then
                    txtLeakGasP.Enabled = False
                Else
                    txtLeakGasP.Enabled = True
                End If
                txtLeakGasA.Enabled = True
                txtH.Enabled = True
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = True
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = True
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 9 '(10)冷冻液化气容器小孔、中孔泄漏
                txtQ.Enabled = True
                txtInT.Enabled = True
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = True
                txtH.Enabled = False
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = True
                txtLeakLiquidHeight.Enabled = True
                txtLeakLiquidCd.Enabled = True
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
            Case 10 '(11)冷冻液化气容器爆裂
                txtQ.Enabled = True
                txtInT.Enabled = False
                Me.chkAutoCalLeakP.Enabled = False
                txtLeakGasP.Enabled = False
                txtLeakGasA.Enabled = False
                txtH.Enabled = False
                cmbLeakGasShape.Enabled = False
                txtAngle.Enabled = False
                txtDurationT.Enabled = False
                txtLeakLiquidHeight.Enabled = False
                txtLeakLiquidCd.Enabled = False
                txtLeakTwoCd.Enabled = False
                cbmSourceType.Enabled = False
                txtQ0.Enabled = False
                txtS_S.Enabled = False
                txtThickness.Enabled = False
                cmbLeakEvaporationGround.Enabled = True
                txtS.Enabled = True
                txtVolatilizationT.Enabled = True
                txtSHe.Enabled = True
                Me.chkAutoCalVapP.Enabled = False
                txtLeakEvaporationP.Enabled = False
        End Select
        cbmSourceType_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub chkAutoCalLeakP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCalLeakP.CheckedChanged
        Me.Dis.IntialSource.chkLeakGasP = Me.chkAutoCalLeakP.Checked
        Me.txtLeakGasP.Enabled = Not Me.chkAutoCalLeakP.Checked
    End Sub

    Private Sub chkAutoCalVapP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCalVapP.CheckedChanged
        Me.m_Dis.IntialSource.chkVap = Me.chkAutoCalVapP.Checked
        txtLeakEvaporationP.Enabled = Not Me.chkAutoCalVapP.Checked
    End Sub

    Private Sub txtLeakEvaporationP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationP.Validating
        Me.m_Dis.IntialSource.LeakEvaporationP = txtLeakEvaporationP.Value
    End Sub


    Private Sub chkIsHeavy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsHeavy.CheckedChanged
        Me.m_Dis.IntialSource.IsHeavy = chkIsHeavy.Checked
        txtAirProportion.Enabled = chkIsHeavy.Checked
    End Sub

    Private Sub txtAirProportion_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAirProportion.Validating
        Me.m_Dis.IntialSource.AirProportion = txtAirProportion.Value
    End Sub

    Private Sub txtProbability_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtProbability.Validating
        Me.m_Dis.IntialSource.Probability = txtProbability.Value

    End Sub
End Class