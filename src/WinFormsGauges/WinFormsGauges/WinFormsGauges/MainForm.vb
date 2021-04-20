Imports Windows.Devices.Geolocation
Imports Windows.Devices.Sensors

Public Class MainForm

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

        SpeedUnit = SpeedUnit.MilesPerHours
        UpdateGaugeScale()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _geoLocator = New Geolocator() With
        {
            .ReportInterval = 100
        }
    End Sub

    Private Sub _geoLocator_PositionChanged(sender As Geolocator, args As PositionChangedEventArgs) Handles _geoLocator.PositionChanged
        Dim value As Decimal

        Select Case _speedUnit
            Case SpeedUnit.MetersPerSecond
                value = args.Position.Coordinate.Speed
            Case SpeedUnit.KilometersPerHour
                value = args.Position.Coordinate.Speed * 3.6
            Case SpeedUnit.MilesPerHours
                value = args.Position.Coordinate.Speed * 2.23693629
        End Select

        _odoMeterValueDelayComponent.TargetValue = value
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

End Class

Friend Enum SpeedUnit
    MetersPerSecond
    KilometersPerHour
    MilesPerHours
End Enum
