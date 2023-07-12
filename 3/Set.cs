using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Collections;

namespace _3
{
    class Set<T> : IEnumerable<T>
    {
        // ______________ IEnumerable ______________
        public IEnumerator<T> GetEnumerator()
        {
            return allItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return allItems.GetEnumerator();
        }


        // ______________ Поля ______________
        private HashSet<T> allItems;


        // ______________ Конструкторы ______________
        static Set()
        {
            Console.WriteLine("Инициализация множества...\n");
        }
        public Set()
        {
            allItems = new HashSet<T>();
        }
        public Set(IEnumerable<T> collection)
        {
            allItems = new HashSet<T>(collection);
        }


        // ______________ Операторы ______________
        public static Set<T> operator <<(Set<T> set, T item) // добавить
        {
            set.allItems.Add(item);
            return set;
        }
        public static Set<T> operator >>(Set<T> set, T item) // удалить
        {
            set.allItems.Remove(item);
            return set;
        }
        public static bool operator >(Set<T> set1, Set<T> set2) // является ли set2 подмножеством set1 (set2 в set1)
        {
            return set2.allItems.IsSubsetOf(set1.allItems);
        }
        #region <
        public static bool operator <(Set<T> set1, Set<T> set2) // является ли set2 подмножеством set1 (set2 в set1)
        {
            return set2.allItems.IsSubsetOf(set1.allItems);
        }
        #endregion
        public static bool operator !=(Set<T> set1, Set<T> set2) // неравенство
        {
            return !set1.allItems.SetEquals(set2.allItems);
        }
        #region ==
        public static bool operator ==(Set<T> set1, Set<T> set2)
        {
            return false;
        }
        #endregion
        public static Set<T> operator %(Set<T> set1, Set<T> set2) // пересечение (новое множество из того что входит и в set1 и в set2)
        {
            return new Set<T>(set1.allItems.Intersect(set2.allItems));
        }


        // ______________ Функции ______________
        public void Add(T item)
        {
            allItems.Add(item);
        }
        public void Remove(T item)
        {
            allItems.Remove(item);
        }


        public static void FindShortestWord(Set<string> set)
        {

            List<string> strings = new();

            foreach (string item in set.allItems)
            {
                strings.Add(item);
            }
            var t = strings.OrderBy(x => x.Length).ToList<string>().First<string>();

            Console.WriteLine("shortest word: " + t);
        }
        public static void Sort(Set<T> set)
        {
            
            List<T> numbers = new();

            foreach (T item in set.allItems)
            {
                numbers.Add(item);
            }
            numbers.Sort();

            Console.Write("sort: ");
            foreach (T person in numbers)
            {
                Console.Write(person + " ");
            }
            Console.Write("\n\n");
        }

        public void Print()
        {
            foreach (T item in allItems)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }


        // ______________ Вложенные классы ______________ ????? как создать вложенный обьект
        public class Production
        {
            private int _id { get; set; }
            private string _organizationName { get; set; } = String.Empty;

            public Production(int id, string name)
            {
                _id = id;
                _organizationName = name;
                Console.WriteLine("Организация: ");
                Console.WriteLine("id: " + _id);
                Console.WriteLine("название: " + _organizationName);
            }
        }
        public class Developer
        {
            private int _id { get; set; }
            private string _developerName { get; set; } = String.Empty;
            private string _department { get; set; } = String.Empty;

            public Developer(int id, string name, string department)
            {
                _id = id;
                _developerName = name;
                _department = department;
                Console.WriteLine("Разработчик: ");
                Console.WriteLine("id: " + _id);
                Console.WriteLine("Имя: " + _developerName);
                Console.WriteLine("Отдел: " + _department);
            }
        }
    }


    static class StatisticOperation<T>
    {
        public static int Sum(Set<int> set)
        {
            int sum = 0;
            foreach (int number in set)
            {
                sum += number;
            }
            return sum;
        }
        public static int Count(Set<T> set)
        {
            int count = 0;
            foreach (T number in set)
            {
                count++;
            }
            return count;
        }
        public static int Difference(Set<int> set)
        {
            int min = set.Min();
            int max = set.Max();

            int diff = max - min;

            return diff;
        }

    }


    class Program
    {
        static void Main()
        {
            Set<int> set = new(new int[] { 1, 2, 3, 4 });

            set.Add(5);

            set >>= 1;
            set <<= 6;

            Set<int> set2 = new(new int[] { 56, 99, 2, 3, 12 });
            Set<int> set3 = new(new int[] { 2, 3 });

            set.Print();
            set2.Print();

            bool subset = set > set2;
            Console.WriteLine("subset: " + subset);

            bool equals1 = set != set2;
            Console.WriteLine("equals set set2: "+ equals1);

            bool equals2 = set2 != set3;
            Console.WriteLine("equals set2 set3: "+ equals2 + "\n");

            Set<int> intesiction = set % set2;
            intesiction.Print();

            // ______________  ______________

            Console.WriteLine("-----------------\n");
            Set<int>.Sort(set2);

            Set<string> stringSet = new(new string[] { "chai", "tea", "iLoveYou", "1265465465" });
            Set<string>.FindShortestWord(stringSet);

            // ______________  ______________

            Console.WriteLine("-----------------\n");

            Set<object>.Developer dev = new(1, "Слава", "Фронтенд");

            // ______________  ______________

            Console.WriteLine("-----------------\n");

            Console.WriteLine("sum set: " + StatisticOperation<int>.Sum(set));
            Console.WriteLine("count set: " + StatisticOperation<int>.Count(set));
            Console.WriteLine("difference set2: " + StatisticOperation<int>.Difference(set2));

            Console.WriteLine("\ncount stringSet: " + StatisticOperation<string>.Count(stringSet));

            // 2) упорядочивание 
            // как сделать и нужно ли
        }
    }
}
