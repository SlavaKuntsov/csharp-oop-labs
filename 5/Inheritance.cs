using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;
using static _5.Interface;

namespace _5
{
    // ______________ Перечесление ______________
    public enum ProductCategorty
    {
        Products,
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

    // ______________ 2) Абстрактный класс ______________
    public abstract class Products
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public ProductCategorty Category { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}\n";
        }
    }
    // ______________ 1) Классы ______________
    public class Device : Products, ITech 
    {
        public string? Manufacturer { get; set; } // производитель

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
            return $"Device: {Name}, Price: {Price}, Manufacturer: {Manufacturer}";
        }
    }
    public class PrinterDevice : Device, ITech
    {
        public bool IsColor { get; set; }
        public int PrintSpeed { get; set; }

        public override string ToString()
        {
            return $"PrinterDevice: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, IsColor: {IsColor}, PrintSpped: {PrintSpeed}";
        }
    }
    public class Scanner : Device, ITech
    {
        public int ScanResolution { get; set; }

        public override string ToString()
        {
            return $"Scanner: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, ScanResolution: {ScanResolution}";
        }
    }
    public class Computer : Device, ITech
    {
        public string? Processor { get; set; }
        public string? GraphicsCard { get; set; }

        public override string ToString()
        {
            return $"Computer: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Processor: {Processor}, GraphicsCard: {GraphicsCard}";
        }
    }
    public class Tablet : Device, ITech
    {
        public int ScreenSize { get; set; }

        public override string ToString()
        {
            return $"Tablet: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Screen Size: {ScreenSize}";
        }
    }


    // ______________ 3) Запрет от sealed на переопределение ______________
    public class Laptop : Computer, ITech
    {
        public override string ToString()
        {
            return $"Laptop: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Processor: {Processor}, GraphicsCard: {GraphicsCard}";
        }
    }


    // ______________ 7) Класс Printer ______________
    partial class Printer
    {
        public static void IAmPrinting(Products products)
        {
            Console.WriteLine("Original Printer:");
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
    internal class Inheritance
    {
        static void Main()
        {

            Device dev = new() { Name = "device", Price = 10000, Manufacturer = "China", Category = ProductCategorty.Device };

            Printer.IAmPrinting(dev);

            Computer computer = new() { Name = "my desktop", Price = 3500, Manufacturer = "China", GraphicsCard = "1650", Processor = "ryzen 5", Category = ProductCategorty.Computer };

            Printer.IAmPrintingPartial(computer);


            Laboratory lab = new();

            lab.Add(new Device { Name = "device", Price = 1, Manufacturer = "Chinaaaaaaa", Category = ProductCategorty.Device });
            lab.Add(new Device { Name = "device", Price = 1000, Manufacturer = "Chinaaaaaaa", Category = ProductCategorty.Device });
            lab.Add(new Device { Name = "device", Price = 15, Manufacturer = "Chinaaaaaaa", Category = ProductCategorty.Device });
            lab.Add(new Computer { Name = "computer", Price = 3000, Manufacturer = "ccc", Category = ProductCategorty.Computer });
            lab.Add(new Computer { Name = "computer2", Price = 3300, Manufacturer = "ccc2", Category = ProductCategorty.Computer });
            lab.Add(new Computer { Name = "computer2", Price = 3300, Manufacturer = "ccc2", Category = ProductCategorty.Computer });
            lab.Add(new Scanner { Name = "scanner", Price = 89, Manufacturer = "Беларусь", ScanResolution = 1000, Category = ProductCategorty.Scanner });


            Console.WriteLine("\n-----------");

            lab.CategoryCount();


            Console.WriteLine("-----------\n\nnew list:");

            lab.NewList = new List<Products>() { new Device { Name = "new device", Price = 999, Manufacturer = "рб", Category = ProductCategorty.Device } };
            lab.Print();

            Console.WriteLine("\n______________ controller ______________");

            LaboratoryController laboratoryController = new();

            laboratoryController.AddDevice("my pc", 2100, "china");
            laboratoryController.AddDevice("other pc", 1000, "c1");
            laboratoryController.AddDevice("my pc2", 3700, "c2");
            laboratoryController.AddScanner("scanner", 400, "belarus", 1000);

            laboratoryController.Print();
            Console.WriteLine("");
            laboratoryController.CategoryCount();   
        }
    }
}