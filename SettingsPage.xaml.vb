Imports Microsoft.UI.Xaml
Imports vba.MainPage
Imports vba.Services
Imports Microsoft.UI.Xaml.Controls
Imports Microsoft.UI.Xaml.Media
Imports Windows.UI.Core
Imports Windows.UI.ViewManagement
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Input
' https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class SettingsPage
    Inherits Page

    Public Sub New()
        InitializeComponent()
        AddHandler ThemeSelectorService.ThemeChanged, AddressOf OnThemeChanged

        ' 启用自定义标题栏
        SetAcrylicBrushForCurrentTheme()
    End Sub

    Private Sub OnThemeChanged(sender As Object, e As EventArgs)
        ' 当主题变化时更新背景
        SetAcrylicBrushForCurrentTheme()
    End Sub
    Private Sub SetAcrylicBrushForCurrentTheme()
        ' 获取当前的主题
        Dim currentTheme As ElementTheme = ThemeSelectorService.GetCurrentTheme()

        ' 根据当前主题选择不同的 AcrylicBrush
        If currentTheme = ElementTheme.Dark Then
            ' 使用暗模式的 AcrylicBrush
            G1.Background = CType(G1.Resources("AcrylicBrushDark"), Windows.UI.Xaml.Media.AcrylicBrush)
        Else
            ' 使用亮模式的 AcrylicBrush
            G1.Background = CType(G1.Resources("AcrylicBrushLight"), Windows.UI.Xaml.Media.AcrylicBrush)
        End If
    End Sub
    Private Async Sub ComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ' 获取 ComboBox 控件
        Dim comboBox As ComboBox = CType(sender, ComboBox)

        ' 获取当前选中的项
        Dim selectedItem As String = CType(comboBox.SelectedItem, String)

        ' 获取选中项的内容
        If selectedItem IsNot Nothing Then
            ' 创建一个完全透明的颜色
            Dim transparentColor As Windows.UI.Color = Windows.UI.Color.FromArgb(0, 0, 0, 0)
            Dim Black As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 0, 0, 0)
            Dim White As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 255, 255, 255)
            Dim c454545 As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 45, 45, 45)
            Dim c414141 As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 41, 41, 41)
            Dim c167167167 As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 167, 167, 167)
            Dim c233233233 As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 233, 233, 233)
            Dim c237237237 As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 237, 237, 237)
            Dim c959595 As Windows.UI.Color = Windows.UI.Color.FromArgb(255, 95, 95, 95)
            Dim titleBar = ApplicationView.GetForCurrentView().TitleBar
            Dim selectedContent As String = selectedItem
            ' 执行你需要的操作，例如更新界面
            If selectedContent = "暗色" Then
                ' 设置为暗色主题
                Await ThemeSelectorService.SetThemeAsync(ElementTheme.Dark)
                titleBar.ButtonBackgroundColor = transparentColor
                titleBar.ButtonForegroundColor = White
                titleBar.ButtonInactiveBackgroundColor = transparentColor
                titleBar.ButtonHoverBackgroundColor = c454545
                titleBar.ButtonPressedBackgroundColor = c414141
                titleBar.ButtonPressedForegroundColor = c167167167
                titleBar.ButtonHoverForegroundColor = White

            ElseIf selectedContent = "亮色" Then
                ' 设置为亮色主题
                Await ThemeSelectorService.SetThemeAsync(ElementTheme.Light)
                titleBar.ButtonBackgroundColor = transparentColor
                titleBar.ButtonForegroundColor = Black
                titleBar.ButtonInactiveBackgroundColor = transparentColor
                titleBar.ButtonHoverBackgroundColor = c233233233
                titleBar.ButtonPressedBackgroundColor = c237237237
                titleBar.ButtonPressedForegroundColor = c959595
                titleBar.ButtonHoverForegroundColor = Black
            ElseIf selectedContent = "系统" Then
                ' 设置为系统主题
                Await ThemeSelectorService.SetThemeAsync(ElementTheme.Default)
                If ThemeSelectorService.IsDarkMode = True Then
                    titleBar.ButtonBackgroundColor = transparentColor
                    titleBar.ButtonForegroundColor = White
                    titleBar.ButtonInactiveBackgroundColor = transparentColor
                    titleBar.ButtonHoverBackgroundColor = c454545
                    titleBar.ButtonPressedBackgroundColor = c414141
                    titleBar.ButtonPressedForegroundColor = c167167167
                    titleBar.ButtonHoverForegroundColor = White
                Else
                    titleBar.ButtonBackgroundColor = transparentColor
                    titleBar.ButtonForegroundColor = Black
                    titleBar.ButtonInactiveBackgroundColor = transparentColor
                    titleBar.ButtonHoverBackgroundColor = c233233233
                    titleBar.ButtonPressedBackgroundColor = c237237237
                    titleBar.ButtonPressedForegroundColor = c959595
                    titleBar.ButtonHoverForegroundColor = Black
                End If
            End If
        End If
    End Sub

    Private Sub Window_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ' 获取 ComboBox 控件
        Dim comboBox As ComboBox = CType(sender, ComboBox)
        Dim navView As New NavigationView
        Dim titleBar = ApplicationView.GetForCurrentView().TitleBar
        ' 获取当前选中的项
        Dim selectedItem As String = CType(comboBox.SelectedItem, String)
        Dim selectedContent As String = selectedItem
        ' 获取选中项的内容
        If selectedItem IsNot Nothing Then
            If selectedContent = "横式" Then
                setleft.SetTop()
            Else selectedContent = "竖式"
                setleft.SetLeft()
            End If
        End If
    End Sub
End Class