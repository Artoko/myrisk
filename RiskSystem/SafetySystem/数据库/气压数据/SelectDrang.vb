Public Class SelectDrang
    Private rstUserList As ADODB.Recordset
    Private strUserName3, strUserName1, strUserName2, strUserName4 As String
    Private strUserName0 As String
    Private m_Province As String = ""
    Private m_City As String = ""
    Private objConn As ADODB.Connection
    Private stSQL As String


    Private Function Source() As String
        'Database is located in same dir as app

        If My.Application.Info.DirectoryPath = "\" Then
            Source = My.Application.Info.DirectoryPath & "tq.txt"
        Else
            Source = My.Application.Info.DirectoryPath & "\" & "tq.txt"
        End If

    End Function

    Private Sub Data_Conn()
        'Open database connection to Access 2000 datasource

        stSQL = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source = " & Source()

        objConn = New ADODB.Connection
        objConn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        objConn.Open(stSQL)

    End Sub
    Private Sub DB_Colse()
        objConn.Close()
        'UPGRADE_NOTE: 在对对象 conADO 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        objConn = Nothing

    End Sub

    Private Sub SelectDrang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.cobSeason.Text = "冬季"
        'Me.cobSeason.Items.Add("夏季")
        'Me.cobSeason.Items.Add("冬季")


        Dim LoadProvince As String = "select 字段1 from Noname2"
        LoadLstProvinceVal(LoadProvince)

        '给省份框赋值
        Dim ProvinceSql As String = ""
        ProvinceSql = "select top 1 字段1 from Noname2"
        Dim top As String = TopProvince(ProvinceSql)
        Me.ctxtP.Text = top
        '给地区框赋值
        Dim a As String = "select top 1 字段3 from Noname1 where 字段2 ='" + top + "'"

        Me.ctxtCity.Text = TopCity(a)

        '给 lstCity 框赋值
        Dim CitySql As String = "select 字段3 from Noname1 where 字段2= '" + top + "'"
        LstCityVal(CitySql)
        '给纬度，经度，季节 框赋值
        Dim f As String = "select top 1 字段5,字段6,字段7 from Noname1 "
        InFo(f)

        lstProvince.SelectedIndex = 0
        lstProvince_SelectedIndexChanged(sender, e)
        lstCity.SelectedIndex = 0
        lstCity_SelectedIndexChanged(sender, e)
        cobSeason.SelectedIndex = 0
        cob_SelectedIndexChanged(sender, e)
    End Sub
    ''' <summary>
    ''' 在窗体加载时 给 LstProvince 框赋值
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <remarks></remarks>
    Private Sub LoadLstProvinceVal(ByVal sql As String)
        UnEncrypt(Source) '解密数据库

        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集


        rstUserList.Open(sql, objConn)
        Do Until rstUserList.EOF = True
            If IsDBNull(rstUserList.Fields("字段1").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段1").Value
            End If
            lstProvince.Items.Add(strUserName0)
            rstUserList.MoveNext()
        Loop

        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
    End Sub
    ''' <summary>
    ''' 在窗体加载时 给省份框赋值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TopProvince(ByVal sender As String) As String
        UnEncrypt(Source) '解密数据库
        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集

        rstUserList.Open(sender, objConn)
        'Do Until rstUserList.EOF = True
        If IsDBNull(rstUserList.Fields("字段1").Value) Then
            strUserName0 = ""
        Else
            strUserName0 = rstUserList.Fields("字段1").Value
        End If
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
        Return strUserName0
    End Function
    ''' <summary>
    ''' 在窗体加载时 给地区框赋值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TopCity(ByVal sender As String) As String
        UnEncrypt(Source) '解密数据库
        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集

        rstUserList.Open(sender, objConn)
        Do Until rstUserList.EOF = True
            If IsDBNull(rstUserList.Fields("字段3").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段3").Value
            End If

            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
        Return strUserName0

    End Function

    Private Sub lstProvince_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstProvince.MouseDown
        
    End Sub
    ''' <summary>
    ''' 给 lstCity 框赋值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub LstCityVal(ByVal sender As String)
        UnEncrypt(Source) '解密数据库
        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集
        'Dim sql As String = "select 字段1 from ProvinceTable "
        rstUserList.Open(sender, objConn)
        Do Until rstUserList.EOF = True
            If IsDBNull(rstUserList.Fields("字段3").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段3").Value
            End If
            lstCity.Items.Add(strUserName0)
            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
    End Sub
    ''' <summary>
    ''' 得到 lstCity框 的第一个数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CityData(ByVal sender As String) As String
        UnEncrypt(Source) '解密数据库
        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集

        rstUserList.Open(sender, objConn)
        Do Until rstUserList.EOF = True
            If IsDBNull(rstUserList.Fields("字段3").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段3").Value
                Exit Do
            End If
            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
        Return strUserName0
    End Function
    ''' <summary>
    ''' 给纬度，经度，季节 赋值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub InFo(ByVal sender As String)
        UnEncrypt(Source) '解密数据库

        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集

        rstUserList.Open(sender, objConn)
        Do Until rstUserList.EOF = True

            If IsDBNull(rstUserList.Fields("字段5").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段5").Value
            End If
            If IsDBNull(rstUserList.Fields("字段6").Value) Then
                strUserName1 = ""
            Else
                strUserName1 = rstUserList.Fields("字段6").Value
            End If
            If IsDBNull(rstUserList.Fields("字段7").Value) Then
                strUserName2 = ""
            Else
                strUserName2 = rstUserList.Fields("字段7").Value
            End If


            Me.ctxtN.Text = strUserName0
            Me.ctxtE.Text = strUserName1

            Me.ctxtSeason.Text = strUserName2

            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
    End Sub
    Private Sub lstCity_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstCity.MouseDown
        
    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSeason.SelectedIndexChanged
        If cobSeason.Text = "冬季" Then
            Dim Winterlysql As String = "select 字段7 from Noname1 where 字段2 = '" + Me.ctxtP.Text + "' and 字段3= '" + Me.ctxtCity.Text + "'"
            Me.ctxtSeason.Text = SeasonWinterly(Winterlysql)
        Else
            Dim Estivalsql As String = "select 字段8 from Noname1 where 字段2 = '" + Me.ctxtP.Text + "' and 字段3= '" + Me.ctxtCity.Text + "'"
            Me.ctxtSeason.Text = SeasonEstival(Estivalsql)
        End If
        
    End Sub
    ''' <summary>
    ''' 当 cobSeason 选择夏季时
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SeasonEstival(ByVal sender As String) As String
        UnEncrypt(Source) '解密数据库
        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集
        'Dim sql As String = "select 字段1 from ProvinceTable "
        rstUserList.Open(sender, objConn)
        Do Until rstUserList.EOF = True
            If IsDBNull(rstUserList.Fields("字段8").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段8").Value
                Exit Do
            End If
            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
        Return strUserName0
    End Function
    ''' <summary>
    ''' 当 cobSeason 选择冬季时
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SeasonWinterly(ByVal sender As String) As String
        UnEncrypt(Source) '解密数据库
        Call Data_Conn() '连接数据库
        rstUserList = New ADODB.Recordset '设置记录集
        'Dim sql As String = "select 字段1 from ProvinceTable "
        rstUserList.Open(sender, objConn)
        Do Until rstUserList.EOF = True
            If IsDBNull(rstUserList.Fields("字段7").Value) Then
                strUserName0 = ""
            Else
                strUserName0 = rstUserList.Fields("字段7").Value
                Exit Do
            End If
            rstUserList.MoveNext()
        Loop
        rstUserList.Close() '关闭记录集
        rstUserList = Nothing
        DB_Colse() '断开数据库
        Encrypt(Source) '加密数据库
        Return strUserName0
    End Function

    Private Sub btnQuilt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub lstProvince_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProvince.SelectedIndexChanged
        Dim sql As String
        Dim s As String

        s = Me.lstProvince.Text
        sql = "select 字段3 from Noname1 where 字段2= '" + s + "'"
        Me.lstCity.Items.Clear()
        LstCityVal(sql)
        ctxtP.Text = Me.lstProvince.Text

        Dim c As String
        c = "select  top 1 字段3 from Noname1 where 字段2= '" + s + "'"
        ctxtCity.Text = CityData(c)


        Dim d As String
        d = Me.ctxtCity.Text
        Dim f As String
        f = "select 字段5,字段6,字段7 from Noname1 where 字段2 ='" + s + "' and 字段3 ='" + d + "'"

        InFo(f)
        lstCity.SelectedIndex = 0
        lstCity_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub lstCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCity.SelectedIndexChanged

        Dim sql As String
        Dim city As String
        city = Me.lstCity.Text
        sql = "select * from Noname1 where 字段3 = '" + city + "'"
        InFo(sql)
        Me.ctxtCity.Text = Me.lstCity.Text
        cob_SelectedIndexChanged(sender, e)
    End Sub
End Class