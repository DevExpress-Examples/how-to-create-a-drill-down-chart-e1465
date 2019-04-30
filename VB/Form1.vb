Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace DrillDownChart
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' TODO: This line of code loads data into the 'nwindDataSet.SalesPerson' table. You can move, or remove it, as needed.
			Me.salesPersonTableAdapter.Fill(Me.nwindDataSet.SalesPerson)
		End Sub

		Private Sub chartControl1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles chartControl1.MouseClick
			' Obtain the object being clicked.
			Dim hi As ChartHitInfo = chartControl1.CalcHitInfo(e.X, e.Y)

			' Check whether it was a series point, and if yes - 
			' obtain its argument, and pass it to the detail series.
			Dim point As SeriesPoint = hi.SeriesPoint

			If point IsNot Nothing Then
				Dim argument As String = point.Argument.ToString()

				' Flip the series.
				If chartControl1.Series(0).Visible = True Then
					chartControl1.Series(0).Visible = False

					chartControl1.Series(1).Name = argument
					chartControl1.Series(1).Visible = True

					' Since the new series determines another diagram's type,
					' you should re-define axes properties.
					Dim diagram As XYDiagram = TryCast(chartControl1.Diagram, XYDiagram)
					diagram.AxisY.Label.TextPattern = "{V:c0}"

					chartControl1.Series(1).DataFilters(0).Value = argument

					chartControl1.Titles(0).Visibility = DevExpress.Utils.DefaultBoolean.True
					chartControl1.Titles(1).Text = "Personal Sales by Categories"
				End If
			End If

			' Obtain the title under the test point.
			Dim link As ChartTitle = hi.ChartTitle

			' Check whether the link was clicked, and if yes - 
			' restore the main series.
			If link IsNot Nothing AndAlso link.Text.StartsWith("Back") Then
				chartControl1.Series(0).Visible = True
				chartControl1.Series(1).Visible = False

				link.Visibility = DevExpress.Utils.DefaultBoolean.False
				chartControl1.Titles(1).Text = "Sales by Person"
			End If
		End Sub

	End Class
End Namespace