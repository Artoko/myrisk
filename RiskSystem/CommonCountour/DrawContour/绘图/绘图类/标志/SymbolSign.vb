Imports System.Drawing.Drawing2D
<Serializable()> Public Class SymbolSign
    Private mSymbolShape As New SymbolShape '��־����״
    Private mSymbolSize As Double = 1.4 '��־�Ĵ�С����mm��ʾ
    Private mSymbolColor As Color = Color.Red  '��־����ɫ
    Public mSymbolsPoint As PointF '��־��λ�ã��������ʾλ�á�ÿ0����Ϊ��Դ��λ�ã��������Դ������ƶ����
    Public Property SymbolShape() As SymbolShape
        Get
            Return mSymbolShape
        End Get
        Set(ByVal value As SymbolShape)
            mSymbolShape = value
        End Set
    End Property
    Public Property SymbolSize() As Double
        Get
            Return mSymbolSize
        End Get
        Set(ByVal value As Double)
            mSymbolSize = value
        End Set
    End Property
    Public Property SymbolColor() As Color
        Get
            Return mSymbolColor
        End Get
        Set(ByVal value As Color)
            mSymbolColor = value
        End Set
    End Property
    Public Sub DrawSymbolSign(ByVal grap As Graphics) '���Ʊ�־

        Dim myMatrix As New Matrix()
        Dim graphicsContainer As GraphicsContainer 'Ƕ�׵� Graphics ���� 
        graphicsContainer = grap.BeginContainer() '��ʼǶ�׵� Graphics ����
        myMatrix.Translate(mSymbolsPoint.X, mSymbolsPoint.Y) 'ƽ�Ƶ����ֵ�
        myMatrix.Scale(PannelSetting.gScale, PannelSetting.gScale) '�����尴�����ط�
        myMatrix.Multiply(New Matrix(1, 0, 0, -1, 0, 0)) '��ת
        grap.Transform = myMatrix
        Dim rect As Rectangle
        rect.X = -mSymbolSize / 2 / PannelSetting.MMTOPIX '�����mm�ı���
        rect.Y = -mSymbolSize / 2 / PannelSetting.MMTOPIX
        rect.Width = mSymbolSize / PannelSetting.MMTOPIX
        rect.Height = mSymbolSize / PannelSetting.MMTOPIX
        mSymbolShape.SymbolShapeColor = mSymbolColor
        mSymbolShape.DrawSymbolShape(grap, rect)
        grap.EndContainer(graphicsContainer) '�˳���ͼ����

    End Sub
End Class
