using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;
using System.Globalization;

namespace PPMS.DAL
{
    public class DAL_Meter
    {
        public List<Meter> GetMeterList()
        {
            List<Meter> MeterList = new List<Meter>();
            using (var dbContext = new ppmsEntities())
            {
                MeterList = (from a in dbContext.Meters
                             where a.IsActive == true
                             select a).ToList();
            }
            return MeterList;
        }

        public List<DailyMeterReading> GetDailyMeterReading()
        {
            List<DailyMeterReading> dailyMeterReading = new List<DailyMeterReading>();
            DateTime today = DateTime.Now;
            using (var dbContext = new ppmsEntities())
            {
                dailyMeterReading = (from a in dbContext.DailyMeterReadings
                                     where a.IsActive == true && a.UpdatedOn <= today
                                     orderby a.UpdatedOn descending
                                     select a).ToList();
            }
            return dailyMeterReading;
        }

        public Fuel GetFuelByFuelID(int fuelID)
        {
            Fuel fuel = new Fuel();
            using (var dbContext = new ppmsEntities())
            {
                fuel = (from a in dbContext.Fuels
                        where a.IsActive == true && a.Id == fuelID
                        select a).FirstOrDefault();
            }
            return fuel;
        }
        public List<Fuel> GetFuelList()
        {
            List<Fuel> fuelList = new List<Fuel>();
            using (var dbContext = new ppmsEntities())
            {
                fuelList = (from a in dbContext.Fuels
                            where a.IsActive == true
                            select a).ToList();
            }
            return fuelList;
        }

        public long CreateMeter(Meter meter, DailyMeterReading dailyMeterReading, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Meter meterData = new Meter();
                meterData = (from a in dbContext.Meters
                             where a.IsActive == true && a.Name == meter.Name
                             select a).FirstOrDefault();
                if (meterData == null)
                {
                    //Create Meter
                    meter.IsActive = true;
                    meter.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    meter.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    meter.CreatedOn = DateTime.Now;
                    meter.UpdatedOn = DateTime.Now;
                    dbContext.Meters.Add(meter);
                    dbContext.SaveChanges();
                    int meterID = meter.Id;

                    dailyMeterReading.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    dailyMeterReading.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyMeterReading.UpdatedOn = DateTime.Now;
                    dailyMeterReading.CreatedOn = DateTime.Now;
                    dailyMeterReading.IsActive = true;
                    dailyMeterReading.MeterId = meterID;

                    dbContext.DailyMeterReadings.Add(dailyMeterReading);
                    dbContext.SaveChanges();
                    return dailyMeterReading.Id;
                }
                else
                {
                    throw new Exception("Meter already exist !");
                }
            }
        }

        public long UpdateMeter(Meter meter, DailyMeterReading dailyMeterReading, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Meter meterData = new Meter();
                meterData = (from a in dbContext.Meters
                             where a.IsActive == true && a.Id == meter.Id
                             select a).FirstOrDefault();
                meterData.Description = meter.Description;
                meterData.FuelTypeId = meter.FuelTypeId;
                meterData.UpdatedOn = DateTime.Now;
                meterData.Updatedby = Convert.ToInt64(userOpMap.UserID);
                dbContext.SaveChanges();

                DateTime today = DateTime.Now;
                DailyMeterReading dailyMeterReadingData = new DailyMeterReading();
                dailyMeterReadingData = (from a in dbContext.DailyMeterReadings
                                         where (a.UpdatedOn.Value.Day == today.Day &&
                                         a.UpdatedOn.Value.Month == today.Month &&
                                         a.UpdatedOn.Value.Year == today.Year && a.MeterId == meter.Id && a.IsActive == true)
                                         select a).FirstOrDefault();
                if (dailyMeterReadingData == null)
                {
                    dailyMeterReading.MeterId = meter.Id;
                    dailyMeterReading.DayStartReading = dailyMeterReading.DayStartReading;
                    dailyMeterReading.DayEndReading = dailyMeterReading.DayEndReading;
                    dailyMeterReading.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    dailyMeterReading.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyMeterReading.UpdatedOn = DateTime.Now;
                    dailyMeterReading.CreatedOn = DateTime.Now;
                    dailyMeterReading.IsActive = true;

                    dbContext.DailyMeterReadings.Add(dailyMeterReading);
                    dbContext.SaveChanges();//this generates the Id for DailyMeterReadings
                }
                else
                {
                    dailyMeterReadingData.DayStartReading = dailyMeterReading.DayStartReading;
                    dailyMeterReadingData.DayEndReading = dailyMeterReading.DayEndReading;
                    dailyMeterReadingData.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyMeterReadingData.UpdatedOn = DateTime.Now;
                    dbContext.SaveChanges();//this generates the Id for DailyMeterReadings
                }
                return dailyMeterReading.Id;
            }
        }
    }
}
