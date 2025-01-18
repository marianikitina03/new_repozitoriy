using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task02_07._10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину прямоугольника");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите ширину прямоугольника");
            var b = double.Parse(Console.ReadLine());
            var p = (a + b) * 2;
            var area = a * b;
            var ab = Math.Pow(a, 2) + Math.Pow(b, 2);
            var diagonal = Math.Sqrt(ab);

            Console.WriteLine();
            Console.WriteLine("Площадь прямоугольника = " + area);
            Console.WriteLine();
            Console.WriteLine("Периметр прямоугольника = " + p);
            Console.WriteLine();
            Console.WriteLine("Диагональ прямоугольника = " + diagonal);

            Console.ReadKey();
        }
    }
}
