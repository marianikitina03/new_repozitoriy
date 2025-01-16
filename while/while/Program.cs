using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое натуральное число");
            int a;
            if (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите второе натуральное число, которое будет больше первого");
            int b;
            if (!int.TryParse(Console.ReadLine(), out b ) || a > b )
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            bool found = false;

            int i = a;

            while (i <= b)
            {
                if (i % 123 == 0)
                {
                    found = true;
                    break;
                }
                i++;
            }

            if (found)
            {
                Console.WriteLine($"Первое число в промежутке от {a} до {b}, которое делится на 123 без остатка это {i}");
            }
            else
            {
                Console.WriteLine($"В промежутке от {a} до {b} нет числа, которое делится на 123 без остатка");
            }
            Console.ReadKey();

        }
    }
}
