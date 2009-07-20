Imports WeifenLuo.WinFormsUI

Public Class frmResult
    Inherits DockContent

    Private Sub frmProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

#Region "ContextMenuStrip Window Position"
    Private Sub FloatingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FloatingToolStripMenuItem.Click
        Me.DockState = WeifenLuo.WinFormsUI.DockState.Float
    End Sub

    Private Sub DockableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DockableToolStripMenuItem.Click
        Me.DockState = Me.ShowHint
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
        Dim MainForm As frmMain
        MainForm = My.Application.ApplicationContext.MainForm
        MainForm.PropertyToolStripMenuItem.Checked = False
    End Sub

    Private Sub AutoHideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoHideToolStripMenuItem.Click
        Select Case Me.DockState
            Case WeifenLuo.WinFormsUI.DockState.DockBottom
                DockState = WeifenLuo.WinFormsUI.DockState.DockBottomAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockTop
                DockState = WeifenLuo.WinFormsUI.DockState.DockTopAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockLeft
                DockState = WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide
            Case WeifenLuo.WinFormsUI.DockState.DockRight
                DockState = WeifenLuo.WinFormsUI.DockState.DockRightAutoHide
        End Select
    End Sub

    Private Sub TabbedDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabbedDocumentToolStripMenuItem.Click
        DockState = WeifenLuo.WinFormsUI.DockState.Document
    End Sub
#End Region

    Private Sub frmProperty_DockStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockStateChanged
        For Each item As ToolStripMenuItem In ContextMenuDock.Items
            item.Checked = False
        Next
        Select Case Me.DockState

            Case WeifenLuo.WinFormsUI.DockState.Document
                TabbedDocumentToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.DockState.Float
                FloatingToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.DockState.DockBottomAutoHide, _
                 WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide, _
                 WeifenLuo.WinFormsUI.DockState.DockRightAutoHide, _
                 WeifenLuo.WinFormsUI.DockState.DockTopAutoHide

                AutoHideToolStripMenuItem.Checked = True

            Case WeifenLuo.WinFormsUI.DockState.DockBottom, _
                 WeifenLuo.WinFormsUI.DockState.DockLeft, _
                 WeifenLuo.WinFormsUI.DockState.DockRight, _
                 WeifenLuo.WinFormsUI.DockState.DockTop

                DockableToolStripMenuItem.Checked = True
        End Select
    End Sub



    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Select Case Project0.PType
            Case 0 '泄漏
                If e.Node.Level = 2 Then
                    Dim i As Integer = e.Node.Parent.Index
                    Dim j As Integer = e.Node.Index
                    '更新等值线图
                    RefreshCoutour(i, j, e.Node.Text)
                ElseIf e.Node.Level = 1 Then
                    Dim i As Integer = e.Node.Index
                End If

            Case 1 '火灾
                If e.Node.Level >= 1 Then
                    '更新等值线图
                    RefreshFireCountor()
                End If
        End Select
    End Sub
    


    
    ''' <summary>
    ''' 网格点数组
    ''' </summary>
    ''' <param name="i">气象条件的序号</param>
    ''' <param name="j">时间的序号</param>
    ''' <remarks></remarks>
    Public Sub RefreshCoutour(ByVal i As Integer, ByVal j As Integer, Optional ByVal strSlip As String = "")
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
            If strSlip = "滑移平均最大浓度" Then
                For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                    myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.SlipGrid(i, l, k).MaxCon
                Next
            Else
                For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                    myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.InstantaneousGridC(i, j, k, l)
                Next
            End If
        Next

        '设置等值线名称和值的数组
        ReDim myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourNames(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
        ReDim myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourValue(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
        For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourNames(n) = Project0.Dis0.Forecast.HurtConcentration(n).Name
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourValue(n) = FormatNumber(Project0.Dis0.Forecast.HurtConcentration(n).ConcentrationVale, 7)
        Next
        For i1 As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
            For j1 As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                For k1 As Integer = 0 To myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourValue.Length - 1
                    If myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.GridPoint(i1, j1) = myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourValue(k1) Then
                        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.GridPoint(i1, j1) = myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourValue(k1) + 0.000001
                    End If
                Next
            Next
        Next
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
        '设置伤害范围

        ReDim myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
        ReDim myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
        For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
            '设置事故名称
            ReDim Preserve myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtName(myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
            ReDim Preserve myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtValue(myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
            myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
            If strSlip = "滑移平均最大浓度" Then
                myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(i).Slip.HurtLengthSlip(m)
            Else
                myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(i).ForeTimeResults(j).HurtLength(m)
            End If
        Next
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
        '重新计算等值线
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ResetCountData()
        myFrmMain.DrawContourWindow.ContourPaint1.Refresh()
    End Sub
    

    Public Sub RefreshFireCountor()
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ChartType = 1 '设置类型为火灾爆炸类型

        With myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting
            '设置事故名称
            ReDim .ArrayHurtName(-1)
            '设置事故值
            ReDim .ArrayHurtValue(-1)
            ReDim .ContourNames(-1)
            ReDim .ContourValue(-1)
            Select Case Project0.FAndB.FType
                Case 0 'TNT爆炸
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.UVCE.DestroyRr.Length - 1
                        If Project0.FAndB.UVCE.DestroyRr(k).Selected Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.UVCE.DestroyRr(k).MDrangName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.UVCE.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.UVCE.DestroyRr(k).MDrangName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.UVCE.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.UVCE.SoucePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.UVCE.SoucePoint.y
                Case 1 '凝聚相
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.MaterialTNT.DestroyRr.Length - 1
                        If Project0.FAndB.MaterialTNT.DestroyRr(k).Selected Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.MaterialTNT.DestroyRr(k).MDrangName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.MaterialTNT.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.MaterialTNT.DestroyRr(k).MDrangName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.MaterialTNT.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.MaterialTNT.SoucePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.MaterialTNT.SoucePoint.y

                Case 2 '加油站
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.GasStation.DestroyRr.Length - 1
                        If Project0.FAndB.GasStation.DestroyRr(k).Selected Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.GasStation.DestroyRr(k).MDrangName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.GasStation.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.GasStation.DestroyRr(k).MDrangName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.GasStation.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.GasStation.SoucePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.GasStation.SoucePoint.y
                Case 3 '物理爆炸
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.PhysicsExplode.DestroyRr.Length - 1
                        If Project0.FAndB.PhysicsExplode.DestroyRr(k).Selected Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.PhysicsExplode.DestroyRr(k).MDrangName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.PhysicsExplode.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.PhysicsExplode.DestroyRr(k).MDrangName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.PhysicsExplode.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.PhysicsExplode.SoucePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.PhysicsExplode.SoucePoint.y


                Case 10 '池火灾
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.PoolFire.ArrHeatEradiate.Length - 1
                        If Project0.FAndB.PoolFire.ArrHeatEradiate(k).Checkd Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.PoolFire.ArrHeatEradiate(k).HeatName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.PoolFire.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.PoolFire.ArrHeatEradiate(k).HeatName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.PoolFire.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.PoolFire.SourcePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.PoolFire.SourcePoint.y

                Case 11 'BLEVE
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.Bleve.ArrHeatEradiate.Length - 1
                        If Project0.FAndB.Bleve.ArrHeatEradiate(k).Checkd Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.Bleve.ArrHeatEradiate(k).HeatName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.Bleve.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.Bleve.ArrHeatEradiate(k).HeatName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.Bleve.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.Bleve.SourcePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.Bleve.SourcePoint.y

                Case 12 '固体火灾
                    .setType(1)
                    For k As Integer = 0 To Project0.FAndB.SolidFire.ArrHeatEradiate.Length - 1
                        If Project0.FAndB.SolidFire.ArrHeatEradiate(k).Checkd Then
                            '设置事故名称
                            ReDim Preserve .ArrayHurtName(.ArrayHurtName.Length)
                            .ArrayHurtName(.ArrayHurtName.Length - 1) = Project0.FAndB.SolidFire.ArrHeatEradiate(k).HeatName & "半径"
                            '设置事故值
                            ReDim Preserve .ArrayHurtValue(.ArrayHurtValue.Length)
                            .ArrayHurtValue(.ArrayHurtValue.Length - 1) = Project0.FAndB.SolidFire.ResultR(k)


                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.SolidFire.ArrHeatEradiate(k).HeatName & "半径"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.SolidFire.ResultR(k)
                        End If
                    Next
                    .ContourPannel.Contours.x0 = Project0.FAndB.SolidFire.SourcePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.SolidFire.SourcePoint.y

                Case 13 '喷射火

                    .setType(0)
                    For k As Integer = 0 To Project0.FAndB.Jet.JetFire.ArrHeatEradiate.Length - 1
                        If Project0.FAndB.Jet.JetFire.ArrHeatEradiate(k).Checkd Then
                            '设置事故名称
                            ReDim Preserve .ContourNames(.ContourNames.Length)
                            .ContourNames(.ContourNames.Length - 1) = Project0.FAndB.Jet.JetFire.ArrHeatEradiate(k).HeatName & "范围"

                            ReDim Preserve .ContourValue(.ContourValue.Length)
                            .ContourValue(.ContourValue.Length - 1) = Project0.FAndB.Jet.JetFire.ArrHeatEradiate(k).Heat

                        End If
                    Next
                    ''重新计算等值线
                    'myFrmMain.DrawContourWindow.ContourPaint1.ResetCountData()
                    .ContourPannel.Contours.x0 = Project0.FAndB.Jet.JetFire.SourcePoint.x
                    .ContourPannel.Contours.y0 = Project0.FAndB.Jet.JetFire.SourcePoint.y
                    myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ResetCountData()
                    Dim JJJ As Integer = 0
                    For k As Integer = 0 To Project0.FAndB.Jet.JetFire.ArrHeatEradiate.Length - 1
                        If Project0.FAndB.Jet.JetFire.ArrHeatEradiate(k).Checkd Then
                            '设置事故值。由于喷射火返回的是事故范围围成的线，所以直接给出线的点
                            .ContourPannel.Contours.ArrayContour(JJJ) = New DrawContour.Contour
                            ReDim .ContourPannel.Contours.ArrayContour(JJJ).OneContourLine(Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint.Length - 1)
                            ReDim .ContourPannel.Contours.ArrayContour(JJJ).ArrayContourPoints(0)
                            .ContourPannel.Contours.ArrayContour(JJJ).ArrayContourPoints(0) = New DrawContour.ContourPoints

                            ReDim .ContourPannel.Contours.ArrayContour(JJJ).ArrayContourPoints(0).vecContourPoints(Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint.Length - 1)
                            For Ln As Integer = 0 To Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint.Length - 1

                                .ContourPannel.Contours.ArrayContour(JJJ).OneContourLine(Ln) = New DrawContour.Point3D
                                .ContourPannel.Contours.ArrayContour(JJJ).OneContourLine(Ln).x = Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint(Ln).x
                                .ContourPannel.Contours.ArrayContour(JJJ).OneContourLine(Ln).y = Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint(Ln).y

                                .ContourPannel.Contours.ArrayContour(JJJ).ArrayContourPoints(0).vecContourPoints(Ln) = New DrawContour.Point3D
                                .ContourPannel.Contours.ArrayContour(JJJ).ArrayContourPoints(0).vecContourPoints(Ln).x = Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint(Ln).x
                                .ContourPannel.Contours.ArrayContour(JJJ).ArrayContourPoints(0).vecContourPoints(Ln).y = Project0.FAndB.Jet.ResultHurtPoint(k).ArrayHurtPoint(Ln).y

                                .ContourPannel.Contours.ArrayContour(JJJ).ContourName = Project0.FAndB.Jet.JetFire.ArrHeatEradiate(k).HeatName
                                .ContourPannel.Contours.ArrayContour(JJJ).ContourValue = Project0.FAndB.Jet.JetFire.ArrHeatEradiate(k).Heat


                            Next
                            JJJ += 1
                        End If

                    Next

                    .ContourPannel.Contours.ContourStartColor = Color.FromArgb(255, 0, 0)   '设置等值线的起始颜色
                    .ContourPannel.Contours.ContourEndColor = Color.FromArgb(255, 255, 0)   '设置等值线的结束颜色
                    .ContourPannel.Contours.ContourColorGradual() '等值线颜色渐变
                    myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = False
                    myFrmMain.DrawContourWindow.ContourPaint1.Refresh()
                    Exit Sub
            End Select
        End With

        '重新计算等值线
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
        myFrmMain.DrawContourWindow.ContourPaint1.ContourPaintSetting.ResetCountData()
        myFrmMain.DrawContourWindow.ContourPaint1.Refresh()
    End Sub

    

End Class