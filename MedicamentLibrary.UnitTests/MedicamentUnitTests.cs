using Description;
using MedicamentLibrary;
using NUnit.Framework;

namespace MedicamentLibrary.UnitTests
{
    [TestFixture]
    public class MedicamentUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var miramistin = CreateTestMedicament();

            Assert.That(miramistin.ArticleNumber, Is.EqualTo(15809195));
            Assert.That(miramistin.Name, Is.EqualTo("Мирамистин"));
            Assert.That(miramistin.Description, Is.EqualTo(DescriptionOrNot.No));
            Assert.That(miramistin.Manufacturer, Is.EqualTo("Инфамед"));
            Assert.That(miramistin.Price, Is.EqualTo(471.5));
            Assert.That(miramistin.Quality, Is.EqualTo(3));

        }

        [Test]
        public void GetInfoTest()
        {
            var miramistin = CreateTestMedicament();
            var info = miramistin.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("15809195 (арт.) Мирамистин;"));
            Assert.That($"Без рецепта; Производитель: Инфамед;", Is.EqualTo(info[1]));
            Assert.That($"Цена: 471,5 руб.; Количество на складе: 3 штук(и).", Is.EqualTo(info[2]));
        }

        private Medicament CreateTestMedicament()
        {
            var miramistin = new Medicament(15809195, "Мирамистин", DescriptionOrNot.No, "Инфамед");
            miramistin.Price = 471.5;
            miramistin.Quality = 3;
            return miramistin;
        }

       
    }

    [TestFixture]
    public class PillsUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var noshpa = GetTestPills();

            Assert.That(noshpa.QualityOfPills, Is.EqualTo(24));

        }

        [Test]
        public void GetInfo_Pills_FourStringInfo()
        {
            var noshpa = GetTestPills();
            var lines = new[]
            {
                "12377890 (арт.) Ношпа;",
                "Без рецепта; Производитель: Санофи;",
                "Цена: 143,7 руб.; Количество на складе: 57 штук(и).",
                "Количество таблеток: 24 штук(и)."
            };

            var info = noshpa.GetInfo();

            Assert.That(info.Length,Is.EqualTo(4));

            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private Medicament.Pills GetTestPills()
        {
            var noshpa = new Medicament.Pills(12377890, "Ношпа", DescriptionOrNot.No, "Санофи",24);
            noshpa.Price = 143.7;
            noshpa.Quality = 57;
            return noshpa;
        }
    }

    [TestFixture]
    public class MixtureUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var bronhipret = GetTestMixture();

            Assert.That(bronhipret.VolumeMl, Is.EqualTo(50));

        }

        [Test]
        public void GetInfo_Mixture_FourStringInfo()
        {
            var bronhipret = GetTestMixture();
            var lines = new[]
            {
                "38548022 (арт.) Бронхипрет;",
                "Без рецепта; Производитель: Бионорика;",
                "Цена: 301,4 руб.; Количество на складе: 27 штук(и).",
                "Объем микстуры: 50 (мл)."
            };

            var info = bronhipret.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));

            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private Medicament.Mixture GetTestMixture()
        {
            var bronhipret = new Medicament.Mixture(38548022, "Бронхипрет", DescriptionOrNot.No, "Бионорика", 50);
            bronhipret.Price = 301.4;
            bronhipret.Quality = 27;
            return bronhipret;
        }
    }

    [TestFixture]
    public class OintmentUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var ophlomelid = GetTestOintment();

            Assert.That(ophlomelid.VolumeMg, Is.EqualTo(500));

        }

        [Test]
        public void GetInfo_Ointment_FourStringInfo()
        {
            var ophlomelid = GetTestOintment();
            var lines = new[]
            {
                "12193131 (арт.) Офломелид;",
                "Нужен рецепт; Производитель: Синтез;",
                "Цена: 325,3 руб.; Количество на складе: 1 штук(и).",
                "Объем тубы: 500 (мг)."
            };

            var info = ophlomelid.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));

            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private Medicament.Ointment GetTestOintment()
        {
            var ophlomelid = new Medicament.Ointment(12193131, "Офломелид", DescriptionOrNot.Yes, "Синтез", 500);
            ophlomelid.Price = 325.3;
            ophlomelid.Quality = 1;
            return ophlomelid;
        }
    }
}