using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            while (true) 
            {
                Console.WriteLine("Введите натуральное число");

                if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
                {
                    Console.WriteLine("Введите натуральное число");
                    continue; 
                }

                if (!HasDifferentDigits(number)) 
                {
                    Console.WriteLine("Число содержит повторяющиеся цифры. Введите число, в котором все цифры различны");
                    continue; 
                }

                break; 
            }

            int maxDigit = -1;
            int position = 0;
            int maxPosition = -1;

            while (number > 0)
            {
                int digit = number % 10;
                position++;

                if (digit > maxDigit)
                {
                    maxDigit = digit;
                    maxPosition = position;
                }

                number /= 10;
            }

            Console.WriteLine($"Порядковый номер максимальной цифры (справа налево): {maxPosition}");
            Console.ReadKey();
        }

        
        static bool HasDifferentDigits(int num)
        {
            HashSet<int> digits = new HashSet<int>(); 

            while (num > 0)
            {
                int digit = num % 10; 

                if (digits.Contains(digit)) 
                {
                    return false;
                }

                digits.Add(digit); 
                num /= 10; 
            }

            return true;
        }

    }
}
    

