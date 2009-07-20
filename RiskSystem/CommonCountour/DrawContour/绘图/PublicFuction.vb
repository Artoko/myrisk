Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Module PublicFuction

    Public ImageFileName As String
    Public Sub InsertBackImage(ByVal m_Pannel As Pannel)
        Dim frmDialog As New OpenFileDialog
        frmDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
        If frmDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ImageFileName = frmDialog.FileName
            If Not m_Pannel Is Nothing Then
                m_Pannel.BackImage.LoadBitmap(ImageFileName)
                ActivePaintForm.Refresh()
            End If
        End If
    End Sub
   
    Public Sub CutImage(ByVal m_Pannel As Pannel)
        If m_Pannel IsNot Nothing Then
            If m_Pannel.BackImage.CutImage = True Then
                m_Pannel.BackImage.CutImage = False
            Else
                m_Pannel.BackImage.CutImage = True
            End If
            ActivePaintForm.Refresh()
        End If
    End Sub
    Public Sub StretchImage(ByVal m_Pannel As Pannel)
        If m_Pannel IsNot Nothing Then
            If m_Pannel.BackImage.BackInside = True Then
                m_Pannel.BackImage.BackInside = False
            Else
                m_Pannel.BackImage.BackInside = True
            End If
            ActivePaintForm.Refresh()
        End If
    End Sub
    Public Sub ImageVisible(ByVal m_Pannel As Pannel)
        If Not m_Pannel Is Nothing Then
            If m_Pannel.BackImage.BackVisible = True Then
                m_Pannel.BackImage.BackVisible = False
            Else
                m_Pannel.BackImage.BackVisible = True
            End If
            ActivePaintForm.Refresh()
        End If
    End Sub
End Module
