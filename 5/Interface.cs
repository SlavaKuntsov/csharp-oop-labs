using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    public interface Interface
    {
        // ______________ 1) Интерфейсы ______________
        interface ITech
        {
            string? Name { get; set; }
            decimal? Price { get; set; }
            string ToString();
        }
        // ______________ 4) Одноименные интерфкйс Clone  ______________
        interface IClone
        {
            string Clone();
        }
    }
}
