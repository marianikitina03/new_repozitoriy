using Description;
using MedicamentLibrary;

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
}

