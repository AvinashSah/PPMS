using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
            DateTime today = DateTime.Now;
            using (var dbContext = new ppmsEntities())
            {
                dailyFuelCost = (from a in dbContext.DailyFuelCosts
                                 where a.IsActive == true && a.Date <= today
                                 orderby a.Date descending
                                 select a).ToList();
            }
            return dailyFuelCost;
        }



        public long UpdateFuel(Fuel fuel, DailyFuelCost dailyFuelCost, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Fuel fuelData = new Fuel();
                fuelData = (from a in dbContext.Fuels
                            where a.IsActive == true && a.Id == fuel.Id
                            select a).FirstOrDefault();
                fuelData.Description = fuel.Description;
                fuelData.Type = fuel.Type;
                dbContext.SaveChanges();

                dailyFuelCost.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                dailyFuelCost.Updatedby = Convert.ToInt64(userOpMap.UserID);
                dailyFuelCost.UpdatedOn = DateTime.Now;
                dailyFuelCost.CreatedOn = DateTime.Now;

                dbContext.DailyFuelCosts.Add(dailyFuelCost);
                dbContext.SaveChanges();//this generates the Id for customer
                return dailyFuelCost.Id;
            }
        }

        public long CreateFuel(Fuel fuel, DailyFuelCost dailyFuelCost, UserOpMap userOpMap)
        {
            using (var dbContext = new ppmsEntities())
            {
                Fuel fuelData = new Fuel();
                fuelData = (from a in dbContext.Fuels
                            where a.IsActive == true && a.Name == fuel.Name && a.Type == fuel.Type
                            select a).FirstOrDefault();
                if (fuelData == null)
                {
                    //Create Fuel
                    fuel.IsActive = true;
                    fuel.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    fuel.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    fuel.CreatedOn = DateTime.Now;
                    fuel.UpdatedOn = DateTime.Now;
                    dbContext.Fuels.Add(fuel);
                    dbContext.SaveChanges();
                    int fuelID = fuel.Id;

                    dailyFuelCost.CreatedBy = Convert.ToInt64(userOpMap.UserID);
                    dailyFuelCost.Updatedby = Convert.ToInt64(userOpMap.UserID);
                    dailyFuelCost.UpdatedOn = DateTime.Now;
                    dailyFuelCost.CreatedOn = DateTime.Now;
                    dailyFuelCost.FuelTypeId = fuelID;

                    dbContext.DailyFuelCosts.Add(dailyFuelCost);
                    dbContext.SaveChanges();//this generates the Id for customer
                    return dailyFuelCost.Id;
                }
                else
                {
                    throw new Exception("Fuel already exist !");
                }
            }
        }
    }
}
