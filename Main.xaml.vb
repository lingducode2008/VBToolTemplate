' https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

Imports Windows.UI.Notifications
Imports Windows.Data.Xml.Dom
Imports Windows.UI.Popups
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.ApplicationModel.DataTransfer
Imports vba.Services

''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class Main
    Inherits Page
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        AddHandler ThemeSelectorService.ThemeChanged, AddressOf OnThemeChanged
        ' 在 InitializeComponent() 调用之后添加任何初始化。

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

    Private Sub Tongzhi(sender As Object, e As RoutedEventArgs)
        TongzhiTip.IsOpen = True
    End Sub

    ' 创建剪贴板内容的方法
    Private Function CreateDataPackage(text As String) As DataPackage
        Dim dataPackage As New DataPackage()
        dataPackage.SetText(text)
        Return dataPackage
    End Function


    Private Sub b0_click(sender As Object, e As RoutedEventArgs)
        ' 获取文本框的内容
        Dim title As String = tb0.Text
        Dim content As String = tb1.Text

        ' 创建通知内容
        Dim toastXml As New XmlDocument()
        toastXml.LoadXml("<toast><visual><binding template='ToastGeneric'><text>" & title & "</text><text>" & content & "</text></binding></visual></toast>")

        ' 创建并显示通知
        Dim toast As New ToastNotification(toastXml)
        ToastNotificationManager.CreateToastNotifier().Show(toast)
    End Sub

End Class
