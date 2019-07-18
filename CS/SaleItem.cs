﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace DrillDownChart {
    class SaleItem {
        readonly static string[] companies = new string[] { "DevAV North", "DevAV South", "DevAV West", "DevAV East", "DevAV Central" };
        static Dictionary<string, List<string>> categorizedProducts;
        internal static Dictionary<string, List<string>> CategorizedProducts {
            get {
                if (categorizedProducts == null) {
                    categorizedProducts = new Dictionary<string, List<string>>();
                    categorizedProducts["Cameras"] = new List<string>() { "Camera", "Camcorder", "Binoculars", "Flash", "Tripod" };
                    categorizedProducts["Cell Phones"] = new List<string>() { "Smartphone", "Mobile Phone", "Smart Watch", "Sim Card" };
                    categorizedProducts["Computers"] = new List<string>() { "Desktop", "Laptop", "Tablet", "Printer" };
                    categorizedProducts["TV, Audio"] = new List<string>() { "Television", "Home Audio", "Headphone", "DVD Player" };
                    categorizedProducts["Vehicle Electronics"] = new List<string>() { "GPS Unit", "Radar", "Car Alarm", "Car Accessories" };
                    categorizedProducts["Multipurpose Batteries"] = new List<string>() { "Battery", "Charger", "Converter", "Tester", "AC/DC Adapter" };
                }
                return categorizedProducts;
            }
        }
        internal static List<SaleItem> GetTotalIncome() {
            Random rnd = new Random(DateTime.Now.Millisecond);
            DateTime now = DateTime.Now;
            DateTime endDate = new DateTime(now.Year, now.Month, 1);
            List<SaleItem> items = new List<SaleItem>();
            foreach (string company in companies) {
                double companyFactor = rnd.NextDouble() * 0.6 + 1;
                foreach (string category in CategorizedProducts.Keys) {
                    double categoryFactor = rnd.NextDouble() * 0.6 + 1;
                    foreach (string product in CategorizedProducts[category]) {
                        int maxIncome = rnd.Next(60, 140);
                        for (int i = 0; i < 1000; i++) {
                            if (i % 100 == 0)
                                maxIncome = Math.Max(40, rnd.Next(maxIncome - 20, maxIncome + 20));
                            DateTime date = endDate.AddDays(-i - 1);
                            double income = rnd.Next(20, maxIncome) * companyFactor * categoryFactor;
                            items.Add(new SaleItem() { Category = category, Company = company, Product = product, OrderDate = date, Income = income });
                        }
                    }
                }
            }
            return items;
        }
        public string Product { get; set; }
        public string Company { get; set; }
        public DateTime OrderDate { get; set; }
        public string Month { get; set; }
        public double Income { get; set; }
        public double Revenue { get; set; }
        public string Category { get; set; }
    }
    class CategorySaleItem {
        readonly List<SaleItem> saleItems = new List<SaleItem>();
        Dictionary<string, double> productIncome;
        public int OrderIndex { get; set; }
        public string Category { get; set; }
        public List<SaleItem> SaleItems { get { return saleItems; } }
        public double TotalIncome { get { return saleItems.Sum((x) => x.Income); } }
        public Dictionary<string, double> ProductIncome {
            get {
                if (productIncome == null) {
                    productIncome = new Dictionary<string, double>();
                    foreach (SaleItem item in SaleItems)
                        if (productIncome.Keys.Contains(item.Product))
                            productIncome[item.Product] += item.Income;
                        else
                            productIncome[item.Product] = item.Income;
                }
                return productIncome;
            }
        }
    }
}