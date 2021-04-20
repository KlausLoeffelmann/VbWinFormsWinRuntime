Imports GaugesLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me._gForceControl = New GaugesLib.GForceVisualizerControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me._speedGaugeControl = New GaugesLib.GaugeControl()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me._gpsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me._speedUnitToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me._odoMeterValueDelayComponent = New GaugesLib.ValueDelayComponent(Me.components)
        Me._webView = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_gForceControl
        '
        Me._gForceControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gForceControl.Location = New System.Drawing.Point(397, 4)
        Me._gForceControl.Margin = New System.Windows.Forms.Padding(4)
        Me._gForceControl.Name = "_gForceControl"
        Me._gForceControl.Size = New System.Drawing.Size(385, 245)
        Me._gForceControl.TabIndex = 1
        Me._gForceControl.Text = "GForceVisualizerControl1"
        Me._gForceControl.XGforce = 0!
        Me._gForceControl.YGforce = 0!
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me._gForceControl, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 15)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1179, 253)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me._speedGaugeControl)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(385, 245)
        Me.Panel1.TabIndex = 2
        '
        '_speedGaugeControl
        '
        Me._speedGaugeControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._speedGaugeControl.DialLength = 20.0!
        Me._speedGaugeControl.DialOffsetAngle = 90.0!
        Me._speedGaugeControl.Font = New System.Drawing.Font("Segoe UI", 13.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me._speedGaugeControl.Location = New System.Drawing.Point(10, 10)
        Me._speedGaugeControl.Margin = New System.Windows.Forms.Padding(4)
        Me._speedGaugeControl.MaxValue = 260.0!
        Me._speedGaugeControl.MinValue = 0!
        Me._speedGaugeControl.Name = "_speedGaugeControl"
        Me._speedGaugeControl.SeperationStepValue = 20.0!
        Me._speedGaugeControl.Size = New System.Drawing.Size(371, 231)
        Me._speedGaugeControl.TabIndex = 1
        Me._speedGaugeControl.Text = "GaugeControl1"
        Me._speedGaugeControl.UnitTextOffset = 40.0!
        Me._speedGaugeControl.Value = 0!
        Me._speedGaugeControl.ValueHandEnd = 140.0!
        Me._speedGaugeControl.ValueHandStart = 30.0!
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._gpsStatusLabel, Me._speedUnitToolStripSplitButton})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 793)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 18, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1212, 26)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        '_gpsStatusLabel
        '
        Me._gpsStatusLabel.AutoSize = False
        Me._gpsStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._gpsStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._gpsStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me._gpsStatusLabel.Name = "_gpsStatusLabel"
        Me._gpsStatusLabel.Size = New System.Drawing.Size(200, 19)
        Me._gpsStatusLabel.Text = "No GPS Data"
        '
        '_speedUnitToolStripSplitButton
        '
        Me._speedUnitToolStripSplitButton.AutoSize = False
        Me._speedUnitToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me._speedUnitToolStripSplitButton.Image = CType(resources.GetObject("_speedUnitToolStripSplitButton.Image"), System.Drawing.Image)
        Me._speedUnitToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._speedUnitToolStripSplitButton.Name = "_speedUnitToolStripSplitButton"
        Me._speedUnitToolStripSplitButton.Size = New System.Drawing.Size(150, 23)
        '
        '_odoMeterValueDelayComponent
        '
        Me._odoMeterValueDelayComponent.StepDuration = 25
        Me._odoMeterValueDelayComponent.StepsToTargetCount = 10
        Me._odoMeterValueDelayComponent.TargetValue = New Decimal(New Integer() {0, 0, 0, 0})
        '
        '_webView
        '
        Me._webView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._webView.CreationProperties = Nothing
        Me._webView.Location = New System.Drawing.Point(15, 276)
        Me._webView.Margin = New System.Windows.Forms.Padding(4)
        Me._webView.Name = "_webView"
        Me._webView.Size = New System.Drawing.Size(1179, 497)
        Me._webView.TabIndex = 4
        Me._webView.Text = "WebView21"
        Me._webView.ZoomFactor = 1.0R
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 819)
        Me.Controls.Add(Me._webView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.Text = "WinForms Gauges"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _gForceControl As GaugesLib.GForceVisualizerControl
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents _gpsStatusLabel As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents _speedGaugeControl As GaugeControl
    Friend WithEvents _speedUnitToolStripSplitButton As ToolStripSplitButton
    Friend WithEvents _odoMeterValueDelayComponent As ValueDelayComponent
    Friend WithEvents _webView As Microsoft.Web.WebView2.WinForms.WebView2
End Class
