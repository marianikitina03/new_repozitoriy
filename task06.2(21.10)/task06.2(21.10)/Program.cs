using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task06._2_21._10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "кинематограф";
            Console.WriteLine($"Из слова \"{s}\" получили");

            var word1 =
               s.Remove(0, 5)
               .Remove(0, 3) +
                ReverseString(s.Remove(8, 4))
            .Remove(1, 2)
            .Remove(2) +
            ReverseString(s.Remove(6, 6))
            .Remove(1) +
            ReverseString(s.Remove(3, 9)) 
            .Remove(1);

            var word2 =
                ReverseString(s.Remove(5, 7))
                .Remove(2) +
                ReverseString(s.Remove(0, 6))
                .Remove(0,5) +
            ReverseString(s.Remove(0, 6))
                .Remove(0, 2)
                .Remove(3)
                .Remove(1, 1);


            Console.WriteLine(word1);
            Console.WriteLine(word2);  


            Console.ReadKey();
        }
        static string ReverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
