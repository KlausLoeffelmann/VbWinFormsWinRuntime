Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class GaugeControl
    Inherits Control

    Public Event ValueChanged As EventHandler

    Private _value As Single = 0

    Public Sub New()
        DoubleBuffered = True
        ResizeRedraw = True
        Font = New Font(Font.FontFamily, Font.Size * 1.5F, FontStyle.Bold)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g = e.Graphics

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(BackColor)

        'Create Brushes and Pens
        Dim penWidth As Single = 3.0F
        Dim halfPenWidth As Single = penWidth / 2

        Dim foreColorPen = New Pen(ForeColor, penWidth)
        Dim foreColorBrush = New SolidBrush(ForeColor)

        Dim closeSize As New RectangleF(
            halfPenWidth,
            halfPenWidth,
            (ClientSize.Width - 1) - penWidth,
            (ClientSize.Height - 1) - penWidth)

        Dim center As PointF =
            New PointF With
            {
                .X = ClientSize.Width / 2.0F,
                .Y = ClientSize.Height / 2.0F
            }

        'Size minus edge of the gauge.
        Dim size As SizeF =
            New SizeF With
            {
                .Width = CSng(closeSize.Width / 2.0),
                .Height = CSng(closeSize.Height / 2.0)
            }

        'Outer dial circle
        g.DrawEllipse(foreColorPen, closeSize)

        'Draw the dial.
        Dim dialSteps As Single = (MaxValue - MinValue) / SeperationStepValue
        Dim angleStep As Single = (GaugeEndAngle - GaugeStartAngle) / dialSteps
        Dim currentUnitValue As Single = MinValue

        For angle As Single = GaugeStartAngle To GaugeEndAngle Step angleStep
            ' Draw unit separators.
            Dim effectiveAngle = (angle + DialOffsetAngle) Mod 360
            Dim pcStart = New PolarCoordinate(center, size.Width, size.Height, effectiveAngle)
            Dim pcEnd = New PolarCoordinate(center, size.Width - DialLength, size.Height - DialLength, effectiveAngle)
            g.DrawLine(Pens.Black, pcStart.Cartesian.X, pcStart.Cartesian.Y, pcEnd.Cartesian.X, pcEnd.Cartesian.Y)

            ' Draw unit texts.
            Dim textPos As New PolarCoordinate(center, size.Width - UnitTextOffset, size.Height - UnitTextOffset, effectiveAngle)
            Dim currentUnitText = CInt(Fix(currentUnitValue)).ToString()
            currentUnitValue += SeperationStepValue
            Dim textExtends = g.MeasureString(currentUnitText, Font)

            Dim textHotSpotOffset = New SizeF(textExtends.Width \ 2, textExtends.Height \ 2)
            Dim textPosition = textPos.Cartesian - textHotSpotOffset
            g.DrawString(currentUnitText, Font, foreColorBrush, textPosition)
        Next angle

        ' Draw value hand.
        Dim valueAngle = GaugeStartAngle + DialOffsetAngle + Value * angleStep
        Dim handStart = New PolarCoordinate(center, size.Width - ValueHandStart, size.Height - ValueHandStart, valueAngle)
        Dim handEnd = New PolarCoordinate(center, size.Width - ValueHandEnd, size.Height - ValueHandEnd, valueAngle)
        g.DrawLine(foreColorPen, handStart.Cartesian.X, handStart.Cartesian.Y, handEnd.Cartesian.X, handEnd.Cartesian.Y)

        Dim centerEllipse = New SizeF(size.Width - ValueHandEnd - 5, size.Height - ValueHandEnd - 5)
        g.FillEllipse(foreColorBrush, New RectangleF(center - centerEllipse, centerEllipse + centerEllipse))
    End Sub

    <DefaultValue(40), Category("Appearance")>
    Public Property GaugeStartAngle As Integer = 40

    <DefaultValue(320), Category("Appearance")>
    Public Property GaugeEndAngle As Integer = 320

    <DefaultValue(0), Category("Appearance")>
    Public Property MinValue As Single = 0

    <DefaultValue(260), Category("Appearance")>
    Public Property MaxValue As Single = 260

    <DefaultValue(20), Category("Appearance")>
    Public Property SeperationStepValue As Single = 20

    <DefaultValue(90), Category("Appearance")>
    Public Property DialOffsetAngle As Single = 90

    <DefaultValue(20), Category("Appearance")>
    Public Property DialLength As Single = 20

    <DefaultValue(40), Category("Appearance")>
    Public Property UnitTextOffset As Single = 40

    <DefaultValue(0), Category("Appearance")>
    Public Property Value As Single
        Get
            Return _value
        End Get
        Set
            _value = Value
            OnValueChanged(EventArgs.Empty)
        End Set
    End Property

    Protected Overridable Sub OnValueChanged(e As EventArgs)
        Invalidate()
        RaiseEvent ValueChanged(Me, e)
    End Sub

    <DefaultValue(30), Category("Appearance")>
    Public Property ValueHandStart As Single = 30

    <DefaultValue(140), Category("Appearance")>
    Public Property ValueHandEnd As Single = 140

End Class
