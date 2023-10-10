using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;

namespace _6
{
    // ______________ Перечесление ______________
    public enum ProductCategorty
    {
        Product,
        Device,
        PrinterDevice,
        Scanner,
        Computer,
        Tablet
    }


    // ______________ Структура ______________
    public struct ProductInfo
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategorty Category { get; set; }
    }


    // ______________ 1) Интерфейсы ______________
    public interface ITech
    {
        string Name { get; set; }
        decimal Price { get; set; }
        string ToString();
    }


    // ______________ 4) Одноименные интерфкйс Clone  ______________
    public interface IClone
    {
        string Clone();
    }


    // ______________ 2) Абстрактный класс ______________
    public abstract class Products
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductCategorty Category { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
    // ______________ 1) Классы ______________
    public class Device : Products, ITech // может тоже abstract class ????????
    {
        public string? Manufacturer { get; set; } // производитель

        // ______________ Переопределение методов от Object ______________
        public override bool Equals(object? obj)
        {
            return obj is Products products &&
                   Name == products.Name &&
                   Price == products.Price;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Category: {Category}";
        }

        // заменнем методом ToString() по заданию 6)
        //______________ Виртуальный метод ______________
        //public virtual string GetInfo() // перегрузили виртуальный метод
        //{
        //    return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}";
        //}
    }
    public class PrinterDevice : Device, ITech
    {
        public bool IsColor { get; set; }
        public int PrintSpeed { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, IsColor: {IsColor}, PrintSpped: {PrintSpeed}, Category: {Category}";
        }
    }
    public class Scanner : Device, ITech
    {
        public int ScanResolution { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, ScanResolution: {ScanResolution}, Category: {Category}";
        }
    }
    public class Computer : Device, ITech
    {
        public string Processor { get; set; }
        public string GraphicsCard { get; set; }

        // ______________ 3) Запрет от sealed на переопределение ______________
        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Processor: {Processor}, GraphicsCard: {GraphicsCard}, Category: {Category}";
        }
    }
    public class Tablet : Device, ITech
    {
        public int ScreenSize { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Screen Size: {ScreenSize}, Category: {Category}";
        }
    }


    // ______________ 3) Запрет от sealed на переопределение ______________
    public class Laptop : Computer, ITech
    {
        //public override string GetInfo()
        //{
        //    return "123";
        //}
    }


    // ______________ 7) Класс Printer ______________
    partial class Printer
    {
        public static void IAmPrinting(Products products)
        {
            Console.WriteLine("Origin Printer:");
            Console.WriteLine("    " + products.ToString() + "\n");
        }
    }


    // ______________ 4) Одноименные класс Clone ______________
    public abstract class ClassCloneAbstact
    {
        public abstract string Clone();
    }

    class InheritanceClone : ClassCloneAbstact, IClone
    {
        public override string Clone()
        {
            return "ClassClone void";
        }

        string IClone.Clone()
        {
            return "IClone void";
        }
    }


    // ______________ Функции ______________
    class Inheritance
    {
        static void Main()
        {
            #region old
            Console.WriteLine("\n______________ 1 ______________\n");

            Device dev = new() { Name = "device", Price = 10000, Manufacturer = "China", Category = ProductCategorty.Device };

            Printer.IAmPrinting(dev);

            Computer computer = new() { Name = "my desktop", Price = 3500, Manufacturer = "China", GraphicsCard = "1650", Processor = "ryzen 5", Category = ProductCategorty.Computer };

            Printer.IAmPrintingPartial(computer);

            Console.WriteLine("\n______________ 3 ______________\n");

            Laboratory lab = new Laboratory();

            lab.Add(new Device { Name = "device", Price = 1, Manufacturer = "Chinaaaaaaa", Category = ProductCategorty.Device });
            lab.Add(new Device { Name = "device", Price = 1000, Manufacturer = "Chinaaaaaaa", Category = ProductCategorty.Device });
            lab.Add(new Device { Name = "device", Price = 15, Manufacturer = "Chinaaaaaaa", Category = ProductCategorty.Device });
            lab.Add(new Computer { Name = "computer", Price = 3000, Manufacturer = "ccc", Category = ProductCategorty.Computer });
            lab.Add(new Computer { Name = "computer2", Price = 3300, Manufacturer = "ccc2", Category = ProductCategorty.Computer });
            lab.Add(new Computer { Name = "computer2", Price = 3300, Manufacturer = "ccc2", Category = ProductCategorty.Computer });
            lab.Add(new Scanner { Name = "scanner", Price = 89, Manufacturer = "Беларусь", ScanResolution = 1000, Category = ProductCategorty.Scanner });


            Console.WriteLine("\n-----------");

            //lab.SortByPrice();


            Console.WriteLine("\n-----------");

            lab.CategoryCount();


            Console.WriteLine("-----------\nnew list:");

            lab.NewListValues = new List<Products>() { new Device { Name = "new device", Price = 999, Manufacturer = "рб", Category = ProductCategorty.Device } };
            lab.Print();

            Console.WriteLine("\n______________ controller ______________");

            LaboratoryController laboratoryController = new();

            laboratoryController.AddDevice("my pc", 2100, "china");
            laboratoryController.AddDevice("other pc", 1000, "c1");
            laboratoryController.AddDevice("my pc2", 3700, "c2");
            laboratoryController.AddScanner("scanner", 400, "belarus", 1000);
            laboratoryController.AddScanner("", 12312, "belarus", 200);

            laboratoryController.Print();
            Console.WriteLine("");
            laboratoryController.CategoryCount();
            #endregion


            // ______________ 5) Assert ______________

            object? someObject = null;
            Debug.Assert(someObject != null, "someObject is null! this could totally be a bug!");
            //try
            //{
            //    int a = 0;
            //    if(a == 1)
            //    {
            //        throw new MyExceptions("error");
            //    }
            //    else
            //    {
            //        Console.WriteLine(a);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}