using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public partial class Person
    {
        public void OtherVoid()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("this void in Partial.cs");
            Console.ResetColor();
        }
    }
}
