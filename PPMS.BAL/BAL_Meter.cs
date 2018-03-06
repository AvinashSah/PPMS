using PPMS.ENTITIES;
using PPMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.BAL
{
    public class BAL_Meter
    {
        public List<Meter> GetMeterList()
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            return dAL_Meter.GetMeterList();

        }

        public List<DailyMeterReading> GetDailyMeterReading()
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            return dAL_Meter.GetDailyMeterReading();
        }
        public Fuel GetFuelByFuelID(int fuelID)
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            return dAL_Meter.GetFuelByFuelID(fuelID);

        }
        public long CreateMeter(MeterData meterData, UserOpMap userOpMap)
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            Meter meter = new Meter();
            DailyMeterReading dailyMeterReading = new DailyMeterReading();
            meter.Name = meterData.Name;
            meter.Description = meterData.Description;
            meter.FuelTypeId = meterData.FuelTypeID;
            dailyMeterReading.DayStartReading = meterData.DayStartReading;
            dailyMeterReading.DayEndReading = meterData.DayEndReading;
            return dAL_Meter.CreateMeter(meter, dailyMeterReading, userOpMap);
        }

        public long UpdateMeter(MeterData meterData, UserOpMap userOpMap)
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            Meter meter = new Meter();
            DailyMeterReading dailyMeterReading = new DailyMeterReading();
            meter.Id = meterData.Id;
            meter.Name = meterData.Name;
            meter.Description = meterData.Description;
            meter.FuelTypeId = meterData.FuelTypeID;
            dailyMeterReading.DayStartReading = meterData.DayStartReading;
            dailyMeterReading.DayEndReading = meterData.DayEndReading;
            return dAL_Meter.UpdateMeter(meter, dailyMeterReading, userOpMap);
        }
        public List<Fuel> GetFuelList()
        {
            DAL_Meter dAL_Meter = new DAL_Meter();
            return dAL_Meter.GetFuelList();

        }
    }
}
