Imports DisPuff
Public Class Form1
    '设置一个二维数组，用于储存关心点的计算结果
    Private CareData(-1, -1) As Double
    '设置一个三维数组，用于储存网格点的计算结果
    Private GridData(-1, -1, -1) As Double

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox1.Text = ""

        Dim mydis As New Dis '实例化一个预测对象

        mydis.SetSourceNameAndLocation("氯气管断裂", 0, 0) '设置泄漏源的名称和坐标

        mydis.SetLeakCustomPoint(5.0, 10) '设置事故类型为自定义类型中的点源泄漏。挥发到空气中的泄漏量为5.0kg/s，挥发持续的时间为10分种

        '设置气象参数：事故源所在经度114度，纬度34度，风速3m/s，总云量8，低云量2，
        '事故泄漏时刻(2008年7月29日9点30分0秒)，日出时刻(2009年 7月 20日 6时 0分 0秒)，日落时刻(2009年 7月 20日 20时 0分 0秒),
        '环境温度为16摄氏度，气压为101325Pa。
        Dim LeakTime As New DateTime(2009, 7, 20, 9, 30, 0)
        Dim SunriseTime As New DateTime(2009, 7, 20, 6, 0, 0)
        Dim SunsetTime As New DateTime(2009, 7, 20, 20, 0, 0)
        mydis.SetMet(114, 34, 270, 3, 8, 2, LeakTime, SunriseTime, SunsetTime, 16, 101325) '设置事故发生的位置及气象数据

        '预测的起始时刻、步长和预测时刻的个数
        Dim startTime As Double = 1 '起始时刻为泄漏发生后的1分钟
        Dim IntervalTime As Double = 1 '预测的时间间隔为1分钟
        Dim Count As Integer = 15 '预测的时刻为15个
        mydis.SetForecastTime(startTime, IntervalTime, Count)

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

        '设置网格点：X轴的开始坐标为-1000米，步长100米，个数21个；Y轴的开始坐标为-1000米，步长100米，个数21个；预测网格离地高度0米
        mydis.SetGrid(-1000, 100, 21, -1000, 100, 21, 0)

        '计算污染物扩散
        mydis.Cal()

        '获取计算结果
        mydis.GetCareData(CareData)
        mydis.GetGridData(GridData)

        Dim strResult As String = "关心点的预测结果为：" & vbCrLf
        For i As Integer = 0 To Count - 1
            strResult = strResult & "预测时刻为" & startTime + i * IntervalTime & "分钟" & vbCrLf
            For j As Integer = 0 To myCareReceptor.Length - 1
                strResult = strResult & myCareReceptor(j).Name & "的浓度[mg/m^3]:" & CareData(i, j) & vbCrLf
            Next
            strResult = strResult & vbCrLf
        Next
        Me.TextBox1.Text = strResult

        ComboBox1.Items.Clear()
        For i As Integer = 0 To Count - 1
            ComboBox1.Items.Add(startTime + i * IntervalTime)
        Next
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.C1FlexGrid1.Clear()
        Me.C1FlexGrid1.Rows.Count = 1
        Me.C1FlexGrid1.Cols.Count = 1
        Me.C1FlexGrid1.Rows.Count = 21 + 1
        Me.C1FlexGrid1.Cols.Count = 21 + 1
        Me.C1FlexGrid1.SetData(0, 0, "Y\X")

        For i As Integer = 0 To 21 - 1
            Me.C1FlexGrid1.SetData(0, i + 1, -1000 + i * 100)
        Next
        For i As Integer = 0 To 21 - 1
            Me.C1FlexGrid1.SetData(Me.C1FlexGrid1.Rows.Count - (i + 1), 0, -1000 + i * 100)
        Next
        If ComboBox1.Items.Count > 0 Then
            For i As Integer = 0 To 21 - 1
                For j As Integer = 0 To 21 - 1
                    Me.C1FlexGrid1.SetData(i + 1, j + 1, FormatNumber(Me.GridData(Me.ComboBox1.SelectedIndex, i, j).ToString, 4))
                Next
            Next
        End If
        Me.C1FlexGrid1.AutoResize = True
        Me.C1FlexGrid1.AutoSizeCols()
    End Sub
End Class
