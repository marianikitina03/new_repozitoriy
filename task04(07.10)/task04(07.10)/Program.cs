using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task04_07._10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите действительное число х");
            var x = double.Parse(Console.ReadLine());

            var y = MyFunction(x);
            Console.WriteLine($"f(x)={y}");
            Console.ReadKey();

            
        }

        static double MyFunction(double x)
        {
            return Math.Sqrt((x * x) + (Math.Sqrt((x * x) + (1 / (x * x)))));
        }
    }
}
