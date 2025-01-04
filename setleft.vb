Imports Microsoft.UI.Xaml.Controls
Imports vba.MainPage
Imports Windows.Devices.Enumeration
Namespace Services
    Public Module GlobalControls
        Public NavView
    End Module

    Public NotInheritable Class setleft
        Public Shared Function SetLeft()
            NavView.PaneDisplayMode = NavigationViewPaneDisplayMode.Left
            NavView.IsSettingsVisible = False
        End Function
        Public Shared Function SetTop()
            NavView.PaneDisplayMode = NavigationViewPaneDisplayMode.Top
            NavView.IsSettingsVisible = False
        End Function
    End Class
End Namespace