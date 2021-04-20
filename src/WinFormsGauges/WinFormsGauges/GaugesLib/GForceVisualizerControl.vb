Imports System.Drawing.Drawing2D

Public Class GForceVisualizerControl
    Inherits Control

    Public Event XGForceChanged As EventHandler
    Public Event YGForceChanged As EventHandler

    Private ReadOnly animationTimer As Timer

    Private _xGforce As Single
    Private _yGforce As Single
    Private _maxGUnits As Integer = 2
    Private _gUnitPartitioning As Single = 0.5F
    Private _previousXGforce As Single
    Private _previousYGforce As Single

    Private _forecolorPen As Pen
    Private _forecolorBrush As Brush
    Private _forecolorPenWidth As Single = 2

    Public Sub New()
        DoubleBuffered = True
        ResizeRedraw = True
    End Sub

    Public Property XGforce() As Single
        Get
            Return _xGforce
        End Get
        Set(ByVal value As Single)
            If Not Object.Equals(_xGforce, value) Then
                _previousXGforce = _xGforce
                _xGforce = value
                OnXGForceChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property YGforce() As Single
        Get
            Return _yGforce
        End Get
        Set(ByVal value As Single)
            If Not Object.Equals(_yGforce, value) Then
                _previousYGforce = _yGforce
                _yGforce = value
                OnYGForceChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Protected Overridable Sub OnXGForceChanged(ByVal e As EventArgs)
        Invalidate()
        RaiseEvent XGForceChanged(Me, e)
    End Sub

    Protected Overridable Sub OnYGForceChanged(ByVal e As EventArgs)
        Invalidate()
        RaiseEvent YGForceChanged(Me, e)
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        _forecolorBrush = New SolidBrush(ForeColor)
        _forecolorPen = New Pen(_forecolorBrush, _forecolorPenWidth)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        g.Clear(BackColor)
        If _forecolorPen Is Nothing Then
            _forecolorBrush = New SolidBrush(ForeColor)
            _forecolorPen = New Pen(_forecolorBrush, _forecolorPenWidth)
        End If

        ' Draw Scaling Circles
        Dim unitWidth = ClientRectangle.Width / (_maxGUnits / _gUnitPartitioning) / 2
        Dim unitHeight = ClientRectangle.Height / (_maxGUnits / _gUnitPartitioning) / 2
        Dim ellipseRectangle =
            New RectangleF(
            ClientRectangle.Width \ 2 - unitWidth,
            ClientRectangle.Height \ 2 - unitHeight,
            unitWidth * 2,
            unitHeight * 2)

        For gUnits As Single = 0 To _maxGUnits - 1 Step _gUnitPartitioning
            g.DrawEllipse(_forecolorPen, ellipseRectangle)
            ellipseRectangle.Inflate(unitWidth, unitHeight)
        Next gUnits

        ' Draw indicator.
        Dim indicatorWidth = ClientRectangle.Width \ 40
        Dim indicatorHeight = ClientRectangle.Height \ 40

        g.FillEllipse(
            _forecolorBrush,
            New RectangleF(
                ClientRectangle.Width \ 2 + XGforce * (ClientRectangle.Width \ (_maxGUnits * 2)) - indicatorWidth,
                ClientRectangle.Height \ 2 + YGforce * (ClientRectangle.Height \ (_maxGUnits * 2)) - indicatorHeight,
                indicatorWidth * 2,
                indicatorHeight * 2))
    End Sub
End Class
