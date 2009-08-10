''' <summary>
''' 喷射火类
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Class Jet
    Private m_JetFire As New JetFire
    Private m_ResultHurtPoint(-1) As hurtPointstruct

    Property JetFire() As JetFire
        Get
            Return Me.m_JetFire
        End Get
        Set(ByVal value As JetFire)
            Me.m_JetFire = value
        End Set
    End Property

    ''' <summary>
    ''' 不同热辐射对应的点序列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ResultHurtPoint() As hurtPointstruct()
        Get
            ReDim m_ResultHurtPoint(Me.m_JetFire.ResultHurtPoint.Length - 1)
            For i As Integer = 0 To Me.m_JetFire.ResultHurtPoint.Length - 1
                Me.m_ResultHurtPoint(i) = New hurtPointstruct
                ReDim Me.m_ResultHurtPoint(i).ArrayHurtPoint(Me.m_JetFire.ResultHurtPoint(i).ArrayHurtPoint.Length - 1)
                For j As Integer = 0 To Me.m_ResultHurtPoint(i).ArrayHurtPoint.Length - 1
                    Me.m_ResultHurtPoint(i).ArrayHurtPoint(j) = New Point2D
                    Me.m_ResultHurtPoint(i).ArrayHurtPoint(j).x = CoorX(Me.m_JetFire.SourcePoint.x, Me.m_JetFire.ResultHurtPoint(i).ArrayHurtPoint(j).x, Me.m_JetFire.ResultHurtPoint(i).ArrayHurtPoint(j).y, Me.m_JetFire.SourceAngle)
                    Me.m_ResultHurtPoint(i).ArrayHurtPoint(j).y = Coory(Me.m_JetFire.SourcePoint.y, Me.m_JetFire.ResultHurtPoint(i).ArrayHurtPoint(j).x, Me.m_JetFire.ResultHurtPoint(i).ArrayHurtPoint(j).y, Me.m_JetFire.SourceAngle)
                Next
            Next
            Return Me.m_ResultHurtPoint
        End Get
        Set(ByVal value As hurtPointstruct())
            Me.m_ResultHurtPoint = value
        End Set
    End Property
    '将绝对坐标转换为相对坐标，X轴转换
    Public Function CoordinateX(ByVal x As Double, ByVal y As Double, ByVal Angle As Double, ByVal x0 As Double, ByVal y0 As Double) As Double
        Dim AnglePi As Double = (Angle - 90) * (Math.PI) / 180
        CoordinateX = (x - x0) * System.Math.Cos(AnglePi) + (y - y0) * System.Math.Sin(AnglePi)

    End Function

    '将绝对坐标转换为相对坐标，Y轴转换
    Public Function CoordinateY(ByVal x As Double, ByVal y As Double, ByVal Angle As Double, ByVal x0 As Double, ByVal y0 As Double) As Double
        Dim AnglePi As Double = (Angle - 90) * (Math.PI) / 180
        CoordinateY = (y - y0) * System.Math.Cos(AnglePi) - (x - x0) * System.Math.Sin(AnglePi)
    End Function
    ''' <summary>
    ''' 将相对坐标转换为绝对坐标
    ''' </summary>
    ''' <param name="x0"></param>
    ''' <param name="X1"></param>
    ''' <param name="Y1"></param>
    ''' <param name="angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CoorX(ByVal x0 As Double, ByVal X1 As Double, ByVal Y1 As Double, ByVal angle As Double) As Double
        Dim AnglePi As Double = (angle - 90) * (Math.PI) / 180
        CoorX = x0 + X1 * Math.Cos(AnglePi) - Y1 * Math.Sin(AnglePi)
    End Function
    ''' <summary>
    ''' 将相对坐标转换为绝对坐标
    ''' </summary>
    ''' <param name="y0"></param>
    ''' <param name="X1"></param>
    ''' <param name="Y1"></param>
    ''' <param name="angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Coory(ByVal y0 As Double, ByVal X1 As Double, ByVal Y1 As Double, ByVal angle As Double) As Double
        Dim AnglePi As Double = (angle - 90) * (Math.PI) / 180
        Coory = y0 + X1 * Math.Sin(AnglePi) + Y1 * Math.Cos(AnglePi)
    End Function

    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer, ByVal m_carepoint As CarePoint()) As String
        Dim ChangeDistance(m_carepoint.Length - 1) As CarePoint
        For i As Integer = 0 To ChangeDistance.Length - 1
            ChangeDistance(i) = New FireBlast.CarePoint
            ChangeDistance(i).Dist = m_carepoint(i).Dist  '名称
            ChangeDistance(i).Rpoint.x = CoordinateX(m_carepoint(i).Rpoint.x, m_carepoint(i).Rpoint.y, Me.m_JetFire.SourceAngle, Me.m_JetFire.SourcePoint.x, Me.m_JetFire.SourcePoint.y)
            ChangeDistance(i).Rpoint.y = CoordinateY(m_carepoint(i).Rpoint.x, m_carepoint(i).Rpoint.y, Me.m_JetFire.SourceAngle, Me.m_JetFire.SourcePoint.x, Me.m_JetFire.SourcePoint.y)
        Next
        Return Me.m_JetFire.GetResultString(dNum, pNum, m_carepoint, ChangeDistance)
    End Function
    ''' <summary>
    ''' 计算喷射火
    ''' </summary>
    ''' <param name="m_carepoint"></param>
    ''' <remarks></remarks>
    Public Sub Cal(ByVal m_carepoint As CarePoint())
        Dim ChangeDistance(m_carepoint.Length - 1) As CarePoint
        For i As Integer = 0 To ChangeDistance.Length - 1
            ChangeDistance(i) = New FireBlast.CarePoint
            ChangeDistance(i).Dist = m_carepoint(i).Dist  '名称
            ChangeDistance(i).Rpoint.x = CoordinateX(m_carepoint(i).Rpoint.x, m_carepoint(i).Rpoint.y, Me.m_JetFire.SourceAngle, Me.m_JetFire.SourcePoint.x, Me.m_JetFire.SourcePoint.y)
            ChangeDistance(i).Rpoint.y = CoordinateY(m_carepoint(i).Rpoint.x, m_carepoint(i).Rpoint.y, Me.m_JetFire.SourceAngle, Me.m_JetFire.SourcePoint.x, Me.m_JetFire.SourcePoint.y)
        Next
        Me.m_JetFire.Cal(m_carepoint, ChangeDistance)
    End Sub
End Class
