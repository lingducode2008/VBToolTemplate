Imports Windows.Storage
Imports System.Threading.Tasks

Module StorageExtensions
    ' �첽����
    Public Async Function SaveAsync(Of T)(settings As ApplicationDataContainer, key As String, value As T) As Task
        Await Task.Run(Sub() settings.Values(key) = value)
    End Function

    ' �첽��ȡ
    Public Async Function ReadAsync(Of T)(settings As ApplicationDataContainer, key As String) As Task(Of T)
        Return Await Task.Run(Function() CType(settings.Values(key), T))
    End Function
End Module
