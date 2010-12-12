''' <summary>
''' 各点高值
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure Rectable
    ''' <summary>
    ''' 网格点的各点高值(第n大，网格点Y,X)。网格点是按行压到数组中的
    ''' </summary>
    ''' <remarks></remarks>
    Public GridRectbleConAndTime(,,) As RectableConAndTime
    ''' <summary>
    ''' 关心点的各点高值(第n大，关心点数)。网格点是按行压到数组中的
    ''' </summary>
    ''' <remarks></remarks>
    Public CareRectbleConAndTime(,) As RectableConAndTime
End Structure
