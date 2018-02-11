using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPMS.ENTITIES;

namespace PPMS.DAL
{
    public class DAL_Fuel
    {
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

        public List<DailyFuelCost> GetDailyFuelCost()
        {
            List<DailyFuelCost> dailyFuelCost = new List<DailyFuelCost>();
            DateTime myDate = new DateTime();
            using (var dbContext = new ppmsEntities())
            {
                dailyFuelCost = (from a in dbContext.DailyFuelCosts
                                 where a.IsActive == true && a.Date == myDate
                                 select a).ToList();
            }
            return dailyFuelCost;
        }
    }
}
