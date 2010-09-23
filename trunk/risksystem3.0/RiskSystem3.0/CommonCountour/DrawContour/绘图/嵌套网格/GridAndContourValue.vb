Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
<Serializable()> Public Class GridAndContourValue
    Public m_nRows As Integer = 50
    Public m_nCols As Integer = 50  '网格点数组的大小
    Public m_Xmin As Double = -1000
    Public m_Ymin As Double = -1000
    Public m_Xmax As Double = 1000
    Public m_Ymax As Double = 1000 '网格的最大坐标和最小坐标
    Public ContourValueSetting As New ContourValueSetting

End Class
