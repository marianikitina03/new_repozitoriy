using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты точки (x,y) через пробел");
            var input = Console.ReadLine();
            var k = input.IndexOf(' ');
            var x = double.Parse(input.Substring(0, k));
            var y = double.Parse(input.Substring(k+1));

            if (IsPointInArea(x, y))
                Console.WriteLine("Точка с координатами x,y принадлежит выделенной области");
            else
                Console.WriteLine("Точка с координатами x,y НЕ принадлежит выделенной области");

            Console.ReadKey();
        }


        static bool IsPointInArea(double x, double y)
        {
            return y >= -2 && (x <= -3  || x >= -1 );
        }

    }

}
