﻿#ExternalChecksum("C:\Users\Administrator\Desktop\vbtool\vba云母\Main.xaml", "{8829d00f-11b8-4213-878b-770e8597ac16}", "52D9CA1D08892A1664182E9C953112EE115F7C353AA72A86E09ED1181D0D8365")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Namespace Global.vba

    Partial Class Main
        Implements Global.Windows.UI.Xaml.Markup.IComponentConnector
        Implements Global.Windows.UI.Xaml.Markup.IComponentConnector2


        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 0.0.0.0")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub Connect(ByVal connectionId As Integer, ByVal target As Global.System.Object) Implements Global.Windows.UI.Xaml.Markup.IComponentConnector.Connect
            Select Case connectionId
            Case 2 ' Main.xaml line 13
                    Me.G1 = CType(target, Global.Windows.UI.Xaml.Controls.Grid)
                    Exit Select
            Case 3 ' Main.xaml line 25
                    Dim element3 As Global.Windows.UI.Xaml.Controls.Button = CType(target, Global.Windows.UI.Xaml.Controls.Button)
                AddHandler DirectCast(element3, Global.Windows.UI.Xaml.Controls.Button).Click, AddressOf Me.Tongzhi
                    Exit Select
            Case 4 ' Main.xaml line 27
                    Me.TongzhiTip = CType(target, Global.Microsoft.UI.Xaml.Controls.TeachingTip)
                    Exit Select
            Case 5 ' Main.xaml line 32
                    Me.tb0 = CType(target, Global.Windows.UI.Xaml.Controls.TextBox)
                    Exit Select
            Case 6 ' Main.xaml line 35
                    Me.tb1 = CType(target, Global.Windows.UI.Xaml.Controls.TextBox)
                    Exit Select
            Case 7 ' Main.xaml line 38
                    Me.b0 = CType(target, Global.Windows.UI.Xaml.Controls.Button)
                AddHandler DirectCast(Me.b0, Global.Windows.UI.Xaml.Controls.Button).Click, AddressOf Me.b0_click
                    Exit Select
                    Case Else
                        Exit Select
            End Select
                Me._contentLoaded = true
        End Sub

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 0.0.0.0")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function GetBindingConnector(connectionId As Integer, target As Object) As Global.Windows.UI.Xaml.Markup.IComponentConnector Implements Global.Windows.UI.Xaml.Markup.IComponentConnector2.GetBindingConnector
            Dim returnValue As Global.Windows.UI.Xaml.Markup.IComponentConnector = Nothing
            Return returnValue
        End Function
    End Class

End Namespace


