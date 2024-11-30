using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое слагаемое");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе слагаемое");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("Сумма чисел равна " + (x + y));

            Console.ReadKey();

           }
    }
}
