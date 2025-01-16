using Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentLibrary
{
    public class Medicament
    {
        public int ArticleNumber { get; }
        public string Title { get; set; }
        public DescriptionOrNot Description { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int Quality { get; set; }

        public Medicament(int articleNumber, string title, DescriptionOrNot description, string manufacturer)
        {
            ArticleNumber = articleNumber;
            Title = title;
            Description = description;
            Manufacturer = manufacturer;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[5];
            info[0] = $"{ArticleNumber} {Title}";

            string description;
            if (Description == DescriptionOrNot.Yes)
                description = "Нужен рецепт";
            else
                description = "Без рецепта";

            info[1] = $"{Description}"; // Здесь было Description, вероятно, нужно description
            info[2] = $"Производитель: {Manufacturer}";
            info[3] = $"Цена: {Price}";
            info[4] = $"Количество на складе:{Quality}";
            return info;
        }
    }
}