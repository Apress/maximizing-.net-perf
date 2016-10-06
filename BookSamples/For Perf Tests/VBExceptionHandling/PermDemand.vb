Imports System.Security
Imports System.Security.Permissions

Public Class PermDemand

    Public Function DoubleValNone(ByVal i As Int32) As Int32
        Return i * 2
    End Function

    <ReflectionPermissionAttribute(SecurityAction.Demand, Unrestricted:=True)> _
    Public Function DoubleValDemand(ByVal i As Int32) As Int32
        Return i * 2
    End Function

    <ReflectionPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
   Public Function DoubleValLinkDemand(ByVal i As Int32) As Int32
        Return i * 2
    End Function
End Class
