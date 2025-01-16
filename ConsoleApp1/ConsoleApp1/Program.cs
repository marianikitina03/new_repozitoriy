using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число m (от 5 до 20)");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите целое число n (от 5 до 20)");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            if (m < 5 || m > 20 || n < 5 || n > 20)
            {
                Console.WriteLine("Числа не удовлетворяют неравенству 5 <= m,n <= 20");
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

            var violations = IsArrayOrdered(matrix);
            var oddSums = CalculateOddInColumns(matrix);

            if (violations.Count > 0)
            {
                var randomViolation = violations[rnd.Next(violations.Count)];
                Console.WriteLine($"В строке массива {randomViolation.Item1} числа не упорядочены по возрастанию, так как элемент [{randomViolation.Item1}, {randomViolation.Item2}] > [{randomViolation.Item1}, {randomViolation.Item2 + 1}]");
            }
            else
            {
                Console.WriteLine("Все строки упорядочены по возрастанию.");
            }
            Console.WriteLine() ;

            for (int j = 0; j < oddSums.Length; j++)
            {
                Console.WriteLine($"В столбце [{j}] сумма нечетных элементов равна {oddSums[j]}");
            }
            Console.ReadKey();
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
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],2} ");

                Console.WriteLine();
            }
        }

        static List<(int, int)> IsArrayOrdered(int[,] matrix)
        {
            var violations = new List<(int, int)>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] > matrix[i, j + 1])
                    {
                        violations.Add((i, j)); 
                    }
                }
            }
            return violations;
        }

        static int[] CalculateOddInColumns(int[,] matrix)
        {
            int[] sums = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] % 2 != 0) 
                    {
                        sums[j] += matrix[i, j];
                    }
                }
            }
            return sums;
        }

    }

}

            
        
           
    
    

