Imports Windows.Devices.Geolocation
Imports Windows.Devices.Sensors

Public Class MainForm

    Private _browserInitializationAwaiter As TaskCompletionSource = New TaskCompletionSource()
    Private _browserNavigationCompletedAwaiter As TaskCompletionSource(Of Uri)
    Private _timer As Timer

    'Default point when displaying the map for the first time.
    Private _microsoftCampus As (longitude As Decimal, latitude As Decimal) = (47.644054, -122.129379)

    Private WithEvents _geoLocator As Geolocator
    Private WithEvents _accelerometer As Accelerometer
    Private _speedUnit As SpeedUnit
    Private _transparentForm As TransparentForm
    Private _currentLocationUri As Uri
    Private _previousLocationUri As Uri
    Private _isRecording As Boolean

    Private _speedUnitTexts As (speedUnit As SpeedUnit, description As String)() =
        {
            (SpeedUnit.MetersPerSecond, "Meters per second"),
            (SpeedUnit.KilometersPerHour, "Kilometers per hour"),
            (SpeedUnit.MilesPerHours, "Miles per hour")
        }
    Private _currentLatitude As Double
    Private _currentLongitude As Double

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

        With _positionRecordingListView
            .HideSelection = False
            .FullRowSelect = True
            .View = View.Details
            .Columns.Add("Time", 80)
            .Columns.Add("Latitude", 120)
            .Columns.Add("Longitude", 120)
        End With

        'Call back, when the WebView Control is ready.
        AddHandler _webView.CoreWebView2Ready, AddressOf WebView_CoreWebViewReady

        SpeedUnit = SpeedUnit.MilesPerHours
        UpdateGaugeScale()

        _timer = New Timer With
        {
            .Interval = 1000,
            .Enabled = True
        }

    End Sub

    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _gpsStatusLabel.Text = "Initializing WebBrowser..."
        _geoLocator = New Geolocator() With
        {
            .ReportInterval = 100
        }

        Await WaitForWebViewInitializedAsync()
        Dim microsoftCampusLocationUri = GetBingMapsUrl(_microsoftCampus.longitude, _microsoftCampus.latitude)
        Await NavigateAsync(microsoftCampusLocationUri)

        _transparentForm = New TransparentForm
        _transparentForm.Show()
        UpdateTransparentForm()

        AddHandler _timer.Tick,
            Async Sub()
                If _currentLocationUri IsNot Nothing Then
                    Try
                        If (_previousLocationUri <> _currentLocationUri) Then
                            Await NavigateAsync(_currentLocationUri)
                            _previousLocationUri = _currentLocationUri
                        End If
                    Catch ex As Exception
                    End Try

                    If _isRecording Then
                        With _positionRecordingListView
                            Dim listViewItem = .Items.Add($"{Now:HH:mm:ss}")
                            listViewItem.SubItems.Add($"{_currentLatitude:0.000000}")
                            listViewItem.SubItems.Add($"{_currentLongitude:0.000000}")
                        End With
                    End If
                End If
            End Sub
    End Sub

    Protected Overrides Sub OnLocationChanged(e As EventArgs)
        MyBase.OnLocationChanged(e)
        UpdateTransparentForm()
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        UpdateTransparentForm()
    End Sub

    Private Sub UpdateTransparentForm()

        Dim headerOffset = 80

        If _transparentForm Is Nothing Then
            Return
        End If
        _transparentForm.Location = _webView.PointToScreen(New Point(0, headerOffset))
        _transparentForm.Size = _webView.Size - New Size(0, headerOffset)
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
        End If

        _odoMeterValueDelayComponent.TargetValue = value

        Invoke(Sub()
                   Text = "Speed: " & value
               End Sub)

        _currentLatitude = args.Position.Coordinate.Latitude
        _currentLongitude = args.Position.Coordinate.Longitude
        _currentLocationUri = GetBingMapsUrl(
            _currentLatitude,
            _currentLongitude)
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

    Private Function GetBingMapsUrl(latitude As Decimal, longitude As Decimal) As Uri
        Dim uriString = $"https://bing.com/maps/default.aspx?cp={latitude.ToString.Trim}~{longitude.ToString.Trim}&lvl=12&style=g"
        Return New Uri(uriString)
    End Function

    Private Function GetBingMapsPointUrl(latitude As Decimal, longitude As Decimal) As Uri
        Dim uriString = $"https://bing.com/maps/default.aspx?sp=point.{latitude.ToString.Trim}_{longitude.ToString.Trim}_Current"
        Return New Uri(uriString)
    End Function

    Private Sub _startPositionRecordingButton_Click(sender As Object, e As EventArgs) Handles _startPositionRecordingButton.Click
        _isRecording = _isRecording Xor True
    End Sub

    Private Sub _odoMeterValueDelayComponent_ActualValueChanged(sender As Object, e As EventArgs) Handles _odoMeterValueDelayComponent.ActualValueChanged
        _speedGaugeControl.Value = _odoMeterValueDelayComponent.ActualValue
    End Sub
End Class

Friend Enum SpeedUnit
    MetersPerSecond
    KilometersPerHour
    MilesPerHours
End Enum
