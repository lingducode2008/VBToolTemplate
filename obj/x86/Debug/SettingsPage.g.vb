﻿#ExternalChecksum("C:\Users\Administrator\Desktop\vbtool\vba云母\SettingsPage.xaml", "{8829d00f-11b8-4213-878b-770e8597ac16}", "9F428D3B2721D0C1B937875129235A92BA43A1015CAAA75585D32188F158EA78")
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

    Partial Class SettingsPage
        Implements Global.Windows.UI.Xaml.Markup.IComponentConnector
        Implements Global.Windows.UI.Xaml.Markup.IComponentConnector2


        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", " 0.0.0.0")>  _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub Connect(ByVal connectionId As Integer, ByVal target As Global.System.Object) Implements Global.Windows.UI.Xaml.Markup.IComponentConnector.Connect
            Select Case connectionId
            Case 2 ' SettingsPage.xaml line 13
                    Me.G1 = CType(target, Global.Windows.UI.Xaml.Controls.Grid)
                    Exit Select
            Case 3 ' SettingsPage.xaml line 43
                    Dim element3 As Global.Windows.UI.Xaml.Controls.ComboBox = CType(target, Global.Windows.UI.Xaml.Controls.ComboBox)
                AddHandler DirectCast(element3, Global.Windows.UI.Xaml.Controls.ComboBox).SelectionChanged, AddressOf Me.Window_SelectionChanged
                    Exit Select
            Case 4 ' SettingsPage.xaml line 33
                    Dim element4 As Global.Windows.UI.Xaml.Controls.ComboBox = CType(target, Global.Windows.UI.Xaml.Controls.ComboBox)
                AddHandler DirectCast(element4, Global.Windows.UI.Xaml.Controls.ComboBox).SelectionChanged, AddressOf Me.ComboBox_SelectionChanged
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

