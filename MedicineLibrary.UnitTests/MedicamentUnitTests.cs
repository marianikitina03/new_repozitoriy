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

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That(info[0], Is.EqualTo("15809195 (арт.) Мирамистин"));
            Assert.That(info[1], Is.EqualTo("Без рецепта"));
            Assert.That(info[2], Is.EqualTo("Производитель: Инфамед"));
            Assert.That(info[3], Is.EqualTo("Цена: 471,5 руб."));
            Assert.That(info[4], Is.EqualTo("Количество на складе: 3 штук(и)"));
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