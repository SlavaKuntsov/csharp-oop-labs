using System;

namespace _1
{
    public class ArraysLab
    {
        internal void Main()
        {
            // ______________ A ______________

            int[,] array = new int[,] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };

            int row = array.GetLength(0);
            int col = array.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");

            // ______________ B ______________

            string[] stringArray = { "first", "two", "three" };

            foreach(string word in stringArray)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine($"Array length: {stringArray.Length}");
        }

    }
}
