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
            var x = GetNumber("x");
            var y = GetNumber("y");

            if (IsStatementTrue(x, y))
                Console.WriteLine("Точка с координатами x,y принадлежит выделенной области");
            else
                Console.WriteLine("Точка с координатами x,y НЕ принадлежит выделенной области");

            Console.ReadKey();
        }


        static bool IsStatementTrue(int x, int y)
        {
            return y >= -2 && (x <= -3  || x >= -1 );
        }

        static int GetNumber(string numberName)
        {
            Console.WriteLine($"Введите координату {numberName}");

            return int.Parse(Console.ReadLine());
        }
    }
    
}
