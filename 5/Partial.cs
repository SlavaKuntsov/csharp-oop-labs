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

        public void SortByPrice()
        {
            List<Products> sortAllProducts = new(allProducts.OrderByDescending(p => p.Price)) ;
            Console.Write("sort by price: \n");
            foreach (Products tech in sortAllProducts)
            {
                Console.WriteLine("    " + tech);
            }
        }

        public void CategoryCount()
        {
            int allCount = 0;

            Dictionary<ProductCategorty, int> categoryCount = new();

            //int deviceCount = 0;
            //int printerCount = 0;
            //int scannerCount = 0;  
            //int computerCount = 0;
            //int tabletCount = 0;

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

        public void Print()
        {
            foreach (Products product in allProducts)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
