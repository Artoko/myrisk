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
        txtSHe.Value = Me.m_Dis.IntialSource.SHe

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
              '环境温度和环境压力
        txtTa.Value = Me.m_Dis.Forecast.Ta
        txtPa.Value = Me.m_Dis.Forecast.Pa

    End Sub
    Private Sub txtLeakSourceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakSourceName.Validating
        Me.m_Dis.IntialSource.LeakSourceName = txtLeakSourceName.Text   '设置泄漏源名称
    End Sub

    Private Sub txtX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating
        Me.m_Dis.IntialSource.Coordinate.x = txtX.Value '设置泄漏源的坐标，最好设置为0
    End Sub

    Private Sub txtY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtY.Validating
        Me.m_Dis.IntialSource.Coordinate.y = txtY.Value '设置泄漏源的坐标，最好设置为0
    End Sub

    Private Sub txtQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ.Validating
        Me.m_Dis.IntialSource.Q = txtQ.Value '设置容器内的储存量，单位kg
    End Sub

    Private Sub txtInT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInT.Validating
        Me.m_Dis.IntialSource.InT = txtInT.Value '设置容器内物料的储存温度，单位摄氏度
    End Sub

    Private Sub txtLeakGasP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasP.Validating
        Me.m_Dis.IntialSource.LeakGasP = txtLeakGasP.Value '设置容器的压力，单位Pa

    End Sub
    Private Sub txtDurationT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDurationT.Validating
        Me.m_Dis.IntialSource.DurationT0 = txtDurationT.Value '设置泄漏持续的时间。如果在用户设置的泄漏时间内容器内的物料已经泄漏完，系统会自动按泄漏完物料的时间来计算。单位min
    End Sub

    Private Sub txtLeakGasA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakGasA.Validating
        Me.m_Dis.IntialSource.LeakGasA = txtLeakGasA.Value '设置容器泄漏口的面积，单位平方米
    End Sub

    Private Sub txtH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtH.Validating
        Me.m_Dis.IntialSource.H = txtH.Value '设置泄漏口距地面的高度。单位m
    End Sub

    Private Sub cmbLeakGasShape_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLeakGasShape.SelectedIndexChanged
        Me.m_Dis.IntialSource.LeakGasShape = cmbLeakGasShape.SelectedIndex '设置泄漏口形状。0--圆形；1--三角形；2--长方形

    End Sub

    Private Sub txtAngle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAngle.Validating
        Me.m_Dis.IntialSource.Angle = txtAngle.Value '泄漏口的喷射角度。水平方向为0度，垂直方向为90度。建议设置为0度
    End Sub
    Private Sub txtLeakLiquidHeight_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidHeight.Validating
        Me.m_Dis.IntialSource.LeakLiquidHeight = txtLeakLiquidHeight.Value '泄漏口之上液面的高度。即液面到泄漏口之间的高度差，单位m.
    End Sub

    Private Sub txtLeakLiquidCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakLiquidCd.Validating
        Me.m_Dis.IntialSource.LeakLiquidCd = txtLeakLiquidCd.Value '液体泄漏系数。建议设置为0.62
    End Sub
    Private Sub txtLeakTwoCd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakTwoCd.Validating
        Me.m_Dis.IntialSource.LeakTwoCd = txtLeakTwoCd.Value '两相流泄漏系数。建议设置为0.8
    End Sub

    Private Sub cmbLeakEvaporationGround_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLeakEvaporationGround.SelectedIndexChanged
        Me.m_Dis.IntialSource.LeakEvaporationGround = cmbLeakEvaporationGround.SelectedIndex '在这里设置地面的情况： Case 0 '水泥  Case 1 '土地(含水8%)   Case 2 '干阔土地  Case 3 '湿地  Case 4 '砂砾地
    End Sub

    Private Sub txtS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS.TextChanged

    End Sub

    Private Sub txtS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS.Validating
        Me.m_Dis.IntialSource.S = txtS.Value '围堰的面积，单位平方米。如果没有围堰，则设置为0
    End Sub

    Private Sub txtVolatilizationT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVolatilizationT.TextChanged

    End Sub

    Private Sub txtVolatilizationT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVolatilizationT.Validating
        Me.m_Dis.IntialSource.VolatilizationT = txtVolatilizationT.Value '泄漏到围堰的液体的蒸发时间。这个时间一般指从泄漏到围堰内开始到人工处理结束的时间。如果在人工处理结束之间泄漏液体已经蒸发完毕，软件会自动转成液体蒸发完毕的时间。
    End Sub

    Private Sub txtSHe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSHe.TextChanged

    End Sub

    Private Sub txtSHe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSHe.Validating
        Me.m_Dis.IntialSource.SHe = txtSHe.Value '围堰的高度，m。
    End Sub
    Private Sub txtQ0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ0.Validating
        Me.m_Dis.IntialSource.Q0 = txtQ0.Value '如果用户选择了自定泄漏类型。这里输入的是泄漏物的挥发速率，单位为kg/s。

    End Sub

    Private Sub txtS_S_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtS_S.Validating
        Me.m_Dis.IntialSource.S_S = txtS_S.Value '如果用户选择了自定泄漏类型的面源排放。这里输入的是面源的面积，单位为平方米。
    End Sub

    Private Sub txtThickness_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtThickness.Validating
        Me.m_Dis.IntialSource.Thickness = txtThickness.Value '如果用户选择了自定泄漏类型的体源排放。这里输入的是体源的厚度，单位为m。
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
        Me.Dis.IntialSource.chkLeakGasP = Me.chkAutoCalLeakP.Checked '如果设置了这个选项，必须设置相应的安托因参数，软件会根据安托因参数来计算容器内的压力。安托因参数的设置在数据库相关的设置中。如果不选择，就按用户输入的压力来计算，单位Pa。
        Me.txtLeakGasP.Enabled = Not Me.chkAutoCalLeakP.Checked
    End Sub

    Private Sub chkAutoCalVapP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCalVapP.CheckedChanged
        Me.m_Dis.IntialSource.chkVap = Me.chkAutoCalVapP.Checked '如果选择了这个选项，必须设置相应的安托因参数。安托因参数的设置在数据库相关的设置中。如果不选择，就按用户输入的蒸汽压来计算蒸发量。
        txtLeakEvaporationP.Enabled = Not Me.chkAutoCalVapP.Checked
    End Sub

    Private Sub txtLeakEvaporationP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLeakEvaporationP.Validating
        Me.m_Dis.IntialSource.LeakEvaporationP = txtLeakEvaporationP.Value '用户输入的蒸汽压，单位Pa。
    End Sub

    Private Sub txtTa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTa.Validating
        Me.m_Dis.Forecast.Ta = txtTa.Value '环境温度。摄氏度

    End Sub

    Private Sub txtPa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPa.Validating
        Me.m_Dis.Forecast.Pa = txtPa.Value '大气压力，Pa。

    End Sub
End Class