Imports HaGisPack
Public Class GisHelper

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
