Public Class TransparentForm

    Private Const _positionMarkerSize As Single = 20

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.LimeGreen
        Me.TransparencyKey = Color.LimeGreen
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.DrawRectangle(
            Pens.Red,
            New Rectangle(New Point(0, 0), Me.Size - New Size(1, 1)))

        e.Graphics.FillEllipse(
            Brushes.Red,
            New Rectangle(Size.Width / 2 - _positionMarkerSize / 2,
                          Size.Height / 2 - _positionMarkerSize / 2,
                          _positionMarkerSize, _positionMarkerSize))
    End Sub

End Class