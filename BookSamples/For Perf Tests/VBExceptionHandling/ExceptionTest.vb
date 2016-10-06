Public Class ExceptionTest
    Public Sub OnErrorMethod()
        On Error Resume Next

        Dim s(9) As Char
        s(0) = "a"
        s(1) = "b"
        s(2) = "b"
        s(3) = "b"
        s(4) = "b"
        s(5) = "b"
        s(6) = "b"
        s(7) = "b"
        s(8) = "b"
        s(9) = "b"
    End Sub

    Public Sub TryCatchMethod()
        Try
            Dim s(9) As Char
            s(0) = "a"
            s(1) = "b"
            s(2) = "b"
            s(3) = "b"
            s(4) = "b"
            s(5) = "b"
            s(6) = "b"
            s(7) = "b"
            s(8) = "b"
            s(9) = "b"
        Catch

        End Try
    End Sub
End Class
