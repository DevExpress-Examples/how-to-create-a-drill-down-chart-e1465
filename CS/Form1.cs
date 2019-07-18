using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;

namespace DrillDownChart {
    public partial class Form1 : XtraForm {
        List<string> categories;
        Font linkFont;
        Font regularFont;
        ChartControl chartControl { get { return chartControl1; } }
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e) {
            var keys = SaleItem.CategorizedProducts.Keys;
            categories = new List<string>(keys.Count);
            foreach (string category in SaleItem.CategorizedProducts.Keys)
                categories.Add(category);

            List<SaleItem> data = SaleItem.GetTotalIncome();
            chartControl.DataSource = data;
            chartControl.SeriesTemplate.SeriesDataMember = "Category";
            chartControl.SeriesTemplate.ArgumentDataMember = "Company";
            chartControl.SeriesTemplate.QualitativeSummaryOptions.SummaryFunction = "SUM([Income])";
            chartControl.SeriesTemplate.View = new StackedBarSeriesView();

            SeriesTemplate argumentDrillTemplate = new SeriesTemplate();
            argumentDrillTemplate.SeriesDataMember = "Category";
            argumentDrillTemplate.ArgumentDataMember = "OrderDate";
            argumentDrillTemplate.View = new StackedAreaSeriesView();
            argumentDrillTemplate.DateTimeSummaryOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            argumentDrillTemplate.DateTimeSummaryOptions.UseAxisMeasureUnit = false;
            argumentDrillTemplate.DateTimeSummaryOptions.SummaryFunction = "SUM([Income])";
            chartControl.SeriesTemplate.ArgumentDrillTemplate = argumentDrillTemplate;

            SeriesTemplate seriesDrillTemplate = new SeriesTemplate();
            seriesDrillTemplate.SeriesDataMember = "Product";
            seriesDrillTemplate.ArgumentDataMember = "Company";
            seriesDrillTemplate.QualitativeSummaryOptions.SummaryFunction = "SUM([Income])";
            seriesDrillTemplate.View = new StackedBarSeriesView();
            chartControl.SeriesTemplate.SeriesDrillTemplate = seriesDrillTemplate;

            SeriesTemplate seriesPointDrillTemplate = new SeriesTemplate();
            seriesPointDrillTemplate.SeriesDataMember = "Product";
            seriesPointDrillTemplate.ArgumentDataMember = "OrderDate";
            seriesPointDrillTemplate.DateTimeSummaryOptions.MeasureUnit = DateTimeMeasureUnit.Month;
            seriesPointDrillTemplate.DateTimeSummaryOptions.UseAxisMeasureUnit = false;
            seriesPointDrillTemplate.DateTimeSummaryOptions.SummaryFunction = "SUM([Income])";
            seriesPointDrillTemplate.View = new StackedAreaSeriesView();
            chartControl.SeriesTemplate.SeriesPointDrillTemplate = seriesPointDrillTemplate;

            if (chartControl.Diagram is XYDiagram diagram) {
                diagram.Rotated = true;
                regularFont = diagram.AxisX.Label.Font;
                linkFont = new Font(regularFont, FontStyle.Underline);
                diagram.AxisX.Label.Font = linkFont;
            }

            chartControl.DrillDownStateChanged += chart_DrillDownStateChanged;
        }

        void chart_DrillDownStateChanged(object sender, DrillDownStateChangedEventArgs e) {
            if (chartControl.Diagram is XYDiagram diagram && e.Series.Length > 0) {
                if (e.Series[0].View is StackedBarSeriesView) {
                    chartControl.CrosshairEnabled = DefaultBoolean.False;
                    chartControl.ToolTipEnabled = DefaultBoolean.True;
                    diagram.Rotated = true;
                    diagram.AxisX.Label.Font = this.linkFont;
                    diagram.EnableAxisXScrolling = false;
                    diagram.EnableAxisXZooming = false;
                }
                else {
                    chartControl.CrosshairEnabled = DefaultBoolean.True;
                    chartControl.ToolTipEnabled = DefaultBoolean.False;
                    diagram.Rotated = false;
                    diagram.AxisX.Label.Font = this.regularFont;
                    diagram.EnableAxisXScrolling = true;
                    diagram.EnableAxisXZooming = true;
                }
            }
            foreach (DrillDownItem item in e.States) {
                if (item.Parameters.ContainsKey("Category")) {
                    chartControl.PaletteBaseColorNumber = categories.IndexOf(item.Parameters["Category"].ToString()) + 1;
                    return;
                }
            }
            chartControl.PaletteBaseColorNumber = 0;
        }
    }
}
