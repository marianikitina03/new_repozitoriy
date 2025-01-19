using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k;
            if (!TryInputNumber("Введите количество студентов в каждой группе (k)", out k))
            {
                Console.ReadKey();
                return;
            }

            if (k < 1)
            {
                Console.WriteLine("Количество студентов должно быть больше нуля");
                Console.ReadKey();
                return;
            }

            double[] agesGroup1 = new double[k];
            double[] agesGroup2 = new double[k];

            Console.WriteLine("Введите возраст студентов первой группы:");
            for (int i = 0; i < k; i++)
            {
                if (!TryInputDouble($"Возраст студента {i + 1}:", out agesGroup1[i]))
                {
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Введите возраст студентов второй группы:");
            for (int i = 0; i < k; i++)
            {
                if (!TryInputDouble($"Возраст студента {i + 1}:", out agesGroup2[i]))
                {
                    Console.ReadKey();
                    return;
                }
            }

            double averageAgeGroup1 = CalculateAverage(agesGroup1);
            double averageAgeGroup2 = CalculateAverage(agesGroup2);

            Console.WriteLine($"Средний возраст студентов первой группы: {averageAgeGroup1}");
            Console.WriteLine($"Средний возраст студентов второй группы: {averageAgeGroup2}");

            Console.ReadKey();
        }

        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста введите целое число.");
                return false;
            }

            return true;
        }

        static bool TryInputDouble(string message, out double number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!double.TryParse(input, out number))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста введите число (возможны нецелые значения).");
                return false;
            }

            return true;
        }

        static double CalculateAverage(double[] ages)
        {
            double sum = 0;
            foreach (var age in ages)
            {
                sum += age;
            }
            return sum / ages.Length;
        }
    }

}
