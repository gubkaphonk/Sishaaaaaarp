using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement;

public class GasHeatingApartment : Apartment
{
    public double LastGasMeterReading { get; set; }

    public GasHeatingApartment(int apartmentNumber, string responsibleOwner, string ownerPhoneNumber,
                             double lastColdWaterMeterReading, double lastHotWaterMeterReading,
                             ElectricityMeterType electricityMeterType, double[] lastElectricityMeterReadings,
                             double lastGasMeterReading)
        : base(apartmentNumber, responsibleOwner, ownerPhoneNumber, lastColdWaterMeterReading,
              lastHotWaterMeterReading, electricityMeterType, lastElectricityMeterReadings)
    {
        LastGasMeterReading = lastGasMeterReading;
    }

    public override string[] GetInfo()
    {
        var info = new string[8];
        info[0] = $"Номер квартиры: {ApartmentNumber}";
        info[1] = $"Ответственный собственник: {ResponsibleOwner}";
        info[2] = $"Телефонный номер собственника: {OwnerPhoneNumber}";
        info[3] = $"Последние показания счетчика ХВС: {LastColdWaterMeterReading}";
        info[4] = $"Последние показания счетчика ГВС: {LastHotWaterMeterReading}";
        info[5] = $"Тип электросчетчика: {ElectricityMeterType}";
        info[6] = $"Последние показания электросчетчика: {string.Join(", ", LastElectricityMeterReadings)}";
        info[7] = $"Последние показания счетчика газа: {LastGasMeterReading}";
        return info;
    }
}