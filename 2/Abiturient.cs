using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Abiturient // ______________ Вариант 5 ______________
    {

        private readonly int _id;

        private string _name;
        private string _surname;
        private string _patronymic;

        private string _address;
        private string _phoneNumber;
        private List<int> _Grades;

        // конструкторы

        static Abiturient() // статистический вызывается сразу
        {
            Console.WriteLine("Инициализация абитуриента...\n");
        }

        public Abiturient() //по умолчанию или без параметров???
        {
            _id = "1".GetHashCode();
            _name = "имя";
            _surname = "фамилия";
            _patronymic = "отчество";
            _address = "адрес";
            _phoneNumber = "375293647671";
            _Grades = new List<int>();
            //name = _name;

            MainAbiturient();
        }
        public Abiturient(string name, string surname, string patronymic, string address, string phoneNumber, List<int> Grades) // с параметрами
        {
            _id = name.GetHashCode();
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _address = address;
            _phoneNumber = phoneNumber;
            _Grades = Grades;

            MainAbiturient();
        }
        //                                  ???????????????????????????????????????????????????????
        private Abiturient(int id) // закрытый
        {
            this._id = id;

            MainAbiturient();
        }

        public static Abiturient CreateAbiturientWithId(int id) // определенный id
        {
            return new Abiturient(id);
        }


        // функции
        void MainAbiturient()
        {
            Console.WriteLine($"id: {_id}");
            Console.WriteLine($"имя: {_name}\nфамилия: {_surname}\nотчество: {_patronymic}");
            Console.WriteLine($"адрес: {_address}");
            Console.WriteLine($"номер телефона: {_phoneNumber}");
            if(_Grades == null || _Grades.Count == 0)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.Write("оценки: ");
                Console.WriteLine(String.Join(", ", _Grades));
                Console.WriteLine("\n");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Abiturient abiturient1 = new();
            Abiturient abiturient2 = new("Святосла", "Кунцов", "Юрьевич", "кв 69", "3647671", new List<int> { 4, 4, 9, 4, 4 } );

            var abiturient3 = Abiturient.CreateAbiturientWithId(123);

            //Random rnd = new Random(245);

        }
    }
}
