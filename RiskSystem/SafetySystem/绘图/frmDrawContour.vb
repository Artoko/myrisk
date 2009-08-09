Public Class frmDrawContour
    Private m_AddProject As Boolean = 0 '添加项目

    Private m_LeakType As Integer '典型泄漏的类型
    Private m_FireBlastType As Integer '火灾爆炸类型


    ''' <summary>
    ''' 添加项目标志，0不添加，1添加
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AddProject() As Boolean
        Get
            Return Me.m_AddProject
        End Get
        Set(ByVal value As Boolean)
            Me.m_AddProject = value
        End Set
    End Property
    ''' <summary>
    ''' 典型泄漏的类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property leakType() As Integer
        Get
            Return Me.m_LeakType
        End Get
        Set(ByVal value As Integer)
            Me.m_LeakType = value
        End Set
    End Property
    ''' <summary>
    ''' 火灾爆炸类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FireBlastType() As Integer
        Get
            Return Me.m_FireBlastType
        End Get
        Set(ByVal value As Integer)
            Me.m_FireBlastType = value
        End Set
    End Property
    Private Sub frmDrawContour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ''' <summary>
    ''' 通过鼠标来显示预测窗口
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContourPaint1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContourPaint1.Click

    End Sub

    Private Sub ContourPaint1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContourPaint1.Load
        ContourPaint1.ContourPaintSetting.ContourPannel.Axes.LeftAxis.AxisGridding.AxisGriddingVisible = False
        ContourPaint1.ContourPaintSetting.ContourPannel.Axes.BottomAxis.AxisGridding.AxisGriddingVisible = False

    End Sub

    Private Sub ContourPaint1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ContourPaint1.MouseDoubleClick

    End Sub
    ''' <summary>
    ''' 添加方案
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContourPaint1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ContourPaint1.MouseDown
        'Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        'Dim point As New PointF
        'point.X = e.X
        'point.Y = e.Y
        'point = ContourPaint1.PointToLocation(point)
        'If e.Button = Windows.Forms.MouseButtons.Left And Me.m_AddProject = True Then
        '    Select Case Project0.PType
        '        Case 0 '泄漏模型
        '            Select Case Me.m_LeakType
        '                Case 0 '气体泄漏扩散模型
        '                    Dim dlgGas As New frmDisGasLeak  '气体泄漏扩散模型
        '                    dlgGas.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgGas.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgGas.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, )
        '                    dlgGas.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgGas.ShowDialog = Windows.Forms.DialogResult.OK Then

        '                        Project0.Dis0 = dlgGas.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 0 '气体泄漏
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针
        '                        '设置图中的泄漏源位置
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If

        '                Case 1 '液体泄漏
        '                    Dim dlgLiquid As New frmDisLiquidLeak   '液体泄漏扩散模型
        '                    dlgLiquid.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgLiquid.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquid.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquid.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgLiquid.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgLiquid.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 1 '液体泄漏
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针
        '                        '设置图中的泄漏源位置
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '                Case 2 '两相流泄漏扩散模型
        '                    Dim dlgTwo As New frmDisTwo    '两相流泄漏扩散模型
        '                    dlgTwo.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgTwo.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgTwo.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgTwo.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgTwo.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgTwo.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 2 '两相流泄漏
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针
        '                        '设置图中的泄漏源位置
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '                Case 3 '气体容器破裂
        '                    Dim dlgGasboo As New frmGasBoo     '气体容器破裂
        '                    dlgGasboo.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgGasboo.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgGasboo.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgGasboo.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgGasboo.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgGasboo.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 3 '气体容器破裂
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针
        '                        '设置图中的泄漏源位置
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '                Case 4 '液体容器破裂
        '                    Dim dlgLiquidboo As New frmDisLiquidBoo      '液体容器破裂
        '                    dlgLiquidboo.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgLiquidboo.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquidboo.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquidboo.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgLiquidboo.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgLiquidboo.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 4 '液体容器破裂
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针
        '                        '设置图中的泄漏源位置
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If

        '                Case 10
        '                    Dim dlg As New frmDisFu '手动扩散模型
        '                    dlg.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlg.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlg.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 10 '手动扩散模型
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '                Case 11
        '                    Dim dlg As New frmHeavy  '瞬时重气扩散模型
        '                    dlg.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlg.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlg.Dis
        '                        Project0.Dis0.IntialSource.IsHeavy = True '采用重气体模型
        '                        Project0.Dis0.Heavy.HeavyType = 1 '表示类型为box模型

        '                        Project0.Dis0.IntialSource.LeakType = 11 '瞬时重气扩散模型
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If

        '                Case 12
        '                    Dim dlg As New frmSlabHeavy  '连续重气扩散模型
        '                    dlg.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlg.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlg.Dis
        '                        Project0.Dis0.IntialSource.IsHeavy = True '采用重气体模型
        '                        Project0.Dis0.Heavy.HeavyType = 2 '表示类型为slab模型

        '                        Project0.Dis0.IntialSource.LeakType = 12 'slab重气扩散模型
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '设置点源
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '            End Select

        '        Case 1 '爆炸模型

        '            Select Case Me.m_FireBlastType
        '                Case 0 '蒸汽云爆炸，TNT当量法
        '                    Dim dlg As New frmUVCE   'TNT当量法
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.UVCE.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.UVCE.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        '                        Project0.FAndB.FType = 0
        '                        Project0.FAndB.UVCE = dlg.UVCE
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.UVCE.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.UVCE.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.UVCE.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '                Case 1 '凝聚相爆炸
        '                    Dim dlg As New frmMatialTNT    'TNT当量法
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.MaterialTNT.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.MaterialTNT.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint

        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 1
        '                        Project0.FAndB.MaterialTNT = dlg.MaterialTNT
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance


        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.MaterialTNT.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.MaterialTNT.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.MaterialTNT.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()

        '                    End If

        '                Case 2 '加油站爆炸
        '                    Dim dlg As New frmGasStation     'TNT当量法
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.GasStation.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.GasStation.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 2
        '                        Project0.FAndB.GasStation = dlg.GasStation
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance


        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.GasStation.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.GasStation.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.GasStation.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()

        '                    End If

        '                Case 3 '物理爆炸
        '                    Dim dlg As New frmPhysicsExplode    'TNT当量法
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.PhysicsExplode.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.PhysicsExplode.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 3
        '                        Project0.FAndB.PhysicsExplode = dlg.PhysicsExplode
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.PhysicsExplode.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.PhysicsExplode.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.PhysicsExplode.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If


        '                Case 10 '用10表示火灾事故中的池火
        '                    Dim dlg As New frmPoolFire      'TNT当量法
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.PoolFire.SourcePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.PoolFire.SourcePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 10
        '                        Project0.FAndB.PoolFire = dlg.PoolFire
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance


        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.PoolFire.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.PoolFire.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.PoolFire.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If


        '                Case 11 '用11表示bleve
        '                    Dim dlg As New frmBleve
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.Bleve.SourcePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Bleve.SourcePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 11
        '                        Project0.FAndB.Bleve = dlg.Bleve
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.Bleve.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.Bleve.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.Bleve.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If

        '                Case 12 '用12表示固体火灾
        '                    Dim dlg As New frmSolidFire
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.SolidFire.SourcePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.SolidFire.SourcePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 12
        '                        Project0.FAndB.SolidFire = dlg.SolidFire
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.SolidFire.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.SolidFire.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.SolidFire.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If

        '                Case 13 '用13表示喷射火
        '                    Dim dlg As New frmJet
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.jet.JetFire.SourcePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.jet.JetFire.SourcePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 13
        '                        Project0.FAndB.Jet = dlg.jet
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '初始化火灾爆炸的图形设置
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '设置解决方案中的为指针

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.Jet.JetFire.SourceName   '设置事故源的坐标
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.Jet.JetFire.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.Jet.JetFire.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '初始化
        '                        Me.Refresh() '重绘
        '                        '根据方案设置窗口
        '                        myFrmMain.ActiveMenu()
        '                        '更新关心点
        '                        RefreshCare()
        '                    End If
        '            End Select
        '    End Select
        'ElseIf Me.ContourPaint1.MouseMoveType = 5 Then '关心点

        '    Dim frmCarePoint As New frmAddCare
        '    frmCarePoint.txtX.Value = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '    frmCarePoint.txtY.Value = FormatNumber(point.Y, 0, TriState.True, TriState.False, )
        '    If Project0.PType = 1 Then '隐藏Z值
        '        frmCarePoint.LabelZ.Visible = False
        '        frmCarePoint.txtZ.Visible = False
        '    End If

        '    If frmCarePoint.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        If Project0.PType = 0 Then '泄漏
        '            ReDim Preserve Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length)
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1) = New DisPuff.CareReceptor

        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Name = frmCarePoint.txtName.Text
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D = New DisPuff.Point3D
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D.x = frmCarePoint.txtX.Value
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D.y = frmCarePoint.txtY.Value
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D.z = frmCarePoint.txtZ.Value

        '        Else '火灾爆炸
        '            ReDim Preserve Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length)
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1) = New FireBlast.CarePoint
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Dist = frmCarePoint.txtName.Text
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Rpoint = New FireBlast.Point2D
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Rpoint.x = frmCarePoint.txtX.Value
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Rpoint.y = frmCarePoint.txtY.Value

        '        End If
        '        '更新关心点
        '        RefreshCare()
        '    End If

        'End If
    End Sub
    
    ''' <summary>
    ''' 用关心点更新绘图
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshCare()


        Dim CareSymbols As DrawContour.CareSymbols = ContourPaint1.ContourPaintSetting.ContourPannel.Symbols.CareSymbols
        If Project0.PType = 0 Then '泄漏事故
            ReDim CareSymbols.ArrayCareName(Project0.Dis0.Forecast.CareReceptor.Length - 1)
            ReDim CareSymbols.ArrayCarePoint(Project0.Dis0.Forecast.CareReceptor.Length - 1)
            For i As Integer = 0 To Project0.Dis0.Forecast.CareReceptor.Length - 1
                CareSymbols.ArrayCareName(i) = Project0.Dis0.Forecast.CareReceptor(i).Name
                CareSymbols.ArrayCarePoint(i) = New DrawContour.Point3D()
                CareSymbols.ArrayCarePoint(i).x = Project0.Dis0.Forecast.CareReceptor(i).Point3D.x
                CareSymbols.ArrayCarePoint(i).y = Project0.Dis0.Forecast.CareReceptor(i).Point3D.y
            Next
            CareSymbols.Symbol.SymbolVisible = True
            'CareSymbols.Symbol.SymbolSign.SymbolColor = Color.Red
            'CareSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidSquare
            CareSymbols.IntialCareSymbols() '初始化
        Else '火灾爆炸
            ReDim CareSymbols.ArrayCareName(Project0.FAndB.carepoint.Length - 1)
            ReDim CareSymbols.ArrayCarePoint(Project0.FAndB.carepoint.Length - 1)
            For i As Integer = 0 To Project0.FAndB.carepoint.Length - 1
                CareSymbols.ArrayCareName(i) = Project0.FAndB.carepoint(i).Dist
                CareSymbols.ArrayCarePoint(i) = New DrawContour.Point3D()
                CareSymbols.ArrayCarePoint(i).x = Project0.FAndB.carepoint(i).Rpoint.x
                CareSymbols.ArrayCarePoint(i).y = Project0.FAndB.carepoint(i).Rpoint.y
            Next
            'CareSymbols.Symbol.SymbolVisible = True
            'CareSymbols.Symbol.SymbolSign.SymbolColor = Color.Red
            'CareSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidSquare
            CareSymbols.IntialCareSymbols() '初始化
        End If

        Me.Refresh() '重绘
    End Sub



    Private Sub ContourPaint1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ContourPaint1.MouseMove
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        Dim point As New PointF
        point.X = e.X
        point.Y = e.Y
        point = ContourPaint1.PointToLocation(point)
        myFrmMain.txtLocation.Text = "坐标: " & FormatNumber(point.X, 1, TriState.True, TriState.False, TriState.False) & " , " & FormatNumber(point.Y, 1, TriState.True, TriState.False, TriState.False)
    End Sub
    ''' <summary>
    ''' 初始化等值线图的最大值，最小值和网格点
    ''' </summary>
    ''' <param name="Xmin"></param>
    ''' <param name="Xstep"></param>
    ''' <param name="XCount"></param>
    ''' <param name="Ymin"></param>
    ''' <param name="Ystep"></param>
    ''' <param name="YCount"></param>
    ''' <remarks></remarks>
    Private Sub intialDrawData(ByVal Xmin As Integer, ByVal Xstep As Integer, ByVal XCount As Integer, ByVal Ymin As Integer, ByVal Ystep As Integer, ByVal YCount As Integer)
        '设置等值线区域x,y方向上的最大值、最小值及网格个数
        Me.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '设置起始坐标
        Me.ContourPaint1.ContourPaintSetting.m_Xmax = Xmin + (XCount - 1) * Xstep '设置X轴的终点坐标
        Me.ContourPaint1.ContourPaintSetting.m_nCols = XCount '设置数据的个数
        Me.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '设置起始坐标
        Me.ContourPaint1.ContourPaintSetting.m_Ymax = Ymin + (YCount - 1) * Ystep  '设置y轴的终点坐标
        Me.ContourPaint1.ContourPaintSetting.m_nRows = YCount '设置数据的个数
        '初始化网格数组
        ReDim Me.ContourPaint1.ContourPaintSetting.GridPoint(Me.ContourPaint1.ContourPaintSetting.m_nRows - 1, Me.ContourPaint1.ContourPaintSetting.m_nCols - 1)

        Me.Refresh()
    End Sub
    Private Sub intialFireDrawData(ByVal Xmin As Integer, ByVal XMax As Integer, ByVal Ymin As Integer, ByVal Ymax As Integer)
        '设置等值线区域x,y方向上的最大值、最小值及网格个数
        Me.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '设置起始坐标
        Me.ContourPaint1.ContourPaintSetting.m_Xmax = XMax '设置X轴的终点坐标
        Me.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '设置起始坐标
        Me.ContourPaint1.ContourPaintSetting.m_Ymax = Ymax  '设置y轴的终点坐标
        '初始化网格数组
        Me.ContourPaint1.ContourPaintSetting.InitialPaint()
        Me.Refresh()
    End Sub
    ''' <summary>
    ''' 设置等值线的图的属性值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPropety(ByVal Xstep As Integer, ByVal Ystep As Integer)
        With Me.ContourPaint1.ContourPaintSetting
            '初始化绘图面板
            .InitialPaint()
            '设置绘图面板数据
            .ResetCountData()
            '设置等值线图左轴、标题可见
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleName = "Y轴"
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleName = "X轴"
            '设置左轴的增加值,并使左刻度可见
            .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Ystep
            .ContourPannel.Axes.LeftAxis.MainAxisScale.ScaleVisible = True
            '设置底轴的增加值，并使底刻度可见
            .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = Xstep
            .ContourPannel.Axes.BottomAxis.MainAxisScale.ScaleVisible = True
            '设置右轴的增加值,并使左刻度不可见
            .ContourPannel.Axes.RightAxis.MainAxisScale.Increase = .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase
            .ContourPannel.Axes.RightAxis.MainAxisScale.ScaleVisible = False
            '设置顶轴增加值，并使底刻度不可见
            .ContourPannel.Axes.TopAxis.MainAxisScale.Increase = .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase
            .ContourPannel.Axes.TopAxis.MainAxisScale.ScaleVisible = False

            '设置左轴刻度的标注可见
            .ContourPannel.Axes.LeftAxis.AxisLabel.LabelVisible = True
            '设置底轴刻度的标注可见
            .ContourPannel.Axes.BottomAxis.AxisLabel.LabelVisible = True
            Me.Refresh()
        End With

    End Sub

    Private Sub IntialHurtData()
        With Me.ContourPaint1.ContourPaintSetting
            '设置事故名称
            ReDim .ArrayHurtName(-1)
            '设置事故值
            ReDim .ArrayHurtValue(-1)
            ReDim .ContourPannel.Contours.ContourValueSetting.ContourNames(-1)
            ReDim .ContourPannel.Contours.ContourValueSetting.ContourValue(-1)

        End With
        '重新计算等值线
        ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
        ContourPaint1.ContourPaintSetting.ResetCountData()
        ContourPaint1.Refresh()
    End Sub
#Region "计算结果绘图"
    
    ''' <summary>
    ''' 根据用户选择的下拉列表绘图
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshResult()
        If cmbRusult.Text = "瞬时浓度" Then
            If cmbMet.SelectedIndex >= 0 And cmbTime.SelectedIndex >= 0 Then
                '设置等值线的网格点
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.InstantaneousGridC(cmbMet.SelectedIndex, cmbTime.SelectedIndex, k, l)
                    Next
                Next
                '设置等值线名称和值的数组
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
                For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(n) = Project0.Dis0.Forecast.HurtConcentration(n).Name
                    Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(n) = FormatNumber(Project0.Dis0.Forecast.HurtConcentration(n).ConcentrationVale, 7)
                Next
                Me.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
                Me.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
                '设置伤害范围

                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
                For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    '设置事故名称
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                    'If strSlip = "滑移平均最大浓度" Then
                    '    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                    'Else
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                    'End If
                Next
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
                '重新计算等值线
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "滑移平均浓度" Then
            If cmbMet.SelectedIndex >= 0 Then
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.SlipGrid(cmbMet.SelectedIndex, k, l).MaxCon
                    Next
                Next
                '设置等值线名称和值的数组
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
                For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(n) = Project0.Dis0.Forecast.HurtConcentration(n).Name
                    Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(n) = FormatNumber(Project0.Dis0.Forecast.HurtConcentration(n).ConcentrationVale, 7)
                Next
                For i1 As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For j1 As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        For k1 As Integer = 0 To Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue.Length - 1
                            If Me.ContourPaint1.ContourPaintSetting.GridPoint(i1, j1) = Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(k1) Then
                                Me.ContourPaint1.ContourPaintSetting.GridPoint(i1, j1) = Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(k1) + 0.000001
                            End If
                        Next
                    Next
                Next
                Me.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
                Me.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
                '设置伤害范围

                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
                For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    '设置事故名称
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                    'If strSlip = "滑移平均最大浓度" Then
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                    'Else
                    'Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                    'End If
                Next
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
                '重新计算等值线
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "死亡百分率" Then
            If cmbMet.SelectedIndex >= 0 Then
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.D(cmbMet.SelectedIndex, k, l)
                    Next
                Next
                '设置等值线名称和值的数组
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(3 - 1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(3 - 1)
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(0) = "90%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(0) = 90
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(1) = "50%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(1) = 50
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(2) = "10%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(2) = 10

                Me.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
                Me.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
                '设置伤害范围

                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
                For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    '设置事故名称
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                    'Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                    'If strSlip = "滑移平均最大浓度" Then
                    '    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                    'Else
                    'Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                    'End If
                Next
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
                '重新计算等值线
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "个人风险值" Then

            For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                    Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.PersonalRisk(k, l) '个人风险
                Next
            Next
            '设置等值线名称和值的数组
            ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(6 - 1)
            ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(6 - 1)
            For i As Integer = 0 To Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue.Length - 1
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(i) = (1 / (10 ^ (i + 4))).ToString
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(i) = (1 / (10 ^ (i + 4)))
            Next

            Me.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
            Me.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
            '设置伤害范围

            ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
            ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
            For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                '设置事故名称
                ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                'Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                'If strSlip = "滑移平均最大浓度" Then
                '    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                'Else
                'Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                'End If
            Next
            Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
            Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
            '重新计算等值线
            Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
            Me.ContourPaint1.ContourPaintSetting.ResetCountData()
            Me.ContourPaint1.Refresh()
        End If

        


    End Sub
    Private Sub cmbRusult_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRusult.SelectedIndexChanged
        If cmbRusult.Text = "瞬时浓度" Then '瞬时浓度
            cmbTime.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                cmbTime.Items.Add(Project0.Dis0.Forecast.OutPut.ForeStart + i * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
            Next
            If cmbTime.Items.Count > 0 Then
                cmbTime.SelectedIndex = 0
            End If
            cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1 '气象条件
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            If cmbMet.Items.Count > 0 Then
                cmbMet.SelectedIndex = 0
            End If
        ElseIf cmbRusult.Text = "死亡百分率" Or cmbRusult.Text = "滑移平均浓度" Then
            cmbTime.Items.Clear()
            cmbTime.Items.Add("所有")
            cmbTime.SelectedIndex = 0
            cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1 '气象条件
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            cmbMet.Items.Add("所有")
            cmbMet.SelectedIndex = 0
        ElseIf cmbRusult.Text = "个人风险值" Then
            cmbTime.Items.Clear()
            cmbTime.Items.Add("所有")
            cmbTime.SelectedIndex = 0
            cmbMet.Items.Clear()
            cmbMet.Items.Add("所有")
            cmbMet.SelectedIndex = 0
        End If
        RefreshResult() ' 根据用户选择的下拉列表绘图
    End Sub

    Private Sub cmbMet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMet.SelectedIndexChanged
        RefreshResult() ' 根据用户选择的下拉列表绘图

    End Sub

    Private Sub cmbTime_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTime.SelectedIndexChanged
        RefreshResult() ' 根据用户选择的下拉列表绘图

    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshResult() ' 根据用户选择的下拉列表绘图

    End Sub
#End Region



    Private Sub cmbRusult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRusult.Click

    End Sub
End Class
