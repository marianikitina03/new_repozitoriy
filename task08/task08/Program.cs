﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task08
{
    
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите значение аргумента функции");
                var x = double.Parse(Console.ReadLine());

                Console.WriteLine($"f({x}) = {MyFunction(x)}");

                Console.ReadKey();
            }

            static double MyFunction(double x)
            {
                if (x < -3)
                    return 0;
                else if (x > -1)
                    return 2;

                return 1;
            }
        }
    }


