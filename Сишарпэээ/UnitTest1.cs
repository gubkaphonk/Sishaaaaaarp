using NUnit.Framework;
using System;
using ApartmentManagement;

namespace ApartmentManagement.Tests
{
    [TestFixture]
    public class ApartmentTests
    {
        [Test]
        public void CentralHeatingApartment_GetInfo_ReturnsCorrectInfo()
        {
            var apartment = new CentralHeatingApartment(
                apartmentNumber: 104,
                responsibleOwner: "Халзанов Дмитрий Чингизович",
                ownerPhoneNumber: "+79122877334",
                lastColdWaterMeterReading: 100.5,
                lastHotWaterMeterReading: 50.3,
                electricityMeterType: ElectricityMeterType.DoubleRate,
                lastElectricityMeterReadings: new double[] { 150.0, 250.0 },
                area: 75.5
            );

            var info = apartment.GetInfo();

            Assert.That(info.Length, Is.EqualTo(8));
            Assert.That(info[0], Is.EqualTo("Номер квартиры: 104"));
            Assert.That(info[7], Is.EqualTo("Площадь квартиры: 75.5 кв.м (центральное отопление)"));
        }

        [Test]
        public void GasHeatingApartment_GetInfo_ReturnsCorrectInfo()
        {
            var apartment = new GasHeatingApartment(
                apartmentNumber: 104,
                responsibleOwner: "Халзанов Дмитрий Чингизович",
                ownerPhoneNumber: "+79122877334",
                lastColdWaterMeterReading: 120.7,
                lastHotWaterMeterReading: 60.2,
                electricityMeterType: ElectricityMeterType.SingleRate,
                lastElectricityMeterReadings: new double[] { 200.0 },
                lastGasMeterReading: 350.8
            );

            var info = apartment.GetInfo();

            Assert.That(info.Length, Is.EqualTo(8));
            Assert.That(info[0], Is.EqualTo("Номер квартиры: 104"));
            Assert.That(info[7], Is.EqualTo("Последние показания счетчика газа: 350.8"));
        }

        [Test]
        public void Apartment_GetInfo_ReturnsBaseInfo()
        {
            var apartment = new Apartment(
                apartmentNumber: 104,
                responsibleOwner: "Халзанов Дмитрий Чингизович",
                ownerPhoneNumber: "+79122877334",
                lastColdWaterMeterReading: 90.3,
                lastHotWaterMeterReading: 45.1,
                electricityMeterType: ElectricityMeterType.DoubleRate,
                lastElectricityMeterReadings: new double[] { 180.0, 280.0 }
            );

            var info = apartment.GetInfo();

            Assert.That(info.Length, Is.EqualTo(7));
            Assert.That(info[0], Is.EqualTo("Номер квартиры: 104"));
            Assert.That(info[3], Is.EqualTo("Последние показания счетчика ХВС: 90.3"));
        }
    }
}