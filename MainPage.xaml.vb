Imports Microsoft.UI.Xaml.Controls
Imports Microsoft.UI.Xaml.Media
Imports vba.Services
Imports Windows.ApplicationModel.Core
Imports Windows.UI
Imports Windows.UI.Core
Imports Windows.UI.ViewManagement
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Input

' https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class MainPage

    ' 在窗口的最大化、恢复等状态变化时更新按钮的背景透明度
    Private Sub Window_Activated(sender As Object, e As WindowActivatedEventArgs)
        Dim titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar
        titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent
    End Sub

    Public Sub New()
        InitializeComponent()
        AddHandler ThemeSelectorService.ThemeChanged, AddressOf OnThemeChanged
        ' 启用自定义标题栏

        SetCustomTitleBar()
        UpdateButtonIconColor()
        AddHandler Window.Current.CoreWindow.Activated, AddressOf OnCoreWindowActivated

        Dim navView As Microsoft.UI.Xaml.Controls.NavigationView = Me.NavView
        navView.IsSettingsVisible = False


        GlobalControls.NavView = Me.NavView

        ' 隐藏默认标题栏
        Dim coreTitleBar As CoreApplicationViewTitleBar = CoreApplication.GetCurrentView().TitleBar
        coreTitleBar.ExtendViewIntoTitleBar = True

        ' 将标题栏按钮背景设置为透明
        Dim titleBar As ApplicationViewTitleBar = ApplicationView.GetForCurrentView().TitleBar
        titleBar.ButtonBackgroundColor = Colors.Transparent

        Window.Current.SetTitleBar(CustomTitleBar)

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
    Private Sub NavView_Loaded(sender As Object, e As RoutedEventArgs)
        ' 设置默认选中的项
        NavView.SelectedItem = NavView.MenuItems(0) ' 默认选中第一个菜单项
    End Sub

    Private Sub NavView_SelectionChanged(sender As Object, e As NavigationViewSelectionChangedEventArgs)
        ' 获取选中的菜单项
        Dim selectedItem = e.SelectedItem
        Dim tag = TryCast(selectedItem, NavigationViewItem).Tag.ToString()

        ' 根据 Tag 导航到对应页面
        Select Case selectedItem.Tag.ToString()
            Case "HomePage"
                contentFrame.Navigate(GetType(Main))
            Case "AboutPage"
                contentFrame.Navigate(GetType(AboutPage))
            Case "SettingsPage"
                contentFrame.Navigate(GetType(SettingsPage))
        End Select
    End Sub
    Private Sub SetCustomTitleBar()
        ' 获取当前应用的标题栏
        Dim titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar

        ' 设置按钮背景为透明
        titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent
        titleBar.ButtonForegroundColor = Windows.UI.Colors.White ' 默认图标颜色为白色

        ' 根据当前系统主题设置按钮图标颜色
        UpdateButtonIconColor()

    End Sub

    Private Sub OnThemeChanged(sender As Object, e As Object)
        ' 当系统主题变化时更新按钮图标颜色
        UpdateButtonIconColor()
        SetAcrylicBrushForCurrentTheme()
    End Sub

    Private Sub UpdateButtonIconColor()
        ' 获取当前应用的标题栏
        Dim titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar

        ' 根据系统主题设置按钮图标颜色
        If Application.Current.RequestedTheme = ApplicationTheme.Dark Then
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White ' 深色主题，图标为白色
        Else
            titleBar.ButtonForegroundColor = Windows.UI.Colors.Black ' 浅色主题，图标为黑色
        End If
    End Sub

    Private Sub OnCoreWindowActivated(sender As Object, e As WindowActivatedEventArgs)
        ' 获取当前应用的标题栏
        Dim titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar
    End Sub


    Private Sub NavView_BackRequested(sender As Object, e As NavigationViewBackRequestedEventArgs)
        If contentFrame.CanGoBack Then
            ' 如果可以返回，执行返回操作
            contentFrame.GoBack()
        End If
    End Sub

    Public Sub contentFrame_Navigated(sender As Object, e As NavigationEventArgs)
        ' 根据当前页面类型更新 NavigationView 的选中项
        Dim currentPage = e.SourcePageType

        If currentPage = GetType(Main) Then
            ' 如果当前页面是 MainPage，选中 Home 菜单项
            NavView.SelectedItem = NavView.MenuItems.OfType(Of NavigationViewItem)().FirstOrDefault(Function(item) item.Tag = "HomePage")
        ElseIf currentPage = GetType(AboutPage) Then
            ' 如果当前页面是 AboutPage，选中 About 菜单项
            NavView.SelectedItem = NavView.MenuItems.OfType(Of NavigationViewItem)().FirstOrDefault(Function(item) item.Tag = "AboutPage")
        ElseIf currentPage = GetType(SettingsPage) Then
            ' 如果当前页面是 SettingsPage，选中 Settings 菜单项
            NavView.SelectedItem = NavView.MenuItems.OfType(Of NavigationViewItem)().FirstOrDefault(Function(item) item.Tag = "SettingsPage")
        End If
        NavView.IsBackEnabled = contentFrame.CanGoBack
    End Sub

End Class
