using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class A
    {
        public int x = 1;
    }
    class B : A
    {
        public new int x = 2;
        public void m(int a, int b)
        {
            x = a;
            base.x = b;
            Console.Write(x + " " + base.x);
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            b.m(3, 4);
        }
    }

}
