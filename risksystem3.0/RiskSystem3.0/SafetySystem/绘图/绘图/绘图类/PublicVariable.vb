Module PublicVariable

    Public gAxisRect As Rectangle '��ʾ����������ľ�������ת��������������
    Public gAxisLabelRect As Rectangle '��ʾ����������ı�ע������ת��������������
    Public gAxisTitleRect As Rectangle '��ʾ����������ı��������ת��������������
    Public gTitleRect As Rectangle '��ʾ���Ʊ��������
    Public gLegendContourFillRect As Rectangle '��ֵ�����ͼ��������δת�����������
    Public gLegendContourLineRect As Rectangle '��ֵ�����ͼ��������δת�����������
    Public gLegendSymbolRect As Rectangle '��ֵ�����ͼ��������δת�����������

    Public gRightLegendPoint As Single '��ʾ����ı�����ұߣ����ڻ���ͼ��
    Public mmScale As Single = 10 '1mm��ʾ10m��ʵ�ʱ���Ϊ1:10000����������1000m��Ϊ100mmĬ�ϵĿ�ȣ�������Ϊ5000m����Ӧ�øı����,ӦΪ5000/1000����ˣ�ʵ�ʱ���ӦΪmmScale*1000
    Public gScale As Single = 1 '��ͼ���������ڲ������ػ�ͼ����Ӧ��������Ϊmm��
    Public gWidth As Single = 2000 '����Ŀ��Ĭ�Ͽ��Ϊ2000m
    Public gHeight As Single = 2000 '����Ŀ��Ĭ�ϸ߶�Ϊ2000m
    Public gVMainIncrease As Single = 500 '��ֱ������̶ȼ��
    Public gHMainIncrease As Single = 500 'ˮƽ������̶ȼ��
    Public Const MMTOPIX = 0.265 '�����ػ���mm�ĳ���

    Public OriginX As Integer = 70 / MMTOPIX
    Public OriginY As Integer = 70 / MMTOPIX
    Public BackOriginX As Integer = 10
    Public BackOriginY As Integer = -10
    Public BackgScale As Single = 1 'Ĭ��ֵΪ1����������

    Public PaintType As Single = 0 '��ͼ�����ͣ�0Ϊ��ֵ�ߣ�1Ϊ���ֱ�ը


    Public OriginToUtm As Point

End Module
