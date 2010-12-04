''' <summary>
''' 这个类是用于生成多烟团的轨迹的。
''' </summary>
''' <remarks></remarks>
Public Class MultiFlogTrack
    Private m_arrayFlogTrack(-1) As FlogTrack

    Property arrayFlogTrack() As FlogTrack()
        Get
            Return Me.m_arrayFlogTrack
        End Get
        Set(ByVal value As FlogTrack())
            Me.m_arrayFlogTrack = value
        End Set
    End Property
    ''' <summary>
    ''' 生成预测时刻多个烟团的轨迹和多个烟团对应的扩散参数
    ''' </summary>
    ''' <param name="arrayMet"></param>
    ''' <param name="Sn"></param>
    ''' <param name="MultiLeakSorce"></param>
    ''' <param name="ForecastTime"></param>
    ''' <param name="point0"></param>
    ''' <param name="stab"></param>
    ''' <param name="ground"></param>
    ''' <param name="ax"></param>
    ''' <param name="az"></param>
    ''' <remarks></remarks>
    Private Sub CreateMultiFlogTrack(ByVal arrayMet As Met(), ByVal Sn As Integer, ByVal MultiLeakSorce As MultiLeakSorce, ByVal ForecastTime As Integer, ByVal point0 As Point3D, ByVal stab As Double, ByVal ground As String, ByVal ax As Double, ByVal az As Double)
        For i As Integer = 0 To MultiLeakSorce.V1.Length

        Next
    End Sub


    ''' <summary>
    ''' 生成单个烟团的轨迹和该烟团对应的扩散参数
    ''' </summary>
    ''' <param name="arrayMet">预测时间内的气象数组</param>
    ''' <param name="Sn">序号</param>
    ''' <param name="LeaveTime">排放持续时间</param>
    ''' <param name="ForecastTime">从泄漏开始后的预测时刻</param>
    ''' <param name="IntialLocation">烟团的初始位置</param>
    ''' <param name="ground">地面类型</param>
    ''' <param name="ax">初始扩散参数，点源初始为0，面源和体源为相应的参数</param>
    ''' <param name="az">初始扩散参数，点源初始为0，面源和体源为相应的参数</param>
    ''' <param name="re_point">预测时刻的烟团位置</param>
    ''' <param name="re_ax">预测时刻的扩散参数</param>
    ''' <param name="re_az">预测时刻的扩散参数</param>
    ''' <remarks></remarks>
    Private Sub CreateFlogTrack(ByVal arrayMet As Met(), ByVal Sn As Integer, ByVal LeaveTime As Double, ByVal ForecastTime As Integer, ByRef IntialLocation As Point3D, ByVal ground As String, ByVal ax As Double, ByVal az As Double, ByRef re_point As Point3D, ByRef re_ax As Double, ByRef re_az As Double)
        '先不考虑重气体，以后再考虑。
        '第一步：计算烟团的中心位置
        If ForecastTime > 3600 Then '如果预测时刻大于1小时就进行追踪
            Dim ax1 As Double = 0
            Dim az1 As Double = 0
            If LeaveTime < 3600 Then
                Dim DX As Double = Math.Sin(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (3600 - LeaveTime)
                Dim DY As Double = Math.Cos(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (3600 - LeaveTime)
                IntialLocation.x = IntialLocation.x + DX
                IntialLocation.y = IntialLocation.y + DY
                IntialLocation.z = IntialLocation.z
                '根据上一步计算得到的水平和垂直向扩散参数计算出当前气象条件下烟团虚拟的距离
                Dim DX_1 As Double = Anti_DiffuseY15(ax, arrayMet(Sn).Stab, ground) '虚拟的距离
                ax1 = DiffuseY15(arrayMet(Sn).u2 * 3600 + DX_1, arrayMet(Sn).Stab, ground)

                Dim DZ_1 As Double = Anti_DiffuseZ15(az, arrayMet(Sn).Stab, ground) '虚拟的距离
                az1 = DiffuseZ15(arrayMet(Sn).u2 * 3600 + DZ_1, arrayMet(Sn).Stab, ground)
            End If
            Sn += 1
            ForecastTime -= 3600
            LeaveTime -= 3600

            '如果气象条件超出的边界，用边界的气象条件
            If Sn > arrayMet.Length - 1 Then
                Sn = arrayMet.Length - 1
            End If
            CreateFlogTrack(arrayMet, Sn, LeaveTime, ForecastTime, IntialLocation, ground, ax1, az1, re_point, re_ax, re_az)
        Else
            Dim DX As Double = Math.Sin(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (ForecastTime - LeaveTime)
            Dim DY As Double = Math.Cos(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (ForecastTime - LeaveTime)
            IntialLocation.x = IntialLocation.x + DX
            IntialLocation.y = IntialLocation.y + DY
            IntialLocation.z = IntialLocation.z

            '根据上一步计算得到的水平和垂直向扩散参数计算出当前气象条件下烟团虚拟的距离
            Dim DX_1 As Double = Anti_DiffuseY15(ax, arrayMet(Sn).Stab, ground) '虚拟的距离
            Dim ax1 As Double = DiffuseY15(arrayMet(Sn).u2 * ForecastTime + DX_1, arrayMet(Sn).Stab, ground)

            Dim DZ_1 As Double = Anti_DiffuseZ15(az, arrayMet(Sn).Stab, ForecastTime) '虚拟的距离
            Dim az1 As Double = DiffuseZ15(arrayMet(Sn).u2 * ForecastTime + DZ_1, arrayMet(Sn).Stab, ground)

            re_point.x = IntialLocation.x
            re_point.y = IntialLocation.y
            re_point.z = IntialLocation.z
            re_ax = ax1
            re_az = az1
            Exit Sub
        End If
    End Sub
End Class
