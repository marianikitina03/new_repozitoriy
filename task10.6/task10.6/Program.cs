using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Трехзначные числа, в которых нет одинаковых цифр:");

            string result = "";

            for (int number = 100; number <= 999; number++)
            {
                if (HasDifferentDigits(number))
                {
                    result += $"{number}, "; 
                }
            }

            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 2); 
            }

            Console.WriteLine(result); 
            Console.ReadKey();
        }

        static bool HasDifferentDigits(int number)
        {
            bool[] digits = new bool[10];

            while (number > 0)
            {
                int digit = number % 10;

                if (digits[digit])
                {
                    return false;
                }

                digits[digit] = true;
                number /= 10;
            }

            return true;
        }
    }
}
