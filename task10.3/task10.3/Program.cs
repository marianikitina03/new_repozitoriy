using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
                int n;
                if (!TryInputNumber("Введите количество чисел n:", out n) || n <= 0)
                {
                    Console.WriteLine("Количество чисел должно быть больше нуля ");
                    Console.ReadKey();
                    return;
                }

                int[] numbers = new int[n];

                for (int i = 0; i < n; i++)
                {
                    if (!TryInputNumber($"Введите число {i + 1}:", out numbers[i]))
                    {
                        Console.ReadKey();
                        return;
                    }
                }

                int maxCount = 1;
                int currentCount = 1;

                for (int i = 1; i < n; i++)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        currentCount++;
                    }
                    else
                    {
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }
                        currentCount = 1;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }

                Console.WriteLine($"Максимальное количество подряд идущих одинаковых чисел: {maxCount}");
                Console.ReadKey();
            }

            static bool TryInputNumber(string message, out int number)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();

                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Ошибка ввода. Введите целое число.");
                    return false;
                }

                return true;
            }

        }
    }

