using NUnit.Framework;
using System;
using ApartmentManagement;

namespace Task13_Test
{
    [TestFixture]
    public class ApartmentTests
    {
        [Test]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            int apartmentNumber = 104;
            string responsibleOwner = "Халзанов Дмитрий Чингизович";
            string ownerPhoneNumber = "+79122866335";
            double lastColdWaterMeterReading = 123.45;
            double lastHotWaterMeterReading = 67.89;
            ElectricityMeterType electricityMeterType = ElectricityMeterType.DoubleRate;
            double[] lastElectricityMeterReadings = new double[] { 100.1, 200.2 };

            // Act
            var apartment = new Apartment(
                apartmentNumber,
                responsibleOwner,
                ownerPhoneNumber,
                lastColdWaterMeterReading,
                lastHotWaterMeterReading,
                electricityMeterType,
                lastElectricityMeterReadings
            );

            // Assert
            Assert.That(apartment.ApartmentNumber, Is.EqualTo(apartmentNumber));
            Assert.That(apartment.ResponsibleOwner, Is.EqualTo(responsibleOwner));
            Assert.That(apartment.OwnerPhoneNumber, Is.EqualTo(ownerPhoneNumber));
            Assert.That(apartment.LastColdWaterMeterReading, Is.EqualTo(lastColdWaterMeterReading));
            Assert.That(apartment.LastHotWaterMeterReading, Is.EqualTo(lastHotWaterMeterReading));
            Assert.That(apartment.ElectricityMeterType, Is.EqualTo(electricityMeterType));
            Assert.That(apartment.LastElectricityMeterReadings, Is.EqualTo(lastElectricityMeterReadings));
        }

        [Test]
        public void GetInfo_ReturnsCorrectInformation()
        {
            // Arrange
            var apartment = new Apartment(
                apartmentNumber: 104,
                responsibleOwner: "Халзанов Дмитрий Чингизович",
                ownerPhoneNumber: "+79122866335",
                lastColdWaterMeterReading: 123.45,
                lastHotWaterMeterReading: 67.89,
                electricityMeterType: ElectricityMeterType.DoubleRate,
                lastElectricityMeterReadings: new double[] { 100.1, 200.2 }
            );

            // Act
            var info = apartment.GetInfo();

            // Assert
            Assert.That(info.Length, Is.EqualTo(7));
            Assert.That(info[0], Is.EqualTo($"Номер квартиры: {apartment.ApartmentNumber}"));
            Assert.That(info[1], Is.EqualTo($"Собственник: {apartment.ResponsibleOwner}"));
            Assert.That(info[2], Is.EqualTo($"Телефонный номер собственника: {apartment.OwnerPhoneNumber}"));
            Assert.That(info[3], Is.EqualTo($"Последние показания ХВС: {apartment.LastColdWaterMeterReading}"));
            Assert.That(info[4], Is.EqualTo($"Последние показания ГВС: {apartment.LastHotWaterMeterReading}"));
            Assert.That(info[5], Is.EqualTo($"Тип электросчетчика: {apartment.ElectricityMeterType}"));
            Assert.That(info[6], Is.EqualTo($"Последние показания электросчетчика: {string.Join(", ", apartment.LastElectricityMeterReadings)}"));
        }
    }
}