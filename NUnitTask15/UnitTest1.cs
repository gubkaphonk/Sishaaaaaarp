using NUnit.Framework;
using System;
using System.Linq;
using ApartmentManagement;

namespace NUnitTask15
{
    [TestFixture]
    public class ApartmentTests
    {
        [Test]
        public void CompareTo_ShouldSortApartmentsByNumber()
        {
            var apt1 = new GasHeatingApartment(101, "Owner1", "111", 100, 50, ElectricityMeterType.SingleRate, new double[] { 1000 }, 200);
            var apt2 = new GasHeatingApartment(102, "Owner2", "222", 200, 60, ElectricityMeterType.DoubleRate, new double[] { 2000, 1500 }, 300);
            var apt3 = new CentralHeatingApartment(103, "Owner3", "333", 300, 70, ElectricityMeterType.SingleRate, new double[] { 3000 }, 40);

            Assert.That(apt1.CompareTo(apt2), Is.LessThan(0));
            Assert.That(apt2.CompareTo(apt3), Is.LessThan(0));
            Assert.That(apt1.CompareTo(apt3), Is.LessThan(0));
            Assert.That(apt1.CompareTo(apt1), Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class BuildingTests
    {
        private Building building;
        private Apartment[] testApartments;

        [SetUp]
        public void Setup()
        {
            testApartments = new Apartment[]
            {
                new GasHeatingApartment(101, "Owner1", "111", 100, 50, ElectricityMeterType.SingleRate, new double[] { 1000 }, 200),
                new CentralHeatingApartment(102, "Owner2", "222", 200, 60, ElectricityMeterType.DoubleRate, new double[] { 2000, 1500 }, 40),
                new GasHeatingApartment(103, "Owner3", "333", 300, 70, ElectricityMeterType.SingleRate, new double[] { 3000 }, 200)
            };

            building = new Building("ул. Готвальда, д. 14", testApartments);
        }

        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            Assert.That(building.Address, Is.EqualTo("ул. Готвальда, д. 14"));
            Assert.That(building.ApartmentCount, Is.EqualTo(3));
        }

        [Test]
        public void Enumerable_ShouldReturnAllApartments()
        {
            int i = 0;
            foreach (var apartment in building)
            {
                Assert.That(apartment, Is.SameAs(testApartments[i]));
                i++;
            }
            Assert.That(i, Is.EqualTo(3));
        }

        [Test]
        public void Apartments_ShouldBeSortable()
        {
            var reversedApartments = testApartments.Reverse().ToArray();
            var buildingWithReversed = new Building("ул. Готвальда, д. 14", reversedApartments);

            var sortedApartments = buildingWithReversed.OrderBy(a => a).ToArray();
            Assert.That(sortedApartments[0].ApartmentNumber, Is.EqualTo(101));
            Assert.That(sortedApartments[1].ApartmentNumber, Is.EqualTo(102));
            Assert.That(sortedApartments[2].ApartmentNumber, Is.EqualTo(103));
        }
    }
}