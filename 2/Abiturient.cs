using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Abiturient // ______________ Вариант 5 ______________
    {
        private static int abiturientCount = 0;

        private readonly int _id;

        public string _name { get; set; } = string.Empty;
        private string _surname { get; set; } = string.Empty;
        private string _patronymic { get; set; } = string.Empty;

        private const string _address = "БГТУ";
        private string _phoneNumber { get; set; } = string.Empty;
        private List<int> _Grades;

        // успеваемость
        private int _sum = 0;
        private static bool _goodAcademicPerformance = false;

// ______________ Конструкторы ______________
        static Abiturient() // статистический вызывается сразу
        {
            Console.WriteLine("Инициализация абитуриента...\n");
        }

        public Abiturient() //по умолчанию или без параметров???
        {
            Random rnd = new Random(245);

            //_name = "имя";
            //_surname = "фамилия";
            //_patronymic = "отчество";
            //_address = "адрес";
            //_phoneNumber = "375293647671";
            //_Grades = new List<int>();

            _id = _phoneNumber.GetHashCode();

            abiturientCount++;
            MainAbiturient();
        }
        public Abiturient(string name, string surname, string patronymic, string address, string phoneNumber, List<int> Grades) // с параметрами
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _Grades = Grades;

            _id = phoneNumber.GetHashCode();

// ______________ Средний балл ______________
            foreach (int grade in _Grades)
            {
                _sum += grade;
            }
            _sum = _sum / _Grades.Count;

            /*
            if(_sumResult > 6)
            {
                _goodAcademicPerformance = true;
            }
             */

            abiturientCount++;
            MainAbiturient();
        }
// ???????????????????????????????????????????????????????
        private Abiturient(int id) // закрытый
        {
            this._id = id;

            abiturientCount++;
            MainAbiturient();
        }

        public static Abiturient CreateAbiturientWithId(int id) // определенный id
        {
            return new Abiturient(id);
        }


// ______________ Fuctions ______________
        void MainAbiturient()
        {
            Console.WriteLine($"id: {_id}");
            Console.WriteLine($"имя: {_name}\nфамилия: {_surname}\nотчество: {_patronymic}");
            Console.WriteLine($"адрес: {_address}");
            Console.WriteLine($"номер телефона: {_phoneNumber}");
            if(_Grades == null || _Grades.Count == 0)
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.Write("оценки: ");
                Console.WriteLine(String.Join(", ", _Grades));
                //Console.WriteLine($"sum grades: {_sumResult}\n");
                //Console.WriteLine($"успеваемость: {_goodAcademicPerformance}\n");
            }
            Console.WriteLine("\n");
            
        }

        public static void PrintCount()
        {
            Console.WriteLine("---");
            Console.WriteLine($"Количество абитуриентов: {abiturientCount}");
            Console.WriteLine("---\n");
        }

        public static void UnsatisfactoryGrades(Array array)
        {
            //Console.WriteLine("array: " + array);
            Console.WriteLine($"\nCписок абитуриентов, имеющих неудовлетворительные оценки:");
            foreach (Abiturient abiturient in array)
            {
                int minGrade = abiturient._Grades.Min();
                if(minGrade < 4)
                {
                    Console.WriteLine($"    -{abiturient._name}");
                }
            }
        }
        public static void GradesIsHigherThan(Array array, int point)
        {
            //Console.WriteLine("array: " + array);
            Console.WriteLine($"\nСписок абтуриентов с баллом выше : {point}");
            foreach (Abiturient abiturient in array)
            {
                if(abiturient._sum > point)
                {
                    Console.WriteLine($"    -{abiturient._name}");
                }
            }
        }

    }

    class Program
    {
        static void Main()
        {
// ______________ Массив обьектов Abiturient ______________
            Abiturient[] allAbiturients = new Abiturient[]
            {
                //new(),
                //Abiturient.CreateAbiturientWithId(13),
                new("Святослав", "Кунцов", "Юрьевич", "кв 69", "3647671", new List<int> { 4, 4, 9, 4, 4 } ),
                new("паша", "паша", "паша", "", "13123", new List<int> { 3, 4, 4, 4, 4 } ),
                new("никита", "никита", "никита", "", "897689", new List<int> { 9, 9, 9, 9, 9 } ),
            };
            //var abiturient3 = Abiturient.CreateAbiturientWithId(123);


// ______________ Вывод количества обьектов ______________
            Abiturient.PrintCount();


// ______________ Partial class ______________
            Person void1 = new();
            void1.AbiturientVoid();
            void1.OtherVoid();


// ______________ Сравнение обьектов ______________ ??????????????????????????
            Object abiturient1 = new();
            Object abiturient1_CLone = new();

            //Abiturient abiturient2 = new("Святослав", "Кунцов", "Юрьевич", "кв 69", "3647671", new List<int> { 4, 4, 9, 4, 4 } );
            //Abiturient abiturient2_Clone = new("Святослав", "Кунцов", "Юрьевич", "кв 69", "3647671", new List<int> { 4, 4, 9, 4, 4 } );

            //Console.WriteLine("\n--- " + abiturient1.Equals(abiturient2));
            //Console.WriteLine("--- " + abiturient1.Equals(abiturient1_CLone));

            //Console.WriteLine("успеваемость:\n");
            //Abiturient.AcademicPerformance();


// ______________ Cписок абитуриентов, имеющих неудовлетворительные оценки ______________
            Abiturient.UnsatisfactoryGrades(allAbiturients);


// ______________ Список абтуриентов с баллом выше заданного ______________
            Abiturient.GradesIsHigherThan(allAbiturients, 6);


        }
    }

    public partial class Person
    {
        public void AbiturientVoid()
        {
            Console.WriteLine("------    this void in Abiturient.cs   ------");
        }

    }
}
