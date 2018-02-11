using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;

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
            DateTime myDate = new DateTime();
            using (var dbContext = new ppmsEntities())
            {
                dailyDailyTankerReading = (from a in dbContext.DailyTankerReadings
                                 where a.IsActive == true && a.Date == myDate
                                 select a).ToList();
            }
            return dailyDailyTankerReading;
        }
    }
}
