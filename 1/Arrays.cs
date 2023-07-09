using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Arrays
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

            Console.WriteLine("    old:");
            foreach(string word in stringArray)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine($"\nArray length: {stringArray.Length}\n");

            Console.Write("new value: ");
            string? newValue = Console.ReadLine();

            stringArray[2] = newValue ?? "qwe";

            Console.WriteLine("\n    new:");
            foreach (string word in stringArray)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("");

            // ______________ C ______________

            double[][] stepwiseArray = new double[3][];

            //stepwiseArray[0] = new double[2];
            //stepwiseArray[1] = new double[3];
            //stepwiseArray[2] = new double[4];

            for (int i = 0; i < 3; i++)
            {
                stepwiseArray[i] = new double[i + 1];
            }

            // input
            for (int i = 0; i < stepwiseArray.Length; i++)
            {
                for (int j = 0; j < stepwiseArray[i].Length; j++)
                {
                    stepwiseArray[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            // output
            Console.WriteLine("\nStepwise Array:\n");
            for (int i = 0; i < stepwiseArray.Length; i++)
            {
                for (int j = 0; j < stepwiseArray[i].Length; j++)
                {
                    Console.Write(stepwiseArray[i][j] + "   ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

            // ______________ D ______________

            var notTypedArray = new[] {
                new[] { 1.0, 1.5, 2.0 },
                new[] { 2.0, 2.5, 3.0 }
            };

            var notTypedString = "Not typed string\n";

            Console.WriteLine(notTypedString);
            Console.WriteLine("Not typed array:\n");

            foreach (double[] rowArr in notTypedArray)
            {
                foreach (double number in rowArr)
                {
                    Console.Write(number + "   ");
                }
                Console.WriteLine("");
            }
        }
    }
}
