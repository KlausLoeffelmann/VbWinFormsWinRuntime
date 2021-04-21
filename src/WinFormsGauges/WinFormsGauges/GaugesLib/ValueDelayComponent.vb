Public Class ValueDelayComponent

    Public Event ActualValueChanged(sender As Object, e As EventArgs)

    Private WithEvents _timer As Timer
    Private _targetValue As Decimal
    Private _stepDuration As Integer = 25
    Private _stepValue As Decimal
    Private _actualValue As Decimal
    Private _previousValue As Decimal

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        _timer = New Timer With
        {
            .Interval = _stepDuration,
            .Enabled = True
        }
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
        If _stepValue > 0 Then
            ActualValue += _stepValue
            If ActualValue >= TargetValue Then
                _stepValue = 0
                ActualValue = TargetValue
            End If
        Else
            ActualValue += _stepValue
            If ActualValue <= TargetValue Then
                _stepValue = 0
                ActualValue = TargetValue
            End If
        End If

        If ActualValue <> _previousValue Then
            RaiseEvent ActualValueChanged(Me, EventArgs.Empty)
        End If
        _previousValue = ActualValue
    End Sub

    Public Property TargetValue As Decimal
        Get
            Return _targetValue
        End Get
        Set(value As Decimal)
            _targetValue = value
            _stepValue = (TargetValue - ActualValue) / StepsToTargetCount
        End Set
    End Property

    Public Property StepsToTargetCount As Integer = 10

    Public Property StepDuration As Integer
        Get
            Return _stepDuration
        End Get
        Set(value As Integer)
            _stepDuration = value
            _timer.Interval = StepDuration
        End Set
    End Property

    Public Property ActualValue As Decimal
        Get
            Return _actualValue
        End Get
        Private Set(value As Decimal)
            _actualValue = value
        End Set
    End Property
End Class
