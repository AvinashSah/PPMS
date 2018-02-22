using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;
using PPMS.DAL;

namespace PPMS.BAL
{
    public class BAL_Tanker
    {
        public List<Tanker> GetTankerList()
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            return dAL_Tanker.GetTankerList();
        }

        public List<DailyTankerReading> GetDailyTankerReading()
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            return dAL_Tanker.GetDailyTankerReading();
        }

        public Fuel GetFuelByFuelID(int fuelID)
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            return dAL_Tanker.GetFuelByFuelID(fuelID);

        }

        public DailyTankerReading GetDailyTankerReadingByTankerID(int tankerID)
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            return dAL_Tanker.GetDailyTankerReadingByTankerID(tankerID);

        }
        public List<Fuel> GetFuelList()
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            return dAL_Tanker.GetFuelList();

        }
        public Tanker GetTankerByID(string tankerID)
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            return dAL_Tanker.GetTankerByID(tankerID);
        }
        public long CreateTanker(TankerData tankerData, UserOpMap userOpMap)
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            Tanker tanker = new Tanker();
            DailyTankerReading dailyTankerReading = new DailyTankerReading();
            tanker.Name = tankerData.Name;
            tanker.Size = tankerData.Size;
            tanker.Description = tankerData.Description;
            tanker.FuelTypeId = tankerData.FuelTypeID;
            dailyTankerReading.DailyStartReading = tankerData.DayStartReading;
            dailyTankerReading.DailyEndReading = tankerData.DayEndReading;
            return dAL_Tanker.CreateTanker(tanker, dailyTankerReading, userOpMap);
        }

        public long UpdateTanker(TankerData tankerData, UserOpMap userOpMap)
        {
            DAL_Tanker dAL_Tanker = new DAL_Tanker();
            Tanker tanker = new Tanker();
            DailyTankerReading dailyTankerReading = new DailyTankerReading();
            tanker.Id = tankerData.Id;
            tanker.Name = tankerData.Name;
            tanker.Description = tankerData.Description;
            tanker.Size = tankerData.Size;
            tanker.FuelTypeId = tankerData.FuelTypeID;
            dailyTankerReading.DailyStartReading = tankerData.DayStartReading;
            dailyTankerReading.DailyEndReading = tankerData.DayEndReading;
            return dAL_Tanker.UpdateTanker(tanker, dailyTankerReading, userOpMap);
        }
    }
}
