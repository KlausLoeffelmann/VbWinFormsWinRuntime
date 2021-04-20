Public Structure PolarCoordinate
	Private _xLength As Single
	Private _yLength As Single
	Private _angle As Single
	Private _offset As PointF

	Private privateCartesian As PointF

	Public Sub New(ByVal Offset As PointF, ByVal Length As Single, ByVal Angle As Single)
		Me.New()
		_xLength = Length
		_yLength = Length
		_angle = Angle
		_offset = Offset
		Recalculate()
	End Sub

	Public Sub New(ByVal offset As PointF, ByVal xLength As Single, ByVal yLength As Single, ByVal angle As Single)
		Me.New()
		_xLength = xLength
		_yLength = yLength
		_angle = angle
		_offset = offset
		Recalculate()
	End Sub

	Public Property Cartesian() As PointF
		Get
			Return privateCartesian
		End Get
		Private Set(ByVal value As PointF)
			privateCartesian = value
		End Set
	End Property

	Public Property Length_X() As Single
		Get
			Return _xLength
		End Get
		Set(ByVal value As Single)
			_xLength = value
			Recalculate()
		End Set
	End Property

	Public Property Length_Y() As Single
		Get
			Return _yLength
		End Get
		Set(ByVal value As Single)
			_yLength = value
			Recalculate()
		End Set
	End Property

	Public Property Angle() As Single
		Get
			Return _angle
		End Get
		Set(ByVal value As Single)
			_angle = value
			Recalculate()
		End Set
	End Property

	Public Property Offset() As PointF
		Get
			Return _offset
		End Get
		Set(ByVal value As PointF)
			_offset = value
			Recalculate()
		End Set
	End Property

	Friend ReadOnly Property OriginalAngle() As Single

	Private Sub Recalculate()
		Dim x = Convert.ToSingle(Offset.X + Math.Cos(Angle * Math.PI / 180) * Length_X)
		Dim y = Convert.ToSingle(Offset.Y + Math.Sin(Angle * Math.PI / 180) * Length_Y)
		Cartesian = New PointF(x, y)
	End Sub
End Structure
