using static _4.Interface;

namespace _4
{
    //  Иерархия
    //
    // - Товар
    //   |--- Техника
    //        |--- Печатающее устройство
    //        |--- Сканер
    //        |--- Персональные устройства
    //              |--- Компьютер
    //              |--- Планшет
    //
    //
    //      ?????
    //
    //
    //  Товар, Техника, Печатающее устройство, Сканер, Компьютер, Планшет



    // ______________ 2) Абстрактный класс ______________
    public abstract class Products : ITech
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}\n";
        }
    }
    // ______________ 1) Классы ______________
    public class Device : Products
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
            return $"Device: {Name}, Price: {Price}, Manufacturer: {Manufacturer}";
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
            return $"PrinterDevice: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, IsColor: {IsColor}, PrintSpped: {PrintSpeed}";
        }
    }
    public sealed class Scanner : Device, ITech
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

    class Printer
    {
        public static void IAmPrinting(Products products)
        {
            Console.WriteLine(products.ToString());
        }
    }


    // ______________ 4) Одноименные класс Clone ______________
    public abstract class ClassCloneAbstact
    {
        public abstract string Clone();
    }

    class InheritanceClone : ClassCloneAbstact, IClone
    {
        public override string Clone() => "ClassClone void";
        //public override string Clone()
        //{
        //    Console.WriteLine("ClassClone void");
        //}

        string IClone.Clone() => "IClone void";
    }


    // ______________ Функции ______________
    //class Inheritance
    //{
    //    static void Main()
    //    {
    //        Device prod = new Device { Name = "prod", Price = 100, Manufacturer = "Китай" };
    //        Device prod2 = new Device { Name = "prod2", Price = 1002 };
    //        Device prod3 = new Device { Name = "prod2", Price = 1002 };
    //        Console.WriteLine(prod.ToString());
    //        Console.WriteLine(prod2.ToString());


    //        Console.Write("\nEquals: ");
    //        Console.WriteLine(prod3.Equals(prod2));
    //        Console.WriteLine();


    //        Tablet tablet = new Tablet { Name = "tablet", Price = 89, Manufacturer = "Беларусь", ScreenSize = 1920 };
    //        Console.WriteLine(tablet.ToString());

    //        Computer comp = new Computer { Name = "comp", Price = 89, Manufacturer = "Беларусь", Processor = "amd", GraphicsCard = "1650" };
    //        Laptop laptop = new Laptop { Name = "laptop" };
    //        Console.WriteLine(comp.ToString());
    //        Console.WriteLine(laptop.ToString());



    //        Console.WriteLine("\nSimilar 'Clone':");
    //        InheritanceClone clone = new();
    //        Console.WriteLine(clone.Clone());
    //        Console.WriteLine(((IClone)clone).Clone()); //       ( ( IInterface )object ).Void()
    //        Console.WriteLine();



    //        PrinterDevice printer = new PrinterDevice { Name = "printer", Price = 89, Manufacturer = "Беларусь", IsColor = true, PrintSpeed = 100 };
    //        Console.WriteLine(printer.ToString());

    //        Scanner scanner = new Scanner { Name = "scanner", Price = 89, Manufacturer = "Беларусь", ScanResolution = 1000 };
    //        Console.WriteLine(scanner.ToString());
    //        Printer.IAmPrinting(scanner);


    //        Console.WriteLine("\nArray of object with IAmPrinting():");
    //        Products[] allProduts = new Products[]
    //        {
    //            new Device{Name = "all device", Price = 1000, Manufacturer = "china"},
    //            new PrinterDevice{ Name = "printer", Price = 89, Manufacturer = "Беларусь", IsColor = true, PrintSpeed = 100 },
    //            new Scanner { Name = "scanner", Price = 89, Manufacturer = "Беларусь", ScanResolution = 1000 },
    //            new Computer { Name = "comp", Price = 89, Manufacturer = "Беларусь", Processor = "amd", GraphicsCard = "1650" },
    //            new Tablet { Name = "tablet", Price = 89, Manufacturer = "Беларусь", ScreenSize = 1920 }
    //        };
    //        foreach (var item in allProduts)
    //        {
    //            Console.Write("    ");
    //            Printer.IAmPrinting(item);
    //        }

    //        Products product1 = new Computer { Name = "product1", Price = 1200, Manufacturer = "Беларусь", Processor = "intel", GraphicsCard = "3050" };
    //        Products product2 = new Tablet { Name = "product2", Price = 700, Manufacturer = "Беларусь", ScreenSize = 1920 };
    //        Products product3 = new Scanner { Name = "scanner", Price = 89, Manufacturer = "Беларусь", ScanResolution = 1000 };

    //        Console.WriteLine();
    //        if (product1 is Computer)
    //        {
    //            Computer? computerIs = product1 as Computer;
    //            Console.WriteLine(computerIs.ToString());
    //        }
    //        if (product2 is Tablet)
    //        {
    //            Tablet? tabletIs = product2 as Tablet;
    //            Console.WriteLine(tabletIs.ToString());
    //        }
    //        if (product3 is Scanner)
    //        {
    //            Scanner? scannerIs = product3 as Scanner;
    //            Console.WriteLine(scannerIs.ToString());
    //        }

    //    }
    //}
}