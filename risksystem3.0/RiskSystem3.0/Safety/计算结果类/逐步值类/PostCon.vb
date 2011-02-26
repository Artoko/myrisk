Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
<Serializable()> Public Class PostCon
    ''' <summary>
    ''' 时刻。指某气象条件对应的时刻
    ''' </summary>
    ''' <remarks></remarks>
    Public m_MetDateTime As Date
    ''' <summary>
    ''' 开始的时刻。单位min
    ''' </summary>
    ''' <remarks></remarks>
    Public m_StartTime As Double

    ''' <summary>
    ''' 步长。单位min
    ''' </summary>
    ''' <remarks></remarks>
    Public m_TimeStep As Double

    ''' <summary>
    ''' 第一气象条件下预测的时刻个数
    ''' </summary>
    ''' <remarks></remarks>
    Public m_TimeCount As Integer

    ''' <summary>
    ''' 网格点的值(第几个时刻,网格点Y,X)。网格点是按行压到数组中的
    ''' </summary>
    ''' <remarks></remarks>
    Public GridCon(,,) As Double
    ''' <summary>
    ''' 关心点的值(第几个时刻，关心点数)。网格点是按行压到数组中的
    ''' </summary>
    ''' <remarks></remarks>
    Public CareCon(,) As Double
    ''' <summary>
    ''' 根据对应的气象时刻储存相应的文件
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Save(ByVal Path As String, ByVal SourceID As String) As Boolean
        Dim again As Boolean = True
        Do
            '保存主项目文件------------------------------
            Dim fileStr As Stream = File.Open(Path & SourceID & "-" & Me.m_MetDateTime.Year.ToString & "-" & Me.m_MetDateTime.Month.ToString & "-" & Me.m_MetDateTime.Day.ToString & "-" & Me.m_MetDateTime.Hour.ToString & ".pst", FileMode.Create)
            Try
                Dim formatter As IFormatter
                formatter = CType(New BinaryFormatter, IFormatter)
                formatter.Serialize(fileStr, Me)
                fileStr.Dispose()
                ' All done
                fileStr.Close()
                Return True
            Catch ex As Exception
                fileStr.Close()
                If MsgBox("写文件时出现错误!错误原因如下：" & ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then
                    again = True
                Else
                    again = False
                    Return False
                End If
            End Try
        Loop While again = True
    End Function
    Public Shared Function Open(ByVal FileName As String) As PostCon
        Dim fileStr As Stream = Nothing
        Dim formatter As IFormatter
        Dim PostCon As New PostCon
        Dim obj As Object

        Try
            fileStr = File.Open(FileName, FileMode.Open)
            formatter = CType(New BinaryFormatter, IFormatter)
            fileStr.Seek(0, SeekOrigin.Begin)
            obj = formatter.Deserialize(fileStr)
            PostCon = CType(obj, PostCon)
            fileStr.Close()
            Return PostCon
        Catch ex As Exception
            fileStr.Close()
            Return Nothing
        End Try
    End Function
End Class
