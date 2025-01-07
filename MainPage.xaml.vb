Imports Microsoft.UI.Xaml.Controls
Imports Microsoft.UI.Xaml.Media
Imports vba.Services
Imports Windows.ApplicationModel.Core
Imports Windows.UI
Imports Windows.UI.Core
Imports Windows.UI.ViewManagement
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Input

''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class MainPage

    Public Sub New()
        InitializeComponent()

        ' 主题变化时触发
        AddHandler ThemeSelectorService.ThemeChanged, AddressOf OnThemeChanged

        ' 启用自定义标题栏
        SetCustomTitleBar()

        ' 更新按钮图标颜色
        UpdateButtonIconColor()

        ' 监听窗口激活状态
        AddHandler Window.Current.CoreWindow.Activated, AddressOf OnCoreWindowActivated

        ' 隐藏默认标题栏并扩展自定义标题栏
        Dim coreTitleBar As CoreApplicationViewTitleBar = CoreApplication.GetCurrentView().TitleBar
        coreTitleBar.ExtendViewIntoTitleBar = True
        Window.Current.SetTitleBar(CustomTitleBar)

        ' 将标题栏按钮背景设置为透明（激活时）
        Dim titleBar As ApplicationViewTitleBar = ApplicationView.GetForCurrentView().TitleBar
        titleBar.ButtonBackgroundColor = Colors.Transparent

        ' 设置当前主题下的亚克力背景
        SetAcrylicBrushForCurrentTheme()

        ' 默认选项不显示“设置”图标
        Dim navView As Microsoft.UI.Xaml.Controls.NavigationView = Me.NavView
        navView.IsSettingsVisible = False

        ' 将 NavView 存到全局服务中（如果需要）
        GlobalControls.NavView = Me.NavView
    End Sub

    ''' <summary>
    ''' 监听窗口激活与非激活状态
    ''' </summary>
    Private Sub OnCoreWindowActivated(sender As Object, e As WindowActivatedEventArgs)
        Dim titleBar = ApplicationView.GetForCurrentView().TitleBar
        If e.WindowActivationState = CoreWindowActivationState.Deactivated Then
            ' 当窗口失去焦点（非激活）时，设置按钮和标题栏为透明或其它颜色
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent
            titleBar.ButtonInactiveForegroundColor = Colors.Gray

            ' 如果希望标题栏文字也变成灰色：
            titleBar.InactiveBackgroundColor = Colors.Transparent
            titleBar.InactiveForegroundColor = Colors.Gray

        Else
            ' 窗口处于激活状态
            If ThemeSelectorService.IsDarkMode = True Then
                titleBar.ButtonBackgroundColor = Colors.Transparent
                titleBar.ButtonForegroundColor = Colors.White
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent
                titleBar.ButtonInactiveForegroundColor = Colors.Gray

                ' 标题栏背景和前景
                titleBar.BackgroundColor = Colors.Transparent
                titleBar.ForegroundColor = Colors.White
                titleBar.InactiveBackgroundColor = Colors.Transparent
                titleBar.InactiveForegroundColor = Colors.Gray
            Else
                titleBar.ButtonBackgroundColor = Colors.Transparent
                titleBar.ButtonForegroundColor = Colors.Black
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent
                titleBar.ButtonInactiveForegroundColor = Colors.Gray

                ' 标题栏背景和前景
                titleBar.BackgroundColor = Colors.Transparent
                titleBar.ForegroundColor = Colors.Black
                titleBar.InactiveBackgroundColor = Colors.Transparent
                titleBar.InactiveForegroundColor = Colors.Gray
            End If
        End If
    End Sub

    ''' <summary>
    ''' 自定义标题栏的初始化
    ''' </summary>
    Private Sub SetCustomTitleBar()
        Dim titleBar = ApplicationView.GetForCurrentView().TitleBar

        ' 激活时按钮背景与前景色
        titleBar.ButtonBackgroundColor = Colors.Transparent
        titleBar.ButtonForegroundColor = Colors.White

        ' 非激活时按钮背景与前景色
        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent
        titleBar.ButtonInactiveForegroundColor = Colors.Gray

        ' 标题栏整体在激活、非激活时的背景与前景
        titleBar.BackgroundColor = Colors.Transparent
        titleBar.ForegroundColor = Colors.White
        titleBar.InactiveBackgroundColor = Colors.Transparent
        titleBar.InactiveForegroundColor = Colors.Gray
    End Sub

    ''' <summary>
    ''' 当系统主题变化时触发
    ''' </summary>
    Private Sub OnThemeChanged(sender As Object, e As Object)
        UpdateButtonIconColor()
        SetAcrylicBrushForCurrentTheme()
    End Sub

    ''' <summary>
    ''' 根据系统主题更新标题栏按钮图标颜色
    ''' </summary>
    Private Sub UpdateButtonIconColor()
        Dim titleBar = ApplicationView.GetForCurrentView().TitleBar

        If Application.Current.RequestedTheme = ApplicationTheme.Dark Then
            titleBar.ButtonForegroundColor = Colors.White  ' 深色主题用白色
        Else
            titleBar.ButtonForegroundColor = Colors.Black  ' 浅色主题用黑色
        End If
    End Sub

    ''' <summary>
    ''' 根据当前主题设置亚克力背景
    ''' </summary>
    Private Sub SetAcrylicBrushForCurrentTheme()
        Dim currentTheme As ElementTheme = ThemeSelectorService.GetCurrentTheme()

        If currentTheme = ElementTheme.Dark Then
            ' 暗色主题下
            G1.Background = CType(G1.Resources("AcrylicBrushDark"), Windows.UI.Xaml.Media.AcrylicBrush)
        Else
            ' 亮色主题下
            G1.Background = CType(G1.Resources("AcrylicBrushLight"), Windows.UI.Xaml.Media.AcrylicBrush)
        End If
    End Sub

    ''' <summary>
    ''' NavigationView 加载完成时设置默认选项
    ''' </summary>
    Private Sub NavView_Loaded(sender As Object, e As RoutedEventArgs)
        NavView.SelectedItem = NavView.MenuItems(0) ' 默认选中第一个菜单项
    End Sub

    ''' <summary>
    ''' 点击 NavigationViewItem 时，根据 Tag 导航到对应页面
    ''' </summary>
    Private Sub NavView_SelectionChanged(sender As Object, e As NavigationViewSelectionChangedEventArgs)
        Dim selectedItem = e.SelectedItem
        Dim itemTag = TryCast(selectedItem, NavigationViewItem).Tag.ToString()

        Select Case itemTag
            Case "HomePage"
                contentFrame.Navigate(GetType(Main))
            Case "AboutPage"
                contentFrame.Navigate(GetType(AboutPage))
            Case "SettingsPage"
                contentFrame.Navigate(GetType(SettingsPage))
        End Select
    End Sub

    ''' <summary>
    ''' 处理返回按钮事件
    ''' </summary>
    Private Sub NavView_BackRequested(sender As Object, e As NavigationViewBackRequestedEventArgs)
        If contentFrame.CanGoBack Then
            contentFrame.GoBack()
        End If
    End Sub

    ''' <summary>
    ''' Frame 导航后，根据当前 SourcePageType 更新选中的菜单项
    ''' </summary>
    Public Sub contentFrame_Navigated(sender As Object, e As NavigationEventArgs)
        Dim currentPage = e.SourcePageType

        If currentPage = GetType(Main) Then
            NavView.SelectedItem = NavView.MenuItems.
                OfType(Of NavigationViewItem)().
                FirstOrDefault(Function(item) item.Tag = "HomePage")
        ElseIf currentPage = GetType(AboutPage) Then
            NavView.SelectedItem = NavView.MenuItems.
                OfType(Of NavigationViewItem)().
                FirstOrDefault(Function(item) item.Tag = "AboutPage")
        ElseIf currentPage = GetType(SettingsPage) Then
            NavView.SelectedItem = NavView.MenuItems.
                OfType(Of NavigationViewItem)().
                FirstOrDefault(Function(item) item.Tag = "SettingsPage")
        End If

        NavView.IsBackEnabled = contentFrame.CanGoBack
    End Sub

End Class
