using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число");
            int b;

            if (!int.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();

            var numbers = new int[15];

            for (int i = 0; i < 15; i++)
            {
                numbers[i] = (i * i) - b;
            }

            Console.WriteLine("Массив:");
            PrintArray(numbers);
            Console.WriteLine();

            ChangeArray(numbers);


            Console.WriteLine("Измененный массив:");
            PrintArray(numbers);
            Console.WriteLine();

            double average = CalculateAverage(numbers, out int sum);
            Console.WriteLine($"Среднее арифметическое элементов массива: {average:F3}");
            Console.WriteLine();

            Console.WriteLine("Введите целое число k");
            int k;
            if (!int.TryParse(Console.ReadLine(), out k))
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();

            Console.WriteLine("Остаток от деления элементов массива на число k:");
            CountRemainder(numbers, k);
            Console.ReadKey();
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(";");
                }
            }
            Console.WriteLine();
        }

        static void ChangeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!(i % 2 == 0))
                {
                    array[i] = -array[i];
                }
            }
        }

        static double CalculateAverage(int[] array, out int sum)
        {
            sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return (double)sum / array.Length;
        }

        static void CountRemainder(int[] array, int k)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] % k);
                if (i < array.Length - 1)
                {
                    Console.Write(";");
                }
            }
            Console.WriteLine();
        }
    }
    
}
