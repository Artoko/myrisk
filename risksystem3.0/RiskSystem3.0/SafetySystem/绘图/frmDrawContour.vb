Imports DisForm
Public Class frmDrawContour
    Private m_AddProject As Boolean = 0 '�����Ŀ

    Private m_LeakType As Integer '����й©������
    Private m_FireBlastType As Integer '���ֱ�ը����
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
    ''' <summary>
    ''' ��ȾԴ�����ͣ�0��Դ��1��Դ��2������Դ��3�������Դ��4Բ����Դ��5����Դ��6��Դ��11Ϊ������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SourceType As Integer '��ȾԴ����
    ''' <summary>
    ''' �����������
    ''' </summary>
    ''' <remarks></remarks>
    Public ArrayPoint(-1) As PointF
    Private m_OldMenuSctrip As ContextMenuStrip '�����Ĳ˵�
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
    ''' ��ȾԴ�����ͣ�0��Դ��1��Դ��2������Դ��3�������Դ��4Բ����Դ��5����Դ��6��Դ��11������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceType() As Integer
        Get
            Return Me.m_SourceType
        End Get
        Set(ByVal value As Integer)
            Me.m_SourceType = value
        End Set
    End Property

    ''' <summary>
    ''' ԭ���������Ĳ˵�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OldMenuSctrip() As ContextMenuStrip
        Get
            Return Me.m_OldMenuSctrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            Me.m_OldMenuSctrip = value
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
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        Dim point As New PointF
        point.X = e.X
        point.Y = e.Y
        point = ContourPaint1.PointToLocation(point)
        If e.Button = Windows.Forms.MouseButtons.Left And Me.m_AddProject = True Then
            Select Case Me.m_SourceType
                Case 0 '��Դ

                Case 1 '��Դ
                Case 2 '������Դ
                Case 3 '�������Դ
                Case 4 'Բ����Դ
                Case 5 '����Դ
                Case 6 '��Դ
                Case 11 '������
                    ReDim Preserve ArrayPoint(ArrayPoint.Length)
                    ArrayPoint(ArrayPoint.Length - 1).X = e.X
                    ArrayPoint(ArrayPoint.Length - 1).Y = e.Y
            End Select

        ElseIf Me.ContourPaint1.MouseMoveType = 5 Then '���ĵ�

        End If
    End Sub
    ''' <summary>
    ''' �ڻ�ͼ��������ȾԴ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPolluteDraw()
        '�ڻ�ͼ��������ȾԴ��λ�ú�ͼ��
        Dim PolluteSymbols As DrawContour.PolluteSymbols = ContourPaint1.ContourPaintSetting.ContourPannel.Symbols.PolluteSymbol
        ReDim PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0)
        '��Դ
        PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0) = New DrawContour.NameAndPoints
        PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0).Name = Project0.Dis0.IntialSource.LeakSourceName '���õ�Դ
        ReDim PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0).ArrayPoint(0)
        PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0).ArrayPoint(0).x = Project0.Dis0.IntialSource.Coordinate.x
        PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0).ArrayPoint(0).y = Project0.Dis0.IntialSource.Coordinate.y
        PolluteSymbols.PointSourceSymbols.ArrayPointSourceNameAndPoints(0).Type = 0
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
        '���ý�����
        Dim BuildingSymbols As DrawContour.BuildingSymbols = ContourPaint1.ContourPaintSetting.ContourPannel.Symbols.BuildingSymbols
        ReDim BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(Project0.Dis0.Forecast.PopulationRegions.ArrayPopulationRegion.Length - 1)
        For i As Integer = 0 To Project0.Dis0.Forecast.PopulationRegions.ArrayPopulationRegion.Length - 1
            BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(i) = New DrawContour.NameAndPoints
            BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(i).Name = Project0.Dis0.Forecast.PopulationRegions.ArrayPopulationRegion(i).Name    '
            ReDim BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(i).ArrayPoint(Project0.Dis0.Forecast.PopulationRegions.ArrayPopulationRegion(i).ArrayLocation.Length - 1) '���õ�һ��Ľ�����Ľ�
            '����������
            For j As Integer = 0 To BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(i).ArrayPoint.Length - 1
                BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(i).ArrayPoint(j).x = Project0.Dis0.Forecast.PopulationRegions.ArrayPopulationRegion(i).ArrayLocation(j).X
                BuildingSymbols.BuildingPoly.ArrayPointSourceNameAndPoints(i).ArrayPoint(j).y = Project0.Dis0.Forecast.PopulationRegions.ArrayPopulationRegion(i).ArrayLocation(j).Y
            Next
        Next

        CareSymbols.IntialCareSymbols() '��ʼ��

        'ContourPaint1.ContourPaintSetting.SetGrid(Project0.Dis0.Forecast.Grid.MinX, Project0.Dis0.Forecast.Grid.StepX, Project0.Dis0.Forecast.Grid.CountX _
        '                                          , Project0.Dis0.Forecast.Grid.MinY, Project0.Dis0.Forecast.Grid.StepY, Project0.Dis0.Forecast.Grid.CountY)

        Refresh() '�ػ�       
    End Sub

    Private Sub ContourPaint1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ContourPaint1.MouseMove
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm
        Dim point As New PointF
        point.X = e.X
        point.Y = e.Y
        point = ContourPaint1.PointToLocation(point)
        myFrmMain.txtLocation.Text = "����: " & FormatNumber(point.X, 1, TriState.True, TriState.False, TriState.False) & " , " & FormatNumber(point.Y, 1, TriState.True, TriState.False, TriState.False)

        Select Case Me.m_SourceType
            Case 0 '��Դ

            Case 1 '��Դ
                If e.Button = Windows.Forms.MouseButtons.Left And Me.m_AddProject = True Then
                    ReDim Preserve ArrayPoint(1)
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    If Math.Abs(e.X - ArrayPoint(0).X) <= Math.Abs(e.Y - ArrayPoint(0).Y) And Math.Abs(e.X - ArrayPoint(0).X) > 0 And Math.Abs(e.Y - ArrayPoint(0).Y) > 0 Then
                        ArrayPoint(1).X = e.X
                        ArrayPoint(1).Y = ArrayPoint(0).Y + Math.Abs(e.X - ArrayPoint(0).X) * (e.Y - ArrayPoint(0).Y) / Math.Abs(e.Y - ArrayPoint(0).Y)

                    ElseIf Math.Abs(e.X - ArrayPoint(0).X) > Math.Abs(e.Y - ArrayPoint(0).Y) And Math.Abs(e.X - ArrayPoint(0).X) > 0 And Math.Abs(e.Y - ArrayPoint(0).Y) > 0 Then
                        ArrayPoint(1).Y = e.Y
                        ArrayPoint(1).X = ArrayPoint(0).X + Math.Abs(e.Y - ArrayPoint(0).Y) * (e.X - ArrayPoint(0).X) / Math.Abs(e.X - ArrayPoint(0).X)
                    End If

                    Dim LeftPoint As PointF
                    If ArrayPoint(0).X < ArrayPoint(1).X Then
                        LeftPoint.X = ArrayPoint(0).X
                    Else
                        LeftPoint.X = ArrayPoint(1).X
                    End If
                    If ArrayPoint(0).Y < ArrayPoint(1).Y Then
                        LeftPoint.Y = ArrayPoint(0).Y
                    Else
                        LeftPoint.Y = ArrayPoint(1).Y
                    End If
                    myGrap.DrawRectangle(Pens.Green, New Rectangle(LeftPoint.X, LeftPoint.Y, Math.Abs(ArrayPoint(1).X - ArrayPoint(0).X), Math.Abs(ArrayPoint(1).X - ArrayPoint(0).X)))

                End If
            Case 2 '������Դ
                If ArrayPoint.Length = 1 Then
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    myGrap.DrawLine(Pens.Green, ArrayPoint(0), New PointF(e.X, e.Y))
                ElseIf ArrayPoint.Length >= 2 Then

                    ReDim Preserve ArrayPoint(2)

                    ArrayPoint(2).X = e.X
                    ArrayPoint(2).Y = e.Y
                    Dim K1 As Double = 0 'б��
                    Dim K2 As Double = 0 '���ߵ�б��
                    '�����б��K1
                    Dim P1, P20, P2, P3, P4 As PointF '���ڱ�ʾ4������
                    If Math.Abs(ArrayPoint(0).X - ArrayPoint(1).X) < 1 Then
                        P1 = ArrayPoint(0)
                        P3 = ArrayPoint(2)
                        P2.X = P1.X
                        P2.Y = P3.Y
                        P4.X = P3.X
                        P4.Y = P1.Y
                    ElseIf Math.Abs(ArrayPoint(0).Y - ArrayPoint(1).Y) < 1 Then 'ֱ��û��б��
                        P1 = ArrayPoint(0)
                        P3 = ArrayPoint(2)
                        P2.X = P3.X
                        P2.Y = P1.Y
                        P4.X = P1.X
                        P4.Y = P3.Y
                    Else
                        P1 = ArrayPoint(0)
                        P20 = ArrayPoint(1)
                        P3 = ArrayPoint(2)
                        '�ȸ���P1 P20���б��
                        K1 = (P20.Y - P1.Y) / (P20.X - P1.X)
                        K2 = -1 / K1
                        '�ٸ���P1��P3����P2��P4
                        'P2
                        Dim B1, C1, B2, C2 As Double
                        B1 = -1 * K1
                        C1 = (K1 * P1.X - P1.Y)
                        B2 = -1 * K2
                        C2 = (K2 * P3.X - P3.Y)
                        P2.Y = (B1 * C2 - B2 * C1) / (B2 - B1)
                        P2.X = (C1 - C2) / (B2 - B1)

                        'P4
                        B1 = -1 * K1
                        C1 = (K1 * P3.X - P3.Y)
                        B2 = -1 * K2
                        C2 = (K2 * P1.X - P1.Y)
                        P4.Y = (B1 * C2 - B2 * C1) / (B2 - B1)
                        P4.X = (C1 - C2) / (B2 - B1)

                    End If
                    '����
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    myGrap.DrawLine(Pens.Green, P1, P2)
                    myGrap.DrawLine(Pens.Green, P2, P3)
                    myGrap.DrawLine(Pens.Green, P3, P4)
                    myGrap.DrawLine(Pens.Green, P4, P1)
                End If
            Case 3 '�������Դ

                If Me.m_AddProject = True Then
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    Dim A() As PointF = ArrayPoint
                    ReDim Preserve A(A.Length)
                    A(A.Length - 1).X = e.X
                    A(A.Length - 1).Y = e.Y
                    ReDim Preserve A(A.Length)
                    A(A.Length - 1).X = A(0).X
                    A(A.Length - 1).Y = A(0).Y
                    myGrap.DrawPolygon(Pens.Green, A)
                End If

            Case 4 'Բ����Դ

                If e.Button = Windows.Forms.MouseButtons.Left And Me.m_AddProject = True Then
                    ReDim Preserve ArrayPoint(1)
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    ArrayPoint(1).X = e.X
                    ArrayPoint(1).Y = e.Y
                    '����뾶
                    Dim R As Double = DrawContour.PublicFun.Distance(ArrayPoint(0), ArrayPoint(1))
                    '����Բ�ĵ����ֱ��
                    myGrap.DrawLine(Pens.Green, ArrayPoint(0), ArrayPoint(1))
                    myGrap.DrawEllipse(Pens.Green, New Rectangle(ArrayPoint(0).X - R, ArrayPoint(0).Y - R, 2.0 * R, 2.0 * R))

                End If
            Case 5 '����Դ
                If ArrayPoint.Length = 1 Then
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    myGrap.DrawLine(Pens.Green, ArrayPoint(0), New PointF(e.X, e.Y))
                ElseIf ArrayPoint.Length >= 2 Then

                    ReDim Preserve ArrayPoint(2)

                    ArrayPoint(2).X = e.X
                    ArrayPoint(2).Y = e.Y
                    Dim K1 As Double = 0 'б��
                    Dim K2 As Double = 0 '���ߵ�б��
                    '�����б��K1
                    Dim P1, P20, P2, P3, P4 As PointF '���ڱ�ʾ4������
                    If Math.Abs(ArrayPoint(0).X - ArrayPoint(1).X) < 1 Then
                        P1 = ArrayPoint(0)
                        P3 = ArrayPoint(2)
                        P2.X = P1.X
                        P2.Y = P3.Y
                        P4.X = P3.X
                        P4.Y = P1.Y
                    ElseIf Math.Abs(ArrayPoint(0).Y - ArrayPoint(1).Y) < 1 Then 'ֱ��û��б��
                        P1 = ArrayPoint(0)
                        P3 = ArrayPoint(2)
                        P2.X = P3.X
                        P2.Y = P1.Y
                        P4.X = P1.X
                        P4.Y = P3.Y
                    Else
                        P1 = ArrayPoint(0)
                        P20 = ArrayPoint(1)
                        P3 = ArrayPoint(2)
                        '�ȸ���P1 P20���б��
                        K1 = (P20.Y - P1.Y) / (P20.X - P1.X)
                        K2 = -1 / K1
                        '�ٸ���P1��P3����P2��P4
                        'P2
                        Dim B1, C1, B2, C2 As Double
                        B1 = -1 * K1
                        C1 = (K1 * P1.X - P1.Y)
                        B2 = -1 * K2
                        C2 = (K2 * P3.X - P3.Y)
                        P2.Y = (B1 * C2 - B2 * C1) / (B2 - B1)
                        P2.X = (C1 - C2) / (B2 - B1)

                        'P4
                        B1 = -1 * K1
                        C1 = (K1 * P3.X - P3.Y)
                        B2 = -1 * K2
                        C2 = (K2 * P1.X - P1.Y)
                        P4.Y = (B1 * C2 - B2 * C1) / (B2 - B1)
                        P4.X = (C1 - C2) / (B2 - B1)

                    End If
                    '����
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    myGrap.DrawLine(Pens.Green, P1, P2)
                    myGrap.DrawLine(Pens.Green, P2, P3)
                    myGrap.DrawLine(Pens.Green, P3, P4)
                    myGrap.DrawLine(Pens.Green, P4, P1)
                End If

            Case 6 '��Դ
                If Me.m_AddProject = True AndAlso ArrayPoint.Length > 0 Then
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    Dim A() As PointF = ArrayPoint
                    ReDim Preserve A(A.Length)
                    A(A.Length - 1).X = e.X
                    A(A.Length - 1).Y = e.Y
                    myGrap.DrawLines(Pens.Green, A)
                End If
            Case 11 '������

                If Me.m_AddProject = True Then
                    Me.Refresh()
                    Dim myGrap As Graphics = ContourPaint1.CreateGraphics()
                    Dim A() As PointF = ArrayPoint
                    ReDim Preserve A(A.Length)
                    A(A.Length - 1).X = e.X
                    A(A.Length - 1).Y = e.Y
                    ReDim Preserve A(A.Length)
                    A(A.Length - 1).X = A(0).X
                    A(A.Length - 1).Y = A(0).Y
                    myGrap.DrawPolygon(Pens.Green, A)
                End If

        End Select
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
        'ReDim Me.ContourPaint1.ContourPaintSetting.GridPoint(Me.ContourPaint1.ContourPaintSetting.m_nRows - 1, Me.ContourPaint1.ContourPaintSetting.m_nCols - 1)

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
            '.ResetCountData()
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
        'ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
        'ContourPaint1.ContourPaintSetting.ResetCountData()
        'ContourPaint1.Refresh()
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
                        'Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.InstantaneousGridC(cmbMet.SelectedIndex, cmbTime.SelectedIndex, k, l)
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
                'Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                'Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "����ƽ��Ũ��" Then
            If cmbMet.SelectedIndex >= 0 Then
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        'Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.SlipGrid(cmbMet.SelectedIndex, k, l).MaxCon
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
                            'If Me.ContourPaint1.ContourPaintSetting.GridPoint(i1, j1) = Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(k1) Then
                            '    Me.ContourPaint1.ContourPaintSetting.GridPoint(i1, j1) = Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(k1) + 0.000001
                            'End If
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
                'Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                'Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "�����ٷ���" Then
            If cmbMet.SelectedIndex >= 0 Then
                For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                    For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                        'Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.D(cmbMet.SelectedIndex)(k, l)
                    Next
                Next
                '���õ�ֵ�����ƺ�ֵ������
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(5 - 1)
                ReDim Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(5 - 1)
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(0) = "90%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(0) = 90
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(1) = "50%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(1) = 50
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(2) = "10%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(2) = 10
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(3) = "1%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(3) = 1
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourNames(4) = "0.1%"
                Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ContourValueSetting.ContourValue(4) = 0.1

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
                'Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
                'Me.ContourPaint1.ContourPaintSetting.ResetCountData()
                'Me.ContourPaint1.Refresh()
            End If
        ElseIf cmbRusult.Text = "���˷���ֵ" Then

            For k As Integer = 0 To Project0.Dis0.Forecast.Grid.CountY - 1
                For l As Integer = 0 To Project0.Dis0.Forecast.Grid.CountX - 1
                    'Me.ContourPaint1.ContourPaintSetting.GridPoint(k, l) = Project0.Dis0.Results.AllGridResult.PersonalRisk(k, l) * Project0.Dis0.IntialSource.Probability '���˷���
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
            'Me.ContourPaint1.ContourPaintSetting.ContourPannel.Contours.ReCalContour = True
            'Me.ContourPaint1.ContourPaintSetting.ResetCountData()
            'Me.ContourPaint1.Refresh()
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
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).m_DateTime.Year & "��" & Project0.Dis0.Forecast.Met(i).m_DateTime.Month & "��" & Project0.Dis0.Forecast.Met(i).m_DateTime.Day & "��" & Project0.Dis0.Forecast.Met(i).m_DateTime.Hour & "ʱ")
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
                cmbMet.Items.Add(Project0.Dis0.Forecast.Met(i).m_DateTime.Year & "��" & Project0.Dis0.Forecast.Met(i).m_DateTime.Month & "��" & Project0.Dis0.Forecast.Met(i).m_DateTime.Day & "��" & Project0.Dis0.Forecast.Met(i).m_DateTime.Hour & "ʱ")
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

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim myFrmMain As frmMain = My.Application.ApplicationContext.MainForm

        Select Case Me.m_SourceType
            Case 0 '��Դ
            Case 1 '��Դ
            Case 2 '������Դ
            Case 3 '�������Դ
            Case 4 'Բ����Դ
            Case 5 '����Դ
            Case 6 '��Դ
            Case 11 '������
                Dim frmPopu As New frmPopulation
                frmPopu.PopulationRegions = Project0.Dis0.Forecast.PopulationRegions.Clone
                ReDim Preserve frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length)
                frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1) = New DisPuff.PopulationRegion
                frmPopu.PopulationRegions.nPopulationRegion += 1
                frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1).Name = "����" & frmPopu.PopulationRegions.nPopulationRegion
                '���õ�һ����������
                Dim P As PointF
                P = ContourPaint1.PointToLocation(Me.ArrayPoint(0))
                '������������
                Dim AF(Me.ArrayPoint.Length - 1) As PointF
                Dim AP(Me.ArrayPoint.Length - 1) As Point
                ReDim frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1).ArrayLocation(Me.ArrayPoint.Length - 1)
                For i As Integer = 0 To Me.ArrayPoint.Length - 1
                    AF(i) = ContourPaint1.PointToLocation(Me.ArrayPoint(i))
                    AP(i).X = AF(i).X
                    AP(i).Y = AF(i).Y
                    frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1).ArrayLocation(i) = New PointF
                    frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1).ArrayLocation(i).X = AP(i).X
                    frmPopu.PopulationRegions.ArrayPopulationRegion(frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1).ArrayLocation(i).Y = AP(i).Y
                Next

                frmPopu.PopulationRegions.SelectedIndex = frmPopu.PopulationRegions.ArrayPopulationRegion.Length - 1
                If frmPopu.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Project0.Dis0.Forecast.PopulationRegions = frmPopu.PopulationRegions.Clone

                    SetPolluteDraw()  '���ý�������ͼ���е�λ��
                    Project0.Dis0.Forecast.SetPopulation()

                    Me.ContourPaint1.ContextMenuStrip = ContourPaint1.mnuPaint
                    ContourPaint1.SetMouseType(0) '��ͷ��
                    Me.m_AddProject = False
                    Me.m_SourceType = -1
                End If
                '�������
                ReDim ArrayPoint(-1)
        End Select

    End Sub

    Private Sub ȡ��CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ȡ��CToolStripMenuItem.Click
        '�������
        ReDim ArrayPoint(-1)
        Me.ContourPaint1.ContextMenuStrip = ContourPaint1.mnuPaint
        ContourPaint1.SetMouseType(0) '��ͷ��
        Me.m_AddProject = False
        Me.m_SourceType = -1
    End Sub
End Class
