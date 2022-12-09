Imports DevExpress.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors

Namespace DrillDownChart
    Partial Public Class Form1
        Inherits XtraForm

        Private categories As List(Of String)
        Private linkFont As DXFont
        Private regularFont As DXFont
        Private ReadOnly Property chartControl() As ChartControl
            Get
                Return chartControl1
            End Get
        End Property
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim keys = SaleItem.CategorizedProducts.Keys
            categories = New List(Of String)(keys.Count)
            For Each category As String In SaleItem.CategorizedProducts.Keys
                categories.Add(category)
            Next category

            Dim data As List(Of SaleItem) = SaleItem.GetTotalIncome()
            chartControl.DataSource = data
            chartControl.SeriesTemplate.SeriesDataMember = "Category"
            chartControl.SeriesTemplate.ArgumentDataMember = "Company"
            chartControl.SeriesTemplate.QualitativeSummaryOptions.SummaryFunction = "SUM([Income])"
            chartControl.SeriesTemplate.View = New StackedBarSeriesView()

            Dim argumentDrillTemplate As New SeriesTemplate()
            argumentDrillTemplate.SeriesDataMember = "Category"
            argumentDrillTemplate.ArgumentDataMember = "OrderDate"
            argumentDrillTemplate.View = New StackedAreaSeriesView()
            argumentDrillTemplate.DateTimeSummaryOptions.MeasureUnit = DateTimeMeasureUnit.Month
            argumentDrillTemplate.DateTimeSummaryOptions.UseAxisMeasureUnit = False
            argumentDrillTemplate.DateTimeSummaryOptions.SummaryFunction = "SUM([Income])"
            chartControl.SeriesTemplate.ArgumentDrillTemplate = argumentDrillTemplate

            Dim seriesDrillTemplate As New SeriesTemplate()
            seriesDrillTemplate.SeriesDataMember = "Product"
            seriesDrillTemplate.ArgumentDataMember = "Company"
            seriesDrillTemplate.QualitativeSummaryOptions.SummaryFunction = "SUM([Income])"
            seriesDrillTemplate.View = New StackedBarSeriesView()
            chartControl.SeriesTemplate.SeriesDrillTemplate = seriesDrillTemplate

            Dim seriesPointDrillTemplate As New SeriesTemplate()
            seriesPointDrillTemplate.SeriesDataMember = "Product"
            seriesPointDrillTemplate.ArgumentDataMember = "OrderDate"
            seriesPointDrillTemplate.DateTimeSummaryOptions.MeasureUnit = DateTimeMeasureUnit.Month
            seriesPointDrillTemplate.DateTimeSummaryOptions.UseAxisMeasureUnit = False
            seriesPointDrillTemplate.DateTimeSummaryOptions.SummaryFunction = "SUM([Income])"
            seriesPointDrillTemplate.View = New StackedAreaSeriesView()
            chartControl.SeriesTemplate.SeriesPointDrillTemplate = seriesPointDrillTemplate

            Dim diagram As XYDiagram = CType(chartControl.Diagram, XYDiagram)
            If (Not (diagram) Is Nothing) Then
                diagram.Rotated = True
                regularFont = diagram.AxisX.Label.DXFont
                linkFont = New DXFont(regularFont, DXFontStyle.Underline)
                diagram.AxisX.Label.DXFont = linkFont
            End If

            AddHandler chartControl.DrillDownStateChanged, AddressOf chart_DrillDownStateChanged
        End Sub

        Private Sub chart_DrillDownStateChanged(ByVal sender As Object, ByVal e As DrillDownStateChangedEventArgs)
            Dim diagram As XYDiagram = TryCast(chartControl.Diagram, XYDiagram)

            If (diagram IsNot Nothing) AndAlso (e.Series.Length > 0) Then

                If TypeOf e.Series(0).View Is StackedBarSeriesView Then
                    chartControl.CrosshairEnabled = DefaultBoolean.[False]
                    chartControl.ToolTipEnabled = DefaultBoolean.[True]
                    diagram.Rotated = True
                    diagram.AxisX.Label.DXFont = Me.linkFont
                    diagram.EnableAxisXScrolling = False
                    diagram.EnableAxisXZooming = False
                Else
                    chartControl.CrosshairEnabled = DefaultBoolean.[True]
                    chartControl.ToolTipEnabled = DefaultBoolean.[False]
                    diagram.Rotated = False
                    diagram.AxisX.Label.DXFont = Me.regularFont
                    diagram.EnableAxisXScrolling = True
                    diagram.EnableAxisXZooming = True
                End If
            End If

            For Each item As DrillDownItem In e.States

                If item.Parameters.ContainsKey("Category") Then
                    chartControl.PaletteBaseColorNumber = categories.IndexOf(item.Parameters("Category").ToString()) + 1
                    Return
                End If
            Next

            chartControl.PaletteBaseColorNumber = 0
        End Sub
    End Class
End Namespace
