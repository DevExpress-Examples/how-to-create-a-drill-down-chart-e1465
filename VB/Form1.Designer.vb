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
            Dim simpleDiagram1 As New DevExpress.XtraCharts.SimpleDiagram()
            Dim series1 As New DevExpress.XtraCharts.Series()
            Dim pieSeriesLabel1 As New DevExpress.XtraCharts.PieSeriesLabel()
            Dim pieSeriesView1 As New DevExpress.XtraCharts.PieSeriesView()
            Dim series2 As New DevExpress.XtraCharts.Series()
            Dim sideBySideBarSeriesLabel1 As New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
            Dim pieSeriesLabel2 As New DevExpress.XtraCharts.PieSeriesLabel()
            Dim pieSeriesView2 As New DevExpress.XtraCharts.PieSeriesView()
            Dim chartTitle1 As New DevExpress.XtraCharts.ChartTitle()
            Dim chartTitle2 As New DevExpress.XtraCharts.ChartTitle()
            Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
            Me.salesPersonTableAdapter = New DrillDownChart.nwindDataSetTableAdapters.SalesPersonTableAdapter()
            Me.salesPersonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.nwindDataSet = New DrillDownChart.nwindDataSet()
            DirectCast(Me.chartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(simpleDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(series1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(pieSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(pieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(series2, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(sideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(pieSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(pieSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.salesPersonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' chartControl1
            ' 
            Me.chartControl1.DataAdapter = Me.salesPersonTableAdapter
            Me.chartControl1.DataSource = Me.salesPersonBindingSource
            simpleDiagram1.EqualPieSize = False
            Me.chartControl1.Diagram = simpleDiagram1
            Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chartControl1.Location = New System.Drawing.Point(0, 0)
            Me.chartControl1.Name = "chartControl1"
            Me.chartControl1.RuntimeHitTesting = True
            series1.ArgumentDataMember = "Sales Person"
            pieSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False
            pieSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty
            pieSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True
            pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns
            pieSeriesLabel1.TextColor = System.Drawing.Color.Black
            series1.Label = pieSeriesLabel1
            series1.LegendTextPattern = "{A}"
            series1.Name = "Categories"
            series1.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Ascending
            series1.SummaryFunction = "SUM([Extended Price])"
            pieSeriesView1.RuntimeExploding = False
            pieSeriesView1.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise
            series1.View = pieSeriesView1
            series2.ArgumentDataMember = "CategoryName"
            series2.DataFilters.ClearAndAddRange(New DevExpress.XtraCharts.DataFilter() { New DevExpress.XtraCharts.DataFilter("Sales Person", "System.String", DevExpress.XtraCharts.DataFilterCondition.Equal, Nothing)})
            sideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True
            series2.Label = sideBySideBarSeriesLabel1
            series2.Name = "Series 1"
            series2.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending
            series2.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1
            series2.SummaryFunction = "SUM([Extended Price])"
            Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() { series1, series2}
            pieSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True
            Me.chartControl1.SeriesTemplate.Label = pieSeriesLabel2
            pieSeriesView2.RuntimeExploding = False
            pieSeriesView2.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise
            Me.chartControl1.SeriesTemplate.View = pieSeriesView2
            Me.chartControl1.Size = New System.Drawing.Size(789, 471)
            Me.chartControl1.TabIndex = 0
            chartTitle1.Alignment = System.Drawing.StringAlignment.Near
            chartTitle1.Antialiasing = False
            chartTitle1.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Underline)
            chartTitle1.Indent = 20
            chartTitle1.Text = "Back to the main view..."
            chartTitle1.TextColor = System.Drawing.Color.RoyalBlue
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.False
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom
            chartTitle2.Indent = 20
            chartTitle2.Text = "Sales by Person"
            Me.chartControl1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() { chartTitle1, chartTitle2})
            ' 
            ' salesPersonTableAdapter
            ' 
            Me.salesPersonTableAdapter.ClearBeforeFill = True
            ' 
            ' salesPersonBindingSource
            ' 
            Me.salesPersonBindingSource.DataMember = "SalesPerson"
            Me.salesPersonBindingSource.DataSource = Me.nwindDataSet
            ' 
            ' nwindDataSet
            ' 
            Me.nwindDataSet.DataSetName = "nwindDataSet"
            Me.nwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(789, 471)
            Me.Controls.Add(Me.chartControl1)
            Me.Name = "Form1"
            Me.Text = "Drill-Down Chart"
            DirectCast(simpleDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(pieSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(pieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(series1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(sideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(series2, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(pieSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(pieSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.chartControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.salesPersonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents chartControl1 As DevExpress.XtraCharts.ChartControl
        Private salesPersonTableAdapter As nwindDataSetTableAdapters.SalesPersonTableAdapter
        Private nwindDataSet As nwindDataSet
        Private salesPersonBindingSource As System.Windows.Forms.BindingSource

    End Class
End Namespace

