Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
<Serializable()> Public Class ImportImages
    Private m_ImportBack1 As New CImPortImage.InsertImage
    Private m_ImportBack2 As New CImPortImage.InsertImage
    ''' <summary>
    ''' 地理位置图
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ImportBack1() As CImPortImage.InsertImage
        Get
            Return Me.m_ImportBack1
        End Get
        Set(ByVal value As CImPortImage.InsertImage)
            Me.m_ImportBack1 = value
        End Set
    End Property
    ''' <summary>
    ''' 厂区平面图
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ImportBack2() As CImPortImage.InsertImage
        Get
            Return Me.m_ImportBack2
        End Get
        Set(ByVal value As CImPortImage.InsertImage)
            Me.m_ImportBack2 = value
        End Set
    End Property

End Class

