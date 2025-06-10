using System;
using Description;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MedicamentLibrary
{
    public class Medicament: IComparable<Medicament>
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

        public class Pills : Medicament
        {
            public int QualityOfPills { get; set; }

            public Pills(int articleNumber, string name, DescriptionOrNot description, string manufacturer, int qualityOfPills)
                : base(articleNumber, name, description, manufacturer)
            {
                QualityOfPills = qualityOfPills;
            }

            public override string[] GetInfo()
            {
                var info = new string[4];
                var medicamentInfo = base.GetInfo();

                info[0] = medicamentInfo[0];
                info[1] = medicamentInfo[1];
                info[2] = medicamentInfo[2];
                info[3] = $"Количество таблеток: {QualityOfPills} штук(и).";
                return info;
            }
        }

        public class Mixture : Medicament
        {
            public int VolumeMl { get; set; }

            public Mixture(int articleNumber, string name, DescriptionOrNot description, string manufacturer, int volumeMl)
                : base(articleNumber, name, description, manufacturer)
            {
                VolumeMl = volumeMl;
            }

            public override string[] GetInfo()
            {
                var info = new string[4];
                var medicamentInfo = base.GetInfo();

                info[0] = medicamentInfo[0];
                info[1] = medicamentInfo[1];
                info[2] = medicamentInfo[2];
                info[3] = $"Объем микстуры: {VolumeMl} (мл).";
                return info;
            }
        }

        public class Ointment : Medicament
        {
            public int VolumeMg { get; set; }

            public Ointment(int articleNumber, string name, DescriptionOrNot description, string manufacturer, int volumeMg)
                : base(articleNumber, name, description, manufacturer)
            {
                VolumeMg = volumeMg;
            }

            public override string[] GetInfo()
            {
                var info = new string[4];
                var medicamentInfo = base.GetInfo();

                info[0] = medicamentInfo[0];
                info[1] = medicamentInfo[1];
                info[2] = medicamentInfo[2];
                info[3] = $"Объем тубы: {VolumeMg} (мг).";
                return info;
            }
        }

        public virtual string[] GetInfo()
        {
            var info = new string[3];
            info[0] = $"{ArticleNumber} (арт.) {Name};";

            string description;
            if (Description == DescriptionOrNot.Yes)
                description = "Нужен рецепт";
            else
                description = "Без рецепта";

            info[1] = $"{description}; Производитель: {Manufacturer};";
            info[2] = $"Цена: {Price} руб.; Количество на складе: {Quality} штук(и).";
            return info;
        }

        public int CompareTo(Medicament other)
        {
            if (Name != other.Name)
                return Name.CompareTo(other.Name);
            else 
            return Price.CompareTo(other.Price);


        }
    }

    public class MedicamentArticleNumberComparer : IComparer<Medicament>
    {
        public int Compare(Medicament x, Medicament y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1; 
            if (y == null) return 1; 
            return x.ArticleNumber.CompareTo(y.ArticleNumber);
        }
    }


    public class Pharmacy : IEnumerable<Medicament>
    {
        public string Title { get; set; }
        public string Address { get; set; }
        List<Medicament> collection;

        public int Count { get => collection.Count; }
        public List<Medicament> Collection => collection;
        public Pharmacy(string title, string address, IEnumerable<Medicament> medicaments)
        {
            Title = title;
            Address = address;
            collection = new List<Medicament>();
            foreach (var medicament in medicaments)
                if (!collection.Contains(medicament))
                    collection.Add(medicament);
        }

        public IEnumerator<Medicament> GetEnumerator() => collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}