using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;
using System.Globalization;

namespace PPMS.DAL
{
    public class DAL_Tanker
    {
        public List<Tanker> GetTankerList()
        {
            List<Tanker> tankerList = new List<Tanker>();
            using (var dbContext = new ppmsEntities())
            {
                tankerList = (from a in dbContext.Tankers
                              where a.IsActive == true
                              select a).ToList();
            }
            return tankerList;
        }

        public List<DailyTankerReading> GetDailyTankerReading()
        {
            List<DailyTankerReading> dailyDailyTankerReading = new List<DailyTankerReading>();
            DateTime today = DateTime.Now;
            using (var dbContext = new ppmsEntities())
            {
                dailyDailyTankerReading = (from a in dbContext.DailyTankerReadings
                                           where a.IsActive == true && a.Date <= today
                                           orderby a.Date descending
                                           select a).ToList();
            }
            return dailyDailyTankerReading;
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

        public DailyTankerReading GetDailyTankerReadingByTankerID(int tankerID)
        {
            DailyTankerReading dailyDailyTankerReading = new DailyTankerReading();
            using (var dbContext = new ppmsEntities())
            {
                dailyDailyTankerReading = (from a in dbContext.DailyTankerReadings
                                           where a.IsActive == true && a.TankerId == tankerID
                                           select a).FirstOrDefault();
            }
            return dailyDailyTankerReading;
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
        public Tanker GetTankerByID(string tankerID)
        {
            Tanker tanker = new Tanker();
            int tankerId = Convert.ToInt32(tankerID);
            using (var dbContext = new ppmsEntities())
            {
                tanker = (from a in dbContext.Tankers
                          where a.IsActive == true && a.Id == tankerId
                          select a).FirstOrDefault();
            }
            return tanker;
        }
        public long CreateTanker(Tanker tanker, DailyTankerReading dailyTankerReading, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Tanker tankerData = new Tanker();
                tankerData = (from a in dbContext.Tankers
                              where a.IsActive == true && a.Name == tanker.Name
                              select a).FirstOrDefault();
                if (tankerData == null)
                {
                    //Create Tanker
                    tanker.IsActive = true;
                    tanker.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    tanker.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    tanker.CreatedOn = DateTime.Now;
                    tanker.UpdatedOn = DateTime.Now;
                    dbContext.Tankers.Add(tanker);
                    dbContext.SaveChanges();
                    int tankerID = tanker.Id;

                    dailyTankerReading.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    dailyTankerReading.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyTankerReading.UpdatedOn = DateTime.Now;
                    dailyTankerReading.CreatedOn = DateTime.Now;
                    dailyTankerReading.Date = DateTime.Now;
                    dailyTankerReading.IsActive = true;
                    dailyTankerReading.TankerId = tankerID;

                    dbContext.DailyTankerReadings.Add(dailyTankerReading);
                    dbContext.SaveChanges();
                    return dailyTankerReading.Id;
                }
                else
                {
                    throw new Exception("Tanker already exist !");
                }
            }
        }

        public long UpdateTanker(Tanker tanker, DailyTankerReading dailyTankerReading, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Tanker tankerData = new Tanker();
                tankerData = (from a in dbContext.Tankers
                              where a.IsActive == true && a.Id == tanker.Id
                              select a).FirstOrDefault();
                tankerData.Description = tanker.Description;
                tankerData.Size = tanker.Size;
                tankerData.FuelTypeId = tanker.FuelTypeId;
                dbContext.SaveChanges();

                DateTime today = DateTime.Now;
                DailyTankerReading dailyTankerReadingData = new DailyTankerReading();
                dailyTankerReadingData = (from a in dbContext.DailyTankerReadings
                                          where a.Date >= today && a.TankerId == tanker.Id && a.IsActive == true
                                          select a).FirstOrDefault();
                if (dailyTankerReadingData == null)
                {
                    dailyTankerReading.TankerId = tanker.Id;
                    dailyTankerReading.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    dailyTankerReading.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyTankerReading.UpdatedOn = DateTime.Now;
                    dailyTankerReading.CreatedOn = DateTime.Now;
                    dailyTankerReading.Date = DateTime.Now;
                    dailyTankerReading.IsActive = true;

                    dbContext.DailyTankerReadings.Add(dailyTankerReading);
                    dbContext.SaveChanges();//this generates the Id for DailyTankerReadings
                }
                else
                {
                    dailyTankerReadingData.DailyStartReading = dailyTankerReading.DailyStartReading;
                    dailyTankerReadingData.DailyEndReading = dailyTankerReading.DailyEndReading;
                    dailyTankerReadingData.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyTankerReadingData.UpdatedOn = DateTime.Now;
                    dbContext.SaveChanges();//this generates the Id for DailyTankerReadings
                }
                return dailyTankerReading.Id;
            }
        }
    }
}
