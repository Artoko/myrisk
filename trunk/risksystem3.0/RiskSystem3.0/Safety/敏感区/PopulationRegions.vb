<Serializable()> Public Class PopulationRegions
    Implements ICloneable


    Public ArrayPopulationRegion(-1) As PopulationRegion
    Public nPopulationRegion As Integer = 0
    Public SelectedIndex As Integer = -1
    Public Sub SetPopulations(ByRef Grid As Grid)
        For i As Integer = 0 To Me.ArrayPopulationRegion.Length - 1
            Me.ArrayPopulationRegion(i).SetPopulation(Grid)
        Next
    End Sub


    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim obj As New PopulationRegions
        obj.nPopulationRegion = Me.nPopulationRegion
        ReDim obj.ArrayPopulationRegion(Me.ArrayPopulationRegion.Length - 1)
        For i As Integer = 0 To Me.ArrayPopulationRegion.Length - 1
            obj.ArrayPopulationRegion(i) = New PopulationRegion
            obj.ArrayPopulationRegion(i) = Me.ArrayPopulationRegion(i).Clone


        Next
        obj.SelectedIndex = Me.SelectedIndex
        Return obj
    End Function
End Class
