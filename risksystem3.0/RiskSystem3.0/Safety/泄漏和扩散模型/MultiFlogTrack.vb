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
    ''' 生成多个烟团
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
    ''' 生成单个烟团的轨迹
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateFlogTrack(ByVal arrayMet As Met(), ByVal Sn As Integer, ByVal LeaveTime As Double, ByVal ForecastTime As Integer, ByVal point0 As Point3D, ByVal stab As Double, ByVal ground As String, ByVal ax As Double, ByVal az As Double, ByRef re_point As Point3D, ByRef re_ax As Double, ByRef re_az As Double)
        '先不考虑重气体，以后再考虑。
        '第一步：计算烟团的中心位置
        If ForecastTime > 3600 Then '如果预测时刻大于1小时就进行追踪
            Dim ax1 As Double = 0
            Dim az1 As Double = 0
            If LeaveTime < 3600 Then
                Dim DX As Double = Math.Sin(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (3600 - LeaveTime)
                Dim DY As Double = Math.Cos(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (3600 - LeaveTime)
                point0.x = point0.x + DX
                point0.y = point0.y + DY
                point0.z = point0.z
                '根据上一步计算得到的水平和垂直向扩散参数计算出当前气象条件下烟团虚拟的距离
                Dim DX_1 As Double = Anti_DiffuseY15(ax, stab, ground) '虚拟的距离
                ax1 = DiffuseY15(arrayMet(Sn).u2 * 3600 + DX_1, stab, ground)

                Dim DZ_1 As Double = Anti_DiffuseZ15(az, stab, ground) '虚拟的距离
                az1 = DiffuseZ15(arrayMet(Sn).u2 * 3600 + DZ_1, stab, ground)
            End If
            Sn += 1
            ForecastTime -= 3600
            LeaveTime -= 3600

            '如果气象条件超出的边界，用边界的气象条件
            If Sn > arrayMet.Length - 1 Then
                Sn = arrayMet.Length - 1
            End If
            CreateFlogTrack(arrayMet, Sn, LeaveTime, ForecastTime, point0, stab, ground, ax1, az1, re_point, re_ax, re_az)
        Else
            Dim DX As Double = Math.Sin(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (ForecastTime - LeaveTime)
            Dim DY As Double = Math.Cos(arrayMet(Sn).WindDer) * arrayMet(Sn).u2 * (ForecastTime - LeaveTime)
            point0.x = point0.x + DX
            point0.y = point0.y + DY
            point0.z = point0.z

            '根据上一步计算得到的水平和垂直向扩散参数计算出当前气象条件下烟团虚拟的距离
            Dim DX_1 As Double = Anti_DiffuseY15(ax, stab, ground) '虚拟的距离
            Dim ax1 As Double = DiffuseY15(arrayMet(Sn).u2 * ForecastTime + DX_1, stab, ground)

            Dim DZ_1 As Double = Anti_DiffuseZ15(az, stab, ForecastTime) '虚拟的距离
            Dim az1 As Double = DiffuseZ15(arrayMet(Sn).u2 * ForecastTime + DZ_1, stab, ground)

            re_point.x = point0.x
            re_point.y = point0.y
            re_point.z = point0.z
            re_ax = ax1
            re_az = az1
            Exit Sub
        End If
    End Sub
End Class
