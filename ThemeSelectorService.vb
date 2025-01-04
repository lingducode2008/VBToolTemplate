Imports Windows.ApplicationModel.Core
Imports Windows.Storage
Imports Windows.UI.Core
Imports Microsoft.UI.Xaml

Imports Windows.UI.Xaml.Media

Namespace Services
    Public NotInheritable Class ThemeSelectorService
        Private Sub New()
        End Sub

        Private Const SettingsKey As String = "AppBackgroundRequestedTheme"

        Public Shared Property Theme As ElementTheme = ElementTheme.Default

        Public Shared Event ThemeChanged As EventHandler

        ' 异步初始化主题
        Public Shared Async Function InitializeAsync() As Task
            Theme = LoadThemeFromSettings()
            Await SetRequestedThemeAsync()
        End Function

        ' 设置主题的异步方法
        Public Shared Async Function SetThemeAsync(theme As ElementTheme) As Task
            ThemeSelectorService.Theme = theme

            ' 设置主题并保存
            Await SetRequestedThemeAsync()
            SaveThemeInSettings(theme)

            RaiseEvent ThemeChanged(Nothing, EventArgs.Empty)
        End Function

        ' 异步设置请求的主题
        Public Shared Async Function SetRequestedThemeAsync() As Task
            For Each view In CoreApplication.Views
                Await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    Sub()
                        Dim frameworkElement = TryCast(Window.Current.Content, FrameworkElement)
                        If frameworkElement IsNot Nothing Then
                            frameworkElement.RequestedTheme = Theme
                        End If
                    End Sub)
            Next
        End Function

        ' 同步读取主题设置
        Private Shared Function LoadThemeFromSettings() As ElementTheme
            Dim cacheTheme As ElementTheme = ElementTheme.Default
            Dim themeName As String = If(ApplicationData.Current.LocalSettings.Values.ContainsKey(SettingsKey), CType(ApplicationData.Current.LocalSettings.Values(SettingsKey), String), "")

            If Not String.IsNullOrEmpty(themeName) Then
                [Enum].TryParse(themeName, cacheTheme)
            End If

            Return cacheTheme
        End Function

        ' 同步保存主题设置
        Private Shared Sub SaveThemeInSettings(theme As ElementTheme)
            ApplicationData.Current.LocalSettings.Values(SettingsKey) = theme.ToString()
        End Sub

        ' 新增：判断当前主题是否为暗黑模式
        Public Shared Function IsDarkMode() As Boolean
            Return Theme = ElementTheme.Dark
        End Function

        ' 新增：获取当前主题
        Public Shared Function GetCurrentTheme() As ElementTheme
            Return Theme
        End Function
    End Class
End Namespace
