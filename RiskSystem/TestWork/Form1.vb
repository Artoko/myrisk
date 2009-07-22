Imports DisPuff
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox1.Clear()

        Dim mydis As New Dis '实例化一个预测对象

        mydis.SetSourceNameAndLocation("氯气管断裂", 0, 0) '设置泄漏源的名称和坐标

        mydis.SetLeakCustomPoint(5.0, 10) '设置事故类型为自定义类型中的点源泄漏。挥发到空气中的泄漏量为5.0kg/s，挥发持续的时间为10分种

        '预测的起始时刻、步长和预测时刻的个数
        Dim startTime As Double = 1 '起始时刻为泄漏发生后的1分钟
        Dim IntervalTime As Double = 1 '预测的时间间隔为1分钟
        Dim Count As Integer = 15 '预测的时刻为15个
        mydis.SetForecastTime(startTime, IntervalTime, Count)

        '设置关心点数组为3个
        Dim myCareReceptor(2) As CareReceptor

        '实例化每个关心点。并设置名称和坐标
        myCareReceptor(0) = New CareReceptor
        myCareReceptor(0).Name = "宋村"
        myCareReceptor(0).Point3D.x = 200
        myCareReceptor(0).Point3D.y = 0
        myCareReceptor(0).Point3D.z = 0

        myCareReceptor(1) = New CareReceptor
        myCareReceptor(1).Name = "良村"
        myCareReceptor(1).Point3D.x = 500
        myCareReceptor(1).Point3D.y = 0
        myCareReceptor(1).Point3D.z = 0

        myCareReceptor(2) = New CareReceptor
        myCareReceptor(2).Name = "孙村"
        myCareReceptor(2).Point3D.x = 400
        myCareReceptor(2).Point3D.y = 150
        myCareReceptor(2).Point3D.z = 0


        '设置一个二维数组，用于储存关心点的计算结果
        Dim CareData(-1, -1) As Double
        mydis.GetCareData(myCareReceptor, CareData)

        Dim strResult As String = "关心点的预测结果为：" & vbCrLf
        For i As Integer = 0 To Count - 1
            strResult = strResult & "预测时刻为" & startTime + i * IntervalTime & "分钟" & vbCrLf
            For j As Integer = 0 To myCareReceptor.Length - 1
                strResult = strResult & myCareReceptor(j).Name & "的浓度[mg/m^3]:" & CareData(i, j) & vbCrLf
            Next
            strResult = strResult & vbCrLf
        Next
        Me.TextBox1.Text = strResult
    End Sub
End Class
