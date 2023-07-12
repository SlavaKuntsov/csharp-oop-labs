using System.Diagnostics;
using System.Xml.Linq;

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




    // ______________ 1) Интерфейсы ______________
    public interface ITech
    {
        string Name { get; set; }
        decimal Price { get; set; }
        string GetInfo();
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

    }
    // ______________ 1) Классы ______________
    public class Device : Products, ITech
    {
        public string Manufacturer { get; set; } // производитель

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
        public override string? ToString()
        {
            return base.ToString();
        }

        // ______________ Виртуальный метод ______________
        public virtual string GetInfo() // перегрузили виртуальный метод
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}";
        }
    }
    public class Printer : Device, ITech
    {
        public string IsColor { get; set; }
        public string PrintSpeed { get; set; }
    }
    public class Scanner : Device, ITech
    {
        public string ScanResolution { get; set; }
    }
    public class Computer : Device, ITech
    {
        public string Processor { get; set; }
        public string GraphicsCard { get; set; }

        // ______________ 3) Запрет от sealed на переопределение ______________
        public override sealed string GetInfo()
        {
            return "this is a computer";
        }
    }
    public class Tablet : Device, ITech
    {
        public int ScreenSize { get; set; }

        public virtual string GetInfo()
        {
            return $"Product: {Name}, Price: {Price}, Manufacturer: {Manufacturer}, Screen Size: {ScreenSize}";
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
            Device prod = new Device { Name = "name", Price = 100, Manufacturer = "Китай" };
            Device prod2 = new Device { Name = "name2", Price = 1002 };
            Device prod3 = new Device { Name = "name2", Price = 1002 };

            Console.WriteLine("info: " + prod.GetInfo());
            Console.WriteLine("info: " + prod2.GetInfo());

            Console.WriteLine(prod3.Equals(prod2));

            Console.WriteLine("\n______________ 2 ______________\n");

            Tablet tablet = new Tablet { Name = "tablet", Price = 89, Manufacturer = "Беларусь", ScreenSize = 1920 };
            //Console.WriteLine(tablet.GetInfo());

            Console.WriteLine("\n______________ 3 ______________\n");

            Computer comp = new Computer { Name = "comp" };
            Laptop laptop = new Laptop { Name = "laptop" };

            Console.WriteLine(comp.GetInfo());
            Console.WriteLine(laptop.GetInfo());

            Console.WriteLine("\n______________ 4 ______________\n");

            InheritanceClone clone = new();

            Console.WriteLine(clone.Clone());
            Console.WriteLine( ((IClone)clone).Clone() ); //       ( ( IInterface )object ).Void()
        }
    }
}