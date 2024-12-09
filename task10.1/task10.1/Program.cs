using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            if (!TryInputNumber("Введите число n", out n))
            {
                Console.ReadKey();
                return;
            }

            if (n <= 0)
            {
                Console.WriteLine("Число n должно быть больше 0");
                Console.ReadKey();
                return;
            }

            double sum = 0;

            for (var i = 1; i <= n; i++)
            {
                sum += Math.Sqrt(i);
            }

            Console.WriteLine($"Сумма квадратных корней всех целых чисел от 1 до {n} равна {sum}");
            Console.ReadKey();
        }

        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }

            return true;
        }
    }
}
