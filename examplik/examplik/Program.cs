using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace examplik
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите целое число m");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите целое число n");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }
            

            if (m < 5 || m > 20 || n < 5 || n > 20)
            {
                Console.WriteLine("Числа не удовлетворяют неравенству");
                Console.ReadKey();
                return;

            }

            var matrix = new int[m, n];
            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(100);
            Console.WriteLine();
            PrintMatrix(matrix);
            Console.WriteLine();

            var index = GetIndexOfColumnWithMibimalLastElement(matrix);

            if (index < 0)
                Console.WriteLine("Нет столбца");
            else
                Console.WriteLine($"Столбец с индексом {index} подходит");

            Console.WriteLine();

            var diffs = GetMaxMinDifferenciesBy(matrix);

            for(var i=0, i <diffs.Length; i++)
                Console.WriteLine($"Строка {i}: разность max и min {diffs}")

        }

        static bool TryInputNumber(out int number)
        {
            number = 0;
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }
            number = n;
            return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    Console.Write($"{matrix[i, j],2}");
                Console.WriteLine();
            }
        }

        static int GetIndexOfColumnWithMibimalLastElement(int[,] matrix)
        {
            var index = -1;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var isBadColumn = false;
                for(var i=0; i<matrix.GetLength(0) -1; i++)
                {
                    if (matrix[i,j] < matrix[matrix.GetLength(0) - 1, j])
                    {
                        isBadColumn = true;
                        break;
                    }
                    if (isBadColumn)
                        continue;
                    else
                    {
                        index = j;
                        break;
                    }
                }

            }
                return index;
        }

        static int[] GetMaxMinDifferenciesBy(int[,] matrix)
        {
            var result = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int min = int.MaxValue;


                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }

                    return result;
        }
    }
}    
    

