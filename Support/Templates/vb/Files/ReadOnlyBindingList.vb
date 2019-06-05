Imports System
Imports System.Collections.Generic
Imports Csla
Imports Csla.Security

<Serializable()> _
Public Class ReadOnlyBindingList
  Inherits ReadOnlyBindingListBase(Of ReadOnlyBindingList, ReadOnlyChild)

#Region "Authorization Rules"

  Private Shared Sub AddObjectAuthorizationRules()
    ' TODO: add authorization rules 
    ' AuthorizationRules.AllowGet(GetType(ReadOnlyList), "Role")
  End Sub

#End Region

#Region "Factory Methods"

  Public Shared Function GetReadOnlyBindingList(ByVal filter As String) As ReadOnlyBindingList
    Return DataPortal.Fetch(Of ReadOnlyBindingList)(filter)
  End Function

#End Region

#Region "Data Access"

  Private Overloads Sub DataPortal_Fetch(ByVal criteria As String)
    RaiseListChangedEvents = False
    IsReadOnly = False
    ' TODO: load values 
    Dim objectData As Object = Nothing
    For Each child As Object In DirectCast(objectData, List(Of Object))
      Add(ReadOnlyChild.GetReadOnlyChild(child))
    Next
    IsReadOnly = True
    RaiseListChangedEvents = True
  End Sub

#End Region

End Class
