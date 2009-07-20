Module PublicVal
    Public boolClose As Boolean = False  '关闭窗口标志
    
    Public nStack As Integer = 0  '污染源编号
    Public nSourceName As Integer = 0 '污染源的名称
    Public nDiscCart As Integer = 0 '关心点的编号
    Public METTIMES As Integer = 24 '每天的气象数据次数

    Public sCreateAermodWindow As Boolean = False  '是否创建aermod窗体

    Public Project0 As New Project '公共项目
    Public Vesion As Integer = 2 '1为单位版，2为单机版

    Public strjmCode As String = "woasdfgjyikhgighkghjkdfasdfc" '加密码
End Module

