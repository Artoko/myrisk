Imports HaGisPack
Public Class frmResultMapGis
    Public GisManager As GisManager
    Private m_MdiParentForm As frmResultMain
    '主要对应的项目管理器
    Public m_Proj As Project
    Public Function InitWindow(ByRef proj As Project, ByVal MdiParentForm As frmResultMain) As Boolean
        m_Proj = proj
        Me.GisManager = New GisManager(Me.Map1)
        m_MdiParentForm = MdiParentForm
        Me.GisManager.UISys.PropertyGrid = MdiParentForm.frmResultProperty.PropertyGrid1
        Me.GisManager.UISys.Tree = MdiParentForm.frmResultLayersManage.TreeView1
    End Function

    ''' <summary>
    ''' 根据现有项目情况构建图像显示系统
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BuildLayers()

        GisHelper.CreatGridLayer(m_Proj, Me.GisManager)



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
    '''　创建网格图层
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CreatGridLayer(ByRef proj As Project, ByRef gis As GisManager)
        Dim mPath As String = proj.GetProjWorkPath
        gis.NewProj(mPath)
        Dim gridLayer As New FDGridLayer("grid")
        gridLayer.descString = "网格"

        gis.LayerSys.AddLayer(gridLayer)

        Dim mGrid As New DisPuff.Grid
        mGrid = proj.Dis0.Forecast.Grid
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
        gis.LayerSys.AddLayer(PointLayer)

        Dim LineLayer As New FELineLayer("LineSource")
        LineLayer.descString = "线源"
        gis.LayerSys.AddLayer(LineLayer)

        Dim AreaLayer As New FEPolygonLayer("AreaSource")
        AreaLayer.descString = "面源"
        gis.LayerSys.AddLayer(AreaLayer)

        Dim VolumeLayer As New FEPolygonLayer("VolumeSource")
        VolumeLayer.descString = "体源"
        gis.LayerSys.AddLayer(VolumeLayer)

        Dim DiscreteLayer As New FEPointLayer("DiscreteSource")
        DiscreteLayer.descString = "接受点"
        CType(DiscreteLayer.PointSymbol, DotSpatial.Symbology.PointSymbolizer).SetFillColor(Color.Red)

        gis.LayerSys.AddLayer(DiscreteLayer)


    End Sub


End Class