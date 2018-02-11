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
    }
}
