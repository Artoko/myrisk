Imports DisPuff
Public Class Form1
    Private mydis As Dis  '计算用的对象

    '设置一个一维数组，用于储存关心点的计算结果
    Private CareData(-1) As Double
    '设置一个二维数组，用于储存网格点的计算结果
    Private GridData(-1, -1) As Double
    '设置网格点
    Private m_MinX As Integer = 0 'X轴的开始坐标，通过计算结果自动获取
    Private m_StepX As Integer = 0 '步长，通过结果自动获取
    Private m_MinY As Integer = 0 'Y轴的开始坐标，通过计算结果自动获取
    Private m_StepY As Integer = 0 '步长，通过结果自动获取

    Private m_Count As Integer = 41 '设置网格点数为41个


    Private ArrayHurtConcentration(-1) As HurtConcentration

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox1.Text = ""

        mydis = New Dis '实例化一个预测对象。把实例化放到了声明中

        mydis.SetSourceNameAndLocation("氯气管断裂", 0, 0) '设置泄漏源的名称和坐标。一般来说，泄漏源做为坐标的原点。

        mydis.SetLeakCustomPoint(5.0, 10) '设置事故类型为自定义类型中的点源泄漏。挥发到空气中的泄漏量为5.0kg/s，挥发持续的时间为10分种

        '设置气象参数：事故源所在经度114度，纬度34度，风速3m/s，总云量8，低云量2，
        '事故泄漏时刻(2008年7月29日9点30分0秒)，日出时刻(2009年 7月 20日 6时 0分 0秒)，日落时刻(2009年 7月 20日 20时 0分 0秒),
        '环境温度为16摄氏度，气压为101325Pa。
        Dim LeakTime As New DateTime(2009, 7, 20, 9, 30, 0)
        Dim SunriseTime As New DateTime(2009, 7, 20, 6, 0, 0)
        Dim SunsetTime As New DateTime(2009, 7, 20, 20, 0, 0)
        mydis.SetMet(114, 34, 270, 3, 8, 2, LeakTime, SunriseTime, SunsetTime, 16, 101325) '设置事故发生的位置及气象数据

        '预测的时刻
        Dim ForeTime As Double = 10 '预测时刻为泄漏发生后的10分钟
        mydis.SetForecastTime(ForeTime)

        '设置关心点数组为3个
        Dim myCareReceptor(2) As CareReceptor

        '实例化每个关心点。并设置名称和坐标
        myCareReceptor(0) = New CareReceptor
        myCareReceptor(0).Name = "荣村"
        myCareReceptor(0).Point3D.x = 200
        myCareReceptor(0).Point3D.y = 0
        myCareReceptor(0).Point3D.z = 0

        myCareReceptor(1) = New CareReceptor
        myCareReceptor(1).Name = "孙村"
        myCareReceptor(1).Point3D.x = 500
        myCareReceptor(1).Point3D.y = 0
        myCareReceptor(1).Point3D.z = 0

        myCareReceptor(2) = New CareReceptor
        myCareReceptor(2).Name = "大帐"
        myCareReceptor(2).Point3D.x = 600
        myCareReceptor(2).Point3D.y = 100
        myCareReceptor(2).Point3D.z = 0

        mydis.SetCare(myCareReceptor)

        '设置网格点：预测网格离地高度0米
        mydis.SetGridCount(Me.m_Count, 0)

        '设置地表参数：地表特征的序号：0--平原地区农村及城市远郊区；1--工业区或城区；2--丘陵山区的农村或城市
        mydis.SetGround(0)

        '设置毒性参数。
        ReDim ArrayHurtConcentration(1)
        ArrayHurtConcentration(0) = New HurtConcentration
        ArrayHurtConcentration(0).Name = "半致浓度"
        ArrayHurtConcentration(0).ConcentrationVale = 1390

        ArrayHurtConcentration(1) = New HurtConcentration
        ArrayHurtConcentration(1).Name = "短时间接触允许浓度"
        ArrayHurtConcentration(1).ConcentrationVale = 30

        mydis.SetToxicity(ArrayHurtConcentration)


        '计算污染物扩散。如果没有注册软件，将返回false
        If mydis.Cal() = False Then
            Exit Sub
        End If

        '获取计算结果

        mydis.GetCareData(CareData)
        mydis.GetGridData(GridData, Me.m_MinX, Me.m_StepX, Me.m_MinY, Me.m_StepY, Me.m_Count)

        Dim strResult As String = "关心点的预测结果为：" & vbCrLf
        strResult = strResult & "预测时刻为" & ForeTime & "分钟" & vbCrLf
        For j As Integer = 0 To myCareReceptor.Length - 1
            strResult = strResult & myCareReceptor(j).Name & "的浓度[mg/m^3]:" & CareData(j) & vbCrLf
        Next
        strResult = strResult & vbCrLf
        Me.TextBox1.Text = strResult

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add(ForeTime)

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.C1FlexGrid1.Clear()
        Me.C1FlexGrid1.Rows.Count = 1
        Me.C1FlexGrid1.Cols.Count = 1
        Me.C1FlexGrid1.Rows.Count = Me.m_Count + 1
        Me.C1FlexGrid1.Cols.Count = Me.m_Count + 1
        Me.C1FlexGrid1.SetData(0, 0, "Y\X")

        For i As Integer = 0 To Me.m_Count - 1
            Me.C1FlexGrid1.SetData(0, i + 1, Me.m_MinX + i * Me.m_StepX)
        Next
        For i As Integer = 0 To Me.m_Count - 1
            Me.C1FlexGrid1.SetData(Me.C1FlexGrid1.Rows.Count - (i + 1), 0, Me.m_MinY + i * Me.m_StepY)
        Next
        If ComboBox1.Items.Count > 0 Then
            For i As Integer = 0 To Me.m_Count - 1
                For j As Integer = 0 To Me.m_Count - 1
                    Me.C1FlexGrid1.SetData(i + 1, j + 1, FormatNumber(Me.GridData(i, j).ToString, 4))
                Next
            Next
        End If
        Me.C1FlexGrid1.AutoResize = True
        Me.C1FlexGrid1.AutoSizeCols()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TextBox2.Clear()
        Dim strContour As String = "X          ,      Y" & vbCrLf
        Dim OneContourLine(-1) As YT_ContourDLL.Point3D
        For n As Integer = 0 To Me.ArrayHurtConcentration.Length - 1
            strContour += vbCrLf & Me.ArrayHurtConcentration(n).Name & vbCrLf
            OneContourLine = mydis.GetContours(Me.ArrayHurtConcentration(n).ConcentrationVale) '在这里获取想要的值的等值线。如获取浓度值为30mg/m^3的等值线。注意，如果要获取闭合的等值线，设置的值不能小于
            For i As Integer = 0 To OneContourLine.Length - 1
                If OneContourLine(i).z <> -1 Then '-1用做等值线结束的标志
                    strContour += OneContourLine(i).x & "  ,  " & OneContourLine(i).y & vbCrLf
                End If
            Next
        Next
        Me.TextBox2.Text = strContour
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        '打开气体泄漏量计算对话框
        Dim frmNewLeakGas As New frmLeakGas
        Static nGas As Short
        nGas = nGas + 1
        Dim strName As String
        strName = "未标题" & nGas
        frmNewLeakGas.Text = "气体泄漏量计算--" & strName
        frmNewLeakGas.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        '打开两相流计算对话框
        Dim frmNewLeakTwo As New frmLeakTwo
        Static nTwo As Short
        nTwo = nTwo + 1
        Dim strName As String
        strName = "未标题" & nTwo
        frmNewLeakTwo.Text = "两相流泄漏量计算--" & strName
        frmNewLeakTwo.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        '打开液体泄漏量计算对话框
        Dim frmNewLeakLiquid As New frmLeakLiquid
        Static nLiquid As Short
        nLiquid = nLiquid + 1
        Dim strName As String
        strName = "未标题" & nLiquid
        frmNewLeakLiquid.Text = "液体泄漏量计算--" & strName
        frmNewLeakLiquid.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        '打开液体闪蒸量计算对话框
        Dim frmNewLeakFlash As New frmLeakFlash
        Static nFlash As Short
        nFlash = nFlash + 1
        Dim strName As String
        strName = "未标题" & nFlash
        frmNewLeakFlash.Text = "闪蒸量计算--" & strName
        frmNewLeakFlash.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        '打开热量蒸发量计算对话框
        Dim frmNewLeakHeat As New frmLeakHeat
        Static nHeat As Short
        nHeat = nHeat + 1
        Dim strName As String
        strName = "未标题" & nHeat
        frmNewLeakHeat.Text = "热量蒸发量计算--" & strName
        frmNewLeakHeat.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        '打开质量蒸发量计算对话框
        Dim frmNewLeakQuality As New frmLeakQuality
        Static nQuality As Short
        nQuality = nQuality + 1
        Dim strName As String
        strName = "未标题" & nQuality
        frmNewLeakQuality.Text = "质量蒸发量计算--" & strName
        frmNewLeakQuality.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.TextBox1.Text = ""

        '对于典型泄漏事故，把参数设置全部放到了对话框中-----------------------------------------
        mydis = New Dis '实例化一个预测对象。把实例化放到了声明中

     
        '如果要计算典型泄漏则调用下面的代码。典型泄漏的相关设置在对话框中，您可以参考。如果设置了典型泄漏，就应设置物质的相关数据----------------------
        '设置事故类型
        Dim frmLeakSource As frmLeakSource = New frmLeakSource()
        frmLeakSource.Dis = Me.mydis '注意这里是引用传递。然后所有的参数都在对话框时进行设置
        If frmLeakSource.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.mydis = frmLeakSource.Dis
        End If

        Dim frmChem As frmChemistry = New frmChemistry()
        frmChem.Dis = Me.mydis '注意这里是引用传递。然后所有的参数都在对话框时进行设置
        If frmChem.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.mydis = frmChem.Dis
        End If
        ''--------------------------------------------------------------------------------------



        '设置气象参数：事故源所在经度114度，纬度34度，风速3m/s，总云量8，低云量2，
        '事故泄漏时刻(2008年7月29日9点30分0秒)，日出时刻(2009年 7月 20日 6时 0分 0秒)，日落时刻(2009年 7月 20日 20时 0分 0秒),
        '环境温度为16摄氏度，气压为101325Pa。
        Dim LeakTime As New DateTime(2009, 7, 20, 9, 30, 0)
        Dim SunriseTime As New DateTime(2009, 7, 20, 6, 0, 0)
        Dim SunsetTime As New DateTime(2009, 7, 20, 20, 0, 0)
        mydis.SetMet(114, 34, 270, 3, 8, 2, LeakTime, SunriseTime, SunsetTime, 16, 101325) '设置事故发生的位置及气象数据

        '预测的时刻
        Dim ForeTime As Double = 10 '预测时刻为泄漏发生后的10分钟
        mydis.SetForecastTime(ForeTime)

        '设置关心点数组为3个
        Dim myCareReceptor(2) As CareReceptor

        '实例化每个关心点。并设置名称和坐标
        myCareReceptor(0) = New CareReceptor
        myCareReceptor(0).Name = "荣村"
        myCareReceptor(0).Point3D.x = 200
        myCareReceptor(0).Point3D.y = 0
        myCareReceptor(0).Point3D.z = 0

        myCareReceptor(1) = New CareReceptor
        myCareReceptor(1).Name = "孙村"
        myCareReceptor(1).Point3D.x = 500
        myCareReceptor(1).Point3D.y = 0
        myCareReceptor(1).Point3D.z = 0

        myCareReceptor(2) = New CareReceptor
        myCareReceptor(2).Name = "大帐"
        myCareReceptor(2).Point3D.x = 600
        myCareReceptor(2).Point3D.y = 100
        myCareReceptor(2).Point3D.z = 0

        mydis.SetCare(myCareReceptor)

        '设置网格点：预测网格离地高度0米
        mydis.SetGridCount(Me.m_Count, 0)

        '设置地表参数：地表特征的序号：0--平原地区农村及城市远郊区；1--工业区或城区；2--丘陵山区的农村或城市
        mydis.SetGround(0)

        '设置毒性参数。
        ReDim ArrayHurtConcentration(1)
        ArrayHurtConcentration(0) = New HurtConcentration
        ArrayHurtConcentration(0).Name = "半致浓度"
        ArrayHurtConcentration(0).ConcentrationVale = 1390

        ArrayHurtConcentration(1) = New HurtConcentration
        ArrayHurtConcentration(1).Name = "短时间接触允许浓度"
        ArrayHurtConcentration(1).ConcentrationVale = 30

        mydis.SetToxicity(ArrayHurtConcentration)


        '计算污染物扩散。如果没有注册软件，将返回false
        If mydis.Cal() = False Then
            Exit Sub
        End If

        '获取计算结果

        mydis.GetCareData(CareData)
        mydis.GetGridData(GridData, Me.m_MinX, Me.m_StepX, Me.m_MinY, Me.m_StepY, Me.m_Count)

        Dim strResult As String = "关心点的预测结果为：" & vbCrLf
        strResult = strResult & "预测时刻为" & ForeTime & "分钟" & vbCrLf
        For j As Integer = 0 To myCareReceptor.Length - 1
            strResult = strResult & myCareReceptor(j).Name & "的浓度[mg/m^3]:" & CareData(j) & vbCrLf
        Next
        strResult = strResult & vbCrLf
        Me.TextBox1.Text = strResult

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add(ForeTime)

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub
End Class
