using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public partial class Printer
    {
        public static void IAmPrintingPartial(Products products)
        {
            Console.WriteLine("Partial Printer:");
            Console.WriteLine("    " + products.ToString() + "\n");
        }
    }

    public partial class Laboratory // ???????????? get и set методы конструктора
    {
        private List<Products> allProducts;
        // ______________ Конструктор ______________
        public Laboratory()
        {
            allProducts = new List<Products>();
        }

        // ______________ Функции ______________
        public void Add(Products products)
        {
            allProducts.Add(products);
        }
        public void Remove(Products products)
        {
            allProducts.Remove(products);
        }

        public void Print() // было SortByPrice, стало Print
        {
            List<Products> sortAllProducts = new(allProducts.OrderByDescending(p => p.Price)) ;
            //Console.Write("sort by price: \n");
            foreach (Products tech in sortAllProducts)
            {
                Console.WriteLine(tech);
                //Console.WriteLine("    " + tech);
            }
        }
        //public void Print() //изначальный Print
        //{
        //    foreach (Products product in allProducts)
        //    {
        //        Console.WriteLine(product.ToString());
        //    }
        //}
        public void CategoryCount()
        {
            int allCount = 0;

            Dictionary<ProductCategorty, int> categoryCount = new();

            foreach (Products product in allProducts)
            {
                allCount++;
                if(categoryCount.ContainsKey(product.Category))
                {
                    categoryCount[product.Category]++;
                }
                else
                {
                    categoryCount.Add(product.Category, 1);
                }
            }
            foreach(KeyValuePair<ProductCategorty, int> item in categoryCount)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        public List<Products> NewListValues
        {
            get { return allProducts; }
            set { allProducts = value; }
        }

    }

    public partial class LaboratoryController 
    {
        private Laboratory lab;

        public LaboratoryController()
        {
            lab = new Laboratory();
        }

        public void AddDevice(string name, int price, string manufacterer)
        {
            Device device = new() { Name = name, Price = price, Manufacturer = manufacterer, Category = ProductCategorty.Device };
            lab.Add(device);
        }
        public void AddScanner(string name, int price, string manufacterer, int scanResolution)
        {
            Scanner scanner = new() { Name = name, Price = price, Manufacturer = manufacterer, ScanResolution = scanResolution, Category = ProductCategorty.Scanner };
            lab.Add(scanner);
        }

        public void Print()
        {
            //lab.SortByPrice();
            lab.Print();
        }
        public void CategoryCount()
        {
            lab.CategoryCount();   
        }
    }

}
