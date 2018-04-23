using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace DrillDownChart {
    public partial class Form1 : Form {

        public Form1 () {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.SalesPerson' table. You can move, or remove it, as needed.
            this.salesPersonTableAdapter.Fill(this.nwindDataSet.SalesPerson);
        }

        private void chartControl1_MouseClick (object sender, MouseEventArgs e) {
            // Obtain the object being clicked.
            ChartHitInfo hi = chartControl1.CalcHitInfo(e.X, e.Y);

            // Check whether it was a series point, and if yes - 
            // obtain its argument, and pass it to the detail series.
            SeriesPoint point = hi.SeriesPoint;

            if (point != null) {
                string argument = point.Argument.ToString();

                // Flip the series.
                if (chartControl1.Series[0].Visible == true) {
                    chartControl1.Series[0].Visible = false;

                    chartControl1.Series[1].Name = argument;
                    chartControl1.Series[1].Visible = true;

                    // Since the new series determines another diagram's type,
                    // you should re-define axes properties.
                    XYDiagram diagram = chartControl1.Diagram as XYDiagram;
                    diagram.AxisY.Label.NumericOptions.Format = NumericFormat.Currency;
                    diagram.AxisY.Label.NumericOptions.Precision = 0;

                    chartControl1.Series[1].DataFilters[0].Value = argument;

                    chartControl1.Titles[0].Visible = true;
                    chartControl1.Titles[1].Text = "Personal Sales by Categories";
                }
            }

            // Obtain the title under the test point.
            ChartTitle link = hi.ChartTitle;

            // Check whether the link was clicked, and if yes - 
            // restore the main series.
            if (link != null && link.Text.StartsWith("Back")) {
                chartControl1.Series[0].Visible = true;
                chartControl1.Series[1].Visible = false;

                link.Visible = false;
                chartControl1.Titles[1].Text = "Sales by Person";
            }
        }

    }
}