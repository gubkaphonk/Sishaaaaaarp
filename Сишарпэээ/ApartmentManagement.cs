using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement
{
    public enum ElectricityMeterType
    {
        SingleRate,
        DoubleRate
    }

    public class Apartment : IComparable<Apartment>
    {
        public int ApartmentNumber { get; }
        public string ResponsibleOwner { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public double LastColdWaterMeterReading { get; set; }
        public double LastHotWaterMeterReading { get; set; }
        public ElectricityMeterType ElectricityMeterType { get; set; }
        public double[] LastElectricityMeterReadings { get; set; }

        public Apartment(int apartmentNumber, string responsibleOwner, string ownerPhoneNumber,
                         double lastColdWaterMeterReading, double lastHotWaterMeterReading,
                         ElectricityMeterType electricityMeterType, double[] lastElectricityMeterReadings)
        {
            ApartmentNumber = apartmentNumber;
            ResponsibleOwner = responsibleOwner;
            OwnerPhoneNumber = ownerPhoneNumber;
            LastColdWaterMeterReading = lastColdWaterMeterReading;
            LastHotWaterMeterReading = lastHotWaterMeterReading;
            ElectricityMeterType = electricityMeterType;
            LastElectricityMeterReadings = lastElectricityMeterReadings;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[7];
            info[0] = $"Номер квартиры: {ApartmentNumber}";
            info[1] = $"Cобственник: {ResponsibleOwner}";
            info[2] = $"Телефонный номер собственника: {OwnerPhoneNumber}";
            info[3] = $"Последние показания ХВС: {LastColdWaterMeterReading}";
            info[4] = $"Последние показания ГВС: {LastHotWaterMeterReading}";
            info[5] = $"Тип электросчетчика: {ElectricityMeterType}";
            info[6] = $"Последние показания электросчетчика: {string.Join(", ", LastElectricityMeterReadings)}";
            return info;
        }
        public int CompareTo(Apartment? other)
        {
            if (other is null)
                return 1;

            return this.ApartmentNumber.CompareTo(other.ApartmentNumber);
        }
    }

    public class Building : IEnumerable<Apartment>
    {
        public string Address { get; }
        private List<Apartment> apartments;

        public int ApartmentCount => apartments.Count;

        public Building(string address, IEnumerable<Apartment> apartments)
        {
            Address = address;
            this.apartments = new List<Apartment>(apartments);
        }

        public IEnumerator<Apartment> GetEnumerator() => apartments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}