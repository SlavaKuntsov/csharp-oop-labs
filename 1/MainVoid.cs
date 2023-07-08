using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1
{
    internal class MainVoid
    {
        static void Main()
        {

            string classChoise = DisplayMenu();

            if(!string.IsNullOrEmpty(classChoise) )
            {
                switch (classChoise)
                {
                    case "1":
                        Console.WriteLine(123);
                        ReturnToMenu();
                        break;
                    case "2":
                        StringsLab newStrings = new();
                        newStrings.Main();
                        ReturnToMenu();
                        break;
                    case "3":
                        ArraysLab newArrays = new();
                        newArrays.Main();
                        ReturnToMenu();
                        break;



                    case "x":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("    Выбран неверный номер");
                        ReturnToMenu();
                        break;
                }
            }
        }

        static public string DisplayMenu()
        {
            Console.WriteLine("\n    Выберите номер лабораторной работы: \n");
            Console.WriteLine("    1. Типы");
            Console.WriteLine("    2. Строки");
            Console.WriteLine("    3. Массивы");

            Console.WriteLine("    x. Выйти");

            Console.Write("\n    Ваш выбор: ");

            string classChoise = Console.ReadLine();
            Console.WriteLine("\n---------------------------------------\n");
            return classChoise;
        }

        static public void ReturnToMenu()
        {
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("\n    Нажмите любую клавишу для продожения...");
            Console.ReadKey();
            Console.Clear();
            Main();
        }
    }
}
