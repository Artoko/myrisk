Module Declaration
    Public Const FreezingPoint As Double = 273.15 '0���϶ȵľ����¶�
    Public Const MooreR As Double = 8.314 'Ħ�����峣��RΪ8.314J.K-1.mol-1
    Public Const Gravity As Double = 9.8 '�������ٶ�

End Module
<Serializable()> Public Structure Point3D
    Public x As Double
    Public y As Double
    Public z As Double
End Structure
''' <summary>
''' ����ֵ�Ľṹ
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure MaxCD
    Public MaxC As Double '����ֵ��Ũ��
    Public MaxD As Double '����ֵ���ֵľ���
    Public maxT As Double '����ֵ���ֵ�ʱ��
End Structure

<Serializable()> Public Structure Point2D
    Public x As Double
    Public y As Double
End Structure