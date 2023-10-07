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
                        Types newTypes = new();
                        newTypes.Main();
                        ReturnToMenu();
                        break;
                    case "2":
                        Strings newStrings = new();
                        newStrings.Main();
                        ReturnToMenu();
                        break;
                    case "3":
                        Arrays newArrays = new();
                        newArrays.Main();
                        ReturnToMenu();
                        break;
                    case "4":
                        Tuples newTuples = new();
                        newTuples.Main();
                        ReturnToMenu();
                        break;
                    case "5":
                        int[] numbersArray = { 1, 25334, 3 };
                        string letter = "New string";

                        Console.WriteLine(Calculate(numbersArray, letter));
                        ReturnToMenu();
                        break;
                    case "6":
                        Console.WriteLine("checked");
                        FunctionOne();
                        ReturnToMenu();
                        break;
                    case "7":
                        Console.WriteLine("unchecked");
                        FunctionTwo();
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



            // ______________ Local function ______________

            (int, int, int, char) Calculate(int[] numbers, string letters)
            {

                int sum = 0;
                foreach (int number in numbers)
                {
                    sum += number;
                }
                //Console.WriteLine(numbers.Max());
                //Console.WriteLine(numbers.Min());
                //Console.WriteLine(letters[0]);

                (int, int, int, char) tuple = (numbers.Max(), numbers.Min(), sum, letters[0]);
                return tuple;
            }


            // ______________ checked/unchecked ______________

            void FunctionOne()
            {
                checked
                {
                    int max = int.MaxValue;
                    Console.WriteLine("max значение int в checked: " + max);
                    max++;
                    Console.WriteLine("Yвеличить значение на 1: " + max);
                }
            }

            void FunctionTwo()
            {
                unchecked
                {
                    int max = int.MaxValue;
                    Console.WriteLine("max значение int в unchecked: " + max);
                    max++;
                    Console.WriteLine("Увеличение значения на 1 : " + max);
                }
            }

        }

        static public string DisplayMenu()
        {
            Console.WriteLine("\n    Выберите номер лабораторной работы: \n");
            Console.WriteLine("    1. Типы");
            Console.WriteLine("    2. Строки");
            Console.WriteLine("    3. Массивы");
            Console.WriteLine("    4. Кортежи");
            Console.WriteLine("    5. Local function");
            Console.WriteLine("    6. checked");
            Console.WriteLine("    7. unchecked");

            //Console.WriteLine("\n    x. Выйти");

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
