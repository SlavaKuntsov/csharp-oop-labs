using System;
using System.Text;

namespace _1
{
    public class StringsLab
    {
        internal void Main()
        {
            
            // ______________ A ______________

            string string1 = "Это первая строка";
            string string2 = "Это вторая строка";
            string string3 = "Это третья строка";

            int result = string.Compare(string1, string2); // можно использовать Compare

            Console.WriteLine(result);

            // ______________ B ______________


            string all1 = string1 + ' ' + string2 + ' ' + string3;
            string all2 = string.Concat(string1, ' ', string2, ' ', string3);

            Console.WriteLine(all1);
            Console.WriteLine(all2);

            //

            string copy = string.Copy(string1);

            Console.WriteLine(copy);

            //

            string substring = string1.Substring(4, 6);

            Console.WriteLine(substring);

            //

            string[] allWords = string1.Split(' ');

            foreach (string word in allWords)
            {
                Console.WriteLine($"Substring: {word}"); // + интерполирование
            }

            //

            string modified = string1.Insert(string1.Length, ", модифицированная");

            Console.WriteLine(modified);

            //

            string removeSubstring = modified.Remove(0, 4);

            Console.WriteLine(removeSubstring);

            // ______________ С ______________

            string stringNull = null;
            string stringEmpty = "";

            if(string.IsNullOrEmpty(stringEmpty))
            {
                Console.WriteLine("Is null or empty");
            }
            else
            {
                Console.WriteLine("Is string");
            }

            // ______________ D ______________

            StringBuilder build = new StringBuilder("new", 10);

            build.Replace("new", "old");

            build.Insert(0, "1. ");

            build.Insert(6, " !");


            Console.WriteLine(build);

            
        }
    }
}