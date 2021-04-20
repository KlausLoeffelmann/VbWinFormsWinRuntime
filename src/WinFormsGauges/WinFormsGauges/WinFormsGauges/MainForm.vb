Imports Windows.Devices.Geolocation
Imports Windows.Devices.Sensors

Public Class MainForm

    Private _browserInitializationAwaiter As TaskCompletionSource = New TaskCompletionSource()
    Private _browserNavigationCompletedAwaiter As TaskCompletionSource(Of Uri)

    Private WithEvents _geoLocator As Geolocator
    Private WithEvents _accelerometer As Accelerometer
    Private _speedUnit As SpeedUnit

    Private _speedUnitTexts As (speedUnit As SpeedUnit, description As String)() =
        {
            (SpeedUnit.MetersPerSecond, "Meters per second"),
            (SpeedUnit.KilometersPerHour, "Kilometers per hour"),
            (SpeedUnit.MilesPerHours, "Miles per hour")
        }

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        For Each item In _speedUnitTexts
            _speedUnitToolStripSplitButton.DropDownItems.Add(
                New ToolStripDropDownButton() With
                {
                    .Text = item.description,
                    .Tag = item.speedUnit
                })
        Next

        'Call back, when the WebView Control is ready.
        AddHandler _webView.CoreWebView2Ready, AddressOf WebView_CoreWebViewReady

        SpeedUnit = SpeedUnit.MilesPerHours
        UpdateGaugeScale()
    End Sub

    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _gpsStatusLabel.Text = "Initializing WebBrowser..."
        _geoLocator = New Geolocator() With
        {
            .ReportInterval = 100
        }

        Await WaitForWebViewInitializedAsync()
        Await NavigateAsync(New Uri("https://bing.com/maps/default.aspx?cp=43.901683~-69.522416&lvl=12&style=r"))
    End Sub

    Private Sub _geoLocator_PositionChanged(sender As Geolocator, args As PositionChangedEventArgs) Handles _geoLocator.PositionChanged
        Dim value As Decimal

        If args.Position.Coordinate.Speed IsNot Nothing Then
            Select Case _speedUnit
            Case SpeedUnit.MetersPerSecond
                value = args.Position.Coordinate.Speed
            Case SpeedUnit.KilometersPerHour
                value = args.Position.Coordinate.Speed * 3.6
            Case SpeedUnit.MilesPerHours
                value = args.Position.Coordinate.Speed * 2.23693629
        End Select

            _odoMeterValueDelayComponent.TargetValue = value
        End If
    End Sub

    Private Sub _geoLocator_StatusChanged(sender As Geolocator, args As StatusChangedEventArgs) Handles _geoLocator.StatusChanged
        _gpsStatusLabel.Text = args.Status.ToString()
    End Sub

    Private Property SpeedUnit As SpeedUnit
        Get
            Return _speedUnit
        End Get
        Set(value As SpeedUnit)
            _speedUnit = value
            _speedUnitToolStripSplitButton.Text = _speedUnitTexts(_speedUnit).description
            UpdateGaugeScale()
        End Set
    End Property

    Private Sub _speedUnitToolSplitButton_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles _speedUnitToolStripSplitButton.DropDownItemClicked
        SpeedUnit = CType(DirectCast(e.ClickedItem, ToolStripDropDownButton).Tag, SpeedUnit)
    End Sub

    Private Sub UpdateGaugeScale()
        With _speedGaugeControl
            Select Case SpeedUnit
                Case SpeedUnit.MetersPerSecond
                    .MaxValue = 70
                    .SeperationStepValue = 5
                Case SpeedUnit.KilometersPerHour
                    .MaxValue = 260
                    .SeperationStepValue = 20
                Case SpeedUnit.MilesPerHours
                    .MaxValue = 140
                    .SeperationStepValue = 10
            End Select
            .Invalidate()
        End With
    End Sub

    Private Sub WebView_CoreWebViewReady(sender As Object, e As EventArgs)
        _browserInitializationAwaiter.TrySetResult()
        AddHandler _webView.CoreWebView2.NavigationCompleted, AddressOf WebView_NavigationCompleted
    End Sub

    Private Sub WebView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs)
        Debug.WriteLine($"NavigationCompleted-Success: {e.IsSuccess}")
        Debug.WriteLine($"NavigationCompleted-Navigation ID: {e.NavigationId}")

        _browserNavigationCompletedAwaiter.TrySetResult(New Uri(_webView.CoreWebView2.Source))
    End Sub

    Private Async Function WaitForWebViewInitializedAsync() As Task
        Try
            Await _webView.EnsureCoreWebView2Async(Nothing).ConfigureAwait(False)
            Await _browserInitializationAwaiter.Task.ConfigureAwait(False)
        Catch ex As Exception

        End Try
    End Function

    Private Async Function NavigateAsync(uri As Uri) As Task(Of Uri)
        'TODO: Implement timeout on NavigateAsync by using CancellationTokenSource
        _browserNavigationCompletedAwaiter = New TaskCompletionSource(Of Uri)

        _webView.CoreWebView2.Navigate(uri.ToString())
        Return Await _browserNavigationCompletedAwaiter.Task
    End Function

    Private Function GetBingMapsUrl() As String
        'Campus.
        Return "https://www.bing.com/maps?osid=3297b7d2-6aaa-4303-8d53-36be73c9e7b4&cp=47.634539~-122.179014&lvl=14&imgid=17367977-35be-43e5-b4f8-cb826d6466ea&v=2&sV=2&form=S00027"
    End Function

    Private Function GetBingMapsUrl(latitude As Decimal, longitude As Decimal) As String
        Return $"https:\/\/bing.com\/maps\/default.aspx?cp={latitude.ToString.Trim}~-{longitude.ToString.Trim}&lvl=12&style=r"
    End Function
End Class

Friend Enum SpeedUnit
    MetersPerSecond
    KilometersPerHour
    MilesPerHours
End Enum
