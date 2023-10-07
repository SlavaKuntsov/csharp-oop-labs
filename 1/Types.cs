using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public  class Types
    {
        internal void Main()
        {
            // ______________ A ______________

            string StringVariable = "STRIIIIIIING";

            Console.WriteLine("Input bool variable");
            bool BoolVariable = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Input byte variable");
            byte ByteVariable = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Input sbyte variable");
            sbyte SByteVariable = Convert.ToSByte(Console.ReadLine());

            Console.WriteLine("Input char variable");
            char CharVariable = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Input float variable");
            //float FloatVariable = Convert.ToSingle(1.1);
            float FloatVariable = float.Parse(Console.ReadLine());

            Console.WriteLine("Input double variable");
            double DoubleVarible = Convert.ToDouble(Console.ReadLine());
            //double DoubleVarible = Convert.ToDouble(1.2);

            Console.WriteLine("Input decimal variable");
            decimal DecimalVariable = Convert.ToDecimal(Console.ReadLine());
            //decimal DecimalVariable = Convert.ToDecimal(1.3);

            Console.WriteLine("Input int variable");
            int IntVariable = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input uint variable");
            uint UintVariable = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Input long variable");
            long LongVariable = long.Parse(Console.ReadLine());

            Console.WriteLine("Input ulong variable");
            ulong UlongVariable = ulong.Parse(Console.ReadLine());

            Console.WriteLine("Input short variable");
            short ShortVariable = short.Parse(Console.ReadLine());

            Console.WriteLine("Input ushort variable");
            ushort UshortVariable = ushort.Parse(Console.ReadLine());





            
            Console.WriteLine("variables:");
            Console.WriteLine(" string variable is: {0}", StringVariable);
            Console.WriteLine(" bool variable is: {0}", BoolVariable);
            Console.WriteLine(" byte variable is: {0}", ByteVariable);
            Console.WriteLine(" sbyte variable is: {0}", SByteVariable);
            Console.WriteLine(" char variable is: {0}", CharVariable);
            Console.WriteLine(" float variable is: {0}", FloatVariable);
            Console.WriteLine(" double variable is: {0}", DoubleVarible);
            Console.WriteLine(" decimal variable is: {0}", DecimalVariable);
            Console.WriteLine(" int variable is: {0}", IntVariable);
            Console.WriteLine(" uint variable is: {0}", UintVariable);
            Console.WriteLine(" long variable is: {0}", LongVariable);
            Console.WriteLine(" ulong variable is: {0}", UlongVariable);
            Console.WriteLine(" short variable is: {0}", ShortVariable);
            Console.WriteLine(" ushort variable is: {0}", UshortVariable);

            // ______________ B ______________

            byte a = 1;
            int b = a;

            sbyte c = 2;
            double d = c;

            int f = 3;
            decimal g = f;

            uint p = 9;
            decimal y = p;

            float t = 1.1f;
            double r = t;



            int i = 1;
            byte e = (byte)i;

            double o = 2.2;
            int n = (int)o; 

            float j = 1.1f;
            byte l = (byte)j;

            decimal q = 1.23456789876543213M;
            uint s = (uint)q;

            int h = 5;
            char v = (char)h;
            
            // ______________ C ______________



            int value = 13; 
            object Object = value; 
            int NewValue = (int)Object; 

            // ______________ D ______________

            var VAR = 5;
            
            // ______________ E ______________


            int? nullValue = null;
            Console.WriteLine(nullValue);

        }
    }
}
