Public Class TransparentPanel
    Inherits Panel

    Const WS_EX_TRANSPARENT = &H20

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim createParamsValue As CreateParams = MyBase.CreateParams
            createParamsValue.ExStyle = createParamsValue.ExStyle Or WS_EX_TRANSPARENT
            Return createParamsValue
        End Get
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
    End Sub
End Class
