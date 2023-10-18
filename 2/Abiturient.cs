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

        private string? _name { get; set; }
        private string? _surname { get; set; }
        private string? _patronymic { get; set; }
        private const string _address = "БГТУ";
        private string? _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;   
            }
        }

        private List<int> _Grades;
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
            _id = (uint)_address.GetHashCode();
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

            _id = (uint)_name.GetHashCode();

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

            _id = (uint)_name.GetHashCode();

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
            string gradesString = string.Join(", ", this._Grades);
            Console.WriteLine($"    id: {this._id}, имя: {this._name}, фамилия: {this._surname}, отчество: {this._patronymic}, адрес: {_address} номер телефона: {this._phoneNumber}, отметки: {gradesString}, средний балл: {this._sum}, min: {this._minGrade}, max: {this._maxGrade}");
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
            Console.Write("\nКоличество абитуриентов: ");
            Console.ResetColor();
            Console.WriteLine(abiturientCount + "\n");
        }
        private void AcademicStatistics(List<int> grades)
        {
            this._sum = grades.Average();
            this._maxGrade = grades.Max();
            this._minGrade = grades.Min();
        }
        public static void UnsatisfactoryGrades(Array array, out int minGrade)
        {

            minGrade = 4;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nCписок абитуриентов, имеющих неудовлетворительные оценки:");
            Console.ResetColor();
            foreach (Abiturient abiturient in array)
            {
                if (abiturient._minGrade < minGrade)
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Abiturient other = (Abiturient)obj;

            return this._name == other._name &&
                   this._surname == other._surname &&
                   this._patronymic == other._patronymic &&
                   this._phoneNumber == other._phoneNumber &&
                   this._Grades.SequenceEqual(other._Grades);
        }
        public override int GetHashCode()
        { 
            Console.WriteLine("hash code");
            return HashCode.Combine(_surname, _patronymic);
        }
        public override string ToString()
        {
            return $"Фамилия Имя этого студента - {this._surname} {this._name}";
        }
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
            bool equals_1 = allAbiturients[0].Equals(allAbiturients[1]);
            bool equals_2 = allAbiturients[2].Equals(allAbiturients[2]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nСравнение обьектов:");
            Console.ResetColor();

            Console.WriteLine($"    {equals_1}");
            Console.WriteLine($"    {equals_2}");


            // ______________ Cписок абитуриентов, имеющих неудовлетворительные оценки ______________
            int minGrade;
            Abiturient.UnsatisfactoryGrades(allAbiturients, out minGrade);

            Console.WriteLine($"Минимальная оценка: {minGrade}");


            // ______________ Список абтуриентов с баллом выше заданного ______________
            int needPoint = 6;
            Abiturient.GradesIsHigherThan(allAbiturients, ref needPoint);


            // ______________ Вывод количества обьектов ______________
            Abiturient.PrintCount();


            // ______________ Partial class ______________
            Person void1 = new();
            void1.AbiturientVoid();
            void1.OtherVoid();

            // ______________ Переопеределение ______________
            Console.WriteLine($"\n{allAbiturients[0].ToString()}");

            // ______________ Переопеределение ______________
            var anonym = new { name = "slava", surname = "k", patronymic = "y"};

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Anonym: ");
            Console.ResetColor();
            Console.WriteLine($"{anonym.name} {anonym.surname} {anonym.patronymic}");
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
