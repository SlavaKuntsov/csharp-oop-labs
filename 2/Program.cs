namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[][] stepwiseArray = new double[3][];


            stepwiseArray[0] = new double[2];
            stepwiseArray[1] = new double[3];
            stepwiseArray[2] = new double[4];

            Console.WriteLine("Инициализация первой строки:");
            for (int i = 0; i < 2; i++)
            {
                stepwiseArray[0][i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Инициализация второй строки:");
            for (int i = 0; i < 3; i++)
            {
                stepwiseArray[1][i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Инициализация третей строки:");
            for (int i = 0; i < 4; i++)
            {
                stepwiseArray[2][i] = Convert.ToDouble(Console.ReadLine());
            }



            for (int i = 0; i < 2; i++)
            {
                Console.Write($"\t{stepwiseArray[0][i]}");
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"\t{stepwiseArray[1][i]}"); 
            }

            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"\t{stepwiseArray[2][i]}");
            }
        }
    }
}