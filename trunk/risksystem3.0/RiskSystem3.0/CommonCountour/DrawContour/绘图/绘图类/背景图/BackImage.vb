Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
<Serializable()> Public Class BackImage
    Public BackRect As New Rectangle() '����ͼ�ľ��Ρ�������ľ���
    Public ImageRect As New Rectangle() 'ͼ�εĴ�С��λ��
    Public BackInside As Boolean = False  '��ͼ��־�����ΪTrue ����䰴���������з��������򰴱������з���
    Public BackVisible As Boolean = True  '����ͼ�Ƿ�ɼ�
    Public CutImage As Boolean = False   '����ͼ��
    Public imageFileName As String '����ͼ���ļ���
    Private bmp As Bitmap '��ͼ

    Property bitmap() As Bitmap '��ͼ
        Get
            Return Me.bmp
        End Get
        Set(ByVal value As Bitmap)
            Me.bmp = value
        End Set
    End Property
    Public Sub LoadBitmap(ByVal imageFile As String)
        Try
            imageFileName = imageFile
            bmp = New Bitmap(imageFileName)
            ImageRect.Width = bmp.Width
            ImageRect.Height = bmp.Height
        Catch ex As Exception

        End Try

    End Sub
    Public Sub UnloadBitmap()
        If bmp IsNot Nothing Then
            bmp.Dispose()
            bmp = Nothing
        End If
    End Sub
    Public Sub DrawImage(ByVal grap As Graphics)
        'The existing bitmap.
        If bmp IsNot Nothing Then
            If BackVisible Then '����ɼ����ͼ
                If BackInside Then '�������ͼ��־Ϊtrue ����з��� 'ͨ��������ͼ��������תͼ��
                    Dim destinationPoints As PointF() = { _
                         New Point(PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height), _
                         New Point(PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height), _
                         New Point(PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y)}
                    grap.DrawImage(bmp, destinationPoints)
                Else
                    'BackRect.X = ImageRect.X -PannelSetting.OriginX *PannelSetting.gScale + BackPannelSetting.OriginX *PannelSetting.gScale
                    'BackRect.Y = ImageRect.Y +PannelSetting.OriginY *PannelSetting.gScale + BackPannelSetting.OriginY *PannelSetting.gScale - ImageRect.Height *PannelSetting.gScale * BackPannelSetting.gScale
                    'BackRect.Width = ImageRect.Width *PannelSetting.gScale * BackPannelSetting.gScale
                    'BackRect.Height = ImageRect.Height *PannelSetting.gScale * BackPannelSetting.gScale
                    Dim destinationPoints As PointF() = { _
                                             New Point(BackRect.X, BackRect.Y + BackRect.Height), _
                                             New Point(BackRect.X + BackRect.Width, BackRect.Y + BackRect.Height), _
                                             New Point(BackRect.X, BackRect.Y)}
                    If CutImage = True Then
                        Dim x As Integer = (PannelSetting.gAxisRect.X - BackRect.X) * bmp.Width / BackRect.Width
                        Dim y As Integer = (BackRect.Y + BackRect.Height - (PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height)) * bmp.Height / BackRect.Height
                        Dim width As Integer = bmp.Width * PannelSetting.gAxisRect.Width / BackRect.Width
                        Dim height As Integer = bmp.Height * PannelSetting.gAxisRect.Height / BackRect.Height
                        Dim destinationRect As New Rectangle(x, y, width, height)
                        Dim destPoint() As PointF = { _
                         New Point(PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height), _
                         New Point(PannelSetting.gAxisRect.X + PannelSetting.gAxisRect.Width, PannelSetting.gAxisRect.Y + PannelSetting.gAxisRect.Height), _
                         New Point(PannelSetting.gAxisRect.X, PannelSetting.gAxisRect.Y)}
                        grap.DrawImage(bmp, destPoint, destinationRect, GraphicsUnit.Pixel)
                    Else
                        grap.DrawImage(bmp, destinationPoints)
                    End If
                End If
            End If

            ' bmp.Dispose()
        End If

    End Sub


    Public Sub Zoom(ByVal grap As Graphics, ByVal delta As Integer)
        If BackRect.Width > 0 And BackRect.Height > 0 And BackInside = False Then
            PannelSetting.BackgScale = PannelSetting.BackgScale + PannelSetting.BackgScale * delta / 5000
        End If
    End Sub
End Class
