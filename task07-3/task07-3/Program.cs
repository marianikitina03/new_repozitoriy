using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace task07_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белой ладьи");
            WhiteAndBlack(out x1, out y1);

            Console.WriteLine("Введите позицию черного слона");
            var x2 = WhiteAndBlack(out x1, out int y2);

            if (x1 == x2 && y1 == y2)
                Console.WriteLine("Фигуры стоят на одной клетке");
            else if (x1 == x2 || y1 == y2)
                Console.WriteLine("Фигуры под боем друг друга");
            else Console.WriteLine("Сделайте ход белой ладьей");
            Console.ReadKey();
        }

      

        static void DecodePosition(string position, out int x, out int y)
        {
            x = int.Parse(position[1].ToString());
            y = (int)position[0] - 0x60;
        }

        static int WhiteAndBlack(string numberName, out int PawnColumn)
        {
            var PawnPosition = Console.ReadLine();
            int PawnRow;
            DecodePosition(PawnPosition, out PawnRow, out PawnColumn);
       
            return PawnRow;
        }
    }
}
