using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число (факториал n!)");

            long factorial;

            if (!long.TryParse(Console.ReadLine(), out factorial) || factorial < 1)
            {
                Console.WriteLine("Введите натуральное число.");
                Console.ReadKey();
                return;
            }

            int n = 1;
            long currentFactorial = 1;

            while (currentFactorial < factorial)
            {
                n++;
                currentFactorial *= n; 
            }

            if (currentFactorial == factorial)
            {
                Console.WriteLine($"Число n равно {n}");
            }
            else
            {
                Console.WriteLine($"{factorial} не является факториалом");
            }

            Console.ReadKey();
        }

    }
    
}
