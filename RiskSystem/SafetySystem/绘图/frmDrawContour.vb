Public Class frmDrawContour
    Private m_AddProject As Boolean = 0 '�����Ŀ

    Private m_LeakType As Integer '����й©������
    Private m_FireBlastType As Integer '���ֱ�ը����


    ''' <summary>
    ''' �����Ŀ��־��0����ӣ�1���
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
    ''' ����й©������
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
    ''' ���ֱ�ը����
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
    ''' ͨ���������ʾԤ�ⴰ��
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
    ''' ��ӷ���
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
        '        Case 0 'й©ģ��
        '            Select Case Me.m_LeakType
        '                Case 0 '����й©��ɢģ��
        '                    Dim dlgGas As New frmDisGasLeak  '����й©��ɢģ��
        '                    dlgGas.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgGas.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgGas.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, )
        '                    dlgGas.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgGas.ShowDialog = Windows.Forms.DialogResult.OK Then

        '                        Project0.Dis0 = dlgGas.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 0 '����й©
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��
        '                        '����ͼ�е�й©Դλ��
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If

        '                Case 1 'Һ��й©
        '                    Dim dlgLiquid As New frmDisLiquidLeak   'Һ��й©��ɢģ��
        '                    dlgLiquid.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgLiquid.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquid.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquid.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgLiquid.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgLiquid.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 1 'Һ��й©
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��
        '                        '����ͼ�е�й©Դλ��
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '                Case 2 '������й©��ɢģ��
        '                    Dim dlgTwo As New frmDisTwo    '������й©��ɢģ��
        '                    dlgTwo.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgTwo.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgTwo.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgTwo.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgTwo.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgTwo.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 2 '������й©
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��
        '                        '����ͼ�е�й©Դλ��
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '                Case 3 '������������
        '                    Dim dlgGasboo As New frmGasBoo     '������������
        '                    dlgGasboo.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgGasboo.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgGasboo.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgGasboo.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgGasboo.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgGasboo.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 3 '������������
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��
        '                        '����ͼ�е�й©Դλ��
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '                Case 4 'Һ����������
        '                    Dim dlgLiquidboo As New frmDisLiquidBoo      'Һ����������
        '                    dlgLiquidboo.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlgLiquidboo.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquidboo.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlgLiquidboo.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlgLiquidboo.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlgLiquidboo.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 4 'Һ����������
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��
        '                        '����ͼ�е�й©Դλ��
        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If

        '                Case 10
        '                    Dim dlg As New frmDisFu '�ֶ���ɢģ��
        '                    dlg.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlg.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlg.Dis
        '                        Project0.Dis0.IntialSource.LeakType = 10 '�ֶ���ɢģ��
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '                Case 11
        '                    Dim dlg As New frmHeavy  '˲ʱ������ɢģ��
        '                    dlg.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlg.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlg.Dis
        '                        Project0.Dis0.IntialSource.IsHeavy = True '����������ģ��
        '                        Project0.Dis0.Heavy.HeavyType = 1 '��ʾ����Ϊboxģ��

        '                        Project0.Dis0.IntialSource.LeakType = 11 '˲ʱ������ɢģ��
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If

        '                Case 12
        '                    Dim dlg As New frmSlabHeavy  '����������ɢģ��
        '                    dlg.Dis.Forecast.Grid = Project0.Dis0.Forecast.Grid
        '                    dlg.Dis.IntialSource.Coordinate.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.IntialSource.Coordinate.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.Dis.Forecast.CareReceptor = Project0.Dis0.Forecast.CareReceptor
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.Dis0 = dlg.Dis
        '                        Project0.Dis0.IntialSource.IsHeavy = True '����������ģ��
        '                        Project0.Dis0.Heavy.HeavyType = 2 '��ʾ����Ϊslabģ��

        '                        Project0.Dis0.IntialSource.LeakType = 12 'slab������ɢģ��
        '                        intialDrawData(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                        , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)
        '                        SetPropety(Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.StepY)

        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(0).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '            End Select

        '        Case 1 '��ըģ��

        '            Select Case Me.m_FireBlastType
        '                Case 0 '�����Ʊ�ը��TNT������
        '                    Dim dlg As New frmUVCE   'TNT������
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.UVCE.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.UVCE.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        '                        Project0.FAndB.FType = 0
        '                        Project0.FAndB.UVCE = dlg.UVCE
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.UVCE.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0) = New DrawContour.Point3D()
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.UVCE.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.UVCE.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '                Case 1 '�����౬ը
        '                    Dim dlg As New frmMatialTNT    'TNT������
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.MaterialTNT.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.MaterialTNT.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint

        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 1
        '                        Project0.FAndB.MaterialTNT = dlg.MaterialTNT
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance


        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.MaterialTNT.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.MaterialTNT.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.MaterialTNT.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()

        '                    End If

        '                Case 2 '����վ��ը
        '                    Dim dlg As New frmGasStation     'TNT������
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.GasStation.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.GasStation.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 2
        '                        Project0.FAndB.GasStation = dlg.GasStation
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance


        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.GasStation.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.GasStation.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.GasStation.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()

        '                    End If

        '                Case 3 '����ը
        '                    Dim dlg As New frmPhysicsExplode    'TNT������
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.PhysicsExplode.SoucePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.PhysicsExplode.SoucePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 3
        '                        Project0.FAndB.PhysicsExplode = dlg.PhysicsExplode
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance

        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.PhysicsExplode.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.PhysicsExplode.SoucePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.PhysicsExplode.SoucePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If


        '                Case 10 '��10��ʾ�����¹��еĳػ�
        '                    Dim dlg As New frmPoolFire      'TNT������
        '                    dlg.Grid = Project0.FAndB.Grid
        '                    dlg.PoolFire.SourcePoint.x = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.PoolFire.SourcePoint.y = FormatNumber(point.Y, 0, TriState.True, TriState.False, TriState.False)
        '                    dlg.ArrayDistance = Project0.FAndB.carepoint
        '                    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                        Project0.FAndB.FType = 10
        '                        Project0.FAndB.PoolFire = dlg.PoolFire
        '                        Project0.FAndB.Grid = dlg.Grid
        '                        Project0.FAndB.carepoint = dlg.ArrayDistance


        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.PoolFire.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.PoolFire.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.PoolFire.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If


        '                Case 11 '��11��ʾbleve
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

        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.Bleve.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.Bleve.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.Bleve.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If

        '                Case 12 '��12��ʾ�������
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

        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.SolidFire.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.SolidFire.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.SolidFire.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If

        '                Case 13 '��13��ʾ�����
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

        '                        IntialHurtData() '��ʼ�����ֱ�ը��ͼ������
        '                        intialFireDrawData(Project0.FAndB.Grid.MinX, Project0.FAndB.Grid.MaxX, Project0.FAndB.Grid.MinY, Project0.FAndB.Grid.MaxY)
        '                        SetPropety(Project0.FAndB.Grid.StepX, Project0.FAndB.Grid.StepY)
        '                        myFrmMain.Result.TreeView1.Nodes.Clear()
        '                        myFrmMain.SolutionExplorer.ExplorerBar1.Groups(1).Items(0).Checked = True '���ý�������е�Ϊָ��

        '                        Dim PolluteSymbols As DrawContour.PolluteSymbols = Me.ContourPaint1.ContourPannel.Symbols.PolluteSymbol
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0)
        '                        ReDim PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0)

        '                        PolluteSymbols.PointSourceSymbols.ArrayPolluteName(0) = Project0.FAndB.Jet.JetFire.SourceName   '�����¹�Դ������
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).x = Project0.FAndB.Jet.JetFire.SourcePoint.x
        '                        PolluteSymbols.PointSourceSymbols.ArrayPollutePoint(0).y = Project0.FAndB.Jet.JetFire.SourcePoint.y
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolVisible = True
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolColor = Color.Blue
        '                        PolluteSymbols.PointSourceSymbols.Symbol.SymbolSign.SymbolShape.SymbolShapeStyle = DrawContour.SymbolShapeStyle.SolidCircle
        '                        PolluteSymbols.PointSourceSymbols.IntialPolluteSymbols()  '��ʼ��
        '                        Me.Refresh() '�ػ�
        '                        '���ݷ������ô���
        '                        myFrmMain.ActiveMenu()
        '                        '���¹��ĵ�
        '                        RefreshCare()
        '                    End If
        '            End Select
        '    End Select
        'ElseIf Me.ContourPaint1.MouseMoveType = 5 Then '���ĵ�

        '    Dim frmCarePoint As New frmAddCare
        '    frmCarePoint.txtX.Value = FormatNumber(point.X, 0, TriState.True, TriState.False, TriState.False)
        '    frmCarePoint.txtY.Value = FormatNumber(point.Y, 0, TriState.True, TriState.False, )
        '    If Project0.PType = 1 Then '����Zֵ
        '        frmCarePoint.LabelZ.Visible = False
        '        frmCarePoint.txtZ.Visible = False
        '    End If

        '    If frmCarePoint.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        If Project0.PType = 0 Then 'й©
        '            ReDim Preserve Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length)
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1) = New DisPuff.CareReceptor

        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Name = frmCarePoint.txtName.Text
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D = New DisPuff.Point3D
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D.x = frmCarePoint.txtX.Value
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D.y = frmCarePoint.txtY.Value
        '            Project0.Dis0.Forecast.CareReceptor(Project0.Dis0.Forecast.CareReceptor.Length - 1).Point3D.z = frmCarePoint.txtZ.Value

        '        Else '���ֱ�ը
        '            ReDim Preserve Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length)
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1) = New FireBlast.CarePoint
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Dist = frmCarePoint.txtName.Text
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Rpoint = New FireBlast.Point2D
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Rpoint.x = frmCarePoint.txtX.Value
        '            Project0.FAndB.carepoint(Project0.FAndB.carepoint.Length - 1).Rpoint.y = frmCarePoint.txtY.Value

        '        End If
        '        '���¹��ĵ�
        '        RefreshCare()
        '    End If

        'End If
    End Sub
    
    ''' <summary>
    ''' �ù��ĵ���»�ͼ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshCare()


        Dim CareSymbols As DrawContour.CareSymbols = ContourPaint1.ContourPaintSetting.ContourPannel.Symbols.CareSymbols
        If Project0.PType = 0 Then 'й©�¹�
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
            CareSymbols.IntialCareSymbols() '��ʼ��
        Else '���ֱ�ը
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
            CareSymbols.IntialCareSymbols() '��ʼ��
        End If

        Me.Refresh() '�ػ�
    End Sub



    Private Sub ContourPaint1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ContourPaint1.MouseMove
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        Dim point As New PointF
        point.X = e.X
        point.Y = e.Y
        point = ContourPaint1.PointToLocation(point)
        myFrmMain.txtLocation.Text = "����: " & FormatNumber(point.X, 1, TriState.True, TriState.False, TriState.False) & " , " & FormatNumber(point.Y, 1, TriState.True, TriState.False, TriState.False)
    End Sub
    ''' <summary>
    ''' ��ʼ����ֵ��ͼ�����ֵ����Сֵ�������
    ''' </summary>
    ''' <param name="Xmin"></param>
    ''' <param name="Xstep"></param>
    ''' <param name="XCount"></param>
    ''' <param name="Ymin"></param>
    ''' <param name="Ystep"></param>
    ''' <param name="YCount"></param>
    ''' <remarks></remarks>
    Private Sub intialDrawData(ByVal Xmin As Integer, ByVal Xstep As Integer, ByVal XCount As Integer, ByVal Ymin As Integer, ByVal Ystep As Integer, ByVal YCount As Integer)
        '���õ�ֵ������x,y�����ϵ����ֵ����Сֵ���������
        Me.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '������ʼ����
        Me.ContourPaint1.ContourPaintSetting.m_Xmax = Xmin + (XCount - 1) * Xstep '����X����յ�����
        Me.ContourPaint1.ContourPaintSetting.m_nCols = XCount '�������ݵĸ���
        Me.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '������ʼ����
        Me.ContourPaint1.ContourPaintSetting.m_Ymax = Ymin + (YCount - 1) * Ystep  '����y����յ�����
        Me.ContourPaint1.ContourPaintSetting.m_nRows = YCount '�������ݵĸ���
        '��ʼ����������
        ReDim Me.ContourPaint1.ContourPaintSetting.GridPoint(Me.ContourPaint1.ContourPaintSetting.m_nRows - 1, Me.ContourPaint1.ContourPaintSetting.m_nCols - 1)

        Me.Refresh()
    End Sub
    Private Sub intialFireDrawData(ByVal Xmin As Integer, ByVal XMax As Integer, ByVal Ymin As Integer, ByVal Ymax As Integer)
        '���õ�ֵ������x,y�����ϵ����ֵ����Сֵ���������
        Me.ContourPaint1.ContourPaintSetting.m_Xmin = Xmin '������ʼ����
        Me.ContourPaint1.ContourPaintSetting.m_Xmax = XMax '����X����յ�����
        Me.ContourPaint1.ContourPaintSetting.m_Ymin = Ymin '������ʼ����
        Me.ContourPaint1.ContourPaintSetting.m_Ymax = Ymax  '����y����յ�����
        '��ʼ����������
        Me.ContourPaint1.ContourPaintSetting.InitialPaint()
        Me.Refresh()
    End Sub
    ''' <summary>
    ''' ���õ�ֵ�ߵ�ͼ������ֵ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPropety(ByVal Xstep As Integer, ByVal Ystep As Integer)
        With Me.ContourPaint1.ContourPaintSetting
            '��ʼ����ͼ���
            .InitialPaint()
            '���û�ͼ�������
            .ResetCountData()
            '���õ�ֵ��ͼ���ᡢ����ɼ�
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleVisible = True
            .ContourPannel.Axes.LeftAxis.AxisTitle.TitleName = "Y��"
            .ContourPannel.Axes.BottomAxis.AxisTitle.TitleName = "X��"
            '�������������ֵ,��ʹ��̶ȿɼ�
            .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase = Ystep
            .ContourPannel.Axes.LeftAxis.MainAxisScale.ScaleVisible = True
            '���õ��������ֵ����ʹ�׿̶ȿɼ�
            .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase = Xstep
            .ContourPannel.Axes.BottomAxis.MainAxisScale.ScaleVisible = True
            '�������������ֵ,��ʹ��̶Ȳ��ɼ�
            .ContourPannel.Axes.RightAxis.MainAxisScale.Increase = .ContourPannel.Axes.LeftAxis.MainAxisScale.Increase
            .ContourPannel.Axes.RightAxis.MainAxisScale.ScaleVisible = False
            '���ö�������ֵ����ʹ�׿̶Ȳ��ɼ�
            .ContourPannel.Axes.TopAxis.MainAxisScale.Increase = .ContourPannel.Axes.BottomAxis.MainAxisScale.Increase
            .ContourPannel.Axes.TopAxis.MainAxisScale.ScaleVisible = False

            '��������̶ȵı�ע�ɼ�
            .ContourPannel.Axes.LeftAxis.AxisLabel.LabelVisible = True
            '���õ���̶ȵı�ע�ɼ�
            .ContourPannel.Axes.BottomAxis.AxisLabel.LabelVisible = True
            Me.Refresh()
        End With

    End Sub

    Private Sub IntialHurtData()
        With Me.ContourPaint1.ContourPaintSetting
            '�����¹�����
            ReDim .ArrayHurtName(-1)
            '�����¹�ֵ
            ReDim .ArrayHurtValue(-1)
            ReDim .ContourPannel.Contours.ContourValueSetting.ContourNames(-1)
            ReDim .ContourPannel.Contours.ContourValueSetting.ContourValue(-1)

        End With
        '���¼����ֵ��
        ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
        ContourPaint1.ContourPaintSetting.ResetCountData()
        ContourPaint1.Refresh()
    End Sub
#Region "��������ͼ"
    
    ''' <summary>
    ''' �����û�ѡ��������б��ͼ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshResult()
        If cmbRusult.Text = "˲ʱŨ��" Then
            If cmbMet.SelectedIndex >= 0 And cmbTime.SelectedIndex >= 0 Then
                '���õ�ֵ�ߵ������
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.InstantaneousGridC(cmbMet.SelectedIndex, cmbTime.SelectedIndex, k, l)
                    Next
                Next
                '���õ�ֵ�����ƺ�ֵ������
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(Project0.Dis0.Forecast.HurtConcentration.Length - 1)
                For n As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(n) = Project0.Dis0.Forecast.HurtConcentration(n).Name
                    Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(n) = FormatNumber(Project0.Dis0.Forecast.HurtConcentration(n).ConcentrationVale, 7)
                Next
                Me.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
                Me.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
                '�����˺���Χ

                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
                For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    '�����¹�����
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                    'If strSlip = "����ƽ�����Ũ��" Then
                    '    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                    'Else
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                    'End If
                Next
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
                '���¼����ֵ��
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "����ƽ��Ũ��" Then
            If cmbMet.SelectedIndex >= 0 Then
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.SlipGrid(cmbMet.SelectedIndex, k, l).MaxCon
                    Next
                Next
                '���õ�ֵ�����ƺ�ֵ������
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
                '�����˺���Χ

                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
                For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    '�����¹�����
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                    'If strSlip = "����ƽ�����Ũ��" Then
                    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                    'Else
                    'Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                    'End If
                Next
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
                '���¼����ֵ��
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "�����ٷ���" Then
            If cmbMet.SelectedIndex >= 0 Then
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.D(cmbMet.SelectedIndex, k, l)
                    Next
                Next
                '���õ�ֵ�����ƺ�ֵ������
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
                '�����˺���Χ

                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
                For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                    '�����¹�����
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                    ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                    'Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                    'If strSlip = "����ƽ�����Ũ��" Then
                    '    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                    'Else
                    'Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                    'End If
                Next
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
                '���¼����ֵ��
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "���˷���ֵ" Then

            For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                    Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.PersonalRisk(k, l) '���˷���
                Next
            Next
            '���õ�ֵ�����ƺ�ֵ������
            ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(6 - 1)
            ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(6 - 1)
            For i As Integer = 0 To Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue.Length - 1
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(i) = (1 / (10 ^ (i + 4))).ToString
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(i) = (1 / (10 ^ (i + 4)))
            Next

            Me.ContourPaint1.ContourPaintSetting.m_nRows = Project0.Dis0.Forecast.Grid.CountY
            Me.ContourPaint1.ContourPaintSetting.m_nCols = Project0.Dis0.Forecast.Grid.CountX
            '�����˺���Χ

            ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(-1)
            ReDim Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(-1)
            For m As Integer = 0 To Project0.Dis0.Forecast.HurtConcentration.Length - 1
                '�����¹�����
                ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(Me.ContourPaint1.ContourPaintSetting.ArrayHurtName.Length)
                ReDim Preserve Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue.Length)
                'Me.ContourPaint1.ContourPaintSetting.ArrayHurtName(m) = Project0.Dis0.Forecast.HurtConcentration(m).Name
                'If strSlip = "����ƽ�����Ũ��" Then
                '    Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).Slip.HurtLengthSlip(m)
                'Else
                'Me.ContourPaint1.ContourPaintSetting.ArrayHurtValue(m) = Project0.Dis0.Results.MetResults(cmbMet.SelectedIndex).ForeTimeResults(cmbTime.SelectedIndex).HurtLength(m)
                'End If
            Next
            Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.x0 = Project0.Dis0.IntialSource.Coordinate.x
            Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.y0 = Project0.Dis0.IntialSource.Coordinate.y
            '���¼����ֵ��
            Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
            Me.ContourPaint1.ContourPaintSetting.ResetCountData()
            Me.ContourPaint1.Refresh()
        End If

        


    End Sub
    Private Sub cmbRusult_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRusult.SelectedIndexChanged
        If cmbRusult.Text = "˲ʱŨ��" Then '˲ʱŨ��
            cmbTime.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.OutPut.ForeCount - 1
                cmbTime.Items.Add(Project0.Dis0.Forecast.OutPut.ForeStart + i * Project0.Dis0.Forecast.OutPut.ForeInterval & "min")
            Next
            If cmbTime.Items.Count > 0 Then
                cmbTime.SelectedIndex = 0
            End If
            cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1 '��������
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            If cmbMet.Items.Count > 0 Then
                cmbMet.SelectedIndex = 0
            End If
        ElseIf cmbRusult.Text = "�����ٷ���" Or cmbRusult.Text = "����ƽ��Ũ��" Then
            cmbTime.Items.Clear()
            cmbTime.Items.Add("����")
            cmbTime.SelectedIndex = 0
            cmbMet.Items.Clear()
            For i As Integer = 0 To Project0.Dis0.Forecast.Met.Length - 1 '��������
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).Vane & "," & Project0.Dis0.Forecast.Met(i).WindSpeed & "," & Project0.Dis0.Forecast.Met(i).Stab)
            Next
            cmbMet.Items.Add("����")
            cmbMet.SelectedIndex = 0
        ElseIf cmbRusult.Text = "���˷���ֵ" Then
            cmbTime.Items.Clear()
            cmbTime.Items.Add("����")
            cmbTime.SelectedIndex = 0
            cmbMet.Items.Clear()
            cmbMet.Items.Add("����")
            cmbMet.SelectedIndex = 0
        End If
        RefreshResult() ' �����û�ѡ��������б��ͼ
    End Sub

    Private Sub cmbMet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMet.SelectedIndexChanged
        RefreshResult() ' �����û�ѡ��������б��ͼ

    End Sub

    Private Sub cmbTime_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTime.SelectedIndexChanged
        RefreshResult() ' �����û�ѡ��������б��ͼ

    End Sub

    Private Sub cmbNum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshResult() ' �����û�ѡ��������б��ͼ

    End Sub
#End Region



    Private Sub cmbRusult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRusult.Click

    End Sub
End Class
