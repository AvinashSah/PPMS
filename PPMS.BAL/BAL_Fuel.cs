using PPMS.DAL;
using PPMS.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.BAL
{
    public class BAL_Fuel
    {
        public List<Fuel> GetFuelList()
        {
            DAL_Fuel dAL_Fuel = new DAL_Fuel();
            return dAL_Fuel.GetFuelList();

        }

        public List<DailyFuelCost> GetDailyFuelCost()
        {
            DAL_Fuel dAL_Fuel = new DAL_Fuel();
            return dAL_Fuel.GetDailyFuelCost();
        }

        public long UpdateFuel(FuelData fuelData, UserOpMap userOpMap)
        {
            DAL_Fuel dAL_Fuel = new DAL_Fuel();
            Fuel fuel = new Fuel();
            DailyFuelCost dailyFuelCost = new DailyFuelCost();
            fuel.Id = fuelData.Id;
            fuel.Name = fuelData.Name;
            fuel.Description = fuelData.Description;
            dailyFuelCost.FuelTypeId = fuel.Id;
            dailyFuelCost.CostPerLiter = fuelData.CostPerLiter;
            return dAL_Fuel.UpdateFuel(fuel, dailyFuelCost, userOpMap);
        }

        public long CreateFuel(FuelData fuelData, UserOpMap userOpMap)
        {
            DAL_Fuel dAL_Fuel = new DAL_Fuel();
            Fuel fuel = new Fuel();
            DailyFuelCost dailyFuelCost = new DailyFuelCost();
            fuel.Name = fuelData.Name;
            fuel.Description = fuelData.Description;
            dailyFuelCost.CostPerLiter = fuelData.CostPerLiter;
            return dAL_Fuel.CreateFuel(fuel, dailyFuelCost, userOpMap);
        }
    }
}
