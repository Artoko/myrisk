Imports HaGisPack
Public Class frmResultMapGis
    Public GisManager As GisManager
    Private m_MdiParentForm As frmResultMain
    '主要对应的项目管理器
    Public m_Proj As Project


    ''' <summary>
    ''' 用于保存较老的等值线层的Key，以便于叠加或删除等值线层
    ''' </summary>
    ''' <remarks></remarks>
    Private m_OldContourdKey As String
    ''' <summary>
    ''' 用于保存较老的
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OldContourdKey() As String
        Get
            Return Me.m_OldContourdKey
        End Get
        Set(ByVal value As String)
            Me.m_OldContourdKey = value
        End Set
    End Property
    Public Function InitWindow(ByRef proj As Project, ByVal MdiParentForm As frmResultMain) As Boolean
        m_Proj = proj
        Me.GisManager = New GisManager(Me.Map1)
        m_MdiParentForm = MdiParentForm
        Me.GisManager.UISys.PropertyGrid = MdiParentForm.frmResultProperty.PropertyGrid1
        Me.GisManager.UISys.Tree = MdiParentForm.frmResultLayersManage.TreeView1
        BuildLayers()
    End Function

    ''' <summary>
    ''' 根据现有项目情况构建图像显示系统
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BuildLayers()

        Dim mPath As String = Project0.GetProjWorkPath
        Me.GisManager.NewProj(mPath)
        Dim gridLayer As New FDGridLayer("grid")
        gridLayer.descString = "网格"

        Me.GisManager.LayerSys.AddLayer(gridLayer)

        Dim mGrid As New DisPuff.Grid
        mGrid = Project_Calculated.Dis0.Forecast.Grid
        gridLayer.LeftBottomX = mGrid.MinX
        gridLayer.LeftBottomY = mGrid.MinY
        gridLayer.XCells = mGrid.CountX
        gridLayer.YCells = mGrid.CountY
        gridLayer.YUnit = mGrid.StepX
        gridLayer.XUnit = mGrid.StepY

        gridLayer.MainScaleLength = 100
        gridLayer.ViceScaleLength = 50



        Dim PointLayer As New FEPointLayer("PointSource")
        PointLayer.descString = "点源"

        Dim LineLayer As New FELineLayer("LineSource")
        LineLayer.descString = "线源"

        Dim AreaLayer As New FEPolygonLayer("AreaSource")
        AreaLayer.descString = "面源"

        Dim VolumeLayer As New FEPolygonLayer("VolumeSource")
        VolumeLayer.descString = "体源"

        Dim cl As FCompoundLayer = New FCompoundLayer("Source")
        cl.descString = "事故源"
        cl.AddChild(VolumeLayer)
        cl.AddChild(AreaLayer)
        cl.AddChild(LineLayer)
        cl.AddChild(PointLayer)
        Me.GisManager.LayerSys.AddLayer(cl)

        Dim DiscreteLayer As New FEPointLayer("DiscreteSource")
        DiscreteLayer.descString = "接受点"
        CType(DiscreteLayer.PointSymbol, DotSpatial.Symbology.PointSymbolizer).SetFillColor(Color.Red)

        Me.GisManager.LayerSys.AddLayer(DiscreteLayer)


        Dim contourlayer As FDContourLayer = New FDContourLayer("contour")
        contourlayer.descString = "等值线"
        cl.AddChild(contourlayer)




    End Sub
    ''' <summary>
    ''' 当项目发生变化时，引用此函数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OnProjChanged()
        Me.ClearAll()
        Me.BuildLayers()
    End Sub

    ''' <summary>
    ''' 清空窗体到原始状态，卸载所有图像
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ClearAll()

    End Sub

    ''' <summary>
    ''' 添加图形
    ''' </summary>
    ''' <param name="shp"></param>
    ''' <remarks></remarks>
    Public Sub AddShape(ByVal shp As FShape)

        'GisHelper.AddShape(Me.m_Proj, shp, Me.GisManager)

    End Sub

    Public Sub RemoveShape(ByVal shp As FShape)


        'GisHelper.RemoveShape(Me.m_Proj, shp, Me.GisManager)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <param name="nRow"></param>
    ''' <param name="Ymin"></param>
    ''' <param name="Ystep"></param>
    ''' <param name="nCol"></param>
    ''' <param name="Xmin"></param>
    ''' <param name="xstep"></param>
    ''' <param name="OffsetX"></param>
    ''' <param name="OffsetY"></param>
    ''' <param name="ContourKey"></param>
    ''' <param name="IsSave"></param>
    ''' <param name="dblA"></param>
    ''' <remarks></remarks>
    Public Sub SetContour(ByVal Grid(,) As Double, ByVal nRow As Double, ByVal Ymin As Double, ByVal Ystep As Double _
                          , ByVal nCol As Double, ByVal Xmin As Double, ByVal xstep As Double, ByVal OffsetX As Double _
                          , ByVal OffsetY As Double, ByVal ContourKey As String, ByVal IsSave As Boolean, ByVal dblA() As Double)
        Dim MyMainFrm As frmMain = My.Application.ApplicationContext.MainForm
        Try
            Dim Index As Integer = 0
            '先删除旧的等值线层
            Me.GisManager.LayerSys.SaveLayer(Me.OldContourdKey, Me.m_Proj.GetProjWorkPath & "Post\")
            If OldContourdKey IsNot Nothing AndAlso OldContourdKey <> "" Then
                Me.GisManager.LayerSys.RemoveLayer(Me.OldContourdKey)
            End If
            Dim grd As FDGridLayer = Me.GisManager.LayerSys.GetLayer("grid")
            grd.SetGridProperty(nCol - 1, nRow - 1, Xmin, Ymin, xstep, Ystep, 0, 0)
            '如果用户已经保存了图层，就导入，否则就生成新的。
            'If Me.GisManager.LayerSys.IsSingleLayerSaved(ContourKey) And Me.m_manager.IsSingleLayerExist(ContourKey) And IsSave = True Then
            '    If Me.m_manager.LoadSingleLayer(ContourKey) = True Then '如果载入成功，则返回，否则创建

            '        '缺少等值线的UTM坐标设置
            '        If Index <= 0 Then
            '            Index = PublicVal.BackImage0.InsertImageCollection.Count
            '            Index += AermodProject0.Aermap.Control.DataFile.Length
            '        End If
            '        MyMainFrm.frmAnalyse.m_tree.MoveLayerPosition(Me.m_manager.GetLayerCount - 1, Index)
            '        Me.OldContourdKey = ContourKey
            '        Exit Sub
            '    End If
            'End If


            '等值线
            Dim conLayer As FDContourLayer = New FDContourLayer(ContourKey) ' = PublicVal.CommonDrawProperty._Contour.CopyLayerProp
            Me.GisManager.LayerSys.AddLayer(conLayer)
            '缺少等值线的UTM坐标设置
            'If Index <= 0 Then
            '    Index = PublicVal.BackImage0.InsertImageCollection.Count
            '    Index += AermodProject0.Aermap.Control.DataFile.Length
            'End If
            'MyMainFrm.frmAnalyse.m_tree.MoveLayerPosition(Me.m_manager.GetLayerCount - 1, Index)
            conLayer.descString = "等值线"
            '图例样式
            'conLayer.IsLengendTextFormat = True
            'conLayer.LTextFormatNum = 5
            Me.OldContourdKey = ContourKey

            '等值线
            'Dim con As SDSContourLayer
            'frmM.frmGis_Map.m_manager.GetLayer(ContourFileKey, con)
            conLayer.MyContours = New DrawContour.Contours
            conLayer.MyContours.GridPoint = Grid
            conLayer.MyContours.nRow = nRow
            conLayer.MyContours.nCol = nCol

            conLayer.MyContours.Xmin = CInt(Xmin + 0)
            conLayer.MyContours.Xmax = CInt(Xmin + (nCol - 1) * xstep)
            conLayer.MyContours.Ymin = CInt(Ymin + 0)
            conLayer.MyContours.Ymax = CInt(Ymin + (nRow - 1) * Ystep)

            'con.MyContours.Xmin = Xmin
            'con.MyContours.Xmax = Xmax
            'con.MyContours.Ymin = Ymin
            'con.MyContours.Ymax = Ymax
            conLayer.IsShowLegend = True
            Dim lns As List(Of ContourLine)
            'Dim cth As New CTHelperV2(conLayer)
            Dim ls As New List(Of Double)
            For i As Integer = 0 To dblA.Length - 1
                ls.Add(dblA(i))
            Next
            'lns = cth.GetResultList(ls)

            'conLayer. = lns

            conLayer.ContourLineList = New List(Of ContourLine)
            Dim CL As ContourLine
            For i As Integer = 0 To dblA.Length - 1
                CL = New ContourLine()
                CL.ContourLineValue = dblA(i)
                conLayer.ContourLineList.Add(CL)
            Next

        Catch ex As Exception
        End Try
        Me.Refresh()
    End Sub


    Public Function GetContourValue(ByVal Grid(,) As Double, ByVal nRow As Double, ByVal Ymin As Double, ByVal Ymax As Double _
                         , ByVal nCol As Double, ByVal Xmin As Double, ByVal Xmax As Double) As Double()
        Dim Max As Double = -999999999
        Dim Min As Double = 999999999
        For i As Integer = 0 To nRow - 1
            For j As Integer = 0 To nCol - 1
                If Min > Grid(i, j) Then
                    Min = Grid(i, j)
                End If
                If Max < Grid(i, j) Then
                    Max = Grid(i, j)
                End If
            Next
        Next

        '设置等值线名称和值的数组
        Dim n As Integer = 20
        Dim Increase As Double = 0
        Dim dblA(-1) As Double

        If Max <> -999999999 And Max > 0 Then
            'Min = Max / 20
            Max = Max - Increase * n / 2
            Increase = (Max - Min) / n
            Dim j As Integer = 0
            For j = 0 To 100 '选取整数来分析
                If CInt(Increase * 10 ^ j) > 0 Then
                    Increase = CInt(Increase * 10 ^ j) / 10 ^ j
                    Exit For
                End If
            Next

            Min = Min + Increase * n / 8

            Min = FormatNumber(Min, j)
            For i As Integer = 0 To n - 1 - 10
                Dim dblValue As Double = Min + Increase * i
                ReDim Preserve dblA(dblA.Length)
                dblA(dblA.Length - 1) = dblValue
                If dblA.Length >= n Then
                    Exit For
                End If
            Next
        End If
        Return dblA
    End Function

    ''' <summary>
    ''' 根据网格数据显示等值线图
    ''' </summary>
    ''' <param name="Grid">网格数据，二维数组</param>
    ''' <param name="Xmin">X方向最小值</param>
    ''' <param name="Xdelta">X方向步长</param>
    ''' <param name="Xnum">X方向网格点数</param>
    ''' <param name="Ymin">Y方向最小值</param>
    ''' <param name="Ydelta">Y方向步长</param>
    ''' <param name="Ynum">Y方向最小值</param>
    ''' <param name="ContourKey">等值线图层的关键字</param>
    ''' <param name="OffsetX">X方向的偏移量</param>
    ''' <param name="OffsetY">Y方向的偏移量</param>
    ''' <param name="IsSave">是否是保存等值线图</param>
    ''' <remarks></remarks>
    Public Sub ChangeContours(ByVal Grid(,) As Double, ByVal Xmin As Double, ByVal Xdelta As Double, ByVal Xnum As Double _
                          , ByVal Ymin As Double, ByVal Ydelta As Double, ByVal Ynum As Double _
                          , ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ContourKey As String, ByVal IsSave As Boolean)
        Dim dblA() As Double = GetContourValue(Grid, Ynum, Ymin, Ymin + (Ynum - 1) * Ydelta _
                    , Xnum, Xmin, Xmin + (Xnum - 1) * Xdelta)
        Me.SetContour(Grid, Ynum, Ymin, Ydelta _
                    , Xnum, Xmin, Xdelta, OffsetX, OffsetY, ContourKey, IsSave, dblA)

    End Sub

    Private Sub frmResultMapGis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class