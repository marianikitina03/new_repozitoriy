using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task03_07._10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите трехзначное число n");
            var number = int.Parse(Console.ReadLine());

            var first = number / 100;
            var second = number / 10 % 10;
            var third = number % 10;

            Console.WriteLine("Исходное число x = " + second + "" + first + "" + third);
            Console.ReadKey();
        }
    }
}
