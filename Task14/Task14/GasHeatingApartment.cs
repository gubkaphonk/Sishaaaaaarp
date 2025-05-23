using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement
{
    public class GasHeatingApartment : Apartment
    {
        public double LastGasMeterReading { get; set; } // Последние показания счетчика газа

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
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];

            Array.Copy(baseInfo, info, baseInfo.Length);
            info[baseInfo.Length] = $"Последние показания счетчика газа: {LastGasMeterReading}";

            return info;
        }
    }
}