Public Class frmFireResult
    Private m_ReLoad As Boolean = False
    ''' <summary>
    ''' 是否重新载入数据的标志
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ReLoad() As Boolean
        Get
            Return Me.m_ReLoad
        End Get
        Set(ByVal value As Boolean)
            Me.m_ReLoad = value
        End Set
    End Property
    ''' <summary>
    ''' 计算下风向
    ''' </summary>
    ''' <param name="num"></param>
    ''' <remarks></remarks>
    Public Sub RefreshFireVane(ByVal num As Integer)
        TChart1.Series.Clear() '清除所有
        EFlexVane.Cols.Count = 2
        Dim s As New Steema.TeeChart.Styles.Line
        Dim a(-1) As Double
        Dim b(-1) As Double
        '更新图表
        Select Case Project0.FAndB.FType
            Case 0
                'TNT爆炸当量法
                EFlexVane.Rows.Count = Project0.FAndB.UVCE.Tcount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "超压[Pa]")
                ReDim a(0 To Project0.FAndB.UVCE.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.UVCE.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.UVCE.Tstep
                    b(k) = Project0.FAndB.UVCE.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 1
                '凝聚相爆炸
                EFlexVane.Rows.Count = Project0.FAndB.MaterialTNT.Tcount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "超压[Pa]")
                ReDim a(0 To Project0.FAndB.MaterialTNT.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.MaterialTNT.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.MaterialTNT.Tstep
                    b(k) = Project0.FAndB.MaterialTNT.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 2
                '加油站爆炸
                EFlexVane.Rows.Count = Project0.FAndB.GasStation.Tcount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "超压[Pa]")
                ReDim a(0 To Project0.FAndB.GasStation.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.GasStation.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.GasStation.Tstep
                    b(k) = Project0.FAndB.GasStation.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 3
                '物理爆炸
                EFlexVane.Rows.Count = Project0.FAndB.PhysicsExplode.Tcount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "超压[Pa]")
                ReDim a(0 To Project0.FAndB.PhysicsExplode.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.PhysicsExplode.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.PhysicsExplode.Tstep
                    b(k) = Project0.FAndB.PhysicsExplode.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 10
                '池火灾模型
                EFlexVane.Rows.Count = Project0.FAndB.PoolFire.StepCount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "热辐射[J/m^2]")
                ReDim a(0 To Project0.FAndB.PoolFire.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.PoolFire.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.PoolFire.StepLong
                    b(k) = Project0.FAndB.PoolFire.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 11
                '沸腾液体扩展蒸气云爆炸(BLEVE)
                EFlexVane.Rows.Count = Project0.FAndB.Bleve.StepCount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "热辐射[J/m^2]")
                ReDim a(0 To Project0.FAndB.Bleve.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.Bleve.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.Bleve.StepLong
                    b(k) = Project0.FAndB.Bleve.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 12
                '固体火灾
                EFlexVane.Rows.Count = Project0.FAndB.SolidFire.StepCount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "热辐射[J/m^2]")
                ReDim a(0 To Project0.FAndB.SolidFire.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.SolidFire.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.SolidFire.StepLong
                    b(k) = Project0.FAndB.SolidFire.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
            Case 13
                '喷射火
                EFlexVane.Rows.Count = Project0.FAndB.Jet.JetFire.StepCount + 1
                EFlexVane.SetData(0, 0, "距离[m]")
                EFlexVane.SetData(0, 1, "热辐射[J/m^2]")
                ReDim a(0 To Project0.FAndB.Jet.JetFire.ResultDP.Length - 1)
                ReDim b(0 To Project0.FAndB.Jet.JetFire.ResultDP.Length - 1)
                For k As Integer = 0 To a.Length - 1
                    a(k) = (k + 1) * Project0.FAndB.Jet.JetFire.StepLong
                    b(k) = Project0.FAndB.Jet.JetFire.ResultDP(k)
                    EFlexVane.SetData(k + 1, 0, FormatNumber(a(k), num))
                    EFlexVane.SetData(k + 1, 1, FormatNumber(b(k), num))
                Next
        End Select

        '把第一个数为0去掉
        While b IsNot Nothing AndAlso b(0) <= 0
            If b(0) <= 0 Then
                For i As Integer = 0 To b.Length - 2
                    a(i) = a(i + 1)
                    b(i) = b(i + 1)
                Next
                ReDim Preserve a(a.Length - 2)
                ReDim Preserve b(b.Length - 2)
            End If

        End While

        s.Add(a, b)
        TChart1.Series.Add(s)
        EFlexVane.AutoResize = True
        EFlexVane.AutoSizeCols()
    End Sub

    Private Sub frmTNTResult_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.m_ReLoad = True Then
            cmbNum.SelectedIndex = 0
            If cmbNum.Text IsNot Nothing AndAlso cmbNum.Text <> "" AndAlso cmbNum.Text >= 0 Then
                RefreshFireVane(cmbNum.Text)
            End If

            '将重新载入标志设置
            Me.m_ReLoad = False
        End If
    End Sub
    Private Sub frmChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EFlexVane.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
    End Sub

    Private Sub 复制CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制CToolStripMenuItem.Click
        Me.TChart1.Export.Image.JPEG.CopyToClipboard()
    End Sub

    Private Sub 设置SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置SToolStripMenuItem.Click
        TChart1.ShowEditor()
    End Sub
    
    Private Sub cmbNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNum.Click

    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNum.SelectedIndexChanged
        If cmbNum.Text IsNot Nothing AndAlso cmbNum.Text <> "" AndAlso cmbNum.Text >= 0 Then
            RefreshFireVane(cmbNum.Text)
        End If
    End Sub
End Class
