using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task05_14._10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = CalculateX();
            Console.WriteLine("x = " + Math.Round(x,3)); 
            Console.ReadKey();
        }
        static double SR(double value)
        { 
            return Math.Sqrt(value); 
        }

        static double Tg2(double value)
        {
            return Math.Pow(Math.Tan(value),2);
        }
        static double CalculateX()
        {
            double first = SR((1 + Tg2(2)) / 3) ; 
            double second = SR((5 + Tg2(3)) / 8) ;
            double third = SR((1 + Tg2(5)) / 6);
            return first + second + third;
        }
    }
}
