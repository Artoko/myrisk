Public Class frmCare
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
    Private Sub frmCare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshEFlexCare()
    End Sub

    ''' <summary>
    ''' 添加关心点
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdAddCare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCare.Click
        ReDim Preserve Me.m_Dis.Forecast.CareReceptor(Me.m_Dis.Forecast.CareReceptor.Length) '数组长度加1
        Me.m_Dis.Forecast.CareReceptor(Me.m_Dis.Forecast.CareReceptor.Length - 1) = New DisPuff.CareReceptor
        'Me.m_Dis.Forecast.CareReceptor(Me.m_Dis.Forecast.CareReceptor.Length - 1).Name = "关心点"
        Dim P As New DisPuff.Point3D
        Me.m_Dis.Forecast.CareReceptor(Me.m_Dis.Forecast.CareReceptor.Length - 1).Point3D = P
        RefreshEFlexCare()
    End Sub
    Private Sub EFlexCare_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EFlexCare.Validating
        Dim nCount As Integer = EFlexCare.Rows.Count - 1
        ReDim Me.m_Dis.Forecast.CareReceptor(nCount - 1)
        For i As Integer = 0 To nCount - 1
            Me.m_Dis.Forecast.CareReceptor(i) = New DisPuff.CareReceptor
            Me.m_Dis.Forecast.CareReceptor(i).Name = Me.EFlexCare.GetData(i + 1, 0) '名称
            Dim p As New DisPuff.Point3D
            p.x = Me.EFlexCare.GetData(i + 1, 1)
            p.y = Me.EFlexCare.GetData(i + 1, 2)
            p.z = Me.EFlexCare.GetData(i + 1, 3)
            Me.m_Dis.Forecast.CareReceptor(i).Point3D = p
        Next
    End Sub
    Private Sub cmdDelCare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelCare.Click
        Dim index As Integer = Me.EFlexCare.RowSel - 1
        If index >= 0 Then
            For i As Integer = index To Me.m_Dis.Forecast.CareReceptor.Length - 2
                Me.m_Dis.Forecast.CareReceptor(i) = Me.m_Dis.Forecast.CareReceptor(i + 1)
            Next
            ReDim Preserve Me.m_Dis.Forecast.CareReceptor(Me.m_Dis.Forecast.CareReceptor.Length - 2)
            RefreshEFlexCare()
        End If
    End Sub

    ''' <summary>
    ''' 用表格更新关心点
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshEFlexCare()
        Dim nCount As Integer = Me.m_Dis.Forecast.CareReceptor.Length
        Me.EFlexCare.Rows.Count = nCount + 1
        For i As Integer = 0 To nCount - 1
            Me.EFlexCare.SetData(i + 1, 0, Me.m_Dis.Forecast.CareReceptor(i).Name)
            Me.EFlexCare.SetData(i + 1, 1, Me.m_Dis.Forecast.CareReceptor(i).Point3D.x)
            Me.EFlexCare.SetData(i + 1, 2, Me.m_Dis.Forecast.CareReceptor(i).Point3D.y)
            Me.EFlexCare.SetData(i + 1, 3, Me.m_Dis.Forecast.CareReceptor(i).Point3D.z)
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