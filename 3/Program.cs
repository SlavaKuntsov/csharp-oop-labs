namespace _3
{
    class Program
    {
        static void Main()
        {
            Set<int> set = new(new int[] { 1, 2, 3, 4 });

            set.Add(5);

            set >>= 1;

            set <<= 6;

            set >>= 3;
            set >>= 2;

            set <<= 1;
            set <<= 100;
            set <<= 22;


            Console.Write("Первое множество: ");
            set.Print();

            Set<int> set_2 = new(new int[] { 56, 99, 2, 3, 12 });
            Set<int> set_3 = new(new int[] { 2, 3 });

            Console.Write("Второе множество: ");
            set_2.Print();

            Console.Write("Третье множество: ");
            set_3.Print();

            
            Console.WriteLine("\n-----------------\n");


            bool subset = set > set_2;
            Console.WriteLine("Подмножество: " + subset);

            bool equals_1 = set != set_2;
            Console.WriteLine("Неравенство множеств: " + equals_1);

            bool equals_2 = set_2 != set_2;
            Console.WriteLine("Неравенство множеств: " + equals_2);


            Console.WriteLine("\n-----------------\n");


            Set<int> intersection = set % set_2;
            Console.Write("Пересечение  множеств 1 и 2: ");
            intersection.Print();

            Set<int> intersection_2 = set_2 % set_3;
            Console.Write("Пересечение  множеств 2 и 3: ");
            intersection_2.Print();


            Console.WriteLine("\n-----------------\n");


            Set<int>.Sort(set);


            Console.WriteLine("-----------------\n");

            // почему вызывается static Set() во второй раз


            Set<string> stringSet = new(new string[] { "chai", "tea", "iLoveYou", "1265465465", "sd" });
            stringSet.Print();  

            Set<string>.FindShortestWord(stringSet);


            Console.WriteLine("\n-----------------\n");


            Set<object>.Production _ = new(1, "myCompany");

            Set<object>.Developer __ = new(1, "Кунцов Святослав Юрьевич", "Frontend development");


            Console.WriteLine("-----------------\n");


            Console.WriteLine("Сумма set: " + StatisticOperation<int>.Sum(set));
            Console.WriteLine("Количество в set: " + StatisticOperation<int>.Count(set));
            Console.WriteLine("Разница Min и Max в set_2: " + StatisticOperation<int>.Difference(set_2));

            Console.WriteLine("\nКоличество в stringSet: " + StatisticOperation<string>.Count(stringSet));

        }
    }
}
