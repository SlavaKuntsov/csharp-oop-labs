using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Tuples
    {
        internal void Main()
        {
            // ______________ A ______________

            (int, string, char, string, ulong) tuple = (1, "string", 'c', "string", 123L);

            // ______________ B ______________

            Console.WriteLine(tuple + "\n");

            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);


            // ______________ C ______________

            var tuple2 = new Tuple<int, string, char, string, ulong>(1, "string", 'c', "string", 123L);
            var tuple22 = new Tuple<int, string, char, string, ulong>(1, "string", 'c', "char", 123L);
            Console.WriteLine("\ntuple2.Item2\n");


            var tuple3 = (1, "string", 'c', "string", 123544534544L);

            int a = tuple3.Item1;
            string b = tuple3.Item2;
            char c = tuple3.Item3;
            string d = tuple3.Item4;
            long e = tuple3.Item5;

            Console.WriteLine($"{a} {b} {c} {d} {e}\n");


            var (f, g, h, i, j) = tuple3;

            Console.WriteLine($"{f} {g} {h} {i} {j}\n");


            var (_, k, _, l, _) = tuple3;

            Console.WriteLine($"k: {k}");

            // ______________ D ______________

            if (tuple2 == tuple22)
            {
                Console.WriteLine(123);
            }
            else
            {
                Console.WriteLine(456);
            }
            
        }
    }
}
