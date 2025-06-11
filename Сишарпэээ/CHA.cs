using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement;

namespace ApartmentManagement
{
    public class CentralHeatingApartment : Apartment
    {
        public double Area { get; set; }

        public CentralHeatingApartment(int apartmentNumber, string responsibleOwner, string ownerPhoneNumber,
                                     double lastColdWaterMeterReading, double lastHotWaterMeterReading,
                                     ElectricityMeterType electricityMeterType, double[] lastElectricityMeterReadings,
                                     double area)
            : base(apartmentNumber, responsibleOwner, ownerPhoneNumber, lastColdWaterMeterReading,
                  lastHotWaterMeterReading, electricityMeterType, lastElectricityMeterReadings)
        {
            Area = area;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];

            Array.Copy(baseInfo, info, baseInfo.Length);
            info[baseInfo.Length] = $"Площадь квартиры: {Area} кв.м (центральное отопление)";

            return info;
        }
    }
}