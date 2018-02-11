using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;

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
            DateTime myDate = new DateTime();
            using (var dbContext = new ppmsEntities())
            {
                dailyMeterReading = (from a in dbContext.DailyMeterReadings
                                 where a.IsActive == true && a.Date == myDate
                                 select a).ToList();
            }
            return dailyMeterReading;
        }
    }
}
