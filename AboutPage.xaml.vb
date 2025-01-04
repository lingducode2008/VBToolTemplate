' https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

Imports vba.Services

''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class AboutPage
    Inherits Page
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        AddHandler ThemeSelectorService.ThemeChanged, AddressOf OnThemeChanged
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


End Class
