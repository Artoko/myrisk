Public Class frmGrid

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
    Private Sub frmGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '计算网格点标志
        chkGrid.Checked = Me.m_Dis.Forecast.IsCalGrid
        '设置网格
        txtMinX.Value = Me.m_Dis.Forecast.Grid.MinX
        txtStepX.Value = Me.m_Dis.Forecast.Grid.StepX
        txtCountX.Value = Me.m_Dis.Forecast.Grid.CountX
        txtMinY.Value = Me.m_Dis.Forecast.Grid.MinY
        txtStepY.Value = Me.m_Dis.Forecast.Grid.StepY
        txtCountY.Value = Me.m_Dis.Forecast.Grid.CountY
        txtWGH.Value = Me.m_Dis.Forecast.Grid.WGH
        Me.txtPopulation.Value = Me.m_Dis.Forecast.Grid.Population '人口密度
        '设置网格的内容
        ReSetFlexGrid()
        For i As Integer = 0 To txtCountX.Value - 1
            For j As Integer = 0 To txtCountY.Value - 1
                Me.flexPopulation.SetData(j + 1, i + 1, FormatNumber(Me.Dis.Forecast.Grid.GridPopulation(j, i), 4))
            Next
        Next
        Me.flexPopulation.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.flexPopulation.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.flexPopulation.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.flexPopulation.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.flexPopulation.AutoSizeCols()
    End Sub



    Private Sub ReSetFlexGrid()
        Me.flexPopulation.Cols.Count = txtCountX.Value + 1
        Me.flexPopulation.Rows.Count = txtCountY.Value + 1
        Me.flexPopulation.SetData(0, 0, "y\x")
        For i As Integer = 0 To txtCountX.Value - 1
            Me.flexPopulation.SetData(0, i + 1, txtMinX.Value + i * txtStepX.Value)
        Next
        For j As Integer = 0 To txtCountY.Value - 1
            Me.flexPopulation.SetData(j + 1, 0, txtMinY.Value + j * txtStepY.Value)
        Next
        Me.flexPopulation.AutoSizeCols()
    End Sub

    ''' <summary>
    ''' 根据人口密度设置网格
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IntialGridData()
        ReSetFlexGrid()
        '计算每个网格的面积
        Dim S As Double = txtStepX.Value * txtStepY.Value '计算区域的面积，单位是m^2
        Dim p As Double = S / 1000000 * txtPopulation.Value '计算每个网格的人口数
        For i As Integer = 0 To txtCountX.Value - 1
            For j As Integer = 0 To txtCountY.Value - 1
                Me.flexPopulation.SetData(j + 1, i + 1, FormatNumber(p, 4))
            Next
        Next

        Me.flexPopulation.AutoSizeCols()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.m_Dis.Forecast.IsCalGrid = chkGrid.Checked
        Me.m_Dis.Forecast.Grid.MinX = txtMinX.Value
        Me.m_Dis.Forecast.Grid.StepX = txtStepX.Value
        Me.m_Dis.Forecast.Grid.CountX = txtCountX.Value
        Me.m_Dis.Forecast.Grid.MinY = txtMinY.Value
        Me.m_Dis.Forecast.Grid.StepY = txtStepY.Value
        Me.m_Dis.Forecast.Grid.CountY = txtCountY.Value
        Me.m_Dis.Forecast.Grid.WGH = txtWGH.Value

        Me.m_Dis.Forecast.Grid.Population = Me.txtPopulation.Value '人口密度
        '设置网格的内容
        ReDim Me.m_Dis.Forecast.Grid.GridPopulation(txtCountY.Value - 1, txtCountX.Value - 1)
        For i As Integer = 0 To txtCountX.Value - 1
            For j As Integer = 0 To txtCountY.Value - 1
                Me.Dis.Forecast.Grid.GridPopulation(j, i) = Me.flexPopulation.GetData(j + 1, i + 1)
            Next
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub chkGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGrid.CheckedChanged
        Me.m_Dis.Forecast.IsCalGrid = chkGrid.Checked
    End Sub
    Private Sub txtMinX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinX.Validating
        ReSetFlexGrid()
    End Sub


    Private Sub txtStepX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStepX.Validating
        ReSetFlexGrid()
    End Sub

    Private Sub txtCountX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCountX.Validating
        ReSetFlexGrid()
    End Sub

    Private Sub txtMinY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinY.Validating
        ReSetFlexGrid()

    End Sub

    Private Sub txtStepY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStepY.Validating
        ReSetFlexGrid()
    End Sub

    Private Sub txtCountY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCountY.Validating
        ReSetFlexGrid()
    End Sub

    Private Sub cmdSetPopular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetPopular.Click
        IntialGridData()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub
End Class