Imports System.Windows.Forms
Imports System.Data
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
        For i As Integer = 0 To Me.m_Dis.ListLeakSource.IntialSource.Count - 1
            Me.lstSource.Items.Add(Me.m_Dis.ListLeakSource.IntialSource(i).LeakSourceName)
        Next
        If Me.lstSource.Items.Count > 0 Then
            Me.lstSource.SelectedIndex = 0
        End If
        '环境温度和环境压力
        txtTa.Value = Me.m_Dis.Forecast.Ta
        txtPa.Value = Me.m_Dis.Forecast.Pa
    End Sub
    Private Sub txtLeakSourceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakSourceName = txtLeakSourceName.Text   '泄漏源名称
            Dim Index As Integer = Me.lstSource.SelectedIndex
            Me.lstSource.Items.Clear()
            For i As Integer = 0 To Me.m_Dis.ListLeakSource.IntialSource.Count - 1
                Me.lstSource.Items.Add(Me.m_Dis.ListLeakSource.IntialSource(i).LeakSourceName)
            Next
            Me.lstSource.SelectedIndex = Index
        End If
    End Sub

    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Coordinate.x = txtX.Value
        End If

    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Coordinate.y = txtY.Value
        End If

    End Sub

    Private Sub txtQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Q = txtQ.Value
        End If

    End Sub

    Private Sub txtInT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInT.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).InT = txtInT.Value
        End If

    End Sub

    Private Sub txtLeakGasP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakGasP = txtLeakGasP.Value
        End If


    End Sub

    Private Sub txtLeakGasA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasA.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakGasA = txtLeakGasA.Value
        End If

    End Sub

    Private Sub txtH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtH.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).H = txtH.Value
        End If

    End Sub

    Private Sub cmbLeakGasShape_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLeakGasShape.SelectedIndexChanged
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakGasShape = cmbLeakGasShape.SelectedIndex
        End If

    End Sub

    Private Sub txtAngle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAngle.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Angle = txtAngle.Value
        End If

    End Sub
    Private Sub txtDurationT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDurationT.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).DurationT = txtDurationT.Value '排放时间
        End If

    End Sub
    Private Sub txtLeakLiquidHeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidHeight.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakLiquidHeight = txtLeakLiquidHeight.Value
        End If

    End Sub

    Private Sub txtLeakLiquidCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCd.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakLiquidCd = txtLeakLiquidCd.Value
        End If

    End Sub


    Private Sub cmbLeakEvaporationGround_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLeakEvaporationGround.SelectedIndexChanged
        If Me.lstSource.SelectedIndex >= 0 Then

            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakEvaporationGround = cmbLeakEvaporationGround.SelectedIndex
        End If
    End Sub

    Private Sub txtS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS.TextChanged

    End Sub

    Private Sub txtS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).S = txtS.Value
        End If

    End Sub

    Private Sub txtVolatilizationT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVolatilizationT.TextChanged

    End Sub

    Private Sub txtVolatilizationT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVolatilizationT.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).VolatilizationT = txtVolatilizationT.Value
        End If

    End Sub

    Private Sub txtSHe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSHe.TextChanged

    End Sub

    Private Sub txtSHe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSHe.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).SHe = txtSHe.Value
        End If

    End Sub
    Private Sub txtQ0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ0.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Q0 = txtQ0.Value
        End If


    End Sub

    Private Sub txtS_S_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS_S.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).S_S = txtS_S.Value
        End If

    End Sub

    Private Sub txtThickness_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtThickness.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Thickness = txtThickness.Value
        End If

    End Sub

    Private Sub txtLeakTwoCd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoCd.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakTwoCd = txtLeakTwoCd.Value
        End If

    End Sub

    Private Sub cbmSourceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbmSourceType.SelectedIndexChanged
        If Me.lstSource.SelectedIndex >= 0 Then
            '根据泄漏源的类型，显示不同的参数
            If Me.cbmSourceType.SelectedIndex >= 0 Then
                Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).SourceType = Me.cbmSourceType.SelectedIndex
            End If

            Select Case cbmSourceType.SelectedIndex
                Case 0 '点源
                    txtH.Enabled = cbmSourceType.Enabled
                    txtQ0.Enabled = cbmSourceType.Enabled
                    txtS_S.Enabled = False
                    txtThickness.Enabled = False
                Case 1 '面源
                    txtH.Enabled = cbmSourceType.Enabled
                    txtQ0.Enabled = cbmSourceType.Enabled
                    txtS_S.Enabled = cbmSourceType.Enabled
                    txtThickness.Enabled = False

                    txtS_S.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).S_S
                    LabelS.Text = "面源面积S[m^2]:"
                Case 2 '体源
                    txtH.Enabled = cbmSourceType.Enabled
                    txtQ0.Enabled = cbmSourceType.Enabled
                    txtS_S.Enabled = cbmSourceType.Enabled
                    txtThickness.Enabled = cbmSourceType.Enabled
                    txtS_S.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).S_S
                    LabelS.Text = "体源面积S[m^2]:"

            End Select
        End If

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
        If Me.lstSource.SelectedIndex >= 0 Then
            If cmbLeakType.SelectedIndex >= 0 Then
                Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakType = cmbLeakType.SelectedIndex
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
        End If

    End Sub

    Private Sub chkAutoCalLeakP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCalLeakP.CheckedChanged
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).chkLeakGasP = Me.chkAutoCalLeakP.Checked
            Me.txtLeakGasP.Enabled = Not Me.chkAutoCalLeakP.Checked
        End If

    End Sub

    Private Sub chkAutoCalVapP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCalVapP.CheckedChanged
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).chkVap = Me.chkAutoCalVapP.Checked
            txtLeakEvaporationP.Enabled = Not Me.chkAutoCalVapP.Checked
        End If

    End Sub

    Private Sub txtLeakEvaporationP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationP.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakEvaporationP = txtLeakEvaporationP.Value
        End If

    End Sub


    Private Sub chkIsHeavy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsHeavy.CheckedChanged
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).IsHeavy = chkIsHeavy.Checked
            txtAirProportion.Enabled = chkIsHeavy.Checked
        End If

    End Sub

    Private Sub txtAirProportion_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAirProportion.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).AirProportion = txtAirProportion.Value
        End If

    End Sub

    Private Sub txtProbability_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtProbability.Validating
        If Me.lstSource.SelectedIndex >= 0 Then
            Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Probability = txtProbability.Value
        End If
    End Sub

    Private Sub txtTa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTa.Validating
        Me.m_Dis.Forecast.Ta = txtTa.Value

    End Sub

    Private Sub txtPa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPa.Validating
        Me.m_Dis.Forecast.Pa = txtPa.Value

    End Sub

    Private Sub txtDurationT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDurationT.TextChanged

    End Sub

    Private Sub txtQ0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQ0.TextChanged

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim InSource As New DisPuff.IntialSource
        InSource.LeakSourceName = "事故源" & Me.m_Dis.ListLeakSource.SourceIndex + 1
        InSource.ID = "Leak_" & Me.m_Dis.ListLeakSource.SourceIndex + 1
        Me.m_Dis.ListLeakSource.SourceIndex += 1
        Me.m_Dis.ListLeakSource.IntialSource.Add(InSource)
        Me.lstSource.Items.Add(InSource.LeakSourceName)
        Me.lstSource.SelectedIndex = Me.lstSource.Items.Count - 1

    End Sub

    Private Sub lstSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSource.SelectedIndexChanged
        If Me.lstSource.SelectedIndex >= 0 Then
            cmbLeakType.SelectedIndex = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakType '泄漏类型
            txtLeakSourceName.Text = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakSourceName  '泄漏源名称
            txtX.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Coordinate.x
            txtY.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Coordinate.y
            txtQ.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Q
            txtInT.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).InT
            txtLeakGasP.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakGasP
            txtLeakGasA.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakGasA
            txtH.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).H
            txtLeakLiquidHeight.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakLiquidHeight
            txtDurationT.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).DurationT
            txtLeakLiquidCd.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakLiquidCd
            cmbLeakEvaporationGround.SelectedIndex = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakEvaporationGround
            txtS.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).S
            txtS_S.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).S_S
            txtVolatilizationT.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).VolatilizationT
            txtSHe.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).SHe

            cbmSourceType.SelectedIndex = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).SourceType
            txtQ0.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Q0
            txtThickness.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Thickness
            cmbLeakGasShape.SelectedIndex = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakGasShape
            txtAngle.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Angle
            txtLeakTwoCd.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakTwoCd
            txtLeakLiquidCd.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakLiquidCd

            chkAutoCalLeakP.Checked = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).chkLeakGasP
            chkAutoCalVapP.Checked = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).chkVap
            txtLeakEvaporationP.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).LeakEvaporationP
            cmbLeakType_SelectedIndexChanged(sender, e)
            chkIsHeavy.Checked = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).IsHeavy
            txtAirProportion.Enabled = chkIsHeavy.Checked
            txtAirProportion.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).AirProportion

            txtProbability.Value = Me.m_Dis.ListLeakSource.IntialSource(Me.lstSource.SelectedIndex).Probability
        End If
    End Sub

    Private Sub txtLeakSourceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeakSourceName.TextChanged

    End Sub
End Class