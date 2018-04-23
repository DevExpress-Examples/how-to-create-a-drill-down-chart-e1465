Imports Microsoft.VisualBasic
Imports System
Namespace DrillDownChart
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim SimpleDiagram1 As DevExpress.XtraCharts.SimpleDiagram = New DevExpress.XtraCharts.SimpleDiagram()
            Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim PieSeriesLabel1 As DevExpress.XtraCharts.PieSeriesLabel = New DevExpress.XtraCharts.PieSeriesLabel()
            Dim PiePointOptions1 As DevExpress.XtraCharts.PiePointOptions = New DevExpress.XtraCharts.PiePointOptions()
            Dim PiePointOptions2 As DevExpress.XtraCharts.PiePointOptions = New DevExpress.XtraCharts.PiePointOptions()
            Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
            Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim SideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
            Dim PointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
            Dim PieSeriesLabel2 As DevExpress.XtraCharts.PieSeriesLabel = New DevExpress.XtraCharts.PieSeriesLabel()
            Dim PiePointOptions3 As DevExpress.XtraCharts.PiePointOptions = New DevExpress.XtraCharts.PiePointOptions()
            Dim PieSeriesView2 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
            Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
            Dim ChartTitle2 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
            Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
            Me.salesPersonTableAdapter = New DrillDownChart.nwindDataSetTableAdapters.SalesPersonTableAdapter()
            Me.salesPersonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.nwindDataSet = New DrillDownChart.nwindDataSet()
            CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(SimpleDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(PieSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(PieSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.salesPersonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'chartControl1
            '
            Me.chartControl1.DataAdapter = Me.salesPersonTableAdapter
            Me.chartControl1.DataSource = Me.salesPersonBindingSource
            SimpleDiagram1.EqualPieSize = False
            Me.chartControl1.Diagram = SimpleDiagram1
            Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chartControl1.Location = New System.Drawing.Point(0, 0)
            Me.chartControl1.Name = "chartControl1"
            Me.chartControl1.RuntimeHitTesting = True
            Series1.ArgumentDataMember = "Sales Person"
            PieSeriesLabel1.Border.Visible = False
            PieSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty
            PieSeriesLabel1.LineVisible = True
            PiePointOptions1.PercentOptions.ValueAsPercent = False
            PiePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Currency
            PiePointOptions1.ValueNumericOptions.Precision = 0
            PieSeriesLabel1.PointOptions = PiePointOptions1
            PieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns
            PieSeriesLabel1.TextColor = System.Drawing.Color.Black
            Series1.Label = PieSeriesLabel1
            PiePointOptions2.PercentOptions.ValueAsPercent = False
            PiePointOptions2.PointView = DevExpress.XtraCharts.PointView.Argument
            PiePointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.FixedPoint
            PiePointOptions2.ValueNumericOptions.Precision = 1
            Series1.LegendPointOptions = PiePointOptions2
            Series1.Name = "Categories"
            Series1.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Ascending
            Series1.SummaryFunction = "SUM([Extended Price])"
            Series1.SynchronizePointOptions = False
            PieSeriesView1.RuntimeExploding = False
            Series1.View = PieSeriesView1
            Series2.ArgumentDataMember = "CategoryName"
            Series2.DataFilters.ClearAndAddRange(New DevExpress.XtraCharts.DataFilter() {New DevExpress.XtraCharts.DataFilter("Sales Person", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, Nothing)})
            SideBySideBarSeriesLabel1.LineVisible = True
            PointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Currency
            PointOptions1.ValueNumericOptions.Precision = 0
            SideBySideBarSeriesLabel1.PointOptions = PointOptions1
            Series2.Label = SideBySideBarSeriesLabel1
            Series2.Name = "Series 1"
            Series2.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending
            Series2.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1
            Series2.SummaryFunction = "SUM([Extended Price])"
            Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
            PieSeriesLabel2.LineVisible = True
            PiePointOptions3.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
            PieSeriesLabel2.PointOptions = PiePointOptions3
            Me.chartControl1.SeriesTemplate.Label = PieSeriesLabel2
            PieSeriesView2.RuntimeExploding = False
            Me.chartControl1.SeriesTemplate.View = PieSeriesView2
            Me.chartControl1.Size = New System.Drawing.Size(777, 466)
            Me.chartControl1.TabIndex = 0
            ChartTitle1.Alignment = System.Drawing.StringAlignment.Near
            ChartTitle1.Antialiasing = False
            ChartTitle1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Underline)
            ChartTitle1.Indent = 20
            ChartTitle1.Text = "Back to the main view..."
            ChartTitle1.TextColor = System.Drawing.Color.RoyalBlue
            ChartTitle1.Visible = False
            ChartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom
            ChartTitle2.Indent = 20
            ChartTitle2.Text = "Sales by Person"
            Me.chartControl1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1, ChartTitle2})
            '
            'salesPersonTableAdapter
            '
            Me.salesPersonTableAdapter.ClearBeforeFill = True
            '
            'salesPersonBindingSource
            '
            Me.salesPersonBindingSource.DataMember = "SalesPerson"
            Me.salesPersonBindingSource.DataSource = Me.nwindDataSet
            '
            'nwindDataSet
            '
            Me.nwindDataSet.DataSetName = "nwindDataSet"
            Me.nwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(777, 466)
            Me.Controls.Add(Me.chartControl1)
            Me.Name = "Form1"
            Me.Text = "Drill-Down Chart"
            CType(SimpleDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(PieSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(PieSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(PieSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.salesPersonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

		#End Region

        Private WithEvents chartControl1 As DevExpress.XtraCharts.ChartControl
		Private salesPersonTableAdapter As nwindDataSetTableAdapters.SalesPersonTableAdapter
		Private nwindDataSet As nwindDataSet
		Private salesPersonBindingSource As System.Windows.Forms.BindingSource

	End Class
End Namespace

