using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку на русском языке");
            string str;

            while (true)
            {
                str = Console.ReadLine().ToLower();

                char[] vowels = { 'а', 'о', 'е', 'у', 'и', 'я', 'ё', 'ю', 'ы', 'э' };
                int vowelCount = 0;

                int aCount = 0;
                int oCount = 0;
                int eCount = 0;
                int uCount = 0;
                int iCount = 0;
                int yaCount = 0;
                int yoCount = 0;
                int yuCount = 0;
                int yCount = 0;
                int ehCount = 0;

                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Вы ничего не ввели. Попробуйте еще раз.");
                    continue;
                }

                bool isValid = true;

                foreach (char c in str)
                {
                    if (!('а' <= c && c <= 'я' || 'А' <= c && c <= 'Я' || c == 'ё' || c == 'Ё' || char.IsWhiteSpace(c) && str.Any(char.IsLetter)))
                    {
                        isValid = false;
                        break;
                    }

                    if (isValid == true && vowels.Contains(c))
                    {
                        vowelCount++;
                        switch (c)
                        {
                            case 'а': aCount++; break;
                            case 'о': oCount++; break;
                            case 'е': eCount++; break;
                            case 'у': uCount++; break;
                            case 'и': iCount++; break;
                            case 'я': yaCount++; break;
                            case 'ё': yoCount++; break;
                            case 'ю': yuCount++; break;
                            case 'ы': yCount++; break;
                            case 'э': ehCount++; break;
                        }
                    }
                }

                if (isValid == false)
                {
                    Console.WriteLine("В строке должны быть только русские буквы. Попробуйте еще раз.");
                    continue;
                }

                Console.WriteLine();
                Console.WriteLine("Количество каждой гласной в строке:");
                Console.WriteLine($"а: {aCount}");
                Console.WriteLine($"е: {eCount}");
                Console.WriteLine($"ё: {yoCount}");
                Console.WriteLine($"и: {iCount}");
                Console.WriteLine($"о: {oCount}");
                Console.WriteLine($"у: {uCount}");
                Console.WriteLine($"ы: {yCount}");
                Console.WriteLine($"э: {ehCount}");
                Console.WriteLine($"ю: {yuCount}");
                Console.WriteLine($"я: {yaCount}");
                Console.WriteLine($"Общее количество гласных: {vowelCount}");
                Console.ReadKey();

                break;
            }
        }
    }
}
