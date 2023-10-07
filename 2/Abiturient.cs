using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Abiturient // ______________ Вариант 5 ______________
    {
        private static int abiturientCount = 0;
        private readonly uint _id;

        public string? _name { get; set; }
        private string? _surname { get; set; }
        private string? _patronymic { get; set; }
        private const string _address = "БГТУ";
        private string? _phoneNumber { get; set; }

        private List<int>? _Grades;
        private double? _sum { get; set; }
        private int? _maxGrade { get; set; }
        private int? _minGrade { get; set; }


        // ______________ Конструкторы ______________
        static Abiturient() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Инициализация абитуриента...\n");
            Console.ResetColor();
        }
        public Abiturient() 
        {            
            _id = (uint)abiturientCount.GetHashCode();
            abiturientCount++;
        }
        public Abiturient(string name, string surname, string patronymic, 
            List<int> Grades = null)
        {
            this._name = name;
            this._surname = surname;
            this._patronymic = patronymic;
            this._phoneNumber = "+375293333333";
            this._Grades = Grades ?? new List<int> { 5, 5, 5, 5, 5 };

            _id = (uint)abiturientCount.GetHashCode();

            AcademicStatistics(_Grades);

            abiturientCount++;
        }
        public Abiturient(string name, string surname, string patronymic, string phoneNumber, List<int> Grades)
        { 
            this._name = name;
            this._surname = surname;
            this._patronymic = patronymic;
            this._phoneNumber = phoneNumber;
            this._Grades = Grades;

            _id = (uint)abiturientCount.GetHashCode();

            AcademicStatistics(_Grades);

            abiturientCount++;
        }
        private Abiturient(int id)
        {
            this._id = (uint)id;

            abiturientCount++;
        }
        public static Abiturient CreateAbiturientWithId(int id) 
        {
            return new Abiturient(id);
        }


        // ______________ Методы ______________
        public void PrintInMethods()
        {
            #region
            //Console.WriteLine($"id: {abiturient._id}");
            //Console.WriteLine($"имя: {abiturient._name}\nфамилия: {abiturient._surname}\nотчество: {abiturient._patronymic}");
            //Console.WriteLine($"адрес: {_address}");
            //Console.WriteLine($"номер телефона: {abiturient._phoneNumber}");
            #endregion
            string gradesString = string.Join(", ", _Grades);
            Console.WriteLine($"    id: {_id}, имя: {_name}, фамилия: {_surname}, отчество: {_patronymic}, адрес: {_address} номер телефона: {_phoneNumber}, отметки: {gradesString}, средний балл: {_sum}, min: {_minGrade}, max: {_maxGrade}");
        }
        public static void PrintAll(Array array)
        {
            foreach(Abiturient abiturient in array)
            {
                string gradesString = string.Join(", ", abiturient._Grades);
                Console.WriteLine($"    id: {abiturient._id}, имя: {abiturient._name}, фамилия: {abiturient._surname}, отчество: {abiturient._patronymic}, адрес: {_address} номер телефона: {abiturient._phoneNumber}, отметки: {gradesString}, средний балл: {abiturient._sum}, min: {abiturient._minGrade}, max: {abiturient._maxGrade}");
            }
        }
        public static void PrintCount()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nКоличество абитуриентов: {abiturientCount}\n");
            Console.ResetColor();
        }
        // 1 или 3 метода?
        private void AcademicStatistics(List<int> grades)
        {
            this._sum = grades.Average();
            this._maxGrade = grades.Max();
            this._minGrade = grades.Min();
        }
        public static void UnsatisfactoryGrades(Array array)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nCписок абитуриентов, имеющих неудовлетворительные оценки:");
            Console.ResetColor();
            foreach (Abiturient abiturient in array)
            {
                if (abiturient._minGrade < 4)
                    abiturient.PrintInMethods();
            }
        }
        public static void GradesIsHigherThan(Array array, ref int point)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nСписок абтуриентов с баллом выше : '{point}'");
            Console.ResetColor();
            foreach (Abiturient abiturient in array)
            {
                if (abiturient._sum > point)
                    abiturient.PrintInMethods();
            }
        }


        // ______________ Переопределения ______________
    }


    class Program
    {
        static void Main()
        {
            // ______________ Создание обьектов ______________ 
            Abiturient[] allAbiturients = new Abiturient[]
            {
                new("Святослав", "Кунцов", "Юрьевич", "3647671", new List<int> { 4, 4, 9, 4, 4 } ),
                new("паша", "паша", "паша", "13123", new List<int> { 3, 4, 4, 4, 4 } ),
                new("никита", "никита", "никита", "897689", new List<int> { 9, 9, 9, 9, 9 } ),
            };

            Abiturient objectWithDefaultParam = new("аня", "аня", "аня", new List<int> { 9, 9, 9, 9, 9 });
            Abiturient objectWithoutParams = new();

            var _ = Abiturient.CreateAbiturientWithId(123);

            Abiturient.PrintAll(allAbiturients);


            // ______________ Сравнение обьектов ______________ 


            // ______________ Cписок абитуриентов, имеющих неудовлетворительные оценки ______________
            Abiturient.UnsatisfactoryGrades(allAbiturients);


            // ______________ Список абтуриентов с баллом выше заданного ______________
            int needPoint = 6;
            Abiturient.GradesIsHigherThan(allAbiturients, ref needPoint);


            // ______________ Вывод количества обьектов ______________
            Abiturient.PrintCount();


            // ______________ Partial class ______________
            Person void1 = new();
            void1.AbiturientVoid();
            void1.OtherVoid();
        }
    }

    public partial class Person
    {
        public void AbiturientVoid()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("this void in Abiturient.cs");
            Console.ResetColor();
        }

    }
}
