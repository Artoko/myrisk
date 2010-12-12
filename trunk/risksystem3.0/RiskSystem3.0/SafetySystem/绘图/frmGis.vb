Imports HaGisPack
Public Class frmGis
    Public GisManager As GisManager


    '主要对应的项目管理器
    Public m_Proj As Project


    Public Function InitWindow(ByRef proj As Project) As Boolean
        m_Proj = proj
        AddHandler m_Proj.ProjChanged, AddressOf Me.OnProjChanged
        Me.GisManager = New GisManager(Me.Map1)
        Dim frmMain As frmMain
        frmMain = Me.MdiParent

        Me.GisManager.UISys.PropertyGrid = frmMain.m_frmprop.PropertyGrid1
        Me.GisManager.UISys.Tree = frmMain.m_frmMapLayerManage.TreeView1

        AddHandler Me.GisManager.MFSys.ShapeAdded, AddressOf Me.AddShape
        AddHandler Me.GisManager.MFSys.ShapeRemoved, AddressOf Me.RemoveShape
        'AddHandler Me.GisManager.MFSys.ShapeChanged, AddressOf Me.ChangeShape



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


    Private Sub frmGis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class