Public Class frmPopulation
    Protected m_PopulationRegions As New DisPuff.PopulationRegions
    ''' <summary>
    ''' 泄漏预测对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PopulationRegions() As DisPuff.PopulationRegions
        Get
            Return Me.m_PopulationRegions
        End Get
        Set(ByVal value As DisPuff.PopulationRegions)
            Me.m_PopulationRegions = value
        End Set
    End Property
    ''' <summary>
    ''' 添加网格
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Me.m_PopulationRegions.nPopulationRegion += 1
        Me.ListSubGrid.Items.Add("区域" & Me.m_PopulationRegions.nPopulationRegion)
        ReDim Preserve Me.m_PopulationRegions.ArrayPopulationRegion(Me.m_PopulationRegions.ArrayPopulationRegion.Length)
        Me.m_PopulationRegions.ArrayPopulationRegion(Me.m_PopulationRegions.ArrayPopulationRegion.Length - 1) = New DisPuff.PopulationRegion
        Me.m_PopulationRegions.ArrayPopulationRegion(Me.m_PopulationRegions.ArrayPopulationRegion.Length - 1).Name = "区域" & Me.m_PopulationRegions.nPopulationRegion
        Me.ListSubGrid.SelectedIndex = Me.ListSubGrid.Items.Count - 1

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim Index As Integer = Me.ListSubGrid.SelectedIndex
        If Index >= 0 Then
            If Index < Me.ListSubGrid.Items.Count - 1 Then
                For i As Integer = Index To Me.m_PopulationRegions.ArrayPopulationRegion.Length - 2
                    Me.m_PopulationRegions.ArrayPopulationRegion(i) = Me.m_PopulationRegions.ArrayPopulationRegion(i + 1)
                Next
                ReDim Preserve Me.m_PopulationRegions.ArrayPopulationRegion(Me.m_PopulationRegions.ArrayPopulationRegion.Length - 2)
                Me.ListSubGrid.Items.Remove(Me.ListSubGrid.SelectedItem)
                Me.ListSubGrid.SelectedIndex = Index
            Else
                ReDim Preserve Me.m_PopulationRegions.ArrayPopulationRegion(Me.m_PopulationRegions.ArrayPopulationRegion.Length - 2)
                Me.ListSubGrid.Items.Remove(Me.ListSubGrid.SelectedItem)
                Me.ListSubGrid.SelectedIndex = Index - 1
            End If
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub ListSubGrid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSubGrid.SelectedIndexChanged
        Me.m_PopulationRegions.SelectedIndex = Me.ListSubGrid.SelectedIndex

        EFlexCoo()
    End Sub

    Private Sub frmSubGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListSubGrid.Items.Clear()
        If Me.m_PopulationRegions.ArrayPopulationRegion IsNot Nothing Then
            For isub As Integer = 0 To Me.m_PopulationRegions.ArrayPopulationRegion.Length - 1
                ListSubGrid.Items.Add(Me.m_PopulationRegions.ArrayPopulationRegion(isub).Name)
            Next
        End If
        Me.ListSubGrid.SelectedIndex = Me.m_PopulationRegions.SelectedIndex
        ListSubGrid_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ListSubGrid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ListSubGrid.Validating

    End Sub

    Private Sub BCrooCr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCrooCr.Click
        If Me.ListSubGrid.Items.Count >= 1 Then
            Dim xx As Integer = Me.ListSubGrid.SelectedIndex
            ReDim Preserve Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation.Length) '顶点增加1
            EFlexCoo()
        End If

    End Sub
    ''' <summary>
    ''' 设置EFlexCoor,角点坐标
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EFlexCoo()
        If Me.ListSubGrid.Items.Count >= 1 Then
            Dim xx As Integer = Me.ListSubGrid.SelectedIndex
            If xx >= 0 Then
                Me.txtName.Text = Me.m_PopulationRegions.ArrayPopulationRegion(xx).Name
                Me.txtPopulation.Text = Me.m_PopulationRegions.ArrayPopulationRegion(xx).AllPopulateion

                Me.EFlexCoor.Rows.Count = Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation.Length + 1
                For i As Integer = 0 To Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation.Length - 1
                    Me.EFlexCoor.SetData(i + 1, 0, i + 1)
                    Me.EFlexCoor.SetData(i + 1, 1, Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(i).X)
                    Me.EFlexCoor.SetData(i + 1, 2, Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(i).Y)
                Next
            End If

        End If
    End Sub

    Private Sub BCrooDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCrooDel.Click
        Dim index As Integer = Me.EFlexCoor.RowSel - 1
        If Me.ListSubGrid.Items.Count >= 1 Then
            Dim xx As Integer = Me.ListSubGrid.SelectedIndex
            If index >= 0 Then
                For i As Integer = index To Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation.Length - 2
                    Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(i) = Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(i + 1)
                Next
                ReDim Preserve Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation.Length - 2)
            End If
            Me.EFlexCoo()
        End If
    End Sub

    Private Sub EFlexCoor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexCoor.Validating
        If Me.ListSubGrid.Items.Count >= 1 Then
            Dim L As Integer = Me.EFlexCoor.Rows.Count - 1
            Dim xx As Integer = Me.ListSubGrid.SelectedIndex
            If xx >= 0 Then
                For i As Integer = 0 To L - 1
                    Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(i).X = Me.EFlexCoor.GetData(i + 1, 1)
                    Me.m_PopulationRegions.ArrayPopulationRegion(xx).ArrayLocation(i).Y = Me.EFlexCoor.GetData(i + 1, 2)
                Next
            End If
        End If
    End Sub

    Private Sub txtName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating
        If Me.ListSubGrid.Items.Count >= 1 Then
            Dim L As Integer = Me.EFlexCoor.Rows.Count - 1
            Dim xx As Integer = Me.ListSubGrid.SelectedIndex
            If xx >= 0 Then
                Me.m_PopulationRegions.ArrayPopulationRegion(xx).Name = Me.txtName.Text

            End If
        End If
    End Sub

    Private Sub txtPopulation_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPopulation.Validating
        If Me.ListSubGrid.Items.Count >= 1 Then
            Dim L As Integer = Me.EFlexCoor.Rows.Count - 1
            Dim xx As Integer = Me.ListSubGrid.SelectedIndex
            If xx >= 0 Then
                Me.m_PopulationRegions.ArrayPopulationRegion(xx).AllPopulateion = Me.txtPopulation.Text
            End If
        End If
    End Sub
End Class