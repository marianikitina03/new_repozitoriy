using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            do
            {
                Console.WriteLine("Введите число, которое больше 100 и делится на 19 без остатка.");
                a = int.Parse(Console.ReadLine());
            } while (a < 100 || a % 19 != 0);
            Console.WriteLine($"Всё правильно. Число {a} больше 100 и делится на 19 без остатка.");
            Console.ReadKey();

        }
    }
}
