using System.Collections;

namespace _3
{
    public class Set<T> : IEnumerable<T>
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Инициализация множества...\n");
            Console.ResetColor();
        }
        public Set()
        {
            this.allItems = new HashSet<T>();
        }
        public Set(IEnumerable<T> collection)
        {
            this.allItems = new HashSet<T>(collection);
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


        // ______________ Переопределения ______________
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }


        // ______________ Функции ______________
        public void Add(T item)
        {
            this.allItems.Add(item);
        }
        public void Remove(T item)
        {
            this.allItems.Remove(item);
        }


        public static void FindShortestWord(Set<string> set)
        {

            List<string> strings = new();

            foreach (string item in set.allItems)
            {
                strings.Add(item);
            }
            string shortestWord = strings.OrderBy(x => x.Length).ToList<string>().First<string>();

            Console.WriteLine("shortest word: " + shortestWord);
        }
        public static void Sort(Set<T> set)
        {
            
            List<T> sortArray = new();

            foreach (T item in set.allItems)
            {
                sortArray.Add(item);
            }
            sortArray.Sort();

            Console.Write("sort: ");
            foreach (T item in sortArray)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n\n");
        }

        public void Print()
        {
            if(this.allItems.Count == 0)
            {
                Console.Write("Нет элементов");
            }
            foreach (T item in this.allItems)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }


        // ______________ Вложенные классы ______________ ????? как создать вложенный обьект
        public class Production
        {
            private int _id { get; set; }
            private string _organizationName { get; set; }

            public Production(int id, string name)
            {
                this._id = id;
                this._organizationName = name;

                Console.WriteLine("Организация: ");
                Console.WriteLine($"    id: {_id}, Название: {_organizationName}");


            }
        }
        public class Developer
        {
            private int _id { get; set; }
            private string _developerName { get; set; }
            private string _department { get; set; }

            public Developer(int id, string name, string department)
            {
                this._id = id;
                this._developerName = name;
                this._department = department;

                Console.WriteLine("Разработчик: ");
                Console.WriteLine($"    id: {_id}, ФИО: {_developerName}, Отдел: {_department}");
            }
        }
    }
}
