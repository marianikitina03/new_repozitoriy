using System;
using Description;
using MedicamentLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentApp
{
    internal class MedicamentApp
    {
        static void Main(string[] args)
        {
            var miramistin = new Medicament(15809195, "Мирамистин", DescriptionOrNot.No, "Инфамед");

            miramistin.Price = 471.5;
            miramistin.Quality = 3;

            string[] info = miramistin.GetInfo();
            foreach (var line in info)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();
        }
    }
}