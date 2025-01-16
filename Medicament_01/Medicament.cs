using System;
using Description;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentLibrary
{
    public class Medicament
    {
        public int ArticleNumber { get; }
        public string Name { get; set; }
        public DescriptionOrNot Description { get; set; }
        public string Manufacturer;
        public double Price;
        public int Quality;

        public Medicament(int articleNumber, string name, DescriptionOrNot description, string manufacturer)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Manufacturer = manufacturer;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[5];
            info[0] = $"{ArticleNumber} (арт.) {Name}";

            string description;
            if (Description == DescriptionOrNot.Yes)
                description = "Нужен рецепт";
            else
                description = "Без рецепта";

            info[1] = $"{description}";
            info[2] = $"Производитель: {Manufacturer}";
            info[3] = $"Цена: {Price} руб.";
            info[4] = $"Количество на складе: {Quality} штук(и)";
            return info;
        }
    }
}