Public Class LateBindingTest
    Public Function LateBindingMethod(ByRef o As Object) As Integer
        Return o.Count + 1
    End Function

    Public Function EarlyBoundMethod(ByRef al As ArrayList) As Integer
        Return al.Count + 1
    End Function
End Class
