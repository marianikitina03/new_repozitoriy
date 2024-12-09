using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Person mike;
            mike = new Person();
            mike.Name = "Михаил";
            mike.LastName = "Иванов";
            mike.SetAge(20);

  
            var kate = new Person()
            {
                Name = "Екатерина",
                LastName = "Петрова",
                
            };
            kate.SetAge(19);

            mike.PrintInfo();
            kate.PrintInfo();
            Console.ReadKey();
        }
        public class Person
        {
            public string Name;
            public string LastName;
            private int age;

            public void SetAge(int age)
            {
                if (age < 0 || age > 150)
                    throw new ArgumentException();
                this.age = age;
            }
            public void PrintInfo()
            {
                Console.WriteLine($"{Name} {LastName}, возраст: {Age}");
            }
        }
       

    }
    
}


