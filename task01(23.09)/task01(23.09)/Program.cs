using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task01_23._09_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Звезда");

            Console.WriteLine();

            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Взгляни на звезды: много звезд");
            Console.WriteLine("В безмолвии ночном");
            Console.WriteLine("Горит, блестит кругом луны");
            Console.WriteLine("На небе голубом.");

            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
