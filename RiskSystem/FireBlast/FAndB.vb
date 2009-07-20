Public Class FAndB
    Private m_FType As Integer '���ֱ�ը����
    ''' <summary>
    ''' Ԥ�ⷶΧ
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Grid As New Grid
    Protected m_carepoint(-1) As CarePoint '��������
    ''' <summary>
    ''' �����Ʊ�ը
    ''' </summary>
    ''' <remarks></remarks>
    Private m_UVCE As New UVCE
    ''' <summary>
    ''' �����౬ը
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MaterialTNT As New MaterialTNT
    ''' <summary>
    ''' ����վ��ը
    ''' </summary>
    ''' <remarks></remarks>
    Private m_GasStation As New GasStation
    ''' <summary>
    ''' ����ը
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PhysicsExplode As New PhysicsExplode
    ''' <summary>
    ''' �ػ���
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PoolFire As New PoolFireLogic
    ''' <summary>
    ''' bleve
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Bleve As New Bleve
    ''' <summary>
    ''' �������
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SolidFire As New SolidFire
    ''' <summary>
    ''' �����
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Jet As New Jet


    ''' <summary>
    ''' ���ֱ�ը����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FType() As Integer
        Get
            Return Me.m_FType
        End Get
        Set(ByVal value As Integer)
            Me.m_FType = value
        End Set
    End Property
    ''' <summary>
    ''' ��������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property carepoint() As CarePoint()
        Get
            Return Me.m_carepoint
        End Get
        Set(ByVal value As CarePoint())
            Me.m_carepoint = value
        End Set
    End Property
    ''' <summary>
    ''' �����Ʊ�ը��TNT����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UVCE() As UVCE
        Get
            Return Me.m_UVCE
        End Get
        Set(ByVal value As UVCE)
            Me.m_UVCE = value
        End Set
    End Property
    ''' <summary>
    ''' �����౬ը
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MaterialTNT() As MaterialTNT
        Get
            Return Me.m_MaterialTNT
        End Get
        Set(ByVal value As MaterialTNT)
            Me.m_MaterialTNT = value
        End Set
    End Property
    ''' <summary>
    ''' ����վ��ը
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GasStation() As GasStation
        Get
            Return Me.m_GasStation
        End Get
        Set(ByVal value As GasStation)
            Me.m_GasStation = value
        End Set
    End Property
    ''' <summary>
    ''' ���ֱ�ը
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PhysicsExplode() As PhysicsExplode
        Get
            Return Me.m_PhysicsExplode
        End Get
        Set(ByVal value As PhysicsExplode)
            Me.m_PhysicsExplode = value
        End Set
    End Property
    ''' <summary>
    ''' Ԥ�ⷶΧ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Grid() As Grid
        Get
            Return Me.m_Grid
        End Get
        Set(ByVal value As Grid)
            Me.m_Grid = value
        End Set
    End Property
    ''' <summary>
    ''' �ػ���
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PoolFire() As PoolFireLogic
        Get
            Return Me.m_PoolFire
        End Get
        Set(ByVal value As PoolFireLogic)
            Me.m_PoolFire = value
        End Set
    End Property
    ''' <summary>
    ''' bleve
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Bleve() As Bleve
        Get
            Return Me.m_Bleve
        End Get
        Set(ByVal value As Bleve)
            Me.m_Bleve = value
        End Set
    End Property
    ''' <summary>
    ''' �������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SolidFire() As SolidFire
        Get
            Return Me.m_SolidFire
        End Get
        Set(ByVal value As SolidFire)
            Me.m_SolidFire = value
        End Set
    End Property
    ''' <summary>
    ''' �����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Jet() As Jet
        Get
            Return Me.m_Jet
        End Get
        Set(ByVal value As Jet)
            Me.m_Jet = value
        End Set
    End Property
    Public Sub Cal()
        Select Case Me.m_FType
            Case 0
                Me.m_UVCE.Cal(m_carepoint)
            Case 1
                Me.m_MaterialTNT.Cal(m_carepoint)
            Case 2
                Me.m_GasStation.Cal(m_carepoint)
            Case 3
                Me.m_PhysicsExplode.Cal(m_carepoint)


            Case 10
                Me.m_PoolFire.Cal(m_carepoint)
            Case 11
                Me.m_Bleve.Cal(m_carepoint)
            Case 12
                Me.m_SolidFire.Cal(m_carepoint)
            Case 13
                Me.m_Jet.Cal(m_carepoint)
        End Select
    End Sub
    ''' <summary>
    ''' ���ػ��ֱ�ը�ļ���������������
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultString(ByVal dNum As Integer, ByVal pNum As Integer) As String

        Dim strRe = ""
        Select Case Me.m_FType
            Case 0
                strRe += Me.m_UVCE.GetResultString(dNum, pNum, m_carepoint)
            Case 1
                strRe += Me.m_MaterialTNT.GetResultString(dNum, pNum, m_carepoint)
            Case 2
                strRe += Me.m_GasStation.GetResultString(dNum, pNum, m_carepoint)
            Case 3
                strRe += Me.PhysicsExplode.GetResultString(dNum, pNum, m_carepoint)


            Case 10
                strRe += Me.m_PoolFire.GetResultString(dNum, pNum, m_carepoint)

            Case 11
                strRe += Me.m_Bleve.GetResultString(dNum, pNum, m_carepoint)
            Case 12
                strRe += Me.m_SolidFire.GetResultString(dNum, pNum, m_carepoint)
            Case 13
                strRe += Me.m_Jet.GetResultString(dNum, pNum, m_carepoint)
        End Select
        Return strRe
    End Function
End Class
