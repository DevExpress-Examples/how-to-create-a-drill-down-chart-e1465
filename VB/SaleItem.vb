Imports System
Imports System.Collections.Generic
Imports System.Linq
Namespace DrillDownChart
	Friend Class SaleItem
		Private ReadOnly Shared companies() As String = { "DevAV North", "DevAV South", "DevAV West", "DevAV East", "DevAV Central" }
'INSTANT VB NOTE: The field categorizedProducts was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private Shared categorizedProducts_Renamed As Dictionary(Of String, List(Of String))
		Friend Shared ReadOnly Property CategorizedProducts() As Dictionary(Of String, List(Of String))
			Get
				If categorizedProducts_Renamed Is Nothing Then
					categorizedProducts_Renamed = New Dictionary(Of String, List(Of String))()
					categorizedProducts_Renamed("Cameras") = New List(Of String)() From {"Camera", "Camcorder", "Binoculars", "Flash", "Tripod"}
					categorizedProducts_Renamed("Cell Phones") = New List(Of String)() From {"Smartphone", "Mobile Phone", "Smart Watch", "Sim Card"}
					categorizedProducts_Renamed("Computers") = New List(Of String)() From {"Desktop", "Laptop", "Tablet", "Printer"}
					categorizedProducts_Renamed("TV, Audio") = New List(Of String)() From {"Television", "Home Audio", "Headphone", "DVD Player"}
					categorizedProducts_Renamed("Vehicle Electronics") = New List(Of String)() From {"GPS Unit", "Radar", "Car Alarm", "Car Accessories"}
					categorizedProducts_Renamed("Multipurpose Batteries") = New List(Of String)() From {"Battery", "Charger", "Converter", "Tester", "AC/DC Adapter"}
				End If
				Return categorizedProducts_Renamed
			End Get
		End Property
		Friend Shared Function GetTotalIncome() As List(Of SaleItem)
			Dim rnd As New Random(Date.Now.Millisecond)
			Dim now As Date = Date.Now
			Dim endDate As New Date(now.Year, now.Month, 1)
			Dim items As New List(Of SaleItem)()
'INSTANT VB NOTE: The variable company was renamed since Visual Basic does not handle local variables named the same as class members well:
			For Each company_Renamed As String In companies
				Dim companyFactor As Double = rnd.NextDouble() * 0.6 + 1
'INSTANT VB NOTE: The variable category was renamed since Visual Basic does not handle local variables named the same as class members well:
				For Each category_Renamed As String In CategorizedProducts.Keys
					Dim categoryFactor As Double = rnd.NextDouble() * 0.6 + 1
'INSTANT VB NOTE: The variable product was renamed since Visual Basic does not handle local variables named the same as class members well:
					For Each product_Renamed As String In CategorizedProducts(category_Renamed)
						Dim maxIncome As Integer = rnd.Next(60, 140)
						For i As Integer = 0 To 999
							If i Mod 100 = 0 Then
								maxIncome = Math.Max(40, rnd.Next(maxIncome - 20, maxIncome + 20))
							End If
							Dim [date] As Date = endDate.AddDays(-i - 1)
'INSTANT VB NOTE: The variable income was renamed since Visual Basic does not handle local variables named the same as class members well:
							Dim income_Renamed As Double = rnd.Next(20, maxIncome) * companyFactor * categoryFactor
							items.Add(New SaleItem() With {
								.Category = category_Renamed,
								.Company = company_Renamed,
								.Product = product_Renamed,
								.OrderDate = [date],
								.Income = income_Renamed
							})
						Next i
					Next product_Renamed
				Next category_Renamed
			Next company_Renamed
			Return items
		End Function
		Public Property Product() As String
		Public Property Company() As String
		Public Property OrderDate() As Date
		Public Property Month() As String
		Public Property Income() As Double
		Public Property Revenue() As Double
		Public Property Category() As String
	End Class
	Friend Class CategorySaleItem
'INSTANT VB NOTE: The field saleItems was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private ReadOnly saleItems_Renamed As New List(Of SaleItem)()
'INSTANT VB NOTE: The field productIncome was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private productIncome_Renamed As Dictionary(Of String, Double)
		Public Property OrderIndex() As Integer
		Public Property Category() As String
		Public ReadOnly Property SaleItems() As List(Of SaleItem)
			Get
				Return saleItems_Renamed
			End Get
		End Property
		Public ReadOnly Property TotalIncome() As Double
			Get
				Return saleItems_Renamed.Sum(Function(x) x.Income)
			End Get
		End Property
		Public ReadOnly Property ProductIncome() As Dictionary(Of String, Double)
			Get
				If productIncome_Renamed Is Nothing Then
					productIncome_Renamed = New Dictionary(Of String, Double)()
					For Each item As SaleItem In SaleItems
						If productIncome_Renamed.Keys.Contains(item.Product) Then
							productIncome_Renamed(item.Product) += item.Income
						Else
							productIncome_Renamed(item.Product) = item.Income
						End If
					Next item
				End If
				Return productIncome_Renamed
			End Get
		End Property
	End Class
End Namespace