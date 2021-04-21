Imports GaugesLib

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me._gForceControl = New GaugesLib.GForceVisualizerControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me._speedGaugeControl = New GaugesLib.GaugeControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me._startPositionRecordingButton = New System.Windows.Forms.Button()
        Me._positionRecordingListView = New System.Windows.Forms.ListView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me._gpsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me._speedUnitToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me._odoMeterValueDelayComponent = New GaugesLib.ValueDelayComponent(Me.components)
        Me._webView = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me._transparentPanel = New WinFormsGauges.TransparentPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_gForceControl
        '
        Me._gForceControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gForceControl.Location = New System.Drawing.Point(317, 3)
        Me._gForceControl.Name = "_gForceControl"
        Me._gForceControl.Size = New System.Drawing.Size(308, 192)
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
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(942, 198)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me._speedGaugeControl)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 192)
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
        Me._speedGaugeControl.Location = New System.Drawing.Point(8, 8)
        Me._speedGaugeControl.MaxValue = 260.0!
        Me._speedGaugeControl.MinValue = 0!
        Me._speedGaugeControl.Name = "_speedGaugeControl"
        Me._speedGaugeControl.SeperationStepValue = 20.0!
        Me._speedGaugeControl.Size = New System.Drawing.Size(297, 181)
        Me._speedGaugeControl.TabIndex = 1
        Me._speedGaugeControl.Text = "GaugeControl1"
        Me._speedGaugeControl.UnitTextOffset = 40.0!
        Me._speedGaugeControl.Value = 0!
        Me._speedGaugeControl.ValueHandEnd = 140.0!
        Me._speedGaugeControl.ValueHandStart = 30.0!
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me._startPositionRecordingButton)
        Me.Panel2.Controls.Add(Me._positionRecordingListView)
        Me.Panel2.Location = New System.Drawing.Point(631, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(308, 192)
        Me.Panel2.TabIndex = 3
        '
        '_startPositionRecordingButton
        '
        Me._startPositionRecordingButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._startPositionRecordingButton.Location = New System.Drawing.Point(3, 3)
        Me._startPositionRecordingButton.Name = "_startPositionRecordingButton"
        Me._startPositionRecordingButton.Size = New System.Drawing.Size(301, 40)
        Me._startPositionRecordingButton.TabIndex = 1
        Me._startPositionRecordingButton.Text = "Start position recording"
        Me._startPositionRecordingButton.UseVisualStyleBackColor = True
        '
        '_positionRecordingListView
        '
        Me._positionRecordingListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._positionRecordingListView.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me._positionRecordingListView.HideSelection = False
        Me._positionRecordingListView.Location = New System.Drawing.Point(3, 49)
        Me._positionRecordingListView.Name = "_positionRecordingListView"
        Me._positionRecordingListView.Size = New System.Drawing.Size(301, 140)
        Me._positionRecordingListView.TabIndex = 0
        Me._positionRecordingListView.UseCompatibleStateImageBehavior = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._gpsStatusLabel, Me._speedUnitToolStripSplitButton})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 625)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(969, 26)
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
        Me._gpsStatusLabel.Size = New System.Drawing.Size(200, 20)
        Me._gpsStatusLabel.Text = "No GPS Data"
        '
        '_speedUnitToolStripSplitButton
        '
        Me._speedUnitToolStripSplitButton.AutoSize = False
        Me._speedUnitToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me._speedUnitToolStripSplitButton.Image = CType(resources.GetObject("_speedUnitToolStripSplitButton.Image"), System.Drawing.Image)
        Me._speedUnitToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._speedUnitToolStripSplitButton.Name = "_speedUnitToolStripSplitButton"
        Me._speedUnitToolStripSplitButton.Size = New System.Drawing.Size(150, 24)
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
        Me._webView.Location = New System.Drawing.Point(12, 216)
        Me._webView.Name = "_webView"
        Me._webView.Size = New System.Drawing.Size(939, 398)
        Me._webView.TabIndex = 4
        Me._webView.Text = "WebView21"
        Me._webView.ZoomFactor = 1.0R
        '
        '_transparentPanel
        '
        Me._transparentPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._transparentPanel.Location = New System.Drawing.Point(15, 216)
        Me._transparentPanel.Name = "_transparentPanel"
        Me._transparentPanel.Size = New System.Drawing.Size(936, 398)
        Me._transparentPanel.TabIndex = 5
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 651)
        Me.Controls.Add(Me._transparentPanel)
        Me.Controls.Add(Me._webView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MainForm"
        Me.Text = "WinForms Gauges"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents _startPositionRecordingButton As Button
    Friend WithEvents _positionRecordingListView As ListView
    Friend WithEvents _transparentPanel As TransparentPanel
End Class
